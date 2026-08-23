using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers
{
    /// <summary>
    /// Proveedor de datos para recolectar Vistas de Diseño (Drafting Views) de un documento de Revit (incluidos modelos vinculados).
    /// </summary>
    public class DraftingViewProvider
    {
        public static List<CadDetailItemModel> GetDraftingViews(Document doc)
        {
            var results = new List<CadDetailItemModel>();
            if (doc == null || !doc.IsValidObject) return results;

            try
            {
                // 1. Mapeo seguro de Vistas colocadas en Planos (ViewId -> SheetNumber / Name y SheetId)
                var viewToSheetMap = new Dictionary<ElementId, (ElementId SheetId, string SheetName)>();
                try
                {
                    var viewports = new FilteredElementCollector(doc)
                        .OfClass(typeof(Viewport))
                        .Cast<Viewport>()
                        .ToList();

                    foreach (var vp in viewports)
                    {
                        try
                        {
                            var viewId = vp.ViewId;
                            var sheetId = vp.SheetId;
                            if (sheetId != ElementId.InvalidElementId && doc.GetElement(sheetId) is ViewSheet sheet)
                            {
                                viewToSheetMap[viewId] = (sheet.Id, $"{sheet.SheetNumber} - {sheet.Name}");
                            }
                        }
                        catch { }
                    }
                }
                catch (Exception ex)
                {
                    LoggerService.LogWarning($"DraftingViewProvider: No se pudieron mapear viewports en '{doc.Title}': {ex.Message}");
                }

                // 2. Mapeo seguro de CADs (ImportInstance) por Vista anfitriona
                var viewCadCountMap = new Dictionary<ElementId, int>();
                try
                {
                    var importInstances = new FilteredElementCollector(doc)
                        .OfClass(typeof(ImportInstance))
                        .WhereElementIsNotElementType()
                        .Cast<ImportInstance>()
                        .ToList();

                    foreach (var imp in importInstances)
                    {
                        try
                        {
                            if (imp.OwnerViewId != ElementId.InvalidElementId)
                            {
                                if (!viewCadCountMap.ContainsKey(imp.OwnerViewId))
                                {
                                    viewCadCountMap[imp.OwnerViewId] = 0;
                                }
                                viewCadCountMap[imp.OwnerViewId]++;
                            }
                        }
                        catch { }
                    }
                }
                catch (Exception ex)
                {
                    LoggerService.LogWarning($"DraftingViewProvider: No se pudieron mapear import instances en '{doc.Title}': {ex.Message}");
                }

                // 3. Recolectar todas las Vistas de Diseño directamente por clase ViewDrafting
                var collectedViews = new List<View>();
                try
                {
                    var draftingViews = new FilteredElementCollector(doc)
                        .OfClass(typeof(ViewDrafting))
                        .WhereElementIsNotElementType()
                        .Cast<ViewDrafting>()
                        .ToList();

                    foreach (var dv in draftingViews)
                    {
                        try
                        {
                            if (dv.IsValidObject && !dv.IsTemplate)
                            {
                                collectedViews.Add(dv);
                            }
                        }
                        catch { }
                    }
                }
                catch (Exception ex)
                {
                    LoggerService.LogWarning($"DraftingViewProvider: Falló recolección directa por ViewDrafting en '{doc.Title}': {ex.Message}");
                }

                // Fallback secundario: Si no se encontró ninguna por clase ViewDrafting, intentar por View genérica
                if (!collectedViews.Any())
                {
                    try
                    {
                        var allViews = new FilteredElementCollector(doc)
                            .OfClass(typeof(View))
                            .WhereElementIsNotElementType()
                            .Cast<View>()
                            .ToList();

                        foreach (var v in allViews)
                        {
                            try
                            {
                                if (v.IsValidObject && !v.IsTemplate && v.ViewType == ViewType.DraftingView)
                                {
                                    collectedViews.Add(v);
                                }
                            }
                            catch { }
                        }
                    }
                    catch { }
                }

                // 4. Construir modelos CadDetailItemModel de forma segura
                foreach (var dv in collectedViews.OrderBy(v => v.Name))
                {
                    try
                    {
                        string sheetInfo = string.Empty;
                        ElementId? sheetId = null;
                        if (viewToSheetMap.TryGetValue(dv.Id, out var sInfo))
                        {
                            sheetInfo = sInfo.SheetName;
                            sheetId = sInfo.SheetId;
                        }

                        int cadCount = viewCadCountMap.TryGetValue(dv.Id, out var count) ? count : 0;

                        var item = new CadDetailItemModel
                        {
                            Name = dv.Name,
                            ViewName = dv.Name,
                            SheetName = sheetInfo,
                            SheetId = sheetId,
                            Category = "Drafting Views",
                            IsDraftingView = true,
                            IsLinked = doc.IsLinked,
                            CadCount = cadCount,
                            ElementId = dv.Id,
                            OwnerViewId = dv.Id,
                            NativeElement = dv,
                            SourceDocument = doc,
                            SourceDocumentName = doc.Title
                        };

                        results.Add(item);
                    }
                    catch (Exception ex)
                    {
                        LoggerService.LogWarning($"DraftingViewProvider: Error procesando vista de diseño individual: {ex.Message}");
                    }
                }

                LoggerService.LogInfo($"DraftingViewProvider: Recolectadas {results.Count} vistas de diseño en '{doc.Title}'.");
            }
            catch (Exception ex)
            {
                LoggerService.LogError($"DraftingViewProvider: Error recolectando vistas de diseño en '{doc.Title}'", ex);
            }

            return results;
        }
    }
}
