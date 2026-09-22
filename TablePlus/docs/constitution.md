# TablePlus — Constitution & Inviolable Architectural Principles

**Scope:** Add-in Local (`TablePlus`)  
**Parent Constitution:** [Global Workspace Constitution](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/docs/constitution.md)  
**Authority:** Subordinate only to [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md) and Global Constitution  
**Language:** English (Official Engineering Standard)  
**Status:** APPROVED (Updated for Comprehensive Tabular Suite)  
**Date:** 2026-09-22  

---

## 1. Domain Objective & Strategic Scope

`TablePlus` is the enterprise Autodesk Revit add-in designed as a **Comprehensive Tabular & Spreadsheet Management Suite**. It unifies two critical BIM spreadsheet workflows into a single cohesive platform:

1. **Visual Table & Document Publishing (Sheet Placement)**:
   - Imports external spreadsheets (`.xlsx`, `.xls`, `.csv`), Word documents (`.docx`), and PDFs into Revit as native **Drafting Views**, **Legend Views**, or high-resolution **Images**.
   - Preserves typographic elegance, cell borders, fill colors, and merged cell hierarchies.
   - Manages table lifecycle and reload strategies (`UpdateDataOnly`, `PreserveRevitColumnRowSize`, `RecreateSchedule`).
2. **Parametric Schedule Data Exchange (Bidirectional Model Editing)**:
   - Inspects and exports native Revit **Tablas de Planificación / Schedules** (`ViewSchedule`) and model element parameters to Excel.
   - Re-imports modified Excel data back into Revit to update building element parameters (`Element.get_Parameter().Set()`) with full transaction safety and validation.
3. **Extensible Modular Foundation**:
   - Built to accommodate future tabular extensions (e.g., custom formula engines, cloud sync, automated table splitters).

---

## 2. Reference Projects Governance (`references_examples/`)

This add-in draws its operational patterns and algorithmic foundations from two established DiRoots components, while completely modernizing their architecture:

| Reference Component | Role & Reusable Logic | Discarded Elements |
|---|---|---|
| **`references_examples/.../tablegen`** | Cell dimension math, merged cell polygons, vector line/text placement, cell fill shading, and `UpdateBehaviorOption` logic. | Discard legacy Windows Forms/WPF dialogs, obfuscated helper classes (`A.--.50.cs`), and hardcoded dark theme. |
| **`references_examples/.../sheetlink`** | `ViewSchedule` inspection, parameter extraction, row-to-element mapping, and transactional batch parameter updates. | Discard Syncfusion proprietary dependencies; replace with clean open-source .NET libraries (`ClosedXML`). |

**Strict Read-Only Guarantee**: Files in `references_examples/` must never be modified, renamed, or overwritten.

---

## 3. Modular Specification Roadmap (Vertical Slices)

To maintain software engineering rigor and deterministic delivery, `TablePlus` is broken into sequential vertical specifications:

```text
TablePlus/specs/
├── 001-excel-vector-import/     # [ACTIVE] Core Excel Vector Table Import to Drafting/Legend views
├── 002-table-sync-reload/       # Table Sync & Reload Engine (UpdateDataOnly, PreserveSizes, Recreate)
├── 003-schedule-data-exchange/  # Bidirectional Schedule Link (Revit Schedules <-> Excel parameter editing)
├── 004-style-mapping/           # Advanced Style Mapping (Lines, Text Fonts, Decimal separators, B&W)
└── 005-document-image-import/   # Word (.docx) & PDF (.pdf) Rasterized Image Import
```

---

## 4. Inviolable Architectural Principles

### 4.1. Design System & UI Replacement
- Discard all legacy UI from both reference projects.
- All windows, dialogs, and panels must use the **FilterPlus modern card-based theme**:
  - Light and dark theme adaptation for Revit 2024+.
  - All templates, styles, and brushes declared inline within `<Window.Resources>`. Zero `pack://application:,,,/` external dictionary imports.
  - Virtualization enabled on all collection controls (`VirtualizingStackPanel.IsVirtualizing="True"`).

### 4.2. Revit API Transaction Invariants
- **Visual View Generation (Module 1)**: Operations must be wrapped in a scoped `using (Transaction tx = new Transaction(doc, "Import Table"))` with a `WarningSwallower` (`IFailuresPreprocessor`) to dismiss harmless geometry warnings.
- **Parametric Schedule Updates (Module 2)**: Modifications to model elements must be wrapped in a `Transaction` or `TransactionGroup` with rollback protection. Check `doc.IsWorkshared` and enforce element borrowing prior to mutation.
- **Read Operations**: Never open transactions for inspecting documents, workbooks, or reading schedule definitions.

### 4.3. Pure Managed Office Independence
- **Zero COM Dependencies**: No dependency on `Microsoft.Office.Interop.Excel` or client-installed Microsoft Office.
- All spreadsheet manipulation must use clean, open-source managed libraries (e.g., `ClosedXML` / `ExcelDataReader`).

### 4.4. Unified Ribbon & Entry Points (`Application.cs`)
The add-in registers a unified Ribbon Panel under the `DBDev Tools` tab (or `Add-Ins` if tab exists):
- **Panel:** `TablePlus` (or `Tables`)
- **Buttons**:
  - `Import Table` (`CmdImportTable`)
  - `Sync Tables` (`CmdSyncTables`)
  - `Schedule Link` (`CmdScheduleLink`)
  - `Settings` (`CmdTableSettings`)
- Multi-version resolution hook `AppDomain.CurrentDomain.AssemblyResolve` registered in `OnStartup()`.

### 4.5. Persistent Metadata Schema (Extensible Storage)
- Every generated table view and synchronized schedule link must be stamped with a registered `TablePlus` Extensible Storage schema storing:
  - `SourceFilePath`
  - `SheetName` / `RangeAddress`
  - `LastImportTimestampUtc`
  - `MappingProfileId`
  - `UpdateBehavior`

---

## 5. Prohibited Patterns
- ❌ Do NOT store native Revit `Element` instances in ViewModels.
- ❌ Do NOT write code across modules without approving their corresponding vertical `spec.md`, `plan.md`, and `tasks.md`.
- ❌ Do NOT suppress fatal failures or corrupt document state (`FailureSeverity.DocumentCorruption`).
