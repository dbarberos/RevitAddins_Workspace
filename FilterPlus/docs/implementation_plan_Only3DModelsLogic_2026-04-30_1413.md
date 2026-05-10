# Implementation Plan — FilterPlus: 'Only 3D Modeled' Filter Logic

## Background
Implement the logic for the "Only 3D Modeled" toggle to filter out annotations and view-specific elements, ensuring mutual exclusion with other filters and handling selection persistence.

## Proposed Changes

### ElementModel.cs [MODIFY]
- Added metadata properties: `IsModelElement`, `IsAnnotation`, `HasBoundingBox`.

### RevitSelectionService.cs [MODIFY]
- Populated the new metadata during pre-fetch by checking `Category.CategoryType`.

### SelectionFilterViewModel.cs [MODIFY]
- **OnIsOnly3DModelsChanged**:
  - Implemented mutual exclusion: Sets `IsOnlyAnnotation` and `HasBoundingBox` to `false`.
  - Implemented auto-uncheck: Removes IDs of elements hidden by the filter from `_persistentCheckedIds`.
- **Refactoring**:
  - `UpdateDropdowns` and `InitializeTree` now accept a filtered collection instead of using the global `_activeElements` directly.
  - `BuildTree` calls `GetFilteredElements()` to obtain the current visible subset based on active toggles.

## Verification Plan
1. Open Revit 2024.
2. Select elements (including some text/annotations).
3. Toggle "Only 3D Modeled" ON.
4. Verify that text/annotations disappear from the tree.
5. Verify that if they were checked, they are now UNCHECKED (and the counter decreases).
6. Toggle "Only 3D Modeled" OFF.
7. Verify elements return but remain unchecked.
