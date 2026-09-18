# Debugging Log: Revit API ViewSpecific Filtering to Exclude 3D Model Elements

**Date:** 2026-07-22  
**Skill:** `revit-api`  
**API Surface:** `Autodesk.Revit.DB.Element.ViewSpecific`  

## 1. Symptom & Error
Calling `ElementTransformUtils.CopyElements(View sourceView, ICollection<ElementId> elementsToCopy, View targetView, Transform transform, CopyPasteOptions options)` throws an `ArgumentException`:
`The specified view cannot be used as a source or destination for copying elements between two views. Parameter name: sourceView`

## 2. Root Cause
`CopyElements(View, ...)` is only supported by the Revit API for view-specific 2D annotation/detail elements (`element.ViewSpecific == true`).
If the collection contains 3D model elements (e.g. `Muros`, `Pilares`, `Vigas`, `Suelos` where `element.ViewSpecific == false`), the Revit API rejects the call.

## 3. Recommended Solution Pattern
Filter the collector explicitly using `e.ViewSpecific`:

```csharp
public static List<ElementId> Get2DViewAnnotationsOnly(Document doc, ElementId viewId)
{
    return new FilteredElementCollector(doc, viewId)
        .WhereElementIsNotElementType()
        .Where(e => e.ViewSpecific && 
                    e is not View && 
                    e is not Viewport && 
                    e is not SunAndShadowSettings && 
                    e is not Level && 
                    e is not SketchPlane)
        .Select(e => e.Id)
        .ToList();
}
```

This guarantees:
1. No 3D model elements (Walls, Columns, Beams, Floors) are ever transferred or copied into the target project database.
2. Only 2D annotations (Detail Curves, Filled Regions, Dimensions, Text Notes) are copied.
3. The view-to-view `CopyElements` call executes cleanly without exceptions.
