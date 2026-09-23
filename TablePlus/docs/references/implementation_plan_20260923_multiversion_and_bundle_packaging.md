# Implementation Plan: TablePlus Multi-Version Support (2024–2027) & Autodesk App Store Bundle

This plan establishes multi-version support covering Autodesk Revit **2024, 2025, 2026, and 2027** for the `TablePlus` add-in, generating all compilation configurations, orchestrator scripts, publish metadata, and the complete Autodesk App Store bundle (`.bundle` and `.zip`), mirroring the structure in `FilterPlus` and `TransferPlus`.

## User Review Required

> [!NOTE]
> Following user instructions, the supported versions are strictly **2024 through 2027** (Revit 2024, 2025, 2026, 2027). Revit 2023 is excluded as requested.

## Proposed Changes

### 1. Project Configuration & Compilation Setup

#### [MODIFY] [TablePlus.csproj](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/TablePlus.csproj)
- Set `<Configurations>` strictly to `Debug.R24;Debug.R25;Debug.R26;Debug.R27` and `Release.R24;Release.R25;Release.R26;Release.R27`.
- Add `<DefaultItemExcludes>$(DefaultItemExcludes);Deploy\**;TablePlusPublishPackage\**</DefaultItemExcludes>`.
- Add `<PropertyGroup Condition="$(Configuration.StartsWith('Debug'))"><DefineConstants>$(DefineConstants);DEBUG</DefineConstants></PropertyGroup>`.
- Add condition to `System.Text.Json` for `.NETFramework` to eliminate NU1510 warnings in .NET 9.

#### [NEW] [TablePlus/build-and-pack.ps1](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/build-and-pack.ps1)
- Dedicated local pipeline orchestrator for TablePlus providing interactive/automated menu for Production (Release + Obfuscar) vs Development (Debug + PDB symbols), package restore, build, and packaging.

#### [MODIFY] [build-and-pack.ps1](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/build-and-pack.ps1)
- Update root script to dynamically handle any add-in (`TablePlus`, `FilterPlus`, `TransferPlus`) cleanly via the `$SolutionName` parameter without hardcoded `FilterPlus` folder cleanup.

---

### 2. Resources & Help Documentation

#### [NEW] [TablePlus/Resources/Icon16.png](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/Resources/Icon16.png)
#### [NEW] [TablePlus/Resources/Icon32.png](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/Resources/Icon32.png)
- Standardized icons placed at the root of `Resources/` for the Autodesk App Store bundle builder.

#### [NEW] [TablePlus/Resources/help.html](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/Resources/help.html)
- Standalone HTML help documentation detailing overview, requirements & compatibility (Revit 2024–2027), installation/uninstallation, ribbon commands, Excel vector import guide, Extensible Storage schema, and support info.

---

### 3. Autodesk App Store Publish Package Metadata

#### [NEW] [TablePlus/TablePlusPublishPackage/AppDescription.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/TablePlusPublishPackage/AppDescription.md)
#### [NEW] [TablePlus/TablePlusPublishPackage/DigitalSignatureInfo.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/TablePlusPublishPackage/DigitalSignatureInfo.md)
#### [NEW] [TablePlus/TablePlusPublishPackage/PrivacyPolicy.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/TablePlusPublishPackage/PrivacyPolicy.md)
#### [NEW] [TablePlus/TablePlusPublishPackage/Steps.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/TablePlusPublishPackage/Steps.md)
#### [NEW] [TablePlus/TablePlusPublishPackage/WebsiteInfo.txt](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/TablePlusPublishPackage/WebsiteInfo.txt)
- Complete suite of metadata, publishing instructions, privacy policy, and store descriptions aligned with Autodesk Developer Portal guidelines.

---

### 4. Compilation & Bundle Generation (2024–2027)

- Run `dotnet publish` for all 4 configurations:
  - `Release.R24` (.NET Framework 4.8)
  - `Release.R25` (.NET 8.0)
  - `Release.R26` (.NET 8.0)
  - `Release.R27` (.NET 9.0)
- Execute `.\.agents\skills\revit-appstore-bundle\scripts\build-bundle.ps1 -AppName "TablePlus" -Version "1.0.0" -ProjectDir ".\TablePlus" -TargetYears @("2024", "2025", "2026", "2027")`.
- Verify generated bundle structures:
  - `TablePlus/Deploy/TablePlus.bundle/`
  - `TablePlus/Deploy/TablePlus_v1.0.0.zip`
  - `TablePlus/TablePlusPublishPackage/TablePlus.bundle/`
  - `TablePlus/TablePlusPublishPackage/TablePlus.bundle.zip`
  - `PackageContents.xml` with `SeriesMin="R2024"` and `SeriesMax="R2027"`.
  - All dependency DLLs bundled in each version subfolder (`2024`, `2025`, `2026`, `2027`).

---

### 5. Add-in Master Plan, Constitution & User Guide Updates

#### [MODIFY] [TablePlus/docs/constitution.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/docs/constitution.md)
- Add Section 4.6: Multi-Version Architecture & App Store Delivery (Revit 2024–2027, Autoloader `"R"` prefix, dependency isolation, and obfuscation targets).

#### [NEW] [TablePlus/docs/User_Guide.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/docs/User_Guide.md)
- Comprehensive Markdown user guide for TablePlus v1.0.0 documenting features, multi-version architecture, and bundle distribution.

#### [MODIFY] [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md)
- Ensure TablePlus multi-version scope (2024–2027) is recognized in workspace rules.

## Verification Plan

### Automated Build Verification
1. Run `dotnet build TablePlus\TablePlus.csproj -c Release.R24 /p:DeployAddin=false` -> 0 errors.
2. Run `dotnet build TablePlus\TablePlus.csproj -c Release.R25 /p:DeployAddin=false` -> 0 errors.
3. Run `dotnet build TablePlus\TablePlus.csproj -c Release.R26 /p:DeployAddin=false` -> 0 errors.
4. Run `dotnet build TablePlus\TablePlus.csproj -c Release.R27 /p:DeployAddin=false` -> 0 errors.
5. Run bundle packaging script and verify:
   - `PackageContents.xml` XML validation and `SeriesMin="R2024" SeriesMax="R2027"`.
   - Check that `Contents/2024`, `Contents/2025`, `Contents/2026`, `Contents/2027` each contain `TablePlus.dll`, `ClosedXML.dll`, `TablePlus.addin`, and `Resources/help.html`.
   - Check that `.zip` archives exist in `Deploy/` and `TablePlusPublishPackage/`.
