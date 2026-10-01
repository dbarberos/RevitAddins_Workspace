# Walkthrough: Modernization & DiRoots TableGen Form Alignment for TablePlus Add-Table Modal

**Date:** 2026-10-01  
**Target Projects:** [TablePlus.csproj](file:///b:/REVIT/C%23/RevitAddins_Workspace/TablePlus/TablePlus.csproj)  
**Components Modified:**
- [TableEnums.cs](file:///b:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Models/TableEnums.cs)
- [TableImportConfig.cs](file:///b:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Models/TableImportConfig.cs)
- [TableItemModel.cs](file:///b:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Models/TableItemModel.cs)
- [TableImportViewModel.cs](file:///b:/REVIT/C%23/RevitAddins_Workspace/TablePlus/ViewModels/TableImportViewModel.cs)
- [TableImportView.xaml](file:///b:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Views/TableImportView.xaml)
- [TableImportView.xaml.cs](file:///b:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Views/TableImportView.xaml.cs)

---

## 1. Context & Motivation

In previous iterations, the "Add Table" dialog in TablePlus was implemented as a tall, three-card vertical scrolling window (`700x820px`) where users had to scroll vertically across three separate card sections to configure a single table import. 

By analyzing the production architecture of DiRoots TableGen (`references_examples/DiRootsOne/DiRoots.One/tablegen`, specifically `AddOrUpdateExcelWindow.cs` and `AddBaseViewModel.cs`), a far more ergonomic, compact 2-column form structure was identified. The goal of this task was to adapt the Add Table modal to replicate this proven ergonomic layout while preserving TablePlus's modern FilterPlus design language, multi-format support, and dual-stack compilation (.NET 8 and .NET Framework 4.8).

---

## 2. Architectural Changes

### A. New Models & Enums
1. **`TableImportType`**:
   - `Table`: Editable 2D vector detail lines, text notes, and filled regions in Revit views.
   - `Image`: High-resolution raster rendering for complex spreadsheets or charts.
2. **`TablePageOption`**:
   - `AllPages`: Imports entire multi-page documents (Word, PDF, Markdown).
   - `SelectPages`: Allows custom range entry (e.g. `1-3, 5`).
3. **`TableImportConfig` & `TableItemModel`**:
   - Added `ImportType`, `DpiResolution`, `PageOption`, `SelectedPages`, and `NumberOfCopies` (1 to 50).
   - Added `ImportTypeBadge` (`TBL` vs `IMG`) for quick identification.

### B. ViewModel Extensions (`TableImportViewModel.cs`)
- Added reactive properties:
  - `AvailableImportTypes` (`Table`, `Image`)
  - `AvailableDpiValues` (`72, 96, 150, 300, 600`)
  - `AvailablePageOptions` (`AllPages`, `SelectPages`)
  - `AvailableViewTypes` (`DraftingView`, `LegendView`, `ScheduleView`)
  - `AvailableRegionModes` (`Entire Worksheet`, `Named Range`, `Custom Range`)
  - `NumberOfCopies` (clamped between 1 and 50)
- Dynamic visibility and enablement logic:
  - `IsExcelSource`: Controls visibility of `Worksheet` and `Region / Range` rows.
  - `IsPagedDocument`: Controls visibility of `Page Options` and `SelectedPages` input.
  - `IsImageImport`: Controls visibility of `Resolution (DPI)`.
  - `IsScaleEnabled`: Automatically disables the scale selector when `ScheduleView` is selected (as schedules in Revit do not support geometric scale).
  - `IsPageSelectionCustom`: Displays the page range TextBox when `SelectPages` is active.
- Multi-copy bulk generation:
  - `ImportTableAsync()` iterates through `1 .. NumberOfCopies`, generating sequential unique view names (e.g. `Table 001`, `Table 002`) and collecting all created views into `CreatedViews`.

### C. View Modernization (`TableImportView.xaml` & `TableImportView.xaml.cs`)
- Compact dialog size: `Width="640" Height="720" MinWidth="580" MinHeight="620"` with `WindowStartupLocation="CenterScreen"` and Revit main process modal ownership via `WindowInteropHelper`.
- Form Body:
  - Two-column Grid layout inside a single sleek card (`Column 0: 135px` for semibold labels; `Column 1: *` for input controls).
  - Implemented `EnumDisplayConverter` directly in the view layer to cleanly format enum names into readable UI labels without relying on external packages.
  - Controls styled with FilterPlus theme (clean rounded text boxes, virtualized combo boxes, modern animated switches for options).
  - Maintained drag & drop file loading for Excel (`.xlsx, .xls, .xlsm`), Word (`.docx, .doc, .rtf`), PDF (`.pdf`), Markdown (`.md`), and Text (`.txt, .csv, .tsv`).

---

## 3. Validation & Build Results

Both target configurations were verified and compiled cleanly:
1. **Revit 2025 (`Debug R25`)**:
   - Framework: .NET 8 (CoreCLR)
   - Result: `Build succeeded. 0 Warning(s) 0 Error(s)`
   - Deployed to: `%AppData%\Autodesk\Revit\Addins\2025\TablePlus\`
2. **Revit 2024 (`Release R24`)**:
   - Framework: .NET Framework 4.8
   - Result: `Build succeeded. 0 Warning(s) 0 Error(s)`
   - Deployed to: `%AppData%\Autodesk\Revit\Addins\2024\TablePlus\`
