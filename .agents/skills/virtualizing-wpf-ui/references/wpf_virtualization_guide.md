# WPF UI Virtualization Guide

## Quick Setup
For standard Lists and ItemsControls, apply the following attached properties to enable and optimize virtualization:
```xml
<ListBox ItemsSource="{Binding LargeCollection}"
         VirtualizingPanel.IsVirtualizing="True"
         VirtualizingPanel.VirtualizationMode="Recycling"
         VirtualizingPanel.ScrollUnit="Pixel"
         VirtualizingPanel.CacheLength="2,2"
         VirtualizingPanel.CacheLengthUnit="Page"/>
```

## Key Properties

| Property | Recommended | Purpose |
|----------|-------------|---------|
| `IsVirtualizing` | True | Enable virtualization |
| `VirtualizationMode` | Recycling | Reuse UI containers instead of creating new ones |
| `ScrollUnit` | Pixel | Smooth scrolling (instead of jumping item by item) |
| `CacheLength` | "1,1" to "2,2" | Buffer pages outside the visible area to prevent tearing |

## Virtualization Breakers

**These patterns DISABLE virtualization entirely. AVOID them:**
```xml
<!-- ❌ ScrollViewer wrapper -->
<ScrollViewer>
    <ListBox/>
</ScrollViewer>

<!-- ❌ CanContentScroll disabled -->
<ListBox ScrollViewer.CanContentScroll="False"/>

<!-- ❌ Grouping without flag -->
<ListBox>
    <ListBox.GroupStyle>...</ListBox.GroupStyle>
</ListBox>
```

**Correct Fixes:**
```xml
<!-- ✅ No wrapper needed - ListBox has built-in ScrollViewer -->
<ListBox ItemsSource="{Binding Items}"/>

<!-- ✅ Grouping with virtualization -->
<ListBox VirtualizingPanel.IsVirtualizingWhenGrouping="True">
    <ListBox.GroupStyle>...</ListBox.GroupStyle>
</ListBox>
```

## Performance Tips

### Deferred Scrolling
If the dataset is extremely large (100k+ items), dragging the scrollbar can lag. Enable deferred scrolling to only update the UI when the user releases the thumb:
```xml
<!-- Faster scrollbar dragging -->
<ListBox ScrollViewer.IsDeferredScrollingEnabled="True"/>
```
