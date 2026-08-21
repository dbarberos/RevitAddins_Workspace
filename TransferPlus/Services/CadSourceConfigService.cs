using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TransferPlus.Models;

namespace TransferPlus.Services;

public static class CadSourceConfigService
{
    private static readonly string ConfigDirectory = Path.GetFullPath(
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TransferPlus"));

    private static readonly string ConfigFilePath = Path.Combine(ConfigDirectory, "cad_sources.json");

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    static CadSourceConfigService()
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

    public static List<CadSourceItemModel> LoadSources()
    {
        try
        {
            if (!File.Exists(ConfigFilePath))
            {
                TelemetryLogger.LogInfo("No existe archivo previo de fuentes de CAD. Se devuelve lista vacía.");
                return new List<CadSourceItemModel>();
            }

            string json = File.ReadAllText(ConfigFilePath);
            var items = JsonSerializer.Deserialize<List<CadSourceItemModel>>(json, JsonOptions);
            return items ?? new List<CadSourceItemModel>();
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error al cargar la configuración de fuentes de CAD", ex);
            return new List<CadSourceItemModel>();
        }
    }

    public static bool SaveSources(IEnumerable<CadSourceItemModel> sources)
    {
        try
        {
            var list = sources?.ToList() ?? new List<CadSourceItemModel>();
            
            // Validar rutas de directorios
            foreach (var item in list)
            {
                if (item.SourceType == CadSourceType.Directory && !string.IsNullOrWhiteSpace(item.Path))
                {
                    try
                    {
                        item.Path = Path.GetFullPath(item.Path);
                    }
                    catch (Exception ex)
                    {
                        TelemetryLogger.LogWarning($"Ruta de directorio CAD no válida: '{item.Path}'. Error: {ex.Message}");
                    }
                }
            }

            string json = JsonSerializer.Serialize(list, JsonOptions);
            File.WriteAllText(ConfigFilePath, json);
            TelemetryLogger.LogInfo($"Configuración de fuentes de CAD guardada correctamente en {ConfigFilePath}");
            return true;
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error al guardar la configuración de fuentes de CAD", ex);
            return false;
        }
    }
}
