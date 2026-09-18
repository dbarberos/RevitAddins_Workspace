# Debugging & Pattern: Leaf-Only Element Deletion & Hierarchical Safety Confirmation Dialog

## Info
* **Date:** 2026-09-14
* **Component:** `ConfirmCadDeleteWindow.xaml` / `CadDeleteCandidateModel.cs` / `TransferPlusViewModel.cs`
* **Skill Target:** `revit-addin-gui-design`, `revit-api`
* **Technology:** WPF HierarchicalDataTemplate / TreeView Tri-State Checkboxes / Revit Element Deletion

---

## 1. Symptom & Bug Description
In a Revit add-in asset explorer organized hierarchically (e.g. `Sort by Sheet` -> `Sheet` -> `View` -> `CAD Links / Imports / Detail Items`), invoking the **Delete** button when managing active project content caused unexpected cascade deletions:
* Instead of deleting only the selected or checked CAD import/link, the parent **Sheet** (`ViewSheet`) and parent **View** (`View`) containing the item were also permanently deleted from the Revit project database.
* Any other unrelated drawings, viewports, or titleblocks placed on that sheet were completely lost.

---

## 2. Root Cause

1. **WPF TreeView Tri-State Checkbox Bubbling**:
   When all children under a parent node are checked (or when a user checks a parent node directly), WPF tri-state checkbox logic automatically sets `parent.IsChecked = true`.
2. **Intermediate Node `ElementId` Assignment**:
   When building hierarchical trees, intermediate group nodes (such as the Sheet group node or the View group node) were assigned model instances holding the `ElementId` of the parent `ViewSheet` or `View`.
3. **Unfiltered Deletion Collection**:
   The collection routine gathered all checked nodes indiscriminately:
   ```csharp
   // BUGGY PATTERN:
   var itemsToDelete = GetAllDescendantNodes(RootNodes)
       .Where(n => n.IsChecked == true && n.Item != null)
       .Select(n => n.Item.ElementId);
   doc.Delete(itemsToDelete); // DELETES BOTH PARENT SHEETS/VIEWS AND LEAF ITEMS!
   ```
   Passing a `ViewSheet.Id` or `View.Id` to `Document.Delete()` causes Revit to delete the container and all hosted elements.

---

## 3. Architectural Solution

### A. Immutable Leaf-Only Filtering Pattern
Enforce an immutable check preventing any non-leaf or container category node from entering the deletion candidate list:
```csharp
private List<CadDetailItemModel> CollectCheckedCadItems()
{
    var checkedLeaves = new List<CadDetailItemModel>();
    foreach (var node in GetAllDescendantNodes(CadTreeRootNodes))
    {
        // STRICT FILTER: Ignore any grouping / container node
        if (node.Children.Count > 0) continue;
        if (node.Category == "Sheet" || node.Category == "View" || node.Category == "Root") continue;

        if (node.IsChecked == true && node.Item != null)
        {
            checkedLeaves.Add(node.Item);
        }
    }
    return checkedLeaves;
}
```

### B. Hierarchical Safety Confirmation Dialog (`ConfirmCadDeleteWindow.xaml`)
Before executing any destructive action in the active model, open a dedicated modal confirmation window showing the full hierarchy and explicitly distinguishing preserved containers from deletion targets:

1. **Hierarchy DTOs (`CadDeleteCandidateModel.cs`)**:
   ```csharp
   public class CadDeleteSheetGroup
   {
       public string SheetName { get; set; }
       public bool IsPreserved => true; // "Will be kept in project"
       public ObservableCollection<CadDeleteViewGroup> Views { get; set; }
   }

   public class CadDeleteViewGroup
   {
       public string ViewName { get; set; }
       public bool IsPreserved => true; // "Will be kept in project"
       public ObservableCollection<CadDeleteItemNode> Items { get; set; }
   }

   public class CadDeleteItemNode
   {
       public string Name { get; set; }
       public string Category { get; set; }
       public ElementId ElementId { get; set; }
       // Multi-version compatibility (Revit 2024-2027)
       public long RawId => ElementId.Value;
   }
   ```

2. **Visual Hierarchy Indicators**:
   * **Sheets & Views**: Rendered with green badges:
     `<TextBlock Text="[Will be kept in project]" Foreground="#107C41" FontWeight="SemiBold"/>`
   * **Leaf Elements**: Rendered with high-visibility red badges and Element ID:
     `<TextBlock Text="[To be deleted]" Foreground="#D83B01" FontWeight="Bold"/>`
     `<TextBlock Text="{Binding RawId, StringFormat='(ID: {0})'}" Foreground="#666666"/>`

3. **Atomic Execution & Tree Refresh**:
   If confirmed, collect only the leaf `ElementId`s and execute inside a single Revit `Transaction`:
   ```csharp
   using (var t = new Transaction(doc, "Delete CAD Details"))
   {
       t.Start();
       doc.Delete(elementIdsToDelete);
       t.Commit();
   }
   SelectedCadDetail = null;
   LoadCadItemsFromSource(doc); // Rebuild explorer tree
   ```
