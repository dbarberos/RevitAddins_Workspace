# Walkthrough: Integration of CAD Mode with PowerRename Palette and Transfer

**Project:** TransferPlus  
**Date:** 2026-09-15  
**Version:** 1.2.0  
**Status:** Validated and Packaged  

---

## 1. Overview

In TransferPlus, three distinct operational modes coexist in the UI:
1. **Standard Mode**: Transfers standard Revit system/model elements (`Elemento`).
2. **Family Mode** (`IsFamiliesManagerActive`): Transfers loadable families (`FamilyItemModel`) and family symbols (`FamilySymbolItemModel`).
3. **CAD Mode** (`IsCadDetailsManagerActive`): Transfers drafting views, imported CAD instances, linked CAD files, and external DWG/DXF/DGN/SAT files (`CadDetailItemModel`).

Previously, clicking **"Apply"** in the **Rename** card while in CAD Mode failed with the warning dialog `"No elements checked for renaming."`. This occurred because `OpenRenamePanel()` only had two branches: `if (IsFamiliesManagerActive)` and `else` (which assumed standard `Elemento` items).

---

## 2. Changes Made

### A. Model Layer: `RenamePreviewItem.cs`
- Added `CadIdentifier` (`string?`) and `CadItem` (`CadDetailItemModel?`).
- Added constructor `RenamePreviewItem(CadDetailItemModel cadItem, string cadIdentifier)` that resolves `OriginalName` cleanly from `cadItem.Name` or fallback `cadItem.ViewName`.

### B. ViewModel Layer: `TransferPlusViewModel.cs`
- **`GetCadIdentifier(CadDetailItemModel cad)`**: Generates stable unique keys (`CAD_ELEM_{id}_{name}`, `CAD_FILE_{path}`, etc.) to prevent duplicate collisions in dictionaries.
- **`OpenRenamePanel()`**: Added `if (IsCadDetailsManagerActive)` branch to collect checked CAD items via `CollectCheckedCadItems()`, populate `RenamePreviewItems`, and open the side panel.
- **`UpdateCheckedCount()`**: Added live dynamic synchronization for CAD items. Checking or unchecking nodes in the TreeView dynamically adds or removes items from the Rename DataGrid without resetting intact rename fields.
- **Manager Mode Switching**: Added automatic closing of the rename panel (`CloseRenamePanel()`) whenever `IsFamiliesManagerActive` or `IsCadDetailsManagerActive` changes, preventing cross-mode data pollution.
- **`TransferCommand`**: Integrated `cadCustomNames` (`Dictionary<ElementId, string>`) and `cadRenameMap` (`Dictionary<string, string>`) so that any transformed names in the Rename panel are passed to:
  - `FamilyRevitService.TransferDraftingViews(...)`
  - `FamilyRevitService.TransferCadInstancesToDraftingViews(...)`
  - `ICadProvider.TransferCadItemAsync(..., overrideViewName: ...)`

### C. Service Layer: `FamilyRevitService.cs`
- `TransferDraftingViews(...)`: Accepts optional `Dictionary<ElementId, string>? customNames = null` and renames duplicated views in `targetDoc`.
- `TransferCadInstancesToDraftingViews(...)`: Accepts optional `Dictionary<ElementId, string>? customNames = null` and overrides `baseViewName` before drafting view creation.

---

## 3. Verification & Build Results

| Verification Step | Command / Tool | Status | Details |
| :--- | :--- | :--- | :--- |
| **Debug Build** | `dotnet build -c Debug.R24` | **PASSED** | 0 compilation errors. |
| **Release R24** | `dotnet build -c Release.R24` | **PASSED** | 0 compilation errors. |
| **Release R25** | `dotnet build -c Release.R25` | **PASSED** | 0 compilation errors. |
| **Release R26** | `dotnet build -c Release.R26` | **PASSED** | 0 compilation errors. |
| **Release R27** | `dotnet build -c Release.R27` | **PASSED** | 0 compilation errors. |
| **Bundle Generation** | `build-bundle.ps1` | **PASSED** | Generated `TransferPlus_v1.2.0.zip` and `TransferPlus.bundle.zip` across Revit 2024-2027. |

---

## 4. User Testing Instructions

1. Open Revit and launch **TransferPlus**.
2. Activate CAD Mode by clicking **"CAD Details Manager: Activate"**.
3. Select any source document containing CAD links, CAD imports, or drafting views.
4. Mark one or more checkboxes in the TreeView.
5. Click **"Apply"** in the **"Rename:"** card.
6. The side Rename palette opens immediately, showing all checked CAD items.
7. Modify search/replace rules or format options (e.g. uppercase, prefix/suffix).
8. Toggle checkboxes in the tree and verify the Rename list reflects changes in real time.
9. Click **Transfer** to copy the CAD details into the target model under their new names.
