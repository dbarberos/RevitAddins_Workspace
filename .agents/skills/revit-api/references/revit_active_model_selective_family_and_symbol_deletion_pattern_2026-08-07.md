# Technical Reference: Selective Active Model Family & Type Deletion Pattern in Revit API

**Date:** 2026-08-07  
**Target Skills:** `revit-api`, `revit-transactions`, `revit-addin-helpers`  
**Domain:** Revit API / Active Model Element Deletion / Selective Symbol vs Family Removal / Conditional Commands  

---

## 📌 Problem Overview & Rules

When implementing element deletion from the Revit active model explorer:
1. **Source Restriction:** Deletion MUST only be enabled for **Active Open Models** (`Adoc != null` and `EsVinculo == false`). Custom sources (Local Folders, Azure Storage, Autodesk Docs) and Linked Models (`EsVinculo == true`) cannot be mutated directly in the Revit session.
2. **Selective Deletion Logic:**
   - If ALL types of a family are checked (or the family node itself is selected): Delete the entire `Family` (`doc.Delete(family.Id)`).
   - If ONLY SOME types are checked: Delete only the specific `FamilySymbol` elements (`doc.Delete(symbol.Id)`). The `Family` definition and unchecked types remain intact.
3. **Placed Instance Impact Warning:** Deleting a `Family` or `FamilySymbol` removes all placed `FamilyInstance` elements of those types from active views and geometry.

---

## 🛠️ Implementation Architecture

### 1. Conditional Command Enablement (`CanDeleteSelectedFamilies`)
```csharp
private bool CanDeleteSelectedFamilies()
{
    if (!IsFamiliesManagerActive) return false;
    if (SelectedSourceDocument == null) return false;
    if (SelectedSourceDocument.Adoc == null) return false; // Exclude Custom Sources (Folders, Azure, ACC)
    if (SelectedSourceDocument.EsVinculo) return false;     // Exclude Linked Models
    if (SelectedSourceDocument.Adoc.IsReadOnly) return false;

    // Verify at least one family or symbol node is checked in tree
    var checkedFamilyNodes = GetAllDescendantNodes(RootNodes)
        .Where(n => (n.IsChecked == true || n.IsChecked == null) && (n.Category == "Family" || n.Item is FamilyItemModel));

    if (checkedFamilyNodes.Any()) return true;

    return SelectedFamily != null;
}
```

### 2. Transactional Deletion & Tree Refresh
```csharp
[RelayCommand(CanExecute = nameof(CanDeleteSelectedFamilies))]
private async Task DeleteSelectedFamiliesAsync()
{
    if (SelectedSourceDocument == null || SelectedSourceDocument.Adoc == null || SelectedSourceDocument.EsVinculo)
        return;

    var doc = SelectedSourceDocument.Adoc;

    // English confirmation warning
    string warningMessage = $"You are about to delete {fullFamiliesCount} family(ies) and {partialTypesCount} type(s) from the active model.\n\n" +
                            "Warning: Deleting families or types will also permanently remove any placed instances of these elements from the active document.\n\n" +
                            "Do you want to proceed with the deletion?";

    var confirmResult = System.Windows.MessageBox.Show(
        warningMessage,
        "Confirm Element Deletion",
        System.Windows.MessageBoxButton.YesNo,
        System.Windows.MessageBoxImage.Warning);

    if (confirmResult != System.Windows.MessageBoxResult.Yes) return;

    using (var t = new Transaction(doc, "Delete Families and Types"))
    {
        t.Start();

        foreach (var (familyModel, revitFamily, deleteAllTypes, selectedSymbols) in familiesToDelete)
        {
            if (deleteAllTypes)
            {
                // Delete entire Family
                doc.Delete(revitFamily.Id);
            }
            else
            {
                // Delete only specific FamilySymbol (types)
                foreach (var symModel in selectedSymbols)
                {
                    var symbolElem = new FilteredElementCollector(doc)
                        .OfClass(typeof(FamilySymbol))
                        .Cast<FamilySymbol>()
                        .FirstOrDefault(s => s.Family.Id == revitFamily.Id && s.Name.Equals(symModel.Name, StringComparison.OrdinalIgnoreCase));

                    if (symbolElem != null)
                    {
                        doc.Delete(symbolElem.Id);
                    }
                }
            }
        }

        t.Commit();
    }

    // Refresh tree view to reflect active model updates
    await LoadFamiliesFromSourceAsync(SelectedSourceDocument.Nombre);
}
```

---

## 📋 Best Practices Matrix

| Scenario | Action | Revit Result |
| :--- | :--- | :--- |
| **All Types Checked** | `doc.Delete(family.Id)` | Deletes family, all types, and placed instances. |
| **Some Types Checked** | `doc.Delete(symbol.Id)` | Deletes selected types and their instances. Family and unchecked types stay. |
| **Linked / External Sources** | Command Disabled (`CanExecute = false`) | Prevents invalid mutation attempts on read-only/external sources. |
