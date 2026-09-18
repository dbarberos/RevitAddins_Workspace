# Debugging Log: Revit API Viewport Placement NullReferenceException in Empty Models

**Date:** 2026-07-22  
**Add-in:** TransferPlus  
**Component:** `TransferOrchestrator.cs`  

## 1. Problem Summary
1. **Empty Model Viewport Placement Crash**:
   - When transferring a `ViewSheet` with a 3D plan view into a completely empty destination model (no 3D geometry), `TransferOrchestrator.cs` threw `ERROR in SheetTransfer: Failed processing view '2243642' on sheet '420': Referencia a objeto no establecida como instancia de un objeto.`
   - The view creation succeeded (Level and ViewPlan were created), but viewport placement aborted.
2. **Schedule View Filter Exception**:
   - Logs reported `EXCEPTION in CopyFilters: The view type does not support View Filters.` when attempting to process schedules.

## 2. Root Cause Analysis
1. **Viewport BoundingBox Evaluation Failure**:
   - `get_BoundingBox(sourceSheet)` and `get_BoundingBox(targetSheet)` were evaluated to compute the center of the viewport.
   - In an empty target model where the view has no 3D elements or crop box geometry rendered, `get_BoundingBox()` returns `null`.
   - Accessing `.Max` or `.Min` on `null` triggered `NullReferenceException`.
2. **Schedule Filter Support Limitation**:
   - `ViewSchedule` elements do not support filters or graphic category overrides in Revit API. Calling `GetFilters()` on a schedule threw `InvalidOperationException`.

## 3. Solution Implementation
1. **Native Viewport Center positioning (`Viewport.GetBoxCenter()` / `Viewport.SetBoxCenter()`):**
   - Replaced `get_BoundingBox()` calculation with native Revit API methods:
     ```csharp
     XYZ center = srcViewport.GetBoxCenter();
     Viewport targetViewport = Viewport.Create(targetDoc, targetSheet.Id, targetViewId, center);
     targetViewport.SetBoxCenter(center);
     targetViewport.Rotation = srcViewport.Rotation;
     ```
   - This places the viewport at the exact sheet center point without depending on 3D bounding box geometry.
2. **AreGraphicsOverridesAllowed Guards:**
   - Added guards to `CopyFilters` and `CopyViewGraphicsAndOverrides`:
     ```csharp
     if (vistaorigen is ViewSchedule vs && vs.IsTitleblockRevisionSchedule) return;
     if (vistaorigen is ViewSchedule) return;
     if (!vistaorigen.AreGraphicsOverridesAllowed()) return;
     ```

## 4. Verification
- Compiled cleanly with **0 Errors** across `.NET Framework 4.8` (`Debug.R24`).
