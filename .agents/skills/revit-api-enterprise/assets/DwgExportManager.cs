// ==============================================================================
// SKILL: revit-api-enterprise (Distributed & Cloud Integrations)
// PATTERN: Structured Batch DWG Exporter
// PURPOSE: Exports multiple sheet views to DWG format with strict standards.
// ==============================================================================

using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;

namespace RevitAddinBase.Enterprise
{
    public class DwgExportManager
    {
        public void ExportSheetsToDwg(Document doc, string destinationFolder, ICollection<ElementId> viewIds)
        {
            // 1. Configure strict DWG export options
            DWGExportOptions dwgOptions = new DWGExportOptions
            {
                MergedViews = true, // Merge external references (XREFs) into a single master file
                ExportOfSolids = SolidGeometryObjectExport.Polymesh,
                TargetUnit = ExportUnit.Meter
            };

            // 2. Run the export engine
            // The method Export accepts a file name suffix added to view/sheet names
            bool success = doc.Export(destinationFolder, "BIM_SettingOut", viewIds, dwgOptions);
            
            if (!success)
            {
                throw new InvalidOperationException("DWG export operation failed.");
            }
        }
    }
}
