// ==============================================================================
// SKILL: SKILL-RVT-EXP (Export & Interoperability)
// PATTERN: Native PDF Batch Exporter (Revit 2022+)
// PURPOSE: Generates PDF files from Views and Sheets without virtual printers.
// DEPENDENCIES: Autodesk.Revit.DB, System.Collections.Generic
// ==============================================================================

using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Export
{
    /// <summary>
    /// Utility class for batch exporting Views and Sheets to PDF format natively.
    /// </summary>
    public static class PdfExportManager
    {
        /// <summary>
        /// Exports a list of views/sheets to a single combined PDF or multiple individual PDFs.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="viewIds">List of View/Sheet ElementIds to export.</param>
        /// <param name="exportFolder">Destination directory on the local disk.</param>
        /// <param name="fileName">The output filename (without .pdf extension).</param>
        /// <param name="combine">True to merge into one PDF; False for individual files.</param>
        /// <returns>True if the export was successfully dispatched.</returns>
        public static bool ExportToPdf(Document doc, IList<ElementId> viewIds, string exportFolder, string fileName, bool combine = true)
        {
            if (doc == null || viewIds == null || viewIds.Count == 0 || string.IsNullOrWhiteSpace(exportFolder))
                return false;

            try
            {
                PDFExportOptions options = new PDFExportOptions
                {
                    Combine = combine,
                    FileName = fileName,
                    // Vector format is mandatory for high-quality architectural deliverables
                    RasterQuality = RasterQualityType.High, 
                    AlwaysUseRaster = false,
                    ExportVisibleInCurrentViewOnly = false,
                    ZoomType = ZoomFitType.Zoom,
                    ZoomPercentage = 100
                };

                // Native API call (Supported Revit 2022 and above)
                doc.Export(exportFolder, viewIds, options);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ExportAPI] PDF Export Failed: {ex.Message}");
                return false;
            }
        }
    }
}