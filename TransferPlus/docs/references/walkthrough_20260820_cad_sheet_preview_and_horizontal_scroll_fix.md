# Walkthrough: Full Sheet Preview & WPF TreeView Horizontal Scrolling Fix

**Date**: 2026-08-20  
**Add-in**: TransferPlus (CAD Mode & TreeView UI)  
**Branch**: `TransferCAD`  

---

## 1. Overview & Objectives

This development cycle addressed two critical user requests in TransferPlus:
1. **Full Sheet (`ViewSheet`) Preview Rendering**: In CAD Mode, when selecting a Sheet (Plano) node in the hierarchical tree, render the full sheet thumbnail (including titleblock, annotations, and placed viewports) into the preview card.
2. **Elimination of Text Truncation in Horizontal Scrolling**: When names exceed the visible column width, users can scroll horizontally to inspect the full name without any clipping or character cutoffs, while keeping the row's CheckBox pinned to the left and Count pinned to the right.

---

## 2. Technical Implementation Details

### A. Full Sheet (`ViewSheet`) Preview Rendering
- **Data Model**: Added `public ElementId? SheetId { get; set; }` to [`CadDetailItemModel.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/CadDetailItemModel.cs).
- **Detail & CAD Providers**: Updated `DetailItemProvider`, `DraftingViewProvider`, `DetailViewProvider`, `DetailGroupProvider`, and `CadInstanceProvider` to map `Viewport.ViewId -> (SheetId, SheetName)` and assign `SheetId` to collected items.
- **Tree Builder (`BuildCadTree`)**: When grouping by sheet (`CadSortBySheet`), instantiated a dedicated `CadDetailItemModel` with `Category = "Sheet"`, `NativeElement = ViewSheet`, and `ElementId = sheet.Id`, attached to `sheetNode.Item`.
- **Selection Dispatcher (`TreeView_SelectedItemChanged`)**: Handled `selectedNode.Category == "Sheet"` to set `SelectedCadDetail` to the sheet model.
- **Thumbnail Routing (`CadThumbnailService.cs`)**: Route `Category == "Sheet"` and `ViewSheet` instances directly to `FamilyRevitService.GenerateViewPreview(doc, sheetId)`, utilizing Revit's `ImageExportOptions` with `ZoomFitType.FitToPage` to render the full sheet layout.

### B. WPF TreeView Layout Clip Elimination for Horizontal Scrolling
- **Problem**: When using `TranslateTransform` driven by a pinned horizontal `ScrollBar`, text characters past a fixed width (~200px) remained invisible even when scrolled.
- **Root Cause**: WPF's layout engine automatically generates a `GetLayoutClip` on any `FrameworkElement` arranged inside a constrained `Grid` column slot when its size exceeds the slot width.
- **Resolution**: Wrapped the `StackPanel` (expander + node name text) inside an unconstrained `<Canvas Height="24" HorizontalAlignment="Stretch">` within the middle column (`Grid.Column="1" ClipToBounds="True"`).
- **Behavior**:
  - `Canvas` measures and arranges children with infinite horizontal bounds, preventing WPF from injecting a layout clip.
  - `Grid.Column="1"` with `ClipToBounds="True"` strictly enforces boundary clipping at the column borders, guaranteeing that text does not bleed over the pinned CheckBox (Column 0, 26px) or the pinned Count (Column 2, 60px).
  - Increased `TreeHScrollBar.Maximum` to `1500` to support arbitrary text length.

---

## 3. Files Modified

| File | Changes |
|---|---|
| [`TransferPlus/Models/CadDetailItemModel.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/CadDetailItemModel.cs) | Added `SheetId` property. |
| [`TransferPlus/Services/CadThumbnailService.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/CadThumbnailService.cs) | Added full sheet routing in `GetPreviewImageAsync`. |
| [`TransferPlus/Services/Providers/DetailItemProvider.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/DetailItemProvider.cs) | Enriched viewport mapping with `SheetId`. |
| [`TransferPlus/Services/Providers/DraftingViewProvider.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/DraftingViewProvider.cs) | Enriched viewport mapping with `SheetId`. |
| [`TransferPlus/Services/Providers/DetailViewProvider.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/DetailViewProvider.cs) | Enriched viewport mapping with `SheetId`. |
| [`TransferPlus/Services/Providers/DetailGroupProvider.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/DetailGroupProvider.cs) | Enriched viewport mapping with `SheetId`. |
| [`TransferPlus/Services/Providers/CadInstanceProvider.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/CadInstanceProvider.cs) | Enriched viewport mapping with `SheetId`. |
| [`TransferPlus/ViewModels/TransferPlusViewModel.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs) | Attached `sheetCadItem` and `viewCadItem` in `BuildCadTree`. |
| [`TransferPlus/Views/TransferPlusView.xaml`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml) | Enclosed middle column in `Canvas` and set `TreeHScrollBar.Maximum="1500"`. |
| [`TransferPlus/Views/TransferPlusView.xaml.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml.cs) | Handled `selectedNode.Category == "Sheet"` selection and fallback hierarchy lookup. |

---

## 4. Verification & Validation

- **Compilation**: Built with `dotnet build -c Debug.R24 /p:DeployAddin=true` (`0 Errors, 336 Warnings`).
- **Deployment**: Verified in Revit 2024.
- **Git State**: Pushed to `origin/TransferCAD`.
