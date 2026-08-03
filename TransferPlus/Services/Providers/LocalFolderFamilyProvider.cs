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
            if (string.IsNullOrWhiteSpace(_folderPath) || !Directory.Exists(_folderPath))
            {
                TelemetryLogger.LogWarning($"Local folder path does not exist: '{_folderPath}'");
                return Task.FromResult<IEnumerable<FamilyItemModel>>(result);
            }

            var rfaFiles = Directory.GetFiles(_folderPath, "*.rfa", SearchOption.AllDirectories);
            foreach (var filePath in rfaFiles)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (BackupRegex.IsMatch(filePath)) continue;

                string familyName = Path.GetFileNameWithoutExtension(filePath);
                string categoryName = Path.GetFileName(Path.GetDirectoryName(filePath) ?? _folderPath);

                result.Add(new FamilyItemModel
                {
                    Name = familyName,
                    CategoryName = categoryName,
                    SourceName = ProviderName,
                    StatusMessage = "Disponible en disco",
                    ImagePreviewUrl = filePath,
                    Symbols = new List<FamilySymbolItemModel>
                    {
                        new FamilySymbolItemModel { Name = familyName, FamilyName = familyName, IsActive = true }
                    }
                });
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error enumerating local folder families at '{_folderPath}'", ex);
        }

        return Task.FromResult<IEnumerable<FamilyItemModel>>(result);
    }

    public Task<bool> TransferFamilyAsync(FamilyItemModel familyItem, Document destinationDoc, CancellationToken cancellationToken = default)
    {
        if (familyItem == null || destinationDoc == null) return Task.FromResult(false);

        string filePath = familyItem.ImagePreviewUrl;
        bool success = _familyRevitService.TryLoadFamily(destinationDoc, filePath, out _);
        return Task.FromResult(success);
    }
}
