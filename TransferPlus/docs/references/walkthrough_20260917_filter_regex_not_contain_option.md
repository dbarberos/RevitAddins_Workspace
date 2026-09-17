# Walkthrough: Add "Not Contain" Option to Filter Regex Help

**Date:** 2026-09-17  
**Add-in:** TransferPlus  
**Version:** v1.3.0  
**Branch:** TransferCAD  

---

## 1. Summary of Changes

A new regular expression helper option, **"Not Contain (Negative Matching)"**, was integrated into the **Regex Help (Filter)** popup located on the persistent **Filter** card in TransferPlus.

This feature enables users across all application modes (**Standard Mode**, **Family Mode**, and **CAD Mode**) to filter and select all elements whose names do NOT contain a given keyword or pattern.

---

## 2. Modified Components & Files

| Component | File | Changes Made |
|---|---|---|
| **View (WPF / XAML)** | [TransferPlusView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml) | Added `Not Contain (Negative Matching)` category header and button row with code `^(?!.*text).*$` and description to `BtnFilterRegexHelper` popup. |
| **ViewModel (C#)** | [TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs) | Enhanced `InsertFilterRegexHelper` with smart text substitution (`text` replaced with current filter text if present) and automatic activation of `FilterUseRegex = true` and `FilterOnlyNames = true` to prevent false positive category matches. |
| **Documentation** | [User_Guide.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/docs/User_Guide.md) | Added section 5.9 documenting Search & Advanced Filtering and updated the v1.3.0 Changelog. |
| **Help Resource** | [help.html](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Resources/help.html) | Added bullet point in Section 5 and updated v1.3.0 Changelog. |

---

## 3. Key Technical Decisions & Edge Case Handling

1. **Negative Lookahead Syntax**:
   - Uses `^(?!.*text).*$`. In .NET Regular Expressions with `RegexOptions.IgnoreCase`, this matches all strings from start to end that do not contain the substring `"text"`.
2. **Category False-Positive Suppression**:
   - When filtering without `FilterOnlyNames`, TransferPlus checks `Category` if `Name` fails to match. If someone searches for items *not* containing `"Puerta"`, a door called `"Puerta 1"` would fail the name match, but its category `"Doors"` does NOT contain `"Puerta"`, incorrectly causing it to match!
   - By automatically enabling `FilterOnlyNames = true` whenever a lookahead `(?` pattern is inserted, the filter strictly tests element and view names.
3. **Smart Keyword Substitution**:
   - If the user types a term like `M_` in the filter box and clicks the button, the helper replaces `"text"` with `"M_"`, resulting directly in `^(?!.*M_).*$`.
   - If the filter box is empty, it populates `^(?!.*text).*$` for the user to edit.

---

## 4. Compilation and Build Validation

| Target / Script | Result | Output Artifact |
|---|---|---|
| `dotnet build -c Debug.R24 /p:DeployAddin=true` | **SUCCESS** (0 errors, 438 warnings) | Deployed to Revit 2024 Add-Ins directory |
| `dotnet build -c Release.R24` | **SUCCESS** (0 errors, 438 warnings) | `bin/Release.R24/TransferPlus.dll` |
| `build-bundle.ps1` | **SUCCESS** (0 errors) | `Deploy/TransferPlus_v1.3.0.zip` and `TransferPlusPublishPackage/TransferPlus.bundle.zip` |

---

## 5. Verification Checklist
- [x] UI matches existing rows: button border on left (`Width="110"`), text description on right.
- [x] Placed at the very end of the list under its own category header.
- [x] Clicking row inserts regex, enables `Use Regex`, enables `Only by name`, and closes popup.
- [x] Filter functions across CAD Mode, Family Mode, and Standard Mode.
- [x] Bundles re-packaged and local desktop add-in updated.
