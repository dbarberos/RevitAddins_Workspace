# Skill: Reactive Events and Dynamic Model Update (DMU / IUpdater)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-010
* **Technical Area:** Background Automation / Event Listeners / DMU
* **API dependencies:** `Autodesk.Revit.DB.UpdaterRegistry`, `Autodesk.Revit.DB.IUpdater`, `Autodesk.Revit.DB.Events`
* **Design Patterns:** Observer Pattern / Reactor
* **Operational Impact:** Critical. Bad implementations can generate infinite loops, freeze the Host (Revit) or corrupt the undo stack (Undo/Redo).

---

## 2. Reactive Architecture in Revit API

There are two main strategies for running code without direct user intervention in Revit:

### A. Application / Document Events (Listener Mode)
Delegated methods subscribe to global system events. They are executed *after* or *before* a general action occurs, but in independent or closed transactional threads.
* *Examples:* `DocumentOpened`, `DocumentSaving`, `ViewActivated`, `DocumentChanged`.
* *Limitation:* During many of these events, the document is locked (Read-Only) and no new transactions can be started to modify the model.

### B. Dynamic Model Update or DMU (Injector Mode)

It is the most powerful system. Allows you to register an `IUpdater` that listens for changes to specific elements. When the change occurs, Revit pauses the user's native transaction, passes control to the `IUpdater` to modify additional elements, and then merges both actions into a single "Undo" step.

---

## 3. Implementation of the `IUpdater` Contract

To create a dynamic updater, the class must inherit and implement `IUpdater`. 

```csharp
public class AutoNumberingUpdater : IUpdater
{
    private UpdaterId _updaterId;

    public AutoNumberingUpdater(AddInId addInId)
    {
        // The Updater requires a unique GUID injected along with the AddInId
        _updaterId = new UpdaterId(addInId, new Guid("F1A2B3C4-D5E6-7890-A1B2-C3D4E5F6A7B8"));
    }

    public void Execute(UpdaterData data)
    {
        Document doc = data.GetDocument();

        // Extract IDs of the elements that triggered the event
        ICollection<ElementId> addedElementIds = data.GetAddedElementIds();
        ICollection<ElementId> modifiedElementIds = data.GetModifiedElementIds();

        // IMPORTANT: 'using (Transaction t...)' is not used here.
        // The DMU is already running within the user's active transaction.
        
        foreach (ElementId id in addedElementIds)
        {
            Element elem = doc.GetElement(id);
            // Apply business logic (e.g. automatically fill a parameter)
        }
    }

    public string GetUpdaterName() => "Auto Numbering Core";
    public string GetAdditionalInformation() => "Update codes when creating doors.";
    public ChangePriority GetChangePriority() => ChangePriority.DoorsOpeningsWindows;
    public UpdaterId GetUpdaterId() => _updaterId;
}
4. Registration and Triggers
An IUpdater doesn't do anything on its own; It must be registered in the system during Revit startup (OnStartup of the IExternalApplication interface) and associated with a "Trigger" or UpdaterRegistry.AddTrigger.
Common Antipattern (Infinite Loop/Deadly Recursion)
C#
// FATAL: The Updater modifies walls. If a trigger is registered so that the Updater 
// fire "every time a wall is modified", when modifying the wall, 
// the Updater will call itself infinitely until Revit collapses.
Optimized Pattern (Registry Specific)
C#
// Inside the OnStartup of IExternalApplication
AutoNumberingUpdater myUpdater = new AutoNumberingUpdater(application.ActiveAddInId);
UpdaterRegistry.RegisterUpdater(myUpdater);

// 1. Define the Filter (Who do we listen to)
ElementCategoryFilter doorsFilter = new ElementCategoryFilter(BuiltInCategory.OST_Doors);

// 2. Define the Trigger (When we hear it: Only when adding new elements)
UpdaterRegistry.AddTrigger(
    myUpdater.GetUpdaterId(), 
    filterDoors, 
    Element.GetChangeTypeElementAddition()
);
5. Agent Injection Instructions (Prompting Prompt)
To ensure that the development of DMU components meets stability standards in a production environment, it is mandatory to follow these guidelines:
Internal Transactional Prohibition: Never try to start a Transaction, TransactionGroup or invoke doc.Regenerate() within the Execute(UpdaterData) method. The DMU execution context already provides a transaction opened by the native engine.
Recursion Prevention (Anti-Loop): If the IUpdater is going to modify a specific parameter (e.g. "Comments"), the modification trigger (Element.GetChangeTypeParameter) should NEVER be listening for that same parameter. Configure the trigger to listen for changes to the "Geometry" or "Other parameters" to avoid infinite recursive calls.
Mandatory Unregister: Any IUpdater registered in OnStartup using UpdaterRegistry.RegisterUpdater MUST be explicitly unregistered in the OnShutdown method using UpdaterRegistry.UnregisterUpdater. Leaving orphaned updaters in memory corrupts the clean shutdown of the host application.
ChangePriority: Always assign the correct ChangePriority in the Updater contract according to the architectural class that is going to be modified in the Execute method, not according to what triggers the event. This ensures that Revit correctly orders the rebuild of the underlying database.