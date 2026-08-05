using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers;

public class AutodeskDocsFamilyProvider : IFamilyProvider
{
    private readonly FamilySourceItemModel _sourceItem;
    private readonly FamilyRevitService _familyRevitService;

    public string ProviderName => _sourceItem.Name;
    public FamilySourceType SourceType => FamilySourceType.AutodeskDocs;

    public AutodeskDocsFamilyProvider(FamilySourceItemModel sourceItem, FamilyRevitService familyRevitService)
    {
        _sourceItem = sourceItem ?? throw new ArgumentNullException(nameof(sourceItem));
        _familyRevitService = familyRevitService ?? throw new ArgumentNullException(nameof(familyRevitService));
    }

    public async Task<IEnumerable<FamilyItemModel>> GetFamiliesAsync(CancellationToken cancellationToken = default)
    {
        var result = new List<FamilyItemModel>();

        if (string.IsNullOrWhiteSpace(_sourceItem.ProjectId) || string.IsNullOrWhiteSpace(_sourceItem.FolderId))
        {
            TelemetryLogger.LogWarning($"[AutodeskDocsFamilyProvider] ProjectId o FolderId está vacío para fuente '{_sourceItem.Name}'.");
            return result;
        }

        try
        {
            string accessToken = _sourceItem.AccessToken;

            // Refresh token if needed
            if (string.IsNullOrWhiteSpace(accessToken) && !string.IsNullOrWhiteSpace(_sourceItem.RefreshToken))
            {
                var refreshRes = await AutodeskDocsService.RefreshTokenAsync(_sourceItem.RefreshToken, _sourceItem.ClientId, cancellationToken);
                if (refreshRes.Success)
                {
                    accessToken = refreshRes.AccessToken;
                    _sourceItem.AccessToken = refreshRes.AccessToken;
                    _sourceItem.RefreshToken = refreshRes.RefreshToken;
                    
                    var allSources = FamilySourceConfigService.LoadSources();
                    int idx = allSources.FindIndex(s => s.Id == _sourceItem.Id);
                    if (idx >= 0) allSources[idx] = _sourceItem;
                    FamilySourceConfigService.SaveSources(allSources);
                }
            }

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                TelemetryLogger.LogWarning($"[AutodeskDocsFamilyProvider] No hay Access Token válido para fuente '{_sourceItem.Name}'.");
                return result;
            }

            TelemetryLogger.LogInfo($"[AutodeskDocsFamilyProvider] Consultando contenidos de carpeta ACC '{_sourceItem.FolderName}' (FolderId: {_sourceItem.FolderId})...");

            var (subfolders, rfaItems) = await AutodeskDocsService.GetFolderContentsAsync(
                accessToken,
                _sourceItem.ProjectId,
                _sourceItem.FolderId,
                cancellationToken);

            foreach (var item in rfaItems)
            {
                cancellationToken.ThrowIfCancellationRequested();

                string familyName = Path.GetFileNameWithoutExtension(item.DisplayName);
                result.Add(new FamilyItemModel
                {
                    Name = familyName,
                    CategoryName = "Autodesk Docs",
                    SourceName = ProviderName,
                    StatusMessage = $"ACC Cloud ({FormatFileSize(item.ContentLength)})",
                    ImagePreviewUrl = item.Id, // ACC Item URN stored here for downloading
                    RevitVersion = "ACC Cloud",
                    Symbols = new List<FamilySymbolItemModel>
                    {
                        new FamilySymbolItemModel
                        {
                            Name = familyName,
                            FamilyName = familyName,
                            IsActive = true
                        }
                    }
                });
            }

            TelemetryLogger.LogInfo($"[AutodeskDocsFamilyProvider] Se obtuvieron {result.Count} familias .rfa de Autodesk Docs para '{_sourceItem.Name}'.");
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error en AutodeskDocsFamilyProvider para fuente '{_sourceItem.Name}'", ex);
        }

        return result;
    }

    public async Task<bool> TransferFamilyAsync(FamilyItemModel familyItem, Document destinationDoc, string? overrideFamilyName = null, CancellationToken cancellationToken = default)
    {
        if (familyItem == null) throw new ArgumentNullException(nameof(familyItem));
        if (destinationDoc == null) throw new ArgumentNullException(nameof(destinationDoc));

        try
        {
            string accessToken = _sourceItem.AccessToken;
            if (string.IsNullOrWhiteSpace(accessToken) && !string.IsNullOrWhiteSpace(_sourceItem.RefreshToken))
            {
                var refreshRes = await AutodeskDocsService.RefreshTokenAsync(_sourceItem.RefreshToken, _sourceItem.ClientId, cancellationToken);
                if (refreshRes.Success)
                {
                    accessToken = refreshRes.AccessToken;
                    _sourceItem.AccessToken = refreshRes.AccessToken;
                    _sourceItem.RefreshToken = refreshRes.RefreshToken;

                    var allSources = FamilySourceConfigService.LoadSources();
                    int idx = allSources.FindIndex(s => s.Id == _sourceItem.Id);
                    if (idx >= 0) allSources[idx] = _sourceItem;
                    FamilySourceConfigService.SaveSources(allSources);
                }
            }

            string itemId = familyItem.ImagePreviewUrl;
            TelemetryLogger.LogInfo($"[AutodeskDocsFamilyProvider] Obteniendo URL de descarga de ACC para '{familyItem.Name}' (Item: {itemId})...");

            string? downloadUrl = await AutodeskDocsService.GetLatestVersionDownloadUrlAsync(
                accessToken,
                _sourceItem.ProjectId,
                itemId,
                cancellationToken);

            if (string.IsNullOrWhiteSpace(downloadUrl))
            {
                TelemetryLogger.LogWarning($"[AutodeskDocsFamilyProvider] No se pudo obtener URL de descarga para '{familyItem.Name}'.");
                return false;
            }

            string localTempFilePath = await AutodeskDocsService.DownloadAccFamilyFileAsync(
                accessToken,
                downloadUrl,
                familyItem.Name + ".rfa",
                cancellationToken);

            if (!File.Exists(localTempFilePath))
            {
                TelemetryLogger.LogWarning($"[AutodeskDocsFamilyProvider] El archivo descargado no existe en: {localTempFilePath}");
                return false;
            }

            TelemetryLogger.LogInfo($"[AutodeskDocsFamilyProvider] Cargando archivo descargado '{familyItem.Name}' ({localTempFilePath}) en modelo Revit...");
            bool success = false;

            if (!string.IsNullOrWhiteSpace(overrideFamilyName) && destinationDoc.Application != null)
            {
                var uiApp = new Autodesk.Revit.UI.UIApplication(destinationDoc.Application);
                var targetSymbolNames = familyItem.Symbols?.Select(s => s.Name);
                success = _familyRevitService.TryLoadFileFamilyWithOverride(uiApp, destinationDoc, localTempFilePath, overrideFamilyName, targetSymbolNames);
            }
            else
            {
                if (familyItem.Symbols != null && familyItem.Symbols.Any())
                {
                    foreach (var sym in familyItem.Symbols)
                    {
                        if (_familyRevitService.TryLoadFamilySymbol(destinationDoc, localTempFilePath, sym.Name, out _))
                        {
                            success = true;
                        }
                    }
                }

                if (!success)
                {
                    TelemetryLogger.LogInfo($"[AutodeskDocsFamilyProvider] Cargando archivo .rfa completo de ACC '{familyItem.Name}'...");
                    success = _familyRevitService.TryLoadFamily(destinationDoc, localTempFilePath, out _);
                }
            }

            if (success)
            {
                TelemetryLogger.LogInfo($"[AutodeskDocsFamilyProvider] Familia de ACC '{familyItem.Name}' cargada con éxito en el documento.");
            }
            else
            {
                TelemetryLogger.LogWarning($"[AutodeskDocsFamilyProvider] No se pudo cargar la familia de ACC '{familyItem.Name}' en el documento.");
            }
            return success;
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error transfiriendo familia ACC '{familyItem.Name}' a modelo destino '{destinationDoc.Title}'", ex);
            return false;
        }
    }

    private static string FormatFileSize(long bytes)
    {
        if (bytes <= 0) return "0 B";
        string[] suf = { "B", "KB", "MB", "GB", "TB" };
        int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
        double num = Math.Round(bytes / Math.Pow(1024, place), 1);
        return $"{num} {suf[place]}";
    }
}
