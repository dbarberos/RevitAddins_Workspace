// ==============================================================================
// SKILL: SKILL-RVT-FAM (Families & Documentation)
// PATTERN: Safe Family Instantiation
// PURPOSE: Handles the loading of .rfa files, safe activation of FamilySymbols 
//          (Types) in memory, and placement of point-based or hosted instances.
// DEPENDENCIES: Autodesk.Revit.DB
// ==============================================================================

using System;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Families
{
    /// <summary>
    /// Utility class to safely place Family Instances in a Project environment.
    /// </summary>
    public static class FamilyInstantiator
    {
        /// <summary>
        /// Safely activates a FamilySymbol in memory. MUST be done before placing an instance.
        /// Requires an active Transaction.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="symbol">The FamilySymbol (Type) to activate.</param>
        /// <returns>True if active and ready to be placed.</returns>
        public static bool EnsureSymbolIsActive(Document doc, FamilySymbol symbol)
        {
            if (doc == null || symbol == null) return false;

            if (!symbol.IsActive)
            {
                symbol.Activate();
                doc.Regenerate(); // Critical: Compiles the symbol into the host memory
            }

            return symbol.IsActive;
        }

        /// <summary>
        /// Places a standalone (point-based) family instance on a specific level.
        /// Requires an active Transaction.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="symbol">The FamilySymbol to instantiate.</param>
        /// <param name="location">XYZ coordinate for placement.</param>
        /// <param name="level">The reference Level.</param>
        /// <returns>The generated FamilyInstance.</returns>
        public static FamilyInstance PlaceStandaloneInstance(Document doc, FamilySymbol symbol, XYZ location, Level level)
        {
            if (doc == null || symbol == null || level == null) return null;
            if (!EnsureSymbolIsActive(doc, symbol)) return null;

            try
            {
                // Autodesk recommends this overload for standard point-based elements (like furniture or trees)
                return doc.Create.NewFamilyInstance(location, symbol, level, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[FamilyAPI] Failed to place instance: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Places a hosted family instance (e.g., a window on a wall, or a light fixture on a ceiling).
        /// Requires an active Transaction.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="symbol">The FamilySymbol to instantiate.</param>
        /// <param name="hostElement">The Wall, Ceiling, or Floor element to host the instance.</param>
        /// <param name="location">XYZ coordinate for placement (must fall on the host's geometry).</param>
        /// <param name="level">The reference Level.</param>
        /// <returns>The generated FamilyInstance.</returns>
        public static FamilyInstance PlaceHostedInstance(Document doc, FamilySymbol symbol, Element hostElement, XYZ location, Level level)
        {
             if (doc == null || symbol == null || hostElement == null || level == null) return null;
             if (!EnsureSymbolIsActive(doc, symbol)) return null;

             try
             {
                 return doc.Create.NewFamilyInstance(location, symbol, hostElement, level, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
             }
             catch (Exception ex)
             {
                 System.Diagnostics.Debug.WriteLine($"[FamilyAPI] Failed to place hosted instance: {ex.Message}");
                 return null;
             }
        }
    }
}