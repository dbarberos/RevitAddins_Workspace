# Debugging: Modeless WPF UI Thread Blocking & Revit API Context
**Date:** 2026-07-07
**Tags:** `WPF`, `Modeless`, `Threading`, `Dispatcher`, `ActionEventHandler`

## 🔴 Symptom
When attempting to execute Revit API calls (such as selection filtering or applying UI state to elements) from a button click in a **Modeless WPF Window**, the Revit UI freezes, blocks indefinitely, or throws an `Autodesk.Revit.Exceptions.InvalidOperationException` stating that the API can only be called from the main Revit thread. 
Attempting to circumvent this using `Application.Current.Dispatcher.Invoke` does not solve the issue, as the WPF Dispatcher runs on its own background thread distinct from the Revit API execution context.

## 🔍 Root Cause
Modeless WPF windows (`Show()`) run independently of the Revit process thread. Commands triggered from the ViewModels (e.g., `RelayCommand`) execute on this separate thread. When they attempt to read or write to the Revit document, they violate Revit's strict single-threaded API requirement. `Dispatcher.Invoke` only marshals calls back to the *WPF UI thread*, not the *Revit main thread*.

## 🛠️ Solution
To bridge the gap between the WPF Modeless thread and the Revit API thread, we must implement an `IExternalEventHandler`. This is Revit's native mechanism for asynchronously injecting tasks into its main loop.

### Implementation Steps
1. **Create an `ActionEventHandler`**: A generic class implementing `IExternalEventHandler` that accepts an `Action` delegate (see `assets/ActionEventHandler.cs`).
2. **Register the Event**: Instantiate the handler and register it using `ExternalEvent.Create()` during the application or command initialization on the main Revit thread.
3. **Pass to ViewModel**: Inject the `ActionEventHandler` and `ExternalEvent` instance into the ViewModel's constructor.
4. **Raise the Event**: Inside the WPF `RelayCommand`, queue the Revit API logic inside an `Action` and trigger the external event.

```csharp
// Inside the WPF ViewModel Command:
private void ApplyFilter()
{
    // WRONG: Direct execution causes InvalidOperationException
    // _revitSelectionService.FilterSelection();

    // WRONG: Dispatcher.Invoke does not fix Revit context
    // Application.Current.Dispatcher.Invoke(() => _revitSelectionService.FilterSelection());

    // CORRECT: Marshal to Revit thread via ExternalEvent
    _actionHandler.Raise(() =>
    {
        _revitSelectionService.FilterSelection();
    }, _actionExternalEvent);
}
```

This pattern ensures that the Modeless UI remains fully responsive while API calls are safely queued and executed by Revit when it is ready.
