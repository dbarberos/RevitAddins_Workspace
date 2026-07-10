# Plan de Implementación: Botón de Restauración de Selección de Revit en FilterPlus

Este plan describe el diseño y la implementación del botón de restauración de selección en el explorador de elementos de **FilterPlus**. Esta funcionalidad permitirá al usuario sincronizar instantáneamente el estado del explorador con los elementos actualmente seleccionados en el lienzo de Revit.

---

## 1. Diseño de la Interfaz (UI/UX)

El botón se integrará en el cabecero de la columna izquierda (explorador de elementos) de la siguiente manera:
* **Ubicación**: En la fila del título "Elements", a la derecha de los botones de expandir y contraer árbol.
* **Aspecto**: Un icono de tipo "Restore/Reset" (flecha circular) con el estilo de la rueda dentada (Configuration):
  * Altura de fila sin alterar (el botón tendrá dimensiones de 20x20 px para emparejarse con expandir/contraer).
  * Color gris neutro (`#777`) que se oscurece (`#333`) y cambia su fondo (`#eeeeee`) con hover.
  * Cuando esté deshabilitado (`IsEnabled="False"`), su opacidad se reducirá a `0.3` para dar un aspecto atenuado limpio.

---

## 2. Comportamiento y Lógica de Negocio

El botón operará bajo las siguientes reglas lógicas:

1. **Acción de Clic (`RestoreRevitSelectionCommand`)**:
   * Se ejecuta de forma asíncrona mediante el hilo de Revit (`ActionEventHandler`).
   * Consulta la selección actual del viewport (`_uiDoc.Selection.GetElementIds()`).
   * **Inclusión Automática de Modelos Vinculados**: Si los elementos seleccionados en Revit pertenecen a un modelo vinculado (o si la selección incluye directamente la instancia del vínculo `RevitLinkInstance`), y dicho modelo vinculado ha sido deseleccionado en la lista de modelos de filtrado (`SelectedModels`), se comprobará y se volverá a incluir automáticamente el modelo vinculado dentro de `SelectedModels`. Tras esto, se actualizará el texto de modelos seleccionados y se llamará a `LoadScopesAndHandleCache` para actualizar los elementos en memoria.
   * Limpia las selecciones actuales del explorador y asigna exactamente las nuevas claves obtenidas a `_persistentCheckedIds`.
   * Vuelve a consultar y pre-cargar en memoria la lista de elementos correspondientes a la selección activa (`GetAvailableElements(SelectionScope.CurrentSelection, ...)`).
   * Cambia la propiedad del alcance de la selección (`CurrentScope`) al valor `SelectionScope.CurrentSelection`.
   * Reconstruye el árbol de visualización (`BuildTree()`), el cual marcará de manera automática los checkboxes correspondientes.
   * Marca el estado de selección modificada (`IsSelectionDirty`) como `false` y deshabilita el propio botón de restauración (ya que ahora coinciden).

2. **Detección de Cambios y Habilitado/Deshabilitado (`CanRestoreRevitSelection`)**:
   * El botón estará **deshabilitado** cuando el conjunto de elementos marcados en el árbol coincida exactamente con la selección real de Revit.
   * Estará **habilitado** en cuanto cambie la selección (bien porque el usuario marque/desmarque elementos en el árbol, o porque seleccione otra cosa en la vista de Revit y active la ventana).
   * **Sincronización Inteligente**:
     * Para evitar llamadas costosas en bucles (polling), se evaluará la coincidencia de selección:
       1. Cada vez que cambie una casilla del árbol (`OnTreeSelectionChanged()`).
       2. Cada vez que el usuario regrese y enfoque la ventana del add-in (evento `Activated` de la ventana WPF).

---

## 3. Cambios Propuestos

### [FilterPlus](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus)

#### [MODIFY] [SelectionFilterView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml)
* Reestructurar `Grid.ColumnDefinitions` del cabecero del explorador de elementos para añadir una columna para el botón Restore.
* Agregar el botón Restore con un diseño de control/icono de restauración y enlazar su propiedad `Command` a `RestoreRevitSelectionCommand` e `IsEnabled` a `CanRestoreRevitSelection`.

#### [MODIFY] [SelectionFilterView.xaml.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml.cs)
* Suscribirse al evento `this.Activated` en el constructor para disparar `viewModel.UpdateCanRestore()` asíncronamente cuando la ventana reciba el foco de nuevo.

#### [MODIFY] [SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)
* Declarar la propiedad observable `CanRestoreRevitSelection` (booleana).
* Añadir el comando `RestoreRevitSelectionCommand` que realiza la lógica descrita en el apartado 2 (incluyendo la auto-recuperación de modelos vinculados si hiciera falta).
* Añadir el método asíncrono `UpdateCanRestore()` que compara las casillas marcadas con la selección física de Revit usando `SetEquals` y actualiza el estado en el hilo de UI.
* Añadir una llamada a `UpdateCanRestore()` dentro de `OnTreeSelectionChanged()`.

---

## 4. Plan de Verificación

### Pruebas Manuales
1. **Verificación de UI**: Comprobar que el icono de restaurar aparece perfectamente alineado en el grupo "Elements" a la derecha de expandir/contraer. Verificar que cambia a tono oscuro al pasar el cursor (hover).
2. **Sincronización inicial**: Abrir el add-in con elementos previamente seleccionados en Revit. El explorador debe cargarlos con check y el botón Restore debe estar deshabilitado (ya que coinciden).
3. **Casos de activación**:
   * Desmarcar un elemento en el árbol. El botón Restore debe habilitarse. Pulsarlo debe revertir el cambio (marcarlo de nuevo) y deshabilitar el botón.
   * Seleccionar otros elementos en el viewport de Revit y hacer clic de vuelta en la ventana del add-in. El botón debe habilitarse. Al pulsarlo, el árbol debe actualizarse con la nueva selección de Revit y el botón se deshabilitará.
4. **Auto-inclusión de Vínculos**:
   * Desmarcar el modelo vinculado en la ventana "Model Selection" de manera que no esté en el filtrado.
   * Tener elementos del modelo vinculado seleccionados en Revit.
   * Hacer clic en "Restore": verificar que el modelo vinculado es añadido automáticamente a `SelectedModels`, se vuelven a calcular los scopes e incluye dichos elementos en el explorador con check.
