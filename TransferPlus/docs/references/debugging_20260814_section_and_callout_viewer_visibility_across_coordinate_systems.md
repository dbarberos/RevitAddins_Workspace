# Debugging Log: Section Cut Marks & Callout Bubble Visibility Across Coordinate Systems & View Templates

**Date:** 2026-08-14  
**Add-in / Module:** TransferPlus / `TransferOrchestrator.cs`  
**Tags:** `RevitAPI`, `ViewSection`, `ViewPlan`, `Callouts`, `Transform`, `RevitLinkInstance`, `OST_Viewers`, `ViewTemplates`, `ScaleThreshold`, `CopyElements`, `OnDuplicates`

---

## 1. Problem Description

When transferring a floor plan or structural plan view containing Section markers and Callout bubbles between Revit documents:
- The child `ViewSection` (sections) and callout views were created in the target document's Project Browser.
- However, on the transferred parent plan view (`vistadestino`), the 2D viewer marks (section cutting lines, section heads, callout boundaries, and callout heads) remained completely invisible, even when categories, crop box, and scale thresholds were unlocked.

---

## 2. Root Cause Analysis

### Iteration 1 & 2 — Initial Diagnoses:
1. **Fragile Link Matching**: Handled via `GetTransformForSource`.
2. **Scale Threshold (`SECTION_COARSER_SCALE_PULLDOWN`)**: Unlocked to $\ge 10000$.
3. **Category and Template Locking**: Unlocked across `OST_Viewers` and view templates.

### Iteration 3 — The Crucial API Mechanism Discovery:
Even with all visibility parameters unlocked and crop regions deactivated, the symbols did not exist in the parent view.
**Why?**
1. **Detached 3D Creation**:
   - `ViewSection.CreateSection(doc, vftId, bbox)` creates an isolated 3D section view in the database. It does **not** register or draw a 2D cutting line on `vistadestino`. For Revit to draw a section cut mark on a plan view, the section's 3D bounding box must physically intersect the plan view's cutting plane in model space.
2. **Native View-to-View `CopyElements`**:
   - In Revit API, transferring child/dependent views (callouts and sections) from `vistaorigen` into `vistadestino` via:
     ```csharp
     ElementTransformUtils.CopyElements(
         vistaorigen, 
         new List<ElementId> { childView.Id }, 
         vistadestino, 
         null, 
         copyOptions);
     ```
     causes Revit to copy the view **AND automatically instantiate the 2D Viewer Symbol (section line with heads or callout bubble) directly inside `vistadestino`**.

---

## 3. Solution: View-to-View Copy with Strict "On Duplicates" Rules

### A. Primary Strategy in `ponCallouts` and `ponSections`:
Execute `ElementTransformUtils.CopyElements(vistaorigen, new List<ElementId>{ elementToCopy }, vistadestino, null, copyOptions)`. If this fails, fall back to `ViewSection.CreateCallout` / `ViewSection.CreateSection`.

### B. Strict Adherence to "On Duplicates":
1. **`KeepOriginal` (`cf_rbKeepOriginal`)**:
   If a view with the same name exists in `destino`, re-use the existing view, synchronize its details and graphics, and avoid creating phantom duplicates.
2. **`AppendSuffix` (`cf_rbAppendSuffix`)**:
   If a duplicate exists, create the copy and rename it with `GetUniqueViewName(destino, name + suffixText, viewType)`.
3. **`AbortTransaction` (`cf_rbAbortTransaction`)**:
   If a duplicate exists, abort immediately by throwing `OperationCanceledException` with `DuplicateElementInfo` so the user modal displays.
4. **No conflict**:
   Preserve the exact original source view name.

---

## 4. Verification Table

| Aspect | Prior Behavior | New Behavior |
|--------|----------------|--------------|
| Section Marker Generation | Missing on plan (created as detached 3D view) | ✅ Instantiated natively via View-to-View `CopyElements` |
| Callout Bubble Generation | Missing or detached | ✅ Instantiated natively via View-to-View `CopyElements` |
| "Keep Original" | Created new views without checking child duplicates | ✅ Re-uses existing child views without duplicate creation |
| "Append Suffix" | Inconsistent suffixing on child views | ✅ Generates clean unique suffixed names |
| "Abort Transaction" | Silently ignored on child views | ✅ Aborts and reports duplicates cleanly |
