# Walkthrough: Family Details UI Layout Optimization and Additional Metadata Properties

**Date:** 2026-08-19  
**Component:** `TransferPlus.Views.TransferPlusView`, `TransferPlus.Models.FamilyItemModel`, `TransferPlus.Services.Providers.*`  
**Status:** Validated and Deployed across Revit 2024-2027

---

## 1. Summary of Changes

1. **Equalization of UI Gaps in Family Details Card:**
   - Standardized the vertical spacing between property titles (bold label) and property values to be identical to the gap between consecutive property rows (`Margin="0,0,0,0"` uniform minimal spacing).
2. **New Metadata Properties Added:**
   - **File size (`File size`):** Displays formatted family file size in `KB` or `MB` (e.g. `245 KB`, `1.4 MB`, or `-` if in-memory without physical file).
   - **Last modified (`Last modified`):** Displays the last date the family or its source file was saved in standard format `yyyy-MM-dd` (e.g. `2024-05-12` or `-`).
3. **Data Providers Coverage:**
   - `LocalFolderFamilyProvider`: Extracts size and timestamp via `System.IO.FileInfo`.
   - `AzureStorageFamilyProvider`: Extracts size and timestamp from Azure Blob metadata (`ContentLength`, `LastModified`).
   - `AwsS3StorageFamilyProvider`: Extracts size and timestamp from S3 object metadata (`SizeBytes`, `LastModified`).
   - `AutodeskDocsFamilyProvider`: Extracts size and timestamp from ACC/BIM360 item attributes (`storageSize`, `lastModifiedTime`).
   - `OpenDocumentFamilyProvider` & `LinkedDocumentFamilyProvider`: Extracts document save date from source file on disk when available.

---

## 2. Modified Files

- [TransferPlus/Models/FamilyItemModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/FamilyItemModel.cs): Added `FileSizeBytes`, `LastModified`, `FileSizeFormatted`, and `LastModifiedFormatted`.
- [TransferPlus/Services/AutodeskDocsService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/AutodeskDocsService.cs): Added `LastModified` to `AccItemModel` and parsed `lastModifiedTime` from APS/ACC responses.
- [TransferPlus/Services/Providers/LocalFolderFamilyProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/LocalFolderFamilyProvider.cs)
- [TransferPlus/Services/Providers/AzureStorageFamilyProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/AzureStorageFamilyProvider.cs)
- [TransferPlus/Services/Providers/AwsS3StorageFamilyProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/AwsS3StorageFamilyProvider.cs)
- [TransferPlus/Services/Providers/AutodeskDocsFamilyProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/AutodeskDocsFamilyProvider.cs)
- [TransferPlus/Services/Providers/OpenDocumentFamilyProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/OpenDocumentFamilyProvider.cs)
- [TransferPlus/Services/Providers/LinkedDocumentFamilyProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/LinkedDocumentFamilyProvider.cs)
- [TransferPlus/ViewModels/TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs)
- [TransferPlus/Views/TransferPlusView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml)

---

## 3. Verification

- All Release builds (`Release.R24`, `Release.R25`, `Release.R26`, `Release.R27`) compiled with **0 errors**.
- Deployed locally to `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\`.
- Updated package: `TransferPlus/TransferPlusPublishPackage/TransferPlus.bundle.zip`.
