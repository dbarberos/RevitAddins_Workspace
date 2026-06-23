# Implementation Plan - Selection Scopes (Phase 2)

Implement a second column in the FilterPlus Explorer to allow users to switch between different selection scopes.

## Proposed Changes

### UI (WPF)
- Expand window width to 700.
- Enable Column 2 (250px) and GridSplitter.
- Add "Select" card with RadioButtons:
    - Current Selection
    - Elements in View
    - All Model Elements
- Use `EnumToBoolConverter` for RadioButton binding.
- Match styles from ConfigurationView (White card, specific margins).

### ViewModel
- Add `SelectionScope` enum and `CurrentScope` property.
- Implement `OnCurrentScopeChanged` logic:
    - Save manual checks from `CurrentSelection`.
    - Restore them when returning to `CurrentSelection`.
    - Sync with live Revit selection when entering `View` or `All` modes.
- Update `LoadElements` to fetch data from `RevitSelectionService` based on scope.

### Service
- Update `RevitSelectionService.GetAvailableElements` to accept `SelectionScope`.
- Implement filtering logic using `FilteredElementCollector` for each scope.

## Verification Plan
- Build for Revit 2024.
- Manual test in Revit (simulated):
    - Launch with selection -> Tree shows selected.
    - Switch to View -> Tree shows all in view, but only keeps checked those in Revit selection.
    - Switch back to Selection -> Tree restores manual checks.
