# Task List: Sort by Level (Dynamic Hierarchy)

- [x] Add `Sort by Level` CheckBox in `SelectionFilterView.xaml`.
- [x] Add `_sortByLevel` observable property in `SelectionFilterViewModel.cs`.
- [x] Add `_activeGroupings` list in `SelectionFilterViewModel.cs`.
- [x] Refactor `OnSortByPhaseChanged` and implement `OnSortByLevelChanged` to track grouping order.
- [x] Implement recursive `BuildGroupedTree` method.
- [x] Refactor `InitializeTree` to use `BuildGroupedTree` instead of hardcoded conditions.
- [x] Compile and verify logic (0 errors).
