# Implementation Plan — FilterPlus: 'on Live Selection' Logic

## Background
Implement the final selection switch "on Live Selection" which enables real-time synchronization between the FilterPlus tree and the Revit selection.

## Proposed Changes

### SelectionFilterView.xaml [MODIFY]
- Swapped the positions of the last two checkboxes: "Sort by Phase" is now second-to-last, and the final checkbox is the new selection switch.
- Renamed the label from "Unselect All" to **"on Live Selection"**.

### SelectionFilterViewModel.cs [MODIFY]
- **Property Rename**: Renamed `UnselectAllOnRun` (private `_unselectAllOnRun`) to `IsLiveSelection` (private `_isLiveSelection`).
- **Live Sync**: Updated `OnTreeSelectionChanged` to call `ApplyFilter()` immediately whenever a checkbox in the tree is toggled, provided `IsLiveSelection` is active.
- **Toggle Trigger**: Added `OnIsLiveSelectionChanged` to apply the current selection state in Revit as soon as the switch is turned ON.
- **Safety**: The implementation respects the `IsBulkUpdating` flag to prevent redundant API calls during large tree operations (like category selection or searching).

## Verification Plan
1. Launch FilterPlus.
2. Verify "on Live Selection" is the last option in the Select card.
3. Check some elements in the tree.
4. Toggle **"on Live Selection"** ON.
5. Verify that Revit's selection updates immediately without pressing "Apply Selection".
6. With the switch ON, check/uncheck elements in the tree.
7. Verify Revit selection follows every click in real-time.
