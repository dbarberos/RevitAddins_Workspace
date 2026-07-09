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
- Failure Handling, DMU, Logging, and Modeless Dispatching (Consolidated in [revit-api-resilience](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/SKILL.md)).
- Worksets & Shared Coordinates (Consolidated in [revit-api-worksharing](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/SKILL.md)).

## Assets
- [BaseCommandBoilerplate.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/BaseCommandBoilerplate.cs): Reusable base command wrapping IExternalCommand execution lifecycle with dialog exception reporting.
- [OptimizedCollectorFilters.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/OptimizedCollectorFilters.cs): Collection of fast collector queries and extension methods.
- [RibbonUiFactory.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/RibbonUiFactory.cs): Helper for programmatic creation of Ribbon Tabs, Panels, and PushButtons.
- [StructuralWallSelectionFilter.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/StructuralWallSelectionFilter.cs): Clean document element selection interaction wrappers.
