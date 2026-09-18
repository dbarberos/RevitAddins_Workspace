# Debugging Report: In-Memory Family LoadFamily Transaction Conflict Exception

**Date:** 2026-08-05  
**Domain:** Revit API / Family EditFamily & LoadFamily / Transaction Scope  
**Target Skill:** `revit-api`  

---

## 🔴 Symptom
When transferring an in-memory family from an open or linked model via `Document.EditFamily` and `familyDoc.LoadFamily(targetDocument, overwriteOptions)`, Revit throws an `InvalidOperationException`:

`The document must not be modifiable before calling LoadFamily. Any open transaction must be closed prior the call.`

---

## 🔍 Root Cause Analysis

In the Revit API, calling `familyDoc.LoadFamily(targetDocument, overwriteOptions)` directly invokes internal C++ transaction managers on `targetDocument`.

If an outer `Transaction` is already active on `targetDocument` (`targetDocument.IsModifiable == true`), Revit strictly rejects the `LoadFamily` call to prevent transaction nesting corruption and throws:
`InvalidOperationException: The document must not be modifiable before calling LoadFamily.`

---

## 🟢 Resolution Pattern

DO NOT wrap `familyDoc.LoadFamily(targetDocument, ...)` in an active `Transaction` on `targetDocument`:

```csharp
public bool TryTransferInMemoryFamily(Document sourceDocument, Family sourceFamily, Document targetDocument, out Family? loadedFamily)
{
    loadedFamily = null;
    Document? familyDoc = null;

    try
    {
        // 1. Edit family in background memory
        familyDoc = sourceDocument.EditFamily(sourceFamily);
        if (familyDoc == null) return false;

        var overwriteOptions = new SilentOverwriteFamilyOption();

        // 2. Call LoadFamily WITHOUT an open transaction on targetDocument (Revit API requirement)
        loadedFamily = familyDoc.LoadFamily(targetDocument, overwriteOptions);
        if (loadedFamily != null)
        {
            return true;
        }

        // 3. Fallback lookup if family already existed in target document
        loadedFamily = new FilteredElementCollector(targetDocument)
            .OfClass(typeof(Family))
            .Cast<Family>()
            .FirstOrDefault(f => f.Name.Equals(sourceFamily.Name, StringComparison.OrdinalIgnoreCase));

        return loadedFamily != null;
    }
    finally
    {
        if (familyDoc != null && familyDoc.IsValidObject)
        {
            try { familyDoc.Close(false); } catch { }
        }
    }
}
```
