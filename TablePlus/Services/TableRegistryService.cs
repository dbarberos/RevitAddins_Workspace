using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using Autodesk.Revit.DB;
using TablePlus.Models;

namespace TablePlus.Services;

/// <summary>
/// Implementation of ITableRegistryService for discovering, inspecting,
/// and managing the lifecycle of TablePlus tables in an Autodesk Revit Document.
/// </summary>
public class TableRegistryService : ITableRegistryService
{
    private readonly ISchemaService _schemaService;
    private readonly IExcelReaderService _excelReaderService;

    public TableRegistryService(ISchemaService? schemaService = null, IExcelReaderService? excelReaderService = null)
    {
        _schemaService = schemaService ?? new SchemaService();
        _excelReaderService = excelReaderService ?? new ExcelReaderService();
    }

    /// <inheritdoc />
    public async Task<IList<TableItemModel>> DiscoverTablesAsync(Document doc)
    {
        if (doc == null) return [];

        var discoveredItems = new List<TableItemModel>();

        // 1. Query candidate Drafting and Legend views
        var candidateViews = new FilteredElementCollector(doc)
            .OfClass(typeof(View))
            .Cast<View>()
            .Where(v => !v.IsTemplate && (v.ViewType == ViewType.DraftingView || v.ViewType == ViewType.Legend))
            .ToList();

        foreach (var view in candidateViews)
        {
            if (!_schemaService.HasTableMetadata(view)) continue;

            var config = _schemaService.ReadTableMetadata(view);
            if (config == null) continue;

#if REVIT2024_OR_GREATER
            long viewIdVal = view.Id.Value;
#else
            long viewIdVal = view.Id.IntegerValue;
#endif

            string filePath = config.SourceFilePath;
            string fileName = !string.IsNullOrWhiteSpace(filePath)
                ? Path.GetFileName(filePath)
                : "Unknown.xlsx";

            // Infer source type from file extension if not explicitly set
            var sourceType = config.SourceType;
            if (sourceType == TableSourceType.ExcelXlsx && !string.IsNullOrWhiteSpace(filePath))
            {
                var ext = Path.GetExtension(filePath).ToLowerInvariant();
                if (ext == ".xlsm") sourceType = TableSourceType.ExcelXlsm;
                else if (ext == ".csv") sourceType = TableSourceType.Csv;
            }

            var item = new TableItemModel
            {
                ViewId = viewIdVal,
                ViewName = view.Name,
                ViewType = config.TargetViewType,
                ViewScale = config.ViewScale > 0 ? config.ViewScale : (view.Scale > 0 ? view.Scale : 1),
                SourceFilePath = filePath,
                SourceFileName = fileName,
                SelectedSheetName = config.SelectedSheetName,
                CellRangeAddress = config.RangeMode switch
                {
                    CellRangeSelectionMode.CustomRange => config.CustomRangeAddress ?? string.Empty,
                    CellRangeSelectionMode.NamedRange => config.SelectedNamedRange ?? string.Empty,
                    _ => "EntireSheet"
                },
                SourceType = sourceType,
                IsAutoSyncEnabled = config.IsAutoSyncEnabled,
                IsBlackAndWhite = config.BlackAndWhiteMode,
                Config = config
            };

            // Evaluate live file status and sheet catalog
            await RefreshItemStatusAsync(item).ConfigureAwait(false);

            discoveredItems.Add(item);
        }

        return discoveredItems;
    }

    /// <inheritdoc />
    public async Task RefreshItemStatusAsync(TableItemModel item)
    {
        if (item == null) return;

        string filePath = item.SourceFilePath;
        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            item.Status = TableSyncStatus.FileNotFound;
            item.StatusTooltip = string.IsNullOrWhiteSpace(filePath)
                ? "No source file path specified."
                : $"Source file not found at: {filePath}";

            if (item.AvailableSheets.Count == 0 && !string.IsNullOrWhiteSpace(item.SelectedSheetName))
            {
                item.AvailableSheets.Add(item.SelectedSheetName);
            }
            return;
        }

        try
        {
            var fileInfo = new FileInfo(filePath);
            DateTime lastWriteUtc = fileInfo.LastWriteTimeUtc;

            if (!string.IsNullOrWhiteSpace(item.Config.LastImportedTimestampUtc) &&
                DateTime.TryParse(item.Config.LastImportedTimestampUtc, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var lastSyncUtc))
            {
                // 2-second tolerance for file system write timestamp variance
                if (lastWriteUtc > lastSyncUtc.AddSeconds(2))
                {
                    item.Status = TableSyncStatus.Modified;
                    item.StatusTooltip = $"Source file was modified on {fileInfo.LastWriteTime:yyyy-MM-dd HH:mm:ss} (Out of date).";
                }
                else
                {
                    item.Status = TableSyncStatus.UpToDate;
                    item.StatusTooltip = $"Synchronized with source file ({fileInfo.LastWriteTime:yyyy-MM-dd HH:mm:ss}).";
                }
            }
            else
            {
                item.Status = TableSyncStatus.UpToDate;
                item.StatusTooltip = "Table is synchronized.";
            }

            // Discover available worksheets asynchronously
            var workbook = await Task.Run(() => _excelReaderService.InspectWorkbook(filePath)).ConfigureAwait(false);
            if (workbook?.Sheets != null && workbook.Sheets.Count > 0)
            {
                var newSheets = new ObservableCollection<string>();
                foreach (var sheet in workbook.Sheets)
                {
                    newSheets.Add(sheet.Name);
                }

                // If selected sheet not in catalog, append it
                if (!string.IsNullOrWhiteSpace(item.SelectedSheetName) && !newSheets.Contains(item.SelectedSheetName))
                {
                    newSheets.Add(item.SelectedSheetName);
                }

                item.AvailableSheets = newSheets;
            }
        }
        catch (Exception ex)
        {
            item.Status = TableSyncStatus.FileNotFound;
            item.StatusTooltip = $"Error reading source file: {ex.Message}";
        }

        if (item.AvailableSheets.Count == 0 && !string.IsNullOrWhiteSpace(item.SelectedSheetName))
        {
            item.AvailableSheets.Add(item.SelectedSheetName);
        }
    }

    /// <inheritdoc />
    public bool DeleteOrUnlinkTable(Document doc, TableItemModel item, bool deleteView)
    {
        if (doc == null || item == null) return false;

#if REVIT2024_OR_GREATER
        var elementId = new ElementId(item.ViewId);
#else
        var elementId = new ElementId((int)item.ViewId);
#endif

        var view = doc.GetElement(elementId) as View;
        if (view == null) return false;

        if (deleteView)
        {
            doc.Delete(elementId);
            return true;
        }

        // Unlink: remove Extensible Storage entity while preserving Revit drafting lines & texts
        _schemaService.RemoveTableMetadata(view);
        item.Status = TableSyncStatus.Unlinked;
        item.StatusTooltip = "Metadata unlinked from Revit view.";
        return true;
    }
}
