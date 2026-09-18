# Debugging Log: Revit API View-Specific 2D Elements Collection Pattern

**Date:** 2026-07-22  
**Skill:** `revit-api`  
**API Surface:** `Autodesk.Revit.DB.FilteredElementCollector`  

## 1. Symptom & Problem
When attempting to copy all 2D annotation elements (detail lines, text notes, filled regions, dimensions) from a source view to a target view using `view.GetDependentElements(null)`, most 2D detail drawings are missing.

## 2. Root Cause
In the Revit API, `View.GetDependentElements(null)` returns internal view dependency entities (e.g. view crop shape, view filters, view templates), but does **NOT** return standard view-owned graphic elements like `DetailCurve`, `FilledRegion`, `Dimension`, or `TextNote`.

## 3. Recommended Solution Pattern
To collect 100% of 2D annotation and detail elements drawn in a view, use `FilteredElementCollector(Document, ElementId viewId)`:

```csharp
public static List<Element> GetAllViewSpecific2DElements(Document doc, ElementId viewId)
{
    return new FilteredElementCollector(doc, viewId)
        .WhereElementIsNotElementType()
        .Where(e => e is not View && 
                    e is not Viewport && 
                    e is not SunAndShadowSettings && 
                    e is not Level && 
                    e is not SketchPlane)
        .ToList();
}
```

This pattern ensures complete collection of:
- Detail Lines & Detail Curves (`DetailCurve`)
- Filled Regions (`FilledRegion`)
- Dimensions (`Dimension`)
- Text Notes (`TextNote`)
- Revision Clouds (`RevisionCloud`)
- Detail Component Instances (`FamilyInstance`)
