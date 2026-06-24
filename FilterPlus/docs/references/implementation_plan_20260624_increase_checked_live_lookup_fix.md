# Goal Description

Implementar el patrón de búsqueda directa en el modelo (Live Lookup) para el método `ApplyIncreaseChecked` del `SelectionFilterViewModel.cs`.
Al leer los artefactos almacenados (como `walkthrough_20260622_increase_checked_purge_feature.md` y `debugging_increase_checked_apply_not_firing_2026-06-22.md`), queda evidenciado que el problema de la UI "congelada" o inactiva en la rama `main` ocurre porque el proceso asume que todos los elementos relacionados (por ejemplo, aquellos de la misma categoría o nivel) ya existen en la colección pre-cargada `_activeElements`.

Para solucionar esto, inyectaremos cualquier elemento encontrado por las condiciones de "Increase Checked" que falte en el árbol actual, haciendo consultas "en vivo" a Revit mediante `doc.GetElement(id)`. Esto restaurará la funcionalidad completa de "Increase Checked" tal como operaba en la rama `AddSelection` (fase previa).

## User Review Required

> [!IMPORTANT]
> Se va a reestructurar la fase de inyección de `ApplyIncreaseChecked` para que siempre busque los elementos en vivo (`doc.GetElement(id)`) cuando no se encuentren en la vista actual del árbol (`_activeElements`). Esto evitará que la colección rechace IDs faltantes y causará que el árbol se reconstruya visualmente.

## Proposed Changes

### ViewModel Layer

#### [MODIFY] [SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)
- Se actualizará el método `ApplyIncreaseChecked()` para recolectar primero los `ElementId` de los elementos chequeados y luego compararlos directamente contra Revit (`FilteredElementCollector`).
- Se añadirá el bloque `--- INJECTION PHASE ---` que itera sobre los IDs objetivo. Si un ID no existe en `_activeElements`, se obtendrá el elemento vía `doc.GetElement()`, se mapeará a `ElementModel`, y se inyectará dinámicamente.
- Se asegurará de que `_persistentCheckedIds` se actualice con la selección unificada antes de invocar `BuildTree()` en el hilo principal de Revit.

## Verification Plan

### Automated Tests
- Compilar el proyecto usando `dotnet build -c Debug.R24` para verificar que no haya problemas de referencia por las actualizaciones en el ViewModel.

### Manual Verification
- Iniciar Revit y cargar FilterPlus.
- En el árbol, seleccionar un elemento de una categoría específica (ej. "Muros").
- Ir al panel "Increase Checked", marcar la opción "Same Category" y presionar "Apply".
- Validar visualmente que el sistema procesa sin congelarse, que el mensaje de estado se actualiza, y que se añaden y seleccionan los elementos adicionales en el árbol.
