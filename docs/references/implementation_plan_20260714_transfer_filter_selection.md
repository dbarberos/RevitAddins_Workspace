# Implementation Plan: Lógica de Filtrado de Selección de TransferFilter

Este plan define el diseño para implementar la lógica de búsqueda y filtrado de selección de la tarjeta "Filter" de **TransferPlus**, haciéndola idéntica a la funcionalidad de **FilterPlus**.

## Cambios Propuestos

### 1. [`TreeItemViewModel.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TreeItemViewModel.cs)
* Agregar la propiedad estática `IsBulkUpdating` para evitar disparar cientos de eventos de WPF simultáneamente durante operaciones por lotes.
* Modificar el setter de `IsChecked` para respetar `IsBulkUpdating`.
* Implementar los métodos auxiliares recursivos `SetCheckedState` y `RefreshState`.

### 2. [`TransferPlusViewModel.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs)
* Eliminar los métodos parciales automáticos `OnSearchFilterChanged`, `OnFilterUseOrChanged`, etc., para que no se filtre en tiempo real mientras el usuario escribe.
* Rediseñar `FilterTree` para realizar un filtrado por selección de los nodos que se muestran actualmente en `RootNodes` (en lugar de reconstruir todo el árbol).
* Implementar el método recursivo de coincidencia `FilterNode` para evaluar nombres, categorías, familias y tipos en función de las opciones `FilterOnlyNames` y `FilterUseRegex`.
* Actualizar `ClearFilter` para que no solo limpie las propiedades de texto, sino que además desmarque de forma masiva todos los elementos cargados en el explorador.

## Plan de Verificación

* **Compilación de Código**: Asegurar que compila exitosamente en .NET Framework 4.8 / .NET 8.
* **Prueba de Flujo de Trabajo en Revit**:
  1. Seleccionar modelo origen y cargar elementos.
  2. Buscar "Plano" y pulsar Apply (debe marcar planos de dibujo, etc.).
  3. Probar Use OR, Only by name y Use Regex.
  4. Pulsar Clear para desmarcar todo.
