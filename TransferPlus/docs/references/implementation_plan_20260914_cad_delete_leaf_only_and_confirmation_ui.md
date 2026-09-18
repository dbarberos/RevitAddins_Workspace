# Plan de Implementación: Eliminación Exclusiva de Elementos Hoja en CAD Mode y Ventana de Confirmación

**Fecha:** 2026-09-14  
**Componente:** TransferPlus  
**Autor:** DBDev_dbarberos (DBDev Solutions)  
**Entorno:** Autodesk Revit 2024–2027 (.NET Framework 4.8 / .NET 8)

---

## 🎯 Objetivos y Requisitos

1. **Eliminación Exclusiva de Elementos Hoja (Lowest-level Elements Only)**:
   - El botón/icono de borrado en la tarjeta *"Select Details/CAD:"* debe eliminar **únicamente los elementos hoja seleccionados o marcados** (vínculos CAD, importaciones DWG, componentes de detalle, grupos de detalle).
   - **Prohibición de eliminación de contenedores padre:** Ningún plano (`ViewSheet`) ni vista contenedora (`View`) será eliminado jamás por esta acción.
   - De esta manera, el plano o vista creado se conserva íntegro en el Project Browser de Revit para ser reutilizado con nuevos elementos, dejando la decisión de eliminar planos o vistas al propio usuario de forma manual.

2. **Resolución Flexible de Selección**:
   - Si existen casillas de verificación marcadas en elementos hoja del árbol, se eliminarán esos elementos hoja marcados.
   - Si no hay casillas marcadas pero se ha seleccionado un elemento individual en la tarjeta (`SelectedCadDetail`), el botón actuará sobre ese elemento individual.

3. **Ventana Modal de Confirmación Estilizada (`ConfirmCadDeleteWindow.xaml`)**:
   - Ventana con el diseño visual nativo de TransferPlus (icono Pack URI, fuentes Segoe UI, cabecera con icono de advertencia en rojo).
   - Muestra un árbol jerárquico siguiendo la misma nomenclatura del explorador:
     - `Plano: [Número - Nombre]` $\rightarrow$ `[Preserved (Sheet)]`
       - `Vista: [Nombre de la Vista]` $\rightarrow$ `[Preserved (View)]`
         - `Elemento: [Nombre del DWG / Detalle]` $\rightarrow$ `[To be deleted]` (en rojo, con ID de Revit).
   - Resumen inferior: *"Total: X element(s) to delete. Parent Sheets and Views will be preserved."*
   - Botones de acción: `Cancel` y `Delete Elements` (rojo).

---

## 🛠️ Cambios Realizados

1. **`TransferPlus/Models/CadDeleteCandidateModel.cs`**:
   - Modelos DTO jerárquicos (`CadDeleteSheetGroup`, `CadDeleteViewGroup`, `CadDeleteItemNode`) para la presentación clara en la ventana de confirmación.

2. **`TransferPlus/Views/ConfirmCadDeleteWindow.xaml` y `.xaml.cs`**:
   - Ventana modal WPF con TreeView jerárquico y badges visuales para los contenedores preservados y los elementos a eliminar.

3. **`TransferPlus/ViewModels/TransferPlusViewModel.cs`**:
   - `CollectCheckedCadItems()`: Filtrado estricto para ignorar nodos de agrupación (`Sheet`, `View`, `Root` o con hijos).
   - `CanDeleteSelectedCadItems()`: Habilitado cuando el modelo activo es editable y existen casillas marcadas o un elemento individual seleccionado.
   - `DeleteSelectedCadItemsAsync()`: Construcción del árbol jerárquico de confirmación, apertura del diálogo modal y ejecución de la transacción de Revit borrando exclusivamente los IDs de elementos hoja.
