# Guide 2: Efficient User Interface Design (Ribbon)

This guide covers building tabs, panels, buttons, and submenus in Autodesk Revit. It focuses on using extension methods to keep your Ribbon creation modular, managing visual resources (embedded icons), and designing efficient menu layouts (PullDowns/Stacks) to maximize Ribbon space.

## 1. Extension Methods for UI Creation

Normally, to add a panel to a tab, you would have to pass the application as an argument to a static utility method. To make the code more intuitive, we use **Extension Methods** in C#. By using the `this` keyword, we can "extend" the native classes of the Revit API.

**Code Example: Extending UIControlledApplication and RibbonPanel**

```csharp
namespace Guru.Extensions 
{ 
    public static class UiApplicationExt 
    { 
        // Extends the application to easily add a panel
        public static RibbonPanel AddRibbonPanel(this UIControlledApplication uiApp, string tabName, string panelName) 
        { 
            return uiApp.CreateRibbonPanel(tabName, panelName); 
        } 
    } 

    public static class RibbonPanelExt 
    { 
        // Extends a panel to easily add a push button
        public static PushButton AddPushButton(this RibbonPanel panel, PushButtonData buttonData) 
        { 
            return panel.AddItem(buttonData) as PushButton; // Casts the result to PushButton 
        } 
    } 
}
```

*Practical Usage: In your `OnStartup` method, you can now write `uiApp.AddRibbonPanel(...)` directly instead of writing repetitive utility helper calls.*

---

## 2. Simple Buttons: PushButton

The `PushButton` is the basic execution button. To create one in Revit, you first need a configuration object called `PushButtonData`. The required arguments are:
1.  **Internal Name**: A unique identifier (not visible to the user).
2.  **Display Text**: The text that appears on the Revit Ribbon.
3.  **Assembly Path**: The absolute path to your `.dll` file.
4.  **Full Class Name**: The namespace and class name of the class that implements `IExternalCommand` (`Execute` method).

**Code Example: Generating the Button**

```csharp
using System.Reflection; 
using Autodesk.Revit.UI; 

// 1. Get the path of the currently executing assembly 
string assemblyPath = Assembly.GetExecutingAssembly().Location; 

// 2. Define the button configuration data 
PushButtonData btnData = new PushButtonData( 
    "cmdMyTool", // Internal Name 
    "Run\nTool", // Display Text (\n creates a line break) 
    assemblyPath, // Path to DLL 
    "Guru.Commands.MyCommand" // Namespace + Class 
); 

// 3. Add it to the panel using our custom extension method 
PushButton myButton = myPanel.AddPushButton(btnData);
```

---

## 3. Professional Tooltips and Icons

Avoid using local file paths (e.g. `C:\my_images\...`), as they will fail when distributing the plugin. You must embed your images as **Resource** or **Resource Include** in Visual Studio.

### Icon Management
Revit uses two standard icon sizes at 96 DPI: **16x16 pixels** (for small dropdown menus or stacked rows) and **32x32 pixels** (for main Ribbon buttons). Revit requires these images to be converted into the native Windows `ImageSource` type.

**Code Example: Extracting an Embedded Icon**
To load the image from the assembly, use WPF's `pack://application` URI scheme (recommended) or a resource stream:

```csharp
// Resource path (Note: periods are used instead of slashes) 
string resourcePath = "Guru.Resources.Icons32.MyIcon32.png"; 

// Extract the file from assembly resources (Stream) 
using (Stream stream = assembly.GetManifestResourceStream(resourcePath)) 
{ 
    // Decode the PNG into an ImageSource for Revit 
    PngBitmapDecoder decoder = new PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default); 
    ImageSource imageSource = decoder.Frames[0]; 

    // Assign to the button properties (LargeImage = 32x32, Image = 16x16) 
    myButton.LargeImage = imageSource; 
}
```

### Tooltip Management
For tooltips (the helpful description that appears when hovering over a button), it is best to create a `.resx` (Resource File) that functions as a translation dictionary. When Revit loads, use C#'s `ResourceManager` to load these help texts into a global Dictionary in memory, and then assign them: `myButton.ToolTip = "Perform selection filtering based on parameters."`.

---

## 4. Saving Space: PullDowns and Stacks

As you add more tools, the Ribbon will quickly become cluttered. Grouping buttons is essential for a clean user experience (UX).

### A. PullDownButton (Dropdown Menus)
A `PullDownButton` groups multiple commands under a single dropdown arrow. A PullDown button **does not execute any command directly**, so its configuration class (`PulldownButtonData`) does not require an assembly path or execution class name, only its internal identifier and display text.

**Code Example:**

```csharp
// 1. Create the dropdown menu configuration 
PulldownButtonData pullDownData = new PulldownButtonData("wallsGroup", "Wall\nTools"); 

// 2. Add the PullDown button to the Panel 
PulldownButton pullDown = myPanel.AddItem(pullDownData) as PulldownButton; 

// 3. Add PushButtons INSIDE the PullDown menu 
pullDown.AddPushButton(btnData1); // Button 1 
pullDown.AddPushButton(btnData2); // Button 2
```

### B. Stacked Items (Stacked Buttons)
If you want buttons to be visible immediately but take up less space, you can stack up to three buttons (PushButtons or PullDowns) vertically in the space of a single large button.

**Code Example: Stacking 3 Buttons**

```csharp
// Use the AddStackedItems method and pass 2 or 3 PushButtonData/ComboBoxData objects 
IList<RibbonItem> stackedItems = myPanel.AddStackedItems(btnData1, btnData2, btnData3); 
// Revit will automatically render them vertically using their 16x16 pixel icons.
```

---

## 5. Revit + WPF Interoperability (.NET)

When developing modern WPF user interfaces inside Revit, there is a golden rule to ensure add-in stability:

### The Dispatcher Problem
In a standard WPF application, developers often use `System.Windows.Application.Current.Dispatcher` to update the interface from background threads. However, in Revit (which is a native C++ host application running .NET assemblies), `Application.Current` is usually **null**. Trying to access its dispatcher will cause a `NullReferenceException`.

### The Solution: Safe Dispatcher
For asynchronous UI updates or to ensure code executes safely on the main thread, always use:

```csharp
// SAFE METHOD (Highly recommended in Revit)
var dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
dispatcher.InvokeAsync(() => {
    // UI update logic (e.g. clearing a TextBox)
    this.MyProperty = string.Empty;
});
```

*Usage: Apply this pattern in your ViewModels or Commands when you need to clear text fields or update bound collections after executing heavy Revit API processes.*
