using System;
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

        public static async Task<BitmapSource?> GetPreviewImageAsync(FamilyItemModel family, CancellationToken cancellationToken)
        {
            try
            {
                if (family.NativeFamily is Family nativeFam && nativeFam.Document != null)
                {
                    // Open Document Element
                    return await RevitTask.RunAsync(app =>
                    {
                        if (cancellationToken.IsCancellationRequested) return null;

                        var doc = nativeFam.Document;
                        var symbolIds = nativeFam.GetFamilySymbolIds();
                        if (symbolIds.Count == 0) return null;
                        
                        var elementType = doc.GetElement(symbolIds.First()) as ElementType;
                        if (elementType != null)
                        {
                            using (Bitmap bmp = elementType.GetPreviewImage(new System.Drawing.Size(128, 128)))
                            {
                                if (bmp != null)
                                {
                                    IntPtr hBitmap = bmp.GetHbitmap();
                                    try
                                    {
                                        var bmpSource = Imaging.CreateBitmapSourceFromHBitmap(
                                            hBitmap,
                                            IntPtr.Zero,
                                            Int32Rect.Empty,
                                            BitmapSizeOptions.FromEmptyOptions());
                                        bmpSource.Freeze(); // Make it cross-thread safe
                                        return bmpSource;
                                    }
                                    finally
                                    {
                                        DeleteObject(hBitmap); // Prevent memory leak
                                    }
                                }
                            }
                        }
                        return null;
                    });
                }
                else if (!string.IsNullOrEmpty(family.SourceName) && File.Exists(family.SourceName))
                {
                    // Local File (Extracted without locking)
                    return await Task.Run(() => 
                    {
                        if (cancellationToken.IsCancellationRequested) return null;
                        return ExtractShellThumbnail(family.SourceName, 128);
                    }, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                LoggerService.LogError($"Failed to load preview image for {family.Name}", ex);
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
                    imageFactory.GetImage(new SIZE { cx = size, cy = size }, SIIGBF.SIIGBF_BIGNOTICON | SIIGBF.SIIGBF_THUMBNAILONLY, out IntPtr hBitmap);
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
