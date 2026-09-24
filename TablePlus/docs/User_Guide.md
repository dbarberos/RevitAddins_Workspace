# TablePlus

> **Current Version:** v1.1.0  
> **Add-in ID (GUID):** `C9281744-8B1A-4C23-9D01-B719E022F3AA`  
> **Target Autodesk Revit Versions:** 2024, 2025, 2026, 2027 (Win64)  
> **Publisher:** DBDev Solutions (`DBDev_dbarberos`)  

---

## 1. General Description

**TablePlus** is an enterprise-grade Autodesk Revit add-in designed as a comprehensive tabular and spreadsheet management suite for BIM Managers, architects, structural engineers, and MEP designers. It resolves one of Revit's longest-standing visual documentation challenges: managing and importing complex tabular data (finishes schedules, calculation sheets, door hardware matrices, structural bar schedules, code compliance tables, and drawing notes) directly into project documentation sheets with true graphic fidelity.

Traditional approaches rely on capturing raster screenshots or importing pixelated `.png`/`.jpg` images, resulting in blurry printouts, unselectable text, distorted line weights, and zero intelligence. **TablePlus completely replaces raster imports with a native parametric vector geometry engine and an interactive Master Table Dashboard**:

- **Master Table Dashboard**: A centralized management interface providing a virtualized 11-column table inventory displaying all linked tables across the active project, their synchronization status, view types, scales, and source files.
- **True 2D Vector Geometry**: Generates crisp, scale-independent Revit detail lines (`DetailCurve`), solid filled regions (`FilledRegion`) for cell background shading, and native Revit text notes (`TextNote`).
- **Interactive Style & Header Mapping**: Full control over line styles, body cell typography, and header row overrides (custom text types, font colors, and background shading).
- **In-Place Non-Destructive Synchronization**: Re-reads modified source spreadsheets and updates existing views in place, preserving sheets where views are already placed.
- **Automated Background Synchronization**: Automatic quiet checking and updating of modified tables when opening a Revit project (`DocumentOpened`).
- **Monochrome Black & White (B&W) Mode**: Instant toggle to strip background fills and force crisp black lines and texts for high-contrast technical drafting.
- **Merged Cell Reconciliation**: Accurately computes complex rectangular merged cell boundaries, unifying cell perimeters and centering text notes across merged spans.
- **Multi-View Documentation Targets**: Imports spreadsheets directly into **New Drafting Views** (scale-independent for sheet placement) or **Legend Views** (allowing identical table graphics to be placed across multiple sheets simultaneously).
- **Persistent Extensible Storage Tracking**: Every generated table is stamped with a unique Revit `Extensible Storage` schema (`E3B21D40-6C9A-4E2F-8A11-92D0543B7A1C`), storing source workbook paths, sheet names, cell ranges, styling parameters, and timestamps.
- **Zero Microsoft Office Dependency**: Operates entirely through high-performance, managed OpenXML libraries (`ClosedXML`), requiring zero client-side installation of Microsoft Excel or COM Interop dependencies.

---

## 2. Requirements and Compatibility

> [!WARNING]
> This add-in is compiled for multiple versions using the `Debug.R[XX]` and `Release.R[XX]` configurations. Ensure you run the compatible build for your Autodesk Revit release.

* **Operating System**: Microsoft Windows 10 / Windows 11 (64-bit).
* **Host Application**: Autodesk Revit 2024, 2025, 2026, 2027 (Win64).
* **Target Frameworks**:
  - Revit 2024: `.NET Framework 4.8`
  - Revit 2025 & 2026: `.NET 8.0`
  - Revit 2027: `.NET 9.0`
* **Microsoft Office Dependency**: **None**. The add-in does not require Microsoft Office, Excel, or Microsoft Access Database Engines to be installed on the machine.

---

## 3. Installation & Uninstallation

### Installation
The installer that ran when you downloaded this plug-in from the Autodesk App Store has already installed the plug-in. You may need to restart the Autodesk product to activate the plug-in.

### Uninstallation
To uninstall this plug-in, exit the Autodesk product if you are currently running it, simply rerun the installer by downloading it again from the Autodesk App Store, and select the 'Uninstall' button, or you can uninstall it from 'Control Panel\Programs\Programs and Features' (Windows 10/11), just as you would uninstall any other application from your system.

---

## 4. Commands and Features Guide

### 4.1. Ribbon Panel Integration
TablePlus integrates into the Autodesk Revit ribbon under the standard **Add-Ins / Complementos** tab, fully complying with Autodesk App Store single-command guidelines:

| Command Button | Function | Technical Class |
|---|---|---|
| **TablePlus Dashboard** | Opens the Master Table Dashboard to inspect, filter, synchronize, format, and add tables in the Revit model. | `TablePlus.Commands.CmdImportTable` |
| *(Contextual F1)* | Launches the offline HTML user manual ([help.html](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/Resources/help.html)) with full usage instructions. | `TablePlus.Application` |

```text
Ribbon Hierarchy:
[Add-Ins / Complementos] (Tab)
 └── [TablePlus] (Panel)
      └── [TablePlus Dashboard] (Large PushButton 32x32 with ToolTip & F1 Help)
```

---

## 5. Comprehensive Usage Guide

### 5.1. Master Table Dashboard Overview
When you click **TablePlus Dashboard**, the main interface displays:

1. **Upper Control Zone (Cards)**:
   - **Table Actions Card**: Fast buttons for `+ Add Table`, `🔄 Sync Selected`, `👁️ Open View` (navigates active view in Revit), and `🗑️ Delete / Unlink` (removes views or metadata).
   - **Filters & Search Card**: Live text search (by view name or source file) and dropdown filters by *View Type* (*All*, *Drafting Views*, *Legend Views*) and *Status* (*All*, *Up to Date*, *Modified*, *File Missing*).
   - **System Status Card**: Real-time status diagnostics, background progress bar, and manual refresh button `🔄`.
2. **Lower Data Zone (Virtualized DataGrid)**:
   - An 11-column grid displaying all linked tables in the Revit model with high-performance virtualization.
3. **Footer Zone**:
   - Status summary counters (*Total Tables*, *Selected*, *Pending/Out of Date*), usage tips, and primary batch sync button.

---

### 5.2. Dashboard Columns Guide

| Column | Description |
|---|---|
| **`[x]` (Select)** | Individual row selection checkbox with master header checkbox for *Select All / None*. |
| **`Src`** | Badge indicating document source format (`XLSX`, `XLSM`, `CSV`, `PDF`, `DOC`). |
| **`Status`** | Real-time synchronization indicator: 🟢 **Up to Date**, 🟠 **Modified** (source file edited externally), 🔴 **File Missing** (path broken). |
| **`View Name`** | Name of the Drafting or Legend view in Revit. **Double-click any row** to immediately activate and display this view in Revit. |
| **`View Type`** | Indicates whether the table is in a *Drafting View* or *Legend View*. |
| **`Scale`** | View scale ratio (e.g. `1:1`, `1:20`). |
| **`Source File`** | Filename of the linked spreadsheet, with full absolute file path in tooltip. |
| **`Worksheet / Range`** | Interactive dropdown allowing you to reselect the active sheet/range directly from the grid and update the table in-place. |
| **`Auto-Sync`** | Checkbox enabling automatic quiet background synchronization every time the Revit project is opened. |
| **`B&W`** | Black & White checkbox forcing solid black text and line styles, suppressing cell background fills. |
| **`Design`** | Button `[ 🎨 Design... ]` opening the dedicated style and header mapping modal dialog. |

---

### 5.3. Importing a New Table (`+ Add Table`)
1. In the Dashboard, click **+ Add Table** to open the Table Import modal window.
2. Click **Browse...** to select your spreadsheet (`.xlsx`, `.xlsm`, `.csv`).
3. Select the desired **Worksheet** and **Cell Range** (Entire Sheet, Named Range, or Custom Range such as `A1:G35`).
4. Choose the target view type (**New Drafting View** or **Legend View**), specify the view name and scale.
5. Click **Import Table**. The vector table is created in Revit and automatically registered in your Dashboard inventory.

---

### 5.4. Customizing Table Styles & Headers (`[ 🎨 Design... ]`)
Clicking **`🎨 Design...`** on any table row opens the **Table Graphic & Header Design** window:

1. **Card 1: Table Gridlines**:
   - Select any Revit Line Style from `BuiltInCategory.OST_Lines` (e.g. `<Thin Lines>`, `<Medium Lines>`, or custom company line styles) to draw exterior table borders and interior cell dividers.
2. **Card 2: Body Cell Typography**:
   - Select the Revit `TextNoteType` assigned to standard data cells across the table body.
3. **Card 3: Header Row Overrides**:
   - Toggle **Enable Header Custom Style** to apply unique styling to the topmost header row.
   - Select a distinct Header `TextNoteType` (e.g., larger font or bold weight).
   - Set **Header Background Shading** (hex color or one-click architectural preset swatches: *Charcoal, Slate, Navy, Ocean Blue, Teal, Forest Green, Amber, Crimson, White*).
   - Set **Header Text Color** (hex color or preset swatch).
   - Review your design in the **Live Mini Preview** box.
4. Click **Apply & Save**. The table view in Revit is immediately synchronized with the new styles.

---

### 5.5. In-Place Synchronization & Auto-Sync
- **Batch Sync**: Check one or more rows and click **🔄 Sync Selected**. TablePlus re-reads the source files and updates the existing Revit views in place without recreating or deleting the views, preserving all sheets where the tables are placed.
- **Auto-Sync on Project Open**: Check the **Auto-Sync** box for any critical table. When any team member opens the Revit project, TablePlus automatically detects if the source spreadsheet was modified and updates the table silently in the background.

---

## 6. Multi-Version Architecture & Build Orchestration

TablePlus is engineered for enterprise monorepo deployment covering four major Autodesk Revit releases:

### 6.1. Build Configurations

| Revit Version | .NET Runtime | Build Configuration | Assembly Output |
|---|---|---|---|
| **Revit 2024** | .NET Framework 4.8 | `Release.R24` / `Debug.R24` | `bin/Release.R24/publish/TablePlus.dll` |
| **Revit 2025** | .NET 8.0 | `Release.R25` / `Debug.R25` | `bin/Release.R25/publish/TablePlus.dll` |
| **Revit 2026** | .NET 8.0 | `Release.R26` / `Debug.R26` | `bin/Release.R26/publish/TablePlus.dll` |
| **Revit 2027** | .NET 9.0 | `Release.R27` / `Debug.R27` | `bin/Release.R27/publish/TablePlus.dll` |

### 6.2. Local Build Pipeline (`TablePlus/build-and-pack.ps1`)
Developers can compile and package the add-in locally via the interactive orchestrator:
```powershell
.\TablePlus\build-and-pack.ps1
```

### 6.3. Autodesk App Store Bundle Packaging
The entire multi-version deliverable is packaged using the standardized automated builder:
```powershell
powershell -ExecutionPolicy Bypass -Command "& .\.agents\skills\revit-appstore-bundle\scripts\build-bundle.ps1 -AppName 'TablePlus' -Version '1.0.0' -Author 'DBDev_dbarberos' -Email 'dbarberos@outlook.com' -ProjectDir '.\TablePlus' -TargetYears @('2024', '2025', '2026', '2027')"
```

---

## 7. Version History (Changelog)

### v1.1.0 - 2026-09-23

#### Added
- **Master Table Dashboard (`MainWindowView.xaml` & `MainWindowViewModel.cs`)**:
  - Centralized management dashboard featuring the signature FilterPlus card-based layout.
  - Three upper functional cards: Table Actions, Multi-criteria Filters & Search, and System Diagnostics.
  - High-performance virtualized 11-column DataGrid displaying selection, source badge, live sync status badge, view name, view type, scale, source file, worksheet selector, auto-sync toggle, monochrome B&W mode toggle, and design launcher.
  - Double-click row navigation to instantly activate views in Revit.
- **Table Graphic & Header Design Modal (`TableStyleMappingView.xaml` & ViewModel)**:
  - Custom line style mapping from `BuiltInCategory.OST_Lines`.
  - Body text typography selector from Revit `TextNoteType`s.
  - Header row overrides for custom text styles, text color, and background fill shading with 10 architectural presets and live mini-preview.
- **In-Place Non-Destructive View Updates (`UpdateTableInView`)**:
  - Re-generates 2D vector elements inside existing drafting/legend views without deleting the view element, preserving placed sheet viewports.
- **Background Auto-Synchronization (`DocumentOpened`)**:
  - Automatic quiet verification and batch synchronization of modified tables upon opening Revit projects.
- **Extensible Storage v2 Tracking (`TableRegistryService`)**:
  - Discovers stamped tables, checks disk timestamps against imported timestamps, and populates worksheet options.
  - Added `RemoveTableMetadata` for clean unlinking while preserving vector graphics.

### v1.0.0 - 2026-09-23
- Initial release with closed-XML vector table import, detail curves, text notes, filled regions, and multi-version bundle packaging for Revit 2024–2027.

---

## 8. Support and Contact

To report bugs, suggest features, or request technical support:
* **Developer**: DBDev_dbarberos
* **Company**: DBDev Solutions
* **Support Email**: [dbarberos@outlook.com](mailto:dbarberos@outlook.com)
* **Website**: [https://dbdev-dbarberos.github.io](https://dbdev-dbarberos.github.io)
* **Documentation & Privacy Policy**: [https://dbdev-dbarberos.github.io/PrivacyPolicy/](https://dbdev-dbarberos.github.io/PrivacyPolicy/)
