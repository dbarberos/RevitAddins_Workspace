# Implementation Plan: Fix CAD Mode Rename Panel ('No elements checked for renaming')

**Project:** TransferPlus  
**Date:** 2026-09-15  
**Version:** 1.2.0  
**Status:** Completed  

---

## 1. Problem Diagnosis & Root Cause

In **CAD Mode** (`IsCadDetailsManagerActive = true`), when elements are checked in the explorer tree and the user clicks **"Apply"** in the **Rename** card:
* The command `OpenRenamePanelCommand` is triggered.
* In `TransferPlusViewModel.OpenRenamePanel()`:
  ```csharp
  if (IsFamiliesManagerActive)
  {
      ...
  }
  else
  {
      var checkedItems = new List<Elemento>();
      CollectCheckedItems(RootNodes, checkedItems);

      if (!checkedItems.Any())
      {
          TaskDialog.Show("TransferPlus", "No elements checked for renaming.");
          return;
      }
      ...
  }
  ```
* Because `IsFamiliesManagerActive` is `false`, the code fell into the `else` branch which calls `CollectCheckedItems(RootNodes, checkedItems)`.
* In CAD Mode, nodes in `RootNodes` contain `CadDetailItemModel` instances (not standard `Elemento` instances).
* Therefore, `checkedItems` was empty (`checkedItems.Count == 0`), triggering the dialog:
  `"No elements checked for renaming."`
* The Rename palette was never populated and `IsRenamePanelOpen` was never set to `true`.
* Furthermore:
  1. `UpdateCheckedCount()` only synchronized `RenamePreviewItems` for `IsFamiliesManagerActive` and standard `Elemento` items; it lacked dynamic synchronization for `CadDetailItemModel`.
  2. `TransferCommand` in CAD Mode did not read `RenamePreviewItems` to apply renamed names to transferred drafting views or CAD instances.

---

## 2. Implemented Architecture

### Component 1: Rename Item Model (`RenamePreviewItem.cs`)
- Added properties:
  - `public string? CadIdentifier { get; init; }`
  - `public CadDetailItemModel? CadItem { get; init; }`
- Added dedicated constructor:
  ```csharp
  public RenamePreviewItem(CadDetailItemModel cadItem, string cadIdentifier)
  {
      CadItem = cadItem;
      CadIdentifier = cadIdentifier;
      SourceId = cadItem.ElementId;
      OriginalName = !string.IsNullOrWhiteSpace(cadItem.Name) ? cadItem.Name : (!string.IsNullOrWhiteSpace(cadItem.ViewName) ? cadItem.ViewName : "CAD Detail");
      WorkingName = OriginalName;
      NewName = OriginalName;
  }
  ```

### Component 2: Main ViewModel (`TransferPlusViewModel.cs`)
1. **Helper Method `GetCadIdentifier`**:
   - Creates a deterministic identifier for CAD items:
     - If `cad.ElementId != null`: `$"CAD_ELEM_{cad.ElementId.Value}_{cad.Name}"`
     - If `cad.FilePath != null`: `$"CAD_FILE_{cad.FilePath}"`
     - Fallback: `$"CAD_ITEM_{cad.Category}_{cad.Name}_{cad.ViewName}_{cad.SheetName}"`
2. **`OpenRenamePanel()` Hookup**:
   - Added `if (IsCadDetailsManagerActive)` branch:
     - Collects checked items using `CollectCheckedCadItems(RootNodes, checkedCadItems)`.
     - Displays error dialog if no CAD items are checked.
     - Populates `RenamePreviewItems` with `new RenamePreviewItem(item, id)`.
     - Sets `SelectAllRenameItems = true`, `IsRenamePanelOpen = true`, and calls `UpdateRenamePreviews()`.
3. **`UpdateCheckedCount()` Dynamic Synchronization**:
   - Added `if (IsCadDetailsManagerActive)` branch inside `if (IsRenamePanelOpen || RenamePreviewItems.Any())`:
     - Dynamically adds newly checked CAD items to `RenamePreviewItems`.
     - Removes unchecked CAD items from `RenamePreviewItems`.
     - Keeps `SelectAllRenameItems` and previews synchronized.
4. **Manager Switching Cleanup**:
   - In `OnIsFamiliesManagerActiveChanged` and `OnIsCadDetailsManagerActiveChanged`, if `IsRenamePanelOpen`, call `CloseRenamePanel()` to avoid cross-mode data bleeding.
5. **CAD Transfer Renaming Integration**:
   - In `TransferCommand` under `IsCadDetailsManagerActive`:
     - Extracts `cadCustomNames` (`Dictionary<ElementId, string>`) and `cadRenameMap` (`Dictionary<string, string>`) from `RenamePreviewItems` where `pItem.IsSelected && pItem.NewName != pItem.OriginalName`.
     - Passes `cadCustomNames` to `familyService.TransferDraftingViews` and `familyService.TransferCadInstancesToDraftingViews`.
     - Passes `overrideViewName` to `provider.TransferCadItemAsync` for external CAD transfers.

### Component 3: Family Revit Service (`FamilyRevitService.cs`)
1. Updated `TransferDraftingViews(sourceDoc, targetDoc, viewIds, customNames)`:
   - Accepts optional `Dictionary<ElementId, string>? customNames = null`.
   - After copying views via `ElementTransformUtils.CopyElements`, renames destination views using matching `customNames[sourceId]`.
2. Updated `TransferCadInstancesToDraftingViews(sourceDoc, targetDoc, cadInstanceIds, customNames)`:
   - Accepts optional `Dictionary<ElementId, string>? customNames = null`.
   - Applies `customNames[cadId]` as `baseViewName` when generating the target drafting view.

---

## 3. Verification & Packaging

* **Debug Build**: `dotnet build TransferPlus/TransferPlus.csproj -c Debug.R24` passed with 0 errors.
* **Release Multi-version Build**: `Release.R24`, `Release.R25`, `Release.R26`, `Release.R27` compiled with 0 errors.
* **App Store Bundle Generation**: `build-bundle.ps1` packaged `TransferPlus.bundle` for 2024, 2025, 2026, and 2027 and outputted:
  - `TransferPlus\Deploy\TransferPlus_v1.2.0.zip`
  - `TransferPlus\TransferPlusPublishPackage\TransferPlus.bundle.zip`
