using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers
{
    /// <summary>
    /// Proveedor de datos para recolectar Componentes de Detalle 2D (Detail Items) de un documento de Revit.
    /// </summary>
    public class DetailItemProvider
    {
        public static List<CadDetailItemModel> GetDetailItems(Document doc)
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

                // 2. Recolectar exclusivamente instancias de Componentes de Detalle 2D (FamilyInstance)
                var detailInstances = new FilteredElementCollector(doc)
                    .OfCategory(BuiltInCategory.OST_DetailComponents)
                    .WhereElementIsNotElementType()
                    .OfType<FamilyInstance>()
                    .ToList();

                foreach (var inst in detailInstances)
                {
                    string familyName = inst.Symbol?.FamilyName ?? "Detail Component";
                    string typeName = inst.Name;
                    string displayName = !string.IsNullOrWhiteSpace(familyName) ? $"{familyName} : {typeName}" : typeName;

                    string viewName = "Model / Unassigned View";
                    string sheetName = string.Empty;
                    ElementId? sheetId = null;

                    if (inst.OwnerViewId != ElementId.InvalidElementId && doc.GetElement(inst.OwnerViewId) is View ownerView)
                    {
                        viewName = ownerView.Name;
                        if (viewToSheetMap.TryGetValue(ownerView.Id, out var sInfo))
                        {
                            sheetName = sInfo.SheetName;
                            sheetId = sInfo.SheetId;
                        }
                    }

                    var item = new CadDetailItemModel
                    {
                        Name = displayName,
                        ViewName = viewName,
                        SheetName = sheetName,
                        SheetId = sheetId,
                        Category = "Detail Items",
                        IsDraftingView = false,
                        IsLinked = false,
                        CadCount = 0,
                        ElementId = inst.Id,
                        OwnerViewId = inst.OwnerViewId,
                        NativeElement = inst,
                        SourceDocument = doc,
                        SourceDocumentName = doc.Title
                    };

                    results.Add(item);
                }

                LoggerService.LogInfo($"DetailItemProvider: Recolectados {results.Count} componentes de detalle en '{doc.Title}'.");
            }
            catch (Exception ex)
            {
                LoggerService.LogError($"DetailItemProvider: Error recolectando componentes de detalle en '{doc.Title}'", ex);
            }

            return results;
        }
    }
}
