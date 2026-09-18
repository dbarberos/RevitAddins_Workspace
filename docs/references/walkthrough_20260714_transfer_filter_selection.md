# Walkthrough: Lógica de Filtrado de Selección de TransferFilter

Hemos completado la implementación de la lógica de búsqueda y filtrado de selección para la tarjeta "Filter" de **TransferPlus** en la rama `TransferFilter`.

---

## Cambios Realizados

### 1. Optimizaciones en `TreeItemViewModel.cs`
* **Control de Rendimiento Masivo (`IsBulkUpdating`)**: Agregamos una bandera booleana estática. Al estar activa, evita el envío masivo de mensajes `CheckedItemsChangedMessage` a través del Messenger en cada cambio individual de estado de checkbox, impidiendo bloqueos de interfaz gráfica.
* **Propagación en Lote (`SetCheckedState` y `RefreshState`)**: Introdujimos métodos recursivos para establecer estados de check masivamente de arriba a abajo, y recalcular estados de padres ("indeterminado" / "marcado" / "desmarcado") de abajo a arriba de forma eficiente.

### 2. Implementación de Búsqueda de Selección en `TransferPlusViewModel.cs`
* **Trigger por Botón**: Eliminamos la ejecución en tiempo real (`OnPropertyChanged`). El filtrado ahora solo se ejecuta cuando el usuario presiona el botón **Apply**.
* **Búsqueda sobre Elementos Visibles**: El filtrado recorre `RootNodes` (los elementos cargados en ese instante en la pantalla) y altera su estado de selección en lugar de regenerar y recortar el árbol físico.
* **Lógica Boolean / Regex**:
  * **Use OR = False**: Desmarca primero todo el árbol y luego marca únicamente las coincidencias de la nueva búsqueda.
  * **Use OR = True**: Mantiene las selecciones previas y marca las nuevas coincidencias adicionales.
  * **Only by name**: Limita la coincidencia al nombre del nodo (`node.Name`). Si está inactivo, busca también coincidencia en la categoría, familia y tipo del elemento subyacente.
  * **Use Regex**: Compila y aplica expresiones regulares en modo `IgnoreCase`.
* **Acción de Limpieza**: Actualizamos el comando `ClearFilter` para restaurar los valores por defecto de la tarjeta y desmarcar por completo todos los elementos del explorador en lote.

---

## Verificación

* **Compilación**: El proyecto compila correctamente sin errores (0 errores).
  ```powershell
  dotnet build -c Debug.R24
  ```
