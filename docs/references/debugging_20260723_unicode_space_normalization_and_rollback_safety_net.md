# Debugging Log: Unicode Space Normalization & View Creation Rollback Safety Net

**Date:** 2026-07-23  
**Add-in:** TransferPlus  
**Component:** `TransferOrchestrator.cs` (`NormalizeName`, `FindExistingViewByName`, `CreateViewPlan`)  

## 1. Problem Summary
Even with `Keep Original` active, transferring an existing view plan repeatedly generated duplicate view plan elements with incrementing numeric suffixes (`P1 - EST - OFICINAS_Nivel Oficinas1`, `P1 - EST - OFICINAS_Nivel Oficinas2`).

## 2. Root Cause Analysis
1. **Non-Breaking Space (`\u00A0`) Discrepancy**:
   - In Spanish/European Revit models and family names, view and level names often contain non-breaking spaces (`\u00A0`, Unicode 160) instead of ASCII space (`\u0020`, Unicode 32).
   - `.Equals(..., StringComparison.OrdinalIgnoreCase)` treats `\u00A0` and `\u0020` as different characters. Thus, `FilteredElementCollector` returned `null` when checking for existing views.
2. **Fallback Suffix Generation in `CreateViewPlan`**:
   - When `FilteredElementCollector` returned `null`, `CreateViewPlan` executed `ViewPlan.Create(targetDoc, ...)`.
   - When attempting `targetViewPlan.Name = srcViewPlan.Name`, Revit's internal engine (which normalizes spaces) detected the duplicate name collision and threw an exception.
   - The `catch` block caught the exception and generated a unique suffixed name (`...1`, `...2`).

## 3. Solution Implementation
1. **Name Normalization (`NormalizeName`)**:
   - Created `NormalizeName(string text)` which converts non-breaking spaces (`\u00A0`) to standard spaces (`' '`) and trims whitespace.
2. **Unified Search Helper (`FindExistingViewByName`)**:
   - Implemented `FindExistingViewByName` using `NormalizeName` for view matching across all lookup sites in `TransferOrchestrator.cs`.
3. **Rollback Safety Net in `CreateViewPlan`**:
   - If direct name assignment fails due to a name collision, `CreateViewPlan` invokes `FindExistingViewByName`.
   - If an existing view is found (or if `Keep Original` is active), it **deletes the newly created temporary view (`targetDoc.Delete(targetViewPlan.Id)`)** and returns the existing view, completely preventing duplicate suffixed views.

## 4. Verification
- Compiled for `.NET Framework 4.8` (`Debug.R24`) with **0 Errors**.
