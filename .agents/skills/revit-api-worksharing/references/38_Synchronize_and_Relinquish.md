# Skill Reference: Synchronize and Relinquish Options

## 1. Relinquishing Element Ownership
When a user finishes executing an automation command, the checked-out elements or borrowed worksets should be released back to the central repository. This is known as "Relinquishing".

> [!WARNING]
> **Prohibition of Auto-Sync**: The agent MUST NOT write code that automatically forces a sync with the central model (`Document.SynchronizeWithCentral`) upon command completion, unless explicitly requested by the user. Sincronizaciones automáticas sin consentimiento saturan el servidor y congelan el flujo de trabajo del equipo de diseño.

Instead, rely on Revit's native Relinquish rules during manual synchronization, or use a modeless dialog notifying the user of their borrowed elements list.

## 2. Programmatic Sincronización Options
If the user explicitly requests synchronization (e.g. in a batch nighttime exporter), configure `TransactWithCentralOptions` and `SynchronizeWithCentralOptions`.

### Code Blueprint: Safe Sincronización
```csharp
public static void SyncModel(Document doc)
{
    if (!doc.IsWorkshared) return;

    TransactWithCentralOptions transOptions = new TransactWithCentralOptions();
    SynchronizeWithCentralOptions syncOptions = new SynchronizeWithCentralOptions();

    // Release all borrowed elements and worksets
    RelinquishOptions relinquishOptions = new RelinquishOptions
    {
        StandardWorksets = true,
        ViewWorksets = true,
        FamilyWorksets = true,
        UserCreatedWorksets = true,
        BorrowedElements = true
    };
    
    syncOptions.SetRelinquishOptions(relinquishOptions);
    syncOptions.Comment = "Automated Batch Sync by Add-in";

    try
    {
        doc.SynchronizeWithCentral(transOptions, syncOptions);
    }
    catch (Exception ex)
    {
        System.Diagnostics.Debug.WriteLine($"[SyncAPI] Synchronization Failed: {ex.Message}");
    }
}
```
