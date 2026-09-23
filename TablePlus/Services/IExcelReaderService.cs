using TablePlus.Models;

namespace TablePlus.Services;

/// <summary>
/// Contract for extracting tabular data, styles, and geometry from Excel workbooks.
/// </summary>
public interface IExcelReaderService
{
    /// <summary>
    /// Inspects an Excel file on disk and retrieves worksheet catalog and named ranges.
    /// </summary>
    ExcelWorkbookModel InspectWorkbook(string filePath);

    /// <summary>
    /// Extracts structured cell models with formatting, fonts, and dimensions in millimeters.
    /// </summary>
    IList<ExcelCellModel> ExtractCells(string filePath, string sheetName, string? cellRangeAddress);

    /// <summary>
    /// Retrieves all merged cell boundaries defined in the target worksheet.
    /// </summary>
    IList<MergedCellRange> ExtractMergedCells(string filePath, string sheetName);
}
