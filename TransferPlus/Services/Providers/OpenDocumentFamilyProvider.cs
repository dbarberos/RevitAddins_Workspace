using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers;

public class OpenDocumentFamilyProvider : IFamilyProvider
{
    private readonly Document _sourceDoc;
    private readonly FamilyRevitService _familyRevitService;

    public string ProviderName => _sourceDoc?.Title ?? "Modelo Abierto";
    public FamilySourceType SourceType => FamilySourceType.Directory;

    public OpenDocumentFamilyProvider(Document sourceDoc, FamilyRevitService familyRevitService)
    {
        _sourceDoc = sourceDoc;
        _familyRevitService = familyRevitService;
    }

    public Task<IEnumerable<FamilyItemModel>> GetFamiliesAsync(CancellationToken cancellationToken = default)
    {
        var result = new List<FamilyItemModel>();

        if (_sourceDoc == null || !_sourceDoc.IsValidObject)
        {
            TelemetryLogger.LogWarning("OpenDocumentFamilyProvider: Documento de origen inválido o nulo.");
            return Task.FromResult<IEnumerable<FamilyItemModel>>(result);
        }

        try
        {
            TelemetryLogger.LogInfo($"OpenDocumentFamilyProvider: Recolectando familias editables en modelo abierto '{_sourceDoc.Title}'...");
            var families = new FilteredElementCollector(_sourceDoc)
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
                    if (_sourceDoc.GetElement(symbolId) is FamilySymbol symbol)
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
                    StatusMessage = $"{symbolModels.Count} tipo(s) en modelo abierto",
                    Symbols = symbolModels,
                    NativeFamily = family,
                    SourceDocument = _sourceDoc
                });
            }

            TelemetryLogger.LogInfo($"OpenDocumentFamilyProvider: Se obtuvieron {result.Count} familias en modelo abierto '{_sourceDoc.Title}'.");
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error enumerando familias en modelo abierto '{_sourceDoc.Title}'", ex);
        }

        return Task.FromResult<IEnumerable<FamilyItemModel>>(result);
    }

    public Task<bool> TransferFamilyAsync(FamilyItemModel familyItem, Document destinationDoc, CancellationToken cancellationToken = default)
    {
        if (familyItem == null || destinationDoc == null || _sourceDoc == null) return Task.FromResult(false);

        if (familyItem.NativeFamily is Family sourceFamily)
        {
            TelemetryLogger.LogInfo($"OpenDocumentFamilyProvider: Iniciando transferencia en memoria de familia '{sourceFamily.Name}' desde '{_sourceDoc.Title}' a destino...");
            bool success = _familyRevitService.TryTransferInMemoryFamily(_sourceDoc, sourceFamily, destinationDoc, out _);
            if (success)
            {
                TelemetryLogger.LogInfo($"OpenDocumentFamilyProvider: Familia '{sourceFamily.Name}' transferida con éxito en memoria.");
            }
            else
            {
                TelemetryLogger.LogWarning($"OpenDocumentFamilyProvider: No se pudo transferir en memoria la familia '{sourceFamily.Name}'.");
            }
            return Task.FromResult(success);
        }

        TelemetryLogger.LogWarning($"NativeFamily no disponible para la familia '{familyItem.Name}'.");
        return Task.FromResult(false);
    }
}
