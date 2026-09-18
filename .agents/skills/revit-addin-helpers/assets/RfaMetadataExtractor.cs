using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;

namespace TransferPlus.Services;

/// <summary>
/// Helper class to extract Revit Version and Family Category from RFA files without loading them into Revit document memory.
/// Uses Autodesk.Revit.DB.BasicFileInfo OLE binary stream header parsing.
/// </summary>
public static class RfaMetadataExtractor
{
    public static (string version, string category) ExtractMetadata(string rfaFilePath)
    {
        string version = string.Empty;
        string category = string.Empty;

        if (string.IsNullOrWhiteSpace(rfaFilePath) || !File.Exists(rfaFilePath))
        {
            return (version, category);
        }

        try
        {
            var info = BasicFileInfo.Extract(rfaFilePath);
            if (info != null)
            {
                var props = typeof(BasicFileInfo).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var prop in props)
                {
                    try
                    {
                        var val = prop.GetValue(info)?.ToString();
                        if (string.IsNullOrWhiteSpace(val)) continue;

                        if (prop.Name.IndexOf("Version", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            prop.Name.IndexOf("Format", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            prop.Name.IndexOf("Build", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            var match = Regex.Match(val, @"20\d{2}");
                            if (match.Success)
                            {
                                version = match.Value;
                            }
                            else if (string.IsNullOrWhiteSpace(version))
                            {
                                version = val;
                            }
                        }

                        if (prop.Name.IndexOf("Category", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            prop.Name.IndexOf("Subject", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            prop.Name.IndexOf("DocumentType", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            category = val;
                        }
                    }
                    catch { }
                }

                if (string.IsNullOrWhiteSpace(version))
                {
                    string infoString = info.ToString() ?? string.Empty;
                    var match = Regex.Match(infoString, @"20\d{2}");
                    if (match.Success)
                    {
                        version = match.Value;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogWarning($"[RfaMetadataExtractor] BasicFileInfo extract warning for '{rfaFilePath}': {ex.Message}");
        }

        return (version, category);
    }
}
