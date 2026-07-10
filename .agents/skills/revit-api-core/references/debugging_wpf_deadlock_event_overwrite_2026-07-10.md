# Debugging Report: WPF UI Deadlock and ActionEventHandler Event Overwrite

## Symptom
When performing rapid UI actions that raise external events to interact with the Revit API, the add-in gets permanently stuck/hung displaying a loading modal overlay (e.g., "Switching model context... Please wait a moment..."). No errors are printed to the console, and the add-in becomes completely unresponsive, requiring a hard restart of Revit.

---

## Root Causes

### 1. External Event Overwriting (Race Condition)
A generic `ActionEventHandler` wrapper that holds a single `private Action _action` field is vulnerable to race conditions.
* When the user clicks "Accept" in a dialog, the add-in calls `_actionHandler.Raise(ActionA)`. This sets `_action = ActionA` and calls `externalEvent.Raise()`.
* Immediately after, the dialog closes, and the main window receives focus, triggering its `Activated` event which invokes a selection state update via `_actionHandler.Raise(ActionB)`.
* Because Revit processes external events asynchronously when it becomes idle, both `Raise` calls happen in quick succession on the UI thread *before* Revit's worker thread can execute `Execute()`.
* The second `Raise` call overwrites the single `_action` field with `ActionB`.
* When Revit finally executes the handler, only `ActionB` is executed. `ActionA` (which was supposed to load the models and set `IsBusy = false`) is lost forever, leaving the UI permanently locked.

### 2. UI Thread Dispatcher Deadlock inside Modals
Calling `Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, ...)` inside an event handler of a WPF modal window (shown via `ShowDialog()`) causes WPF to wait until background priority dispatcher events are processed. Since the modal loop blocks or restricts the message pump, the dispatcher never yields, causing a deadlock on the UI thread. The modal window fails to close, Revit never enters an idle state, and the queued external event never executes.
Additionally, calling `Dispatcher.CurrentDispatcher` from a background thread (e.g. Revit API worker thread) creates a new Dispatcher instance on that background thread. Since background threads do not run a dispatcher message pump, calling `.Invoke` on it will cause the background thread to hang indefinitely.

---

## Resolution

### 1. Queue-Safe ActionEventHandler
The single `_action` field in `ActionEventHandler` must be replaced with a thread-safe `Queue<Action>`. When `Execute()` is triggered, it dequeues and processes all pending actions sequentially:

```csharp
public class ActionEventHandler : IExternalEventHandler
{
    private readonly Queue<Action> _actions = new Queue<Action>();
    private readonly object _lock = new object();

    public void Execute(UIApplication app)
    {
        var actionsToRun = new List<Action>();
        lock (_lock)
        {
            while (_actions.Count > 0)
            {
                actionsToRun.Add(_actions.Dequeue());
            }
        }
        foreach (var action in actionsToRun)
        {
            action.Invoke();
        }
    }

    public void Raise(Action action, ExternalEvent externalEvent)
    {
        lock (_lock)
        {
            _actions.Enqueue(action);
        }
        externalEvent?.Raise();
    }
}
```

### 2. Main UI Dispatcher Capture and Dispatching
* **Capture UI Dispatcher**: Store the UI thread dispatcher during construction of the ViewModel on the UI thread:
  ```csharp
  _uiDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
  ```
* **Safe Thread Marshaling**: Instead of calling `BuildTree()` directly on the Revit background thread (which alters WPF visual tree collections and triggers errors), marshal the execution back to the captured dispatcher:
  ```csharp
  _uiDispatcher.Invoke(() => { BuildTree(); });
  ```
* **Remove Hacks**: Remove all uses of `Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, ...)` to yield the thread. If the workload runs asynchronously in Revit, the WPF bindings will update naturally without dispatcher hacks.
