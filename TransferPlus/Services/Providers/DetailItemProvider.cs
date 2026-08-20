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

                // 2. Recolectar instancias de Componentes de Detalle 2D (FamilyInstances, FilledRegions, etc.)
                var detailElements = new FilteredElementCollector(doc)
                    .OfCategory(BuiltInCategory.OST_DetailComponents)
                    .WhereElementIsNotElementType()
                    .ToElements();

                foreach (var elem in detailElements)
                {
                    string displayName;
                    if (elem is FamilyInstance inst)
                    {
                        string familyName = inst.Symbol?.FamilyName ?? "Detail Component";
                        string typeName = inst.Name;
                        displayName = !string.IsNullOrWhiteSpace(familyName) ? $"{familyName} : {typeName}" : typeName;
                    }
                    else if (elem is FilledRegion filledRegion)
                    {
                        var frType = doc.GetElement(filledRegion.GetTypeId());
                        string typeName = frType != null && !string.IsNullOrWhiteSpace(frType.Name) ? frType.Name : filledRegion.Name;
                        displayName = $"Filled Region : {typeName}";
                    }
                    else
                    {
                        string typeName = string.Empty;
                        if (elem.GetTypeId() != ElementId.InvalidElementId && doc.GetElement(elem.GetTypeId()) is Element typeElem && !string.IsNullOrWhiteSpace(typeElem.Name))
                        {
                            typeName = typeElem.Name;
                        }
                        else
                        {
                            typeName = elem.Name;
                        }
                        displayName = !string.IsNullOrWhiteSpace(typeName) ? typeName : $"Detail Item ({elem.Id.Value})";
                    }

                    string viewName = "Model / Unassigned View";
                    string sheetName = string.Empty;

                    if (elem.OwnerViewId != ElementId.InvalidElementId && doc.GetElement(elem.OwnerViewId) is View ownerView)
                    {
                        viewName = ownerView.Name;
                        if (viewToSheetMap.TryGetValue(ownerView.Id, out var sName))
                        {
                            sheetName = sName;
                        }
                    }

                    var item = new CadDetailItemModel
                    {
                        Name = displayName,
                        ViewName = viewName,
                        SheetName = sheetName,
                        Category = "Detail Items",
                        IsDraftingView = false,
                        IsLinked = false,
                        CadCount = 0,
                        ElementId = elem.Id,
                        OwnerViewId = elem.OwnerViewId,
                        NativeElement = elem,
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
