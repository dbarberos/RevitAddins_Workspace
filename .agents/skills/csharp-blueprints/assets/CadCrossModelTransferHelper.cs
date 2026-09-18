using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace TransferPlus.Helpers;

/// <summary>
/// Reusable helper for cross-model CAD and 2D detail element transfers between Autodesk Revit documents.
/// Provides dedicated ViewDrafting generation, 2D annotation copying, in-memory family extraction, and collision avoidance.
/// </summary>
public static class CadCrossModelTransferHelper
{
    /// <summary>
    /// Finds or creates an available unique ViewDrafting name inside the target document, honoring keepOriginal and suffix policies.
    /// </summary>
    public static string ResolveUniqueViewDraftingName(
        Document targetDoc,
        string desiredBaseName,
        HashSet<string> existingViewNames,
        bool keepOriginal = false,
        string? suffix = null)
    {
        if (keepOriginal && existingViewNames.Contains(desiredBaseName))
        {
            return string.Empty; // Indicates skip
        }

        string baseName = desiredBaseName;
        if (!string.IsNullOrWhiteSpace(suffix) && existingViewNames.Contains(baseName))
        {
            baseName += suffix;
        }

        string candidateName = baseName;
        int counter = 1;
        while (existingViewNames.Contains(candidateName))
        {
            candidateName = $"{baseName}_{counter++}";
        }

        return candidateName;
    }

    /// <summary>
    /// Creates a dedicated ViewDrafting in targetDoc and copies 2D elements from a source view into it.
    /// </summary>
    public static ViewDrafting? TransferElementsToNewDraftingView(
        Document sourceDoc,
        View sourceView,
        Document targetDoc,
        List<ElementId> elementIdsToCopy,
        string targetViewName,
        int targetViewScale = 50)
    {
        if (sourceDoc == null || sourceView == null || targetDoc == null || elementIdsToCopy == null || !elementIdsToCopy.Any())
            return null;

        var draftingVft = new FilteredElementCollector(targetDoc)
            .OfClass(typeof(ViewFamilyType))
            .Cast<ViewFamilyType>()
            .FirstOrDefault(vft => vft.ViewFamily == ViewFamily.Drafting);

        if (draftingVft == null) return null;

        var newDraftingView = ViewDrafting.Create(targetDoc, draftingVft.Id);
        if (newDraftingView == null) return null;

        newDraftingView.Name = targetViewName;
        try
        {
            newDraftingView.Scale = targetViewScale;
        }
        catch { }

        var copyOptions = new CopyPasteOptions();
        ElementTransformUtils.CopyElements(
            sourceView,
            elementIdsToCopy,
            newDraftingView,
            Transform.Identity,
            copyOptions);

        return newDraftingView;
    }

    /// <summary>
    /// Loads the pure Family and FamilySymbol definitions of Detail Components (OST_DetailComponents)
    /// into the target document via in-memory EditFamily without placing visible graphical instances.
    /// </summary>
    public static bool TransferDetailComponentFamilyInMemory(
        Document sourceDoc,
        Family family,
        Document targetDoc,
        string? overrideFamilyName = null)
    {
        if (sourceDoc == null || family == null || targetDoc == null) return false;

        Document? familyDoc = null;
        try
        {
            familyDoc = sourceDoc.EditFamily(family);
            if (familyDoc == null) return false;

            if (!string.IsNullOrWhiteSpace(overrideFamilyName) && !overrideFamilyName.Equals(family.Name, StringComparison.OrdinalIgnoreCase))
            {
                using var tx = new Transaction(familyDoc, "Rename Family In Memory");
                tx.Start();
                if (familyDoc.OwnerFamily != null)
                {
                    familyDoc.OwnerFamily.Name = overrideFamilyName;
                }
                tx.Commit();
            }

            var loadOptions = new OverwriteFamilyLoadOption();
            familyDoc.LoadFamily(targetDoc, loadOptions);
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            if (familyDoc != null && familyDoc.IsValidObject)
            {
                try { familyDoc.Close(false); } catch { }
            }
        }
    }

    private sealed class OverwriteFamilyLoadOption : IFamilyLoadOptions
    {
        public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
        {
            overwriteParameterValues = true;
            return true;
        }

        public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
        {
            source = FamilySource.Family;
            overwriteParameterValues = true;
            return true;
        }
    }
}
