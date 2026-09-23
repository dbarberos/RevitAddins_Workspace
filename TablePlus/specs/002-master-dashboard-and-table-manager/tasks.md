# Tasks: Master Table Dashboard & Table Manager UI

**Spec ID:** `002`  
**Target Add-in:** `TablePlus`  
**Status:** COMPLETED  
**Author / Architect:** SDD Polyglot Architect  
**Date:** 2026-09-23  

---

## 1. Execution Protocol

1. **One Task at a Time**: Process strictly one task per turn.
2. **Review & Check**: Before moving to the next task, verify that the current task compiles and satisfies its associated requirement, then mark it with `[x]`.
3. **No Unplanned Code**: Never add classes, methods, or UI controls outside the approved technical plan.
4. **Artifact Traceability**: Export milestone snapshots to `TablePlus/docs/references/` upon major task blocks.

---

## 2. Microtasks Breakdown (20–30 min per task)

### Phase 1: Pure Domain, DTOs & Extensible Storage Extension

- [x] **T1: Define Pure Models and DTOs (`TableItemModel.cs`, `TableEnums.cs`, `TableImportConfig.cs`)** (Maps to: `RF-2`, `RF-3`, `RF-9`)
  - Create `TablePlus/Models/TableEnums.cs` declaring `TableSyncStatus` (UpToDate, Modified, FileNotFound, Unlinked) and `TableSourceType` (ExcelXlsx, ExcelXlsm, Csv, PdfDocument, WordDocument, ScheduleView).
  - Create `TablePlus/Models/TableItemModel.cs` implementing `ObservableObject` with properties: `IsSelected`, `SourceType`, `Status`, `StatusTooltip`, `ViewId`, `ViewName`, `ViewType`, `ViewScale`, `SourceFilePath`, `SourceFileName`, `SelectedSheetName`, `CellRangeAddress`, `ObservableCollection<string> AvailableSheets`, `IsAutoSyncEnabled`, `IsBlackAndWhite`, and `TableImportConfig Config`.
  - Extend `TablePlus/Models/TableImportConfig.cs` with properties: `IsAutoSyncEnabled`, `SourceType`, `GridLineStyleName`, `BodyTextNoteTypeName`, `HeaderCustomStyleEnabled`, `HeaderTextNoteTypeName`, `HeaderTextColorHex`, `HeaderFillColorHex`.

- [x] **T2: Define `ITableRegistryService` Interface** (Maps to: `RF-2`, `RF-8`, `RF-9`)
  - Create `TablePlus/Services/ITableRegistryService.cs` declaring method signatures for `DiscoverTablesAsync`, `RefreshItemStatusAsync`, and `DeleteOrUnlinkTable`.
  - Verify that `SchemaService` JSON serialization seamlessly absorbs the new `TableImportConfig` styling and auto-sync properties without schema modification.

### Phase 2: Core Table Registry & Geometry Engine Styling Updates

- [x] **T3: Implement `TableRegistryService` (Discovery, Live Timestamp Check & Table Lifecycle)** (Maps to: `RF-2`, `RF-5`, `RF-8`)
  - Create `TablePlus/Services/TableRegistryService.cs` collecting `ViewDrafting` and `View` (Legend) stamped with `TablePlus_TableData` schema.
  - Compare file disk `LastWriteTimeUtc` against stored `LastImportedTimestampUtc` to determine `UpToDate`, `Modified`, or `FileNotFound` status.
  - Implement `RefreshItemStatusAsync` to populate `AvailableSheets` using `IExcelReaderService`.
  - Implement `DeleteOrUnlinkTable` supporting view deletion or schema detaching while preserving graphics.

- [x] **T4: Update `TableGeometryService` for Custom Line Styles, Body Typography & Header Overrides** (Maps to: `RF-4`, `RF-6`)
  - Enhance `TableGeometryService.cs` to resolve `GridLineStyleName` from Revit's line categories (`BuiltInCategory.OST_Lines`).
  - Enhance text note placement: apply `BodyTextNoteTypeName` for standard cells; apply `HeaderTextNoteTypeName` and `HeaderTextColorHex` to row 1 (header row) when `HeaderCustomStyleEnabled` is true.
  - Apply header row background shading (`HeaderFillColorHex`) to cell filled regions in row 1.
  - Enforce `BlackAndWhiteMode`: suppress all filled regions, force solid black texts (including header) and standard black line styles.

### Phase 3: Style Mapping View & ViewModel

- [x] **T5: Implement `TableStyleMappingViewModel` & `TableStyleMappingView.xaml`** (Maps to: `RF-4`)
  - Create `TablePlus/ViewModels/TableStyleMappingViewModel.cs` exposing available Revit line styles, available `TextNoteType`s, header override toggles, and color presets.
  - Create `TablePlus/Views/TableStyleMappingView.xaml` adhering to FilterPlus card theme with inline `<Window.Resources>`.
  - Layout cards: (1) Gridline Styles, (2) Body Cell Typography, (3) Header Row Styling & Colors, and footer Save/Cancel buttons.

### Phase 4: Master Table Dashboard View & ViewModel

- [x] **T6: Implement `MainWindowViewModel` (State Management, Filter, Batch Sync & Execution)** (Maps to: `RF-1`, `RF-2`, `RF-3`, `RF-7`)
  - Create `TablePlus/ViewModels/MainWindowViewModel.cs` using `CommunityToolkit.Mvvm`.
  - Manage `ObservableCollection<TableItemModel> Tables` and `ICollectionView FilteredTables`.
  - Implement live search filter by view/file name and combo filters by View Type and Status.
  - Implement commands: `RefreshInventoryAsync`, `AddTableAsync`, `SyncSelectedAsync` (using `TransactionGroup` and `WarningSwallower`), `OpenSelectedView`, `DeleteSelectedAsync`, `OpenDesignWindow`, and `OnSheetChangedAsync`.

- [x] **T7: Implement `MainWindowView.xaml` (FilterPlus Cards Layout & Virtualized DataGrid)** (Maps to: `RF-1`, `RF-3`)
  - Create `TablePlus/Views/MainWindowView.xaml` with inline styles and converters in `<Window.Resources>`.
  - Upper control zone: Card 1 (Actions: `+ Add Table`, `🔄 Sync Selected`, `👁️ Open View`, `🗑️ Delete / Unlink`), Card 2 (Filters & Search), Card 3 (Global Tools & Options).
  - Lower data zone: Virtualized DataGrid with all 11 columns (Select, Src Icon, Status badge, Revit View Name, View Type, Scale, Source File Name & tooltip, Worksheet dropdown, Auto-Sync checkbox, B&W checkbox, and `[ 🎨 Design... ]` button).
  - Footer zone: table counters, progress bar, and buttons `Close` / `Sync Selected`.

### Phase 5: Command Wiring, Document Lifecycle & Ribbon Integration

- [x] **T8: Wire Unified Command `CmdImportTable` and Document Open Auto-Sync Hook** (Maps to: `RF-8`, `RF-10`)
  - Update `TablePlus/Commands/CmdImportTable.cs` to launch `MainWindowView`.
  - Hook document open event or check on startup for tables with `IsAutoSyncEnabled == true`.
  - Verify seamless launch from the native **Add-Ins / Complementos** ribbon tab.

### Phase 6: Multi-Version Verification, Bundling & SDD Sign-off

- [x] **T9: Multi-Version Compilation & App Store Bundle Packaging** (Maps to: `AC-1` .. `AC-9`)
  - Compile without errors or warnings across: `Release.R24`, `Release.R25`, `Release.R26`, `Release.R27`, and `Debug.R24`.
  - Execute `build-bundle.ps1` to produce updated `TablePlus.bundle` and zip archives.
  - Perform clinical Revit API QA and security review (zero-trust paths, transaction rollback, no raw stack traces).
  - Archive `walkthrough_[YYYYMMDD]_002_master_dashboard.md` in `TablePlus/docs/references/`.
