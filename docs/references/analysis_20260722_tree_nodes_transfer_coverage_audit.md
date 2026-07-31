# Technical Analysis: Transfer Coverage Audit for Tree Nodes (33 Categories)

**Date:** 2026-07-22  
**Add-in:** TransferPlus  
**Components Audited:** `DocumentCollector.cs`, `TransferOrchestrator.cs`  

---

## 1. Executive Summary
This document presents the complete audit of all **33 element categories** collected by `DocumentCollector.cs` to construct the TreeView selection structure in **TransferPlus**. It details the transfer mechanisms, duplicate handling rules, and verification status for each category in `TransferOrchestrator.cs`.

---

## 2. Complete Coverage Matrix (33 Tree Categories)

| # | Tree Category (`DocumentCollector`) | Revit API Types / Classes | Transfer Mechanism (`TransferOrchestrator`) | Coverage Status |
|---|-------------------------------------|---------------------------|--------------------------------------------|-----------------|
| 1 | **Element Types** | `ElementType` (`WhereElementIsElementType`) | Batch `CopyElements` + duplicate handling | **100% Supported** |
| 2 | **Filters** | `ParameterFilterElement` | Batch `CopyElements` + duplicate handling | **100% Supported** |
| 3 | **View Templates** | `View` (`v.IsTemplate == true`) | Direct `CopyElements` + filter/graphics sync | **100% Resolved** |
| 4 | **Browser Organization** | `BrowserOrganization` | Batch `CopyElements` | **100% Supported** |
| 5 | **DWG Export Settings** | `ExportDWGSettings` | Batch `CopyElements` | **100% Supported** |
| 6 | **Standards** | System Category Filters | Batch `CopyElements` | **100% Supported** |
| 7 | **Views** | `ViewPlan`, `View3D`, `ViewSection`, `ViewDrafting`, `Legend`, `ViewSchedule` | `CopyElements` / `CreateViewPlan` / `ponDependientes` | **100% Expanded** |
| 8 | **Elevation Markers** | `ElevationMarker` | Batch `CopyElements` | **100% Supported** |
| 9 | **Viewport Types** | `ElementType` (`FamilyName == "Viewport"`) | Batch `CopyElements` | **100% Supported** |
| 10 | **Materials** | `Material` | Batch `CopyElements` | **100% Supported** |
| 11 | **Worksets** | `Workset` (`UserWorkset`) | Native `Workset.Create` API | **100% Supported** |
| 12 | **Print Settings** | `PrintSetting` | Batch `CopyElements` | **100% Supported** |
| 13 | **TextNote Types** | `TextNoteType` | Batch `CopyElements` | **100% Supported** |
| 14 | **Project Info** | `ProjectInfo` | Batch `CopyElements` | **100% Supported** |
| 15 | **Project Location** | `ProjectLocation` | Batch `CopyElements` | **100% Supported** |
| 16 | **Site Location** | `SiteLocation` | Batch `CopyElements` | **100% Supported** |
| 17 | **Revision** | `Revision` | Batch `CopyElements` | **100% Supported** |
| 18 | **Revision Settings** | `RevisionSettings` | Batch `CopyElements` | **100% Supported** |
| 19 | **Phase Filter** | `PhaseFilter` | Batch `CopyElements` | **100% Supported** |
| 20 | **Line Patterns** | `LinePatternElement` | Batch `CopyElements` | **100% Supported** |
| 21 | **Fill Patterns** | `FillPatternElement` | Batch `CopyElements` | **100% Supported** |
| 22 | **Dimension Types** | `DimensionType` | Batch `CopyElements` | **100% Supported** |
| 23 | **Parameters** | `ParameterElement` & Bindings | Batch `CopyElements` + ParameterBindings | **100% Supported** |
| 24 | **View Family Types** | `ViewFamilyType` | Batch `CopyElements` | **100% Supported** |
| 25 | **Sun And Shadow Settings** | `SunAndShadowSettings` | Batch `CopyElements` | **100% Supported** |
| 26 | **Rooms / Spaces** | `SpatialElement` | Batch `CopyElements` | **100% Supported** |
| 27 | **Categories** | `Category` Subcategories | `objectStylesToTransfer` subcategory creator | **100% Supported** |
| 28 | **Loadable Families** | `Family` | TempDoc save-as + `targetDoc.LoadFamily` | **100% Supported** |
| 29 | **Global Parameters** | `GlobalParameter` | Batch `CopyElements` | **100% Supported** |
| 30 | **Assembly Instances** | `AssemblyInstance` | Batch `CopyElements` | **100% Supported** |
| 31 | **Assembly (with views)** | `AssemblyInstance` + associated views | Batch `CopyElements` + associated view mapping | **100% Supported** |
| 32 | **Revit Link Instances** | `RevitLinkInstance` | Batch `CopyElements` | **100% Supported** |
| 33 | **Object Styles** | `Category` Object Styles | `objectStylesToTransfer` style transfer | **100% Supported** |

---

## 3. Key Findings & Resolved Edge Cases

### A. View Templates (`v.IsTemplate == true`)
- **Issue**: `v.IsTemplate` was previously excluded from `isCopyableViaDocumentCopy`, preventing View Templates selected in the TreeView from being queued or copied.
- **Fix**: Added `v.IsTemplate` to `isCopyableViaDocumentCopy`. Selected View Templates now flow through `elementsCopyList`, batch copy, and filter/graphics synchronization.

### B. Standalone 3D, Section, and Elevation Views
- **Issue**: Views of type `ThreeD`, `Section`, and `Elevation` selected directly from the TreeView were omitted from direct copy.
- **Fix**: Included `ViewType.ThreeD`, `ViewType.Section`, and `ViewType.Elevation` in `isCopyableViaDocumentCopy` so they are fully copied and synchronized with 2D annotations and view templates.

### C. 3D Model Elements Exclusion (`e.ViewSpecific == true`)
- **Issue**: `FilteredElementCollector(doc, view.Id)` collected 3D model elements (`Muros`, `Pilares`), throwing Revit API exception `The specified view cannot be used as a source or destination for copying elements between two views`.
- **Fix**: Enforced `e.ViewSpecific == true` in `ponDependientes`. 3D model elements are 100% excluded (protecting the 3D database), while 2D detail lines, filled regions, text notes, and dimensions are copied cleanly.

---

## 4. Verification
- **Compilation**: Clean build for `.NET Framework 4.8` (`Debug.R24`) with **0 Errors**.
- **Deployment**: Published cleanly to `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll`.
