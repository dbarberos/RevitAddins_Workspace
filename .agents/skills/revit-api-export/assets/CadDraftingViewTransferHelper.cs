using System;
using System.IO;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddin.Export.Helpers;

/// <summary>
/// Reusable helper for programmatic creation of Drafting Views and importing or linking multi-format CAD/3D geometries.
/// </summary>
public static class CadDraftingViewTransferHelper
{
    /// <summary>
    /// Imports or links an external CAD/3D file (.dwg, .dxf, .sat, .dgn, .skp, etc.) into a dedicated 1:1 Drafting View.
    /// </summary>
    public static bool TransferCadToDraftingView(
        Document targetDoc,
        string filePath,
        string? customViewName = null,
        bool isLinkMode = false)
    {
        if (targetDoc == null || string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            return false;
        }

        using (var t = new Transaction(targetDoc, "Transfer External CAD File"))
        {
            t.Start();

            try
            {
                // 1. Locate Drafting View FamilyType
                var draftingViewType = new FilteredElementCollector(targetDoc)
                    .OfClass(typeof(ViewFamilyType))
                    .Cast<ViewFamilyType>()
                    .FirstOrDefault(x => x.ViewFamily == ViewFamily.Drafting);

                if (draftingViewType == null)
                {
                    t.RollBack();
                    return false;
                }

                // 2. Create the Drafting View
                var newDraftingView = ViewDrafting.Create(targetDoc, draftingViewType.Id);
                newDraftingView.Scale = 1;

                // 3. Guarantee Unique View Name
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string baseName = !string.IsNullOrWhiteSpace(customViewName) ? customViewName : $"CAD - {fileName}";
                string uniqueName = baseName;

                var existingNames = new FilteredElementCollector(targetDoc)
                    .OfClass(typeof(View))
                    .Cast<View>()
                    .Select(v => v.Name)
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                int counter = 1;
                while (existingNames.Contains(uniqueName))
                {
                    uniqueName = $"{baseName}_{counter++}";
                }
                newDraftingView.Name = uniqueName;

                string ext = Path.GetExtension(filePath).ToLowerInvariant();

                // 4. Link vs Import Logic
                if (isLinkMode)
                {
                    if (ext == ".dgn")
                    {
                        var linkOpt = new DGNImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
                        targetDoc.Link(filePath, linkOpt, newDraftingView, out _);
                    }
                    else
                    {
                        var linkOpt = new DWGImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
                        targetDoc.Link(filePath, linkOpt, newDraftingView, out _);
                    }
                }
                else
                {
                    if (ext == ".sat")
                    {
                        var impOpt = new SATImportOptions { Placement = ImportPlacement.Origin };
                        targetDoc.Import(filePath, impOpt, newDraftingView);
                    }
                    else if (ext == ".skp")
                    {
                        var impOpt = new SKPImportOptions { Placement = ImportPlacement.Origin };
                        targetDoc.Import(filePath, impOpt, newDraftingView);
                    }
                    else if (ext == ".dgn")
                    {
                        var impOpt = new DGNImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
                        targetDoc.Import(filePath, impOpt, newDraftingView, out _);
                    }
                    else
                    {
                        var impOpt = new DWGImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
                        targetDoc.Import(filePath, impOpt, newDraftingView, out _);
                    }
                }

                t.Commit();
                return true;
            }
            catch
            {
                if (t.HasStarted() && !t.HasEnded())
                {
                    t.RollBack();
                }
                throw;
            }
        }
    }
}
