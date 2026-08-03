using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TransferPlus.Models;

namespace TransferPlus.Services;

public static class FamilySourceConfigService
{
    private static readonly string ConfigDirectory = Path.GetFullPath(
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TransferPlus"));

    private static readonly string ConfigFilePath = Path.Combine(ConfigDirectory, "family_sources.json");

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    static FamilySourceConfigService()
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
            TelemetryLogger.LogError("Error al crear directorio de configuración de TransferPlus", ex);
        }
    }

    public static List<FamilySourceItemModel> LoadSources()
    {
        try
        {
            if (!File.Exists(ConfigFilePath))
            {
                TelemetryLogger.LogInfo("No existe archivo previo de fuentes de familias. Se devuelve lista vacía.");
                return new List<FamilySourceItemModel>();
            }

            string json = File.ReadAllText(ConfigFilePath);
            var items = JsonSerializer.Deserialize<List<FamilySourceItemModel>>(json, JsonOptions);
            return items ?? new List<FamilySourceItemModel>();
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error al cargar la configuración de fuentes de familias", ex);
            return new List<FamilySourceItemModel>();
        }
    }

    public static bool SaveSources(IEnumerable<FamilySourceItemModel> sources)
    {
        try
        {
            var list = sources?.ToList() ?? new List<FamilySourceItemModel>();
            
            // Validar rutas de directorios
            foreach (var item in list)
            {
                if (item.SourceType == FamilySourceType.Directory && !string.IsNullOrWhiteSpace(item.Path))
                {
                    try
                    {
                        item.Path = Path.GetFullPath(item.Path);
                    }
                    catch (Exception ex)
                    {
                        TelemetryLogger.LogWarning($"Ruta de directorio no válida: '{item.Path}'. Error: {ex.Message}");
                    }
                }
            }

            string json = JsonSerializer.Serialize(list, JsonOptions);
            File.WriteAllText(ConfigFilePath, json);
            TelemetryLogger.LogInfo($"Configuración de fuentes de familias guardada correctamente en {ConfigFilePath}");
            return true;
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error al guardar la configuración de fuentes de familias", ex);
            return false;
        }
    }
}
