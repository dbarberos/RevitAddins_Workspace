# Skill: Interoperability, Export and Connectivity with External APIs

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-013
* **Technical Area:** Data I/O / Cloud Connectivity / System Integration
* **API dependencies:** `Autodesk.Revit.DB.Export`, `System.Net.Http`, `System.Text.Json`
* **Design Patterns:** Singleton (for HTTP clients), Async/Await (I/O Isolation)
* **Operational Impact:** Critical. It turns Revit into a connected node within a broader digital ecosystem (e.g. corporate ERPs, cloud databases or OpenBIM flows).

---

## 2. Native Export (OpenBIM and CAD Flows)

Revit exposes its export engines via the overloaded `Document.Export()` method. The secret to an automated and rigorous export lies in correctly configuring the option classes (`DWGExportOptions`, `IFCExportOptions`), preventing the engine from using the default configuration of the user session.

### Example: Mass Export of Drawings to DWG


[See pattern implementation in: assets/DwgExportManager.cs]


---

## 3. Cloud Connectivity: Integration with REST APIs (e.g. Firebase)

The true value of a modern Add-in is its ability to synchronize data bidirectionally. When integrating web technologies (such as injecting model audit data into a NoSQL database like Firebase), the execution thread must be carefully managed to avoid freezing the Revit interface.

### Optimized Pattern: Secure and Asynchronous HTTP Client

Revit blocks its main thread. Network operations (I/O) are slow and must be delegated to a secondary thread using `async/await`.


[See pattern implementation in: assets/CloudSyncService.cs]


---

## 4. Matrix of Antipatterns vs Network Patterns

*Common Anti-Pattern (Interface Locking and Memory Leaks)*


[See pattern implementation in: assets/BlockingHttpClientAntiPattern.cs]


*Architecture Criticism Warning (Return to Revit):*
If the external API call (`GET`) retrieves information that **must modify the Revit model** (e.g. updating the "Status" parameter of 500 doors based on data downloaded from the cloud), you **CANNOT** apply the changes directly after the `await`. You must send the downloaded data to an `IExternalEventHandler` (Skill 11) so that Revit safely processes the database mutation in its next idle cycle.

---

## 5. Agent Injection Instructions (Prompting Prompt)

*When asked to generate code that connects the Revit API to external systems, files, or web databases, implement these guidelines:*

1. **Singleton for HttpClient:** Multiple instantiation of `System.Net.Http.HttpClient` is strictly prohibited. The agent must always declare it as a `private static readonly` field in the service class that manages the network.
2. **Pure Async (Network I/O):** Any method that sends or receives data over the network must be signed with `async Task` and use methods ending in `Async` (e.g. `PostAsync`, `GetAsync`). Never inject `.Result` or `.Wait()` in Revit commands.
3. **Dependency Isolation (JSON):** Use `System.Text.Json` for serialization. Avoid injecting heavy external libraries (such as Newtonsoft.Json or complex database SDKs) unless strictly necessary, as Revit is prone to "DLL Hell" (library version conflicts) if other Add-ins install different versions of the same dependency in the same environment.
4. **Decoupling Export Options:** When exporting IFC or DWG, never use empty constructors if you assume standard behavior. Always instantiate the corresponding `Options` class and explicitly inject the values ​​(IFC version, units, solid type) to ensure deterministic results no matter which user runs the automation.

```