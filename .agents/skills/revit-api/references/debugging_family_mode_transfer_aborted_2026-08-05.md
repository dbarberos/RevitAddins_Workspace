# Debugging Report: Family Mode Transfer Aborted & Strict Checkbox Selection Rule

**Date:** 2026-08-05  
**Domain:** Revit API / Family Mode vs Standard Elements Mode / Strict Checkbox Selection  
**Target Skill:** `revit-api`  

---

## 🔴 Symptom & UX Requirement
In Family Mode (`IsFamiliesManagerActive = true`), clicking a family card in the TreeView is intended purely for inspecting card details in the right-hand panel ("Family Details").

If a user clicks on a family row to consult it, it MUST NOT be implicitly included for transfer. Only families with an **explicitly checked checkbox** (`node.IsChecked != false`) are included in the transfer queue.

---

## 🟢 Resolution Pattern

In `Transfer()`, collect ONLY families with marked checkboxes:

```csharp
if (IsFamiliesManagerActive)
{
    var checkedFamilies = new List<FamilyItemModel>();
    CollectCheckedFamilies(RootNodes, checkedFamilies);

    if (!checkedFamilies.Any())
    {
        TransferPlus.Services.LoggerService.LogInfo("Transfer: Operation aborted. No families have their checkbox marked for transfer.");
        TaskDialog.Show("TransferPlus", "No items selected to transfer. Please check the checkbox of the families you wish to transfer.");
        return;
    }

    // Resolve IFamilyProvider and transfer checked items
    ...
    return;
}
```
