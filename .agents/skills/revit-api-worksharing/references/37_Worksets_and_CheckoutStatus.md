# Skill Reference: Worksets and Checkout Status

## 1. Concurrency Context (Central vs Local)
When a Revit model has worksharing enabled (`doc.IsWorkshared == true`), elements are locked dynamically by the active users. Any attempt to modify a model element without owning it or borrowing it first can result in a fatal `Autodesk.Revit.Exceptions.ModificationOutsideTransactionException` or freeze execution when a native "permission request" dialog pops up.

## 2. Checking Element Checkout Status
Before making database changes inside collaborative central models, the Add-in must query the element's status using `WorksharingUtils.GetCheckoutStatus(doc, elementId)`.

### CheckoutStatus Definitions:
1.  **`NotBorrowed`**: The element is free. The database will attempt a silent, automatic checkout when modified.
2.  **`OwnedByCurrentUser`**: The active session owns the element. Safe to modify.
3.  **`OwnedByOtherUser`**: Lockout. Another user has borrowed or checked out the element. **Do NOT attempt to modify**.

### Code Blueprint: Safety Filter Loop
```csharp
public static List<ElementId> GetWriteableElements(Document doc, ICollection<ElementId> targetIds)
{
    List<ElementId> writeable = new List<ElementId>();
    if (!doc.IsWorkshared) return targetIds.ToList();

    foreach (ElementId id in targetIds)
    {
        CheckoutStatus status = WorksharingUtils.GetCheckoutStatus(doc, id);
        if (status != CheckoutStatus.OwnedByOther)
        {
            writeable.Add(id);
        }
    }
    return writeable;
}
```

## 3. Explicit Element Borrowing
To avoid transaction collapses on slow networks, explicitly borrow elements prior to opening the transaction using `WorksharingUtils.CheckoutElements(doc, elementIds)`. This contacts the central model server to request locks synchronously.
