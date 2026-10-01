# Walkthrough - Main Window DataGrid Structure & Cell Parity with "Add Tables"

**Date:** 2026-10-01  
**Add-in:** TablePlus  
**Component:** `MainWindowView`, `MainWindowViewModel`, `TableItemModel`, `Converters.cs`

---

## 1. Overview & Objectives

In this phase, we brought complete cell structure and design consistency between the master dashboard table (`MainWindowView`) and the **Add Table** interface (`TableImportView`):

1. **Cell Structure Porting**:
   - Replaced static text presentations in `MainWindowView` with the exact modern cell structure from `TableImportView`.
   - Applied clean borderless styling with hover/focus indicators (`DataGridTextBoxStyle`).

2. **Editable View Name (Option B)**:
   - Changed the `View Name` column from a static `TextBlock` to an in-place editable `TextBox`.
   - Wired with `LostFocus` and `KeyDown` (Enter/Esc) events.
   - Automatically renames the actual Autodesk Revit `View` element inside an explicit `Transaction` (`"TablePlus: Rename Table View"`).
   - Validates for illegal Revit naming characters (`\ : { } [ ] | ; < > ? ` ~`) and reverts cleanly if Revit rejects the change.

3. **Interactive Column Controls**:
   - **Worksheet / Page**: Borderless `ComboBox` bound to `AvailableSheets` and `SelectedSheetName`.
   - **Region / Range**: `ComboBox` bound to `AvailableRegionModes` (`Entire Worksheet`, `Named Range`, `Custom Range`) and `SelectedRegionMode`.
   - **View Type**: `ComboBox` bound to `AvailableViewTypes` with compact display formatting via `EnumDisplayConverter`.
   - **Scale**: `ComboBox` bound to `AvailableScales` (`1:1`, `1:2`, `1:5`, `1:10`, `1:20`, `1:25`, `1:50`, `1:100`, `1:200`, `1:500`). Dynamically updates `view.Scale` in the active Revit model inside a dedicated `Transaction`.
   - **Type (Table vs Image)**: `ComboBox` bound to `AvailableImportTypes` with `EnumDisplayConverter`.

4. **Preserved Dashboard Capabilities**:
   - Retained frozen columns for selection checkboxes and view names.
   - Retained health status badges (`Up to Date`, `Modified`, `Missing`), `Auto-Sync` toggles, `B&W` overrides, and `🎨 Design...` style mapping buttons.

---

## 2. Updated Components

| File | Purpose |
|---|---|
| [`MainWindowView.xaml`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Views/MainWindowView.xaml) | Updated `TablesDataGrid.Columns` with editable View Name `TextBox`, dropdowns for Worksheet, Region, View Type, Scale, and Type. |
| [`MainWindowView.xaml.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Views/MainWindowView.xaml.cs) | Added `ViewNameTextBox_LostFocus` and `ViewNameTextBox_KeyDown` handlers to commit renames. |
| [`MainWindowViewModel.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/ViewModels/MainWindowViewModel.cs) | Implemented `RenameViewAsync` command and dynamic transaction handling for `ViewScale` and `RangeMode`. |
| [`TableItemModel.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Models/TableItemModel.cs) | Added `AvailableRegionModes`, `SelectedRegionMode`, `AvailableScales`, `AvailableViewTypes`, and `AvailableImportTypes`. |
| [`Converters.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Views/Converters.cs) | Centralized `EnumDisplayConverter` for shared usage across all TablePlus views. |

---

## 3. Verification

```text
dotnet build TablePlus\TablePlus.csproj -c "Debug R25" /p:DeployAddin=false
  TablePlus -> B:\REVIT\C#\RevitAddins_Workspace\TablePlus\bin\Debug R25\TablePlus.dll
Build succeeded. 0 Warning(s), 0 Error(s).

dotnet build TablePlus\TablePlus.csproj -c "Debug R24" /p:DeployAddin=false
  TablePlus -> B:\REVIT\C#\RevitAddins_Workspace\TablePlus\bin\Debug R24\TablePlus.dll
Build succeeded. 0 Warning(s), 0 Error(s).
```
