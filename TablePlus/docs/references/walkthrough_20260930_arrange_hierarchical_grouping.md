# Walkthrough: Dynamic Hierarchical Grouping under ARRANGE in TablePlus

## Overview
Implemented multi-level, activation-ordered hierarchical grouping in the TablePlus master table (`DataGrid`), driven by the 4 switches located under the **ARRANGE** column of the **Organize:** card:
1. `Sort by Category` (`SortByCategory`)
2. `Sort by Name` (`SortByName`)
3. `Sort by Sheet` (`SortBySheet`)
4. `Sort by View` (`SortByView`)

This functionality replicates the grouping paradigm proven in `FilterPlus` (`SelectionFilterViewModel.cs`):
- Users can activate multiple switches simultaneously.
- The grouping hierarchy order strictly mirrors the chronological sequence in which the switches were toggled ON.
- Each group level can be independently expanded or collapsed.
- Group headers contain responsive CheckBoxes that toggle all items within that group and reflect `Checked`, `Indeterminate`, or `Unchecked` states.
- If all switches are turned OFF, the table seamlessly reverts to the default flat group (`GroupName = "All"`).

---

## Changes Implemented

### 1. Data Model (`TableItemModel.cs`)
- Added observable `SheetName` property representing the Revit Sheet where the view is placed (or `"Unplaced"`).
- Added `CategoryName` property mapping `TargetViewType` to `"Drafting Views"`, `"Legends"`, or `"Schedules"`.
- Added `TableName` property resolving to the Excel source file name or falling back to the view name.

### 2. Service Layer (`TableRegistryService.cs`)
- Implemented `BuildViewToSheetMapping(Document doc)` to query:
  - `Viewport` elements for Drafting Views and Legends.
  - `ScheduleSheetInstance` elements for Schedule Views placed on sheets.
- Automatically assigns `item.SheetName` during table inventory discovery (`DiscoverTablesAsync`).

### 3. ViewModel (`MainWindowViewModel.cs`)
- Maintained a private `List<string> _activeGroupings` tracking activated criteria in chronological order.
- Implemented partial property change handlers for `SortByCategory`, `SortByName`, `SortBySheet`, and `SortByView`.
- Implemented `ApplyGroupings()`:
  - Wraps grouping changes in `FilteredTables.DeferRefresh()`.
  - Clears previous `GroupDescriptions` and reapplies `PropertyGroupDescription`s in exact activation order.
  - If `SortByName` is active, adds `SortDescription` for alphabetical sorting (A-Z).
- Provided `RequestSetAllGroupsExpanded` delegate to invoke visual expand/collapse from `ExpandAllCommand` and `CollapseAllCommand`.

### 4. UI Layout & GroupStyle (`MainWindowView.xaml` & `MainWindowView.xaml.cs`)
- Created `GroupItemToIndentMarginConverter` and `GroupItemToBackgroundConverter` in `Converters.cs` to render visual indentations and tinting across nested levels without shifting DataGrid columns.
- Removed restrictive `DataGridRowsPresenter` from `<GroupStyle.Panel>` to prevent runtime `InvalidCastException` on nested groups.
- Set `<Expander IsExpanded="True">` to enable independent group toggling.
- Added group-level CheckBox event handlers (`GroupCheckBox_Click`, `GroupCheckBox_Loaded`, `UpdateGroupCheckboxes`) providing tri-state synchronization with child table rows.

---

## Verification & Deployment
- Built with 0 errors and 0 warnings:
  - `dotnet build TablePlus\TablePlus.csproj -c "Debug R25"` -> `bin\Debug R25\TablePlus.dll`
  - `dotnet build TablePlus\TablePlus.csproj -c "Release R24"` -> `bin\Release R24\TablePlus.dll`
- Successfully deployed to active Revit addin directories:
  - `C:\Users\dbarb\AppData\Roaming\Autodesk\Revit\Addins\2025\TablePlus\TablePlus.dll`
  - `C:\Users\dbarb\AppData\Roaming\Autodesk\Revit\Addins\2024\TablePlus\TablePlus.dll`
