// ==============================================================================
// SKILL: SKILL-RVT-EXP (Export & Interoperability)
// PATTERN: DWG/DXF Exporter with Layer Mapping
// PURPOSE: Exports views to CAD formats ensuring specific layer configurations 
//          (ExportDWGSettings) are strictly applied.
// DEPENDENCIES: Autodesk.Revit.DB, System.Collections.Generic, System.Linq
// ==============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Export
{
    /// <summary>
    /// Utility class for generating CAD deliverables with precise layer control.
    /// </summary>
    public static class CadExportManager
    {
        /// <summary>
        /// Exports views to DWG using a specific Export Setup stored in the document.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="viewIds">List of View/Sheet ElementIds to export.</param>
        /// <param name="exportFolder">Destination directory.</param>
        /// <param name="setupName">The name of the Export Setup (e.g., "ISO 13567 Layer Standard").</param>
        /// <returns>True if successful.</returns>
        public static bool ExportToDwg(Document doc, ICollection<ElementId> viewIds, string exportFolder, string setupName)
        {
            if (doc == null || viewIds == null || viewIds.Count == 0) return false;

            // Retrieve the specific export setup from the database
            ExportDWGSettings dwgSettings = new FilteredElementCollector(doc)
                .OfClass(typeof(ExportDWGSettings))
                .Cast<ExportDWGSettings>()
                .FirstOrDefault(s => s.Name.Equals(setupName, StringComparison.InvariantCultureIgnoreCase));

            DWGExportOptions options = dwgSettings != null 
                ? dwgSettings.GetDWGExportOptions() 
                : new DWGExportOptions(); // Fallback to Revit defaults if not found

            // Force visual fidelity overrides
            options.MergedViews = true;
            options.ExportOfSolids = SolidGeometryNodeIdOptions.Polymesh;

            try
            {
                // Note: The third parameter is an arbitrary prefix for the generated files
                doc.Export(exportFolder, "CAD_Batch", viewIds, options);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ExportAPI] DWG Export Failed: {ex.Message}");
                return false;
            }
        }
    }
}