# Dynamic Family and Type Rules in Pre-Selection

This plan implements dynamic parameter rules inside the Pre-Selection query builder:
- Adds **"Familias"** and **"Tipos"** to the parameter selection list.
- **"Familias"** will only be selectable if there is already a **"Categorías"** rule in the same logical group.
- **"Tipos"** will only be selectable if there is already a **"Familias"** rule in the same logical group.
- Restricts selectable values in the second ComboBox:
  - If a **"Categorías"** rule is set, the families list in sibling rules is filtered to only show families belonging to that category.
  - If one or more **"Familias"** rules are set, the types list in sibling rules is filtered to strictly show types belonging to the selected family/families (union of types if multiple families are selected).

## User Review Required

> [!NOTE]
> Sibling relationships are defined within the same nesting level (same **AND** / **OR** set). For a rule to see another rule as a sibling, they must belong to the same rule group. This keeps the rule lists scoped to their logical context.

## Proposed Changes

### Pre-Selection Query Builder

---

#### [MODIFY] [PreSelectionRule.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/PreSelectionRule.cs)

- Change `Properties` from a static `List<string>` to a dynamic `ObservableCollection<string>`.
- Add `OnSelectedValueChanged` partial method to notify siblings to update their value dropdowns when a rule selection changes.
- Implement `RefreshPropertiesList()` to:
  - Gather sibling properties.
  - Add `"Familias"` only if `hasCategorySibling` is true.
  - Add `"Tipos"` only if `hasFamilySibling` is true.
  - Reset to `"Categorías"` if the current selection is no longer valid.
- Implement `RefreshValuesList()` to safely update `AvailableValues` preserving the current selection if it remains valid.
- Modify `UpdateAvailableValues()` to:
  - Add cases for `"Familias"` and `"Tipos"`.
  - Filter families based on sibling Category values.
  - Filter types based strictly on sibling Family values.
- Implement helper methods `GetFamiliesFilteredBySiblings()` and `GetTypesFilteredBySiblings()`.
  - `GetTypesFilteredBySiblings()` collects all selected family names from sibling rules in the same set, then selects types from `_allElements` whose `FamilyName` is present in that set.

#### [MODIFY] [PreSelectionRuleSet.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/PreSelectionRuleSet.cs)

- Implement recursion-safe methods:
  - `NotifyRulePropertiesChanged()` to refresh properties lists for all children.
  - `NotifyRuleValuesChanged()` to refresh values lists for all children.
- Call `NotifyRulePropertiesChanged()` when adding a rule or set.

#### [MODIFY] [PreSelectionViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/PreSelectionViewModel.cs)

- Update `MatchesSingleRule` switch block to evaluate `"Familias"` and `"Tipos"` rules against element data:
  - `"Familias"` => `element.FamilyName`
  - `"Tipos"` => `element.TypeName`
- Update `RemoveRule` command in `PreSelectionViewModel` to trigger `parent.NotifyRulePropertiesChanged()` after removal.

---

## Verification Plan

### Manual Verification
1. **Rule Parameter Check**: Open Pre-Selection. The first parameter list should *not* show "Familias" or "Tipos" (only Categorías, Niveles, etc. are available).
2. **Enable Family**: Add a rule for **"Categorías" = Walls**. Add a second rule. The second parameter ComboBox should now expose **"Familias"** (but *not* "Tipos").
3. **Filter Families**: Select **"Familias"** in the second rule. The values ComboBox should only show families belonging to **Walls** category (e.g. Basic Wall, Curtain Wall). Select **Basic Wall**.
4. **Enable Type**: Add a third rule. The third parameter ComboBox should now expose both **"Familias"** and **"Tipos"**.
5. **Filter Types**: Select **"Tipos"** in the third rule. The values ComboBox should strictly show types belonging to **Basic Wall** family.
6. **Union of Types**: Add another rule. Select **"Familias" = Curtain Wall**. In the "Tipos" rule, verify that the selectable types now include types from *both* **Basic Wall** and **Curtain Wall**.
7. **Delete Family Sibling**: Delete the Family rule. The "Tipos" rule should automatically disappear or reset to "Categorías".
8. **Execution**: Apply the rules and verify the checked items match perfectly.
