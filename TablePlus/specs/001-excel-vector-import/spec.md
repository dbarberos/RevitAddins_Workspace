# Specification: 001 — Core Excel Vector Table Import

**Spec ID:** `001-excel-vector-import`  
**Target Add-in:** `TablePlus`  
**Feature Branch:** `TablePlus`  
**Architect:** SDD Architect  
**Status:** DRAFT FOR USER REVIEW (PHASE GATE 2)  
**Date:** 2026-09-22  
**Language:** English (Official Engineering Standard)  

---

## 1. Context & Business Value

BIM Managers, structural engineers, and architects frequently need to present structured tabular data (schedules of finishes, door hardware matrices, calculation summaries, general notes) within Autodesk Revit sheets. Creating these tables manually in Revit is tedious, error-prone, and visually restrictive.

`TablePlus` Spec `001` delivers the foundational vertical slice of the add-in: an end-to-end workflow enabling users to browse and select Excel workbooks (`.xlsx`, `.xls`, `.csv`), select specific worksheets or cell ranges (e.g., `A1:G35`), and convert them into high-fidelity native Revit 2D vector geometry (**Drafting Views** and **Legend Views**) using detail lines (`DetailCurve`), text notes (`TextNote`), and filled regions (`FilledRegion`) with cell borders and background colors.

---

## 2. Reference Project Findings (`references_examples/DiRootsOne`)

- **Reference Examined:** `references_examples/DiRootsOne/DiRoots.One/tablegen/` and `DiRoots.One.TGDatabaseLayer`.
- **Reused Algorithmic Logic:**
  - Parsing row heights and column widths to calculate exact 2D geometric bounding boxes for cells.
  - Computing merged cell bounding polygons and centering/aligning text notes.
  - Converting Excel RGB cell shading into Revit `FilledRegion` with solid fill patterns and color overrides.
  - Associating metadata with created views via Revit `Extensible Storage` (`SchemaUtil`).
- **Discarded / Replaced Components:**
  - Discard all legacy Windows Forms / DiRoots WPF windows.
  - Replace proprietary and obfuscated libraries (`A.--.50.cs`) with clean managed .NET libraries (`ClosedXML` / `ExcelDataReader`) that operate without requiring Microsoft Office installed on the client machine.
  - Discard raw COM invocations in favor of clean C# 12 and `CommunityToolkit.Mvvm`.

---

## 3. Clinical Boundary Questionnaire Resolutions

1. **Parameter & Type Existence:** If a mapped font or line style does not exist in the project, fallback gracefully to the active document's default `TextNoteType` and `<Thin Lines>` line style.
2. **Document State:** The add-in shall only execute in project documents (`.rvt`). The command is disabled if `doc.IsFamilyDocument` is true or if `doc.IsReadOnly` is true.
3. **Worksharing & Borrowing:** Views created (`ViewDrafting`, `ViewLegend`) are new elements assigned to the user's active workset; no element borrowing conflicts occur during creation.
4. **Target Scope:** The user specifies whether the table is generated as a **Drafting View** (for single sheet placement) or a **Legend View** (for multiple sheet placement).
5. **Units & Precision:** Coordinates are calculated in feet (Revit internal unit) based on cell millimeter/inch measurements scaled by the chosen view scale factor.
6. **Failure Preprocessing:** All transactions are guarded by `WarningSwallower` (`IFailuresPreprocessor`) to silently swallow benign line-overlap or small-geometry warnings.
7. **Threading & Execution:** The UI operates as a modal dialog (`ShowDialog()`). Heavy Excel parsing runs on a background task with a progress indicator, while Revit DB mutations run synchronously within the transaction on the main Revit thread.
8. **Extensible Storage:** Every generated view is stamped with a dedicated `TablePlus` schema containing: `SourceFilePath`, `WorksheetName`, `CellRange`, `LastModifiedTimeUtc`, and `ImportMode`.
9. **Large Table Protection:** A safety ceiling warning is displayed if the selected cell range exceeds 3,000 cells to prevent Revit view performance degradation.

---

## 4. Functional Requirements (EARS Notation)

### RF-1: File Selection & Workbook Loading (Ubiquitous & Event-driven)
- **RF-1.1:** The add-in shall provide an intuitive file picker and drag-and-drop zone accepting `.xlsx`, `.xls`, and `.csv` files.
- **RF-1.2:** When a valid file is loaded, the add-in shall asynchronously inspect the workbook structure and display available worksheets.
- **RF-1.3:** If the file is locked or corrupt, the add-in shall display a user-friendly error message without crashing.

### RF-2: Worksheet & Range Selection (State-driven)
- **RF-2.1:** While a workbook is loaded, the add-in shall allow the user to select:
  - The entire worksheet (used range).
  - Excel Named Ranges defined within the workbook.
  - A custom cell range specified in standard notation (e.g., `A1:G25`).
- **RF-2.2:** The add-in shall validate cell range syntax and warn if the specified range contains zero populated cells.

### RF-3: View Configuration (State-driven)
- **RF-3.1:** The add-in shall allow the user to choose the target Revit View Type:
  - **Drafting View** (`ViewDrafting`)
  - **Legend View** (Legend)
- **RF-3.2:** The add-in shall allow the user to specify the target View Name and View Scale (defaulting to 1:1).
- **RF-3.3:** If a view with the chosen name already exists in the document, the add-in shall automatically suggest an incremental suffix (e.g., `Table - Sheet1 (1)`) or allow user renaming.

### RF-4: Native Vector Geometry Generation (Event-driven)
- **RF-4.1:** When the user clicks "Import Table", the add-in shall open a single scoped Revit `Transaction` and generate the view.
- **RF-4.2:** The add-in shall generate horizontal and vertical `DetailCurve` boundary lines matching Excel cell grid lines and border weights.
- **RF-4.3:** The add-in shall generate `TextNote` elements positioned with horizontal alignment (Left, Center, Right) and vertical alignment (Top, Middle, Bottom) matching the source cells.
- **RF-4.4:** Where cells have background fill colors, the add-in shall generate a `FilledRegion` with a solid fill pattern and the corresponding RGB color.
- **RF-4.5:** Where cells are merged, the add-in shall calculate the unified bounding box, suppress internal grid lines, and place a single aligned `TextNote`.

### RF-5: Extensible Storage Stamping (Ubiquitous)
- **RF-5.1:** The add-in shall stamp the created view with `TablePlus_TableDataSchema` storing the source path, sheet name, cell range, and file timestamp.

### RF-6: UI/UX, Ribbon Integration & Design System (Ubiquitous)
- **RF-6.1:** The user interface shall be built using the **FilterPlus modern card-based theme**, supporting Revit 2024+ light and dark themes.
- **RF-6.2:** All styles, templates, and converters shall be defined inline in `<Window.Resources>`.
- **RF-6.3:** List controls displaying worksheets or files shall utilize WPF virtualization.
- **RF-6.4:** The add-in shall register a dedicated Ribbon PushButton (`Import Excel`) with 16x16 and 32x32 px icons in Revit's Ribbon (`Application.cs`), launching the modal import window via `CmdImportTable : IExternalCommand`.

---

## 5. Acceptance Criteria (AC)

- [x] **AC-1 (matches RF-1):** Loading a multi-sheet `.xlsx` file populates the worksheet list within 1.5 seconds without freezing the UI.
- [x] **AC-2 (matches RF-2):** Selecting `A1:D10` correctly scopes the extraction to exactly 10 rows and 4 columns.
- [x] **AC-3 (matches RF-3):** Selecting "Legend View" creates a view under Revit's *Legends* project browser category that can be placed on multiple sheets simultaneously.
- [x] **AC-4 (matches RF-4):** Generated tables display crisp detail lines matching column widths, text notes with correct formatting, and solid color backgrounds for shaded cells.
- [x] **AC-5 (matches RF-4.5):** Merged cells render as a single unified cell without intersecting interior grid lines.
- [x] **AC-6 (matches RF-5):** Querying the view with Revit Lookup or Extensible Storage API reveals the stamped `TablePlus` metadata.
- [x] **AC-7 (matches RF-6):** The UI seamlessly adopts the active Revit light/dark theme without hardcoded black/white contrast defects.
- [x] **AC-8 (matches RF-6.4):** Clicking the "Import Excel" button on the Revit Ribbon opens the `TableImportView` modal window ready for interaction.

---

## 6. Out of Scope for Spec 001 (Planned for Subsequent Specs)

- **Spec 002:** Advanced user-configured Style Mapping dialog (custom font-to-TextNoteType remapping tables, B&W toggle).
- **Spec 003:** Word (`.docx`) and PDF (`.pdf`) rasterized Image Mode import.
- **Spec 004:** Auto-Sync and background file watcher engine.
- **Spec 005:** Direct import into Revit Schedule View headers (`ViewSchedule`).
