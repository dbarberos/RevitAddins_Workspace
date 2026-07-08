# Plan de Actuación: Corrección de Bloqueo y Registro de Logs en Saved Selections

Resolver el bloqueo/cuelgue al guardar selecciones (especialmente cuando están vacías) y añadir logs detallados de todas las interacciones de apertura, pulsado de botones y operaciones de fondo.

## Puerta de Planificación Core (Core Planning Gate)

> [!IMPORTANT]
> **Análisis de Directrices Técnicas (Skills):**
> 1. **Threading & Modeless WPF** ([revit-api-core](file:///.agents/skills/revit-api-core/SKILL.md) / [revit-async-operations](file:///.agents/skills/revit-async-operations/SKILL.md)): El cuelgue se debe a un **Deadlock de Hilos**. El hilo de Revit (ejecutando el External Event) llama a `Dispatcher.Invoke` de forma síncrona para actualizar la interfaz. Dentro de ese invoke síncrono, se ejecuta `LoadSelectionsFromDocument()` que intenta leer de Revit (`doc.ProjectInformation` y `projInfo.GetEntity`) desde el hilo de la UI. Al estar el hilo de Revit ocupado esperando al Dispatcher y el Dispatcher bloqueado esperando el acceso al hilo de Revit (lock de API), el add-in se congela.
>    * **Solución:** Eliminar los `Dispatcher.Invoke` síncronos de fondo y sustituirlos por `Dispatcher.BeginInvoke` asíncronos. Realizar todas las lecturas y escrituras de Revit estrictamente en el hilo de Revit dentro del External Event, y enviar únicamente la colección final de datos a la interfaz de usuario de forma asíncrona.
> 2. **Transaction Safety** ([revit-transactions](file:///.agents/skills/revit-transactions/SKILL.md)): Las transacciones de guardado se mantienen dentro del bloque `using (Transaction t = ...)` en el hilo de Revit.
> 3. **Hardening de Seguridad** ([security-engineer](file:///.agents/skills/security-engineer/SKILL.md)): Las excepciones capturadas se registrarán de forma segura usando `LoggerService.LogError` sin interrumpir el flujo.

---

## Proposed Changes

### 1. Modelos y Servicios de Datos

#### [MODIFY] [SavedSelectionsService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Services/SavedSelectionsService.cs)
- Añadir logs detallados (`LoggerService.LogInfo`) al inicio y finalización exitosa de `LoadSavedSelections` y `SaveSavedSelections`, incluyendo el tamaño de la cadena JSON y la cantidad de elementos procesados.

### 2. Capa de Presentación (ViewModels)

#### [MODIFY] [SaveSelectionViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SaveSelectionViewModel.cs)
- Añadir logs en el constructor indicando que se ha inicializado el diálogo de guardado con la cantidad de selecciones existentes.
- Añadir logs detallados en los comandos de acción:
  - `SaveNew`: Loguear el intento de guardar una nueva selección con su respectivo nombre.
  - `Overwrite`: Loguear la selección existente que se va a sobrescribir.
  - `Cancel`: Loguear la cancelación de la operación.

#### [MODIFY] [SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)
- **Modificar `SaveCurrentSelection`**:
  - Establecer `IsBusy = true` y `StatusMessage = "Guardando selección..."` en el hilo de la UI al iniciar la operación.
  - Ejecutar la serialización y la llamada a `SavedSelectionsService.SaveSavedSelections` en el hilo de Revit.
  - Cargar las selecciones actualizadas (`SavedSelectionsService.LoadSavedSelections`) en el hilo de Revit inmediatamente después de guardar.
  - Actualizar la colección de UI (`SavedSelections`), seleccionar el elemento recién guardado y restablecer `IsBusy = false` usando `Dispatcher.BeginInvoke` (asíncrono).
  - Asegurar el restablecimiento de `IsBusy = false` en bloques `finally` despachados a la UI en caso de error.
- **Modificar `LoadSelectionsFromDocument`**:
  - Cambiar el actual `Dispatcher.Invoke` síncrono por `Dispatcher.BeginInvoke` asíncrono.
  - Asegurar que la consulta a Revit se realiza en el hilo adecuado (se mantendrá seguro en la inicialización del constructor).

---

## Verification Plan

### Manual Verification
1. Compilar y ejecutar el Add-in en Revit.
2. Comprobar que al abrir el diálogo de guardar se registren los logs correspondientes en `debug_log.txt`.
3. Intentar guardar un grupo vacío de elementos ingresando un nombre y haciendo clic en "Save New".
4. Confirmar que el Add-in completa la operación de forma segura sin congelarse, actualiza la UI y registra cada paso en el archivo de log.
