# Debugging Report: Isolated 2D Element Preview Rendering Architecture

**Date:** August 20, 2026  
**Add-in:** TransferPlus  
**Branch:** `TransferCAD`  
**Problem:** Selecting 2D Detail Components in the tree resulted in generic placeholder cards with orange banners because `symbol.GetPreviewImage()` returned `null` for 2D annotation families.

---

## 1. Root Cause Analysis

1. `ElementType.GetPreviewImage(Size)` in Revit DB API is primarily tailored for 3D model families and often returns `null` for 2D Detail Items (`OST_DetailComponents`), 2D Annotation symbols, and detail groups.
2. The UI thumbnail service defaulted to `CreateFallbackCadIcon()`, generating the placeholder card.
3. Exporting the host view (`doc.ExportImage`) was not viable for individual items as it included all other elements and annotations in that view.

---

## 2. Implemented Architecture: `GenerateElementPreview`

1. **Transient Sandbox Transaction**:
   - `using (var tx = new Transaction(doc, "Generate Isolated Element Preview"))` wrapped with `WarningSwallower`.
2. **Scratch Drafting View**:
   - Creates a temporary `ViewDrafting` at scale 1:1.
   - Instantiates only the target `FamilySymbol` (or copies the element) at `XYZ.Zero`.
3. **High-Resolution Framing (`ImageExportOptions`)**:
   - Exports the scratch view via `doc.ExportImage()` with `ZoomType = ZoomFitType.FitToPage`, `PixelSize = 512`, `ImageResolution = DPI_72`, `PNG`.
   - `ZoomFitType.FitToPage` tightly encases only the isolated 2D element vector geometry.
4. **Immediate Clean Rollback**:
   - `tx.RollBack()` in the `finally` block ensures 100% database purity with no model changes.
5. **Thread-Safe WPF Display**:
   - Loaded into `BitmapImage`, frozen with `Freeze()`, and bound to the UI.

---

## 3. Benefits for Future Modes (Family Mode)

This identical pattern can be directly extended to the Family mode in TransferPlus to render high-resolution previews of 2D profile families, annotation symbols, and title blocks where standard `GetPreviewImage()` falls short.
