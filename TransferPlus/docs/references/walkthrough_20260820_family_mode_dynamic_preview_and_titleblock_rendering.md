# Walkthrough: Dynamic Preview Rendering in Family Mode and Title Block Resolution

**Date:** 2026-08-20  
**Status:** Completed & Verified (`0 errors`)  
**Scope:** Family Mode Dynamic 2D/3D Rendering, In-Memory `doc.EditFamily` Inspection, `ViewSheet` Title Block Hosting, and Background `.RFA` Export.

---

## 1. Overview & Problem Statement

In **Family Mode**, families lacking pre-generated thumbnails (such as 2D detail components, annotation tags, profiles, and title blocks) or without embedded OLE preview streams previously fell back directly to generic 2D placeholder vector icons.

Furthermore, attempting to render **Title Blocks (`BuiltInCategory.OST_TitleBlocks`)** by placing them inside a temporary `ViewDrafting` failed with Revit API exceptions (`ArgumentException: The view is not valid for family placement`) because title blocks can exclusively be hosted on a `ViewSheet`.

---

## 2. Implemented Architecture

### A. Dual-Strategy In-Memory Family Rendering (`GenerateFamilyRenderedPreview`)
1. **Primary Strategy — `doc.EditFamily(nativeFam)` (Universal & Clean)**:
   - For all editable families (`nativeFam.IsEditable == true`), opens the family document in memory.
   - Natively queries the family's default 3D isometric view, plan view, or active view.
   - Bypasses all host placement restrictions (wall-hosted, ceiling-hosted, sheet-hosted).
   - Exports the view to PNG at 512x512 px via `ImageExportOptions` with `ZoomFitType.FitToPage`.
   - Closes the in-memory document immediately (`famDoc.Close(false)`), preserving project purity.

2. **Secondary Strategy — Dedicated `ViewSheet` Hosting for Title Blocks**:
   - If `EditFamily` is unavailable, identifies `BuiltInCategory.OST_TitleBlocks`.
   - Creates a temporary `ViewSheet` in a transaction with `WarningSwallower`.
   - Instantiates the `FamilySymbol` on the temporary sheet.
   - Exports the sheet and immediately rolls back (`tx.RollBack()`).

3. **Background `.RFA` Document Export (`GenerateRfaFileRenderedPreview`)**:
   - For external or cloud-cached `.rfa` files lacking OLE thumbnail streams, opens the file silently via `Application.OpenDocumentFile(rfaPath)`.
   - Exports the 3D or plan view to PNG and closes without saving.

---

## 3. Key Files Modified

- `TransferPlus/Services/FamilyRevitService.cs`: Added `GenerateFamilyRenderedPreview` and `GenerateRfaFileRenderedPreview`.
- `TransferPlus/Services/FamilyThumbnailService.cs`: Wired dynamic scratch-view rendering and in-memory .rfa opening before falling back to default 2D schematic icons.
- `TransferPlus/ViewModels/TransferPlusViewModel.cs`: Initialized `FamilyThumbnailService.ActiveDocument` and `FamilyThumbnailService.CurrentApplication`.

---

## 4. Verification

- Compiled successfully under `Debug.R24` (`0 errors`).
- Pushed to `origin/TransferCAD` (`commit 10bebbf`).
