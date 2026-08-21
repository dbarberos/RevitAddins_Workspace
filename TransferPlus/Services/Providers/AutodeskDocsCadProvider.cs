using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers;

public class AutodeskDocsCadProvider : ICadProvider
{
    private readonly CadSourceItemModel _sourceItem;
    private readonly FamilyRevitService _familyRevitService;

    public string ProviderName => _sourceItem.Name;
    public CadSourceType? SourceType => CadSourceType.AutodeskDocs;

    public AutodeskDocsCadProvider(CadSourceItemModel sourceItem, FamilyRevitService familyRevitService)
    {
        _sourceItem = sourceItem ?? throw new ArgumentNullException(nameof(sourceItem));
        _familyRevitService = familyRevitService ?? throw new ArgumentNullException(nameof(familyRevitService));
    }

    public async Task<IEnumerable<CadDetailItemModel>> GetCadItemsAsync(CancellationToken cancellationToken = default)
    {
        var result = new List<CadDetailItemModel>();

        if (string.IsNullOrWhiteSpace(_sourceItem.ProjectId) || string.IsNullOrWhiteSpace(_sourceItem.FolderId))
        {
            TelemetryLogger.LogWarning($"[AutodeskDocsCadProvider] ProjectId o FolderId está vacío para fuente '{_sourceItem.Name}'.");
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
                    
                    var allSources = CadSourceConfigService.LoadSources();
                    int idx = allSources.FindIndex(s => s.Id == _sourceItem.Id);
                    if (idx >= 0) allSources[idx] = _sourceItem;
                    CadSourceConfigService.SaveSources(allSources);
                }
            }

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                TelemetryLogger.LogWarning($"[AutodeskDocsCadProvider] No hay Access Token válido para fuente '{_sourceItem.Name}'.");
                return result;
            }

            TelemetryLogger.LogInfo($"[AutodeskDocsCadProvider] Consultando contenidos CAD de carpeta ACC '{_sourceItem.FolderName}' (FolderId: {_sourceItem.FolderId})...");

            var (subfolders, cadItems) = await AutodeskDocsService.GetFolderCadContentsAsync(
                accessToken,
                _sourceItem.ProjectId,
                _sourceItem.FolderId,
                cancellationToken);

            foreach (var item in cadItems)
            {
                cancellationToken.ThrowIfCancellationRequested();

                string ext = Path.GetExtension(item.DisplayName).TrimStart('.').ToLowerInvariant();
                string cadName = Path.GetFileNameWithoutExtension(item.DisplayName);

                result.Add(new CadDetailItemModel
                {
                    Name = cadName,
                    ViewName = item.DisplayName,
                    FilePath = item.Id, // ACC Item URN stored here for downloading
                    Format = ext,
                    Category = $"{ext.ToUpperInvariant()} File",
                    FileSizeBytes = item.ContentLength,
                    LastModified = item.LastModified,
                    SourceDocumentName = ProviderName,
                    IsExternalFile = true,
                    SourceType = CadSourceType.AutodeskDocs
                });
            }

            TelemetryLogger.LogInfo($"[AutodeskDocsCadProvider] Se obtuvieron {result.Count} archivos CAD de Autodesk Docs en carpeta '{_sourceItem.FolderName}'.");
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error en AutodeskDocsCadProvider para carpeta '{_sourceItem.FolderName}'", ex);
        }

        return result;
    }

    public async Task<bool> TransferCadItemAsync(CadDetailItemModel cadItem, Document destinationDoc, bool isLinkMode = false, string? overrideViewName = null, CancellationToken cancellationToken = default)
    {
        if (cadItem == null || destinationDoc == null || _sourceItem == null) return false;

        string itemId = cadItem.FilePath;
        if (string.IsNullOrWhiteSpace(itemId)) return false;
        string tempLocalPath = string.Empty;

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
                }
            }

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                TelemetryLogger.LogWarning($"[AutodeskDocsCadProvider] No hay Access Token válido para descargar '{cadItem.Name}'.");
                return false;
            }

            TelemetryLogger.LogInfo($"[AutodeskDocsCadProvider] Obteniendo URL de descarga para CAD '{cadItem.Name}' (Item: {itemId})...");
            string? downloadUrl = await AutodeskDocsService.GetLatestVersionDownloadUrlAsync(accessToken, _sourceItem.ProjectId, itemId, cancellationToken);
            if (string.IsNullOrWhiteSpace(downloadUrl))
            {
                TelemetryLogger.LogWarning($"[AutodeskDocsCadProvider] No se pudo obtener URL de descarga para '{cadItem.Name}'.");
                return false;
            }

            string rawFileName = !string.IsNullOrWhiteSpace(cadItem.ViewName) ? cadItem.ViewName : $"{cadItem.Name}.{(string.IsNullOrWhiteSpace(cadItem.Format) ? "dwg" : cadItem.Format)}";
            tempLocalPath = await AutodeskDocsService.DownloadAccFamilyFileAsync(accessToken, downloadUrl, rawFileName, cancellationToken);

            TelemetryLogger.LogInfo($"[AutodeskDocsCadProvider] Archivo CAD descargado en '{tempLocalPath}'. Transfiriendo a Revit (LinkMode: {isLinkMode})...");

            bool loaded = _familyRevitService.TransferExternalCadToDraftingView(destinationDoc, tempLocalPath, overrideViewName, isLinkMode);

            if (loaded)
            {
                TelemetryLogger.LogInfo($"[AutodeskDocsCadProvider] Archivo CAD '{cadItem.Name}' transferido con éxito.");
            }
            else
            {
                TelemetryLogger.LogWarning($"[AutodeskDocsCadProvider] No se pudo transferir archivo CAD '{cadItem.Name}'.");
            }
            return loaded;
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error descargando y transfiriendo CAD de Autodesk Docs '{itemId}'", ex);
            return false;
        }
        finally
        {
            if (!isLinkMode && !string.IsNullOrEmpty(tempLocalPath))
            {
                FamilyFileManager.RemoveFamilyLocalFile(tempLocalPath);
            }
        }
    }
}
