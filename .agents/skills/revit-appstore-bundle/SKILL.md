---
name: revit-appstore-bundle
description: Generates the Autodesk App Store .bundle folder structure and PackageContents.xml for Revit addins. Use when preparing a plugin for the Autodesk App Store marketplace.
---

# Revit AppStore Bundle

This skill standardizes and automates the generation of `.bundle` format packages ready to be published on the **Autodesk App Store**.

When Autodesk rejects a custom MSI installer (especially for free Add-ins) or it is required to comply with their standard format, it is necessary to deliver the add-in within a standardized structure known as "Bundle Format" which the Autodesk store then compiles into its own installers.

## Purpose
- Automate the creation of the `[AppName].bundle` folder.
- Generate the required `PackageContents.xml` file, populated with the author's information, supported versions, and Revit loading structure.
- Copy the dynamic libraries (`.dll`) and the manifest (`.addin`) into the version-specific folders (`Contents/2024/`, etc.).
- Compress the structure into a `.zip` file ready to be uploaded to the Autodesk Developer Portal.

## 🚨 Critical Rules for Autodesk App Store
1. **Contextual Help (Mandatory)**: The Ribbon button MUST have a local HTML help file associated with it via `SetContextualHelp`. This file (`help.html`) must be generated from the User Guide and placed in the bundle's `Resources/` folder.
2. **XML Exclusion in ZIP**: Although we generate `PackageContents.xml` for local developer testing, it must **NOT** be included within the final `.zip` file. Autodesk generates this file automatically during the submission process in the store.
3. **Developer Identity**: When generating `PackageContents.xml` files or running scripts, the agent MUST strictly use `DBDev_dbarberos` as the Author/Name and `DBDev Solutions` as the Company Name. The use of generic AI placeholders like "AI_Corp" or "AI Solutions" is strictly forbidden.

## 📦 Assets (Templates and Source Code)
The following files are located in the `assets/` folder:
*   `assets/PackageContents.xml`: Base template of the Bundle manifest describing compatibility, company, and references to load.

## 🛠️ Scripts (Automation)
To execute this skill, use the provided PowerShell script in the `scripts/` folder.

### `scripts/build-bundle.ps1`
**Typical usage:**
```powershell
.\.agents\skills\revit-appstore-bundle\scripts\build-bundle.ps1 -AppName "FilterPlus" -Version "1.1.0" -Author "Your Name" -Email "your@email.com"
```
**Parameters:**
- `-AppName`: The name of the Add-in (and the resulting folder).
- `-Version`: The current version (e.g., `1.0.0`).
- `-Author`: Developer or company name (e.g., `DBDev_dbarberos`).
- `-Email`: Contact email of the developer.

The script will read the local build folders (`bin/Debug.R24`, `bin/Debug.R25`, etc.) and assemble the Bundle with the available versions found, ultimately creating a zip file.
