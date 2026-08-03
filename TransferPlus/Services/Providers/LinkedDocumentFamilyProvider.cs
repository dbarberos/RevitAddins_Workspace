using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers;

public class LinkedDocumentFamilyProvider : IFamilyProvider
{
    private readonly RevitLinkInstance _linkInstance;
    private readonly FamilyRevitService _familyRevitService;

    public string ProviderName
    {
        get
        {
            var doc = _linkInstance?.GetLinkDocument();
            return doc?.Title ?? _linkInstance?.Name ?? "Modelo Vinculado";
        }
    }

    public FamilySourceType SourceType => FamilySourceType.Directory;

    public LinkedDocumentFamilyProvider(RevitLinkInstance linkInstance, FamilyRevitService familyRevitService)
    {
        _linkInstance = linkInstance;
        _familyRevitService = familyRevitService;
    }

    public Task<IEnumerable<FamilyItemModel>> GetFamiliesAsync(CancellationToken cancellationToken = default)
    {
        var result = new List<FamilyItemModel>();

        if (_linkInstance == null || !_linkInstance.IsValidObject)
        {
            return Task.FromResult<IEnumerable<FamilyItemModel>>(result);
        }

        var linkDoc = _linkInstance.GetLinkDocument();
        if (linkDoc == null || !linkDoc.IsValidObject)
        {
            TelemetryLogger.LogWarning($"El documento vinculado para '{_linkInstance.Name}' no está cargado o disponible.");
            return Task.FromResult<IEnumerable<FamilyItemModel>>(result);
        }

        try
        {
            var families = new FilteredElementCollector(linkDoc)
                .OfClass(typeof(Family))
                .Cast<Family>()
                .Where(f => f.IsEditable && !f.IsInPlace && f.FamilyCategory != null)
                .OrderBy(f => f.Name);

            foreach (var family in families)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var symbolModels = new List<FamilySymbolItemModel>();
                var symbolIds = family.GetFamilySymbolIds();
                foreach (var symbolId in symbolIds)
                {
                    if (linkDoc.GetElement(symbolId) is FamilySymbol symbol)
                    {
                        symbolModels.Add(new FamilySymbolItemModel
                        {
                            Name = symbol.Name,
                            FamilyName = family.Name,
                            IsActive = symbol.IsActive,
                            NativeSymbol = symbol
                        });
                    }
                }

                result.Add(new FamilyItemModel
                {
                    Name = family.Name,
                    CategoryName = family.FamilyCategory?.Name ?? "General",
                    SourceName = ProviderName,
                    StatusMessage = $"{symbolModels.Count} tipo(s) en modelo vinculado",
                    Symbols = symbolModels,
                    NativeFamily = family,
                    SourceDocument = linkDoc
                });
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error enumerando familias en modelo vinculado '{linkDoc.Title}'", ex);
        }

        return Task.FromResult<IEnumerable<FamilyItemModel>>(result);
    }

    public Task<bool> TransferFamilyAsync(FamilyItemModel familyItem, Document destinationDoc, CancellationToken cancellationToken = default)
    {
        if (familyItem == null || destinationDoc == null) return Task.FromResult(false);

        var linkDoc = familyItem.SourceDocument as Document ?? _linkInstance?.GetLinkDocument();
        if (linkDoc == null || !linkDoc.IsValidObject)
        {
            TelemetryLogger.LogWarning($"Documento vinculado no disponible para la familia '{familyItem.Name}'.");
            return Task.FromResult(false);
        }

        if (familyItem.NativeFamily is Family sourceFamily)
        {
            // Transfer directly in-memory via Document.EditFamily -> LoadFamily
            bool success = _familyRevitService.TryTransferInMemoryFamily(linkDoc, sourceFamily, destinationDoc, out _);
            return Task.FromResult(success);
        }

        TelemetryLogger.LogWarning($"NativeFamily no disponible para la familia vinculada '{familyItem.Name}'.");
        return Task.FromResult(false);
    }
}
