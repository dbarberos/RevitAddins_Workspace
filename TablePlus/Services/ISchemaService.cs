using Autodesk.Revit.DB;
using TablePlus.Models;

namespace TablePlus.Services;

/// <summary>
/// Service managing Revit Extensible Storage schemas and entities for TablePlus.
/// Stamped on created drafting and legend views to track source spreadsheet provenance,
/// cell ranges, timestamps, and parameters for future synchronization.
/// </summary>
public interface ISchemaService
{
    /// <summary>
    /// Attaches TablePlus metadata (source file path, worksheet, cell range, timestamp, configuration JSON)
    /// to the target Revit View using Extensible Storage.
    /// MUST be called within an active Revit Transaction.
    /// </summary>
    /// <param name="view">The Revit drafting or legend view where the table is rendered.</param>
    /// <param name="config">The table configuration model.</param>
    /// <param name="sourceFilePath">The absolute or sanitized file path to the source Excel file.</param>
    void StampTableMetadata(View view, TableImportConfig config, string sourceFilePath);

    /// <summary>
    /// Reads and reconstructs the TableImportConfig stored in the Revit View's Extensible Storage entity.
    /// Returns null if no valid TablePlus entity is found on the view.
    /// </summary>
    /// <param name="view">The Revit view to inspect.</param>
    /// <returns>The restored TableImportConfig, or null if not stamped.</returns>
    TableImportConfig? ReadTableMetadata(View view);

    /// <summary>
    /// Checks whether the specified View has a valid TablePlus Extensible Storage entity attached.
    /// </summary>
    /// <param name="view">The Revit view to inspect.</param>
    /// <returns>True if a valid TablePlus entity is present; otherwise false.</returns>
    bool HasTableMetadata(View view);

    /// <summary>
    /// Retrieves the recorded source file path from the view's Extensible Storage.
    /// </summary>
    string? GetSourceFilePath(View view);

    /// <summary>
    /// Retrieves the recorded worksheet name from the view's Extensible Storage.
    /// </summary>
    string? GetWorksheetName(View view);

    /// <summary>
    /// Retrieves the recorded cell range string from the view's Extensible Storage.
    /// </summary>
    string? GetCellRange(View view);

    /// <summary>
    /// Retrieves the recorded import timestamp (UTC ISO 8601) from the view's Extensible Storage.
    /// </summary>
    string? GetTimestampUtc(View view);

    /// <summary>
    /// Removes the TablePlus Extensible Storage entity from the specified View, unlinking it.
    /// MUST be called within an active Revit Transaction.
    /// </summary>
    /// <param name="view">The Revit view to unlink.</param>
    void RemoveTableMetadata(View view);
}
