# FilterPlus UI & UX Styling Design Guide

This guide details the custom styles, layouts, and performance-based UX patterns used in **FilterPlus**. These design patterns should serve as the blueprint when building custom WPF interfaces in the Revit Add-in workspace.

---

## 1. Visual Composition & Colors
FilterPlus utilizes a clean, modern, light theme with premium gray backgrounds, blue accent controls, and harmonized state indicators:
*   **Window Background**: `#f5f5f5` (Light off-white).
*   **Card Background**: `#ffffff` (Pure white).
*   **Card Border**: `1px` thickness, color `#e8e8e8`, with `CornerRadius="8"`.
*   **Primary Accent/Highlight**: `#007ACC` (Standard Revit Blue).
*   **Selection State (Checked)**: Green highlight (`#e8f5e9`).
*   **Selection State (Indeterminate/Three-State)**: Amber highlight (`#fff8e1`).

---

## 2. Scrollbar Relocation (Left-Sided Scrollbar)
To position a `ScrollViewer`'s vertical scrollbar on the physical left (maximizing space next to the right filter panels):
1.  Set `FlowDirection="RightToLeft"` on the parent `<ScrollViewer>`.
2.  Set `FlowDirection="LeftToRight"` on the child layout container (e.g., `<Grid>`).
3.  Apply an **inverted margin** on the child container to create a gap next to the scrollbar: `Margin="0,0,9,0"` (logical Right maps to physical Left).
```xml
<ScrollViewer Grid.Column="2" Grid.Row="1" FlowDirection="RightToLeft" VerticalScrollBarVisibility="Visible" HorizontalScrollBarVisibility="Disabled" BorderThickness="0" Padding="0">
    <Grid FlowDirection="LeftToRight" Margin="0,0,9,0">
        <!-- Content here has scrollbar on physical left -->
    </Grid>
</ScrollViewer>
```

---

## 3. Reusable Custom Styles

### A. Toggle Switch (SwitchStyle CheckBox)
Replaces the standard checkbox checkbox with a smooth sliding pill switch:
*   **Visual Structure**: A rounded `Border` (`Width="28"`, `Height="14"`, `CornerRadius="7"`) enclosing an `Ellipse` (`Width="10"`, `Height="10"`).
*   **Micro-Animation**: Uses a WPF `Storyboard` animating the `TranslateTransform.X` of the ellipse from `0` to `14` over `0.15` seconds upon `IsChecked="True"`.

### B. TreeView Hierarchical Layout & Container Highlights
The TreeView container overrides standard `TreeViewItem` styles to implement custom lines and selection indicators:
1.  **Bottom Border Separation**: Each row uses a `Border` with `BorderThickness="0,0,0,1"` and `BorderBrush="White"` to render clean horizontal dividers.
2.  **Row Highlights**: Uses WPF `DataTrigger` tags bound to the node ViewModel:
    *   If `IsChecked == True`, background is set to `#e8f5e9` (Green highlight).
    *   If `IsChecked == null` (Three-state intermediate), background is set to `#fff8e1` (Amber highlight).
3.  **Arrow Toggle**: The expand/collapse chevron is styled as a flat ToggleButton showing `▶` (collapsed) and `▼` (expanded) with hover highlights.

### C. Translucent Loading Overlay
During heavy calculations or document reads, show a centered modal overlay:
*   **Layout**: A Grid covering the entire window with a semi-translucent background (`#70FFFFFF`).
*   **Card**: A central card (`Border Background="White" CornerRadius="8"`) displaying `StatusMessage` and `IsBusy` bindings, accompanied by a subtle drop shadow:
```xml
<Grid Background="#70FFFFFF" Visibility="{Binding IsBusy, Converter={StaticResource BoolToVis}}">
    <Border Background="White" CornerRadius="8" Padding="25,18" HorizontalAlignment="Center" VerticalAlignment="Center" BorderBrush="#007ACC" BorderThickness="1.5">
        <Border.Effect>
            <DropShadowEffect BlurRadius="12" Direction="-90" ShadowDepth="1" Opacity="0.12"/>
        </Border.Effect>
        <StackPanel Width="220">
            <TextBlock Text="{Binding StatusMessage}" FontWeight="SemiBold" TextAlignment="Center" TextWrapping="Wrap"/>
        </StackPanel>
    </Border>
</Grid>
```

---

## 4. UI Performance Safeguard (Linked Models Limit)
When building controls to read both the current project and links:
1.  Run a rapid count query first using `GetElementCount()`:
    ```csharp
    int totalElements = new FilteredElementCollector(doc).WhereElementIsNotElementType().GetElementCount();
    ```
2.  If the count exceeds `100,000` elements:
    *   Set `IsCacheLimited = true`.
    *   Bypass loading linked models into memory.
    *   Display an orange warning triangle icon (Alert symbol) next to the element counter with a tooltip:
        *"To preserve performance, only elements from the Active Model have been loaded, and linked models are omitted."*
