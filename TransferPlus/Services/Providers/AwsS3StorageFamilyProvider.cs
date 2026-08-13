using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers;

public class AwsS3StorageFamilyProvider : IFamilyProvider
{
    private readonly FamilySourceItemModel _sourceItem;
    private readonly FamilyRevitService _familyRevitService;

    public string ProviderName => string.IsNullOrWhiteSpace(_sourceItem.Name) ? "AWS S3" : _sourceItem.Name;
    public FamilySourceType SourceType => FamilySourceType.AwsS3;

    public AwsS3StorageFamilyProvider(FamilySourceItemModel sourceItem, FamilyRevitService familyRevitService)
    {
        _sourceItem = sourceItem;
        _familyRevitService = familyRevitService;
    }

    public async Task<IEnumerable<FamilyItemModel>> GetFamiliesAsync(CancellationToken cancellationToken = default)
    {
        var result = new List<FamilyItemModel>();

        try
        {
            TelemetryLogger.LogInfo($"AwsS3StorageFamilyProvider: Conectando a AWS S3 (Bucket '{_sourceItem.BucketName}', Ruta '{_sourceItem.RootPath}')...");
            var s3Objects = await AwsS3StorageService.GetAvailableFamiliesAsync(_sourceItem);

            string cacheDir = Path.Combine(Path.GetTempPath(), "TransferPlus_AwsCache");
            Directory.CreateDirectory(cacheDir);

            foreach (var s3Obj in s3Objects)
            {
                cancellationToken.ThrowIfCancellationRequested();

                string cachedFilePath = Path.Combine(cacheDir, Path.GetFileName(s3Obj.ObjectKey));
                try
                {
                    if (!File.Exists(cachedFilePath))
                    {
                        string downloaded = await AwsS3StorageService.DownloadFamilyBlobAsync(_sourceItem, s3Obj.ObjectKey, cacheDir);
                        if (File.Exists(downloaded))
                        {
                            cachedFilePath = downloaded;
                        }
                    }
                }
                catch (Exception dlEx)
                {
                    TelemetryLogger.LogWarning($"[AwsS3StorageFamilyProvider] No se pudo pre-descargar objeto S3 '{s3Obj.ObjectKey}' para metadata: {dlEx.Message}");
                }

                var (ver, cat, symbols) = RfaMetadataExtractor.ExtractCategoryAndSymbols(_familyRevitService?.RevitApp, cachedFilePath);
                string categoryName = string.IsNullOrWhiteSpace(cat) ? "AWS S3 Family" : cat;

                result.Add(new FamilyItemModel
                {
                    Name = s3Obj.FamilyName,
                    CategoryName = categoryName,
                    SourceName = ProviderName,
                    StatusMessage = $"AWS S3 ({s3Obj.FormattedSize})",
                    ImagePreviewUrl = File.Exists(cachedFilePath) ? cachedFilePath : s3Obj.ObjectKey,
                    RevitVersion = string.IsNullOrWhiteSpace(ver) ? "AWS S3 Cloud" : ver,
                    Symbols = symbols
                });
            }

            TelemetryLogger.LogInfo($"AwsS3StorageFamilyProvider: Se obtuvieron {result.Count} familias de AWS S3 en bucket '{_sourceItem.BucketName}'.");
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error en AwsS3StorageFamilyProvider para bucket '{_sourceItem.BucketName}'", ex);
        }

        return result;
    }

    public async Task<bool> TransferFamilyAsync(FamilyItemModel familyItem, Document destinationDoc, string? overrideFamilyName = null, IDictionary<string, string>? symbolRenameMap = null, CancellationToken cancellationToken = default)
    {
        if (familyItem == null || destinationDoc == null || _sourceItem == null) return false;

        string targetPathOrKey = familyItem.ImagePreviewUrl;
        if (string.IsNullOrWhiteSpace(targetPathOrKey)) return false;
        string tempLocalPath = string.Empty;
        try
        {
            if (File.Exists(targetPathOrKey))
            {
                tempLocalPath = targetPathOrKey;
            }
            else
            {
                string cacheDir = Path.Combine(Path.GetTempPath(), "TransferPlus_AwsCache");
                TelemetryLogger.LogInfo($"AwsS3StorageFamilyProvider: Descargando objeto de AWS S3 '{targetPathOrKey}' a almacenamiento temporal local...");
                tempLocalPath = await AwsS3StorageService.DownloadFamilyBlobAsync(_sourceItem, targetPathOrKey, cacheDir);
            }

            TelemetryLogger.LogInfo($"AwsS3StorageFamilyProvider: Objeto descargado en '{tempLocalPath}'. Cargando en Revit...");
            bool loaded = false;

            var targetSymbolNames = familyItem.Symbols?.Where(s => s.IsActive).Select(s => s.Name);

            if (destinationDoc.Application != null)
            {
                var uiApp = new Autodesk.Revit.UI.UIApplication(destinationDoc.Application);
                loaded = _familyRevitService.TryLoadFileFamilyWithOverride(uiApp, destinationDoc, tempLocalPath, overrideFamilyName, targetSymbolNames, symbolRenameMap);
            }
            else
            {
                loaded = _familyRevitService.TryLoadFamily(destinationDoc, tempLocalPath, out _);
            }

            if (loaded)
            {
                TelemetryLogger.LogInfo($"AwsS3StorageFamilyProvider: Familia de AWS S3 '{familyItem.Name}' transferida y cargada con éxito.");
            }
            else
            {
                TelemetryLogger.LogWarning($"AwsS3StorageFamilyProvider: No se pudo cargar la familia de AWS S3 '{familyItem.Name}'.");
            }
            return loaded;
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error descargando y transfiriendo objeto de AWS S3 '{targetPathOrKey}'", ex);
            return false;
        }
    }
}
