# Implementation Plan: Revit Persistent "Saved Selections"

Provide a feature to save, load, and manage selection states directly inside the Revit document database. This ensures selection sets survive across sessions, reloads, and worksharing synchronizations. The selection sets will be serialized as JSON payloads and stored globally in the `ProjectInformation` using Revit's Extensible Storage.

## User Review Required

> [!IMPORTANT]
> **Placeholder/Empty Dropdown Item**: The ComboBox will contain an empty item at index 0 (representing "no selection active"). The "Recover" button will remain disabled until a valid selection is selected.
> **Dedicated Save Dialog (`SaveSelectionView`)**: Clicking **Save** in the main window will open a new dialog offering two independent rows:
> - **Row 1 (Save as New)**: Enabled and highlighted only when a name is typed in the TextBox.
> - **Row 2 (Overwrite Existing)**: Enabled and highlighted only when an existing item is selected from the ComboBox.
> - Both actions require explicit user confirmation ("Save the Selection") via a native TaskDialog before closing.

## Open Questions

- *No open questions.* The requirements are now fully specified and clear.

---

## Proposed Changes

### [Component: Models]

#### [MODIFY] [SavedSelection.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/SavedSelection.cs)
Define serializable structures to store selection data:
- `SavedSelection`: Contains `Name` (string), `Elements` (List of `SavedElementKey`), and `ActiveModelInstanceNames` (List of string).
- `SavedElementKey`: Contains `ElementIdValue` (int) and `LinkInstanceIdValue` (int, representing the host LinkInstance element ID or -1).

---

### [Component: Services]

#### [NEW] [ExtensibleStorageManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Services/ExtensibleStorageManager.cs)
Import `ExtensibleStorageManager.cs` from the global `revit-api-data/assets` folder. Update its namespace to `FilterPlus.Services` and set `DefaultVendorId` to `"DBDev_dbarberos"`.

#### [NEW] [SavedSelectionsService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Services/SavedSelectionsService.cs)
Create a service class to handle serialization and persistence tasks:
- `LoadSavedSelections(Document doc)`: Reads JSON from Extensible Storage and deserializes it to a list of `SavedSelection`.
- `SaveSavedSelections(Document doc, List<SavedSelection> selections)`: Serializes selections to JSON and writes it to Extensible Storage inside a synchronous transaction.

---

### [Component: ViewModels]

#### [NEW] [SaveSelectionViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SaveSelectionViewModel.cs)
Create the ViewModel for the new Save Dialog:
- Properties:
  - `NewSelectionName` (string, bound to Row 1 TextBox).
  - `ExistingSelections` (ObservableCollection of `SavedSelection`, excluding placeholder).
  - `SelectedExistingSelection` (SavedSelection, bound to Row 2 ComboBox).
  - `IsNewNameValid` (bool, returns true if `NewSelectionName` is not empty/whitespace).
  - `IsExistingSelectionSelected` (bool, returns true if `SelectedExistingSelection` is not null).
- Relay Commands:
  - `SaveNewCommand(Window window)`: Shows confirmation TaskDialog ("Save the Selection"). If confirmed, calls the callback to save a new entry, and closes the window.
  - `OverwriteCommand(Window window)`: Shows confirmation TaskDialog ("Save the Selection"). If confirmed, calls the callback to overwrite the existing entry, and closes the window.

#### [MODIFY] [SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)
Add properties and commands for main window interaction:
- Expose Observable Properties:
  - `SavedSelections` (ObservableCollection of `SavedSelection`, including empty placeholder as index 0).
  - `SelectedSavedSelection` (SavedSelection, bound to SelectedItem).
  - `IsSavedSelectionSelected` (bool, returns true if `SelectedSavedSelection` is not null and has a non-empty name).
- Relay Commands:
  - `OpenSaveSelectionDialogCommand`: Exposes command to open `SaveSelectionView` and registers callbacks for saving/overwriting.
  - `RecoverSavedSelectionCommand`:
    - Reads the `SelectedSavedSelection` elements.
    - Syncs active `SelectedModels` using `ApplySelectedModels()`.
    - Resets `_persistentCheckedIds` to the saved element keys.
    - Triggers `BuildTree()` and `ApplyFilter()` to refresh UI explorer and highlight elements in Revit.
- Load saved selections from the document on startup and populate the `SavedSelections` collection.

---

### [Component: Views]

#### [NEW] [SaveSelectionView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SaveSelectionView.xaml)
Create the dialog layout matching the specification:
- Title: "Save Selection"
- Row 1: Left Button `Save New` (Style trigger on `IsNewNameValid` for background/foreground/IsEnabled), Right TextBox.
- Row 2: Left Button `Overwrite` (Style trigger on `IsExistingSelectionSelected` for background/foreground/IsEnabled), Right ComboBox.
- Set `CornerRadius="4"` on buttons to match styling.

#### [NEW] [SaveSelectionView.xaml.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SaveSelectionView.xaml.cs)
WPF code-behind to bind the View to its ViewModel.

#### [MODIFY] [SelectionFilterView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml)
Update the "Saved Selections" card:
- ComboBox: Set `IsEditable="False"` (standard dropdown) and bind:
  - `ItemsSource="{Binding SavedSelections}"`
  - `DisplayMemberPath="Name"`
  - `SelectedItem="{Binding SelectedSavedSelection}"`
- Rename the Apply button to `"Recover"`.
- Set background to `#e0e0e0` / disabled by default, and change to `#007ACC` / enabled when `IsSavedSelectionSelected` is true. Bind command: `Command="{Binding RecoverSavedSelectionCommand}"`.
- Save Button: Bind command `Command="{Binding OpenSaveSelectionDialogCommand}"`.

---

## Verification Plan

### Automated Tests
- Run `dotnet build` to ensure the project builds correctly with the new views and bindings.

### Manual Verification
1. Open Revit 2024 and launch FilterPlus.
2. Select elements and verify visual checks in tree explorer.
3. In "Saved Selections" card, verify "ComboBox" displays an empty/placeholder item first. Verify **Recover** button is disabled/gray.
4. Click **Save** in the card. Verify the `Save Selection` dialog opens.
5. In the dialog:
   - Type `"New Selection 1"` in Row 1. Verify **Save New** button turns blue and enabled. Click it and confirm the dialog.
6. Verify `"New Selection 1"` is now selectable in the main dropdown.
7. Select `"New Selection 1"`. Verify the **Recover** button turns blue and enabled.
8. Click **Recover** and verify it highlights the saved elements.
9. Open the dialog again, select `"New Selection 1"` in Row 2, verify **Overwrite** button turns blue and enabled. Click it and confirm.
10. Close Revit, reopen, and verify the selections are preserved in the document context.
