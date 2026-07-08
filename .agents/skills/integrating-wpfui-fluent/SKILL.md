---
name: integrating-wpfui-fluent
description: Integrates WPF-UI (Wpf.Ui) library for Fluent Design in WPF applications. Use when building modern UI with FluentWindow, NavigationView, SnackbarService, or theme management in Revit add-ins.
---

# WPF-UI (Wpf.Ui) Integration Guide

## Purpose
Guide the development of modern, Windows 11-style Fluent Design interfaces inside WPF. This skill instructs the agent on how to bootstrap a `FluentWindow` and wire it with Dependency Injection (DI) services for navigation, snackbars, and dialogs.

## When to Use
- When scaffolding a completely new UI for an add-in that requires a modern, multi-page application feel.
- When injecting `INavigationService`, `ISnackbarService`, or `IContentDialogService` into ViewModels.
- When converting a standard `Window` to a `FluentWindow` using `Wpf.Ui`.

## Mandatory Rules
- **NuGet Requirement**: The target project `.csproj` must have `<PackageReference Include="WPF-UI" Version="4.2.*" />` installed.
- **Window Base Class**: Replace standard `Window` with `FluentWindow`.
- **DI Registration**: Services must be registered as Singletons; Pages and ViewModels should generally be registered as Transient (managed by `NavigationView`).
- **Page Interface**: Every navigable Page must implement `INavigableView<TViewModel>`.

## References
- [Fluent Integration Guide](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/integrating-wpfui-fluent/references/fluent_integration_guide.md)
- [Debugging: WPF ScrollViewer FlowDirection and Margins](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/integrating-wpfui-fluent/references/debugging_wpf_rtl_scrollviewer_margins_2026-07-02.md)

## Assets
- [FluentSetupTemplates.cs](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/integrating-wpfui-fluent/assets/FluentSetupTemplates.cs): C# boilerplate for HostBuilder DI, MainWindow initialization, and ViewModels.
- [FluentSetupTemplates.xaml](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/integrating-wpfui-fluent/assets/FluentSetupTemplates.xaml): XAML templates for App resources and the FluentWindow layout.
