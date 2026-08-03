using System;
using System.Collections.Generic;
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
        if (string.IsNullOrWhiteSpace(selectedSourceDisplay))
        {
            return new LocalFolderFamilyProvider(string.Empty, familyRevitService);
        }

        try
        {
            // 1. Check if selectedSourceDisplay matches a configured FamilySourceItemModel
            var savedSources = FamilySourceConfigService.LoadSources();
            var matchedSource = savedSources.FirstOrDefault(s => s.IsActive &&
                (s.Name.Equals(selectedSourceDisplay, StringComparison.OrdinalIgnoreCase) ||
                 s.SourceDescription.Equals(selectedSourceDisplay, StringComparison.OrdinalIgnoreCase)));

            if (matchedSource != null)
            {
                if (matchedSource.SourceType == FamilySourceType.AzureStorage)
                {
                    return new AzureStorageFamilyProvider(matchedSource, familyRevitService);
                }
                else
                {
                    return new LocalFolderFamilyProvider(matchedSource.Path, familyRevitService);
                }
            }

            // 2. Check if selectedSourceDisplay matches an open Document in Revit session
            if (targetDocument != null && targetDocument.Application != null)
            {
                foreach (Document openDoc in targetDocument.Application.Documents)
                {
                    if (openDoc.IsValidObject && !openDoc.IsFamilyDocument &&
                        openDoc.Title.Equals(selectedSourceDisplay, StringComparison.OrdinalIgnoreCase))
                    {
                        return new OpenDocumentFamilyProvider(openDoc, familyRevitService);
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
                        if (linkTitle.Equals(selectedSourceDisplay, StringComparison.OrdinalIgnoreCase) ||
                            linkInst.Name.Equals(selectedSourceDisplay, StringComparison.OrdinalIgnoreCase))
                        {
                            return new LinkedDocumentFamilyProvider(linkInst, familyRevitService);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error in FamilyProviderFactory CreateProvider for '{selectedSourceDisplay}'", ex);
        }

        // Fallback: If selectedSourceDisplay is a directory path
        return new LocalFolderFamilyProvider(selectedSourceDisplay, familyRevitService);
    }
}
