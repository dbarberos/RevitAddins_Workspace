# ✅ Efficient Construction of TreeView with Thousands of Nodes without Blocking the UI

When building a large tree (`TreeView` with hundreds or thousands of nodes):

1. **Build the complete structure in memory** (`TreeItemViewModel` offline) before modifying the `ObservableCollection`.
2. **Perform a single atomic swap at the end**: `RootNodes.Clear(); RootNodes.Add(root);`
3. **Use a static flag `IsBulkUpdating`** to suppress the triggering of `SelectionChanged` / `PropertyChanged` during massive construction to avoid "event storms".
4. **Call `RefreshState()` bottom-up at the end** to correctly propagate the state of parent/child checkboxes.

```csharp
// ✅ CORRECT: build offline, insert in a single atomic swap
TreeItemViewModel.IsBulkUpdating = true;
try
{
    var root = new TreeItemViewModel("All", null, 0, callback);
    // ... build the entire tree in 'root' without modifying RootNodes ...
    RootNodes.Clear();      // a single Clear
    RootNodes.Add(root);    // a single Add – a single notification to WPF
}
finally
{
    foreach (var node in RootNodes) node.RefreshState(); // propagate checkboxes
    TreeItemViewModel.IsBulkUpdating = false;
}

// ❌ INCORRECT: adding nodes one by one triggers hundreds of UI updates
foreach (var item in allItems)
    RootNodes.Add(new TreeItemViewModel(item, ...)); // 💥 event storm
```
