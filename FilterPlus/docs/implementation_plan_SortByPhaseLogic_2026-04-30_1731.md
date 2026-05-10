# Implementation Plan — FilterPlus: Sort by Phase Logic

## Background
Implement the hierarchical sorting by project phases. When enabled, elements should be grouped by their "Created Phase" as the top level of the tree.

## Proposed Changes

### ElementModel.cs [MODIFY]
- Added `PhaseName` (string) and `PhaseOrder` (int) properties.

### RevitSelectionService.cs [MODIFY]
- **Pre-fetch Phases**: Captures the list of project phases and their sequence order from `doc.Phases`.
- **Element Mapping**: During pre-fetch, each element's `CreatedPhaseId` is mapped to its name and chronological order. Elements without a phase are marked as "N/A".

### SelectionFilterViewModel.cs [MODIFY]
- **Recursive Refactoring**: Introduced `BuildCategorySubTree` to handle the standard Category > Family > Type > ID hierarchy in a reusable way.
- **Hierarchical Injection**: Updated `InitializeTree` to inject the Phase level at the root when `SortByPhase` is enabled.
- **Ordering**: Phases are sorted chronologically according to their project sequence number.
- **Selection Persistence**: The recursive selection state update (`ApplyInitialSelection`) has been verified to work with the new nested structure.

## Verification Plan
1. Launch FilterPlus.
2. Toggle **"Sort by Phase"** ON.
3. Verify the tree root children are Phase names (e.g., "Existing", "New Construction").
4. Verify the order of phases matches Revit's phase dialog.
5. Verify categories appear inside each phase.
6. Toggle **"Sort by Phase"** OFF.
7. Verify the tree returns to Category-first grouping.
8. Verify that selection marks persist when switching the sort mode.
