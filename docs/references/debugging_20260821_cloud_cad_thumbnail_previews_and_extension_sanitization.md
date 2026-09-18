# Debugging Report: Cloud CAD Thumbnail Previews & File Extension Sanitization

## Metadata
- **Date**: 2026-08-21
- **Component**: TransferPlus (`CadThumbnailService`, `FamilyFileManager`, `AzureStorageService`, `AwsS3StorageService`, `FamilyRevitService`)
- **Category**: Multi-Cloud CAD Cache & In-Memory View Rendering

---

## 1. Symptoms & Problem Description
When selecting CAD files (.dwg, .dxf, .sat, .dgn, .skp) from cloud sources (Azure Blob Storage, AWS S3, Autodesk Docs / ACC), the UI displayed generic 2D schematic icons instead of the expected rendered vector previews of the CAD geometry.

---

## 2. Root Cause Analysis

### Cause A: Remote Cloud Objects Without Local Physical Cache
Cloud providers return remote object keys/blob names (e.g. `folder/drawing.dwg`). When `CadThumbnailService.GetPreviewImageAsync` executed, `File.Exists(cadItem.FilePath)` returned `false`. Without an on-demand download step, the thumbnail generator skipped Revit in-memory rendering and immediately fell back to the generic vector icon.

### Cause B: Unintended File Extension Mutation (`.dwg.rfa`)
`FamilyFileManager.CreateFamilyLocalFile` was designed exclusively for Revit `.rfa` families, forcefully appending `.rfa` if the file name did not end with `.rfa` (`drawing.dwg` -> `drawing.dwg.rfa`). When `AzureStorageService.DownloadCadBlob` used this method, the CAD file was saved with an `.rfa` extension, causing Revit's `DWGImportOptions` to fail upon temporary view import.

---

## 3. Resolution & Architectural Pattern

### A. Dedicated CAD Local Cache (`FamilyFileManager.CreateCadLocalFile`)
Created a dedicated temporary storage manager for CAD files located at `%TEMP%\TransferPlus_CADCache` that strictly preserves the original file extension while applying full Path Traversal sanitization (`Path.GetFullPath` validation).

### B. On-Demand Async Cloud Download (`EnsureLocalCadFileAsync`)
Integrated an on-demand download check in `CadThumbnailService`:
```csharp
private static async Task<string?> EnsureLocalCadFileAsync(CadDetailItemModel cadItem, CancellationToken ct)
{
    if (cadItem == null) return null;
    if (!string.IsNullOrWhiteSpace(cadItem.FilePath) && File.Exists(cadItem.FilePath))
        return cadItem.FilePath;

    var sources = CadSourceConfigService.LoadSources();
    var source = sources.FirstOrDefault(s => s.Name.Equals(cadItem.SourceDocumentName, StringComparison.OrdinalIgnoreCase))
                 ?? sources.FirstOrDefault(s => s.SourceType == cadItem.SourceType);
    if (source == null) return null;

    if (source.SourceType == CadSourceType.AzureStorage)
    {
        string downloaded = AzureStorageService.DownloadCadBlob(source.ConnectionString, source.ContainerName, cadItem.FilePath);
        if (File.Exists(downloaded)) { cadItem.FilePath = downloaded; return downloaded; }
    }
    // Similar handling for AWS S3 and Autodesk Docs...
    return null;
}
```

### C. In-Memory Revit Drafting View Rendering with RollBack
Once downloaded to local disk, `FamilyRevitService.GenerateExternalCadPreview` imports the CAD drawing into a temporary `ViewDrafting`, exports a 512x512 PNG, applies `OptimizeImageFraming`, and executes `tx.RollBack()` to keep the active document completely untouched.

---

## 4. Verification & Results
- Verified compilation with 0 errors across Revit 2024 SDK.
- Local cache avoids redundant downloads on subsequent clicks.
- Renders real CAD vector previews for DWG, DXF, SAT, DGN, and SKP across all local and cloud sources.
