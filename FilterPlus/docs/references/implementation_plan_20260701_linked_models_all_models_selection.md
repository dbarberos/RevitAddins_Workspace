# Implementation Plan: "All Models" Selection & Filtering Support

This plan outlines the design and steps to support selection, pre-selection, and filtering across the host model and all linked models simultaneously under a unified context.

## User Review Required

> [!IMPORTANT]
> **Unified Selection Highlights**: Revit's `Selection.SetReferences()` API allows selecting and highlighting elements from the host document and multiple linked models simultaneously in the Revit viewport. This plan leverages that capability to support unified selection.
>
> **Duplicate Element IDs Solution**: Since `ElementId` values are only unique within their respective documents, we introduce `ElementSelectionKey` (combining `ElementId` and `LinkInstanceId`) to uniquely identify elements in the tree-view and selection collections.

---

## Proposed Changes

### Core Models

#### [NEW] [ElementSelectionKey.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/ElementSelectionKey.cs)
- Created a struct to serve as a unique composite key for selections containing `ElementId` and `LinkInstanceId`.

#### [MODIFY] [ElementModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/ElementModel.cs)
- Added `LinkInstanceId` property.

### Services

#### [MODIFY] [RevitSelectionService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Services/RevitSelectionService.cs)
- Updated `GetAvailableElements` to support "All Models" context.
- Implemented coordinate transformation intersection checks.
- Handled host + links simultaneously via `SetReferences()`.

#### [MODIFY] [PickElementsHandler.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Services/PickElementsHandler.cs)
- Updated the finished selection handler to map composite keys.

### ViewModels

#### [MODIFY] [TreeItemViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/TreeItemViewModel.cs)
- Added `LinkInstanceId` property and converted selection methods to return `ElementSelectionKey`.

#### [MODIFY] [SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)
- Changed tracking to `HashSet<ElementSelectionKey>` and refactored selection/filtering logic.

---

## Verification Plan

### Manual Verification
1. **Model Context Selection**: Verify the dropdown includes "All Models" at the end.
2. **Unified Tree View**: Select "All Models". Verify the explorer tree displays merged categories, families, and types.
3. **Multi-Model Pre-Selection**: Open the Pre-Selection window. Verify rules (e.g. Category = Walls) pre-select elements across all models.
4. **Simultaneous Highlighting**: Highlight elements in both host and linked models at the same time in the Revit viewport.
