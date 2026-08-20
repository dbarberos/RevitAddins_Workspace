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
    }
}
