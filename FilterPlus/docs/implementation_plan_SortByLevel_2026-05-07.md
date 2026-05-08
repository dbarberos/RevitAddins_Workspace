# Implementation Plan: Sort by Level (Dynamic Hierarchy)

## Goal Description
Implement a new "Sort by Level" switch in the SelectionFilter UI that reorganizes the TreeView. The hierarchy of elements will dynamically depend on the **activation order** of the "Sort by Phase" and "Sort by Level" switches.

## Technical Details
- **Activation Order Tracking**: Use a `List<string> _activeGroupings` to track which groupers are active and in what sequence.
- **Recursive Builder**: Replace hardcoded `if/else` grouping logic with a recursive `BuildGroupedTree` method that processes the active groupings stack.
- **Graceful Fallbacks**: Map empty or null level names to "None" to ensure all elements remain visible.

## Proposed Changes

### [MODIFY] Views/SelectionFilterView.xaml
- Inserted the `Sort by Level` switch between Phase and Live Selection.

### [MODIFY] ViewModels/SelectionFilterViewModel.cs
- Added `SortByLevel` property.
- Added `_activeGroupings` logic in property handlers.
- Implemented `BuildGroupedTree` recursive logic for infinite nesting support.

## Verification Plan
### Manual Verification
- Verified activation order combinations: (Level > Phase) and (Phase > Level).
- Verified element selection persistence during hierarchy shifts.
