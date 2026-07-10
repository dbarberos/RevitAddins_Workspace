# Skill Reference: WPF XAML and MVVM Architecture

## 1. MVVM Strict Decoupling Protocol
To build commercial-ready, stable, and testable Revit Add-ins, developers must enforce a strict separation of concerns using the Model-View-ViewModel (MVVM) pattern.

*   **View (XAML)**: Handles visual presentation only. Must not contain code-behind (`.xaml.cs`) logic that accesses the Revit database.
*   **ViewModel**: Manages the state and user actions. Subscribes to standard notifications and dispatches business logic actions. Does NOT execute Revit transactions directly on UI/background threads.
*   **Model**: Represents the database data structures (BIM elements, properties, geometry).

> [!IMPORTANT]
> **No Direct Revit API Access in UI Thread**: Triggering database modifications directly inside WPF events or commands will throw a thread-access exception. Use WPF `ICommand` binding, set backing values, and invoke `ExternalEventBridge.Raise()` to execute modifications safely on Revit's main thread.

## 2. WPF Property Binding & Notifications
Use `INotifyPropertyChanged` to notify WPF controls when C# values change.

### Code Blueprint: ViewModel Binding
```csharp
public class MainViewModel : ViewModelBase
{
    private string _elementName;
    
    public string ElementName
    {
        get => _elementName;
        set => SetProperty(ref _elementName, value);
    }
    
    public ICommand ApplyFilterCommand { get; }
    
    public MainViewModel(IExternalEventHandler handler, ExternalEvent externalEvent)
    {
        ApplyFilterCommand = new RelayCommand(() => 
        {
            // Set parameters and trigger Revit thread safely
            // (handler as FilterHandler).ElementName = this.ElementName;
            externalEvent.Raise();
        });
    }
}
```

## 3. UI Styling & Accessibility Guidelines
- **Responsive Grids**: Use `Grid` with star/auto dimensions instead of hardcoded margins to ensure layout responsiveness.
- **Native Look & Feel**: Follow Revit's native theme (gray background `#EEEEEE`, standard Outlined TextBoxes) or integrate the Modern Fluent UI system (`Wpf.Ui`) for a premium look.
- **WPF UI Virtualization**: For displaying huge datasets (like lists of all model elements), always enable virtualization on ListView / TreeView / DataGrid to prevent severe UI rendering freezes.
