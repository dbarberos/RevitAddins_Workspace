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

    /// <summary>
    /// Updates an existing Drafting View or Legend View in place, deleting previous table curves,
    /// fills, and text notes, and regenerating the updated table graphics.
    /// MUST be called within an active Revit Transaction.
    /// </summary>
    void UpdateTableInView(
        Document doc,
        View targetView,
        TableImportConfig config,
        IList<ExcelCellModel> cells,
        IList<MergedCellRange> mergedRanges);
}
