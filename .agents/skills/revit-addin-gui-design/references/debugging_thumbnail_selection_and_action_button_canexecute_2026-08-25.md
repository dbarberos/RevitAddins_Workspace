# Lesson Learned: Decoupling Selection Preview vs Multi-Checkbox Action Commands in Revit WPF MVVM

**Date:** 2026-08-25  
**Skill:** `revit-addin-gui-design` / `revit-api`  
**Pattern:** WPF TreeView Selection vs Checkbox Hierarchy Synchronization

---

## 1. Context & Problem

In dual-selection WPF TreeViews (where nodes have both mouse focus/click selection `SelectedItem` and boolean check states `IsChecked`):
- A common bug is coupling the visual detail/thumbnail inspector directly to the checked count (`CheckedCount > 1`).
- When multiple items are checked, naive implementations collapse the single thumbnail preview and show *"Multiple items selected"*, preventing the user from inspecting individual items by clicking on them.
- Conversely, action buttons (such as Download or Delete) often fall back to operating on `SelectedItem` when `CheckedCount == 0`, leading to accidental operations on unchecked items that are merely being previewed in the thumbnail box.

---

## 2. Best Practice Architecture

```
[TreeView Node Click]  ────────► Sets SelectedItem (Inspector View Only)
                                 - Always displays single thumbnail (128x128) + metadata
                                 - Does NOT enable action buttons

[TreeView Checkbox]   ────────► Increments CheckedCount
                                 - Controls CanExecute of Batch Action Commands (Delete / Download)
                                 - Enables actions ONLY when CheckedCount > 0
                                 - Never mutates or resets SelectedItem
```

### A. ViewModel Separation
```csharp
// 1. Inspector state: Bound purely to whether an item is focused with the mouse
public bool IsSingleItemDetails => SelectedItem != null;

// 2. Multi-item placeholder: Shown ONLY when no item is focused AND multiple items are checked
public bool ShowMultipleItemsPlaceholder => SelectedItem == null && CheckedCount > 1;

// 3. Action command CanExecute: Requires at least one checked item
private bool CanExecuteBatchAction()
{
    if (SourceDocument == null) return false;
    return CheckedCount > 0;
}
```

### B. XAML Template Structure
```xml
<!-- Single Item Preview Grid (Active whenever SelectedItem != null) -->
<Grid>
    <Grid.Style>
        <Style TargetType="Grid">
            <Setter Property="Visibility" Value="Collapsed"/>
            <Style.Triggers>
                <DataTrigger Binding="{Binding IsSingleItemDetails}" Value="True">
                    <Setter Property="Visibility" Value="Visible"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </Grid.Style>
    <!-- Thumbnail Image + Metadata Stack -->
</Grid>

<!-- Multiple Items Placeholder (Active ONLY when SelectedItem == null && CheckedCount > 1) -->
<TextBlock Text="Multiple items selected" Foreground="#999" FontStyle="Italic">
    <TextBlock.Style>
        <Style TargetType="TextBlock">
            <Setter Property="Visibility" Value="Collapsed"/>
            <Style.Triggers>
                <DataTrigger Binding="{Binding ShowMultipleItemsPlaceholder}" Value="True">
                    <Setter Property="Visibility" Value="Visible"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </TextBlock.Style>
</TextBlock>
```
