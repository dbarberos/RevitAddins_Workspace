# Skill: Electrical Topology, Circuits and Distribution Boards (ElectricalSystem)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-022
* **Technical Area:** Electrical Engineering / Power Distribution / Load Balancing
* **API dependencies:** `Autodesk.Revit.DB.Electrical`
* **Key Concepts:** Logical Circuits, Base Equipment (Panels), Load Classifications.
* **Operational Impact:** Fundamental for the automation of phase balances, mass assignment of luminaires/plugs to electrical panels and auditing of voltage drops.

---

## 2. The Electrical Paradigm: Loads vs Cables



The biggest mental hurdle when programming electrical routines in Revit is understanding that **the physical cable (`Wire`) is irrelevant to thermodynamic or power calculations**. The cable is, in essence, a visual annotation or 2.5D detail element.

The Revit electric engine operates under a strict relational database model based on three pillars:
1. **The Load (`FamilyInstance` with Electrical Connector):** A light fixture, an outlet or a motor. It has an Apparent Power (VA) parameter and a Load Rating (e.g. *Lighting*, *Strength*).
2. **The Circuit (`ElectricalSystem`):** An invisible logical container. Groups several Loads and adds their power considering demand factors.
3. **The Frame or Panel (`FamilyInstance` with Base Equipment property):** The root node that feeds one or more Circuits.

---

## 3. Creation of Logic Circuits (Power Systems)

To automate the electrical installation, no cables are routed. The receiving elements (Loads) are selected and injected into a new `ElectricalSystem`.

### Optimized Pattern (Panel Creation and Assignment)

```csharp
using Autodesk.Revit.DB.Electrical;

public ElectricalSystem CreateCircuitAndAssignPanel(Document doc, ICollection<ElementId> idsLuminarias, FamilyInstanceElectricalBox)
{
    using (Transaction t = new Transaction(doc, "Create Lighting Circuit"))
    {
        t.Start();

        // 1. Create the logical system by grouping the loads.
        // The ElectricalSystemType defines whether it is Power, Data, Security, etc.
        ElectricalSystem newCircuit = ElectricalSystem.Create(doc, LuminaireIds, ElectricalSystemType.PowerCircuit);

        if (newCircuit != null)
        {
            // 2. Connect the logic circuit to the Distribution Board (Panel)
            // This establishes the hierarchical relationship in the System Navigator.
            newCircuit.SelectPanel(electricPanel);
            
            // 3. (Optional) Assign a specific circuit name or number if the standard requires it
            // newCircuit.get_Parameter(BuiltInParameter.RBS_ELEC_CIRCUIT_NAME).Set("L-01");
        }

        t.Commit();
        return newCircuit;
    }
}
4. Antipattern Matrix vs Resilient Code
Common Anti-Pattern (Wires-Based Audit)
C#
// FATAL: Trying to calculate the load of a frame by adding the properties of the modeled cables.
// Many modelers don't draw the wires; they use automatic arrows or they don't model anything physical. 
// The calculation will return 0 or incomplete data.
Optimized Pattern (Reverse Path: From Panel to Load)
To audit an electrical panel, you must iterate over its assigned logic circuits and read the parameters natively added by the Revit engine.
C#
public double CalculatePanelTotalLoad(FamilyInstance panel)
{
    // Check if the family really works as electrical equipment (Equipment)
    MEPModel model = panel.MEPModel;
    if (model == null || !(model is ElectricalEquipmentelectricalEquipment))
    {
        throw new ArgumentException("The selected element is not a Distribution Chart.");
    }

    double totalapparentload = 0;

    // Get all circuits powered by this panel
    ElementSet circuits = electricalequipment.GetAssignedElectricalSystems();
foreach (ElectricalSystem circuit in circuits)
    {
        // Extract the summed and factored power calculated by the internal motor (In Voltamperes - VA)
        Parameter paramApparentLoad = circuit.get_Parameter(BuiltInParameter.RBS_ELEC_APPARENT_LOAD);
        
        if (paramApparentLoad != null && paramApparentLoad.HasValue)
        {
            // The internal units for electrical power in Revit are W or VA (internally equivalent)
            TotalApparentLoad += paramApparentLoad.AsDouble();
        }
    }

    return totalapparentload;
}
5. The Problem of Pole Assignment (Voltage and Phases)
A very common exception when using .SelectPanel() occurs when the Load Voltage (e.g. 230V) or the number of Poles (e.g. 1 Pole) does not match the Distribution System assigned to the Panel (e.g. Three Phase 400V/230V).
The agent should verify that the voltage definitions are compatible before attempting the connection by reading the ElectricalSystem.Voltage property and comparing it to the capabilities of the Panel's FamilyInstance.
6. Agent Injection Instructions (Prompting Prompt)
When processing logic related to electrical installations and control panels, rigorously apply these architectural rules:
Ignore OST_Wire Category for Logic: It is strictly prohibited to use elements of the Wire class or the OST_Wire category to determine electrical connectivity, voltage drop or load balance. All electrical topology evaluation MUST be done through the ElectricalSystem class.
Base Equipment Validation (ElectricalEquipment): Before attempting to use the SelectPanel() method on an ElectricalSystem, always verify that the target element is a FamilyInstance whose MEPModel can be safely cast to ElectricalEquipment. If you pass a normal light fixture as a panel, the code will throw an exception.
Aggregate Reading of Parameters: To obtain electrical data (Intensity, Voltage Drop, Power), do not iterate through each socket or luminaire to add the values ​​in C#. Always extract the added parameter directly from the ElectricalSystem object, taking advantage of Revit's native calculation engine (written in native C++) to ensure identical results to the software's schedules.
Cable Generation (Only upon explicit request): If the BIM standard requires physical modeling of cables, this should be executed ONLY AFTER the creation of the logical ElectricalSystem has been completed. It uses methods like doc.Create.NewWire() extracting the connector paths from the loads already linked to the circuit.