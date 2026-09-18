# Debugging Lesson: Cloud CAD Previews, Cache Management & File Extension Sanitization

## Problem / Symptom
When querying CAD drawings (.dwg, .dxf, .sat, .dgn, .skp) from cloud providers (Azure Blob, AWS S3, Autodesk Construction Cloud / Docs), UI thumbnails failed to render real in-memory geometry previews and displayed generic fallback icons.

## Root Cause
1. **Remote Cloud Paths**: Cloud providers return remote keys/blobs that do not exist on the local filesystem. Calling `File.Exists(filePath)` returned `false`, bypassing Revit's in-memory importer.
2. **File Extension Mutation**: Generic family file handlers appended `.rfa` unconditionally (`drawing.dwg` -> `drawing.dwg.rfa`), preventing Revit's CAD import options (`DWGImportOptions`, `SATImportOptions`, etc.) from recognizing the format.

## Solution Architecture
1. **Dedicated CAD Cache**: Store temporary CAD files in `%TEMP%\TransferPlus_CADCache` preserving their native extension (`.dwg`, `.dxf`, `.sat`, etc.) with strict Path Traversal validation (`Path.GetFullPath`).
2. **On-Demand Async Downloader (`EnsureLocalCadFileAsync`)**: Resolve cloud credentials and download blobs to disk only when requested for preview or transfer, reusing cached copies on subsequent requests.
3. **In-Memory Temporary View with RollBack**:
   - Create a temporary `ViewDrafting` in Revit active document.
   - Import CAD via `doc.Import(tempPath, options, tempView)`.
   - Call `doc.Regenerate()` and export to PNG (512x512) via `ImageExportOptions`.
   - Apply `OptimizeImageFraming` to remove white border margins.
   - Strictly call `tx.RollBack()` to keep the active document unmodified.
