# Debugging Lesson: Title Block (`OST_TitleBlocks`) and Dynamic Family Preview Rendering in Revit API

**Date:** 2026-08-20  
**Context:** Revit 2024+ C# Add-ins (`TransferPlus`) / Dynamic UI Preview Rendering  
**Category:** Revit API Host Validation & Family Document Image Export  

---

## 1. Symptom

When generating dynamic isolated previews for Revit families:
- Most 3D and 2D detail components rendered properly, but **Title Blocks (`BuiltInCategory.OST_TitleBlocks`)** and certain hosted annotation/profile families continued to show fallback/default placeholder icons.
- In telemetry logs:
  ```text
  [GenerateElementPreview] Excepción interna al crear vista temporal para 'A1_Metric_TitleBlock': The view is not valid for family placement.
  ```

---

## 2. Root Cause

1. **Strict Host Restrictions in Revit API**:
   - `FamilySymbol` instances belonging to `BuiltInCategory.OST_TitleBlocks` can **only** be placed inside a `ViewSheet` (`doc.Create.NewFamilyInstance(XYZ.Zero, symbol, viewSheet)`).
   - Calling `NewFamilyInstance` on a `ViewDrafting` or `View3D` throws an unhandled `ArgumentException` ("The view is not valid for family placement"), triggering the fallback catch block.
2. **Profile Families & Complex Annotation Tags**:
   - Profile definitions (`OST_ProfileFamilies`) cannot be placed as standalone 3D or drafting view instances.

---

## 3. Optimal Resolution Pattern

### Strategy A: Universal In-Memory Family Inspection (`doc.EditFamily`)
Opening the in-memory family document via `doc.EditFamily(nativeFam)` completely eliminates placement and hosting restrictions:
- In `famDoc`, all geometries, borders, texts, parameters, and graphics already exist natively in their original coordinate space.
- Exporting `famDoc`'s active view or 3D/plan view with `ImageExportOptions` generates an exact vector render.
- Closing `famDoc.Close(false)` discards the document with 0 side effects.

### Strategy B: Dynamic `ViewSheet` Rollback for Title Blocks
If `EditFamily` cannot be used (e.g. non-editable family), detect `OST_TitleBlocks` and create a scratch `ViewSheet`:
```csharp
if (isTitleBlock)
{
    var tempSheet = ViewSheet.Create(workDoc, ElementId.InvalidElementId);
    tempSheet.Name = $"_TempSheet_{Guid.NewGuid():N}";
    tempSheet.SheetNumber = $"ZZ_{Guid.NewGuid():N}".Substring(0, 8);
    workDoc.Create.NewFamilyInstance(XYZ.Zero, workSym, tempSheet);
    
    // Export with ImageExportOptions then RollBack
}
```

### Strategy C: External `.rfa` Background Opening
For `.rfa` files on disk without embedded OLE preview streams:
```csharp
var rfaDoc = app.OpenDocumentFile(rfaPath);
// Query 3D or plan view, export image via doc.ExportImage(), then close without saving:
rfaDoc.Close(false);
```
