# Tasks: Pre-Selection Rules Builder Polish

- [x] 1. Update Models (PreSelectionRuleSet.cs)
  - [x] Implement `AddNode(IPreselRuleNode node)` with insertion-sorting logic
  - [x] Update `AddRule()` and `AddSet()` commands to call `AddNode(node)`
- [x] 2. Update ViewModels (PreSelectionViewModel.cs)
  - [x] Update constructor default rule initialization to use `RootSet.AddNode`
- [x] 3. Update Views (PreSelectionView.xaml)
  - [x] Replace rule delete button dash `—` content with `❌` and use borderless transparent style
  - [x] Replace set delete button `X` content with `❌` and keep borderless transparent style
- [x] 4. Compilation and Build Validation
  - [x] Build the project for Revit 2024 using `dotnet build`
- [x] 5. Reference Documentation Update
  - [x] Update local reference guides with these improvements
