# Technical Guide: Revit WPF Modeless Window Management & Application.Current Null Resolution

**Date:** 2026-08-07  
**Skills:** `revit-api`, `revit-api-ux`, `csharp-blueprints`  
**Target:** Revit C# Add-in Developers (.NET Framework 4.8 / .NET 8)  

---

## 🚨 Core Problem 1: `System.Windows.Application.Current` is `NULL` in Revit

### Problem Description
In standard WPF standalone applications, developers frequently locate open windows using `Application.Current.Windows`.  
However, inside an Autodesk Revit Add-in, **`System.Windows.Application.Current` returns `null`** because `Revit.exe` is a native Win32/C++ process hosting .NET assemblies, not a WPF `Application` instance.

### Anti-Pattern (Fails Silently in Revit)
```csharp
// ❌ FAILS IN REVIT: Application.Current is null!
var mainView = Application.Current?.Windows?.OfType<Views.TransferPlusView>()?.FirstOrDefault();
mainView?.ToggleLogWindow(); // Never executes!
```

---

## ✅ Solution 1: Direct Action Delegates & Dispatcher Execution

To communicate between secondary ViewModels (such as a Configuration dialog) and the primary view window without relying on `Application.Current`:

### 1. Define Static Action Delegate in ViewModel
```csharp
public partial class ConfigurationViewModel : ObservableObject
{
    public static Action? ToggleDebugWindowAction { get; set; }

    [RelayCommand]
    private void ToggleDebugWindow()
    {
        TelemetryLogger.LogInfo("ConfigurationViewModel: Requesting debug window toggle...");
        ToggleDebugWindowAction?.Invoke();
    }
}
```

### 2. Register Delegate in Primary Window (`TransferPlusView.xaml.cs`)
```csharp
public partial class TransferPlusView : Window
{
    public TransferPlusView()
    {
        InitializeComponent();

        // Wire ViewModel toggle request directly to View Dispatcher
        ConfigurationViewModel.ToggleDebugWindowAction = () =>
        {
            this.Dispatcher.Invoke(() =>
            {
                ToggleDebugLogWindow();
            });
        };
    }
}
```

---

## 🚨 Core Problem 2: Modal Windows (`ShowDialog()`) Freezing Host Windows

### Problem Description
Opening secondary windows in Revit add-ins using `.ShowDialog()` locks the WPF message pump for all parent and sibling windows (`TransferPlusView`, `LogView`). While a modal window is open, clicking secondary controls or attempting to toggle helper windows fails because UI events are blocked.

---

## ✅ Solution 2: Modeless (`Show()`) + `Topmost = true` + Single Instance Pattern

To keep a secondary window (like Configuration) floating above the add-in without freezing user interaction on other windows:

```csharp
[RelayCommand]
private void OpenConfiguration()
{
    // 1. Single Instance Check: Activate existing window if already open
    var existingConfig = System.Windows.Application.Current?.Windows?.OfType<Views.ConfigurationView>()?.FirstOrDefault();
    if (existingConfig != null)
    {
        existingConfig.Activate();
        return;
    }

    // 2. Modeless Open with Owner and Topmost Z-Ordering
    var mainView = System.Windows.Application.Current?.Windows?.OfType<Views.TransferPlusView>()?.FirstOrDefault();
    var configView = new Views.ConfigurationView();
    if (mainView != null)
    {
        configView.Owner = mainView;
    }
    configView.Topmost = true; // Stays visually on top without locking message pump
    configView.Show();         // Modeless Show() instead of ShowDialog()
}
```

---

## 🚨 Core Problem 3: Window Destruction on Close (`X`)

### Problem Description
Clicking `X` on a child helper window disposes the `Window` instance. Re-calling `.Show()` later throws `InvalidOperationException: Cannot set Visibility or call Show after a Window has closed`.

### Solution: Hide on Close Interception
```csharp
private void CreateAndPrepareLogView()
{
    if (_logView != null) return;

    _logView = new LogView();
    _logView.Owner = this;
    _logView.Closing += (s, e) =>
    {
        if (!_isClosing) // Don't cancel when parent application is shutting down
        {
            e.Cancel = true;
            _logView.Hide(); // Hide instead of dispose
        }
    };
}
```

---

## 📋 Best Practices Summary Matrix

| Requirement | Recommended Pattern | Avoid |
| :--- | :--- | :--- |
| **VM-to-View Interop** | Static `Action` delegates dispatched on UI thread | Relying on `Application.Current.Windows` |
| **Secondary Dialogs** | Modeless `.Show()` + `Owner` + `Topmost = true` | Blocking `.ShowDialog()` |
| **Reusable Windows** | Intercept `Closing` event: `e.Cancel = true; Hide()` | Allowing `Close()` and recreating instances |
