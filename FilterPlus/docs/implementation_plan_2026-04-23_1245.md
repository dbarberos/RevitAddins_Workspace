# Implementation Plan - Total View Model Initialization over Partial Selections

## Goal
Decouple the hierarchical data mapping from being restricted solely to pre-selected sets, instructing it to display the comprehensive active Revit view elements regardless of state, while still pre-initializing user-selected checkmarks across elements accurately parsed.

## Implementation details
1. Modified `RevitSelectionService.cs` so it never narrows the tree's dataset generation via active selection bounding, ensuring the total canvas array is universally gathered via `FilteredElementCollector`.
2. Created a separate extraction `GetInitialSelectionIds()` routing raw UI selections purely for marking.
3. Created `ApplyInitialSelection` recursive search methodology checking against the active UI `HashSet`. This checks individual element ID leaves seamlessly, relying completely on WPF propagation to structure and compute parent null (yellow/green) combinations upward into the tree mathematically identical to a human performing physical inputs.
