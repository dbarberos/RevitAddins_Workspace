# Debugging Log: Section Cut Marks & Callout Bubble Visibility Across Coordinate Systems & View Templates

**Date:** 2026-08-14  
**Add-in / Module:** TransferPlus / `TransferOrchestrator.cs`  
**Tags:** `RevitAPI`, `ViewSection`, `ViewPlan`, `Callouts`, `Transform`, `RevitLinkInstance`, `OST_Viewers`, `ViewTemplates`, `ScaleThreshold`

---

## 1. Problem Description

When transferring a floor plan or structural plan view containing Section markers and Callout bubbles between Revit documents:
- The child `ViewSection` (sections) and callout views were created in the target document's Project Browser.
- However, on the transferred parent plan view (`vistadestino`), the 2D viewer marks (section cutting lines, section heads, callout boundaries, and callout heads) remained completely invisible.

---

## 2. Root Cause Analysis

### Iteration 1 — Initial Diagnosis (4 factors):

1. **Fragile Link Matching in `Transform By: Link`**: Matching failed due to `.rvt` extension differences. Fixed with `GetTransformForSource` and `StripRvtExtension`.
2. **Callout Bounding Box Projection Missed `T`**: `ponCallouts` didn't apply `T.OfPoint()`. Fixed.
3. **View Template Overwriting Scale Threshold & Category Visibility**: `matchPlantilla` reset `SECTION_COARSER_SCALE_PULLDOWN` back to restrictive values.
4. **Phase and PhaseFilter Mismatches**: Default phases on new views didn't match parent. Fixed with `SyncViewPhaseAndFilter`.

### Iteration 2 — Refined Diagnosis (Scale Threshold Still Wrong):

After Iteration 1 was applied, section marks and callout bubbles **still did not appear**. The log revealed:
```
EnsureViewerSymbolsVisible: Updated scale threshold on 'WIP_COORD_IFC-STR-IVM_Copy_12' from 50 to 100.
```

**Root cause**: The `targetScale` computation `Math.Max(view.Scale, minScale)` produced values too low because:

1. **Recursive context pollution**: In recursive `ponSections`/`ponCallouts` calls (depth >= 2), `vistadestino` is a **section view** (not the root plan view), so `vistadestino.Scale` is ~100 instead of ~1000.
2. **Condition logic was too restrictive**: The old check `current < targetScale && current > 0` skipped values where `current == 0` or when current equaled the (too-low) target.
3. **Name-based parameter fallback was fragile**: The `Parameters.Cast<Parameter>().FirstOrDefault()` search by localized name was unreliable.

---

## 3. Solution & Best Practices

### Key Fix: Guaranteed Minimum Scale of 10000

```csharp
int targetScale = Math.Max(Math.Max(view.Scale, minScale), 10000);
```

By setting the minimum to **10000**, section and callout marks are guaranteed to show at all common architectural scales (1:50 through 1:10000), regardless of what `vistadestino.Scale` evaluates to in recursive contexts.

### Key Fix: Always Set When Different

```csharp
if (current != targetScale)
{
    hideParam.Set(targetScale);
}
```

Instead of only updating when `current < targetScale && current > 0`, always set when the value differs. This ensures the parameter is correct even if a template sets it to 0 or a value higher than expected.

### Key Fix: Final Sweep in `processPlans`

After ALL `ponCallouts` and `ponSections` complete, iterate over every view in `processedViewsMap` and re-apply `EnsureViewerSymbolsVisible`:

```csharp
if (processedViewsMap != null && processedViewsMap.Count > 0)
{
    foreach (var kvp in processedViewsMap)
    {
        View mappedView = targetDoc.GetElement(kvp.Value) as View;
        if (mappedView != null && mappedView.IsValidObject
            && (mappedView.ViewType == ViewType.Section
                || mappedView.ViewType == ViewType.Detail
                || mappedView is ViewPlan))
        {
            EnsureViewerSymbolsVisible(targetDoc, mappedView, targetPlanToUse.Scale);
        }
    }
}
```

This provides a safety net against View Templates re-locking the `SECTION_COARSER_SCALE_PULLDOWN` parameter during nested template applications.

### Diagnostic Logging

Added explicit logging when the parameter is NULL or READ-ONLY:
```csharp
LoggerService.LogInfo($"EnsureViewerSymbolsVisible: Scale param on '{v.Name}' is {(hideParam == null ? "NULL" : "READ-ONLY")}. Cannot set.");
```

---

## 4. Full List of Revit API Reasons for Invisible Section/Callout Marks

| Cause | API Check | Status |
|-------|-----------|--------|
| "Hide at scales coarser than" too restrictive | `SECTION_COARSER_SCALE_PULLDOWN` >= parent scale | ✅ Fixed (Iteration 2) |
| OST_Viewers category hidden | `view.SetCategoryHidden(OST_Viewers, false)` | ✅ Fixed |
| View Template locks parameters | Set on template AND view | ✅ Fixed |
| Discipline mismatch | `VIEW_DISCIPLINE` synced | ✅ Fixed |
| Phase/PhaseFilter mismatch | `VIEW_PHASE` + `VIEW_PHASE_FILTER` synced | ✅ Fixed |
| BoundingBoxXYZ outside View Range | Half-height extends to cover cut plane | ✅ Fixed |
| Link Transform not applied | `GetTransformForSource` with clean name | ✅ Fixed |
| Crop Region excludes mark | Section origin within plan bounds | N/A (handled by API) |
