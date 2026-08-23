# Pattern: In-Memory Temporary Preview Rendering for Elements in Read-Only / Linked Revit Documents

**Date:** 2026-08-23  
**Category:** Revit API / Preview Thumbnails / Linked Documents / Transactions  
**Target:** Revit 2024+ (C# / .NET)

---

## 1. Problem Statement

Generating an isolated preview image (`ImageExportOptions`) for an element (such as a 2D `Detail Item`, `Group`, `FilledRegion` or `FamilySymbol`) requires:
1. Creating a temporary `ViewDrafting`.
2. Placing or copying the element into that isolated view.
3. Setting the `CropBox` tight to the element's bounding box.
4. Calling `doc.ExportImage(options)`.
5. Rolling back the transaction (`tx.RollBack()`).

When the source document is a **Linked Model** (`RevitLinkInstance` / `linkDoc`) or a **Read-Only Document**, starting a transaction on `linkDoc` fails with `InvalidOperationException: The document is read-only`.

---

## 2. Recommended Solution: Host Document In-Memory Delegation Pattern

Instead of giving up or falling back to generic placeholder icons:
1. Use the active writable host document (`CadThumbnailService.ActiveDocument` or active project model) as `workDoc`.
2. Start a transaction on `workDoc` (`using (var tx = new Transaction(workDoc, "Temp Preview"))`).
3. Create the temporary `ViewDrafting` inside `workDoc`.
4. Copy the element from `linkDoc` into `workDoc` using `ElementTransformUtils.CopyElements(linkDoc, new List<ElementId> { elem.Id }, workDoc, Transform.Identity, new CopyPasteOptions())`.
5. If the element is a `FamilySymbol`, activate it in `workDoc` and instantiate it via `workDoc.Create.NewFamilyInstance(XYZ.Zero, workSym, tempView)`.
6. Call `workDoc.Regenerate()`.
7. Fit `tempView.CropBox` to `placedElem.get_BoundingBox(tempView)` + 8% margin.
8. Call `workDoc.ExportImage(options)` to generate the PNG thumbnail.
9. **Crucial:** Always execute `tx.RollBack()` in the `finally` block.

```csharp
Document workDoc = (doc.IsLinked || doc.IsReadOnly) ? (ActiveHostDocument ?? doc) : doc;
if (workDoc == null || workDoc.IsReadOnly) return null;

using (var tx = new Transaction(workDoc, "Generate Isolated Element Preview"))
{
    WarningSwallower.AttachToTransaction(tx);
    tx.Start();
    try
    {
        var tempView = ViewDrafting.Create(workDoc, draftingTypeId);
        tempView.Scale = 1;

        Element? placedElem = null;
        if (workDoc == doc)
        {
            // Local placement
            if (elem is FamilySymbol sym)
            {
                if (!sym.IsActive) sym.Activate();
                placedElem = workDoc.Create.NewFamilyInstance(XYZ.Zero, sym, tempView);
            }
        }
        else
        {
            // Linked document cross-copy
            var copiedIds = ElementTransformUtils.CopyElements(doc, new List<ElementId> { elem.Id }, workDoc, Transform.Identity, new CopyPasteOptions());
            if (copiedIds.Count > 0 && workDoc.GetElement(copiedIds.First()) is FamilySymbol workSym)
            {
                if (!workSym.IsActive) workSym.Activate();
                placedElem = workDoc.Create.NewFamilyInstance(XYZ.Zero, workSym, tempView);
            }
        }

        workDoc.Regenerate();
        // Fit CropBox and export PNG
        workDoc.ExportImage(options);
    }
    finally
    {
        if (tx.HasStarted() && !tx.HasEnded())
        {
            tx.RollBack();
        }
    }
}
```
