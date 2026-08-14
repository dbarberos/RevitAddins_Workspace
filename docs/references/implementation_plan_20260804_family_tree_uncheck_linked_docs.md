# Implementation Plan — Tree Explorer Refinements & Linked Models Restoration

## Summary of Completed Tasks

This implementation plan details the four core fixes executed in **TransferPlus**:
1. **Azure Storage .NET 4.8 Compatibility**: Fixed runtime `MissingMethodException` when enumerating Azurite blobs by replacing `await foreach` with `Task.Run(() => containerClient.GetBlobs(...))`.
2. **TreeView Default Expansion & Clipping Fix**:
   - Family Mode: Default expansion down to Containers (`allNode.IsExpanded = true`, `containerNode.IsExpanded = true`, `categoryNode.IsExpanded = false`).
   - General Mode: Default expansion down to All (`allNode.IsExpanded = true`, `categoryNode.IsExpanded = false`).
   - Text Clipping: Set `ScrollViewer.HorizontalScrollBarVisibility="Auto"` and removed artificial `ClipToBounds` transforms so long element/family names display completely.
3. **Tree Initial Unchecked State**: Fixed default selection bug by setting `_isChecked = false` in `FamilySymbolItemModel` and enforcing `SetCheckedState(false)` upon tree creation.
4. **Linked Models in Dropdown**: Updated `LoadDocuments()` in `TransferPlusViewModel.cs` to collect loaded `RevitLinkInstance` models via `FilteredElementCollector`, restoring linked models in *"Apply transfer from:"* for both General and Family Modes.

## Affected Components

### [TransferPlus](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus)

#### [MODIFY] [AzureStorageService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/AzureStorageService.cs)
- Converted `GetBlobsAsync` `await foreach` to `Task.Run(() => containerClient.GetBlobs(...))` pageable iteration.

#### [MODIFY] [FamilyItemModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/FamilyItemModel.cs)
- Updated `FamilySymbolItemModel` default properties `_isSelected` and `_isChecked` to `false`.

#### [MODIFY] [TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs)
- Updated `BuildFamilyTree()` and `BuildTree()` expansion levels and enforced initial `allNode.SetCheckedState(false)`.
- Updated `LoadDocuments()` to collect loaded `RevitLinkInstance` documents from `_targetDoc`.

#### [MODIFY] [TransferPlusView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml)
- Updated `CheckboxTreeTemplate` and set `ScrollViewer.HorizontalScrollBarVisibility="Auto"` on `<TreeView>`.

## Verification Plan

### Automated Build Verification
- Run `dotnet build "TransferPlus\TransferPlus.csproj" -c "Debug R24"` (verified 0 Errors, 0 Warnings for breaking changes).

### Manual UI Verification
- Verify TreeView node expansion and horizontal scroll behavior.
- Verify 0 checked items on plugin startup or source document change.
- Verify linked models appearance in *"Apply transfer from:"* dropdown.
