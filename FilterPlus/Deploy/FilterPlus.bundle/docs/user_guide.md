# User Guide - FilterPlus

**Current Version:** 1.1.0  
**Developer:** DBDev_dbarberos  
**Publisher Website:** [Autodesk App Store Profile](https://apps.autodesk.com/en/Publisher/PublisherHomepage) *(Publisher profile URL)*  
**Privacy Policy:** [https://dbdev-dbarberos.github.io/PrivacyPolicy/](https://dbdev-dbarberos.github.io/PrivacyPolicy/)  

---

## 1. General Description & App Compatibility
**FilterPlus** is an advanced, high-performance add-in exclusively designed for **Autodesk Revit** *(Please note: The application supports only Autodesk Revit and does not support Autodesk Advance Steel)*. It fundamentally transforms how BIM professionals interact with model elements by providing an advanced hierarchical tree-view explorer that categorizes elements by Category, Family, Type, and Instance.

Unlike Revit's native selection tools which are flat and limited in scope, FilterPlus offers unparalleled depth and flexibility for navigating complex BIM models. Users can dynamically filter elements in real-time using text searches, regular expressions (Regex), and logical operators (AND/OR). It supports semantic grouping by Workset, Phase, and Level, ensuring that large-scale architectural, structural, and MEP models remain entirely navigable and manageable from a single interface.

FilterPlus introduces advanced boolean selection operations that drastically reduce the time spent on mundane tasks. The 'Increase Checked' feature empowers users to expand their current selection based on complex geometric and relational rules. Users can instantly select elements of the same Category, Family, Type, or Workset. It also allows selection based on element hosting relationships (identifying host elements or all elements hosted by the current selection), nested component extraction, and joined geometries. Users can define exactly where to search (the entire model versus the current view) and how to merge the results (adding to the current selection or creating a completely new set). Exclusions can also be dynamically applied to ignore elements belonging to specific Groups or Assemblies.

By centralizing all these operations into a single, responsive, non-modal interface, FilterPlus allows users to keep the tool open while they work, applying filters and selections iteratively. It is fully compatible with Revit 2023, 2024, 2025, 2026, and 2027, featuring native UI integration, including context menu support for newer versions. FilterPlus is the definitive selection utility for BIM Coordinators, Architects, and Engineers looking to optimize their daily workflows, ensure model accuracy, and save hours of manual selection effort in Autodesk Revit.

---

## 2. Privacy Policy & Data Handling
FilterPlus respects user privacy. The application operates entirely locally within the user's desktop environment and Revit instance.
- **Data Collection & Usage:** The App does not collect, transmit, or share any personal data, telemetry, or model information with the Publisher or any third parties. All processing is done locally on the user's machine.
- **Third-Party Sharing:** Since no data is collected, no data is shared with third-party analytics tools, advertising networks, third-party SDKs, or legal affiliates.
- **Data Retention & Deletion:** All user settings and configurations are stored locally on the user's machine (`%AppData%\FilterPlus`). There is no cloud data retention. Users can request deletion of their data by simply uninstalling the application and manually deleting the local `%AppData%\FilterPlus` folder.
- **Consent Revocation:** Users retain full control over their local data and can revoke consent by uninstalling the application.

---

## 3. Installation & Custom Installer Justification
The add-in is distributed via a professional custom MSI installer. 

**Justification for Custom Installer:**
A custom installer is strictly necessary because FilterPlus requires installation across multiple locations to support multiple Revit versions simultaneously (2023, 2024, 2025, 2026, and 2027). The installer must dynamically detect which versions of Revit are present on the user's system and place the appropriate `Addins` manifest and `.dll` payloads into their respective `%AppData%\Autodesk\Revit\Addins\[Version]` directories. Furthermore, the custom installer seamlessly handles the automatic uninstallation of older versions prior to installing new updates, ensuring clean registries and preventing duplicate ribbon icons or API conflicts. 

1.  Close all open Revit sessions.
2.  Run the `FilterPlus.msi` installer. (Requires administration rights to install across all required Revit directories).
3.  Follow the steps in the setup wizard.
4.  Upon opening Revit, if a security prompt appears, select **"Always Load"**.

> [!NOTE]
> Uninstallation completely removes all application files and settings from the system. When a newer version is installed, the installer will automatically remove the older version first.

---

## 4. Commands and Features Guide

### 3.1. Ribbon Panel
The add-in creates a custom tab named **"DBDev"** (configurable) containing the **FilterPlus** panel.

| Command | Function | Technical Class |
| :--- | :--- | :--- |
| **FilterPlus** | Opens the main window for hierarchical selection and filtering. | `FilterPlus.Commands.StartupCommand` |

### 3.2. Context Menu Integration (Revit 2025+)
In Revit 2025 and higher, FilterPlus integrates into the right-click context menu when elements are selected, allowing you to instantly filter the current selection.

---

## 4. System Requirements

| Requirement | Detail |
| :--- | :--- |
| **Supported Revit Versions** | 2023, 2024, 2025, 2026, 2027 |
| **Operating System** | Windows 10 / 11 (64-bit) |
| **Framework** | .NET Framework 4.8 / .NET 8.0 (depending on Revit version) |

> [!WARNING]
> For Revit 2025 and higher, the add-in requires the host environment to have the .NET 8 runtime installed.

---

## 5. Version History (Changelog)

### [1.0.0] - 2026-04-29
#### Added
- **MSI Installer**: Automated multi-version support (Revit 2023-2027).
- **Security Hardening**: Protection against XXE attacks in XML parser and path traversal protection for settings.
- **Error Logging**: Centralized error logging system (`LoggerService`) for ease of tech support.
- **Context Menu**: Contextual right-click integration for Revit 2025+.

#### Fixed
- User settings loading stability.
- Exception management at the add-in startup entry point.

---
*For technical support, contact: dbarberos@outlook.com*
