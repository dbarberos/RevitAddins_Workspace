# Debugging Log: Revit API Viewport Creation NullReference & Document Regeneration

**Date:** 2026-07-22  
**Skill:** `revit-api`  
**API Surface:** `Viewport.Create` / `Document.Regenerate`  

## 1. Symptom
Calling `Viewport.Create` throws `NullReferenceException` or returns `null` when placing a newly created view on a sheet.

## 2. Root Cause
Revit cannot determine the viewport boundaries if the view's layout/crop settings are not computed. This happens when the view is created in the same transaction but the document has not been regenerated.

## 3. Solution Pattern
1. Call `doc.Regenerate()` on the target document after view creation and before calling `Viewport.Create(...)`.
2. Guard the created `Viewport` against null:
```csharp
doc.Regenerate();
Viewport viewport = Viewport.Create(doc, sheetId, viewId, center);
if (viewport != null)
{
    // Configure types and box center
}
```
