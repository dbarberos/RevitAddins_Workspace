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

    public List<ElementModel> GetAvailableElements(SelectionScope scope)
    {
        LoggerService.LogInfo($"Querying Revit for scope: {scope}...");
        FilteredElementCollector collector;
        
        switch (scope)
        {
            case SelectionScope.CurrentSelection:
                var selectedIds = _uiDoc.Selection.GetElementIds();
                if (!selectedIds.Any()) return new List<ElementModel>();
                collector = new FilteredElementCollector(_doc, selectedIds);
                break;
            case SelectionScope.ElementsVisibleInView:
                collector = new FilteredElementCollector(_doc, _doc.ActiveView.Id);
                break;
            case SelectionScope.ElementsBelongingToView:
            case SelectionScope.AllModelElements:
                collector = new FilteredElementCollector(_doc);
                break;
            default:
                collector = new FilteredElementCollector(_doc, _doc.ActiveView.Id);
                break;
        }

        var elements = collector
            .WhereElementIsNotElementType()
            .ToElements();

        var result = new List<ElementModel>();
        var worksetTable = _doc.GetWorksetTable();

        // Pre-fetch phases once for ordering
        var phaseMap = _doc.Phases.Cast<Phase>()
            .Select((p, i) => new { p.Id, p.Name, Order = i })
            .ToDictionary(x => x.Id, x => (x.Name, x.Order));

        foreach (var el in elements)
        {
            // For ElementsBelongingToView, we include:
            // 1. Elements owned by the view (view-specific like text, detail lines, etc.)
            // 2. Elements visible in the view (have a bounding box)
            if (scope == SelectionScope.ElementsBelongingToView)
            {
                bool isViewSpecific = el.OwnerViewId == _doc.ActiveView.Id;
                bool isVisibleInView = el.get_BoundingBox(_doc.ActiveView) != null;
                
                if (!isViewSpecific && !isVisibleInView) continue;
            }

            var model = MapToElementModel(el, phaseMap, worksetTable);
            if (model != null)
            {
                result.Add(model);
            }
        }

        LoggerService.LogInfo($"Revit query finished. {result.Count} valid elements found.");
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
            // Walls, Floors, etc.
            var type = _doc.GetElement(host.GetTypeId()) as ElementType;
            if (type != null)
            {
                familyName = type.FamilyName;
                typeName = type.Name;
            }
        }

        if (el.LevelId != ElementId.InvalidElementId)
        {
            var level = _doc.GetElement(el.LevelId);
            if (level != null) levelName = level.Name;
        }

        if (el.WorksetId != WorksetId.InvalidWorksetId && _doc.IsWorkshared)
        {
            var table = worksetTable ?? _doc.GetWorksetTable();
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
                var phase = _doc.GetElement(phaseId) as Phase;
                if (phase != null)
                {
                    phaseName = phase.Name;
                    // Dynamically calculate phase order
                    int order = 0;
                    foreach (Phase p in _doc.Phases)
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
            var type = _doc.GetElement(el.GetTypeId()) as ElementType;
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
                            
                        var sysType = _doc.GetElement(conn.MEPSystem.GetTypeId()) as MEPSystemType;
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
                        activePhase = _doc.GetElement(pId) as Phase;
                }
                
                if (activePhase == null)
                {
                    activePhase = _doc.Phases.Cast<Phase>().LastOrDefault();
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

    public void SetSelection(IEnumerable<ElementId> ids)
    {
        _uiDoc.Selection.SetElementIds(ids.ToList());
    }
}
