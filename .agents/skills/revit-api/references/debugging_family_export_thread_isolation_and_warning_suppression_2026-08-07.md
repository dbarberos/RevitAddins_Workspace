# Technical Reference: Revit API Thread Isolation and Modal Warning Suppression in Selective Family Export

**Date:** 2026-08-07  
**Target Skill:** `revit-api`  
**Domain:** Family API / WPF Threading / Failures API & Dialog Suppression  

---

## 📌 Problem Overview

During batch export of selected `.rfa` family files from open or linked models to a local directory:
1. **Thread Violation Error (`Task.Run`):** Offloading family export operations (`doc.EditFamily`, `SaveAs`, `CopyElements`) to background `ThreadPool` worker threads (`await Task.Run(...)`) caused Revit API to throw native exceptions across all items: `A managed exception was thrown by Revit or by one of its external applications.`
2. **Modal Warning Interruption:** Modifying or deleting unselected family types in memory (`familyManager.DeleteCurrentType()`) triggered non-fatal Revit Warnings (such as *"El hueco no corta nada"* / *"Opening cuts nothing"*), raising modal native Revit dialog boxes that halted batch processing and required manual user clicks.

---

## 🛠️ Root Cause & Technical Findings

1. **Revit Single-Thread Guardrail:**  
   The Revit API is single-threaded. Native database operations (`EditFamily`, `SaveAs`, `OpenDocumentFile`, `CopyElements`) must execute strictly on the main Revit UI thread. Moving them to `Task.Run` violates thread affinity.
2. **Missing Failure & Dialog Handling Options:**  
   Transactions creating or deleting family geometry elements generate non-fatal `FailureSeverity.Warning` records. Without attaching `IFailuresPreprocessor` (`WarningSwallower`) and hooking into `UIApplication.DialogBoxShowing`, Revit halts execution to present modal confirmation UI.

---

## 💻 Resolution Architecture

### 1. Main Thread Execution with WPF Dispatcher Pump
Replace `Task.Run` wrappers with direct main-thread loops while pumping WPF background events to keep the UI progress bar responsive:

```csharp
for (int i = 0; i < total; i++)
{
    var (family, activeSymbols) = familiesToDownload[i];
    StatusMessage = $"Downloading family '{family.Name}' ({i + 1}/{total})...";
    ProgressPercentage = (int)((double)(i + 1) / total * 100);

    // Pump WPF UI events without offloading Revit API calls to background threads
    System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(
        System.Windows.Threading.DispatcherPriority.Background,
        new Action(() => { }));

    bool ok = _familyRevitService.ExportSelectiveFamilyToFolder(
        _app,
        SelectedSourceDocument.Adoc,
        family,
        selectedFolder,
        activeSymbols);

    if (ok) countSuccess++;
}
```

### 3. Azure/Cloud RFA Local Path Resolution
When downloading families from cloud sources (Azure Storage / ACC), `ImagePreviewUrl` may hold the blob name (e.g. `mile/modificados/Puerta_PC06.rfa`). Store the downloaded local cached file path in `ImagePreviewUrl` (`cachedFilePath`) and implement fallback resolution across `%TEMP%\TransferPlus_Families\`, `%TEMP%\TransferPlus_AzureCache\`, and `%TEMP%\TransferPlus_AccCache\` before calling `OpenDocumentFile`:

```csharp
// Caso 2: Origen desde archivo .rfa local o descargado (Azure / Local / ACC)
else if (!string.IsNullOrWhiteSpace(familyItem.ImagePreviewUrl))
{
    string rfaPath = familyItem.ImagePreviewUrl;
    if (!File.Exists(rfaPath))
    {
        string fileName = Path.GetFileName(rfaPath);
        string tempFamiliesPath = Path.Combine(Path.GetTempPath(), "TransferPlus_Families", fileName);
        string tempAzurePath = Path.Combine(Path.GetTempPath(), "TransferPlus_AzureCache", fileName);
        string tempAccPath = Path.Combine(Path.GetTempPath(), "TransferPlus_AccCache", fileName);

        if (File.Exists(tempFamiliesPath)) rfaPath = tempFamiliesPath;
        else if (File.Exists(tempAzurePath)) rfaPath = tempAzurePath;
        else if (File.Exists(tempAccPath)) rfaPath = tempAccPath;
    }

    if (File.Exists(rfaPath))
    {
        familyDoc = uiApp.Application.OpenDocumentFile(rfaPath);
    }
}
```

---

## ✅ Best Practices Checklist for Revit Family Export

- [x] **Never use `Task.Run` for Revit API calls:** Perform export loops on the main thread and update WPF UI via `Dispatcher.Invoke(DispatcherPriority.Background, ...)`.
- [x] **Attach `WarningSwallower`:** Always pass `IFailuresPreprocessor` to `Transaction.SetFailureHandlingOptions()` when deleting or creating types in `FamilyManager`.
- [x] **Hook `DialogBoxShowing`:** Override modal task dialogs during batch operations to return `TaskDialogResult.Ok` or `OverrideResult(1)`.
