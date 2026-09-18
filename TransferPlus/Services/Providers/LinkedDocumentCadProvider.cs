using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers;

public class LinkedDocumentCadProvider : ICadProvider
{
    private readonly RevitLinkInstance _linkInstance;
    private readonly FamilyRevitService _familyRevitService;

    public string ProviderName => _linkInstance?.Name ?? "Modelo Vinculado";
    public CadSourceType? SourceType => null;

    public LinkedDocumentCadProvider(RevitLinkInstance linkInstance, FamilyRevitService familyRevitService)
    {
        _linkInstance = linkInstance;
        _familyRevitService = familyRevitService;
    }

    public Task<IEnumerable<CadDetailItemModel>> GetCadItemsAsync(CancellationToken cancellationToken = default)
    {
        var result = new List<CadDetailItemModel>();

        if (_linkInstance == null || !_linkInstance.IsValidObject)
        {
            TelemetryLogger.LogWarning("LinkedDocumentCadProvider: RevitLinkInstance inválido o nulo.");
            return Task.FromResult<IEnumerable<CadDetailItemModel>>(result);
        }

        var linkDoc = _linkInstance.GetLinkDocument();
        if (linkDoc == null || !linkDoc.IsValidObject)
        {
            TelemetryLogger.LogWarning($"LinkedDocumentCadProvider: No se pudo obtener el documento vinculado para '{_linkInstance.Name}'.");
            return Task.FromResult<IEnumerable<CadDetailItemModel>>(result);
        }

        try
        {
            TelemetryLogger.LogInfo($"LinkedDocumentCadProvider: Recolectando todos los detalles y CADs en modelo vinculado '{linkDoc.Title}'...");
            
            result.AddRange(DraftingViewProvider.GetDraftingViews(linkDoc));
            result.AddRange(CadInstanceProvider.GetCadInstances(linkDoc));
            result.AddRange(DetailViewProvider.GetDetailViews(linkDoc));
            result.AddRange(DetailGroupProvider.GetDetailGroups(linkDoc));
            result.AddRange(DetailItemProvider.GetDetailItems(linkDoc));

            TelemetryLogger.LogInfo($"LinkedDocumentCadProvider: Se obtuvieron {result.Count} elementos CAD/detalles en modelo vinculado '{linkDoc.Title}'.");
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error enumerando elementos CAD en modelo vinculado '{_linkInstance.Name}'", ex);
        }

        return Task.FromResult<IEnumerable<CadDetailItemModel>>(result);
    }

    public Task<bool> TransferCadItemAsync(
        CadDetailItemModel cadItem, 
        Document destinationDoc, 
        bool isLinkMode = false, 
        string? overrideViewName = null, 
        bool keepOriginal = false, 
        string? suffix = null, 
        CancellationToken cancellationToken = default)
    {
        if (cadItem == null || destinationDoc == null || _linkInstance == null) return Task.FromResult(false);

        var linkDoc = _linkInstance.GetLinkDocument();
        if (linkDoc == null || !linkDoc.IsValidObject) return Task.FromResult(false);

        if (cadItem.ElementId != null && cadItem.ElementId != ElementId.InvalidElementId)
        {
            var customNames = !string.IsNullOrWhiteSpace(overrideViewName)
                ? new Dictionary<ElementId, string> { [cadItem.ElementId] = overrideViewName }
                : null;

            if (cadItem.IsDraftingView || cadItem.NativeElement is ViewDrafting)
            {
                int count = _familyRevitService.TransferDraftingViews(linkDoc, destinationDoc, new List<ElementId> { cadItem.ElementId }, customNames, keepOriginal, suffix);
                return Task.FromResult(count > 0);
            }
            else if (cadItem.NativeElement is View)
            {
                int count = _familyRevitService.TransferModelDetailViewsToDraftingViews(linkDoc, destinationDoc, new List<ElementId> { cadItem.ElementId }, customNames, keepOriginal, suffix);
                return Task.FromResult(count > 0);
            }
            else if (cadItem.NativeElement is ImportInstance)
            {
                int count = _familyRevitService.TransferCadInstancesToDraftingViews(linkDoc, destinationDoc, new List<ElementId> { cadItem.ElementId }, customNames, keepOriginal, suffix);
                return Task.FromResult(count > 0);
            }
            else if (cadItem.NativeElement is FamilyInstance || cadItem.NativeElement is FamilySymbol)
            {
                var renameMap = !string.IsNullOrWhiteSpace(overrideViewName)
                    ? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) { [cadItem.Name] = overrideViewName }
                    : null;
                int count = _familyRevitService.TransferDetailComponentFamilies(linkDoc, destinationDoc, new List<ElementId> { cadItem.ElementId }, renameMap, keepOriginal, suffix);
                return Task.FromResult(count > 0);
            }
            else
            {
                int count = _familyRevitService.TransferDetailAnnotationsToDraftingViews(linkDoc, destinationDoc, new List<ElementId> { cadItem.ElementId }, customNames, keepOriginal, suffix);
                return Task.FromResult(count > 0);
            }
        }

        return Task.FromResult(false);
    }
}
