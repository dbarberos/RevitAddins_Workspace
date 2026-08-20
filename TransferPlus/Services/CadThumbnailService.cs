using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services
{
    /// <summary>
    /// Servicio para extracción y generación de miniaturas (thumbnails) de elementos CAD y Vistas de Diseño.
    /// </summary>
    public static class CadThumbnailService
    {
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject(IntPtr hObject);

        private static readonly ConcurrentDictionary<string, BitmapSource> _thumbnailCache = new();

        /// <summary>
        /// Obtiene la imagen en miniatura (thumbnail) de un elemento CAD o Vista de Diseño de manera asíncrona.
        /// </summary>
        public static async Task<BitmapSource?> GetPreviewImageAsync(CadDetailItemModel cadItem, CancellationToken cancellationToken)
        {
            if (cadItem == null) return null;

            if (cadItem.Thumbnail is BitmapSource existingBmp)
            {
                return existingBmp;
            }

            string cacheKey = $"{cadItem.SourceDocumentName}_{cadItem.DisplayCategory}_{cadItem.Name}_{cadItem.ElementId?.Value}";
            if (_thumbnailCache.TryGetValue(cacheKey, out var cachedBmp))
            {
                cadItem.Thumbnail = cachedBmp;
                return cachedBmp;
            }

            BitmapSource? result = null;

            try
            {
                Document? doc = cadItem.SourceDocument as Document;
                if (doc == null && cadItem.NativeElement is Element ne && ne.Document != null)
                {
                    doc = ne.Document;
                }

                // 1. CASO A: Elemento de Detalle individual 2D (FamilyInstance / FamilySymbol / Group)
                // -> Renderizar exclusivamente el elemento aislado en vista temporal con ImageExportOptions
                if ((cadItem.Category == "Detail Items" || cadItem.Category == "Details Groups" ||
                     cadItem.NativeElement is FamilyInstance || cadItem.NativeElement is FamilySymbol || cadItem.NativeElement is Group) &&
                    !(cadItem.NativeElement is ViewSheet) && !(cadItem.NativeElement is View) && cadItem.Category != "Sheet")
                {
                    if (doc != null && cadItem.ElementId != null && cadItem.ElementId != ElementId.InvalidElementId)
                    {
                        var revitService = new FamilyRevitService();
                        string? previewPath = revitService.GenerateElementPreview(doc, cadItem.ElementId, cadItem.OwnerViewId);
                        if (!string.IsNullOrWhiteSpace(previewPath) && System.IO.File.Exists(previewPath))
                        {
                            result = LoadBitmapFromPath(previewPath);
                        }
                    }

                    // Fallback: Si no se pudo generar con vista temporal, intentar GetPreviewImage nativo de Revit
                    if (result == null && cadItem.NativeElement is Element elem)
                    {
                        result = ExtractNativeElementThumbnail(elem, cancellationToken);
                    }
                }
                // 2. CASO B: Plano Completo (ViewSheet) o Vista Completa (View, ViewDrafting, Detail View, Detail Callout) o ImportInstance CAD
                else
                {
                    ElementId? viewId = null;

                    if (cadItem.NativeElement is ViewSheet vs)
                    {
                        viewId = vs.Id;
                    }
                    else if (cadItem.Category == "Sheet" && (cadItem.SheetId != null || cadItem.ElementId != null))
                    {
                        viewId = cadItem.SheetId ?? cadItem.ElementId;
                    }
                    else if (cadItem.NativeElement is View v)
                    {
                        viewId = v.Id;
                    }
                    else if (cadItem.NativeElement is ImportInstance cadInst)
                    {
                        viewId = cadInst.OwnerViewId;
                    }
                    else if (cadItem.IsDraftingView && cadItem.ElementId != null)
                    {
                        viewId = cadItem.ElementId;
                    }
                    else if (cadItem.OwnerViewId != null && cadItem.OwnerViewId != ElementId.InvalidElementId)
                    {
                        viewId = cadItem.OwnerViewId;
                    }

                    if (doc != null && viewId != null && viewId != ElementId.InvalidElementId)
                    {
                        var revitService = new FamilyRevitService();
                        string? previewPath = revitService.GenerateViewPreview(doc, viewId);
                        if (!string.IsNullOrWhiteSpace(previewPath) && System.IO.File.Exists(previewPath))
                        {
                            result = LoadBitmapFromPath(previewPath);
                        }
                    }
                }

                // 3. CASO C: Si aún es nulo y tenemos un Element nativo, intentar extracción nativa
                if (result == null && cadItem.NativeElement is Element genericElem && genericElem.Document != null)
                {
                    result = ExtractNativeElementThumbnail(genericElem, cancellationToken);
                }

                // 4. CASO D: Fallback visual: Generar icono gráfico vectorial 2D informativo
                if (result == null && !cancellationToken.IsCancellationRequested)
                {
                    result = CreateFallbackCadIcon(cadItem.Name, cadItem.DisplayCategory, cadItem.ViewName);
                }

                if (result != null)
                {
                    _thumbnailCache[cacheKey] = result;
                    cadItem.Thumbnail = result;
                }
            }
            catch (Exception ex)
            {
                LoggerService.LogError($"[CadThumbnailService] Error extrayendo miniatura para '{cadItem.Name}'", ex);
            }

            return result;
        }

        private static BitmapSource? LoadBitmapFromPath(string previewPath)
        {
            try
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bitmapImage.UriSource = new Uri(previewPath, UriKind.Absolute);
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                return bitmapImage;
            }
            catch (Exception loadEx)
            {
                LoggerService.LogWarning($"[CadThumbnailService] Error cargando BitmapImage desde '{previewPath}': {loadEx.Message}");
                return null;
            }
        }

        private static BitmapSource? ExtractNativeElementThumbnail(Element elem, CancellationToken ct)
        {
            try
            {
                if (ct.IsCancellationRequested || elem == null || !elem.IsValidObject) return null;

                Bitmap? bmp = null;

                // 1. Si elem es FamilyInstance, obtener el preview de su FamilySymbol (ElementType)
                if (elem is FamilyInstance fi)
                {
                    ElementType? symbol = fi.Symbol;
                    if (symbol == null && fi.GetTypeId() != ElementId.InvalidElementId && fi.Document != null)
                    {
                        symbol = fi.Document.GetElement(fi.GetTypeId()) as ElementType;
                    }

                    if (symbol != null && symbol.IsValidObject)
                    {
                        try
                        {
                            bmp = symbol.GetPreviewImage(new System.Drawing.Size(512, 512));
                        }
                        catch { }

                        if (bmp == null)
                        {
                            try
                            {
                                bmp = symbol.GetPreviewImage(new System.Drawing.Size(256, 256));
                            }
                            catch { }
                        }
                    }
                }

                // 2. Si elem es directamente ElementType
                if (bmp == null && elem is ElementType directType && directType.IsValidObject)
                {
                    try
                    {
                        bmp = directType.GetPreviewImage(new System.Drawing.Size(512, 512));
                    }
                    catch { }

                    if (bmp == null)
                    {
                        try
                        {
                            bmp = directType.GetPreviewImage(new System.Drawing.Size(256, 256));
                        }
                        catch { }
                    }
                }

                // 3. Si elem es una instancia genérica con TypeId asociado
                if (bmp == null && elem.GetTypeId() != ElementId.InvalidElementId && elem.Document != null)
                {
                    try
                    {
                        if (elem.Document.GetElement(elem.GetTypeId()) is ElementType typeObj && typeObj.IsValidObject)
                        {
                            bmp = typeObj.GetPreviewImage(new System.Drawing.Size(512, 512));
                            if (bmp == null)
                            {
                                bmp = typeObj.GetPreviewImage(new System.Drawing.Size(256, 256));
                            }
                        }
                    }
                    catch { }
                }

                if (bmp != null)
                {
                    using (bmp)
                    {
                        IntPtr hBitmap = bmp.GetHbitmap();
                        try
                        {
                            var bmpSource = Imaging.CreateBitmapSourceFromHBitmap(
                                hBitmap,
                                IntPtr.Zero,
                                Int32Rect.Empty,
                                BitmapSizeOptions.FromEmptyOptions());
                            bmpSource.Freeze();
                            return bmpSource;
                        }
                        finally
                        {
                            DeleteObject(hBitmap);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.LogWarning($"[CadThumbnailService] Extracción nativa devolvió error para '{elem.Name}': {ex.Message}");
            }

            return null;
        }

        private static BitmapSource CreateFallbackCadIcon(string name, string category, string viewName)
        {
            int width = 256;
            int height = 256;
            using (var bmp = new Bitmap(width, height))
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Fondo suave
                using (var bgBrush = new SolidBrush(System.Drawing.Color.FromArgb(248, 249, 250)))
                {
                    g.FillRectangle(bgBrush, 0, 0, width, height);
                }

                // Borde exterior
                using (var borderPen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(220, 224, 230), 2))
                {
                    g.DrawRectangle(borderPen, 1, 1, width - 2, height - 2);
                }

                // Barra superior de categoría
                System.Drawing.Color bannerColor = category.Contains("Links") ? System.Drawing.Color.FromArgb(0, 122, 204) : 
                                   (category.Contains("Drafting") ? System.Drawing.Color.FromArgb(16, 124, 65) : System.Drawing.Color.FromArgb(180, 70, 0));
                using (var bannerBrush = new SolidBrush(bannerColor))
                {
                    g.FillRectangle(bannerBrush, 0, 0, width, 40);
                }

                // Texto de Categoría
                using (var bannerFont = new Font("Segoe UI", 11, System.Drawing.FontStyle.Bold))
                using (var bannerTextBrush = new SolidBrush(System.Drawing.Color.White))
                {
                    var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(category.ToUpperInvariant(), bannerFont, bannerTextBrush, new RectangleF(0, 0, width, 40), format);
                }

                // Rejilla de plano técnico (CAD Grid)
                using (var gridPen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(235, 238, 242), 1))
                {
                    for (int x = 20; x < width - 20; x += 20)
                    {
                        g.DrawLine(gridPen, x, 50, x, height - 50);
                    }
                    for (int y = 50; y < height - 50; y += 20)
                    {
                        g.DrawLine(gridPen, 20, y, width - 20, y);
                    }
                }

                // Geometría CAD esquemática centrada
                using (var shapePen = new System.Drawing.Pen(bannerColor, 2))
                {
                    g.DrawRectangle(shapePen, 50, 65, 156, 85);
                    g.DrawLine(shapePen, 50, 65, 206, 150);
                    g.DrawLine(shapePen, 50, 150, 206, 65);
                    g.DrawEllipse(shapePen, 98, 77, 60, 60);
                }

                // Nombre y Ubicación en la parte inferior
                using (var titleFont = new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold))
                using (var subFont = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular))
                using (var textBrush = new SolidBrush(System.Drawing.Color.FromArgb(40, 40, 40)))
                using (var subBrush = new SolidBrush(System.Drawing.Color.FromArgb(100, 100, 100)))
                {
                    var format = new StringFormat { Alignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter };
                    g.DrawString(name, titleFont, textBrush, new RectangleF(10, 168, width - 20, 42), format);

                    string location = !string.IsNullOrWhiteSpace(viewName) ? $"View: {viewName}" : "Model-wide";
                    g.DrawString(location, subFont, subBrush, new RectangleF(10, 215, width - 20, 28), format);
                }

                IntPtr hBitmap = bmp.GetHbitmap();
                try
                {
                    var bmpSource = Imaging.CreateBitmapSourceFromHBitmap(
                        hBitmap,
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
                    bmpSource.Freeze();
                    return bmpSource;
                }
                finally
                {
                    DeleteObject(hBitmap);
                }
            }
        }
    }
}
