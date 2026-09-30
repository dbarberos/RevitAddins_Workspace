# Walkthrough: System Status Relocation to Compact Footer HUD in TablePlus

## Overview
Migrated the **System Status** component from the upper card zone (Row 0) to a compact, high-density **Health & Telemetry HUD card** in the bottom bar (Row 2), positioned right next to the tables counter and configuration cog.

---

## Changes Implemented

### 1. Upper Control Zone Simplification (`MainWindowView.xaml`)
- Removed the former Card 3 ("System Status") from Row 0.
- Updated `Row 0` `Grid.ColumnDefinitions` to 2 cards (`Filter` and `Organize:`) plus open trailing space.
- Provided a cleaner, distraction-free upper area focused purely on finding and organizing tables.

### 2. Compact Bottom Health & Status HUD (`MainWindowView.xaml`)
- Located in `Row 2` immediately adjacent to the `X / Y tables selected` badge card.
- **Borderless & Minimalist Design**: Eliminated the outer card container/border box, integrating controls seamlessly into the bottom bar.
- **Round Rescan Button**: Circular button matching the exact visual style, sizing, and colors of the Configuration Cog button (`Viewbox 18x18`, two curved sync arrows vector, `#777` turning `#333` on hover with `#eeeeee` background).
- **Solid Circular Status Badges**: Clean 22x22px solid colored circles with bold white count numbers inside:
  - **Up to Date Circle (`#10B981` Green)**: Count of synchronized tables (`{UpToDateCount}`). Tooltip: *"Tables fully synchronized with their source files on disk. Click to filter."*
  - **Modified Circle (`#F59E0B` Amber/Yellow)**: Count of modified tables (`{ModifiedCount}`). Tooltip: *"Tables whose source Excel files on disk have been edited and require synchronization. Click to filter."*
  - **File Missing Circle (`#EF4444` Red)**: Count of tables missing source files (`{FileNotFoundCount}`). Tooltip: *"Tables whose source Excel file cannot be found at the specified path. Click to filter."*
- **Light Gray Telemetry Text**: `BusyStatusMessage` displayed directly after the status badge circles in light gray (`#888888`), accompanied by a discrete 2.5px progress bar when background tasks are active.
- Configured each status badge with `FilterByStatusBadgeCommand`: clicking any badge toggles filtering the DataGrid directly to that status (or clears back to `"All"`).

### 3. ViewModel Logic (`MainWindowViewModel.cs`)
- Added observable properties:
  - `UpToDateCount`
  - `ModifiedCount`
  - `FileNotFoundCount`
- Updated `UpdateCounters()` to dynamically calculate exact counts for each synchronization status alongside `TotalCount` and `SelectedCount`.
- Implemented `FilterByStatusBadge(string status)` command.

---

## Verification & Deployment
- Recompiled with 0 errors and 0 warnings:
  - `Debug R25`: `bin\Debug R25\TablePlus.dll`
  - `Release R24`: `bin\Release R24\TablePlus.dll`
- Deployed to active Revit directories:
  - `C:\Users\dbarb\AppData\Roaming\Autodesk\Revit\Addins\2025\TablePlus\TablePlus.dll`
  - `C:\Users\dbarb\AppData\Roaming\Autodesk\Revit\Addins\2024\TablePlus\TablePlus.dll`
