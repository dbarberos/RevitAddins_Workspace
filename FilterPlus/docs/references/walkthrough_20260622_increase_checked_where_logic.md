# Walkthrough - Diagnostic Logging, Layout Fix, and Revit 2024 Target for 'Increase Checked'

We have updated the **Increase Checked** feature of **FilterPlus** to work correctly in the active Revit 2024 environment:
1. Changed build targets to compile for **Revit 2024** (`Debug.R24`) and cleaned up the old root DLL that was blocking updates.
2. Merged elements checked in other scopes (`idsFromOtherScopes`) to preserve selection state.
3. Isolated `_activeElements` injection to only include newly matched target elements (`targetIds`).
4. Added the third domain option "Visible in current view" under "WHERE".

## Changes Made

### Views

#### [SelectionFilterView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml)

- Fixed overlapping controls inside the "Increase Checked" Card Grid:
  - Added a third row definition (`<RowDefinition Height="Auto"/>`) to the outer grid layout.
  - Moved the `Apply` Button from `Grid.Row="1"` to `Grid.Row="2"` and added `Margin="0,10,0,0"` to give it vertical spacing from the checkboxes.
  - Restored command binding to `Command="{Binding ApplyIncreaseCheckedCommand}"`.
- Added the `Visible in current view` radio button in the "WHERE" panel.

### ViewModels

#### [SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)

- Added the `IncreaseWhereVisibleInView` property.
- Handled the `IncreaseWhereVisibleInView` selection domain by querying `FilteredElementCollector(doc, doc.ActiveView.Id)` in `ApplyIncreaseChecked()`.
- Updated the checkmark merging logic to preserve `idsFromOtherScopes` in `finalCheckedIds`.
- Refined element injection to only process `targetIds` (elements newly matched by the increase operation).
- Included detailed diagnostic logs (`LoggerService.LogInfo`) throughout the selection process to ease future tracing.

### Deployments

- Removed the outdated DLL `C:\Users\david.barbero\AppData\Roaming\Autodesk\Revit\Addins\2024\FilterPlus.dll` from May to prevent load conflicts.
- Built and deployed the updated add-in assembly using the Revit 2024 configuration (`Debug.R24`).

## Validation Results

- Successfully built the solution using:
  ```powershell
  dotnet build -c Debug.R24
  ```
  The build compiled with 0 errors and successfully updated the files under `C:\Users\david.barbero\AppData\Roaming\Autodesk\Revit\Addins\2024\FilterPlus\`.
