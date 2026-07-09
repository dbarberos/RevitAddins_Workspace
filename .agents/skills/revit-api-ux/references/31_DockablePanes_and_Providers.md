# Skill Reference: Dockable Panes and Providers

## 1. Context & Lifecycle Management
Dockable Panes in Revit act as native sidebar panels (like the Project Browser or Properties Palette). They are registered via `IDockablePaneProvider` and can host custom WPF XAML Pages.

> [!IMPORTANT]
> **Registration Window**: Dockable Panes MUST be registered strictly during the `IExternalApplication.OnStartup()` lifecycle event. Attempting to call `uiApp.RegisterDockablePane` anywhere else (such as inside an `IExternalCommand`) will throw a fatal `Autodesk.Revit.Exceptions.InvalidOperationException` and crash the application.

## 2. Programmatic Registration
To register a Dockable Pane:
1. Define a class implementing `IDockablePaneProvider`.
2. Map your WPF Page to the `FrameworkElement` property inside the `SetupDockablePane` callback.
3. Configure the initial docking position using `DockablePaneState`.

### Code Blueprint: Registration Setup
```csharp
public class MyDockablePaneProvider : IDockablePaneProvider
{
    private readonly System.Windows.Controls.Page _wpfPage;

    public MyDockablePaneProvider(System.Windows.Controls.Page wpfPage)
    {
        _wpfPage = wpfPage;
    }

    public void SetupDockablePane(DockablePaneProviderData data)
    {
        // Link WPF visual tree
        data.FrameworkElement = _wpfPage as System.Windows.FrameworkElement;
        
        // Define initial dock state
        data.InitialState = new DockablePaneState
        {
            DockPosition = DockPosition.Right,
            TabBehind = DockablePanes.BuiltInDockablePanes.ProjectBrowser
        };
    }
}
```

Registering during startup:
```csharp
public Result OnStartup(UIControlledApplication application)
{
    Guid paneGuid = new Guid("YOUR-UNIQUE-GUID-HERE");
    DockablePaneId paneId = new DockablePaneId(paneGuid);
    
    MyWpfPage page = new MyWpfPage();
    MyDockablePaneProvider provider = new MyDockablePaneProvider(page);
    
    application.RegisterDockablePane(paneId, "My Panel Title", provider);
    return Result.Succeeded;
}
```

## 3. Display and Interactivity
To show or focus the pane from a Ribbon pushbutton or a command, use `UIApplication.GetDockablePane(paneId).Show()`.

> [!WARNING]
> You cannot instantiate a `DockablePaneId` inside modeless threads without passing a valid Revit API context. Ensure all UI interactions requesting panel operations route their calls through the Revit UI thread.
