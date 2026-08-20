# Debugging Log: WPF Layout Clipping in Constrained TreeView Columns During Horizontal Scroll

**Date**: 2026-08-20  
**Context**: Custom WPF TreeViewItem ControlTemplate with pinned left/right columns and horizontal middle column scrolling.  
**Affected Component**: `TransferPlusView.xaml` (Explorer TreeView)  

---

## 1. Symptom & Problem Statement

When building a 3-column `TreeViewItem` row layout:
- **Column 0 (`Width="26"`)**: Pinned CheckBox aligned vertically across all hierarchy levels.
- **Column 1 (`Width="*"`)**: Middle column containing the hierarchy expander (`▶`) and item name, transformed horizontally using `TranslateTransform X="{Binding Value, ElementName=TreeHScrollBar, Converter={StaticResource NegativeConverter}}"`.
- **Column 2 (`Width="60"`)**: Pinned Count column aligned vertically at the far right.

**Bug**: When an item name exceeded the visible width of Column 1, scrolling the horizontal scrollbar shifted the visible text to the left, but characters beyond the initial cell boundary remained cut off / clipped at a fixed right-side cutoff line. The text never expanded or became visible despite scrolling.

---

## 2. Root Cause Analysis

In WPF's layout engine (`UIElement` / `FrameworkElement`):
1. When a control (`StackPanel`, `Grid`, etc.) is placed inside a `Grid` cell of constrained width (`Width="*"`), WPF's `ArrangeOverride` assigns it a final layout slot: `Rect(0, 0, cellWidth, cellHeight)`.
2. Even if `StackPanel Orientation="Horizontal"` measures its child `TextBlock` to its true natural length (e.g. `800px`), `StackPanel`'s arranged `RenderSize.Width` is clamped to `cellWidth`.
3. WPF's internal `FrameworkElement.GetLayoutClip` automatically computes and applies an unmanaged geometry layout clip whenever an element's arranged visual contents exceed the parent slot.
4. Because `TranslateTransform` is a post-layout render transform, it shifts the already-clipped visual bitmap: the text outside `cellWidth` is never rendered by WPF's composition pipeline, creating a persistent truncation cutoff.

---

## 3. Resolution & Code Pattern

To allow infinite horizontal text measurement without triggering WPF's automatic `GetLayoutClip`, wrap the translated `StackPanel` inside an unconstrained `<Canvas>` panel while keeping `ClipToBounds="True"` on the parent `<Grid Grid.Column="1">`:

```xml
<!-- 2. Middle Column: Expander + Content (indented by level, scrollable via TreeHScrollBar) -->
<Grid Grid.Column="1" ClipToBounds="True" Height="24">
    <!-- Canvas does not clamp child arrange slots to cell widths, avoiding GetLayoutClip -->
    <Canvas Height="24" HorizontalAlignment="Stretch" VerticalAlignment="Center">
        <StackPanel Orientation="Horizontal" VerticalAlignment="Center" Height="24">
            <StackPanel.RenderTransform>
                <TranslateTransform X="{Binding Value, ElementName=TreeHScrollBar, Converter={StaticResource NegativeConverter}}"/>
            </StackPanel.RenderTransform>
            
            <!-- Expander Toggle -->
            <ToggleButton x:Name="Expander" Margin="{Binding IndentMargin}" 
                          IsChecked="{Binding IsExpanded, RelativeSource={RelativeSource TemplatedParent}}" 
                          ClickMode="Press" VerticalAlignment="Center">
                <ToggleButton.Template>
                    <ControlTemplate TargetType="ToggleButton">
                        <Border Width="18" Height="20" Background="Transparent" Cursor="Hand">
                            <TextBlock x:Name="ExpanderText" Text="▶" VerticalAlignment="Center" HorizontalAlignment="Center" FontSize="10" Foreground="Gray"/>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsChecked" Value="True">
                                <Setter TargetName="ExpanderText" Property="Text" Value="▼"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </ToggleButton.Template>
            </ToggleButton>
            
            <!-- Content Row (Node Name TextBlock) -->
            <ContentPresenter x:Name="PART_Header" ContentSource="Header" VerticalAlignment="Center"/>
        </StackPanel>
    </Canvas>
</Grid>
```

### Why this works:
- `Canvas` arranges its children with infinite width (`child.Arrange(new Rect(0, 0, desiredWidth, desiredHeight))`), which gives the `StackPanel` and `TextBlock` an unclipped layout slot and prevents WPF from applying `GetLayoutClip`.
- The parent `<Grid Grid.Column="1" ClipToBounds="True">` restricts visual overflow so that scrolled text strictly stays within Column 1 and never overlaps the pinned CheckBox (Column 0) or Count (Column 2).
