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
- **`GenerateViewPreview` in `FamilyRevitService`**: Renders complete views (Drafting Views, Detail Views, Callouts) via `doc.ExportImage(ImageExportOptions)`.
- **`GenerateElementPreview` in `FamilyRevitService`**: Renders isolated 2D detail components (`FamilyInstance` / `FamilySymbol`) and detail groups by instantiating them inside an in-memory scratch `ViewDrafting` in a silent transaction with `WarningSwallower`, exporting tightly framed with `ZoomFitType.FitToPage`, and immediately performing `tx.RollBack()` to preserve 100% document purity.
- **`CadThumbnailService`**:
  - Resolves view vs isolated element targets, manages in-memory caching (`_thumbnailCache`), and safely loads images into `BitmapImage` with `BitmapCacheOption.OnLoad` and `BitmapImage.Freeze()` to ensure cross-thread safety on the WPF UI thread.
  - Multi-tier hierarchy: Isolated `GenerateElementPreview` -> `GenerateViewPreview` -> `ElementType.GetPreviewImage()` -> 2D schematic vector CAD fallback card.

### 2.4. UI / UX Modernization (`TransferPlusView.xaml`)
- **Card "Select Details/CAD"**:
  - Divided into 2 clear columns:
    - **`ORIGIN`** (Left): Radio buttons for `CAD Links / CAD Imports`, `Drafting Views`, `Details Views / Detail Callouts`, `Details Groups`, `Details Items`.
    - **`ORGANIZE`** (Right): Switches for `Sort by Sheet`, `Sort by View`, `Sort by Name`.
  - **Standardized ToolTips**: Informative 3-part structured tooltips on hover for every option, describing the concept, elements collected, and where to find them in Revit.
  - Typography aligned with *FilterPlus* (`FontSize="9" FontWeight="SemiBold" Foreground="#999"`, `FontSize="11"` for rows, and `Margin="0,0,0,6"` spacing).
  - Horizontal separator line.
  - **Full Column Width 200px Height Thumbnail**: Responsive container (`HorizontalAlignment="Stretch"`, `Height="200"`) with lateral margins, loading spinner, and uniform proportional image scaling (`Stretch="Uniform"`).

---

## 3. Verification & Build Results

- **Compiler Target:** `.NET Framework 4.8` (Revit 2024).
- **Build Status:** **`0 Errors`**, **`0 Breaking Changes`**.
- **Deployment:** Automatically deployed to `%APPDATA%\Autodesk\Revit\Addins\2024\TransferPlus`.
