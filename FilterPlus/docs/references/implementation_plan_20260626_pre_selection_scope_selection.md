# Pre-Selection Scope Filter Selection (All Model Elements / Elements inView)

This plan details the implementation of two mutually exclusive checkboxes ("All Model Elements" and "Elements in View") at the far right of the header in the "Filter Rules" window (`PreSelectionView.xaml`). The checkboxes will dynamically change the scope of elements to filter, refreshing the available dropdown values for each rule dynamically. 

When "Apply" is clicked, the window will close, the corresponding scope option in the main "Select" card will be selected, and the elements matching the pre-selection rules within that scope will be checked in the tree explorer.

## User Review Required

> [!IMPORTANT]
> - **Mutual Exclusivity of Checkboxes:**
>   - Checking "All Model Elements" will uncheck "Elements in View".
>   - Checking "Elements in View" will uncheck "All Model Elements".
>   - One option must always be checked. Unchecking the active option will be prevented.
> - **Select Card Synchronization (Deferred to "Apply"):**
>   - **Toggling the checkboxes inside the Pre-Selection window has NO immediate effect on the main window's selection or the tree explorer.** It only updates the list of `AvailableValues` inside the Pre-Selection window rules.
>   - Only when the user clicks **"Apply"** will the main window's `CurrentScope` be updated to match the selected checkbox, the main tree view be rebuilt for that scope, and the matching elements checked in the explorer.
> - **Dynamic Available Values Update:**
>   - Swapping the scope in the Pre-Selection window dynamically updates the `AvailableValues` dropdown options for each active rule in the tree.
>   - Previously selected values are preserved if they are still valid in the new scope; otherwise, they fall back to the first available option.

## Open Questions

Ninguna. La sincronización se realiza de manera síncrona actualizando el estado de selección en el ViewModel principal únicamente al invocar el comando Apply.

## Proposed Changes

### Component: ViewModels & Models (RevitAddins Workspace)

---

#### [MODIFY] [SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)
- Expose the pre-fetched element lists as public properties:
  - `public List<ElementModel> AllModelElements => _allModelElements;`
  - `public List<ElementModel> ElementsBelongingToView => _elementsBelongingToViewElements;`
- Modify `ApplyPreSelection(HashSet<Autodesk.Revit.DB.ElementId> matchingIds, SelectionScope targetScope)` to:
  - Update `_persistentCheckedIds` with the matching IDs.
  - Set `CurrentScope = targetScope;` (which triggers a synchronous rebuild of the tree for that scope and applies the check states from `_persistentCheckedIds`).
  - Refresh the states of the tree nodes (`node.RefreshState()`) and notify selection changes.

#### [MODIFY] [IPreselRuleNode.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/IPreselRuleNode.cs)
- Add the `void UpdateElements(IEnumerable<ElementModel> elements);` signature.

#### [MODIFY] [PreSelectionRule.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/PreSelectionRule.cs)
- Remove `readonly` from `_allElements`.
- Implement `UpdateElements(IEnumerable<ElementModel> elements)`:
  - Cache `SelectedValue`.
  - Update `_allElements` reference.
  - Run `UpdateAvailableValues()`.
  - Restore `SelectedValue` if it is present in the updated `AvailableValues`, or set it to `AvailableValues.FirstOrDefault()` otherwise.

#### [MODIFY] [PreSelectionRuleSet.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/PreSelectionRuleSet.cs)
- Remove `readonly` from `_allElements`.
- Implement `UpdateElements(IEnumerable<ElementModel> elements)` to recursively propagate the updated elements to all child nodes in `Children`.

#### [MODIFY] [PreSelectionViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/PreSelectionViewModel.cs)
- Remove `readonly` from `_elements`.
- Define observable properties:
  - `[ObservableProperty] private bool _isAllModelElements = true;`
  - `[ObservableProperty] private bool _isElementsInView = false;`
- Add recursion guard field: `private bool _isUpdatingScope;`.
- Add change handlers:
  - `partial void OnIsAllModelElementsChanged(bool value)`: If `value` is true, set `IsElementsInView = false` and update elements scope. If false and `IsElementsInView` is also false, force it back to true.
  - `partial void OnIsElementsInViewChanged(bool value)`: If `value` is true, set `IsAllModelElements = false` and update elements scope. If false and `IsAllModelElements` is also false, force it back to true.
- Implement `UpdateElementScope()`:
  - Set `_elements` to `AllModelElements` or `ElementsBelongingToView` from the main ViewModel.
  - Call `RootSet.UpdateElements(_elements)`.
- Update `Apply()`:
  - Determine target scope (`SelectionScope.AllModelElements` or `SelectionScope.ElementsBelongingToView`).
  - Pass both `matchingIds` and `targetScope` to `_mainViewModel.ApplyPreSelection(matchingIds, targetScope)`.

---

### Component: Views (RevitAddins Workspace)

---

#### [MODIFY] [PreSelectionView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/PreSelectionView.xaml)
- Replace the simple header `TextBlock` in `Grid.Row="0"` with a `Grid` containing:
  - Column 0: The title TextBlock ("Filter Rules").
  - Column 1: A horizontal StackPanel containing the two CheckBoxes:
    - CheckBox 1: `Content="All Model Elements"`, bound to `IsAllModelElements` (Mode=TwoWay).
    - CheckBox 2: `Content="Elements in View"`, bound to `IsElementsInView` (Mode=TwoWay).

## Verification Plan

### Manual Verification
1. Close Autodesk Revit before building.
2. Compile the project: `dotnet build FilterPlus.csproj -c Release.R24`.
3. Open Revit 2024, open the add-in, and click on the "Pre-Selection" option.
4. Verify checkboxes behavior in the "Filter Rules" window header:
   - "All Model Elements" is checked by default.
   - "Elements in View" is unchecked by default.
   - Confirm mutual exclusivity (one is always checked, checking one unchecks the other).
   - **Confirm that checking/unchecking these has NO immediate effect on the main window's selection/scope or tree.**
5. Verify dynamic dropdown updates when switching scopes inside Pre-Selection.
6. Set rules (e.g., matching a category or level), toggle to "Elements in View", and click "Apply".
7. Verify that:
   - The Pre-Selection window closes.
   - In the main window "Select" card, the option "Elements in View" is automatically selected.
   - The tree explorer updates and checks only the elements in the current view that match the rules.
8. Re-open Pre-Selection, switch to "All Model Elements", define rules, and click "Apply".
9. Verify that:
   - The Pre-Selection window closes.
   - In the main window "Select" card, the option "All Model Elements" is selected.
   - The tree explorer updates and checks all elements in the entire model that match the rules.
