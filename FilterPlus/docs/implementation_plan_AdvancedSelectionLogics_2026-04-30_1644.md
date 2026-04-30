# Implementation Plan — FilterPlus: Advanced Selection Logics

## Background
Implement the logic for "Only Annotations" and "Has Bounding Box" toggles, including the renaming of the 3D toggle to "Only 3D model objects".

## Proposed Changes

### SelectionFilterView.xaml [MODIFY]
- Renamed the first checkbox label to **"Only 3D model objects"**.

### SelectionFilterViewModel.cs [MODIFY]
- **Mutual Exclusion**: Updated `OnIsOnly3DModelsChanged`, `OnIsOnlyAnnotationChanged`, and `OnHasBoundingBoxChanged` to ensure only one of these three primary geometry filters can be active at a time.
- **Auto-Uncheck**: Implemented a shared `UncheckHiddenElements` method that removes IDs from `_persistentCheckedIds` if they are filtered out by the active toggle.
- **Offline Filtering**: Updated `GetFilteredElements` to apply all active toggles (3D objects, Annotations, Bounding Box) using the pre-fetched metadata in `ElementModel`.

## Verification Plan
1. Launch FilterPlus in Revit 2024.
2. Select a mix of 3D objects (Walls), annotations (Text), and system objects (Sun Path).
3. Toggle **"Only 3D model objects"**:
   - Annotations and Sun Path should disappear.
   - Any checked annotations should be unchecked.
4. Toggle **"Only Annotations"**:
   - 3D objects and Sun Path should disappear.
   - "Only 3D model objects" should turn OFF.
5. Toggle **"Has Bounding Box"**:
   - Everything without a physical extent (Sun Path, Materials) should disappear.
   - Both other toggles should turn OFF.
