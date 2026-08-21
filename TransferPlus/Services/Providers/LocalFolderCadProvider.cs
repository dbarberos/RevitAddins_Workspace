using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers;

public class LocalFolderCadProvider : ICadProvider
{
    private static readonly HashSet<string> SupportedCadExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".dwg", ".dxf", ".axm", ".sat", ".dgn", ".obj", ".3dm", ".skp", ".stl"
    };

    private readonly string _folderPath;
    private readonly FamilyRevitService _familyRevitService;

    public string ProviderName => string.IsNullOrWhiteSpace(_folderPath) ? "Local Folder" : Path.GetFileName(_folderPath.TrimEnd('\\', '/'));
    public CadSourceType? SourceType => CadSourceType.Directory;

    public LocalFolderCadProvider(string folderPath, FamilyRevitService familyRevitService)
    {
        _folderPath = folderPath;
        _familyRevitService = familyRevitService;
    }

    public Task<IEnumerable<CadDetailItemModel>> GetCadItemsAsync(CancellationToken cancellationToken = default)
    {
        var result = new List<CadDetailItemModel>();

        try
        {
            if (string.IsNullOrWhiteSpace(_folderPath) ||
                _folderPath.IndexOfAny(Path.GetInvalidPathChars()) >= 0 ||
                !Directory.Exists(_folderPath))
            {
                TelemetryLogger.LogWarning($"LocalFolderCadProvider: La ruta de carpeta local no es válida o no existe: '{_folderPath}'");
                return Task.FromResult<IEnumerable<CadDetailItemModel>>(result);
            }

            TelemetryLogger.LogInfo($"LocalFolderCadProvider: Escaneando archivos CAD en carpeta local '{_folderPath}'...");
            
            var allFiles = Directory.EnumerateFiles(_folderPath, "*.*", SearchOption.AllDirectories);

            foreach (var filePath in allFiles)
            {
                cancellationToken.ThrowIfCancellationRequested();

                string ext = Path.GetExtension(filePath);
                if (!SupportedCadExtensions.Contains(ext)) continue;

                // Ignore temporary or lock files
                string fileName = Path.GetFileName(filePath);
                if (fileName.StartsWith("~$") || fileName.StartsWith(".")) continue;

                long sizeBytes = 0;
                DateTime? lastMod = null;
                try
                {
                    var fi = new FileInfo(filePath);
                    if (fi.Exists)
                    {
                        sizeBytes = fi.Length;
                        lastMod = fi.LastWriteTime;
                    }
                }
                catch { }

                string format = ext.TrimStart('.').ToLowerInvariant();

                result.Add(new CadDetailItemModel
                {
                    Name = Path.GetFileNameWithoutExtension(filePath),
                    ViewName = fileName,
                    FilePath = filePath,
                    Format = format,
                    Category = $"{format.ToUpperInvariant()} File",
                    FileSizeBytes = sizeBytes,
                    LastModified = lastMod,
                    SourceDocumentName = ProviderName,
                    IsExternalFile = true,
                    SourceType = CadSourceType.Directory
                });
            }

            TelemetryLogger.LogInfo($"LocalFolderCadProvider: Escaneo completado. Se encontraron {result.Count} archivos CAD válidos en '{_folderPath}'.");
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error enumerating local folder CAD files at '{_folderPath}'", ex);
        }

        return Task.FromResult<IEnumerable<CadDetailItemModel>>(result);
    }

    public Task<bool> TransferCadItemAsync(CadDetailItemModel cadItem, Document destinationDoc, bool isLinkMode = false, string? overrideViewName = null, CancellationToken cancellationToken = default)
    {
        if (cadItem == null || destinationDoc == null || string.IsNullOrWhiteSpace(cadItem.FilePath)) return Task.FromResult(false);

        string filePath = cadItem.FilePath;
        bool success = _familyRevitService.TransferExternalCadToDraftingView(destinationDoc, filePath, overrideViewName, isLinkMode);

        if (success)
        {
            TelemetryLogger.LogInfo($"LocalFolderCadProvider: Archivo CAD '{cadItem.Name}' {(isLinkMode ? "vinculado" : "importado")} con éxito en '{destinationDoc.Title}'.");
        }
        else
        {
            TelemetryLogger.LogWarning($"LocalFolderCadProvider: No se pudo transferir archivo CAD '{cadItem.Name}' desde '{filePath}'.");
        }

        return Task.FromResult(success);
    }
}
