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
using TransferPlus.Models;
using System.Linq;

namespace TransferPlus.Services
{
    public static class FamilyThumbnailService
    {
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject(IntPtr hObject);

        private static readonly ConcurrentDictionary<string, BitmapSource> _thumbnailCache = new();

        /// <summary>
        /// Extracts a preview image for the given family model.
        /// IMPORTANT: TransferPlus opens as a MODAL dialog (ShowDialog), which means Revit's
        /// idle loop never fires and ExternalEvent/RevitTask will NEVER complete.
        /// Therefore, for native families we extract the preview SYNCHRONOUSLY on the
        /// WPF dispatcher thread (which IS the Revit API thread in a modal dialog context).
        /// Shell extraction for disk files runs on a background thread.
        /// </summary>
        public static async Task<BitmapSource?> GetPreviewImageAsync(FamilyItemModel family, CancellationToken cancellationToken)
        {
            if (family == null) return null;

            // 1. Return immediately if family model already has cached thumbnail
            if (family.Thumbnail is BitmapSource existingBmp)
            {
                LoggerService.LogInfo($"[ThumbnailService] Instant cache hit from FamilyItemModel for '{family.Name}'.");
                return existingBmp;
            }

            // 2. Check static session cache
            string cacheKey = $"{family.SourceName}_{family.Name}";
            if (_thumbnailCache.TryGetValue(cacheKey, out var cachedBmp))
            {
                family.Thumbnail = cachedBmp;
                LoggerService.LogInfo($"[ThumbnailService] Instant cache hit from session dictionary for '{family.Name}'.");
                return cachedBmp;
            }

            try
            {
                BitmapSource? result = null;

                // --- Strategy A: Native Revit Family (synchronous on current thread) ---
                if (family.NativeFamily is Family nativeFam && nativeFam.Document != null)
                {
                    LoggerService.LogInfo($"[ThumbnailService] Extracting preview SYNCHRONOUSLY for native family '{family.Name}'...");
                    result = ExtractNativeFamilyThumbnail(nativeFam, cancellationToken);
                }

                // --- Strategy B1: Direct RFA OLE PNG stream extraction for disk files ---
                if (result == null && !cancellationToken.IsCancellationRequested)
                {
                    string? diskPath = ResolveDiskPath(family);
                    if (!string.IsNullOrEmpty(diskPath) && File.Exists(diskPath))
                    {
                        LoggerService.LogInfo($"[ThumbnailService] Executing direct RFA stream extraction for '{diskPath}'...");
                        result = ExtractRfaFileThumbnail(diskPath);
                    }
                }

                // --- Strategy B2: Windows Shell extraction fallback ---
                if (result == null && !cancellationToken.IsCancellationRequested)
                {
                    string? diskPath = ResolveDiskPath(family);
                    if (!string.IsNullOrEmpty(diskPath) && File.Exists(diskPath))
                    {
                        LoggerService.LogInfo($"[ThumbnailService] Executing Windows Shell extraction (256px) for '{diskPath}'...");
                        result = await Task.Run(() =>
                        {
                            if (cancellationToken.IsCancellationRequested) return null;
                            return ExtractShellThumbnail(diskPath, 256);
                        }, cancellationToken);
                    }
                }

                // --- Strategy C: Guaranteed 2D Reference Symbol Icon Fallback ---
                if (result == null && !cancellationToken.IsCancellationRequested)
                {
                    LoggerService.LogInfo($"[ThumbnailService] Generating 2D reference preview icon fallback for '{family.Name}'...");
                    result = CreateFallback2DReferenceIcon(family.Name, family.CategoryName);
                }

                if (result != null)
                {
                    _thumbnailCache[cacheKey] = result;
                    family.Thumbnail = result;
                    LoggerService.LogInfo($"[ThumbnailService] Successfully cached preview for '{family.Name}'.");
                    return result;
                }
                else
                {
                    LoggerService.LogWarning($"[ThumbnailService] No preview image found for '{family.Name}'.");
                }
            }
            catch (OperationCanceledException)
            {
                LoggerService.LogInfo($"[ThumbnailService] Cancelled for '{family.Name}'.");
            }
            catch (Exception ex)
            {
                LoggerService.LogError($"[ThumbnailService] Exception while extracting thumbnail for '{family.Name}'", ex);
            }
            return null;
        }

        /// <summary>
        /// Extracts the preview image from a native Revit Family object SYNCHRONOUSLY.
        /// This is safe because TransferPlus runs as a modal dialog, so the current
        /// thread IS Revit's API thread.
        /// </summary>
        private static BitmapSource? ExtractNativeFamilyThumbnail(Family nativeFam, CancellationToken ct)
        {
            try
            {
                var doc = nativeFam.Document;
                var symbolIds = nativeFam.GetFamilySymbolIds();
                if (symbolIds.Count == 0)
                {
                    LoggerService.LogWarning($"[ThumbnailService] Native family '{nativeFam.Name}' has 0 symbol IDs.");
                    return null;
                }

                foreach (var symId in symbolIds)
                {
                    if (ct.IsCancellationRequested) return null;

                    if (doc.GetElement(symId) is ElementType elementType)
                    {
                        Bitmap? bmp = null;
                        try
                        {
                            bmp = elementType.GetPreviewImage(new System.Drawing.Size(256, 256));
                        }
                        catch { }

                        bmp ??= elementType.GetPreviewImage(new System.Drawing.Size(128, 128));

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
                }
                LoggerService.LogWarning($"[ThumbnailService] GetPreviewImage returned NULL for all symbols in '{nativeFam.Name}'.");
            }
            catch (Exception ex)
            {
                LoggerService.LogError($"[ThumbnailService] Error extracting native preview for '{nativeFam.Name}'", ex);
            }
            return null;
        }

        /// <summary>
        /// Resolves the on-disk file path for Shell thumbnail extraction.
        /// Supports: Local .rfa paths, linked model .rvt paths, and Azure cached files.
        /// </summary>
        private static string? ResolveDiskPath(FamilyItemModel family)
        {
            if (!string.IsNullOrEmpty(family.ImagePreviewUrl) && File.Exists(family.ImagePreviewUrl))
                return family.ImagePreviewUrl;
            if (!string.IsNullOrEmpty(family.SourceName) && File.Exists(family.SourceName))
                return family.SourceName;
            if (family.NativeFamily is Family fam && fam.Document?.PathName is string docPath && File.Exists(docPath))
                return docPath;
            return null;
        }

        /// <summary>
        /// Directly extracts the embedded native PNG preview stream from a Revit .rfa file on disk.
        /// High-speed OLE stream extraction in < 1ms.
        /// </summary>
        private static BitmapSource? ExtractRfaFileThumbnail(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) return null;

                byte[] fileBytes;
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    long readLen = Math.Min(fs.Length, 3 * 1024 * 1024);
                    fileBytes = new byte[readLen];
                    fs.Read(fileBytes, 0, (int)readLen);
                }

                // Search for PNG header: 0x89 0x50 0x4E 0x47 0x0D 0x0A 0x1A 0x0A
                byte[] pngHeader = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
                int headerIdx = IndexOfSequence(fileBytes, pngHeader, 0);

                if (headerIdx >= 0)
                {
                    byte[] pngEnd = new byte[] { 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82 };
                    int endIdx = IndexOfSequence(fileBytes, pngEnd, headerIdx);

                    if (endIdx > headerIdx)
                    {
                        int pngLength = (endIdx + pngEnd.Length) - headerIdx;
                        byte[] pngBytes = new byte[pngLength];
                        Buffer.BlockCopy(fileBytes, headerIdx, pngBytes, 0, pngLength);

                        using (var ms = new MemoryStream(pngBytes))
                        {
                            var bmpImage = new BitmapImage();
                            bmpImage.BeginInit();
                            bmpImage.CacheOption = BitmapCacheOption.OnLoad;
                            bmpImage.StreamSource = ms;
                            bmpImage.EndInit();
                            bmpImage.Freeze();
                            return bmpImage;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.LogWarning($"[ThumbnailService] Direct RFA stream extraction failed for '{filePath}': {ex.Message}");
            }

            return null;
        }

        private static int IndexOfSequence(byte[] array, byte[] pattern, int startIndex)
        {
            int maxFirst = array.Length - pattern.Length;
            for (int i = startIndex; i <= maxFirst; i++)
            {
                if (array[i] != pattern[0]) continue;
                bool match = true;
                for (int j = 1; j < pattern.Length; j++)
                {
                    if (array[i + j] != pattern[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match) return i;
            }
            return -1;
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
                            bmpSource.Freeze(); // Thread safety for WPF
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
                LoggerService.LogInfo($"Shell thumbnail extraction failed for {filePath}: {ex.Message}");
            }
            return null;
        }

        /// <summary>
        /// Generates a clean 2D vector reference symbol preview icon for non-3D families (profiles, annotations, drafting components).
        /// </summary>
        private static BitmapSource CreateFallback2DReferenceIcon(string familyName, string categoryName)
        {
            int width = 96;
            int height = 96;
            using (var bitmap = new System.Drawing.Bitmap(width, height))
            {
                using (var g = System.Drawing.Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clear(System.Drawing.Color.FromArgb(248, 249, 250));

                    // Draw outer border
                    using (var penBorder = new System.Drawing.Pen(System.Drawing.Color.FromArgb(220, 224, 230), 1))
                    {
                        g.DrawRectangle(penBorder, 0, 0, width - 1, height - 1);
                    }

                    // Draw 2D blueprint / reference geometry box
                    using (var penBox = new System.Drawing.Pen(System.Drawing.Color.FromArgb(0, 122, 204), 1.5f))
                    {
                        g.DrawRectangle(penBox, 20, 20, 56, 44);
                    }

                    // Draw dashed reference axes
                    using (var penDash = new System.Drawing.Pen(System.Drawing.Color.FromArgb(160, 180, 200), 1))
                    {
                        penDash.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        g.DrawLine(penDash, 48, 10, 48, 74);
                        g.DrawLine(penDash, 10, 42, 86, 42);
                    }

                    // Draw "2D SYMBOL" label
                    using (var font = new System.Drawing.Font("Segoe UI", 7.5f, System.Drawing.FontStyle.Bold))
                    using (var brushText = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(100, 110, 120)))
                    {
                        var sf = new System.Drawing.StringFormat
                        {
                            Alignment = System.Drawing.StringAlignment.Center,
                            LineAlignment = System.Drawing.StringAlignment.Center
                        };
                        g.DrawString("2D SYMBOL", font, brushText, new System.Drawing.RectangleF(0, 72, width, 20), sf);
                    }
                }

                IntPtr hBitmap = bitmap.GetHbitmap();
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

        // P/Invoke for Shell
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        private static extern void SHCreateItemFromParsingName(
            [In][MarshalAs(UnmanagedType.LPWStr)] string pszPath,
            [In] IntPtr pbc,
            [In][MarshalAs(UnmanagedType.LPStruct)] ref Guid riid,
            [Out][MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out IShellItem ppv);

        [ComImport]
        [Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IShellItem { }

        [ComImport]
        [Guid("bcc18b79-ba16-442f-80c4-8a59c30c463b")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IShellItemImageFactory
        {
            void GetImage(
                [In, MarshalAs(UnmanagedType.Struct)] SIZE size,
                [In] SIIGBF flags,
                [Out] out IntPtr phbm);
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
            SIIGBF_WIDETHUMBNAILS = 0x40,
            SIIGBF_ICONBACKGROUND = 0x80,
            SIIGBF_SCALEUP = 0x100,
            SIIGBF_BIGNOTICON = 0x200
        }
    }
}
