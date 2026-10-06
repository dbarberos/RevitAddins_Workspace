using Autodesk.Revit.DB;
using TablePlus.Models;

namespace TablePlus.Services;

/// <summary>
/// Service creating and maintaining native Revit Schedules (ViewSchedule)
/// using the freeform Header section grid. Requires ZERO project parameters,
/// eliminates parameter pollution completely, and supports merged cells.
/// </summary>
public class HeaderScheduleService
{
    private readonly ISchemaService _schemaService;
    private const double MmToFeet = 1.0 / 304.8;

    public HeaderScheduleService(ISchemaService schemaService)
    {
        _schemaService = schemaService ?? throw new ArgumentNullException(nameof(schemaService));
    }

    /// <summary>
    /// Generates a new native Schedule in Revit using the freeform Header grid.
    /// </summary>
    public ViewSchedule GenerateHeaderSchedule(
        Document doc,
        TableImportConfig config,
        IList<ExcelCellModel> cells,
        IList<MergedCellRange> mergedRanges)
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

        // 1. Create standard Schedule on BuiltInCategory.OST_GenericModel
        var schedule = ViewSchedule.CreateSchedule(doc, new ElementId(BuiltInCategory.OST_GenericModel));
        schedule.Name = GetUniqueScheduleName(doc, config.ViewName);

        // 2. Hide body headers so only the custom header grid displays
        schedule.Definition.ShowTitle = false;
        schedule.Definition.ShowHeaders = false;

        // 3. Configure the Header section
        ConfigureHeaderGrid(schedule, cells, mergedRanges, distinctRows, distinctCols);

        // 4. Stamp metadata
        _schemaService.StampTableMetadata(schedule, config, config.SourceFilePath);

        LoggerService.LogInfo($"[HeaderScheduleService] Successfully generated Header Schedule '{schedule.Name}' ({distinctRows.Count} rows, {distinctCols.Count} columns, 0 parameters).");
        return schedule;
    }

    /// <summary>
    /// Updates an existing Header Schedule with newly extracted cells.
    /// </summary>
    public void UpdateHeaderSchedule(
        Document doc,
        ViewSchedule schedule,
        TableImportConfig config,
        IList<ExcelCellModel> cells,
        IList<MergedCellRange> mergedRanges)
    {
        if (doc == null) throw new ArgumentNullException(nameof(doc));
        if (schedule == null) throw new ArgumentNullException(nameof(schedule));
        if (cells == null || cells.Count == 0) return;

        var distinctCols = cells.Select(c => c.ColumnIndex).Distinct().OrderBy(c => c).ToList();
        var distinctRows = cells.Select(c => c.RowIndex).Distinct().OrderBy(r => r).ToList();

        ConfigureHeaderGrid(schedule, cells, mergedRanges, distinctRows, distinctCols);
        _schemaService.StampTableMetadata(schedule, config, config.SourceFilePath);

        LoggerService.LogInfo($"[HeaderScheduleService] Successfully updated Header Schedule '{schedule.Name}'.");
    }

    private static void ConfigureHeaderGrid(
        ViewSchedule schedule,
        IList<ExcelCellModel> cells,
        IList<MergedCellRange> mergedRanges,
        List<int> distinctRows,
        List<int> distinctCols)
    {
        var header = schedule.GetTableData().GetSectionData(SectionType.Header);
        if (header == null) return;

        int targetCols = distinctCols.Count;
        int targetRows = distinctRows.Count;

        // Adjust columns
        while (header.NumberOfColumns < targetCols)
        {
            header.InsertColumn(header.NumberOfColumns);
        }

        // Adjust rows
        while (header.NumberOfRows < targetRows)
        {
            header.InsertRow(header.NumberOfRows);
        }

        // Populate cell texts
        foreach (var cell in cells)
        {
            int r = distinctRows.IndexOf(cell.RowIndex);
            int c = distinctCols.IndexOf(cell.ColumnIndex);
            if (r >= 0 && r < header.NumberOfRows && c >= 0 && c < header.NumberOfColumns)
            {
                try
                {
                    header.SetCellText(r, c, cell.FormattedValue ?? string.Empty);
                }
                catch
                {
                    // Ignore cell write locks
                }
            }
        }

        // Apply merged ranges if any
        if (mergedRanges != null && mergedRanges.Count > 0)
        {
            foreach (var merge in mergedRanges)
            {
                int rTop = distinctRows.IndexOf(merge.StartRow);
                int rBottom = distinctRows.IndexOf(merge.EndRow);
                int cLeft = distinctCols.IndexOf(merge.StartColumn);
                int cRight = distinctCols.IndexOf(merge.EndColumn);

                if (rTop >= 0 && rBottom >= 0 && cLeft >= 0 && cRight >= 0 &&
                    rTop < header.NumberOfRows && rBottom < header.NumberOfRows &&
                    cLeft < header.NumberOfColumns && cRight < header.NumberOfColumns &&
                    (rTop != rBottom || cLeft != cRight))
                {
                    try
                    {
                        var mergedCell = new TableMergedCell(rTop, cLeft, rBottom, cRight);
                        header.MergeCells(mergedCell);
                    }
                    catch
                    {
                        // Ignore invalid overlap merges
                    }
                }
            }
        }

        // Apply column widths in feet
        for (int c = 0; c < distinctCols.Count && c < header.NumberOfColumns; c++)
        {
            int origCol = distinctCols[c];
            double widthMm = cells
                .Where(cell => cell.ColumnIndex == origCol && cell.WidthMillimeters > 0)
                .Select(cell => cell.WidthMillimeters)
                .FirstOrDefault();

            if (widthMm > 0)
            {
                try
                {
                    header.SetColumnWidth(c, Math.Max(widthMm * MmToFeet, 0.05));
                }
                catch
                {
                    // Ignore width lock
                }
            }
        }
    }

    private static string GetUniqueScheduleName(Document doc, string requestedName)
    {
        string baseName = string.IsNullOrWhiteSpace(requestedName) ? "Header Schedule" : requestedName.Trim();
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
