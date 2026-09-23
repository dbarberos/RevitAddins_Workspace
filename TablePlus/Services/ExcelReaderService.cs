using System.IO;
using ClosedXML.Excel;
using TablePlus.Models;

namespace TablePlus.Services;

/// <summary>
/// Managed implementation of IExcelReaderService using ClosedXML without COM dependencies.
/// </summary>
public class ExcelReaderService : IExcelReaderService
{
    private const double PointsToMm = 0.352778; // 1 pt = 1/72 inch = 25.4 / 72 mm
    private const double ExcelCharWidthToMm = 2.032; // Standard 8.43 chars = ~17.13 mm (approx 2.032 mm per char)

    public ExcelWorkbookModel InspectWorkbook(string filePath)
    {
        ValidateFilePath(filePath);

        var fileInfo = new FileInfo(filePath);
        var workbookModel = new ExcelWorkbookModel
        {
            FilePath = fileInfo.FullName,
            FileName = fileInfo.Name,
            LastModifiedUtc = fileInfo.LastWriteTimeUtc
        };

        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var workbook = new XLWorkbook(stream);

        int index = 1;
        foreach (var ws in workbook.Worksheets)
        {
            var usedRange = ws.RangeUsed();
            var sheetModel = new ExcelSheetModel
            {
                Name = ws.Name,
                PositionIndex = index++,
                UsedRangeAddress = usedRange?.RangeAddress.ToStringRelative() ?? "A1",
                RowCount = usedRange?.RowCount() ?? 0,
                ColumnCount = usedRange?.ColumnCount() ?? 0
            };

            // Collect Named Ranges defined in this worksheet or globally targeting this sheet
            foreach (var nr in workbook.DefinedNames)
            {
                if (nr.Ranges.Any(r => r.Worksheet?.Name.Equals(ws.Name, StringComparison.OrdinalIgnoreCase) == true))
                {
                    sheetModel.NamedRanges.Add(nr.Name);
                }
            }

            foreach (var nr in ws.DefinedNames)
            {
                if (!sheetModel.NamedRanges.Contains(nr.Name))
                {
                    sheetModel.NamedRanges.Add(nr.Name);
                }
            }

            workbookModel.Sheets.Add(sheetModel);
        }

        return workbookModel;
    }

    public IList<MergedCellRange> ExtractMergedCells(string filePath, string sheetName)
    {
        ValidateFilePath(filePath);

        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var workbook = new XLWorkbook(stream);

        var ws = workbook.Worksheet(sheetName);
        var mergedList = new List<MergedCellRange>();

        foreach (var range in ws.MergedRanges)
        {
            var first = range.RangeAddress.FirstAddress;
            var last = range.RangeAddress.LastAddress;

            double totalWidthMm = 0;
            for (int col = first.ColumnNumber; col <= last.ColumnNumber; col++)
            {
                double colWidthChars = ws.Column(col).Width;
                totalWidthMm += Math.Max(colWidthChars * ExcelCharWidthToMm, 4.0);
            }

            double totalHeightMm = 0;
            for (int row = first.RowNumber; row <= last.RowNumber; row++)
            {
                double rowHeightPt = ws.Row(row).Height;
                totalHeightMm += Math.Max(rowHeightPt * PointsToMm, 3.0);
            }

            mergedList.Add(new MergedCellRange
            {
                StartRow = first.RowNumber,
                EndRow = last.RowNumber,
                StartColumn = first.ColumnNumber,
                EndColumn = last.ColumnNumber,
                TotalWidthMillimeters = totalWidthMm,
                TotalHeightMillimeters = totalHeightMm
            });
        }

        return mergedList;
    }

    public IList<ExcelCellModel> ExtractCells(string filePath, string sheetName, string? cellRangeAddress)
    {
        ValidateFilePath(filePath);

        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var workbook = new XLWorkbook(stream);

        var ws = workbook.Worksheet(sheetName);
        IXLRange targetRange;

        if (string.IsNullOrWhiteSpace(cellRangeAddress))
        {
            targetRange = ws.RangeUsed() ?? ws.Range(1, 1, 1, 1);
        }
        else
        {
            targetRange = ws.Range(cellRangeAddress!);
        }

        var mergedRanges = ExtractMergedCells(filePath, sheetName);
        var cells = new List<ExcelCellModel>();

        int firstRow = targetRange.RangeAddress.FirstAddress.RowNumber;
        int lastRow = targetRange.RangeAddress.LastAddress.RowNumber;
        int firstCol = targetRange.RangeAddress.FirstAddress.ColumnNumber;
        int lastCol = targetRange.RangeAddress.LastAddress.ColumnNumber;

        for (int r = firstRow; r <= lastRow; r++)
        {
            var xlRow = ws.Row(r);
            double rowHeightMm = Math.Max(xlRow.Height * PointsToMm, 3.0);

            for (int c = firstCol; c <= lastCol; c++)
            {
                var xlCol = ws.Column(c);
                double colWidthMm = Math.Max(xlCol.Width * ExcelCharWidthToMm, 4.0);
                var xlCell = ws.Cell(r, c);

                var cellModel = new ExcelCellModel
                {
                    RowIndex = r,
                    ColumnIndex = c,
                    FormattedValue = xlCell.GetFormattedString() ?? string.Empty,
                    WidthMillimeters = colWidthMm,
                    HeightMillimeters = rowHeightMm,
                    FontFamily = xlCell.Style.Font.FontName,
                    FontSizePoints = xlCell.Style.Font.FontSize,
                    IsBold = xlCell.Style.Font.Bold,
                    IsItalic = xlCell.Style.Font.Italic,
                    IsUnderline = xlCell.Style.Font.Underline != XLFontUnderlineValues.None,
                    HorizontalAlign = MapHorizontalAlignment(xlCell.Style.Alignment.Horizontal),
                    VerticalAlign = MapVerticalAlignment(xlCell.Style.Alignment.Vertical),
                    BackgroundColorHex = ExtractBackgroundHex(xlCell),
                    TextColorHex = ExtractTextColorHex(xlCell),
                    Borders = ExtractBorders(xlCell)
                };

                // Determine merge state
                var matchMerge = mergedRanges.FirstOrDefault(m => m.Contains(r, c));
                if (matchMerge != null)
                {
                    cellModel.IsMerged = true;
                    cellModel.MergeRange = matchMerge;
                    cellModel.IsMergeMaster = matchMerge.IsMaster(r, c);

                    if (cellModel.IsMergeMaster)
                    {
                        cellModel.WidthMillimeters = matchMerge.TotalWidthMillimeters;
                        cellModel.HeightMillimeters = matchMerge.TotalHeightMillimeters;
                    }
                }

                cells.Add(cellModel);
            }
        }

        return cells;
    }

    private static void ValidateFilePath(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("Excel file path cannot be empty.", nameof(filePath));

        string fullPath = Path.GetFullPath(filePath);
        if (!File.Exists(fullPath))
            throw new FileNotFoundException($"Excel file not found at: {fullPath}");
    }

    private static CellHorizontalAlignment MapHorizontalAlignment(XLAlignmentHorizontalValues align) =>
        align switch
        {
            XLAlignmentHorizontalValues.Center => CellHorizontalAlignment.Center,
            XLAlignmentHorizontalValues.Right => CellHorizontalAlignment.Right,
            XLAlignmentHorizontalValues.Justify => CellHorizontalAlignment.Justify,
            _ => CellHorizontalAlignment.Left
        };

    private static CellVerticalAlignment MapVerticalAlignment(XLAlignmentVerticalValues align) =>
        align switch
        {
            XLAlignmentVerticalValues.Top => CellVerticalAlignment.Top,
            XLAlignmentVerticalValues.Bottom => CellVerticalAlignment.Bottom,
            _ => CellVerticalAlignment.Middle
        };

    private static string? ExtractBackgroundHex(IXLCell cell)
    {
        var fill = cell.Style.Fill;
        if (fill.PatternType == XLFillPatternValues.None) return null;

        var color = fill.BackgroundColor;
        if (color.ColorType == XLColorType.Color)
        {
            return $"#{color.Color.R:X2}{color.Color.G:X2}{color.Color.B:X2}";
        }
        return null;
    }

    private static string? ExtractTextColorHex(IXLCell cell)
    {
        var fontColor = cell.Style.Font.FontColor;
        if (fontColor.ColorType == XLColorType.Color)
        {
            return $"#{fontColor.Color.R:X2}{fontColor.Color.G:X2}{fontColor.Color.B:X2}";
        }
        return null;
    }

    private static CellBorders ExtractBorders(IXLCell cell)
    {
        var borders = new CellBorders();
        var xlBorder = cell.Style.Border;

        borders.Top = new CellBorderLine(MapBorderStyle(xlBorder.TopBorder));
        borders.Bottom = new CellBorderLine(MapBorderStyle(xlBorder.BottomBorder));
        borders.Left = new CellBorderLine(MapBorderStyle(xlBorder.LeftBorder));
        borders.Right = new CellBorderLine(MapBorderStyle(xlBorder.RightBorder));

        return borders;
    }

    private static CellBorderStyle MapBorderStyle(XLBorderStyleValues style) =>
        style switch
        {
            XLBorderStyleValues.Thin => CellBorderStyle.Thin,
            XLBorderStyleValues.Medium => CellBorderStyle.Medium,
            XLBorderStyleValues.Thick => CellBorderStyle.Thick,
            XLBorderStyleValues.Double => CellBorderStyle.Double,
            XLBorderStyleValues.Dashed => CellBorderStyle.Dashed,
            XLBorderStyleValues.Dotted => CellBorderStyle.Dotted,
            XLBorderStyleValues.Hair => CellBorderStyle.Hair,
            _ => CellBorderStyle.None
        };
}
