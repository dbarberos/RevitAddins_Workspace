---
name: revit-api-core
description: Database control, UI, Events, Transactions, and WPF/WebView2 async coordination.
---

# REVIT API CORE

## Purpose
Expert instructions and design rules for Autodesk Revit API developers in the revit-api-core domain.

## References
- [01 Architecture and Transactions](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/01_Architecture_and_Transactions.md)
- [02 FilteredElementCollector](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/02_FilteredElementCollector.md)
- [03 Transactions and Regeneration (Consolidated)](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-transactions/SKILL.md)
- [04 UI and Ribbon](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/04_UI_and_Ribbon.md)
- [07 Selection and Interaction](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/07_Selection_and_Interaction.md)
- [Debugging: ViewSheet Unique Name Constraint & Append Suffix](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/debugging_viewsheet_unique_constraint_2026-07-20.md)
- [Debugging: View-to-View Copy Missing Types](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/debugging_view_to_view_copy_missing_types_2026-07-20.md)
- [Debugging: View Copying Causes Transaction Corruption & Silently Rolls Back Sheet Creation](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/debugging_view_copy_transaction_corruption_2026-07-20.md)
- [Debugging: ViewPlan Copy Level Uniqueness & Direct Selection Creation](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/debugging_viewplan_copy_level_uniqueness_2026-07-21.md)
- [Debugging: Callout View Side-Effect Sibling Views Elimination](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/debugging_callout_sideeffect_sibling_2026-07-30.md)
- [Debugging: Callout Symbol Visibility Rules & Scale Threshold Filter](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/debugging_callout_visibility_and_scale_threshold_2026-07-30.md)
- [Debugging: Revit Link Instances Missing from Session Document Collector](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/debugging_linked_models_source_dropdown_20260804.md)
- [Debugging: Azure SDK MissingMethodException (IAsyncEnumerator) on .NET Framework 4.8](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/debugging_azure_storage_dotnet48_20260804.md)
- Failure Handling, DMU, Logging, and Modeless Dispatching (Consolidated in [revit-api-resilience](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/SKILL.md)).
- Worksets & Shared Coordinates (Consolidated in [revit-api-worksharing](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/SKILL.md)).


## Assets
- [BaseCommandBoilerplate.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/BaseCommandBoilerplate.cs): Reusable base command wrapping IExternalCommand execution lifecycle with dialog exception reporting.
- [OptimizedCollectorFilters.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/OptimizedCollectorFilters.cs): Collection of fast collector queries and extension methods.
- [RibbonUiFactory.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/RibbonUiFactory.cs): Helper for programmatic creation of Ribbon Tabs, Panels, and PushButtons.
- [StructuralWallSelectionFilter.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/StructuralWallSelectionFilter.cs): Clean document element selection interaction wrappers.
