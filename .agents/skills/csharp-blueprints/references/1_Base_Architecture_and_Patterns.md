# Guide 1: Base Architecture and Patterns in the Revit API

This guide lays the foundation for your add-in development, covering class organization, implementing mandatory Revit interfaces, managing global variables, and building scalable code using generics.

## 1. Classes, Properties, and Access Modifiers

In add-in development, code must be carefully organized under different **Namespaces** to avoid name clashes. Classes act as templates or "molds" that define what objects can do.

**Best Practices and Concepts:**
*   **Static vs. Instantiated Classes**: If you need to create a "Toolkit" or set of utilities that you call directly without creating a new object, use `public static class`. If you will create multiple copies or represent an object (such as a form result), use a standard `public class`.
*   **Private Fields vs. Public Properties**: Hide class information using private fields (camelCase) and expose it using public properties (PascalCase) with get and set methods. This protects your code from being modified unsafely by other classes.

**Code Example: Base class to handle form results (FormResult)**

```csharp
namespace Guru.Forms 
{ 
    public class FormResult 
    { 
        // Public property that the rest of the code can read and modify 
        public bool Cancelled { get; set; } 
        public bool IsValid { get; set; } 

        // Constructor for no arguments (default state) 
        public FormResult() 
        { 
            this.Cancelled = true; 
            this.IsValid = false; 
        } 

        // Method to quickly invalidate the form 
        public void SetToInvalid() 
        { 
            this.Cancelled = true; 
            this.IsValid = false; 
        } 
    } 
}
```

*In this example, we use the `this` keyword to refer to the current instance of the class.*

---

## 2. Implementing Revit Interfaces

The Revit API requires us to use "interfaces" which act as mandatory contracts that our classes must implement. These interfaces provide the entry points for our code.

### A. The IExternalApplication Interface (App Startup)
This class runs when Revit starts up and shuts down. It provides access to the `UIControlledApplication`, which is needed to build the Ribbon (toolbar) before the user opens any models.

**Code Example:**

```csharp
using Autodesk.Revit.UI; 

namespace Guru 
{ 
    public class Application : IExternalApplication 
    { 
        public Result OnStartup(UIControlledApplication uiControlledApp) 
        { 
            // Logic to create Ribbon tabs and buttons goes here... 
            return Result.Succeeded; // Mandatory return to satisfy the interface 
        } 

        public Result OnShutdown(UIControlledApplication uiControlledApp) 
        { 
            // Cleanup logic when closing Revit 
            return Result.Succeeded; 
        } 
    } 
}
```

### B. The IExternalCommand Interface (Button Click)
This interface requires the `Execute` method. When the user clicks your Ribbon button, this is the code that runs. It provides `ExternalCommandData`, which allows you to retrieve the currently active document. You must decorate this class with the transaction attribute `[Transaction(TransactionMode.Manual)]` if you plan to modify the model.

**Code Example:**

```csharp
using Autodesk.Revit.Attributes; 
using Autodesk.Revit.DB; 
using Autodesk.Revit.UI; 

namespace Guru.Commands.General 
{ 
    [Transaction(TransactionMode.Manual)] 
    public class CommandTest : IExternalCommand 
    { 
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements) 
        { 
            // Extract the application and active document 
            UIApplication uiApp = commandData.Application; 
            UIDocument uiDoc = uiApp.ActiveUIDocument; 
            Document doc = uiDoc.Document; 

            // Main logic for your tool goes here... 
            return Result.Succeeded; 
        } 
    } 
}
```

---

## 3. Global Variables and the "Idling" Event

Unlike other languages, C# does not have global variables by default. Sometimes we need continuous access to the `UIApplication`, even outside the normal execution of a command.

**The Problem**: During Revit startup (`OnStartup`), the `UIApplication` is not yet available.
**The Solution**: We subscribe to a Revit event called `Idling` (when Revit first becomes idle). Once it fires, we capture the application, save it in our static `Globals` class, and **immediately unsubscribe** to avoid consuming resources for the rest of the session.

**Code Example: Event Management**

```csharp
public static class Globals 
{ 
    // Global variable that will hold the application reference 
    public static UIApplication UiApp { get; set; } 

    // This method is called during OnStartup 
    public static void RegisterProperties(UIControlledApplication uiControlledApp) 
    { 
        // Subscribe to the Idling event 
        uiControlledApp.Idling += RegisterUiApp; 
    } 

    // This method captures the event when it fires 
    private static void RegisterUiApp(object sender, Autodesk.Revit.UI.Events.IdlingEventArgs e) 
    { 
        // 1. Immediately unsubscribe so it doesn't run again 
        var uiControlledApp = sender as UIControlledApplication; 
        if (uiControlledApp != null) uiControlledApp.Idling -= RegisterUiApp; 

        // 2. Extract the sender as UIApplication and save it 
        if (sender is UIApplication app) 
        { 
            UiApp = app; 
        } 
    } 
}
```

---

## 4. Generic Methods and Classes `<T>`

As codebases grow, you will often find yourself casting objects dynamically, which can be unsafe. Generics allow classes and methods to accept a type that is specified at runtime, improving type safety, readability, and IDE autocomplete.

**Best Practices:**
*   Replace generic uses of `object` with `T` in your utility classes.
*   Use `default(T)` instead of `null` when a type may not exist. Value types (such as `int` or `bool`) cannot be null, so `default(T)` dynamically resolves to `0` for integers, `false` for booleans, etc.

**Code Example: Enhancing the FormResult class with Generics**

```csharp
// By adding <T>, we specify that this class holds an object of any type
public class FormResult<T> 
{ 
    // Object is no longer an ambiguous "object", but of the specified type T 
    public T Object { get; set; } 
    public List<T> Objects { get; set; } 

    public FormResult() 
    { 
        // Initialize values based on the default value of the provided type 
        this.Object = default(T); 
        this.Objects = new List<T>(); 
    } 
}
```

*Practical Usage: Instead of retrieving generic and unsafe information, we define the type when we use it:* `FormResult<ViewSheet> form = new FormResult<ViewSheet>();`. *Now the IDE and the compiler know exactly that `form.Object` is a sheet (`ViewSheet`), eliminating unnecessary casting and minimizing runtime errors.*
