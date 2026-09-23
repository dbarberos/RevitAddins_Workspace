using Autodesk.Revit.DB;
using TablePlus.Models;

namespace TablePlus.Services;

/// <summary>
/// Service managing the discovery, inspection, and lifecycle of TablePlus tables in a Revit document.
/// </summary>
public interface ITableRegistryService
{
    /// <summary>
    /// Scans the Revit Document for all Drafting and Legend views stamped with TablePlus metadata,
    /// verifies disk file timestamps, discovers available sheets, and returns populated TableItemModels.
    /// </summary>
    /// <param name="doc">The active Revit Document.</param>
    /// <returns>A list of discovered TableItemModels.</returns>
    Task<IList<TableItemModel>> DiscoverTablesAsync(Document doc);

    /// <summary>
    /// Refreshes the synchronization status, disk timestamps, and available worksheets for a specific table item.
    /// </summary>
    /// <param name="item">The table item model to refresh.</param>
    Task RefreshItemStatusAsync(TableItemModel item);

    /// <summary>
    /// Deletes the table view or unlinks TablePlus metadata from the Revit Document.
    /// MUST be called within an active Revit Transaction.
    /// </summary>
    /// <param name="doc">The active Revit Document.</param>
    /// <param name="item">The table item model to delete or unlink.</param>
    /// <param name="deleteView">If true, permanently deletes the Revit view element; if false, removes Extensible Storage metadata while preserving view graphics.</param>
    /// <returns>True if operation succeeded; otherwise false.</returns>
    bool DeleteOrUnlinkTable(Document doc, TableItemModel item, bool deleteView);
}
