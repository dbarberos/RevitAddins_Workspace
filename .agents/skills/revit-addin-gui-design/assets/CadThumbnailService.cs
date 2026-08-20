using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Autodesk.Revit.DB;

namespace RevitAddin.GuiAssets
{
    /// <summary>
    /// Reusable service for asynchronous view and CAD detail thumbnail generation, caching, and multi-tier fallbacks.
    /// </summary>
    public static class CadThumbnailService
    {
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject(IntPtr hObject);

        private static readonly ConcurrentDictionary<string, BitmapSource> _thumbnailCache = new();

        public static async Task<BitmapSource?> GetViewThumbnailAsync(Document doc, ElementId viewId, string cacheKey, CancellationToken ct)
        {
            if (doc == null || viewId == null || viewId == ElementId.InvalidElementId) return null;

            if (_thumbnailCache.TryGetValue(cacheKey, out var cached)) return cached;

            BitmapSource? result = null;

            try
            {
                var view = doc.GetElement(viewId) as View;
                if (view != null && !view.IsTemplate)
                {
                    string tempDir = Path.Combine(Path.GetTempPath(), "ViewThumbnails", Guid.NewGuid().ToString("N"));
                    tempDir = Path.GetFullPath(tempDir);
                    if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);

                    string baseFilePath = Path.Combine(tempDir, "preview");
                    var options = new ImageExportOptions
                    {
                        ExportRange = ExportRange.SetOfViews,
                        ZoomType = ZoomFitType.FitToPage,
                        PixelSize = 512,
                        ImageResolution = ImageResolution.DPI_72,
                        ShadowViewsFileType = ImageFileType.PNG,
                        HLRandWFViewsFileType = ImageFileType.PNG,
                        FilePath = baseFilePath
                    };
                    options.SetViewsAndSheets(new List<ElementId> { viewId });
                    doc.ExportImage(options);

                    var files = Directory.GetFiles(tempDir, "*.png");
                    if (files.Length > 0 && File.Exists(files[0]))
                    {
                        var bmp = new BitmapImage();
                        bmp.BeginInit();
                        bmp.CacheOption = BitmapCacheOption.OnLoad;
                        bmp.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                        bmp.UriSource = new Uri(files[0], UriKind.Absolute);
                        bmp.EndInit();
                        bmp.Freeze();
                        result = bmp;
                    }
                }

                if (result != null)
                {
                    _thumbnailCache[cacheKey] = result;
                }
            }
            catch { }

            return result;
        }
    }
}
