using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FilterPlus.Models;
using System.Collections.Generic;
using System.Linq;
using Nice3point.Revit.Extensions;

namespace FilterPlus.Services;
 
public enum SelectionScope
{
    CurrentSelection,
    ElementsVisibleInView,
    ElementsBelongingToView,
    AllModelElements
}

public class RevitSelectionService
{
    private readonly UIDocument _uiDoc;
    private readonly Document _doc;

    public UIDocument UiDocument => _uiDoc;
    public Document Document => _doc;

    public RevitSelectionService(UIDocument uiDoc)
    {
        _uiDoc = uiDoc;
        _doc = uiDoc.Document;
    }

    public HashSet<ElementId> GetInitialSelectionIds()
    {
        var ids = _uiDoc.Selection.GetElementIds().ToHashSet();
        LoggerService.LogInfo($"Initial selection retrieved: {ids.Count} elements.");
        return ids;
    }

    public List<ElementModel> GetAvailableElements(SelectionScope scope, RevitModelRepresentation selectedModel = null)
    {
        bool isAllModels = selectedModel != null && selectedModel.DisplayName == "All Models";

        if (!isAllModels)
        {
            Document doc = selectedModel?.Document ?? _doc;
            RevitLinkInstance linkInstance = selectedModel?.LinkInstance;
            return GetAvailableElementsForDoc(scope, doc, linkInstance);
        }
        else
        {
            LoggerService.LogInfo($"Querying Revit for scope: {scope} on ALL models combined...");
            // 1. Get host elements
            var result = GetAvailableElementsForDoc(scope, _doc, null);

            // 2. Get elements from all loaded links
            var linkCollector = new FilteredElementCollector(_doc)
                .OfClass(typeof(RevitLinkInstance));

            foreach (var el in linkCollector)
            {
                if (el is RevitLinkInstance linkInst)
                {
                    var linkedDoc = linkInst.GetLinkDocument();
                    if (linkedDoc != null)
                    {
                        var linkedElements = GetAvailableElementsForDoc(scope, linkedDoc, linkInst);
                        result.AddRange(linkedElements);
                    }
                }
            }

            LoggerService.LogInfo($"Querying ALL models complete. Total elements found: {result.Count}");
            return result;
        }
    }

    private List<ElementModel> GetAvailableElementsForDoc(SelectionScope scope, Document doc, RevitLinkInstance linkInstance)
    {
        LoggerService.LogInfo($"Collecting elements for scope: {scope} in doc: {doc.Title} (LinkInstance: {linkInstance?.Name ?? "None"})...");
        FilteredElementCollector collector;
        
        switch (scope)
        {
            case SelectionScope.CurrentSelection:
                if (linkInstance != null)
                {
                    return new List<ElementModel>();
                }
                var selectedIds = _uiDoc.Selection.GetElementIds();
                if (!selectedIds.Any()) return new List<ElementModel>();
                collector = new FilteredElementCollector(doc, selectedIds);
                break;
            case SelectionScope.ElementsVisibleInView:
            case SelectionScope.ElementsBelongingToView:
                if (linkInstance != null)
                {
                    collector = new FilteredElementCollector(doc);
                }
                else
                {
                    collector = new FilteredElementCollector(doc, _doc.ActiveView.Id);
                }
                break;
            case SelectionScope.AllModelElements:
                collector = new FilteredElementCollector(doc);
                break;
            default:
                if (linkInstance != null)
                {
                    collector = new FilteredElementCollector(doc);
                }
                else
                {
                    collector = new FilteredElementCollector(doc, _doc.ActiveView.Id);
                }
                break;
        }

        var elements = collector
            .WhereElementIsNotElementType()
            .ToElements();

        var result = new List<ElementModel>();
        var worksetTable = doc.GetWorksetTable();

        var phaseMap = doc.Phases.Cast<Phase>()
            .Select((p, i) => new { p.Id, p.Name, Order = i })
            .ToDictionary(x => x.Id, x => (x.Name, x.Order));

        Outline hostViewOutline = null;
        if (linkInstance != null && (scope == SelectionScope.ElementsVisibleInView || scope == SelectionScope.ElementsBelongingToView))
        {
            var activeView = _doc.ActiveView;
            if (activeView != null)
            {
                try
                {
                    if (activeView.CropBoxActive)
                    {
                        var cropBox = activeView.CropBox;
                        hostViewOutline = new Outline(cropBox.Min, cropBox.Max);
                    }
                    else
                    {
                        var viewOutline = activeView.get_BoundingBox(null);
                        if (viewOutline != null)
                        {
                            hostViewOutline = new Outline(viewOutline.Min, viewOutline.Max);
                        }
                    }
                }
                catch
                {
                    // Fallback to null
                }
            }
        }

        var totalTransform = linkInstance?.GetTotalTransform();

        foreach (var el in elements)
        {
            if (linkInstance != null)
            {
                if (scope == SelectionScope.ElementsVisibleInView || scope == SelectionScope.ElementsBelongingToView)
                {
                    var localBox = el.get_BoundingBox(null);
                    if (localBox == null) continue;

                    if (hostViewOutline != null && totalTransform != null)
                    {
                        XYZ minHost = totalTransform.OfPoint(localBox.Min);
                        XYZ maxHost = totalTransform.OfPoint(localBox.Max);

                        double minX = Math.Min(minHost.X, maxHost.X);
                        double minY = Math.Min(minHost.Y, maxHost.Y);
                        double minZ = Math.Min(minHost.Z, maxHost.Z);
                        double maxX = Math.Max(minHost.X, maxHost.X);
                        double maxY = Math.Max(minHost.Y, maxHost.Y);
                        double maxZ = Math.Max(minHost.Z, maxHost.Z);

                        var elOutline = new Outline(new XYZ(minX, minY, minZ), new XYZ(maxX, maxY, maxZ));

                        if (!hostViewOutline.Intersects(elOutline, 0.001))
                        {
                            continue;
                        }
                    }
                }
            }
            else
            {
                if (scope == SelectionScope.ElementsBelongingToView)
                {
                    bool isViewSpecific = el.OwnerViewId == _doc.ActiveView.Id;
                    bool isVisibleInView = el.get_BoundingBox(_doc.ActiveView) != null;
                    
                    if (!isViewSpecific && !isVisibleInView) continue;
                }
            }

            var model = MapToElementModel(el, phaseMap, worksetTable);
            if (model != null)
            {
                if (linkInstance != null)
                {
                    model.LinkInstanceId = linkInstance.Id;
                }
                else
                {
                    model.LinkInstanceId = ElementId.InvalidElementId;
                }
                result.Add(model);
            }
        }

        return result;
    }

    public ElementModel MapToElementModel(
        Element el, 
        Dictionary<ElementId, (string Name, int Order)> phaseMap = null, 
        WorksetTable worksetTable = null)
    {
        if (el == null) return null;
        if (el.Category == null) return null;

        string categoryName = el.Category.Name;
        string familyName = "N/A";
        string typeName = el.Name;
        string levelName = "N/A";
        string worksetName = "N/A";

        if (el is FamilyInstance fi)
        {
            if (fi.Symbol != null)
            {
                familyName = fi.Symbol.FamilyName;
                typeName = fi.Symbol.Name;
            }
        }
        else if (el is HostObject host)
        {
            var type = el.Document.GetElement(host.GetTypeId()) as ElementType;
            if (type != null)
            {
                familyName = type.FamilyName;
                typeName = type.Name;
            }
        }

        if (el.LevelId != ElementId.InvalidElementId)
        {
            var level = el.Document.GetElement(el.LevelId);
            if (level != null) levelName = level.Name;
        }

        if (el.WorksetId != WorksetId.InvalidWorksetId && el.Document.IsWorkshared)
        {
            var table = worksetTable ?? el.Document.GetWorksetTable();
            var workset = table.GetWorkset(el.WorksetId);
            if (workset != null) worksetName = workset.Name;
        }

        // Phase detection
        string phaseName = "N/A";
        int phaseOrder = 999;
        var phaseId = el.CreatedPhaseId;
        if (phaseId != ElementId.InvalidElementId)
        {
            if (phaseMap != null && phaseMap.TryGetValue(phaseId, out var phaseInfo))
            {
                phaseName = phaseInfo.Name;
                phaseOrder = phaseInfo.Order;
            }
            else
            {
                var phase = el.Document.GetElement(phaseId) as Phase;
                if (phase != null)
                {
                    phaseName = phase.Name;
                    int order = 0;
                    foreach (Phase p in el.Document.Phases)
                    {
                        if (p.Id == phaseId)
                        {
                            phaseOrder = order;
                            break;
                        }
                        order++;
                    }
                }
            }
        }

        // Parameter metadata extraction for advanced deep-search (Safe Mode to prevent AccessViolationException)
        System.Text.StringBuilder metaBuilder = new System.Text.StringBuilder();
        try
        {
            // Marcas y Comentarios de Ejemplar
            var pMark = el.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
            if (pMark != null && pMark.HasValue) metaBuilder.Append(pMark.AsString()?.ToLowerInvariant()).Append(" ");

            var pComments = el.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
            if (pComments != null && pComments.HasValue) metaBuilder.Append(pComments.AsString()?.ToLowerInvariant()).Append(" ");

            // Marcas y Comentarios de Tipo
            var type = el.Document.GetElement(el.GetTypeId()) as ElementType;
            if (type != null)
            {
                var pTypeMark = type.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_MARK);
                if (pTypeMark != null && pTypeMark.HasValue) metaBuilder.Append(pTypeMark.AsString()?.ToLowerInvariant()).Append(" ");

                var pTypeComments = type.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_COMMENTS);
                if (pTypeComments != null && pTypeComments.HasValue) metaBuilder.Append(pTypeComments.AsString()?.ToLowerInvariant()).Append(" ");
            }

            // Añadir el Nivel como "Restricción" base
            if (!string.IsNullOrEmpty(levelName) && levelName != "N/A")
            {
                metaBuilder.Append(levelName.ToLowerInvariant()).Append(" ");
            }
        }
        catch
        {
            // Ignorar errores de lectura puntuales
        }

        // System and Domain detection
        string systemName = "N/A";
        string systemClassification = "N/A";
        string mepDomain = "N/A";
        
        try
        {
            var sysParam = el.get_Parameter(BuiltInParameter.RBS_SYSTEM_NAME_PARAM);
            if (sysParam != null && sysParam.HasValue)
            {
                systemName = sysParam.AsString();
            }

            ConnectorManager cm = null;
            if (el is FamilyInstance fi2 && fi2.MEPModel != null)
            {
                cm = fi2.MEPModel.ConnectorManager;
            }
            else if (el is MEPCurve mepCurve)
            {
                cm = mepCurve.ConnectorManager;
            }

            if (cm != null)
            {
                foreach (Connector conn in cm.Connectors)
                {
                    if (conn.MEPSystem != null)
                    {
                        if (string.IsNullOrEmpty(systemName) || systemName == "N/A") 
                            systemName = conn.MEPSystem.Name;
                            
                        var sysType = el.Document.GetElement(conn.MEPSystem.GetTypeId()) as MEPSystemType;
                        if (sysType != null)
                        {
                            systemClassification = sysType.SystemClassification.ToString();
                            break;
                        }
                    }
                }
            }
        }
        catch
        {
            // Ignore system retrieval issues
        }
        
        // Compute MEP Domain
        if (el.Category != null)
        {
            string catLower = el.Category.Name.ToLowerInvariant();
            if (catLower.Contains("duct") || catLower.Contains("air") || catLower.Contains("mechanical") || catLower.Contains("terminal"))
            {
                mepDomain = "Mechanical";
            }
            else if (catLower.Contains("pipe") || catLower.Contains("plumbing") || catLower.Contains("sprinkler"))
            {
                mepDomain = "Piping";
            }
            else if (catLower.Contains("fitting"))
            {
                if (catLower.Contains("pipe")) mepDomain = "Piping";
                else if (catLower.Contains("duct")) mepDomain = "Mechanical";
            }
            else if (catLower.Contains("electrical") || catLower.Contains("lighting") || catLower.Contains("cable tray") || catLower.Contains("conduit") || catLower.Contains("wire") || catLower.Contains("switch"))
            {
                mepDomain = "Electrical";
            }
        }
        
        if (mepDomain == "N/A" && systemClassification != "N/A")
        {
            string sysClassLower = systemClassification.ToLowerInvariant();
            if (sysClassLower.Contains("air") || sysClassLower.Contains("exhaust") || sysClassLower.Contains("supply") || sysClassLower.Contains("return"))
                mepDomain = "Mechanical";
            else if (sysClassLower.Contains("water") || sysClassLower.Contains("sanitary") || sysClassLower.Contains("hydronic") || sysClassLower.Contains("fire") || sysClassLower.Contains("otherpipe"))
                mepDomain = "Piping";
        }

        // Zone detection
        string zoneName = "N/A";
        try
        {
            if (el is Autodesk.Revit.DB.Mechanical.Space space)
            {
                if (space.Zone != null) zoneName = space.Zone.Name;
            }
            else if (el is FamilyInstance fi3)
            {
                Phase activePhase = null;
                var viewPhaseParam = _doc.ActiveView.get_Parameter(BuiltInParameter.VIEW_PHASE);
                if (viewPhaseParam != null && viewPhaseParam.HasValue)
                {
                    var pId = viewPhaseParam.AsElementId();
                    if (pId != ElementId.InvalidElementId)
                    {
                        var hostPhase = _doc.GetElement(pId) as Phase;
                        if (hostPhase != null)
                        {
                            activePhase = el.Document.Phases.Cast<Phase>()
                                .FirstOrDefault(p => p.Name.Equals(hostPhase.Name, StringComparison.OrdinalIgnoreCase));
                        }
                    }
                }
                
                if (activePhase == null)
                {
                    activePhase = el.Document.Phases.Cast<Phase>().LastOrDefault();
                }

                Autodesk.Revit.DB.Mechanical.Space sp = null;
                if (activePhase != null)
                {
                    try { sp = fi3.get_Space(activePhase); } catch {}
                }
                if (sp == null)
                {
                    sp = fi3.Space;
                }
                
                if (sp != null && sp.Zone != null)
                {
                    zoneName = sp.Zone.Name;
                }
            }
        }
        catch
        {
            // Ignore zone retrieval issues
        }

        return new ElementModel
        {
            Id = el.Id,
            CategoryName = categoryName,
            FamilyName = familyName,
            TypeName = typeName,
            LevelName = levelName,
            WorksetName = worksetName,
            SystemName = systemName,
            SystemClassification = systemClassification,
            MepDomain = mepDomain,
            ZoneName = zoneName,
            IsModelElement = el.Category?.CategoryType == CategoryType.Model,
            IsAnnotation = el.Category?.CategoryType == CategoryType.Annotation,
            HasBoundingBox = el.get_BoundingBox(null) != null,
            PhaseName = phaseName,
            PhaseOrder = phaseOrder,
            SearchableMetadata = metaBuilder.ToString()
        };
    }

    public void SetSelection(IEnumerable<ElementSelectionKey> selection)
    {
        var refs = new List<Reference>();
        var hostIds = new List<ElementId>();

        foreach (var key in selection)
        {
            if (key.LinkInstanceId == null || key.LinkInstanceId == ElementId.InvalidElementId)
            {
                hostIds.Add(key.ElementId);
            }
            else
            {
                var linkInstance = _doc.GetElement(key.LinkInstanceId) as RevitLinkInstance;
                if (linkInstance != null)
                {
                    var linkedDoc = linkInstance.GetLinkDocument();
                    if (linkedDoc != null)
                    {
                        var el = linkedDoc.GetElement(key.ElementId);
                        if (el != null)
                        {
                            try
                            {
                                var refInLink = new Reference(el);
                                var hostRef = refInLink.CreateLinkReference(linkInstance);
                                refs.Add(hostRef);
                            }
                            catch (Exception ex)
                            {
                                LoggerService.LogError($"SetSelection failed for linked element {key.ElementId}", ex);
                            }
                        }
                    }
                }
            }
        }

        // Convert host ElementIds to Reference objects so they can be selected in the same call
        foreach (var id in hostIds)
        {
            var el = _doc.GetElement(id);
            if (el != null)
            {
                try
                {
                    refs.Add(new Reference(el));
                }
                catch (Exception ex)
                {
                    LoggerService.LogError($"SetSelection failed for host element {id}", ex);
                }
            }
        }

        // Select all references (host + links) simultaneously
        try
        {
            _uiDoc.Selection.SetReferences(refs);
        }
        catch (Exception ex)
        {
            LoggerService.LogError("SetSelection via SetReferences failed", ex);
        }
    }
}
