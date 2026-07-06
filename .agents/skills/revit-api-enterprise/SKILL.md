---
name: revit-api-enterprise
description: Interoperability, DevOps multi-versioning, Unit Testing/TDD, ACC, and APS Cloud.
---

# Skill Manifest: Revit API Enterprise & Cloud Ecosystem (`revit-api-enterprise`)

## 1. Skill Identity & Purpose
* **ID:** SKILL-RVT-ENT
* **Domain:** Cloud Execution (Design Automation), REST Interoperability, Multi-Versioning (CI/CD), and Unit Testing (QA).
* **Objective:** Orchestrate the integration of Revit Add-ins into enterprise IT ecosystems. Manage headless cloud executions, safe asynchronous web requests, and maintain cross-version compatibility through abstraction and preprocessor directives.

---

## 2. Core Execution Guardrails
When executing tasks within this domain, the agent MUST strictly enforce these programmatic constraints:
1. **Design Automation Isolation (Cloud):** Code designed for Autodesk Platform Services (APS) Design Automation MUST NOT reference `Autodesk.Revit.UI`. Any invocation of `TaskDialog` or Ribbon panels will instantly crash the headless cloud server.
2. **HTTP Async Offloading:** REST API calls (`HttpClient`) MUST NOT block the main Revit thread synchronously. The agent must handle web requests asynchronously and use `IExternalEventHandler` (from `revit-api-core`) if the response needs to modify the BIM model.
3. **Multi-Version Compilation:** The Revit API changes annually. The agent MUST use C# preprocessor directives (e.g., `#if REVIT2024_OR_GREATER`) when handling deprecated methods (like `Parameter.Definition.Name` vs `GetDataType()`).
4. **Testable Architecture (IoC):** Native Revit classes (`Document`, `Wall`) cannot be instantiated in Unit Tests. The agent MUST generate interface wrappers (`IRevitRepository`) to allow mocking with frameworks like Moq.

---

## 3. Reference Mapping (Theory & Ontologies)
When specific enterprise architecture concepts are needed, locate the following files in the references folder:

* **External Integrations:** [13_Interoperability_and_REST.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-enterprise/references/13_Interoperability_and_REST.md)
  * *Use cases:* HTTP GET/POST, JSON Serialization, and preventing Thread Starvation.
* **DevOps & Cross-Versioning:** [15_DevOps_and_MultiVersioning.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-enterprise/references/15_DevOps_and_MultiVersioning.md)
  * *Use cases:* MSBuild configurations, Post-Build events, and `#define` directives.
* **Headless Cloud Execution:** [16_DesignAutomation_Cloud.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-enterprise/references/16_DesignAutomation_Cloud.md)
  * *Use cases:* `DesignAutomationReadyEvent`, WorkItems, and handling cloud paths.
* **Quality Assurance (TDD - Consolidated):** [revit-addin-testing](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-testing/SKILL.md)
  * *Use cases:* xUnit setup, mocking Revit API, Dependency Injection, and testing strategy.
* **Cloud Models & ACC:** [29_CloudModelsAPI_and_ACC.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-enterprise/references/29_CloudModelsAPI_and_ACC.md)
  * *Use cases:* Accessing Autodesk Construction Cloud models, ModelPathUtils, and opening cloud workshared documents.

---

## 4. Asset Mapping (Code Blueprints)
Do not reinvent enterprise architecture. Inject, adapt, or copy the exact implementations located in the assets folder:

* [RestApiIntegrator.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-enterprise/assets/RestApiIntegrator.cs): Thread-safe HTTP client singleton for communicating with ERPs, PowerBI, or external databases.
* [VersionCompatibilityBridge.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-enterprise/assets/VersionCompatibilityBridge.cs): Utility class utilizing preprocessor directives to safely bridge API breaking changes across Revit years.
* [DesignAutomationHandler.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-enterprise/assets/DesignAutomationHandler.cs): Boilerplate entry point for APS Design Automation, replacing standard `IExternalCommand` UI hooks.
* [Skill13_Pattern_1.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-enterprise/assets/Skill13_Pattern_1.cs) to [Skill13_Pattern_3.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-enterprise/assets/Skill13_Pattern_3.cs): HTTP web request wrappers, JSON serializers, and asynchronous web call execution tasks.
* [UnitTestingWrappers.cs (Relocated)](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-testing/assets/UnitTestingWrappers.cs): Interfaces and wrapper proxies for isolating element database interactions during unit tests.

---

## 5. Agent Processing Instructions (RAG & Chain-of-Thought)
1. **Analyze Prompt:** Identify if the user needs external communication (HTTP), cross-version compatibility (macros), or cloud execution (APS).
2. **Consult Reference:** Review the matching domain in the references folder to ensure architectural constraints (like no UI in the cloud) are respected.
3. **Consume Asset:** Open the target `.cs` asset from the assets folder. Use its robust error handling and interface definitions.
4. **Output Format:** Provide the optimized solution. If writing Cloud code, explicitly comment out or remove any `Autodesk.Revit.UI` dependencies.
