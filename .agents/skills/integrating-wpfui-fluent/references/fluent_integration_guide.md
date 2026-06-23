# WPF-UI (Wpf.Ui) Integration Guide

This guide details how to implement a Fluent Design WPF application based on Wpf.Ui 4.x.

## 1. NuGet Package Requirement
To use these features, the project must reference the WPF-UI NuGet package:
```xml
<PackageReference Include="WPF-UI" Version="4.2.*" />
```

## 2. Key Architectural Rules

1.  **Use `FluentWindow`**: Inherit from `FluentWindow` instead of the standard `Window`.
2.  **Title Bar Extension**: Combine `ExtendsContentIntoTitleBar="True"` with the `ui:TitleBar` component in XAML.
3.  **Dependency Injection**: Use `Microsoft.Extensions.Hosting.Host` (GenericHost) to register services.
    *   `INavigationService`, `ISnackbarService`, `IContentDialogService` should be **Singletons**.
    *   Pages and their ViewModels should be **Transient** (since `NavigationView` manages their lifecycles).
4.  **Navigation Implementation**: 
    *   Every Page must implement `INavigableView<TViewModel>`.
    *   `INavigationService.SetNavigationControl()` must be called in the `MainWindow` constructor to wire the visual control to the backend service.

## 3. Navigation Service Usage
For programmatic navigation inside a ViewModel, inject `INavigationService`:
```csharp
[RelayCommand]
private void NavigateToSettings()
{
    _navigationService.Navigate(typeof(SettingsPage));
}
```

## 4. Snackbar Service Usage
To display temporary floating notifications, inject `ISnackbarService` and ensure a `<ui:SnackbarPresenter>` exists in the MainWindow XAML.
```csharp
_snackbarService.Show(
    "Success",
    "Data has been saved.",
    ControlAppearance.Success,
    new SymbolIcon(SymbolRegular.Checkmark24),
    TimeSpan.FromSeconds(3));
```

## 5. ContentDialog Service Usage
To display modal dialogs that blur the background, inject `IContentDialogService` and ensure a `<ui:ContentDialogService>` host exists in the MainWindow XAML.
```csharp
var result = await _contentDialogService.ShowSimpleDialogAsync(
    new SimpleContentDialogCreateOptions
    {
        Title = "Confirm Deletion",
        Content = "Are you sure you want to delete this?",
        PrimaryButtonText = "Delete",
        CloseButtonText = "Cancel"
    });

if (result == ContentDialogResult.Primary)
{
    // Handle deletion
}
```

## 6. Theme Management
Wpf.Ui allows seamless switching between Light and Dark themes:
```csharp
// Switch theme manually
ApplicationThemeManager.Apply(ApplicationTheme.Dark);
ApplicationThemeManager.Apply(ApplicationTheme.Light);

// Detect system theme and auto-apply
ApplicationThemeManager.ApplySystemTheme();
```

## 7. CommunityToolkit.Mvvm Integration
Wpf.Ui integrates naturally with the `CommunityToolkit.Mvvm` source generators. ViewModels should inherit from `ObservableObject` and use `[ObservableProperty]` and `[RelayCommand]` attributes for clean code.
