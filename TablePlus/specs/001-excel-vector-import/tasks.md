# Tasks: 001 — Core Excel Vector Table Import

**Spec ID:** `001-excel-vector-import`  
**Target Add-in:** `TablePlus`  
**Feature Branch:** `TablePlus`  
**Status:** DRAFT FOR USER REVIEW (PHASE GATE 4)  
**Architect:** SDD Architect  
**Date:** 2026-09-22  
**Language:** English (Official Engineering Standard)  

---

## 1. Execution Protocol

1. **Atomic Step-by-Step Execution**: Implement strictly one task at a time.
2. **Deterministic Verification**: Verify each task compiles or passes validation before checking the box (`[x]`).
3. **Strict Plan Adherence**: Do not write code or classes outside the approved `plan.md`.

---

## 2. Microtasks Breakdown (20–30 min per task)

### Phase 1: Infrastructure, Project Scaffolding & Manifests
- [x] **T1: Scaffold TablePlus Project & Manifests** (Maps to: `RF-6.4`)
  - Create `TablePlus/TablePlus.csproj` multi-targeted with Nice3point Revit SDK references and `ImplicitUsings`.
  - Create `TablePlus/TablePlus.addin` registration manifest.
  - Setup `TablePlus/Resources/Icons/` with 16x16 and 32x32 TablePlus icons.

### Phase 2: Decoupled Domain Models (DTOs)
- [x] **T2: Implement Pure Domain Models** (Maps to: `RF-1`, `RF-2`, `RF-3`)
  - Create `TablePlus/Models/ExcelCellModel.cs` (coordinates, formatted value, font, borders, background hex).
  - Create `TablePlus/Models/MergedCellRange.cs` (bounding row/column indices).
  - Create `TablePlus/Models/ExcelWorkbookModel.cs` and `TableImportConfig.cs` (target view type, name, scale).

### Phase 3: Pure Excel File Reader Service
- [x] **T3: Implement ExcelReaderService with ClosedXML / OpenXML** (Maps to: `RF-1`, `RF-2`, `RF-4.5`)
  - Create `TablePlus/Services/IExcelReaderService.cs` and `ExcelReaderService.cs`.
  - Implement workbook inspection (sheet names, used ranges).
  - Implement cell extraction with font styles, borders, alignments, and background RGB colors.
  - Implement merged cells detection.

### Phase 4: Revit API Vector Geometry Engine
- [x] **T4: Implement TableGeometryService & WarningSwallower** (Maps to: `RF-4`, `AC-3`, `AC-4`, `AC-5`)
  - Create `TablePlus/Services/WarningSwallower.cs` implementing `IFailuresPreprocessor`.
  - Create `TablePlus/Services/ITableGeometryService.cs` and `TableGeometryService.cs`.
  - Implement `ViewDrafting` / Legend View creation with configured scale.
  - Implement `DetailCurve` generation for cell borders and merged cell perimeters.
  - Implement `TextNote` creation with alignment and font size scaling in feet.
  - Implement `FilledRegion` generation with solid fill patterns and RGB color overrides.

### Phase 5: Extensible Storage Metadata Stamping
- [x] **T5: Implement SchemaService for Tracking & Future Sync** (Maps to: `RF-5`, `AC-6`)
  - Create `TablePlus/Services/ISchemaService.cs` and `SchemaService.cs`.
  - Register `TablePlus_TableData` schema GUID: `E3B21D40-6C9A-4E2F-8A11-92D0543B7A1C`.
  - Implement methods to stamp and retrieve `SourceFilePath`, `WorksheetName`, `CellRange`, and `Timestamp`.

### Phase 6: Modern WPF Presentation Layer (FilterPlus Theme)
- [x] **T6: Implement TableImportViewModel with CommunityToolkit.Mvvm** (Maps to: `RF-1`, `RF-2`, `RF-3`)
  - Create `TablePlus/ViewModels/TableImportViewModel.cs`.
  - Implement asynchronous file loading, worksheet selection, and range validation.
  - Implement `[RelayCommand]` for browsing files and executing the import.
- [x] **T7: Build TableImportView.xaml with FilterPlus Design System** (Maps to: `RF-6.1`, `RF-6.2`, `RF-6.3`, `AC-7`)
  - Create `TablePlus/Views/TableImportView.xaml` with inline resources, brushes, and control templates.
  - Layout Card 1 (File Browser & Drag/Drop), Card 2 (Worksheet & Range Picker), Card 3 (View Settings & Scale).
  - Add determinate progress bar during processing.

### Phase 7: External Command & Ribbon Integration
- [ ] **T8: Implement CmdImportTable & Application.cs** (Maps to: `RF-6.4`, `AC-8`)
  - Create `TablePlus/Commands/CmdImportTable.cs` with `[Transaction(TransactionMode.Manual)]`.
  - Implement `TablePlus/Application.cs` (`IExternalApplication`) creating Ribbon Tab `DBDev Tools` / Panel `Tables` / PushButton `Import Excel`.
  - Wire `AppDomain.CurrentDomain.AssemblyResolve` hook for .NET 8 / Revit 2025+ support.

### Phase 8: Compilation, Validation & Final Verification
- [ ] **T9: Full Build Validation & Acceptance Criteria Verification** (Maps to: `AC-1` through `AC-8`)
  - Compile `TablePlus.csproj` across active configurations.
  - Verify zero warnings, valid `.addin` file, and ready-to-test state in Revit.
