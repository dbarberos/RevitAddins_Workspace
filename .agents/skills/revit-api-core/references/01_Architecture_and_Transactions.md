# Skill: Base Architecture and Load Cycle in Revit API (Initial Boilerplate)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-001
* **Technical Area:** .NET Framework Extensibility / Injection in Revit Host
* **API dependencies:** `Autodesk.Revit.DB`, `Autodesk.Revit.UI`
* **Design Patterns:** Command Pattern (Interface-driven execution)
* **Target Version:** .NET Framework 4.8 / .NET Core (depending on Revit version)

---

## 2. Decomposition of the Base Architecture

The entry point of any executable extension in Revit requires the implementation of strict contracts imposed by the Host (`Revit.exe`). Unlike interpreted scripting, the command lifecycle is completely controlled by the Revit user interface through the Command pattern.

### A. The `IEExternalCommand` Contract
Any isolated add-in must inherit and implement the `IExternalCommand` interface. This interface forces the `Execute` method to be defined:

```csharp
public ResultExecute(
    ExternalCommandData commandData, 
    ref string message, 
    ElementId elements)
ExternalCommandData (Input): Acts as the container for the global context of the application at execution time. Allows access to the UIApplication, which exposes the active session, the document (UIDocument / Document) and the geometric database.
ref string message (Output/Error): Parameter by reference used exclusively if the command fails (Result.Failed). The string assigned here will be displayed natively by the Revit interface in an error dialog.
ElementId elements (Output/Selection): Set of element IDs that Revit will visually highlight in the model if the command fails, serving as a visual debugging tool for the end user.
B. The Return Mechanism (Result)
The Result enumerator manages post-execution state in the main Revit thread:
Result.Succeeded: Ends the operation and integrates the changes if the transaction is committed.
Result.Failed: Aborts any pending changes and activates the native dialog using the message parameter.
Result.Cancelled: Indicates that the user interrupted the action (e.g. canceling a screen selection), reverting previous operations without launching error alerts.
3. The Manifest File (.addin) and Loading Cycle
Revit is a closed environment that does not perform arbitrary scanning of DLLs. Requires an XML manifest (.addin) located in trusted directories (%AppData%\Autodesk\Revit\Addins\[Year]).
Semantic Structure of the Manifesto:
XML
<?xml version="1.0" encoding="utf-8" standalone="no"?>
<RevitAddIn>
  <AddIn Type="Command">
    <Name>guRoo Command</Name>
    <Assembly>Path\To\Your\Library\guRoo.dll</Assembly>
    <AddInId>A1B2C3D4-E5F6-7A8B-9C0D-1E2F3A4B5C6D</AddInId>
    <FullClassName>guRoo.Command</FullClassName>
    <VendorId>AussieBIMGuru</VendorId>
    <VendorDescription>Gavin Crump, [http://www.aussiebimguru.com](http://www.aussiebimguru.com)</VendorDescription>
  </AddIn>
</RevitAddIn>
Critical Configuration Guidelines (Build Pipeline):
FullClassName: Must be the fully qualified name (Namespace.Class). Any typing errors here will cause a catastrophic loading failure when starting Revit.
AddInId: Must be a universally unique GUID. If two commands share GUIDs, the second one will be blocked by collision.
Reference Properties (IDE): When linking RevitAPI.dll and RevitAPIUI.dll, the Copy Local property must be set to False. If set to True, the compiler will drag the base libraries into the output, causing internal memory conflicts and instability in the Revit process.
4. Refactoring Guide and Advanced Good Practices
The code base for this starter lesson is linear and monolithic. To scale it to a production environment, the development agent must apply the following software engineering rules:
Decoupling the Execute Method
The Execute method must act strictly as a Controller. It should not contain business logic or direct database queries.
Suggested Pattern: Separation of extraction from context.
C#
[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
public class Command : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementId elements)
    {
        // 1. Secure Context Initialization and Capture
        var uiApp = commandData?.Application ?? throw new ArgumentNullException(nameof(commandData));
        var doc = uiApp.ActiveUIDocument?.Document;
        
        if (doc == null)
        {
            message = "An active document cannot be found in the Revit session.";
            return Result.Failed;
        }

        try
        {
            // 2. Delegation to the specific business/Skill layer
            return RunBusinessLogic(doc);
        }
        catch (Exception ex)
        {
            // 3. Explicit Global Capture System (Logging)
            message = $"Critical failure in command: {ex.Message}";
            // The corporate Logging system would be integrated here (e.g. Serilog/NLog)
            return Result.Failed;
        }
    }

    private Result RunBusinessLogic(Document doc)
    {
        //Automation-specific code is executed in isolation here
        return Result.Succeeded;
    }
}
5. Agent Injection Instructions (Prompting Prompt)
When you act as the Development Agent of this project and are asked to initialize a command or extend the base, strictly follow this protocol:
Folder Structure: Make sure that classes that inherit from IExternalCommand are located in the /Commands or /EntryPoints folder.
GUID Generation: Always generate a fresh GUID for each command using cryptographic algorithms (Guid.NewGuid()), never duplicate an existing manifest.
Required Attributes: Every command class must be explicitly decorated with [Transaction(TransactionMode.Manual)]. Do not use Automatic mode, as it is implicitly deprecated for poor memory control practices.
Nullability Validation: Always validate the existence of ActiveUIDocument and Document before invoking any Revit SDK method.

***

### How to proceed?

This document serves as the "conceptual memory" that the agent will read before writing a single line of code in your project, ensuring that it respects clean architecture, manual transactions, and good compilation practices.