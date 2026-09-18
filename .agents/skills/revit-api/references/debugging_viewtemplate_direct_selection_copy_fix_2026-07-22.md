# Debugging Log: Revit API ViewTemplate Direct Selection Copy Pattern

**Date:** 2026-07-22  
**Skill:** `revit-api`  
**API Surface:** `Autodesk.Revit.DB.View.IsTemplate`  

## 1. Symptom & Problem
When selecting a View Template (`View` with `v.IsTemplate == true`) in an add-in element tree to transfer it between documents, the template is classified as a model view and excluded from `ElementTransformUtils.CopyElements`, causing the transfer operation to complete without creating or copying the View Template into the target document.

## 2. Root Cause
View Templates are instances of `Autodesk.Revit.DB.View` with `IsTemplate = true`. Standard plan views cannot be copied directly via `ElementTransformUtils.CopyElements`, but **View Templates CAN and SHOULD be copied directly via `ElementTransformUtils.CopyElements`**.

## 3. Recommended Solution Pattern
Check `v.IsTemplate` when categorizing views for `CopyElements`:

```csharp
if (elem is View v)
{
    if (v.IsTemplate || v.ViewType == ViewType.DraftingView || v.ViewType == ViewType.Legend)
    {
        // Queue for direct ElementTransformUtils.CopyElements batch
        elementsCopyList.Add(v.Id);
    }
}
```

This guarantees:
1. Selected View Templates are included in the batch copy.
2. Filters, graphics overrides, and category visibilities defined on the template are preserved in the target model.
