# Debugging Revit API Thread Violations from WPF Modeless Windows

**Date:** 2026-06-23  
**Symptoms:**  
A button click from a WPF Modeless Window (e.g., "Apply Filter") fails silently. No elements are updated in the UI, and the expected error logging `TaskDialog` does not appear. The user perceives that the button "has stopped working" after a code merge, despite identical logic.

**Root Cause:**
1. **Thread Violation:** The WPF button's command executes on a secondary WPF UI thread. Calling strict Revit API methods like `doc.ActiveView` or creating a `FilteredElementCollector` outside the main Revit API context throws an `Autodesk.Revit.Exceptions.InvalidOperationException` in Revit 2024+.
2. **Double Fault (Silent Crash):** The try/catch block intercepts the exception and attempts to log the error using a Revit `TaskDialog.Show()`. However, `TaskDialog` also requires the main Revit UI thread. Attempting to show it from the WPF thread triggers a second `InvalidOperationException`, which is silently swallowed by the WPF dispatcher, leaving no trace of the failure.

**Solution (Pattern):**
1. **Generic Action Handler:** Use a custom `IExternalEventHandler` (e.g., `ActionEventHandler`) to marshal arbitrary API calls back to the main Revit thread.
2. **WPF UI Wrapping:** In the ViewModel, wrap the command logic within the handler's execution block:
   ```csharp
   _actionHandler.Raise(() => {
       // Safe Revit API calls (doc.ActiveView, FilteredElementCollector, etc.)
       // Safe TaskDialogs
   }, _actionExternalEvent);
   ```
3. **Safe Error Logging:** Modify global error loggers to use standard Windows `MessageBox.Show()` instead of `TaskDialog` when called from undetermined thread contexts.
