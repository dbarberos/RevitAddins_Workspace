# TransferPlus

> **Current Version:** v1.1.0  
> **Add-in ID (GUID):** `D1981E8C-1951-45C0-B24C-CA821B7288D2`  

---

## 1. Overview

**TransferPlus** is an enterprise-grade multi-model asset transfer and management solution for Autodesk Revit. Designed to overcome the limitations of Revit's native *Transfer Project Standards* tool, TransferPlus enables granular, asynchronous transferring of project standards, loadable/system families, 2D/3D views (plans, sections, elevations, callouts, drafting views, 3D views), sheets, schedules, legends, and model geometry between active documents, linked models, local directories, Autodesk Docs (ACC/BIM360), Azure Blob Storage, and AWS S3 cloud buckets.

---

## 2. Requirements and Compatibility

> [!WARNING]
> This add-in is compiled for multiple versions using the `Debug.R[XX]` and `Release.R[XX]` configurations.

* **Platform**: .NET Framework 4.8 (Revit 2023, 2024) / .NET 8 (Revit 2025, 2026, 2027).
* **Supported Revit Versions**: 2023, 2024, 2025, 2026, 2027 (Win64).

---

## 3. Installation & Uninstallation

The installer that ran when you downloaded this plug-in from the Autodesk App Store has already installed the plug-in. You may need to restart the Autodesk product to activate the plug-in.

To uninstall this plug-in, exit the Autodesk product if you are currently running it, simply rerun the installer by downloading it again from the Autodesk App Store, and select the 'Uninstall' button, or you can uninstall it from 'Control Panel\Programs\Programs and Features' (Windows 10/11), just as you would uninstall any other application from your system.

---

## 4. Commands and Features Guide

### 4.1. Ribbon Panel Integration
The add-in integrates into Revit's Ribbon interface under the **DBDev** tab (or native **Manage** tab configuration).

| Command | Function | Technical Class |
|---------|----------|-----------------|
| **TransferPlus** | Opens the main multi-document transfer and asset explorer window. | `TransferPlus.Application` |
| **Transfer Rename** | Opens the PowerRename batch preview dialog for rule-based regex renaming. | `TransferPlus.ViewModels.RenamePreviewViewModel` |

---

## 5. Comprehensive Usage Guide

### 5.1. Target Document Selection (`Transfer to:`)
At the top of the main window, the destination selector allows configuring target models:
* **Multi-Model Checkboxes**: Check one or multiple destination documents simultaneously.
* **Open & Linked Documents**: Operates seamlessly across active host projects and loaded link instances.
* **Selection Summary**: A dedicated header indicator displays the total number of checked destination models.

---

### 5.2. Hierarchical Asset Explorer (`What:`)
The central tree view presents all transferrable content organized by category and subtype:
* **Families**: Loadable families with real-time thumbnail extraction (`FamilyThumbnailService`) and system family types.
* **Views**: Floor Plans, Ceiling Plans, Structural Plans, Sections, Elevations, Drafting Views, 3D Views, and View Callouts.
* **Sheets**: Sheet definitions, titleblocks, and placed viewports.
* **Schedules & Legends**: Single-category, multi-category, material takeoff, and assembly schedules.
* **Project Standards**: Line Styles, Line Patterns, Fill Patterns, Materials, Object Styles, View Filters, Text/Dimension Styles, and Phase Settings.

---

### 5.3. Duplicate & Conflict Resolution (`On Duplicates:`)
Configure how TransferPlus handles elements that already exist in target models:
* **Keep Original**: Skips transfer for existing elements, preserving destination definitions without creating duplicates.
* **Abort Transaction**: Safely rolls back the entire transfer transaction if any naming collision occurs.
* **Append Suffix**: Automatically appends a custom user-defined suffix (e.g. `_Copy`, `_Transfer`) to copied elements.
* **PowerRename (Transfer & Rename)**: Opens a real-time pattern matching dialog with RegEx find/replace, prefix/suffix, and sequential numbering rules.

---

### 5.4. View & Geometry Transfer Rules (`On Views & Geometry:`)
Advanced options tailored for copying views and placed elements:
* **Accept on all Dialogs**: Automatically swallows and suppresses non-fatal Revit warning popups using `IFailuresPreprocessor`.
* **Transfer Sheet with Views**: Automatically discovers, transfers, and places all viewports belonging to copied sheets.
* **Use Legend / Schedule / Assembly if Exists in Target**: Re-references existing destination schedules/legends, avoiding duplicate generation.
* **Transfer Callouts of Views**: Recursively transfers child callouts and maintains parental view links.
* **Transfer Sections & Details of Views**: Recreates section cutting planes and detail markers within destination views.
* **Transfer View Elements**: Copies 2D annotations and 3D model geometry contained within source views.
* **Force Level in Level Base Views**: Maps source levels to target levels by name or closest elevation height.

---

### 5.5. Coordinate System Transformation (`Transform By:`)
Defines the 3D mathematical transformation matrix applied during cross-document transfers:
* **None (`Origin to Origin`)**: Strictly aligns internal project origins $(0,0,0)$, ideal for orthogonal aligned models.
* **Link (`WYSIWYG Placement`)**: Uses the link instance transformation (`GetTotalTransform()`), copying elements exactly where they visually appear.
* **Shared (`Survey Point & Shared Coordinates`)**: Applies differential coordinate transformations between project locations for master planning and civil coordinates.

---

### 5.6. Multi-Source Cloud & Local Family Providers
Manage and import Revit families directly from multiple external repositories:
* **Local Directories**: Recursively load `.rfa` libraries from local disks or network shares.
* **Autodesk Docs / ACC**: Connect to cloud-hosted Autodesk Construction Cloud / BIM 360 projects.
* **Azure Blob Storage**: Enterprise private cloud blob containers.
* **AWS S3**: Cloud-hosted S3 family buckets.

---

### 5.7. Family Details & Metadata Inspection
When a family or family type is selected in Family Mode, the right-hand **Family Details** card provides instant inspection:
* **Real-time Thumbnail Preview**: Dynamic 128x128 pixel visual preview extracted asynchronously.
* **Family & Type Information**: Full name, active type, category, and host classification (Wall, Floor, Ceiling, Face, Unhosted).
* **Target Revit Version**: Displays the Revit build version of the `.rfa` asset (e.g. `Revit 2024`).
* **File Size (`File size`)**: Real-time display of physical family file size formatted in `KB` or `MB`.
* **Last Modified (`Last modified`)**: Date timestamp (`yyyy-MM-dd`) indicating when the family was last saved on disk or in the cloud.
* **Optimized Single-Line Layout**: Text trimming with ellipsis (`CharacterEllipsis`) and full tooltips ensure all metadata rows remain visible within the card height.

---

## 6. Version History (Changelog)

### v1.1.0 - 2026-08-19

#### Added
- **Family Details Metadata**: Added **`File size`** (formatted in KB/MB) and **`Last modified`** (`yyyy-MM-dd`) properties dynamically populated across Local Folders, Azure Blob Storage, AWS S3, Autodesk Docs (ACC/BIM360), and Open/Linked documents.
- **Window Icon Standardization**: Integrated Pack URI resources (`pack://application:,,,/TransferPlus;component/Resources/Icons/TransferPlus32x32.png`) across all 14 application windows, preventing default Revit host icon fallbacks.
- **Multi-Version App Store Packaging**: Created automated `build-bundle.ps1` deployment script producing standardized `TransferPlus.bundle` packages for Revit 2024, 2025, 2026, and 2027.

#### Changed
- **Family Details UI Spacing**: Equalized vertical gaps between property titles, property values, and consecutive rows to a uniform minimal spacing (`Margin="0,0,0,0"`).
- **Single-Line Text Trimming**: Enabled `TextWrapping="NoWrap"`, `TextTrimming="CharacterEllipsis"`, and tooltips on all detail rows to guarantee all properties fit seamlessly in the card.

#### Fixed
- **Secondary Window Headers**: Resolved default Revit icon display in child modal windows.
- **Ternary Nullable Type Conversions**: Fixed compilation ambiguity for nullable timestamps and file lengths in storage providers.

---

### v1.0.0

#### Added
- **Multi-Document Transfer Engine**: Core architecture for transferring families, standards, views, and sheets across multiple target documents.
- **Hierarchical Asset Tree**: Categorized explorer for selecting families, views, sheets, schedules, and standards.
- **On Duplicates Conflict Resolution**: Support for *Keep Original*, *Abort Transaction*, *Append Suffix*, and *PowerRename*.
- **On Views Options**: Support for *Transfer Sheet with Views*, *Use Existing Legends/Schedules*, *Transfer Callouts*, and *Transfer View Elements*.
- **Transform By Engine**: Coordinate system transformations for *None (Origin-to-Origin)*, *Link (WYSIWYG)*, and *Shared Coordinates*.
- **Multi-Source Family Providers**: Integrations for Local Folders, Autodesk Docs, Azure Blob Storage, and AWS S3.
- **Section & Callout Viewer Synchronization**: Enhanced viewer element mapping and scale threshold management.
- **Security Hardening**: Windows DPAPI encryption for cloud secrets, zero-trust path sanitization, and safe JSON serialization.
- **Multi-Version Deployment**: Full support for Revit 2023, 2024, 2025, 2026, and 2027.

---

## 7. Support and Contact

For bug reports, feature requests, or technical assistance:
* **Developer**: DBDev_dbarberos
* **Company**: DBDev Solutions
* **Website**: https://dbdev-dbarberos.github.io
* **Support Email**: dbarberos@outlook.com
