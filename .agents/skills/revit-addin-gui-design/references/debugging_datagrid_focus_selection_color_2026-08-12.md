# Debugging Report: DataGrid Focus & Selection Highlight Color System

## 1. Problem Description & Symptom
In WPF DataGrid controls displaying tabular data (such as the Rename palette in TransferPlus), selecting a row turns the row background to dark blue (`#007ACC`). White text was applied to both `Original Name` and `New Name` columns for readability.
However, when focus moved away from the DataGrid (e.g., user clicked a button or input box elsewhere on the form), WPF's default inactive selection behavior changed the row background to light gray, while the `New Name` text remained white, rendering it invisible against the light background.

## 2. Root Cause
1. **WPF Default Inactive Brushes**: By default, WPF `DataGrid` overrides row background to `SystemColors.ControlBrushKey` (light gray) when `IsKeyboardFocusWithin == False`.
2. **Hardcoded / Trigger Mismatches**: Setting text colors without evaluating `DataGrid.IsKeyboardFocusWithin` causes text colors to stay white even when the background switches to inactive light gray.

## 3. Technical Solution

### A. Override Inactive System Brushes in DataGrid Resources
Set inactive selection brushes to transparent and custom dark text:

```xaml
<DataGrid.Resources>
    <!-- Prevent WPF from applying light gray background when row loses focus -->
    <SolidColorBrush x:Key="{x:Static SystemColors.InactiveSelectionHighlightBrushKey}" Color="Transparent"/>
    <SolidColorBrush x:Key="{x:Static SystemColors.InactiveSelectionHighlightTextBrushKey}" Color="#333333"/>
</DataGrid.Resources>
```

### B. Use Focus-Aware `MultiDataTrigger` for Cell Text Colors
To ensure text turns crisp white **only** when the DataGrid row is selected AND the control retains active focus:

```xaml
<TextBlock Text="{Binding NewName}">
    <TextBlock.Style>
        <Style TargetType="TextBlock">
            <!-- Default color when not selected or when inactive -->
            <Setter Property="Foreground" Value="#007ACC"/>
            <Style.Triggers>
                <MultiDataTrigger>
                    <MultiDataTrigger.Conditions>
                        <Condition Binding="{Binding RelativeSource={RelativeSource AncestorType=DataGridRow}, Path=IsSelected}" Value="True"/>
                        <Condition Binding="{Binding RelativeSource={RelativeSource AncestorType=DataGrid}, Path=IsKeyboardFocusWithin}" Value="True"/>
                    </MultiDataTrigger.Conditions>
                    <Setter Property="Foreground" Value="White"/>
                </MultiDataTrigger>
            </Style.Triggers>
        </Style>
    </TextBlock.Style>
</TextBlock>
```

## 4. Key Takeaway & Rule
Always pair `DataGridRow.IsSelected` with `DataGrid.IsKeyboardFocusWithin` using a `MultiDataTrigger` when applying high-contrast selection colors (such as white text over dark blue). Override `InactiveSelectionHighlightBrushKey` to prevent unwanted WPF gray focus highlights.
