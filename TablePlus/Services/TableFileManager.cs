using System;
using System.IO;
using System.Security;

namespace TablePlus.Services;

/// <summary>
/// Secure manager for local temporary spreadsheet files in TablePlus.
/// Implements Path Traversal protection (Path.GetFullPath validation) and sanitization via TelemetryLogger.
/// </summary>
public static class TableFileManager
{
    private static readonly string BaseTempDirectory = Path.GetFullPath(Path.Combine(Path.GetTempPath(), "TablePlus_Tables"));

    static TableFileManager()
    {
        try
        {
            if (!Directory.Exists(BaseTempDirectory))
            {
                Directory.CreateDirectory(BaseTempDirectory);
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error creating TablePlus temporary files directory", ex);
        }
    }

    /// <summary>
    /// Creates a local temporary spreadsheet file (.xlsx, .xlsm, .xls, .csv) from a data stream,
    /// enforcing strict Path Traversal validation with Path.GetFullPath.
    /// </summary>
    public static string CreateTableLocalFile(Stream dataStream, string rawFileName)
    {
        if (dataStream == null) throw new ArgumentNullException(nameof(dataStream));
        if (string.IsNullOrWhiteSpace(rawFileName)) throw new ArgumentException("Invalid file name.", nameof(rawFileName));

        if (!Directory.Exists(BaseTempDirectory))
        {
            Directory.CreateDirectory(BaseTempDirectory);
        }

        // Sanitize file name by stripping invalid characters
        string safeFileName = string.Join("_", rawFileName.Split(Path.GetInvalidFileNameChars()));
        string ext = Path.GetExtension(safeFileName).ToLowerInvariant();
        if (ext is not (".xlsx" or ".xlsm" or ".xls" or ".csv" or ".txt" or ".tsv" or ".tab" or ".prn" or ".dat" or ".log" or ".asc" or ".pdf" or ".docx" or ".doc" or ".rtf" or ".md" or ".markdown"))
        {
            safeFileName += ".xlsx";
        }

        string combinedPath = Path.Combine(BaseTempDirectory, safeFileName);
        string fullPath = Path.GetFullPath(combinedPath);

        // Strict Path Traversal validation: fullPath must reside strictly within BaseTempDirectory
        if (!fullPath.StartsWith(BaseTempDirectory, StringComparison.OrdinalIgnoreCase))
        {
            TelemetryLogger.LogWarning($"Path Traversal attempt intercepted for table file: '{fullPath}'");
            throw new SecurityException("Access Denied: Path Traversal violation detected while writing temporary table file.");
        }

        using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            dataStream.CopyTo(fileStream);
        }

        TelemetryLogger.LogInfo($"Local table file created safely at: {fullPath}");
        return fullPath;
    }

    /// <summary>
    /// Deletes a temporary spreadsheet file, ensuring it resides safely within the cache boundary.
    /// </summary>
    public static void RemoveTableLocalFile(string localFilePath)
    {
        if (string.IsNullOrWhiteSpace(localFilePath)) return;

        try
        {
            string fullPath = Path.GetFullPath(localFilePath);
            if (fullPath.StartsWith(BaseTempDirectory, StringComparison.OrdinalIgnoreCase) && File.Exists(fullPath))
            {
                File.Delete(fullPath);
                TelemetryLogger.LogInfo($"Temporary table file removed: {fullPath}");
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error removing temporary table file", ex);
        }
    }
}
