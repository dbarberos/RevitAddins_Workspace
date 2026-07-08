# Debugging Lesson Learned: WPF IsBulkUpdating Scope Block (2026-06-30)

## Symptom
When the user applied a Pre-Selection Rule filter, the internal scope was updated (e.g., from "Elements in View" to "All Model Elements"), but the main UI TreeView explorer did not rebuild to reflect the new scope. The `ApplyPreSelection` logic executed perfectly and output logs, but the visual tree was stale. 

## Root Cause
In `SelectionFilterViewModel.cs`, the `OnCurrentScopeChanged` method handles the scope switch and triggers `RebuildTree()`. However, `OnCurrentScopeChanged` began with an early exit check:
```csharp
if (TreeItemViewModel.IsBulkUpdating) return;
```
When `ApplyPreSelection` was executed, it initiated bulk selection updates which set `TreeItemViewModel.IsBulkUpdating = true` to prevent UI freezing during node checking.
If the applied pre-selection required a scope change (which fires the `CurrentScope` setter, thereby invoking `OnCurrentScopeChanged`), the scope change logic would instantly return without doing anything because `IsBulkUpdating` was still `true`. High-level UI commands (like changing the entire data scope and rebuilding the tree) were being incorrectly suppressed by a flag designed only to suppress repetitive child-node property changed events.

## Solution
1. Removed the `if (TreeItemViewModel.IsBulkUpdating) return;` check from the start of `OnCurrentScopeChanged`. 
2. **Key Design Rule**: Changing the data scope is a foundational UI state change that must always succeed. It should never be blocked by a bulk updating lock intended solely for looping through child nodes.
3. This guarantees that `RebuildTree()` will execute and the tree will visually reflect the selected items in the correct scope.
