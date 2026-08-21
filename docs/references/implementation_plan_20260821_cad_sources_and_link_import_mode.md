# Implementation Plan - CAD Details Manager Sources & Multi-Cloud CAD Integration

## 1. Goal Description
Extend the **CAD Details Manager** card in TransferPlus to support managing multi-cloud and local CAD sources (reproducing the architecture and UX of *Families Manager*), adding support for all 9 Revit-compatible CAD formats (`.dwg`, `.dxf`, `.axm`, `.sat`, `.dgn`, `.obj`, `.3dm`, `.skp`, `.stl`), and adding a contextual transfer mode selector (**Import CAD** vs **Link CAD**) under the ORGANIZE column in the *Select Details/CAD* card.

---

## 2. Key Architecture & Decisions

1. **Storage Isolation**:
   - Stored in `%APPDATA%\TransferPlus\cad_sources.json` with DPAPI encryption (`SecurityUtils.EncryptString` / `DecryptString`).
2. **Transfer Strategy**:
   - For external CAD files from local folder, Autodesk Docs, AWS S3, or Azure Blob, TransferPlus automatically creates a dedicated `ViewDrafting` named `CAD - [FileName]` at scale 1:1, centered at origin `XYZ.Zero`.
3. **Import vs Link Mode Rules**:
   - **`Link CAD` Enabled**: ONLY when source is a **Local Directory** (`Directory`) or **Autodesk Docs** (`AutodeskDocs`).
   - **`Link CAD` Disabled / Forced `Import CAD`**: When source is **AWS S3**, **Azure Storage**, an **Open Revit Model**, or a **Linked Revit Model**.

---

## 3. Implemented Components

- **Models**: `CadSourceItemModel.cs`, `CadDetailItemModel.cs` (extended with `IsExternalFile`, `Format`, `FilePath`), `Archivo.cs` (extended with `EsCadSource`, `CadSourceType`).
- **Services**: `CadSourceConfigService.cs`, `AzureStorageService.cs` (CAD methods), `AwsS3StorageService.cs` (CAD methods), `AutodeskDocsService.cs` (CAD methods), `FamilyRevitService.cs` (`TransferExternalCadToDraftingView`).
- **Providers**: `ICadProvider.cs`, `LocalFolderCadProvider.cs`, `AzureStorageCadProvider.cs`, `AwsS3StorageCadProvider.cs`, `AutodeskDocsCadProvider.cs`, `OpenDocumentCadProvider.cs`, `LinkedDocumentCadProvider.cs`, `CadProviderFactory.cs`.
- **ViewModels**: `CadSourcesViewModel.cs`, `CadSourceTypeViewModel.cs`, `TransferPlusViewModel.cs` (orchestration, commands, properties).
- **Views**: `CadSourcesWindow.xaml` (+ code-behind), `CadSourceTypeWindow.xaml` (+ code-behind), `TransferPlusView.xaml` (Sources button & Import/Link radio buttons).
