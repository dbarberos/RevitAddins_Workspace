using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers;

public class OpenDocumentCadProvider : ICadProvider
{
    private readonly Document _sourceDoc;
    private readonly FamilyRevitService _familyRevitService;

    public string ProviderName => _sourceDoc?.Title ?? "Modelo Abierto";
    public CadSourceType? SourceType => null;

    public OpenDocumentCadProvider(Document sourceDoc, FamilyRevitService familyRevitService)
    {
        _sourceDoc = sourceDoc;
        _familyRevitService = familyRevitService;
    }

    public Task<IEnumerable<CadDetailItemModel>> GetCadItemsAsync(CancellationToken cancellationToken = default)
    {
        var result = new List<CadDetailItemModel>();

        if (_sourceDoc == null || !_sourceDoc.IsValidObject)
        {
            TelemetryLogger.LogWarning("OpenDocumentCadProvider: Documento de origen inválido o nulo.");
            return Task.FromResult<IEnumerable<CadDetailItemModel>>(result);
        }

        try
        {
            TelemetryLogger.LogInfo($"OpenDocumentCadProvider: Recolectando todos los detalles y CADs en modelo abierto '{_sourceDoc.Title}'...");
            
            result.AddRange(DraftingViewProvider.GetDraftingViews(_sourceDoc));
            result.AddRange(CadInstanceProvider.GetCadInstances(_sourceDoc));
            result.AddRange(DetailViewProvider.GetDetailViews(_sourceDoc));
            result.AddRange(DetailGroupProvider.GetDetailGroups(_sourceDoc));
            result.AddRange(DetailItemProvider.GetDetailItems(_sourceDoc));

            TelemetryLogger.LogInfo($"OpenDocumentCadProvider: Se obtuvieron {result.Count} elementos CAD/detalles en modelo abierto '{_sourceDoc.Title}'.");
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error enumerando elementos CAD en modelo abierto '{_sourceDoc.Title}'", ex);
        }

        return Task.FromResult<IEnumerable<CadDetailItemModel>>(result);
    }

    public Task<bool> TransferCadItemAsync(CadDetailItemModel cadItem, Document destinationDoc, bool isLinkMode = false, string? overrideViewName = null, CancellationToken cancellationToken = default)
    {
        if (cadItem == null || destinationDoc == null || _sourceDoc == null) return Task.FromResult(false);

        if (cadItem.ElementId != null && cadItem.ElementId != ElementId.InvalidElementId)
        {
            if (cadItem.IsDraftingView || cadItem.NativeElement is View)
            {
                int count = _familyRevitService.TransferDraftingViews(_sourceDoc, destinationDoc, new List<ElementId> { cadItem.ElementId });
                return Task.FromResult(count > 0);
            }
            else if (cadItem.NativeElement is ImportInstance)
            {
                int count = _familyRevitService.TransferCadInstancesToDraftingViews(_sourceDoc, destinationDoc, new List<ElementId> { cadItem.ElementId });
                return Task.FromResult(count > 0);
            }
            else
            {
                int count = _familyRevitService.TransferDraftingViews(_sourceDoc, destinationDoc, new List<ElementId> { cadItem.ElementId });
                return Task.FromResult(count > 0);
            }
        }

        return Task.FromResult(false);
    }
}
