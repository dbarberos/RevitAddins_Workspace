# Skill Reference: Real-Time Context & Event Subscriptions

## 1. Monitoring Model Mutability
To keep a Dockable Pane or floating UI synced in real-time with model changes (e.g. updating a clash list when a wall is deleted), subscribe to `Application.DocumentChanged` or `UIControlledApplication.Idling`.

These events are fired by Revit's main database thread and are safe for querying:
- `DocumentChanged`: Triggered whenever an element is added, deleted, or modified.
- `Idling`: Triggered when Revit is not processing any user commands, allowing lightweight background refreshing.

## 2. Preventing Memory Leaks (The Disposal Guardrail)
Because Revit keeps Add-ins in memory for the entire session, failing to unsubscribe from global application events will keep UI pages and ViewModels alive, causing severe memory leaks (DLL lockups and RAM saturation).

> [!WARNING]
> **Bulletproof Unsubscription**: Always implement `IDisposable` or setup explicit shutdown hooks to unsubscribe from events during `IExternalApplication.OnShutdown()`.

### Code Blueprint: Safe Subscriptions Lifecycle
```csharp
public class EventMonitor : IDisposable
{
    private readonly Autodesk.Revit.ApplicationServices.Application _app;

    public EventMonitor(Autodesk.Revit.ApplicationServices.Application app)
    {
        _app = app;
        // Subscribe
        _app.DocumentChanged += OnDocumentChanged;
    }

    private void OnDocumentChanged(object sender, DocumentChangedEventArgs e)
    {
        // Guard family documents
        if (e.GetDocument().IsFamilyDocument) return;
        
        // Process updates
    }

    public void Dispose()
    {
        // Unsubscribe
        if (_app != null)
        {
            _app.DocumentChanged -= OnDocumentChanged;
        }
    }
}
```

Handling within `IExternalApplication`:
```csharp
public class Application : IExternalApplication
{
    private EventMonitor _monitor;

    public Result OnStartup(UIControlledApplication application)
    {
        // Wait for ControlledApplication initialization or capture inside idling
        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication application)
    {
        // CRITICAL: Dispose the monitor to remove event hooks
        _monitor?.Dispose();
        return Result.Succeeded;
    }
}
```
