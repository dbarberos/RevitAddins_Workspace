# Debugging Log: Viewport Placement NullReferenceException & Regeneration

**Date:** 2026-07-22  
**Add-in:** TransferPlus  
**Component:** `TransferOrchestrator.cs`  

## 1. Problem
During view replication on sheets, placing viewports was throwing:
`ERROR in SheetTransfer: Failed creating viewport for '...' on sheet '...': Referencia a objeto no establece como instancia de un objeto.`

## 2. Root Cause Analysis
1. **Unregenerated Document Geometry**:
   Revit requires a document regeneration (`doc.Regenerate()`) after creating a view or placing sheet elements, so their physical extents and crop boundaries are calculated. If not regenerated, `Viewport.Create` internally fails to compute boundaries and can return `null` or throw exceptions.
2. **Missing Viewport Null Guard**:
   Calling `targetViewport.GetValidTypes()` without checking if `targetViewport == null` led to a `NullReferenceException`.

## 3. Solution
1. **Force Document Regeneration**:
   Call `targetDoc.Regenerate();` before starting the viewport and schedule replication loop.
2. **Defensive Viewport Check**:
   Wrap the viewport type and placement properties in an explicit null guard:
   ```csharp
   Viewport targetViewport = Viewport.Create(targetDoc, targetSheet.Id, targetViewId, center);
   if (targetViewport != null) { ... }
   ```

## 4. Verification
- Compiled and deployed with 0 errors.
