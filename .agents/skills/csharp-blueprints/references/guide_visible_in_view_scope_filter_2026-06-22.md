# Design Pattern: "Visible in Current View" Scope for Element Filtering

**Date:** 2026-06-22  
**Skill Target:** `csharp-blueprints` / `revit-api`  
**Add-in:** FilterPlus

---

## Overview

The FilterPlus add-in needed a third **WHERE** scope for the "Increase Checked" feature, in addition to existing ones:

| Scope | Revit Collector Equivalent |
|---|---|
| All Model | `FilteredElementCollector(doc)` |
| Elements in View | Elements where `OwnerViewId == ActiveView.Id` or have a visible bounding box |
| **Visible in Current View** *(new)* | `FilteredElementCollector(doc, doc.ActiveView.Id)` |

---

## Implementation

### XAML (RadioButton)
```xml
<RadioButton Content="Visible in current view"
             IsChecked="{Binding IncreaseWhereVisibleInView}"
             GroupName="WhereGroup" />
```

### ViewModel Property
```csharp
[ObservableProperty]
private bool _increaseWhereVisibleInView;
```

### Collector Logic
```csharp
if (IncreaseWhereVisibleInView)
{
    var visibleCollector = new FilteredElementCollector(doc, doc.ActiveView.Id);
    domainElements = visibleCollector.WhereElementIsNotElementType().ToElements().ToList();
}
else if (IncreaseWhereCurrentView)
{
    var viewCollector = new FilteredElementCollector(doc);
    domainElements = viewCollector.WhereElementIsNotElementType().ToElements()
        .Where(el => el.OwnerViewId == doc.ActiveView.Id || el.get_BoundingBox(doc.ActiveView) != null)
        .ToList();
}
else
{
    var modelCollector = new FilteredElementCollector(doc);
    domainElements = modelCollector.WhereElementIsNotElementType().ToElements().ToList();
}
```

---

## Key Rule

> **For "Visible in Current View", always use `FilteredElementCollector(doc, viewId)` — the two-argument overload. This is the most performant way to limit collection to a specific view's visible elements. Never simulate visibility with a bounding box null-check for this purpose, as it is significantly slower.**

---

## RadioButton Group Name Rule
When adding new `RadioButton` controls to an existing group (e.g., `WhereGroup`), ensure all buttons in the same logical group share the same `GroupName` attribute value. Omitting this causes all buttons to be simultaneously selectable.
