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
- [10 IUpdater and Events](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/10_IUpdater_and_Events.md)
- [11 WPF and Async Events](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/11_WPF_and_Async_Events.md)
- [14 Worksharing and Worksets](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/14_Worksharing_and_Worksets.md)
- [17 WebView2 and WebUI](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/17_WebView2_and_WebUI.md)
- [Debugging Modeless WPF Thread Blocks](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/debugging_modeless_wpf_thread_block_2026-07-07.md): Root cause and solution for `InvalidOperationException` using `ActionEventHandler`.

## Assets
- [ActionEventHandler.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/ActionEventHandler.cs): Generic External Event handler used to safely marshal WPF ViewModel commands to the main Revit UI thread.
- [BaseCommandBoilerplate.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/BaseCommandBoilerplate.cs): Reusable base command wrapping IExternalCommand execution lifecycle with dialog exception reporting.
- [ExternalEventBridge.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/ExternalEventBridge.cs): Queued External Event handler bridging asynchronous actions to the main Revit UI thread.
- [OptimizedCollectorFilters.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/OptimizedCollectorFilters.cs): Collection of fast collector queries and extension methods.
- [RibbonUiFactory.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/RibbonUiFactory.cs): Helper for programmatic creation of Ribbon Tabs, Panels, and PushButtons.
- [StructuralWallSelectionFilter.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/StructuralWallSelectionFilter.cs): Clean document element selection interaction wrappers.
- [WebMessageRouter.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/WebMessageRouter.cs) to [DockablePaneWebViewRegistration.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/assets/DockablePaneWebViewRegistration.cs): WebView2 controller injection and browser interop boilerplates.
