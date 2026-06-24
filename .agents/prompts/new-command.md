# Prompt: Scaffolding New Commands in Revit (C# / Python)

This prompt standardizes the step-by-step sequential flow to create a new command in Revit, whether using compiled C# code or a dynamic pyRevit script.

---

## 🎯 Task Objective
Create and inject a new command that integrates into the Revit Ribbon interface, applying interface injection for model isolation and safe transactions.

---

## 🚀 Sequential Flow for C# Commands

### Step 1: Service Definition and Contract (Interface Injection)
*   Extract the API method signature to a pure interface in the `/Services/` folder:
    ```csharp
    public interface IMyFeatureService
    {
        IList<MyDataModel> ExecuteQuery();
    }
    ```
*   Implement the actual service consuming the Revit API.

### Step 2: C# Command Class Creation
*   Create a `Cmd[Action][Entity].cs` file in the `Commands/` folder.
*   Apply the manual transaction attribute:
    ```csharp
    [Transaction(TransactionMode.Manual)]
    public class CmdMyAction : IExternalCommand
    {
        private readonly IMyFeatureService _service;
        
        // Primary constructor or via dependency injection
        public CmdMyAction(IMyFeatureService service)
        {
            _service = service;
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Execute query or delegate to services
            return Result.Succeeded;
        }
    }
    ```

### Step 3: Ribbon UI Linking (`Application.cs`)
*   Locate the Ribbon initialization in the `OnStartup` method of `Application.cs` and inject the corresponding button referencing the `FullClassName` of the command class.

---

## 🚀 Sequential Flow for pyRevit Scripts (Python)

### Step 1: Configure the Folder Hierarchy
*   Create the corresponding folder under the pyRevit extension on disk:
    `MyModule.extension > MyPanel.panel > MyAction.pushbutton`

### Step 2: Write the Configuration Manifest (`bundle.yaml`)
*   Create the `bundle.yaml` file with minimal descriptive metadata:
    ```yaml
    title: "Button Name"
    tooltip: "Brief functional description of the macro when hovering."
    ```

### Step 3: Write the Logic File (`script.py`)
*   Create the `script.py` file injecting the pyRevit context initialization and transaction wrapper:
    ```python
    # -*- coding: utf-8 -*-
    from pyrevit import revit, DB, UI
    from pyrevit import forms

    # Retrieve active session
    doc = revit.doc

    # Wrap write executions in native transactions
    with revit.Transaction("Action Name"):
        # Your Revit model manipulation logic here
        pass
    ```
