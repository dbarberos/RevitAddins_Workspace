using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers;

public static class CadProviderFactory
{
    public static ICadProvider CreateProvider(
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
            TelemetryLogger.LogWarning("CadProviderFactory: selectedSourceDisplay es nulo o vacío. Retornando LocalFolderCadProvider por defecto.");
            return new LocalFolderCadProvider(string.Empty, familyRevitService);
        }

        TelemetryLogger.LogInfo($"CadProviderFactory: Resolviendo proveedor CAD para fuente seleccionada '{selectedSourceDisplay}'...");

        try
        {
            // 1. Check if selectedSourceDisplay matches a configured CadSourceItemModel
            var savedSources = CadSourceConfigService.LoadSources();
            var matchedSource = savedSources.FirstOrDefault(s => s.IsActive &&
                (s.Name.Equals(selectedSourceDisplay, StringComparison.OrdinalIgnoreCase) ||
                 s.SourceDescription.Equals(selectedSourceDisplay, StringComparison.OrdinalIgnoreCase) ||
                 s.Path.Equals(selectedSourceDisplay, StringComparison.OrdinalIgnoreCase)));

            if (matchedSource != null)
            {
                if (matchedSource.SourceType == CadSourceType.AzureStorage)
                {
                    TelemetryLogger.LogInfo($"CadProviderFactory: Creado AzureStorageCadProvider para contenedor '{matchedSource.ContainerName}' ({matchedSource.Name})");
                    return new AzureStorageCadProvider(matchedSource, familyRevitService);
                }
                else if (matchedSource.SourceType == CadSourceType.AwsS3)
                {
                    TelemetryLogger.LogInfo($"CadProviderFactory: Creado AwsS3StorageCadProvider para bucket '{matchedSource.BucketName}' ({matchedSource.Name})");
                    return new AwsS3StorageCadProvider(matchedSource, familyRevitService);
                }
                else if (matchedSource.SourceType == CadSourceType.AutodeskDocs)
                {
                    TelemetryLogger.LogInfo($"CadProviderFactory: Creado AutodeskDocsCadProvider para carpeta ACC '{matchedSource.FolderName}' ({matchedSource.Name})");
                    return new AutodeskDocsCadProvider(matchedSource, familyRevitService);
                }
                else
                {
                    TelemetryLogger.LogInfo($"CadProviderFactory: Creado LocalFolderCadProvider para ruta guardada '{matchedSource.Path}' ({matchedSource.Name})");
                    return new LocalFolderCadProvider(matchedSource.Path, familyRevitService);
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
                            TelemetryLogger.LogInfo($"CadProviderFactory: Creado OpenDocumentCadProvider para modelo abierto '{openDoc.Title}'");
                            return new OpenDocumentCadProvider(openDoc, familyRevitService);
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
                            TelemetryLogger.LogInfo($"CadProviderFactory: Creado LinkedDocumentCadProvider para modelo vinculado '{linkTitle}'");
                            return new LinkedDocumentCadProvider(linkInst, familyRevitService);
                        }
                    }
                }
            }

            // 4. Safe Directory Path Fallback
            if (!string.IsNullOrWhiteSpace(cleanTitle) &&
                cleanTitle.IndexOfAny(Path.GetInvalidPathChars()) < 0 &&
                Directory.Exists(cleanTitle))
            {
                TelemetryLogger.LogInfo($"CadProviderFactory: Creado LocalFolderCadProvider para directorio directo '{cleanTitle}'");
                return new LocalFolderCadProvider(cleanTitle, familyRevitService);
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error en CadProviderFactory para fuente '{selectedSourceDisplay}'", ex);
        }

        TelemetryLogger.LogWarning($"CadProviderFactory: No se pudo resolver proveedor específico para '{selectedSourceDisplay}'. Retornando LocalFolderCadProvider vacío.");
        return new LocalFolderCadProvider(string.Empty, familyRevitService);
    }
}
