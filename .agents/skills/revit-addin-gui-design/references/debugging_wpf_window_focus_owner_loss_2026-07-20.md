# Debugging Report: WPF Window Falling Behind Revit Main Window After Dialogs [Focus / Z-Order Loss]

## Info
* **Date:** 2026-07-20
* **Component:** `CmdTransferPlus.cs` / `TransferPlusView.xaml.cs` / `TransferPlusViewModel.cs`
* **Skill Target:** `revit-addin-gui-design`
* **Technology:** WPF / C# / Revit API (Win32 Window Ownership)

---

## 1. Symptom
When a custom WPF window triggers an internal task (e.g., Revit `TaskDialog.Show` or WPF `MessageBox.Show`), upon closing the dialog, the main WPF window unexpectedly drops behind the Revit main window in the OS Z-Order. To the user, it appears as though the add-in crashed or closed unexpectedly, confusing the user workflow.

---

## 2. Root Cause
1. **Un-owned Top-Level Window:** The WPF window was instantiated and displayed via `view.ShowDialog()` without binding its Win32 parent handle (`HWND Owner`) to Revit's `UIApplication.MainWindowHandle`.
2. **OS Focus Handoff:** When `TaskDialog.Show` (owned natively by Revit's main window handle) closes, Windows Desktop Window Manager (DWM) automatically hands active Z-order focus back to the dialog's owner (Revit). Because the custom WPF window was un-owned, DWM raised the Revit window above it in the Z-order stack.

---

## 3. Solution

### A. Assign Revit MainWindowHandle as WPF Window Owner
In the `IExternalCommand` entrypoint, bind Revit's main window handle to the WPF window using `System.Windows.Interop.WindowInteropHelper`:

```csharp
public override void Execute()
{
    var viewModel = new TransferPlusViewModel(Application, Application.ActiveUIDocument.Document);
    var view = new TransferPlusView(viewModel);

    if (Application.MainWindowHandle != System.IntPtr.Zero)
    {
        new System.Windows.Interop.WindowInteropHelper(view).Owner = Application.MainWindowHandle;
    }

    view.ShowDialog();
}
```

### B. Force Reactivation After Long-Running Tasks
In the ViewModel's execution handler, add a helper to explicitly re-focus and activate the WPF window in the `finally` block:

```csharp
finally
{
    IsBusy = false;
    StatusMessage = "Ready";
    ProgressPercentage = 0;
    BringMainWindowToFront();
}

private void BringMainWindowToFront()
{
    var activeWindow = System.Windows.Application.Current?.Windows
        .OfType<System.Windows.Window>()
        .FirstOrDefault(w => w is TransferPlus.Views.TransferPlusView);

    if (activeWindow != null)
    {
        activeWindow.Activate();
        activeWindow.Focus();
    }
}
```
