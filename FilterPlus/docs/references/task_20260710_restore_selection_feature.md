# TODO List: Restore Revit Selection Feature in FilterPlus

- `[x]` Implement `CanRestoreRevitSelection` property, `RestoreRevitSelectionCommand`, and `UpdateCanRestore` logic in `SelectionFilterViewModel.cs`
- `[x]` Add the Restore button to the explorer header in `SelectionFilterView.xaml`
- `[x]` Wire the window `Activated` event in `SelectionFilterView.xaml.cs` to trigger `UpdateCanRestore`
- `[x]` Fix WPF UI Dispatcher Background deadlocks inside the Modal loop.
- `[x]` Implement Queue-safe sequential processing for ActionEventHandler external events.
- `[x]` Fix active model selection wipe upon linked models deselection.
- `[x]` Compile and verify the project using the R24 SDK
