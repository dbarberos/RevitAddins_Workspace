# Debugging Log: Revit API Project Phase Element Copy Restriction

**Date:** 2026-07-22  
**Skill:** `revit-api`  
**API Surface:** `Autodesk.Revit.DB.Phase` / `ElementTransformUtils.CopyElements`  

## 1. Symptom
Passing an `ElementId` of a `Phase` (`Autodesk.Revit.DB.Phase`) to `ElementTransformUtils.CopyElements` throws an `ArgumentException`:
`Las fases de proyecto no se pueden copiar. Parameter name: elementsToCopy` (`Project phases cannot be copied. Parameter name: elementsToCopy`)

## 2. Root Cause
Autodesk Revit API explicitly forbids copying `Phase` elements between documents using `CopyElements`.

## 3. Recommended Solution Pattern
Filter out `Phase` elements before invoking `ElementTransformUtils.CopyElements`:

```csharp
if (elem is Phase || elem.Category?.Id.Value == (long)BuiltInCategory.OST_Phases)
{
    // Skip direct CopyElements to prevent API exception
    continue;
}
```
