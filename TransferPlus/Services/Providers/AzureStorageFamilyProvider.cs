using System;
using System.Collections.Generic;
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

            foreach (var blob in blobs)
            {
                result.Add(new FamilyItemModel
                {
                    Name = blob.FamilyName,
                    CategoryName = "Azure Family",
                    SourceName = ProviderName,
                    StatusMessage = $"Azure Blob ({blob.FormattedSize})",
                    ImagePreviewUrl = blob.BlobName, // BlobName stored here
                    Symbols = new List<FamilySymbolItemModel>
                    {
                        new FamilySymbolItemModel { Name = blob.FamilyName, FamilyName = blob.FamilyName, IsActive = true }
                    }
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

    public async Task<bool> TransferFamilyAsync(FamilyItemModel familyItem, Document destinationDoc, CancellationToken cancellationToken = default)
    {
        if (familyItem == null || destinationDoc == null) return false;

        string blobName = familyItem.ImagePreviewUrl;
        if (string.IsNullOrWhiteSpace(blobName)) return false;

        try
        {
            TelemetryLogger.LogInfo($"AzureStorageFamilyProvider: Descargando blob de Azure '{blobName}' a almacenamiento temporal local...");
            string tempLocalPath = await AzureStorageService.DownloadFamilyBlobAsync(
                _sourceItem.ConnectionString,
                _sourceItem.ContainerName,
                blobName,
                cancellationToken);

            TelemetryLogger.LogInfo($"AzureStorageFamilyProvider: Blob descargado en '{tempLocalPath}'. Cargando en Revit...");
            bool loaded = _familyRevitService.TryLoadFamily(destinationDoc, tempLocalPath, out _);

            FamilyFileManager.RemoveFamilyLocalFile(tempLocalPath);
            if (loaded)
            {
                TelemetryLogger.LogInfo($"AzureStorageFamilyProvider: Familia de Azure '{familyItem.Name}' transferida y cargada con éxito.");
            }
            else
            {
                TelemetryLogger.LogWarning($"AzureStorageFamilyProvider: No se pudo cargar la familia de Azure '{familyItem.Name}'.");
            }
            return loaded;
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error descargando y transfiriendo blob de Azure '{blobName}'", ex);
            return false;
        }
    }
}
