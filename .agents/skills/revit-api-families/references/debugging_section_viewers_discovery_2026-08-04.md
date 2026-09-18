# Debugging Report: Finding Section Marks placed on a View (`OST_Viewers`)

* **Date:** 2026-08-04
* **Domain:** Revit API / View Management / Document Automation (`revit-api-families`)
* **Problem:** Searching for section/detail markers placed on a specific floor plan view returned 0 child views when using a document-wide `FilteredElementCollector(doc)`.

---

## Root Cause Analysis

1. `ViewSection` objects in Revit have `OwnerViewId = -1` because they are top-level model views, not dependent children of a floor plan.
2. The visual section marker visible on a floor plan is an annotation element belonging to `BuiltInCategory.OST_Viewers`.
3. A document-wide collector `new FilteredElementCollector(doc)` returns `OST_Views` elements instead of the actual `OST_Viewers` annotation symbols placed on specific views.
4. **Revit API Constraint:** `OST_Viewers` elements placed on a specific view are ONLY returned when using the **view-scoped** collector constructor: `new FilteredElementCollector(doc, viewId)`.

---

## Correct Implementation Pattern

```csharp
// Use view-scoped collector constructor to find section marks visible on 'parentView'
var viewScopedViewers = new FilteredElementCollector(doc, parentView.Id)
    .WherePasses(new ElementCategoryFilter(BuiltInCategory.OST_Viewers))
    .WhereElementIsNotElementType()
    .ToList();

var childSections = new List<View>();

foreach (var viewer in viewScopedViewers)
{
    // Inspect ElementId parameters on the viewer symbol to obtain the generated ViewSection
    foreach (Parameter p in viewer.Parameters)
    {
        if (p != null && p.StorageType == StorageType.ElementId &&
            p.AsElementId() is ElementId refId && refId != ElementId.InvalidElementId)
        {
            if (doc.GetElement(refId) is View refView && refView.IsValidObject && !refView.IsTemplate &&
                (refView.ViewType == ViewType.Section || refView.ViewType == ViewType.Detail))
            {
                if (!childSections.Any(cv => cv.Id.Value == refView.Id.Value))
                {
                    childSections.Add(refView);
                }
            }
        }
    }
}
```
