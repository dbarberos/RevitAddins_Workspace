# Skill: High Performance Collection and Filtering (FilteredElementCollector)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-002
* **Technical Area:** Transactional Database Querying / Memory Optimization
* **API dependencies:** `Autodesk.Revit.DB`
* **Key Concepts:** Marshalling, Fast Filters, Slow Filters, Lazy Evaluation (LINQ)
* **Impact on Performance:** Critical (Logarithmic or operational scale O(N) vs O(1))

---

## 2. The Architecture of the FilteredElementCollector

Revit is primarily developed in native C++. The C# API acts as a Managed Wrapper layer. Every time we request an element from C# to the underlying database, a communication process between native and managed memory called **Marshalling** occurs. If not managed correctly, this process overwhelms the .NET Garbage Collector and severely degrades performance on large models.

The `FilteredElementCollector` class is designed to perform element filtering directly in native C++ memory before passing the objects to the C# layer.

### API Filter Classification (The Execution Pipeline)

To maximize speed, queries should be structured hierarchically following the performance pipeline rule:



1. **Fast Filters:** They operate directly in the native software (C++). They evaluate the essential metadata of the element without needing to expand the entire object in memory.
    * *Examples:* `ElementClassFilter`, `ElementCategoryFilter`, `ElementIsElementTypeFilter`.
2. **Slow Filters:** Requires expanding the entire element in host memory to evaluate complex internal properties or geometries. They should be applied *only* after you have narrowed down the universe of items with quick filters.
    * *Examples:* `ElementParameterFilter`, `FamilySymbolFilter`, `StructuralInstanceUsageFilter`.
3. **Post-Extract Filtering (.NET/LINQ):** Occurs entirely in C# managed memory. It is the slowest and most flexible point. It should only be used for logical conditions that the Revit API cannot resolve natively.

---

## 3. Code Comparison Matrix and Antipatterns

The following explains the difference between an empirical approach (common in initial scripts) and an advanced software engineering implementation.

### Common Antipattern (Low Efficiency)
```csharp
// FATAL: Download all elements of the model to .NET memory and filter with heavy loops or inefficient LINQ
var allElements = new FilteredElementCollector(doc)
    .WhereElementIsNotElementType()
    .ToElements(); // <--- BUG: Force Marshalling of thousands of objects immediately

foreach (Element in allElements)
{
    if (el.Category != null && el.Category.Name == "Walls") // <--- ERROR: String comparison of categories
    {
        // Business logic
    }
}
Optimized Pattern (High Performance)
C#
// CORRECT: Filtering occurs in C++ and only strictly necessary references are retrieved
ICollection<Element> instantiatedwalls = new FilteredElementCollector(doc)
    .OfCategory(BuiltInCategory.OST_Walls) // <-- Fast Filter (native category ID, no strings)
    .WhereElementIsNotElementType() // <-- Fast Filter
    .ToElements();                         // <-- Optimized execution on a single data set
4. Advanced Integration with LINQ and Deferred Evaluation
When the native Revit API does not provide a specific filter (for example, searching for elements whose custom parameter matches a complex Regex pattern), LINQ should be used safely. The secret lies in keeping the FilteredElementCollector object as an IEnumerable before calling methods like ToList() or ToArray().
Practical Example: Filtering by Type and Safe Casting
C#
public IEnumerable<Wall> GetWallsWithSpecificWidth(Document doc, double minimumWidth)
{
return new FilteredElementCollector(doc)
        .OfClass(typeof(Wall)) // Fast Filter: Restrict the collection to the native Wall class
        .Cast<Wall>() // Safely convert the generic API wrapper to Strongly Typed types
        .Where(w => w.WallType.Width > minimumWidth); // Lazy LINQ filtering in .NET memory
}
Architectural Note: Cast<T>() is substantially more efficient than using .Select(e => e as T) because it takes advantage of the CLR's internal type conversion mechanisms without generating redundant memory allocations in the loop.
5. Agent Injection Instructions (Prompting Prompt)
When processing requirements that involve extracting information from the Revit model, implement the following guidelines:
Prohibition of Strings in Categories: It is strictly prohibited to evaluate categories using strings (Element.Category.Name == "..."). The BuiltInCategory enumerator must be used combined with the .OfCategory() method.
Using BuiltInParameter: To evaluate parameters in slow filters (ElementParameterFilter), always use BuiltInParameter or the GUID of the Shared Parameter. Never search for parameters by their business name visible in the UI.
Type Elimination Strategy: Make sure to explicitly call .WhereElementIsElementType() or .WhereElementIsNotElementType() in each query to avoid mixing family definitions with actual instances installed in the geometric space.
Resource Release (Disposal): If the agent generates multiple large collectors within a complex iterative loop, wrap the FilteredElementCollector in a using block to force the native release of the Revit memory pointer.
***
This module ensures that the agent understands the memory implications of *Marshalling* and how to chain native filters before delegating tasks to LINQ, which is critical to maintaining the stability of Revit in real projects.