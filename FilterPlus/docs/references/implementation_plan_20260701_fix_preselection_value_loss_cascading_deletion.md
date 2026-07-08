# Bug Fix: Pre-Selection Rule Value Retention and Detailed Logging

This plan addresses the bug where adding a new rule or selecting a family causes existing category/family selections to revert to their default first values. It also introduces comprehensive logging to the FilterPlus Debug Log window.

## Root Cause Analysis
1. **Properties List Refresh**: When a rule is added or modified, `NotifyRulePropertiesChanged()` calls `RefreshPropertiesList()` on sibling rules to dynamically add or remove `"Familias"` and `"Tipos"` parameters.
2. **Missing Guard on SelectedProperty**: During `RefreshPropertiesList()`, we call `Properties.Clear()`. This causes WPF's ComboBox to push `null` back to the ViewModel's `SelectedProperty`.
3. **Cascading Reset**: Because we did *not* check the `_isUpdatingProperties` guard inside `OnSelectedPropertyChanged(string value)`, the VM executed `OnSelectedPropertyChanged(null)`. This cleared `AvailableValues` and set `SelectedValue` to `null` (wiping out the chosen Category/Family value) before refilling the properties list.
4. **Incorrect Restoration**: The selection was lost permanently because the property change handler had already reset the values.

## Solution
1. **Add Property Guard**: Add `if (_isUpdatingProperties) return;` at the top of `OnSelectedPropertyChanged()`. This completely ignores the temporary `null` pushbacks from WPF when the properties list is being rebuilt.
2. **Synchronous Updates**: Revert the asynchronous `Dispatcher.InvokeAsync` calls back to stable synchronous updates, since the guards now fully protect the selections from being wiped out.
3. **Comprehensive Logging**: Add detailed step-by-step logs using `LoggerService.LogInfo` to output execution trace information to the Debug Log window, allowing real-time monitoring of rule changes.

---

## Proposed Changes

### Pre-Selection Rules

#### [MODIFY] [PreSelectionRule.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/PreSelectionRule.cs)

- Implement `if (_isUpdatingProperties) return;` guard at the top of `OnSelectedPropertyChanged()`.
- Add detailed logs showing current property, value, list counts, and early exits to all methods.
- Revert all dispatcher calls to synchronous execution.

#### [MODIFY] [PreSelectionRuleSet.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/PreSelectionRuleSet.cs)

- Add logs inside `PruneDependentRules()`, `NotifyRulePropertiesChanged()`, `NotifyRuleValuesChanged()`, `AddRule()`, and `AddSet()`.

---

## Verification Plan

### Manual Verification
1. **Debug Log Verification**: Open the Pre-Selection window and open the Debug Log.
2. Add a rule: select **Categorías = Walls**. Verify log shows rule created and value set.
3. Add a second rule. Verify the first rule's category and value remain **Walls** (no `null` property changes should be logged or executed for the first rule).
4. Change the second rule to **Familias**. Select **Basic Wall**. Verify logs show category and family values are preserved.
5. Add a third rule. Set to **Tipos = Generic 200mm**. Verify all rules are stable and logs trace successful checks.
