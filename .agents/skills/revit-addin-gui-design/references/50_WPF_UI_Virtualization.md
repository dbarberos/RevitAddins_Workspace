# WPF UI Virtualization Guide

WPF UI Virtualization is critical in AEC tools to display large sets of BIM elements without saturating memory or freezing the main Revit UI thread.

---

## 1. Quick Setup
For standard lists, select elements, and grids, apply the following properties to reuse visual container resources:
```xml
<ListBox ItemsSource="{Binding LargeCollection}"
         VirtualizingPanel.IsVirtualizing="True"
         VirtualizingPanel.VirtualizationMode="Recycling"
         VirtualizingPanel.ScrollUnit="Pixel"
         VirtualizingPanel.CacheLength="2,2"
         VirtualizingPanel.CacheLengthUnit="Page"/>
```

## 2. Key Properties Configuration
*   **`IsVirtualizing="True"`**: Enables the virtualization engine.
*   **`VirtualizationMode="Recycling"`**: Crucial. Reuses UI visual containers (like `ListBoxItem`) as items scroll out of view instead of disposing of them and creating new ones.
*   **`ScrollUnit="Pixel"`**: Changes scrolling from item-by-item (which is jumpy and recalculates layouts constantly) to smooth pixel-based scrolling.
*   **`CacheLength="2,2"` & `CacheLengthUnit="Page"`**: Controls how many pages of elements are pre-rendered off-screen, preventing flickering or blank spots when scrolling quickly.

---

## 3. UI Virtualization Breakers (Anti-Patterns)
Avoid the following structures which silently **disable** virtualization completely:

### ❌ Wrapping Lists inside a ScrollViewer
```xml
<!-- WRONG: The ScrollViewer gives the ListBox infinite height, causing it to render all containers at once -->
<ScrollViewer>
    <ListBox ItemsSource="{Binding HugeCollection}"/>
</ScrollViewer>
```
*   **Correct Pattern**: ListBox/ListView has a built-in `ScrollViewer` template. Let the list control handle its own scrolling.

### ❌ Disabling CanContentScroll
```xml
<!-- WRONG: Disabling content scroll switches scrolling to logical viewport coordinates, killing virtualization -->
<ListBox ScrollViewer.CanContentScroll="False" ItemsSource="{Binding HugeCollection}"/>
```

### ❌ Grouping without Group Virtualization flag
```xml
<!-- WRONG: Standard grouping breaks virtualization unless explicitly enabled -->
<ListBox VirtualizingPanel.IsVirtualizingWhenGrouping="False">
    <ListBox.GroupStyle>...</ListBox.GroupStyle>
</ListBox>
```
*   **Correct Pattern**: Always set `VirtualizingPanel.IsVirtualizingWhenGrouping="True"` when utilizing `GroupStyle`.

---

## 4. Performance Tuning
*   **Deferred Scrolling**: For datasets exceeding 50,000+ items, dragging the scrollbar thumb can overload the dispatcher. Enable deferred scrolling to update item visualization only when the mouse button is released:
    ```xml
    <ListBox ScrollViewer.IsDeferredScrollingEnabled="True"/>
    ```
