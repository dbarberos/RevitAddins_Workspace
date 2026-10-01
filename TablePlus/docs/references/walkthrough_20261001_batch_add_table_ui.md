# Walkthrough - Batch "Add Table" UI & Multi-File Management

**Date:** 2026-10-01  
**Add-in:** TablePlus  
**Component:** `TableImportView`, `TableImportViewModel`, `TableBatchImportItemModel`, `TableSourceSelectionView`

---

## 1. Overview & Objectives

In this phase, we completed the modernization of the **Add Table** workflow, transitioning from a single-file wizard to a full-featured, multi-item batch management interface matching the concepts and architecture of professional add-ins (e.g. DiRoots TableGen):

1. **Intermediate Source Selection (`TableSourceSelectionView`)**:
   - Resized and proportioned with generous dimensions (`620px` width, `170px` height) and `24px` horizontal and `20px` vertical margins.
   - Distinct, elegant title `"Select the source of your file/s:"` (`FontWeight="Bold"`, `FontSize="12"`, `Foreground="#999"`, `8px` gap).
   - High-contrast TransferPlus dropdown and `"Select"` button.
   - iOS-style `"Use relative path"` switch (`28x14`, animated toggle), automatically enabled for local disks/folders and disabled for cloud repositories.

2. **Streamlined "Add Tables" Manager (`TableImportView`)**:
   - The first element visible upon opening the window is directly the **batch DataGrid table**.
   - Removed macro header bar (title, description, and queue count badge) and intermediate option toolbar.
   - Clean interactive column configuration for each table item:
     - **Selection Checkbox**: Independent per-row selection toggle.
     - **File Name**: Truncated with full path tooltip and source badge.
     - **Worksheet / Page**: Dynamic ComboBox listing extracted worksheets for Excel files.
     - **Region / Range**: Options for `Entire Sheet`, `Custom Range`, or `Named Range`.
     - **View Type**: `Drafting View`, `Legend View`, or `Schedule View`.
     - **View Name**: Editable text box with duplicate prevention.
     - **Scale**: View scale selection (`1:1`, `1:5`, `1:10`, `1:20`, `1:50`, `1:100`, etc.).
     - **Type**: Table import type (`Table`, `Drawing`, `Image`, `Schedule`).

3. **Bottom Action Footer**:
   - **Selection Dropdown**: ComboBox located on the bottom-left providing instant selection actions (`Select All`, `Deselect All`, `Invert Selection`).
   - **Status & Selection Counter**: Centered badge showing `{X} selected to create`.
   - **Primary Actions**: Right-aligned `Cancel` and `Apply` (`ImportBatchTablesCommand`) buttons.

4. **Batch Creation & Transaction Engine**:
   - The `ImportBatchTablesAsync` method iterates through all selected rows.
   - All individual view generations are wrapped inside a single Revit `TransactionGroup` (`"TablePlus — Batch Create Tables"`), committing once via `tg.Assimilate()` to provide a single, clean Undo step.
   - Silent warning suppression via `WarningSwallower` prevents intrusive Revit warning popups.
   - Registered Extensible Storage metadata tracks each view's link to its original source file and sheet.

---

## 2. Key Files & Structure

| File | Purpose |
|---|---|
| [`TableBatchImportItemModel.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Models/TableBatchImportItemModel.cs) | Observable model representing an individual row in the batch import DataGrid. |
| [`TableImportView.xaml`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Views/TableImportView.xaml) | WPF card-based batch manager view with DataGrid, management toolbar, and footer. |
| [`TableImportView.xaml.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Views/TableImportView.xaml.cs) | Code-behind with drag-and-drop file appending and compact enum display converter. |
| [`TableImportViewModel.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/ViewModels/TableImportViewModel.cs) | Batch viewmodel managing `BatchItems`, multi-file parsing, row duplication, batch apply, and `TransactionGroup` creation. |
| [`TableSourceSelectionView.xaml`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Views/TableSourceSelectionView.xaml) | Spacious 620x170 intermediate source selection dialog with relative path switch. |
| [`MainWindowViewModel.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/ViewModels/MainWindowViewModel.cs) | Master dashboard coordination updating inventory after batch table creation. |

---

## 3. Verification & Build Results

Both targets compiled cleanly without warnings or errors, and deployed to their corresponding Revit add-in directories:

```text
dotnet build TablePlus\TablePlus.csproj -c "Debug R25"
  TablePlus -> B:\REVIT\C#\RevitAddins_Workspace\TablePlus\bin\Debug R25\TablePlus.dll
  TablePlus -> C:\Users\dbarb\AppData\Roaming\Autodesk\Revit\Addins\2025\
Build succeeded. 0 Warning(s), 0 Error(s).

dotnet build TablePlus\TablePlus.csproj -c "Debug R24"
  TablePlus -> B:\REVIT\C#\RevitAddins_Workspace\TablePlus\bin\Debug R24\TablePlus.dll
  TablePlus -> C:\Users\dbarb\AppData\Roaming\Autodesk\Revit\Addins\2024\
Build succeeded. 0 Warning(s), 0 Error(s).
```
