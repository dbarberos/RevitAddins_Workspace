using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers;

public class LocalFolderFamilyProvider : IFamilyProvider
{
    private static readonly Regex BackupRegex = new(@"\.\d{4}\.rfa$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private readonly string _folderPath;
    private readonly FamilyRevitService _familyRevitService;

    public string ProviderName => string.IsNullOrWhiteSpace(_folderPath) ? "Local Folder" : Path.GetFileName(_folderPath.TrimEnd('\\', '/'));
    public FamilySourceType SourceType => FamilySourceType.Directory;

    public LocalFolderFamilyProvider(string folderPath, FamilyRevitService familyRevitService)
    {
        _folderPath = folderPath;
        _familyRevitService = familyRevitService;
    }

    public Task<IEnumerable<FamilyItemModel>> GetFamiliesAsync(CancellationToken cancellationToken = default)
    {
        var result = new List<FamilyItemModel>();

        try
        {
            if (string.IsNullOrWhiteSpace(_folderPath) ||
                _folderPath.IndexOfAny(Path.GetInvalidPathChars()) >= 0 ||
                !Directory.Exists(_folderPath))
            {
                TelemetryLogger.LogWarning($"LocalFolderFamilyProvider: La ruta de carpeta local no es válida o no existe: '{_folderPath}'");
                return Task.FromResult<IEnumerable<FamilyItemModel>>(result);
            }

            TelemetryLogger.LogInfo($"LocalFolderFamilyProvider: Escaneando archivos .rfa en carpeta local '{_folderPath}'...");
            var rfaFiles = Directory.GetFiles(_folderPath, "*.rfa", SearchOption.AllDirectories);

            foreach (var filePath in rfaFiles)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (BackupRegex.IsMatch(filePath)) continue;

                string familyName = Path.GetFileNameWithoutExtension(filePath);

                var (ver, cat, symbols) = RfaMetadataExtractor.ExtractCategoryAndSymbols(_familyRevitService?.RevitApp, filePath);
                string revitVersion = string.IsNullOrWhiteSpace(ver) ? "RFA File" : ver;
                string categoryName = string.IsNullOrWhiteSpace(cat) ? "General" : cat;

                long? sizeBytes = null;
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

                result.Add(new FamilyItemModel
                {
                    Name = familyName,
                    CategoryName = categoryName,
                    SourceName = ProviderName,
                    StatusMessage = $"{symbols.Count} tipo(s) disponible(s)",
                    ImagePreviewUrl = filePath,
                    RevitVersion = revitVersion,
                    FileSizeBytes = sizeBytes,
                    LastModified = lastMod,
                    Symbols = symbols
                });
            }

            TelemetryLogger.LogInfo($"LocalFolderFamilyProvider: Escaneo completado. Se encontraron {result.Count} familias .rfa válidas en '{_folderPath}'.");
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error enumerating local folder families at '{_folderPath}'", ex);
        }

        return Task.FromResult<IEnumerable<FamilyItemModel>>(result);
    }

    public Task<bool> TransferFamilyAsync(FamilyItemModel familyItem, Document destinationDoc, string? overrideFamilyName = null, IDictionary<string, string>? symbolRenameMap = null, CancellationToken cancellationToken = default)
    {
        if (familyItem == null || destinationDoc == null) return Task.FromResult(false);

        string filePath = familyItem.ImagePreviewUrl;
        bool success = false;

        var targetSymbolNames = familyItem.Symbols?.Where(s => s.IsActive).Select(s => s.Name);

        if (destinationDoc.Application != null)
        {
            var uiApp = new Autodesk.Revit.UI.UIApplication(destinationDoc.Application);
            success = _familyRevitService.TryLoadFileFamilyWithOverride(uiApp, destinationDoc, filePath, overrideFamilyName, targetSymbolNames, symbolRenameMap);
        }
        else
        {
            TelemetryLogger.LogInfo($"LocalFolderFamilyProvider: Cargando archivo .rfa local completo '{familyItem.Name}' ({filePath}) en documento de Revit...");
            success = _familyRevitService.TryLoadFamily(destinationDoc, filePath, out _);
        }

        if (success)
        {
            TelemetryLogger.LogInfo($"LocalFolderFamilyProvider: Familia '{familyItem.Name}' cargada con éxito en el modelo destino.");
        }
        else
        {
            TelemetryLogger.LogWarning($"LocalFolderFamilyProvider: No se pudo cargar la familia '{familyItem.Name}' desde disco.");
        }
        return Task.FromResult(success);
    }
}
