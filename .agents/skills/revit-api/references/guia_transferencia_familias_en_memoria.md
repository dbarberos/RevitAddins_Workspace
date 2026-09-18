# Technical Guide: In-Memory Family Transfer Between Revit Documents

**Date:** 2026-08-03  
**Target Skill:** `revit-api`  

## 🎯 Overview
When transferring Revit Families (`Family`) between open documents in session or loaded links (`RevitLinkInstance`), do **NOT** use `ElementTransformUtils.CopyElements` or temporary disk export unless strictly required.

The official, safest, and most performant Revit API method is **In-Memory Family Editing and Loading** using `Document.EditFamily()` and `familyDoc.LoadFamily()`.

---

## ❌ Why Avoid `ElementTransformUtils.CopyElements` for Families
1. `CopyElements` is designed for placing physical instances in model views.
2. Transferring `Family` symbols directly across documents with `CopyElements` often throws `Autodesk.Revit.Exceptions.ArgumentException`.
3. It frequently generates suffixed duplicate family types (`FamilyName.0001` or `CopyOf_`), corrupting BIM standard naming.

---

## ✅ Best Practice: In-Memory Transfer Pattern

```csharp
public bool TryTransferInMemoryFamily(Document sourceDoc, Family sourceFamily, Document targetDoc)
{
    if (sourceDoc == null || sourceFamily == null || targetDoc == null) return false;

    Document? familyDoc = null;
    try
    {
        // 1. Open family in memory (creates no GUI window)
        familyDoc = sourceDoc.EditFamily(sourceFamily);
        if (familyDoc == null) return false;

        // 2. Configure silent overwrite options
        var overwriteOptions = new SilentOverwriteFamilyOption();

        // 3. Start transaction in target document
        using var transaction = new Transaction(targetDoc, $"Load Family '{sourceFamily.Name}'");
        WarningSwallower.AttachToTransaction(transaction);
        transaction.Start();

        // 4. Load family in memory into target document
        Family loadedFamily = familyDoc.LoadFamily(targetDoc, overwriteOptions);
        if (loadedFamily != null)
        {
            transaction.Commit();
            return true;
        }

        transaction.RollBack();
        return false;
    }
    catch (Exception ex)
    {
        TelemetryLogger.LogError($"Error transferring family '{sourceFamily?.Name}' in memory", ex);
        return false;
    }
    finally
    {
        // 5. Always close in-memory family document
        familyDoc?.Close(false);
    }
}
```

---

## 🔒 Key Benefits
- **Zero Disk Overhead**: Fast in-memory execution without temporary file I/O delays or permission issues.
- **Type Integrity**: Preserves nested parameters, formulas, and type definitions without generating `CopyOf_` duplicate types.
- **Transaction Safety**: Wrapped in Revit transactions with `WarningSwallower` to suppress non-fatal modal warnings.
