namespace TablePlus.Models;

/// <summary>
/// Metadata and range descriptors for an individual worksheet.
/// </summary>
public class ExcelSheetModel
{
    public string Name { get; set; } = string.Empty;
    public int PositionIndex { get; set; }
    public string UsedRangeAddress { get; set; } = string.Empty;
    public int RowCount { get; set; }
    public int ColumnCount { get; set; }
    public List<string> NamedRanges { get; set; } = [];
}

/// <summary>
/// Container holding workbook inspection data and sheet catalog.
/// </summary>
public class ExcelWorkbookModel
{
    public string FilePath { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public DateTime LastModifiedUtc { get; set; }
    public List<ExcelSheetModel> Sheets { get; set; } = [];
}
