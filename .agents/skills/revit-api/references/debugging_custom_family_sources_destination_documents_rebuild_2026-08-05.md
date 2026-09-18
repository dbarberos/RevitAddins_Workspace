# Debugging Report: Missing Target Destination Models for Custom Family Sources

**Date:** 2026-08-05  
**Domain:** Revit API / Family Mode / Custom Family Sources / UI Destination Rebuild  
**Target Skill:** `revit-api`  

---

## 🔴 Symptom
When selecting a custom family source (such as a Local Directory, Azure Storage container, or Autodesk Docs / ACC cloud location) from the "Sources" dropdown in Family Mode, no destination models were rendered under the "Transfer to:" UI card.

---

## 🔍 Root Cause Analysis

In `TransferPlusViewModel.cs`:
1. Standard open Revit models have `source.Adoc != null`.
2. Custom family sources (Local Folders, Azure Storage, Autodesk Docs) have `source.Adoc == null`.
3. In `OnSelectedSourceDocumentChanged`, the code rebuilding `DestinationDocuments` was located inside the `if (value.Adoc != null)` branch.
4. When `value.Adoc == null` was selected, the `else` block executed `DestinationDocuments.Clear();` without populating open project documents in the session, leaving the "Transfer to:" UI card empty.

---

## 🟢 Resolution Pattern

Move the `DestinationDocuments` rebuild logic outside the `value.Adoc != null` branch so that it executes for **ALL** selected source types:

```csharp
partial void OnSelectedSourceDocumentChanged(Archivo? value)
{
    if (value != null)
    {
        if (value.Adoc != null)
        {
            if (IsFamiliesManagerActive)
            {
                _ = LoadFamiliesFromSourceAsync(value.Nombre);
            }
            else
            {
                LoadSourceItems(value.Adoc);
            }
        }
        else
        {
            if (IsFamiliesManagerActive)
            {
                _ = LoadFamiliesFromSourceAsync(value.Nombre);
            }
        }

        // Rebuild destination documents for ALL sources (open models and custom family sources):
        DestinationDocuments.Clear();
        foreach (Document doc in _app.Application.Documents)
        {
            if (doc.IsLinked || doc.IsFamilyDocument) continue;
            if (value.Adoc != null && doc.PathName.Equals(value.Adoc.PathName, StringComparison.OrdinalIgnoreCase)) continue;

            var dest = new Archivo(doc) { Checked = true };
            dest.Nombre = GetDocumentDisplayName(doc);
            dest.OnCheckedPropertyChanged = () => OnPropertyChanged(nameof(CheckedDestinationsText));
            DestinationDocuments.Add(dest);
        }
    }
}
```
