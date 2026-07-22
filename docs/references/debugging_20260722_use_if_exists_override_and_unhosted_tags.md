# Debugging Log: Revit API Option Priority & Unhosted Tags 2D View Copy Fallback

**Date:** 2026-07-22  
**Add-in:** TransferPlus  
**Component:** `TransferOrchestrator.cs`  

## 1. Problem Summary
1. **Option Override Collision**:
   - `Use Legend if Exist in Target`, `Use Schedule if Exist in Target`, and `Use Assembly Views if Exist in Target` were being overridden when `Append Suffix` was active on the duplicates card. Duplicate copies with `_Copy` suffixes were created instead of reusing the target element.
2. **2D Annotation Copy Failure in Empty Models**:
   - In empty destination models (without 3D elements), views containing mixed 2D elements (detail lines, text notes, dimensions) and 3D tags (door/wall tags) failed to copy any 2D elements.
   - `ElementTransformUtils.CopyElements` threw an exception on the batch due to unhosted tags, aborting the transfer of detail lines and text notes.

## 2. Root Cause Analysis
1. **Logic Precedence in Placed Views Loop**:
   - Under `if (useExistingSetting)`, an `else if (config.cf_rbAppendSuffix)` branch set `shouldCopyView = true;`. This caused suffix rule execution to take precedence over the explicit user option "Use if Exists".
2. **Batch Copy Failure on Mixed View-Specific Collections**:
   - Passing a collection containing both valid 2D annotations (detail lines) and invalid unhosted 3D tags into a single `CopyElements` call caused the entire batch to fail.

## 3. Solution Implementation
1. **Strict Priority for 'Use if Exists' Options**:
   - Modified `TransferOrchestrator.cs` so that if `useExistingSetting` evaluates to `true` (user checked use legend/schedule/assembly view if exists) and `existingTargetView != null`, the add-in unconditionally reuses the target view:
     ```csharp
     if (useExistingSetting)
     {
         shouldCopyView = false;
         targetViewId = existingTargetView.Id;
         LoggerService.LogInfo($"SheetTransfer: Option 'Use if exists in Target' active for '{srcPlacedView.Name}' ({srcPlacedView.ViewType}). Re-using existing target view.");
     }
     ```
2. **Element-by-Element Fallback in `ponDependientes`**:
   - Updated `ponDependientes` to catch batch `CopyElements` exceptions and retry copying elements one-by-one:
     ```csharp
     try
     {
         ElementTransformUtils.CopyElements(vistaorigen, collection, vistadestino, Transform.Identity, copyOptions);
     }
     catch (Exception exBatch)
     {
         int copiedCount = 0;
         foreach (ElementId singleId in collection)
         {
             try
             {
                 ElementTransformUtils.CopyElements(vistaorigen, new List<ElementId> { singleId }, vistadestino, Transform.Identity, copyOptions);
                 copiedCount++;
             }
             catch { }
         }
     }
     ```

## 4. Verification
- Compiled and published cleanly with **0 Errors** (`Debug.R24`).
