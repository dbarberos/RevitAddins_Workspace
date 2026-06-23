# Implementation Plan: Sort by Workset (Dynamic Hierarchy)

## Goal Description
Extend the dynamic hierarchy system to include a third grouping level: **Workset**. This allows users to cross-slice Revit data based on Phase, Level, and Workset in any stacking order determined by the activation sequence.

## Technical Details
- **Architecture**: Leverages the recursive `BuildGroupedTree` pattern established in previous iterations.
- **Data Source**: Uses the `WorksetName` property from `ElementModel`.
- **UI**: Added a third switch in the Selection card.

## Proposed Changes
### Views
- **[MODIFY]** `Views/SelectionFilterView.xaml`: Added "Sort by Workset" checkbox.

### ViewModels
- **[MODIFY]** `ViewModels/SelectionFilterViewModel.cs`: 
  - Added `SortByWorkset` property.
  - Updated grouping stack logic to include "Workset".
  - Extended recursive tree builder to process `e.WorksetName`.
