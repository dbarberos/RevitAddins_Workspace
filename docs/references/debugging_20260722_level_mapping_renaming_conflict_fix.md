# Debugging Log: Level Mapping Target Level Renaming Conflict Fix

**Date:** 2026-07-22  
**Add-in:** TransferPlus  
**Component:** `TransferOrchestrator.cs`  

## 1. Problem Summary
When transferring level-based plan views with `Force Level in Level Base Views` enabled, mapping a source level (e.g. `P1 - EST - OFICINAS`) to an existing target level (e.g. `Nivel 8`) still resulted in TransferPlus creating a new level named `P1 - EST - OFICINAS`. Furthermore, Revit displayed a native warning dialog:
"Tipos duplicados: Los siguientes tipos ya existen pero son diferentes... Tipos de nivel : Niveles : Nivel : KRN_▼_Nivel A1".

## 2. Root Cause Analysis
1. **Target Level Renaming in Transaction**:
   Section 2.8.2 (`temporaryRenamedLevels`) of `TransferOrchestrator.cs` attempted to temporarily rename the existing target level `Nivel 8` to `P1 - EST - OFICINAS` inside a transaction `tRename` prior to view creation.
2. **Lookup Breakdown in `CreateViewPlan`**:
   Later, when `CreateViewPlan` executed to create the plan view for the sheet, it checked `levelMappings["P1 - EST - OFICINAS"]`, which contained `"Nivel 8"`.
   `CreateViewPlan` searched `targetDoc` levels for `l.Name.Equals("Nivel 8")`.
   Because `Nivel 8` had just been renamed to `"P1 - EST - OFICINAS"`, the lookup for `"Nivel 8"` returned `null`.
3. **Fallback Triggered New Level Creation**:
   Because the lookup returned `null`, `CreateViewPlan` executed its fallback block:
   ```csharp
   Level newLevel = Level.Create(targetDoc, srcLevel.ProjectElevation);
   newLevel.Name = GetUniqueLevelName(targetDoc, srcLevelName);
   ```
   This created a brand new level in `targetDoc` named `P1 - EST - OFICINAS`, triggering duplicate level type creation warnings and binding the view to the newly created level instead of `Nivel 8`.

## 3. Solution
1. **Removed `temporaryRenamedLevels` and Level Renaming Transactions**:
   Completely eliminated `temporaryRenamedLevels`, transaction `tRename`, and cleanup transaction `tRestore`. Levels in `targetDoc` are never temporarily renamed.
2. **Direct ElementId Binding in `CreateViewPlan`**:
   `CreateViewPlan` now searches for the target level by its unchanged name (`"Nivel 8"`). Finding `matchedLevel` directly, it assigns `targetLevelId = matchedLevel.Id` and passes it to `ViewPlan.Create(...)`.
3. **Prevented Duplicate Level Type Popups**:
   Eliminating temporary level renaming prevents Revit from attempting to import duplicate Level Types during copy operations.

## 4. Verification
- Compiled for `.NET Framework 4.8` (`Debug.R24`) with **0 Errors**.
- Overwrote `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll`.
