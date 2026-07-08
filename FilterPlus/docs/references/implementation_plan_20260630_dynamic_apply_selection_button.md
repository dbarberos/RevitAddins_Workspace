# Dynamic Background Color for "Apply Selection" Button

This plan implements a dynamic visual cue on the "Apply Selection" button. 
- When the checked items in the TreeView explorer match what has been applied to the Revit model, the button will blend in with the other buttons (using the default gray button background).
- When the checked items in the tree deviate from the applied Revit selection (due to user interactions, filters, or expansion rules), the button will turn **Blue** (`#007ACC`) to indicate that the selection must be applied.

## User Review Required

> [!IMPORTANT]
> The "Clear" button currently resets the selection and immediately applies it to Revit. Under this plan, if **On Live Selection** is unchecked:
> - Clicking **Clear** will uncheck all boxes in the tree and turn the **Apply Selection** button **Blue**.
> - The Revit selection will *not* be cleared until the user presses **Apply Selection**.
> - If **On Live Selection** is checked, clearing the checkboxes will instantly clear the Revit selection as before.

Please confirm if this is the desired behavior for the **Clear** button.

## Proposed Changes

### ViewModel & View Styling

---

#### [MODIFY] [SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)

- Define a private field `_lastAppliedCheckedIds` to track the last selection state applied to the Revit database.
- Define a new observable property `IsSelectionDirty` (`bool`).
- Implement an `UpdateIsSelectionDirty()` helper method that performs a set-comparison between `_persistentCheckedIds` and `_lastAppliedCheckedIds`.
- Initialize both collections in the constructor.
- Update `OnTreeSelectionChanged()` to invoke `UpdateIsSelectionDirty()` when `IsLiveSelection` is disabled.
- Update `ApplyFilter()` to sync `_lastAppliedCheckedIds` and clear the dirty state (`IsSelectionDirty = false`).
- Update `ClearFilters()` so that it clears tree nodes and updates `IsSelectionDirty` (turning the button blue) without immediately applying the filter to Revit (unless `IsLiveSelection` is enabled).

#### [MODIFY] [SelectionFilterView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml)

- Modify the "Apply Selection" `<Button>` styling.
- Remove hardcoded `Background="#007ACC"` and `Foreground="White"` attributes.
- Add a `<Button.Style>` with a `DataTrigger` bound to `IsSelectionDirty`.
- When `IsSelectionDirty` is `True`, the trigger applies `Background="#007ACC"` and `Foreground="White"`.
- When `IsSelectionDirty` is `False`, the trigger is inactive, allowing the button to fall back to default WPF styling (matching "Clear" and "Select in Revit").

## Verification Plan

### Manual Verification
1. **Startup**: Run the add-in. The tree selection matches Revit's active selection. The "Apply Selection" button should have the default gray background.
2. **Interact with Checkbox**: Check or uncheck a tree item. The "Apply Selection" button must turn **Blue**.
3. **Apply Selection**: Click "Apply Selection". The button must turn back to default gray.
4. **Clear**: Click "Clear" when selection is active. The checkboxes will clear, and the button will turn **Blue**.
5. **Increase Checked**: Use "Increase Checked" options (e.g., "Same category" or "Group or Assembly") and click Apply. The button should turn **Blue** (or stay blue if it was already).
6. **Live Selection**: Turn "On Live Selection" on. Changing checkbox states should immediately apply in Revit, and the button must remain default gray.
