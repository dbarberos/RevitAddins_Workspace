using System.Globalization;
using System.Text.Json;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using TablePlus.Models;

namespace TablePlus.Services;

/// <summary>
/// Implementation of Extensible Storage stamping and reading for TablePlus views.
/// Embeds source spreadsheet metadata, cell range, and configuration data directly
/// within target Revit Drafting and Legend Views for provenance and synchronization.
/// </summary>
public class SchemaService : ISchemaService
{
    /// <summary>
    /// Static GUID uniquely identifying the TablePlus Extensible Storage Schema.
    /// Do NOT change once deployed to production.
    /// </summary>
    public static readonly Guid SchemaGuid = new("E3B21D40-6C9A-4E2F-8A11-92D0543B7A1C");

    private const string SchemaName = "TablePlus_TableData";
    private const string VendorId = "DBDev_dbarberos";

    private const string FieldSourceFilePath = "SourceFilePath";
    private const string FieldWorksheetName = "WorksheetName";
    private const string FieldCellRange = "CellRange";
    private const string FieldTimestampUtc = "TimestampUtc";
    private const string FieldViewScale = "ViewScale";
    private const string FieldConfigJson = "ConfigJson";

    private static readonly object SchemaLock = new();
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = false,
        PropertyNameCaseInsensitive = true
    };

    /// <summary>
    /// Gets the registered schema or builds and registers it if not already present in the active session.
    /// </summary>
    public static Schema GetOrCreateSchema()
    {
        var schema = Schema.Lookup(SchemaGuid);
        if (schema != null)
        {
            return schema;
        }

        lock (SchemaLock)
        {
            schema = Schema.Lookup(SchemaGuid);
            if (schema != null)
            {
                return schema;
            }

            var builder = new SchemaBuilder(SchemaGuid);
            builder.SetReadAccessLevel(AccessLevel.Public);
            builder.SetWriteAccessLevel(AccessLevel.Public);
            builder.SetVendorId(VendorId);
            builder.SetSchemaName(SchemaName);

            builder.AddSimpleField(FieldSourceFilePath, typeof(string));
            builder.AddSimpleField(FieldWorksheetName, typeof(string));
            builder.AddSimpleField(FieldCellRange, typeof(string));
            builder.AddSimpleField(FieldTimestampUtc, typeof(string));
            builder.AddSimpleField(FieldViewScale, typeof(int));
            builder.AddSimpleField(FieldConfigJson, typeof(string));

            return builder.Finish();
        }
    }

    /// <inheritdoc />
    public void StampTableMetadata(View view, TableImportConfig config, string sourceFilePath)
    {
        if (view == null) throw new ArgumentNullException(nameof(view));
        if (config == null) throw new ArgumentNullException(nameof(config));

        var schema = GetOrCreateSchema();
        var entity = new Entity(schema);

        var effectiveRange = config.RangeMode switch
        {
            CellRangeSelectionMode.CustomRange => config.CustomRangeAddress ?? string.Empty,
            CellRangeSelectionMode.NamedRange => config.SelectedNamedRange ?? string.Empty,
            _ => "EntireSheet"
        };

        var timestampUtc = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture);
        config.LastImportedTimestampUtc = timestampUtc;
        if (!string.IsNullOrWhiteSpace(sourceFilePath))
        {
            config.SourceFilePath = sourceFilePath;
        }

        var jsonPayload = string.Empty;
        try
        {
            jsonPayload = JsonSerializer.Serialize(config, JsonOptions);
        }
        catch
        {
            // If serialization fails, fallback to empty JSON string; individual fields are still populated
        }

        entity.Set(FieldSourceFilePath, config.SourceFilePath ?? string.Empty);
        entity.Set(FieldWorksheetName, config.SelectedSheetName ?? string.Empty);
        entity.Set(FieldCellRange, effectiveRange);
        entity.Set(FieldTimestampUtc, timestampUtc);
        entity.Set(FieldViewScale, config.ViewScale);
        entity.Set(FieldConfigJson, jsonPayload);

        view.SetEntity(entity);
    }

    /// <inheritdoc />
    public TableImportConfig? ReadTableMetadata(View view)
    {
        if (view == null) return null;

        var schema = Schema.Lookup(SchemaGuid);
        if (schema == null) return null;

        var entity = view.GetEntity(schema);
        if (entity == null || !entity.IsValid()) return null;

        // 1. Attempt deserialization from the full JSON payload
        var jsonPayload = SafeGetString(entity, schema, FieldConfigJson);
        if (!string.IsNullOrWhiteSpace(jsonPayload))
        {
            try
            {
                var config = JsonSerializer.Deserialize<TableImportConfig>(jsonPayload!, JsonOptions);
                if (config != null)
                {
                    if (string.IsNullOrWhiteSpace(config.ViewName))
                    {
                        config.ViewName = view.Name;
                    }
                    return config;
                }
            }
            catch
            {
                // Fallback to manual reconstruction below
            }
        }

        // 2. Fallback: Reconstruct from individual schema fields
        var fallbackConfig = new TableImportConfig
        {
            SourceFilePath = SafeGetString(entity, schema, FieldSourceFilePath) ?? string.Empty,
            SelectedSheetName = SafeGetString(entity, schema, FieldWorksheetName) ?? string.Empty,
            ViewName = view.Name,
            ViewScale = SafeGetInt(entity, schema, FieldViewScale, defaultValue: 1),
            LastImportedTimestampUtc = SafeGetString(entity, schema, FieldTimestampUtc)
        };

        var rangeStr = SafeGetString(entity, schema, FieldCellRange);
        if (!string.IsNullOrWhiteSpace(rangeStr))
        {
            if (rangeStr!.Equals("EntireSheet", StringComparison.OrdinalIgnoreCase))
            {
                fallbackConfig.RangeMode = CellRangeSelectionMode.EntireSheet;
            }
            else if (rangeStr.Contains(':'))
            {
                fallbackConfig.RangeMode = CellRangeSelectionMode.CustomRange;
                fallbackConfig.CustomRangeAddress = rangeStr;
            }
            else
            {
                fallbackConfig.RangeMode = CellRangeSelectionMode.NamedRange;
                fallbackConfig.SelectedNamedRange = rangeStr;
            }
        }

        fallbackConfig.TargetViewType = view.ViewType == ViewType.DraftingView
            ? TargetViewType.DraftingView
            : TargetViewType.LegendView;

        return fallbackConfig;
    }

    /// <inheritdoc />
    public bool HasTableMetadata(View view)
    {
        if (view == null) return false;

        var schema = Schema.Lookup(SchemaGuid);
        if (schema == null) return false;

        var entity = view.GetEntity(schema);
        return entity != null && entity.IsValid();
    }

    /// <inheritdoc />
    public string? GetSourceFilePath(View view)
    {
        if (view == null) return null;
        var schema = Schema.Lookup(SchemaGuid);
        if (schema == null) return null;

        var entity = view.GetEntity(schema);
        return entity.IsValid() ? SafeGetString(entity, schema, FieldSourceFilePath) : null;
    }

    /// <inheritdoc />
    public string? GetWorksheetName(View view)
    {
        if (view == null) return null;
        var schema = Schema.Lookup(SchemaGuid);
        if (schema == null) return null;

        var entity = view.GetEntity(schema);
        return entity.IsValid() ? SafeGetString(entity, schema, FieldWorksheetName) : null;
    }

    /// <inheritdoc />
    public string? GetCellRange(View view)
    {
        if (view == null) return null;
        var schema = Schema.Lookup(SchemaGuid);
        if (schema == null) return null;

        var entity = view.GetEntity(schema);
        return entity.IsValid() ? SafeGetString(entity, schema, FieldCellRange) : null;
    }

    /// <inheritdoc />
    public string? GetTimestampUtc(View view)
    {
        if (view == null) return null;
        var schema = Schema.Lookup(SchemaGuid);
        if (schema == null) return null;

        var entity = view.GetEntity(schema);
        return entity.IsValid() ? SafeGetString(entity, schema, FieldTimestampUtc) : null;
    }

    private static string? SafeGetString(Entity entity, Schema schema, string fieldName)
    {
        try
        {
            var field = schema.GetField(fieldName);
            if (field != null)
            {
                return entity.Get<string>(field);
            }
        }
        catch
        {
            // Silently swallow missing or corrupted field reads
        }
        return null;
    }

    private static int SafeGetInt(Entity entity, Schema schema, string fieldName, int defaultValue = 1)
    {
        try
        {
            var field = schema.GetField(fieldName);
            if (field != null)
            {
                return entity.Get<int>(field);
            }
        }
        catch
        {
            // Silently swallow missing or corrupted field reads
        }
        return defaultValue;
    }
}
