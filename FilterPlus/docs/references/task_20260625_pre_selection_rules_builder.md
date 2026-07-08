# Pre-Selection Rules Builder Tasks

- [x] 1. Update Models
  - [x] Add `SystemName`, `SystemClassification`, `MepDomain`, and `ZoneName` to `ElementModel.cs`
  - [x] Create `PreSelectionRule.cs` representing a single selection rule
- [x] 2. Update RevitSelectionService
  - [x] Update `MapToElementModel(...)` to extract MEP System name, System Classification, MEP Domain, and Zone name
- [x] 3. Update ViewModels
  - [x] Create `PreSelectionViewModel.cs` to hold the rules builder state (AND/OR, rule items list, Add/Remove rule commands, Apply/Cancel commands)
  - [x] Update `SelectionFilterViewModel.cs` to add `OpenPreSelectionCommand`, helper `GetActiveModelElements()`, and tree check state application logic (`ApplyPreSelection`)
- [x] 4. Create and Bind Views
  - [x] Create `Views/PreSelectionView.xaml` with matching Revit Filter Rules layout
  - [x] Create `Views/PreSelectionView.xaml.cs` code-behind
  - [x] Bind "Pre-Selection" button in `SelectionFilterView.xaml` to `OpenPreSelectionCommand`
- [x] 5. Compilation and Verification
  - [x] Build the add-in for Revit 2024 (completed with 0 errors)
  - [x] Test the Pre-Selection rule matching behavior in Revit
