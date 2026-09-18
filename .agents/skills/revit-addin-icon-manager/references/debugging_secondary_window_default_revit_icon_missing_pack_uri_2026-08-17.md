# Debugging & Lesson Learned: Default Revit Icon Fallback on Secondary Modeless/Modal Dialogs

**Date:** 2026-08-17  
**Skill:** `revit-addin-icon-manager`  
**Tags:** `WPF`, `Window`, `Icon`, `Pack-URI`, `Revit-Host`, `AppStore`

---

## 1. Problem Description

During quality audits or user execution of Revit Add-ins (e.g. `TransferPlus`, `FilterPlus`), while the main entry window displays the custom add-in icon, secondary configuration windows, source pickers, or input dialogs display the generic Autodesk Revit application icon or Windows default window icon.

---

## 2. Root Cause

1. **Missing `Icon` Attribute on Child Windows**: Secondary XAML windows instantiated via `new ChildWindow().ShowDialog()` or `Show()` often omit the `Icon` property in their root `<Window>` tag.
2. **Host Icon Fallback**: Because WPF runs inside the external process `Revit.exe`, Windows inherits the application window icon directly from `Revit.exe` if no explicit icon is bound.
3. **Missing Resource Registration**: If an icon path is set with relative syntax (`Icon="Icons/my_icon.png"`), the WPF parser fails to resolve the resource inside the Revit host assembly.

---

## 3. Standard Solution

### Step 1: Declare Resources in `.csproj`
Ensure that all icon variations are explicitly declared with `<Resource Include="..." />` in the project file:
```xml
<ItemGroup>
    <Resource Include="Resources\Icons\TransferPlus16x16.png"/>
    <Resource Include="Resources\Icons\TransferPlus32x32.png"/>
    <Resource Include="Resources\Icons\TransferPlus120x120.png"/>
</ItemGroup>
```

### Step 2: Apply Absolute Pack URI on ALL Window XAML Roots
Every WPF Window (main, settings, dialogs, log view) must explicitly set:
```xml
<Window x:Class="TransferPlus.Views.MyDialogWindow"
        ...
        Icon="pack://application:,,,/TransferPlus;component/Resources/Icons/TransferPlus32x32.png">
```

### Step 3: Programmatic Fallback (C# Code-Behind)
If windows are generated dynamically without XAML, set the icon in the constructor:
```csharp
this.Icon = new System.Windows.Media.Imaging.BitmapImage(
    new Uri("pack://application:,,,/TransferPlus;component/Resources/Icons/TransferPlus32x32.png")
);
```
