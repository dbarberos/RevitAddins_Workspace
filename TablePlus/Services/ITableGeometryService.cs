using Autodesk.Revit.DB;
using TablePlus.Models;

namespace TablePlus.Services;

/// <summary>
/// Contract for transforming extracted Excel cell data into native Revit vector views and geometry.
/// </summary>
public interface ITableGeometryService
{
    /// <summary>
    /// Generates a native Drafting View or Legend View containing detail curves, text notes, and filled regions.
    /// </summary>
    View GenerateTable(
        Document doc,
        TableImportConfig config,
        IList<ExcelCellModel> cells,
        IList<MergedCellRange> mergedRanges);
}
