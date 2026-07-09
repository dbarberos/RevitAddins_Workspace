# Skill Manifest: Revit API Advanced UX/UI (`revit-api-ux`)

## 1. Skill Identity & Purpose
* **ID:** SKILL-RVT-UX
* **Domain:** Dockable Panes, WPF/XAML, MVVM Architecture, and Real-Time Event Monitoring.
* **Objective:** Orchestrate the creation of seamless, non-blocking user interfaces that behave like native Revit panels (e.g., the Properties Palette). Handle the translation of visual UI wireframes into production-ready WPF XAML and bind them safely to the Revit API context.

## 2. Core Execution Guardrails
When executing tasks within this domain, the agent MUST strictly enforce these programmatic constraints:
1. **Dockable Registration Window:** Dockable Panes (`IDockablePaneProvider`) MUST be registered strictly during the `IExternalApplication.OnStartup()` event. Attempting to register a pane within an `IExternalCommand` will cause a fatal exception.
2. **MVVM Strictness:** The agent MUST NOT write code-behind (`.xaml.cs`) that directly accesses the Revit API. All UI interactions must route through a ViewModel using `ICommand` and dispatch tasks to the `ExternalEventBridge` (from `SKILL-RVT-CORE`).
3. **Event Unsubscription:** When subscribing to `Application.DocumentChanged` or `UIApp.Idling` to update the UX in real-time, the agent MUST ensure a bulletproof unsubscription mechanism on application shutdown to prevent memory leaks.
4. **Image-to-XAML Protocol:** When the user provides an image or wireframe for a UI:
   - Use `Grid` and `StackPanel` for responsive layouts.
   - Apply native Revit UI styling (or standard Windows 10/11 system colors) so the add-in doesn't look alien.
   - Map all actionable buttons to WPF `Command="{Binding MyCommand}"` instead of `Click="Btn_Click"`.

## 3. Reference Mapping (Theory & Ontologies)
When specific UX architecture concepts are needed, locate the following files in the `./references/` directory:
* **Dockable Panes:** `31_DockablePanes_and_Providers.md`
* **WPF & MVVM in Revit:** `32_WPF_XAML_MVVM.md`
* **Real-Time Context:** `33_DocumentEvents_and_Idling.md`

## 4. Asset Mapping (Code Blueprints)
Inject, adapt, or copy the exact implementations located in the `./assets/` directory:
* `DockablePaneRegistrator.cs` -> Boilerplate for creating and registering the `IDockablePaneProvider` natively.
* `ViewModelBase.cs` -> Core `INotifyPropertyChanged` implementation for seamless data-binding between Revit data and XAML.
* `DynamicEventMonitor.cs` -> Safe wrapper for tracking when the user modifies elements in the model to instantly refresh the Dockable Pane.