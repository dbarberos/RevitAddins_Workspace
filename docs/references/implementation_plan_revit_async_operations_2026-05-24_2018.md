# Integration of `Revit.Async` Skill

To address the critical issue of executing Revit API code from background threads without freezing the UI or triggering `Autodesk.Revit.Exceptions.InvalidOperationException` (because the API is single-threaded), we will integrate the `Revit.Async` pattern as a dedicated skill.

This will instruct the agent on how to correctly wrap `ExternalEvent` operations using `Revit.Async` (by Kennan Chen) so we can leverage modern `async/await` inside our WPF ViewModels.

## Proposed Changes

### `revit-async-operations` Skill Folder
I will create the new directory: `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\revit-async-operations\`

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\revit-async-operations\SKILL.md`
The master index file. It will define the NuGet requirement (`Revit.Async`) and act as the core instruction set for whenever the agent needs to invoke the Revit API from a WPF ViewModel command.

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\revit-async-operations\references\revit_async_guide.md`
Theoretical guide on the single-threaded nature of Revit:
- **The Problem**: Explaining why background threads crash Revit (InvalidOperationException).
- **The Solution**: How `Revit.Async` wraps Revit's native `IExternalEventHandler` and `ExternalEvent`.
- **Initialization**: Mandatory `RevitTask.Initialize(application)` call inside `IExternalApplication.OnStartup`.
- **Execution**: Correct usage of `await RevitTask.RunAsync()` to marshal work back to the main API thread.

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\revit-async-operations\assets\RevitAsyncTemplates.cs`
A robust C# asset file containing boilerplate snippets for:
- Initialization inside `IExternalApplication`.
- A sample ViewModel command showing `RevitTask.RunAsync` making an asynchronous API modification.
- A sample of `RevitTask.RunAsync` returning data (e.g., fetching a list of elements asynchronously to populate a UI).

## User Review Required
> [!IMPORTANT]
> Do you approve this architecture for integrating `Revit.Async`? Once approved, I will generate the skill files in English to maintain our token optimization strategy and save the plan to the `docs/references` folder.
