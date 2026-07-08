// ==============================================================================
// SKILL: SKILL-RVT-MEP (MEP Engineering & Topology)
// PATTERN: Connector Graph Auditor
// PURPOSE: Safely extracts and evaluates physical nodes (Connectors) to determine 
//          network topology, find disconnects, and map 'AllRefs' for autorouting.
// DEPENDENCIES: Autodesk.Revit.DB
// ==============================================================================

using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace RevitAddinBase.MEP
{
    /// <summary>
    /// Extension methods to audit and traverse physical connector nodes 
    /// in Revit MEP networks.
    /// </summary>
    public static class ConnectorGraphAuditor
    {
        /// <summary>
        /// Extracts the ConnectorManager regardless of whether the element is a 
        /// linear curve (Pipe/Duct) or a nodal fitting/equipment (FamilyInstance).
        /// </summary>
        /// <param name="element">The MEP element.</param>
        /// <returns>The ConnectorManager, or null if the element is not MEP capable.</returns>
        public static ConnectorManager GetConnectorManagerSafe(this Element element)
        {
            if (element == null) return null;

            if (element is MEPCurve mepCurve)
            {
                return mepCurve.ConnectorManager;
            }
            else if (element is FamilyInstance fi && fi.MEPModel != null)
            {
                return fi.MEPModel.ConnectorManager;
            }

            return null;
        }

        /// <summary>
        /// Retrieves all physical, unconnected connectors on an element.
        /// Essential for auto-routing algorithms to find valid connection points.
        /// </summary>
        /// <param name="connectorManager">The manager extracted from GetConnectorManagerSafe.</param>
        /// <param name="domainFilter">Optional: Find only Piping or HVAC connectors.</param>
        /// <returns>A collection of free Connector nodes.</returns>
        public static IEnumerable<Connector> GetFreeConnectors(this ConnectorManager connectorManager, Domain? domainFilter = null)
        {
            if (connectorManager == null) yield break;

            ConnectorSet connectors = connectorManager.Connectors;

            foreach (Connector conn in connectors)
            {
                // CRITICAL: Ignore logical connectors (Systems) as they have no physical origin (XYZ)
                if (conn.ConnectorType == ConnectorType.Logical) continue;

                if (!conn.IsConnected)
                {
                    if (domainFilter.HasValue && conn.Domain != domainFilter.Value) continue;
                    
                    yield return conn;
                }
            }
        }

        /// <summary>
        /// Evaluates the true API connectivity graph to determine if two elements 
        /// are logically and physically linked, ignoring visual overlaps.
        /// </summary>
        /// <param name="elementA">The starting MEP element.</param>
        /// <param name="elementB">The target MEP element.</param>
        /// <returns>True if they share a direct connector reference.</returns>
        public static bool AreElementsPhysicallyConnected(Element elementA, Element elementB)
        {
            if (elementA == null || elementB == null) return false;
            if (elementA.Id == elementB.Id) return false;

            ConnectorManager cmA = elementA.GetConnectorManagerSafe();
            if (cmA == null) return false;

            foreach (Connector connA in cmA.Connectors)
            {
                if (connA.ConnectorType == ConnectorType.Logical) continue;
                if (!connA.IsConnected) continue;

                // Traverse the graph: Check all connections mapped to this node
                ConnectorSet refs = connA.AllRefs;
                foreach (Connector connRef in refs)
                {
                    // Exclude logical system nodes mapping back to themselves
                    if (connRef.ConnectorType == ConnectorType.Logical) continue;

                    // If the owner of the referenced connector is ElementB, we found the link
                    if (connRef.Owner.Id == elementB.Id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}