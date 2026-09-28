# Architecture & Technical Guide — Nice3point.TUnit.Revit (RevitUnit)

## 1. Overview and Core Philosophy

`Nice3point.TUnit.Revit` is an in-process testing framework designed specifically for Autodesk Revit add-ins. Unlike headless unit test runners (which require mocking all Revit API interfaces), `RevitUnit` executes tests directly within an active Revit process, granting full access to:
- **`UIApplication` (`Application` property):** Ribbon panels, pushbuttons, dockable panes, active selection, view managers, and UI events.
- **`Autodesk.Revit.DB.Document`:** Real Revit database transactions, element creation, parameter bindings, geometric analyses, and extensible storage.
- **WPF & Modern UI:** WPF windows and dialogs instantiated under Revit's native host window.

Built on **TUnit** and **Microsoft.Testing.Platform**, tests benefit from source generators, asynchronous assertions (`await Assert.That(...)`), and fine-grained lifecycle hooks.

---

## 2. The Revit Threading Challenge & RevitThreadExecutor

### The STA Invariant
The Revit API enforces strict single-threaded access. Invoking API methods from external threads (such as standard test runners' worker thread pools) throws an `InvalidOperationException`:
> *"Starting a transaction from an external application running outside of API context is not allowed."*

### The Solution: `RevitThreadExecutor`
`Nice3point.TUnit.Revit` introduces dedicated executor attributes that marshal test calls onto Revit's primary UI thread:
- **`[TestExecutor<RevitThreadExecutor>]`:** Forces the test method to execute within the Revit API context.
- **`[HookExecutor<RevitThreadExecutor>]`:** Forces setup (`[Before(Test)]`) and teardown (`[After(Test)]`) hooks to execute within the Revit API context.

When a test class inherits from `RevitApiTest`, the framework automatically manages the connection to Revit and exposes the `Application` property (`Autodesk.Revit.UI.UIApplication`).

---

## 3. UI Level Testing (`UIApplication`)

With `Application` available in `RevitApiTest`, the agent can inspect the active Ribbon hierarchy:
```csharp
[Test]
[TestExecutor<RevitThreadExecutor>]
public async Task RibbonPanel_TablePlus_IsRegistered()
{
    var ribbonPanels = Application.GetRibbonPanels("TablePlus");
    await Assert.That(ribbonPanels).IsNotNull();
    await Assert.That(ribbonPanels).IsNotEmpty();
}
```

Key UI inspection points:
- **Ribbon Tabs & Panels:** `Application.GetRibbonPanels(...)`.
- **Active Document:** `Application.ActiveUIDocument`.
- **Selection:** `Application.ActiveUIDocument.Selection`.
- **Dockable Panes:** `Application.GetDockablePane(paneId)`.

---

## 4. DB Level Testing & Document Isolation Pattern

To avoid shared state contamination between tests, tests operating on Revit elements must create an ephemeral blank document per test and dispose of it upon completion.

### Clean Document Isolation Pattern:
```csharp
public class FeatureTests : RevitApiTest
{
    private Document _testDoc;

    [Before(Test)]
    [HookExecutor<RevitThreadExecutor>]
    public void Setup()
    {
        // Create an in-memory blank metric project document
        _testDoc = Application.Application.NewProjectDocument(UnitSystem.Metric);
    }

    [After(Test)]
    [HookExecutor<RevitThreadExecutor>]
    public void Teardown()
    {
        // Close without saving to maintain pristine environment
        if (_testDoc != null && _testDoc.IsValidObject)
        {
            _testDoc.Close(false);
        }
    }
}
```

---

## 5. Multi-Version Project Configuration (`.csproj`)

The test project leverages `Nice3point.Revit.Sdk` to automatically resolve Revit versions matching the solution:

```xml
<Project Sdk="Nice3point.Revit.Sdk/6.2.1">
    <PropertyGroup>
        <OutputType>Exe</OutputType>
        <TargetFrameworks>net48;net8.0-windows</TargetFrameworks>
        <ImplicitUsings>enable</ImplicitUsings>
        <Configurations>Debug.R24;Debug.R25;Debug.R26;Debug.R27</Configurations>
        <Configurations>$(Configurations);Release.R24;Release.R25;Release.R26;Release.R27</Configurations>
    </PropertyGroup>

    <ItemGroup>
        <PackageReference Include="Nice3point.TUnit.Revit" Version="$(RevitVersion).*"/>
    </ItemGroup>

    <ItemGroup>
        <ProjectReference Include="..\YourAddin\YourAddin.csproj"/>
    </ItemGroup>
</Project>
```

---

## 6. CLI Test Execution

Tests can be executed directly from PowerShell or Bash:

### Method A: `dotnet run` (Preferred for CLI execution)
```powershell
dotnet run --project YourAddin.Tests/YourAddin.Tests.csproj -c "Release.R26"
```

### Method B: `dotnet test`
```powershell
dotnet test YourAddin.Tests/YourAddin.Tests.csproj -c "Release.R26"
```

> **Requirement:** A licensed copy of Autodesk Revit matching the targeted version (e.g. Revit 2026 for `R26`) must be installed on the host machine.
