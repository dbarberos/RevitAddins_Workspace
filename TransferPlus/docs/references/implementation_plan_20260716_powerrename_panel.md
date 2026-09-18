# Plan de Implementación: Panel Lateral PowerRename (Animación Slide-Out)

De acuerdo con tu especificación, implementaremos una **animación dual sincronizada** para que la ventana principal parezca extenderse para dar paso a la paleta, manteniendo el contenido actual intacto y sin deformaciones.

## Nueva Lógica de Funcionamiento (Desacoplamiento de Renombrado y Transferencia)

De acuerdo con la nueva solicitud, el panel lateral de "Transfer & Rename" actuará como un configurador en vivo y no como un ejecutor directo.

1. **Sincronización Dinámica con el Árbol (TreeView):**
   - El árbol de elementos (`TreeItemViewModel`) ya emite un `CheckedItemsChangedMessage` cada vez que se marca o desmarca un elemento.
   - Modificaremos el método `UpdateCheckedCount()` en el `TransferPlusViewModel` para que, además de actualizar el contador, sincronice en tiempo real la colección `RenamePreviewItems`.
   - Si se selecciona un nuevo elemento en el árbol, se añadirá a la lista de previsualización (y se le aplicará el formato/regex activo). Si se deselecciona, se eliminará de la lista.

2. **Cierre y Cancelación (Botón Cancel / ✕):**
   - Eliminaremos el botón "Transferir y Renombrar" del panel lateral.
   - El botón "Cancelar" (y el aspa de cerrar) ejecutarán `CloseRenamePanelCommand`.
   - Este comando vaciará los campos de búsqueda, vaciará la lista `RenamePreviewItems`, y cerrará el panel (`IsRenamePanelOpen = false`). De esta forma, el estado de renombramiento se descarta.

3. **Ejecución de la Transferencia (Botón "Transfer now"):**
   - El botón original "Transfer now" de la ventana principal (`TransferCommand`) será el único encargado de transferir.
   - Modificaremos `TransferCommand` para que compruebe si existe configuración de renombrado activa (es decir, si la lista `RenamePreviewItems` tiene elementos con nuevos nombres que difieren del original).
   - Si existe esta lista (por haber usado la paleta de rename y no haber cancelado), pasará este diccionario (`Dictionary<ElementId, string>`) al `TransferOrchestrator`. Si no existe o se pulsó cancelar, se transferirán con los nombres originales.

---

## Componentes y Estructura del Código

### 1. Elemento de Previsualización: [`RenamePreviewItem.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/RenamePreviewItem.cs)
- Se mantiene igual, representando a la fila en el DataGrid.

### 2. Lógica del ViewModel Principal: [`TransferPlusViewModel.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs) [MODIFY]
- **Sincronización:** Extender la respuesta al `CheckedItemsChangedMessage` para añadir a `RenamePreviewItems` los nuevos elementos de `checkedItems` que no estuvieran, y eliminar los que ya no estén chequeados. Llamar a `UpdateRenamePreviews()` tras la sincronización para aplicar textos.
- **Comandos:**
  - Eliminar `TransferAndRenameCommand`.
  - `CloseRenamePanelCommand`: Vaciar lista `RenamePreviewItems`, resetear `RenameSearchText` a `""`, y ocultar panel.
  - `TransferCommand`: Extraer el diccionario de nuevos nombres desde `RenamePreviewItems` (donde `IsSelected == true` y `NewName != OriginalName`) y pasárselo a `TransferOrchestrator`.

### 3. Orquestador de Transferencias: [`TransferOrchestrator.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/TransferOrchestrator.cs) [MODIFY]
- Extender `TransferElements` para aceptar `Dictionary<ElementId, string>? customNames = null` (ya planeado).

### 4. Interfaz WPF: [`TransferPlusView.xaml`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml) [MODIFY]
- Quitar el botón "Transferir y Renombrar" del Footer del panel lateral.
- Dejar únicamente el botón "Cancelar".

### 4. Interfaz WPF: [`TransferPlusView.xaml`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml) [MODIFY]
- Reestructurar el panel de la paleta lateral derecha para seguir la organización idéntica a Microsoft PowerRename.
- Se dividirá en dos filas (`Grid.RowDefinitions`):
  - **Fila Superior (Controles):** StackPanel con el input text "Find" (como placeholder), seguido de 3 checkboxes en inglés (`Use regular expressions`, `Match all occurrences`, `Match case`), luego otro input text "Changed by:" (como placeholder). Debajo, un bloque "Text format:" con los botones para `aa` (lowercase), `AA` (uppercase), `Aa` (Title Case), `Aa Aa` (Capitalize Each Word), un botón para numerar consecutivamente (ej. icono de lista numerada), y otro para string aleatorio (ej. icono de dado/aleatorio).
  - **Fila Inferior (Resultados):** Tarjeta visual (DataGrid) con dos columnas principales tituladas "Original" y "New Name", utilizando los estilos y colores limpios similares a PowerToys.
- Mantener los Storyboards para animar simultáneamente `Window.Width` y el `Width` del panel de la paleta.

### 5. Nuevas Propiedades ViewModel para Text Format
- Añadir un enum `TextFormatMode { None, Lowercase, Uppercase, TitleCase, CapitalizeEachWord }`.
- Añadir flags `bool EnumerateItems` y `bool RandomizeItems`.
- Actualizar el motor de reemplazo para que, después de aplicar el regex/reemplazo literal, se apliquen estas reglas de capitalización y se iteren los elementos añadiendo contadores o sufijos aleatorios en la lista generada.

---

## Verification Plan

### Manual Verification
- Marcar elementos en el explorador.
- Pulsar "Transfer & Rename..." y verificar que la ventana crece suavemente hacia la derecha revelando la paleta.
- Comprobar que el contenido del panel izquierdo original no se deforma ni se corta.
- Probar filtros, regex y exclusión de elementos en el DataGrid de previsualización.
- Pulsar "Transferir y Renombrar" para confirmar que se copian en el modelo destino con sus nuevos nombres y la paleta se colapsa.
