# Implementation Plan — FilterPlus: Select Panel UI Enhancement (Refined)

## Background
The user wants to expand the "Select" panel to include advanced filtering switches while maintaining the existing scope radio buttons.

## Proposed Changes

### SelectionFilterViewModel [MODIFY]
- Added 5 new observable properties:
  - `IsOnly3DModels`
  - `IsOnlyAnnotation`
  - `HasBoundingBox`
  - `UnselectAllOnRun`
  - `SortByPhase`

### SelectionFilterView.xaml [MODIFY]
- Increased right column width to **320px**.
- Added `SwitchStyle` with **dark gray (#777)** active color to match the add-in's other switches.
- Redesigned the "Select" card:
  - **Two-column layout** (without vertical separator per user request).
  - Standardized **FontSize="11"** for both Scopes and Toggles.
  - Left column: RadioButtons for scope.
  - Right column: CheckBoxes (switches) for advanced filtering.

## Verification Plan
1. Launch FilterPlus in Revit 2024.
2. Verify the "Select" panel shows two clean columns.
3. Verify the toggles are dark gray (#777) when active.
4. Verify font sizes are consistent (11px).
