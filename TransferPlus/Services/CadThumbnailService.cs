using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Linq;
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

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int SHCreateItemFromParsingName(
            [MarshalAs(UnmanagedType.LPWStr)] string pszPath,
            IntPtr pbc,
            ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem ppv);

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
        private interface IShellItem
        {
            void BindToHandler(IntPtr pbc, ref Guid bhid, ref Guid riid, out IntPtr ppv);
            void GetParent(out IShellItem ppsi);
            void GetDisplayName(uint sigdnName, out IntPtr ppszName);
            void GetAttributes(uint sfgaoMask, out uint psfgaoAttribs);
            void Compare(IShellItem psi, uint hint, out int piOrder);
        }

        [ComImport]
        [Guid("bcc18b79-ba16-442f-80c4-8a59c30c463b")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IShellItemImageFactory
        {
            [PreserveSig]
            int GetImage([In, MarshalAs(UnmanagedType.Struct)] SIZE size, [In] SIIGBF flags, [Out] out IntPtr phbm);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SIZE
        {
            public int cx;
            public int cy;
        }

        [Flags]
        private enum SIIGBF
        {
            SIIGBF_RESIZETOFIT = 0x00,
            SIIGBF_BIGGERSIZEOK = 0x01,
            SIIGBF_MEMORYONLY = 0x02,
            SIIGBF_ICONONLY = 0x04,
            SIIGBF_THUMBNAILONLY = 0x08,
            SIIGBF_INCACHEONLY = 0x10,
            SIIGBF_CROPTOSQUARE = 0x20,
            SIIGBF_WIDEOK = 0x40,
            SIIGBF_ICONBACKGROUND = 0x80,
            SIIGBF_SCALEUP = 0x100
        }

        private static readonly ConcurrentDictionary<string, BitmapSource> _thumbnailCache = new();

        public static Autodesk.Revit.ApplicationServices.Application? CurrentApplication { get; set; }
        public static Document? ActiveDocument { get; set; }

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
                Document? doc = cadItem.SourceDocument as Document ?? ActiveDocument;
                if (doc == null && cadItem.NativeElement is Element ne && ne.Document != null)
                {
                    doc = ne.Document;
                }

                // 0. CASO EXTERNO: Archivo CAD externo de disco o nube (.dwg, .dxf, .sat, etc.)
                if (cadItem.IsExternalFile)
                {
                    string? diskPath = await EnsureLocalCadFileAsync(cadItem, cancellationToken);
                    if (!string.IsNullOrWhiteSpace(diskPath) && System.IO.File.Exists(diskPath))
                    {
                        // Estrategia A: Renderizado en memoria en DraftingView temporal de Revit (RollBack)
                        if (doc != null)
                        {
                            var revitService = new FamilyRevitService();
                            string? previewPath = revitService.GenerateExternalCadPreview(doc, diskPath);
                            if (!string.IsNullOrWhiteSpace(previewPath) && System.IO.File.Exists(previewPath))
                            {
                                result = LoadBitmapFromPath(previewPath);
                            }
                        }

                        // Estrategia B: Extracción nativa de thumbnail por Windows Shell (DWG / SKP shell extension)
                        if (result == null && !cancellationToken.IsCancellationRequested)
                        {
                            result = await Task.Run(() =>
                            {
                                if (cancellationToken.IsCancellationRequested) return null;
                                return ExtractShellThumbnail(diskPath, 256);
                            }, cancellationToken);
                        }
                    }

                    // Estrategia C: Fallback gráfico informativo
                    if (result == null && !cancellationToken.IsCancellationRequested)
                    {
                        string info = !string.IsNullOrWhiteSpace(cadItem.SourceDocumentName) ? cadItem.SourceDocumentName : cadItem.Format.ToUpperInvariant();
                        result = CreateFallbackCadIcon(cadItem.Name, cadItem.DisplayCategory, info);
                    }
                }
                // 1. CASO A: Elemento de Detalle individual 2D (FamilyInstance / FamilySymbol / Group / GroupType / FilledRegion)
                // -> Renderizar exclusivamente el elemento aislado en vista temporal con ImageExportOptions y RollBack
                else if ((cadItem.Category == "Detail Items" || cadItem.Category == "Detail Groups" || cadItem.Category == "Details Groups" ||
                     cadItem.NativeElement is FamilyInstance || cadItem.NativeElement is FamilySymbol || cadItem.NativeElement is Group || cadItem.NativeElement is GroupType || cadItem.NativeElement is FilledRegion) &&
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

                    // Fallback A2: Si es una familia/símbolo, intentar renderizado directo de familia
                    if (result == null && !cancellationToken.IsCancellationRequested)
                    {
                        var revitService = new FamilyRevitService();
                        if (cadItem.NativeElement is FamilySymbol sym && sym.Family != null)
                        {
                            string? famPath = revitService.GenerateFamilyRenderedPreview(sym.Family, ActiveDocument);
                            if (!string.IsNullOrWhiteSpace(famPath) && System.IO.File.Exists(famPath))
                            {
                                result = LoadBitmapFromPath(famPath);
                            }
                        }
                        else if (cadItem.NativeElement is FamilyInstance fi && fi.Symbol != null && fi.Symbol.Family != null)
                        {
                            string? famPath = revitService.GenerateFamilyRenderedPreview(fi.Symbol.Family, ActiveDocument);
                            if (!string.IsNullOrWhiteSpace(famPath) && System.IO.File.Exists(famPath))
                            {
                                result = LoadBitmapFromPath(famPath);
                            }
                        }
                    }

                    // Fallback A3: Si no se pudo generar con vista temporal, intentar GetPreviewImage nativo de Revit
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

        private static async Task<string?> EnsureLocalCadFileAsync(CadDetailItemModel cadItem, CancellationToken ct)
        {
            if (cadItem == null) return null;

            if (!string.IsNullOrWhiteSpace(cadItem.FilePath) && File.Exists(cadItem.FilePath))
            {
                return cadItem.FilePath;
            }

            try
            {
                var sources = CadSourceConfigService.LoadSources();
                var source = sources.FirstOrDefault(s => s.Name.Equals(cadItem.SourceDocumentName, StringComparison.OrdinalIgnoreCase))
                             ?? sources.FirstOrDefault(s => s.SourceType == cadItem.SourceType);

                if (source == null) return null;

                if (source.SourceType == CadSourceType.AzureStorage)
                {
                    string blobName = cadItem.FilePath;
                    string downloaded = AzureStorageService.DownloadCadBlob(source.ConnectionString, source.ContainerName, blobName);
                    if (File.Exists(downloaded))
                    {
                        cadItem.FilePath = downloaded;
                        return downloaded;
                    }
                }
                else if (source.SourceType == CadSourceType.AwsS3)
                {
                    string objectKey = cadItem.FilePath;
                    string downloaded = await AwsS3StorageService.DownloadCadBlobAsync(source, objectKey);
                    if (File.Exists(downloaded))
                    {
                        cadItem.FilePath = downloaded;
                        return downloaded;
                    }
                }
                else if (source.SourceType == CadSourceType.AutodeskDocs)
                {
                    string itemId = cadItem.FilePath;
                    string accessToken = source.AccessToken;
                    if (string.IsNullOrWhiteSpace(accessToken) && !string.IsNullOrWhiteSpace(source.RefreshToken))
                    {
                        var refreshRes = await AutodeskDocsService.RefreshTokenAsync(source.RefreshToken, source.ClientId, ct);
                        if (refreshRes.Success)
                        {
                            accessToken = refreshRes.AccessToken;
                            source.AccessToken = refreshRes.AccessToken;
                            source.RefreshToken = refreshRes.RefreshToken;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(accessToken))
                    {
                        string? downloadUrl = await AutodeskDocsService.GetLatestVersionDownloadUrlAsync(accessToken, source.ProjectId, itemId, ct);
                        if (!string.IsNullOrWhiteSpace(downloadUrl))
                        {
                            string rawFileName = !string.IsNullOrWhiteSpace(cadItem.ViewName) ? cadItem.ViewName : $"{cadItem.Name}.{(string.IsNullOrWhiteSpace(cadItem.Format) ? "dwg" : cadItem.Format)}";
                            string downloaded = await AutodeskDocsService.DownloadAccFamilyFileAsync(accessToken, downloadUrl, rawFileName, ct);
                            if (File.Exists(downloaded))
                            {
                                cadItem.FilePath = downloaded;
                                return downloaded;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.LogWarning($"[CadThumbnailService] Error descargando archivo CAD en segundo plano para miniatura: {ex.Message}");
            }

            return null;
        }

        private static BitmapSource? ExtractShellThumbnail(string filePath, int size)
        {
            try
            {
                Guid itemGuid = new Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe"); // IShellItem
                SHCreateItemFromParsingName(filePath, IntPtr.Zero, ref itemGuid, out IShellItem shellItem);

                if (shellItem is IShellItemImageFactory imageFactory)
                {
                    imageFactory.GetImage(new SIZE { cx = size, cy = size }, SIIGBF.SIIGBF_CROPTOSQUARE | SIIGBF.SIIGBF_SCALEUP, out IntPtr hBitmap);
                    if (hBitmap != IntPtr.Zero)
                    {
                        try
                        {
                            var bmpSource = Imaging.CreateBitmapSourceFromHBitmap(
                                hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
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
                LoggerService.LogInfo($"[CadThumbnailService] Shell thumbnail extraction falló para '{filePath}': {ex.Message}");
            }
            return null;
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
