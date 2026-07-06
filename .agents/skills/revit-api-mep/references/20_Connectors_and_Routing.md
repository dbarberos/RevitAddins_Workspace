# Skill: Physical Topology, Connector Management and Routing (ConnectorManager)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-020
* **Technical Area:** MEP Connectivity / Network Graph / Routing
* **API dependencies:** `Autodesk.Revit.DB.Connector`, `Autodesk.Revit.DB.ConnectorManager`, `Autodesk.Revit.DB.MEPCurve`
* **Key Concepts:** Domain, Flow Direction, Connector Coordinate System, References (Refs).
* **Operational Impact:** Critical. It allows you to connect devices by code (Auto-Routing), audit broken networks (Disconnects) and propagate parameters through the model.

---

## 2. Anatomy of a Connector (`Connector`)

In Revit, a connector is not a three-dimensional object, it is a mathematical transfer node. Each connector has:
1. **Origin (`XYZ`):** The exact point in space where the union is made.
2. **Coordinate System (`Transform`):** Defines where the connector "looks" (the `BasisZ` vector is always the output direction perpendicular to the geometric face).
3. **Domain (`Domain`):** Specifies whether it is pipe (`Piping`), conduit (`Hvac`) or electrical (`Electrical`).
4. **Flow Direction (`FlowDirection`):** Indicates whether the node acts as Input (`In`), Output (`Out`) or Bidirectional (`Bidirectional`).

---

## 3. Removing the ConnectorManager (The MEP Triad)

One of the biggest architectural obstacles of the MEP API is that the `ConnectorManager` is not in the same place for all elements. The agent must inject conditional logic based on the element's base class:

* **Linear Sections (`MEPCurve`):** Pipes, Conduits and Cable Trays. They have the direct property `.ConnectorManager`.
* **Equipment and Accessories (`FamilyInstance`):** Boilers, Valves, Elbows. They have the nested property `.MEPModel.ConnectorManager`.
* **Logical Systems (`MEPSystem`):** They do not have a physical `ConnectorManager` (See `SKILL_19`).

```csharp
public ConnectorManager GetConnectorManager(Element elem)
{
    // 1. Case A: Linear Element (Pipe/Conduit)
    if (elem is MEPCurve mepcurve)
    {
        return curveMep.ConnectorManager;
    }
    // 2. Case B: Family Instance (Equipment/Accessory)
    else if (elem is FamilyInstancefamilyInstance && FamilyInstance.MEPModel != null)
    {
        return familyInstance.MEPModel.ConnectorManager;
    }
    
    return null; // The element is not MEP or does not have connectors
}
4. Antipattern Matrix vs Resilient Code
Common Antipattern (False Spatial Analysis)
C#
// FATAL: Assume that two pipes are connected only because their curves end at the same XYZ.
// Revit will not recognize the network, the system will fail and the flow calculations will return zero.
if (pipeA.LocationCurve.GetEndPoint(1).IsAlmostEqualTo(pipeB.LocationCurve.GetEndPoint(0)))
{
    // The developer believes they are connected, but logically they are isolated.
}
Optimized Pattern (Evaluation of References and Logical Nodes)
To find out if "A" is connected to "B", you must iterate over the connectors and evaluate the AllRefs property.
C#
public bool AreConnected(Element elemA, Element elemB)
{
    ConnectorManager cmA = GetConnectorManager(elemA);
    if (cmA == null) return false;

    // Iterate over all connectors of element A
    foreach (Connector connA in cmA.Connectors)
    {
        if (connA.IsConnected)
        {
            // A connector can be attached to multiple things (e.g. a multiple logical node).
            // AllRefs returns the connectors of element 'B' that are hooked to this connector 'A'.
            foreach (Connector connRef in connA.AllRefs)
            {
                // Ignore the logical connector of the system itself
                if (connRef.Owner.Id == elemB.Id)
                {
                    return true; 
                }
            }
        }
    }
    return false;
}
5. Programmatic Connection (Auto-Routing)
To join two pipes or connect a pipe to a pump automatically, the connector origins (XYZ) must match within Revit's tolerance and have compatible domains.
The join is executed using the .ConnectTo() method, which modifies the model and requires an active transaction.
C#
public void JoinFreeConnectors(Document doc, Element elementA, Element elementB)
{
    ConnectorManager cmA = GetConnectorManager(itemA);
    ConnectorManager cmB = GetConnectorManager(itemB);

    ConnectorFreeConnectorA = FindFreeConnector(cmA);
    Connector FreeConnectorB = FindFreeConnector(cmB);

    if (FreeConnectorA != null && FreeConnectorB != null)
    {
        using (Transaction t = new Transaction(doc, "Connect MEP Elements"))
        {
            t.Start();
            
            // If they are not physically at the same point, the logical connection can generate 
            // display errors or breaking Revit routing. (See SKILL 6 to move items).
            if (FreeConnectorA.Origin.IsAlmostEqualTo(FreeConnectorB.Origin))
            {
                FreeConnectorA.ConnectTo(FreeConnectorB);
            }
            
            t.Commit();
        }
    }
}

private Connector FindFreeConnector(ConnectorManager cm)
{
    if (cm == null) return null;
    
    foreach (Connector conn in cm.Connectors)
    {
        // Ignore non-physical connectors (e.g. logical system connectors)
        if (conn.ConnectorType == ConnectorType.Logical) continue;
        
        if (!conn.IsConnected)
        {
            return conn;
        }
    }
    return null;
}
6. Agent Injection Instructions (Prompting Prompt)
When you are required to resolve topology or connectivity issues in MEP installations, strictly apply these policies:
Dual Extraction Rule: NEVER assume that you can get .ConnectorManager directly from the Element object. The agent must always evaluate by type-casting whether it is a MEPCurve or a FamilyInstance to find the manager in the correct property.
Ignoring Logical Connectors (ConnectorType.Logical): When looping through Connector collections, always filter and ignore logical connectors unless you are working exclusively with the MEPSystem topology. A logical connector does not have a valid spatial origin (XYZ) and will throw exceptions if you try to read its .Origin property.
Prohibition of Spatial Collisions for Connectivity: Using BoundingBoxIntersectsFilter or comparing geometric lines to determine whether a pipe network is joined is strictly prohibited. Network auditing MUST be done exclusively by jumping from Connector to Connector.AllRefs.
Pre-Connection Domain Validation: Before invoking connectorA.ConnectTo(connectorB), the agent must ensure by code that connectorA.Domain == connectorB.Domain (e.g. do not try to connect an air duct to an electrical panel).

***

With this competence (Skill 20), the agent acquires the ability to understand and manipulate network graphs in Revit (Nodes and Edges), which is the basis for developing Autorouting algorithms (automatic pipe layout), Clash Resolution (automatic collision avoidance) or generation of single-line principle diagrams.