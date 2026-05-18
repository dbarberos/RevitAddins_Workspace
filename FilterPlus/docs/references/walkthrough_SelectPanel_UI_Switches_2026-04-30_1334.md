# Walkthrough — FilterPlus: Select Panel UI Enhancement (Symmetry Update)

**Date:** 2026-04-30_1334  
**Feature:** Advanced Selection Switches (Symmetry Refinement)  
**Status:** ✅ Layout optimized and centered

---

## 1. Symmetry and Sizing
To achieve a more balanced and compact look, the overall window and the "Select" card have been adjusted.

- **Compact Window**: Total width reduced to **675px** to better fit the content without wasted space.
- **Perfect Centering**: The contents of the "Select" card are now horizontally centered (`HorizontalAlignment="Center"`) within the white border. This ensures that the empty space (gap) to the left of the radio buttons is identical to the space to the right of the switches.
- **Tightened Columns**: The gap between the scope column and the filter switches column has been reduced to **20px**, making the information feel more connected.

## 2. Technical Details
- **Main View**: Updated `ColumnDefinition` for the right panel to `295px`.
- **Card View**: Changed from proportional `*` columns to `Auto` columns with a fixed spacer to prevent off-center stretching.

Build completed successfully. ✅ (Revit needs to be closed to apply the new DLL).
