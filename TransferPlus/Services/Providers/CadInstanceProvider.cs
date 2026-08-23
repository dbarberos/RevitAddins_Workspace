using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers
{
    /// <summary>
    /// Proveedor de datos para recolectar Instancias CAD (ImportInstance: DWG Links / Imports) de un documento de Revit (incluidos modelos vinculados).
    /// </summary>
    public class CadInstanceProvider
    {
        public static List<CadDetailItemModel> GetCadInstances(Document doc)
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
                    LoggerService.LogWarning($"CadInstanceProvider: No se pudieron mapear viewports en '{doc.Title}': {ex.Message}");
                }

                // 2. Recolectar todas las instancias de ImportInstance
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
                            if (!imp.IsValidObject) continue;

                            string cadName = string.Empty;

                            // Obtener nombre desde el tipo de CAD o categoría
                            try
                            {
                                if (imp.GetTypeId() != ElementId.InvalidElementId && doc.GetElement(imp.GetTypeId()) is Element typeElem && !string.IsNullOrWhiteSpace(typeElem.Name))
                                {
                                    cadName = typeElem.Name;
                                }
                                else if (imp.Category != null && !string.IsNullOrWhiteSpace(imp.Category.Name))
                                {
                                    cadName = imp.Category.Name;
                                }
                                else
                                {
                                    cadName = $"CAD_{imp.Id.Value}";
                                }
                            }
                            catch
                            {
                                cadName = $"CAD_{imp.Id.Value}";
                            }

                            string viewName = "3D / Model-wide Placement";
                            string sheetName = string.Empty;
                            ElementId? sheetId = null;

                            if (imp.OwnerViewId != ElementId.InvalidElementId)
                            {
                                try
                                {
                                    if (doc.GetElement(imp.OwnerViewId) is View ownerView)
                                    {
                                        viewName = ownerView.Name;
                                        if (viewToSheetMap.TryGetValue(ownerView.Id, out var sInfo))
                                        {
                                            sheetName = sInfo.SheetName;
                                            sheetId = sInfo.SheetId;
                                        }
                                    }
                                }
                                catch { }
                            }

                            var item = new CadDetailItemModel
                            {
                                Name = cadName,
                                ViewName = viewName,
                                SheetName = sheetName,
                                SheetId = sheetId,
                                IsLinked = imp.IsLinked,
                                IsDraftingView = false,
                                CadCount = 1,
                                ElementId = imp.Id,
                                OwnerViewId = imp.OwnerViewId,
                                NativeElement = imp,
                                SourceDocument = doc,
                                SourceDocumentName = doc.Title
                            };

                            results.Add(item);
                        }
                        catch (Exception ex)
                        {
                            LoggerService.LogWarning($"CadInstanceProvider: Error procesando ImportInstance individual: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggerService.LogWarning($"CadInstanceProvider: Error recolectando ImportInstances en '{doc.Title}': {ex.Message}");
                }

                LoggerService.LogInfo($"CadInstanceProvider: Recolectadas {results.Count} instancias CAD en '{doc.Title}'.");
            }
            catch (Exception ex)
            {
                LoggerService.LogError($"CadInstanceProvider: Error recolectando instancias CAD en '{doc.Title}'", ex);
            }

            return results;
        }
    }
}
