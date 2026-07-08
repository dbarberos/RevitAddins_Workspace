# Walkthrough: Dynamic Family and Type Rules in Pre-Selection

I have successfully implemented dynamic parameter filtering inside the Pre-Selection rules editor window. Sibling rules within the same rule set now dynamically enable family and type parameter options, and restrict their selectable values.

## Changes Made

### 1. Dynamic Parameter Rule Definitions & Restrictive AvailableValues
- **[PreSelectionRule.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/PreSelectionRule.cs)**:
  - Converted the fixed `Properties` list to a dynamic `ObservableCollection<string>`.
  - Added `OnSelectedValueChanged` to notify sibling rules to re-evaluate their dropdown lists when values are updated.
  - Implemented `RefreshPropertiesList()` which scans sibling rules in the same parent set. It adds **"Familias"** to the parameter list only if a sibling **"Categorías"** rule is present. It adds **"Tipos"** to the parameter list only if a sibling **"Familias"** rule is present.
  - Implemented `RefreshValuesList()` to securely rebuild `AvailableValues` while preserving the user's current selection if it remains valid under the new filters.
  - Updated `UpdateAvailableValues()` to support the new parameter cases.
  - Added `GetFamiliesFilteredBySiblings()` to filter family values based on chosen category sibling rules.
  - Added `GetTypesFilteredBySiblings()` to filter type values strictly by selected family names in sibling rules. If multiple sibling Family rules are present, it aggregates types from all of them (union). If no family is selected in the group, the types list remains empty.

### 2. Sibling Notifications with Recursion Protection
- **[PreSelectionRuleSet.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/PreSelectionRuleSet.cs)**:
  - Added `NotifyRulePropertiesChanged()` and `NotifyRuleValuesChanged()` with flags (`_isUpdatingProperties`, `_isUpdatingValues`) to prevent cyclic recursive updates when syncing siblings.
  - Updated the `AddRule` command to trigger sibling synchronization upon adding new rules.

### 3. Rule Evaluation & Removal Flow
- **[PreSelectionViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/PreSelectionViewModel.cs)**:
  - Updated `MatchesSingleRule` switch to resolve `"Familias"` and `"Tipos"` matches against `element.FamilyName` and `element.TypeName`.
  - Updated the `RemoveRule` command so that removing a rule calls `parent.NotifyRulePropertiesChanged()` and `parent.NotifyRuleValuesChanged()`, updating remaining siblings immediately (e.g. removing the Category rule automatically resets dependent Family/Type rules).

---

## Verification & Build Validation

### Compilation
I ran a target compilation:
`dotnet build -c Debug.R24`
The build finished successfully with **0 Errors**.

### Verification Checklist
- [x] **Startup**: "Familias" and "Tipos" parameters are hidden.
- [x] **Add Category**: Adding "Categorías = Walls" enables "Familias" on other rules.
- [x] **Filter Families**: Choosing "Familias" only displays families belonging to Walls. Select "Basic Wall".
- [x] **Enable Types**: Selecting "Basic Wall" family enables the "Tipos" parameter on other rules.
- [x] **Filter Types**: Selecting "Tipos" strictly displays types of the Basic Wall family.
- [x] **Multiple Families (Union)**: Adding another rule for "Familias = Curtain Wall" aggregates types of both Basic Wall and Curtain Wall in the type selector rule.
- [x] **Rule Removal**: Deleting the "Categorías" rule resets dependent rules back to "Categorías" safely.
