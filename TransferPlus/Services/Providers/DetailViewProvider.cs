using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers
{
    /// <summary>
    /// Proveedor de datos para recolectar Vistas de Detalle (Detail Views y Detail Callouts) de un documento de Revit.
    /// </summary>
    public class DetailViewProvider
    {
        public static List<CadDetailItemModel> GetDetailViews(Document doc)
        {
            var results = new List<CadDetailItemModel>();
            if (doc == null || !doc.IsValidObject) return results;

            try
            {
                // 1. Mapeo de Vistas colocadas en Planos (ViewId -> SheetNumber / Name)
                var viewToSheetMap = new Dictionary<ElementId, string>();
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
                            viewToSheetMap[viewId] = $"{sheet.SheetNumber} - {sheet.Name}";
                        }
                    }
                    catch { }
                }

                // 2. Mapeo de CADs (ImportInstance) por Vista anfitriona
                var viewCadCountMap = new Dictionary<ElementId, int>();
                var importInstances = new FilteredElementCollector(doc)
                    .OfClass(typeof(ImportInstance))
                    .WhereElementIsNotElementType()
                    .Cast<ImportInstance>()
                    .ToList();

                foreach (var imp in importInstances)
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

                // 3. Recolectar todas las Vistas de Detalle y Callouts de Detalle
                var detailViews = new FilteredElementCollector(doc)
                    .OfClass(typeof(View))
                    .Cast<View>()
                    .Where(v => !v.IsTemplate && (v.ViewType == ViewType.Detail || v.IsCallout))
                    .OrderBy(v => v.Name)
                    .ToList();

                foreach (var dv in detailViews)
                {
                    string sheetInfo = viewToSheetMap.TryGetValue(dv.Id, out var sName) ? sName : string.Empty;
                    int cadCount = viewCadCountMap.TryGetValue(dv.Id, out var count) ? count : 0;

                    string displayCat = dv.IsCallout ? "Detail Callouts" : "Detail Views";

                    var item = new CadDetailItemModel
                    {
                        Name = dv.Name,
                        ViewName = dv.Name,
                        SheetName = sheetInfo,
                        Category = displayCat,
                        IsDraftingView = false,
                        IsLinked = false,
                        CadCount = cadCount,
                        ElementId = dv.Id,
                        OwnerViewId = dv.Id,
                        NativeElement = dv,
                        SourceDocument = doc,
                        SourceDocumentName = doc.Title
                    };

                    results.Add(item);
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
