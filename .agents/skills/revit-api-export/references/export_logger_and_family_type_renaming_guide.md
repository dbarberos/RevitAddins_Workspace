# Technical Guide: Family Export Logging & Multi-Level (Family/Type) Renaming

This document details the architectural pattern for executing selective family downloads/exports in Revit add-ins, combining real-time status bar updates, detailed text report logging, and dual-level MVVM renaming (Family names and internal Type names).

---

## 1. Dual-Level MVVM Renaming Strategy (Family & Types)

When renaming families in Family Mode before export or model transfer:
- **Hierarchical Flat Collection (`RenamePreviewItem`)**: Both Family items (`FAM:FamilyName`) and Type items (`SYM:FamilyName::SymbolName`) are flattened into `ObservableCollection<RenamePreviewItem>`.
- **Item Identity**:
  - `IsType = false`, `ParentFamilyName = "Door"` for Family entries.
  - `IsType = true`, `ParentFamilyName = "Door"` for Type entries.
- **Lookup Maps**:
  - `familyRenameMap`: Maps `OriginalFamilyName` -> `NewFamilyName`. Used to rename output `.rfa` files (`NewName.rfa`) and override family loads.
  - `symbolRenameMap`: Maps `OriginalTypeName` -> `NewTypeName`. Passed to `familyDoc` processing.

### Type Renaming Inside Family Document Context (`FamilyManager`)
Inside an opened `familyDoc` (`OpenDocumentFile` or `SafeEditFamily`):
```csharp
if (symbolRenameMap != null && symbolRenameMap.Any())
{
    var existingTypesList = familyManager.Types.Cast<FamilyType>().ToList();
    foreach (FamilyType familyType in existingTypesList)
    {
        if (symbolRenameMap.TryGetValue(familyType.Name, out string? newTypeName) &&
            !string.IsNullOrWhiteSpace(newTypeName) &&
            !newTypeName.Equals(familyType.Name, StringComparison.OrdinalIgnoreCase))
        {
            try
            {
                familyManager.CurrentType = familyType;
                familyManager.RenameCurrentType(newTypeName);
            }
            catch (Exception ex)
            {
                // Handle duplicate type names or API constraints safely
            }
        }
    }
}
```

---

## 2. Export Logger Service & Text Reports

A dedicated `ExportLoggerService` formats a clean `.txt` execution summary after batch downloads/exports:

```csharp
public static class ExportLoggerService
{
    public static string WriteDownloadLog(
        string targetDirectory,
        string sourceDocName,
        int totalFamilies,
        int countSuccess,
        IEnumerable<ExportLogFamilyEntry> entries)
    {
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string filePath = Path.Combine(targetDirectory, $"TransferPlus_Download_Log_{timestamp}.txt");
        
        // Build structured Markdown-like text report with header, summary, and itemized entries
        // ...
        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        return filePath;
    }
}
```

---

## 3. Revit Status Bar Interop (`AdWindows.dll` Reflection)

To update the Revit UI Status Bar in real-time during synchronous/asynchronous batch loops without version locking:

```csharp
public static void SetRevitStatusBarText(string text)
{
    try
    {
        var componentManagerType = Type.GetType("Autodesk.Windows.ComponentManager, AdWindows");
        if (componentManagerType != null)
        {
            var prop = componentManagerType.GetProperty("StatusBarText", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            prop?.SetValue(null, text, null);
        }
    }
    catch { }
}
```
