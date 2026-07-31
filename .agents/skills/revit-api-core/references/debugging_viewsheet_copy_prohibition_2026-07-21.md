# Lessons Learned: ViewSheet Direct Copy Prohibition & Model View Replication

**Rule / Standard:** Never pass `ViewSheet` containing model views (`ViewPlan`, `ViewSection`, `ViewElevation`, `View3D`) directly to `ElementTransformUtils.CopyElements(...)`.

## 1. Exception Details
`ArgumentException`: `Las vistas de plano de este modelo no pueden contener más de un ejemplar de la misma vista. Parameter name: elementsToCopy`

## 2. Explanation
`ElementTransformUtils.CopyElements` attempts to copy placed viewports and their underlying views. Revit forbids duplicating model views via generic document copy because model views require level association, view family types, and unique naming.

## 3. Recommended Pattern
1. **Exclude `ViewSheet` from `CopyElements`**:
   ```csharp
   if (elem is ViewSheet)
   {
       sheetsToTransfer.Add(item);
   }
   ```
2. **Instantiate `ViewSheet` Programmatically**:
   ```csharp
   ViewSheet targetSheet = ViewSheet.Create(targetDoc, titleBlockTypeId);
   ```
3. **Copy TitleBlocks and 2D elements onto targetSheet**:
   ```csharp
   ElementTransformUtils.CopyElements(sourceSheet, sheetElementsToCopy, targetSheet, Transform.Identity, options);
   ```
4. **Replicate Model Views with Suffix if Duplicate**:
   ```csharp
   if (config.cf_rbAppendSuffix && srcPlacedView is ViewPlan srcPlan)
   {
       ViewPlan newPlan = ViewPlan.Create(targetDoc, vftId, levelId);
       newPlan.Name = srcPlan.Name + suffix;
       Viewport.Create(targetDoc, targetSheet.Id, newPlan.Id, centerPoint);
   }
   ```
