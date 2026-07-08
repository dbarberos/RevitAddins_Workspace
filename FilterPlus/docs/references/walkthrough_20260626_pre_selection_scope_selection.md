# Walkthrough: Pre-Selection Scope Filter Selection

I have implemented two mutually exclusive checkboxes ("All Model Elements" and "Elements in View") in the header row of the "Filter Rules" (Pre-Selection) window. They allow the user to choose the scope of elements to evaluate. Additionally, clicking "Apply" synchronizes this choice with the main window's selection scope, rebuilding the tree and checking matching elements.

## Changes Made

### 1. Model & Base Layer
- **[IPreselRuleNode.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/IPreselRuleNode.cs)**: Added the `void UpdateElements(IEnumerable<ElementModel> elements)` signature to the rule node interface.
- **[PreSelectionRule.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/PreSelectionRule.cs)**: Made `_allElements` mutable. Implemented `UpdateElements()` to update the elements cache, refresh the `AvailableValues` dropdown options, and preserve the user's previously selected value if it remains valid in the new scope (falling back to the first value otherwise).
- **[PreSelectionRuleSet.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/PreSelectionRuleSet.cs)**: Made `_allElements` mutable. Implemented `UpdateElements()` to recursively push updated element scopes down to all child sets and rules.

### 2. ViewModels
- **[SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)**:
  - Exposed pre-fetched lists `AllModelElements`, `ElementsVisibleInView`, and `ElementsBelongingToView` as public properties.
  - Updated `ApplyPreSelection` to accept a `SelectionScope targetScope` parameter. It updates `_persistentCheckedIds`, changes the active `CurrentScope` to `targetScope` (which triggers a synchronous tree rebuild for the target scope), and checks the correct elements.
  - **Bug Fix (Tree Explorer Not Rebuilding)**: Removed the `TreeItemViewModel.IsBulkUpdating = true` assignment from `ApplyPreSelection` since it blocked `OnCurrentScopeChanged` from triggering a tree rebuild. Additionally, added an explicit check `if (CurrentScope == targetScope) BuildTree();` to guarantee the explorer updates even when the scope has not changed.
- **[PreSelectionViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/PreSelectionViewModel.cs)**:
  - Changed `_elements` to be mutable.
  - Added observable properties `IsAllModelElements` (default `true`) and `IsElementsInView` (default `false`).
  - Implemented partial property change handlers to enforce strict mutual exclusivity (checking one unchecks the other, and unchecking the active one is prevented).
  - Implemented `UpdateElementScope()` to swap the active elements list using properties from the main ViewModel and recursively notify the rule tree.
  - Updated the constructor to initialize `_elements` to the main ViewModel's `AllModelElements`.
  - Updated the `Apply` command to determine the selected target scope (`SelectionScope.AllModelElements` or `SelectionScope.ElementsBelongingToView`) and pass it to `ApplyPreSelection` in the main ViewModel.

### 3. Views
- **[PreSelectionView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/PreSelectionView.xaml)**:
  - Replaced the simple `TextBlock` header at `Grid.Row="0"` with a `Grid` layout.
  - Placed the "Filter Rules" title in the left column.
  - Added a horizontal `StackPanel` in the right column with the two `CheckBox` controls bound to `IsAllModelElements` and `IsElementsInView` (Mode=TwoWay).

---

## Verification & Testing

### Compilation
- Compiled successfully for Revit 2024 using `dotnet build FilterPlus.csproj -c Release.R24` (and confirmed DLLs can be updated once Revit is closed).

### Manual Test Script
1. Open Revit 2024, load the FilterPlus add-in, and click **"Pre-Selection"**.
2. Verify that in the window header, **"All Model Elements"** is checked and **"Elements in View"** is unchecked.
3. Click **"Elements in View"** $\rightarrow$ verify that "All Model Elements" automatically unchecks.
4. Click **"All Model Elements"** again $\rightarrow$ verify that "Elements in View" unchecks.
5. Try to click the checked checkbox to uncheck it $\rightarrow$ verify it stays checked (mutual exclusivity).
6. Confirm that checking/unchecking checkboxes does NOT immediately alter any main window state or checked tree nodes in the background.
7. Create a rule (e.g. `Categorías`), toggle the scope checkbox between "All Model Elements" and "Elements in View", and verify that the values inside the ComboBox dropdown update dynamically to reflect only values from the active scope.
8. Set up rules, choose **"Elements in View"**, and click **"Apply"**:
   - The Pre-Selection window closes.
   - The main window's **"Select"** tab scope option updates to **"Elements in View"** automatically.
   - The tree explorer updates and checks only the matching elements present in the active view.
