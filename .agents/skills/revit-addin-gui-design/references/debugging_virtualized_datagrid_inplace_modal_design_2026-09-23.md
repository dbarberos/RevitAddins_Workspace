# Debugging Lesson: Virtualized DataGrid with In-Place Modal Design (TablePlus)

**Date:** 2026-09-23  
**Skill:** `revit-addin-gui-design`  
**Context:** TablePlus Spec 002 (Master Table Dashboard & Table Manager)  

---

## 1. Problem Description

When implementing a complex table dashboard managing hundreds of spreadsheet views in Autodesk Revit:
1. Embedding numerous interactive controls (checkboxes, badges, per-row worksheet ComboBoxes, and design action buttons) across an 11-column DataGrid can cause severe scrolling lag, UI freezes, or high memory consumption if UI virtualization is disabled or misconfigured.
2. Opening a modal style configuration window (`TableStyleMappingView`) from a DataGrid row action button can lead to Revit window loss-of-focus, z-order stacking bugs, or `XamlParseException` if external ResourceDictionaries (`pack://application:,,,/`) are imported.
3. WPF TextBlock does not support CSS properties like `LetterSpacing`, causing compilation failures (`MC3072`).

---

## 2. Root Cause Analysis

1. **Virtualization Breakdown**: Wrapping a `DataGrid` inside a parent `ScrollViewer` or omitting `ScrollViewer.CanContentScroll="True"` disables WPF's `VirtualizingStackPanel`. As a result, hundreds of row visual trees and nested controls are instantiated simultaneously in memory.
2. **Modal Stacking & Pack URI Crash**: Modals opened from Revit add-ins require explicit `WindowInteropHelper(this).Owner = Process.GetCurrentProcess().MainWindowHandle;`. Additionally, Revit's unmanaged host lacks a standard WPF application lifecycle, causing external `ResourceDictionary.Source` pack URIs to throw unhandled `XamlParseException`s at runtime.

---

## 3. Resolution & Code Pattern

### A. Virtualized 11-Column DataGrid Setup
```xaml
<DataGrid x:Name="TablesDataGrid"
          ItemsSource="{Binding FilteredTables}"
          SelectedItem="{Binding SelectedTable}"
          AutoGenerateColumns="False"
          CanUserAddRows="False"
          CanUserDeleteRows="False"
          CanUserResizeRows="False"
          GridLinesVisibility="Horizontal"
          HorizontalGridLinesBrush="#E2E8F0"
          HeadersVisibility="Column"
          BorderThickness="0"
          Background="White"
          RowStyle="{StaticResource TableRowStyle}"
          ColumnHeaderStyle="{StaticResource TableHeaderStyle}"
          VirtualizingStackPanel.IsVirtualizing="True"
          VirtualizingStackPanel.VirtualizationMode="Recycling"
          ScrollViewer.CanContentScroll="True"
          EnableRowVirtualization="True">
    <!-- 11 columns with inline templates -->
</DataGrid>
```

### B. Double-Click Row Navigation in Revit
```xaml
<Style x:Key="TableRowStyle" TargetType="DataGridRow">
    <EventSetter Event="MouseDoubleClick" Handler="DataGridRow_MouseDoubleClick"/>
    <!-- Triggers for hover and selection -->
</Style>
```
```csharp
private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
{
    _viewModel.OpenSelectedView();
}
```

### C. Direct Event-Driven Row ComboBox Reselection
```csharp
private void WorksheetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (sender is FrameworkElement { DataContext: TableItemModel item } && e.AddedItems.Count > 0)
    {
        _ = _viewModel.OnSheetChangedAsync(item);
    }
}
```

### D. Modal Interop Attachment
```csharp
Loaded += (_, _) =>
{
    try
    {
        var revitWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
        if (revitWindowHandle != IntPtr.Zero)
        {
            new WindowInteropHelper(this).Owner = revitWindowHandle;
        }
    }
    catch
    {
        // Silently fallback if outside live Revit host
    }
};
```
