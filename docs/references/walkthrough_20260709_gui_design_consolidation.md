# Walkthrough: UI/UX Consolidation and GUI Design Skill Creation

We have successfully created the `revit-addin-gui-design` skill, migrated all existing knowledge from `integrating-wpfui-fluent` and `virtualizing-wpf-ui` into it, extracted `FilterPlus`'s visual styles, and updated the global rules in `AGENTS.md`.

## 1. Created the Global Agent Skill `revit-addin-gui-design`
*   **Skill Manifest**: Created [SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/SKILL.md) in English.
*   **Assets Consolidated**:
    *   `FluentSetupTemplates.cs` & `FluentSetupTemplates.xaml` (Fluent Window and GenericHost bootstrap templates).
    *   `VirtualizationHelpers.cs` & `VirtualizingDataGrid.xaml` (Performance diagnostic scripts and grid templates).
    *   [FilterPlusStyles.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/assets/FilterPlusStyles.xaml): **[NEW]** Reusable styles dictionary enclosing ToggleSwitch, flat header buttons, and custom white-bordered container card grids.
*   **Reference Guides Consolidated**:
    *   [50_WPF_UI_Virtualization.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/50_WPF_UI_Virtualization.md) (Detailed virtualization rules).
    *   [51_WPF_Fluent_Design.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/51_WPF_Fluent_Design.md) (Wpf.Ui library features).
    *   [52_FilterPlus_UI_Styling.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/52_FilterPlus_UI_Styling.md): **[NEW]** Style guidelines explaining card borders, sliding toggle micro-animations, left-aligned scrollbars via inverted flow direction layout, loading overlays, and element limit caches.
    *   `debugging_wpf_rtl_scrollviewer_margins_2026-07-02.md` & `debugging_cache_limit_linked_models_2026-07-08.md` (RTL margins and linked document cache limits reports).

## 2. Updated Agent Rules (`AGENTS.md`)
*   Registered `revit-addin-gui-design` in Available Skills.
*   Consolidated the Planning Gate rule under Section 6.1:
    > **WPF UI Design & Performance (revit-addin-gui-design)**: For controls displaying 1000+ items (ListView, TreeView, DataGrid), WPF virtualization is mandatory (never wrap in a ScrollViewer, never disable content scroll). UI setups must follow premium card-based design systems with smooth animations (such as FilterPlus SwitchStyle) and keep vertical scrollbars physically left-sided via inverted margins under FlowDirection. Always apply the 100,000 element safety limit check to prevent UI freezes on linked documents.

## 3. Cleaned Up Redundancies
*   Completely deleted old, redundant skill directories `.agents/skills/integrating-wpfui-fluent` and `.agents/skills/virtualizing-wpf-ui`.
