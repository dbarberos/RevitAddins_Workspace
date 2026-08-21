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
            TelemetryLogger.LogInfo($"OpenDocumentCadProvider: Recolectando instancias CAD y vistas de diseño en modelo abierto '{_sourceDoc.Title}'...");
            
            var cadInstances = CadInstanceProvider.GetCadInstances(_sourceDoc);
            result.AddRange(cadInstances);

            TelemetryLogger.LogInfo($"OpenDocumentCadProvider: Se obtuvieron {result.Count} elementos CAD en modelo abierto '{_sourceDoc.Title}'.");
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
            int count = _familyRevitService.TransferCadInstancesToDraftingViews(_sourceDoc, destinationDoc, new List<ElementId> { cadItem.ElementId });
            return Task.FromResult(count > 0);
        }

        return Task.FromResult(false);
    }
}
