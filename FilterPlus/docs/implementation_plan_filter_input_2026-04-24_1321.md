# Implementation Plan - Phase 2: Filter Input

In this phase, we will add a filter input field to the Selection Filter window. This will allow users to search for elements in the hierarchical tree view (the "explorer").

## User Review Required

> [!IMPORTANT]
> The "Clear" button is specified to "return to the previous selection before entering text". 
> **Question:** Does this mean that any checkmarks changed *while* filtering should be undone? Or does it simply mean that the filter is removed and all elements become visible again?
> I will implement the "Clear" to reset the text and visibility, and I can also add a "Restore Selection" logic if confirmed.

## Proposed Changes

### Core Logic

#### [MODIFY] [TreeItemViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/TreeItemViewModel.cs)
- Add `[ObservableProperty] private bool _isVisible = true;` to support filtering.

#### [MODIFY] [SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)
- Add `[ObservableProperty] private string _filterText;`
- Add `OnFilterTextChanged` partial method to trigger filtering.
- Implement `ApplySearchFilter()` method to update `IsVisible` on all nodes.
- Add `ClearSearchCommand` to clear the text and restore visibility.

### User Interface

#### [MODIFY] [SelectionFilterView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml)
- Update the left column layout to include a row for the filter.
- Add a `DockPanel` or `Grid` containing:
    - `TextBlock` with "Filter:"
    - `TextBox` bound to `FilterText`.
    - `Button` with "Clear" bound to `ClearSearchCommand`.
- Update `TreeViewItem` style to bind `Visibility` to the `IsVisible` property using a `BooleanToVisibilityConverter`.

## Verification Plan

### Manual Verification
1. Open the Selection Filter window.
2. Verify the "Filter:" label, input box, and "Clear" button appear above the tree.
3. Type a keyword (e.g., "Wall") and verify the tree filters to show only matching elements (including their parents for context).
4. Click "Clear" and verify the text box is empty and all elements are visible again.
