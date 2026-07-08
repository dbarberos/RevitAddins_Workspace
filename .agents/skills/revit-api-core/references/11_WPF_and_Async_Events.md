# Skill: Non-Modal Interfaces and Asynchronous Execution (IExternalEventHandler)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-011
* **Technical Area:** Asynchronous Execution / Modeless WPF / UI Threading
* **API dependencies:** `Autodesk.Revit.UI.IExternalEventHandler`, `Autodesk.Revit.UI.ExternalEvent`
* **Design Patterns:** Event-Driven Architecture, Command/Message Queuing
* **Operational Impact:** Critical. Avoids interface blocks (UI Freezes), allows parallel workflows and interactive dashboards on secondary screen.

---

## 2. The Main Thread Problem (Revit API Context)

Revit is a Single-Threaded application when it comes to its API. The active model can only be interacted with when Revit "gives" control to an Add-in (for example, within the `Execute` method of an `IEExternalCommand`).

There are two types of graphical windows (WPF/WinForms):
1. **Modals (`window.ShowDialog()`):** They block Revit completely. The user cannot click on the model until they close the window. Revit keeps the API context securely open.
2. **Non-Modal or Floating (`window.Show()`):** The window opens, but Revit is still active. The `Execute` method of the original command terminates immediately. **Danger:** If the floating window has a "Create Wall" button, clicking it will cause the code to run in a different Windows thread than Revit. Revit will detect unauthorized access and kill the process (Crash).

---

## 3. Architecture of IExternalEventHandler



To allow a floating window to modify the model, a "message box" must be created. The window submits a request, and Revit, when it is idle and safe to do so, picks up the request and executes it in its own main thread.

This bridge is built by implementing `IExternalEventHandler`.

### Step 1: The Handler (The code that Revit will modify)
```csharp
public class GeneratorWallsHandler : IExternalEventHandler
{
    // Local variables to receive parameters from the UI
    public double RequiredHeight { get; set; }

    // This method is ONLY invoked by Revit safely
    public void Execute(UIApplication app)
    {
        UIDocument uidoc = app.ActiveUIDocument;
        if (uidoc == null) return;
        Document doc = uidoc.Document;

        using (Transaction t = new Transaction(doc, "Create Walls from Floating UI"))
        {
            t.Start();
            // Secure business logic (Revit API)
            // Wall.Create(doc, curve, level.Id, false);
            t.Commit();
        }
    }

    public string GetName() => "Wall Generator Handler";
}
Step 2: The Registry and the Window (WPF)
The event must be instantiated and registered before opening the floating window.
C#
// Inside the main IExternalCommand:
WallGeneratorHandler handler = new WallGeneratorHandler();
ExternalEvent externalEvent = ExternalEvent.Create(handler); // Create the communication channel

// Dependency injection into the WPF window
MyFloatingWindow window = new MyFloatingWindow(handler, externalEvent);
window.Show(); // The window is launched without blocking Revit
Step 3: The Launch (Trigger from the UI)
When the user clicks the button in the WPF window, the Revit logic is not invoked directly. The "flag" of the event is raised.
C#
// Inside the Code-Behind of the WPF window (Button_Click):
private void BtnGenerar_Click(object sender, RoutedEventArgs e)
{
    // 1. Pass data from the UI to the handler
    _handler.RequiredHeight = double.Parse(txtHeight.Text);

    // 2. Notify Revit that there is a pending task
    _externalevent.Raise(); 
}
4. Matrix of Antipatterns vs Patterns
Common Anti-Pattern (Risk of Imminent Crash)
C#
// FATAL: Within a floating WPF button the Document is invoked directly
private void BtnClick(object sender, RoutedEventArgs e)
{
Transaction t = new Transaction(_doc, "Create"); // CRASH: Invalid API context
    t.Start();
}
Optimized Pattern (MVVM + IExternalEventHandler)
In advanced architectures, the ExternalEvent is not passed directly to the window's code-behind (.xaml.cs), but is instead injected into the ViewModel using the MVVM pattern. The WPF commands (ICommand) simply assign the properties in a state container and execute event.Raise().
5. Agent Injection Instructions (Prompting Prompt)
To ensure asynchronous stability of front-end tools, strictly enforce these rules:
Thread Exclusivity Rule: It is strictly prohibited to use native C# multithreading namespaces (System.Threading.Tasks.Task.Run, Thread.Start, async/await) to invoke methods from the Autodesk.Revit.DB or Autodesk.Revit.UI libraries. Any native Revit logic must run in sync with the ExternalEvent.
Event Lifecycle: The ExternalEvent object must be instantiated using ExternalEvent.Create() only once during the initial command, and kept alive referenced in graphics memory. Don't create a new ExternalEvent every time the user presses a button in the UI.
Context Pass: The Execute(UIApplication app) method of the handler is blind to what happens in the graphical interface. The agent must set properties or Setter methods on the IExternalEventHandler class to transfer the data (strings, doubles, collections of ElementIds) from the visual layer before calling .Raise().
Visual Blocking: Because execution is asynchronous, Revit can take a fraction of a second to service the .Raise() request. Temporarily disable critical WPF UI buttons immediately after the click to prevent the user from accidentally triggering the event multiple times, and re-enable them upon completion of the handler execution.