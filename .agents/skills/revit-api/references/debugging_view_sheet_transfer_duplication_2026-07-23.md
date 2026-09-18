# Debugging Log: Cross-Document View & Sheet Transfer Duplication Prevention

**Date:** 2026-07-23  
**Domain:** `revit-api` (SKILL_09: Views, Sheets, Viewports and ViewTemplates)  
**Language:** English (SkillOpt Standard)  

---

## 1. Problem Description & Symptoms
During batch transfer of sheets (`ViewSheet`), plan views (`ViewPlan`), and worksets (`Workset`) between open Revit documents:
1. **Unwanted Suffix Duplication**: Transferring existing views generated duplicate view plan elements with incrementing numeric suffixes (`P1 - EST - OFICINAS 1`, `P1 - EST - OFICINAS 2`) even when the user selected **"Keep Original"** or **"Append Suffix"**.
2. **Property Discrepancy Between Duplicate Views**: The first created view lacked graphics/2D properties, whereas the second suffixed view accumulated all transferred properties.
3. **Silent Failure on Non-Workshared Workset Transfers**: Transferring Worksets to a non-workshared destination model displayed a success dialog despite failing to create Worksets.

---

## 2. Root Cause Analysis

### Root Cause 1: Subtle Character & Whitespace Normalization Mismatches
- In European and translated Revit models, view names contain non-breaking spaces (`\u00A0`), en-dashes (`\u2013`), em-dashes (`\u2014`), or zero-width spaces (`\u200B`).
- Standard C# string comparison (`.Equals(..., StringComparison.OrdinalIgnoreCase)`) evaluates these unicode variations as non-matching strings compared to standard ASCII space (`\u0020`) or hyphen (`\u002D`).
- Consequently, `FilteredElementCollector` searches returned `null`. Believing the view did not exist, the orchestrator called `ViewPlan.Create`.

### Root Cause 2: Hot-Renaming of Existing Target View on Name Collision
- In `processSheetViewports` under `Append Suffix`, `CreateViewPlan` created a temporary view with the original name.
- When name assignment threw an exception due to collision in target, `CreateViewPlan` caught the exception, found the existing target view, and returned it.
- `processSheetViewports` assumed the returned view was newly created and executed `newPlan.Name = srcPlacedView.Name + " 1"`. This **renamed the existing original view in target to "P1 - EST - OFICINAS 1"**.
- Subsequently, Stage 5 (`planViewsToTransfer`) searched for `P1 - EST - OFICINAS`, failed to find it (as it had been renamed to `... 1`), and created a second blank view, transferring properties to only one of them.

### Root Cause 3: Missing Pre-flight Validation for Worksets
- Revit API restricts `Workset.Create` to workshared documents (`doc.IsWorkshared`). Non-workshared target models bypassed workset creation silently without notifying the ViewModel.

---

## 3. Technical Solution & Design Patterns

### A. 4-Tier View Matching Strategy (`FindExistingViewByName`)
To ensure 100% reliable view detection regardless of character encoding or formatting differences:
1. **Tier 1 (Exact Match)**: `v.Name.Trim().Equals(target.Trim(), StringComparison.OrdinalIgnoreCase)`.
2. **Tier 2 (Normalized Match)**: Replaces unicode dashes (`\u2010`..`\u2015`, `\u2212`) with `-`, unicode whitespaces (`\u00A0`, `\u200B`, `\uFEFF`, etc.) with `' '`, and collapses consecutive spaces.
3. **Tier 3 (Parameter Match)**: Queries `BuiltInParameter.VIEW_NAME` using normalized comparison.
4. **Tier 4 (AlphaNumeric-Only Match)**: Strips all punctuation, dashes, spaces, and underscores (`ToAlphaNumericOnly`), comparing pure alphanumeric characters (e.g., `"p1estoficinasniveloficinas"`).

### B. Upfront Suffixed Name Calculation (`forceNewSuffixedView: true`)
- `CreateViewPlan` calculates the unique suffixed target view name upfront before invoking `ViewPlan.Create`.
- Prevents hot-renaming existing target views and ensures clean 1:1 view creation under `Append Suffix`.
- Under `Keep Original`, returns the existing target view directly without mutating names or instantiating unnecessary elements.

### C. Pre-flight Workset Interception & Tagged Traversal Logs
- Added pre-flight check in `TransferPlusViewModel` validating `DestinationDocuments.All(d => d.Adoc.IsWorkshared)`. Shows `TaskDialog` in English and cancels the entire transfer when invalid.
- Injected tagged logs throughout view creation stages (`CreateViewPlan [START]`, `[PRE-CHECK]`, `[RE-USE EXISTING]`, `[SUFFIX NAME GENERATED]`, `[API CALL]`, `[API SUCCESS]`, `[NAME ASSIGNED]`, `[COPY SETTINGS]`).

---

## 4. Code Verification & Impact
- Built and verified against `.NET Framework 4.8` (`Debug.R24`) with **0 Errors**.
- Deployed DLL to `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll`.
