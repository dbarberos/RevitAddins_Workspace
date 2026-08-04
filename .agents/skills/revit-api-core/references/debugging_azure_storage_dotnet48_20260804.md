# Debugging Log: Azure SDK MissingMethodException (IAsyncEnumerator) on .NET Framework 4.8

**Date**: 2026-08-04  
**Skill Target**: `revit-api-core` / `security-engineer`  
**Components**: `AzureStorageService.cs`

---

## 1. Symptom

Selecting Azure Storage / Azurite containers in Revit 2024 (.NET Framework 4.8) threw a runtime exception:
`MissingMethodException: Method not found: 'System.Collections.Generic.IAsyncEnumerator`1<!0> Azure.AsyncPageable`1.GetAsyncEnumerator(System.Threading.CancellationToken)'`

---

## 2. Root Cause

- In .NET Framework 4.8, `Azure.Storage.Blobs` `AsyncPageable<T>` relies on `IAsyncEnumerable<T>` interface bindings.
- Executing `await foreach` over `containerClient.GetBlobsAsync()` in a .NET Framework 4.8 add-in process causes runtime assembly resolution crashes because `System.Threading.Tasks.Extensions` or `Microsoft.Bcl.AsyncInterfaces` bindings differ between host Revit and Azure SDK binaries.

---

## 3. Solution

Replace `await foreach` over `GetBlobsAsync()` with synchronous pageable iteration (`GetBlobs()`) wrapped inside `Task.Run()`:

```csharp
// Before (Crashed under .NET Framework 4.8):
// await foreach (BlobItem blobItem in containerClient.GetBlobsAsync(cancellationToken: cancellationToken)) { ... }

// After (100% compatible with .NET 4.8 and .NET 8, executes asynchronously off UI thread):
List<FamilyItemModel> families = await Task.Run(() =>
{
    var list = new List<FamilyItemModel>();
    foreach (BlobItem blobItem in containerClient.GetBlobs(cancellationToken: cancellationToken))
    {
        if (blobItem.Name.EndsWith(".rfa", StringComparison.OrdinalIgnoreCase))
        {
            // Process blob item
        }
    }
    return list;
}, cancellationToken);
```
