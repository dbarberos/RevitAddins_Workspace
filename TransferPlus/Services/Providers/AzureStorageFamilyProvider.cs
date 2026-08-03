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
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error in AzureStorageFamilyProvider for container '{_sourceItem.ContainerName}'", ex);
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
            // Asynchronously stream blob to local temp file
            string tempLocalPath = await AzureStorageService.DownloadFamilyBlobAsync(
                _sourceItem.ConnectionString,
                _sourceItem.ContainerName,
                blobName,
                cancellationToken);

            // Load into Revit destination document via transaction
            bool loaded = _familyRevitService.TryLoadFamily(destinationDoc, tempLocalPath, out _);

            // Clean up temporary local file
            FamilyFileManager.RemoveFamilyLocalFile(tempLocalPath);
            return loaded;
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error downloading and transferring Azure family blob '{blobName}'", ex);
            return false;
        }
    }
}
