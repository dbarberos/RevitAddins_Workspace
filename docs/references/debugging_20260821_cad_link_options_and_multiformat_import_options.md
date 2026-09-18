# Debugging Log: Revit API CAD Link/Import Options & Multi-Format Signatures

## Metadata
- **Date**: 2026-08-21
- **Component**: `TransferPlus.Services.FamilyRevitService`
- **Keywords**: `Document.Link`, `Document.Import`, `DWGImportOptions`, `DGNImportOptions`, `SATImportOptions`, `SKPImportOptions`

---

## 1. Symptom
Compilation errors during CAD transfer implementation:
- `error CS0246: El nombre del tipo o del espacio de nombres 'DWGLinkOptions' no se encontró`
- `error CS0246: El nombre del tipo o del espacio de nombres 'DGNLinkOptions' no se encontró`
- `error CS1503: Argumento 2: no se puede convertir de 'SATImportOptions' a 'DGNImportOptions'` (due to invalid `out ElementId` overload)
- `error CS1503: Argumento 2: no se puede convertir de 'SKPImportOptions' a 'DGNImportOptions'`

---

## 2. Root Cause
1. In Revit's Database API (`Autodesk.Revit.DB`), there are no separate `DWGLinkOptions` or `DGNLinkOptions` classes. Both `doc.Link` and `doc.Import` methods consume `DWGImportOptions` and `DGNImportOptions`.
2. The `Document.Import` method overloads for 3D formats (`SATImportOptions`, `SKPImportOptions`) do not use the `out ElementId elementId` signature; they strictly use `targetDoc.Import(string filePath, SATImportOptions options, View view)`.

---

## 3. Resolution & Code Pattern

```csharp
if (isLinkMode)
{
    // Link mode (Revit API doc.Link)
    if (ext == ".dwg" || ext == ".dxf")
    {
        var linkOpt = new DWGImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
        targetDoc.Link(filePath, linkOpt, newDraftingView, out _);
    }
    else if (ext == ".dgn")
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
    // Import mode (Revit API doc.Import)
    if (ext == ".dwg" || ext == ".dxf")
    {
        var impOpt = new DWGImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
        targetDoc.Import(filePath, impOpt, newDraftingView, out _);
    }
    else if (ext == ".sat")
    {
        var impOpt = new SATImportOptions { Placement = ImportPlacement.Origin };
        targetDoc.Import(filePath, impOpt, newDraftingView);
    }
    else if (ext == ".dgn")
    {
        var impOpt = new DGNImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
        targetDoc.Import(filePath, impOpt, newDraftingView, out _);
    }
    else if (ext == ".skp")
    {
        var impOpt = new SKPImportOptions { Placement = ImportPlacement.Origin };
        targetDoc.Import(filePath, impOpt, newDraftingView);
    }
    else
    {
        var impOpt = new DWGImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
        targetDoc.Import(filePath, impOpt, newDraftingView, out _);
    }
}
```
