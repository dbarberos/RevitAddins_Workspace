using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers;

public class AzureStorageFamilyProvider : IFamilyProvider
{
    private readonly FamilySourceItemModel _sourceItem;
    private readonly FamilyRevitService _familyRevitService;

    public string ProviderName => string.IsNullOrWhiteSpace(_sourceItem.Name) ? "Azure Storage" : _sourceItem.Name;
    public FamilySourceType SourceType => FamilySourceType.AzureStorage;

    public AzureStorageFamilyProvider(FamilySourceItemModel sourceItem, FamilyRevitService familyRevitService)
    {
        _sourceItem = sourceItem;
        _familyRevitService = familyRevitService;
    }

    public async Task<IEnumerable<FamilyItemModel>> GetFamiliesAsync(CancellationToken cancellationToken = default)
    {
        var result = new List<FamilyItemModel>();

        try
        {
            TelemetryLogger.LogInfo($"AzureStorageFamilyProvider: Conectando a Azure Blob Storage (Contenedor '{_sourceItem.ContainerName}', Ruta '{_sourceItem.RootPath}')...");
            var blobs = await AzureStorageService.GetAvailableFamiliesAsync(
                _sourceItem.ConnectionString,
                _sourceItem.ContainerName,
                _sourceItem.RootPath,
                cancellationToken);

            string cacheDir = Path.Combine(Path.GetTempPath(), "TransferPlus_AzureCache");
            Directory.CreateDirectory(cacheDir);

            foreach (var blob in blobs)
            {
                cancellationToken.ThrowIfCancellationRequested();

                string cachedFilePath = Path.Combine(cacheDir, Path.GetFileName(blob.BlobName));
                try
                {
                    if (!File.Exists(cachedFilePath))
                    {
                        string downloaded = AzureStorageService.DownloadFamilyBlob(
                            _sourceItem.ConnectionString,
                            _sourceItem.ContainerName,
                            blob.BlobName);
                        if (File.Exists(downloaded))
                        {
                            cachedFilePath = downloaded;
                        }
                    }
                }
                catch (Exception dlEx)
                {
                    TelemetryLogger.LogWarning($"[AzureStorageFamilyProvider] No se pudo pre-descargar blob '{blob.BlobName}' para metadata: {dlEx.Message}");
                }

                var (ver, cat, symbols) = RfaMetadataExtractor.ExtractCategoryAndSymbols(_familyRevitService?.RevitApp, cachedFilePath);
                string categoryName = string.IsNullOrWhiteSpace(cat) ? "Azure Family" : cat;

                result.Add(new FamilyItemModel
                {
                    Name = blob.FamilyName,
                    CategoryName = categoryName,
                    SourceName = ProviderName,
                    StatusMessage = $"Azure Blob ({blob.FormattedSize})",
                    ImagePreviewUrl = File.Exists(cachedFilePath) ? cachedFilePath : blob.BlobName,
                    RevitVersion = string.IsNullOrWhiteSpace(ver) ? "Azure Cloud" : ver,
                    Symbols = symbols
                });
            }

            TelemetryLogger.LogInfo($"AzureStorageFamilyProvider: Se obtuvieron {result.Count} familias de Azure en contenedor '{_sourceItem.ContainerName}'.");
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error en AzureStorageFamilyProvider para contenedor '{_sourceItem.ContainerName}'", ex);
        }

        return result;
    }

    public Task<bool> TransferFamilyAsync(FamilyItemModel familyItem, Document destinationDoc, string? overrideFamilyName = null, IDictionary<string, string>? symbolRenameMap = null, CancellationToken cancellationToken = default)
    {
        if (familyItem == null || destinationDoc == null || _sourceItem == null) return Task.FromResult(false);

        string blobName = familyItem.ImagePreviewUrl;
        if (string.IsNullOrWhiteSpace(blobName)) return Task.FromResult(false);
        string tempLocalPath = string.Empty;
        try
        {
            TelemetryLogger.LogInfo($"AzureStorageFamilyProvider: Descargando blob de Azure '{blobName}' a almacenamiento temporal local...");
            tempLocalPath = AzureStorageService.DownloadFamilyBlob(
                _sourceItem.ConnectionString,
                _sourceItem.ContainerName,
                blobName);

            TelemetryLogger.LogInfo($"AzureStorageFamilyProvider: Blob descargado en '{tempLocalPath}'. Cargando en Revit...");
            bool loaded = false;

            var targetSymbolNames = familyItem.Symbols?.Where(s => s.IsActive).Select(s => s.Name);

            if (destinationDoc.Application != null)
            {
                var uiApp = new Autodesk.Revit.UI.UIApplication(destinationDoc.Application);
                loaded = _familyRevitService.TryLoadFileFamilyWithOverride(uiApp, destinationDoc, tempLocalPath, overrideFamilyName, targetSymbolNames, symbolRenameMap);
            }
            else
            {
                // Carga directa de la familia completa .rfa
                loaded = _familyRevitService.TryLoadFamily(destinationDoc, tempLocalPath, out _);
            }

            if (loaded)
            {
                TelemetryLogger.LogInfo($"AzureStorageFamilyProvider: Familia de Azure '{familyItem.Name}' transferida y cargada con éxito.");
            }
            else
            {
                TelemetryLogger.LogWarning($"AzureStorageFamilyProvider: No se pudo cargar la familia de Azure '{familyItem.Name}'.");
            }
            return Task.FromResult(loaded);
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error descargando y transfiriendo blob de Azure '{blobName}'", ex);
            return Task.FromResult(false);
        }
        finally
        {
            if (!string.IsNullOrEmpty(tempLocalPath))
            {
                FamilyFileManager.RemoveFamilyLocalFile(tempLocalPath);
            }
        }
    }
}
