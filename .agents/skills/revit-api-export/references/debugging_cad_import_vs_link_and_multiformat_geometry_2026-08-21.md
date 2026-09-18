# Debugging Log: Revit API CAD Link/Import Options & Multi-Format Signatures

## Metadata
- **Date**: 2026-08-21
- **Skill**: `revit-api-export`
- **Keywords**: `Document.Link`, `Document.Import`, `DWGImportOptions`, `DGNImportOptions`, `SATImportOptions`, `SKPImportOptions`, `ViewDrafting`

---

## 1. Context & Symptom
When implementing multi-cloud CAD transfers into Revit drafting views (`ViewDrafting`), compilation errors occurred due to option type name mismatches:
- `error CS0246: El nombre del tipo o del espacio de nombres 'DWGLinkOptions' no se encontró`
- `error CS0246: El nombre del tipo o del espacio de nombres 'DGNLinkOptions' no se encontró`
- `error CS1503: Argumento 2: no se puede convertir de 'SATImportOptions' a 'DGNImportOptions'` (due to passing an invalid `out ElementId` parameter).

---

## 2. Root Cause
1. **Revit API Design**: Unlike RVT links (`RevitLinkOptions`), CAD links (`.dwg`, `.dxf`, `.dgn`) reuse the exact same options classes as imports: `DWGImportOptions` and `DGNImportOptions`. There is no `DWGLinkOptions` class in the Revit API.
2. **Method Signature Variations**:
   - `doc.Link(path, DWGImportOptions, view, out ElementId elementId)`
   - `doc.Link(path, DGNImportOptions, view, out ElementId elementId)`
   - `doc.Import(path, DWGImportOptions, view, out ElementId elementId)`
   - `doc.Import(path, DGNImportOptions, view, out ElementId elementId)`
   - `doc.Import(path, SATImportOptions, view)` -> **No `out ElementId` parameter**.
   - `doc.Import(path, SKPImportOptions, view)` -> **No `out ElementId` parameter**.

---

## 3. Recommended Resolution Pattern

```csharp
using Autodesk.Revit.DB;

public static bool TransferCadToDraftingView(Document targetDoc, string filePath, string viewName, bool isLinkMode)
{
    using (Transaction t = new Transaction(targetDoc, "Transfer CAD File"))
    {
        t.Start();

        // 1. Locate Drafting View FamilyType
        var draftingViewType = new FilteredElementCollector(targetDoc)
            .OfClass(typeof(ViewFamilyType))
            .Cast<ViewFamilyType>()
            .FirstOrDefault(x => x.ViewFamily == ViewFamily.Drafting);

        if (draftingViewType == null) return false;

        var draftingView = ViewDrafting.Create(targetDoc, draftingViewType.Id);
        draftingView.Name = viewName;
        draftingView.Scale = 1;

        string ext = System.IO.Path.GetExtension(filePath).ToLowerInvariant();

        if (isLinkMode)
        {
            if (ext == ".dgn")
            {
                var opt = new DGNImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
                targetDoc.Link(filePath, opt, draftingView, out _);
            }
            else
            {
                var opt = new DWGImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
                targetDoc.Link(filePath, opt, draftingView, out _);
            }
        }
        else
        {
            if (ext == ".sat")
            {
                var opt = new SATImportOptions { Placement = ImportPlacement.Origin };
                targetDoc.Import(filePath, opt, draftingView);
            }
            else if (ext == ".skp")
            {
                var opt = new SKPImportOptions { Placement = ImportPlacement.Origin };
                targetDoc.Import(filePath, opt, draftingView);
            }
            else if (ext == ".dgn")
            {
                var opt = new DGNImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
                targetDoc.Import(filePath, opt, draftingView, out _);
            }
            else
            {
                var opt = new DWGImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
                targetDoc.Import(filePath, opt, draftingView, out _);
            }
        }

        t.Commit();
        return true;
    }
}
```
