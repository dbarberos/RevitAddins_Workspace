# Packaging and Deployment Walkthrough: FilterPlus

This document outlines the final packaging, compilation, and deployment pipeline implemented for the FilterPlus Revit Add-in (v1.6.0).

---

## 🏗️ Deployment Pipeline Overview

To ensure full traceability and ease of deployment, the packaging pipeline is automated through two specialized PowerShell scripts under the project root:

1.  **Version Synchronization (`sync-version.ps1`)**:
    *   Reads the `**Current Version:**` token from [User_Guide.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/docs/User_Guide.md).
    *   Updates version properties synchronously in [FilterPlus.csproj](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/FilterPlus.csproj), WiX [Product.wxs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Installer/Product.wxs), and App Store bundle `PackageContents.xml`.
2.  **App Store Bundle Packaging (`build-bundle.ps1`)**:
    *   Collects compiled multi-version DLL and `.addin` manifests from output folders.
    *   Copies the F1 contextual help [help.html](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Resources/help.html) to the bundle resources folder.
    *   Generates a standardized `.zip` archive named `[AppName]_v[Version].zip` for the Autodesk Developer Portal (excluding `PackageContents.xml` inside the zip per store specifications).
3.  **MSI Installer Packaging (`build-msi.ps1`)**:
    *   Compiles `Product.wxs` with WiX `candle.exe`.
    *   Links the object file with WiX `light.exe` to generate the installer.
    *   Names the output using the version pattern: `[AppName]_v[Version].msi`.
    *   Cleans intermediate build files automatically.

---

## 🗃️ Version-Naming and Archiving Policy

To prevent overwriting older builds and allow easy restoration of previous iterations, both scripts automatically enforce an **archiving policy**:

*   **Output folder**: All production-ready deployment packages (`.msi` and `.zip` files) are placed in the `FilterPlus/Deploy/` folder.
*   **Versioned names**:
    *   MSI: `FilterPlus_v1.6.0.msi`
    *   App Store ZIP: `FilterPlus_v1.6.0.zip`
*   **Automatic Archiving**: Prior to compiling a new installer or creating a new zip, the scripts scan `FilterPlus/Deploy/` for any existing versioned files (`FilterPlus_v*.msi` and `FilterPlus_v*.zip`) and move them to `FilterPlus/Deploy/Archive/`.

---

## 🛠️ Step-by-Step Generation Guide

Follow these sequential steps in PowerShell to generate a new final release build:

### Step 1: Compile Final Release Binaries
Compile the project for all target Revit versions in Release mode to ensure there are no debug components left:
```powershell
dotnet publish -c Release.R23
dotnet publish -c Release.R24
dotnet publish -c Release.R25
dotnet publish -c Release.R26
dotnet publish -c Release.R27
```

### Step 2: Generate MSI Installer (Per-User Deployments)
Execute the installer build script. It automatically triggers `sync-version.ps1`, archives older MSIs to the `Archive/` folder, compiles the WiX code, and outputs a versioned installer:
```powershell
powershell -ExecutionPolicy Bypass -File FilterPlus/Installer/build-msi.ps1
```
*   **Output**: [FilterPlus_v1.6.0.msi](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Deploy/FilterPlus_v1.6.0.msi)
*   **Archived files**: [Deploy/Archive/](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Deploy/Archive/)

### Step 3: Generate Autodesk App Store Bundle
Execute the bundle script to assemble the version folders, copy contextual help files, and build the `.zip` archive:
```powershell
powershell -ExecutionPolicy Bypass -File .agents/skills/revit-appstore-bundle/scripts/build-bundle.ps1 -AppName "FilterPlus" -Version "1.6.0" -Author "DBDev_dbarberos" -Email "dbarberos@outlook.com" -ProjectDir "FilterPlus"
```
*   **Output**: [FilterPlus_v1.6.0.zip](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Deploy/FilterPlus_v1.6.0.zip)

---

## 📚 Global Skill Reference (For future add-ins)

This packaging and archiving workflow is codified in the following repository skills so that any newly created add-in adopts the same standard:
*   [revit-addin-installer-manager/SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-installer-manager/SKILL.md)
*   [revit-appstore-bundle/SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-appstore-bundle/SKILL.md)
