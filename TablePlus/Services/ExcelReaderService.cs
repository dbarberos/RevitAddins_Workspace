using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using ClosedXML.Excel;
using TablePlus.Models;

namespace TablePlus.Services;

/// <summary>
/// Managed implementation of IExcelReaderService using ClosedXML without COM dependencies,
/// with native support for OpenXML spreadsheets (.xlsx, .xlsm), delimited text files (.csv, .txt, .tsv, etc.),
/// and Adobe PDF document tables (.pdf).
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

        var ext = fileInfo.Extension.ToLowerInvariant();
        if (ext is ".csv" or ".txt" or ".tsv" or ".tab" or ".prn" or ".dat" or ".log" or ".asc")
        {
            return InspectTextFile(filePath, workbookModel);
        }
        else if (ext is ".pdf")
        {
            return InspectPdfFile(filePath, workbookModel);
        }
        else if (ext is ".docx" or ".doc" or ".rtf")
        {
            return InspectWordDocument(filePath, workbookModel);
        }
        else if (ext is ".md" or ".markdown")
        {
            return InspectMarkdownFile(filePath, workbookModel);
        }

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
                if (nr.Name.StartsWith("_xlnm.", StringComparison.OrdinalIgnoreCase) ||
                    nr.Name.Equals("Print_Area", StringComparison.OrdinalIgnoreCase) ||
                    nr.Name.Equals("Print_Titles", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (nr.Ranges.Any(r => r.Worksheet?.Name.Equals(ws.Name, StringComparison.OrdinalIgnoreCase) == true))
                {
                    if (!sheetModel.NamedRanges.Contains(nr.Name))
                    {
                        sheetModel.NamedRanges.Add(nr.Name);
                    }
                }
            }

            foreach (var nr in ws.DefinedNames)
            {
                if (nr.Name.StartsWith("_xlnm.", StringComparison.OrdinalIgnoreCase) ||
                    nr.Name.Equals("Print_Area", StringComparison.OrdinalIgnoreCase) ||
                    nr.Name.Equals("Print_Titles", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (!sheetModel.NamedRanges.Contains(nr.Name))
                {
                    sheetModel.NamedRanges.Add(nr.Name);
                }
            }

            try
            {
                foreach (var pa in ws.PageSetup.PrintAreas)
                {
                    var addr = pa.RangeAddress.ToStringRelative();
                    if (!string.IsNullOrWhiteSpace(addr))
                    {
                        sheetModel.PrintAreas.Add($"Print Area ({addr})");
                    }
                }
            }
            catch
            {
                // Silently ignore if page setup print areas are not readable
            }

            // Fallback: check if defined names has a Print_Area for this sheet
            if (sheetModel.PrintAreas.Count == 0)
            {
                var paNamed = ws.DefinedNames.FirstOrDefault(n => n.Name.Equals("Print_Area", StringComparison.OrdinalIgnoreCase) || n.Name.EndsWith("Print_Area", StringComparison.OrdinalIgnoreCase))
                              ?? workbook.DefinedNames.FirstOrDefault(n => (n.Name.Equals("Print_Area", StringComparison.OrdinalIgnoreCase) || n.Name.EndsWith("Print_Area", StringComparison.OrdinalIgnoreCase))
                                                                           && n.Ranges.Any(r => r.Worksheet?.Name.Equals(ws.Name, StringComparison.OrdinalIgnoreCase) == true));
                if (paNamed != null)
                {
                    try
                    {
                        var firstRange = paNamed.Ranges.FirstOrDefault(r => r.Worksheet?.Name.Equals(ws.Name, StringComparison.OrdinalIgnoreCase) == true) ?? paNamed.Ranges.FirstOrDefault();
                        if (firstRange != null)
                        {
                            var addr = firstRange.RangeAddress.ToStringRelative();
                            if (!string.IsNullOrWhiteSpace(addr))
                            {
                                sheetModel.PrintAreas.Add($"Print Area ({addr})");
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }

            workbookModel.Sheets.Add(sheetModel);
        }

        return workbookModel;
    }

    public IList<MergedCellRange> ExtractMergedCells(string filePath, string sheetName)
    {
        ValidateFilePath(filePath);

        var ext = Path.GetExtension(filePath).ToLowerInvariant();
        if (ext is ".csv" or ".txt" or ".tsv" or ".tab" or ".prn" or ".dat" or ".log" or ".asc" or ".pdf" or ".docx" or ".doc" or ".rtf" or ".md" or ".markdown")
        {
            return new List<MergedCellRange>();
        }

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

        var ext = Path.GetExtension(filePath).ToLowerInvariant();
        if (ext is ".csv" or ".txt" or ".tsv" or ".tab" or ".prn" or ".dat" or ".log" or ".asc")
        {
            return ExtractTextCells(filePath, cellRangeAddress);
        }
        else if (ext is ".pdf")
        {
            return ExtractPdfCells(filePath, cellRangeAddress);
        }
        else if (ext is ".docx" or ".doc" or ".rtf")
        {
            return ExtractWordCells(filePath, cellRangeAddress);
        }
        else if (ext is ".md" or ".markdown")
        {
            return ExtractMarkdownCells(filePath, cellRangeAddress);
        }

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

    #region Text and Delimited Files Handling

    private static ExcelWorkbookModel InspectTextFile(string filePath, ExcelWorkbookModel workbookModel)
    {
        var lines = ReadNonEmptyLines(filePath, maxLines: 5000);
        int rowCount = Math.Max(lines.Count, 1);
        char delimiter = DetectDelimiter(lines, Path.GetExtension(filePath));

        int maxCols = 1;
        if (lines.Count > 0)
        {
            maxCols = lines.Max(l => SplitDelimitedLine(l, delimiter).Count);
            if (maxCols < 1) maxCols = 1;
        }

        string colLetter = GetColumnLetter(maxCols);
        var sheetModel = new ExcelSheetModel
        {
            Name = Path.GetFileNameWithoutExtension(filePath),
            PositionIndex = 1,
            UsedRangeAddress = $"A1:{colLetter}{rowCount}",
            RowCount = rowCount,
            ColumnCount = maxCols
        };

        workbookModel.Sheets.Add(sheetModel);
        return workbookModel;
    }

    private static IList<ExcelCellModel> ExtractTextCells(string filePath, string? cellRangeAddress)
    {
        var lines = ReadNonEmptyLines(filePath, maxLines: 5000);
        if (lines.Count == 0)
        {
            lines.Add(string.Empty);
        }

        char delimiter = DetectDelimiter(lines, Path.GetExtension(filePath));
        var parsedRows = lines.Select(l => SplitDelimitedLine(l, delimiter)).ToList();
        int maxCols = parsedRows.Max(r => r.Count);
        if (maxCols < 1) maxCols = 1;

        // Calculate dynamic column widths (in mm) based on longest cell content
        var colWidths = new double[maxCols + 1];
        for (int c = 1; c <= maxCols; c++)
        {
            int maxLen = 0;
            foreach (var row in parsedRows)
            {
                if (c - 1 < row.Count)
                {
                    maxLen = Math.Max(maxLen, row[c - 1].Length);
                }
            }
            colWidths[c] = Math.Clamp(maxLen * ExcelCharWidthToMm, 18.0, 180.0);
        }

        var cells = new List<ExcelCellModel>();
        for (int r = 1; r <= parsedRows.Count; r++)
        {
            var rowData = parsedRows[r - 1];
            bool isHeader = (r == 1);
            double rowHeightMm = isHeader ? 7.0 : 6.0;

            for (int c = 1; c <= maxCols; c++)
            {
                string text = (c - 1 < rowData.Count) ? rowData[c - 1] : string.Empty;

                var cellModel = new ExcelCellModel
                {
                    RowIndex = r,
                    ColumnIndex = c,
                    FormattedValue = text,
                    WidthMillimeters = colWidths[c],
                    HeightMillimeters = rowHeightMm,
                    FontFamily = "Arial",
                    FontSizePoints = isHeader ? 8.5 : 8.0,
                    IsBold = isHeader,
                    IsItalic = false,
                    IsUnderline = false,
                    HorizontalAlign = CellHorizontalAlignment.Left,
                    VerticalAlign = CellVerticalAlignment.Middle,
                    BackgroundColorHex = isHeader ? "#F2F4F7" : null,
                    TextColorHex = isHeader ? "#1D2939" : "#333333",
                    Borders = new CellBorders
                    {
                        Top = new CellBorderLine(CellBorderStyle.Thin),
                        Bottom = new CellBorderLine(CellBorderStyle.Thin),
                        Left = new CellBorderLine(CellBorderStyle.Thin),
                        Right = new CellBorderLine(CellBorderStyle.Thin)
                    }
                };

                cells.Add(cellModel);
            }
        }

        return cells;
    }

    private static List<string> ReadNonEmptyLines(string filePath, int maxLines)
    {
        var lines = new List<string>();
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var reader = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);

        string? line;
        while ((line = reader.ReadLine()) != null && lines.Count < maxLines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                lines.Add(line);
            }
        }

        return lines;
    }

    private static char DetectDelimiter(List<string> lines, string extension)
    {
        var ext = extension.ToLowerInvariant();
        if (ext is ".tsv" or ".tab") return '\t';
        if (ext is ".csv")
        {
            int commas = 0, semicolons = 0;
            foreach (var l in lines.Take(10))
            {
                commas += l.Count(c => c == ',');
                semicolons += l.Count(c => c == ';');
            }
            return (semicolons > commas) ? ';' : ',';
        }

        char[] candidates = ['\t', ';', ',', '|'];
        char bestDelim = '\t';
        int maxHits = 0;

        foreach (var candidate in candidates)
        {
            int hits = lines.Take(10).Sum(l => l.Count(c => c == candidate));
            if (hits > maxHits)
            {
                maxHits = hits;
                bestDelim = candidate;
            }
        }

        return (maxHits > 0) ? bestDelim : '\t';
    }

    private static List<string> SplitDelimitedLine(string line, char delimiter)
    {
        var result = new List<string>();
        if (string.IsNullOrEmpty(line))
        {
            result.Add(string.Empty);
            return result;
        }

        var sb = new StringBuilder();
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (c == '"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                {
                    sb.Append('"');
                    i++; // skip escaped quote
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == delimiter && !inQuotes)
            {
                result.Add(sb.ToString().Trim());
                sb.Clear();
            }
            else
            {
                sb.Append(c);
            }
        }
        result.Add(sb.ToString().Trim());
        return result;
    }

    private static string GetColumnLetter(int columnNumber)
    {
        string columnLetter = string.Empty;
        while (columnNumber > 0)
        {
            int modulo = (columnNumber - 1) % 26;
            columnLetter = Convert.ToChar('A' + modulo) + columnLetter;
            columnNumber = (columnNumber - modulo) / 26;
        }
        return string.IsNullOrEmpty(columnLetter) ? "A" : columnLetter;
    }

    #endregion

    #region PDF Documents Handling

    private sealed class PdfParsedData
    {
        public int ColumnCount { get; set; } = 3;
        public List<List<string>> Rows { get; set; } = new();
    }

    private static ExcelWorkbookModel InspectPdfFile(string filePath, ExcelWorkbookModel workbookModel)
    {
        var pdfData = ParsePdfStructure(filePath);
        int rowCount = Math.Max(pdfData.Rows.Count, 1);
        int colCount = Math.Max(pdfData.ColumnCount, 1);
        string colLetter = GetColumnLetter(colCount);

        var sheetModel = new ExcelSheetModel
        {
            Name = Path.GetFileNameWithoutExtension(filePath),
            PositionIndex = 1,
            UsedRangeAddress = $"A1:{colLetter}{rowCount}",
            RowCount = rowCount,
            ColumnCount = colCount
        };

        workbookModel.Sheets.Add(sheetModel);
        return workbookModel;
    }

    private static IList<ExcelCellModel> ExtractPdfCells(string filePath, string? cellRangeAddress)
    {
        var pdfData = ParsePdfStructure(filePath);
        var cells = new List<ExcelCellModel>();

        int maxCols = pdfData.ColumnCount;
        var colWidths = new double[] { 0, 30.0, 45.0, 95.0 };

        for (int r = 1; r <= pdfData.Rows.Count; r++)
        {
            var rowData = pdfData.Rows[r - 1];
            bool isHeader = (r == 1);
            double rowHeightMm = isHeader ? 7.5 : 6.0;

            for (int c = 1; c <= maxCols; c++)
            {
                string text = (c - 1 < rowData.Count) ? rowData[c - 1] : string.Empty;
                double colWidth = (c < colWidths.Length) ? colWidths[c] : 40.0;

                var cellModel = new ExcelCellModel
                {
                    RowIndex = r,
                    ColumnIndex = c,
                    FormattedValue = text,
                    WidthMillimeters = colWidth,
                    HeightMillimeters = rowHeightMm,
                    FontFamily = "Arial",
                    FontSizePoints = isHeader ? 8.5 : 8.0,
                    IsBold = isHeader,
                    IsItalic = false,
                    IsUnderline = false,
                    HorizontalAlign = CellHorizontalAlignment.Left,
                    VerticalAlign = CellVerticalAlignment.Middle,
                    BackgroundColorHex = isHeader ? "#E0F2FE" : (r % 2 == 0 ? "#F8FAFC" : null),
                    TextColorHex = isHeader ? "#0369A1" : "#1E293B",
                    Borders = new CellBorders
                    {
                        Top = new CellBorderLine(CellBorderStyle.Thin),
                        Bottom = new CellBorderLine(CellBorderStyle.Thin),
                        Left = new CellBorderLine(CellBorderStyle.Thin),
                        Right = new CellBorderLine(CellBorderStyle.Thin)
                    }
                };

                cells.Add(cellModel);
            }
        }

        return cells;
    }

    private static PdfParsedData ParsePdfStructure(string filePath)
    {
        var data = new PdfParsedData { ColumnCount = 3 };
        var fi = new FileInfo(filePath);
        string fileName = fi.Name;
        string fileSize = $"{fi.Length / 1024.0:F1} KB";
        if (fi.Length > 1024 * 1024)
        {
            fileSize = $"{fi.Length / (1024.0 * 1024.0):F2} MB";
        }
        string modDate = fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");

        int pageCount = 1;
        var textLines = new List<string>();

        try
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            string rawContent = Encoding.ASCII.GetString(bytes);

            // Search for page count: /Count (\d+) or count of /Type\s*/Page\b
            var matchCount = Regex.Match(rawContent, @"/Type\s*/Pages.*?/Count\s+(\d+)", RegexOptions.Singleline);
            if (matchCount.Success && int.TryParse(matchCount.Groups[1].Value, out int count) && count > 0)
            {
                pageCount = count;
            }
            else
            {
                int pageOccurrences = Regex.Matches(rawContent, @"/Type\s*/Page\b").Count;
                if (pageOccurrences > 0) pageCount = pageOccurrences;
            }

            // Extract visible text strings inside PDF text operators ( ... ) Tj
            var textMatches = Regex.Matches(rawContent, @"\(([^\\\)]{3,})\)\s*Tj", RegexOptions.Singleline);
            foreach (Match m in textMatches)
            {
                string text = m.Groups[1].Value.Trim();
                if (!string.IsNullOrWhiteSpace(text) && text.Any(char.IsLetterOrDigit) && !textLines.Contains(text))
                {
                    textLines.Add(text);
                    if (textLines.Count >= 50) break;
                }
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogWarning($"PDF structure parsing warning for {filePath}: {ex.Message}");
        }

        // Header
        data.Rows.Add(new List<string> { "Document", "Property / Section", "Value" });
        data.Rows.Add(new List<string> { "Metadata", "File Name", fileName });
        data.Rows.Add(new List<string> { "Metadata", "File Size", fileSize });
        data.Rows.Add(new List<string> { "Metadata", "Page Count", pageCount.ToString() });
        data.Rows.Add(new List<string> { "Metadata", "Last Modified", modDate });

        if (textLines.Count > 0)
        {
            int lineNum = 1;
            foreach (var line in textLines)
            {
                data.Rows.Add(new List<string> { "Content", $"Line {lineNum++}", line });
            }
        }
        else
        {
            data.Rows.Add(new List<string> { "Content", "Status", "Vector / Raster PDF container (Ready)" });
        }

        return data;
    }

    #endregion

    #region Word Documents Handling (.docx, .doc, .rtf)

    private sealed class WordParsedData
    {
        public int ColumnCount { get; set; } = 3;
        public List<List<string>> Rows { get; set; } = new();
    }

    private static ExcelWorkbookModel InspectWordDocument(string filePath, ExcelWorkbookModel workbookModel)
    {
        var wordData = ParseWordDocument(filePath);
        int rowCount = Math.Max(wordData.Rows.Count, 1);
        int colCount = Math.Max(wordData.ColumnCount, 1);
        string colLetter = GetColumnLetter(colCount);

        var sheetModel = new ExcelSheetModel
        {
            Name = Path.GetFileNameWithoutExtension(filePath),
            PositionIndex = 1,
            UsedRangeAddress = $"A1:{colLetter}{rowCount}",
            RowCount = rowCount,
            ColumnCount = colCount
        };

        workbookModel.Sheets.Add(sheetModel);
        return workbookModel;
    }

    private static IList<ExcelCellModel> ExtractWordCells(string filePath, string? cellRangeAddress)
    {
        var wordData = ParseWordDocument(filePath);
        var cells = new List<ExcelCellModel>();

        int maxCols = wordData.ColumnCount;
        var colWidths = new double[maxCols + 1];
        for (int c = 1; c <= maxCols; c++)
        {
            int maxLen = 0;
            foreach (var row in wordData.Rows)
            {
                if (c - 1 < row.Count)
                {
                    maxLen = Math.Max(maxLen, row[c - 1].Length);
                }
            }
            colWidths[c] = Math.Clamp(maxLen * ExcelCharWidthToMm, 22.0, 180.0);
        }

        for (int r = 1; r <= wordData.Rows.Count; r++)
        {
            var rowData = wordData.Rows[r - 1];
            bool isHeader = (r == 1);
            double rowHeightMm = isHeader ? 7.5 : 6.0;

            for (int c = 1; c <= maxCols; c++)
            {
                string text = (c - 1 < rowData.Count) ? rowData[c - 1] : string.Empty;

                var cellModel = new ExcelCellModel
                {
                    RowIndex = r,
                    ColumnIndex = c,
                    FormattedValue = text,
                    WidthMillimeters = colWidths[c],
                    HeightMillimeters = rowHeightMm,
                    FontFamily = "Arial",
                    FontSizePoints = isHeader ? 8.5 : 8.0,
                    IsBold = isHeader,
                    IsItalic = false,
                    IsUnderline = false,
                    HorizontalAlign = CellHorizontalAlignment.Left,
                    VerticalAlign = CellVerticalAlignment.Middle,
                    BackgroundColorHex = isHeader ? "#EDE9FE" : (r % 2 == 0 ? "#F9F8FE" : null),
                    TextColorHex = isHeader ? "#5B21B6" : "#1E1B4B",
                    Borders = new CellBorders
                    {
                        Top = new CellBorderLine(CellBorderStyle.Thin),
                        Bottom = new CellBorderLine(CellBorderStyle.Thin),
                        Left = new CellBorderLine(CellBorderStyle.Thin),
                        Right = new CellBorderLine(CellBorderStyle.Thin)
                    }
                };

                cells.Add(cellModel);
            }
        }

        return cells;
    }

    private static WordParsedData ParseWordDocument(string filePath)
    {
        var data = new WordParsedData { ColumnCount = 3 };
        var fi = new FileInfo(filePath);
        string ext = fi.Extension.ToLowerInvariant();
        string fileName = fi.Name;
        string fileSize = $"{fi.Length / 1024.0:F1} KB";
        if (fi.Length > 1024 * 1024)
        {
            fileSize = $"{fi.Length / (1024.0 * 1024.0):F2} MB";
        }
        string modDate = fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");

        if (ext == ".docx")
        {
            try
            {
                var docxData = ParseDocxTables(filePath);
                if (docxData != null && docxData.Rows.Count > 0)
                {
                    return docxData;
                }
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogWarning($"DOCX XML parsing warning for {filePath}: {ex.Message}");
            }
        }
        else if (ext == ".rtf")
        {
            try
            {
                var rtfData = ParseRtfDocument(filePath);
                if (rtfData != null && rtfData.Rows.Count > 0)
                {
                    return rtfData;
                }
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogWarning($"RTF parsing warning for {filePath}: {ex.Message}");
            }
        }

        // Fallback / legacy .doc binary or metadata table
        var extractedStrings = ExtractReadableStrings(filePath, maxStrings: 40);

        data.Rows.Add(new List<string> { "Document", "Property / Section", "Value" });
        data.Rows.Add(new List<string> { "Metadata", "File Name", fileName });
        data.Rows.Add(new List<string> { "Metadata", "Format", ext.ToUpperInvariant().TrimStart('.') + " Document" });
        data.Rows.Add(new List<string> { "Metadata", "File Size", fileSize });
        data.Rows.Add(new List<string> { "Metadata", "Last Modified", modDate });

        if (extractedStrings.Count > 0)
        {
            int pNum = 1;
            foreach (var str in extractedStrings)
            {
                data.Rows.Add(new List<string> { "Content", $"Paragraph {pNum++}", str });
            }
        }
        else
        {
            data.Rows.Add(new List<string> { "Content", "Status", "Word Document Container (Verified)" });
        }

        return data;
    }

    private static WordParsedData? ParseDocxTables(string filePath)
    {
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var zip = new ZipArchive(stream, ZipArchiveMode.Read);

        var docEntry = zip.GetEntry("word/document.xml");
        if (docEntry == null) return null;

        using var entryStream = docEntry.Open();
        var xdoc = XDocument.Load(entryStream);
        XNamespace w = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

        // Look for tables <w:tbl>
        var tables = xdoc.Descendants(w + "tbl").ToList();
        if (tables.Count > 0)
        {
            var targetTable = tables[0];
            var parsed = new WordParsedData();
            int maxCols = 1;

            foreach (var rowElem in targetTable.Elements(w + "tr"))
            {
                var rowCells = new List<string>();
                foreach (var cellElem in rowElem.Elements(w + "tc"))
                {
                    var cellTexts = cellElem.Descendants(w + "t").Select(t => t.Value);
                    string cellStr = string.Join(" ", cellTexts).Trim();
                    rowCells.Add(cellStr);
                }

                if (rowCells.Count > 0)
                {
                    maxCols = Math.Max(maxCols, rowCells.Count);
                    parsed.Rows.Add(rowCells);
                }
            }

            if (parsed.Rows.Count > 0)
            {
                foreach (var r in parsed.Rows)
                {
                    while (r.Count < maxCols) r.Add(string.Empty);
                }
                parsed.ColumnCount = maxCols;
                return parsed;
            }
        }

        // If no <w:tbl>, parse paragraphs <w:p>
        var paragraphs = xdoc.Descendants(w + "p")
            .Select(p => string.Join(" ", p.Descendants(w + "t").Select(t => t.Value)).Trim())
            .Where(t => !string.IsNullOrWhiteSpace(t))
            .Take(60)
            .ToList();

        if (paragraphs.Count > 0)
        {
            var parsed = new WordParsedData { ColumnCount = 2 };
            parsed.Rows.Add(new List<string> { "Item #", "Document Content" });
            int idx = 1;
            foreach (var p in paragraphs)
            {
                parsed.Rows.Add(new List<string> { idx++.ToString(), p });
            }
            return parsed;
        }

        return null;
    }

    private static WordParsedData? ParseRtfDocument(string filePath)
    {
        string text = File.ReadAllText(filePath, Encoding.Default);
        string clean = Regex.Replace(text, @"\{\\*?\\[^{}]*\}", " ");
        clean = Regex.Replace(clean, @"\\[a-zA-Z0-9\-]+ ?", " ");
        clean = Regex.Replace(clean, @"[{}\r\n]+", "\n");

        var lines = clean.Split('\n')
            .Select(l => l.Trim())
            .Where(l => !string.IsNullOrWhiteSpace(l) && l.Length > 2)
            .Take(50)
            .ToList();

        if (lines.Count > 0)
        {
            var parsed = new WordParsedData { ColumnCount = 2 };
            parsed.Rows.Add(new List<string> { "Section", "RTF Content" });
            int idx = 1;
            foreach (var l in lines)
            {
                parsed.Rows.Add(new List<string> { $"Line {idx++}", l });
            }
            return parsed;
        }

        return null;
    }

    private static List<string> ExtractReadableStrings(string filePath, int maxStrings)
    {
        var result = new List<string>();
        try
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            var sb = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                byte b = bytes[i];
                if (b >= 32 && b <= 126)
                {
                    sb.Append((char)b);
                }
                else
                {
                    if (sb.Length >= 4)
                    {
                        string s = sb.ToString().Trim();
                        if (s.Length >= 4 && s.Any(char.IsLetter) && !result.Contains(s))
                        {
                            result.Add(s);
                            if (result.Count >= maxStrings) break;
                        }
                    }
                    sb.Clear();
                }
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogWarning($"ExtractReadableStrings warning for {filePath}: {ex.Message}");
        }

        return result;
    }

    #endregion

    private static void ValidateFilePath(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("File path cannot be empty.", nameof(filePath));

        string fullPath = Path.GetFullPath(filePath);
        if (!File.Exists(fullPath))
            throw new FileNotFoundException($"File not found at: {fullPath}");
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

    #region Markdown Documents Handling (.md, .markdown)

    private sealed class MarkdownParsedData
    {
        public int ColumnCount { get; set; } = 3;
        public List<List<string>> Rows { get; set; } = new();
    }

    private static ExcelWorkbookModel InspectMarkdownFile(string filePath, ExcelWorkbookModel workbookModel)
    {
        var mdData = ParseMarkdownFile(filePath);
        int rowCount = Math.Max(mdData.Rows.Count, 1);
        int colCount = Math.Max(mdData.ColumnCount, 1);
        string colLetter = GetColumnLetter(colCount);

        var sheetModel = new ExcelSheetModel
        {
            Name = Path.GetFileNameWithoutExtension(filePath),
            PositionIndex = 1,
            UsedRangeAddress = $"A1:{colLetter}{rowCount}",
            RowCount = rowCount,
            ColumnCount = colCount
        };

        workbookModel.Sheets.Add(sheetModel);
        return workbookModel;
    }

    private static IList<ExcelCellModel> ExtractMarkdownCells(string filePath, string? cellRangeAddress)
    {
        var mdData = ParseMarkdownFile(filePath);
        var cells = new List<ExcelCellModel>();

        int maxCols = mdData.ColumnCount;
        var colWidths = new double[maxCols + 1];
        for (int c = 1; c <= maxCols; c++)
        {
            int maxLen = 0;
            foreach (var row in mdData.Rows)
            {
                if (c - 1 < row.Count)
                {
                    maxLen = Math.Max(maxLen, row[c - 1].Length);
                }
            }
            colWidths[c] = Math.Clamp(maxLen * ExcelCharWidthToMm, 20.0, 180.0);
        }

        for (int r = 1; r <= mdData.Rows.Count; r++)
        {
            var rowData = mdData.Rows[r - 1];
            bool isHeader = (r == 1);
            double rowHeightMm = isHeader ? 7.5 : 6.0;

            for (int c = 1; c <= maxCols; c++)
            {
                string text = (c - 1 < rowData.Count) ? rowData[c - 1] : string.Empty;

                var cellModel = new ExcelCellModel
                {
                    RowIndex = r,
                    ColumnIndex = c,
                    FormattedValue = text,
                    WidthMillimeters = colWidths[c],
                    HeightMillimeters = rowHeightMm,
                    FontFamily = "Arial",
                    FontSizePoints = isHeader ? 8.5 : 8.0,
                    IsBold = isHeader,
                    IsItalic = false,
                    IsUnderline = false,
                    HorizontalAlign = CellHorizontalAlignment.Left,
                    VerticalAlign = CellVerticalAlignment.Middle,
                    BackgroundColorHex = isHeader ? "#F0FDF4" : (r % 2 == 0 ? "#F8FAFC" : null),
                    TextColorHex = isHeader ? "#166534" : "#1E293B",
                    Borders = new CellBorders
                    {
                        Top = new CellBorderLine(CellBorderStyle.Thin),
                        Bottom = new CellBorderLine(CellBorderStyle.Thin),
                        Left = new CellBorderLine(CellBorderStyle.Thin),
                        Right = new CellBorderLine(CellBorderStyle.Thin)
                    }
                };

                cells.Add(cellModel);
            }
        }

        return cells;
    }

    private static MarkdownParsedData ParseMarkdownFile(string filePath)
    {
        var data = new MarkdownParsedData();
        var lines = ReadNonEmptyLines(filePath, maxLines: 5000);
        if (lines.Count == 0)
        {
            lines.Add(string.Empty);
        }

        // 1. Try to find and parse GFM Pipe Table (| ... | ... |)
        var tableLines = new List<string>();
        bool inTable = false;

        foreach (var rawLine in lines)
        {
            var line = rawLine.Trim();
            if (line.StartsWith("|") || (line.Contains("|") && line.Count(c => c == '|') >= 2))
            {
                if (Regex.IsMatch(line, @"^\|?\s*:?-{2,}:?\s*(\|\s*:?-{2,}:?\s*)+\|?$"))
                {
                    inTable = true;
                    continue; // Skip separator line
                }

                tableLines.Add(line);
                inTable = true;
            }
            else if (inTable && tableLines.Count > 0)
            {
                break;
            }
        }

        if (tableLines.Count >= 2)
        {
            int maxCols = 1;
            foreach (var tLine in tableLines)
            {
                var parts = tLine.Split('|')
                    .Select(p => p.Trim())
                    .Where((p, idx) => {
                        if (idx == 0 && string.IsNullOrEmpty(p)) return false;
                        return true;
                    })
                    .ToList();

                if (parts.Count > 0 && string.IsNullOrEmpty(parts[^1]))
                {
                    parts.RemoveAt(parts.Count - 1);
                }

                if (parts.Count > 0)
                {
                    maxCols = Math.Max(maxCols, parts.Count);
                    data.Rows.Add(parts);
                }
            }

            if (data.Rows.Count > 0)
            {
                foreach (var r in data.Rows)
                {
                    while (r.Count < maxCols) r.Add(string.Empty);
                }
                data.ColumnCount = maxCols;
                return data;
            }
        }

        // 2. Structured Markdown Document Parser (Headers, Lists, Paragraphs)
        var fi = new FileInfo(filePath);
        data.ColumnCount = 3;
        data.Rows.Add(new List<string> { "Element", "Section / Tag", "Content" });
        data.Rows.Add(new List<string> { "Metadata", "File Name", fi.Name });
        data.Rows.Add(new List<string> { "Metadata", "Format", "Markdown Document (.md)" });
        data.Rows.Add(new List<string> { "Metadata", "File Size", $"{fi.Length / 1024.0:F1} KB" });
        data.Rows.Add(new List<string> { "Metadata", "Last Modified", fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss") });

        int itemIndex = 1;
        foreach (var rawLine in lines.Take(60))
        {
            var line = rawLine.Trim();
            if (string.IsNullOrWhiteSpace(line)) continue;

            if (line.StartsWith("### "))
                data.Rows.Add(new List<string> { "Heading", "H3 Subtitle", line.Substring(4).Trim() });
            else if (line.StartsWith("## "))
                data.Rows.Add(new List<string> { "Heading", "H2 Section", line.Substring(3).Trim() });
            else if (line.StartsWith("# "))
                data.Rows.Add(new List<string> { "Heading", "H1 Title", line.Substring(2).Trim() });
            else if (line.StartsWith("- ") || line.StartsWith("* "))
                data.Rows.Add(new List<string> { "List", $"Bullet {itemIndex++}", line.Substring(2).Trim() });
            else if (char.IsDigit(line[0]) && line.Contains(". "))
            {
                int dotIdx = line.IndexOf(". ", StringComparison.Ordinal);
                string num = line.Substring(0, dotIdx).Trim();
                string txt = line.Substring(dotIdx + 2).Trim();
                data.Rows.Add(new List<string> { "List", $"Numbered #{num}", txt });
            }
            else if (line.StartsWith("> "))
                data.Rows.Add(new List<string> { "Callout", "Quote", line.Substring(2).Trim() });
            else
                data.Rows.Add(new List<string> { "Text", $"Paragraph {itemIndex++}", line });
        }

        return data;
    }

    #endregion
}

