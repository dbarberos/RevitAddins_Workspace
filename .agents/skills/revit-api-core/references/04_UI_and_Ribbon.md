# Skill: User Interface Integration (Ribbon UI and IExternalApplication)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-004
* **Technical Area:** User Interface / Host Integration
* **API dependencies:** `Autodesk.Revit.UI`, `System.Reflection`, `System.Windows.Media.Imaging`
* **Design Patterns:** Bootstrap / Initialization Pattern
* **Visual Impact:** High (Defines the user experience and accessibility of the tools)

---

## 2. Architecture of IExternalApplication



To create tabs, panels, and buttons in Revit, the Add-in must run when Revit starts, not when the user clicks a button. This requires implementing the `IExternalApplication` interface, which requires two fundamental methods:

1. **`OnStartup(UIControlledApplication application)`:** Runs during Revit startup. Here the graphical interface (Ribbon) is built.
2. **`OnShutdown(UIControlledApplication application)`:** Executes when Revit closes. It is used to free resources (e.g. close connections to external databases or stop registration/logging processes).

### Base Structure
```csharp
public class App : IExternalApplication
{
    public Result OnStartup(UIControlledApplication application)
    {
        // 1. Create Tab (Optional, the default Add-Ins tab can be used)
        string tabName = "My Custom Tools";
        application.CreateRibbonTab(tabName);

        // 2. Create Panel within the Tab
        RibbonPanel panel = application.CreateRibbonPanel(tabName, "Architecture");

        // 3. Add Buttons to the Panel
        CreateButtons(panel);

        return Result.Succeeded;
    }

    public ResultOnShutdown(UIControlledApplication application)
    {
        return Result.Succeeded;
    }
}
3. Button Injection (PushButtonData) and Reflection
For a button to execute a command (IExternalCommand), Revit needs to know exactly where the compiled .dll file is (the Assembly) and the name of the class to execute.
Common Antipattern (Static Routes)
C#
// FATAL: Using absolute paths ("C:\Users\...") breaks the Add-in when changing computers.
string dllPath = @"C:\Users\Admin\Desktop\MyAddin\bin\Debug\MyAddin.dll";
Optimized Pattern (System.Reflection)
The correct way is to ask the system at runtime where the currently running code is located.
C#
private void CreateButtons(RibbonPanel panel)
{
    // Get the dynamic path of the current .dll
    string assemblyPath = Assembly.GetExecutingAssembly().Location;

    // Create the button data container
    PushButtonData buttonData = new PushButtonData(
        "cmdCreateWalls", // Internal name (unique)
        "Create\nWalls", // Display name (accepts line breaks \n)
        assemblyPath, // Assembly Path
        "MyAddin.Commands.CrearMuros" // Namespace + IExternalCommand class
    );

    // Add descriptive tooltips
    buttonData.ToolTip = "Create base walls from selected lines.";
    buttonData.LongDescription = "Make sure you are in a floor plan view before running.";

    // Insert the button into the panel
    PushButton button = panel.AddItem(buttonData) as PushButton;

    // Assign Icons (Requires WPF conversion)
    // button.LargeImage = GetIcon("icon32x32.png");
}
4. Graphic Resources Management (Icons)
Revit uses the WPF (Windows Presentation Foundation) graphics engine for its UI. Button images must be converted to ImageSource (specifically BitmapImage).
LargeImage: 32x32 pixel icons.
Image (Small): 16x16 pixel icons.
Graphics resources should not be loaded from external disk paths. They must be integrated (Embedded Resources) within the .dll itself to ensure that they are not lost.
5. Agent Injection Instructions (Prompting Prompt)
When you need to create or modify the Add-in user interface, apply these architectural rules:
Reflection Required: ALWAYS use System.Reflection.Assembly.GetExecutingAssembly().Location to bind commands to buttons. Never use static strings for routes.
Dual Manifest: If the Add-in uses IExternalApplication, the .addin manifest must change the <AddIn Type="Command"> node to <AddIn Type="Application">. The <FullClassName> attribute should point to the class that implements the UI, not the individual commands.
Panel Modularity: Don't clutter a single RibbonPanel. If there are more than 5 tools, group the commands logically in multiple panels (e.g. "Architecture", "MEP", "Data") or use pulldown buttons (PulldownButton).
Silent Error Handling in UI: If an error occurs within OnStartup (e.g. an icon is not found), catch the exception with a try-catch block and return Result.Failed or Result.Succeeded (if it is a minor UI error) without launching invasive dialogs that interrupt the start of Revit for the user.