# CommunityToolkit.Mvvm Core Generators

Instead of manually implementing `INotifyPropertyChanged` and writing boilerplate getters/setters or `ICommand` classes, use the C# source generators provided by the toolkit.

## 1. Observable Properties
Decorate private fields with `[ObservableProperty]`. The generator creates public PascalCase properties.
**Rule:** The class must be `partial` and inherit from `ObservableObject`.

```csharp
public partial class UserViewModel : ObservableObject
{
    [ObservableProperty]
    private string _firstName = string.Empty;

    // This generates:
    // public string FirstName { get => _firstName; set => SetProperty(ref _firstName, value); }
}
```

## 2. Depending Properties (Calculated)
Use `[NotifyPropertyChangedFor]` to notify UI elements when a dependent property should also update.

```csharp
public partial class UserViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    private string _firstName = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    private string _lastName = string.Empty;

    public string FullName => $"{FirstName} {LastName}";
}
```

## 3. Commands
Decorate a method with `[RelayCommand]`. It generates an `IRelayCommand` property.

```csharp
public partial class UserViewModel : ObservableObject
{
    // Generates: public IRelayCommand SaveCommand { get; }
    [RelayCommand]
    private void Save()
    {
        // Save logic
    }

    // Async support: Generates SaveDataCommand (removes 'Async' suffix from method name)
    [RelayCommand]
    private async Task SaveDataAsync()
    {
        await Task.Delay(1000);
    }
}
```

## 4. Command CanExecute
Specify a boolean property or method to control if the command can execute. Use `[NotifyCanExecuteChangedFor]` to trigger UI evaluation when the state changes.

```csharp
public partial class UserViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private bool _isDataValid;

    private bool CanSave() => IsDataValid;

    [RelayCommand(CanExecute = nameof(CanSave))]
    private void Save()
    {
        // Save logic
    }
}
```
