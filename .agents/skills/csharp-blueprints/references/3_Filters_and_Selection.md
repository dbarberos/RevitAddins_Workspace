# Guide 3: Element Querying, Filtering, and Selection

Querying data correctly marks the difference between an add-in that processes information in milliseconds and one that freezes the Revit interface. This guide covers element querying using filters, collecting Worksets, advanced LINQ filtering, and managing user selection states.

## 1. Using FilteredElementCollector

Almost every command you build will need to interact with Revit model elements. The `FilteredElementCollector` class acts like a database query. Instead of asking Revit to "give me all elements," we chain filters together to narrow the search.

**Best Practices: Quick Filters vs. Slow Filters**
*   **Quick Filters**: Interact directly with the Revit database without expanding the elements in memory. Examples: `.OfClass()` and `.OfCategory()`. **Always start your collector with a Quick Filter**.
*   **Slow Filters**: Have a significant performance impact if applied globally because they force Revit to read deeper element parameter information. Examples: `ElementLevelFilter` or checking element parameter values.

**Code Example: Basic Wall Collector**

```csharp
using Autodesk.Revit.DB; 
using System.Collections.Generic; 

// Assumes 'doc' is the active Document 

// 1. Initialize the collector 
var walls = new FilteredElementCollector(doc) 
    // 2. Quick Filter by Class 
    .OfClass(typeof(Wall)) 
    // 3. Exclude types (WallTypes), we want physical instances only 
    .WhereElementIsNotElementType() 
    // 4. Convert and execute the collector 
    .ToElements();
```

---

## 2. Collecting Worksets

A common mistake is thinking that everything in Revit is an `Element`. Worksets are a major exception; they inherit from `WorksetPreview`, not `Element`. Therefore, you cannot use a traditional `FilteredElementCollector`.

**Code Example: Collect all User Worksets**

```csharp
using Autodesk.Revit.DB; 
using System.Linq; 

// Use FilteredWorksetCollector instead of FilteredElementCollector 
var userWorksets = new FilteredWorksetCollector(doc) 
    // Filter only those created by the user (ignore system worksets) 
    .OfKind(WorksetKind.UserWorkset) 
    .ToWorksets() 
    .ToList(); // Convert to a generic C# list for easy manipulation
```

---

## 3. Advanced Filtering with System.Linq

Although the native Revit API provides advanced filters (like `WherePasses` with `ElementParameterFilter`), they can be complex and hard to maintain. The modern alternative is to use **System.Linq**. Once you extract basic elements using a Revit Quick Filter, use Lambda expressions (`=>`) to filter and sort the data in C# memory.

**Best Practices with LINQ:**
*   Only apply LINQ **after** you have reduced the element count using a Revit Quick Filter.
*   Use `.Cast<T>()` to convert elements (`Element`) to their real C# class (e.g. `ViewSheet`), which grants access to their specific properties.

**Code Example: Filtering and sorting sheets with LINQ**

```csharp
using Autodesk.Revit.DB; 
using System.Linq; 
using System.Collections.Generic; 

List<ViewSheet> validSheets = new FilteredElementCollector(doc) 
    .OfCategory(BuiltInCategory.OST_Sheets) // Quick Filter 
    .WhereElementIsNotElementType() 
    .Cast<ViewSheet>() // Convert to Revit ViewSheet objects 
    // LINQ: Filter out 'Placeholder' sheets 
    .Where(sheet => !sheet.IsPlaceholder) 
    // LINQ: Sort alphanumerically by sheet number 
    .OrderBy(sheet => sheet.SheetNumber) 
    .ToList(); // Return final list
```

---

## 4. Getting and Setting the Active Selection

Often, your commands will act on elements that the user **already selected** before running the plugin. This is managed using the `UIDocument` class and its `Selection` property.

**Code Example: Extension Methods to Manage Selection States**

```csharp
using Autodesk.Revit.UI; 
using Autodesk.Revit.DB; 
using System.Collections.Generic; 
using System.Linq; 

public static class UIDocumentExtensions 
{ 
    // Method to extract all elements currently selected by the user 
    public static List<Element> GetSelectedElements(this UIDocument uiDoc) 
    { 
        if (uiDoc == null) return new List<Element>(); 
        Document doc = uiDoc.Document; 
        
        // Get active selection element IDs 
        ICollection<ElementId> selectedIds = uiDoc.Selection.GetElementIds(); 
        
        // Map IDs to physical elements using LINQ 
        return selectedIds.Select(id => doc.GetElement(id)) 
            .Where(e => e != null) 
            .ToList(); 
    } 

    // Method to set a new selection state (highlight elements in blue on screen) 
    public static void SetSelectedElements(this UIDocument uiDoc, List<ElementId> idsToSelect) 
    { 
        uiDoc.Selection.SetElementIds(idsToSelect); 
    } 
}
```

---

## 5. Controlled Interactive Selections: ISelectionFilter

If you want the user to click elements in real-time (`PickObject` or `PickObjects`) but need to restrict what they can click (e.g. "Only allow picking Rooms"), you must implement a custom selection filter using the `ISelectionFilter` interface.

**Code Example: Restrictive Selection Filter by Category**

```csharp
using Autodesk.Revit.DB; 
using Autodesk.Revit.UI.Selection; 

// 1. Define the class implementing the ISelectionFilter contract 
public class CategorySelectionFilter : ISelectionFilter 
{ 
    private BuiltInCategory _targetCategory; 

    // Constructor: Define the permitted category 
    public CategorySelectionFilter(BuiltInCategory category) 
    { 
        _targetCategory = category; 
    } 

    // 2. Rule for physical elements 
    public bool AllowElement(Element elem) 
    { 
        if (elem.Category == null) return false; 
        // Revit 2024+: Exclusively use ElementId.Value (long) instead of IntegerValue
        return elem.Category.Id.Value == (long)_targetCategory; 
    } 

    // 3. Rule for references (e.g. faces, edges) - not needed here 
    public bool AllowReference(Reference reference, XYZ position) 
    { 
        return false; 
    } 
}
```

**Using the filter class in a command:**

```csharp
// Run restricted selection for Rooms only 
ISelectionFilter roomFilter = new CategorySelectionFilter(BuiltInCategory.OST_Rooms); 
// The cursor changes and the user can only click on Rooms 
IList<Reference> pickedRefs = uiDoc.Selection.PickObjects(ObjectType.Element, roomFilter, "Select rooms and click Finish");
```
