# User Guide - FilterPlus

**Current Version:** 1.1.0
**Developer:** DBDev / dbase_Architecture

---

## 1. Overview
**FilterPlus** is an advanced add-in for Autodesk Revit designed to streamline element selection and filtering in complex projects. It offers **total hierarchical navigation** (All > Category > Family > Type > Element ID) and a dynamic organization system that allows restructuring the selection tree according to user needs.

## 2. Installation Instructions
The add-in is distributed as a professional Autoloader bundle.

1.  Close all open Revit sessions.
2.  Copy the `FilterPlus.bundle` folder to `%AppData%\Autodesk\ApplicationPlugins\`.
3.  Upon opening Revit, if a security warning appears, select **"Always Load"**.

> [!NOTE]
> Installation is performed in the user profile, so it does not require administrator privileges for most users.

## 3. Command and Feature Guide

### 3.1. Advanced Hierarchical Explorer
The main interface allows for granular element selection through a 5-level tree.
- **Semantic Memory**: The explorer remembers your visual expansion level even when changing organization criteria.
- **Multi-selection**: Intelligent checkboxes manage indeterminate states in parent folders.

### 3.2. Dynamic Organization (Switches)
You can reorganize the project hierarchy instantly using the side switches:
- **Sort by Phase**: Groups elements by creation phase.
- **Sort by Level**: Organizes the hierarchy based on the associated level.
- **Sort by Workset**: Useful for collaborative projects with subprojects.

### 3.3. Intelligent Search Engine
- **Regex Support**: Advanced search using regular expressions.
- **OR Logic**: Allows accumulating selections from multiple consecutive searches.
- **Name Filtering**: Option to limit search only to the type/family name for higher speed.

### 3.4. Contextual Menu (Revit 2025+)
Native integration into the right-click menu to instantly filter existing selections.

## 4. System Requirements

| Requirement | Detail |
| :--- | :--- |
| **Revit Versions** | 2023, 2024, 2025, 2026, 2027 |
| **Operating System** | Windows 10 / 11 (64-bit) |
| **Framework** | .NET Framework 4.8 / .NET 8.0 (depending on Revit version) |

> [!WARNING]
> For Revit 2025 and above, the add-in requires the .NET 8 runtime to be installed.

## 5. Version History (Changelog)

### [1.1.0] - 2026-05-08
#### Added
- **Total Hierarchy**: Implementation of the 5-level TreeView (Category > Family > Type > Element).
- **Dynamic Sorting**: New organization modes by Phase, Level, and Subproject (Workset).
- **Advanced Search Engine**: Support for Regex, OR logic, and "Only by Name" mode.
- **Semantic Depth Memory**: Logic to preserve the user's expansion depth during reorganizations.
- **UI Optimization**: Minimalist redesign with vector icons and automatic dimension adjustment for 1080p screens.

#### Fixed
- **WPF Virtualization**: Fixed TreeView state corruption bug by switching to `VirtualizationMode="Standard"`.
- **Thread Safety**: Improved stability of Revit API calls from background threads in bulk selection processes.

### [1.0.0] - 2026-04-29
#### Added
- **MSI Installer Support**: Automated multi-version support (2023-2027).
- **Security Hardening**: Protection against XXE attacks and path validation.
- **Error Logging**: Centralized error logging system (`LoggerService`).

---
*For technical support, contact: dbarberos@outlook.com*
