---
name: revit-addin-gui-design
description: Implements modern UI/UX design systems, WPF virtualization for large datasets, Fluent Window layouts, and premium FilterPlus card-based styles in Revit add-ins.
---

# Skill Manifest: Revit Add-in GUI Design (`revit-addin-gui-design`)

## 1. Skill Identity & Purpose
*   **ID**: SKILL-RVT-GUI
*   **Domain**: User Interface & Experience (UI/UX), WPF Styling, Fluent Design System, Control Virtualization, and Performance Safeguards.
*   **Objective**: Standardize GUI development for Revit add-ins, combining modern aesthetics (Fluent Design, card containers, toggles, loading indicators) with extreme performance optimization to prevent Revit UI freezing.

## 2. Core Execution Guardrails
When developing interfaces for Revit add-ins, the agent MUST enforce the following constraints:
1.  **Virtualization Breakers**: NEVER wrap a virtualizing control (ListView, TreeView, DataGrid) inside a `ScrollViewer` or set `CanContentScroll="False"`. Doing so forces WPF to instantiate UI containers for all data items, causing Revit to crash/freeze on larger models.
2.  **Scrollbar Alignment (RTL)**: To position a vertical scrollbar on the physical left, apply `FlowDirection="RightToLeft"` on the `ScrollViewer` and `FlowDirection="LeftToRight"` on the child content. Invert the margin declarations (e.g., `Margin="0,0,9,0"`) to apply gaps next to the scrollbar.
3.  **UI Thread Protection (Cache Limits)**: When collecting model elements for display, count elements first. If they exceed 100,000, fallback to the **Active Model Only** (omitting link files) and display a clear warning indicator.
4.  **Entrypoint Modal vs Modeless**: Enforce modeless windows (using `ExternalEvent` marshaling) for interactive operations, and modal `TaskDialog` containers for quick confirmations.

## 3. Reference Mapping (Theory & Best Practices)
Consult these documents inside `references/` for detailed guidelines:
*   **WPF UI Virtualization**: [50_WPF_UI_Virtualization.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/50_WPF_UI_Virtualization.md)
*   **Fluent Design & Wpf.Ui**: [51_WPF_Fluent_Design.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/51_WPF_Fluent_Design.md)
*   **FilterPlus Custom Layouts**: [52_FilterPlus_UI_Styling.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/52_FilterPlus_UI_Styling.md)
*   **Debugging Scrollbar Alignment**: [debugging_wpf_rtl_scrollviewer_margins_2026-07-02.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/debugging_wpf_rtl_scrollviewer_margins_2026-07-02.md)
*   **Debugging Cache Limits**: [debugging_cache_limit_linked_models_2026-07-08.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/debugging_cache_limit_linked_models_2026-07-08.md)
*   **Debugging Window Z-Order Focus**: [debugging_wpf_window_focus_owner_loss_2026-07-20.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/debugging_wpf_window_focus_owner_loss_2026-07-20.md)
*   **Debugging Duplicate Abort Dialog Columns**: [debugging_duplicate_abort_dialog_columns_2026-07-20.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/debugging_duplicate_abort_dialog_columns_2026-07-20.md)
*   **Debugging Regex Helper Auto-Enable**: [debugging_regex_helper_auto_enable_2026-07-20.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/debugging_regex_helper_auto_enable_2026-07-20.md)
*   **Debugging Regex Prefix & Suffix Helpers**: [debugging_regex_prefix_suffix_helpers_2026-07-20.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/debugging_regex_prefix_suffix_helpers_2026-07-20.md)
*   **Debugging Cancel Button Window Close**: [debugging_cancel_button_close_window_2026-07-20.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/debugging_cancel_button_close_window_2026-07-20.md)
*   **Debugging TreeView Uncheck & Clipping**: [debugging_treeview_uncheck_clipping_expansion_20260804.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/debugging_treeview_uncheck_clipping_expansion_20260804.md)
*   **Debugging DataGrid Focus Selection Colors**: [debugging_datagrid_focus_selection_color_2026-08-12.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/debugging_datagrid_focus_selection_color_2026-08-12.md)
*   **Debugging Sequential Rename & Multi-Pass Apply**: [debugging_sequential_rename_multi_pass_apply_2026-08-12.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/debugging_sequential_rename_multi_pass_apply_2026-08-12.md)

## 4. Asset Mapping (Code & Layout Templates)
Copy, adapt, or inject the code templates located in the `assets/` directory:
*   **WPF-UI Bootstrapper & Window**: [FluentSetupTemplates.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/assets/FluentSetupTemplates.cs) / [FluentSetupTemplates.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/assets/FluentSetupTemplates.xaml)
*   **Virtualization Helpers**: [VirtualizationHelpers.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/assets/VirtualizationHelpers.cs) / [VirtualizingDataGrid.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/assets/VirtualizingDataGrid.xaml)
*   **FilterPlus Custom Styles Dictionary**: [FilterPlusStyles.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/assets/FilterPlusStyles.xaml)
