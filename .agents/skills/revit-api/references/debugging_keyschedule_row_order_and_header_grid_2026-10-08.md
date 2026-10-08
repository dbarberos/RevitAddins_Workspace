# Debugging Lesson Learned: Revit Key Schedule Row Ordering & Header Visibility

> **Date:** 2026-10-08  
> **Target Subsystem:** `Autodesk.Revit.DB.ViewSchedule` (Key Schedules & Header Schedules)  
> **Component:** `TablePlus.Services.KeyScheduleService`, `TablePlus.Services.HeaderScheduleService`

---

## 1. Symptom

When importing structured tabular data (such as Excel sheets) into native Revit `ViewSchedule` objects:
1. **Row Sequence Inversion / Alphabetical Sorting:** In Key Schedules (`ViewSchedule.CreateKeySchedule`), data rows were rearranged alphabetically by the Key Name field (`BuiltInParameter.REF_TABLE_ATTRIBUTE`) rather than preserving the row order of the source data.
2. **Hidden Header Schedules:** In Header Schedules created with `ViewSchedule.CreateSchedule`, the view appeared empty or collapsed upon placement because the title bar and header grid formatting were disabled by default.

---

## 2. Root Cause

1. **Revit Default Sorting on Key Schedules:**
   - Revit's internal database automatically defaults to sorting Key Schedule rows ascending by their primary key name unless an explicit `ScheduleSortGroupField` is defined.
   - When new rows are created via `definition.InsertDataRow()`, Revit assigns keys based on parameter values, scrambling the original spreadsheet row positions.

2. **Schedule Title Display Property:**
   - A Revit Schedule definition requires `definition.ShowTitle = true` to display the upper header section. Without this setting, Revit collapses the header layout, hiding the title text and formatting.

---

## 3. Resolution & Code Pattern

### A. Preserving Row Order via Hidden Index Parameter
1. Bind an integer shared/project parameter (e.g., `TP_Row_Index`) to `OST_GenericModel`.
2. As rows are inserted into the Key Schedule, write the sequential row number into `TP_Row_Index`.
3. Add a `ScheduleSortGroupField` configured to sort ascending by `TP_Row_Index`.
4. Hide the index field (`field.IsHidden = true`) so the schedule appears clean to the user while preserving the exact row order.

```csharp
// 1. Add sorting field by row index
ScheduleField indexField = definition.AddField(ScheduleFieldType.Instance, rowIndexParamId);
indexField.IsHidden = true;

ScheduleSortGroupField sortField = new ScheduleSortGroupField(indexField.FieldId, ScheduleSortOrder.Ascending);
definition.AddSortGroupField(sortField);

// 2. Synchronize rows with their sequence number
for (int r = 0; r < rows.Count; r++)
{
    // Write index to preserve source row order
    Parameter rowIdxParam = rowElement.LookupParameter("TP_Row_Index");
    if (rowIdxParam != null && !rowIdxParam.IsReadOnly)
    {
        rowIdxParam.Set(r);
    }
}
```

### B. Enabling Header Schedule Title Visibility
Explicitly activate `definition.ShowTitle = true` during schedule initialization:

```csharp
ViewSchedule schedule = ViewSchedule.CreateSchedule(doc, categoryId);
schedule.Definition.ShowTitle = true; // Mandatory to prevent collapsed header grid
schedule.Name = targetName;
```
