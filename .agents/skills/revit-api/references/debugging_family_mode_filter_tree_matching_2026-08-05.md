# Technical Debugging: Family Mode Filter & Search Integration

## 📌 Context & Problem Statement
In **TransferPlus** (Family Mode), the right-hand **Filter** card allows filtering elements in the TreeView by text input. However, in Family Mode, tree nodes represent:
- Level 1: Container / Source Name (e.g. `"Active Model: P.VACIO"`, `"Local Folder"`)
- Level 2: Category Name (e.g. `"Puertas"`, `"Ventanas"`)
- Level 3: Family Item (`FamilyItemModel`)
- Level 4: Family Symbol / Type (`FamilySymbolItemModel`)

Previously, searching for a specific type name (Level 4) or family/category name in Family Mode did not automatically expand parent nodes to reveal the matching checked types to the user.

---

## 🛠️ Root Cause & Technical Fix

1. **Item Type Pattern Matching (`FilterNode`):**  
   Added support for `FamilySymbolItemModel` nodes at Level 4, checking `symItem.Name` and `symItem.FamilyName`.
2. **Auto-Expansion of Matched Paths (`ExpandParents`):**  
   When a node matches the filter query (by family name, type name, category, or version), `FilterNode` sets `node.IsExpanded = true` and recursively calls `ExpandParents(node)` up to the root node (`allNode`), ensuring matched items are immediately visible in the WPF TreeView.
3. **Selection Synchronization:**  
   `FilterNode` sets `node.SetCheckedState(true)` on matched nodes, which triggers `UpdateCheckedCount()`, updating the bottom counter and enabling transfer buttons for the matched selection.

```csharp
if (match)
{
    node.SetCheckedState(true);
    node.IsExpanded = true;
    ExpandParents(node);
}

private void ExpandParents(TreeItemViewModel node)
{
    var parent = node.Parent;
    while (parent != null)
    {
        parent.IsExpanded = true;
        parent = parent.Parent;
    }
}
```

---

## ✅ Verification
- Compiles with **0 Errores**.
- Testing in Family Mode: Typing a type name (e.g. `"90cm"`), family name, or category name checks matching items and expands parent folders down to the matched node.
