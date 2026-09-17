# Implementation Plan: Add "Not Contain" Option to Filter Regex Help

**Date:** 2026-09-17  
**Add-in:** TransferPlus  
**Component:** Asset Explorer Filter Card & Regex Helper Palette  

---

## 1. Objective
Add a new regular expression pattern option to the **Regex Help (Filter)** dropdown within the main window's **Filter** card, allowing users across all add-in modes (**Current Project / Standard Mode**, **Family Mode**, and **CAD Mode**) to filter and select elements whose names do NOT contain a specified keyword.

---

## 2. Technical Architecture & Analysis

### 2.1. Shared Filter Card Scope
The Filter card in `TransferPlusView.xaml` (lines 490–850) is part of the persistent right-hand settings panel and is shared across all operation modes (Standard, Family, and CAD mode).

### 2.2. Negative Matching Pattern & Lookahead
- Regex: `^(?!.*text).*$`
- The negative lookahead `(?!.*text)` ensures that the string starting at the anchor `^` does not contain the sequence `text` anywhere before matching the remainder of the line `.*$`.
- Case-insensitivity is managed via `RegexOptions.IgnoreCase`.

### 2.3. Category False-Positive Prevention
In `TransferPlusViewModel.FilterNode`:
```csharp
match = searchRegex.IsMatch(node.Name);
if (!match && !FilterOnlyNames)
{
    match = searchRegex.IsMatch(node.Category);
}
```
If `FilterOnlyNames` were `false`, an element with name `"Puerta Entrada"` (which doesn't match `^(?!.*Puerta).*$`) would fail the first check, but `searchRegex.IsMatch("Doors")` would evaluate to `true` (since `"Doors"` does not contain `"Puerta"`). This would produce false positive selections.  
**Resolution:** When the negative match helper is selected, the ViewModel automatically enforces `FilterOnlyNames = true` alongside `FilterUseRegex = true`.

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
Enhanced `InsertFilterRegexHelper(string snippet)`:
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

---

## 4. Verification & Validation
- **Debug.R24 Build & Local Deploy**: Completed successfully (0 errors).
- **Release.R24 Build**: Completed successfully (0 errors).
- **Autodesk App Store Bundle Package**: Packaged successfully via `build-bundle.ps1` for Revit 2023–2027.
- **Documentation**: Updated `User_Guide.md` and embedded `Resources/help.html`.
