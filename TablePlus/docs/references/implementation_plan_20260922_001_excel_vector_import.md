# Implementation Plan: 001 — Core Excel Vector Table Import

**Add-in:** `TablePlus`  
**Feature Spec:** `001-excel-vector-import`  
**Date:** 2026-09-23  
**Status:** FULLY EXECUTED & VALIDATED (T1–T9 Complete)  
**Architect:** SDD Architect  
**Language:** English  

---

## 1. Technical Context & Scope

`TablePlus` is a comprehensive Revit tabular management suite unifying spreadsheet-to-vector documentation (inspired by DiRoots TableGen) and schedule data exchange (inspired by DiRoots SheetLink).

Specification `001-excel-vector-import` delivers the core foundation:
- Direct vector importation from Excel (`.xlsx`, `.xls`, `.csv`) into native Revit **Drafting Views** (`ViewDrafting`) and **Legend Views** (Legends).
- Excel cell formatting fidelity: Font sizes, alignments, borders, background fills (`FilledRegion`), and merged cells (`MergedCellRange`).
- Provenance stamping via Revit **Extensible Storage** (`TablePlus_TableData`, Schema GUID `E3B21D40-6C9A-4E2F-8A11-92D0543B7A1C`).
- Modern UI following the **FilterPlus card-based theme** with full WPF virtualization and inline resources.

---

## 2. Architecture & Service Decomposition

```text
TablePlus/
├── Application.cs                  # IExternalApplication (Ribbon Tab 'DBDev Tools' / 'Tables')
├── TablePlus.csproj               # Nice3point.Revit.Sdk multi-targeted (.NET 4.8 / .NET 8)
├── TablePlus.addin                # AddIn manifest (VendorId: DBDev_dbarberos)
├── Commands/
│   └── CmdImportTable.cs          # IExternalCommand (Manual transaction entrypoint)
├── Models/
│   ├── Enums.cs                   # TargetViewType, CellAlignments, RangeModes
│   ├── ExcelCellModel.cs          # Pure domain DTO for cell geometry & styling
│   ├── MergedCellRange.cs         # Bounding coordinates for merged blocks
│   ├── ExcelWorkbookModel.cs      # Workbook structure & sheets metadata
│   └── TableImportConfig.cs       # Import execution parameters & timestamp
├── Services/
│   ├── IExcelReaderService.cs     # Excel parsing abstraction
│   ├── ExcelReaderService.cs      # ClosedXML engine (COM-free, DefinedNames)
│   ├── ITableGeometryService.cs   # Revit vector element creation contract
│   ├── TableGeometryService.cs    # Curves, TextNotes, FilledRegions generator
│   ├── ISchemaService.cs          # Extensible Storage contract
│   ├── SchemaService.cs           # Schema registry & view metadata stamping
│   └── WarningSwallower.cs        # IFailuresPreprocessor (popup suppression)
├── ViewModels/
│   └── TableImportViewModel.cs    # CommunityToolkit.Mvvm presentation logic
└── Views/
    ├── TableImportView.xaml       # FilterPlus card-based theme UI
    └── TableImportView.xaml.cs    # Code-behind
```

---

## 3. Core Technical Decisions

1. **Unmanaged COM-Free Excel Reader**:
   - Uses `ClosedXML` (v0.104.2) for fast, secure OpenXML inspection without Excel runtime dependencies.
   - Extracts font metrics, foreground/background hex colors, and merged cell boundaries.
2. **Revit Vector Geometry Engine**:
   - Computes table origin at $(0,0,0)$ with columns expanding along $+X$ and rows along $-Y$.
   - Dimensions converted from millimeters to feet: `mm * (1.0 / 304.8) * ViewScale`.
   - `FilledRegion` with `OverrideGraphicSettings` applying solid drafting fill patterns.
   - Interior border suppression for merged cell blocks.
3. **Extensible Storage Metadata**:
   - Schema GUID: `E3B21D40-6C9A-4E2F-8A11-92D0543B7A1C`.
   - Fields: `SourceFilePath`, `WorksheetName`, `CellRange`, `TimestampUtc`, `ViewScale`, `ConfigJson`.
   - Stamped automatically on the created view before committing the Revit transaction.
4. **WPF / MVVM Presentation**:
   - Inline resources in `<Window.Resources>` to prevent Revit host `pack://` resolution errors.
   - Card 1: Source File Selection (browse / drag & drop).
   - Card 2: Worksheet & Range Selection (entire sheet, named range, custom range).
   - Card 3: Target View Settings (Drafting vs Legend, view name, scale).
   - Action Bar: Determinate progress bar and execution triggers.
