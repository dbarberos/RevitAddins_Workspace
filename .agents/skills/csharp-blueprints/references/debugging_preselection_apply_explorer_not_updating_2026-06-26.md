# Debugging Log: Pre-Selection Apply Button Not Updating Tree Explorer

## Symptom
When the user configured rules in the **Filter Rules** (Pre-Selection) window and clicked **"Apply"**, the dialog closed and the correct scope ("All Model Elements" or "Elements in View") was selected in the main window's **"Select"** card. However, the tree explorer did not refresh or check the elements matching the pre-selection rules.

## Root Cause
The `ApplyPreSelection` method in `SelectionFilterViewModel.cs` wrapped its operation in a bulk update lock:
```csharp
TreeItemViewModel.IsBulkUpdating = true;
try
{
    _persistentCheckedIds = matchingIds;
    CurrentScope = targetScope;
}
...
```
Setting `CurrentScope` triggers the `OnCurrentScopeChanged` property change handler. However, the first check inside `OnCurrentScopeChanged` is:
```csharp
partial void OnCurrentScopeChanged(SelectionScope value)
{
    if (TreeItemViewModel.IsBulkUpdating) return; // <--- Exits early!
    ...
}
```
Because `IsBulkUpdating` was set to `true`, the scope change handler aborted immediately, preventing the tree structure from being rebuilt for the new scope.

Additionally, if the user applied a pre-selection filter with the same scope that was already active (e.g. they were already in "All Model Elements" and ran the filter on "All Model Elements"), the `CurrentScope` setter did not fire a property-changed event, meaning the tree was never rebuilt to reflect the updated `_persistentCheckedIds` list.

## Solution
1. **Remove the Bulk Update Lock in `ApplyPreSelection`**: Let `BuildTree()` handle its own `IsBulkUpdating` lifecycle internally, allowing `OnCurrentScopeChanged` to execute cleanly.
2. **Force Rebuild on Scope Equality**: Check if the target scope is already active. If it is, call `BuildTree()` explicitly; otherwise, assign `CurrentScope = targetScope` to let the property change handler trigger it.

### Refactored Method:
```csharp
public void ApplyPreSelection(HashSet<Autodesk.Revit.DB.ElementId> matchingIds, SelectionScope targetScope)
{
    try
    {
        LoggerService.LogInfo($"[ApplyPreSelection] Applying matching IDs: {matchingIds.Count} on scope: {targetScope}");

        _persistentCheckedIds = matchingIds;
        CheckedElementsCount = _persistentCheckedIds.Count;

        if (CurrentScope == targetScope)
        {
            BuildTree();
        }
        else
        {
            CurrentScope = targetScope;
        }
    }
    catch (Exception ex)
    {
        LoggerService.LogError("ApplyPreSelection", ex);
    }
}
```
