using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers;

public static class FamilyProviderFactory
{
    public static IFamilyProvider CreateProvider(
        string selectedSourceDisplay,
        Document targetDocument,
        FamilyRevitService familyRevitService)
    {
        if (targetDocument != null && familyRevitService != null && familyRevitService.RevitApp == null)
        {
            familyRevitService.RevitApp = targetDocument.Application;
        }

        if (string.IsNullOrWhiteSpace(selectedSourceDisplay))
        {
            TelemetryLogger.LogWarning("FamilyProviderFactory: selectedSourceDisplay es nulo o vacío. Retornando LocalFolderFamilyProvider por defecto.");
            return new LocalFolderFamilyProvider(string.Empty, familyRevitService);
        }

        TelemetryLogger.LogInfo($"FamilyProviderFactory: Resolviendo proveedor de familias para fuente seleccionada '{selectedSourceDisplay}'...");

        try
        {
            // 1. Check if selectedSourceDisplay matches a configured FamilySourceItemModel
            var savedSources = FamilySourceConfigService.LoadSources();
            var matchedSource = savedSources.FirstOrDefault(s => s.IsActive &&
                (s.Name.Equals(selectedSourceDisplay, StringComparison.OrdinalIgnoreCase) ||
                 s.SourceDescription.Equals(selectedSourceDisplay, StringComparison.OrdinalIgnoreCase) ||
                 s.Path.Equals(selectedSourceDisplay, StringComparison.OrdinalIgnoreCase)));

            if (matchedSource != null)
            {
                if (matchedSource.SourceType == FamilySourceType.AzureStorage)
                {
                    TelemetryLogger.LogInfo($"FamilyProviderFactory: Creado AzureStorageFamilyProvider para contenedor '{matchedSource.ContainerName}' ({matchedSource.Name})");
                    return new AzureStorageFamilyProvider(matchedSource, familyRevitService);
                }
                else if (matchedSource.SourceType == FamilySourceType.AwsS3)
                {
                    TelemetryLogger.LogInfo($"FamilyProviderFactory: Creado AwsS3StorageFamilyProvider para bucket '{matchedSource.BucketName}' ({matchedSource.Name})");
                    return new AwsS3StorageFamilyProvider(matchedSource, familyRevitService);
                }
                else if (matchedSource.SourceType == FamilySourceType.AutodeskDocs)
                {
                    TelemetryLogger.LogInfo($"FamilyProviderFactory: Creado AutodeskDocsFamilyProvider para carpeta ACC '{matchedSource.FolderName}' ({matchedSource.Name})");
                    return new AutodeskDocsFamilyProvider(matchedSource, familyRevitService);
                }
                else
                {
                    TelemetryLogger.LogInfo($"FamilyProviderFactory: Creado LocalFolderFamilyProvider para ruta guardada '{matchedSource.Path}' ({matchedSource.Name})");
                    return new LocalFolderFamilyProvider(matchedSource.Path, familyRevitService);
                }
            }

            // Clean display string by stripping prefixes
            string cleanTitle = selectedSourceDisplay;
            if (cleanTitle.StartsWith("Active Model: ", StringComparison.OrdinalIgnoreCase))
            {
                cleanTitle = cleanTitle.Substring("Active Model: ".Length).Trim();
            }
            else if (cleanTitle.StartsWith("Link: ", StringComparison.OrdinalIgnoreCase))
            {
                cleanTitle = cleanTitle.Substring("Link: ".Length).Trim();
            }

            // 2. Check if selectedSourceDisplay matches an open Document in Revit session
            if (targetDocument != null && targetDocument.Application != null)
            {
                foreach (Document openDoc in targetDocument.Application.Documents)
                {
                    if (openDoc.IsValidObject && !openDoc.IsFamilyDocument)
                    {
                        string docTitle = openDoc.Title;
                        if (docTitle.Equals(cleanTitle, StringComparison.OrdinalIgnoreCase) ||
                            selectedSourceDisplay.EndsWith(docTitle, StringComparison.OrdinalIgnoreCase) ||
                            selectedSourceDisplay.Contains(docTitle))
                        {
                            TelemetryLogger.LogInfo($"FamilyProviderFactory: Creado OpenDocumentFamilyProvider para modelo abierto '{openDoc.Title}'");
                            return new OpenDocumentFamilyProvider(openDoc, familyRevitService);
                        }
                    }
                }

                // 3. Check if selectedSourceDisplay matches a Linked Model (RevitLinkInstance) in targetDocument
                var linkInstances = new FilteredElementCollector(targetDocument)
                    .OfClass(typeof(RevitLinkInstance))
                    .Cast<RevitLinkInstance>();

                foreach (var linkInst in linkInstances)
                {
                    if (linkInst.IsValidObject)
                    {
                        var linkDoc = linkInst.GetLinkDocument();
                        string linkTitle = linkDoc?.Title ?? linkInst.Name;

                        if (linkTitle.Equals(cleanTitle, StringComparison.OrdinalIgnoreCase) ||
                            linkInst.Name.Equals(cleanTitle, StringComparison.OrdinalIgnoreCase) ||
                            selectedSourceDisplay.Contains(linkTitle) ||
                            selectedSourceDisplay.Contains(linkInst.Name))
                        {
                            TelemetryLogger.LogInfo($"FamilyProviderFactory: Creado LinkedDocumentFamilyProvider para modelo vinculado '{linkTitle}'");
                            return new LinkedDocumentFamilyProvider(linkInst, familyRevitService);
                        }
                    }
                }
            }

            // 4. Safe Directory Path Fallback
            // Check if cleanTitle is a valid local directory path before passing to LocalFolderFamilyProvider
            if (!string.IsNullOrWhiteSpace(cleanTitle) &&
                cleanTitle.IndexOfAny(Path.GetInvalidPathChars()) < 0 &&
                Directory.Exists(cleanTitle))
            {
                TelemetryLogger.LogInfo($"FamilyProviderFactory: Creado LocalFolderFamilyProvider para directorio directo '{cleanTitle}'");
                return new LocalFolderFamilyProvider(cleanTitle, familyRevitService);
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error en FamilyProviderFactory para fuente '{selectedSourceDisplay}'", ex);
        }

        TelemetryLogger.LogWarning($"FamilyProviderFactory: No se pudo resolver proveedor específico para '{selectedSourceDisplay}'. Retornando LocalFolderFamilyProvider vacío.");
        return new LocalFolderFamilyProvider(string.Empty, familyRevitService);
    }
}
