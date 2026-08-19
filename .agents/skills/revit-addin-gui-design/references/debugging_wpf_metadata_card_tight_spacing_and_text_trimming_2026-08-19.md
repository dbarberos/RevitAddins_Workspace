# Debugging: WPF Metadata Card Tight Spacing and Multi-Row Trimming

**Date:** 2026-08-19  
**Skill:** `revit-addin-gui-design`  
**Problem:** In fixed-height metadata inspection cards (such as 128px high side panels alongside thumbnails), displaying 6+ stacked property pairs (Title + Value) caused vertical overflow, pushing bottom fields outside the visible card boundaries. Standard `Margin="0,0,0,0"` left too much font metric line leading (~3-4px per line), which accumulated across 12-14 lines of text.

---

## Root Cause

1. **WPF TextBlock Font Metrics Leading:** By default, Segoe UI / Tahoma TextBlocks at `FontSize="10"` have internal vertical leading and ascent/descent metrics totaling ~13.5px per TextBlock.
2. **TextWrapping Multi-Line Expansion:** Long family/type names (e.g. `Door-Curtain-Wall-Double-Storefront`) wrapped into 2 or 3 lines, consuming 30-40px of vertical space and pushing subsequent fields out of view.

---

## Solution

1. **Negative Micro-Margins for Uniform 50% Gap Reduction:**
   Applying micro-negative vertical margins cancels the font metric dead-space symmetrically:
   - **Property Title:** `Margin="0,0,0,-2"` (pulls the value text 2px higher).
   - **Property Value:** `Margin="0,0,0,-1"` (pulls the next row 1px higher).
   - **Row StackPanel:** `Margin="0,-1,0,0"` (pulls the entire row 1px higher).
   This creates an exact, visually balanced ~1.5px gap between title and value, and between consecutive rows.

2. **Single-Line Trimming with Ellipsis and Full Tooltips:**
   Enforce single-line height while preserving readability via tooltip inspection:
   ```xaml
   <TextBlock Text="{Binding SelectedSymbol.Name}" 
              FontSize="10" Foreground="#333333" 
              TextWrapping="NoWrap" 
              TextTrimming="CharacterEllipsis" 
              ToolTip="{Binding SelectedSymbol.Name}" 
              Margin="0,0,0,-1"/>
   ```

---

## Example Pattern

```xaml
<!-- Compact Right Column Metadata Container -->
<StackPanel Grid.Column="1" VerticalAlignment="Top" Margin="0,0,0,0">
    <TextBlock Text="{Binding SelectedFamily.Name}" 
               FontWeight="Bold" FontSize="12" Foreground="#111111"
               TextWrapping="NoWrap" TextTrimming="CharacterEllipsis"
               ToolTip="{Binding SelectedFamily.Name}" Margin="0,0,0,0"/>

    <StackPanel Margin="0,-1,0,0">
        <TextBlock Text="Type" FontWeight="Bold" FontSize="10" Foreground="#111111" Margin="0,0,0,-2"/>
        <TextBlock Text="{Binding SelectedSymbol.Name}" FontSize="10" Foreground="#333333" 
                   TextWrapping="NoWrap" TextTrimming="CharacterEllipsis" ToolTip="{Binding SelectedSymbol.Name}" Margin="0,0,0,-1"/>
    </StackPanel>

    <StackPanel Margin="0,-1,0,0">
        <TextBlock Text="Category" FontWeight="Bold" FontSize="10" Foreground="#111111" Margin="0,0,0,-2"/>
        <TextBlock Text="{Binding SelectedFamily.CategoryName}" FontSize="10" Foreground="#333333" 
                   TextWrapping="NoWrap" TextTrimming="CharacterEllipsis" ToolTip="{Binding SelectedFamily.CategoryName}" Margin="0,0,0,-1"/>
    </StackPanel>

    <StackPanel Margin="0,-1,0,0">
        <TextBlock Text="File size" FontWeight="Bold" FontSize="10" Foreground="#111111" Margin="0,0,0,-2"/>
        <TextBlock Text="{Binding SelectedFamily.FileSizeFormatted}" FontSize="10" Foreground="#333333" Margin="0,0,0,-1"/>
    </StackPanel>

    <StackPanel Margin="0,-1,0,0">
        <TextBlock Text="Last modified" FontWeight="Bold" FontSize="10" Foreground="#111111" Margin="0,0,0,-2"/>
        <TextBlock Text="{Binding SelectedFamily.LastModifiedFormatted}" FontSize="10" Foreground="#333333" Margin="0,0,0,0"/>
    </StackPanel>
</StackPanel>
```
