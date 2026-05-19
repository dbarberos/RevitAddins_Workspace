# User Guide - FilterPlus

**Current Version:** 1.1.0  
**Developer:** DBDev_dbarberos  

---

## 1. General Description
**FilterPlus** is an advanced add-in for Autodesk Revit designed to streamline element selection and filtering in complex projects. It enables hierarchical navigation (Category > Family > Type > Element) and dynamic filtering that overcomes the limitations of Revit's native selection filter.

---

## 2. Installation Instructions
The add-in is distributed via a professional installer package (MSI).

1.  Close all open Revit sessions.
2.  Run the `FilterPlus.msi` installer.
3.  Follow the steps in the setup wizard.
4.  Upon opening Revit, if a security prompt appears, select **"Always Load"**.

> [!NOTE]
> The add-in is installed in the user profile (`%AppData%\Autodesk\Revit\Addins`), so it does not require administrative privileges for most users.

---

## 3. Commands and Features Guide

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
