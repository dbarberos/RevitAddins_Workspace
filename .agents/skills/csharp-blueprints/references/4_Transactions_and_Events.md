# Guide 4: Transactions, Collaboration, and Events

This guide covers the database safety protocols you must follow to modify the Revit database. It details how to write transactions, check element editability in collaborative (Workshared) environments, and hook into native Revit events securely without disrupting standard user workflows.

## 1. Transactions: Database Integrity

In Revit, the model database is locked by default. To make any changes (creating, modifying, or deleting elements), you must request a spot in the processing queue using a `Transaction`.

**Best Practices:**
*   **Declare with Using**: Always wrap transactions in a `using` block. This guarantees the transaction is properly disposed of from memory and closed, even if an unexpected error occurs during execution.
*   **Descriptive Naming**: Provide a clear name when starting the transaction (e.g., "MyPlugin: Modify Walls"). This name appears in the user's "Undo" menu, so it should be descriptive and clear.

**Code Example: Transaction Structure**

```csharp
using Autodesk.Revit.DB; 

// ... inside your Execute method ... 
// Assumes you have gathered the view sheets to modify 

// The using block ensures the transaction memory is released when finished 
using (Transaction t = new Transaction(doc, "Guru: Add Revisions")) 
{ 
    // 1. Start the transaction 
    t.Start(); 

    foreach (ViewSheet sheet in selectedSheets) 
    { 
        // 2. Modify the model (e.g., add a revision ID to a sheet) 
        var currentRevisions = sheet.GetAdditionalRevisionIds(); 
        currentRevisions.Add(myRevisionId); 
        sheet.SetAdditionalRevisionIds(currentRevisions); 
    } 

    // 3. Commit and save changes to the database 
    t.Commit(); 
}
```

---

## 2. Editability in Collaborative Environments (Worksharing)

Before modifying any element within a transaction, you must ensure you have permission to edit it. In a workshared model, an element could be checked out by another user or out-of-date compared to the central file. Attempting to modify it will throw a fatal error.

**Best Practices:**
*   **Early Checks**: First check if the document is workshared using `doc.IsWorkshared`. If it is not, all elements are editable, and you can skip complex checks.
*   **Check Borrowing and Synchronized States**: Use the `WorksharingUtils` class to retrieve the `CheckoutStatus` (who owns the element) and the `ModelUpdatesStatus` (if it is synchronized with the central file).

**Code Example: Element Editability Extension Method**

```csharp
using Autodesk.Revit.DB; 

public static class ElementExtensions 
{ 
    public static bool IsEditable(this Element element) 
    { 
        Document doc = element.Document; 

        // If the model is not workshared, it is always editable 
        if (!doc.IsWorkshared) return true; 

        // Get the borrowing state of the element 
        CheckoutStatus checkoutStatus = WorksharingUtils.GetCheckoutStatus(doc, element.Id); 
        ModelUpdatesStatus updateStatus = WorksharingUtils.GetModelUpdatesStatus(doc, element.Id); 

        // If owned by another user, we cannot edit it 
        if (checkoutStatus == CheckoutStatus.OwnedByOtherUser) return false; 

        // If owned by the current user, we can edit it 
        if (checkoutStatus == CheckoutStatus.OwnedByCurrentUser) return true; 

        // If no one owns it, verify it is up-to-date with the central file 
        return updateStatus == ModelUpdatesStatus.CurrentWithCentral; 
    } 
}
```

*Practical Usage: In your execution loop, call `if (myElement.IsEditable()) { ... }` before modifying elements to prevent crashes.*

---

## 3. Event Handling and Delegation

The Revit API constantly triggers background events (such as document opening, printing, and synchronizing). You can subscribe your own methods to these events to execute code automatically.

**Best Practices:**
*   **Mandatory Try/Catch Blocks**: When subscribing to native Revit events (such as `DocumentSynchronizingWithCentral`), your code runs on the main execution thread. If your code fails with an unhandled exception, it can block the user's sync process completely. You must wrap event handler bodies in a `try-catch` block.
*   **Responsible Subscriptions**: Subscribe to an event using `+=` and ensure you unsubscribe using `-=` (preferably in the `OnShutdown` method of your `IExternalApplication`) to avoid leaving ghost processes in memory.

**Code Example: Subscribing to a Synchronizing Event**

```csharp
using Autodesk.Revit.ApplicationServices; 
using Autodesk.Revit.DB.Events; 
using System; 
using System.Diagnostics; 

public static class SyncTimer 
{ 
    private static DateTime _syncStart; 

    // Subscribe method (called in the application's OnStartup) 
    public static void Register(ControlledApplication app) 
    { 
        // Subscribe to the event that fires when starting a sync 
        app.DocumentSynchronizingWithCentral += OnSyncStarted; 
    } 

    // Unsubscribe method (called during OnShutdown) 
    public static void Deregister(ControlledApplication app) 
    { 
        app.DocumentSynchronizingWithCentral -= OnSyncStarted; 
    } 

    // The delegate method reacting to the event 
    private static void OnSyncStarted(object sender, DocumentSynchronizingWithCentralEventArgs e) 
    { 
        // Wrap in try-catch to never block the user's synchronization process 
        try 
        { 
            _syncStart = DateTime.Now; // Save starting time 
            Debug.WriteLine($"Sync started at: {_syncStart}"); 
        } 
        catch (Exception ex) 
        { 
            // Silent error logging 
            Debug.WriteLine($"Error in sync event handler: {ex.Message}"); 
        } 
    } 
}
```
