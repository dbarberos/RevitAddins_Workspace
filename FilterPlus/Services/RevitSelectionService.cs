using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FilterPlus.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilterPlus.Services;

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
        return _uiDoc.Selection.GetElementIds().ToHashSet();
    }

    public List<ElementModel> GetAvailableElements()
    {
        // Get all elements in active view that can be selected
        var elements = new FilteredElementCollector(_doc, _doc.ActiveView.Id)
            .WhereElementIsNotElementType()
            .ToElements();

        var result = new List<ElementModel>();
        var worksetTable = _doc.GetWorksetTable();

        foreach (var el in elements)
        {
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

            result.Add(new ElementModel
            {
                Id = el.Id,
                CategoryName = categoryName,
                FamilyName = familyName,
                TypeName = typeName,
                LevelName = levelName,
                WorksetName = worksetName
            });
        }

        return result;
    }

    public void SetSelection(IEnumerable<ElementId> ids)
    {
        _uiDoc.Selection.SetElementIds(ids.ToList());
    }
}
