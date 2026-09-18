# Debugging Report: WPF Standalone Window Missing StaticResource Converter Exception

**Date:** 2026-08-05  
**Domain:** WPF / XAML / StaticResourceExtension / Revit Add-in Dialogs  
**Target Skill:** `revit-api`  

---

## 🔴 Symptom
When opening a secondary WPF dialog window (e.g. `AutodeskDocsSourceWindow`), a runtime `XamlParseException` is thrown:
`Se produjo una excepción al proporcionar un valor en 'System.Windows.StaticResourceExtension'.`

---

## 🔍 Root Cause Analysis

Standalone WPF `Window` dialogs instantiated via `ShowDialog()` do NOT automatically inherit resources defined inside the main view's `<Window.Resources>` (such as `TransferPlusView.xaml`).

When `AutodeskDocsSourceWindow.xaml` referenced `Visibility="{Binding IsConnected, Converter={StaticResource BoolToVis}}"`, WPF failed to locate `BoolToVis` in `AutodeskDocsSourceWindow.xaml.Resources` or `Application.Current.Resources`, causing `StaticResourceExtension` to fail at runtime.

---

## 🟢 Resolution Pattern

Always declare standard converters locally inside the dialog's `<Window.Resources>`:

```xaml
<Window x:Class="TransferPlus.Views.AutodeskDocsSourceWindow"
        ...
        Background="#FAFAFA">

    <Window.Resources>
        <BooleanToVisibilityConverter x:Key="BoolToVis"/>
    </Window.Resources>

    <Grid>
        ...
    </Grid>
</Window>
```
