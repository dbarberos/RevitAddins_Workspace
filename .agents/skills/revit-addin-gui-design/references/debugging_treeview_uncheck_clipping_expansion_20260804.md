# Debugging Log: WPF TreeView Text Truncation, Hierarchy Expansion & Initial Check State

**Date**: 2026-08-04  
**Skill Target**: `revit-addin-gui-design` / `csharp-blueprints`  
**Components**: `TransferPlusView.xaml`, `TransferPlusViewModel.cs`, `FamilyItemModel.cs`

---

## 1. Symptom 1: Text Clipping / Truncation on Deep Hierarchy Levels

### Issue
When displaying 5-level hierarchical TreeView items (Root -> Container -> Category -> Family -> Symbol), long names at level 3 and 4 were cut off horizontally, even though a horizontal scrollbar container was present.

### Root Cause
1. `CheckboxTreeTemplate` in XAML had `<Grid Grid.Column="0" ClipToBounds="True">` and an artificial `TranslateTransform` bound to an external `ScrollBar`.
2. The outer `<TreeView>` was explicitly configured with `ScrollViewer.HorizontalScrollBarVisibility="Disabled"`.
3. Disabling native horizontal scrolling while clipping bounds forced WPF to truncate text whenever item indentations expanded past the panel boundary.

### Solution
- Removed `ClipToBounds="True"` and artificial transforms from `CheckboxTreeTemplate`.
- Configured native WPF horizontal scrolling on `<TreeView>`:
```xml
<TreeView ItemTemplate="{StaticResource CheckboxTreeTemplate}"
          ScrollViewer.VerticalScrollBarVisibility="Auto"
          ScrollViewer.HorizontalScrollBarVisibility="Auto">
```

---

## 2. Symptom 2: TreeView Items Checked by Default on Load

### Issue
When launching the add-in or changing the source document dropdown, all elements or families in the TreeView were automatically checked by default.

### Root Cause
1. In `FamilySymbolItemModel.cs`, the properties `_isChecked` and `_isSelected` were initialized to `true` by default (`[ObservableProperty] private bool _isChecked = true;`).
2. When building symbol nodes in `BuildFamilyTree()`, `symbolNode.IsChecked` inherited `sym.IsChecked = true`.
3. Adding a child node with `IsChecked = true` triggered recursive parent check state updates (`UpdateParentCheckState()`), checking `familyNode`, `categoryNode`, `containerNode`, and `allNode`.

### Solution
1. Set default property backing fields to `false` in data models:
```csharp
[ObservableProperty]
private bool _isSelected = false;

[ObservableProperty]
private bool _isChecked = false;
```
2. Enforce explicit unchecking on tree creation:
```csharp
allNode.UpdateRecursiveCounts();
allNode.SetCheckedState(false);
RootNodes.Add(allNode);
```
