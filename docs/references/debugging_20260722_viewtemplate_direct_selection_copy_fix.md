# Debugging Log: Revit API ViewTemplate Direct Copying & Standalone View Synchronization

**Date:** 2026-07-22  
**Add-in:** TransferPlus  
**Component:** `TransferOrchestrator.cs`  

## 1. Problem Summary
1. **View Templates Selected in TreeView Not Copying**:
   - Selecting a View Template (e.g. `KRN_000_MEDICIONES`) directly in the TreeView resulted in log line: `INFO: Transfer: Model view 'KRN_000_MEDICIONES' (type FloorPlan) excluded from direct CopyElements. Handled separately.`
   - However, View Templates were omitted from plan/sheet processing and were dropped without being copied to the target document.
2. **Existing Standalone Plan Views Skipped**:
   - Selecting a standalone plan view that already existed in the target model resulted in `Skipping creation` without matching template/filters or copying 2D detail elements.

## 2. Root Cause Analysis
- `isCopyableViaDocumentCopy` evaluated `v.IsTemplate` to `false`, omitting View Templates from `elementsCopyList`.
- In `planViewsToTransfer`, existing target views triggered a simple `Skipping creation` statement without executing `matchPlantilla` or `ponDependientes`.

## 3. Solution Implementation
1. **Added `v.IsTemplate` to `isCopyableViaDocumentCopy`**:
   ```csharp
   bool isCopyableViaDocumentCopy = v.IsTemplate ||
                                    v.ViewType == ViewType.DraftingView ||
                                    v.ViewType == ViewType.Legend ||
                                    (v is ViewSchedule vs && !vs.IsTitleblockRevisionSchedule);
   ```
2. **Support Keep Original & Append Suffix on Standalone Plan Views**:
   - Re-use target view if `Keep Original` is active, applying `matchPlantilla` and `ponDependientes`.
   - Create new view with suffix if `Append Suffix` is active.

## 4. Verification
- Compiled cleanly with **0 Errors** and deployed `TransferPlus.dll`.
