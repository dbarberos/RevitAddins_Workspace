using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TransferPlus.Services;

/// <summary>
/// Model representing an individual family export result for logging purposes.
/// </summary>
public class ExportLogFamilyEntry
{
    public string FamilyName { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string RevitVersion { get; set; } = string.Empty;
    public List<string> ExportedSymbols { get; set; } = new List<string>();
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}

/// <summary>
/// Service responsible for generating, formatting, and persisting structured .txt log reports
/// when downloading families in TransferPlus.
/// </summary>
public static class ExportLoggerService
{
    /// <summary>
    /// Generates and saves a formatted .txt report file for a family download batch operation.
    /// </summary>
    /// <param name="targetDirectory">Directory where the .txt file will be created.</param>
    /// <param name="sourceDocumentName">Name of the source document or provider.</param>
    /// <param name="entries">List of family export entries.</param>
    /// <returns>The full path of the generated log file, or null if writing failed.</returns>
    public static string? SaveDownloadLog(
        string targetDirectory,
        string sourceDocumentName,
        IEnumerable<ExportLogFamilyEntry> entries)
    {
        if (string.IsNullOrWhiteSpace(targetDirectory) || !Directory.Exists(targetDirectory))
        {
            return null;
        }

        try
        {
            var entryList = entries.ToList();
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"TransferPlus_Download_Log_{timestamp}.txt";
            string filePath = Path.Combine(targetDirectory, fileName);

            int totalCount = entryList.Count;
            int successCount = entryList.Count(e => e.IsSuccess);
            int failCount = totalCount - successCount;

            var sb = new StringBuilder();
            sb.AppendLine("================================================================================");
            sb.AppendLine("                    TRANSFERPLUS - FAMILY DOWNLOAD EXPORT LOG                   ");
            sb.AppendLine("================================================================================");
            sb.AppendLine($"Date & Time     : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"Source Document : {TelemetryLogger.SanitizePath(sourceDocumentName)}");
            sb.AppendLine($"Target Directory: {TelemetryLogger.SanitizePath(targetDirectory)}");
            sb.AppendLine("================================================================================");
            sb.AppendLine();
            sb.AppendLine("SUMMARY");
            sb.AppendLine("--------------------------------------------------------------------------------");
            sb.AppendLine($"Total Families Processed : {totalCount}");
            sb.AppendLine($"Successfully Exported   : {successCount}");
            sb.AppendLine($"Failed Exports          : {failCount}");
            sb.AppendLine("--------------------------------------------------------------------------------");
            sb.AppendLine();
            sb.AppendLine("EXPORT DETAILS");
            sb.AppendLine("--------------------------------------------------------------------------------");

            for (int i = 0; i < entryList.Count; i++)
            {
                var entry = entryList[i];
                sb.AppendLine($"[{i + 1}] Family: {entry.FamilyName}");
                sb.AppendLine($"    Category    : {entry.CategoryName}");
                sb.AppendLine($"    Revit Vers. : {entry.RevitVersion}");
                sb.AppendLine($"    Status      : {(entry.IsSuccess ? "SUCCESS" : $"ERROR - {entry.ErrorMessage}")}");

                if (entry.ExportedSymbols != null && entry.ExportedSymbols.Any())
                {
                    sb.AppendLine($"    Exported Types ({entry.ExportedSymbols.Count}):");
                    foreach (var symbol in entry.ExportedSymbols)
                    {
                        sb.AppendLine($"      - {symbol}");
                    }
                }
                else
                {
                    sb.AppendLine("    Exported Types : None");
                }

                sb.AppendLine("--------------------------------------------------------------------------------");
            }

            sb.AppendLine();
            sb.AppendLine("================================================================================");
            sb.AppendLine("                           END OF REPORT - TRANSFERPLUS                         ");
            sb.AppendLine("================================================================================");

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
            TelemetryLogger.LogInfo($"[ExportLogger] Download log report written successfully to '{filePath}'.");
            return filePath;
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("ExportLoggerService.SaveDownloadLog", ex);
            return null;
        }
    }
}
