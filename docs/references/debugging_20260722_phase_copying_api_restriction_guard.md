# Debugging Log: Revit API Phase Element Copying Restriction

**Date:** 2026-07-22  
**Add-in:** TransferPlus  
**Component:** `TransferOrchestrator.cs`, `DocumentCollector.cs`  

## 1. Problem Summary
- Log line: `[12:18:59.673] ERROR in Transfer Elements: Las fases de proyecto no se pueden copiar. Parameter name: elementsToCopy`
- Selecting a `Phase` element (Category: `Fases` / `OST_Phases`) in the TreeView and transferring it caused Revit API `ElementTransformUtils.CopyElements` to throw an exception and roll back the transfer transaction.

## 2. Root Cause Analysis
- In Autodesk Revit API, `Phase` (`Autodesk.Revit.DB.Phase`) represents a project-level timeline phase.
- The Revit API explicitly prohibits copying `Phase` elements between documents using `ElementTransformUtils.CopyElements` and throws an `ArgumentException` (`"Project phases cannot be copied"` / `"Las fases de proyecto no se pueden copiar"`).

## 3. Solution Implementation
1. **TransferOrchestrator Protection Guard**:
   ```csharp
   if (elem is Phase || (elem != null && elem.Category != null && elem.Category.Id.Value == (long)BuiltInCategory.OST_Phases))
   {
       LoggerService.LogWarning($"Transfer: Element '{item.Nombre}' (Category: Fases, Id: {item.eID.Value}) is a Project Phase. Revit API restricts direct Phase copying between documents. Skipping.");
       continue;
   }
   ```
2. **DocumentCollector Tree UI Notice**:
   - Set `item6.NoTransferible = true;` on phase elements so the TreeView indicates the API restriction.

## 4. Verification
- Compiled with 0 errors (`Debug.R24`).
