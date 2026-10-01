# Lesson Learned: Compact Two-Column Modal Form Architecture for Revit Add-in Dialogs

**Date:** 2026-10-01  
**Category:** WPF / GUI Design / Modal Form Ergonomics  
**Skill:** `revit-addin-gui-design`

---

## 1. Problem Description

Initial implementations of Revit creation/import dialogs (such as "Add Table", "New Sheet", or "Import Element") frequently fall into the trap of using stacked vertical cards with excessive padding, headers, and separators. In TablePlus, this resulted in a window measuring `700x820px` that forced the user to scroll down through 3 separate cards to configure a single table import.

Furthermore, different file sources (Excel vs Word/PDF vs Delimited Text) require different parameters (e.g. Worksheets and Named Ranges for Excel; Page selections for PDF/Word; DPI resolution for Image exports), making a static card layout either overly cluttered or confusing.

---

## 2. Root Cause Analysis

1. **Card Overkill for Single-Task Dialogs**: While card-based dashboards (e.g. Master-Detail DataGrids) benefit from separate filtering and organizing cards, a modal creation dialog should present a unified, scannable configuration form.
2. **Missing Dynamic Context**: Hardcoding all options into the visual tree creates cognitive load when options do not apply to the currently selected file type or target view.

---

## 3. Solution: The DiRoots Two-Column Form Pattern

Inspecting production add-ins like DiRoots TableGen (`AddOrUpdateExcelWindow.cs` & `AddBaseViewModel.cs`) reveals the industry best practice:
- **Two-Column Grid Structure**:
  - `Column 0`: Fixed width (`130px - 145px`), semibold, right-aligned or left-aligned labels with consistent vertical spacing.
  - `Column 1`: Flexible (`*`), hosting cleanly styled inputs (TextBoxes, ComboBoxes, Switches).
- **Dynamic Row Visibility Driven by ViewModel Flags**:
  - `IsExcelSource`: Controls `Worksheet` and `Region / Range` rows.
  - `IsPagedDocument`: Controls `Page Options` and `SelectedPages` rows.
  - `IsImageImport`: Controls `Resolution (DPI)` row.
  - `IsScaleEnabled`: Automatically disables geometric scale when `TargetViewType.ScheduleView` is selected (as Revit schedules do not support scales).
- **Inline Enum Display Converter**:
  - Declared directly in the Window's assembly/code-behind to avoid pack-URI `ResourceDictionary` resolution failures in Revit:
  ```csharp
  public class EnumDisplayConverter : IValueConverter
  {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
          return value switch
          {
              TargetViewType.DraftingView => "Drafting View (ViewDrafting)",
              TargetViewType.LegendView => "Legend View (Multi-Sheet)",
              TargetViewType.ScheduleView => "Schedule View (ViewSchedule)",
              TableImportType.Table => "Table (Vector Lines & Text)",
              TableImportType.Image => "Image (High-Resolution Raster)",
              TablePageOption.AllPages => "All Pages",
              TablePageOption.SelectPages => "Select Pages...",
              _ => value?.ToString() ?? string.Empty
          };
      }
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
  }
  ```

---

## 4. XAML Implementation Template

```xaml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="135"/>
        <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/> <!-- Source -->
        <RowDefinition Height="Auto"/> <!-- Import Type -->
        <RowDefinition Height="Auto"/> <!-- File Path -->
        <RowDefinition Height="Auto"/> <!-- Worksheet (Conditional) -->
        <RowDefinition Height="Auto"/> <!-- Region (Conditional) -->
        <RowDefinition Height="Auto"/> <!-- Page Options (Conditional) -->
        <RowDefinition Height="Auto"/> <!-- View Type -->
        <RowDefinition Height="Auto"/> <!-- View Name -->
        <RowDefinition Height="Auto"/> <!-- View Scale -->
        <RowDefinition Height="Auto"/> <!-- Resolution (Conditional) -->
        <RowDefinition Height="Auto"/> <!-- Number of Copies -->
        <RowDefinition Height="Auto"/> <!-- Options -->
    </Grid.RowDefinitions>

    <!-- Source Row -->
    <TextBlock Grid.Row="0" Grid.Column="0" Text="Source:" FontWeight="SemiBold" 
               Foreground="{StaticResource TextSecondaryBrush}" VerticalAlignment="Center" Margin="0,0,12,12"/>
    <ComboBox Grid.Row="0" Grid.Column="1" ItemsSource="{Binding SourceOptions}" 
              SelectedItem="{Binding SelectedSourceOption}" DisplayMemberPath="DisplayName"
              Style="{StaticResource VirtualizedComboBoxStyle}" Margin="0,0,0,12"/>

    <!-- Conditional Excel Worksheet Row -->
    <TextBlock Grid.Row="3" Grid.Column="0" Text="Worksheet:" FontWeight="SemiBold" 
               Foreground="{StaticResource TextSecondaryBrush}" VerticalAlignment="Top" Margin="0,8,12,12"
               Visibility="{Binding IsExcelSource, Converter={StaticResource BoolToVis}}"/>
    <StackPanel Grid.Row="3" Grid.Column="1" Margin="0,0,0,12"
                Visibility="{Binding IsExcelSource, Converter={StaticResource BoolToVis}}">
        <ComboBox ItemsSource="{Binding Worksheets}" SelectedItem="{Binding SelectedWorksheet}"
                  Style="{StaticResource VirtualizedComboBoxStyle}"/>
        <TextBlock Text="{Binding UsedRangePreview}" Foreground="{StaticResource TextMutedBrush}" 
                   FontSize="11" Margin="2,4,0,0"/>
    </StackPanel>
</Grid>
```

---

## 5. Key Takeaways

1. **Height Reduction**: Switching from stacked cards to a unified 2-column form reduced required dialog height from `820px` down to `640px` with zero vertical scrolling needed on standard 1080p displays.
2. **Context-Sensitive Forms**: Hiding irrelevant rows (e.g. hiding Worksheets when importing a Word/PDF document) drastically reduces user confusion and validation defects.
3. **Multi-Copy Support**: Incorporating a `NumberOfCopies` row (1 to 50) allows batch view generation with automatic numbering (`Table 001`, `Table 002`) in a single user transaction.
