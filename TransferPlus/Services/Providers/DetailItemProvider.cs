using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services.Providers
{
    /// <summary>
    /// Proveedor de datos para recolectar Componentes de Detalle 2D (Detail Items, Filled Regions y Tipos de Detalle) de un documento de Revit (incluidos modelos vinculados).
    /// </summary>
    public class DetailItemProvider
    {
        public static List<CadDetailItemModel> GetDetailItems(Document doc)
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
                    LoggerService.LogWarning($"DetailItemProvider: No se pudieron mapear viewports en '{doc.Title}': {ex.Message}");
                }

                var processedTypeIds = new HashSet<ElementId>();

                // 2. Recolectar instancias colocadas de Componentes de Detalle 2D (FamilyInstance)
                try
                {
                    var detailInstances = new FilteredElementCollector(doc)
                        .OfCategory(BuiltInCategory.OST_DetailComponents)
                        .WhereElementIsNotElementType()
                        .OfType<FamilyInstance>()
                        .ToList();

                    foreach (var inst in detailInstances)
                    {
                        try
                        {
                            if (!inst.IsValidObject) continue;

                            string familyName = "Detail Component";
                            string typeName = inst.Name;

                            var symbol = doc.GetElement(inst.GetTypeId()) as FamilySymbol;
                            if (symbol != null)
                            {
                                processedTypeIds.Add(symbol.Id);
                                if (symbol.Family != null && !string.IsNullOrWhiteSpace(symbol.Family.Name))
                                {
                                    familyName = symbol.Family.Name;
                                }
                                if (!string.IsNullOrWhiteSpace(symbol.Name))
                                {
                                    typeName = symbol.Name;
                                }
                            }

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
                                IsLinked = doc.IsLinked,
                                CadCount = 0,
                                ElementId = inst.Id,
                                OwnerViewId = inst.OwnerViewId,
                                NativeElement = inst,
                                SourceDocument = doc,
                                SourceDocumentName = doc.Title
                            };

                            results.Add(item);
                        }
                        catch (Exception ex)
                        {
                            LoggerService.LogWarning($"DetailItemProvider: Error procesando FamilyInstance de detalle: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggerService.LogWarning($"DetailItemProvider: Error recolectando FamilyInstance de detalle en '{doc.Title}': {ex.Message}");
                }

                // 3. Recolectar Regiones de Detalle (FilledRegion y MaskingRegion)
                try
                {
                    var filledRegions = new FilteredElementCollector(doc)
                        .OfClass(typeof(FilledRegion))
                        .WhereElementIsNotElementType()
                        .Cast<FilledRegion>()
                        .ToList();

                    foreach (var fr in filledRegions)
                    {
                        try
                        {
                            if (!fr.IsValidObject) continue;

                            string regionName = "Filled Region";
                            if (doc.GetElement(fr.GetTypeId()) is FilledRegionType frt && !string.IsNullOrWhiteSpace(frt.Name))
                            {
                                regionName = $"Filled Region : {frt.Name}";
                            }

                            string viewName = "Model / Unassigned View";
                            string sheetName = string.Empty;
                            ElementId? sheetId = null;

                            if (fr.OwnerViewId != ElementId.InvalidElementId && doc.GetElement(fr.OwnerViewId) is View ownerView)
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
                                Name = regionName,
                                ViewName = viewName,
                                SheetName = sheetName,
                                SheetId = sheetId,
                                Category = "Detail Items",
                                IsDraftingView = false,
                                IsLinked = doc.IsLinked,
                                CadCount = 0,
                                ElementId = fr.Id,
                                OwnerViewId = fr.OwnerViewId,
                                NativeElement = fr,
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
                    LoggerService.LogWarning($"DetailItemProvider: Error recolectando FilledRegions en '{doc.Title}': {ex.Message}");
                }

                // 4. Recolectar Tipos de Componentes de Detalle (FamilySymbol) cargados no instanciados
                try
                {
                    var detailSymbols = new FilteredElementCollector(doc)
                        .OfCategory(BuiltInCategory.OST_DetailComponents)
                        .WhereElementIsElementType()
                        .OfType<FamilySymbol>()
                        .ToList();

                    foreach (var sym in detailSymbols)
                    {
                        try
                        {
                            if (!sym.IsValidObject || processedTypeIds.Contains(sym.Id)) continue;

                            string famName = sym.Family?.Name ?? "Detail Family";
                            string symName = sym.Name;
                            string displayName = $"{famName} : {symName}";

                            var item = new CadDetailItemModel
                            {
                                Name = displayName,
                                ViewName = "(Family Definition / Unplaced)",
                                SheetName = string.Empty,
                                SheetId = null,
                                Category = "Detail Items",
                                IsDraftingView = false,
                                IsLinked = doc.IsLinked,
                                CadCount = 0,
                                ElementId = sym.Id,
                                OwnerViewId = null,
                                NativeElement = sym,
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
                    LoggerService.LogWarning($"DetailItemProvider: Error recolectando FamilySymbols de detalle en '{doc.Title}': {ex.Message}");
                }

                LoggerService.LogInfo($"DetailItemProvider: Recolectados {results.Count} componentes/regiones de detalle en '{doc.Title}'.");
            }
            catch (Exception ex)
            {
                LoggerService.LogError($"DetailItemProvider: Error recolectando componentes de detalle en '{doc.Title}'", ex);
            }

            return results;
        }
    }
}
