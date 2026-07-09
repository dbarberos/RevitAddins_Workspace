# Walkthrough: Integración de la Habilidad de Resiliencia (`revit-api-resilience`)

Hemos estructurado e integrado con éxito el conocimiento de grado comercial sobre resiliencia en Revit API (`docs\revit-api-golden-assets-resilence`) dentro del repositorio global de habilidades del agente en `.agents/skills/revit-api-resilience/`.

## Resumen de Cambios

### 1. Creación e Integración de `revit-api-resilience`
Hemos creado el skill [revit-api-resilience](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/SKILL.md) para unificar la supresión de popups, triggers en tiempo real (DMU), telemetría segura y encolamiento nativo de tareas asíncronas.

*   **Assets de C# Consolidados**:
    *   [WarningSwallower.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/assets/WarningSwallower.cs): Manejador de `IFailuresPreprocessor` para suprimir advertencias modal en procesos por lotes.
    *   [DynamicUpdater.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/assets/DynamicUpdater.cs): Patrón base para `IUpdater` (DMU) para responder a eventos síncronos dentro de transacciones activas.
    *   [TelemetryLogger.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/assets/TelemetryLogger.cs): Logger estático que aplica Regex para enmascarar rutas locales de usuario (`C:\Users\[REDACTED]\...`) cumpliendo políticas de PII.
    *   [AsyncTaskDispatcher.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/assets/AsyncTaskDispatcher.cs): Despachador de cola basado en `ConcurrentQueue` e `IExternalEventHandler` para evitar InvalidOperationExceptions en modeless UI.
    *   [ActionEventHandler.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/assets/ActionEventHandler.cs): Trasladado desde `revit-api-core`, con namespace unificado y adaptado para delegar errores a `TelemetryLogger`.

*   **Guías de Referencia**:
    *   [40_FailureAPI_and_Preprocessors.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/references/40_FailureAPI_and_Preprocessors.md): Teoría sobre la supresión segura de diálogos de Revit.
    *   [41_DMU_and_IUpdater.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/references/41_DMU_and_IUpdater.md): Manual completo de DMU (IUpdater), prevenciones contra bucles infinitos y desuscripción obligatoria. Fusionado con los datos antiguos de `revit-api-core`.
    *   [42_ExternalEvents_and_Idling.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/references/42_ExternalEvents_and_Idling.md): Explicación de la asincronía en Revit API, la regla de hilo único y el patrón `IExternalEventHandler`. Fusionado con el antiguo `11_WPF_and_Async_Events.md`.
    *   [43_Logging_and_CrashReporting.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/references/43_Logging_and_CrashReporting.md): Teoría sobre observabilidad corporativa y anonimización de logs.
    *   [debugging_modeless_wpf_thread_block_2026-07-07.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/references/debugging_modeless_wpf_thread_block_2026-07-07.md): Caso real e instrucciones de depuración para bloqueos causados por el uso directo de Revit API en hilos modeless WPF. Trasladado desde `revit-api-core`.

### 2. Control de Redundancias y Limpieza
Para prevenir conocimiento duplicado en el agente que pudiese generar confusión:
*   Eliminamos `10_IUpdater_and_Events.md`, `11_WPF_and_Async_Events.md` y `debugging_modeless_wpf_thread_block_2026-07-07.md` de `revit-api-core/references/`.
*   Eliminamos `ActionEventHandler.cs` y `ExternalEventBridge.cs` (este último redundante con `AsyncTaskDispatcher.cs`) de `revit-api-core/assets/`.
*   Actualizamos el índice [revit-api-core/SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/SKILL.md) para quitar referencias anteriores y redirigir formalmente a `revit-api-resilience`.
*   Eliminamos la carpeta temporal `docs\revit-api-golden-assets-resilence`.

### 3. Modificaciones en el Planning Gate Global
*   Actualizamos [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md) añadiendo la habilidad `revit-api-resilience` al listado (Sección 6).
*   Inyectamos las siguientes reglas estrictas en el Planning Gate de `AGENTS.md` (Sección 6.1):
    1.  **Threading & Modeless UI**: Modificar documentos o iniciar transacciones desde ViewModels debe hacerse con `AsyncTaskDispatcher` o `IExternalEventHandler`.
    2.  **Failure Handling & Telemetry**: Empleo de `WarningSwallower` para suprimir advertencias menores, prohibición de suprimir `DocumentCorruption`, y sanitización obligatoria de rutas locales con PII usando `TelemetryLogger`.
    3.  **Dynamic Model Update (DMU)**: Registro exclusivo de `IUpdater` en `OnStartup`, validación previa a través de `IsUpdaterRegistered`, prevención de loops infinitos y desregistro obligatorio en `OnShutdown`.
