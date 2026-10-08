using Autodesk.Revit.DB;
using TablePlus.Models;

namespace TablePlus.Services;

/// <summary>
/// Service creating and maintaining native Revit Key Schedules (ViewSchedule)
/// populated with external spreadsheet data. Utilizes the reusable column pool
/// (TP_Column_01..N) to prevent project parameter pollution.
/// </summary>
public class KeyScheduleService
{
    private readonly ISchemaService _schemaService;

    public KeyScheduleService(ISchemaService schemaService)
    {
        _schemaService = schemaService ?? throw new ArgumentNullException(nameof(schemaService));
    }

    /// <summary>
    /// Generates a new native Key Schedule in Revit from extracted Excel cells.
    /// </summary>
    public ViewSchedule GenerateKeySchedule(
        Document doc,
        TableImportConfig config,
        IList<ExcelCellModel> cells)
    {
        if (doc == null) throw new ArgumentNullException(nameof(doc));
        if (config == null) throw new ArgumentNullException(nameof(config));
        if (cells == null || cells.Count == 0) throw new ArgumentException("Cell list cannot be empty.", nameof(cells));

        var distinctCols = cells.Select(c => c.ColumnIndex).Distinct().OrderBy(c => c).ToList();
        var distinctRows = cells.Select(c => c.RowIndex).Distinct().OrderBy(r => r).ToList();

        if (distinctRows.Count == 0 || distinctCols.Count == 0)
        {
            throw new InvalidOperationException("No grid cells found to build schedule.");
        }

        int headerRowIndex = distinctRows[0];
        string? bannerTitle = null;
        List<int> dataRowIndices;

        if (distinctRows.Count >= 2)
        {
            int r0Count = cells.Count(c => c.RowIndex == distinctRows[0] && !string.IsNullOrWhiteSpace(c.FormattedValue));
            int r1Count = cells.Count(c => c.RowIndex == distinctRows[1] && !string.IsNullOrWhiteSpace(c.FormattedValue));

            // If the first row is a single title cell (e.g. "TUR1") and the next row contains multiple column headers
            if (r0Count == 1 && r1Count >= 2)
            {
                var titleCell = cells.FirstOrDefault(c => c.RowIndex == distinctRows[0] && !string.IsNullOrWhiteSpace(c.FormattedValue));
                bannerTitle = titleCell?.FormattedValue;
                headerRowIndex = distinctRows[1];
                dataRowIndices = distinctRows.Skip(2).ToList();
            }
            else
            {
                dataRowIndices = distinctRows.Skip(1).ToList();
            }
        }
        else
        {
            dataRowIndices = distinctRows.Skip(1).ToList();
        }

        using var tx = new Transaction(doc, $"TablePlus: Create Key Schedule {config.ViewName}");
        var failureOpts = tx.GetFailureHandlingOptions();
        failureOpts.SetFailuresPreprocessor(new WarningSwallower());
        tx.SetFailureHandlingOptions(failureOpts);

        tx.Start();

        // 1. Ensure required reusable column parameters exist and are bound
        int extraColumnsCount = Math.Max(distinctCols.Count - 1, 0);
        SharedParameterPoolService.EnsureParametersBound(doc, extraColumnsCount);

        // 2. Create the Key Schedule on BuiltInCategory.OST_GenericModel
        var schedule = ViewSchedule.CreateKeySchedule(doc, new ElementId(BuiltInCategory.OST_GenericModel));
        schedule.Name = GetUniqueScheduleName(doc, config.ViewName);

        // 3. Configure column headers & sort index
        ConfigureScheduleColumns(doc, schedule, cells, distinctCols, headerRowIndex, bannerTitle);

        // 4. Populate rows with cell data
        PopulateScheduleRows(doc, schedule, cells, distinctCols, dataRowIndices);

        // 5. Stamp metadata for tracking and synchronization
        _schemaService.StampTableMetadata(schedule, config, config.SourceFilePath);

        doc.Regenerate();
        tx.Commit();

        LoggerService.LogInfo($"[KeyScheduleService] Successfully generated Key Schedule '{schedule.Name}' ({dataRowIndices.Count} rows, {distinctCols.Count} columns).");
        return schedule;
    }

    /// <summary>
    /// Updates an existing Key Schedule with newly extracted cells.
    /// </summary>
    public void UpdateKeySchedule(
        Document doc,
        ViewSchedule schedule,
        TableImportConfig config,
        IList<ExcelCellModel> cells)
    {
        if (doc == null) throw new ArgumentNullException(nameof(doc));
        if (schedule == null) throw new ArgumentNullException(nameof(schedule));
        if (cells == null || cells.Count == 0) return;

        using var tx = new Transaction(doc, $"TablePlus: Update Key Schedule {config.ViewName}");
        var failureOpts = tx.GetFailureHandlingOptions();
        failureOpts.SetFailuresPreprocessor(new WarningSwallower());
        tx.SetFailureHandlingOptions(failureOpts);

        tx.Start();

        var distinctCols = cells.Select(c => c.ColumnIndex).Distinct().OrderBy(c => c).ToList();
        var distinctRows = cells.Select(c => c.RowIndex).Distinct().OrderBy(r => r).ToList();

        int headerRowIndex = distinctRows[0];
        string? bannerTitle = null;
        List<int> dataRowIndices;

        if (distinctRows.Count >= 2)
        {
            int r0Count = cells.Count(c => c.RowIndex == distinctRows[0] && !string.IsNullOrWhiteSpace(c.FormattedValue));
            int r1Count = cells.Count(c => c.RowIndex == distinctRows[1] && !string.IsNullOrWhiteSpace(c.FormattedValue));

            if (r0Count == 1 && r1Count >= 2)
            {
                var titleCell = cells.FirstOrDefault(c => c.RowIndex == distinctRows[0] && !string.IsNullOrWhiteSpace(c.FormattedValue));
                bannerTitle = titleCell?.FormattedValue;
                headerRowIndex = distinctRows[1];
                dataRowIndices = distinctRows.Skip(2).ToList();
            }
            else
            {
                dataRowIndices = distinctRows.Skip(1).ToList();
            }
        }
        else
        {
            dataRowIndices = distinctRows.Skip(1).ToList();
        }

        // Ensure parameters
        int extraColumnsCount = Math.Max(distinctCols.Count - 1, 0);
        SharedParameterPoolService.EnsureParametersBound(doc, extraColumnsCount);

        // Delete existing key row elements
        var existingElements = new FilteredElementCollector(doc, schedule.Id)
            .WhereElementIsNotElementType()
            .ToElementIds();

        if (existingElements.Count > 0)
        {
            doc.Delete(existingElements);
        }

        // Reconfigure columns & rows
        ConfigureScheduleColumns(doc, schedule, cells, distinctCols, headerRowIndex, bannerTitle);
        PopulateScheduleRows(doc, schedule, cells, distinctCols, dataRowIndices);

        _schemaService.StampTableMetadata(schedule, config, config.SourceFilePath);

        doc.Regenerate();
        tx.Commit();

        LoggerService.LogInfo($"[KeyScheduleService] Successfully updated Key Schedule '{schedule.Name}'.");
    }

    private static void ConfigureScheduleColumns(
        Document doc,
        ViewSchedule schedule,
        IList<ExcelCellModel> cells,
        List<int> distinctCols,
        int headerRowIndex,
        string? bannerTitle = null)
    {
        var schedulableFields = schedule.Definition.GetSchedulableFields();

        // 1. Ensure hidden TP_Row_Index field is added and set as primary ascending sort order
        ScheduleField? rowIndexField = null;
        for (int f = 0; f < schedule.Definition.GetFieldCount(); f++)
        {
            var field = schedule.Definition.GetField(f);
            if (field.GetName() == SharedParameterPoolService.RowIndexParamName)
            {
                rowIndexField = field;
                break;
            }
        }

        if (rowIndexField == null)
        {
            var rowIndexSf = schedulableFields.FirstOrDefault(sf => sf.GetName(doc) == SharedParameterPoolService.RowIndexParamName);
            if (rowIndexSf != null)
            {
                rowIndexField = schedule.Definition.AddField(rowIndexSf);
            }
        }

        if (rowIndexField != null)
        {
            rowIndexField.IsHidden = true;
            schedule.Definition.ClearSortGroupFields();
            var sortGroup = new ScheduleSortGroupField(rowIndexField.FieldId, ScheduleSortOrder.Ascending);
            schedule.Definition.AddSortGroupField(sortGroup);
        }

        // 2. Field 0 in a Key Schedule is the Key Name parameter
        string col0Text = cells.FirstOrDefault(c => c.RowIndex == headerRowIndex && c.ColumnIndex == distinctCols[0])?.FormattedValue ?? string.Empty;
        if (schedule.Definition.GetFieldCount() > 0)
        {
            var field0 = schedule.Definition.GetField(0);
            field0.ColumnHeading = string.IsNullOrWhiteSpace(col0Text) ? " " : col0Text;
        }

        // 3. Columns 1..N: TP_Column_XX
        for (int i = 1; i < distinctCols.Count; i++)
        {
            string paramName = SharedParameterPoolService.GetColumnParamName(i);
            string heading = cells.FirstOrDefault(c => c.RowIndex == headerRowIndex && c.ColumnIndex == distinctCols[i])?.FormattedValue ?? $"Col {i + 1}";

            // Check if field is already added
            bool alreadyAdded = false;
            for (int f = 0; f < schedule.Definition.GetFieldCount(); f++)
            {
                var existingField = schedule.Definition.GetField(f);
                if (existingField.GetName() == paramName)
                {
                    existingField.ColumnHeading = heading;
                    alreadyAdded = true;
                    break;
                }
            }

            if (!alreadyAdded)
            {
                var targetSf = schedulableFields.FirstOrDefault(sf => sf.GetName(doc) == paramName);
                if (targetSf != null)
                {
                    var newField = schedule.Definition.AddField(targetSf);
                    newField.ColumnHeading = heading;
                }
            }
        }

        // 4. If banner title exists, group headers above the columns
        if (bannerTitle is { Length: > 0 } title && distinctCols.Count > 1)
        {
            try
            {
                if (schedule.CanGroupHeaders(0, 0, 0, distinctCols.Count - 1))
                {
                    schedule.GroupHeaders(0, 0, 0, distinctCols.Count - 1, title.Trim());
                }
            }
            catch (Exception ex)
            {
                LoggerService.LogWarning($"[KeyScheduleService] Could not group banner header: {ex.Message}");
            }
        }
    }

    private static void PopulateScheduleRows(
        Document doc,
        ViewSchedule schedule,
        IList<ExcelCellModel> cells,
        List<int> distinctCols,
        List<int> dataRowIndices)
    {
        if (dataRowIndices.Count == 0) return;

        var body = schedule.GetTableData().GetSectionData(SectionType.Body);

        // Insert required number of rows into Key Schedule
        for (int r = 0; r < dataRowIndices.Count; r++)
        {
            body.InsertRow(body.NumberOfRows);
        }

        // Obtain created key elements
        var keyElements = new FilteredElementCollector(doc, schedule.Id)
            .WhereElementIsNotElementType()
            .ToElements();

        for (int r = 0; r < dataRowIndices.Count && r < keyElements.Count; r++)
        {
            int rowIdx = dataRowIndices[r];
            var keyElem = keyElements[r];

            // Primary sort index: sequential 1-based index (e.g. "000001", "000002"...)
            var sortParam = keyElem.LookupParameter(SharedParameterPoolService.RowIndexParamName);
            sortParam?.Set($"{(r + 1):D6}");

            // Column 0: Key Name
            string val0 = cells.FirstOrDefault(c => c.RowIndex == rowIdx && c.ColumnIndex == distinctCols[0])?.FormattedValue ?? string.Empty;
            string keyParamName = schedule.Definition.GetField(0).GetName();
            var keyParam = keyElem.LookupParameter(keyParamName);
            keyParam?.Set(val0);

            try
            {
                keyElem.Name = string.IsNullOrWhiteSpace(val0) ? $"Row {r + 1}" : val0;
            }
            catch
            {
                // Ignore if name cannot be updated directly
            }

            // Columns 1..N: TP_Column_XX
            for (int c = 1; c < distinctCols.Count; c++)
            {
                string val = cells.FirstOrDefault(cCell => cCell.RowIndex == rowIdx && cCell.ColumnIndex == distinctCols[c])?.FormattedValue ?? string.Empty;
                string paramName = SharedParameterPoolService.GetColumnParamName(c);
                var param = keyElem.LookupParameter(paramName);
                param?.Set(val);
            }
        }
    }

    private static string GetUniqueScheduleName(Document doc, string requestedName)
    {
        string baseName = string.IsNullOrWhiteSpace(requestedName) ? "Table Schedule" : requestedName.Trim();
        string candidate = baseName;
        int counter = 1;

        var existingNames = new HashSet<string>(
            new FilteredElementCollector(doc)
                .OfClass(typeof(ViewSchedule))
                .Cast<ViewSchedule>()
                .Select(v => v.Name),
            StringComparer.OrdinalIgnoreCase);

        while (existingNames.Contains(candidate))
        {
            candidate = $"{baseName} ({counter++})";
        }

        return candidate;
    }
}
