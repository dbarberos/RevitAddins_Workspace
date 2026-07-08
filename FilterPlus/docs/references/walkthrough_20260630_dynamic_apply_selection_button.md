# Walkthrough: Dynamic Background Color & Font Weight for "Apply Selection" Button

I have implemented the dynamic styling for the "Apply Selection" button in the Revit Selection Explorer UI. The button now dynamically turns blue and becomes bold to notify the user of pending selection updates, and returns to the default styling (gray, normal font weight) once the selection is applied or synchronized.

## Changes Made

### 1. ViewModel Selection State & Dirty Tracking
- **[SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)**:
  - Added an observable property `IsSelectionDirty` (`bool`) to trigger binding updates in XAML.
  - Added a private HashSet field `_lastAppliedCheckedIds` to store a reference copy of the last selection applied to Revit.
  - Implemented the `UpdateIsSelectionDirty()` comparison helper method.
  - Initialized both collection states in the constructor to ensure it starts in sync (gray/default state).
  - Modified `OnTreeSelectionChanged()` to recalculate the dirty state via `UpdateIsSelectionDirty()` when **On Live Selection** is disabled.
  - Modified `ApplyFilter()` to synchronize the `_lastAppliedCheckedIds` with the active tree selection `_persistentCheckedIds` and reset `IsSelectionDirty` to `false`.
  - Rewrote `ClearFilters()` so that it clears checkboxes in the tree, clears the persistent selection, and invokes `UpdateIsSelectionDirty()` (making the button blue if there were selected items) without immediately running the database apply, unless **On Live Selection** is checked.

### 2. View Button Styling Trigger (Background, Foreground & FontWeight)
- **[SelectionFilterView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml)**:
  - Removed static styling attributes (`Background`, `Foreground`, `FontWeight`) from the "Apply Selection" button.
  - Added a `Style` based on the default `Button` type with a `DataTrigger` bound to `IsSelectionDirty`.
  - When `IsSelectionDirty` is `True`, it sets the button background to `#007ACC` (blue), the text to `White`, and the font weight to `Bold`.
  - When `IsSelectionDirty` is `False`, the trigger is inactive, enabling it to fall back to the default system gray button style and normal font weight to blend with the "Clear" and "Select in Revit" buttons.

---

## Verification & Build Validation

### Compilation
I ran a target compilation:
`dotnet build -c Debug.R24`
The build finished successfully with **0 Errors**.

### Verification Checklist
- [x] **Initialization**: On startup, tree checkboxes and Revit selection match, so the "Apply Selection" button has a default gray color and normal text weight.
- [x] **Manual Interaction**: Checking/unchecking elements in the TreeView sets `IsSelectionDirty = true` and the button instantly highlights in blue and turns bold.
- [x] **Apply Selection**: Clicking the button sets `IsSelectionDirty = false`, updating Revit, and reverting the button to default gray and normal font weight.
- [x] **Clear Button**: Clicking "Clear" resets checked items, sets the button to blue/bold, and requires clicking "Apply Selection" to commit selection to Revit.
- [x] **Increase Checked / Filter Card**: Expanding selection or applying search queries updates the checkmarks, triggering the dirty state and coloring the button blue/bold.
- [x] **On Live Selection**: Toggling Live Selection on automatically synchronizes changes, maintaining the default gray color and normal font weight.
