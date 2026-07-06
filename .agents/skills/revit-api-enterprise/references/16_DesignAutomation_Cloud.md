# Skill: Cloud Execution and Headless Architecture (APS Design Automation for Revit)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-016
* **Technical Area:** Cloud Computing / Headless Execution / Autodesk Platform Services (APS)
* **API dependencies:** `Autodesk.Revit.ApplicationServices`, `DesignAutomationBridge`
* **Design Patterns:** Inversion of Control (IoC), Worker/Job Queue, RESTful API
* **Operational Impact:** Allows you to run Revit routines on Autodesk servers (batch processing, bulk generation of nightly PDFs/IFCs, direct connection to web integrations) without requiring active local licenses or the intervention of a human user.

---

## 2. The Paradigm Shift: From `IExternalCommand` to `IExternalDBApplication`



To run code in the cloud (Design Automation API), there is no drawing canvas, there is no mouse, and there is no Ribbon. It is a pure console environment (Headless Revit). 

Therefore, the base architecture changes radically:
* `Autodesk.Revit.UI` is no longer used. References to `RevitAPIUI.dll` should be completely removed from the project.
* The entry point changes from `IExternalCommand` to **`IExternalDBApplication`**.
* The Add-in is packaged in a special format called `AppBundle` and uploaded to Autodesk servers.

### The New Base Contract
```csharp
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using DesignAutomationFramework;

public class CloudApp : IExternalDBApplication
{
    public ExternalDBApplicationResult OnStartup(ControlledApplication app)
    {
        // Subscription to the event that is fired when the cloud loads the submitted model
        DesignAutomationBridge.DesignAutomationReadyEvent += HandleDesignAutomationReadyEvent;
        return ExternalDBApplicationResult.Succeeded;
    }

    public ExternalDBApplicationResult OnShutdown(ControlledApplication app)
    {
        return ExternalDBApplicationResult.Succeeded;
    }

    private void HandleDesignAutomationReadyEvent(object sender, DesignAutomationReadyEventArgs e)
    {
        //Active document is pulled from the event, not from the UI
        Document doc = e.DesignAutomationData.RevitDoc;

        // Execution of silent transactional logic (SKILL 3 and 5)
        RunAuditoriaCloud(doc);

        // Save changes and tell the cloud that the task is finished
        e.Succeeded = true; 
    }
}
3. I/O Management in the Cloud (Workitems and JSON)
In the cloud, the user cannot type a value in a text box. All input and output (I/O) flow is done using files.
The operating model works through Workitems. A web server (such as Node.js or an Azure Function) makes a REST request to APS delivering three things:
Input URL: A download link for the original .rvt model.
Input Arguments: A params.json file with configuration values ​​(e.g. { "wall_height": 3.5, "audit": true }).
Output URL: An upload link (pre-signed Upload URL) where the Add-in will send the modified .rvt model or the resulting Excel report.
Deserialization of Arguments in the Add-in
The Add-in should look for the parameters file in the current Working Directory of the Autodesk server:
C#
private void ExecuteAuditoriaCloud(Document doc)
{
    string paramsPath = Path.Combine(Directory.GetCurrentDirectory(), "params.json");
    
    if (File.Exists(paramsPath))
    {
        string json = File.ReadAllText(paramsPath);
        // Deserialize using System.Text.Json (SKILL 13)
        MyParameters payload = JsonSerializer.Deserialize<MyParameters>(json);
        
        // Execute logic with payload.wall_height
    }
}
4. Antipattern Matrix (The Risk of Cloud Crash)
When migrating legacy desktop code to Design Automation, the Autodesk server will abort the job immediately if it detects certain memory calls.
Common Antipattern (Graphical Interface Dependency)
C#
// FATAL: If this code is executed on an APS Headless server, 
// the cloud Revit process will crash as it cannot find the Windows thread (User32).
TaskDialog.Show("Process", "Starting calculation...");
UIDocument uidoc = new UIDocument(doc);
ElementId id = uidoc.Selection.PickObject(ObjectType.Element).ElementId;
Optimized Pattern (UI Dependency Injection)
The agent must design the logical core (Core) completely separating it from the visualization layer. If a status is required to be reported, the standard Log system should be used (writing to Console.WriteLine that APS automatically captures) instead of dialog windows.
5. Agent Injection Instructions (Prompting Prompt)
When developing cloud-oriented components using APS Design Automation, follow these architectural rules:
Total UI Namespace Prohibition: Using or referencing the Autodesk.Revit.UI namespace is strictly prohibited. Any attempt to use TaskDialog, UIDocument, Selection or IExternalCommand will cause the AppBundle to immediately fail.
Logging to Standard Console: The Autodesk cloud captures standard output streams. Use Console.WriteLine() to log progress, errors, or warnings. This information will form the final text report of the Workitem that the external web server will consume to audit the success of the operation.
Blind Exception Handling: Wraps the main HandleDesignAutomationReadyEvent event in a global try-catch block. If an unhandled exception occurs, be sure to set e.Succeeded = false and do a Console.WriteLine(ex.Message) so the external orchestrator knows exactly why the Workitem failed.
Using IExternalDBApplication: Configure the .addin manifest file so that the <AddIn> node is of type DBApplication and not Command or Application.

***
With this layer, the knowledge base would range from the lowest local manipulation of C++ (Marshalling) to the asynchronous execution of microservices architecture in the cloud using *Design Automation*.