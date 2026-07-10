# Plan de Implementación: Migración y Recuperación de la Lógica de `TransferSingle` a `TransferPlus`

Este plan describe el proceso detallado para recuperar y adaptar el 100% de la lógica de negocio y los elementos de interacción de la UI del addin original `references_examples/TransferSingle` (desarrollado originalmente para Revit 2020) e integrarla en nuestro nuevo proyecto multi-versión **`TransferPlus`** para Revit 2024+, sustituyendo la interfaz WinForms por la vista WPF premium.

---

## 1. Justificación del Flujo
El andamiaje inicial se realizó con una plantilla limpia de `Nice3point.Revit.Sdk` para asegurar la configuración multi-versión (.NET Framework 4.8 / .NET 8), WPF y ofuscación desatendida. Sin embargo, para no perder las complejas características de recolección de Revit (las 37 categorías, copiado recursivo de vistas dependientes/callouts, copiado de planos y traducción de coordenadas de vínculos), recuperaremos y adaptaremos los archivos lógicos originales.

---

## 2. Archivos a Recuperar y Adaptar

### A. Modelos y Estructuras de Datos

#### [NEW] [Elemento.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/Elemento.cs)
* Copiado de la versión original. Namespace ajustado a `TransferPlus.Models`.
* Mantiene propiedades vitales como `IsView`, `IsLegend`, `IsSheet`, `IsSchedule`, `IsWorkset`, `SheetNumber`, `NoTransferible`, `wID` y `eID`.

#### [NEW] [Nodo.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/Nodo.cs)
* Copiado de la versión original para mantener la agrupación jerárquica de categorías (All -> Categoría -> Familia -> Tipo -> Elementos). Namespace ajustado a `TransferPlus.Models`.

#### [NEW] [Archivo.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/Archivo.cs)
* Copiado de la versión original. Namespace actualizado a `TransferPlus.Models`. Mapea los documentos vinculados y abiertos.

#### [NEW] [Estructura.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/Estructura.cs)
* Copiado de la versión original. Mantiene la lista de raíces, nodos, archivos y log de transacciones.

#### [NEW] [Configuraciones.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/Configuraciones.cs)
* Copiado y adaptado. Se retiran los campos de control WinForms (`System.Drawing.Size` y `System.Drawing.Point`) y se mantiene la configuración de copiado (`cf_rbOverride`, `cf_chk_Links`, `cf_chk_Callout`, `cf_chk_SheetWithViews`, etc.).

---

### B. Servicios y Lógica de Negocio

#### [NEW] [Serializaciones.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Serializaciones.cs)
* Copiado de la versión original. Namespace cambiado a `TransferPlus.Services`. Reemplazado `MessageBox.Show` por `TaskDialog.Show` de Revit.

#### [NEW] [DocumentCollector.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/DocumentCollector.cs)
* Se portará la totalidad del método `TomaElementosSeleccion` original (las 37 consultas de FilteredElementCollector).
* Se adaptará para recibir un delegado de progreso `Action<string, int, int>? progressCallback` que reporte a la ventana WPF el porcentaje actual.

#### [NEW] [TransferOrchestrator.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/TransferOrchestrator.cs)
* Contendrá la lógica del botón Transferir original (copias recursivas, transformaciones, matrices de coordenadas de vínculos, y `WarningSwallower`).

---

### C. Ajuste de la Capa de Presentación (ViewModels & Views)

#### [MODIFY] [TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs)
* Adaptará los comandos para poblar la vista en base a los modelos `Nodo` y `Elemento` originales.
* Se expondrán todos los comandos de renombrado y edición del árbol de elementos:
  * `AddPrefixCommand` y `AddSuffixCommand` (solicitan el texto mediante un cuadro de diálogo WPF modal ligero).
  * `FindAndReplaceCommand` (solicita texto original y reemplazo).
  * `ChangeCaseCommand` (mayúsculas, minúsculas, ProperCase).
  * `DeleteElementsCommand` (elimina elementos seleccionados del documento origen tras confirmación).
* Se agregarán las propiedades reactivas para vincular los checkboxes de configuración de vínculos, planos y llamadas de detalle.

#### [MODIFY] [TransferPlusView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml)
* Se portarán todos los controles visuales originales adaptados a WPF y organizados en tarjetas (`CardBorderStyle`):
  * **Filtros e Inputs**: ComboBox para origen, Lista con checkboxes para los archivos destino.
  * **Panel de Operaciones de Texto**: Botones premium con iconos circulares para prefijo, sufijo, buscar/reemplazar, cambiar caja y eliminar.
  * **Opciones de Transferencia**: Switches planos estilo iOS para incluir llamadas de detalle (`cf_chk_Callout`), vistas en planos (`cf_chk_SheetWithViews`), activar vínculos (`cf_chk_Links`), etc.
  * **Tratamiento de Coordenadas**: RadioButtons para coordenadas de vínculo, coordenadas compartidas o ninguna.
  * **Manejo de Duplicados**: RadioButtons para sobrescribir, cancelar o preguntar.
* Enlazará la barra de progreso flotante (`ProgressBar`) a la propiedad `ProgressPercentage` y habilitará un `TextBlock` con el estado detallado.

#### [NEW] [RenameTextView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/RenameTextView.xaml) & [TakeTextView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TakeTextView.xaml)
* Diálogos modales WPF ligeros y estilizados que reemplazarán a `RenameText.cs` y `TakeText.cs` de WinForms para solicitar los valores de búsqueda/prefijo.

---

## 3. Plan de Verificación
1. **Compilación local**: Compilar el proyecto para Revit 2024 (R24).
2. **Revisión de Seguridad**: Verificar transacciones correctas utilizando bloques `using` en el orquestador.
