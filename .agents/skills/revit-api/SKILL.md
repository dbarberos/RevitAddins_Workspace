---
name: revit-api
description: Strict C# rules for Autodesk Revit Add-in development. Use this when writing, modifying, or reviewing Revit API code to ensure thread-safety, proper transactions, and modern Revit API practices.
---

# Strict C# Code Instructions
* Always use C# 12. Use 'Primary Constructors' in ViewModels.
* Never use `#region`. Keep classes small and focused.
* Always inject dependencies through the constructor; never instantiate services directly inside a Command.

# Versioning and Git Synchronization
* **Single Source of Truth:** The true version of the Add-in resides in the **Git Tags**.
* **Synchronization:** Whenever a build or installer is prepared, the Agent MUST synchronize the git tag (`git describe --tags --abbrev=0`) with the `<Version>` property in the `.csproj` file.
* **Consistency:** Do not allow discrepancies between the installer version, assembly version, and git tag.

# Revit API Instructions
* When searching for elements in the model using `FilteredElementCollector`, ALWAYS prioritize QuickFilters (like `OfCategory()`) over slow filters like parameter literals.
* Never attempt to modify the Revit UI (Ribbon) outside the application's `OnStartup` event.
* **TRANSACTIONS (MANDATORY)**: Any modification to the model MUST be wrapped inside a `Transaction` block complying strictly with the `revit-transactions` skill (using `using`, and checking for `SubTransaction` when necessary).
* **THREAD SAFETY (MANDATORY)**: When making Revit API calls from a background thread or WPF ViewModel (`[RelayCommand]`), you MUST wrap the execution using the `revit-async-operations` skill (`RevitTask.RunAsync()`) to prevent `InvalidOperationException` and UI freezing.

## 📚 Technical References (Knowledge Base)
For deep technical details, consult the following files in the `references/` folder:

- `references/thread_safety_and_events.md`: Critical rules about thread contexts, `Dispatcher`, `ExternalEvent`, and `DoEvents` (Avoiding Crashes).
- `references/treeview_construction.md`: How to massively build trees and TreeViews without blocking the UI.
- `references/csproj_templates.md`: Base `.csproj` templates for .NET Framework 4.8 and .NET 8 using `Nice3point`.
- `references/revit_breaking_changes.md`: How to manage units conversion with `ForgeTypeId` vs legacy `DisplayUnitType` and other API breakages.
- `references/revit_filtered_element_collector.md`: Mandatory guidelines for high-performance element selection, quick filters, and memory-saving iterations.
- `references/revit_element_relations_and_connectivity.md`: Advanced navigation of element relationships, model groups, assemblies, 3D physical intersection filters, and MEP connector networks connectivity.

# Agent Execution Flow
1. When the user asks you to create a new Add-in, your first step MUST be to run `dotnet new revit -n [Name]`.
2. Your second step MUST be to restructure the `/UI` folders into `/Views` and `/ViewModels` according to MVVM standards.
3. Whenever you create, iterate, or modify an add-in, you MUST copy the generated artifacts (Implementation Plan, Task, and Walkthrough) to the current project's `docs/` folder, following the modular documentation standard (e.g. `docs/references/[artifact]_[keywords]_[YYYY-MM-DD_HHmm].md`).
