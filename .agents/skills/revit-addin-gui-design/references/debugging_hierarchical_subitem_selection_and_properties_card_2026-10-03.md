# Lesson Learned: Hierarchical Sub-Item Selection & External Properties Card Synchronization in WPF DataGrids

**Date:** 2026-10-03  
**Category:** WPF / MVVM / DataGrid Hierarchies & Detail Synchronization  
**Skill:** `revit-addin-gui-design`

---

## 1. Problem Description

When displaying multi-level documents in a WPF dialog (such as an Excel or PDF workbook containing multiple worksheets/pages), developers often face the following interaction dilemmas:
1. **Unwanted Parent Row Selection**: Clicking a nested worksheet sub-item triggers WPF's default `DataGridRow.IsSelected` behavior, turning the entire parent row blue and visually obscuring the hierarchy.
2. **Sub-Item Selection Loss / Event Stealing**: Attaching mouse click handlers to nested item borders can inadvertently consume the mouse event (`e.Handled = true`), breaking inner interactive controls like `CheckBox` (import toggle) and `ComboBox` (printable area/region dropdown).
3. **Card Synchronization without Orphan States**: An external detail card ("Table properties") placed outside the DataGrid must display and edit the properties (Origin, Type of view, Scale) of the actively selected worksheet. If no item is selected or multiple files exist, the card can become desynchronized or show blank/stale data.
4. **Format-Aware Default Properties**: Excel files require vector `Table` origin by default, while PDFs require raster `Image` origin by default, both targeting `Legend View` with scale `1`.

---

## 2. Root Cause Analysis

1. **WPF Visual Tree & Routed Event Bubbling**: Clicking any element inside a DataGrid cell or row template bubbles up to `DataGridRow`, triggering its default selection brush (`SystemColors.HighlightBrushKey`).
2. **Local Property Precedence over Triggers**: Setting `Background="Transparent"` directly as a local attribute on a `Border` overrides any `Style.Triggers` (such as `IsMouseOver` or `DataTrigger Binding="{Binding IsRowSelected}"`), preventing color changes on hover or selection.
3. **Premature `e.Handled = true` in Code-Behind**: Intercepting `PreviewMouseLeftButtonDown` and setting `e.Handled = true` stops event tunneling/bubbling, causing child checkboxes to stop toggling and dropdowns to stop opening.

---

## 3. The Architecture Solution

### 1. Transparent Parent Selection & Exclusive Sub-Item Tracking
In `DataGrid.Resources`, nullify the default OS selection brushes:
```xml
<DataGrid.Resources>
    <SolidColorBrush x:Key="{x:Static SystemColors.HighlightBrushKey}" Color="Transparent"/>
    <SolidColorBrush x:Key="{x:Static SystemColors.HighlightTextBrushKey}" Color="#0F172A"/>
    <SolidColorBrush x:Key="{x:Static SystemColors.InactiveSelectionHighlightBrushKey}" Color="Transparent"/>
    <SolidColorBrush x:Key="{x:Static SystemColors.InactiveSelectionHighlightTextBrushKey}" Color="#0F172A"/>
</DataGrid.Resources>
```

In the child model (`TableBatchSheetItemModel`), declare:
```csharp
[ObservableProperty]
private bool _isRowSelected;
```

In the parent ViewModel (`TableImportViewModel`), manage exclusive selection:
```csharp
public void SelectSheetRow(TableBatchSheetItemModel targetSheet)
{
    if (targetSheet == null) return;
    SelectedSheetRow = targetSheet;

    if (targetSheet.ParentFile != null)
        SelectedBatchFile = targetSheet.ParentFile;

    foreach (var file in BatchFiles)
    {
        foreach (var sheet in file.Sheets)
        {
            sheet.IsRowSelected = (sheet == targetSheet);
        }
    }
}
```

### 2. Non-Intrusive Click Handling via `PreviewMouseLeftButtonDown`
In the sub-item's `Border`, attach `PreviewMouseLeftButtonDown="SheetRow_PreviewMouseLeftButtonDown"`.
In code-behind, dispatch the model selection **without** setting `e.Handled = true`:
```csharp
private void SheetRow_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
{
    if (sender is FrameworkElement fe && fe.DataContext is TableBatchSheetItemModel sheetModel)
    {
        _viewModel.SelectSheetRow(sheetModel);
        // Do NOT set e.Handled = true: allows CheckBox and ComboBox child controls to work seamlessly!
    }
}
```

### 3. Pure Style Triggers for Hover and Persistent Highlight
Avoid setting `Background="Transparent"` inline on the `Border`. Define it inside `<Border.Style>`:
```xml
<Border BorderThickness="0" Padding="32,2,12,2"
        PreviewMouseLeftButtonDown="SheetRow_PreviewMouseLeftButtonDown"
        Cursor="Hand">
    <Border.Style>
        <Style TargetType="Border">
            <Setter Property="Background" Value="Transparent"/>
            <Style.Triggers>
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter Property="Background" Value="{StaticResource RowHoverBrush}"/>
                </Trigger>
                <DataTrigger Binding="{Binding IsRowSelected}" Value="True">
                    <Setter Property="Background" Value="{StaticResource RowHoverBrush}"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </Border.Style>
    <Grid Height="26">
        <!-- CheckBox, Sheet Name, Area ComboBox -->
    </Grid>
</Border>
```

### 4. Detail Card Binding & Format-Aware Defaults
In the child item model constructor:
```csharp
// Defaults: Table, Legend View, and 1 for spreadsheets; Image, Legend View, and 1 for PDF.
SelectedViewType = TargetViewType.LegendView;
SelectedScale = 1;
SelectedImportType = parentFile.SourceType == TableSourceType.PdfDocument
    ? TableImportType.Image
    : TableImportType.Table;
```

In the external card XAML:
```xml
<Grid IsEnabled="{Binding HasSelectedSheetRow}">
    <!-- Origin: Table vs Image -->
    <ComboBox ItemsSource="{Binding AvailableImportTypes}"
              SelectedItem="{Binding SelectedSheetRow.SelectedImportType, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" ... />

    <!-- Type of view: Drafting View, Legend View, Schedule View -->
    <ComboBox ItemsSource="{Binding AvailableViewTypes}"
              SelectedItem="{Binding SelectedSheetRow.SelectedViewType, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" ... />

    <!-- Scale: Numeric TextBox bound with validation -->
    <TextBox Text="{Binding SelectedSheetRow.ScaleInputText, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" ... />
</Grid>
```

---

## 4. Key Takeaways
1. **Never swallow routed events on container rows** (`e.Handled = false`) when they contain interactive children (`CheckBox`, `ComboBox`).
2. **Move default background to Style Setter** so triggers (`IsMouseOver` and `IsRowSelected`) can evaluate without being blocked by local property precedence.
3. **Always auto-select the first sub-item on batch load** (`SelectSheetRow(BatchFiles[0].Sheets[0])`) so external properties cards immediately display valid default values.
