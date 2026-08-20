# Walkthrough: CAD Details & Drafting Views Transfer & Native Preview

**Date:** August 20, 2026  
**Add-in:** TransferPlus  
**Branch:** `TransferCAD`

---

## 1. Overview & Objective

This release extends **TransferPlus** with full support for transferring **Drafting Views** and embedded/linked **CAD Instances (DWG)** between open Revit documents, complemented by a high-performance **native Revit view preview (Thumbnail)** integrated inside the main UI.

---

## 2. Key Features Implemented

### 2.1. CAD & Drafting Views Data Layer & Collectors
- **`CadDetailItemModel`**: Pure observable model capturing view names, sheet allocations (`SheetNumber - SheetName`), link status, CAD counts, and `NativeElement` / `SourceDocument` references.
- **`DraftingViewProvider`**: Collects all non-template `ViewType.DraftingView` instances, maps them to viewports/sheets, and counts embedded CAD instances.
- **`CadInstanceProvider`**: Collects `ImportInstance` elements across the model, resolving host owner views and linked vs imported definitions.

### 2.2. Robust Revit Transfer Logic (`FamilyRevitService`)
- **`TransferDraftingViews`**: Uses `ElementTransformUtils.CopyElements` wrapped in a silent transaction with `WarningSwallower` and rollback protection to seamlessly duplicate drafting views into target documents.
- **`TransferCadInstancesToDraftingViews`**: Automatically locates or retrieves the `ViewFamily.Drafting` type in the target document, constructs unique drafting view containers (e.g. `CAD - filename.dwg (ViewName)`), and copies the CAD instances into them.

### 2.3. Native Revit Preview Rendering (`ImageExportOptions`)
- **`GenerateViewPreview` in `FamilyRevitService`**: Eliminates any dependency on 3rd party DWG parsing libraries by invoking Revit's native `doc.ExportImage(ImageExportOptions)`:
  - `ExportRange = ExportRange.SetOfViews`
  - `ZoomType = ZoomFitType.FitToPage`
  - `PixelSize = 512`
  - `ImageResolution = ImageResolution.DPI_72`
  - File format: `PNG`
  - Output path: Sanitized temporary folder in `%TEMP%\TransferPlus_Previews`
- **`CadThumbnailService`**:
  - Resolves view targets, manages in-memory caching (`_thumbnailCache`), and safely loads images into `BitmapImage` with `BitmapCacheOption.OnLoad` and `BitmapImage.Freeze()` to ensure cross-thread safety on the WPF UI thread.
  - Multi-tier fallback hierarchy: `doc.ExportImage()` -> `ElementType.GetPreviewImage()` -> 2D schematic vector CAD fallback card.

### 2.4. UI / UX Modernization (`TransferPlusView.xaml`)
- **Card "Select Details/CAD"**:
  - Divided into 2 clear columns:
    - **`ORIGIN`** (Left): Radio buttons for `CAD Links / CAD Imports`, `Drafting Views`, `Details Views / Detail Callouts`, `Details Groups`, `Details Items`.
    - **`ORGANIZE`** (Right): Switches for `Sort by Sheet`, `Sort by View`, `Sort by Name`.
  - Typography aligned with *FilterPlus* (`FontSize="9" FontWeight="SemiBold" Foreground="#999"`, `FontSize="11"` for rows, and `Margin="0,0,0,6"` spacing).
  - Horizontal separator line.
  - **Centered 200x200 px Thumbnail**: Rounded border with responsive loading spinner, placeholder prompt, and live preview rendering.

---

## 3. Verification & Build Results

- **Compiler Target:** `.NET Framework 4.8` (Revit 2024).
- **Build Status:** **`0 Errors`**, **`0 Breaking Changes`**.
- **Deployment:** Automatically deployed to `%APPDATA%\Autodesk\Revit\Addins\2024\TransferPlus`.
