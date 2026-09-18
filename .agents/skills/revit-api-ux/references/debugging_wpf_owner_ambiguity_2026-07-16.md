# Debugging Report: Resolving WPF Window Ownership and Namespace Ambiguities in Revit Context

## Symptom
1. Triggering a child modal WPF window (e.g., `NumberingSettingsView`) causes the Revit command to crash silently, hang, or fail to show the window.
2. The compilation fails with errors such as:
   `error CS0117: 'Application' does not contain a definition for 'Current'`
3. Non-modal diagnostic windows (e.g., `LogView`) get pinned behind the main view or Revit frame, making them unreachable or causing focus locking.

---

## Root Cause
1. **Namespace Ambiguity:** Revit namespaces (`Autodesk.Revit.UI.Application` and `Autodesk.Revit.ApplicationServices.Application`) conflict with the WPF `System.Windows.Application` class. Using the unqualified `Application` symbol resolves to Revit's classes instead of WPF's.
2. **WPF Window Owner Safety:** Nice3point templates and default C# code-behind classes often attempt to resolve the active parent window using:
   `Owner = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive) ?? Application.Current.MainWindow;`
   In many Revit application session contexts, `System.Windows.Application.Current` can be null or the windows list is empty. This results in a `NullReferenceException` before `ShowDialog()` is reached.
3. **Startup Location:** Having `WindowStartupLocation="CenterOwner"` set in XAML makes the window crash at startup if `Owner` cannot be assigned correctly.

---

## Solution & Best Practices

### 1. Resolve Namespace Ambiguity
Always use the fully qualified `System.Windows.Application` namespace when accessing `Current` in WPF code-behinds:
```csharp
var app = System.Windows.Application.Current;
```

### 2. Implement Safe Owner Resolution
Wrap the Owner assignment inside a `try-catch` block with null checks:
```csharp
public NumberingSettingsView(MyViewModel viewModel)
{
    InitializeComponent();
    DataContext = viewModel;
    try
    {
        if (System.Windows.Application.Current != null)
        {
            var activeWindow = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            Owner = activeWindow ?? System.Windows.Application.Current.MainWindow;
        }
    }
    catch
    {
        // Fail-safe: let WPF display the window without Owner under CenterScreen mode
    }
}
```

### 3. Fallback Startup Location
Configure child modal windows in XAML to use `CenterScreen` as a startup location fallback rather than strictly depending on a parent owner:
```xml
WindowStartupLocation="CenterScreen"
```

### 4. Non-Modal Stacking and Focus Ownership
For non-modal tool windows (e.g., Debug Logger, Element Viewers) launched alongside the main view, assigning the parent view as the owner resolves window stacking, Lifecycle, and drag issues.

> [!WARNING]
> Attempting to set `Owner = this` inside the **constructor** of the parent window will throw `InvalidOperationException: Cannot set Owner property on a Window that has not been shown previously` because the parent window's Win32 HWND handle is not yet fully instantiated.

**Correct implementation using the `Loaded` event:**
```csharp
public MyMainView(MyViewModel viewModel)
{
    InitializeComponent();
    DataContext = viewModel;
    
    // Defer child window creation until the parent window is shown
    this.Loaded += MyMainView_Loaded;
}

private void MyMainView_Loaded(object sender, RoutedEventArgs e)
{
    this.Loaded -= MyMainView_Loaded;
    try
    {
        _logView = new LogView();
        _logView.Owner = this; // Safe now because parent window is loaded and visible
        _logView.Show();
        this.Closed += (s, e) => _logView.Close();
    }
    catch (System.Exception ex)
    {
        // Safe logger fallback
    }
}
```
