# WPF-UI (Wpf.Ui) Integration Guide

This guide details how to implement a modern, Windows 11-style Fluent Design interface inside WPF using the `Wpf.Ui` library.

---

## 1. NuGet Dependency
Ensure the project targets the following NuGet package:
```xml
<PackageReference Include="WPF-UI" Version="4.2.*" />
```

## 2. Key Architectural Rules
1.  **Use `FluentWindow`**: Inherit from `Wpf.Ui.Controls.FluentWindow` instead of `System.Windows.Window`.
2.  **Extends Title Bar**: Set `ExtendsContentIntoTitleBar="True"` to allow content to drag up into the windows header. Integrate the `<ui:TitleBar>` control in your XAML.
3.  **Dependency Injection (DI)**: Register navigation and dialog controllers as Singletons:
    *   `INavigationService` (Singleton)
    *   `ISnackbarService` (Singleton)
    *   `IContentDialogService` (Singleton)
    *   Navigable pages and their respective viewmodels should be registered as **Transient** because their lifecycle is managed by the page navigator.

---

## 3. UI Navigation Service
To trigger page transitions programmatically, inject `INavigationService` and invoke `Navigate`:
```csharp
[RelayCommand]
private void NavigateToSettings()
{
    _navigationService.Navigate(typeof(SettingsPage));
}
```
*   Navigable page views must implement the generic interface `INavigableView<TViewModel>`.

## 4. Snackbar & Dialog Overlays
*   **Snackbar**: Place a `<ui:SnackbarPresenter>` on the top grid layer of `MainWindow.xaml` and register it inside the window constructor using `snackbarService.SetSnackbarPresenter()`. Trigger alerts like this:
    ```csharp
    _snackbarService.Show(
        "Operation Completed",
        "The element parameters have been successfully written.",
        ControlAppearance.Success,
        new SymbolIcon(SymbolRegular.Checkmark24),
        TimeSpan.FromSeconds(3.5));
    ```
*   **ContentDialog**: Place a `<ui:ContentDialogService>` in the XAML and wire it using `contentDialogService.SetDialogHost()`. Trigger modern modals:
    ```csharp
    var result = await _contentDialogService.ShowSimpleDialogAsync(
        new SimpleContentDialogCreateOptions
        {
            Title = "Discard Changes?",
            Content = "All unsaved changes will be permanently lost.",
            PrimaryButtonText = "Discard",
            CloseButtonText = "Keep Editing"
        });
    ```

## 5. System Theme Synchronization
Wpf.Ui supports Light, Dark, and High Contrast. Synchronize the add-in with Windows theme preferences automatically:
```csharp
ApplicationThemeManager.ApplySystemTheme();
```
