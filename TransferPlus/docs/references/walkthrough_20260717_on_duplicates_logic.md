# Walkthrough: "On Duplicates" Feature Implementation

We updated the duplication resolution UI and back-end logic to allow three distinct options during element copying operations.

## Features Implemented

1. **Revised UI Options**
   - In `TransferPlusView.xaml`, replaced "Ok", "Abort", and "Ask User" with:
     *   **Keep Original**: Automatically accepts the version already present in the target model.
     *   **Abort Transaction**: Automatically halts the process if any duplication is found, rolling back the target transaction and warning the user.
     *   **Append Suffix:**: Appends a custom text string to any duplicate elements (including types and instances) during transfer.
   - Added a `TextBox` for `DuplicatesSuffixText` next to "Append Suffix:" that dynamically enables only when the suffix option is selected.

2. **Clean Rename Mappings**
   - Updated the properties in `TransferPlusViewModel.cs` and matching configuration fields in `Configuraciones.cs`:
     *   `KeepOriginal` maps to `cf_rbKeepOriginal`
     *   `AbortTransaction` maps to `cf_rbAbortTransaction`
     *   `AppendSuffix` maps to `cf_rbAppendSuffix`
     *   `DuplicatesSuffixText` maps to `cf_suffixText`

3. **Collision Detection and Bridge Document Strategy**
   - Implemented a duplicate name validator helper `TargetHasDuplicateName` inside `TransferOrchestrator.cs` supporting both `ElementType`s and standard instances (Views, Sheets, Levels, Filters, Categories, etc.).
   - For **Append Suffix**, if any name collisions are found, the orchestrator executes the *Bridge Document* strategy:
     1. Creates a temporary project document in memory using `NewProjectDocument` matching the unit system.
     2. Copies the elements into it.
     3. Appends the suffix to all colliding elements' names inside the temp document.
     4. Copies the elements from the temp document to the final target document.
     5. Discards the temporary document without saving.
   - For **Abort Transaction**, the orchestrator manually pre-scans and collects duplicate names. If any exist, it throws an `OperationCanceledException` containing the duplicates in its `Data` property.

4. **Detailed Duplicates Abort Dialog (WPF)**
   - Created [DuplicatesAbortView](file:///C:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/DuplicatesAbortView.xaml) which displays a table listing the names of all duplicate elements (Worksets, Families, Object Styles, Types) that prevented the transfer.
   - Built a selection mechanism allowing users to select rows and copy them to the Windows clipboard using Ctrl+C, "Copy Selected", or "Copy All" buttons for external tracking.

## Compilation
- The solution compiles successfully without errors (`0 Errores`).
