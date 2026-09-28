# Implementation Plan — TablePlus Configuration Window & External Sources Settings

## 1. Overview & Objectives
This document records the architectural specification and implementation steps executed to integrate the Configuration and External Sources Settings in **TablePlus v1.2.0**, replicating the workflow, user experience, and design aesthetics from TransferPlus CAD & Details Sources Settings.

## 2. Requirements & Functional Scope
1. **Filter & Search Card Refinement**:
   - Replaced legacy Filter & Search Card in `MainWindowView.xaml` with the compact Filter card pattern from TransferPlus.
   - Constrained card width to half-row without unnecessary stretched white-space.
2. **Ribbon & Configuration Window (`ConfigurationView.xaml`)**:
   - Replaced old config window with the standard Config layout:
     - **Tab Option Card**: Add-Ins tab (default), Revit Manage tab (`Manage Project` / `Gestionar proyecto`), and Custom tab.
     - **Context Menu Toggle**: "Create new linked table from right-click context menu" with helper modal explaining Revit 2025+ API requirement.
     - **TablePlus Debug Log Toggle**: "Logs Window" button toggling visibility of the `LogView` window across both Debug and Production builds.
3. **External Table Sources Management**:
   - Situated directly beneath the context menu switch.
   - **Soft Green Header Banner**: Explains external source management for spreadsheet formats (`.xlsx, .xlsm, .xls, .csv`), editing/deletion capabilities, and active state visibility in the "Add Table" dialog.
   - **Action Toolbar**: `+` (Add Source), Pencil (Edit Source), Trashcan (Remove Source).
   - **Virtualized Sources List**: Displays `Active` (Checkbox), `Name` (Text), and `Source` (Path or remote description).
4. **Secondary Source Dialogs (Parity with TransferPlus)**:
   - **Autodesk Docs (APS / Forma)**: 3-legged OAuth 2.0 PKCE with local loopback listener (port 8989), Hubs $\rightarrow$ Projects $\rightarrow$ Folders tree navigation.
   - **Azure Storage**: Connection String/SAS, container selection, path prefix, live connection test.
   - **AWS S3**: S3 Bucket, Region, credentials, custom endpoint URL support (MinIO, Floci), live connection test.
   - **Directory**: Folder browser for favorite local and network directories.
5. **Add Table Integration (`TableImportView.xaml` & `TableImportViewModel.cs`)**:
   - Source Location dropdown listing active configured sources.
   - For Directory sources: sets folder browser initial path and lists compatible spreadsheets.
   - For Cloud sources: lists remote spreadsheet blobs and safely downloads them to isolated temporary cache `%TEMP%\TablePlus_Tables` before vector parsing.
6. **Security & Resilience**:
   - Windows DPAPI encryption (`ProtectedData`) for secrets, tokens, and connection strings in `table_sources.json`.
   - Zero-Trust file access preventing Path Traversal via `Path.GetFullPath` validation.
   - Dual-framework compilation (.NET Framework 4.8 and .NET 8.0) with zero errors and zero warnings.

## 3. Architecture & Class Diagram
```
TablePlus
├── Application.cs                 # Ribbon placement & context menu listener
├── Commands/
│   ├── CmdImportTable.cs          # Dashboard launcher
│   └── TableContextMenuCreator.cs # Revit 2025+ canvas context menu
├── Models/
│   ├── TablePlusSettings.cs       # Tab options and contextual toggle
│   ├── TableSourceItemModel.cs    # Encrypted external source configuration
│   └── TableEnums.cs              # Document formats vs ExternalTableSourceType
├── Services/
│   ├── SettingsService.cs         # Settings persistence (DPAPI)
│   ├── TableSourceConfigService.cs# Sources JSON persistence (DPAPI)
│   ├── TableFileManager.cs        # Safe cache manager & path traversal guard
│   ├── AutodeskDocsService.cs     # OAuth PKCE & ACC Hub/Project/Folder API
│   ├── AzureStorageService.cs     # Azure Blob container operations
│   ├── AwsS3StorageService.cs     # S3 bucket operations
│   └── TelemetryLogger.cs         # PII-scrubbed logger
├── ViewModels/
│   ├── ConfigurationViewModel.cs  # Tab options, switches, and sources management
│   ├── TableSourceTypeViewModel.cs# Source type selection modal
│   ├── DirectorySourceViewModel.cs# Directory configuration modal
│   ├── AzureStorageSourceViewModel.cs
│   ├── AwsS3SourceViewModel.cs
│   ├── AutodeskDocsSourceViewModel.cs
│   └── TableImportViewModel.cs    # "Add Table" viewmodel with cloud sources
└── Views/
    ├── ConfigurationView.xaml
    ├── TableSourceTypeWindow.xaml
    ├── DirectorySourceWindow.xaml
    ├── AzureStorageSourceWindow.xaml
    ├── AwsS3SourceWindow.xaml
    ├── AutodeskDocsSourceWindow.xaml
    └── TableImportView.xaml
```

## 4. Verification & Validation Plan
- [x] Multi-configuration compilation: `Debug.R25`, `Release.R25`, `Release.R24`.
- [x] Nullable reference type audit: 0 warnings.
- [x] Validation of DPAPI encryption for secrets.
- [x] Verification of temporary cache isolation.
