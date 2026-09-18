# Technical Feature & Debugging: Family Mode "On Duplicates" Strategy

## 📌 Context & Feature Scope
In **TransferPlus**, the **"On Duplicates"** card provides three strategy options:
1. `KeepOriginal`
2. `AbortTransaction`
3. `AppendSuffix` (with `DuplicatesSuffixText`)

This feature was extended to support **Family Mode** (`IsFamiliesManagerActive == true`), while preserving its existing operation in Standard Mode.

---

## 🛠️ Implementation Details

### 1. `KeepOriginal` Mode:
- **Existing Family Check:** Checks if a `Family` element with `familyItem.Name` already exists in `destDoc`.
- **Existing Symbol Inspection:** Evaluates the selected `FamilySymbol` items under `familyItem.Symbols`.
  - **All Types Exist:** If ALL selected types exist in `destDoc` under the family, the family transfer is **skipped** (0 redundant copies made).
  - **Partial Missing Types:** If one or more selected types do NOT exist in the destination family, a cloned `FamilyItemModel` containing **ONLY missing symbols** is transferred to `destDoc`.
  - **Family Not Found:** Transferred normally.

### 2. `AbortTransaction` Mode:
- Pre-scans selected families and active types against `destDoc` before transferring.
- If **ANY** family name or selected type name already exists in `destDoc`:
  - Instantly **aborts/rolls back** the operation.
  - Displays `TaskDialog.Show("TransferPlus - Operation Aborted", ...)` detailing the conflicting family or type.

### 3. `AppendSuffix` Mode:
- If a family with `familyItem.Name` already exists in `destDoc`:
  - Computes `overrideFamilyName = fam.Name + suffix`.
  - Transfers the family into `destDoc` with the suffixed family name (e.g. `Door_PC06_V2`).
  - **Type Names Preserved:** Internal family type names keep their exact original names without adding suffixes.

---

## ✅ Verification
- Compiles with **0 Errores** and deploys to `%APPDATA%\Autodesk\Revit\Addins\2024\TransferPlus\`.
