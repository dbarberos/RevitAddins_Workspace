# Walkthrough: TablePlus Key Schedule Row Ordering & Header Schedule Visibility

> **Date:** 2026-10-08  
> **Component:** `TablePlus` (KeyScheduleService, HeaderScheduleService, TableImportViewModel, MainWindowViewModel)  
> **Status:** Verified & Deployed to Revit 2024 and 2025

---

## 1. Summary of Issues Resolved

During runtime verification of Excel table imports into native Revit Schedule views:
1. **Key Schedule Row Order Mismatch:** In Key Schedules (`ViewSchedule` with `IsTitleblockRevisionSchedule = false`, `Category.Id = OST_GenericModel`), rows appeared sorted alphabetically by the Key Name parameter instead of respecting the row sequence of the original Excel worksheet.
2. **Header Schedule Visibility Lock:** Header Schedule views were created without enabling title visibility (`Definition.ShowTitle = false`), causing the generated grid cells to remain hidden or unformatted in the Revit project browser/sheet placements.
3. **Revit File Lock During Compilation:** Build scripts occasionally attempted compilation while `Revit.exe` held a lock on `TablePlus.dll`, leading to `MSB3026` or deployment bypass.

---

## 2. Root Cause Analysis

### A. Key Schedule Sorting
- Revit's internal database sorts Key Schedule instances by their primary key name (`KeyNameParameter`) unless an explicit `ScheduleSortGroupField` is applied.
- When rows were created via `ScheduleDefinition.InsertDataRow()`, Revit assigned keys based on the key parameter, disrupting the original Excel row order.

### B. Header Schedule Title Visibility
- Revit Schedule views default to suppressing the title banner if not explicitly configured. Without `definition.ShowTitle = true`, the upper header section was collapsed, and header cells did not render with proper styling.

---

## 3. Implementation Details

1. **Row Index Tracking (`TP_Row_Index`):**
   - Bound an integer parameter `TP_Row_Index` to `OST_GenericModel` via `SharedParameterPoolService`.
   - On each inserted row in `KeyScheduleService`, synchronized `TP_Row_Index = rowIndex`.
   - Configured `ScheduleSortGroupField` sorted ascending by `TP_Row_Index`, then marked the field hidden (`IsHidden = true`) so the original Excel order is guaranteed without polluting the visible schedule.

2. **Header Schedule Title Enablement:**
   - Explicitly configured `schedule.Definition.ShowTitle = true` inside `HeaderScheduleService`.
   - Synchronized cell text and column spans across header rows.

3. **Revit Lock Gate Enforcement:**
   - Verified that `Revit.exe` is closed before running `dotnet build` or `dotnet publish`, ensuring binaries in `%AppData%\Autodesk\Revit\Addins\2024\` and `2025\` are completely updated.

---

## 4. Verification

- Tested with `Test.xlsx` (`tur1` and `tur2` sheets).
- Successfully imported and synchronized Key Schedules and Header Schedules.
- Verified row order precisely matches Excel source.
- Verified compilation and deployment in `Release.R24` and `Release.R25`.
