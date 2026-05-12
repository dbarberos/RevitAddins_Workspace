# User Guide - FilterPlus

**Current Version:** 1.1.0
**Developer:** DBDev / dbase_Architecture

---

## 1. General Description
**FilterPlus** is an advanced add-in for Autodesk® Revit® designed to streamline the selection and filtering of elements in complex BIM projects. It offers **full hierarchical navigation** (All > Category > Family > Type > Element ID) and a dynamic organization system that allows you to restructure the selection tree based on your specific project needs.

## 2. Installation Instructions
The add-in is distributed in the official Autodesk App Store format (Autoloader).

1.  Close all active Revit sessions.
2.  Install the package provided by the App Store.
3.  When opening Revit, if a security warning appears, select **"Always Load"**.

> [!NOTE]
> The installation is performed in the user profile (`%AppData%\Autodesk\ApplicationPlugins`), which does not require administrator privileges for most users.

## 3. Command and Feature Guide

### 3.1. Advanced Hierarchical Explorer
The main interface allows granular element selection through a 5-level tree.
- **Semantic Depth Memory**: The explorer remembers your visual expansion level even when changing the sorting or organization criteria.
- **Multi-Selection**: Intelligent checkboxes that manage indeterminate states in parent folders for partial selections.

### 3.2. Dynamic Organization (Switches)
You can instantly reorganize the project hierarchy using the side switches:
- **Sort by Phase**: Groups elements by their creation phase.
- **Sort by Level**: Organizes the hierarchy based on the associated Revit level.
- **Sort by Workset**: Essential for collaborative projects and worksharing coordination.

### 3.3. Intelligent Search Engine
- **Regex Support**: Advanced search using Regular Expressions.
- **Logical OR**: Allows accumulating selection results from multiple consecutive searches.
- **Name-Only Filter**: An option to limit the search only to the type/family name for maximum speed in massive models.

### 3.4. Contextual Menu (Revit 2025+)
Native integration into the right-click menu to filter existing selections instantly.

## 4. System Requirements

| Requirement | Detail |
| :--- | :--- |
| **Revit Versions** | 2023, 2024, 2025, 2026, 2027 |
| **Operating System** | Windows 10 / 11 (64-bit) |
| **Framework** | .NET Framework 4.8 / .NET 8.0 (depending on Revit version) |

> [!WARNING]
> For Revit 2025 and higher, the add-in requires the .NET 8 runtime environment to be installed.

## 5. Version History (Changelog)

### [1.1.0] - 2026-05-08
#### Added
- **Full Hierarchy**: Implementation of the 5-level TreeView (Category > Family > Type > Element).
- **Dynamic Sorting**: New organization modes for Phase, Level, and Workset.
- **Advanced Search Engine**: Support for Regex, logical OR, and "Only by Name" mode.
- **Semantic Depth Memory**: Logic to preserve user expansion depth during reorganizations.
- **UI Optimization**: Minimalist redesign with vector icons and automatic scaling for 1080p and 4K displays.

#### Fixed
- **WPF Virtualization**: Resolved the tree view state corruption bug by switching to `VirtualizationMode="Standard"`.
- **Thread Safety**: Improved stability of Revit API calls from background threads during bulk selection processes.

### [1.0.0] - 2026-04-29
#### Added
- **MSI Installer**: Automated multi-version support (2023-2027).
- **Security Hardening**: Protection against XXE attacks and path validation.
- **Error Logging**: Centralized logging system (`LoggerService`).

---
*For technical support, contact: dbarberos@outlook.com*

