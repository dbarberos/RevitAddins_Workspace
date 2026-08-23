using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers
{
    /// <summary>
    /// Proveedor de datos para recolectar Vistas de Detalle (Detail Views, Detail Sections y Detail Callouts) de un documento de Revit (incluidos modelos vinculados).
    /// </summary>
    public class DetailViewProvider
    {
        public static List<CadDetailItemModel> GetDetailViews(Document doc)
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
                    LoggerService.LogWarning($"DetailViewProvider: No se pudieron mapear viewports en '{doc.Title}': {ex.Message}");
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
                    LoggerService.LogWarning($"DetailViewProvider: No se pudieron mapear import instances en '{doc.Title}': {ex.Message}");
                }

                // 3. Recolectar todas las Vistas de Detalle, Secciones de Detalle y Callouts
                var allViews = new FilteredElementCollector(doc)
                    .OfClass(typeof(View))
                    .WhereElementIsNotElementType()
                    .Cast<View>()
                    .ToList();

                foreach (var v in allViews)
                {
                    try
                    {
                        if (!v.IsValidObject || v.IsTemplate) continue;

                        bool isDetail = false;
                        bool isCallout = false;

                        try
                        {
                            if (v.ViewType == ViewType.Detail)
                            {
                                isDetail = true;
                            }
                        }
                        catch { }

                        try
                        {
                            if (v.IsCallout)
                            {
                                isCallout = true;
                            }
                        }
                        catch { }

                        // Verificar si es una sección de detalle
                        if (!isDetail && !isCallout && v is ViewSection vs)
                        {
                            try
                            {
                                if (v.ViewType == ViewType.Section && (v.Name.IndexOf("Detail", StringComparison.OrdinalIgnoreCase) >= 0 || v.Name.IndexOf("Detalle", StringComparison.OrdinalIgnoreCase) >= 0))
                                {
                                    isDetail = true;
                                }
                            }
                            catch { }
                        }

                        if (!isDetail && !isCallout) continue;

                        string sheetInfo = string.Empty;
                        ElementId? sheetId = null;
                        if (viewToSheetMap.TryGetValue(v.Id, out var sInfo))
                        {
                            sheetInfo = sInfo.SheetName;
                            sheetId = sInfo.SheetId;
                        }

                        int cadCount = viewCadCountMap.TryGetValue(v.Id, out var count) ? count : 0;
                        string displayCat = isCallout ? "Detail Callouts" : "Detail Views";

                        var item = new CadDetailItemModel
                        {
                            Name = v.Name,
                            ViewName = v.Name,
                            SheetName = sheetInfo,
                            SheetId = sheetId,
                            Category = displayCat,
                            IsDraftingView = false,
                            IsLinked = doc.IsLinked,
                            CadCount = cadCount,
                            ElementId = v.Id,
                            OwnerViewId = v.Id,
                            NativeElement = v,
                            SourceDocument = doc,
                            SourceDocumentName = doc.Title
                        };

                        results.Add(item);
                    }
                    catch (Exception ex)
                    {
                        LoggerService.LogWarning($"DetailViewProvider: Error procesando vista individual: {ex.Message}");
                    }
                }

                LoggerService.LogInfo($"DetailViewProvider: Recolectadas {results.Count} vistas de detalle/callouts en '{doc.Title}'.");
            }
            catch (Exception ex)
            {
                LoggerService.LogError($"DetailViewProvider: Error recolectando vistas de detalle en '{doc.Title}'", ex);
            }

            return results;
        }
    }
}
