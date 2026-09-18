# Walkthrough - ResoluciÃ³n de Errores en Transferencia de Planos y Vistas en Modelos VacÃos

**Fecha:** 2026-07-22  
**Add-in:** TransferPlus  
**Componente:** `TransferOrchestrator.cs`  

Se ha diagnosticado y resuelto el error `Referencia a objeto no establecida como instancia de un objeto` al transferir planos con vistas a modelos vacÃos, y se ha documentado la matriz de transferencia de planos y vistas.

## Cambios Realizados

### 1. UbicaciÃ³n de Viewports Inmune a Modelos VacÃos (`Viewport.GetBoxCenter()`)
- **[TransferOrchestrator.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/TransferOrchestrator.cs):**
  - **Problema en Modelo VacÃo**: En un modelo destino vacÃo (sin elementos 3D ni vista generada), `srcViewport.get_BoundingBox(sourceSheet)` o `targetViewport.get_BoundingBox(targetSheet)` devolvÃa `null`. El cÃ¡lculo `(boundingBoxXYZ.Max + boundingBoxXYZ.Min) / 2.0` fallaba con `NullReferenceException` (`Referencia a objeto no establecida como instancia de un objeto`), abortando la transferencia de la vista.
  - **SoluciÃ³n**: Se reemplazÃ³ la llamada a `get_BoundingBox` por la propiedad nativa del API de Revit `srcViewport.GetBoxCenter()` y `targetViewport.SetBoxCenter(center)`. De este modo, la posiciÃ³n del viewport en la hoja se calcula y asigna directamente sin depender de los contornos geomÃ©tricos 3D de la vista.

### 2. ProtecciÃ³n de Filtros en Vistas de Tablas (`ViewSchedule`)
- **[TransferOrchestrator.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/TransferOrchestrator.cs):**
  - **Problema**: Las vistas de tablas (`ViewSchedule`) no soportan filtros de vista ni modificaciones de visibilidad de categorÃas. Al invocar `vistaorigen.GetFilters()`, Revit lanzaba una excepciÃ³n `The view type does not support View Filters.`
  - **SoluciÃ³n**: Se agregÃ³ una comprobaciÃ³n preventiva al inicio de `CopyFilters` y `CopyViewGraphicsAndOverrides`:
    ```csharp
    if (vistaorigen is ViewSchedule vs && vs.IsTitleblockRevisionSchedule) return;
    if (vistaorigen is ViewSchedule) return;
    if (!vistaorigen.AreGraphicsOverridesAllowed()) return;
    ```

### 3. Matriz de LÃ³gica de Transferencia y DocumentaciÃ³n
- Se elaborÃ³ el documento `implementation_plan_20260722_empty_model_viewport_transfer_logic.md` con el diagrama de flujo y la tabla detallada de comportamiento para cada combinaciÃ³n de las tarjetas **"On Duplicates"** y **"On Views"**.

## VerificaciÃ³n
- **CompilaciÃ³n:** El cÃ³digo C# compila con **0 Errores** para `.NET Framework 4.8` (`Debug.R24`).
