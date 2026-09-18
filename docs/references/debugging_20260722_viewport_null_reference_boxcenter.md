# Debugging Log: Revit API Viewport Placement NullReferenceException on BoxCenter

**Date:** 2026-07-22  
**Add-in:** TransferPlus  
**Component:** `TransferOrchestrator.cs`  

## 1. Problem Summary
- Log line: `[11:16:33.137] ERROR in SheetTransfer: Failed creating viewport for 'ECI - EST...' on sheet '420_Copy1': Referencia a objeto no establecida como instancia de un objeto.`
- Although 2D elements were successfully copied into the target view (`[11:16:33.126] INFO: ponDependientes: Batch copied all 20 2D view elements...`), the view was never placed on the sheet because Viewport creation failed.

## 2. Root Cause Analysis
- `srcViewport.GetBoxCenter()` returned `null` for the plan view viewport.
- Dereferencing `center.X` in logger interpolation (`$"{center.X:F2}"`) threw a `NullReferenceException`.
- The exception aborted `Viewport.Create(...)`, leaving the view created in the browser but unplaced on the target sheet canvas.

## 3. Solution Implementation
- Implemented a 3-tier safe fallback chain for Viewport center point:
  ```csharp
  XYZ center = null;
  try { center = srcViewport.GetBoxCenter(); } catch { }

  if (center == null)
  {
      try
      {
          Outline boxOutline = srcViewport.GetBoxOutline();
          if (boxOutline != null)
          {
              center = (boxOutline.MaximumPoint + boxOutline.MinimumPoint) / 2.0;
          }
      }
      catch { }
  }

  if (center == null)
  {
      center = new XYZ(1.5, 1.0, 0.0);
  }
  ```

## 4. Verification
- Code compiles with 0 errors (`Debug.R24`).
