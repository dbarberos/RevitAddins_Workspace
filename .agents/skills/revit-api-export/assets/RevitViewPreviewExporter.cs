using System;
using System.Collections.Generic;
using System.IO;
using Autodesk.Revit.DB;

namespace RevitAddin.ExportHelpers
{
    /// <summary>
    /// Utility class to export native Revit view previews into lightweight PNG files.
    /// </summary>
    public static class RevitViewPreviewExporter
    {
        public static string? ExportViewThumbnail(Document doc, ElementId viewId, int pixelSize = 512)
        {
            if (doc == null || viewId == null || viewId == ElementId.InvalidElementId) return null;

            try
            {
                var view = doc.GetElement(viewId) as View;
                if (view == null || view.IsTemplate) return null;

                string tempDir = Path.Combine(Path.GetTempPath(), "RevitViewPreviews", Guid.NewGuid().ToString("N"));
                tempDir = Path.GetFullPath(tempDir);
                if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);

                string baseFilePath = Path.Combine(tempDir, "preview");
                baseFilePath = Path.GetFullPath(baseFilePath);

                var options = new ImageExportOptions
                {
                    ExportRange = ExportRange.SetOfViews,
                    ZoomType = ZoomFitType.FitToPage,
                    PixelSize = pixelSize,
                    ImageResolution = ImageResolution.DPI_72,
                    ShadowViewsFileType = ImageFileType.PNG,
                    HLRandWFViewsFileType = ImageFileType.PNG,
                    FilePath = baseFilePath,
                    FitDirection = FitDirectionType.Horizontal
                };

                options.SetViewsAndSheets(new List<ElementId> { viewId });
                doc.ExportImage(options);

                var files = Directory.GetFiles(tempDir, "*.png");
                return files.Length > 0 ? files[0] : null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Exports an isolated 2D element (Detail Item, FamilySymbol, Group) preview by creating a scratch DraftingView,
        /// instantiating/copying the single element, exporting via ImageExportOptions (FitToPage), and rolling back the transaction.
        /// </summary>
        public static string? ExportIsolatedElementThumbnail(Document doc, ElementId elementId, ElementId? ownerViewId = null, int pixelSize = 512)
        {
            if (doc == null || elementId == null || elementId == ElementId.InvalidElementId) return null;

            try
            {
                var elem = doc.GetElement(elementId);
                if (elem == null) return null;

                var draftingType = new FilteredElementCollector(doc)
                    .OfClass(typeof(ViewFamilyType))
                    .Cast<ViewFamilyType>()
                    .FirstOrDefault(vft => vft.ViewFamily == ViewFamily.Drafting);

                if (draftingType == null) return null;

                string tempDir = Path.Combine(Path.GetTempPath(), "RevitElementPreviews", Guid.NewGuid().ToString("N"));
                tempDir = Path.GetFullPath(tempDir);
                if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);

                string baseFilePath = Path.Combine(tempDir, "preview");
                baseFilePath = Path.GetFullPath(baseFilePath);

                string? resultPath = null;

                using (var tx = new Transaction(doc, "Generate Isolated Preview"))
                {
                    var failOpt = tx.GetFailureHandlingOptions();
                    tx.SetFailureHandlingOptions(failOpt);
                    tx.Start();

                    try
                    {
                        var tempView = ViewDrafting.Create(doc, draftingType.Id);
                        tempView.Name = $"_TempPreview_{Guid.NewGuid():N}";
                        tempView.Scale = 1;

                        if (elem is FamilyInstance fi && fi.Symbol != null)
                        {
                            if (!fi.Symbol.IsActive) fi.Symbol.Activate();
                            doc.Create.NewFamilyInstance(XYZ.Zero, fi.Symbol, tempView);
                        }
                        else if (elem is FamilySymbol sym)
                        {
                            if (!sym.IsActive) sym.Activate();
                            doc.Create.NewFamilyInstance(XYZ.Zero, sym, tempView);
                        }
                        else if (ownerViewId != null && ownerViewId != ElementId.InvalidElementId && doc.GetElement(ownerViewId) is View srcView)
                        {
                            ElementTransformUtils.CopyElements(srcView, new List<ElementId> { elem.Id }, tempView, Transform.Identity, new CopyPasteOptions());
                        }

                        doc.Regenerate();

                        var options = new ImageExportOptions
                        {
                            ExportRange = ExportRange.SetOfViews,
                            ZoomType = ZoomFitType.FitToPage,
                            PixelSize = pixelSize,
                            ImageResolution = ImageResolution.DPI_72,
                            ShadowViewsFileType = ImageFileType.PNG,
                            HLRandWFViewsFileType = ImageFileType.PNG,
                            FilePath = baseFilePath,
                            FitDirection = FitDirectionType.Horizontal
                        };

                        options.SetViewsAndSheets(new List<ElementId> { tempView.Id });
                        doc.ExportImage(options);

                        var files = Directory.GetFiles(tempDir, "*.png");
                        if (files.Length > 0) resultPath = files[0];
                    }
                    finally
                    {
                        if (tx.HasStarted() && !tx.HasEnded()) tx.RollBack();
                    }
                }

                return resultPath;
            }
            catch
            {
                return null;
            }
        }
    }
}
