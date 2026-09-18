# Debugging: Sheet Transfer from Linked Models and View Template Retention during 2D Element Consolidation

**Date**: 2026-07-28  
**Component**: Revit API / View Sheet Transfer / View Templates / Link Graphical Overrides  
**Stack**: C# 12 / .NET Framework 4.8 / Revit API  

---

## 1. Symptom

1. **Empty View Replication on First Attempt**:
   When transferring a `ViewSheet` from a linked document (`RevitLinkInstance`), no placed views, viewports, or schedules were replicated on the first run (`GetAllPlacedViews` and `FilteredElementCollector(sourceDoc, sheet.Id)` returned 0 elements). Subsequent runs succeeded after Revit initialized internal document caches.

2. **Revit Link Overrides Overwritten by View Templates**:
   Linked models configured as hidden in the source view template remained visible in target views after the view template was applied.

3. **Loss of View Template Assignment on Transferred Views**:
   View Templates were copied to the target document, but were NOT assigned to the final transferred views (`targetView.ViewTemplateId` remained `InvalidElementId`).

---

## 2. Root Cause Analysis

### A. View-Scoped Collectors on Linked Documents
In the Revit API, `FilteredElementCollector(doc, viewId)` restricts queries to elements in `viewId`'s in-memory graphical display index. When `doc` is a background linked document (`RevitLinkInstance.GetLinkDocument()`), Revit lazy-loads graphical view display indices. On the first query of a sheet in a link document, `sourceSheet.GetAllPlacedViews()` and `FilteredElementCollector(sourceDoc, sourceSheet.Id).OfClass(typeof(Viewport))` return 0 elements.

### B. Link Visibility in View Templates
Evaluating `srcLink.IsHidden(srcView)` does not detect link visibility rules contained inside an applied View Template (`srcView.ViewTemplateId`). Furthermore, applying overrides skipped templates when `!targetView.IsTemplate` guard was enforced.

### C. 2D Element View Consolidation Wipes View Template Assignment
When view-dependent 2D elements (annotations, dimensions, detail lines) are copied using view-level `ElementTransformUtils.CopyElements(sourceView, 2dElements, targetView, ...)`, Revit creates a new side-effect view (`sideEffectView`) to host the elements, deletes the initial target view, and renames `sideEffectView`.
Because `matchPlantilla` originally ran *before* 2D element copy, the initial target view (which had the template assigned) was deleted. The new `sideEffectView` created by Revit's `CopyElements` was initialized with `ViewTemplateId = ElementId.InvalidElementId`. `matchPlantilla` was never re-invoked on the consolidated view.

---

## 3. Solution & Code Blueprint

### Fix 1: Global Document Collectors for Linked Document Sheets
Replace view-scoped collectors (`FilteredElementCollector(sourceDoc, sheet.Id)`) with global document collectors filtered in C# by `.OwnerViewId == sourceSheet.Id` or `.SheetId == sourceSheet.Id`. This queries the linked document's raw database without depending on uninitialized graphical display indices:

```csharp
// Collect Viewports globally across sourceDoc (bypasses uninitialized view display index on linked docs)
var globalViewports = new FilteredElementCollector(sourceDoc)
    .OfClass(typeof(Viewport))
    .Cast<Viewport>()
    .Where(vp => vp.OwnerViewId == sourceSheet.Id || vp.SheetId == sourceSheet.Id)
    .ToList();

foreach (var vp in globalViewports)
{
    if (vp.ViewId != ElementId.InvalidElementId && !placedViewIds.Contains(vp.ViewId))
    {
        placedViewIds.Add(vp.ViewId);
    }
}

// Collect ScheduleSheetInstances globally across sourceDoc
var globalSchedules = new FilteredElementCollector(sourceDoc)
    .OfClass(typeof(ScheduleSheetInstance))
    .Cast<ScheduleSheetInstance>()
    .Where(inst => inst.OwnerViewId == sourceSheet.Id)
    .ToList();

foreach (var inst in globalSchedules)
{
    if (inst.ScheduleId != ElementId.InvalidElementId)
    {
        if (sourceDoc.GetElement(inst.ScheduleId) is ViewSchedule vs && !vs.IsTitleblockRevisionSchedule)
        {
            if (!placedViewIds.Contains(inst.ScheduleId))
            {
                placedViewIds.Add(inst.ScheduleId);
            }
        }
    }
}
```

### Fix 2: Link Visibility in View Templates
Check `srcTemplateView.IsHidden(srcLink)` when `srcView` has a template assigned, and apply `targetGraphicsView.HideElements(new List<ElementId> { targetLink.Id })` directly to `targetGraphicsView` (which represents the target template `newTemplate` if a template is being processed).

### Fix 3: Re-apply `matchPlantilla` & Update `CopyViewSettings` for Consolidated Views

1. **Re-invoke `matchPlantilla` post-consolidation**:
```csharp
View consolidatedPlacedView = ponDependientes(sourceDoc, srcPlacedView.GetDependentElements(null), srcPlacedView, newPlacedView, options);
if (consolidatedPlacedView != null && consolidatedPlacedView.IsValidObject && consolidatedPlacedView.Id != targetViewId)
{
    targetViewId = consolidatedPlacedView.Id;
    processedViewsMap[placedViewId] = targetViewId;
    newPlacedView = consolidatedPlacedView;
    LoggerService.LogInfo($"SheetTransfer [CONSOLIDATED VIEW UPDATED]: Updated targetViewId to {targetViewId.Value} ('{newPlacedView.Name}') after 2D consolidation.");

    // RE-APPLY matchPlantilla on consolidated view to re-assign template and sync overrides
    matchPlantilla(sourceDoc, targetDoc, srcPlacedView, newPlacedView, options, config, duplicateItems);
}
```

2. **Assign `ViewTemplateId` in `CopyViewSettings`**:
```csharp
private static void CopyViewSettings(View srcView, View targetView)
{
    try
    {
        targetView.Scale = srcView.Scale;
        targetView.DetailLevel = srcView.DetailLevel;
        targetView.DisplayStyle = srcView.DisplayStyle;
        
        if (srcView.CropBoxActive)
        {
            targetView.CropBoxActive = srcView.CropBoxActive;
            targetView.CropBoxVisible = srcView.CropBoxVisible;
            targetView.CropBox = srcView.CropBox;
        }

        // View Template assignment
        if (srcView.ViewTemplateId != ElementId.InvalidElementId)
        {
            View srcTemplate = srcView.Document.GetElement(srcView.ViewTemplateId) as View;
            if (srcTemplate != null)
            {
                View targetTemplate = new FilteredElementCollector(targetView.Document)
                    .OfClass(typeof(View))
                    .Cast<View>()
                    .FirstOrDefault(v => v.IsTemplate && v.Name.Equals(srcTemplate.Name, StringComparison.OrdinalIgnoreCase));
                if (targetTemplate != null)
                {
                    try
                    {
                        targetView.ViewTemplateId = targetTemplate.Id;
                        LoggerService.LogInfo($"CopyViewSettings: Successfully assigned template '{targetTemplate.Name}' to view '{targetView.Name}'.");
                    }
                    catch { }
                }
            }
        }

        CopyViewInstanceParameters(srcView, targetView);
    }
    catch (Exception ex)
    {
        LoggerService.LogWarning($"CopyViewSettings: Failed for '{srcView.Name}': {ex.Message}");
    }
}
```

---

## 4. Verification

- Verified on sheet transfers from linked documents (`RevitLinkInstance`).
- Placed views, viewports, and schedules are replicated on the **very first attempt**.
- Transferred views successfully retain their assigned View Templates (`ViewTemplateId`), correctly hiding/showing linked models per template settings.

---

## 5. Callout View Consolidation and Reference Retention (`ponCallouts`)

### Symptom
When transferring views containing Callouts (`cf_chk_Callout = true`), `ponCallouts` threw:
`InvalidObjectException: The referenced object is not valid, possibly because it has been deleted from the database, or its creation was undone.`

### Root Cause
When 2D elements inside a Callout view are copied via `ponDependientes`, Revit creates a side-effect view, deletes the initial callout view (`view`), and returns the new consolidated callout view (`consolidatedView`).
`ponCallouts` did not capture the return value of `ponDependientes` and passed the deleted `view` object to subsequent operations and recursive calls.

### Solution
Capture the consolidated view return value in `ponCallouts`:
```csharp
if (CopiaDetalles)
{
    View consolidatedView = ponDependientes(origen, view2, view, copyOptions);
    if (consolidatedView != null && consolidatedView.IsValidObject)
    {
        view = consolidatedView; // Update reference to live consolidated view
        if (config != null)
        {
            matchPlantilla(origen, destino, view2, view, copyOptions, config, new List<TransferPlus.Models.DuplicateElementInfo>());
        }
    }
}

if (processedViewsMap != null && view != null && view.IsValidObject)
{
    processedViewsMap[calloutView.Id] = view.Id;
}

if (view != null && view.IsValidObject)
{
    ponCallouts(origen, destino, view2, view, copyOptions, CopiaDetalles, Contador + 1, transforma, T, config, processedViewsMap);
}
```

---

## 6. Primitive `ElementId` Comparison in Direct Plan View Loop

### Symptom
Even after updating `targetPlanToUse` to `View`, direct view transfer threw `InvalidObjectException` immediately after `ponDependientes [CONSOLIDATION SUCCESS]`.

### Root Cause
Line 1169 contained: `if (..., consolidatedPlan.Id != targetPlanToUse.Id)`
`ponDependientes` deleted `targetPlanToUse` from the Revit database via `destino.Delete(emptyViewId)` and returned `consolidatedPlan`.
When C# evaluated `targetPlanToUse.Id` on the deleted `targetPlanToUse` object, Revit's C++ wrapper threw `InvalidObjectException`.

In contrast, `SheetTransfer` was comparing `consolidatedPlacedView.Id != targetViewId` where `targetViewId` was a primitive `ElementId` struct stored *before* `ponDependientes`.

### Solution
Store `ElementId previousTargetPlanId = targetPlanToUse.Id;` as a primitive struct *before* calling `ponDependientes`:
```csharp
ElementId previousTargetPlanId = targetPlanToUse.Id;
View consolidatedPlan = ponDependientes(sourceDoc, srcViewPlan, targetPlanToUse, options);
if (consolidatedPlan != null && consolidatedPlan.IsValidObject)
{
    targetPlanToUse = consolidatedPlan;
    processedViewsMap[srcViewPlan.Id] = targetPlanToUse.Id;

    if (consolidatedPlan.Id != previousTargetPlanId)
    {
        LoggerService.LogInfo($"Transfer [CONSOLIDATED PLAN UPDATED]: Updated targetPlanToUse to {targetPlanToUse.Id.Value} ('{targetPlanToUse.Name}') after 2D consolidation.");
        matchPlantilla(sourceDoc, targetDoc, srcViewPlan, targetPlanToUse, options, config, duplicateItems);
    }
}
```

---

## 7. Callout View Preservation & Bubble Link Protection (`IsCalloutView`)

### Symptom
When transferring views with Callouts (`ponCallouts`), the Callout Bubble/Tag in the parent view and the Callout View itself disappeared from the target model.

### Root Cause
In Revit, deleting a Callout View via `destino.Delete(calloutViewId)` **automatically destroys the Callout Bubble/Tag in the parent view**.
When `ponDependientes` ran 2D element consolidation on a Callout View, Revit created a temporary side-effect view (`sideEffectView`). `ponDependientes` then executed `destino.Delete(emptyViewId)` to delete `vistadestino` (the initial callout view created by Revit when inserting the callout tag in the parent view).
Deleting `vistadestino` destroyed the Callout Tag in the parent view, and `sideEffectView` was an unattached standalone view that could not even be renamed.

### Solution
1. Add `IsCalloutView(View view)` to detect if a view is a Callout/Section view linked to a parent view bubble:
```csharp
public static bool IsCalloutView(View view)
{
    if (view == null) return false;
    try
    {
        var param = view.get_Parameter(BuiltInParameter.SECTION_PARENT_VIEW_NAME);
        if (param != null && !string.IsNullOrWhiteSpace(param.AsString())) return true;
    }
    catch { }
    if (view.ViewType == ViewType.Section || view.ViewType == ViewType.Elevation) return true;
    if (view.Name != null && (view.Name.IndexOf("Llamada", StringComparison.OrdinalIgnoreCase) >= 0 || view.Name.IndexOf("Callout", StringComparison.OrdinalIgnoreCase) >= 0)) return true;
    return false;
}
```

2. In `ponDependientes`, if `IsCalloutView(vistadestino)` is true:
   - **NEVER delete `vistadestino`**.
   - Copy 2D elements from `sideEffectView` directly into `vistadestino`.
   - Delete only the temporary `sideEffectView`.
   - Return `vistadestino`.

This keeps the Callout Tag in the parent view 100% intact, linked, and visible, while populating the Callout View with all 2D annotations and parameters!



