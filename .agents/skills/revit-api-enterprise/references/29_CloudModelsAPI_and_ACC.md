# Skill: Cloud Model Management and ACC / BIM 360 (Cloud Models API)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-029
* **Technical Area:** Cloud Collaboration / ACC / BIM 360 / Remote Execution
* **API dependencies:** `Autodesk.Revit.DB.ModelPathUtils`, `Autodesk.Revit.DB.Document`, `Autodesk.Revit.ApplicationServices.Application`
* **Key Concepts:** URN / GUIDs, Region (US/EMEA), WorksetConfiguration, RelinquishOptions.
* **Operational Impact:** Critical for server automation. It allows you to open, audit and synchronize models directly from the cloud without human intervention, forming the basis for "Nightly Builds" routines or centralized data extractions (Data Harvesting).

---

## 2. The Paradigm Shift: Goodbye to Windows Routes



In a traditional environment, opening a file requires a `string` with the path (`C:\Projects\Model.rvt`). In the Revit Cloud Worksharing API, a file does not have a physical path, but rather a **three-party cryptographic identity**:

1. **Region (`string`):** The server where the project is hosted (usually `"US"` or `"EMEA"`).
2. **Project ID (`Guid`):** The unique identifier of the project in BIM 360 / ACC.
3. **Model ID (`Guid`):** The unique identifier of the specific `.rvt` file within that project.

The agent must use the `ModelPathUtils` class to transform these abstract identifiers into a `ModelPath` object that Revit can consume.

---

## 3. Programmatic Opening of Cloud Models

When automating tasks, opening a model in the cloud is a delicate operation. Downloading gigabytes of information blocks the main thread. To optimize this, the `OpenOptions` class should be used to manipulate the settings of worksets (*Worksets*) before the file is loaded into memory.

### Optimized Pattern (Optimized Unattended Opening)
```csharp
public Document OpenUnattendedCloudModel(Application app, string region, Guid projectId, Guid modelId)
{
    // 1. Build the cloud path
    ModelPath CloudPath = ModelPathUtils.ConvertCloudGUIDsToCloudPath(region, projectId, modelId);

    // 2. Configure opening options
    OpenOptions options = new OpenOptions();
    
    // Silently unlink external references (Links) to save RAM and time
    options.DetachFromCentralOption = DetachFromCentralOption.DoNotDetach;
    
    // 3. Subproject Strategy (Worksets)
    // Close all subprojects that are not strictly necessary for the audit
    WorksetConfiguration configSubprojects = new WorksetConfiguration(WorksetConfigurationOption.CloseAllWorksets);
    options.SetOpenWorksetsConfiguration(configSubprojects);

    // 4. Open the document (This operation will download the local cache automatically)
    Document docCloud = app.OpenDocumentFile(CloudPath, options);
    
    return docCloud;
}
4. Secure Sync and Permission Release (Relinquish)
If the script modifies data in the cloud model (for example, updating an "Audited" parameter to all walls), it must return those changes to the central server.
Being a network operation, it requires specific transactional options (TransactWithCentralOptions) and, more critically, releasing permissions (RelinquishOptions) so as not to leave items locked to human users the next day.
C#
public void SyncWithCloud(Document doc, string commentmessage)
{
    if (!doc.IsWorkshared || !doc.IsModelInCloud) return;

    // 1. Synchronization Options
    SynchronizeWithCentralOptions syncOptions = new SynchronizeWithCentralOptions();
    syncOptions.SaveLocalBefore = true;
    syncOptions.SaveLocalAfter = false; 
    syncOptions.Comment = $"[Auto-Script] {messageComment}";

    // 2. Permission Release Options (Return ownership to the server)
    RelinquishOptions relinquish = new RelinquishOptions(true);
relinquish.StandardWorksets = true;
    relinquish.ViewWorksets = true;
    relinquish.FamilyWorksets = true;
    relinquish.UserWorksets = true;
    relinquish.CheckedOutElements = true; // Fundamental: Release borrowed elements

    syncOptions.SetRelinquishOptions(relinquish);

    // 3. Transactional Network Options
    TransactWithCentralOptions netOptions = new TransactWithCentralOptions();

    // 4. Execute the synchronization towards ACC/BIM 360
    doc.SynchronizeWithCentral(netOptions, syncOptions);
}
5. Antipattern Matrix vs Resilient Code
Common Antipattern (Local Cache Manipulation)
C#
// FATAL: Try to open or modify the temporary files that Revit saves in the folder 
// %LocalAppData%\Autodesk\Revit\PacCache.
// These files are fragmented binaries. Try to open the .rvt from the local cache 
// instead of using ModelPathUtils it will corrupt the file and break the link with the cloud.
Optimized Pattern (Environment Identification)
Before executing conditional logic on how to save a file, the agent must read the state of the document using native properties to route the action correctly.
C#
public void SaveModel(Document doc)
{
    if (doc.IsModelInCloud)
    {
        // ACC/BIM 360 synchronization route (See section 4)
    }
    else if (doc.IsWorkshared)
    {
        // Sync path to Local Server/NAS (SKILL 14)
    }
    else
    {
        // Standard local save (doc.Save())
    }
}
6. Agent Injection Instructions (Prompting Prompt)
When processing requests to open, save, or audit Revit models hosted on cloud servers, strictly apply these guidelines:
Prohibition of Handling Physical Routes for Cloud: It is strictly prohibited to use constructors that accept string (Windows routes) to access BIM 360 or ACC models. The agent SHOULD always generate the path using ModelPathUtils.ConvertCloudGUIDsToCloudPath().
Remote Open RAM Optimization: When generating algorithms to process cloud models unattended, ALWAYS inject a WorksetConfiguration object set to CloseAllWorksets into the OpenOptions, unless the user explicitly indicates that the algorithm requires reading 3D geometry or links that depend on open subprojects.
Relinquish Total Required: Any code that calls doc.SynchronizeWithCentral() in an automation context MUST instantiate a RelinquishOptions object with all its properties set to true (especially CheckedOutElements). Failure to inject this class will cause the script to leave residual locks on the production database.
Managing External APIs for GUIDs: Please note that the Revit API does not provide a native way to search for projects by name in BIM 360. If the user requests a script that "searches for project