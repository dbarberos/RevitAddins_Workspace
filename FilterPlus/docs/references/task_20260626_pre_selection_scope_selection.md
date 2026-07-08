# Tasks: Pre-Selection Scope Filter Selection

- [x] 1. Update `SelectionFilterViewModel.cs`
  - [x] Expose pre-fetched element lists (`AllModelElements`, `ElementsBelongingToView`, `ElementsVisibleInView`) as public properties
  - [x] Modify `ApplyPreSelection` to accept `targetScope`, update `_persistentCheckedIds`, update `CurrentScope` and refresh tree node states
- [x] 2. Update `IPreselRuleNode.cs`
  - [x] Declare `UpdateElements(IEnumerable<ElementModel> elements)` signature
- [x] 3. Update Rule Models
  - [x] Modify `PreSelectionRule.cs` to implement `UpdateElements` and safely restore `SelectedValue`
  - [x] Modify `PreSelectionRuleSet.cs` to recursively propagate element updates to children
- [x] 4. Update `PreSelectionViewModel.cs`
  - [x] Define `IsAllModelElements` and `IsElementsInView` properties
  - [x] Implement change handlers to enforce mutual exclusivity
  - [x] Implement `UpdateElementScope` to swap active elements and call node updates
  - [x] Update `Apply` command to determine target scope and pass it to the main ViewModel
- [x] 5. Update `PreSelectionView.xaml`
  - [x] Replace header title with a Grid containing the title on the left and scope CheckBoxes on the right
- [x] 6. Compile and Verify
  - [x] Build the project for Revit 2024 using `dotnet build`
