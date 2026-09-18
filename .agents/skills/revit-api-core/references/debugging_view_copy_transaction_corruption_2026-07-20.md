# Debugging Report: View Copying Causes Transaction Corruption & Silently Rolls Back Sheet Creation

**Date:** 2026-07-20
**Skill:** revit-api-core

## Symptom
When transferring a `ViewSheet` with the "Transfer Sheet with Views" option checked, the add-in says "Completed successfully!" but the sheet is never created in the target model. This happens even when duplicating/suffixing names. However, when the option is unchecked, the sheet (with only its titleblock/2D elements) is created successfully.

## Root Cause
1. **Model Views are Not Copyable**: Model views (`FloorPlan`, `CeilingPlan`, `Elevation`, `Section`, `ThreeD`) cannot be copied between documents using `ElementTransformUtils.CopyElements`. Doing so throws an `ArgumentException`.
2. **Transaction Poisoning**: When `CopyElements` throws this exception inside an active transaction, Revit poisons the transaction and marks it internally as "Must Roll Back". Even if the exception is caught in a C# try-catch block and the transaction is committed using `.Commit()`, the commit fails under the hood (silently rolling back all changes, including the sheet created at the start of the transaction).
3. **Schedules are Not Viewports**: Schedules on a sheet are represented by `ScheduleSheetInstance` instead of `Viewport`, and trying to create a viewport for a schedule using `Viewport.Create` throws an exception, also poisoning the transaction.
4. **Already Placed Views**: Trying to place a non-legend/non-schedule view (like a drafting view or model view) on a sheet when it is already placed on another sheet throws an exception, poisoning the transaction.

## Solution
1. **Filter Copyable Views**: Only copy views that are copyable: `ViewType.DraftingView`, `ViewType.Legend`, and `ViewType.Schedule` (excluding sheet revision schedules). For model views, check if a view with the same name and type already exists in the target model. If it does, re-use it. If not, log a warning and skip viewport replication for it.
2. **Check View Placement Validity**: Before creating a viewport, verify if the view can be placed on the sheet using `Viewport.CanAddViewToSheet(...)`.
3. **Copy Schedules Correctly**: Use `ScheduleSheetInstance.Create` to place schedules on sheets instead of `Viewport.Create`.
4. **Log & Rethrow Exceptions**: Avoid swallowing exceptions silently in the main transfer transaction. If an exception occurs, log it using `LoggerService.LogError`, call `t.RollBack()`, and rethrow.

```csharp
// 1. Check if view is copyable
bool isCopyable = srcPlacedView.ViewType == ViewType.DraftingView ||
                  srcPlacedView.ViewType == ViewType.Legend ||
                  (srcPlacedView.ViewType == ViewType.Schedule && !srcPlacedView.IsTitleblockRevisionSchedule);

if (isCopyable)
{
    // Duplicate check and copy...
}
else
{
    // Model views: look for matching view by name in targetDoc
    var existingTargetView = new FilteredElementCollector(targetDoc)
        .OfClass(typeof(View))
        .Cast<View>()
        .FirstOrDefault(v => v.ViewType == srcPlacedView.ViewType && v.Name.Equals(srcPlacedView.Name, StringComparison.OrdinalIgnoreCase));

    if (existingTargetView != null)
    {
        targetViewId = existingTargetView.Id;
    }
}

// 2. Validate viewport placement before calling Viewport.Create
if (targetViewId != ElementId.InvalidElementId)
{
    if (srcPlacedView.ViewType != ViewType.Schedule)
    {
        if (Viewport.CanAddViewToSheet(targetDoc, targetSheet.Id, targetViewId))
        {
            Viewport.Create(targetDoc, targetSheet.Id, targetViewId, XYZ.Zero);
        }
    }
    else
    {
        // 3. Place schedules using ScheduleSheetInstance
        ScheduleSheetInstance.Create(targetDoc, targetSheet.Id, targetViewId, point);
    }
}
```
