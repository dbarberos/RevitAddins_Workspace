# Debugging Log: Revit API View Elements Batch Copy Fallback & Option Precedence

**Date:** 2026-07-22  
**Skill:** `revit-api`  
**API Surface:** `Autodesk.Revit.DB.ElementTransformUtils`  

## 1. Symptom & Problem
1. **Batch Copy Failure on View-Specific Elements**:
   When copying dependent 2D elements from a source view to a target view (e.g. into an empty model), `ElementTransformUtils.CopyElements` fails if any single element in the collection is an unhosted 3D tag (e.g., Door Tag or Wall Tag whose 3D element does not exist in the target model).
   Because `CopyElements` is transactional for the batch, valid 2D elements (detail lines, text notes, dimensions) are also rejected.

2. **Option Collision in Add-in UI**:
   User options like "Use Legend if Exist" or "Use Schedule if Exist" were overridden when duplicate rules like "Append Suffix" were set, creating unwanted suffix duplicates.

## 2. Recommended Solution Patterns

### A. Element-by-Element Fallback Pattern for View-Specific Annotations
When copying view-dependent elements, perform a batch copy first. If it fails, fallback to element-by-element copy to preserve non-hosted 2D lines and text:

```csharp
public static void CopyViewSpecificElements(View sourceView, ICollection<ElementId> elementIds, View targetView, CopyPasteOptions options)
{
    if (elementIds == null || !elementIds.Any()) return;

    try
    {
        // 1. Try fast batch copy first
        ElementTransformUtils.CopyElements(sourceView, elementIds, targetView, Transform.Identity, options);
    }
    catch
    {
        // 2. Fallback to single-item copying to preserve valid 2D annotations (lines, text, dimensions)
        foreach (ElementId id in elementIds)
        {
            try
            {
                ElementTransformUtils.CopyElements(sourceView, new List<ElementId> { id }, targetView, Transform.Identity, options);
            }
            catch
            {
                // Ignore unhosted tags or invalid elements silently
            }
        }
    }
}
```

### B. Strict Precedence for Specific Element Reuse Options
Specific reuse options (e.g., `UseLegendIfExists`, `UseScheduleIfExists`) must always take absolute precedence over global naming collision rules (`AppendSuffix`):

```csharp
bool useExisting = (isLegend && config.UseLegendIfExists) || (isSchedule && config.UseScheduleIfExists);

if (useExisting && existingTargetView != null)
{
    // Always reuse existing target view, ignoring suffix rules
    shouldCopyView = false;
    targetViewId = existingTargetView.Id;
}
else if (config.AppendSuffix && existingTargetView != null)
{
    // Apply suffix rule only when specific reuse option is disabled
    shouldCopyView = true;
}
```
