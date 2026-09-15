# Debugging Log: CAD Mode Rename Panel "No elements checked for renaming"

**Date:** 2026-09-15  
**Component:** `TransferPlus` (`TransferPlusViewModel`, `RenamePreviewItem`, `FamilyRevitService`)  
**Target Skill:** `csharp-blueprints`  

---

## 1. Symptom

In `TransferPlus` CAD Mode (`IsCadDetailsManagerActive = true`), with CAD elements or drafting views checked in the explorer tree, clicking the **"Apply"** button in the **"Rename:"** card showed an error dialog with the message:
`"No elements checked for renaming."`
The PowerRename palette did not open, and checked CAD items could not be renamed.

---

## 2. Root Cause

`TransferPlus` contains three distinct operating modes (`Standard Element Mode`, `Family Mode`, `CAD Mode`).
When `OpenRenamePanelCommand` was invoked:
1. `OpenRenamePanel()` only had two branches:
   ```csharp
   if (IsFamiliesManagerActive) { ... }
   else
   {
       var checkedItems = new List<Elemento>();
       CollectCheckedItems(RootNodes, checkedItems);
       if (!checkedItems.Any())
       {
           TaskDialog.Show("TransferPlus", "No elements checked for renaming.");
           return;
       }
       ...
   }
   ```
2. In CAD Mode, `IsFamiliesManagerActive` is `false`, so execution fell into the `else` branch.
3. `CollectCheckedItems(RootNodes, checkedItems)` checks `node.Item is Elemento`. Because the nodes in CAD mode wrap `CadDetailItemModel`, `checkedItems` was always empty.
4. Consequently, `!checkedItems.Any()` was true, popping the error dialog.
5. Furthermore, `UpdateCheckedCount()` lacked CAD synchronization for `RenamePreviewItems`, and `TransferCommand` in CAD mode did not apply renamed names during element creation or copy.

---

## 3. Resolution

1. **Model Extension (`RenamePreviewItem.cs`)**:
   - Added `CadIdentifier` and `CadItem` properties.
   - Added constructor `RenamePreviewItem(CadDetailItemModel cadItem, string cadIdentifier)`.

2. **ViewModel Multi-Mode Segregation (`TransferPlusViewModel.cs`)**:
   - Added `GetCadIdentifier(CadDetailItemModel cad)` to generate unique keys and avoid dictionary collisions.
   - Updated `OpenRenamePanel()` with an explicit `if (IsCadDetailsManagerActive)` branch calling `CollectCheckedCadItems()`.
   - Updated `UpdateCheckedCount()` with real-time CAD synchronization so checking/unchecking items in the tree dynamically reflects in `RenamePreviewItems`.
   - In `OnIsFamiliesManagerActiveChanged` and `OnIsCadDetailsManagerActiveChanged`, invoked `CloseRenamePanel()` to cleanly isolate state when switching modes.
   - In `TransferCommand`, extracted `cadCustomNames` and `cadRenameMap` to propagate modified names to `FamilyRevitService` and `ICadProvider`.

3. **Revit Transfer Service (`FamilyRevitService.cs`)**:
   - Extended `TransferDraftingViews(...)` and `TransferCadInstancesToDraftingViews(...)` to accept `Dictionary<ElementId, string>? customNames = null` and rename copied/created drafting views.

---

## 4. Key Code Pattern

```csharp
// Multi-mode check in OpenRenamePanel
if (IsCadDetailsManagerActive)
{
    var checkedCadItems = new List<CadDetailItemModel>();
    CollectCheckedCadItems(RootNodes, checkedCadItems);

    if (!checkedCadItems.Any())
    {
        TaskDialog.Show("TransferPlus", "No elements checked for renaming.");
        return;
    }

    var processedIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    foreach (var item in checkedCadItems)
    {
        string id = GetCadIdentifier(item);
        if (processedIds.Add(id))
        {
            var pItem = new RenamePreviewItem(item, id);
            pItem.PropertyChanged += PreviewItem_PropertyChanged;
            RenamePreviewItems.Add(pItem);
        }
    }
}
else if (IsFamiliesManagerActive)
{
    // Family mode collection
}
else
{
    // Standard Elemento mode collection
}
```
