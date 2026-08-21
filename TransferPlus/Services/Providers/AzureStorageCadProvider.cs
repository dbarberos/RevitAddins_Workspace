using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers;

public class AzureStorageCadProvider : ICadProvider
{
    private readonly CadSourceItemModel _sourceItem;
    private readonly FamilyRevitService _familyRevitService;

    public string ProviderName => string.IsNullOrWhiteSpace(_sourceItem.Name) ? "Azure Storage" : _sourceItem.Name;
    public CadSourceType? SourceType => CadSourceType.AzureStorage;

    public AzureStorageCadProvider(CadSourceItemModel sourceItem, FamilyRevitService familyRevitService)
    {
        _sourceItem = sourceItem;
        _familyRevitService = familyRevitService;
    }

    public async Task<IEnumerable<CadDetailItemModel>> GetCadItemsAsync(CancellationToken cancellationToken = default)
    {
        var result = new List<CadDetailItemModel>();

        try
        {
            TelemetryLogger.LogInfo($"AzureStorageCadProvider: Conectando a Azure Blob Storage (Contenedor '{_sourceItem.ContainerName}', Ruta '{_sourceItem.RootPath}')...");
            var blobs = await AzureStorageService.GetAvailableCadBlobsAsync(
                _sourceItem.ConnectionString,
                _sourceItem.ContainerName,
                _sourceItem.RootPath,
                cancellationToken);

            foreach (var blob in blobs)
            {
                cancellationToken.ThrowIfCancellationRequested();

                result.Add(new CadDetailItemModel
                {
                    Name = blob.FileName,
                    ViewName = Path.GetFileName(blob.BlobName),
                    FilePath = blob.BlobName,
                    Format = blob.Extension,
                    Category = $"{blob.Extension.ToUpperInvariant()} File",
                    FileSizeBytes = blob.ContentLength,
                    LastModified = blob.LastModified.HasValue ? blob.LastModified.Value.DateTime : null,
                    SourceDocumentName = ProviderName,
                    IsExternalFile = true,
                    SourceType = CadSourceType.AzureStorage
                });
            }

            TelemetryLogger.LogInfo($"AzureStorageCadProvider: Se obtuvieron {result.Count} archivos CAD de Azure en contenedor '{_sourceItem.ContainerName}'.");
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error en AzureStorageCadProvider para contenedor '{_sourceItem.ContainerName}'", ex);
        }

        return result;
    }

    public Task<bool> TransferCadItemAsync(CadDetailItemModel cadItem, Document destinationDoc, bool isLinkMode = false, string? overrideViewName = null, CancellationToken cancellationToken = default)
    {
        if (cadItem == null || destinationDoc == null || _sourceItem == null) return Task.FromResult(false);

        string blobName = cadItem.FilePath;
        if (string.IsNullOrWhiteSpace(blobName)) return Task.FromResult(false);
        string tempLocalPath = string.Empty;

        try
        {
            TelemetryLogger.LogInfo($"AzureStorageCadProvider: Descargando archivo CAD de Azure '{blobName}' a almacenamiento temporal local...");
            tempLocalPath = AzureStorageService.DownloadCadBlob(
                _sourceItem.ConnectionString,
                _sourceItem.ContainerName,
                blobName);

            TelemetryLogger.LogInfo($"AzureStorageCadProvider: Archivo CAD descargado en '{tempLocalPath}'. Importando en Revit...");
            
            // Azure objects are always imported (isLinkMode forced false)
            bool loaded = _familyRevitService.TransferExternalCadToDraftingView(destinationDoc, tempLocalPath, overrideViewName, isLinkMode: false);

            if (loaded)
            {
                TelemetryLogger.LogInfo($"AzureStorageCadProvider: Archivo CAD de Azure '{cadItem.Name}' transferido e importado con éxito.");
            }
            else
            {
                TelemetryLogger.LogWarning($"AzureStorageCadProvider: No se pudo importar archivo CAD de Azure '{cadItem.Name}'.");
            }
            return Task.FromResult(loaded);
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error descargando y transfiriendo blob CAD de Azure '{blobName}'", ex);
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
