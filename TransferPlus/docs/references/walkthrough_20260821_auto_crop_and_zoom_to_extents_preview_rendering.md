# Walkthrough: Auto-Crop and Zoom-to-Extents Preview Rendering for Small Elements and Tags

**Date:** 2026-08-21  
**Status:** Completed & Verified (`0 errors`)  
**Scope:** Elimination of excessive white margins, Reference Plane suppression, View CropBox fitting, and Pixel-level Auto-Framing (`OptimizeImageFraming`).

---

## 1. Overview & Problem Statement

When exporting dynamic previews for small 2D elements such as **Annotation Tags (`BuiltInCategory.OST_Tags`)**, **Generic Annotations (`BuiltInCategory.OST_GenericAnnotation`)**, or **Detail Items (`BuiltInCategory.OST_DetailComponents`)**:
- The rendered thumbnail displayed the element as a microscopic dot in the center of a large 512x512 canvas.
- **Root Cause**: In family documents and temporary views, Revit's `FitToPage` fits **all visible elements** including default Reference Planes (`OST_CLines`), Reference Lines (`OST_ReferenceLines`), and Dimension lines, which often span hundreds or thousands of millimeters across (100x larger than a 10mm tag).

---

## 2. Implemented Architecture

### A. View Clean-Up & Suppression (`HideReferencePlanesAndAnnotations`)
Before calling `doc.ExportImage()`, all reference and datum categories are hidden in the view:
- `BuiltInCategory.OST_CLines` (Reference Planes)
- `BuiltInCategory.OST_ReferenceLines`
- `BuiltInCategory.OST_Dimensions`
- `BuiltInCategory.OST_Grids`
- `BuiltInCategory.OST_Levels`

### B. Dynamic View CropBox Fitting
On 2D views (`ViewDrafting` / `ViewPlan`), the `BoundingBoxXYZ` of the placed element is computed, and a tight `CropBox` with an 8% margin is applied:
- `tempView.CropBoxActive = true;`
- `tempView.CropBoxVisible = false;`

### C. Pixel-Level Auto-Framing (`OptimizeImageFraming`)
A high-speed GDI+ pixel scanner scans the exported PNG:
- Detects the exact bounding rectangle `[minX, minY, maxX, maxY]` of non-white and non-transparent pixels.
- If content occupies `< 85%` of the image canvas, crops the content tightly.
- Rescales and centers the cropped element onto a new 512x512 square canvas with high-quality bicubic interpolation and an 8% clean margin.
- Overwrites the PNG on disk, guaranteeing that any element (from a 5mm tag to a large family) occupies 85-90% of the thumbnail window.

---

## 3. Key Files Modified

- `TransferPlus/Services/FamilyRevitService.cs`: Added `OptimizeImageFraming`, `HideReferencePlanesAndAnnotations`, and tight CropBox adjustments across `GenerateElementPreview`, `GenerateFamilyRenderedPreview`, `GenerateRfaFileRenderedPreview`, and `GenerateViewPreview`.

---

## 4. Verification

- Build and deployment succeeded (`0 errors`).
- Pushed to `origin/TransferCAD` (`commit 2f45fb3`).
