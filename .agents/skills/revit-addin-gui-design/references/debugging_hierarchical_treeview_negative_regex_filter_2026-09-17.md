# Debugging Log: Hierarchical TreeView Negative Regex Filter Cascading Contradiction

**Date:** 2026-09-17  
**Category:** WPF UI / TreeView / MVVM Filter Engine  
**Severity:** Critical (Filter Inversion Failure / Over-selection)  

---

## 1. Symptom

When applying a negative regular expression pattern (e.g. `^(?!.*dwg).*$` or any pattern with negative lookarounds `(?!` / `(?<!`) in an interactive hierarchical TreeView filter with parent-child tri-state propagation:
- The filter fails to isolate items omitting the forbidden keyword.
- Instead, **100% of all elements in the entire tree are selected simultaneously**, including elements that explicitly contain the forbidden keyword.

---

## 2. Root Cause

1. **Top-Down Cascading (`SetCheckedState(true)`):**
   In a hierarchical tree, Level 1 nodes are structural grouping containers (e.g. `"CAD Formats"`, `"Drafting Views"`, `"Views"`, `"Families"`, `"Sheets"`).
2. **Container Name vs Item Name Asymmetry:**
   Structural container names almost *never* contain the specific keyword being excluded (e.g. `"CAD Formats"` does not contain `"dwg"`).
3. When evaluating top-down:
   - `searchRegex.IsMatch("CAD Formats")` returns `true`.
   - The engine executes `node.SetCheckedState(true)` on the container.
   - `SetCheckedState(true)` cascades downwards and forcibly sets `IsChecked = true` on **every child, grandchild, and leaf item** (including `plano.dwg`).
   - Even though the subsequent recursive call on `plano.dwg` evaluates `match = false`, the child was already checked and is never unchecked.
   - Because all top-level category containers match the negative condition, all elements in the project end up checked.

---

## 3. Solution: Leaf-Only Bottom-Up Evaluation Engine

Negative regular expressions and exclusion filters in hierarchical trees **must never be evaluated top-down or cascade from container nodes**. They must strictly evaluate terminal leaf elements and propagate check states upwards (*Bottom-Up*):

```csharp
private void FilterTreeNegative(Regex searchRegex)
{
    // 1. Isolate true leaf nodes (excluding structural grouping containers)
    var allLeaves = GetAllDescendantNodes(RootNodes)
        .Where(n => n.Level > 0 && (n.Children == null || !n.Children.Any()) && n.Category != "Sheet" && n.Category != "View" && n.Category != "Root")
        .ToList();

    // 2. Evaluate each leaf node strictly
    foreach (var leaf in allLeaves)
    {
        bool match = searchRegex.IsMatch(leaf.Name);
        if (!match && !FilterOnlyNames)
        {
            match = searchRegex.IsMatch(leaf.Category);
            // ... check linked model items
        }

        if (match)
        {
            leaf.IsChecked = true;
            leaf.IsExpanded = true;
            ExpandParents(leaf);
        }
        else if (!FilterUseOr)
        {
            leaf.IsChecked = false;
        }
    }

    // 3. Propagate state bottom-up to all parent containers
    foreach (var root in RootNodes)
    {
        root.RefreshState();
    }
}
```

### Result:
- Leaf items containing `"dwg"` remain `false`.
- Leaf items omitting `"dwg"` become `true`.
- Parent containers execute `RefreshState()`, setting their state to `true` (all match), `false` (none match), or `null` (indeterminate/tri-state) without overriding child selections.
