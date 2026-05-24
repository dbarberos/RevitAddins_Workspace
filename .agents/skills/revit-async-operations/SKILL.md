---
name: revit-async-operations
description: Wraps Revit's ExternalEvent to allow asynchronous execution of Revit API code using async/await pattern via the Revit.Async library (by Kennan Chen). Prevents UI freezing and Autodesk.Revit.Exceptions.InvalidOperationException when calling API from background threads (like WPF buttons).
---

# Revit.Async Operations Guide

## Purpose
Autodesk Revit API is strictly single-threaded. Calling API methods from a WPF ViewModel command running on a background UI thread will crash the add-in. This skill automatically provides the boilerplate to safely marshal tasks back to the Revit main thread using the `Revit.Async` NuGet package.

## When to Use (MANDATORY AUTOMATIC ENFORCEMENT)
- **Always** use this when implementing `[RelayCommand]` in a WPF ViewModel that modifies or reads from the Revit Document.
- **Always** use this when you need a background task to process heavy data while keeping the WPF UI responsive.
- Whenever you face a `RevitServerException` or `InvalidOperationException` regarding context/threads.

## Mandatory Rules
- **NuGet Requirement**: Project must have `<PackageReference Include="Revit.Async" Version="2.0.*" />` (check for latest).
- **Initialization**: `RevitTask.Initialize(application)` MUST be called in `IExternalApplication.OnStartup`.
- **Execution**: All Revit API calls inside ViewModels MUST be wrapped in `await RevitTask.RunAsync(...)`.
- **No Native Threads**: NEVER use `Task.Run()`, `Thread.Start()`, or `BackgroundWorker` to interact with Revit's `Document` or UI.

## References
- [Revit Async Architecture Guide](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-async-operations/references/revit_async_guide.md)

## Assets
- [RevitAsyncTemplates.cs](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-async-operations/assets/RevitAsyncTemplates.cs): C# boilerplate for `OnStartup` initialization and `ViewModel` command examples.
