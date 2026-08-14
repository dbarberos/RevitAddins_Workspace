# Lesson Learned: Revit Family Identity Preservation & Avoid Duplicate Family Creation with Suffix '1'

## Date: 2026-08-06
## Module: TransferPlus (Revit Add-in, C# / .NET 4.8 / Revit API 2024)

---

## 1. Issue Summary
When transferring newly selected family types into an existing target family in Revit, Revit created a duplicate family with a numeric suffix (e.g. `KRN_PUE_Puerta interior 1H1`) instead of merging the types into the existing family (`KRN_PUE_Puerta interior 1H`).

---

## 2. Technical Cause
- `SaveAs` to a temporary directory (`%TEMP%\TransferPlus_TempFamilies\...`) was being called even when the family name was NOT being changed (`overrideFamilyName == null`).
- Calling `SaveAs` on an in-memory family document changes its file path reference. When `familyDoc.LoadFamily(targetDoc)` is subsequently called, Revit treats the temporary file as a distinct external file and creates a new suffixed family (e.g. `FamilyName1`) to prevent overwriting.

---

## 3. Solution
- Do NOT call `SaveAs` when `overrideFamilyName` is `null` or empty.
- Call `familyDoc.LoadFamily(targetDoc, overwriteOptions)` directly on the in-memory family document.
- Revit native memory matching recognizes the existing family in `targetDoc` and merges the types directly inside the target family without creating suffixed duplicate family elements.
