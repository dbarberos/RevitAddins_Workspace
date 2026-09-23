# Specification: Master Table Dashboard & Table Manager UI

**Spec ID:** `002`  
**Target Add-in:** `TablePlus`  
**Feature Branch:** `feature/002-master-dashboard-table-manager`  
**Author / Architect:** SDD Polyglot Architect  
**Status:** DRAFT (Ready for User Validation)  
**Date:** 2026-09-23  

---

## 1. Context & Business Value

In Spec 001, TablePlus established its high-fidelity vector import engine, converting Excel spreadsheets into native Revit Drafting and Legend Views with typographic and geometric precision.

As the number of tables in a BIM project grows (door schedules, finishes matrices, load calculations, regulatory compliance tables), users require a centralized **Master Table Dashboard** (analogous to DiRoots TableGen) to visualize, inspect, reconfigure, and synchronize all project tables from a single intuitive window.

This specification elevates TablePlus from a single-shot import utility into an enterprise **Tabular Information Manager for Autodesk Revit**, providing:
1. **Consolidated Inventory**: An interactive, virtualized DataGrid displaying all tables existing in the active Revit project.
2. **Top Execution Panel**: Action buttons (Sync, Open View, Delete) executed against selected rows.
3. **Dedicated Design Column**: In-row `[ 🎨 Design... ]` button launching a dedicated style and color configuration modal.
4. **Provenance & Real-time Status**: Live file monitoring detecting if source Excel spreadsheets have been modified or moved on disk.
5. **In-place Reconfiguration**: Dropdown selectors on each row to switch worksheets or ranges without deleting and reimporting views.
6. **Auto-Synchronization Automation**: Configurable per-table auto-sync triggers for Revit startup and batch sync operations.
7. **Black & White (B&W) Drawing Standardization**: Dedicated toggle per table to strip color fills and enforce clean black lines and text for formal construction documentation.
8. **Future-Proof Extensibility**: Polymorphic architecture supporting new source document types (Excel now; Word/PDF/Schedules in subsequent specs) without redesigning the UI core.

### Visual Architecture & Layout Mockup

```text
┌──────────────────────────────────────────────────────────────────────────────────────────────┐
│  TablePlus — Master Table Dashboard                                            [-] [□] [X]   │
├──────────────────────────────────────────────────────────────────────────────────────────────┤
│  [ UPPER CONTROL ZONE: ACTION & FILTER CARDS ]                                               │
│  ┌─────────────────────────────┐ ┌───────────────────────────┐ ┌───────────────────────────┐ │
│  │ 📁 Selection Actions        │ │ 🔍 Filters & Search       │ │ ⚙️ Global Tools           │ │
│  │ [ + Add Table / Import ]    │ │ [ Search table/file...  ] │ │ [ Default Style Rules ]   │ │
│  │ [ 🔄 Sync Selected ]        │ │ View:   [All Views     ▼] │ │ [ Application Settings ]  │ │
│  │ [ 👁️ Open Selected View ]   │ │ Status: [All Statuses  ▼] │ │                           │ │
│  │ [ 🗑️ Delete / Unlink ]      │ │                           │ │                           │ │
│  └─────────────────────────────┘ └───────────────────────────┘ └───────────────────────────┘ │
├──────────────────────────────────────────────────────────────────────────────────────────────┤
│  [ LOWER DATA ZONE: VIRTUALIZED TABLES DATAGRID ]                                            │
│  ┌───┬───┬──────┬──────────────┬─────────────┬──────┬──────────────┬────────┬────┬────┬─────┐│
│  │[x]│Src│Status│Revit View    │View Type    │Scale │Source File   │Sheet/Rg│Auto│B&W │Desig││
│  ├───┼───┼──────┼──────────────┼─────────────┼──────┼──────────────┼────────┼────┼────┼─────┤│
│  │[x]│📊 │🟢 OK │Tabla Acabados│DraftingView │1:1   │Acabados.xlsx │[Hoja1▼]│[x] │[ ] │[ 🎨]││
│  │[ ]│📊 │🟠 Mod│Cuadro Puertas│LegendView   │1:20  │Puertas.xlsx  │[A1:F8▼]│[x] │[x] │[ 🎨]││
│  │[ ]│📄 │🔴 Err│Planilla Carga│DraftingView │1:1   │Cargas.xlsx   │[Datos▼]│[ ] │[ ] │[ 🎨]││
│  └───┴───┴──────┴──────────────┴─────────────┴──────┴──────────────┴────────┴────┴────┴─────┘│
├──────────────────────────────────────────────────────────────────────────────────────────────┤
│  Total Tables: 3 | Selected: 1 | Out of Date: 1                        [ Close ] [ Apply ]   │
└──────────────────────────────────────────────────────────────────────────────────────────────┘
```

---

## 2. Reference Project Findings (`references_examples/DiRootsOne/`)

- **Reference Analyzed:** `references_examples/DiRootsOne/DiRoots.One/DiRoots/One/TableGen/`
  - Inspecting `MainWindow.cs`, `MainWindowViewModel.cs`, and `SelectedExcel.cs`.
- **Reused Architectural Patterns:**
  - **Master-Detail Layout**: Distinct upper action panel for high-level operations ("Add Table", "Sync Selected", "Search / Filter") combined with an expansive lower DataGrid detailing every table in the model.
  - **Status Tri-State**: Visual indicators (🟢 Up to Date, 🟠 Externally Modified, 🔴 File Not Found / Broken Link) comparing the file's `LastWriteTimeUtc` against the view's stored sync timestamp.
  - **Inline Reconfiguration**: Embedding sheet and range dropdown selectors directly within grid rows.
  - **Black & White Filter**: A dedicated row column ("Black & White") providing one-click monochrome rendering.
  - **Auto-Sync Tagging**: Checkbox column marking tables that should be refreshed automatically.
- **Discarded / Replaced Components:**
  - *Discarded:* Legacy WinForms styling, obfuscated reflection bindings, and proprietary DiRoots license and telemetry services.
  - *Adopted:* Modern WPF card-based theme (matching FilterPlus), `CommunityToolkit.Mvvm` 8.x source generators, pure `ClosedXML` / OpenXML reading, and native Revit `Extensible Storage`.

---

## 3. Clinical Boundary Questionnaire Resolutions

1. **Parameter & Metadata Existence:**
   - How are existing tables detected?
   - *Resolution:* TablePlus queries all `ViewDrafting` and `View` (Legend) elements in the active document. It checks for the presence of the `TablePlus_TableData` schema (`E3B21D40-6C9A-4E2F-8A11-92D0543B7A1C`). Only views stamped with this schema are populated into the manager DataGrid.
2. **Document State (Read-Only / Family):**
   - *Resolution:* If `doc.IsFamilyDocument` is true, a warning informs the user that TablePlus operates only on Project documents (`.rvt`). If `doc.IsReadOnly` is true, action buttons ("Add", "Sync", "Delete") are disabled, allowing read-only inspection of table metadata.
3. **Worksharing & Borrowing:**
   - *Resolution:* When synchronizing or modifying an existing view in a workshared model, TablePlus verifies ownership and borrows view elements via `WorksharingUtils.CheckoutElements(doc, elementIds)` before modifying geometry.
4. **Target Scope:**
   - *Resolution:* Active project document views. Linked models are excluded from direct modification but link status can be displayed if a view references linked files.
5. **Coordinate Systems:**
   - *Resolution:* Table graphics reside on 2D view planes (Drafting / Legend). Coordinate transformations do not affect 2D vector tables, ensuring 100% scale fidelity across views.
6. **Units & Scale Display:**
   - *Resolution:* The DataGrid explicitly displays the view's assigned scale (e.g. `1:1`, `1:10`, `1:20`).
7. **Failure Preprocessing:**
   - *Resolution:* All table updates and batch synchronization transactions register `WarningSwallower` to suppress benign line/text warnings and prevent modal popups from interrupting batch sync.
8. **UI Modality & Virtualization:**
   - *Resolution:* The Master Dashboard is launched as a modal WPF window owned by Revit's main window handle (`WindowInteropHelper`). The table list control uses WPF virtualization (`VirtualizingStackPanel.IsVirtualizing="True"`) to seamlessly handle projects with 100+ tables.
9. **Transaction Granularity:**
   - *Resolution:* Batch synchronization of multiple tables is wrapped in a `TransactionGroup("TablePlus Batch Sync")` containing individual sub-transactions per table. If one table fails (e.g. locked file), that sub-transaction is rolled back, while other valid tables complete successfully.
10. **Extensibility & Future Features:**
    - *Resolution:* The DataGrid binds to an extensible `TableItemModel` implementing an `ITableSourceItem` interface. The `SourceType` enum (`ExcelXlsx`, `ExcelXlsm`, `Csv`, and reserved `PdfDocument`, `WordDocument`, `ScheduleView`) decouples the UI from the underlying document engine, allowing future specs to plug in without UI regressions.

---

## 4. Functional Requirements (EARS Notation)

### RF-1: Master Window Layout & Modern Card-Based Architecture
- **RF-1.1 (Ubiquitous):** The add-in shall provide a centralized Master Table Dashboard window (`MainWindowView.xaml`) styled with the **FilterPlus card-based theme**, fully compatible with Revit light and dark themes.
- **RF-1.2 (Ubiquitous):** The window shall be divided into:
  - **Upper Control Zone:** Three cards containing:
    1. **Main Actions Card:** Action buttons executed against selected rows:
       - `+ Add Table / Import`: Launches the import workflow to add a new table to the model.
       - `🔄 Sync Selected`: Re-reads and synchronizes all checked tables.
       - `👁️ Open View`: Activates and displays the selected table's view in Revit's drawing area.
       - `🗑️ Delete / Unlink`: Removes the table view or unlinks TablePlus metadata.
    2. **Filters & Quick Search Card:** Live text search filter by view or file name, and dropdown filters by View Type (*All*, *Drafting*, *Legend*) and Status (*All*, *Up to date*, *Modified*, *Error*).
    3. **Global Settings & Tools Card:** Quick access to global defaults and application options.
  - **Lower Data Zone:** An expansive virtualized DataGrid presenting all linked tables in the model.
  - **Footer Zone:** Status summary (total tables, selected count, out-of-date count) and execution buttons ("Sync Selected", "Close").

### RF-2: Table Inventory Discovery & Live Status Tracking
- **RF-2.1 (Event-driven):** When the Master Dashboard opens, the add-in shall query all Drafting and Legend Views in the active document and populate the grid with views stamped with the TablePlus Extensible Storage schema.
- **RF-2.2 (State-driven):** For each discovered table, the add-in shall inspect the source file path on disk:
  - If the file exists and `LastWriteTimeUtc <= LastImportedTimestampUtc`: assign **🟢 Up to Date** status.
  - If the file exists and `LastWriteTimeUtc > LastImportedTimestampUtc`: assign **🟠 Externally Modified** status.
  - If the file path does not exist or is inaccessible: assign **🔴 File Not Found / Broken Link** status.

### RF-3: Comprehensive DataGrid Column Structure
- **RF-3.1 (Ubiquitous):** The lower DataGrid shall display the following columns in order:
  1. **Selection (`[x]`):** Checkbox allowing individual row selection and a header checkbox for "Select All / None".
  2. **Source Icon:** Visual icon indicating document origin (Excel `.xlsx`/`.xlsm`/`.csv`, with SVG/PNG asset).
  3. **Status:** Colored badge/icon indicating 🟢 Up to Date, 🟠 Modified, or 🔴 Missing, with descriptive tooltip.
  4. **View Name:** The name of the Revit Drafting or Legend View (with double-click or inline rename support).
  5. **View Type:** Badge displaying `Drafting View` or `Legend View`.
  6. **View Scale:** Text displaying the view scale (e.g. `1:1`, `1:20`, `1:50`).
  7. **Source File:** File name with full absolute path displayed in tooltip.
  8. **Worksheet / Range Selector:** An interactive dropdown (ComboBox) per row displaying the current sheet/range, populated with available worksheets from the source workbook.
  9. **Auto-Sync (`[x]`):** Checkbox enabling/disabling automatic background synchronization for this table.
  10. **Black & White (`[x]`):** Checkbox ("B&W") forcing monochrome rendering (black text, black lines, transparent fills).
  11. **Design (`[ 🎨 Design... ]`):** A button in each row that opens the **Table Style & Design Configuration Window** (`TableStyleMappingView.xaml`) for that specific table.

### RF-4: Table Style & Design Configuration Window (`TableStyleMappingView`)
- **RF-4.1 (Event-driven):** When the user clicks the `[ 🎨 Design... ]` button on a row, the add-in shall open a modal style configuration window for that specific table.
- **RF-4.2 (Ubiquitous):** The Style Configuration Window shall provide:
  - **Grid Line Styles:** Dropdown selector to choose the Revit Line Style (`GraphicsStyle` from Revit's line categories) applied to cell grid borders (interior gridlines and exterior table frame).
  - **Body Text Style:** Dropdown selector to choose the Revit `TextNoteType` used for standard cell typography.
  - **Header Row Overrides:**
    - Toggle checkbox: `Enable Custom Header Row Style`.
    - Dropdown selector for Header `TextNoteType` (allowing larger font, bold weight, or distinct typography).
    - Color picker / selector for Header text font color.
    - Color picker / selector for Header background fill shading (`FilledRegion`).
- **RF-4.3 (State-driven):** Saving the design configuration stores the styling parameters in the table's `TableImportConfig` metadata (persisted in Extensible Storage) and updates the table geometry on next sync.

### RF-5: In-Place Worksheet & Range Reconfiguration
- **RF-5.1 (Event-driven):** When the user changes the worksheet or range selection in the row's dropdown, the add-in shall update the table's in-memory configuration and mark the row as modified/pending sync.
- **RF-5.2 (Event-driven):** Upon confirming the update, TablePlus shall re-read the newly selected range and update the view geometry without recreating the view element.

### RF-6: Black & White (B&W) Rendering Engine Integration
- **RF-6.1 (Event-driven):** When the user toggles the **Black & White** checkbox for a table and triggers a sync:
  - All text notes (including header row) shall be rendered with solid black color (`RGB(0, 0, 0)`).
  - All gridline borders shall be drawn with standard black Revit line styles.
  - All cell background filled regions (`FilledRegion`) shall be suppressed / omitted, producing clean white cell interiors.
- **RF-6.2 (State-driven):** If the B&W checkbox is unchecked, custom cell fills and header colors configured in the Design window or source spreadsheet shall be restored upon synchronization.

### RF-7: Batch & Selected Synchronization Engine
- **RF-7.1 (Event-driven):** When the user clicks **Sync Selected** in the top action card or window footer, the add-in shall iterate over all checked rows in the DataGrid, open each source spreadsheet, apply the configured line/text/header styles, and update view graphics within an isolated `TransactionGroup`.
- **RF-7.2 (Unwanted behavior):** If a source file is locked by another process or missing, the add-in shall skip that table, log a non-blocking warning, and continue synchronizing the remaining selected tables.
- **RF-7.3 (Ubiquitous):** Progress shall be reported in real time via an interactive progress bar showing current table `X of Y`.

### RF-8: Auto-Sync On Document Open Lifecycle
- **RF-8.1 (State-driven):** When a Revit document containing TablePlus tables is opened, if any table has `IsAutoSyncEnabled == true`, TablePlus shall verify if the source files were modified externally.
- **RF-8.2 (Optional):** If out-of-date tables are detected, TablePlus shall present a lightweight notification banner offering to sync all modified auto-sync tables with a single click.

### RF-9: Extensible Storage v2 Schema Extension
- **RF-9.1 (Ubiquitous):** The add-in shall serialize `IsAutoSyncEnabled`, `BlackAndWhiteMode`, `LineStyleName`, `TextNoteTypeName`, `HeaderCustomStyleEnabled`, `HeaderFillColorHex`, `HeaderTextColorHex`, `SourceType`, and `ViewScale` into the existing `ConfigJson` field of the `TablePlus_TableData` schema, ensuring 100% backward compatibility with views created in Spec 001.

### RF-10: Ribbon Entry Point Integration
- **RF-10.1 (Event-driven):** Clicking the `TablePlus` / `Import Excel` PushButton in Revit's native **Add-Ins / Complementos** ribbon tab shall launch the Master Table Dashboard (`MainWindowView`).
- **RF-10.2 (Ubiquitous):** The standalone "Import New Table" workflow shall be accessible directly from the Master Dashboard via the `+ Add Table` button in the top action card.

---

## 5. Acceptance Criteria (AC)

- [ ] **AC-1 (matches RF-1):** Launching the add-in from Revit's Ribbon displays the Master Table Dashboard with the top action cards and lower DataGrid within 1.0 second.
- [ ] **AC-2 (matches RF-1.2):** Selecting one or more rows in the DataGrid enables the top action buttons (`Sync Selected`, `Open View`, `Delete / Unlink`), and clicking `Open View` directly activates the selected view in Revit.
- [ ] **AC-3 (matches RF-2):** All existing tables created in the document are discovered and correctly tagged with 🟢 Up to Date, 🟠 Externally Modified, or 🔴 File Not Found based on disk file timestamps.
- [ ] **AC-4 (matches RF-3):** The DataGrid renders all 11 columns accurately (Selection, Source Icon, Status, View Name, View Type, View Scale, Source File, Worksheet ComboBox, Auto-Sync checkbox, B&W checkbox, and Design button `[ 🎨 Design... ]`).
- [ ] **AC-5 (matches RF-4):** Clicking `[ 🎨 Design... ]` opens the `TableStyleMappingView` modal dialog, allowing the user to select line styles, body text note types, and customize header row text/background colors.
- [ ] **AC-6 (matches RF-5):** Changing the worksheet in a row's dropdown and clicking sync re-renders the view with the new worksheet's contents without altering the view ID.
- [ ] **AC-7 (matches RF-6):** Checking "Black & White" and synchronizing eliminates all background `FilledRegion` shading and enforces black font/borders in the resulting Revit view.
- [ ] **AC-8 (matches RF-7):** Selecting multiple rows and clicking "Sync Selected" updates all checked tables within a single `TransactionGroup`, properly swallowing benign Revit warnings and applying any customized design styles.
- [ ] **AC-9 (matches RF-8 & RF-9):** Closing and reopening Revit preserves all settings (Auto-Sync, B&W, custom line/header styles, scale, range) read from Extensible Storage.

---

## 6. Out of Scope (Planned for Subsequent Specs)

- **Spec 003:** Global Project Style Mapping Profiles (saving reusable design presets to apply across multiple projects).
- **Spec 004:** Real-time FileSystemWatcher background daemon with automatic model update.
- **Spec 005:** Direct import into Revit Schedule View headers (`ViewSchedule`).
- **Spec 006:** Word (`.docx`) and PDF (`.pdf`) rasterized table vectorization.

