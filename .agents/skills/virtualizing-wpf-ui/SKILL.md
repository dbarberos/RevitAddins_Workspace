---
name: virtualizing-wpf-ui
description: Implements WPF UI virtualization for large data sets using VirtualizingStackPanel. Use when displaying 1000+ items in ItemsControl, ListView, or DataGrid to prevent memory and performance issues, which is critical in AECO environments.
---

# WPF UI Virtualization

## Purpose
Prevent memory crashes and massive performance drops when rendering thousands of BIM elements, schedules, or material lists in WPF interfaces. This skill instructs on applying virtualization patterns correctly.

## When to Use
- When generating XAML for `ItemsControl`, `ListBox`, `ListView`, or `DataGrid` that will hold large datasets.
- When fixing performance issues related to UI freezing during data loading.

## Mandatory Rules
- **NEVER** wrap a virtualizing control in a `ScrollViewer` (it breaks virtualization).
- **NEVER** set `ScrollViewer.CanContentScroll="False"` on a list control.
- If grouping is required, always explicitly enable `VirtualizingPanel.IsVirtualizingWhenGrouping="True"`.

## References
- [WPF Virtualization Guide](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/virtualizing-wpf-ui/references/wpf_virtualization_guide.md)
- [Debugging Cache Limit with Linked Models](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/virtualizing-wpf-ui/references/debugging_cache_limit_linked_models_2026-07-08.md)

## Assets
- [VirtualizationHelpers.cs](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/virtualizing-wpf-ui/assets/VirtualizationHelpers.cs): C# diagnostic tools for UI virtualization.
- [VirtualizingDataGrid.xaml](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/virtualizing-wpf-ui/assets/VirtualizingDataGrid.xaml): XAML snippets for virtualized grids and lists.
