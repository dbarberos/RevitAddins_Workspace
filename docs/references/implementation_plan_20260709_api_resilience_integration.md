# Plan de Implementación: Integración de Revit API Resilience (`revit-api-resilience`)

Este plan detalla las acciones necesarias para asimilar e integrar los nuevos conocimientos aportados en la carpeta `docs\revit-api-golden-assets-resilence` hacia el repositorio global de habilidades del agente (`.agents/skills/revit-api-resilience`).

## Objetivos Clave
Dotar a los Add-ins generados de una calidad y estabilidad de grado comercial. Para ello, el agente incorporará patrones de diseño robustos contra fallos:
1.  **Manejo Silencioso de Errores (Warning Swallower)**: Para suprimir advertencias durante ejecuciones por lotes sin corromper la base de datos.
2.  **Actualización Dinámica del Modelo (DMU - Dynamic Updater)**: Para disparar lógicas automáticas en tiempo real en respuesta a las acciones del usuario.
3.  **Telemetría y Registro de Fallos (Telemetry Logger)**: Para capturar trazas de errores higienizadas sin exponer rutas locales (PII).
4.  **Enrutamiento Asíncrono de UI (Async Task Dispatcher)**: Para canalizar peticiones realizadas desde interfaces modeless (WPF) y ejecutarlas en el hilo de la API de Revit de forma segura a través de `IExternalEventHandler`.

## Open Questions
> [!NOTE]
> Actualmente no se han proporcionado los archivos de texto (guías) para la carpeta `references` asociados a estos archivos (ej. `40_FailureAPI_and_Preprocessors.md`, `41_DMU_and_IUpdater.md`, etc.).
> ¿Deseas que genere estos documentos de referencia aplicando mi conocimiento experto sobre la API de Revit, o vas a proporcionar tú esos archivos antes de que aplique este plan?

## Cambios Propuestos

### 1. Habilidad de Resiliencia (`revit-api-resilience`)

#### [NEW] [SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/SKILL.md)
* Archivo índice configurado con las reglas estrictas de telemetría y supresión de fallos definidas en `docs/revit-api-golden-assets-resilence/SKILL.md`.

#### [NEW] [Assets de revit-api-resilience]
Moveremos los siguientes archivos a `.agents/skills/revit-api-resilience/assets/`:
* [AsyncTaskDispatcher.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/assets/AsyncTaskDispatcher.cs)
* [DynamicUpdater.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/assets/DynamicUpdater.cs)
* [TelemetryLogger.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/assets/TelemetryLogger.cs)
* [WarningSwallower.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-resilience/assets/WarningSwallower.cs)

#### [NEW] [Referencias de revit-api-resilience]
Se crearán (o copiarán) los siguientes manuales en `.agents/skills/revit-api-resilience/references/`:
* `40_FailureAPI_and_Preprocessors.md`: Sobre cómo y cuándo suprimir warnings sin afectar a la integridad de la base de datos de Revit (`FailureSeverity.Error`).
* `41_DMU_and_IUpdater.md`: Reglas sobre la inscripción del `IUpdater` en el `OnStartup` de la aplicación.
* `42_ExternalEvents_and_Idling.md`: La arquitectura interna de `IExternalEventHandler` y su uso en WPF modeless.
* `43_Logging_and_CrashReporting.md`: Higienización de trazas de error, eliminación de rutas locales.

---

### 2. Registro e Instrucciones Globales del Agente

#### [MODIFY] [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md)
* **Tabla de Skills (Sección 6)**: Añadir `revit-api-resilience` como dominio de control de errores y encolado asíncrono.
* **Planning Gate (Sección 6.1)**: Actualizar/Añadir reglas mandatorias:
  1. *Telemetry & Error Handling (revit-api-resilience)*: Exigir la anonimización y limpieza (scrubbing) de los local paths en el registro de errores, y prohibir la supresión ciega de `FailureSeverity.DocumentCorruption`.
  2. *WPF Async Dispatching (revit-api-resilience)*: Toda acción generada en hilos background desde un ViewModel (WPF) que modifique el documento Revit debe ser encolada a través del `AsyncTaskDispatcher`.

## Plan de Verificación

1. **Linter**: Comprobar que los archivos `.cs` trasladados a `assets/` se pueden referenciar y no tienen dependencias perdidas.
2. **Validación del Documento**: Comprobar que el yaml en `SKILL.md` es válido.
3. **Limpieza**: Eliminar la carpeta temporal `docs\revit-api-golden-assets-resilence` cuando finalice el proceso de integración.
