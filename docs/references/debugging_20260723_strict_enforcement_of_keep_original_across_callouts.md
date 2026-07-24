# Debugging Log: Strict Enforcement of Keep Original Across Callouts & Sheet Viewports

**Date:** 2026-07-23  
**Add-in:** TransferPlus  
**Component:** `TransferOrchestrator.cs` (`ponCallouts`, `TargetHasDuplicateName`)  

## 1. Problem Summary
When `Keep Original` (`config.cf_rbKeepOriginal`) was active, transferring a view plan or sheet that contained callouts or child viewports resulted in Revit creating duplicate view copies with a numeric suffix (e.g. `P1 - EST - OFICINAS_Nivel Oficinas 1`).

## 2. Root Cause Analysis
1. **Unconditional `CopyElements` in `ponCallouts`**:
   - `ponCallouts` iterated through dependent views (`vistaorigen.GetDependentElements`) and invoked `ElementTransformUtils.CopyElements` directly without checking whether `config.cf_rbKeepOriginal` was active or if a view with the same name already existed in `destino`.
   - When Revit copied the callout view element into `destino`, it detected the existing view name and automatically appended ` 1` (or ` 2`).
2. **`TargetHasDuplicateName` for `ViewSheet`**:
   - `TargetHasDuplicateName` checked `ViewSheet` elements using `View.Name` instead of `ViewSheet.SheetNumber`.

## 3. Solution Implementation
1. **Pre-check in `ponCallouts`**:
   - Updated `ponCallouts` signature to receive `Configuraciones config`.
   - Evaluates `FilteredElementCollector(destino).OfClass(typeof(View))` for matching callout names.
   - If `existingCallout != null` and `Keep Original` is active, logs `ponCallouts: Callout view '{calloutView.Name}' already exists in target document. Option 'Keep Original' active. Re-using target callout view.`, synchronizes 2D elements/nested callouts onto `existingCallout`, and skips calling `ElementTransformUtils.CopyElements`.
2. **Sheet Number Resolution in `TargetHasDuplicateName`**:
   - Explicitly evaluates `ViewSheet` by `SheetNumber` and `Name` to ensure correct duplicate detection.

## 4. Verification
- Compiled for `.NET Framework 4.8` (`Debug.R24`) with **0 Errors**.
