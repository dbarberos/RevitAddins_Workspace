using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers;

public class AwsS3StorageCadProvider : ICadProvider
{
    private readonly CadSourceItemModel _sourceItem;
    private readonly FamilyRevitService _familyRevitService;

    public string ProviderName => string.IsNullOrWhiteSpace(_sourceItem.Name) ? "AWS S3" : _sourceItem.Name;
    public CadSourceType? SourceType => CadSourceType.AwsS3;

    public AwsS3StorageCadProvider(CadSourceItemModel sourceItem, FamilyRevitService familyRevitService)
    {
        _sourceItem = sourceItem;
        _familyRevitService = familyRevitService;
    }

    public async Task<IEnumerable<CadDetailItemModel>> GetCadItemsAsync(CancellationToken cancellationToken = default)
    {
        var result = new List<CadDetailItemModel>();

        try
        {
            TelemetryLogger.LogInfo($"AwsS3StorageCadProvider: Conectando a AWS S3 (Bucket '{_sourceItem.BucketName}', Ruta '{_sourceItem.RootPath}')...");
            var blobs = await AwsS3StorageService.GetAvailableCadBlobsAsync(_sourceItem);

            foreach (var blob in blobs)
            {
                cancellationToken.ThrowIfCancellationRequested();

                result.Add(new CadDetailItemModel
                {
                    Name = blob.FileName,
                    ViewName = Path.GetFileName(blob.ObjectKey),
                    FilePath = blob.ObjectKey,
                    Format = blob.Extension,
                    Category = $"{blob.Extension.ToUpperInvariant()} File",
                    FileSizeBytes = blob.SizeBytes,
                    LastModified = blob.LastModified,
                    SourceDocumentName = ProviderName,
                    IsExternalFile = true,
                    SourceType = CadSourceType.AwsS3
                });
            }

            TelemetryLogger.LogInfo($"AwsS3StorageCadProvider: Se obtuvieron {result.Count} archivos CAD de AWS S3 en bucket '{_sourceItem.BucketName}'.");
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error en AwsS3StorageCadProvider para bucket '{_sourceItem.BucketName}'", ex);
        }

        return result;
    }

    public async Task<bool> TransferCadItemAsync(CadDetailItemModel cadItem, Document destinationDoc, bool isLinkMode = false, string? overrideViewName = null, CancellationToken cancellationToken = default)
    {
        if (cadItem == null || destinationDoc == null || _sourceItem == null) return false;

        string objectKey = cadItem.FilePath;
        if (string.IsNullOrWhiteSpace(objectKey)) return false;
        string tempLocalPath = string.Empty;

        try
        {
            TelemetryLogger.LogInfo($"AwsS3StorageCadProvider: Descargando archivo CAD de AWS S3 '{objectKey}' a almacenamiento temporal local...");
            string localTempDir = Path.Combine(Path.GetTempPath(), "TransferPlus_CAD_Aws");
            tempLocalPath = await AwsS3StorageService.DownloadCadBlobAsync(_sourceItem, objectKey, localTempDir);

            TelemetryLogger.LogInfo($"AwsS3StorageCadProvider: Archivo CAD descargado en '{tempLocalPath}'. Importando en Revit...");

            // AWS S3 objects are always imported (isLinkMode forced false)
            bool loaded = _familyRevitService.TransferExternalCadToDraftingView(destinationDoc, tempLocalPath, overrideViewName, isLinkMode: false);

            if (loaded)
            {
                TelemetryLogger.LogInfo($"AwsS3StorageCadProvider: Archivo CAD de AWS S3 '{cadItem.Name}' transferido e importado con éxito.");
            }
            else
            {
                TelemetryLogger.LogWarning($"AwsS3StorageCadProvider: No se pudo importar archivo CAD de AWS S3 '{cadItem.Name}'.");
            }
            return loaded;
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error descargando y transfiriendo objeto CAD de AWS S3 '{objectKey}'", ex);
            return false;
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
