# Integration of `CommunityToolkit.Mvvm` Skills

The three URLs provided cover the core pillars of the **CommunityToolkit.Mvvm** library:
1. **Core Generators**: `[ObservableProperty]`, `[RelayCommand]`, and `ObservableObject`.
2. **Dependency Injection (DI)**: Wiring ViewModels using `Microsoft.Extensions.DependencyInjection`.
3. **Messenger**: Decoupled pub/sub communication using `WeakReferenceMessenger` and `IRecipient<T>`.

Rather than creating three separate, fragmented skills that clutter the agent's context, I propose consolidating them into a single, robust, modular skill named `csharp-community-toolkit-mvvm`. This perfectly aligns with our AECO dual-stack architecture.

## Proposed Changes

### `csharp-community-toolkit-mvvm` Skill Folder
I will create the new directory: `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\csharp-community-toolkit-mvvm\`

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\csharp-community-toolkit-mvvm\SKILL.md`
The master index file. It will define the NuGet requirement (`CommunityToolkit.Mvvm`) and act as the central brain for MVVM generation.

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\csharp-community-toolkit-mvvm\references\toolkit_core.md`
Theoretical guide on using the C# source generators (`[ObservableProperty]`, `[RelayCommand]`) instead of legacy boilerplate `INotifyPropertyChanged` code.

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\csharp-community-toolkit-mvvm\references\toolkit_di.md`
Theoretical guide on resolving ViewModels via constructor injection and registering them as `Transient` or `Singleton` inside the .NET Generic Host.

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\csharp-community-toolkit-mvvm\references\toolkit_messenger.md`
Theoretical guide on decoupled communication using `WeakReferenceMessenger.Default.Send` and implementing `IRecipient<TMessage>`.

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\csharp-community-toolkit-mvvm\assets\MvvmTemplates.cs`
A robust C# file containing boilerplate snippets for:
- A base `ObservableObject` ViewModel.
- A Messenger recipient ViewModel.
- A strongly-typed Message record.

## User Review Required
> [!IMPORTANT]
> Do you approve unifying these three concepts into a single `csharp-community-toolkit-mvvm` skill? This modular approach keeps the `skills/` directory clean while fully equipping the agent with state-of-the-art MVVM capabilities.
