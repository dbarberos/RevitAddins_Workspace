# Architectural Blueprint: Pre-Selection Rules Builder (Recursive MVVM)

## Overview
The Pre-Selection Rules Builder is a C# MVVM implementation that mirrors the Autodesk Revit Filter Rules dialog. It allows users to build nested logical groupings (AND/OR) of selection criteria to filter Revit elements.

## 1. Core Data Models (Composite Pattern)
The structure relies on the **Composite Design Pattern**, enabling recursive nesting of rules and sets.

- **`IPreselRuleNode`**: The base interface that both rules and sets implement. This allows the WPF `ItemsControl` to iterate over a unified collection.
- **`PreSelectionRule` (Leaf)**: Represents a single condition (e.g., Category = "Walls"). Contains the `SelectedProperty` and `SelectedValue`.
- **`PreSelectionRuleSet` (Composite)**: Represents a logical operator (AND/OR). It contains an `ObservableCollection<IPreselRuleNode> Children`.

## 2. Dynamic Sorting in ObservableCollections
To maintain a clean UI where individual rules are always clustered at the top of a set and sub-sets are always placed at the bottom, an insertion logic is applied upon adding new nodes:

```csharp
public void AddNode(IPreselRuleNode node)
{
    if (node is PreSelectionRule rule)
    {
        // Insert exactly after the last existing rule
        int index = Children.Count(c => c is PreSelectionRule);
        Children.Insert(index, rule);
    }
    else if (node is PreSelectionRuleSet set)
    {
        // Append sets to the end
        Children.Add(set);
    }
}
```

## 3. WPF UI Design Patterns
### Vector Graphics over Emojis for Critical Icons
To guarantee that delete icons (`❌` or `—`) render in a consistent premium red color across all Windows environments (avoiding Segoe UI Emoji falling back to black wireframes), standard `Content="X"` was replaced with WPF vector shapes inside transparent, borderless `Button` templates.

**Vector Dash (Rule Deletion):**
```xml
<Border Height="3" Width="12" CornerRadius="1.5" Background="#d9534f" />
```

**Vector X (Set Deletion):**
```xml
<Path Data="M0,0 L10,10 M0,10 L10,0" Stroke="#d9534f" StrokeThickness="3" StrokeEndLineCap="Round" StrokeStartLineCap="Round" />
```
These vectors sit inside a `<Grid Background="Transparent">` to ensure the clickable hit-box is larger than the thin paths.

## 4. Evaluation Engine Integration
The `PreSelectionViewModel` contains a recursive evaluation engine:
- `MatchesSet(element, set)` iterates over `set.Children`. If AND, returns false on first mismatch. If OR, returns true on first match.
- `MatchesNode(element, node)` routes to either `MatchesSingleRule` or `MatchesSet`.
This recursively processes any depth of user-defined Revit filters against pre-extracted `ElementModel` instances.

## 5. Dynamic Scope Toggling & Main View Synchronization
To allow users to switch the element evaluation scope before applying filters, the window includes two mutually exclusive checkboxes ("All Model Elements" and "Elements in View").

### 5.1 Mutual Exclusivity VM Pattern
A recursion guard is used inside property change handlers to ensure only one checkbox is active, preventing infinite binding update loops:
```csharp
partial void OnIsAllModelElementsChanged(bool value)
{
    if (_isUpdatingScope) return;
    _isUpdatingScope = true;
    try
    {
        if (value) IsElementsInView = false;
        else if (!IsElementsInView) IsAllModelElements = true; // Prevent unchecking both
    }
    finally { _isUpdatingScope = false; }
}
```

### 5.2 Recursive Element Propagation
When the scope is toggled, the elements cache is pushed down the tree to refresh dropdowns:
- **`IPreselRuleNode`**: Declares `void UpdateElements(IEnumerable<ElementModel> elements)`.
- **`PreSelectionRuleSet`**: Updates its local cache and loops children: `child.UpdateElements(elements)`.
- **`PreSelectionRule`**: Updates its local cache, runs `UpdateAvailableValues()`, and preserves the active `SelectedValue` if still present in the new set, falling back to `FirstOrDefault()` if not.

### 5.3 Deferred Synchronization on Apply
No state is pushed to the main UI until the user clicks **Apply**. At that point:
1. The rules are evaluated over the selected scope to produce a `HashSet<ElementId>` of matching IDs.
2. The main ViewModel's `_persistentCheckedIds` is updated with this set.
3. The main `CurrentScope` is synchronized to trigger a synchronous tree rebuild for the matching elements.
4. If the target scope is already active, `BuildTree()` is called explicitly to refresh tree state.
