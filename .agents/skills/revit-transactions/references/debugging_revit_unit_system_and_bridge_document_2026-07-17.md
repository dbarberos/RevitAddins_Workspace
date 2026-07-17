# Lesson Learned: Revit Copying Duplicates, Unit System Mismatch, and the Bridge Document Strategy

## Context
When copying elements (especially `ElementType`s) between documents, Revit API's `ElementTransformUtils.CopyElements` doesn't natively allow renaming colliding names on-the-fly. It only supports either merging (using existing types) or aborting the copying process via `IDuplicateTypeNamesHandler`. Furthermore, if the source model is a **Linked Model (RevitLinkInstance)**, it is strictly read-only, meaning developers cannot open a transaction on the source to temporarily rename elements before copying.

---

## Technical Challenges & Resolutions

### 1. Revit Unit System Mismatch
*   **Symptom:** The compilation fails with `error CS1503: Argument 1: cannot convert from 'Autodesk.Revit.DB.DisplayUnit' to 'Autodesk.Revit.DB.UnitSystem'` when trying to create a project document using `targetDoc.DisplayUnitSystem`.
*   **Root Cause:** `Document.DisplayUnitSystem` returns `Autodesk.Revit.DB.DisplayUnit` (an enum with values `METRIC`, `IMPERIAL`), whereas `Application.NewProjectDocument(UnitSystem)` expects the `Autodesk.Revit.DB.UnitSystem` enum (which has values `Metric`, `Imperial`).
*   **Solution:** Convert the `DisplayUnit` value to the correct `UnitSystem` enum value before calling `NewProjectDocument`:
    ```csharp
    UnitSystem unitSys = targetDoc.DisplayUnitSystem == DisplayUnit.IMPERIAL 
        ? UnitSystem.Imperial 
        : UnitSystem.Metric;
    Document tempDoc = targetDoc.Application.NewProjectDocument(unitSys);
    ```

### 2. The Bridge Document (Temp Doc) Strategy
To copy elements and apply a rename suffix without modifying the read-only source document or altering the target document's existing types:
1.  Create an empty temporary document in memory matching the target's unit system.
2.  Open a temporary `Transaction` on this temp document and copy the elements into it.
3.  Rename the copied elements inside the temp document by appending the suffix.
4.  Commit the temp transaction.
5.  Perform the final `CopyElements` from the temp document to the target document.
6.  Close the temp document without saving:
    ```csharp
    Document tempDoc = null;
    try
    {
        // 1. Create temp doc
        UnitSystem unitSys = targetDoc.DisplayUnitSystem == DisplayUnit.IMPERIAL ? UnitSystem.Imperial : UnitSystem.Metric;
        tempDoc = targetDoc.Application.NewProjectDocument(unitSys);

        // 2. Copy and rename in temp doc
        ICollection<ElementId> tempCopied;
        using (Transaction tTemp = new Transaction(tempDoc, "Temp Copy"))
        {
            tTemp.Start();
            tempCopied = ElementTransformUtils.CopyElements(sourceDoc, elementsCopyList, tempDoc, null, new CopyPasteOptions());
            
            var tempCopiedList = tempCopied.ToList();
            for (int i = 0; i < elementsCopyList.Count; i++)
            {
                ElementId tempId = tempCopiedList[i];
                Element tempElem = tempDoc.GetElement(tempId);
                if (tempElem != null && TargetHasDuplicateName(targetDoc, tempElem))
                {
                    tempElem.Name = tempElem.Name + suffixText;
                }
            }
            tTemp.Commit();
        }

        // 3. Final copy to target doc
        ICollection<ElementId> finalCopied = ElementTransformUtils.CopyElements(tempDoc, tempCopied.ToList(), targetDoc, transform, options);
    }
    finally
    {
        if (tempDoc != null)
        {
            tempDoc.Close(false);
        }
    }
    ```
