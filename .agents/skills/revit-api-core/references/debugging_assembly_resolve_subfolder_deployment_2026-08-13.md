# Debugging Report: Resolving Missing Ribbon Button & Silent Startup Failure on Subfolder Assembly Deployment

## Problem Description
After adding new third-party NuGet dependencies (such as `AWSSDK.S3` and `AWSSDK.Core`) to a Revit Add-in compiled for .NET Framework 4.8 / .NET 8, the add-in's ribbon button failed to appear upon launching Revit. No error dialog was shown to the user, and the ribbon tab/button disappeared completely.

---

## Root Cause Analysis
1. **Subfolder Assembly Probing in Revit**:
   - The add-in manifest (`TransferPlus.addin`) references `<Assembly>TransferPlus\TransferPlus.dll</Assembly>`, placing the add-in's DLLs inside a subfolder under `%APPDATA%\Autodesk\Revit\Addins\2024\TransferPlus\`.
   - .NET Framework's default assembly resolution probing path searches for dependency DLLs (such as `AWSSDK.S3.dll` or `AWSSDK.Core.dll`) only in the host application folder (`C:\Program Files\Autodesk\Revit 2024\`) and the root add-ins folder (`%APPDATA%\Autodesk\Revit\Addins\2024\`).
   - It does **NOT** probe subdirectories automatically (`TransferPlus\`).
2. **JIT Compilation Failure**:
   - When Revit invoked `Application.OnStartup()`, JIT compilation failed to resolve `AWSSDK.S3` / `AWSSDK.Core` types, throwing `System.IO.FileNotFoundException`.
   - Revit's add-in manager caught the unhandled exception during `OnStartup` and suppressed the ribbon panel creation.

---

## Solution Code Pattern

Register an `AssemblyResolve` event handler inside `IExternalApplication.OnStartup()` before executing any UI or business logic:

```csharp
namespace TransferPlus;

[UsedImplicitly]
public class Application : ExternalApplication
{
    public override void OnStartup()
    {
        // 1. Hook AssemblyResolve handler FIRST to resolve dependencies from the add-in subfolder
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

    private static System.Reflection.Assembly? OnAssemblyResolve(object? sender, ResolveEventArgs args)
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
        catch
        {
            // Fail silently to allow default resolution
        }
        return null;
    }
}
```

---

## Key Takeaways for Future Add-in Development
- **Mandatory for Subfolder Add-ins**: Any Revit add-in deployed to a subfolder (`%APPDATA%\Autodesk\Revit\Addins\<Version>\<AddinName>\`) MUST hook `AppDomain.CurrentDomain.AssemblyResolve` in `OnStartup()`.
- **Prevents Silent Startup Failures**: Catches and resolves NuGet package assemblies without requiring GAC installation or root folder pollution.
