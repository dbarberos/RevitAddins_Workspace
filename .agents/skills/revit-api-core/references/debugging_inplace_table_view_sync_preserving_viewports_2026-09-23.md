# Debugging Lesson: In-Place Table View Synchronization Preserving Sheet Viewports

**Date:** 2026-09-23  
**Skill:** `revit-api-core`  
**Context:** TablePlus Spec 002 (In-Place Vector Table Synchronization)  

---

## 1. Problem Description

When an imported spreadsheet table placed on a Revit documentation Sheet (`ViewSheet`) needs to be synchronized (due to modified cell values, row insertion, or style changes):
- Recreating the view (`ViewDrafting.Create`) and deleting the old view breaks all `Viewport` associations on documentation sheets, forcing users to manually find, replace, position, and re-tag viewports across documentation sets.
- Conversely, modifying text notes and lines one by one without wiping can create orphan lines, misaligned merged cell borders, or duplicate text notes when row counts change in Excel.

---

## 2. Root Cause Analysis

In the Revit database, sheet viewports reference the unique `ElementId` of the view (`viewport.ViewId`). Deleting the `ViewDrafting` or `ViewLegend` cascades deletion to its parent `Viewport` on any `ViewSheet`.

---

## 3. Resolution & Code Pattern

Instead of recreating the view, implement **In-Place Non-Destructive View Synchronization**:
1. Collect all 2D vector elements belonging to the view using an `ElementMulticlassFilter` targeting `CurveElement`, `FilledRegion`, and `TextNote`.
2. Delete only the internal graphic elements using `doc.Delete(elementsToDelete)`.
3. Regenerate the updated vector grid, filled regions, and text notes inside the same existing `targetView.Id`.
4. Update view scale if modified.
5. Re-stamp the Extensible Storage metadata with updated timestamps and settings.
6. Regenerate the document.

### C# Implementation
```csharp
public void UpdateTableInView(
    Document doc,
    View targetView,
    TableImportConfig config,
    IList<ExcelCellModel> cells,
    IList<MergedCellRange> mergedRanges)
{
    // 1. Delete previous graphical elements belonging to the table in targetView
    var elementsToDelete = new FilteredElementCollector(doc, targetView.Id)
        .WherePasses(new ElementMulticlassFilter(new List<Type>
        {
            typeof(CurveElement),
            typeof(FilledRegion),
            typeof(TextNote)
        }))
        .Select(e => e.Id)
        .ToList();

    if (elementsToDelete.Count > 0)
    {
        doc.Delete(elementsToDelete);
    }

    // 2. Update view scale
    targetView.Scale = Math.Max(config.ViewScale, 1);

    // 3. Re-render table contents (lines, fills, texts)
    RenderTableContents(doc, targetView, config, cells, mergedRanges);

    // 4. Update Extensible Storage metadata
    _schemaService.StampTableMetadata(targetView, config, config.SourceFilePath);

    doc.Regenerate();
}
```

### Benefits
- **Zero Sheet Disruption**: All viewports on all documentation sheets remain in place, perfectly preserving layouts, viewport titles, and print sets.
- **Atomic Transaction Rollback**: Grouped within `TransactionGroup`, ensuring that if Excel parsing fails, the previous view graphics are completely restored without corruption.
