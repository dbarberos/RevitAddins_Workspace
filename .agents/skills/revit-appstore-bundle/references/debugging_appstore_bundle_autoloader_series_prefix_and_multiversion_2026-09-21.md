# Debugging: Autodesk App Store Autoloader Series Prefix & Multi-Version Loading Failures (2026-09-21)

## 1. Incident Summary

During the Autodesk App Store automated and manual validation of the submitted add-in bundle (`FilterPlus.bundle` / `FilterPlus.bundle.zip`), the reviewer reported:

```text
Application Not Loading in Compatible Autodesk Revit Versions. During testing, I observed that the application is not loading in any of the compatible Autodesk Revit versions. Please investigate and resolve this issue to ensure that the application loads and functions correctly across all supported Autodesk Revit versions.
```

In the reviewer's testing environment (Revit 2027):
- The add-in was installed on the system (verified via Control Panel *Programs and Features*).
- When launching Autodesk Revit 2027, the add-in failed to load completely: no tab was created, no button was added to the *Add-Ins* tab, and no error message or crash dialog was displayed.
- The failure reproduced identically across all target versions (Revit 2023 through Revit 2027).

---

## 2. Root Cause Analysis

Investigation identified three distinct root causes:

### A. Missing "R" Prefix in `PackageContents.xml` Series Identifiers (Primary Failure)
Autodesk Revit's internal Autoloader engine evaluates add-in compatibility against the product series using an "R" prefix (e.g., `R2023`, `R2024`, `R2025`, `R2026`, `R2027`).

The bundle manifest `PackageContents.xml` was generated with:
```xml
<!-- INCORRECT: Missing 'R' prefix -->
<RuntimeRequirements OS="Win64" Platform="Revit" SeriesMin="2027" SeriesMax="2027" />
```

When Revit 2027 loads, it evaluates the condition:
$$\text{SeriesMin} \le \text{CurrentSeries} \le \text{SeriesMax}$$
Substituting values:
`"2027" <= "R2027" <= "2027"`

In lexicographical string comparison, ASCII `'R'` (82) is strictly greater than `'2'` (50). Therefore, `"R2027" <= "2027"` evaluates to **FALSE**.
Because the condition fails, **Revit's Autoloader silently discards the bundle component without logging an error or displaying any user dialog**. This occurred across all Revit versions (2023–2027), completely disabling add-in discovery.

### B. ElementId API Breaking Change in Revit 2023 (`Release.R23`)
In newer data models (e.g., `ElementSelectionKey.cs`), `ElementId.Value` was accessed directly:
```csharp
// Broken in Revit 2023:
long thisId = ElementId != null ? ElementId.Value : -1;
```
`ElementId.Value` (64-bit integer) was only introduced in Revit 2024. In Revit 2023 (.NET Framework 4.8), `ElementId` only provides `IntegerValue` (32-bit integer).
This caused 6 fatal `CS1061` compilation errors during `Release.R23` builds, preventing fresh deployment binaries from being created.

### C. Missing CLR Assembly Resolver in .NET 8 CoreCLR (Revit 2025–2027)
When Revit 2025+ loads an add-in from `%ProgramData%\Autodesk\ApplicationPlugins\[AppName].bundle\`, secondary dependencies (`Nice3point.Revit.Toolkit.dll`, `CommunityToolkit.Mvvm.dll`) are placed in the bundle folder. Without a dynamic `AppDomain.CurrentDomain.AssemblyResolve` hook in `Application.OnStartup()`, runtime type binding can fail when secondary dependencies are resolved outside the primary probing path.

---

## 3. Permanent Standard & Resolution

### 1. Enforce "R" Prefix in `PackageContents.xml`
Every `<Components>` block in `PackageContents.xml` MUST strictly format `SeriesMin` and `SeriesMax` with the `"R"` prefix:
```xml
<!-- CORRECT -->
<Components Description="FilterPlus Add-in for Revit 2027">
  <RuntimeRequirements OS="Win64" Platform="Revit" SeriesMin="R2027" SeriesMax="R2027" />
  <ComponentEntry AppName="FilterPlus" Version="1.7.0" ModuleName="./Contents/2027/FilterPlus.addin" AppDescription="DBDev Solutions" LoadOnRevitStartup="True" />
</Components>
```
The packaging script `build-bundle.ps1` enforces this dynamically:
```powershell
<RuntimeRequirements OS="Win64" Platform="Revit" SeriesMin="R$Year" SeriesMax="R$Year" />
```

### 2. Multi-Version `ElementId` Unification Pattern
All models and services accessing `ElementId` numeric values across Revit 2023 and Revit 2024+ must use conditional compilation:
```csharp
#if REVIT2024_OR_GREATER
    long thisId = ElementId != null ? ElementId.Value : -1;
#else
    long thisId = ElementId != null ? ElementId.IntegerValue : -1;
#endif
```

### 3. Universal Assembly Resolve Handler in `Application.cs`
All add-in entry points (`Application : ExternalApplication`) must register an assembly resolver in `OnStartup()`:
```csharp
public override void OnStartup()
{
    AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
    try
    {
        CreateRibbon();
    }
    catch (Exception ex)
    {
        LoggerService.LogError("OnStartup Error creating ribbon", ex);
    }
}

private static System.Reflection.Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
{
    try
    {
        string assemblyName = new System.Reflection.AssemblyName(args.Name).Name + ".dll";
        string folderPath = System.IO.Path.GetDirectoryName(typeof(Application).Assembly.Location) ?? string.Empty;
        string assemblyPath = System.IO.Path.Combine(folderPath, assemblyName);

        if (System.IO.File.Exists(assemblyPath))
        {
            return System.Reflection.Assembly.LoadFrom(assemblyPath);
        }
    }
    catch { }
    return null;
}
```

### 4. Clean Directory Staging in `build-bundle.ps1`
When copying publish outputs into `Contents/202X/`, the packaging script must filter out nested `publish/`, `obj/`, or redundant directory structures to ensure clean bundle deliverables.
