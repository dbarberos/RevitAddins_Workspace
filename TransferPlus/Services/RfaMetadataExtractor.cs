using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;

namespace TransferPlus.Services;

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

    public static (string version, string category, System.Collections.Generic.List<TransferPlus.Models.FamilySymbolItemModel> symbols) ExtractCategoryAndSymbols(
        Autodesk.Revit.ApplicationServices.Application? app,
        string rfaFilePath)
    {
        var symbols = new System.Collections.Generic.List<TransferPlus.Models.FamilySymbolItemModel>();
        string version = string.Empty;
        string category = string.Empty;

        if (string.IsNullOrWhiteSpace(rfaFilePath) || !File.Exists(rfaFilePath))
        {
            return (version, category, symbols);
        }

        var (ver, catBasic) = ExtractMetadata(rfaFilePath);
        version = ver;
        category = catBasic;

        string familyName = Path.GetFileNameWithoutExtension(rfaFilePath);

        if (app != null)
        {
            Document? familyDoc = null;
            try
            {
                familyDoc = app.OpenDocumentFile(rfaFilePath);
                if (familyDoc != null && familyDoc.IsFamilyDocument)
                {
                    var revitCat = familyDoc.OwnerFamily?.FamilyCategory;
                    if (revitCat != null && !string.IsNullOrWhiteSpace(revitCat.Name))
                    {
                        category = revitCat.Name;
                    }

                    if (familyDoc.FamilyManager != null && familyDoc.FamilyManager.Types != null)
                    {
                        foreach (FamilyType familyType in familyDoc.FamilyManager.Types)
                        {
                            symbols.Add(new TransferPlus.Models.FamilySymbolItemModel
                            {
                                Name = familyType.Name,
                                FamilyName = familyName,
                                IsActive = true
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogWarning($"[RfaMetadataExtractor] No se pudo inspeccionar tipos en '{rfaFilePath}' vía OpenDocumentFile: {ex.Message}");
            }
            finally
            {
                familyDoc?.Close(false);
            }
        }

        if (!symbols.Any())
        {
            symbols.Add(new TransferPlus.Models.FamilySymbolItemModel
            {
                Name = familyName,
                FamilyName = familyName,
                IsActive = true
            });
        }

        return (version, category, symbols);
    }
}
