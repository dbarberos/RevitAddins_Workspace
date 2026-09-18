# Implementation Plan: Add "Not Contain" Option to Filter Regex Help & Specialized Bottom-Up Filter Engine

**Date:** 2026-09-17  
**Add-in:** TransferPlus  
**Component:** Asset Explorer Filter Card, Regex Helper Palette & Specialized Leaf-Only Bottom-Up Filter Engine  

---

## 1. Objective
Add a new regular expression pattern option to the **Regex Help (Filter)** dropdown within the main window's **Filter** card, allowing users across all add-in modes (**Current Project / Standard Mode**, **Family Mode**, and **CAD Mode**) to filter and select elements whose names do NOT contain a specified keyword.

Furthermore, implement a specialized bottom-up leaf evaluation engine (`FilterTreeNegative`) to resolve the hierarchical tree anomaly where negative lookaheads (`(?!` / `(?<!`) caused structural parent folders to match and cascade downward, incorrectly selecting 100% of the tree.

---

## 2. Technical Architecture & Root Cause Analysis

### 2.1. Shared Filter Card Scope
The Filter card in `TransferPlusView.xaml` is part of the persistent right-hand settings panel and is shared across all operation modes (Standard, Family, and CAD mode).

### 2.2. The Hierarchical Tree Contradiction in Negative Matching
- **Positive Filters:** When searching for `"dwg"`, parent folders (`"CAD Formats"`, `"Views"`, `"Families"`) do not contain `"dwg"`, evaluating to `false`. Only the specific leaf matching `"dwg"` is checked.
- **Negative Filters (`^(?!.*dwg).*$`):** Parent container names almost never contain `"dwg"`. In standard recursive top-down evaluation, parent folders matched `true`. Calling `node.SetCheckedState(true)` on a parent folder forcibly set `IsChecked = true` on all descendants (even those with `"dwg"`), resulting in 100% of elements being selected.

### 2.3. The Solution: Specialized Bottom-Up Leaf Evaluation (`FilterTreeNegative`)
1. Detect negative lookahead / exclusion filters:
   ```csharp
   bool isNegativeFilter = FilterUseRegex && searchRegex != null && (searchText.Contains("(?!") || searchText.Contains("(?<!"));
   ```
2. When `isNegativeFilter` is `true`, bypass top-down container cascading.
3. Collect all true leaf nodes across the tree (`n.Level > 0 && (n.Children == null || !n.Children.Any()) && n.Category != "Sheet" && n.Category != "View" && n.Category != "Root"`).
4. Strictly evaluate `searchRegex.IsMatch` on each leaf node.
   - If `match == true`: `leaf.IsChecked = true; ExpandParents(leaf);`
   - If `match == false`: `leaf.IsChecked = false;` (unless `FilterUseOr` is active).
5. Propagate states upwards from leaves via `root.RefreshState()`. Parent containers dynamically calculate:
   - All children checked $\rightarrow$ `IsChecked = true`.
   - Zero children checked $\rightarrow$ `IsChecked = false`.
   - Mixed children $\rightarrow$ `IsChecked = null` (Indeterminate).

---

## 3. Implementation Details

### 3.1. XAML View (`TransferPlus/Views/TransferPlusView.xaml`)
Added the new section at the end of the `BtnFilterRegexHelper` popup:
```xml
<!-- Category: Not Contain (Negative Matching) -->
<TextBlock Text="Not Contain (Negative Matching)" FontWeight="Bold" Foreground="#333" Margin="0,15,0,5" FontSize="11"/>
<Button Command="{Binding InsertFilterRegexHelperCommand}" CommandParameter="^(?!.*text).*$" Click="CloseFilterRegexPopup" HorizontalAlignment="Stretch">
    <Grid Margin="0,0,0,5" Width="355">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="110"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <Border Grid.Column="0" Background="#F9F9F9" BorderBrush="#E0E0E0" BorderThickness="1" CornerRadius="4" Height="28" Margin="0,0,10,0">
            <TextBlock Text="^(?!.*text).*$" HorizontalAlignment="Center" VerticalAlignment="Center" FontWeight="SemiBold" FontSize="9" Foreground="#111"/>
        </Border>
        <TextBlock Grid.Column="1" Text="Does not contain 'text' (matches everything else)" VerticalAlignment="Center" TextWrapping="Wrap" Foreground="#555" FontSize="10.5"/>
    </Grid>
</Button>
```

### 3.2. ViewModel (`TransferPlus/ViewModels/TransferPlusViewModel.cs`)
1. Enhanced `InsertFilterRegexHelper(string snippet)`:
   ```csharp
   [RelayCommand]
   private void InsertFilterRegexHelper(string snippet)
   {
       if (snippet.Contains("text") && !string.IsNullOrWhiteSpace(SearchFilter) && !SearchFilter.Contains("(?") && !SearchFilter.Contains(".*"))
       {
           SearchFilter = snippet.Replace("text", SearchFilter.Trim());
       }
       else
       {
           SearchFilter = string.IsNullOrWhiteSpace(SearchFilter) ? snippet : (SearchFilter + snippet);
       }
       FilterUseRegex = true;
       if (snippet.Contains("(?"))
       {
           FilterOnlyNames = true;
       }
   }
   ```
2. Added `FilterTreeNegative(Regex searchRegex)` and routed negative expressions in `FilterTree()`.

---

## 4. Verification & Validation
- **Debug.R24 Build & Local Deploy**: Completed successfully (0 errors).
- **Release.R24 Build**: Completed successfully (0 errors).
- **Autodesk App Store Bundle Package**: Packaged successfully via `build-bundle.ps1` for Revit 2023–2027.
- **Documentation**: Updated `User_Guide.md` and embedded `Resources/help.html`.
