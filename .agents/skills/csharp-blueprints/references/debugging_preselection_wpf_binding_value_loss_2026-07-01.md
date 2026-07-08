# Debugging Log: WPF ComboBox Binding Value Loss, Cascading Deletions, and Logging in Pre-Selection Rules

## Symptom
When the user created pre-selection rules:
1. **Value Loss**: Adding a new rule or modifying sibling rules (e.g., from Categorías to Familias) cleared the chosen selections of existing rules (e.g., Categorías reset to the first default value).
2. **Initial Empty List**: On opening the "Filter Rules" window, the first rule's property was set to `"Categorías"`, but its value dropdown remained empty, requiring the user to switch to another property (e.g., `"Niveles"`) to populate it.
3. **No Cascading Deletion**: Deleting or changing a parent rule (like Category or Family) did not clean up rules that depended on it (like Family or Type).
4. **Lack of Diagnostics**: There was no easy way to track binding loops or property change events in the Debug Log.

---

## Root Cause
1. **WPF ComboBox Reset Behavior**: When sibling rules are updated, `RefreshPropertiesList()` is triggered on each rule. To rebuild the property options, the rule executes `Properties.Clear()`. When the ItemsSource of a WPF ComboBox is cleared, WPF automatically sets the bound `SelectedProperty` to `null`. Without a guard, this triggered `OnSelectedPropertyChanged(null)`, which cleared the rule's `AvailableValues` and reset `SelectedValue = null`.
2. **First-Load Property Change Muffle**: To protect against the ComboBox reset bug, we used a boolean flag `_isUpdatingProperties = true` during `RefreshPropertiesList()`. However, the initial property selection of `"Categorías"` was set *inside* the protected block. The event handler ignored this initial selection change because the flag was true, leaving `AvailableValues` completely empty.
3. **Missing Dependency Pruning**: We had no recursive logic in the `PreSelectionRuleSet` to prune rules that require prerequisite sibling criteria (e.g., "Familias" requires "Categorías", and "Tipos" requires "Familias") when their parents were removed or changed.
4. **Missing Logs**: The VM did not output trace messages detailing rule IDs, current and previous selections, and list size changes.

---

## Solution

### 1. Rebuilding with WPF Property Guard & Deferral
We updated `RefreshPropertiesList()` to only active the `_isUpdatingProperties` flag when modifying the properties collections. Restoring the previous valid selection is also done inside the guard.
However, assigning the default selection (if the previous selection is lost or we are initializing the first rule) is performed *after* the guard is released. This ensures that the first property assignment correctly triggers `OnSelectedPropertyChanged()`.

```csharp
public void RefreshPropertiesList()
{
    if (_isUpdatingProperties) return;
    var currentSelection = SelectedProperty;
    
    try
    {
        // ... (determine newPropertiesList)
        if (Properties.SequenceEqual(newPropertiesList)) return;

        _isUpdatingProperties = true;
        Properties.Clear();
        foreach (var p in newPropertiesList) Properties.Add(p);

        // Restore previous selection if still available
        if (currentSelection != null && Properties.Contains(currentSelection))
        {
            SelectedProperty = currentSelection;
        }
    }
    finally
    {
        _isUpdatingProperties = false;
    }

    // Assign default selection OUTSIDE the guard block to trigger property change handler
    if (SelectedProperty == null || !Properties.Contains(SelectedProperty))
    {
        SelectedProperty = Properties.FirstOrDefault();
    }
}
```

### 2. Guarding `OnSelectedPropertyChanged`
The handler uses `_isUpdatingProperties` to filter out intermediate `null` selections from WPF:

```csharp
partial void OnSelectedPropertyChanged(string value)
{
    if (_isUpdatingProperties) return; // Block temporary WPF null pushbacks

    UpdateAvailableValues();
    SelectedValue = AvailableValues.FirstOrDefault();
    
    Parent?.PruneDependentRules();
    Parent?.NotifyRulePropertiesChanged();
    Parent?.NotifyRuleValuesChanged();
}
```

### 3. Cascading Rule Pruning
We introduced a recursive method `PruneDependentRules()` inside `PreSelectionRuleSet.cs` to remove any sibling rules whose prerequisites are missing:

```csharp
public void PruneDependentRules()
{
    bool hasCategory = Children.OfType<PreSelectionRule>().Any(r => r.SelectedProperty == "Categorías" && !string.IsNullOrEmpty(r.SelectedValue));
    bool hasFamily = Children.OfType<PreSelectionRule>().Any(r => r.SelectedProperty == "Familias" && !string.IsNullOrEmpty(r.SelectedValue));

    var nodesToKeep = new List<IPreselRuleNode>();
    foreach (var child in Children)
    {
        if (child is PreSelectionRule rule)
        {
            if (rule.SelectedProperty == "Familias" && !hasCategory)
            {
                LoggerService.LogInfo($"Pruning rule {rule.SelectedProperty} due to missing category sibling.");
                continue;
            }
            if (rule.SelectedProperty == "Tipos" && !hasFamily)
            {
                LoggerService.LogInfo($"Pruning rule {rule.SelectedProperty} due to missing family sibling.");
                continue;
            }
        }
        else if (child is PreSelectionRuleSet subSet)
        {
            subSet.PruneDependentRules();
        }
        nodesToKeep.Add(child);
    }

    if (Children.Count != nodesToKeep.Count)
    {
        Children.Clear();
        foreach (var node in nodesToKeep) Children.Add(node);
    }
}
```

### 4. Logging Trace
All constructors, list rebuilds, selection changes, and cascading pruning are fully logged using `LoggerService.LogInfo` to help debug any future binding modifications.
