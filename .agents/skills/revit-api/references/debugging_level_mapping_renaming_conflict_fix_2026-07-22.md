# Debugging Log: Avoid Temporarily Renaming Target Levels in Revit Document Copying

**Date:** 2026-07-22  
**Skill:** `revit-api`  
**API Surface:** `Level.Create`, `ViewPlan.Create`, `ElementTransformUtils.CopyElements`  

## 1. Symptom
Mapping a source level to an existing target level when creating plan views programmatically failed to bind to the selected target level, instead creating a new level with the source name and throwing Revit native "Tipos duplicados" dialogs.

## 2. Root Cause
The orchestrator attempted to temporarily rename existing target levels in `targetDoc` to match source level names prior to copy. This caused subsequent lookup routines (`targetLevels.FirstOrDefault(l => l.Name == targetLevelName)`) to return `null` because the level's name had been mutated. The resulting `null` triggered fallback routines that created new levels.

## 3. Solution Pattern
Never temporarily rename target document elements (especially structural elements like `Level` or `Grid`) to match source names. Keep element names intact and resolve target `ElementId` directly by matching string names:
```csharp
var matchedLevel = targetLevels.FirstOrDefault(l => l.Name.Equals(mappedTargetLevelName, StringComparison.OrdinalIgnoreCase));
if (matchedLevel != null)
{
    targetLevelId = matchedLevel.Id;
    ViewPlan newView = ViewPlan.Create(targetDoc, targetVft.Id, targetLevelId);
}
```
