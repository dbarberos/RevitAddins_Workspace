# Walkthrough: TransferPlus v1.2.0 Release, Monorepo Versioning & Documentation Update

**Date:** 2026-09-11  
**Author:** DBDev_dbarberos  
**Company:** DBDev Solutions  
**Add-in:** TransferPlus  
**Version:** 1.2.0  
**Add-in GUID:** `D1981E8C-1951-45C0-B24C-CA821B7288D2`

---

## 1. Executive Summary

This walkthrough details the release of **TransferPlus v1.2.0**, introducing the dedicated **CAD Details & 2D Drafting Views Transfer Mode**, dynamic vector previews, Title Block in-memory rendering, middle column unconstrained horizontal scrolling, and migrating TransferPlus to the new **Monorepo Versioning and Tag Traceability** standard established in `.agents/skills/revit-addin-doc-manager` and `.agents/skills/revit-appstore-bundle`.

---

## 2. Monorepo Versioning Implementation

In alignment with the repository standard for multi-add-in management:
- **Baseline Historical Tagging**: The previous v1.1.0 release commit was tagged as `TransferPlus-v1.1.0` (at commit `9c9ce6a`).
- **Canonical Version Elevation**: In [TransferPlus.csproj](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/TransferPlus.csproj), the assembly version was elevated to:
  ```xml
  <Version>1.2.0</Version>
  ```
- **Scoped Git Tag**: Tag `TransferPlus-v1.2.0` is registered for git history tracking and isolated changelog generation:
  ```powershell
  git tag -a TransferPlus-v1.2.0 -m "Release TransferPlus v1.2.0: CAD Details transfer mode, dynamic 2D vector preview, title block rendering, and auto-crop extents"
  ```
- **Changelog Extraction**: Can be inspected independently using path filtering:
  ```powershell
  git log TransferPlus-v1.1.0..TransferPlus-v1.2.0 --oneline -- TransferPlus/
  ```

---

## 3. Documentation Synchronized

All documentation was updated in English following the Autodesk App Store and `revit-addin-doc-manager` guidelines:

### A. Main User Guide ([TransferPlus/docs/User_Guide.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/docs/User_Guide.md))
- **Header & Version**: Updated to `v1.2.0`.
- **Section 5.8 (CAD Details & 2D Drafting Views Transfer Mode)**: Added comprehensive description covering:
  - 5 origin categories: CAD Formats (DWG, DXF, DGN, SAT), Drafting Views, Detail Views/Callouts, Detail Groups, and Detail Items.
  - Real-time 2D vector preview (200x200 px) using scratch drafting views and transaction rollback.
  - Smart zoom-to-extents and auto-crop margin calculations.
  - Dynamic Title Block rendering via in-memory family editing.
  - Middle column dedicated horizontal scrollbar with fixed checkboxes and count badges.
- **Section 6 (Changelog)**: Prepended `### v1.2.0 - 2026-09-11` (Added, Changed, Fixed) while strictly preserving `v1.1.0` and `v1.0.0` history.

### B. Revit F1 Contextual Help ([TransferPlus/Resources/help.html](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Resources/help.html))
- **Badge**: Updated to `<span class="badge">Version 1.2.0</span>`.
- **Section 5.8**: Injected matching HTML structure and styling for CAD Details transfer mode.
- **Changelog**: Injected `<h3>v1.2.0</h3>` with structured unordered lists mirroring the user guide.

---

## 4. Multi-Version Compilation & App Store Packaging

### A. Multi-Version Compilation
TransferPlus was built in `Release` mode across its supported Revit versions:
- `Release.R24` (.NET Framework 4.8) -> `TransferPlus/bin/Release R24/`
- `Release.R25` (.NET 8) -> `TransferPlus/bin/Release R25/`
- `Release.R26` (.NET 8) -> `TransferPlus/bin/Release R26/`
- `Release.R27` (.NET 8) -> `TransferPlus/bin/Release R27/`

### B. Automated Bundle Generation via `build-bundle.ps1`
The updated build script dynamically extracted version `1.2.0` from `TransferPlus.csproj` and packaged:
- [PackageContents.xml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Deploy/TransferPlus.bundle/PackageContents.xml) with `AppVersion="1.2.0"`.
- Cleaned and organized archive:
  - [TransferPlus/Deploy/Archive/](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Deploy/Archive/): Contains archived historical versions `TransferPlus_v1.0.0.zip` and `TransferPlus_v1.1.0.zip`.
- Production bundle zip:
  - [TransferPlus/Deploy/TransferPlus_v1.2.0.zip](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Deploy/TransferPlus_v1.2.0.zip) (22.8 MB).
- Autodesk App Store distribution package:
  - [TransferPlus/TransferPlusPublishPackage/TransferPlus.bundle.zip](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/TransferPlusPublishPackage/TransferPlus.bundle.zip) (22.8 MB).

---

## 5. Verification & Git State

1. **Tag Verification**:
   - `TransferPlus-v1.1.0`: Verified historical baseline on commit `9c9ce6a`.
   - `TransferPlus-v1.2.0`: Verified new release tag pointing to the current release commit.
2. **File Integrity**:
   - `User_Guide.md` and `help.html` reflect v1.2.0 in English with DBDev branding.
   - Bundle package `TransferPlus.bundle.zip` contains verified DLLs and `.addin` manifests for Revit 2024, 2025, 2026, and 2027.
