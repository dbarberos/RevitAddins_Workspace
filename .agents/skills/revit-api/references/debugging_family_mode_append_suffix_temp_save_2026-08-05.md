# Technical Bug Fix: Append Suffix Family Renaming & Warning Handling

## 🐛 Problem & Cause Analysis
When transferring families in **Family Mode** with `AppendSuffix` enabled:
1. **Family Name Not Suffixed:**  
   `familyDoc.OwnerFamily` is `null` in top-level family documents opened via `sourceDocument.EditFamily(sourceFamily)`. Setting `familyDoc.OwnerFamily.Name = overrideFamilyName` had no effect. As a result, `familyDoc.LoadFamily(targetDocument)` reloaded the family under its original name, overwriting existing families instead of creating new suffixed copies (`FamilyName_Copy`).
2. **Modal Warning Popup ("El hueco no corta nada"):**  
   Loading door/window families into a document triggered Revit's opening geometry warning `OpeningCutsNothing`. Because `targetDocument.LoadFamily` was executed directly without wrapping inside a `Transaction` attached to `WarningSwallower`, Revit interrupted the process with a modal warning dialog.

---

## 🛠️ Root Cause Fix & Implementation

1. **Temporary File Rename (`SaveAs`):**  
   When `overrideFamilyName` is specified (e.g. `KRN_PUE_Int_Panel_Fijo_1H_Copy`):
   - `familyDoc` is saved to a temporary `.rfa` file named `overrideFamilyName + ".rfa"` using `SaveAsOptions { OverwriteExistingFile = true }`.
   - When Revit loads a `.rfa` file from disk (`targetDocument.LoadFamily(tempRfaPath)`), it automatically assigns the filename (without `.rfa`) as the new family name in `targetDocument`.
   - The temporary `.rfa` file is deleted in a `finally` block.
2. **Warning Suppression (`WarningSwallower`):**  
   `targetDocument.LoadFamily` is executed inside a `Transaction(targetDocument, "Cargar Familia TransferPlus")` with `WarningSwallower.AttachToTransaction(txTarget)`. Non-fatal warnings like *"El hueco no corta nada"* are automatically swallowed, preventing any modal dialog popups.

---

## ✅ Verification
- Compiled with **0 Errores**.
- Deployed to `%APPDATA%\Autodesk\Revit\Addins\2024\TransferPlus\`.
- Suffixed families (`FamilyName_Copy`) are properly created as new family entries in the destination model without triggering modal popups.
