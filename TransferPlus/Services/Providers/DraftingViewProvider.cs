using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers
{
    /// <summary>
    /// Proveedor de datos para recolectar Vistas de Diseño (Drafting Views) de un documento de Revit.
    /// </summary>
    public class DraftingViewProvider
    {
        public static List<CadDetailItemModel> GetDraftingViews(Document doc)
        {
            var results = new List<CadDetailItemModel>();
            if (doc == null || !doc.IsValidObject) return results;

            try
            {
                // 1. Mapeo de Vistas colocadas en Planos (ViewId -> SheetNumber / Name y SheetId)
                var viewToSheetMap = new Dictionary<ElementId, (ElementId SheetId, string SheetName)>();
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

                // 3. Recolectar todas las Vistas de Diseño
                var draftingViews = new FilteredElementCollector(doc)
                    .OfClass(typeof(View))
                    .Cast<View>()
                    .Where(v => v.ViewType == ViewType.DraftingView && !v.IsTemplate)
                    .OrderBy(v => v.Name)
                    .ToList();

                foreach (var dv in draftingViews)
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
                        IsDraftingView = true,
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
