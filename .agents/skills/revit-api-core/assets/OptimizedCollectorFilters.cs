// ==============================================================================
// SKILL: SKILL-RVT-CORE (Revit API Core Engine)
// PATTERN: Fast Filter Extension Methods
// PURPOSE: Provides highly optimized, native C++ memory-level querying methods 
//          for Document objects. Prevents early evaluation and CLR marshalling 
//          overhead caused by premature LINQ usage.
// DEPENDENCIES: Autodesk.Revit.DB, System.Collections.Generic, System.Linq
// ==============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Core
{
    /// <summary>
    /// Extension methods for the Revit Document class to perform high-speed database queries.
    /// These methods prioritize 'Quick Filters' (evaluated natively in Revit's memory) 
    /// over 'Slow Filters' or .NET LINQ evaluations.
    /// </summary>
    public static class OptimizedCollectorFilters
    {
        /// <summary>
        /// Retrieves all physical instances of a specific BuiltInCategory in the model.
        /// Excludes Family Symbols/Types automatically.
        /// </summary>
        /// <param name="doc">The active Revit Document.</param>
        /// <param name="category">The exact BuiltInCategory to filter (e.g., OST_Walls).</param>
        /// <returns>A collection of physical Elements.</returns>
        public static IEnumerable<Element> GetInstancesByCategory(this Document doc, BuiltInCategory category)
        {
            if (doc == null) throw new ArgumentNullException(nameof(doc));

            return new FilteredElementCollector(doc)
                .OfCategory(category)
                .WhereElementIsNotElementType()
                .ToElements();
        }

        /// <summary>
        /// Retrieves all Family Types (Symbols) of a specific BuiltInCategory in the model.
        /// Excludes physical instances. Useful for UI dropdowns or Type swapping.
        /// </summary>
        /// <param name="doc">The active Revit Document.</param>
        /// <param name="category">The exact BuiltInCategory to filter (e.g., OST_Doors).</param>
        /// <returns>A collection of ElementTypes.</returns>
        public static IEnumerable<ElementType> GetTypesByCategory(this Document doc, BuiltInCategory category)
        {
            if (doc == null) throw new ArgumentNullException(nameof(doc));

            return new FilteredElementCollector(doc)
                .OfCategory(category)
                .WhereElementIsElementType()
                .Cast<ElementType>()
                .ToList();
        }

        /// <summary>
        /// Retrieves all elements belonging to a specific native Class (e.g., View, Level, Grid).
        /// </summary>
        /// <typeparam name="T">The native Revit API class type inheriting from Element.</typeparam>
        /// <param name="doc">The active Revit Document.</param>
        /// <returns>A strongly-typed list of the requested elements.</returns>
        public static IEnumerable<T> GetElementsByClass<T>(this Document doc) where T : Element
        {
            if (doc == null) throw new ArgumentNullException(nameof(doc));

            return new FilteredElementCollector(doc)
                .OfClass(typeof(T))
                .Cast<T>()
                .ToList();
        }

        /// <summary>
        /// Performs an ultra-fast spatial query finding all elements whose BoundingBox 
        /// intersects with a target spatial bounding box.
        /// </summary>
        /// <param name="doc">The active Revit Document.</param>
        /// <param name="targetBox">The geometric bounding box to evaluate against.</param>
        /// <param name="categoryFilter">Optional: Constrain the search to a specific category to improve speed.</param>
        /// <returns>Elements intersecting the target zone.</returns>
        public static IEnumerable<Element> GetElementsIntersectingBox(this Document doc, BoundingBoxXYZ targetBox, BuiltInCategory? categoryFilter = null)
        {
            if (doc == null) throw new ArgumentNullException(nameof(doc));
            if (targetBox == null) throw new ArgumentNullException(nameof(targetBox));

            // Create the fast spatial filter (Evaluated before geometry extraction)
            Outline outline = new Outline(targetBox.Min, targetBox.Max);
            BoundingBoxIntersectsFilter boxFilter = new BoundingBoxIntersectsFilter(outline);

            FilteredElementCollector collector = new FilteredElementCollector(doc);

            // Apply category Funneling if provided (reduces the pool of elements to check spatially)
            if (categoryFilter.HasValue)
            {
                collector.OfCategory(categoryFilter.Value);
            }

            return collector
                .WhereElementIsNotElementType()
                .WherePasses(boxFilter)
                .ToElements();
        }

        /// <summary>
        /// Safely retrieves an element by its UniqueId (GUID string) without throwing 
        /// exceptions if the element was deleted or doesn't exist.
        /// </summary>
        /// <param name="doc">The active Revit Document.</param>
        /// <param name="uniqueId">The string GUID representation of the element.</param>
        /// <returns>The Element if found; otherwise, null.</returns>
        public static Element GetElementByGuidSafe(this Document doc, string uniqueId)
        {
            if (doc == null) throw new ArgumentNullException(nameof(doc));
            if (string.IsNullOrWhiteSpace(uniqueId)) return null;

            try
            {
                return doc.GetElement(uniqueId);
            }
            catch (Autodesk.Revit.Exceptions.ArgumentException)
            {
                // Element was deleted or GUID is malformed
                return null;
            }
        }
    }
}