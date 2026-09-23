using System.Globalization;
using Autodesk.Revit.DB;
using TablePlus.Models;

namespace TablePlus.Services;

/// <summary>
/// Engine responsible for instantiating Revit 2D vector elements (curves, text notes, filled regions)
/// within newly created or updated Drafting or Legend views.
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

        // 2. Render table contents
        RenderTableContents(doc, view, config, cells, mergedRanges);

        // 3. Stamp Extensible Storage Metadata for tracking and future sync
        _schemaService.StampTableMetadata(view, config, config.SourceFilePath);

        doc.Regenerate();
        tx.Commit();

        return view;
    }

    public void UpdateTableInView(
        Document doc,
        View targetView,
        TableImportConfig config,
        IList<ExcelCellModel> cells,
        IList<MergedCellRange> mergedRanges)
    {
        if (doc == null) throw new ArgumentNullException(nameof(doc));
        if (targetView == null) throw new ArgumentNullException(nameof(targetView));
        if (config == null) throw new ArgumentNullException(nameof(config));
        if (cells == null || cells.Count == 0) throw new ArgumentException("Cell list cannot be empty.", nameof(cells));

        if (doc.IsModifiable)
        {
            ExecuteUpdateTableInView(doc, targetView, config, cells, mergedRanges);
        }
        else
        {
            using var tx = new Transaction(doc, $"TablePlus: Update {targetView.Name}");
            var failureOpts = tx.GetFailureHandlingOptions();
            failureOpts.SetFailuresPreprocessor(new WarningSwallower());
            tx.SetFailureHandlingOptions(failureOpts);

            tx.Start();
            ExecuteUpdateTableInView(doc, targetView, config, cells, mergedRanges);
            tx.Commit();
        }
    }

    private void ExecuteUpdateTableInView(
        Document doc,
        View targetView,
        TableImportConfig config,
        IList<ExcelCellModel> cells,
        IList<MergedCellRange> mergedRanges)
    {
        // 1. Clean out existing 2D detail elements in targetView
        var elementsToDelete = new FilteredElementCollector(doc, targetView.Id)
            .WherePasses(new ElementMulticlassFilter(new List<Type>
            {
                typeof(CurveElement),
                typeof(FilledRegion),
                typeof(TextNote)
            }))
            .Select(e => e.Id)
            .ToList();

        if (elementsToDelete.Count > 0)
        {
            doc.Delete(elementsToDelete);
        }

        // 2. Update view scale
        targetView.Scale = Math.Max(config.ViewScale, 1);

        // 3. Re-render table contents
        RenderTableContents(doc, targetView, config, cells, mergedRanges);

        // 4. Update Extensible Storage metadata
        _schemaService.StampTableMetadata(targetView, config, config.SourceFilePath);

        doc.Regenerate();
    }

    private void RenderTableContents(
        Document doc,
        View view,
        TableImportConfig config,
        IList<ExcelCellModel> cells,
        IList<MergedCellRange> mergedRanges)
    {
        // 1. Pre-calculate coordinate maps (Columns -> X, Rows -> Y)
        var scale = Math.Max(config.ViewScale, 1);
        var (colXMap, colWidthMap) = BuildColumnCoordinates(cells, scale);
        var (rowYMap, rowHeightMap) = BuildRowCoordinates(cells, scale);

        // 2. Identify header row index (topmost row among cells)
        int headerRowIndex = cells.Min(c => c.RowIndex);

        // 3. Obtain necessary Revit Element Types
        var bodyTextNoteTypeId = ResolveTextNoteType(doc, config.BodyTextNoteTypeName);
        var headerTextNoteTypeId = (config.HeaderCustomStyleEnabled && !string.IsNullOrWhiteSpace(config.HeaderTextNoteTypeName))
            ? ResolveTextNoteType(doc, config.HeaderTextNoteTypeName)
            : bodyTextNoteTypeId;

        var solidFillPattern = GetSolidFillPattern(doc);
        var solidFilledRegionType = GetSolidFilledRegionType(doc);

        // 4. Resolve Line Style (respecting B&W mode)
        ElementId lineStyleId = ElementId.InvalidElementId;
        if (!config.BlackAndWhiteMode && !string.IsNullOrWhiteSpace(config.GridLineStyleName))
        {
            lineStyleId = GetLineStyleId(doc, config.GridLineStyleName);
        }
        if (lineStyleId == ElementId.InvalidElementId)
        {
            lineStyleId = GetLineStyleId(doc, "<Thin Lines>");
        }

        // 5. Render Cell Background Shading (FilledRegions)
        if (!config.BlackAndWhiteMode && solidFilledRegionType != null)
        {
            RenderCellFills(
                doc,
                view,
                cells,
                colXMap,
                rowYMap,
                colWidthMap,
                rowHeightMap,
                solidFilledRegionType,
                solidFillPattern,
                config,
                headerRowIndex);
        }

        // 6. Render Cell Borders (DetailCurves)
        RenderCellBorders(doc, view, cells, colXMap, rowYMap, colWidthMap, rowHeightMap, lineStyleId, config.BlackAndWhiteMode);

        // 7. Render Cell TextNotes
        RenderCellTexts(
            doc,
            view,
            cells,
            colXMap,
            rowYMap,
            colWidthMap,
            rowHeightMap,
            bodyTextNoteTypeId,
            headerTextNoteTypeId,
            scale,
            config,
            headerRowIndex);
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
        FillPatternElement? solidPattern,
        TableImportConfig config,
        int headerRowIndex)
    {
        foreach (var cell in cells)
        {
            if (cell.IsMerged && !cell.IsMergeMaster) continue;

            string? fillHex = null;

            // Check if header row override applies
            if (config.HeaderCustomStyleEnabled &&
                cell.RowIndex == headerRowIndex &&
                !string.IsNullOrWhiteSpace(config.HeaderFillColorHex))
            {
                fillHex = config.HeaderFillColorHex;
            }
            else if (config.PreserveBackgroundFills && !string.IsNullOrWhiteSpace(cell.BackgroundColorHex))
            {
                fillHex = cell.BackgroundColorHex;
            }

            if (string.IsNullOrWhiteSpace(fillHex)) continue;

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

                if (TryParseHexColor(fillHex, out var revitColor))
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
        ElementId lineStyleId,
        bool isBlackAndWhite)
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
            DrawUniqueLine(doc, view, new XYZ(x1, yTop, 0), new XYZ(x2, yTop, 0), lineStyleId, drawnSegments, isBlackAndWhite);
            DrawUniqueLine(doc, view, new XYZ(x1, yBottom, 0), new XYZ(x2, yBottom, 0), lineStyleId, drawnSegments, isBlackAndWhite);
            DrawUniqueLine(doc, view, new XYZ(x1, yBottom, 0), new XYZ(x1, yTop, 0), lineStyleId, drawnSegments, isBlackAndWhite);
            DrawUniqueLine(doc, view, new XYZ(x2, yBottom, 0), new XYZ(x2, yTop, 0), lineStyleId, drawnSegments, isBlackAndWhite);
        }
    }

    private static void DrawUniqueLine(
        Document doc,
        View view,
        XYZ start,
        XYZ end,
        ElementId lineStyleId,
        HashSet<string> drawnSegments,
        bool isBlackAndWhite)
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

            if (isBlackAndWhite)
            {
                var ogs = new OverrideGraphicSettings();
                ogs.SetProjectionLineColor(new Color(0, 0, 0));
                view.SetElementOverrides(curve.Id, ogs);
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
        ElementId bodyTextNoteTypeId,
        ElementId headerTextNoteTypeId,
        int scale,
        TableImportConfig config,
        int headerRowIndex)
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

            bool isHeader = cell.RowIndex == headerRowIndex;
            ElementId noteTypeId = (isHeader && config.HeaderCustomStyleEnabled)
                ? headerTextNoteTypeId
                : bodyTextNoteTypeId;

            try
            {
                var opts = new TextNoteOptions(noteTypeId)
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
                var note = TextNote.Create(doc, view.Id, new XYZ(insertX, insertY, 0), textBlockWidth, cell.FormattedValue, opts);

                // Apply text color overrides
                if (config.BlackAndWhiteMode)
                {
                    var ogs = new OverrideGraphicSettings();
                    ogs.SetProjectionLineColor(new Color(0, 0, 0));
                    view.SetElementOverrides(note.Id, ogs);
                }
                else if (isHeader && config.HeaderCustomStyleEnabled && !string.IsNullOrWhiteSpace(config.HeaderTextColorHex))
                {
                    if (TryParseHexColor(config.HeaderTextColorHex, out var headerColor))
                    {
                        var ogs = new OverrideGraphicSettings();
                        ogs.SetProjectionLineColor(headerColor);
                        view.SetElementOverrides(note.Id, ogs);
                    }
                }
                else if (!string.IsNullOrWhiteSpace(cell.TextColorHex) && TryParseHexColor(cell.TextColorHex, out var fontColor))
                {
                    var ogs = new OverrideGraphicSettings();
                    ogs.SetProjectionLineColor(fontColor);
                    view.SetElementOverrides(note.Id, ogs);
                }
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

    private static ElementId ResolveTextNoteType(Document doc, string? typeName)
    {
        if (!string.IsNullOrWhiteSpace(typeName))
        {
            var match = new FilteredElementCollector(doc)
                .OfClass(typeof(TextNoteType))
                .Cast<TextNoteType>()
                .FirstOrDefault(tnt => tnt.Name.Equals(typeName, StringComparison.OrdinalIgnoreCase));
            if (match != null) return match.Id;
        }

        return doc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);
    }

    private static ElementId GetLineStyleId(Document doc, string? lineStyleName)
    {
        if (string.IsNullOrWhiteSpace(lineStyleName)) return ElementId.InvalidElementId;

        var lineCategory = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
        if (lineCategory != null)
        {
            if (lineCategory.SubCategories.Contains(lineStyleName))
            {
                return lineCategory.SubCategories.get_Item(lineStyleName).Id;
            }

            foreach (Category subCat in lineCategory.SubCategories)
            {
                if (string.Equals(subCat.Name, lineStyleName, StringComparison.OrdinalIgnoreCase))
                {
                    return subCat.Id;
                }
            }
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
