# Walkthrough: Standard Mode Tree Optimization & Loadable Families Separation

**Date:** 2026-08-19  
**Component:** `TransferPlus.Services.DocumentCollector`, `TransferPlus.ViewModels.TransferPlusViewModel`  
**Status:** Validated and Deployed across Revit 2024-2027

---

## 1. Summary of Changes

1. **Elimination of Redundant Loadable Component Families from Standard Mode:**
   - In [DocumentCollector.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/DocumentCollector.cs), `Step 1 (Element Types)` now excludes `FamilySymbol` items belonging to editable, non-in-place families (`familySymbol.Family?.IsEditable == true && !familySymbol.Family.IsInPlace`).
   - `Step 28 (Loadable Families bulk collection)` is omitted from the standard tree pass.
   - This keeps the standard explorer significantly lighter and faster, removing hundreds of 3D component doors, windows, furniture, lighting, and mechanical symbols that are already specialized in Family Mode.

2. **100% Preservation of System Families, Annotations, Standards & Views in Standard Mode:**
   - **System Families:** Walls (`WallType`), Floors (`FloorType`), Roofs (`RoofType`), Ceilings (`CeilingType`), Stairs (`StairsType`), Railings (`RailingType`), Foundations (`WallFoundationType`, `ContinuousFootingType`), Curtain Systems (`CurtainSystemType`), Ducts (`DuctType`), Pipes (`PipeType`), etc.
   - **System Annotation Types:** Text Styles (`TextNoteType`), Dimension Styles (`DimensionType`), Grid Types (`GridType`), Level Types (`LevelType`), Filled Regions (`FilledRegionType`), Viewport Types, View Family Types.
   - **Views, Sheets & Templates:** Floor Plans, Sections, Elevations, Drafting Views, 3D Views, Sheets (`ViewSheet`), Schedules (`ViewSchedule`), Legends, View Templates.
   - **Project Standards:** Materials (`Material`), View Filters (`ParameterFilterElement`), Object Styles, Line Patterns, Fill Patterns, Worksets, Global Parameters, Assemblies.

3. **Dedicated Family Mode Specialization:**
   - All loadable component families (`.rfa`) remain exclusively accessible and managed in **Family Mode**, featuring:
     - Multi-source repositories (Local folders, Azure, AWS S3, Autodesk Docs, Open/Linked docs).
     - Async 128x128 px thumbnail previews and complete metadata (`File size`, `Last modified`, `Host`, `Revit Version`).
     - Granular type checkboxes, local `.rfa` download, and model family deletion.

---

## 2. Verification

- All Release configurations (`Release.R24`, `Release.R25`, `Release.R26`, `Release.R27`) compiled with **0 errors**.
- Deployed locally to `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\`.
- Updated Autodesk App Store distribution package: `TransferPlus/TransferPlusPublishPackage/TransferPlus.bundle.zip` and `TransferPlus/Deploy/TransferPlus_v1.1.0.zip`.
