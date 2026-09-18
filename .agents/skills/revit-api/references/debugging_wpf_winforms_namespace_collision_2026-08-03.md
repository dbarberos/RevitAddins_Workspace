# Debugging Report: WPF UseWindowsForms Namespace Collision in Revit Add-ins

**Date:** 2026-08-03  
**Target Skill:** `revit-api`  
**Component:** `.csproj` build configuration / Namespace Resolution  

## Symptom
Adding `<UseWindowsForms>true</UseWindowsForms>` to a Revit `.csproj` project causes compilation to break across multiple files with CS0104 errors:
```text
error CS0104: 'View' es una referencia ambigua entre 'Autodesk.Revit.DB.View' y 'System.Windows.Forms.View'
```

## Root Cause
Enabling `<UseWindowsForms>true</UseWindowsForms>` automatically includes `System.Windows.Forms` in C# 12 implicit usings (`<ImplicitUsings>enable</ImplicitUsings>`). This creates an ambiguous symbol collision between Revit's `Autodesk.Revit.DB.View` and Windows Forms' `System.Windows.Forms.View`.

## Solution
1. **Remove `<UseWindowsForms>true</UseWindowsForms>`** from `.csproj`.
2. To browse folders in WPF across both **.NET Framework 4.8** and **.NET 8** without importing Windows Forms:
   - Use `Microsoft.Win32.OpenFolderDialog` via reflection or fallback to standard WPF `Microsoft.Win32.OpenFileDialog`.

```csharp
// Safe WPF Folder Selection without System.Windows.Forms
var openFolderDialogType = Type.GetType("Microsoft.Win32.OpenFolderDialog, PresentationFramework");
if (openFolderDialogType != null)
{
    var instance = Activator.CreateInstance(openFolderDialogType);
    if (instance != null)
    {
        openFolderDialogType.GetProperty("Title")?.SetValue(instance, "Select Folder");
        var result = openFolderDialogType.GetMethod("ShowDialog", Type.EmptyTypes)?.Invoke(instance, null);
        if (result is true)
        {
            string? folderName = openFolderDialogType.GetProperty("FolderName")?.GetValue(instance) as string;
            if (!string.IsNullOrWhiteSpace(folderName)) return folderName;
        }
    }
}

// Fallback WPF OpenFileDialog
var ofd = new Microsoft.Win32.OpenFileDialog
{
    Title = "Select any file inside target folder",
    CheckFileExists = false
};
if (ofd.ShowDialog() == true)
{
    return Path.GetDirectoryName(ofd.FileName);
}
```
