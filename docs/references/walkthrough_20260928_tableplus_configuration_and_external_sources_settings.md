# Walkthrough — TablePlus Configuration Window & External Sources Settings

## 1. Overview
In this iteration (TablePlus v1.2.0), we implemented the complete **Configuration & External Sources Management** system in TablePlus, bringing full visual and operational parity with TransferPlus's CAD & Details Sources Settings.

## 2. Key Changes & Implemented Features

### 2.1. Filter Card Layout Adjustment
- Replaced the previous wide "Filter & Search" card in `MainWindowView.xaml` with the refined "Filter" card from TransferPlus.
- Set card width to 50% of the upper row (`Width="360"` / `HorizontalAlignment="Left"`), preventing excessive empty spacing.
- Preserved high-performance filtering across view types (`All`, `Drafting`, `Legend`), sync status (`All`, `Up to Date`, `Modified`, `File Missing`), and live search term querying.

### 2.2. Configuration Window (`ConfigurationView.xaml`)
- **Header & Layout**: Modernized window dimensions (`Width="740"`, `Height="680"`) with card-based grouping.
- **Tab Option Card**:
  - `Place TablePlus on Add-Ins tab (default)`
  - `Place on Revit Manage tab (Manage Project)` (localized correctly for Spanish Revit: `Gestionar proyecto` under `Manage` / `Gestionar`)
  - `Place on tab named:` (Custom tab name textbox)
- **Contextual Right-Click Switch**:
  - Titled `"Create new linked table from right-click context menu"`.
  - Accompanied by a `(?)` help dialog explaining Revit 2025+ public API compatibility.
- **TablePlus Debug Log Toggle**:
  - `"Logs Window"` button toggling visibility of the `LogView` window across both Debug and Production modes.
- **Soft Green Header Banner**:
  - Distinctive green alert container (`#E8F5E9` background, `#C3E6CB` border, `#155724` text) explaining that external sources manage `.xlsx, .xlsm, .xls, .csv` files, can be created/edited/deleted, and that active sources populate the "Add Table" creation window.
- **Action Toolbar**:
  - Three vector buttons: `+` (Add Source), Pencil (Edit Source), Trashcan (Remove Source).
- **Sources DataGrid / ListView**:
  - Three columns: `Active` (Checkbox), `Name` (Text), `Source` (Path or remote description).
  - High-performance virtualization enabled with smooth scrolling.

### 2.3. Modal Dialogs for 4 External Source Types
- **Source Type Selector** (`TableSourceTypeWindow`):
  - Radio selection among Autodesk Docs, Azure Storage, AWS S3, and Directory.
- **Autodesk Docs (APS / Forma)** (`AutodeskDocsSourceWindow`):
  - 3-legged OAuth 2.0 PKCE sign-in with automated loopback listener on port 8989.
  - Interactive tree navigation of Hubs $\rightarrow$ Projects $\rightarrow$ Folders (`Project Files`).
- **Azure Storage** (`AzureStorageSourceWindow`):
  - Connection string / SAS URL input with live "Test Connection" button.
  - Container name and Root Path filtering.
- **AWS S3** (`AwsS3SourceWindow`):
  - S3 Bucket Name, AWS Region, Access Key, Secret Key.
  - Support for custom Endpoint URL (MinIO, Floci, LocalStack).
  - Live "Test Connection" button.
- **Directory Sources** (`DirectorySourceWindow`):
  - Native Windows folder picker with alias naming for local/network folders.

### 2.4. Integration with "Add Table" (`TableImportView.xaml`)
- In `TableImportView.xaml` (Card 1), added a `Source Location` dropdown.
- Dropdown is automatically populated with all configured sources whose `IsActive` property is `true`.
- Selecting a **Directory** source sets the default browse directory and lists compatible spreadsheets.
- Selecting a **Cloud** source (Autodesk Docs, Azure, AWS S3) allows browsing remote spreadsheet files and downloading them securely to `%TEMP%\TablePlus_Tables` before reading worksheets and vector geometry.

### 2.5. Security & Robustness Hardening
- **DPAPI Credential Encryption**: Implemented `SecurityUtils.EncryptString` and `DecryptString` utilizing `System.Security.Cryptography.ProtectedData` (Windows Data Protection API). No raw API keys, secrets, connection strings, or OAuth refresh tokens are stored in plain text.
- **Zero-Trust Cache Isolation**: `TableFileManager` validates absolute canonical paths via `Path.GetFullPath`, ensuring no file writes can escape `%TEMP%\TablePlus_Tables` (preventing Path Traversal attacks).
- **Enum Conflict Resolution**: Resolved naming conflict between `TableSourceType` (file formats: `.xlsx, .csv`) and `ExternalTableSourceType` (connection providers: `Directory, AzureStorage, AutodeskDocs, AwsS3`).

## 3. Verification & Build Results
All build configurations passed cleanly with 0 Errors and 0 Warnings:
- `dotnet build TablePlus.csproj -c "Debug.R25"`: **0 Warnings, 0 Errors**
- `dotnet build TablePlus.csproj -c "Release.R25"`: **0 Warnings, 0 Errors**
- `dotnet build TablePlus.csproj -c "Release.R24"`: **0 Warnings, 0 Errors**
- Binaries successfully deployed to `%APPDATA%\Autodesk\Revit\Addins\2025\`.
