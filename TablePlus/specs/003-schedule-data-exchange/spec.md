# Specification: Bidirectional Schedule Data Exchange (Revit Schedules & Categories <-> Excel)

**Spec ID:** `003`  
**Target Add-in:** `TablePlus`  
**Feature Branch:** `feature/003-schedule-data-exchange`  
**Author / Architect:** SDD Polyglot Architect  
**Status:** DRAFT (Phase Gate 2: Ready for User Validation)  
**Date:** 2026-09-24  

---

## 1. Context & Business Value

In Specifications 001 and 002, **TablePlus** successfully delivered its core graphic publishing engines: importing spreadsheets into native vector Drafting/Legend views, offering live monitoring, in-place synchronization, style mappings, and an 11-column virtualized Master Table Dashboard.

However, modern BIM workflows require more than 2D visual publishing: BIM managers, architects, quantity surveyors, and engineers frequently need to perform **bulk editing of Revit model element parameters** (such as room finishes, fire ratings, equipment marks, structural dimensions, or COBie data). Editing thousands of element parameters manually within Revit's native schedule view is notoriously slow, lacks multi-cell drag-and-fill capabilities, and cannot easily leverage advanced Excel formulas or automated scripts.

This specification introduces **Specification 003: Bidirectional Schedule Data Exchange** (`Schedule Link`), integrating the second strategic pillar defined in the [TablePlus Constitution](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/docs/constitution.md):
1. **Dual Extraction Engine**: Export tabular data directly from existing Revit Schedules (`ViewSchedule`) OR directly by Model Categories / Family Types without requiring a pre-existing schedule.
2. **Selective Parameter Inspection**: Intuitive parameter picker distinguishing Instance vs. Type parameters, Built-in vs. Shared parameters, and flagging Read-Only system fields.
3. **High-Fidelity ClosedXML Excel Generation**: Formatted Excel export preserving active Revit display units (e.g. `mm`, `m²`, `°`), locking non-editable metadata columns (`Id`, `UniqueId`), and visually highlighting Type parameters with global-impact badges.
4. **Interactive Worksharing Conflict Resolver**: In workshared models (`doc.IsWorkshared`), if elements are borrowed or locked by other users, an interactive conflict screen is presented allowing the user to either:
   - **Option A**: Proceed updating unborrowed elements and produce an itemized conflict report.
   - **Option B**: Perform an atomic rollback (`TransactionGroup.RollBack()`) and abort, allowing the user to request borrowing in Revit.
5. **Robust In-Place Parameter Writing**: Type-safe parser converting user entries back into Revit's internal database values (`StorageType.String`, `Double`, `Integer`, `ElementId`), enforcing transaction safety, suppressing benign warnings, and reporting comprehensive mutation metrics.

---

## 2. Reference Project Findings (`references_examples/DiRootsOne/`)

- **Reference Analyzed:** `references_examples/DiRootsOne/DiRoots.One/sheetlink/` (`DiRoots.One/sheetlink/sheetlink.core/`)
- **Reused Logic & Patterns:**
  - `ViewSchedule` field extraction: Reading `ScheduleDefinition`, `ScheduleField`, and querying `FilteredElementCollector(doc, viewSchedule.Id)` to extract row elements exactly as filtered and sorted in the native schedule.
  - Category-based extraction: Querying model elements via `FilteredElementCollector(doc).OfCategory(bic).WhereElementIsNotElementType()` and collecting bound parameter sets.
  - Parameter mapping and storage type deduction (`Parameter.StorageType` handling for Double, Integer, String, and ElementId).
- **Discarded / Replaced Components:**
  - **Discarded Legacy UI**: Eliminated complex proprietary Syncfusion grid controls, outdated DevExpress styles, and legacy WinForms dialogs.
  - **Replaced with FilterPlus Design System**: Replaced with clean WPF/MVVM windows with inline XAML resources, virtualized data grids, responsive search boxes, and theme adaptation.
  - **Zero Third-Party Closed Dependencies**: Replaced all proprietary Excel writers with open-source `ClosedXML` and `DocumentFormat.OpenXml`.

---

## 3. Clinical Boundary Questionnaire Resolutions

Based on the architectural clinical questionnaire completed in Phase 2:

1. **Extraction Scope (Dual Mode)**:
   - The user can toggle between **Existing Schedules** (extracts visible fields and filtered rows from a `ViewSchedule`) and **Category Direct Mode** (selects any model category, listing all available instance and type parameters).
2. **Worksharing & Borrowing Conflicts**:
   - Before attempting modifications in workshared models (`doc.IsWorkshared`), the add-in inspects element editability via `WorksharingUtils.GetCheckoutStatus(doc, elementId)`.
   - If blocked or borrowed elements are detected, the system displays an **Interactive Worksharing Conflict Modal** with two clear options:
     - **Option 1 (Skip & Report)**: Proceed with updating accessible elements, skipping locked ones, and displaying a detailed report of locked elements and current owners upon completion.
     - **Option 2 (Full Rollback & Abort)**: Immediately cancel the entire import and roll back the transaction group so the user can request ownership/borrowing in Revit without partial database updates.
3. **Type Parameter Handling**:
   - Both Instance and Type parameters can be exported and updated.
   - In Excel, Type parameter columns are visually branded with a distinct header color (e.g. Lavender/Purple with a `[TYPE]` badge) and a cell comment warning that editing this cell will update all instances sharing that family symbol.
   - On import, unique family types are collected and modified once to prevent redundant database churn.
4. **Units of Measurement & Formatting**:
   - Values are exported using active Revit Project Display Units via `UnitFormatUtils.Format` and `ForgeTypeId`.
   - On import, numerical values are parsed back into internal Revit units using `UnitFormatUtils.TryParse` or culture-aware parsing matching the project unit specifications.
5. **Unique Key & Identifier Integrity**:
   - Every exported Excel worksheet reserves two non-editable metadata columns: `A: ElementId` and `B: UniqueId`.
   - These columns are visually locked (grayed out) with an Excel cell protection notice to prevent accidental row re-indexing or corrupting element references.
6. **Read-Only / Calculated Parameters**:
   - Parameters returning `Parameter.IsReadOnly == true` (such as `Area`, `Volume`, calculated formula fields, or system-managed parameters) are exported with a `[READ-ONLY]` header indicator and gray background, and are skipped automatically during import with zero transaction errors.
7. **Transaction Isolation**:
   - The entire import sequence is wrapped inside an atomic `TransactionGroup` (`"TablePlus Schedule Data Sync"`).
   - Non-fatal warnings are swallowed using the unified `WarningSwallower` (`IFailuresPreprocessor`).
8. **UI Modality & Navigation**:
   - Executed as a modal WPF window (`ScheduleLinkView`) owned by Revit's main handle, preventing focus loss and guaranteeing that document state is not modified concurrently while configuring mappings.

---

## 4. Functional Requirements (EARS Notation)

- **RF-1 (Ubiquitous):** The add-in shall provide a dedicated entry point `Schedule Link` (`CmdScheduleLink`) within the TablePlus ribbon panel under Revit's native **Add-Ins / Complementos** tab.
- **RF-2 (Event-driven):** When the user selects **Schedules Mode**, the add-in shall populate a list of all non-template `ViewSchedule` elements in the active document and display their active fields upon selection.
- **RF-3 (Event-driven):** When the user selects **Categories Mode**, the add-in shall list all model categories containing elements in the project, allowing multi-selection of target categories and interactive selection of desired Instance and Type parameters.
- **RF-4 (State-driven):** While inspecting parameters in either mode, the add-in shall categorize parameters into **Instance**, **Type**, and **Read-Only**, allowing the user to select/deselect specific columns for export.
- **RF-5 (Event-driven):** When the user clicks **Export to Excel**, the add-in shall generate a multi-tab or single-tab `.xlsx` workbook using `ClosedXML`, embedding locked `ElementId`/`UniqueId` headers, formatted project unit strings, and visual badges for Type and Read-Only parameters.
- **RF-6 (Event-driven):** When the user clicks **Import from Excel**, the add-in shall prompt for an edited workbook, read the rows matching `ElementId`/`UniqueId`, and compare spreadsheet values against live Revit parameter values to identify changed cells.
- **RF-7 (State-driven):** If the document is workshared (`doc.IsWorkshared`) and one or more elements to be updated are owned/borrowed by other users, the add-in shall display the **Worksharing Conflict Dialog** prompting the user to either:
  1. Continue updating unblocked elements and log an itemized incident list, OR
  2. Roll back all pending transactions and cancel the import completely.
- **RF-8 (Ubiquitous):** The add-in shall parse edited values into Revit internal units according to their parameter `StorageType` and active `ForgeTypeId` display units, applying mutations via `Parameter.Set()`.
- **RF-9 (Unwanted behavior):** If a user enters an invalid value in Excel (e.g. text in a numerical length parameter or an out-of-range integer), the add-in shall catch the parsing failure, preserve the original Revit value, and flag the cell in the final reconciliation report without crashing.
- **RF-10 (Event-driven):** When the import process completes (or is aborted), the add-in shall present an executive **Reconciliation Summary Dialog** displaying:
  - Total rows analyzed.
  - Number of parameters successfully updated.
  - Number of unchanged parameters skipped.
  - Number of errors/invalid formats detected.
  - Number of worksharing conflicts skipped (if Option 1 was selected).

---

## 5. Acceptance Criteria (AC)

- [ ] **AC-1 (matches RF-1):** Clicking the `Schedule Link` ribbon button under `Add-Ins > TablePlus` opens `ScheduleLinkView` centered on Revit's main window without assembly loading errors.
- [ ] **AC-2 (matches RF-2):** In Schedules Mode, selecting any project `ViewSchedule` accurately queries all scheduled elements and their corresponding column fields.
- [ ] **AC-3 (matches RF-3):** In Categories Mode, selecting a category (e.g. `OST_Doors` or `OST_Rooms`) accurately queries all project instances and presents all associated Instance and Type parameters in a searchable checklist.
- [ ] **AC-4 (matches RF-4):** The parameter selection UI distinctly indicates parameter scopes (`Instance`, `Type`, `Read-Only`) and allows one-click Select All / Deselect All operations.
- [ ] **AC-5 (matches RF-5):** Exporting to Excel creates a valid `.xlsx` workbook containing `ElementId`, `UniqueId`, formatted display values, and distinctive styling for Type headers (`[TYPE]`) and Read-Only headers (`[READ-ONLY]`).
- [ ] **AC-6 (matches RF-6):** Importing an Excel file correctly correlates rows with Revit elements using `UniqueId`/`ElementId` and detects modified cells without altering unmodified cells.
- [ ] **AC-7 (matches RF-7):** In workshared projects with borrowed elements, the interactive conflict screen appears and correctly honors both user choices: proceeding with non-conflicting elements (with report) or executing a clean `TransactionGroup.RollBack()`.
- [ ] **AC-8 (matches RF-8):** Updated parameter values in Revit reflect the exact numerical values formatted in the project's active units (e.g. length in millimeters or feet).
- [ ] **AC-9 (matches RF-9):** Invalid user entries (non-parseable strings, invalid enum values) are trapped safely without corrupting the model or throwing unhandled exceptions.
- [ ] **AC-10 (matches RF-10):** The reconciliation report dialog displays accurate counts of updated, unchanged, and failed elements with clear descriptions.

---

## 6. Out of Scope (Non-Goals)

- Automatic creation or deletion of Revit building elements (doors, walls, rooms) from Excel rows (Specification 003 is strictly bidirectional parameter data synchronization for existing elements).
- Synchronizing Revit family geometry, 3D meshes, or CAD blocks from Excel.
- Editing calculated formula columns that do not map to physical Revit parameters.
