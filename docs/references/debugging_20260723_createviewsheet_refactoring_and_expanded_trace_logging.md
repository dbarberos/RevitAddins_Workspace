# Debugging Log: Refactoring CreateViewSheet & Expanding High-Resolution Trace Logging

**Date:** 2026-07-23  
**Add-in:** TransferPlus  
**Component:** `TransferOrchestrator.cs`, `LoggerService.cs`  

## 1. Problem Summary
1. **Duplicate Sheet Creation under "Keep Original"**:
   - `CreateViewSheet` was executing `ViewSheet.Create(targetDoc, titleBlockTypeId)` **before** evaluating whether a `ViewSheet` with the target `SheetNumber` already existed in `targetDoc`.
   - When `Keep Original` (`cf_rbKeepOriginal`) was active, `CreateViewSheet` proceeded to create a new sheet with an appended suffix/number (e.g. `A101 1`), generating two sheets in the target model.
2. **Residual Strict ViewType Search in `processSheetViewports`**:
   - Line 798 in `processSheetViewports` was still matching target views using `v.ViewType == srcPlacedView.ViewType`. If the target view had a slightly different internal sub-viewtype, it returned `null` and created a duplicate view plan.
3. **Lack of High-Resolution Trace Logs**:
   - Standard logs did not trace pre-checks, titleblock family resolution, viewport box center coordinates, and existing element reuse decisions.

## 2. Root Cause Analysis
1. `CreateViewSheet` instantiated `ViewSheet.Create` at the beginning of the function instead of pre-checking `targetDoc` first.
2. `processSheetViewports` line 798 had not been updated to match the name-only search logic introduced in other parts of `TransferOrchestrator.cs`.

## 3. Solution Implementation
1. **Pre-check in `CreateViewSheet`**:
   - Evaluates `FilteredElementCollector(targetDoc).OfClass(typeof(ViewSheet))` by `SheetNumber` first.
   - If `existingSheet != null` and `Keep Original` is active, logs the reuse and returns `existingSheet` immediately without invoking `ViewSheet.Create`.
2. **Unified View Name Matching**:
   - Updated line 798 in `processSheetViewports` to match target views by `Name.Trim()` across all non-template views.
3. **High-Resolution Debug Logging**:
   - Added `LoggerService.LogInfo` messages tracing:
     - `CreateViewSheet`: Pre-check for existing sheet, TitleBlock matching, and `ViewSheet.Create` execution.
     - `processSheetViewports`: Detailed placement evaluation, viewport center calculation, and view reuse/copy decisions.

## 4. Verification
- Compiled for `.NET Framework 4.8` (`Debug.R24`) with **0 Errors**.
