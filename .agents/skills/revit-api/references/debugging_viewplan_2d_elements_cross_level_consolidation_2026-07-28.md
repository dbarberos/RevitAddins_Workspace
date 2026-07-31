# Debugging Report: ViewPlan 2D Element Transfer & Cross-Level View Consolidation Pattern

**Date**: 2026-07-28  
**Component**: Revit API / View Transfer / `ElementTransformUtils.CopyElements` / 2D Detail Elements  
**Target Skill**: `revit-api`  

---

## 1. Problem & Symptoms

When transferring a floor plan view (`ViewPlan`) across models where source and target levels differ in elevation (or when transferring 2D detail lines/annotations across level mappings):
1. **SketchPlane Exception on ViewPlan**: Calling `EnsureViewWorkplane` assigned `targetViewPlan.SketchPlane = sk`, causing `NewDetailCurve` or detail curve operations to throw:
   > `Autodesk.Revit.Exceptions.ArgumentException: View does not and may not contain a fixed sketch plane. Parameter name: view.`
2. **Element-by-Element Join Failure**: Copying detail lines individually via `CopyElements(new List<ElementId>{ singleId })` threw:
   > `Copying one or more elements failed.`
   This occurred because detail lines in Revit are joined and constrained to each other; copying one line in isolation breaks geometric joins.
3. **Revit Engine Side-Effect View Duplication**:
   - Calling `ElementTransformUtils.CopyElements(sourceView, all2DIds, targetView, Transform.Identity, copyOptions)` across different level elevations causes Revit's internal C++ engine to instantiate a new side-effect view (`ViewPlanName1`, e.g. `P1 - EST - OFICINAS_Nivel Oficinas1`) on the matching level to host all 2D elements.
   - The initial target view (`targetView`) remained empty while the new view (`ViewPlanName1`) received 100% of the 2D detail elements.
   - Deleting the side-effect view lost all 2D elements and triggered warning popups.

---

## 2. Root Cause Analysis

1. **Revit API Constraint on `ViewPlan` SketchPlane**:
   - In Autodesk Revit API, a `ViewPlan` (Floor Plan, Structural Plan) is model-derived and MUST NOT have an explicitly assigned `SketchPlane`. Setting `targetViewPlan.SketchPlane` corrupts internal view state for detail curve factories.
2. **Geometric Connectivity in 2D Detail Elements**:
   - 2D detail lines (`DetailLine`, `DetailArc`) share endpoints, joined corners, or alignment constraints. Copying them individually prevents Revit's dependency solver from resolving endpoints, triggering `CopyElements` failure.
3. **Level Elevation Matching & View Creation in `CopyElements`**:
   - When 2D elements originate from a source view on Level `P1` ($Z_1$) and are pasted into a view on Level `Nivel 8` ($Z_2$), Revit API attempts to match the workplane level.
   - If Level `P1` exists in the target document, Revit creates a side-effect view on Level `P1` named `TargetViewName1` and places all 2D elements into it.

---

## 3. Solution & Architectural Pattern: View Consolidation

### A. Guard `EnsureViewWorkplane` for `ViewPlan`
Never assign `targetView.SketchPlane` to a `ViewPlan`:
```csharp
if (targetView is ViewPlan) return;
```

### B. Batch Copy 2D Elements
Always pass all 2D view-specific element IDs in a **single batch** to `CopyElements` so Revit resolves all line joins and endpoints simultaneously:
```csharp
var all2DIds = viewElements.Select(e => e.Id).ToList();
var copiedBatchIds = ElementTransformUtils.CopyElements(vistaorigen, all2DIds, vistadestino, Transform.Identity, copyOptions);
```

### C. View Consolidation Pattern (Side-Effect View Merging)
When `CopyElements` instantiates a side-effect view containing 100% of the 2D elements:
1. Capture `HashSet<ElementId> existingViewIdsBeforeCopy` prior to calling `CopyElements`.
2. Detect the newly created side-effect view (`!existingViewIdsBeforeCopy.Contains(v.Id) && v.Id != vistadestino.Id`).
3. Copy view settings (`CopyViewSettings`) and instance parameters (`CopyViewInstanceParameters`) from source view to `sideEffectView`.
4. Delete the initial empty view `vistadestino.Id`.
5. Rename `sideEffectView` from `TargetViewName1` to `TargetViewName` (`vistadestino.Name`).
6. Update session tracking (`processedViewsMap[sourceView.Id] = sideEffectView.Id`).

```csharp
var existingViewIdsBeforeCopy = new HashSet<ElementId>(
    new FilteredElementCollector(destino)
        .OfClass(typeof(View))
        .WhereElementIsNotElementType()
        .Select(v => v.Id)
);
int viewsBefore = existingViewIdsBeforeCopy.Count;

var copiedBatchIds = ElementTransformUtils.CopyElements(vistaorigen, all2DIds, vistadestino, Transform.Identity, copyOptions);
int viewsAfter = new FilteredElementCollector(destino).OfClass(typeof(View)).WhereElementIsNotElementType().Count();

if (viewsAfter > viewsBefore)
{
    var newlyCreatedViews = new FilteredElementCollector(destino)
        .OfClass(typeof(View))
        .WhereElementIsNotElementType()
        .Cast<View>()
        .Where(v => !existingViewIdsBeforeCopy.Contains(v.Id) && v.Id != vistadestino.Id)
        .ToList();

    View sideEffectView = newlyCreatedViews.FirstOrDefault();
    if (sideEffectView != null && sideEffectView.IsValidObject)
    {
        string targetName = vistadestino.Name;
        ElementId emptyViewId = vistadestino.Id;

        CopyViewSettings(vistaorigen, sideEffectView);
        CopyViewInstanceParameters(vistaorigen, sideEffectView);

        try { destino.Delete(emptyViewId); } catch { }
        try { sideEffectView.Name = targetName; } catch { }

        return sideEffectView;
    }
}
```

---

## 4. Key Takeaways & Rules

1. **`ViewPlan` Workplanes**: NEVER set `targetViewPlan.SketchPlane`.
2. **Batch Operations**: ALWAYS pass all 2D detail line IDs in a single batch to `CopyElements`.
3. **Consolidation**: NEVER delete a newly created side-effect view when transferring 2D elements. Consolidate it by transferring parameters, deleting the initial empty view, and renaming the populated view to the target name.
