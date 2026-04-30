# Implementation Plan — FilterPlus: Select Panel UI Enhancement

## Background
The user wants to expand the "Select" panel to include advanced filtering switches (Only 3D Models, Only Annotation, etc.) while maintaining the existing scope radio buttons.

## Proposed Changes

### SelectionFilterViewModel [MODIFY]
- Added 5 new observable properties:
  - `IsOnly3DModels`
  - `IsOnlyAnnotation`
  - `HasBoundingBox`
  - `UnselectAllOnRun`
  - `SortByPhase`

### SelectionFilterView.xaml [MODIFY]
- Increased right column width from 250 to 320 to accommodate the dual-column card.
- Added `SwitchStyle` to `Window.Resources` (adapted from `ConfigurationView.xaml`).
- Redesigned the "Select" card:
  - `Grid` with two columns.
  - **Left Column**: Existing Scopes (RadioButtons).
  - **Right Column**: New Toggles (CheckBoxes with `SwitchStyle`).
  - Added vertical separator between columns.
  - Optimized font sizes (11 for scopes, 10 for toggles) for a premium look.

## Verification Plan
1. Launch FilterPlus in Revit 2024.
2. Verify the "Select" panel shows two columns.
3. Verify the toggles animate correctly when clicked.
4. Verify they don't break existing scope selection.
