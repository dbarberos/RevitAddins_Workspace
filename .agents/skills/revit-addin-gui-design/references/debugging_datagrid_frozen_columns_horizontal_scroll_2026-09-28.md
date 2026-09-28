# Debugging Lesson: WPF DataGrid Frozen Columns & Horizontal Scrollbar Lockup (TablePlus)

**Date:** 2026-09-28  
**Skill:** `revit-addin-gui-design`  
**Context:** TablePlus / WPF DataGrid with Frozen Columns & Hierarchy Controls  

---

## 1. Problem Description

When implementing a multi-column dashboard in Autodesk Revit (such as TablePlus's 11-column spreadsheet manager) featuring frozen leading columns (`FrozenColumnCount="2"`) and custom column sizing:
1. **Horizontal Scrollbar Unresponsive**: When the main window width is reduced and trailing columns overflow off-screen to the right, the horizontal scrollbar cannot be dragged or clicked to scroll right. The thumb fills 100% of the track and remains completely locked, preventing users from seeing columns 3 through 11.
2. **Empty Model State Lockup**: This freeze occurs most acutely when the add-in is opened in an empty model with 0 items discovered, when table search/filter criteria match 0 rows, or when hierarchical groups are collapsed.
3. **Header Row Visual Fragmentation**: In the header row, a default vertical line between the selection checkbox column (Col 1) and the element title/name column (Col 2) disrupts visual continuity. The user expects Col 1 to have a strictly fixed width adapted to checkboxes and hierarchy collapse/expand arrow buttons, seamlessly blending into Col 2.

---

## 2. Root Cause Analysis

### A. Extent Collapse Under Logical Scrolling (`CanContentScroll="True"`)
In native WPF `DataGrid`, the horizontal scrollbar's `ScrollableWidth` is calculated from `ScrollContentPresenter.ExtentWidth - ScrollContentPresenter.ViewportWidth`.
* When `ScrollViewer.CanContentScroll="True"`, scrolling is logical (item-based).
* When `ItemsSource` has 0 rows (or containers are collapsed), `DataGridRowsPresenter` generates 0 items and its measure returns `DesiredSize.Width = 0`.
* Consequently, `DG_ScrollViewer.ExtentWidth` collapses to the viewport width. Because `ExtentWidth <= ViewportWidth`, `ScrollableWidth = 0`.
* The scrollbar is disabled (`IsEnabled = False`, `Maximum = 0`), even though the column headers (`PART_ColumnHeadersPresenter`) in Row 0 exceed the viewport by hundreds of pixels (~1260px+).

### B. Header Separator & Sizing Constraints
* By default, `DataGridColumnHeader` styles declare `BorderThickness="0,0,1,1"` and `SeparatorVisibility="Visible"`, drawing a right border and separator between Col 1 and Col 2.
* To make Col 1 and Col 2 read as a single frozen group, Col 1 requires `BorderThickness="0,0,0,1"` and `SeparatorVisibility="Collapsed"`, with strict width pinning (`Width="42" MinWidth="42" MaxWidth="42" CanUserResize="False"`).

---

## 3. Resolution & Code Pattern

### A. XAML Configuration: Physical Pixel Scrolling & Dedicated Checkbox Header
In `MainWindowView.xaml`, set `ScrollViewer.CanContentScroll="False"` on the `DataGrid` to switch to physical (pixel-based) scrolling, and define `CheckboxColumnHeaderStyle`:

```xaml
<!-- Checkbox Column Header Style (No right border, seamless merge with Col 2) -->
<Style x:Key="CheckboxColumnHeaderStyle" TargetType="DataGridColumnHeader" BasedOn="{StaticResource TableHeaderStyle}">
    <Setter Property="BorderThickness" Value="0,0,0,1"/>
    <Setter Property="SeparatorVisibility" Value="Collapsed"/>
    <Setter Property="HorizontalContentAlignment" Value="Center"/>
    <Setter Property="Padding" Value="0"/>
</Style>

<DataGrid x:Name="TablesDataGrid"
          ItemsSource="{Binding FilteredTables}"
          AutoGenerateColumns="False"
          CanUserResizeColumns="True"
          FrozenColumnCount="2"
          HeadersVisibility="Column"
          ScrollViewer.CanContentScroll="False"
          ScrollViewer.HorizontalScrollBarVisibility="Visible"
          ScrollViewer.VerticalScrollBarVisibility="Visible">
    <DataGrid.Columns>
        <!-- COL 1: SELECTION CHECKBOX (FROZEN 1, FIXED 42px, EXPAND/COLLAPSE IN HEADER) -->
        <DataGridTemplateColumn Width="42" MinWidth="42" MaxWidth="42" CanUserResize="False" 
                                HeaderStyle="{StaticResource CheckboxColumnHeaderStyle}">
            <DataGridTemplateColumn.Header>
                <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" VerticalAlignment="Center">
                    <Button Command="{Binding DataContext.CollapseAllCommand, RelativeSource={RelativeSource AncestorType=Window}}" 
                            Style="{StaticResource HeaderIconButtonStyle}" ToolTip="Collapse All" Width="18" Height="18" Margin="1,0">
                        <Path Data="M4,1 L8,7 L0,7 Z" Fill="#555555" HorizontalAlignment="Center" VerticalAlignment="Center"/>
                    </Button>
                    <Button Command="{Binding DataContext.ExpandAllCommand, RelativeSource={RelativeSource AncestorType=Window}}" 
                            Style="{StaticResource HeaderIconButtonStyle}" ToolTip="Expand All" Width="18" Height="18" Margin="1,0">
                        <Path Data="M0,1 L8,1 L4,7 Z" Fill="#555555" HorizontalAlignment="Center" VerticalAlignment="Center"/>
                    </Button>
                </StackPanel>
            </DataGridTemplateColumn.Header>
            <DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <CheckBox IsChecked="{Binding IsSelected, UpdateSourceTrigger=PropertyChanged}"
                              HorizontalAlignment="Center" VerticalAlignment="Center"/>
                </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>

        <!-- COL 2: VIEW NAME (FROZEN 2, CLEAN HEADER, SUBTLE RIGHT BORDER) -->
        <DataGridTemplateColumn Header="View Name" Width="200" MinWidth="140" CanUserResize="True">
            <DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <Border BorderBrush="#E2E8F0" BorderThickness="0,0,1,0" Padding="0">
                        <TextBlock Text="{Binding ViewName}" FontWeight="SemiBold" VerticalAlignment="Center" 
                                   Margin="16,0,6,0" TextTrimming="CharacterEllipsis"/>
                    </Border>
                </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>

        <!-- Columns 3 through 11 (Scrolling Pane) -->
    </DataGrid.Columns>
</DataGrid>
```

### B. Code-Behind / Helper: Dynamic Extent Synchronization
In code-behind or via `DataGridHorizontalScrollHelper`, listen to `LayoutUpdated` to ensure `DG_ScrollViewer.Content.MinWidth` always equals the accumulated column widths:

```csharp
private ScrollViewer? _dataGridScrollViewer;
private double _lastCalculatedMinWidth = -1;

private void TablesDataGrid_LayoutUpdated(object? sender, EventArgs e)
{
    _dataGridScrollViewer ??= TablesDataGrid.Template?.FindName("DG_ScrollViewer", TablesDataGrid) as ScrollViewer;

    if (_dataGridScrollViewer?.Content is FrameworkElement scrollContent)
    {
        double totalColumnsWidth = 0;
        foreach (var col in TablesDataGrid.Columns)
        {
            if (col.ActualWidth > 0)
                totalColumnsWidth += col.ActualWidth;
            else if (col.Width.IsAbsolute)
                totalColumnsWidth += col.Width.Value;
            else if (col.MinWidth > 0)
                totalColumnsWidth += col.MinWidth;
        }

        // Apply threshold guard (> 1.0) to prevent layout cycle loops (LayoutCycleException)
        if (totalColumnsWidth > 0 && Math.Abs(_lastCalculatedMinWidth - totalColumnsWidth) > 1.0)
        {
            _lastCalculatedMinWidth = totalColumnsWidth;
            scrollContent.MinWidth = totalColumnsWidth;
        }
    }
}
```

---

## 4. Key Takeaways for Future Add-ins

1. **Always use physical scrolling (`CanContentScroll="False"`) on DataGrids with frozen columns** if datasets are expected to be under 1,000 items. This preserves pixel-accurate column alignment and header-cell scroll synchronization.
2. **Always synchronize `ScrollViewer.Content.MinWidth` with total column widths** to ensure the horizontal scrollbar remains draggable even when the table is empty or filtered out.
3. **Always use a delta guard (`> 1.0`)** when setting `MinWidth` inside `LayoutUpdated` to prevent infinite measure/arrange cycles.
4. **Col 1 (Checkboxes) must have a dedicated borderless header style** (`BorderThickness="0,0,0,1"`, `SeparatorVisibility="Collapsed"`) to eliminate visual seams with the adjacent frozen name column.
