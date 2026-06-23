# Revit Model Exploration, Querying, and Advanced Filtering

This technical reference guide covers optimal design patterns and debugging strategies for querying, categorizing, and filtering elements dynamically inside Revit Add-ins using C#. It leverages lessons-learned from high-performance selection tree architectures (such as `FilterPlus`).

---

## 1. Multi-Scope Selection Collectors
When constructing a model explorer (like a TreeView), querying the Revit database must be tailored to the active user scope. Initializing the `FilteredElementCollector` correctly prevents performance bottlenecks.

*   **Current Selection Scope**: Restricts querying to active visual selections.
*   **Elements Visible in View Scope**: Gathers physical elements drawn/visible within the active workspace window.
*   **Elements Belonging to View Scope**: Combines visual elements with view-specific annotations (e.g., text notes, details, lines).
*   **All Model Elements Scope**: Queries the entire database universally.

### Optimal collector Construction Pattern
```csharp
public static IEnumerable<Element> QueryElementsByScope(Document doc, UIDocument uiDoc, SelectionScope scope)
{
    FilteredElementCollector collector;
    
    switch (scope)
    {
        case SelectionScope.CurrentSelection:
            var selectedIds = uiDoc.Selection.GetElementIds();
            if (!selectedIds.Any()) return Enumerable.Empty<Element>();
            collector = new FilteredElementCollector(doc, selectedIds);
            break;
            
        case SelectionScope.ElementsVisibleInView:
            collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
            break;
            
        case SelectionScope.ElementsBelongingToView:
        case SelectionScope.AllModelElements:
            collector = new FilteredElementCollector(doc);
            break;
            
        default:
            collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
            break;
    }

    // Exclude ElementTypes to only query physical model instances or annotations
    return collector.WhereElementIsNotElementType().ToElements();
}
```

### View Ownership vs Spatial Bounding Box Filter
To accurately resolve `SelectionScope.ElementsBelongingToView`, you must combine two conditions:
1.  **View-Specific Elements**: Elements whose owner view matches the active view (e.g., detail items, text tags).
2.  **Spatially Visible Elements**: Physical components that intersect the active view's viewport (checked via bounding box visibility).

```csharp
bool isViewSpecific = element.OwnerViewId == activeView.Id;
bool isVisibleInView = element.get_BoundingBox(activeView) != null;

if (!isViewSpecific && !isVisibleInView)
{
    // Skip element (does not logically belong to this view)
}
```

---

## 2. Safe Family and Type Resolution
Revit treats Loadable Families (`FamilyInstance`) and System Families (`HostObject` such as Walls, Floors, Roofs) differently. Direct casting will cause failures or unresolved family names if not handled conditionally.

*   **Loadable Families**: Access the `Symbol` property of the `FamilyInstance` to read `FamilyName` and `Name`.
*   **System Families**: Retrieve the `ElementType` using `element.GetTypeId()` and query the `FamilyName` and `Name` from the type.

### Safe Resolution Pattern
```csharp
public static (string FamilyName, string TypeName) ResolveFamilyAndType(Element element, Document doc)
{
    string familyName = "N/A";
    string typeName = element.Name;

    if (element is FamilyInstance familyInstance)
    {
        if (familyInstance.Symbol != null)
        {
            familyName = familyInstance.Symbol.FamilyName;
            typeName = familyInstance.Symbol.Name;
        }
    }
    else if (element is HostObject hostObject)
    {
        var type = doc.GetElement(hostObject.GetTypeId()) as ElementType;
        if (type != null)
        {
            familyName = type.FamilyName;
            typeName = type.Name;
        }
    }

    return (familyName, typeName);
}
```

---

## 3. High-Performance Phase Mapping
Querying project phases repeatedly during iteration is a major performance bottleneck. Since project phases do not change during a selection command, pre-fetch and index them in a sequential dictionary at startup.

```csharp
// Pre-fetch project phases into an ordered dictionary
var phaseMap = doc.Phases.Cast<Phase>()
    .Select((p, i) => new { p.Id, p.Name, Order = i })
    .ToDictionary(x => x.Id, x => x);

// Usage during element loops:
string phaseName = "N/A";
int phaseOrder = 999;
var phaseId = element.CreatedPhaseId;

if (phaseId != ElementId.InvalidElementId && phaseMap.TryGetValue(phaseId, out var phaseInfo))
{
    phaseName = phaseInfo.Name;
    phaseOrder = phaseInfo.Order;
}
```

---

## 4. Safe Parameter Mining & Caching for local UI Search
To build instantaneous tree searching (via text, category dropdowns, levels, or Regular Expressions) without lagging the UI or sending repeated queries to the Revit API thread, extract and cache searchable metadata inside lightweight local DTOs at load time.

### Preventing `AccessViolationException`
Revit parameters can occasionally be corrupt, null, or throw exceptions if accessed in an unstable view context. Always wrap parameter reading inside narrow `try-catch` scopes, leveraging a pre-sized `StringBuilder` for token generation.

### Search-Ready Metadata Extraction Pattern
```csharp
public static string ExtractSearchableMetadata(Element element, Document doc)
{
    var metaBuilder = new System.Text.StringBuilder(128);

    try
    {
        // 1. Instance Mark & Comments
        var pMark = element.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
        if (pMark != null && pMark.HasValue) 
            metaBuilder.Append(pMark.AsString()?.ToLowerInvariant()).Append(" ");

        var pComments = element.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
        if (pComments != null && pComments.HasValue) 
            metaBuilder.Append(pComments.AsString()?.ToLowerInvariant()).Append(" ");

        // 2. Type Mark & Comments
        var type = doc.GetElement(element.GetTypeId()) as ElementType;
        if (type != null)
        {
            var pTypeMark = type.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_MARK);
            if (pTypeMark != null && pTypeMark.HasValue) 
                metaBuilder.Append(pTypeMark.AsString()?.ToLowerInvariant()).Append(" ");

            var pTypeComments = type.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_COMMENTS);
            if (pTypeComments != null && pTypeComments.HasValue) 
                metaBuilder.Append(pTypeComments.AsString()?.ToLowerInvariant()).Append(" ");
        }
    }
    catch
    {
        // Ignore single parameter failures, preserving application flow
    }

    return metaBuilder.ToString();
}
```
