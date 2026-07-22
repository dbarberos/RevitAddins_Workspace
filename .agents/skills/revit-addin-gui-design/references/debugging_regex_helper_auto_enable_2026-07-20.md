# Debugging Report: Auto-enabling Regex Checkbox on Helper Click & Full Title Pattern

## Info
* **Date:** 2026-07-20
* **Component:** `TransferPlusView.xaml` / `TransferPlusViewModel.cs`
* **Skill Target:** `revit-addin-gui-design`
* **Technology:** WPF MVVM / Data Binding / Regular Expressions

---

## 1. Symptom & Requirements
1. **Manual Checkbox Step:** Users clicking a regex helper option from the "i" info popup expected regex mode to automatically activate. Previously, users had to manually check the "Use regex" checkbox after picking an option.
2. **Missing Full Text Pattern:** There was no quick option in the helper list to match/select an entire string completely including whitespace, word characters, and non-word characters.

---

## 2. Solution

### A. Auto-Enable Regex Mode in ViewModel
Updated `InsertRegexHelper` command in `TransferPlusViewModel.cs` to set `RenameUseRegex = true` whenever a helper button is clicked:

```csharp
[RelayCommand]
private void InsertRegexHelper(string snippet)
{
    RenameSearchText += snippet;
    RenameUseRegex = true; // Auto-activates the Use Regex checkbox by default
}
```

### B. Add Full Title Match Option (`^[\w\s\W]+$`)
Added a new entry button in `TransferPlusView.xaml` under `Basic Matching & Anchors`:
* Pattern: `^[\w\s\W]+$`
* Description: "Selects the full title completely"
