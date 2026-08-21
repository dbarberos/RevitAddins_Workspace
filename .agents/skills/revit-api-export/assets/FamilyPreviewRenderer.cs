using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddin.ExportHelpers
{
    /// <summary>
    /// Utility class for generating dynamic 2D and 3D previews for any Revit Family, Tag, Detail Item, or Title Block.
    /// Features:
    /// - In-memory EditFamily inspection.
    /// - Dedicated ViewSheet hosting for Title Blocks.
    /// - Reference plane & dimension suppression to prevent excessive zoom extents.
    /// - Automatic pixel-level Auto-Crop and Zoom-to-Extents framing (OptimizeImageFraming).
    /// </summary>
    public static class FamilyPreviewRenderer
    {
        public static string? GenerateFamilyPreview(Family nativeFam, Document? targetDoc = null)
        {
            if (nativeFam == null || !nativeFam.IsValidObject) return null;
            Document? doc = nativeFam.Document ?? targetDoc;
            if (doc == null) return null;

            string tempDir = Path.Combine(Path.GetTempPath(), "Revit_Previews", Guid.NewGuid().ToString("N"));
            if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);
            string baseFilePath = Path.Combine(tempDir, "preview");

            // Strategy 1: EditFamily in memory
            if (nativeFam.IsEditable)
            {
                Document? famDoc = null;
                try
                {
                    famDoc = doc.EditFamily(nativeFam);
                    if (famDoc != null)
                    {
                        View? exportView = new FilteredElementCollector(famDoc)
                            .OfClass(typeof(View3D))
                            .Cast<View3D>()
                            .FirstOrDefault(v => !v.IsTemplate && !v.IsPerspective)
                            ?? (View?)new FilteredElementCollector(famDoc).OfClass(typeof(ViewPlan)).Cast<ViewPlan>().FirstOrDefault(v => !v.IsTemplate)
                            ?? (View?)new FilteredElementCollector(famDoc).OfClass(typeof(ViewDrafting)).Cast<ViewDrafting>().FirstOrDefault(v => !v.IsTemplate)
                            ?? famDoc.ActiveView;

                        if (exportView != null)
                        {
                            HideReferencePlanesAndAnnotations(famDoc, exportView);

                            var options = new ImageExportOptions
                            {
                                ExportRange = ExportRange.SetOfViews,
                                ZoomType = ZoomFitType.FitToPage,
                                PixelSize = 512,
                                ImageResolution = ImageResolution.DPI_72,
                                ShadowViewsFileType = ImageFileType.PNG,
                                HLRandWFViewsFileType = ImageFileType.PNG,
                                FilePath = baseFilePath,
                                FitDirection = FitDirectionType.Horizontal
                            };
                            options.SetViewsAndSheets(new List<ElementId> { exportView.Id });
                            famDoc.ExportImage(options);

                            var files = Directory.GetFiles(tempDir, "*.png");
                            if (files.Length > 0)
                            {
                                OptimizeImageFraming(files[0]);
                                return files[0];
                            }
                        }
                    }
                }
                catch { }
                finally
                {
                    try { famDoc?.Close(false); } catch { }
                }
            }

            // Strategy 2: Scratch View with Rollback Transaction
            var symIds = nativeFam.GetFamilySymbolIds();
            if (symIds.Count == 0) return null;
            var symbol = doc.GetElement(symIds.First()) as FamilySymbol;
            if (symbol == null) return null;

            bool isTitleBlock = false;
            if (nativeFam.FamilyCategory != null && (BuiltInCategory)nativeFam.FamilyCategory.Id.Value == BuiltInCategory.OST_TitleBlocks)
                isTitleBlock = true;

            Document workDoc = doc.IsReadOnly && targetDoc != null && !targetDoc.IsReadOnly ? targetDoc : doc;
            if (workDoc.IsReadOnly) return null;

            using (var tx = new Transaction(workDoc, "Generate Family Preview"))
            {
                tx.Start();
                try
                {
                    View? tempView = null;
                    Element? placedElem = null;

                    if (isTitleBlock)
                    {
                        var tempSheet = ViewSheet.Create(workDoc, ElementId.InvalidElementId);
                        tempSheet.Name = $"_TempSheet_{Guid.NewGuid():N}";
                        tempSheet.SheetNumber = $"ZZ_{Guid.NewGuid():N}".Substring(0, 8);
                        tempView = tempSheet;

                        FamilySymbol workSym = symbol;
                        if (workDoc != doc)
                        {
                            var copiedIds = ElementTransformUtils.CopyElements(doc, new List<ElementId> { symbol.Id }, workDoc, Transform.Identity, new CopyPasteOptions());
                            if (copiedIds.Count > 0 && workDoc.GetElement(copiedIds.First()) is FamilySymbol cs) workSym = cs;
                        }
                        if (!workSym.IsActive) workSym.Activate();
                        placedElem = workDoc.Create.NewFamilyInstance(XYZ.Zero, workSym, tempSheet);
                    }
                    else
                    {
                        var draftingType = new FilteredElementCollector(workDoc)
                            .OfClass(typeof(ViewFamilyType))
                            .Cast<ViewFamilyType>()
                            .FirstOrDefault(vft => vft.ViewFamily == ViewFamily.Drafting);

                        if (draftingType != null)
                        {
                            var vDraft = ViewDrafting.Create(workDoc, draftingType.Id);
                            vDraft.Name = $"_Temp2D_{Guid.NewGuid():N}";
                            tempView = vDraft;
                            FamilySymbol workSym = symbol;
                            if (workDoc != doc)
                            {
                                var copiedIds = ElementTransformUtils.CopyElements(doc, new List<ElementId> { symbol.Id }, workDoc, Transform.Identity, new CopyPasteOptions());
                                if (copiedIds.Count > 0 && workDoc.GetElement(copiedIds.First()) is FamilySymbol cs) workSym = cs;
                            }
                            if (!workSym.IsActive) workSym.Activate();
                            placedElem = workDoc.Create.NewFamilyInstance(XYZ.Zero, workSym, vDraft);
                        }
                    }

                    if (tempView != null)
                    {
                        workDoc.Regenerate();

                        if (placedElem != null && (tempView is ViewDrafting || tempView is ViewPlan))
                        {
                            try
                            {
                                var bbox = placedElem.get_BoundingBox(tempView);
                                if (bbox != null && Math.Abs(bbox.Max.X - bbox.Min.X) > 1e-4)
                                {
                                    double marginX = Math.Max((bbox.Max.X - bbox.Min.X) * 0.08, 0.02);
                                    double marginY = Math.Max((bbox.Max.Y - bbox.Min.Y) * 0.08, 0.02);
                                    var crop = tempView.CropBox;
                                    crop.Min = new XYZ(bbox.Min.X - marginX, bbox.Min.Y - marginY, crop.Min.Z);
                                    crop.Max = new XYZ(bbox.Max.X + marginX, bbox.Max.Y + marginY, crop.Max.Z);
                                    tempView.CropBox = crop;
                                    tempView.CropBoxActive = true;
                                    tempView.CropBoxVisible = false;
                                }
                            }
                            catch { }
                        }

                        var options = new ImageExportOptions
                        {
                            ExportRange = ExportRange.SetOfViews,
                            ZoomType = ZoomFitType.FitToPage,
                            PixelSize = 512,
                            ImageResolution = ImageResolution.DPI_72,
                            ShadowViewsFileType = ImageFileType.PNG,
                            HLRandWFViewsFileType = ImageFileType.PNG,
                            FilePath = baseFilePath,
                            FitDirection = FitDirectionType.Horizontal
                        };
                        options.SetViewsAndSheets(new List<ElementId> { tempView.Id });
                        workDoc.ExportImage(options);

                        var files = Directory.GetFiles(tempDir, "*.png");
                        if (files.Length > 0)
                        {
                            OptimizeImageFraming(files[0]);
                            return files[0];
                        }
                    }
                }
                catch { }
                finally
                {
                    if (tx.HasStarted() && !tx.HasEnded()) tx.RollBack();
                }
            }

            return null;
        }

        public static string? GenerateRfaPreview(string rfaPath, Autodesk.Revit.ApplicationServices.Application app)
        {
            if (string.IsNullOrWhiteSpace(rfaPath) || !File.Exists(rfaPath) || app == null) return null;
            string tempDir = Path.Combine(Path.GetTempPath(), "Revit_Previews", Guid.NewGuid().ToString("N"));
            if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);
            string baseFilePath = Path.Combine(tempDir, "preview");

            Document? rfaDoc = null;
            try
            {
                rfaDoc = app.OpenDocumentFile(rfaPath);
                if (rfaDoc == null) return null;

                View? exportView = new FilteredElementCollector(rfaDoc)
                    .OfClass(typeof(View3D))
                    .Cast<View3D>()
                    .FirstOrDefault(v => !v.IsTemplate && !v.IsPerspective)
                    ?? (View?)new FilteredElementCollector(rfaDoc).OfClass(typeof(ViewPlan)).Cast<ViewPlan>().FirstOrDefault(v => !v.IsTemplate)
                    ?? rfaDoc.ActiveView;

                if (exportView != null)
                {
                    HideReferencePlanesAndAnnotations(rfaDoc, exportView);

                    var options = new ImageExportOptions
                    {
                        ExportRange = ExportRange.SetOfViews,
                        ZoomType = ZoomFitType.FitToPage,
                        PixelSize = 512,
                        ImageResolution = ImageResolution.DPI_72,
                        ShadowViewsFileType = ImageFileType.PNG,
                        HLRandWFViewsFileType = ImageFileType.PNG,
                        FilePath = baseFilePath,
                        FitDirection = FitDirectionType.Horizontal
                    };
                    options.SetViewsAndSheets(new List<ElementId> { exportView.Id });
                    rfaDoc.ExportImage(options);

                    var files = Directory.GetFiles(tempDir, "*.png");
                    if (files.Length > 0)
                    {
                        OptimizeImageFraming(files[0]);
                        return files[0];
                    }
                }
            }
            catch { }
            finally
            {
                try { rfaDoc?.Close(false); } catch { }
            }
            return null;
        }

        public static void HideReferencePlanesAndAnnotations(Document doc, View view)
        {
            if (doc == null || view == null) return;
            try
            {
                var categoriesToHide = new[]
                {
                    BuiltInCategory.OST_CLines,
                    BuiltInCategory.OST_ReferenceLines,
                    BuiltInCategory.OST_Dimensions,
                    BuiltInCategory.OST_Grids,
                    BuiltInCategory.OST_Levels
                };

                foreach (var bic in categoriesToHide)
                {
                    try
                    {
                        var cat = doc.Settings.Categories.get_Item(bic);
                        if (cat != null && view.CanEnableTemporaryViewPropertiesMode())
                        {
                            view.SetCategoryHidden(cat.Id, true);
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        public static void OptimizeImageFraming(string imagePath, int targetSize = 512, double paddingFactor = 0.08)
        {
            if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath)) return;

            try
            {
                using (var original = new Bitmap(imagePath))
                {
                    int width = original.Width;
                    int height = original.Height;
                    if (width <= 10 || height <= 10) return;

                    int minX = width, minY = height, maxX = 0, maxY = 0;
                    bool foundContent = false;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            var pixel = original.GetPixel(x, y);
                            if (pixel.A > 20 && (pixel.R < 248 || pixel.G < 248 || pixel.B < 248))
                            {
                                if (x < minX) minX = x;
                                if (x > maxX) maxX = x;
                                if (y < minY) minY = y;
                                if (y > maxY) maxY = y;
                                foundContent = true;
                            }
                        }
                    }

                    if (!foundContent) return;

                    int contentWidth = (maxX - minX) + 1;
                    int contentHeight = (maxY - minY) + 1;

                    if (contentWidth >= width * 0.85 && contentHeight >= height * 0.85) return;

                    using (var cropped = new Bitmap(contentWidth, contentHeight))
                    {
                        using (var gCrop = Graphics.FromImage(cropped))
                        {
                            gCrop.DrawImage(original, new Rectangle(0, 0, contentWidth, contentHeight),
                                new Rectangle(minX, minY, contentWidth, contentHeight),
                                GraphicsUnit.Pixel);
                        }

                        using (var final = new Bitmap(targetSize, targetSize))
                        {
                            using (var gFinal = Graphics.FromImage(final))
                            {
                                gFinal.Clear(Color.White);
                                gFinal.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                gFinal.SmoothingMode = SmoothingMode.HighQuality;
                                gFinal.PixelOffsetMode = PixelOffsetMode.HighQuality;

                                int padding = (int)(targetSize * paddingFactor);
                                int availSize = targetSize - (padding * 2);

                                double scale = Math.Min((double)availSize / contentWidth, (double)availSize / contentHeight);
                                int destWidth = Math.Max(1, (int)(contentWidth * scale));
                                int destHeight = Math.Max(1, (int)(contentHeight * scale));

                                int destX = padding + (availSize - destWidth) / 2;
                                int destY = padding + (availSize - destHeight) / 2;

                                gFinal.DrawImage(cropped, new Rectangle(destX, destY, destWidth, destHeight));
                            }

                            string tempSave = imagePath + ".tmp.png";
                            final.Save(tempSave, ImageFormat.Png);
                            File.Copy(tempSave, imagePath, true);
                            try { File.Delete(tempSave); } catch { }
                        }
                    }
                }
            }
            catch { }
        }
    }
}
