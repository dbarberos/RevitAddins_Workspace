---
name: csharp-community-toolkit-mvvm
description: Master skill for CommunityToolkit.Mvvm. Covers C# Source Generators ([ObservableProperty], [RelayCommand]), Dependency Injection (DI) wiring via Generic Host, and decoupled Messenger pub/sub communication (WeakReferenceMessenger). Use whenever scaffolding ViewModels or modern WPF UI backend logic.
---

# CommunityToolkit.Mvvm Integration

## Purpose
Instructs the agent on how to write modern, boiler-plate-free MVVM code using Microsoft's official `CommunityToolkit.Mvvm` library.

## When to Use
- When writing any WPF ViewModel or data-binding logic.
- When ViewModels need to communicate without tight coupling (Messenger).
- When resolving ViewModels and Services using Dependency Injection.

## Mandatory Rules
- **NuGet Requirement**: The project `.csproj` must have `<PackageReference Include="CommunityToolkit.Mvvm" Version="8.2.*" />` (or latest).
- **Class Modifiers**: ViewModels using source generators (`[ObservableProperty]`, `[RelayCommand]`) **MUST** be `partial` classes.
- **Base Classes**: Inherit from `ObservableObject` (or `ObservableRecipient` if using Messenger).
- **Field Naming**: Backing fields for `[ObservableProperty]` must be `lowerCamelCase` (e.g. `_firstName`).
- **Revit API Threading**: If a `[RelayCommand]` interacts with the Revit API, you **MUST** wrap the API logic using the `revit-async-operations` skill (`RevitTask.RunAsync`).

## References
- [Toolkit Core Generators](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/csharp-community-toolkit-mvvm/references/toolkit_core.md)
- [Dependency Injection Setup](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/csharp-community-toolkit-mvvm/references/toolkit_di.md)
- [Messenger Pub/Sub](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/csharp-community-toolkit-mvvm/references/toolkit_messenger.md)

## Assets
- [MvvmTemplates.cs](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/csharp-community-toolkit-mvvm/assets/MvvmTemplates.cs): C# boilerplate for ViewModels, DI Host builder, and Messaging.
