# Technical Reference: WPF Debug Log Window Lifecycle and Configuration Toggle Pattern

**Date:** 2026-08-07  
**Target Skill:** `revit-api`, `revit-api-ux`  
**Domain:** WPF UI / MVVM Window Interop / Debug Window Lifecycle  

---

## 📌 Problem Overview

In WPF modeless add-in windows in Autodesk Revit:
1. **Window Destruction on Close:** Clicking the `X` title bar button on a child helper window (such as a Debug Log Window `LogView`) closes and disposes the WPF `Window` instance. Subsequent calls to `.Show()` or `.Visibility` throw `InvalidOperationException: Cannot set Visibility or call Show after a Window has closed`.
2. **Environment-Dependent Initial State:** In Debug mode (`#if DEBUG`), the log window must open automatically on startup. In Production (Release) mode, it must remain hidden by default, but toggleable on demand from a secondary Configuration dialog.

---

## 🛠️ Resolution Architecture

### 1. Window Lifecycle Interception (`e.Cancel = true; Hide()`)
Intercept the child window `Closing` event so that clicking `X` hides the window instead of destroying its object instance. Clean up properly when the main parent window closes (`_isClosing = true`):

```csharp
public partial class TransferPlusView : Window
{
    private LogView? _logView;
    private bool _isClosing = false;

    private void CreateAndPrepareLogView()
    {
        if (_logView != null) return;

        _logView = new LogView();
        _logView.Owner = this;
        _logView.Closing += (s, e) =>
        {
            if (!_isClosing)
            {
                e.Cancel = true;
                _logView.Hide(); // Hide instead of close
            }
        };
    }

    private void TransferPlusView_Closed(object? sender, System.EventArgs e)
    {
        _isClosing = true;
        _logView?.Close();
    }

    public void ToggleDebugLogWindow()
    {
        if (_logView == null) CreateAndPrepareLogView();

        if (_logView!.IsVisible)
        {
            _logView.Hide();
        }
        else
        {
            _logView.Show();
            _logView.Activate();
        }
    }
}
```

### 2. ViewModel Interop Command (`ConfigurationViewModel.cs`)
Find the parent window instance via `System.Windows.Application.Current.Windows` and execute `ToggleDebugLogWindow()`:

```csharp
[RelayCommand]
private void ToggleDebugWindow()
{
    var mainView = System.Windows.Application.Current?.Windows
        .OfType<Views.TransferPlusView>()
        .FirstOrDefault();

    mainView?.ToggleDebugLogWindow();
}
```

---

## ✅ Best Practices Checklist for Debug Window Lifecycle

- [x] **Intercept Closing Event:** Override `Closing` with `e.Cancel = true; window.Hide();` to maintain reusable window instances across toggles.
- [x] **Safe Cross-Window Command Dispatch:** Access owner windows via `System.Windows.Application.Current.Windows.OfType<TParentView>()`.
- [x] **Conditional Startup Visibility:** Wrap default `.Show()` calls inside `#if DEBUG` preprocessor directives.
