# Implementation Plan - FilterPlus Treeview Enhancements

## Goal
Fix the missing hierarchical treeview rendering, incorporate leaf node counts recursively through the hierarchy, and implement full-row dynamic background highlighting based on checkbox states (Checked, Indeterminate, Unchecked) while overriding default WPF selection colors.

## Proposed Changes
1. **SelectionFilterViewModel.cs**
   - Rework `InitializeTree()` to recursively track count of leaf nodes (Element IDs) up through the Type, Family, and Category tiers.
   
2. **TreeItemViewModel.cs**
   - Add `[ObservableProperty] private int _count;` inside the viewmodel to enable WPF bindings for the counts.

3. **SelectionFilterView.xaml**
   - Remove `GroupBox` wrapper and replace with standard `Grid`.
   - Implement fixed-width two-column layout (`*` and `60px`) internally for row template and externally for column headers ("Elements" and "Count").
   - Enable `IsThreeState="True"` on `CheckBox` elements to automatically utilize the `null` boolean state logic for indeterminate rendering.
   - Adjust `TreeViewItem` control template to pull `Margin` and `Padding` directly to 0 space, resolving gaps in row background blocks.
   - Inject DataTriggers inside the template to set the row background to `#e8f5e9` (Checked - Green) and `#fff8e1` (Indeterminate - Yellow).
   - Silence default system highlight brushes by overriding them as `Transparent` inside `TreeView.Resources`.
