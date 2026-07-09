using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services;

public static class DocumentCollector
{
    public static List<TransferItem> GetTransferableElements(Document sourceDoc)
    {
        var items = new List<TransferItem>();

        // 1. Gather all element types (Families, System Types)
        var types = new FilteredElementCollector(sourceDoc)
            .WhereElementIsElementType()
            .Where(e => e.Category != null && e is not AssemblyType && e is not RevitLinkType)
            .ToList();

        foreach (var type in types)
        {
            var item = new TransferItem
            {
                ElementId = type.Id,
                Name = type.Name,
                Category = type.Category?.Name ?? "Unknown",
                Family = (type as ElementType)?.FamilyName ?? "System",
                ElementType = type.Name,
                IsLoadable = type is FamilySymbol
            };
            items.Add(item);
        }

        // 2. Gather View Templates
        var viewTemplates = new FilteredElementCollector(sourceDoc)
            .OfClass(typeof(View))
            .Cast<View>()
            .Where(v => v.IsTemplate)
            .ToList();

        foreach (var template in viewTemplates)
        {
            items.Add(new TransferItem
            {
                ElementId = template.Id,
                Name = template.Name,
                Category = "View Templates",
                Family = "View Template",
                ElementType = template.Name
            });
        }

        // 3. Gather Filters
        var filters = new FilteredElementCollector(sourceDoc)
            .OfClass(typeof(ParameterFilterElement))
            .ToList();

        foreach (var filter in filters)
        {
            items.Add(new TransferItem
            {
                ElementId = filter.Id,
                Name = filter.Name,
                Category = "Filters",
                Family = "Filter",
                ElementType = filter.Name
            });
        }

        // 4. Gather Materials
        var materials = new FilteredElementCollector(sourceDoc)
            .OfClass(typeof(Material))
            .ToList();
            
        foreach (var material in materials)
        {
            items.Add(new TransferItem
            {
                ElementId = material.Id,
                Name = material.Name,
                Category = "Materials",
                Family = "Material",
                ElementType = material.Name
            });
        }

        return items;
    }
}
