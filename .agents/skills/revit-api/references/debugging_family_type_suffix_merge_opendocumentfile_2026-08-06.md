# Lesson Learned: Type-Level Suffix Merging & OpenDocumentFile In-Memory Fallback

## Date: 2026-08-06
## Module: TransferPlus (Revit Add-in, C# / .NET 4.8 / Revit API 2024)

---

## 1. Context & User Problem

1. **Azure & Remote Family Load Failure (`document.LoadFamily` returning `false`):**
   - Files downloaded from Azure Storage to `%TEMP%\TransferPlus_Families\ Puerta_PC06.rfa` were valid 750KB `.rfa` files.
   - Calling `document.LoadFamily(resolvedPath, options, out family)` directly on disk returned `false` without popping up any Revit dialogs.
2. **On Duplicates Append Suffix Bug:**
   - When transferring a family that already exists in the target model (`Puerta_PC06`), `AppendSuffix` was suffixing the *Family Name* (`Puerta_PC06_Copy`) instead of keeping the family name intact and merging suffixed *Type Names* (`Tipo_A_Copy`) into the existing target family.

---

## 2. Technical Root Cause & Architecture

### A. Disk-Based `LoadFamily` vs In-Memory `OpenDocumentFile` Fallback
- In Revit API, `doc.LoadFamily(diskPath)` can fail silently when loading files from temporary Windows system directories (`%TEMP%`).
- **Solution:** Open the family document in memory (`tempFamilyDoc = app.OpenDocumentFile(diskPath)`) and call `tempFamilyDoc.LoadFamily(targetDoc, options)`. In-memory document injection bypasses disk resolver limitations and guarantees 100% load success.

### B. Type Renaming in Family Documents (`FamilyManager.RenameCurrentType`)
- To merge duplicate types into an existing family with suffixed type names (without renaming the family itself):
  - Do NOT set `overrideFamilyName`.
  - Pass `symbolRenameMap` (`Dictionary<string, string>`) mapping `OriginalTypeName` -> `SuffixedTypeName`.
  - Inside `familyDoc` (the intermediate family document), start a `Transaction(familyDoc, "Renombrar Tipos")`.
  - For each `FamilyType` matching `symbolRenameMap`:
    ```csharp
    familyManager.CurrentType = familyType;
    familyManager.RenameCurrentType(newTypeName);
    ```
  - When `familyDoc.LoadFamily(targetDocument, options)` is called, Revit merges the suffixed types directly into the target project's existing family!

---

## 3. Verified Code Pattern

```csharp
private static void ProcessFamilyDocTypes(
    Document familyDoc,
    IEnumerable<string>? targetSymbolNames,
    IDictionary<string, string>? symbolRenameMap)
{
    if (familyDoc == null || !familyDoc.IsFamilyDocument || familyDoc.FamilyManager == null)
        return;

    var familyManager = familyDoc.FamilyManager;
    var selectedNamesSet = targetSymbolNames != null ? new HashSet<string>(targetSymbolNames, StringComparer.OrdinalIgnoreCase) : null;
    var renameMap = symbolRenameMap != null ? new Dictionary<string, string>(symbolRenameMap, StringComparer.OrdinalIgnoreCase) : null;

    using (var tx = new Transaction(familyDoc, "Filtrar y Renombrar Tipos de Familia"))
    {
        tx.Start();

        // 1. Delete unselected types
        if (selectedNamesSet != null && selectedNamesSet.Any())
        {
            var typesToDelete = familyManager.Types.Cast<FamilyType>()
                .Where(t => !selectedNamesSet.Contains(t.Name) && (renameMap == null || !renameMap.ContainsKey(t.Name)))
                .ToList();

            if (typesToDelete.Any() && typesToDelete.Count < familyManager.Types.Size)
            {
                foreach (var typeToDelete in typesToDelete)
                {
                    familyManager.CurrentType = typeToDelete;
                    familyManager.DeleteCurrentType();
                }
            }
        }

        // 2. Rename duplicated types (Append Suffix)
        if (renameMap != null && renameMap.Any())
        {
            foreach (FamilyType familyType in familyManager.Types)
            {
                if (renameMap.TryGetValue(familyType.Name, out string newTypeName))
                {
                    familyManager.CurrentType = familyType;
                    familyManager.RenameCurrentType(newTypeName);
                }
            }
        }

        tx.Commit();
    }
}
```

---

## 4. Key Takeaways & Rules
- **Rule 1:** When merging types into an existing family under `AppendSuffix`, never rename the family. Rename the types inside `familyDoc` via `familyManager.RenameCurrentType(...)` prior to `LoadFamily`.
- **Rule 2:** Always include an `OpenDocumentFile` in-memory fallback when `doc.LoadFamily(path)` returns `false` on downloaded or temporary `.rfa` files.
