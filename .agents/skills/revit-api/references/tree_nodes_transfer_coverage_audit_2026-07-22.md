# Technical Analysis: Tree Nodes Transfer Coverage Audit (33 Categories)

**Date:** 2026-07-22  
**Skill:** `revit-api`  
**Add-in:** TransferPlus  

## 1. Objective
Document the complete transfer coverage audit for all 33 categories collected by `DocumentCollector.cs` for Revit Add-in model element transfer workflows.

## 2. Complete Category Matrix

| # | Tree Category | Target Revit API Class | Transfer Mechanism | Status |
|---|---------------|------------------------|--------------------|--------|
| 1 | Element Types | `ElementType` | Batch `CopyElements` | Supported |
| 2 | Filters | `ParameterFilterElement` | Batch `CopyElements` | Supported |
| 3 | View Templates | `View` (`IsTemplate`) | Direct `CopyElements` + Filters/Graphics Sync | Resolved |
| 4 | Browser Organization | `BrowserOrganization` | Batch `CopyElements` | Supported |
| 5 | DWG Export Settings | `ExportDWGSettings` | Batch `CopyElements` | Supported |
| 6 | Standards | System Category Filters | Batch `CopyElements` | Supported |
| 7 | Views (Plan, 3D, Section, Elevation, Drafting, Legend, Schedule) | `View` subclasses | `CopyElements` / `CreateViewPlan` / `ponDependientes` | Expanded |
| 8 | Elevation Markers | `ElevationMarker` | Batch `CopyElements` | Supported |
| 9 | Viewport Types | `ElementType` | Batch `CopyElements` | Supported |
| 10 | Materials | `Material` | Batch `CopyElements` | Supported |
| 11 | Worksets | `Workset` | Native `Workset.Create` | Supported |
| 12 | Print Settings | `PrintSetting` | Batch `CopyElements` | Supported |
| 13 | TextNote Types | `TextNoteType` | Batch `CopyElements` | Supported |
| 14 | Project Info | `ProjectInfo` | Batch `CopyElements` | Supported |
| 15 | Project Location | `ProjectLocation` | Batch `CopyElements` | Supported |
| 16 | Site Location | `SiteLocation` | Batch `CopyElements` | Supported |
| 17 | Revision | `Revision` | Batch `CopyElements` | Supported |
| 18 | Revision Settings | `RevisionSettings` | Batch `CopyElements` | Supported |
| 19 | Phase Filter | `PhaseFilter` | Batch `CopyElements` | Supported |
| 20 | Line Patterns | `LinePatternElement` | Batch `CopyElements` | Supported |
| 21 | Fill Patterns | `FillPatternElement` | Batch `CopyElements` | Supported |
| 22 | Dimension Types | `DimensionType` | Batch `CopyElements` | Supported |
| 23 | Parameters | `ParameterElement` & Bindings | Batch `CopyElements` | Supported |
| 24 | View Family Types | `ViewFamilyType` | Batch `CopyElements` | Supported |
| 25 | Sun And Shadow Settings | `SunAndShadowSettings` | Batch `CopyElements` | Supported |
| 26 | Rooms / Spaces | `SpatialElement` | Batch `CopyElements` | Supported |
| 27 | Categories (Subcategories) | `Category` | `objectStylesToTransfer` | Supported |
| 28 | Loadable Families | `Family` | TempDoc save-as + `LoadFamily` | Supported |
| 29 | Global Parameters | `GlobalParameter` | Batch `CopyElements` | Supported |
| 30 | Assembly Instances | `AssemblyInstance` | Batch `CopyElements` | Supported |
| 31 | Assembly (with views) | `AssemblyInstance` + Views | Batch `CopyElements` + View Mapping | Supported |
| 32 | Revit Link Instances | `RevitLinkInstance` | Batch `CopyElements` | Supported |
| 33 | Object Styles | `Category` | `objectStylesToTransfer` | Supported |
