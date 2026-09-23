# TablePlus

**TablePlus** is an enterprise-grade Autodesk Revit add-in designed as a comprehensive tabular and spreadsheet management suite. It allows BIM managers, architects, structural engineers, and MEP designers to seamlessly import Microsoft Excel spreadsheets (`.xlsx`, `.xlsm`, `.csv`) directly into Autodesk Revit as native vector **Drafting Views** or **Legend Views** with complete typographic and geometric fidelity.

---

## Requirements and Compatibility

* **Platform**: .NET Framework 4.8 (Revit 2024) / .NET 8.0 (Revit 2025, 2026, 2027).
* **Supported Revit Versions**: 2024, 2025, 2026, 2027 (Win64).
* **Zero Microsoft Office Dependency**: TablePlus does not require Microsoft Office or Excel to be installed. Operations are powered by high-performance managed OpenXML libraries.

---

## Installation & Uninstallation

The installer that ran when you downloaded this plug-in from the Autodesk App Store has already installed the plug-in. You may need to restart the Autodesk product to activate the plug-in.

To uninstall this plug-in, exit the Autodesk product if you are currently running it, simply rerun the installer by downloading it again from the Autodesk App Store, and select the 'Uninstall' button, or you can uninstall it from 'Control Panel\Programs\Programs and Features' (Windows 10/11), just as you would uninstall any other application from your system.

---

## Commands and Features Guide

### Ribbon Panel Integration
The add-in creates a dedicated tool panel under the **DBDev Tools** tab (or Revit's standard **Add-Ins** tab):

| Command | Function | Technical Class |
|---------|----------|-----------------|
| **Import Table** | Opens the interactive Excel Vector Table Import dialog to select workbooks, sheets, ranges, target views, and styling options. | `TablePlus.Commands.CmdImportTable` |

---

## Key Features & Comprehensive Usage Guide

### 1. High-Fidelity Vector Import Engine
- **Parametric Detail Lines**: Cell grid borders are generated as crisp, scale-independent Revit detail lines.
- **Filled Regions for Background Shading**: Cells with fill colors are accurately mapped to solid colored Revit `FilledRegion` types.
- **Merged Cell Support**: Full support for horizontally and vertically merged cell spans with automated boundary merging and text centering.
- **Typographic Precision**: Faithful reproduction of font family, font size, bold, italic, underline, font color, horizontal alignment (Left, Center, Right), and vertical alignment (Top, Middle, Bottom).

### 2. View Destination Options
- **Create New Drafting View**: Generates a dedicated drafting view at 1:1 scale, ready to place directly onto sheets.
- **Target Existing Drafting View**: Places or updates tables within the currently active drafting view.
- **Legend Views**: Generates table graphics as a Legend View to allow placing identical tabular documentation across multiple sheets.

### 3. Extensible Storage Metadata Tracking
- Every generated view is tagged with an Extensible Storage schema storing:
  - Source workbook absolute path.
  - Sheet name and cell range address (e.g. `A1:F20`).
  - UTC timestamp of creation/import.
  - Active update behavior mode.

### 4. Modern FilterPlus Card-Based Interface
- Clean, intuitive WPF UI featuring live sheet discovery, cell range address selection, target view preview, and real-time validation warnings.

---

## Version History (Changelog)

### v1.0.0 - 2026-09-23
- Initial release featuring ClosedXML vector import engine.
- Drafting View and Legend View target support.
- Merged cell boundary reconciliation and text note placement.
- Cell fill shading via Revit FilledRegions.
- Extensible Storage schema stamping.
- Multi-version support covering Autodesk Revit 2024, 2025, 2026, and 2027.

---

## Support and Contact

For bug reports, feature requests, or technical assistance:
* **Developer**: DBDev_dbarberos
* **Company**: DBDev Solutions
* **Website**: https://dbdev-dbarberos.github.io
* **Email**: dbarberos@outlook.com
