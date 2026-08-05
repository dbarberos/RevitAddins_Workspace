# Debugging Report: Selective Family Symbol/Type Transfer via FamilyManager

**Date:** 2026-08-05  
**Domain:** Revit API / Family Mode / Selective Symbol Transfer / FamilyManager  
**Target Skill:** `revit-api`  

---

## 🔴 Symptom
When transferring an in-memory family from an open or linked model, attempting to filter unselected types by querying `FilteredElementCollector(familyDoc).OfClass(typeof(FamilySymbol))` returns 0 elements because inside a `.rfa` Family Editor document (`familyDoc`), types are NOT represented as placed `FamilySymbol` elements. Consequently, all types were being transferred into the destination model.

---

## 🔍 Root Cause Analysis

In Revit API:
1. In a Project Document (`.rvt`), family types are `FamilySymbol` elements queried via `FilteredElementCollector`.
2. In a **Family Document** (`.rfa` opened via `doc.EditFamily(family)`):
   - `familyDoc.IsFamilyDocument` is `true`.
   - Family types defined in the Family Editor belong to `familyDoc.FamilyManager.Types` (`FamilyTypeSet`).
   - Querying `OfClass(typeof(FamilySymbol))` inside a `.rfa` family document yields empty or unmanaged instance symbols.
   - Deleting a type from a family document requires iterating `familyDoc.FamilyManager.Types`, setting `familyDoc.FamilyManager.CurrentType = typeToDelete`, and calling `familyDoc.FamilyManager.DeleteCurrentType()` inside a transaction on `familyDoc`.

---

## 🟢 Resolution Pattern

### In-Memory Transfer (FamilyManager Filtering)
In `TryTransferInMemoryFamily`:

```csharp
if (familyDoc.IsFamilyDocument && familyDoc.FamilyManager != null && targetSymbolNames != null)
{
    var selectedNamesSet = new HashSet<string>(targetSymbolNames, StringComparer.OrdinalIgnoreCase);
    if (selectedNamesSet.Any())
    {
        var familyManager = familyDoc.FamilyManager;
        var typesToDelete = new List<FamilyType>();

        foreach (FamilyType familyType in familyManager.Types)
        {
            if (!selectedNamesSet.Contains(familyType.Name))
            {
                typesToDelete.Add(familyType);
            }
        }

        // Keep at least 1 type (Revit requirement)
        if (typesToDelete.Any() && typesToDelete.Count < familyManager.Types.Size)
        {
            TelemetryLogger.LogInfo($"Filtrando {typesToDelete.Count} tipo(s) no seleccionados en la familia en memoria mediante FamilyManager...");
            using (var tx = new Transaction(familyDoc, "Filtrar Tipos Seleccionados"))
            {
                tx.Start();
                foreach (var typeToDelete in typesToDelete)
                {
                    try
                    {
                        familyManager.CurrentType = typeToDelete;
                        familyManager.DeleteCurrentType();
                    }
                    catch (Exception delEx)
                    {
                        TelemetryLogger.LogWarning($"No se pudo eliminar el tipo '{typeToDelete.Name}': {delEx.Message}");
                    }
                }
                tx.Commit();
            }
        }
    }
}
```
