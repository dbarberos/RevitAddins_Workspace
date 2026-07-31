# Debugging Report: View-to-View Copy (Sheet Elements) Fails First Attempt

**Date:** 2026-07-20
**Skill:** revit-api-core

## Symptom
When copying a `ViewSheet` and its 2D elements (TitleBlocks, detail lines, annotations) from a source document to a target document, the new sheet is created in the target model but appears empty. The `TitleBlock` and other family instances fail to instantiate. 
However, if the user deletes the empty sheet and runs the exact same transfer a second time, the `TitleBlock` and details are successfully placed.

## Root Cause
The transfer logic used a two-step process:
1. `ElementTransformUtils.CopyElements(sourceDoc, sheetIds, targetDoc, ...)` to create the `ViewSheet` at the document level.
2. `ElementTransformUtils.CopyElements(sourceSheet, sheetElementsToCopy, targetSheet, ...)` to transfer 2D instances from view to view.

Revit's view-to-view copy operation struggles to instantiate elements if their Type (`FamilySymbol` or `ElementType`) does not already exist in the target document. In the first attempt, the view-to-view copy fails to instantiate the TitleBlock, but successfully *loads* the TitleBlock family into the target model's database as a side effect. On the second attempt, since the family is already present, the view-to-view copy successfully creates the instances.
Furthermore, the newly created `targetSheet` was not fully registered in the target database because `targetDoc.Regenerate()` was not called after step 1.

## Solution
1. **Regenerate the Document**: Always call `targetDoc.Regenerate()` immediately after creating new sheets/views before attempting to copy dependent elements into them.
2. **Pre-copy ElementTypes**: Before performing the view-to-view copy of instances, extract their `GetTypeId()` and copy those types at the document level (`sourceDoc` to `targetDoc`).

```csharp
// 1. Regenerate after creating the targetSheet
targetDoc.Regenerate();

// 2. Pre-copy Types (Symbols) of the sheet elements
var typeIdsToCopy = sheetElementsToCopy
    .Select(id => sourceDoc.GetElement(id)?.GetTypeId())
    .Where(typeId => typeId != null && typeId != ElementId.InvalidElementId)
    .Distinct()
    .ToList();

if (typeIdsToCopy.Any())
{
    ElementTransformUtils.CopyElements(sourceDoc, typeIdsToCopy, targetDoc, null, options);
    targetDoc.Regenerate(); // Regenerate to ensure Types are fully available
}

// 3. Now perform the view-to-view copy
ElementTransformUtils.CopyElements(sourceSheet, sheetElementsToCopy, targetSheet, Transform.Identity, options);
```
