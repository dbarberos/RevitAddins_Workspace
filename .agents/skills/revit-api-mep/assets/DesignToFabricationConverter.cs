// ==============================================================================
// SKILL: revit-api-mep (Fabrication Modeling APIs)
// PATTERN: Design LOD 300 to Fabrication LOD 400 Converter
// PURPOSE: Converts system pipes/ducts to production fabrication parts.
// ==============================================================================

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Fabrication;
using System;
using System.Collections.Generic;

namespace RevitAddinBase.Mep
{
    public class DesignToFabricationConverter
    {
        public void ConvertNetworkToFabrication(Document doc, ISet<ElementId> designIds)
        {
            // 1. Obtain fabrication configuration details
            FabricationConfiguration config = FabricationConfiguration.GetFabricationConfiguration(doc);
            if (config == null)
            {
                throw new InvalidOperationException("No fabrication database loaded in the active document.");
            }

            // 2. Set service mapping ID (e.g. 'Chilled Water - Copper')
            int serviceId = GetFabricationServiceId(config, "CHW_Copper"); 

            using (Transaction t = new Transaction(doc, "Convert to LOD 400"))
            {
                t.Start();

                // 3. Instantiate converter
                Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter converter = 
                    new Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter(doc);
                
                // 4. Run conversion process
                DesignToFabricationConverterResult result = converter.Convert(designIds, serviceId);

                if (result == DesignToFabricationConverterResult.Success)
                {
                    // Optional: Safely delete design pipes if conversion completes fully
                    // doc.Delete(designIds);
                }
                
                t.Commit();
            }
        }

        private int GetFabricationServiceId(FabricationConfiguration config, string serviceName)
        {
            return 0; // Utility placeholder
        }
    }
}
