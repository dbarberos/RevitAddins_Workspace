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

        LoggerService.LogInfo($"[TableRegistryService] DiscoverTablesAsync started for document '{doc.Title}'.");

        var discoveredItems = new List<TableItemModel>();

        // 1. Build ViewId -> Sheet mapping from Viewports and ScheduleSheetInstances
        var viewToSheetMap = BuildViewToSheetMapping(doc);

        // 2. Query candidate Drafting, Legend, and Schedule views
        var candidateViews = new FilteredElementCollector(doc)
            .OfClass(typeof(View))
            .Cast<View>()
            .Where(v => !v.IsTemplate && (v.ViewType == ViewType.DraftingView || v.ViewType == ViewType.Legend || v.ViewType == ViewType.Schedule))
            .ToList();

        LoggerService.LogInfo($"[TableRegistryService] Queried {candidateViews.Count} candidate views (Drafting, Legend, Schedule) in Revit document.");

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
                else if (ext is ".txt" or ".tsv" or ".tab" or ".prn" or ".dat" or ".log" or ".asc") sourceType = TableSourceType.TextFile;
                else if (ext == ".pdf") sourceType = TableSourceType.PdfDocument;
                else if (ext is ".docx" or ".doc" or ".rtf") sourceType = TableSourceType.WordDocument;
                else if (ext is ".md" or ".markdown") sourceType = TableSourceType.MarkdownDocument;
            }

            var effectiveImportType = config.ImportType;
            if (view is ViewSchedule vs)
            {
                if (effectiveImportType is not (TableImportType.KeySchedule or TableImportType.HeaderSchedule))
                {
                    effectiveImportType = vs.Definition.IsKeySchedule ? TableImportType.KeySchedule : TableImportType.HeaderSchedule;
                    config.ImportType = effectiveImportType;
                }
            }

            var item = new TableItemModel
            {
                ViewId = viewIdVal,
                ViewName = view.Name,
                ViewType = config.TargetViewType,
                ViewScale = config.ViewScale > 0 ? config.ViewScale : (view is ViewSchedule ? 1 : (view.Scale > 0 ? view.Scale : 1)),
                ImportType = effectiveImportType,
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
                Config = config,
                SheetName = viewToSheetMap.TryGetValue(view.Id, out var sheet) && !string.IsNullOrWhiteSpace(sheet)
                    ? sheet
                    : "Unplaced"
            };

            // Evaluate live file status and sheet catalog
            await RefreshItemStatusAsync(item).ConfigureAwait(false);

            discoveredItems.Add(item);
            LoggerService.LogInfo($"[TableRegistryService] Discovered table view '{view.Name}' (ID {viewIdVal}): Source='{fileName}', Sheet='{config.SelectedSheetName}', Range='{item.CellRangeAddress}', Placed='{item.SheetName}'.");
        }

        LoggerService.LogInfo($"[TableRegistryService] DiscoverTablesAsync completed: {discoveredItems.Count} TablePlus table(s) registered in memory.");
        return discoveredItems;
    }

    private static Dictionary<ElementId, string> BuildViewToSheetMapping(Document doc)
    {
        var mapping = new Dictionary<ElementId, string>();
        if (doc == null) return mapping;

        try
        {
            // 1. Viewports (Drafting Views and Legends)
            var viewports = new FilteredElementCollector(doc)
                .OfClass(typeof(Viewport))
                .Cast<Viewport>();

            foreach (var vp in viewports)
            {
                if (doc.GetElement(vp.SheetId) is ViewSheet sheet)
                {
                    string sheetLabel = $"{sheet.SheetNumber} - {sheet.Name}";
                    if (mapping.TryGetValue(vp.ViewId, out var existing))
                    {
                        if (!existing.Contains(sheetLabel))
                        {
                            mapping[vp.ViewId] = $"{existing}, {sheetLabel}";
                        }
                    }
                    else
                    {
                        mapping[vp.ViewId] = sheetLabel;
                    }
                }
            }

            // 2. ScheduleSheetInstances (Schedules placed on sheets)
            var scheduleInstances = new FilteredElementCollector(doc)
                .OfClass(typeof(ScheduleSheetInstance))
                .Cast<ScheduleSheetInstance>();

            foreach (var ssi in scheduleInstances)
            {
                if (doc.GetElement(ssi.OwnerViewId) is ViewSheet sheet)
                {
                    string sheetLabel = $"{sheet.SheetNumber} - {sheet.Name}";
                    if (mapping.TryGetValue(ssi.ScheduleId, out var existing))
                    {
                        if (!existing.Contains(sheetLabel))
                        {
                            mapping[ssi.ScheduleId] = $"{existing}, {sheetLabel}";
                        }
                    }
                    else
                    {
                        mapping[ssi.ScheduleId] = sheetLabel;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogError("BuildViewToSheetMapping", ex);
        }

        return mapping;
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

        LoggerService.LogInfo($"[TableRegistryService] DeleteOrUnlinkTable: View='{item.ViewName}' (ID {item.ViewId}), deleteView={deleteView}");

        if (deleteView)
        {
            doc.Delete(elementId);
            LoggerService.LogInfo($"[TableRegistryService] Deleted Revit view '{view.Name}' (ID {elementId}) from document.");
            return true;
        }

        // Unlink: remove Extensible Storage entity while preserving Revit drafting lines & texts
        _schemaService.RemoveTableMetadata(view);
        item.Status = TableSyncStatus.Unlinked;
        item.StatusTooltip = "Metadata unlinked from Revit view.";
        LoggerService.LogInfo($"[TableRegistryService] Unlinked TablePlus Extensible Storage metadata schema from Revit view '{view.Name}' (ID {elementId}).");
        return true;
    }
}
