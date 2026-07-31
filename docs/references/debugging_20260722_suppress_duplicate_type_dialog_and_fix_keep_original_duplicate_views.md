# Debugging Log: Suppress Native Duplicate Types Dialog & Enforce "Keep Original" View Duplication Prevention

**Date:** 2026-07-22  
**Add-in:** TransferPlus  
**Component:** `TransferOrchestrator.cs`  

## 1. Problem Summary
1. **Confusing Native Modal Dialog**:
   - Revit displayed native popup dialog "Tipos duplicados: Los siguientes tipos ya existen pero son diferentes. Se utilizarán los tipos del proyecto en el que está pegando elementos." when copying 2D detail items or view elements.
2. **Duplicate Views Creation Bug**:
   - Transferring a view created TWO views in the target project (e.g. `P1 - EST - OFICINAS_Nivel Oficinas` AND `P1 - EST - OFICINAS_Nivel Oficinas 1`).
3. **Violation of "Keep Original" Setting**:
   - Even when `Keep Original` (`cf_rbKeepOriginal`) was selected in the "On Duplicates" card, the add-in was still creating a second duplicated view instead of skipping creation.

## 2. Root Cause Analysis
1. **Unconfigured `CopyPasteOptions`**:
   - `CopyPasteOptions` instantiated in `ponDependientes` and `ProcessSheetViewports` did not set `.SetDuplicateTypeNamesHandler(...)`. Without an explicit handler returning `DuplicateTypeAction.UseDestinationTypes`, Revit falls back to displaying native dialogs.
2. **Unconditional View Creation on Placed Views**:
   - In `ProcessSheetViewports`, if a model view already existed in `targetDoc` but was already placed on another sheet (`!canAddExisting`), the code unconditionally executed `CreateViewPlan`, ignoring the `Keep Original` setting.
3. **Automatic Suffix Fallback**:
   - Because `CreateViewPlan` attempted to set `targetViewPlan.Name = srcViewPlan.Name` when a view with that name already existed, it caught the name exception and called `GetUniqueViewName(...)`, appending ` 1` and producing the second view (`... 1`).

## 3. Solution Implementation
1. **Attached `CustomCopyHandlerOk`**:
   - Set `options.SetDuplicateTypeNamesHandler(new CustomCopyHandlerOk())` on all `CopyPasteOptions` instances in `ponDependientes` and `ProcessSheetViewports`. This automatically selects `UseDestinationTypes` and suppresses the native popup completely.
2. **Strict "Keep Original" Enforcement**:
   - Updated `ProcessSheetViewports`: under `cf_rbKeepOriginal`, if a view already exists in `targetDoc` and is placed on another sheet, `CreateViewPlan` is **never called** and no duplicate view is created.
3. **Suffix Scoping**:
   - Duplicate views are only created when `Add Suffix` (`cf_rbAppendSuffix`) is explicitly selected.

## 4. Verification
- Compiled for `.NET Framework 4.8` (`Debug.R24`) with **0 Errors**.
- Overwrote `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll`.
