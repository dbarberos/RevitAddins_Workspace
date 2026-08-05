# Technical Feature & Debugging: Filter Card Regex Helper Integration

## 📌 Context & Feature Scope
In **TransferPlus**, the right-hand **Filter** card contains search switches: `"Use OR"`, `"Only by name"`, and `"Use Regex"`. To improve user experience when filtering elements using Regular Expressions, a circular help button `(i)` has been added to the Filter card, mirroring the pattern in the Rename palette.

---

## 🛠️ Implementation & Layout Details

1. **Exact Alignment & Spacing:**  
   The circular `ToggleButton` (`x:Name="BtnFilterRegexHelper"`) is placed in the same horizontal row as the switches, immediately to the right of the `"Use Regex"` CheckBox.
   - `Margin="8,0,0,0"` matches the internal gap of `SwitchStyle` between the toggle pill and its text label.
2. **Preset Pattern Insertion (`InsertFilterRegexHelper`):**  
   Clicking any regex option preset (e.g. `^[\w\s\W]+$`, `\d`, `.*text.*`, `^text`, `text$`) in the popup modal:
   - Appends the selected pattern snippet into the filter input text box (`SearchFilter`).
   - Automatically enables the `"Use Regex"` switch (`FilterUseRegex = true`).
   - Closes the popup modal via `CloseFilterRegexPopup` (`BtnFilterRegexHelper.IsChecked = false`).

```csharp
[RelayCommand]
private void InsertFilterRegexHelper(string snippet)
{
    SearchFilter = (SearchFilter ?? string.Empty) + snippet;
    FilterUseRegex = true;
}
```

---

## ✅ Verification
- Compiles cleanly with **0 Errores**.
- Clicking `(i)` opens the Regex Help modal. Selecting any item populates `SearchFilter`, checks `FilterUseRegex`, and closes the popup.
