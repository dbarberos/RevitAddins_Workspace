# Debugging Log: Section Cut Marks & Callout Bubble Visibility Across Coordinate Systems & View Templates

**Date:** 2026-08-14  
**Skill:** `revit-api-geometry`, `revit-api-core`  
**Domain:** Cross-document View Transfer, Section & Callout Instantiation, On Duplicates Handling  

---

## 1. Problem Description

When transferring floor plan or structural plan views containing Section markers and Callout bubbles between Revit documents:
- The child `ViewSection` (sections) and callout views were created in the target document's Project Browser.
- However, on the transferred parent plan view (`vistadestino`), the 2D viewer marks (section cutting lines, section heads, callout boundaries, and callout heads) remained completely invisible.

---

## 2. Root Cause Analysis

### The Dual Creation Paradigms in Revit API:
1. **Detached 3D Creation (`ViewSection.CreateSection`)**:
   `ViewSection.CreateSection(doc, vftId, bbox)` creates an isolated 3D section view in the database. It does **not** register or draw a 2D cutting line on `vistadestino`. For Revit to draw a section cut mark on a plan view, the section's 3D bounding box must physically intersect the plan view's cutting plane in model space.
2. **Native View-to-View `CopyElements`**:
   In Revit API, transferring child/dependent views (callouts and sections) from `vistaorigen` into `vistadestino` via:
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

## 4. Key Takeaways

> For child views (sections and callouts) that must display their 2D marker tags on a parent plan view, always prioritize view-to-view `CopyElements(parentSrcView, childViewIds, parentTgtView, null, copyOptions)` over programmatic 3D view creation.
