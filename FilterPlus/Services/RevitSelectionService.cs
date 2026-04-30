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
            .ToDictionary(x => x.Id, x => x);

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

            // Skip elements that don't have a valid category
            if (el.Category == null) continue;

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
                var workset = worksetTable.GetWorkset(el.WorksetId);
                if (workset != null) worksetName = workset.Name;
            }

            // Phase detection
            string phaseName = "N/A";
            int phaseOrder = 999;
            var phaseId = el.CreatedPhaseId;
            if (phaseId != ElementId.InvalidElementId && phaseMap.TryGetValue(phaseId, out var phaseInfo))
            {
                phaseName = phaseInfo.Name;
                phaseOrder = phaseInfo.Order;
            }

            result.Add(new ElementModel
            {
                Id = el.Id,
                CategoryName = categoryName,
                FamilyName = familyName,
                TypeName = typeName,
                LevelName = levelName,
                WorksetName = worksetName,
                IsModelElement = el.Category?.CategoryType == CategoryType.Model,
                IsAnnotation = el.Category?.CategoryType == CategoryType.Annotation,
                HasBoundingBox = el.get_BoundingBox(null) != null,
                PhaseName = phaseName,
                PhaseOrder = phaseOrder
            });
        }

        LoggerService.LogInfo($"Revit query finished. {result.Count} valid elements found.");
        return result;
    }

    public void SetSelection(IEnumerable<ElementId> ids)
    {
        _uiDoc.Selection.SetElementIds(ids.ToList());
    }
}
