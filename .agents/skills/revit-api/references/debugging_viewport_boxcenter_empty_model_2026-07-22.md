# Debugging Log: Revit API Viewport BoxCenter Positioning for Empty Models

**Date:** 2026-07-22  
**Skill:** `revit-api`  
**API Surface:** `Autodesk.Revit.DB.Viewport`  

## 1. Symptom & Error
When creating a `Viewport` on a `ViewSheet` targeting a newly created `ViewPlan` in an empty Revit model, calling `viewport.get_BoundingBox(sheet)` returns `null`.
Attempting to read `boundingBox.Max` or `boundingBox.Min` throws `NullReferenceException` (`Referencia a objeto no establecida como instancia de un objeto`).

## 2. Root Cause
In Revit, a view that contains no rendered 3D geometry or has an un-regenerated crop box will return `null` for its `Viewport.get_BoundingBox(sheet)` bounds.

## 3. Recommended Solution Pattern
Avoid using `get_BoundingBox` for viewport positioning. Use the native `GetBoxCenter()` and `SetBoxCenter(XYZ)` methods on `Viewport`:

```csharp
// Retrieve center from source viewport
XYZ center = srcViewport.GetBoxCenter();

// Create target viewport
Viewport targetViewport = Viewport.Create(targetDoc, targetSheet.Id, targetViewId, center);

// Apply type, center, and rotation safely
try
{
    targetViewport.SetBoxCenter(center);
    targetViewport.Rotation = srcViewport.Rotation;
}
catch (Exception ex)
{
    // Handle or log silently
}
```

## 4. View Filters & Overrides Guard on ViewSchedule
Always verify `view.AreGraphicsOverridesAllowed()` before calling `view.GetFilters()` or `view.GetCategoryOverrides()`:

```csharp
if (view == null) return;
if (view is ViewSchedule vs && vs.IsTitleblockRevisionSchedule) return;
if (view is ViewSchedule) return;
if (!view.AreGraphicsOverridesAllowed()) return;

// Safe to process filters or category overrides
var filters = view.GetFilters();
```
