# Walkthrough: Add "Not Contain" Option to Filter Regex Help & Specialized Bottom-Up Engine

**Date:** 2026-09-17  
**Add-in:** TransferPlus  
**Version:** v1.3.0  
**Branch:** TransferCAD  

---

## 1. Summary of Changes

A new regular expression helper option, **"Not Contain (Negative Matching)"**, was integrated into the **Regex Help (Filter)** popup located on the persistent **Filter** card in TransferPlus.

Additionally, a specialized bottom-up leaf evaluation engine (`FilterTreeNegative`) was developed to fix a critical hierarchical tree phenomenon: when using negative lookaheads (such as `^(?!.*dwg).*$`), parent structural folders (`"CAD Formats"`, `"Views"`, `"Families"`) previously evaluated to `match = true` and forced all descendant elements to `true`, erroneously selecting the entire tree. With `FilterTreeNegative`, evaluation is strictly confined to leaf elements, and parent container states are calculated bottom-up via `RefreshState()`.

This feature enables users across all application modes (**Standard Mode**, **Family Mode**, and **CAD Mode**) to accurately filter and select all elements whose names do NOT contain a given keyword or pattern.

---

## 2. Modified Components & Files

| Component | File | Changes Made |
|---|---|---|
| **View (WPF / XAML)** | [TransferPlusView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml) | Added `Not Contain (Negative Matching)` category header and button row with code `^(?!.*text).*$` and description to `BtnFilterRegexHelper` popup. |
| **ViewModel (C#)** | [TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs) | 1. Enhanced `InsertFilterRegexHelper` with smart text substitution and auto-activation of `FilterUseRegex` and `FilterOnlyNames`.<br>2. Implemented `FilterTreeNegative(Regex searchRegex)`: strictly evaluates leaf nodes, bypassing downward container cascading.<br>3. In `FilterTree`, routed negative patterns (`(?!` / `(?<!`) to `FilterTreeNegative`. |
| **Documentation** | [User_Guide.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/docs/User_Guide.md) | Added section 5.9 documenting Search & Advanced Filtering and updated the v1.3.0 Changelog. |
| **Help Resource** | [help.html](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Resources/help.html) | Added bullet point in Section 5 and updated v1.3.0 Changelog. |

---

## 3. Key Technical Decisions & Edge Case Handling

1. **Negative Lookaround Detection**:
   - In `FilterTree()`, `isNegativeFilter` detects `(?!` (negative lookahead) and `(?<!` (negative lookbehind).
2. **Leaf-Only Isolation**:
   - Leaf items to evaluate are gathered via:
     ```csharp
     GetAllDescendantNodes(RootNodes)
         .Where(n => n.Level > 0 && (n.Children == null || !n.Children.Any()) && n.Category != "Sheet" && n.Category != "View" && n.Category != "Root")
     ```
   - Structural grouping containers are never evaluated or forced to `true`.
3. **Bottom-Up State Calculation**:
   - After leaves are set, `root.RefreshState()` propagates states from the leaves up to the root. If all leaves in a folder pass $\rightarrow$ checked (`true`). If none pass $\rightarrow$ unchecked (`false`). If mixed $\rightarrow$ indeterminate (`null`).
4. **Smart Keyword Substitution**:
   - Pre-typed text in the search box (e.g. `dwg`) is automatically substituted into `^(?!.*dwg).*$` upon clicking the helper.

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
- [x] Negative regex patterns are routed to `FilterTreeNegative`.
- [x] Only items omitting the keyword are checked; items containing the keyword remain unchecked.
- [x] Parent categories reflect true tri-state (indeterminate or unchecked) without cascading down.
- [x] Filter functions across CAD Mode, Family Mode, and Standard Mode.
- [x] Bundles re-packaged and local desktop add-in updated.
