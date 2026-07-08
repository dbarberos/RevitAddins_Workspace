# Debugging Log: WPF Tree Rebuild Blocked by Bulk Update Flag on Scope Changes

## Symptom
When clicking the "Apply" button in the Pre-Selection scope filtering window, the scope changed on the main "Select" card (e.g. from `CurrentSelection` to `AllModelElements`), but the TreeView explorer on the left failed to rebuild or show the elements matching the new scope. Additionally, the logged checked elements count reverted to the previous count.

## Root Cause
1. **Property Change Suppression:** In `SelectionFilterViewModel.cs`, the partial method `OnCurrentScopeChanged(SelectionScope value)` checked the bulk update suppression flag:
   ```csharp
   if (TreeItemViewModel.IsBulkUpdating) return;
   ```
   If this flag was evaluated as `true` (e.g. from a previous background layout/tree operation or incomplete cleanup), the entire scope change handler was aborted.
2. **Design Mismatch:** The `IsBulkUpdating` flag is meant to suppress recursive checked/unchecked storms on child/parent nodes during batch selections. It should never block high-level, explicit UI scope changes like switching from "Current Selection" to "All Model Elements", as these rebuild the tree entirely from scratch anyway.
3. **Selection Reversion:** Because `OnCurrentScopeChanged` was bypassed, `BuildTree()` did not run. The UI then triggered layout/focus updates that called `OnTreeSelectionChanged`, which read the checked state from the old, un-rebuilt tree explorer and restored the checked IDs of the previous scope.

## Solution
Removed the `TreeItemViewModel.IsBulkUpdating` early-return check from `OnCurrentScopeChanged` entirely, ensuring that whenever a scope changes, the tree is guaranteed to rebuild from the pre-fetched data.

### Corrected Code in `SelectionFilterViewModel.cs`
```csharp
partial void OnCurrentScopeChanged(SelectionScope value)
{
    // NO IsBulkUpdating check here – always allow scope change to rebuild the tree
    try
    {
        LoggerService.LogInfo($"Scope switched to: {value}. Rebuilding tree from pre-fetched data...");

        _activeElements = value switch
        {
            SelectionScope.CurrentSelection => _currentSelectionElements,
            SelectionScope.ElementsVisibleInView => _elementsVisibleInViewElements,
            SelectionScope.ElementsBelongingToView => _elementsBelongingToViewElements,
            SelectionScope.AllModelElements => _allModelElements,
            _                               => _currentSelectionElements
        };

        LoggerService.LogInfo($"Active elements for scope {value}: {_activeElements.Count}");
        BuildTree();
    }
    catch (Exception ex)
    {
        LoggerService.LogError("OnCurrentScopeChanged", ex);
    }
}
```
