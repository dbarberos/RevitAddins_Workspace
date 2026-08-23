using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers
{
    /// <summary>
    /// Proveedor de datos para recolectar Grupos de Detalle 2D (Detail Groups) de un documento de Revit (incluidos modelos vinculados).
    /// </summary>
    public class DetailGroupProvider
    {
        public static List<CadDetailItemModel> GetDetailGroups(Document doc)
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
                    LoggerService.LogWarning($"DetailGroupProvider: No se pudieron mapear viewports en '{doc.Title}': {ex.Message}");
                }

                var processedTypeIds = new HashSet<ElementId>();

                // 2. Recolectar instancias de Grupos de Detalle colocadas en vistas
                try
                {
                    var allGroups = new FilteredElementCollector(doc)
                        .OfClass(typeof(Group))
                        .WhereElementIsNotElementType()
                        .Cast<Group>()
                        .ToList();

                    foreach (var group in allGroups)
                    {
                        try
                        {
                            if (!group.IsValidObject) continue;

                            bool isDetailGroup = false;
                            try
                            {
                                if (group.Category != null && group.Category.Id.Value == (long)BuiltInCategory.OST_IOSDetailGroups)
                                {
                                    isDetailGroup = true;
                                }
                            }
                            catch { }

                            if (!isDetailGroup && group.GroupType != null)
                            {
                                try
                                {
                                    if (group.GroupType.Category != null && group.GroupType.Category.Id.Value == (long)BuiltInCategory.OST_IOSDetailGroups)
                                    {
                                        isDetailGroup = true;
                                    }
                                }
                                catch { }
                            }

                            // Si el grupo está en una vista específica (OwnerViewId), es un grupo 2D de detalle
                            if (!isDetailGroup && group.OwnerViewId != ElementId.InvalidElementId)
                            {
                                isDetailGroup = true;
                            }

                            if (!isDetailGroup) continue;

                            string groupName = !string.IsNullOrWhiteSpace(group.Name) ? group.Name : (group.GroupType?.Name ?? $"Group_{group.Id.Value}");
                            string viewName = "Model / Unassigned View";
                            string sheetName = string.Empty;
                            ElementId? sheetId = null;

                            if (group.OwnerViewId != ElementId.InvalidElementId && doc.GetElement(group.OwnerViewId) is View ownerView)
                            {
                                viewName = ownerView.Name;
                                if (viewToSheetMap.TryGetValue(ownerView.Id, out var sInfo))
                                {
                                    sheetName = sInfo.SheetName;
                                    sheetId = sInfo.SheetId;
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
                                SheetId = sheetId,
                                Category = "Detail Groups",
                                IsDraftingView = false,
                                IsLinked = doc.IsLinked,
                                CadCount = 0,
                                ElementId = group.Id,
                                OwnerViewId = group.OwnerViewId,
                                NativeElement = group,
                                SourceDocument = doc,
                                SourceDocumentName = doc.Title
                            };

                            results.Add(item);
                        }
                        catch (Exception ex)
                        {
                            LoggerService.LogWarning($"DetailGroupProvider: Error procesando Group individual: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggerService.LogWarning($"DetailGroupProvider: Error recolectando Group instances en '{doc.Title}': {ex.Message}");
                }

                // 3. Recolectar Tipos de Grupos de Detalle no instanciados en el modelo
                try
                {
                    var groupTypes = new FilteredElementCollector(doc)
                        .OfClass(typeof(GroupType))
                        .Cast<GroupType>()
                        .ToList();

                    foreach (var gt in groupTypes)
                    {
                        try
                        {
                            if (!gt.IsValidObject || processedTypeIds.Contains(gt.Id)) continue;

                            bool isDetailType = false;
                            try
                            {
                                if (gt.Category != null && gt.Category.Id.Value == (long)BuiltInCategory.OST_IOSDetailGroups)
                                {
                                    isDetailType = true;
                                }
                            }
                            catch { }

                            if (!isDetailType) continue;

                            var item = new CadDetailItemModel
                            {
                                Name = gt.Name,
                                ViewName = "(Group Definition / Unplaced)",
                                SheetName = string.Empty,
                                Category = "Detail Groups",
                                IsDraftingView = false,
                                IsLinked = doc.IsLinked,
                                CadCount = 0,
                                ElementId = gt.Id,
                                OwnerViewId = ElementId.InvalidElementId,
                                NativeElement = gt,
                                SourceDocument = doc,
                                SourceDocumentName = doc.Title
                            };

                            results.Add(item);
                        }
                        catch { }
                    }
                }
                catch (Exception ex)
                {
                    LoggerService.LogWarning($"DetailGroupProvider: Error recolectando GroupTypes en '{doc.Title}': {ex.Message}");
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
