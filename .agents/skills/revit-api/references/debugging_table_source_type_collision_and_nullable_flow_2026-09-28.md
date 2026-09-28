# Debugging: Type Collision on Source Enums & Multi-Target Nullable Flow Analysis

## Problem Summary
During the integration of external cloud and directory sources (Autodesk Docs, Azure Storage, AWS S3, and Directory) into `TablePlus`:
1. **Ambiguous Symbol Conflict**: `TablePlus.Models.TableEnums.cs` already defined `public enum TableSourceType { ExcelXlsx, ExcelXlsm, Csv, PdfDocument, WordDocument, ScheduleView }` to categorize spreadsheet and document extensions. When porting source provider classes and viewmodels from `TransferPlus`, introducing a second `TableSourceType` caused compiler errors CS0104 and CS0260 (ambiguous reference between the format enum and the provider enum).
2. **Nullable Reference Warnings in .NET Framework 4.8 (CS8604 / CS8601)**: While compiling cleanly in .NET 8, `.NET Framework 4.8` emitted 12 warnings because `string.IsNullOrWhiteSpace(...)` in older reference assemblies does not feature the `[NotNullWhen(false)]` attribute, causing the Roslyn compiler to flag subsequent method parameters as possible null references.

## Root Cause Analysis
- **Enum Namespace Overlap**: Within the same namespace `TablePlus.Models`, two concepts shared the identical name `TableSourceType`: the physical document file format vs. the external storage connection provider.
- **Contract Attribute Discrepancy**: Flow analysis in .NET 8 benefits from nullable contract attributes in CoreCLR. When compiling against `net48`, Roslyn requires explicit null assertions (`!`) or explicit check-throw guards to prove that a string tested with `string.IsNullOrWhiteSpace` is non-null.

## Resolution

### 1. Distinct Naming for External Storage Providers
Renamed the external source provider enum to `ExternalTableSourceType`:
```csharp
namespace TablePlus.Models;

public enum ExternalTableSourceType
{
    Directory,
    AzureStorage,
    AutodeskDocs,
    AwsS3
}
```
All cloud service classes, settings persistence services, and viewmodels (`TableSourceTypeViewModel`, `DirectorySourceViewModel`, `AzureStorageSourceViewModel`, `AwsS3SourceViewModel`, `AutodeskDocsSourceViewModel`, `ConfigurationViewModel`, `TableImportViewModel`) were updated to reference `ExternalTableSourceType`, leaving `TableSourceType` exclusively for tabular file formats.

### 2. Multi-Framework Nullable Flow Discipline
Added the null-forgiving operator (`!`) immediately after `string.IsNullOrWhiteSpace` validation blocks when passing strings to non-nullable parameters in shared code:
```csharp
string? code = await AutodeskDocsService.CaptureOAuthCodeViaLoopbackAsync(8989);
if (string.IsNullOrWhiteSpace(code))
{
    StatusMessage = "Sign-in was cancelled or timed out.";
    return;
}

// Satisfies both .NET 8 and .NET Framework 4.8 compilers cleanly
var tokenResult = await AutodeskDocsService.ExchangeCodeForTokensAsync(
    code!,
    codeVerifier,
    effectiveClientId,
    AutodeskDocsService.DefaultRedirectUri);
```

## Outcome
- Zero compilation errors.
- Zero warnings across `Debug.R25`, `Release.R25`, and `Release.R24`.
