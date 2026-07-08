# Skill: Collaborative Environments, Subprojects and Element Borrowing (Worksharing & Element Borrowing)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-014
* **Technical Area:** Multi-user Environments / Element Ownership / Database Concurrency
* **API dependencies:** `Autodesk.Revit.DB.WorksharingUtils`, `Autodesk.Revit.DB.WorksetTable`, `Autodesk.Revit.DB.CheckoutStatus`
* **Key Concepts:** Central Model, Local Replica, Checkout, Relinquish (Synchronization).
* **Operational Impact:** Critical. Prevents fatal exceptions (`Autodesk.Revit.Exceptions.ModificationOutsideTransactionException` or database crashes) when attempting to mutate an element that is being edited by another user.

---

## 2. The Worksharing Architecture in Revit



When a model has collaborative working enabled (`doc.IsWorkshared == true`), the database is logically divided into Worksets. 
The elements no longer belong only to the document, but have an "Owner" (Owner). 

There are three possible states for an element in a collaborative environment:
1. **OwnedByOther:** Another user has modified the item and has not synced yet. Your Add-in **cannot** modify this element under any circumstances.
2. **OwnedByMe:** The current user has exclusive control of the item.
3. **Unowned:** No one is editing it. If the Add-in tries to modify it, Revit will try to do an automatic and silent "Checkout" with the central server. If it fails due to network latency, the transaction will crash.

---

## 3. Antipattern Matrix vs Resilient Code

The biggest mistake when operating on shared databases is assuming that the item is available for modification and letting the Transaction try to resolve the conflict.

### Common Anti-Pattern (Risk of Synchronous Blocking)
```csharp
// FATAL: Modify elements massively without checking their status on the server.
using (Transaction t = new Transaction(doc, "Update Walls"))
{
    t.Start();
    foreach (Wall wall in walls)
    {
        // If user "Juan" is editing this wall, the next line launches 
        // a native Revit dialog box blocking code execution.
        wall.LookupParameter("Comments").Set("Audited"); 
    }
    t.Commit();
}
Optimized Pattern (Pre-Validation and Explicit Borrowing)
Robust software architecture requires validating the item state with WorksharingUtils before opening the transaction, and explicitly borrowing all required items.
C#
public void UpdateSecureElements(Document doc, ICollection<ElementId> elementsIds)
{
    // 1. If it is not a collaborative model, the flow is the standard (SKILL 3)
    if (!doc.IsWorkshared)
    {
        ModifyElements(doc, elementsIds);
        return;
    }

    // 2. Filter only the elements that can be modified
    List<ElementId> availableElements = new List<ElementId>();

    foreach (ElementId id in elementsIds)
    {
        CheckoutStatus status = WorksharingUtils.GetCheckoutStatus(doc, id);
        
        // Discard items blocked by other users
        if (status != CheckoutStatus.OwnedByOther)
        {
            availableElements.Add(id);
        }
    }

    if (AvailableItems.Count == 0) return;

    // 3. Request control from the central server BEFORE the main transaction
    // This communicates with the network, so it is the most critical step.
    ICollection<ElementId> borrowedElements = WorksharingUtils.CheckoutElements(doc, AvailableElements);

    // 4. Secure Modification (Only on the elements that the server granted us)
    using (Transaction t = new Transaction(doc, "Collaborative Update"))
    {
        t.Start();
        ModifyElements(doc, BorrowedElements);
        t.Commit();
    }
}
4. Subproject Management (Worksets)
In many BIM audit or geometric instantiation routines, the standard (BEP - BIM Execution Plan) requires that elements be placed in a specific Subproject (e.g. "ARQ - Interiors").
The Subproject parameter is not read or written using a GUID or name, but rather via its native WorksetId associated with BuiltInParameter.ELEM_PARTITION_PARAM.
C#
// Find a Subproject by name
WorksetTable worksetTable = doc.GetWorksetTable();
Workset targetsubproject = new FilteredWorksetCollector(doc)
    .OfKind(WorksetKind.UserWorkset)
    .FirstOrDefault(w => w.Name == "ARQ - Interiors");

if (subprojecttarget != null)
{
    // Assign the element to the subproject
    Parameter paramWorkset = element.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM);
    if (paramWorkset != null && !paramWorkset.IsReadOnly)
    {
        paramWorkset.Set(targetsubproject.Id.IntegerValue);
    }
}
5. Agent Injection Instructions (Prompting Prompt)
When generating code that modifies multiple elements or runs maintenance routines on the Revit database, strictly follow these guidelines:
Mandatory Environment Evaluation: Before executing mass modification logic, always evaluate the doc.IsWorkshared property. If true, it compulsorily applies Element Borrowing protocols.
Silent Handling of Rejects: Never throw an exception or stop the entire command if WorksharingUtils.GetCheckoutStatus returns OwnedByOther. Records the ignored element in a Log file (SKILL 4) or in a final report for the user, and continues operating on the available elements.
Prohibition of Automatic Synchronization: The agent should NEVER inject code that automatically invokes Document.SynchronizeWithCentral() upon completion of a command, unless the user has explicitly requested it in the tool design. Forcing a sync without user consent disrupts the team's workflow.
Subproject Parameter Check: When creating new elements, assume that Revit will place them in the "Active Subproject" (WorksetTable.GetActiveWorksetId). If the algorithm requires them to go to a specific one, mutate the BuiltInParameter.ELEM_PARTITION_PARAM immediately after the element is created and within the same transaction.