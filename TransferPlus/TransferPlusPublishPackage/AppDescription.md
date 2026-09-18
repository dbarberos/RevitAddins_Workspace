# TransferPlus

**TransferPlus** is an enterprise-grade multi-model asset transfer and management solution for Autodesk Revit designed to overcome the limitations of the native *Transfer Project Standards* tool. It allows for the granular, asynchronous transfer of project standards, loadable/system families, 2D/3D views (plans, sections, elevations, callouts, drafting views, 3D views), sheets, schedules, legends, and model geometry between active documents, linked models, local directories, Autodesk Docs (ACC/BIM 360), Azure Blob Storage, and AWS S3 cloud buckets.

---

## Requirements and Compatibility

* **Platform**: .NET Framework 4.8 (Revit 2023, 2024) / .NET 8 (Revit 2025, 2026, 2027).
* **Supported Revit Versions**: 2023, 2024, 2025, 2026, 2027 (Win64).

---

## Installation & Uninstallation

The installer that ran when you downloaded this plug-in from the Autodesk App Store has already installed the plug-in. You may need to restart the Autodesk product to activate the plug-in.

To uninstall this plug-in, exit the Autodesk product if you are currently running it, simply rerun the installer by downloading it again from the Autodesk App Store, and select the 'Uninstall' button, or you can uninstall it from 'Control Panel\Programs\Programs and Features' (Windows 10/11), just as you would uninstall any other application from your system.

---

## Commands and Features Guide

### Ribbon Panel Integration
The add-in creates a custom ribbon panel under the **DBDev** tab (or native **Manage** tab configuration).

| Command | Function | Technical Class |
|---------|----------|-----------------|
| **TransferPlus** | Opens the main multi-document transfer and asset explorer window. | `TransferPlus.Application` |
| **Transfer Rename** | Opens the PowerRename batch preview dialog for rule-based regex renaming. | `TransferPlus.ViewModels.RenamePreviewViewModel` |

---

## Comprehensive Usage Guide

### Target Document Selection (`Transfer to:`)
Configure one or multiple target destination models simultaneously:
- **Multi-Model Support**: Select multiple destination documents to push standards and assets in a single batch pass.
- **Open & Linked Models**: Supports open project documents and loaded Revit links.

### Hierarchical Asset Explorer (`What:`)
The central explorer categorizes all transferrable project items:
- **Families**: Loadable families with real-time thumbnail previews and system families.
- **Views**: Floor Plans, Ceiling Plans, Structural Plans, Sections, Elevations, Drafting Views, 3D Views, and View Callouts.
- **Sheets**: Sheet titleblocks, layout structures, and placed viewports.
- **Schedules & Legends**: Single-category, multi-category, material takeoff, and component legends.
- **Project Standards**: Line styles, materials, fill patterns, filters, object styles, text/dimension styles, and phases.

### Duplicate & Conflict Resolution (`On Duplicates:`)
- **Keep Original**: Skips transfer for existing elements, preserving destination definitions without creating duplicates.
- **Abort Transaction**: Safely aborts and rolls back the entire transaction if any naming collision occurs.
- **Append Suffix**: Automatically appends a custom user-defined suffix (e.g. `_Copy`, `_Transfer`) to copied elements.
- **PowerRename**: Real-time regex pattern find/replace, prefixes, suffixes, and sequential numbering rules.

### View & Geometry Rules (`On Views & Geometry:`)
- **Accept on all Dialogs**: Automated suppression of non-fatal Revit warnings using `IFailuresPreprocessor`.
- **Transfer Sheet with Views**: Automatically discovers, transfers, and places all viewports belonging to copied sheets.
- **Use Legend / Schedule / Assembly if Exists in Target**: Re-references existing destination schedules/legends without duplicates.
- **Transfer Callouts of Views**: Recursively transfers child callouts and maintains parental view links.
- **Transfer Sections & Details of Views**: Recreates section cutting planes and detail markers within destination views.
- **Transfer View Elements**: Copies 2D annotations and 3D model geometry contained within source views.
- **Force Level in Level Base Views**: Maps source levels to target levels by name or closest elevation height.

### Coordinate System Transformation (`Transform By:`)
- **None (Origin to Origin)**: Aligns internal project origins $(0,0,0)$ directly.
- **Link (WYSIWYG Placement)**: Aligns elements to their visual link instance placement (`GetTotalTransform()`).
- **Shared (Survey Point & Shared Coordinates)**: Applies differential coordinate transformations between project locations for master planning and civil coordinates.

### Multi-Source Cloud & Local Family Providers
- **Local Directories**: Direct `.rfa` library loading.
- **Autodesk Docs / ACC**: Cloud BIM 360 project integration.
- **Azure Blob Storage**: Enterprise private cloud storage containers.
- **AWS S3**: Scalable S3 family buckets.

### Family Details & Metadata Inspection
- **Real-time Preview**: Instant asynchronous 128x128 pixel thumbnail rendering.
- **Dynamic File Size**: Formatted size display (`File size`) in `KB` or `MB`.
- **Last Modified Timestamp**: Date formatting (`Last modified`) in `yyyy-MM-dd`.
- **Single-Line Trimming**: Zero vertical clipping with full tooltip inspection.

---

## Version History (Changelog)

### v1.1.0 - 2026-08-19
- Added `File size` and `Last modified` properties in Family Details.
- Standardized custom window icons across all dialogs via Pack URIs.
- Compact UI layout optimization with character ellipsis and tooltips.
- Full multi-version packaging for Revit 2024, 2025, 2026, and 2027.

### v1.0.0
- Initial release with multi-document transfer engine, hierarchical asset tree, conflict resolution, and cloud family providers.

---

## Support and Contact

For bug reports, feature requests, or technical assistance:
* **Developer**: DBDev_dbarberos
* **Company**: DBDev Solutions
* **Website**: https://dbdev-dbarberos.github.io
* **Support Email**: dbarberos@outlook.com
