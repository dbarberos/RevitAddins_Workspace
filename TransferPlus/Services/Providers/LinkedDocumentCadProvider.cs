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

    public Task<bool> TransferCadItemAsync(CadDetailItemModel cadItem, Document destinationDoc, bool isLinkMode = false, string? overrideViewName = null, CancellationToken cancellationToken = default)
    {
        if (cadItem == null || destinationDoc == null || _linkInstance == null) return Task.FromResult(false);

        var linkDoc = _linkInstance.GetLinkDocument();
        if (linkDoc == null || !linkDoc.IsValidObject) return Task.FromResult(false);

        if (cadItem.ElementId != null && cadItem.ElementId != ElementId.InvalidElementId)
        {
            if (cadItem.IsDraftingView || cadItem.NativeElement is View)
            {
                int count = _familyRevitService.TransferDraftingViews(linkDoc, destinationDoc, new List<ElementId> { cadItem.ElementId });
                return Task.FromResult(count > 0);
            }
            else if (cadItem.NativeElement is ImportInstance)
            {
                int count = _familyRevitService.TransferCadInstancesToDraftingViews(linkDoc, destinationDoc, new List<ElementId> { cadItem.ElementId });
                return Task.FromResult(count > 0);
            }
            else
            {
                int count = _familyRevitService.TransferDraftingViews(linkDoc, destinationDoc, new List<ElementId> { cadItem.ElementId });
                return Task.FromResult(count > 0);
            }
        }

        return Task.FromResult(false);
    }
}
