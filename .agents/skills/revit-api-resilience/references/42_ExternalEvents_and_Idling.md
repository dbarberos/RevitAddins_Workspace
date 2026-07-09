# Skill: Non-Modal Interfaces and Asynchronous Execution (IExternalEventHandler)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-RES
* **Technical Area:** Asynchronous Execution / Modeless WPF / UI Threading
* **API dependencies:** `Autodesk.Revit.UI.IExternalEventHandler`, `Autodesk.Revit.UI.ExternalEvent`
* **Design Patterns:** Event-Driven Architecture, Command/Message Queuing, Thread-Safe Dispatcher
* **Operational Impact:** Critical. Avoids interface blocks (UI Freezes), prevents InvalidOperationExceptions and crashes when calling the Revit API from background threads (like WPF click events or WebView2 events).

---

## 2. The Main Thread Rule (Revit API Context)
Autodesk Revit API is strictly single-threaded and not thread-safe. The active model can only be interacted with when Revit gives control to an Add-in (for example, within the `Execute` method of an `IExternalCommand` or during a native Revit event callback).

There are two types of graphical windows (WPF/WinForms):
1. **Modals (`window.ShowDialog()`):** They block Revit completely. The user cannot click on the model until they close the window. Revit keeps the API context securely open.
2. **Modeless or Floating (`window.Show()`):** The window opens, but Revit is still active. The `Execute` method of the original command terminates immediately.
   **Danger:** When a button in a modeless UI is clicked, it runs on the WPF UI thread, not the Revit main thread. Attempting to modify the document directly from this thread results in an instant crash (`Autodesk.Revit.Exceptions.InvalidOperationException`).

---

## 3. The Bridge: `IExternalEventHandler`
To allow a floating window to modify the model, a message queue must be established. The modeless UI submits a request, and Revit, when it is idle and safe to do so, executes it on the main thread.

This bridge is built by implementing `IExternalEventHandler`.
Revit provides the `ExternalEvent` class to notify the main thread that a handler has pending tasks.

---

## 4. Native Dispatching Assets
In this skill, we provide two blueprints in the `./assets/` directory to manage this bridge:
1. **`ActionEventHandler.cs`**: A generic `IExternalEventHandler` that accepts an arbitrary `Action` delegate. Extremely simple for one-off actions.
2. **`AsyncTaskDispatcher.cs`**: A thread-safe queue (`ConcurrentQueue<Action<UIApplication>>`) that funnels multiple actions from ViewModel Commands to the main thread. Ideal for commercial-grade enterprise extensions.

### Step-by-Step Native Workflow:
1. **Instantiate and Register:** Create the handler and register it using `ExternalEvent.Create(handler)` on the main Revit thread (e.g., inside `IExternalApplication.OnStartup()`).
2. **Inject into ViewModel:** Pass the handler and `ExternalEvent` instance to the ViewModel.
3. **Queue and Raise:** From the ViewModel command, queue the Revit API lambda block and call `externalEvent.Raise()`.

```csharp
// Inside the WPF ViewModel Command:
private void OnSaveSettings()
{
    // Correct: Queue task safely
    _taskDispatcher.EnqueueTask(app =>
    {
        using (Transaction t = new Transaction(app.ActiveUIDocument.Document, "Save Settings"))
        {
            t.Start();
            // Revit API modifications here...
            t.Commit();
        }
    });
}
```

---

## 5. Matrix of Antipatterns vs Patterns
* **Anti-Pattern (Silent Crash / Thread Block):** Calling `Transaction.Start()` or querying Revit elements directly inside a WPF button click event or a background task (`Task.Run`).
* **Optimized Pattern (MVVM + Task Dispatcher):** The ViewModel commands do not touch the API directly; they delegate database interactions to the `AsyncTaskDispatcher` or `ActionEventHandler`.

---

## 6. Agent Injection Instructions (Mandatory Guidelines)
To ensure asynchronous stability of front-end tools, strictly enforce these rules:
1. **Thread Exclusivity Rule:** It is strictly prohibited to use native C# multithreading namespaces (`System.Threading.Tasks.Task.Run`, `Thread.Start`, `async/await`) to invoke methods from the `Autodesk.Revit.DB` or `Autodesk.Revit.UI` libraries directly. Any native Revit logic must run in sync with the `ExternalEvent` execution.
2. **Event Lifecycle:** The `ExternalEvent` object must be instantiated using `ExternalEvent.Create()` only once during command/application startup, and kept alive in memory. Do not create a new `ExternalEvent` every time the user clicks a button.
3. **Visual Blocking:** Because execution is asynchronous, Revit can take a fraction of a second to service the `.Raise()` request. Temporarily disable critical WPF UI buttons immediately after the click to prevent the user from accidentally triggering the event multiple times, and re-enable them upon completion of the handler execution.
