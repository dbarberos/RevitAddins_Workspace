# Technical Pattern Report: Regex Prefix & Suffix Helper Integration ($1 Capture Group)

## Info
* **Date:** 2026-07-20
* **Component:** `TransferPlusView.xaml` / `TransferPlusViewModel.cs`
* **Skill Target:** `revit-addin-gui-design`
* **Technology:** WPF MVVM / Data Binding / Regular Expression Capture Groups

---

## 1. Feature Requirement
Allow users to easily prepend prefixes or append suffixes to element names during renaming without adding new physical buttons to the UI.

---

## 2. Solution & Architectural Logic

### A. Populating Helper Options in "Changed by:" Popup
Added two new options inside the helper popup ("i" button next to "Changed by:"):
1. `prefix_text$1`: Adds a prefix using regex capture group `$1`.
2. `$1suffix_text`: Adds a suffix using regex capture group `$1`.

### B. Auto-Populating "Find:" and Enabling Regex
Updated `InsertDateHelper` command in `TransferPlusViewModel.cs`. When any snippet containing `$1` is selected:
1. It appends the snippet (`prefix_text$1` or `$1suffix_text`) into `RenameReplaceText` ("Changed by:").
2. It checks if `RenameSearchText` ("Find:") contains `(.*)`. If empty or missing, it sets `RenameSearchText = "(.*)"` to capture the entire original title into Group 1.
3. It automatically sets `RenameUseRegex = true`, enabling the "Use regular expressions" checkbox.

```csharp
[RelayCommand]
private void InsertDateHelper(string snippet)
{
    RenameReplaceText += snippet;

    if (snippet.Contains("$1"))
    {
        if (string.IsNullOrEmpty(RenameSearchText) || !RenameSearchText.Contains("(.*)"))
        {
            RenameSearchText = "(.*)";
        }
        RenameUseRegex = true;
    }
}
```
