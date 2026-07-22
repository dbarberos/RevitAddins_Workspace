# Debugging Report: View & Sheet Copying Constraints & Suffix Duplication

**Date:** 2026-07-21
**Skill:** revit-api-core

## Symptom
1. Exception thrown during document-level element transfer:
   `ERROR in Transfer Elements: Las vistas de plano de este modelo no pueden contener más de un ejemplar de la misma vista. Parameter name: elementsToCopy`
2. Viewports failing to place on target sheets or skipped when a view with the same name already exists in target or is placed on another sheet.

## Root Cause
1. **Document-level CopyElements Limit**: Revit's `ElementTransformUtils.CopyElements(...)` CANNOT copy model views (`ViewPlan`, `ViewSection`, `ViewElevation`, `View3D`) between documents. Passing model views directly to `CopyElements` causes Revit to throw an `ArgumentException` and roll back the transaction.
2. **Revit Viewport Placement Rule**: Revit enforces that a single `View` instance can only be placed on ONE `ViewSheet` at a time. Placing a view that is already placed on another sheet (or duplicating a sheet with an existing view when "Append Suffix" is enabled) throws a viewport placement error if a new view instance is not generated.

## Solution & Code Fixes
1. **Filtering Model Views from Document-level Copy**:
   In `TransferOrchestrator.cs`, all `View` elements (except `ViewSheet`, `ViewDrafting`, `Legend`, and non-revision `ViewSchedule`) are now filtered out of `elementsCopyList`. Model views are NEVER passed to `ElementTransformUtils.CopyElements`.

2. **Sheet Replication with Append Suffix / Keep Original**:
   When replicating a sheet with views:
   - **If "Append Suffix" (`cf_rbAppendSuffix`) is active**: If a view with the same name exists in target (or for any duplicated model view), a BRAND NEW `ViewPlan` is created using `CreateViewPlan`, named with the suffix appended (e.g. `ViewName_TRANSFERPLUS`). Because it is a new view, `Viewport.CanAddViewToSheet` returns `true`, and it is placed on the target sheet without errors.
   - **If "Keep Original" (`cf_rbKeepOriginal`) is active**:
     - The tool checks `Viewport.CanAddViewToSheet(targetDoc, targetSheet.Id, existingTargetView.Id)`.
     - If the existing view in target is unplaced, it re-uses that view for the sheet viewport.
     - If the existing view is ALREADY placed on another sheet in target, it creates a new `ViewPlan` instance so the sheet has its view and does not fail or get skipped.

```csharp
// Filter non-copyable views from direct CopyElements
if (elem is View v)
{
    bool isCopyableViaDocumentCopy = v is ViewSheet ||
                                     v.ViewType == ViewType.DraftingView ||
                                     v.ViewType == ViewType.Legend ||
                                     (v is ViewSchedule vs && !vs.IsTitleblockRevisionSchedule);

    if (!isCopyableViaDocumentCopy)
    {
        LoggerService.LogInfo($"Transfer: Skipping direct CopyElements for model view '{v.Name}' (type {v.ViewType}).");
    }
    else
    {
        elementsCopyList.Add(item.eID);
    }
}
```
