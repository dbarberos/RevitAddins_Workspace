# TransferPlus

> **Current Version:** v1.3.0  
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
By default, in accordance with Autodesk App Store single-command guidelines, the **TransferPlus** ribbon panel is installed directly under Revit's native **"Add-Ins" (Complementos)** tab.

Users can customize or relocate the ribbon panel at any time via the **Settings (Gear Icon)** dialog in the main TransferPlus window:
* **Add-Ins Tab (Default)**: Loads the TransferPlus button under Revit's standard Add-Ins tab.
* **Revit Manage Tab**: Integrates into the native **Manage (Gestionar)** tab, placed inside the **Settings (Configuración)** tool group immediately to the right of the **Additional Settings (Configuración adicional)** icon.
* **Custom Tab**: Allows assigning a custom user-defined ribbon tab name (e.g. `DBDev`).

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

### 5.8. CAD Details & 2D Drafting Views Transfer Mode
TransferPlus provides a dedicated **CAD / Details Mode** tailored for migrating 2D drafting content, standard construction details, and external CAD imports across projects:
* **Five Specialized Origin Categories**:
  - **CAD Formats**: Linked and imported DWG, DXF, DGN, and SAT files.
  - **Drafting Views**: Pure 2D drafting views containing text, lines, dimensions, and detail components.
  - **Detail Views & Callouts**: Model-based detail sections and enlarged detail callouts.
  - **Detail Groups**: Reusable 2D detail groups.
  - **Detail Items**: 2D detail component families and instances.
* **Real-time 2D Vector Preview & Zoom-to-Extents**:
  - 200x200 pixel vector preview generated in real-time via scratch drafting views with automatic transaction rollback.
  - Smart zoom-to-extents auto-framing with safety margins for small annotations, tags, and detail components.
  - Dynamic Title Block rendering with in-memory family editing.
* **Middle Column Horizontal Scrolling**:
  - Dedicated horizontal scrollbar for long element names while keeping selection checkboxes and element counts fixed in place.
* **Cross-Model CAD Transfer Engine**:
  - **Dedicated Drafting Views**: Every transferred CAD instance (`ImportInstance`), model detail view (`ViewSection` of Detail/Callout type), and isolated 2D annotation (`FilledRegion`, detail `Group`, lines) is automatically created in a dedicated `ViewDrafting` in destination documents, ensuring zero view pollution and preserving source annotation scale.
  - **Sheet Hierarchy Bypass**: In `Sort by Sheet` organization, only selected child CAD and detail elements are transferred into Drafting Views; parent `ViewSheet` replication is intentionally bypassed in CAD mode.
  - **In-Memory Detail Component Loading**: 2D Detail Components (`OST_DetailComponents`) have their pure Family and Type definitions loaded into target models via in-memory `EditFamily -> LoadFamily` without creating placeholder graphic instances.
  - **On Duplicates Compliance**: Seamlessly integrates with the "On Duplicates" card:
    * *Abort Transaction*: Pre-flight check detects destination view/family name collisions before starting transactions and alerts the user.
    * *Keep Original*: Automatically skips existing destination views or families.
    * *Append Suffix*: Appends custom suffixes (e.g. `_Copy`) and handles subsequent collisions iteratively (`_Copy_1`, `_Copy_2`).
* **Full 2D Content Replication for Drafting Views**:
  - When transferring native Drafting Views, all child view-specific elements (detail lines, text notes, filled regions, independent dimensions, detail components, and CAD elements) are completely copied into destination drafting views using a resilient two-tier copy strategy (batch copy with element-by-element fallback), ensuring views never arrive empty.
* **3D-Referenced Dimension & Tag Isolation**:
  - When transferring Model Detail Views or Callouts containing annotations referenced to 3D geometry not present in the destination model, non-transferrable 3D-dependent dimensions and tags are safely isolated and skipped, while 100% of independent 2D lines, text notes, filled regions, and detail components are preserved.
  - A single, non-intrusive summary notification dialog in English informs the user upon completion of the multi-model transfer if any 3D references were omitted, eliminating repetitive per-view popup interruptions.
* **PowerRename Palette Integration & Chained Iterations**:
  - Full feature parity between Family Mode and CAD Mode in the PowerRename palette.
  - Chained regex renaming: applying replacements updates working names, allowing subsequent pattern passes.
  - Export/download integration: renamed items are downloaded to disk with their new names across local and cloud sources (Azure, AWS S3, Autodesk Docs ACC).
* **Leaf-Only CAD Deletion & Hierarchical Safety Confirmation**:
  - When managing CAD/detail elements in the active project, clicking the Delete button strictly confines deletion to leaf-level elements (CAD links, imports, detail components, groups).
  - Parent hierarchical containers (Sheets and Views) are **never** deleted, keeping them intact in the project for future reuse with new content.
  - An interactive, styled confirmation dialog (`ConfirmCadDeleteWindow`) displays the hierarchical tree structure (Sheet -> View -> Items), explicitly highlighting parent containers as preserved and leaf elements as scheduled for deletion.

---

## 6. Version History (Changelog)

### v1.3.0 - 2026-09-17

#### Added
- **Cross-Model CAD Transfer Engine**: Complete multi-document transfer architecture for CAD Mode (`IsCadDetailsManagerActive`), handling native Drafting Views, model detail views/callouts, CAD import instances, detail components, and isolated annotations.
- **Dedicated ViewDrafting Generation**: Each transferred CAD instance, model detail view, and 2D annotation is automatically instantiated in its own dedicated `ViewDrafting` in target models, preserving scale and preventing view corruption.
- **Full 2D Child Element Copying in Drafting Views**: Upgraded `TransferDraftingViews` to recursively transfer all internal 2D annotations, detail lines, text notes, filled regions, and detail components into destination views using batch copy and element-by-element fallback.
- **Resilient Fallback & 3D Geometry Reference Isolation**: Implemented two-tier fallback copying in `TransferModelDetailViewsToDraftingViews` and `TransferDraftingViews`. Annotations referencing 3D model geometry not present in destination models are isolated and skipped without halting transfer of independent 2D elements.
- **Single English Notification Dialog**: Unified notification for skipped 3D-dependent annotations across multiple destination models, displaying a single informative dialog upon completion instead of multiple per-view alerts.
- **In-Memory Detail Component Loading**: 2D Detail Component families (`OST_DetailComponents`) are loaded directly into the destination model's database using `EditFamily -> LoadFamily` in memory without creating placeholder graphical elements.
- **Pre-Flight Duplicate Conflict Validation**: Pre-flight inspection for `AbortTransaction` in CAD mode that validates destination view and family names before opening transactions, notifying the user via a descriptive `TaskDialog`.
- **PowerRename Chaining & Iterative Modification**: Enhanced regex replacement matching against working names, enabling multi-stage iterative renaming without losing prior edits.
- **Renamed CAD Download & Export Pipeline**: Full integration between the PowerRename palette and CAD export/download workflows, ensuring downloaded CAD files and exported `.rfa` detail families reflect custom renamed titles.

#### Changed
- **Sheet Replication Isolation**: In CAD Mode under `Sort by Sheet`, parent `ViewSheet` replication is strictly bypassed; only child detail elements are transferred into dedicated drafting views, preserving sheet transfer exclusivity for standard project mode.
- **Provider Architecture Harmonization**: Updated `ICadProvider` and all implementations (`LocalFolderCadProvider`, `AzureStorageCadProvider`, `AwsS3StorageCadProvider`, `AutodeskDocsCadProvider`, `OpenDocumentCadProvider`, `LinkedDocumentCadProvider`) to honor `keepOriginal` and `suffix` policies.

#### Fixed
- **Empty Drafting Views in Destination**: Resolved an issue where `TransferDraftingViews` duplicated only the view header, leaving destination drafting views blank.
- **CAD Mode Rename Palette Empty Selection**: Resolved an issue where opening the Rename palette in CAD mode showed an empty list due to family-only collection filtering.
- **2D Detail View Direct Copy Failure**: Replaced direct view copying of model detail views (which failed without matching 3D hosts) with automated 2D annotation extraction and placement into dedicated `ViewDrafting` containers.
- **Collision-Resistant View Naming**: Implemented iterative collision resolution (`_Copy_1`, `_Copy_2`) to prevent Revit native `ArgumentException` crashes when duplicate view names occur in target models.

### v1.2.0 - 2026-09-11

#### Added
- **CAD Details & 2D Drafting Mode**: Dedicated transfer mode for CAD files (DWG, DXF, DGN), drafting views, detail views/callouts, detail groups, and detail component items.
- **Dynamic 2D Vector Previews**: In-memory vector preview generation using scratch drafting views, native Revit `ImageExportOptions`, and automated transaction rollbacks (`CadThumbnailService`).
- **Title Block & Family Dynamic Rendering**: Dynamic preview rendering for title blocks and family types using in-memory `EditFamily` and `ViewSheet` generation.
- **Auto-Crop & Zoom-to-Extents Framing**: Automatic bounding box framing and margin calculations for small annotation elements, tags, and drafting items.
- **Middle Column Horizontal Scrolling**: Dedicated horizontal scrollbar in the asset tree allowing unconstrained reading of long family/view names while keeping checkboxes and element count badges stationary.
- **Leaf-Only CAD Deletion with Hierarchical Confirmation Dialog**: Interactive safety confirmation window before deleting CAD details from active models. Displays the hierarchy with clear visual indicators that parent Sheets and Views are preserved while only the selected leaf CAD/detail elements are deleted.
- **Ribbon Placement on Add-Ins Tab (Default)**: Aligned with Autodesk App Store single-command guidelines by placing the TransferPlus ribbon panel on Revit's native **Add-Ins (Complementos)** tab by default.
- **Revit Manage Tab Placement (Settings Group)**: New placement option to insert the TransferPlus button directly into the native **Settings (Configuración)** panel of the **Manage (Gestionar)** tab, positioned immediately to the right of the *Additional Settings (Configuración adicional)* command.

#### Changed
- **CAD Mode UI Layout**: Standardized 2-column layout in the Select Details/CAD card with 200x200 thumbnail preview.
- **Tooltip Standardization**: Standardized tooltip max-widths (`MaxWidth="225"`) across all CAD Mode ORIGIN and ORGANIZE toggles.
- **Family Mode Segregation**: Loadable families are strictly isolated in Family Mode, keeping system families in the standard asset tree for optimal performance.
- **Configuration Window Tab Options**: Updated the *Tab Option (*)* selection card in the Configuration window with clear, descriptive choices: *Place TransferPlus on Add-Ins tab (default)*, *Place on Revit Manage tab*, and *Place on tab named:*.

#### Fixed
- **Parent Sheet & View Deletion Prevention in CAD Mode**: Fixed an issue where tri-state checkbox bubbling or parent node resolution in `Sort by Sheet` mode could cause parent `ViewSheet` or `View` containers to be deleted along with CAD details. Deletion is now strictly confined to leaf elements.
- **XML Settings Deserialization Resilience**: Resolved startup deserialization errors caused by legacy `DBDevDefault` tab settings. Implemented backwards-compatible enum mapping (`[XmlEnum("DBDevDefault")]`), seamless in-memory auto-upgrade to `AddInsDefaultTab`, non-blocking warning logging, and safe fallback handling to prevent modal alert freezes during Revit initialization.
- **Polymorphic Detail Item Handling**: Resolved `InvalidCastException` when collecting `OST_DetailComponents` by handling `FilledRegion` and `FamilyInstance` polymorphically.
- **TreeView Layout Clipping**: Fixed text clipping in TreeView item templates using unconstrained Canvas containers.
- **Reference Plane & Dimension Suppression**: Enforced transaction-backed `HideElements` on reference planes and dimensions during thumbnail rendering to produce clean presentation previews.

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
