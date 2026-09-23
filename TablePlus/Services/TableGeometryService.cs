using System.Globalization;
using Autodesk.Revit.DB;
using TablePlus.Models;

namespace TablePlus.Services;

/// <summary>
/// Engine responsible for instantiating Revit 2D vector elements (curves, text notes, filled regions)
/// within newly created Drafting or Legend views.
/// </summary>
public class TableGeometryService : ITableGeometryService
{
    private const double MmToFeet = 1.0 / 304.8;
    private readonly ISchemaService _schemaService;

    public TableGeometryService(ISchemaService? schemaService = null)
    {
        _schemaService = schemaService ?? new SchemaService();
    }

    public View GenerateTable(
        Document doc,
        TableImportConfig config,
        IList<ExcelCellModel> cells,
        IList<MergedCellRange> mergedRanges)
    {
        if (doc == null) throw new ArgumentNullException(nameof(doc));
        if (config == null) throw new ArgumentNullException(nameof(config));
        if (cells == null || cells.Count == 0) throw new ArgumentException("Cell list cannot be empty.", nameof(cells));

        using var tx = new Transaction(doc, $"TablePlus: Import {config.ViewName}");
        var failureOpts = tx.GetFailureHandlingOptions();
        failureOpts.SetFailuresPreprocessor(new WarningSwallower());
        tx.SetFailureHandlingOptions(failureOpts);

        tx.Start();

        // 1. Create target view
        var view = CreateTargetView(doc, config);

        // 2. Pre-calculate coordinate maps (Columns -> X, Rows -> Y)
        var scale = Math.Max(config.ViewScale, 1);
        var (colXMap, colWidthMap) = BuildColumnCoordinates(cells, scale);
        var (rowYMap, rowHeightMap) = BuildRowCoordinates(cells, scale);

        // 3. Obtain necessary Revit Element Types
        var textNoteTypeId = doc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);
        var solidFillPattern = GetSolidFillPattern(doc);
        var solidFilledRegionType = GetSolidFilledRegionType(doc);
        var lineStyleId = GetLineStyleId(doc, "<Thin Lines>");

        // 4. Render Cell Background Shading (FilledRegions)
        if (!config.BlackAndWhiteMode && config.PreserveBackgroundFills && solidFilledRegionType != null)
        {
            RenderCellFills(doc, view, cells, colXMap, rowYMap, colWidthMap, rowHeightMap, solidFilledRegionType, solidFillPattern);
        }

        // 5. Render Cell Borders (DetailCurves)
        RenderCellBorders(doc, view, cells, colXMap, rowYMap, colWidthMap, rowHeightMap, lineStyleId);

        // 6. Render Cell TextNotes
        RenderCellTexts(doc, view, cells, colXMap, rowYMap, colWidthMap, rowHeightMap, textNoteTypeId, scale);

        // 7. Stamp Extensible Storage Metadata for tracking and future sync
        _schemaService.StampTableMetadata(view, config, config.SourceFilePath);

        doc.Regenerate();
        tx.Commit();

        return view;
    }

    private static View CreateTargetView(Document doc, TableImportConfig config)
    {
        ViewFamily targetFamily = config.TargetViewType == TargetViewType.LegendView 
            ? ViewFamily.Legend 
            : ViewFamily.Drafting;

        var viewFamilyType = new FilteredElementCollector(doc)
            .OfClass(typeof(ViewFamilyType))
            .Cast<ViewFamilyType>()
            .FirstOrDefault(vft => vft.ViewFamily == targetFamily);

        if (viewFamilyType == null && config.TargetViewType == TargetViewType.LegendView)
        {
            // Fallback to drafting if legend family type not directly resolvable
            viewFamilyType = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewFamilyType))
                .Cast<ViewFamilyType>()
                .FirstOrDefault(vft => vft.ViewFamily == ViewFamily.Drafting);
        }

        if (viewFamilyType == null)
            throw new InvalidOperationException("Could not find a valid ViewFamilyType for Drafting/Legend views.");

        var view = ViewDrafting.Create(doc, viewFamilyType.Id);
        view.Name = GetUniqueViewName(doc, config.ViewName);
        view.Scale = Math.Max(config.ViewScale, 1);

        return view;
    }

    private static string GetUniqueViewName(Document doc, string requestedName)
    {
        string baseName = string.IsNullOrWhiteSpace(requestedName) ? "Table" : requestedName.Trim();
        string candidate = baseName;
        int counter = 1;

        var existingNames = new HashSet<string>(
            new FilteredElementCollector(doc)
                .OfClass(typeof(View))
                .Cast<View>()
                .Select(v => v.Name),
            StringComparer.OrdinalIgnoreCase);

        while (existingNames.Contains(candidate))
        {
            candidate = $"{baseName} ({counter++})";
        }

        return candidate;
    }

    private static (Dictionary<int, double> xMap, Dictionary<int, double> widthMap) BuildColumnCoordinates(
        IList<ExcelCellModel> cells, int scale)
    {
        var colWidths = new Dictionary<int, double>();
        foreach (var c in cells)
        {
            if (!colWidths.ContainsKey(c.ColumnIndex))
            {
                // In Revit, 1 mm on paper at scale S = mm * MmToFeet * S in model coordinates
                colWidths[c.ColumnIndex] = Math.Max(c.WidthMillimeters * MmToFeet * scale, 0.01);
            }
        }

        var sortedCols = colWidths.Keys.OrderBy(k => k).ToList();
        var xMap = new Dictionary<int, double>();
        double currentX = 0;

        foreach (var col in sortedCols)
        {
            xMap[col] = currentX;
            currentX += colWidths[col];
        }

        return (xMap, colWidths);
    }

    private static (Dictionary<int, double> yMap, Dictionary<int, double> heightMap) BuildRowCoordinates(
        IList<ExcelCellModel> cells, int scale)
    {
        var rowHeights = new Dictionary<int, double>();
        foreach (var c in cells)
        {
            if (!rowHeights.ContainsKey(c.RowIndex))
            {
                rowHeights[c.RowIndex] = Math.Max(c.HeightMillimeters * MmToFeet * scale, 0.01);
            }
        }

        var sortedRows = rowHeights.Keys.OrderBy(k => k).ToList();
        var yMap = new Dictionary<int, double>();
        double currentY = 0;

        foreach (var row in sortedRows)
        {
            yMap[row] = currentY; // Top of row
            currentY -= rowHeights[row]; // Moves downward
        }

        return (yMap, rowHeights);
    }

    private static void RenderCellFills(
        Document doc,
        View view,
        IList<ExcelCellModel> cells,
        Dictionary<int, double> colXMap,
        Dictionary<int, double> rowYMap,
        Dictionary<int, double> colWidthMap,
        Dictionary<int, double> rowHeightMap,
        FilledRegionType regionType,
        FillPatternElement? solidPattern)
    {
        foreach (var cell in cells)
        {
            if (string.IsNullOrWhiteSpace(cell.BackgroundColorHex)) continue;
            if (cell.IsMerged && !cell.IsMergeMaster) continue;

            if (!colXMap.TryGetValue(cell.ColumnIndex, out double x1)) continue;
            if (!rowYMap.TryGetValue(cell.RowIndex, out double yTop)) continue;

            double width = cell.IsMergeMaster && cell.MergeRange != null
                ? ComputeMergeWidth(cell.MergeRange, colWidthMap)
                : colWidthMap[cell.ColumnIndex];

            double height = cell.IsMergeMaster && cell.MergeRange != null
                ? ComputeMergeHeight(cell.MergeRange, rowHeightMap)
                : rowHeightMap[cell.RowIndex];

            double x2 = x1 + width;
            double yBottom = yTop - height;

            try
            {
                var p1 = new XYZ(x1, yBottom, 0);
                var p2 = new XYZ(x2, yBottom, 0);
                var p3 = new XYZ(x2, yTop, 0);
                var p4 = new XYZ(x1, yTop, 0);

                var loop = new CurveLoop();
                loop.Append(Line.CreateBound(p1, p2));
                loop.Append(Line.CreateBound(p2, p3));
                loop.Append(Line.CreateBound(p3, p4));
                loop.Append(Line.CreateBound(p4, p1));

                var region = FilledRegion.Create(doc, regionType.Id, view.Id, new List<CurveLoop> { loop });

                if (TryParseHexColor(cell.BackgroundColorHex, out var revitColor))
                {
                    var ogs = new OverrideGraphicSettings();
                    ogs.SetSurfaceForegroundPatternColor(revitColor);
                    if (solidPattern != null)
                    {
                        ogs.SetSurfaceForegroundPatternId(solidPattern.Id);
                    }
                    view.SetElementOverrides(region.Id, ogs);
                }
            }
            catch
            {
                // Silently skip corrupted cell boundary loops
            }
        }
    }

    private static void RenderCellBorders(
        Document doc,
        View view,
        IList<ExcelCellModel> cells,
        Dictionary<int, double> colXMap,
        Dictionary<int, double> rowYMap,
        Dictionary<int, double> colWidthMap,
        Dictionary<int, double> rowHeightMap,
        ElementId lineStyleId)
    {
        var drawnSegments = new HashSet<string>();

        foreach (var cell in cells)
        {
            if (cell.IsMerged && !cell.IsMergeMaster) continue;

            if (!colXMap.TryGetValue(cell.ColumnIndex, out double x1)) continue;
            if (!rowYMap.TryGetValue(cell.RowIndex, out double yTop)) continue;

            double width = cell.IsMergeMaster && cell.MergeRange != null
                ? ComputeMergeWidth(cell.MergeRange, colWidthMap)
                : colWidthMap[cell.ColumnIndex];

            double height = cell.IsMergeMaster && cell.MergeRange != null
                ? ComputeMergeHeight(cell.MergeRange, rowHeightMap)
                : rowHeightMap[cell.RowIndex];

            double x2 = x1 + width;
            double yBottom = yTop - height;

            // Draw bounding segments (Top, Bottom, Left, Right)
            DrawUniqueLine(doc, view, new XYZ(x1, yTop, 0), new XYZ(x2, yTop, 0), lineStyleId, drawnSegments);
            DrawUniqueLine(doc, view, new XYZ(x1, yBottom, 0), new XYZ(x2, yBottom, 0), lineStyleId, drawnSegments);
            DrawUniqueLine(doc, view, new XYZ(x1, yBottom, 0), new XYZ(x1, yTop, 0), lineStyleId, drawnSegments);
            DrawUniqueLine(doc, view, new XYZ(x2, yBottom, 0), new XYZ(x2, yTop, 0), lineStyleId, drawnSegments);
        }
    }

    private static void DrawUniqueLine(
        Document doc,
        View view,
        XYZ start,
        XYZ end,
        ElementId lineStyleId,
        HashSet<string> drawnSegments)
    {
        // Normalize segment key to eliminate duplicate overlays
        string key = start.X < end.X || (Math.Abs(start.X - end.X) < 1e-6 && start.Y < end.Y)
            ? $"{start.X:F4},{start.Y:F4}->{end.X:F4},{end.Y:F4}"
            : $"{end.X:F4},{end.Y:F4}->{start.X:F4},{start.Y:F4}";

        if (drawnSegments.Contains(key)) return;
        drawnSegments.Add(key);

        if (start.DistanceTo(end) < 1e-4) return;

        try
        {
            var line = Line.CreateBound(start, end);
            var curve = doc.Create.NewDetailCurve(view, line);
            if (lineStyleId != ElementId.InvalidElementId)
            {
                curve.LineStyle = doc.GetElement(lineStyleId);
            }
        }
        catch
        {
            // Suppress benign geometry errors
        }
    }

    private static void RenderCellTexts(
        Document doc,
        View view,
        IList<ExcelCellModel> cells,
        Dictionary<int, double> colXMap,
        Dictionary<int, double> rowYMap,
        Dictionary<int, double> colWidthMap,
        Dictionary<int, double> rowHeightMap,
        ElementId textNoteTypeId,
        int scale)
    {
        foreach (var cell in cells)
        {
            if (string.IsNullOrWhiteSpace(cell.FormattedValue)) continue;
            if (cell.IsMerged && !cell.IsMergeMaster) continue;

            if (!colXMap.TryGetValue(cell.ColumnIndex, out double x1)) continue;
            if (!rowYMap.TryGetValue(cell.RowIndex, out double yTop)) continue;

            double width = cell.IsMergeMaster && cell.MergeRange != null
                ? ComputeMergeWidth(cell.MergeRange, colWidthMap)
                : colWidthMap[cell.ColumnIndex];

            double height = cell.IsMergeMaster && cell.MergeRange != null
                ? ComputeMergeHeight(cell.MergeRange, rowHeightMap)
                : rowHeightMap[cell.RowIndex];

            double x2 = x1 + width;
            double yBottom = yTop - height;

            double margin = Math.Max(0.5 * MmToFeet * scale, 0.002);
            double insertX = cell.HorizontalAlign switch
            {
                CellHorizontalAlignment.Center => (x1 + x2) / 2.0,
                CellHorizontalAlignment.Right => x2 - margin,
                _ => x1 + margin
            };

            double insertY = cell.VerticalAlign switch
            {
                CellVerticalAlignment.Top => yTop - margin,
                CellVerticalAlignment.Bottom => yBottom + margin,
                _ => (yTop + yBottom) / 2.0
            };

            try
            {
                var opts = new TextNoteOptions(textNoteTypeId)
                {
                    HorizontalAlignment = cell.HorizontalAlign switch
                    {
                        CellHorizontalAlignment.Center => HorizontalTextAlignment.Center,
                        CellHorizontalAlignment.Right => HorizontalTextAlignment.Right,
                        _ => HorizontalTextAlignment.Left
                    },
                    VerticalAlignment = cell.VerticalAlign switch
                    {
                        CellVerticalAlignment.Top => VerticalTextAlignment.Top,
                        CellVerticalAlignment.Bottom => VerticalTextAlignment.Bottom,
                        _ => VerticalTextAlignment.Middle
                    }
                };

                double textBlockWidth = Math.Max(width - (margin * 2), 0.02);
                TextNote.Create(doc, view.Id, new XYZ(insertX, insertY, 0), textBlockWidth, cell.FormattedValue, opts);
            }
            catch
            {
                // Silently skip unrenderable text notes
            }
        }
    }

    private static double ComputeMergeWidth(MergedCellRange merge, Dictionary<int, double> colWidthMap)
    {
        double sum = 0;
        for (int c = merge.StartColumn; c <= merge.EndColumn; c++)
        {
            if (colWidthMap.TryGetValue(c, out double w)) sum += w;
        }
        return sum;
    }

    private static double ComputeMergeHeight(MergedCellRange merge, Dictionary<int, double> rowHeightMap)
    {
        double sum = 0;
        for (int r = merge.StartRow; r <= merge.EndRow; r++)
        {
            if (rowHeightMap.TryGetValue(r, out double h)) sum += h;
        }
        return sum;
    }

    private static FilledRegionType? GetSolidFilledRegionType(Document doc) =>
        new FilteredElementCollector(doc)
            .OfClass(typeof(FilledRegionType))
            .Cast<FilledRegionType>()
            .FirstOrDefault(frt => frt.Name.Contains("Solid", StringComparison.OrdinalIgnoreCase)) ??
        new FilteredElementCollector(doc)
            .OfClass(typeof(FilledRegionType))
            .Cast<FilledRegionType>()
            .FirstOrDefault();

    private static FillPatternElement? GetSolidFillPattern(Document doc) =>
        new FilteredElementCollector(doc)
            .OfClass(typeof(FillPatternElement))
            .Cast<FillPatternElement>()
            .FirstOrDefault(fpe =>
            {
                var fp = fpe.GetFillPattern();
                return fp != null && fp.IsSolidFill && fp.Target == FillPatternTarget.Drafting;
            }) ??
        new FilteredElementCollector(doc)
            .OfClass(typeof(FillPatternElement))
            .Cast<FillPatternElement>()
            .FirstOrDefault(fpe =>
            {
                var fp = fpe.GetFillPattern();
                return fp != null && fp.IsSolidFill;
            });

    private static ElementId GetLineStyleId(Document doc, string lineStyleName)
    {
        var lineCategory = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
        if (lineCategory?.SubCategories.Contains(lineStyleName) == true)
        {
            return lineCategory.SubCategories.get_Item(lineStyleName).Id;
        }
        return ElementId.InvalidElementId;
    }

    private static bool TryParseHexColor(string? hex, out Color color)
    {
        color = new Color(0, 0, 0);
        if (string.IsNullOrWhiteSpace(hex)) return false;

        string clean = hex!.TrimStart('#');
        if (clean.Length == 6 &&
            byte.TryParse(clean[..2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte r) &&
            byte.TryParse(clean[2..4], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte g) &&
            byte.TryParse(clean[4..6], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte b))
        {
            color = new Color(r, g, b);
            return true;
        }

        return false;
    }
}
