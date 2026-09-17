# Debugging Report: ResourceDictionary Pack URI Crash in Revit Add-ins

*Date:* 2026-09-17  
*Component:* WPF UI / XAML Resource Management (`revit-addin-gui-design`)  
*Affected Add-in:* TransferPlus (Fixed via FilterPlus Inline Pattern)

---

## 1. Symptom & Error Dialog
When invoking an external command in Autodesk Revit that opens a WPF Window, Revit immediately intercepts an unhandled exception and presents the native dialog:
> **Fallo de comando para comando externo**  
> *Revit no ha podido completar el comando externo. Solicite asistencia a su proveedor...*  
> *Revit ha encontrado Se produjo una excepción al establecer la propiedad 'System.Windows.ResourceDictionary.Source'.*

Inner Exception:
`System.Windows.Markup.XamlParseException: Set property 'System.Windows.ResourceDictionary.Source' threw an exception.`

---

## 2. Root Cause Analysis

### A. Host Process Architecture
Autodesk Revit is a native Win32 C++ host application (`Revit.exe`). When executing third-party add-ins:
- Revit does **not** initialize the standard standalone WPF application lifecycle (`App.xaml`).
- `System.Windows.Application.Current` is either `null` or bound to Revit's private context without registration for the add-in's dynamic assembly mapping.

### B. Pack URI Failure on Merged Dictionaries
In `TransferPlusView.xaml`, styles were declared using an external dictionary loaded via Pack URI:
```xaml
<Window.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/TransferPlus;component/Resources/Styles/TransferPlusStyles.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    ...
```
When the XAML parser attempts to resolve `pack://application:,,,` dynamically at window instantiation time (`new TransferPlusView()`), WPF calls `Application.LoadComponent` or `Application.GetResourceStream`. Because the host is not a standard WPF app, the Pack URI authority fails to resolve, throwing `XamlParseException`.

### C. MSBuild BAML Duplicate Ingestion
Without `<DefaultItemExcludes>` in `.csproj`, MSBuild's default WPF page items crawl all subdirectories (including `Deploy/` and publish packages), causing dozens of duplicate or conflicting `.baml` entries to be embedded in `<AssemblyName>.g.resources`.

---

## 3. Why FilterPlus Never Failed (The Benchmark Pattern)
In `FilterPlus` (`FilterPlus/Views/SelectionFilterView.xaml`), **zero** external `ResourceDictionary.Source` calls are made.
All styles, templates, converters, and system scrollbar dimensions are defined **directly inline within `<Window.Resources>`**:
```xaml
<Window.Resources>
    <BooleanToVisibilityConverter x:Key="BoolToVis"/>
    <sys:Double x:Key="{x:Static SystemParameters.VerticalScrollBarWidthKey}">10</sys:Double>
    <Style TargetType="TextBlock"> ... </Style>
    <Style x:Key="HeaderIconButtonStyle" TargetType="Button"> ... </Style>
    <Style x:Key="SwitchStyle" TargetType="{x:Type CheckBox}"> ... </Style>
</Window.Resources>
```
Because the styles are part of the Window's own BAML class definition, they are materialized in memory upon `InitializeComponent()` with 0 external URI calls.

---

## 4. Resolution Protocol

1. **Inline Window Resources:**
   - Remove `<ResourceDictionary.MergedDictionaries>` and any `Source="pack://application:,,,/..."` references.
   - Declare all styles, data templates, and converters directly inside `<Window.Resources>`.
   - Add `xmlns:sys="clr-namespace:System;assembly=mscorlib"` at the root `<Window>` tag for system parameter overrides (e.g. scrollbars).
2. **Remove Loose Style XAML Files:**
   - Delete standalone style files (`Resources/Styles/*.xaml`) if they are only used by that window.
3. **Configure DefaultItemExcludes in .csproj:**
   ```xml
   <PropertyGroup>
       <DefaultItemExcludes>$(DefaultItemExcludes);Deploy\**;*PublishPackage\**</DefaultItemExcludes>
   </PropertyGroup>
   ```
4. **Inspect Embedded Resources:**
   - Verify with `System.Resources.ResourceReader` on `<Assembly>.g.resources` that no duplicate BAML streams exist.
