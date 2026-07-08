# Debugging: WPF Window Icon Loading Failure in External Hosts (BAML Exception)
**Date:** 2026-07-07
**Tags:** `WPF`, `Window`, `Icon`, `Revit`, `pack-uri`, `BamlException`

## 🔴 Symptom
When launching a Revit Add-in that utilizes WPF Windows, the application crashes on startup with the following exception:
> *System.Windows.Baml2006.TypeConverterMarkupExtension: Se produjo una excepción al proporcionar un valor en...*

The window fails to render, and the debug log indicates that a resource (usually the window title bar icon) cannot be resolved.

## 🔍 Root Cause
This error is triggered when referencing WPF Window resources (such as the `Icon` property) using relative assembly URIs inside a XAML file, e.g.:
```xml
Icon="/Resources/Icons/RibbonIcon32.png"
```
When running a standard WPF application, the relative path resolves relative to the entry assembly. However, inside a Revit Add-in, the entry assembly is **`Revit.exe`**, not your plugin's DLL (`YourAddin.dll`). 

WPF attempts to locate the icon resource inside `Revit.exe`'s resources. Since it is missing, the XAML parser throws a BAML markup extension value-resolution exception.

## 🛠️ Solution
To resolve this, you must explicitly declare the absolute **WPF pack URI** directing the resource lookup to your specific compiled assembly.

### Correct XAML Implementation:
Replace the relative path with the absolute pack URI referencing your assembly name:
```xml
Icon="pack://application:,,,/YourAssemblyName;component/Resources/Icons/YourIconName.png"
```

*Example for FilterPlus:*
```xml
<Window x:Class="FilterPlus.Views.SelectionFilterView"
        ...
        Icon="pack://application:,,,/FilterPlus;component/Resources/Icons/RibbonIcon32.png">
```

This tells the WPF URI parser to look inside the `FilterPlus` DLL's resources, ensuring the icon is safely resolved on any computer regardless of deployment paths.
