---
name: revit-addin-installer-manager
description: Automates the creation of professional MSI installers for multi-version Revit Add-ins (2023-2027) using WiX Toolset v3.11+. Use this when preparing a deployment package, updating installer versions, or generating WXS scripts.
---

# Revit Add-in Installer Manager (WiX Toolset Automation)

This skill guides the agent in automating the creation of professional `.msi` installers for multi-version Revit add-ins, managing the packaging of resources robustly and independently of Visual Studio.

## 📚 Technical References (Knowledge Base)
To obtain theoretical specifications and Windows Installer validation guides, consult the files in the `references/` folder:

*   `references/wix_toolset_architecture.md`: Explanation of how it is possible to create `.msi` files and compile C# projects without using Visual Studio (demystifying the role of the IDE and enabling CI/CD flows).
*   `references/wxs_golden_rules.md`: Mandatory golden rules for writing robust `.wxs` XML files, preventing Windows Installer validation errors (ICE38 and ICE64) in AppData installations.

## 📦 Assets (Templates and Installer Configuration Examples)
The following files are located in the `assets/` folder and can be injected or used as a guide in projects:

*   `assets/ProductTemplate.wxs`: Structured base XML template for packaging multi-version add-ins (Revit 2024 and 2025) with cleanup components and unique IDs.
*   `assets/LicenseTemplate.rtf`: Base file in Rich Text Format (RTF) for the End-User License Agreement (EULA) displayed in the installer interface.