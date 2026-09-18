# Implementación de "On Duplicates" (Duplicidad de Tipos)

El siguiente paso lógico en el desarrollo del motor de transferencia de `TransferPlus` es gestionar qué ocurre cuando se intentan copiar elementos que contienen Tipos (Types) o Familias que ya existen en el documento de destino.

Actualmente, la UI tiene tres opciones en la tarjeta "On Duplicates:":
- **Ok** (Sobreescribir/Aceptar)
- **Abort** (Cancelar transferencia)
- **Ask User** (Preguntar al usuario)

## Limitación técnica de la API de Revit (Importante)

> [!WARNING]
> La API de Revit para copiar elementos (`ElementTransformUtils.CopyElements`) y su controlador de duplicados (`IDuplicateTypeNamesHandler`) **no permite sobreescribir un tipo existente** directamente durante la operación de pegado.
> El enumerador `DuplicateTypeAction` solo tiene dos valores posibles:
> 1. `UseDestinationTypes`: Mantiene el tipo que ya existe en el destino (no lo sobreescribe, pero permite que los elementos instanciados se peguen usando el tipo existente).
> 2. `Abort`: Cancela completamente la operación de pegado.

Por lo tanto, la opción **"Ok"** en la interfaz se traducirá internamente como `UseDestinationTypes` (mantener el tipo del destino para que la transferencia no falle), y **"Abort"** cancelará el proceso.

## Proposed Changes

### 1. `TransferOrchestrator.cs`

Vamos a implementar la lógica para que la opción **"Ask User"** despliegue un `TaskDialog` nativo cuando Revit detecte tipos duplicados.

#### [MODIFY] `TransferOrchestrator.cs`
- Crearemos la clase `CustomCopyHandlerAsk : IDuplicateTypeNamesHandler`.
- Dentro de su método `OnDuplicateTypeNamesFound`, mostraremos un `TaskDialog` indicando: *"Se han encontrado tipos duplicados en el destino. ¿Deseas usar los tipos existentes en el destino o abortar la transferencia?"* con botones `Yes` (UseDestinationTypes) y `No` (Abort).
- Modificaremos la asignación de `CopyPasteOptions` (líneas 148-150) para que evalúe correctamente las 3 propiedades del objeto `config`:
  ```csharp
  if (config.cf_rbAsk)
      options.SetDuplicateTypeNamesHandler(new CustomCopyHandlerAsk());
  else if (config.cf_rbAbort) // Asumiendo que cambiaremos la lógica de _config
      options.SetDuplicateTypeNamesHandler(new CustomCopyHandlerAbort());
  else
      options.SetDuplicateTypeNamesHandler(new CustomCopyHandlerOk());
  ```

### 2. `Configuraciones.cs` y `TransferPlusViewModel.cs`

Actualmente en el código, el `TransferViewModel` mapea las opciones a `_config.cf_rbOverride`, `_config.cf_rbCancel`, y `_config.cf_rbAsk`.

#### [MODIFY] `TransferPlusViewModel.cs` y `Configuraciones.cs`
- Revisaremos que la sincronización de estas propiedades fluya correctamente hacia el `TransferOrchestrator`.
- Posiblemente renombraremos `cf_rbOverride` a `cf_rbUseDestination` para que semánticamente tenga más sentido con lo que hace la API de Revit, o actualizaremos la etiqueta "Ok" de la UI a "Use Destination" para no crear falsas expectativas en el usuario (ya que no se "sobreescribe" el tipo).

## Open Questions

> [!IMPORTANT]
> 1. **Nombres en la Interfaz:** Sabiendo que "Ok" no sobreescribe el tipo existente en el destino sino que usa el del destino, ¿prefieres cambiar el texto del RadioButton en la interfaz de "Ok" a "Use Existing" / "Usar Existente"?
> 2. **Comportamiento "Ask User":** ¿Estás de acuerdo con mostrar un `TaskDialog` interrumpiendo el proceso si se selecciona "Ask User" y se encuentran duplicados, para que el usuario decida en tiempo real si abortar o continuar usando los existentes?

Espero tu aprobación o comentarios sobre estos puntos para proceder a inyectar este código.
