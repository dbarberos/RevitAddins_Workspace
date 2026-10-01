# Walkthrough - Intermediate Source Selection and Cloud/Local File Navigation

**Date:** 2026-10-01  
**Add-in:** TablePlus  
**Component:** `TableSourceSelectionView`, `TableSourceSelectionViewModel`, `CloudFileBrowserView`, `CloudFileBrowserViewModel`, `MainWindowViewModel`

---

## 1. Overview & Objectives

In this phase, we updated the table creation workflow when clicking **Add Table** (or dropping files):
1. **Intermediate Source Selection Dialog (`TableSourceSelectionView`)**:
   - Replaced immediate display of the heavy wizard window (`TableImportView`) with an agile intermediate window.
   - Features the input title `"Select the source of your file/s:"` aligned to the left edge of the input, using `FontWeight="Bold"`, `FontSize="12"`, `Foreground="#999"`, and a `5px` gap above the input row (matching the exact styling of the `Filter` and `Organize` card headers).
   - Features a styled dropdown replicated directly from the top input in the `TransferPlus` add-in:
     - `Border` with `BorderBrush="#007ACC"`, `BorderThickness="1.5"`, `CornerRadius="4"`, `Height="30"`, `Background="White"`, and borderless `ComboBox`.
   - To the right, a primary button labeled `"Select"`.
   - Directly underneath, an iOS-style switchbox labeled `"Use relative path"` (`SwitchStyle` with smooth animation, #ddd to #777, 28x14 dimensions).
   - **Contextual Availability**: Enabled exclusively for local disk and favorite folder sources (`IsRelativePathEnabled = true`). When any cloud source (ACC, Azure, AWS) is selected, the switch automatically disables (`IsEnabled = false`) and resets to prevent invalid relative paths.
2. **Dynamic Source Hierarchy**:
   - Default option: `(Local) Local Disk / File Explorer`.
   - Local directory favorites: `(Local) {Name}` loaded from `TableSourceConfigService`.
   - Cloud storage integrations: `(ACC) {Name}`, `(Azure) {Name}`, `(AWS S3) {Name}`.
3. **Multi-File Selection & Navigation**:
   - **Local Disk / Folder:** Invokes Windows native `OpenFileDialog` with `Multiselect = true` and comprehensive table format filters (`.xlsx`, `.xls`, `.csv`, `.docx`, `.pdf`, `.md`, etc.).
   - **Cloud Sources:** Invokes the new `CloudFileBrowserView` modal allowing search filtering, batch selection (`Select All`, `Deselect All`), column sorting, and multi-file downloads.
4. **Transition to Add Table Wizard**:
   - Selected file paths and `IsRelativePath` preference are injected into `TableImportViewModel`.
   - The primary file is parsed and loaded into `TableImportView` ready for table configuration.

---

## 2. Key Changes & File Map

### New Components
- **[`TableSourcePickerItem.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Models/TableSourcePickerItem.cs)**: Data model encapsulating the dropdown display label (`DisplayName`), source model reference, and type discriminator.
- **[`TableSourceSelectionView.xaml`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Views/TableSourceSelectionView.xaml)** & **[`.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Views/TableSourceSelectionView.xaml.cs)**: Compact WPF modal window (80px height) hosting the TransferPlus-style input and `"Select"` button with Esc keybinding.
- **[`TableSourceSelectionViewModel.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/ViewModels/TableSourceSelectionViewModel.cs)**: Business logic managing source sorting, local vs cloud dispatch, and multi-selection return list.
- **[`CloudFileBrowserView.xaml`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Views/CloudFileBrowserView.xaml)** & **[`.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Views/CloudFileBrowserView.xaml.cs)**: Modern cloud file explorer with search filtering, selection checkboxes, modified dates, file sizes, and download progress.
- **[`CloudFileBrowserViewModel.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/ViewModels/CloudFileBrowserViewModel.cs)**: Asynchronous cloud file fetcher supporting ACC, Azure Blob Storage, and AWS S3.

### Updated Components
- **[`MainWindowViewModel.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/ViewModels/MainWindowViewModel.cs)**:
  - Added `AddTableWithFilesAsync(IEnumerable<string> filePaths)`.
  - Refactored `AddTableAsync` to show `TableSourceSelectionView` before opening `TableImportView`.
- **[`MainWindowView.xaml.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Views/MainWindowView.xaml.cs)**:
  - Enabled multi-file drag-and-drop processing via `validFiles` filtering.
- **[`CmdAddTableDirect.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Commands/CmdAddTableDirect.cs)**:
  - Updated context menu shortcut command to adopt the intermediate source selection window.
- **[`TableImportViewModel.cs`](file:///B:/REVIT/C%23/RevitAddins_Workspace/TablePlus/ViewModels/TableImportViewModel.cs)**:
  - Added `[ObservableProperty] private List<string> _selectedFilePaths = new();`.

---

## 3. Verification & Compilation

- **Revit 2025 (.NET 8):** `dotnet build TablePlus\TablePlus.csproj -c "Debug R25" /p:DeployAddin=false` -> **Build Succeeded (0 Errors, 0 Warnings)**.
- **Revit 2024 (.NET Framework 4.8):** `dotnet build TablePlus\TablePlus.csproj -c "Debug R24" /p:DeployAddin=false` -> **Build Succeeded (0 Errors, 0 Warnings)**.
