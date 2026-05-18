# Implementation Plan - Fix Crash & Debug Window

Address the Revit crash when switching scopes and implement a real-time debug log window.

## Proposed Changes

### Stability Fix
- Added `IsBulkUpdating` flag to `TreeItemViewModel` to suppress recursive parent notifications and property change callbacks during bulk operations.
- This prevents the "event storm" that was likely causing the Revit crash during large tree updates.

### Debug Log System
- **LoggerService**: Enhanced to maintain an `ObservableCollection<string>` of logs with thread-safe UI updates.
- **LogView**: New window to display real-time logs using a dark-themed UI.
- **Integration**: Automatically opens alongside the main window to provide immediate feedback on add-in operations.

## Verification Plan
- Built for Revit 2024 (`dotnet build -c Release.R24`).
- Confirmed that `LoadElements` and `InitializeTree` use the bulk update flag.
- Verified that the `LogView` is instantiated and shown by the main view.
