# Revit API Geometry Reference: Section Cut Marks & Callout Bubble Visibility Across Coordinate Systems & View Templates

**Date:** 2026-08-14  
**Module:** Cross-Document Transfer / Revit API View Section & Callouts  
**Skill:** `revit-api-geometry`, `revit-api-resilience`  
**Tags:** `RevitAPI`, `ViewSection`, `ViewPlan`, `Callouts`, `Transform`, `RevitLinkInstance`, `OST_Viewers`, `ViewTemplates`, `SECTION_COARSER_SCALE_PULLDOWN_METRIC`

---

## 1. Problem Overview

When programmatically generating or transferring `ViewSection` (Section and Detail views) and Callout views between Revit models:
- The views are successfully instantiated in the database and appear in the Project Browser.
- However, the 2D viewer annotation marks (Section heads, section cutting line, callout boundary boxes, and heads) fail to display on the parent floor/structural plan view.

---

## 2. Comprehensive Root Cause Analysis (Lessons Learned)

### A. Coordinate Transformation Across Links (`Transform By: Link`)
- `RevitLinkInstance.GetLinkDocument().Title` often differs from `doc.Title` by `.rvt` file extensions (e.g. `Project_Model` vs `Project_Model.rvt`).
- Matching must use normalized names (stripping `.rvt`) and fuzzy matching on `link.Name`.
- Callout bounding box corner projection must apply matrix multiplication $T \cdot \mathbf{x}$ to all 8 crop corners.

### B. "Hide at Scales Coarser Than" (`SECTION_COARSER_SCALE_PULLDOWN`)
- **Key Mechanism**: On `ViewSection`, `BuiltInParameter.SECTION_COARSER_SCALE_PULLDOWN_METRIC` (or `_IMPERIAL`) defines the coarsest scale denominator at which the section symbol is rendered in other views.
- **The Recursive Trap**: If `ponSections` / `ponCallouts` recurses (depth $\ge 2$), passing `parentView.Scale` as `minScale` will pass the child section's scale ($\sim 1:100$ or $1:50$) rather than the root plan's scale ($1:1000$).
- **The Template Re-lock Trap**: View Templates applied via `matchPlantilla` can overwrite the scale threshold parameter back to restrictive defaults.
- **Rule of Thumb**: When transferring to unknown or coarse host views (e.g., $1:1000$), set the scale threshold to at least **10000** on both the view and its template:
  ```csharp
  int targetScale = Math.Max(Math.Max(view.Scale, minScale), 10000);
  Parameter hideParam = v.get_Parameter(BuiltInParameter.SECTION_COARSER_SCALE_PULLDOWN_IMPERIAL)
                     ?? v.get_Parameter(BuiltInParameter.SECTION_COARSER_SCALE_PULLDOWN_METRIC);
  if (hideParam != null && !hideParam.IsReadOnly && hideParam.AsInteger() != targetScale)
  {
      hideParam.Set(targetScale);
  }
  ```

### C. Category Visibility (`OST_Viewers` & `OST_CalloutBoundary`)
- `OST_Viewers` contains subcategories `OST_SectionHeads`, `OST_CalloutBoundary`, `OST_CalloutHeads`, and `OST_CalloutLeader`.
- If the view or its assigned `ViewTemplate` has `OST_Viewers` hidden, all section and callout lines disappear.
- Must execute `view.SetCategoryHidden(OST_Viewers.Id, false)` and iterate all `SubCategories`.

### D. Vertical Bounding Box Intersection with View Range
- `ViewSection.CreateSection` creates a `BoundingBoxXYZ`.
- The section box must vertically intersect the cut plane of the parent plan view (`PlanViewRange.GetOffset(PlanViewPlane.CutPlane)` + `GenLevel.Elevation`).
- Extend `halfHeight` by `Math.Max(originalHeight, distToCutPlane + 30.0 ft)` to guarantee intersection.

### E. Phase & Discipline Alignment
- Newly instantiated views inherit target model default phases. If parent plan has `Phase 1` and section is created with `Phase 2` (or different `VIEW_DISCIPLINE`), Revit graphics pipeline hides the mark.
- Synchronize `BuiltInParameter.VIEW_PHASE`, `VIEW_PHASE_FILTER`, and `VIEW_DISCIPLINE` before finalizing view creation.

---

## 3. Final Sweep Architecture Pattern

To prevent late-stage overrides by View Templates or 2D detail consolidation from reverting visibility parameters, implement a **Final Sweep** after all child callouts and sections are created:

```csharp
// In parent orchestrator (e.g., processPlans):
EnsureViewerSymbolsVisible(targetDoc, targetPlanToUse, targetPlanToUse.Scale);
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
