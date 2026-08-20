# Debugging Log: 2D Detail Items & Annotation Thumbnail Fallbacks vs Rendered Previews

**Date:** August 20, 2026  
**Component:** `CadThumbnailService` / `FamilyRevitService` / `TransferPlusViewModel`  
**Symptom:** Selecting 2D Detail Components (`OST_DetailComponents`) in the UI tree displayed identical generic placeholder vector cards rather than the actual 2D component drawings.

---

## 1. Root Cause

1. **API Limitation in `ElementType.GetPreviewImage()`**:
   - In Autodesk Revit API, 2D parametric detail families (`OST_DetailComponents`) and 2D annotation symbols do not maintain pre-rendered 3D mesh thumbnail buffers. `symbol.GetPreviewImage(Size)` returns `null` or a blank image for most 2D types.
2. **Fallback Trigger**:
   - When `ExtractNativeElementThumbnail` returned `null`, the thumbnail service fell back to `CreateFallbackCadIcon()`, drawing a generic orange banner placeholder for all 2D items.
3. **Whole View Export Discrepancy**:
   - Calling `doc.ExportImage()` on the parent host view showed all other details, notes, and walls in that view, failing to isolate the selected single element.

---

## 2. Technical Resolution

Implemented the **Scratch DraftingView with Rollback Transaction** pattern in `FamilyRevitService.GenerateElementPreview`:

1. Start a silent `Transaction` with `WarningSwallower`.
2. Create an in-memory scratch `ViewDrafting` at scale 1:1.
3. Instantiate the 2D `FamilySymbol` (or copy the element) at `XYZ.Zero` inside the scratch view.
4. Call `doc.Regenerate()` and export the scratch view via `doc.ExportImage(ImageExportOptions)` using `ZoomFitType.FitToPage` and `512x512 PNG`.
5. Revert the transaction immediately via `tx.RollBack()` in the `finally` block so the Revit document remains 100% clean and unmodified.
6. Return and cache the rendered PNG image, frozen via `BitmapImage.Freeze()`.

---

## 3. Verified Outcome

- Individual 2D detail components render their exact geometry (lines, arcs, hatches, texts) crisp and centered.
- Selecting a parent View folder renders the entire view.
- Document integrity is 100% preserved with zero phantom views left in the project.
