# Debugging Log: Revit API Viewport GetBoxCenter NullReference Exception

**Date:** 2026-07-22  
**Skill:** `revit-api`  
**API Surface:** `Autodesk.Revit.DB.Viewport`  

## 1. Symptom
`srcViewport.GetBoxCenter()` returns `null` or throws when querying a Viewport on a source sheet, causing `NullReferenceException` when dereferencing properties like `center.X` or passing `center` to `Viewport.Create`.

## 2. Root Cause
In certain views (e.g. empty plan views or views with uncalculated bounding extents), `Viewport.GetBoxCenter()` evaluates to `null`.

## 3. Recommended Solution Pattern
Always wrap `GetBoxCenter()` in a safe fallback chain:

```csharp
XYZ center = null;
try { center = srcViewport.GetBoxCenter(); } catch { }

if (center == null)
{
    try
    {
        Outline outline = srcViewport.GetBoxOutline();
        if (outline != null)
        {
            center = (outline.MaximumPoint + outline.MinimumPoint) / 2.0;
        }
    }
    catch { }
}

if (center == null)
{
    center = new XYZ(1.5, 1.0, 0.0); // Sheet center fallback
}
```
