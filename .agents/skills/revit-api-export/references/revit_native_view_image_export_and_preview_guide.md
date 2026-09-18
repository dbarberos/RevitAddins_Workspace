# Revit API: Native View Image Export & Preview Generation Guide

## 1. Context & Purpose
When displaying visual previews of CAD links, DWG imports, drafting details, or 3D models in add-in dialogs, using Revit's native `Document.ExportImage` avoids the need for heavy 3rd-party DWG/DXF rendering libraries.

## 2. Best Practices & Configuration
- **ExportRange**: Use `ExportRange.SetOfViews` when targeting a specific `View.Id` via `options.SetViewsAndSheets(new List<ElementId> { viewId })`.
- **ZoomFitType**: Always specify `options.ZoomType = ZoomFitType.FitToPage` (not `ZoomFitToPage`).
- **Resolution & Sizing**: Set `PixelSize = 512` and `ImageResolution = ImageResolution.DPI_72` for crisp, lightweight UI thumbnails.
- **Output Sanitization**: Export to a unique subfolder under `%TEMP%` using `Path.GetFullPath` to prevent file collision and Path Traversal.
- **WPF Consumption**: Read the generated image into `BitmapImage` with `BitmapCacheOption.OnLoad` and call `BitmapImage.Freeze()` to enable safe rendering across threads.
