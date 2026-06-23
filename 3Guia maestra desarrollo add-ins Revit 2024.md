---

# 📘 **Master Professional Document — Autodesk Revit Add-in Development (2024+)**

## **1. Document Purpose**
This document defines the technical, architectural, and operational standards for developing professional add-ins for Autodesk Revit.  
Its objective is to:

- Guarantee consistency across projects.
- Facilitate automatic code generation using AI agents.
- Ensure compatibility with Revit 2024, 2025, and future versions.
- Establish a modern, scalable, and maintainable workflow framework.

---

## **2. Development Environment**

### **2.1 Recommended IDE**
- **Visual Studio 2022** (Community or higher)

### **2.2 Framework by Revit Version**

| Revit Version | Required Framework |
|---------------|--------------------|
| Revit 2024 and earlier | **.NET Framework 4.8** |
| Revit 2025+ | **.NET 8 (Windows)** |

### **2.3 Essential Dependencies**
Revit requires two main assemblies:

- `RevitAPI.dll`  
- `RevitAPIUI.dll`

In Revit 2025+, these references are managed through official NuGet packages.

---

## **3. Recommended Templates and Frameworks**

### **3.1 Nice3point Templates (Recommended Standard)**

To guarantee consistency and speed, **all projects must be generated using the .NET CLI with Nice3point templates**. Neither the AI nor the developer should create the `.csproj` or basic folder structure manually from scratch.

Template installation (one-time setup per machine):

```bash
dotnet new install Nice3point.Revit.Templates
```

**Creating a new base project:**

```bash
dotnet new revit -n {{ProjectName}}
```

Advantages of using this workflow:

- Automatic configuration of the `.addin` manifest.
- Preconfigured build events (automatic copying to the Revit add-ins directory).
- Integrated multi-version support.
- Professional structure from minute zero.

### **3.2 Critical `.csproj` File Configuration**

When using modern templates (like Nice3point), the compiler automatically injects many global namespaces (Revit API, Nice3point Extensions, generic .NET collections, JetBrains.Annotations, etc.).  

**Golden Rule:**
- **ALWAYS** ensure that **`<ImplicitUsings>enable</ImplicitUsings>`** is configured in your `.csproj` file. 
- **Never set** `<ImplicitUsings>disable</ImplicitUsings>`. Disabling it will cause compilation failures for essential extension methods (like `Application.CreatePanel()`), generic collections, and other dependencies, requiring manual imports across all your code.

---

## **4. Anatomy of a Revit Add-in**

Every add-in consists of three fundamental elements:

1. **Manifest File (.addin)**  
2. **Application Class (`IExternalApplication`)**  
3. **Command Classes (`IExternalCommand`)**

---

### **4.1 Manifest File (.addin)**

```xml
<?xml version="1.0" encoding="utf-8"?>
<RevitAddIns>
  <AddIn Type="Application">
    <Name>{{PROJECT_NAME}}</Name>
    <Assembly>{{ASSEMBLY_PATH}}</Assembly>
    <AddInId>{{GUID}}</AddInId>
    <FullClassName>{{NAMESPACE}}.Application</FullClassName>
    <VendorId>{{VENDOR_ID}}</VendorId>
    <VendorDescription>{{VENDOR_DESCRIPTION}}</VendorDescription>
  </AddIn>
</RevitAddIns>
```

#### **Rules:**
- The GUID must be unique.
- The Assembly path must point to the final `.dll`.
- The FullClassName must match the namespace and class name exactly.

---

### **4.2 Command Class (`IExternalCommand`)**

```csharp
[Transaction(TransactionMode.Manual)]
public class {{COMMAND_NAME}} : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        UIApplication uiApp = commandData.Application;
        UIDocument uiDoc = uiApp.ActiveUIDocument;
        Document doc = uiDoc.Document;

        try
        {
            {{COMMAND_LOGIC}}
            return Result.Succeeded;
        }
        catch (Exception ex)
        {
            message = ex.Message;
            return Result.Failed;
        }
    }
}
```

#### **Rules:**
- Always use `TransactionMode.Manual`.
- Handle exceptions in a controlled manner.
- Never modify the document without an active transaction.

---

### **4.3 Application Class (`IExternalApplication`)**

```csharp
public class Application : IExternalApplication
{
    public Result OnStartup(UIControlledApplication app)
    {
        string tab = "{{TAB_NAME}}";
        app.CreateRibbonTab(tab);

        RibbonPanel panel = app.CreateRibbonPanel(tab, "{{PANEL_NAME}}");

        PushButtonData btn = new PushButtonData(
            "{{BUTTON_ID}}",
            "{{BUTTON_TEXT}}",
            Assembly.GetExecutingAssembly().Location,
            "{{NAMESPACE}}.Commands.{{COMMAND_NAME}}"
        );

        panel.AddItem(btn);
        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication app)
    {
        return Result.Succeeded;
    }
}
```

---

## **5. Golden Rules of the Revit API**

### **5.1 Transactions**

```csharp
using (Transaction t = new Transaction(doc, "Description"))
{
    t.Start();
    // Changes
    t.Commit();
}
```

### **5.2 Querying Elements**

```csharp
var walls = new FilteredElementCollector(doc)
    .OfCategory(BuiltInCategory.OST_Walls)
    .WhereElementIsNotElementType()
    .ToElements();
```

### **5.3 Units and ForgeTypeId**
From Revit 2022+:

- Avoid obsolete integer-based unit types.
- Use `UnitTypeId`, `SpecTypeId`, and `ForgeTypeId` classes.

---

## **6. Standard Folder Structure**

When generating a project using the template (and adapting it if necessary), the final structure must align with the following:

```text
/src
  /{{ProjectName}}
    /Application
    /Commands
    /Services
    /Models
    /UI
      /Views        <-- (WPF windows and controls .xaml)
      /ViewModels   <-- (Presentation logic .cs, MVVM)
    /Utils
    /Resources      <-- (For Ribbon .png icons of 16x16 and 32x32 px)
/addin
  {{ProjectName}}.addin
/docs
  README.md
  CHANGELOG.md
```

*Critical Note: Every new add-in must always be created as an independent folder in the workspace root (`RevitAddins_Workspace/{{ProjectName}}`).*

---

## **7. Naming Conventions**

| Element | Convention |
|----------|------------|
| **Root Namespace** | **`{{ProjectName}}`** (e.g. `MyAwesomeAddin`) |
| Classes | PascalCase |
| Methods | PascalCase |
| Variables | camelCase |
| Commands | `Cmd{Action}{Entity}` |
| Services | `{Entity}Service` |
| Panels | `{Category}Panel` |
| Tabs | `{Company}` |

---

## **8. Recommended Design Patterns**

- **Service Layer** for business logic.
- **Command Handler** for complex commands.
- **Result<T>** for safe operations.
- **Centralized Logger**.
- **MVVM** for WPF interfaces.

---

## **9. Exception Handling**

#### **Rules:**
- Never show raw exceptions to users.
- Always log technical details.
- Use `TaskDialog` for user-friendly errors.

```csharp
catch (Exception ex)
{
    Logger.Log(ex);
    TaskDialog.Show("Error", ex.Message);
    return Result.Failed;
}
```

---

## **10. Complete Workflow**

1. Install Nice3point templates.
2. Create project using templates.
3. Implement commands.
4. Configure Ribbon UI.
5. Select target version (R24 or R25).
6. Compile (automatic copying of `.addin`).
7. Debug in Revit.

---

## **11. Documentation and Development Logs**

To ensure traceability, debugging, and continuous learning, **a log of every creation, iteration, or modification of an add-in must be maintained**.

- **Strict Rule for the Agent (IA):** Whenever the user indicates that the current task is completed or **that the changes work correctly**, the Agent must copy the generated artifacts following a modular structure.
  - Project documentation must be stored in `docs/references/`, `docs/assets/`, or `docs/scripts/`.
  - The files must be named using the strict pattern: `[artifact_name]_[keywords]_[YYYY-MM-DD_HHmm].md`.
  - Standard artifacts include:
    - `implementation_plan_[keywords]_[YYYY-MM-DD_HHmm].md`
    - `task_[keywords]_[YYYY-MM-DD_HHmm].md`
    - `walkthrough_[keywords]_[YYYY-MM-DD_HHmm].md`

This guarantees there is always a searchable, auditable technical log to understand how the code was structured and why design decisions were made.

---

## **12. WPF Best Practices & Troubleshooting**

When developing complex WPF interfaces for Revit (especially hierarchical explorers), keep in mind the following detected issues and their solutions:

### **12.1 TreeView Virtualization and Container Recycling**
**Issue:** Using `VirtualizingStackPanel.VirtualizationMode="Recycling"` on a `TreeView` with two-way bindings on the `IsExpanded` property can produce visual state corruption during filtering or reconstruction. Old visual containers might "push" their previous expansion state to new data objects before resetting, causing spontaneous unwanted branch expansions.

**Solution:** 
- Set the virtualization mode to **`VirtualizationMode="Standard"`** in the TreeView XAML.
- This ensures visual containers are cleanly destroyed and recreated, preventing "ghost" states from transferring between nodes.

```xml
<TreeView VirtualizingStackPanel.IsVirtualizing="True"
          VirtualizingStackPanel.VirtualizationMode="Standard">
```

### **12.2 Expansion Conflicts due to Selection Restoration**
**Issue:** Rebuilding a tree and automatically restoring element checkboxes (selection) often uses recursive logic to expand parents so the checked item is visible. However, if the user manually collapsed a branch, this logic will overwrite their UI preferences, forcing open branches that should be closed.

**Solution:**
- Implement a control parameter (e.g., `bool forceExpand`) in the selection restoration logic.
- **`forceExpand = true`**: Only during the initial launch of the add-in (to show active selections).
- **`forceExpand = false`**: During rebuilds triggered by filters or visual organization switches, allowing visual collapse/expand preferences to be respected.
