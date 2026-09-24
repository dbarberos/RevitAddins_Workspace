# TablePlus

**TablePlus** is an enterprise-grade Autodesk Revit add-in designed as a comprehensive tabular and spreadsheet management suite. It allows BIM managers, architects, structural engineers, and MEP designers to seamlessly import, manage, and synchronize Microsoft Excel spreadsheets (`.xlsx`, `.xlsm`, `.csv`) directly into Autodesk Revit as native vector **Drafting Views** or **Legend Views** with complete typographic and geometric fidelity.

---

## Requirements and Compatibility

* **Platform**: .NET Framework 4.8 (Revit 2024) / .NET 8.0 (Revit 2025, 2026, 2027).
* **Supported Revit Versions**: 2024, 2025, 2026, 2027 (Win64).
* **Zero Microsoft Office Dependency**: TablePlus does not require Microsoft Office or Excel to be installed. Operations are powered by high-performance managed OpenXML libraries.

---

## Installation & Uninstallation

### Installation
The installer that ran when you downloaded this plug-in from the Autodesk App Store has already installed the plug-in. You may need to restart the Autodesk product to activate the plug-in.

### Uninstallation
To uninstall this plug-in, exit the Autodesk product if you are currently running it, simply rerun the installer by downloading it again from the Autodesk App Store, and select the 'Uninstall' button, or you can uninstall it from 'Control Panel\Programs\Programs and Features' (Windows 10/11), just as you would uninstall any other application from your system.

---

## Commands and Features Guide

### Ribbon Panel Integration
The add-in creates a dedicated tool panel under Revit's standard **Add-Ins / Complementos** tab, complying with Autodesk App Store single-command requirements:

| Command | Function | Technical Class |
|---------|----------|-----------------|
| **TablePlus Dashboard** | Opens the Master Table Dashboard to inspect, filter, synchronize, format, and add tables in the Revit model. | `TablePlus.Commands.CmdImportTable` |

---

## Key Features & Comprehensive Usage Guide

### 1. Master Table Dashboard
- **Upper Action Cards**: Direct buttons for `+ Add Table`, `🔄 Sync Selected`, `👁️ Open View` (activates view in Revit), and `🗑️ Delete / Unlink`.
- **Live Search & Multidimensional Filters**: Instantly search by view name or source file, with dropdown filters for View Types (*All, Drafting, Legend*) and Status (*All, Up to Date, Modified, File Missing*).
- **Virtualized DataGrid (11 Columns)**: High-performance table inventory displaying selection checkboxes, source badges (`XLSX`, `CSV`), chromatic sync status badges, view names (double-click to navigate), view types, scales, source files, interactive worksheet selectors, auto-sync checkboxes, monochrome B&W checkboxes, and style design launchers.

### 2. Table Graphic & Header Design Window
- **Gridline Styles**: Select any project Line Style from `BuiltInCategory.OST_Lines` for exterior borders and interior gridlines.
- **Body Cell Typography**: Choose the Revit `TextNoteType` assigned to standard data cells.
- **Header Row Overrides**: Apply custom header `TextNoteType`, font colors, and background shading with 10 architectural preset swatches and live mini-preview.

### 3. In-Place Non-Destructive Synchronization
- Re-reads modified source files and updates existing Revit views in place without deleting them, keeping all sheet viewports and title blocks intact.

### 4. Background Auto-Synchronization
- Check the **Auto-Sync** box for any critical table. Every time a user opens the Revit project, TablePlus quietly inspects the source spreadsheet and updates the table silently if modified.

### 5. Monochrome Black & White (B&W) Mode
- Strip all background fills and force solid black lines and text notes with a single checkbox toggle.

---

## Version History (Changelog)

### v1.1.0 - 2026-09-23
- Added Master Table Dashboard with FilterPlus card layout and 11-column virtualized DataGrid.
- Added Table Graphic & Header Design modal dialog (`TableStyleMappingView`).
- Added in-place non-destructive view updates (`UpdateTableInView`).
- Added background auto-synchronization on project open (`DocumentOpened`).
- Added multi-criteria search and filter engine with double-click view navigation.

### v1.0.0 - 2026-09-23
- Initial release with closed-XML vector table import, detail curves, text notes, filled regions, and multi-version bundle packaging for Revit 2024–2027.

---

## Support and Contact

* **Developer**: DBDev_dbarberos
* **Company**: DBDev Solutions
* **Support Email**: [dbarberos@outlook.com](mailto:dbarberos@outlook.com)
* **Website**: [https://dbdev-dbarberos.github.io](https://dbdev-dbarberos.github.io)
* **Privacy Policy**: [https://dbdev-dbarberos.github.io/PrivacyPolicy/](https://dbdev-dbarberos.github.io/PrivacyPolicy/)
