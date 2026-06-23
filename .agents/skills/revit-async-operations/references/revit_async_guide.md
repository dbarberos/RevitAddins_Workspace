# Revit.Async Architecture Guide

## 1. The Single-Threaded Revit Problem
The Revit API is inherently single-threaded. It only allows interacting with the `Document` from the Revit Main UI Thread. 
In modern WPF MVVM applications, button clicks and UI updates often happen on separate UI dispatcher threads or background tasks. If a WPF ViewModel command tries to modify a Revit `Wall`, it throws an `Autodesk.Revit.Exceptions.InvalidOperationException`.

The native Autodesk solution is to use `IExternalEventHandler` and `ExternalEvent.Create()`. However, this native approach is heavily event-driven and breaks the linear `async/await` control flow.

## 2. The Revit.Async Solution
`Revit.Async` (by Kennan Chen) wraps the native `ExternalEvent` pattern inside an awaitable `Task`. This restores standard C# async workflows, preventing UI freezing and enabling clean MVVM commands.

### Rule 1: Global Initialization
You must initialize the global `RevitTask` handler when the Add-in starts. This binds the library to the Revit application context.
```csharp
public Result OnStartup(UIControlledApplication application)
{
    // Mandatory initialization
    RevitTask.Initialize(application);
    return Result.Succeeded;
}
```

### Rule 2: Fire-and-Forget (Transactions)
If a ViewModel needs to modify the model (e.g., place a family instance), wrap the transaction block inside `RevitTask.RunAsync`.

```csharp
[RelayCommand]
private async Task CreateWallAsync()
{
    // Execution is sent to the Revit Main Thread
    await RevitTask.RunAsync(app =>
    {
        using var tx = new Transaction(app.ActiveUIDocument.Document, "Create Wall");
        tx.Start();
        // Create wall logic...
        tx.Commit();
    });
}
```

### Rule 3: Return Data
If a ViewModel needs to fetch data from Revit (e.g., list of rooms) to display in a DataGrid, use `RevitTask.RunAsync<T>`.

```csharp
[RelayCommand]
private async Task LoadRoomsAsync()
{
    // Fetch data asynchronously without freezing WPF
    var roomNames = await RevitTask.RunAsync(app =>
    {
        var doc = app.ActiveUIDocument.Document;
        return new FilteredElementCollector(doc)
            .OfCategory(BuiltInCategory.OST_Rooms)
            .Select(r => r.Name)
            .ToList();
    });

    // Back on the WPF thread, update the observable collection
    Rooms.Clear();
    foreach(var name in roomNames) Rooms.Add(name);
}
```
