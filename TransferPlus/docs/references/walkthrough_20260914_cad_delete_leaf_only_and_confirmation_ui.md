# Technical Walkthrough: Leaf-Only CAD Deletion & Hierarchical Confirmation Window

**Date:** 2026-09-14  
**Component:** TransferPlus (Autodesk Revit Add-in)  
**Author:** DBDev_dbarberos (DBDev Solutions)  
**Target Environments:** Autodesk Revit 2024, 2025, 2026, 2027 (.NET Framework 4.8 & .NET 8)

---

## 1. Executive Summary

In TransferPlus CAD Mode (`IsCadDetailsManagerActive`), the Delete action button in the **"Select Details/CAD:"** card was updated to eliminate accidental deletion of parent Sheets and Views.

* **Before**: Tri-state checkbox cascading automatically marked parent `Sheet` and `View` nodes as checked when their child DWG was checked. `CollectCheckedCadItems` gathered these parent nodes, causing `DeleteSelectedCadItemsAsync` to delete the Revit `ViewSheet` and containing `View` from the active document along with the DWG.
* **Now**:
  1. **Leaf-Only Deletion Scope**: The deletion command strictly targets lowest-level leaf elements (CAD links, imports, detail components, detail groups). Parent Sheets and Views are **never** deleted and remain 100% intact in the Revit project for future reuse.
  2. **Dual-Targeting Support**: If checkboxes are checked, all checked leaf items are targeted. If no checkboxes are checked, the item actively selected in the card (`SelectedCadDetail`) is targeted.
  3. **Styled Confirmation Window (`ConfirmCadDeleteWindow.xaml`)**: Displays a custom modal dialog matching the visual theme of the add-in. The dialog organizes target items following the explorer's exact hierarchy (`Sheet` $\rightarrow$ `View` $\rightarrow$ `Item`), clearly highlighting `[Preserved (Sheet)]`, `[Preserved (View)]`, and `[To be deleted]`.

---

## 2. Technical Implementation Details

### 2.1. Grouping Node Isolation in `TransferPlusViewModel.cs`
Updated `CollectCheckedCadItems` to reject any structural container nodes:
```csharp
bool isGroupingNode = node.Children.Count > 0 || 
                      node.Category == "Sheet" || 
                      node.Category == "View" || 
                      node.Category == "Root";

if (!isGroupingNode && node.Item is CadDetailItemModel item && node.IsChecked == true)
{
    if (!list.Any(c => c.ElementId == item.ElementId && c.Name == item.Name))
    {
        list.Add(item);
    }
}
```

### 2.2. Flexible Enablement & Targeted Deletion
In `CanDeleteSelectedCadItems()`:
* The button is enabled if the active document is editable AND (any leaf checkboxes are checked OR `SelectedCadDetail` is a valid leaf element).

In `DeleteSelectedCadItemsAsync()`:
* Fallback to `SelectedCadDetail` when no checkboxes are checked.
* Groups items by Sheet $\rightarrow$ View $\rightarrow$ Item to populate `CadDeleteSheetGroup`.
* Opens `ConfirmCadDeleteWindow` modally.
* Executes deletion inside `using (var t = new Transaction(doc, "Delete CAD Details"))` deleting only leaf `ElementId`s.
* Resets `SelectedCadDetail = null` and reloads source CAD items.

### 2.3. Hierarchical Confirmation Window (`ConfirmCadDeleteWindow.xaml`)
* Window features:
  - Header with warning icon and explicit notice that Sheets and Views are preserved.
  - TreeView with styled `HierarchicalDataTemplate`s displaying Sheet containers (blue badge), View containers (purple badge), and leaf elements with red deletion badges and Revit element IDs.
  - Summary footer and `Cancel` / `Delete Elements` buttons.

---

## 3. Verification & Validation Matrix

| Test / Check | Target | Result | Notes |
|---|---|---|---|
| R24 Debug Compilation | `TransferPlus.csproj` | **PASSED (0 Errors)** | Deployed locally to `%APPDATA%\Autodesk\Revit\Addins\2024`. |
| R24-R27 Release Builds | Multi-version compilation | **PASSED (0 Errors)** | Binaries produced for Revit 2024, 2025, 2026, 2027. |
| App Store Bundle Script | `build-bundle.ps1` | **PASSED** | Generated `TransferPlus_v1.2.0.zip` and `TransferPlus.bundle.zip`. |
| Leaf-Only Deletion Logic | Unit & Code verification | **PASSED** | Parent Sheet and View IDs excluded from `doc.Delete()`. |
| Confirmation Window UI | `ConfirmCadDeleteWindow` | **PASSED** | WPF XAML validated with Pack URI icon, TreeView templates, and owner resolution. |

---

## 4. Modified & Created Files Summary
- `TransferPlus/Models/CadDeleteCandidateModel.cs` [NEW]
- `TransferPlus/Views/ConfirmCadDeleteWindow.xaml` [NEW]
- `TransferPlus/Views/ConfirmCadDeleteWindow.xaml.cs` [NEW]
- `TransferPlus/ViewModels/TransferPlusViewModel.cs` [MODIFY]
- `TransferPlus/docs/references/implementation_plan_20260914_cad_delete_leaf_only_and_confirmation_ui.md` [NEW]
- `TransferPlus/docs/references/walkthrough_20260914_cad_delete_leaf_only_and_confirmation_ui.md` [NEW]
