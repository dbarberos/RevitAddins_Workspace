using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TablePlus.Models;

namespace TablePlus.Services;

public static class TableSourceConfigService
{
    private static readonly string ConfigDirectory = Path.GetFullPath(
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TablePlus"));

    private static readonly string ConfigFilePath = Path.Combine(ConfigDirectory, "table_sources.json");

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    static TableSourceConfigService()
    {
        try
        {
            if (!Directory.Exists(ConfigDirectory))
            {
                Directory.CreateDirectory(ConfigDirectory);
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error creating TablePlus config directory", ex);
        }
    }

    public static List<TableSourceItemModel> LoadSources()
    {
        try
        {
            if (!File.Exists(ConfigFilePath))
            {
                TelemetryLogger.LogInfo("No previous table sources file found. Returning empty list.");
                return new List<TableSourceItemModel>();
            }

            string json = File.ReadAllText(ConfigFilePath);
            var items = JsonSerializer.Deserialize<List<TableSourceItemModel>>(json, JsonOptions);
            return items ?? new List<TableSourceItemModel>();
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error loading TablePlus table sources configuration", ex);
            return new List<TableSourceItemModel>();
        }
    }

    public static bool SaveSources(IEnumerable<TableSourceItemModel> sources)
    {
        try
        {
            var list = sources?.ToList() ?? new List<TableSourceItemModel>();

            // Validate directory paths
            foreach (var item in list)
            {
                if (item.SourceType == ExternalTableSourceType.Directory && !string.IsNullOrWhiteSpace(item.Path))
                {
                    try
                    {
                        item.Path = Path.GetFullPath(item.Path);
                    }
                    catch (Exception ex)
                    {
                        TelemetryLogger.LogWarning($"Invalid table directory path: '{item.Path}'. Error: {ex.Message}");
                    }
                }
            }

            string json = JsonSerializer.Serialize(list, JsonOptions);
            File.WriteAllText(ConfigFilePath, json);
            TelemetryLogger.LogInfo($"Table sources configuration saved successfully to {ConfigFilePath}");
            return true;
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error saving TablePlus table sources configuration", ex);
            return false;
        }
    }
}
