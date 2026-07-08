// ==============================================================================
// SKILL: SKILL-RVT-MEP (MEP Engineering & Topology)
// PATTERN: LOD 400 Fabrication Converter & Spooling
// PURPOSE: Handles the automated translation of Design Intent (LOD 300) to 
//          Fabrication Parts (LOD 400). Manages commercial length optimization 
//          and structural hanger placement via ITM/MAJ databases.
// DEPENDENCIES: Autodesk.Revit.DB, Autodesk.Revit.DB.Fabrication, System.Collections.Generic
// ==============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Fabrication;

namespace RevitAddinBase.MEP
{
    /// <summary>
    /// Advanced utility class to interact with Revit's CAM/Fabrication engine.
    /// Operates exclusively with FabricationParts, completely bypassing standard Pipe/Duct logic.
    /// </summary>
    public static class FabricationConverter
    {
        /// <summary>
        /// Converts a selection of LOD 300 Pipes/Ducts into LOD 400 Fabrication Parts.
        /// Must be called within an active Transaction.
        /// </summary>
        /// <param name="doc">The active document.</param>
        /// <param name="designElementIds">The Elements to convert (Pipes, Ducts, native Fittings).</param>
        /// <param name="serviceId">The internal ID of the Fabrication Service (e.g., 'Chilled Water - Copper').</param>
        /// <returns>True if the conversion was fully successful; Partial or Failed returns false.</returns>
        public static bool ConvertDesignToFabrication(Document doc, ISet<ElementId> designElementIds, int serviceId)
        {
            if (doc == null || designElementIds == null || !designElementIds.Any()) return false;

            // 1. Critical Validation: Ensure a fabrication database is actually loaded in the project
            FabricationConfiguration config = FabricationConfiguration.GetFabricationConfiguration(doc);
            if (config == null)
            {
                System.Diagnostics.Debug.WriteLine("[FabricationAPI] Fatal: No Fabrication Configuration loaded in this model.");
                return false;
            }

            // 2. Instantiate the native converter engine
            DesignToFabricationConverter converter = new DesignToFabricationConverter(doc);
            
            // 3. Execute translation using the specified MAJ database service
            DesignToFabricationConverterResult result = converter.Convert(designElementIds, serviceId);

            if (result == DesignToFabricationConverterResult.Success)
            {
                // Optional: Delete the original Design Intent elements if required by BIM execution plan
                // doc.Delete(designElementIds);
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"[FabricationAPI] Conversion ended with status: {result}");
                return false;
            }
        }

        /// <summary>
        /// Automatically segments long straight fabrication runs into purchasable commercial lengths
        /// based on the restrictions defined in the ITM catalog.
        /// </summary>
        /// <param name="doc">The active document.</param>
        /// <param name="fabricationPartIds">The IDs of the straight FabricationParts to optimize.</param>
        public static void OptimizeFabricationLengths(Document doc, ISet<ElementId> fabricationPartIds)
        {
            if (doc == null || fabricationPartIds == null || !fabricationPartIds.Any()) return;

            // This static method automatically cuts the pipes and inserts the necessary couplings/welds
            FabricationPart.OptimizeLengths(doc, fabricationPartIds);
        }

        /// <summary>
        /// Places a physical support (Hanger) on a Fabrication Part and snaps its rod 
        /// to the nearest upper structural element.
        /// Must be called within an active Transaction.
        /// </summary>
        /// <param name="doc">The active document.</param>
        /// <param name="fabPart">The FabricationPart (Pipe/Duct) to support.</param>
        /// <param name="hangerButtonId">The internal ID of the hanger item in the Fabrication Service.</param>
        /// <param name="structuralSlabId">The ElementId of the Floor/Roof to anchor the hanger rod into.</param>
        /// <param name="relativePosition">Parametric position along the pipe (0.0 to 1.0). Default is 0.5 (Center).</param>
        /// <returns>The generated Hanger element, or null if placement fails.</returns>
        public static FabricationPart AddHangerToFabricationPart(
            Document doc, 
            FabricationPart fabPart, 
            int hangerButtonId, 
            ElementId structuralSlabId, 
            double relativePosition = 0.5)
        {
            if (doc == null || fabPart == null) return null;

            // 1. Hangers require a connector reference from the host pipe to attach to.
            Connector attachNode = GetPrimaryConnector(fabPart);
            if (attachNode == null) return null;

            try
            {
                // 2. Generate the hanger geometry on the pipe
                FabricationPart hanger = FabricationPart.CreateHanger(
                    doc, 
                    hangerButtonId, 
                    fabPart.Id, 
                    attachNode, 
                    relativePosition);

                if (hanger != null && structuralSlabId != ElementId.InvalidElementId)
                {
                    // 3. Shoot a ray up and adjust the threaded rod to hit the concrete slab
                    Element slab = doc.GetElement(structuralSlabId);
                    if (slab != null)
                    {
                        hanger.AdjustLengthTo(slab);
                    }
                }

                return hanger;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[FabricationAPI] Failed to place hanger: {ex.Message}");
                return null;
            }
        }

        #region Helper Methods

        private static Connector GetPrimaryConnector(FabricationPart part)
        {
            ConnectorManager cm = part.ConnectorManager;
            if (cm == null) return null;

            foreach (Connector conn in cm.Connectors)
            {
                // Return the first physical connector to act as the anchor alignment node
                if (conn.ConnectorType != ConnectorType.Logical)
                {
                    return conn;
                }
            }
            return null;
        }

        #endregion
    }
}