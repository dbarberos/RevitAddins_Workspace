---
name: revit-addin-installer-manager
description: Automates the creation of professional MSI installers for multi-version Revit Add-ins (2023-2027) using WiX Toolset v3.11+. Use this when preparing a deployment package, updating installer versions, or generating WXS scripts.
---

# Revit Add-in Installer Manager (WiX Toolset Automation)

This skill guides the agent in automating the creation of professional `.msi` installers for multi-version Revit add-ins, managing the packaging of resources robustly and independently of Visual Studio.

## 🚨 Mandatory Critical Rules
1. **Developer Identity:** When generating Wix templates (`.wxs`), `PackageContents.xml` files, or any installer documentation, the agent MUST strictly use `DBDev_dbarberos` as the Author/Manufacturer/Developer Name and `DBDev Solutions` as the Company Name. The use of generic AI placeholders like "AI_Corp" or "AI Solutions" is strictly forbidden.
2. **Version-Naming and Archiving:** All compiled `.msi` installers MUST include the add-in version in their file name, formatted as `[AppName]_v[Version].msi`. During the build process, the agent MUST automatically identify any pre-existing/older `.msi` or `.zip` installer files and move them into a dedicated `Archive/` subdirectory (e.g., `Deploy/Archive/`) to preserve historical accessibility and prevent overwrites.

## 📚 Technical References (Knowledge Base)
To obtain theoretical specifications and Windows Installer validation guides, consult the files in the `references/` folder:

*   `references/wix_toolset_architecture.md`: Explanation of how it is possible to create `.msi` files and compile C# projects without using Visual Studio (demystifying the role of the IDE and enabling CI/CD flows).
*   `references/wxs_golden_rules.md`: Mandatory golden rules for writing robust `.wxs` XML files, preventing Windows Installer validation errors (ICE38 and ICE64) in AppData installations.

## 📦 Assets (Templates and Installer Configuration Examples)
The following files are located in the `assets/` folder and can be injected or used as a guide in projects:

*   `assets/ProductTemplate.wxs`: Structured base XML template for packaging multi-version add-ins (Revit 2024 and 2025) with cleanup components and unique IDs.
*   `assets/LicenseTemplate.rtf`: Base file in Rich Text Format (RTF) for the End-User License Agreement (EULA) displayed in the installer interface.
*   `assets/build-msi.ps1`: Automated PowerShell script to compile the WiX installer, output version-named MSI files, clean intermediate outputs, and archive older builds automatically.