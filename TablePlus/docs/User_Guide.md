# TablePlus

> **Current Version:** v1.0.0  
> **Add-in ID (GUID):** `C9281744-8B1A-4C23-9D01-B719E022F3AA`  

---

## 1. Overview

**TablePlus** is an enterprise-grade tabular and spreadsheet management suite for Autodesk Revit. Designed to overcome the limitations of bitmap/raster imports and native schedule presentation constraints, TablePlus enables high-fidelity vector importing of Microsoft Excel spreadsheets (`.xlsx`, `.xlsm`, `.csv`) into native Revit **Drafting Views** and **Legend Views**.

Unlike pixelated images, TablePlus generates clean, scale-independent parametric vector geometry:
- Native closed **Detail Lines** with matched line weights and styles.
- Solid **Filled Regions** reproducing cell background colors.
- Precision **Text Note** elements inheriting typography (font family, weight, style, color, alignment).
- Robust **Merged Cell** reconciliation with unified boundary polygons and centered text.
- Integrated **Extensible Storage** schema tracking for automated table updates and lifecycle management.

---

## 2. Requirements and Compatibility

> [!WARNING]
> This add-in is compiled for multiple versions using the `Debug.R[XX]` and `Release.R[XX]` configurations.

* **Platform**: .NET Framework 4.8 (Revit 2024) / .NET 8.0 (Revit 2025, 2026, 2027).
* **Supported Revit Versions**: 2024, 2025, 2026, 2027 (Win64).
* **Microsoft Office Dependency**: Zero. Operates completely through managed OpenXML libraries (`ClosedXML`).

---

## 3. Installation & Uninstallation

The installer that ran when you downloaded this plug-in from the Autodesk App Store has already installed the plug-in. You may need to restart the Autodesk product to activate the plug-in.

To uninstall this plug-in, exit the Autodesk product if you are currently running it, simply rerun the installer by downloading it again from the Autodesk App Store, and select the 'Uninstall' button, or you can uninstall it from 'Control Panel\Programs\Programs and Features' (Windows 10/11), just as you would uninstall any other application from your system.

---

## 4. Commands and Features Guide

### 4.1. Ribbon Panel Integration
The add-in creates a custom ribbon panel under the **DBDev Tools** tab (or native **Add-Ins** tab):

| Command | Function | Technical Class |
|---------|----------|-----------------|
| **Import Table** | Opens the interactive Excel Vector Table Import dialog to select workbooks, sheets, ranges, target views, and styling options. | `TablePlus.Commands.CmdImportTable` |

---

## 5. Comprehensive Usage Guide

### 5.1. Excel File and Worksheet Selection
1. Click **Import Table** on the ribbon.
2. In the **Excel Source File** card, click **Browse...** to select your `.xlsx`, `.xlsm`, or `.csv` spreadsheet.
3. TablePlus automatically inspects the workbook structure and populates the **Worksheet** dropdown.
4. Select the target worksheet. The **Cell Range** field auto-populates with the active range (e.g. `A1:G35`). You can modify this range address manually as needed.

### 5.2. View Type & Placement Options
In the **Target View Configuration** card:
- **New Drafting View**: Creates a new, isolated drafting view (e.g., `Table_Notes_20260923`).
- **Existing Drafting View**: Inserts the table directly into the active drafting view.
- **Legend View**: Creates a legend view allowing identical table graphics to be placed across multiple sheets simultaneously.
- **Scale**: Configures view scale (default 1:1 for true tabular dimensions).

### 5.3. Vector Rendering Engine
During generation:
- Grid lines are drawn using native Revit Detail Lines (`DetailCurve`).
- Cells with background fill colors are rendered using solid `FilledRegion` instances.
- Merged cell ranges are merged into unified outer boundary polygons.
- Text notes are placed at computed physical cell coordinates with exact typographic matching (Font, Size, Bold, Italic, Color, Horizontal/Vertical alignment).
- A non-intrusive `WarningSwallower` (`IFailuresPreprocessor`) catches and dismisses non-fatal geometry warnings silently.

### 5.4. Extensible Storage Metadata Tracking
Every view created by TablePlus is stamped with the `TablePlus` schema (GUID: `E3B21D40-6C9A-4E2F-8A11-92D0543B7A1C`) storing:
- `SourceFilePath`: Absolute path to the source spreadsheet.
- `SheetName`: Source worksheet name.
- `RangeAddress`: Imported cell range address.
- `LastImportTimestampUtc`: Timestamp of import.
- `UpdateBehavior`: Active reload strategy.

---

## 6. Multi-Version Architecture & Build Orchestration

### 6.1. Build Configurations
The add-in supports 4 Autodesk Revit targets:
- `Release.R24` / `Debug.R24` (Revit 2024 - .NET Framework 4.8)
- `Release.R25` / `Debug.R25` (Revit 2025 - .NET 8.0)
- `Release.R26` / `Debug.R26` (Revit 2026 - .NET 8.0)
- `Release.R27` / `Debug.R27` (Revit 2027 - .NET 9.0)

### 6.2. Autodesk App Store Bundle Packaging
The automated build script packages all versions into a unified `.bundle`:
```powershell
powershell -ExecutionPolicy Bypass -Command "& .\.agents\skills\revit-appstore-bundle\scripts\build-bundle.ps1 -AppName 'TablePlus' -Version '1.0.0' -Author 'DBDev_dbarberos' -Email 'dbarberos@outlook.com' -ProjectDir '.\TablePlus' -TargetYears @('2024', '2025', '2026', '2027')"
```

Output locations:
- `TablePlus/Deploy/TablePlus.bundle/`
- `TablePlus/Deploy/TablePlus_v1.0.0.zip`
- `TablePlus/TablePlusPublishPackage/TablePlus.bundle.zip`

---

## 7. Version History (Changelog)

### v1.0.0 - 2026-09-23
- Initial release featuring ClosedXML vector table import engine.
- Drafting View and Legend View target support.
- Cell border styles, background fill regions, and font formatting.
- Merged cell boundary reconciliation.
- Extensible Storage schema stamping (`E3B21D40-6C9A-4E2F-8A11-92D0543B7A1C`).
- Multi-version compatibility across Revit 2024, 2025, 2026, and 2027.
- Complete Autodesk App Store bundle packaging.

---

## 8. Support and Contact

For bug reports, feature requests, or technical assistance:
* **Developer**: DBDev_dbarberos
* **Company**: DBDev Solutions
* **Website**: https://dbdev-dbarberos.github.io
* **Email**: dbarberos@outlook.com
