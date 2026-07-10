---
name: revit-api-ux
description: Advanced UX/UI, WPF/XAML MVVM page registration, Dockable Panes, event monitors, and WebView2 React containers.
---

# Skill Manifest: Revit API Advanced UX/UI (`revit-api-ux`)

## 1. Skill Identity & Purpose
* **ID:** SKILL-RVT-UX
* **Domain:** Dockable Panes, WPF/XAML, MVVM Architecture, and WebView2 Web Containers.
* **Objective:** Orchestrate the creation of non-blocking, responsive user interfaces that behave like native panels, supporting both WPF/MVVM and React web containers.

## 2. Core Execution Guardrails
1. **Dockable Registration Window**: Dockable Panes (`IDockablePaneProvider`) MUST be registered strictly during `IExternalApplication.OnStartup()`.
2. **MVVM Thread Safety**: WPF ViewModels must not directly access the Revit database (use commands and `ExternalEventBridge`).
3. **Event Unsubscription**: Always unsubscribe from `DocumentChanged` or `Idling` events on application shutdown to prevent severe memory leaks.
4. **WebView2 Thread Isolation**: WebView2 callbacks occur on separate threads. You must queue arguments and raise an External Event to run database transactions.

## 3. Reference Mapping
* **Dockable Panes**: [31_DockablePanes_and_Providers.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/references/31_DockablePanes_and_Providers.md)
* **WPF & MVVM in Revit**: [32_WPF_XAML_MVVM.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/references/32_WPF_XAML_MVVM.md)
* **Real-Time Context**: [33_DocumentEvents_and_Idling.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/references/33_DocumentEvents_and_Idling.md)
* **WebView2 & React UI**: [17_WebView2_and_WebUI.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/references/17_WebView2_and_WebUI.md)

## 4. Asset Mapping
* [DockablePaneRegistrator.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/DockablePaneRegistrator.cs) -> WPF Page dockable pane registration boilerplate.
* [DynamicEventMonitor.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/DynamicEventMonitor.cs) -> Subscribes and dispatches Revit model modifications to ViewModels.
* [ViewModelBase.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/ViewModelBase.cs) -> Core WPF binding model base.
* [DockablePaneWebViewRegistration.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/DockablePaneWebViewRegistration.cs) -> WebView2 registration boilerplate.
* [WebMessageRouter.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/WebMessageRouter.cs) -> WebView2 to C# message dispatcher.
* [WebMessageResponseSender.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/WebMessageResponseSender.cs) -> C# to WebView2 script dispatcher.
* [DirectDocumentAccessAntiPattern.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/DirectDocumentAccessAntiPattern.cs) -> Anti-pattern of direct API calls from web messaging thread.
