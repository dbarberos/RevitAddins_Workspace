---
name: revit-api-resilience
description: Failure API (pop-up suppression), IUpdater (DMU), telemetry scrubbing, and native AsyncTaskDispatcher.
---

# Skill Manifest: Revit API Resilience & Operations (`revit-api-resilience`)

## 1. Skill Identity & Purpose
* **ID:** SKILL-RVT-RES
* **Domain:** Failure API (Pop-up Suppression), Dynamic Model Update (DMU), Telemetry, and Async Task Dispatching.
* **Objective:** Orchestrate the silent resolution of Revit warnings, automate self-auditing triggers (IUpdater), capture crash analytics without exposing IP, and safely route background UI threads back to the main Revit API context.

## 2. Core Execution Guardrails
When executing tasks within this domain, the agent MUST strictly enforce these programmatic constraints:
1. **Warning Suppression Limit:** The `IFailuresPreprocessor` MUST only resolve Warnings or explicitly known errors. The agent MUST NEVER blindly suppress `FailureSeverity.Error` or `FailureSeverity.DocumentCorruption`, as this will destroy the integrity of the BIM database.
2. **Updater Registration Context:** `IUpdater` implementations MUST be registered during `IExternalApplication.OnStartup()`. Furthermore, the agent must check `UpdaterRegistry.IsUpdaterRegistered()` before registering to avoid cross-loading crashes.
3. **Off-Thread API Access:** The agent MUST NOT call any Revit API method (e.g., `doc.GetElement()`) from inside a Task, BackgroundWorker, or WPF button click event. All API calls triggered by a UI must be wrapped in an `IExternalEventHandler` or queued in the `AsyncTaskDispatcher`.
4. **Telemetry Anonymization:** When capturing exceptions, the agent MUST sanitize file paths. "C:\Users\JohnDoe\Desktop\Model.rvt" must be scrubbed to prevent PII (Personally Identifiable Information) leaks in the cloud telemetry logs.

## 3. Reference Mapping (Theory & Ontologies)
When specific resilience architecture concepts are needed, locate the following files in the `./references/` directory:
* **Pop-up Suppression:** [40_FailureAPI_and_Preprocessors.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/references/40_FailureAPI_and_Preprocessors.md)
* **Real-time Triggers:** [41_DMU_and_IUpdater.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/references/41_DMU_and_IUpdater.md)
* **Async Event Routing:** [42_ExternalEvents_and_Idling.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/references/42_ExternalEvents_and_Idling.md)
* **Application Telemetry:** [43_Logging_and_CrashReporting.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/references/43_Logging_and_CrashReporting.md)
* **Debugging Modeless UI:** [debugging_modeless_wpf_thread_block_2026-07-07.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/references/debugging_modeless_wpf_thread_block_2026-07-07.md)

## 4. Asset Mapping (Code Blueprints)
Inject, adapt, or copy the exact implementations located in the `./assets/` directory:
* [WarningSwallower.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/assets/WarningSwallower.cs) -> Transaction option to silently delete overlapping elements or ignore dimension warnings during batch processing.
* [DynamicUpdater.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/assets/DynamicUpdater.cs) -> Trigger mechanism to instantly react when a user modifies a specific category (e.g., auto-numbering doors on placement).
* [TelemetryLogger.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/assets/TelemetryLogger.cs) -> Cloud-ready exception catcher that captures Revit builds, active memory, and sanitized stack traces.
* [AsyncTaskDispatcher.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/assets/AsyncTaskDispatcher.cs) -> Queue manager that funnels WPF background actions back to the main Revit thread safely.
* [ActionEventHandler.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/assets/ActionEventHandler.cs) -> Generic External Event handler used to safely marshal WPF ViewModel commands to the main Revit thread.
