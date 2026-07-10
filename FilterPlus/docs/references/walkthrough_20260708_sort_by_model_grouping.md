# Walkthrough: Sort by Model Grouping Feature

## 1. Goal
Add a new option to group elements in the tree explorer based on the Revit document (Host or Link Instance) they belong to, respecting the active hierarchy order along with Phases, Levels, and Worksets.

## 2. Changes Made
- **UI Element**: Added a new `CheckBox` in [SelectionFilterView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml) with content "Sort by Model" between "Sort by Workset" and "on Live Selection" checkboxes.
- **ViewModel Property**: Added `SortByModel` observable property and its partial change handler `OnSortByModelChanged` in [SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs).
- **Grouping Logic**:
  - Implemented model resolution in `GetModelDisplayName` using `LinkInstanceId` to match the model to the titles from `AvailableModels` (Active Model vs Links).
  - Extended the `BuildGroupedTree` method to process `"Model"` grouping level, creating a node for the model group and recursively grouping nested elements under it.
- **Documentation**: Updated the changelog section of `User_Guide.md`, `references/user_guide.md`, and `help.html`.

## 3. Verification
- Compiled for Revit 2024 debug target (`Debug.R24`).
- Published production releases for all versions (`Release.R23` through `Release.R27`).
- Re-run `build-bundle.ps1` and `build-msi.ps1` to produce updated deployment artifacts under `Deploy/`.
