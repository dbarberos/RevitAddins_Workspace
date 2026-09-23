# Walkthrough: TablePlus Multi-Version Support (2024–2027) & Autodesk App Store Bundle

This walkthrough summarizes the implementation of full multi-version compatibility (**Autodesk Revit 2024, 2025, 2026, and 2027**) and the generation of the standardized Autodesk App Store bundle for the `TablePlus` add-in, following the standards from `FilterPlus` and `TransferPlus`.

---

## 1. Key Accomplishments

### A. Multi-Version Project Configuration (`TablePlus.csproj`)
- Configured target configurations strictly for Revit **2024, 2025, 2026, and 2027**:
  - `Debug.R24`, `Debug.R25`, `Debug.R26`, `Debug.R27`
  - `Release.R24`, `Release.R25`, `Release.R26`, `Release.R27`
- Injected `<DefaultItemExcludes>$(DefaultItemExcludes);Deploy\**;TablePlusPublishPackage\**</DefaultItemExcludes>` to protect MSBuild from recursive package scanning and BAML resource conflicts.
- Conditioned `System.Text.Json` to `.NETFramework` (Revit 2024) to eliminate .NET 9 package pruning warnings (`NU1510`).

### B. Build Orchestrators & Automation
- **Dedicated Script**: Created `TablePlus/build-and-pack.ps1` for local developer builds (interactive menu for Production vs Debug).
- **Workspace Script Modernization**: Enhanced root `build-and-pack.ps1` to dynamically resolve target project directory and clean `bin`/`obj` cleanly without hardcoding.
- **Bundle Packaging Automation**: Executed `build-bundle.ps1` from `revit-appstore-bundle` targeting `@('2024', '2025', '2026', '2027')`.

### C. Autodesk App Store Package & Metadata
- **Store Help & Icons**: Created `TablePlus/Resources/help.html`, `TablePlus/Resources/Icon16.png`, and `TablePlus/Resources/Icon32.png`.
- **Publish Package**: Created full metadata suite in `TablePlus/TablePlusPublishPackage/`:
  - `AppDescription.md`: Comprehensive description formatted for the Autodesk App Store developer portal.
  - `DigitalSignatureInfo.md`: Authenticode instructions for code signing.
  - `PrivacyPolicy.md`: Formal zero-telemetry / local processing privacy statement.
  - `Steps.md`: Publishing checklist for developer upload.
  - `WebsiteInfo.txt`: Official DBDev publisher information.

### D. Autodesk Autoloader Bundle Verification
- Generated `TablePlus.bundle` in both `TablePlus/Deploy/` and `TablePlus/TablePlusPublishPackage/`.
- Generated compressed archives:
  - `TablePlus/Deploy/TablePlus_v1.0.0.zip` (12.7 MB)
  - `TablePlus/TablePlusPublishPackage/TablePlus.bundle.zip` (12.7 MB)
- Verified `PackageContents.xml`:
  - XML declaration: `<?xml version="1.0" encoding="utf-8"?>`.
  - Autoloader Series with `"R"` prefix: `SeriesMin="R2024" SeriesMax="R2024"`, `R2025`, `R2026`, `R2027`.
  - Author and Vendor: `DBDev_dbarberos` / `DBDev Solutions` / `dbarberos@outlook.com`.
  - ProductCode GUID: `A9D54A27-714C-44FD-8B29-E3DE95F0D759`.
  - Full dependency bundling: Every version subfolder (`Contents/2024`, `Contents/2025`, `Contents/2026`, `Contents/2027`) contains `TablePlus.dll`, `ClosedXML.dll`, `DocumentFormat.OpenXml.dll`, `ExcelNumberFormat.dll`, `SixLabors.Fonts.dll`, `CommunityToolkit.Mvvm.dll`, `Nice3point.Revit.*.dll`, `TablePlus.addin`, and contextual `Resources/help.html`.

### E. Constitution & User Documentation Updates
- Updated `TablePlus/docs/constitution.md` with **Section 4.6 (Multi-Version Architecture & App Store Packaging)** and Prohibited Patterns.
- Created `TablePlus/docs/User_Guide.md` providing end-user documentation, command mapping, vector import workflows, and build orchestration guides.

---

## 2. Verification Results

| Verification Item | Command / Check | Result |
|---|---|---|
| **Compilation R24** (.NET 4.8) | `dotnet publish TablePlus\TablePlus.csproj -c Release.R24 /p:DeployAddin=false` | **PASSED** (0 errors, 0 warnings) |
| **Compilation R25** (.NET 8.0) | `dotnet publish TablePlus\TablePlus.csproj -c Release.R25 /p:DeployAddin=false` | **PASSED** (0 errors, 0 warnings) |
| **Compilation R26** (.NET 8.0) | `dotnet publish TablePlus\TablePlus.csproj -c Release.R26 /p:DeployAddin=false` | **PASSED** (0 errors, 0 warnings) |
| **Compilation R27** (.NET 9.0) | `dotnet publish TablePlus\TablePlus.csproj -c Release.R27 /p:DeployAddin=false` | **PASSED** (0 errors, 0 warnings) |
| **Autodesk App Store Bundle** | `build-bundle.ps1 -TargetYears @('2024','2025','2026','2027')` | **PASSED** (All 4 versions packed) |
| **Autoloader Prefix Check** | Check `SeriesMin`/`SeriesMax` in `PackageContents.xml` | **PASSED** (`R2024`, `R2025`, `R2026`, `R2027`) |
| **Full Dependency Bundling** | Check DLLs in `Contents/2024/`, `2025/`, `2026/`, `2027/` | **PASSED** (All ClosedXML & Nice3point DLLs present) |
| **Archive Integrity** | Verify zip files in `Deploy/` & `TablePlusPublishPackage/` | **PASSED** (12.7 MB archives generated) |

---

## 3. Artifact Traceability Record

Pursuant to the workspace SDD traceability protocol, the corresponding implementation plan and walkthrough are preserved in:
- `TablePlus/docs/references/implementation_plan_20260923_multiversion_and_bundle_packaging.md`
- `TablePlus/docs/references/walkthrough_20260923_multiversion_and_bundle_packaging.md`
