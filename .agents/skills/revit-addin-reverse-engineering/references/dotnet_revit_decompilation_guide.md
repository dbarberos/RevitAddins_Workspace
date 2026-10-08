# .NET & Revit Assembly Decompilation Guide

This reference provides technical procedures for disassembling, inspecting, and extracting evidence from compiled Autodesk Revit add-ins across both **.NET Framework 4.8** (Revit 2020-2024) and **.NET 8 CoreCLR** (Revit 2025+).

---

## 1. Safe Assembly Inspection (Non-Executing)

When inspecting third-party binaries or unknown add-ins, **never execute untrusted code** directly in the primary process. Use metadata inspection tools or PowerShell reflection in read-only mode.

### A. PowerShell CLI Reflection (Lightweight Discovery)
To quickly extract commands, exported types, and referenced Revit API assemblies without third-party tooling:

```powershell
# Load assembly for reflection inspection
$bytes = [System.IO.File]::ReadAllBytes("path\to\Addin.dll")
$assembly = [System.Reflection.Assembly]::Load($bytes)

# List all types implementing IExternalCommand or IExternalApplication
$revitTypes = $assembly.GetExportedTypes() | Where-Object {
    $_.GetInterface("IExternalCommand") -ne $null -or
    $_.GetInterface("IExternalApplication") -ne $null
}

$revitTypes | Select-Object FullName, @{
    Name = "Role";
    Expression = {
        if ($_.GetInterface("IExternalCommand")) { "Command" }
        elseif ($_.GetInterface("IExternalApplication")) { "Application" }
    }
}
```

### B. Dedicated Decompilers
- **ILSpy CLI (`ilspycmd`)**: Preferred for batch decompilation to C# source:
  ```powershell
  ilspycmd -p -o ./decompiled_src Addin.dll
  ```
- **dnSpy / dnSpyEx**: Interactive debugger and IL/C# editor. Excellent for inspecting local variable names and stepping through methods.
- **JetBrains dotPeek / de4dot**: Useful for symbol recovery and deobfuscation.

---

## 2. Inspecting Revit-Specific Artifacts

### A. BAML & XAML Resources Extraction
Most compiled WPF add-ins store their views as compiled BAML inside `[AssemblyName].g.resources`.
- In ILSpy / dotPeek: Expand `Resources` -> `[AssemblyName].g.resources` -> double click any `.baml` file. The decompiler reconstructs the equivalent XAML.
- Look for:
  - `DataContext="{Binding ...}"` to identify the associated ViewModel.
  - `ItemsSource="{Binding ...}"` to identify collection properties.
  - Event handlers (`Click="OnButtonClick"`, `SelectionChanged="OnSelection"`) to see code-behind logic.
  - Custom Converters and ValueConverter parameters.

### B. Extensible Storage Schema Recovery
If the add-in stores persistent metadata in Revit elements or project data without using visible parameters, it uses Extensible Storage (`Autodesk.Revit.DB.ExtensibleStorage`).
- Search the decompiled code for `SchemaBuilder`:
  ```csharp
  SchemaBuilder builder = new SchemaBuilder(new Guid("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"));
  builder.SetReadAccessLevel(AccessLevel.Public);
  builder.SetSchemaName("...");
  builder.AddSimpleField("FieldName", typeof(string));
  ```
- Document the exact **Schema GUID**, **Field Names**, **Types** (string, int, double, XYZ, ElementId), and **Units** (ForgeTypeId / DisplayUnitType).
- A clean clone can read the original add-in's stored data seamlessly by referencing the exact same Schema GUID and field definitions.

### C. Shared Parameters & BuiltInParameter Mapping
- Search for parameter extraction methods:
  - `element.get_Parameter(BuiltInParameter.XXX)`
  - `element.get_Parameter(new Guid("..."))` (Shared Parameter by GUID)
  - `element.LookupParameter("Parameter Name")` (String lookup)
- If shared parameters are loaded from a bundled `.txt` definition file, inspect the embedded resources for `*params*.txt` or `*shared*.txt`.

---

## 3. Deobfuscation & Anti-Tampering Analysis

Commercial Revit add-ins are frequently protected by tools like **Obfuscar**, **ConfuserEx**, **Babel**, or **SmartAssembly**.

### Common Obfuscation Techniques & Countermeasures

| Technique | Signs in Decompiled Code | Agent Strategy |
|---|---|---|
| **Renaming** | Types and methods named `A`, `B`, `a_1`, or unicode characters. | Trace by behavior and method signature: identify Revit API calls (`doc.Create`, `tx.Commit()`). Rename conceptually in your blueprint. |
| **Control Flow Flattening** | Massive `switch` statements with integer state machines inside while(true) loops. | Focus on the Revit API calls made inside state branches and map the execution sequence. |
| **String Encryption** | Calls to `DecryptionHelper.Decrypt(0x2A1F)` instead of string literals. | Inspect the static decryption method (often a simple XOR, AES, or byte array index). Run the decryption helper in a scratch PowerShell session if string literals (parameter names, schema GUIDs) are needed. |
| **Resource Encryption** | BAML resources or icons are packed inside compressed/encrypted streams. | Locate the stream loader hook in `IExternalApplication.OnStartup` or assembly initializer (`.cctor`). |

---

## 4. pyRevit & Scripted Add-in Inspection

When the reference is a pyRevit extension (`.extension`):
- **Inspect `bundle.yaml`**: Check ribbon layout, tooltip, help URL, and context restrictions (e.g. `min_revit_version: 2024`).
- **Inspect `script.py`**:
  - Python scripts use IronPython (`clr.AddReference`) or pyRevit native wrappers (`from pyrevit import revit, DB, UI`).
  - Search for `with revit.Transaction("...")`: Maps directly to C# `using var tx = new Transaction(...)`.
  - Search for `forms.SelectFromList`: Maps to modern WPF Dialogs in C#.
- **Inspect `ui.xaml`**: In pyRevit, XAML is loaded dynamically via `pyrevit.forms.WPFWindow`. The XAML is plain text, making UI inspection instantaneous.
