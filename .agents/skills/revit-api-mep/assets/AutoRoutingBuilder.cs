// ==============================================================================
// SKILL: SKILL-RVT-MEP (MEP Engineering & Topology)
// PATTERN: Auto-Routing & Fitting Generation
// PURPOSE: Generates physical linear networks (Pipes/Ducts) between points and 
//          automatically injects native fittings (Elbows/Tees) by delegating 
//          to the Revit Routing Engine, avoiding manual FamilyInstance placement.
// DEPENDENCIES: Autodesk.Revit.DB, Autodesk.Revit.DB.Plumbing, Autodesk.Revit.DB.Mechanical
// ==============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;

namespace RevitAddinBase.MEP
{
    /// <summary>
    /// Generative utility class for automated MEP routing.
    /// Handles the creation of linear segments and the synchronization required 
    /// to connect them with native fittings (Elbows, Tees, Transitions).
    /// </summary>
    public static class AutoRoutingBuilder
    {
        /// <summary>
        /// Creates a new Pipe segment between two points.
        /// Must be called within an active Transaction.
        /// </summary>
        /// <param name="doc">The active document.</param>
        /// <param name="systemTypeId">The MEPSystemType ID (e.g., Domestic Cold Water).</param>
        /// <param name="pipeTypeId">The PipeType ID (e.g., Standard PVC).</param>
        /// <param name="levelId">The reference Level ID.</param>
        /// <param name="start">Start coordinate (XYZ).</param>
        /// <param name="end">End coordinate (XYZ).</param>
        /// <param name="diameterInternalUnits">Desired diameter in internal units (Feet). Default is 0 (uses system default).</param>
        /// <returns>The generated Pipe instance.</returns>
        public static Pipe CreatePipeSegment(
            Document doc, 
            ElementId systemTypeId, 
            ElementId pipeTypeId, 
            ElementId levelId, 
            XYZ start, 
            XYZ end, 
            double diameterInternalUnits = 0)
        {
            if (doc == null || start.IsAlmostEqualTo(end)) return null;

            // Use the modern static creation method, avoiding doc.Create.NewPipe
            Pipe newPipe = Pipe.Create(doc, systemTypeId, pipeTypeId, levelId, start, end);

            // Mutate diameter if specified
            if (diameterInternalUnits > 0)
            {
                Parameter diameterParam = newPipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM);
                if (diameterParam != null && !diameterParam.IsReadOnly)
                {
                    diameterParam.Set(diameterInternalUnits);
                }
            }

            return newPipe;
        }

        /// <summary>
        /// Generates an automatic Elbow fitting between two pipes or ducts that intersect at a point.
        /// Requires the document to be regenerated if the curves were just created.
        /// </summary>
        /// <param name="doc">The active document.</param>
        /// <param name="curveA">First linear segment (Pipe or Duct).</param>
        /// <param name="curveB">Second linear segment (Pipe or Duct).</param>
        /// <returns>The generated Elbow FamilyInstance, or null if routing preferences fail.</returns>
        public static FamilyInstance GenerateAutoElbow(Document doc, MEPCurve curveA, MEPCurve curveB)
        {
            if (doc == null || curveA == null || curveB == null) return null;

            // 1. Identify the intersection point visually by comparing endpoints
            XYZ intersectionPoint = GetSharedEndpoint(curveA, curveB);
            if (intersectionPoint == null)
            {
                System.Diagnostics.Debug.WriteLine("[AutoRouting] Error: Curves do not share a geometric endpoint.");
                return null;
            }

            // 2. Extract the mathematical connector nodes precisely at the intersection
            Connector connA = GetConnectorAtPoint(curveA, intersectionPoint);
            Connector connB = GetConnectorAtPoint(curveB, intersectionPoint);

            if (connA != null && connB != null)
            {
                try
                {
                    // 3. Delegate to the Native Routing Engine (SKILL 21)
                    // NEVER use doc.Create.NewFamilyInstance for fittings.
                    return doc.Create.NewElbowFitting(connA, connB);
                }
                catch (Autodesk.Revit.Exceptions.InvalidOperationException ex)
                {
                    // This happens if the PipeType's "Routing Preferences" lack an Elbow family
                    System.Diagnostics.Debug.WriteLine($"[AutoRouting] Routing Preferences Failed: {ex.Message}");
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// Orchestrates the creation of two pipes and the immediate generation of an elbow.
        /// Demonstrates the critical 'Regeneration' step required for mathematical nodes to exist.
        /// </summary>
        public static void DrawCorner(
            Document doc, ElementId sysId, ElementId typeId, ElementId levelId, 
            XYZ p1, XYZ p2, XYZ p3)
        {
            // Note: This method assumes an active Transaction is wrapping it.
            
            Pipe pipe1 = CreatePipeSegment(doc, sysId, typeId, levelId, p1, p2, 0);
            Pipe pipe2 = CreatePipeSegment(doc, sysId, typeId, levelId, p2, p3, 0);

            // CRITICAL SYNC (SKILL 21): Compiles the geometry so connectors physically spawn at p2
            doc.Regenerate(); 

            GenerateAutoElbow(doc, pipe1, pipe2);
        }

        #region Helper Methods (Spatial Math)

        private static XYZ GetSharedEndpoint(MEPCurve a, MEPCurve b)
        {
            Curve curveA = (a.Location as LocationCurve)?.Curve;
            Curve curveB = (b.Location as LocationCurve)?.Curve;

            if (curveA == null || curveB == null) return null;

            XYZ[] ptsA = { curveA.GetEndPoint(0), curveA.GetEndPoint(1) };
            XYZ[] ptsB = { curveB.GetEndPoint(0), curveB.GetEndPoint(1) };

            foreach (XYZ ptA in ptsA)
            {
                foreach (XYZ ptB in ptsB)
                {
                    // Use Revit's internal tolerance for spatial comparison
                    if (ptA.IsAlmostEqualTo(ptB)) return ptA;
                }
            }
            return null;
        }

        private static Connector GetConnectorAtPoint(MEPCurve curve, XYZ location)
        {
            ConnectorManager cm = curve.ConnectorManager;
            if (cm == null) return null;

            foreach (Connector conn in cm.Connectors)
            {
                if (conn.ConnectorType == ConnectorType.Logical) continue;

                if (conn.Origin.IsAlmostEqualTo(location))
                {
                    return conn;
                }
            }
            return null;
        }

        #endregion
    }
}