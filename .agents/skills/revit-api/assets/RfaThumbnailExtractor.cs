using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace RevitApiHelpers;

/// <summary>
/// High-performance OLE binary stream thumbnail extractor for Revit .rfa files.
/// Scans embedded PNG stream inside .rfa headers in <1ms without opening Revit.
/// </summary>
public static class RfaThumbnailExtractor
{
    public static BitmapSource? ExtractRfaFileThumbnail(string filePath)
    {
        try
        {
            if (!File.Exists(filePath)) return null;

            byte[] fileBytes;
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                long readLen = Math.Min(fs.Length, 3 * 1024 * 1024); // First 3MB contains OLE preview stream
                fileBytes = new byte[readLen];
                fs.Read(fileBytes, 0, (int)readLen);
            }

            // Search for PNG header: 0x89 0x50 0x4E 0x47 0x0D 0x0A 0x1A 0x0A
            byte[] pngHeader = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            int headerIdx = IndexOfSequence(fileBytes, pngHeader, 0);

            if (headerIdx >= 0)
            {
                // Search for PNG end chunk: IEND (0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82)
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
        catch { }

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
}
