# Debugging Report: ViewSheet Unique Name Constraint & Append Suffix

**Date:** 2026-07-20
**Skill:** revit-api-core

## Symptom
When transferring a `ViewSheet` between models and encountering a duplicate name, selecting "Append Suffix" reported a successful transfer ("Transfer complete!") but failed to actually copy the sheet into the target document. The newly suffixed sheet simply didn't appear in the target model.

## Root Cause
The duplication logic temporarily copies elements to a `tempDoc` and modifies their `.Name` property to include the suffix. 
However, for `ViewSheet` elements, modifying the `.Name` property only changes the **Sheet Title**, but Revit's primary uniqueness constraint for sheets is based on the **`.SheetNumber`** property. Because the `SheetNumber` remained identical to the one in the target document, the final `ElementTransformUtils.CopyElements` from `tempDoc` to `targetDoc` silently failed to instantiate the duplicate sheet due to the collision.

## Solution
When applying a suffix to a `ViewSheet` during conflict resolution, explicitly append the suffix to the `SheetNumber` property in addition to the `.Name` property.

```csharp
// Inside the duplicate resolution loop (tempDoc)
if (tempElem is ViewSheet tempSheet)
{
    try
    {
        tempSheet.SheetNumber = $"{tempSheet.SheetNumber}{suffix}";
        // The .Name (Sheet Title) doesn't strictly need the suffix for uniqueness, 
        // but can be added for clarity:
        tempSheet.Name = $"{tempSheet.Name}{suffix}";
    }
    catch (Exception ex)
    {
        LoggerService.LogWarning($"Could not append suffix to SheetNumber: {ex.Message}");
    }
}
```
