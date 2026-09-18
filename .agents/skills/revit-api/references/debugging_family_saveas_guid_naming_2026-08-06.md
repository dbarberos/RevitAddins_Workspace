# Lesson Learned: Revit Family Document SaveAs Naming Rules

## Date: 2026-08-06
## Module: TransferPlus (Revit Add-in, C# / .NET 4.8 / Revit API 2024)

---

## 1. Issue Summary
When saving an in-memory family document (`familyDoc = sourceDocument.EditFamily(sourceFamily)`) to a temporary `.rfa` path before loading into a target model:
- Naming the temporary file with a GUID (e.g. `FamilyName_2a03c21455fc.rfa`) caused Revit API's `SaveAs` method to mutate the internal `Family.Name` to match the `.rfa` filename (`FamilyName_2a03c21455fc`).
- Consequently, `familyDoc.LoadFamily(targetDocument)` created a brand new family in the target project named `FamilyName_2a03c21455fc` instead of merging into `FamilyName`.

---

## 2. Technical Rule & Solution
- **Rule:** Never append GUIDs or arbitrary hashes to the filename of a temporary `.rfa` file passed to `SaveAs` when you want Revit to preserve the target family's name.
- **Correct Pattern:**
  ```csharp
  string targetFileName = overrideFamilyName ?? sourceFamily.Name;
  string tempRfaPath = Path.Combine(tempDir, targetFileName + ".rfa");
  familyDoc.SaveAs(tempRfaPath, new SaveAsOptions { OverwriteExistingFile = true });
  familyDoc.LoadFamily(targetDocument, overwriteOptions);
  ```
- **Outcome:** The family loaded into the target model retains its exact clean name (`FamilyName`), allowing Revit to merge suffixed types (`Tipo_A_Copy`) into the existing family without duplicating family entities.
