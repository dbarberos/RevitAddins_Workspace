// ==============================================================================
// SKILL: SKILL-RVT-EXP (Export & Interoperability)
// PATTERN: OpenBIM IFC Exporter
// PURPOSE: Generates IFC files configured for optimal parsing by external engines 
//          (like ThatOpen Company fragments).
// DEPENDENCIES: Autodesk.Revit.DB
// ==============================================================================

using System;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Export
{
    /// <summary>
    /// Utility class for generating OpenBIM deliverables.
    /// </summary>
    public static class IfcExportManager
    {
        /// <summary>
        /// Exports the current document to IFC4 format.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="exportFolder">Destination directory.</param>
        /// <param name="fileName">The output filename (without .ifc extension).</param>
        /// <returns>True if successful.</returns>
        public static bool ExportToIfc4(Document doc, string exportFolder, string fileName)
        {
            if (doc == null || string.IsNullOrWhiteSpace(exportFolder)) return false;

            try
            {
                IFCExportOptions options = new IFCExportOptions
                {
                    // IFC4 is highly recommended for modern web viewers and fragment generation
                    FileVersion = IFCVersion.IFC4,
                    WallAndColumnTracking = true,
                    ExportBaseQuantities = true,
                    // Essential for passing rich metadata to web platforms
                    AddOption = "ExportInternalRevitPropertySets", 
                };

                doc.Export(exportFolder, fileName, options);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ExportAPI] IFC Export Failed: {ex.Message}");
                return false;
            }
        }
    }
}
