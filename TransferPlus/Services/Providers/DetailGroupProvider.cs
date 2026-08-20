using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers
{
    /// <summary>
    /// Proveedor de datos para recolectar Grupos de Detalle 2D (Detail Groups) de un documento de Revit.
    /// </summary>
    public class DetailGroupProvider
    {
        public static List<CadDetailItemModel> GetDetailGroups(Document doc)
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

                // 2. Recolectar instancias de Grupos de Detalle colocadas en vistas
                var placedGroups = new FilteredElementCollector(doc)
                    .OfClass(typeof(Group))
                    .WhereElementIsNotElementType()
                    .Cast<Group>()
                    .Where(g => (g.GroupType != null && g.GroupType.Category != null && g.GroupType.Category.Id.Value == (int)BuiltInCategory.OST_IOSDetailGroups) ||
                                (g.Category != null && g.Category.Id.Value == (int)BuiltInCategory.OST_IOSDetailGroups))
                    .ToList();

                var processedTypeIds = new HashSet<ElementId>();

                foreach (var group in placedGroups)
                {
                    string groupName = !string.IsNullOrWhiteSpace(group.Name) ? group.Name : (group.GroupType?.Name ?? $"Group_{group.Id.Value}");
                    string viewName = "Model / Unassigned View";
                    string sheetName = string.Empty;

                    if (group.OwnerViewId != ElementId.InvalidElementId && doc.GetElement(group.OwnerViewId) is View ownerView)
                    {
                        viewName = ownerView.Name;
                        if (viewToSheetMap.TryGetValue(ownerView.Id, out var sName))
                        {
                            sheetName = sName;
                        }
                    }

                    if (group.GetTypeId() != ElementId.InvalidElementId)
                    {
                        processedTypeIds.Add(group.GetTypeId());
                    }

                    var item = new CadDetailItemModel
                    {
                        Name = groupName,
                        ViewName = viewName,
                        SheetName = sheetName,
                        Category = "Detail Groups",
                        IsDraftingView = false,
                        IsLinked = false,
                        CadCount = 0,
                        ElementId = group.Id,
                        OwnerViewId = group.OwnerViewId,
                        NativeElement = group,
                        SourceDocument = doc,
                        SourceDocumentName = doc.Title
                    };

                    results.Add(item);
                }

                // 3. Recolectar Tipos de Grupos de Detalle no instanciados en el modelo
                var groupTypes = new FilteredElementCollector(doc)
                    .OfClass(typeof(GroupType))
                    .Cast<GroupType>()
                    .Where(gt => gt.Category != null && gt.Category.Id.Value == (int)BuiltInCategory.OST_IOSDetailGroups && !processedTypeIds.Contains(gt.Id))
                    .OrderBy(gt => gt.Name)
                    .ToList();

                foreach (var gt in groupTypes)
                {
                    var item = new CadDetailItemModel
                    {
                        Name = gt.Name,
                        ViewName = "(Group Definition / Unplaced)",
                        SheetName = string.Empty,
                        Category = "Detail Groups",
                        IsDraftingView = false,
                        IsLinked = false,
                        CadCount = 0,
                        ElementId = gt.Id,
                        OwnerViewId = ElementId.InvalidElementId,
                        NativeElement = gt,
                        SourceDocument = doc,
                        SourceDocumentName = doc.Title
                    };

                    results.Add(item);
                }

                LoggerService.LogInfo($"DetailGroupProvider: Recolectados {results.Count} grupos de detalle en '{doc.Title}'.");
            }
            catch (Exception ex)
            {
                LoggerService.LogError($"DetailGroupProvider: Error recolectando grupos de detalle en '{doc.Title}'", ex);
            }

            return results;
        }
    }
}
