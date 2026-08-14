# Informe de Análisis Arquitectónico Detallado: Ecosistema `Bim.FamilyManager` (`references_examples\BimFM\Source`)

## 📅 Fecha de Registro: 2026-07-31
## 🧩 Componente: `references_examples\BimFM\Source` -> Desglose Recursivo de Arquitectura, UI, MVVM y Revit API

---

## 1. Puntos de Entrada a Revit (`IExternalApplication` y `IExternalCommand`)

Los puntos de entrada principales a la API de Revit están desacoplados y gestionados por el proyecto **`Bim.FamilyManager`** utilizando la librería de aislamiento y abstracción `Scotec.Revit`:

### A. Registro de Aplicación (`IExternalApplication`)
* **[`RevitFamilyManagerApp.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/references_examples/BimFM/Source/Bim.FamilyManager/RevitFamilyManagerApp.cs)** (Implementa `RevitApp` $\rightarrow$ wrapper de `IExternalApplication`):
  - **`OnStartup()`**: Registra la pestaña y los paneles de la cinta de opciones (**Ribbon UI**) en Revit e inicializa el panel acoplable lateral (**Dockable Pane**) invocando `Application.RegisterDockablePane(Constants.PaneId, ..., _pane)`.
  - **`OnConfigure(IHostBuilder builder)`**: Configura la inyección de dependencias (`Microsoft.Extensions.Hosting` + **Autofac**), carga dinámicamente ensamblados dependientes (`LoadDependentAssemblies`) desde `appsettings.json` y registra en la DI el servicio asíncrono **`RevitTask`**.

### B. Comandos de la Cinta de Opciones (`IExternalCommand`)
Ubicados en `Bim.FamilyManager/Commands/`:
1. **[`OpenFamilyManagerCommand.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/references_examples/BimFM/Source/Bim.FamilyManager/Commands/OpenFamilyManagerCommand.cs)** (Implementa `RevitCommand` $\rightarrow$ wrapper de `IExternalCommand`):
   - Muestra la barra lateral acoplable (`uiApplication.GetDockablePane(PaneId).Show()`).
   - Utiliza el atributo `[RevitCommandIsolation]` para garantizar un contexto de carga aislado en memoria.
2. **[`OpenFamilyManagerSettingsCommand.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/references_examples/BimFM/Source/Bim.FamilyManager/Commands/OpenFamilyManagerSettingsCommand.cs)**:
   - Abre la ventana modal de configuración global del add-in.
3. **[`CreatePreviewImageCommand.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/references_examples/BimFM/Source/Bim.FamilyManager/Commands/CreatePreviewImageCommand.cs)**:
   - Genera manualmente imágenes de miniatura PNG para los tipos de la familia abierta.

---

## 2. Interfaz de Usuario (Archivos `.xaml` y `.xaml.cs`)

La interfaz gráfica está dividida en submódulos especializados según su propósito visual:

### A. Proyecto `Bim.FamilyManager.Ui` (UI Core, Contenedores y Drag & Drop)
* **`FamilyManagerPane.xaml` / `.xaml.cs`**:
  - Contenedor de la barra lateral acoplable (`DockablePane`) de Revit (`IDockablePaneProvider`). Hospeda dinámicamente las vistas del explorador.
* **`FamilyView.xaml` / `.xaml.cs`**:
  - Vista de detalle de una familia seleccionada (muestra miniatura 3D, selector de tipo/símbolo, metadatos y botones de carga o edición).
* **`FamilyDropWindow.xaml` / `.xaml.cs`**:
  - Ventana transparente flotante utilizada durante la operación de arrastrar y soltar (**Drag and Drop**) para seleccionar el tipo de familia antes de la inserción.
* **`SettingsManagerWindow.xaml` / `.xaml.cs`**:
  - Ventana modal principal para la configuración del add-in.
* **`SettingsContentWindow.xaml` / `.xaml.cs`**:
  - Ventana contenedora secundaria para sub-diálogos de ajustes.
* **`DisplaySettingsView.xaml` / `.xaml.cs`**:
  - Control de configuración de preferencias visuales y temas.
* **`FamilySourceSelectionView.xaml` / `.xaml.cs`**:
  - Vista de selección del origen de datos de familias (Directorio Local o Azure Cloud).
* **`FamilySourcesSettingsView.xaml` / `.xaml.cs`**:
  - Lista y gestiona las fuentes de datos configuradas.
* **`FamilySourceSettingsEditView.xaml` / `.xaml.cs`**:
  - Formulario de edición individual para una fuente de familias.
* **Directorio `Themes/` (Sistema de Diseño XAML)**:
  - Contiene los diccionarios de recursos: `Colors.xaml`, `Generic.xaml`, `Icons.xaml` y estilos de controles (`ButtonStyles.xaml`, `ComboBoxStyles.xaml`, `ExpandButtonStyles.xaml`, `ListBoxStyles.xaml`, `ListViewStyles.xaml`, `RadioButtonStyles.xaml`, `TextBlockStyles.xaml`).

### B. Proyecto `Bim.FamilyManager.Ui.FamilyExplorer` (Modo Exploración Jerárquica/Árbol)
* **`FamilyManagerView.xaml` / `.xaml.cs`**: Vista principal del explorador (árbol jerárquico a la izquierda, detalle a la derecha).
* **`FolderView.xaml` / `.xaml.cs`**: Control en árbol (`TreeView`) para la navegación por carpetas de familias.
* **`FamilySourcesView.xaml` / `.xaml.cs`**: Selector superior de fuentes activas.
* **`LayoutSettingsView.xaml` / `.xaml.cs`**: Panel de ajustes de vista y retícula.

### C. Proyecto `Bim.FamilyManager.Ui.FamilyNavigator` (Modo Navegación Ligera)
* **`FamilyManagerView.xaml` / `.xaml.cs`**: Vista alternativa tipo navegador plano.
* **`FamilySourceView.xaml` / `.xaml.cs`**: Muestra el contenido de la fuente seleccionada.
* **`FolderView.xaml` / `.xaml.cs`**: Navegación simplificada por carpetas.
* **`FamilySourcesView.xaml` / `.xaml.cs`**: Selector de fuentes para el navegador.
* **`LayoutSettingsView.xaml` / `.xaml.cs`**: Ajustes de rejilla y disposición.

### D. Proveedores de Fuentes (`Source.Directory` y `Source.AzureStorage`)
* **`DirectorySourceSettingsView.xaml` / `.xaml.cs`**: Configuración de carpetas locales de disco.
* **`AzureStorageSourcePanelView.xaml` / `.xaml.cs`**: Estado de conexión con Azure Blob Storage.
* **`AzureStorageSourceSettingsView.xaml` / `.xaml.cs`**: Formulario de credenciales y contenedores de la nube de Azure.

---

## 3. Lógica de Negocio (ViewModels y Models)

La aplicación aplica una separación estricta bajo el patrón **MVVM**:

```text
 ┌──────────────────────┐         DataBindings / ICommand        ┌──────────────────────────┐
 │   Vistas XAML (.xaml)│ ◄─────────────────────────────────────►│ ViewModels (*ViewModel)  │
 └──────────────────────┘                                        └────────────┬─────────────┘
                                                                              │
                                                                       Invocación de Servicio
                                                                              │
 ┌──────────────────────┐           RevitTask (Thread Safe)           ┌───────▼──────────────────┐
 │  Revit API Document  │ ◄───────────────────────────────────────────│ IFamilyManager / Core    │
 └──────────────────────┘                                        └──────────────────────────┘
```

### A. Ubicación de la Lógica en ViewModels (`*ViewModel.cs`)
* Residen en los proyectos de UI (`Bim.FamilyManager.Ui/ViewModels/`, `FamilyExplorer/ViewModels/`, etc.).
* **`FamilyViewModel.cs`**: Encapsula el estado de una familia seleccionada. Expone propiedades observables (`FamilySymbols`, `SelectedSymbol`, `PreviewImage`, `FamilyMetadata`) y comandos ejecutables (`LoadFamilyCommand`, `EditFamilyCommand`, `CreatePreviewImageCommand`).
* **`FolderViewModel.cs`**: Administra la jerarquía de carpetas, la carga perezosa (*Lazy Loading*) de contenido y las búsquedas en tiempo real mediante `SearchRevitFamiliesAsync`.
* **`FamilyDropViewModel.cs`**: Gestiona la interacción durante el arrastre y suelta de familias hacia el documento activo.
* **`SettingsManagerViewModel.cs`**, **`DisplaySettingsViewModel.cs`**, **`FamilySourcesSettingsViewModel.cs`**: Administran el estado reactivo de las opciones del sistema.

### B. Modelos y Contratos de Datos
* **Abstracciones / Interfaces**: `IRevitFamily`, `IRevitFamilySymbol`, `IFolder`, `IFamilySource` (ubicadas en `Bim.FamilyManager.Abstractions`).
* **Implementaciones Core**: `RevitFamily.cs`, `RevitFamilySymbol.cs`, `Folder.cs`, `FamilySource.cs` (ubicadas en `Bim.FamilyManager.Base`).

### C. Comunicación entre Capas
1. **Vista $\leftrightarrow$ ViewModel**: Vinculación declarativa vía DataBinding y comandos `ICommand`. La asignación de vistas a ViewModels es dinámica mediante un `TemplateSelector` registrado en el contenedor DI (`services.AddViewModelTemplateSelector()`).
2. **ViewModel $\leftrightarrow$ Servicio Core (`IFamilyManager`)**: Los ViewModels no interactúan directamente con las clases nativas de Revit; invocan métodos de la interfaz `IFamilyManager` inyectada vía DI.
3. **ViewModel $\leftrightarrow$ Revit API (Hilo Secundario vs. Principal)**: Para cualquier operación que requiera consultar o modificar Revit desde un comando de UI, los ViewModels/Servicios ejecutan sus llamadas a través de **`RevitTask`**, garantizando que la API de Revit se invoque de forma segura en el hilo principal sin congelar WPF.

---

## 4. Interacción con Revit API

La interacción directa con la API de Revit está centralizada en clases de servicio dedicadas:

### A. Clase `FamilyManager` (`Bim.FamilyManager.Base/Logic/FamilyManager.cs`)
* **`FilteredElementCollector`**:
  - `RemoveFamily(...)`: Ejecuta `new FilteredElementCollector(document).OfClass(typeof(Family))` para localizar y filtrar familias por nombre.
  - `TemporarilyHideAllFamilyConnectors(...)`: Ejecuta `new FilteredElementCollector(doc).OfClass(typeof(ConnectorElement))` para recopilar conectores MEP dentro de un modelo `.rfa`.
* **`Transaction`**:
  - `TryLoadFamilyIntoActiveDocument(...)`: Envuelve la carga en `using var transaction = new Transaction(_activeDocument, "Load Family");`.
  - `RemoveFamilyFromActiveDocument(...)`: Ejecuta `using var transaction = new Transaction(_activeDocument, "Remove Family");`.
  - `TemporarilyHideAllFamilyConnectors(...)`: Ejecuta `using var transaction = new Transaction(doc, "Temp-hide connectors");`.
  - `CreatePreviewImage(...)`: Ejecuta `using var transaction = new Transaction(document, "Add previews");` para escribir las miniaturas en Extensible Storage.
  - `SetCurrentFamilyType(...)`: Abre `using var familyTypeTransaction = new Transaction(document, "Set current family type");`.
* **`TransactionGroup`**:
  - `CreatePreviewImage(...)`: Inicia `using var transactionGroup = new TransactionGroup(document, "Create preview images");`. Cambia iterativamente de tipo de familia y captura la imagen. Al finalizar, invoca **`transactionGroup.RollBack()`**, restituyendo el estado original del documento sin modificar la familia.
* **Modificación y Métodos de `Document`**:
  - `TryLoadFamily(...)`: Invoca `document.LoadFamily(...)` para cargar o actualizar la familia desde un archivo `.rfa` temporal.
  - `LoadMissingSymbols(...)`: Invoca `document.LoadFamilySymbol(...)` para cargar tipos/símbolos individuales faltantes.
  - `EditFamily(...)`: Invoca `uiApp.OpenAndActivateDocument(familyFile)` para abrir la familia en el editor de Revit.
  - `RemoveFamily(...)`: Invoca `document.Delete(family.Id)` para eliminar la familia del modelo.

### B. Clase `FamilyDropHandler` (`Bim.FamilyManager.Ui/FamilyDropHandler.cs`)
* **`Transaction`**:
  - `DropAction(...)`: Abre `using var transaction = new Transaction(uiDocument.Document, "Load Family");` para asegurar que el tipo de familia esté cargado antes de la colocación.
* **Interacción con `UIDocument`**:
  - `CanExecute(...)`: Valida la compatibilidad de colocación usando `uiDocument.CanPlaceElementType(familySymbol)`.
  - `PlaceSymbol(...)`: Invoca la función interactiva de Revit `uiDocument.PostRequestForElementTypePlacement(symbol)`, cediendo el control al cursor del usuario para instanciar la familia en la vista.

### C. Clase `ViewImageExporter` (`Bim.FamilyManager.Base/Logic/ViewImageExporter.cs`)
* **Exportación de `Document`**:
  - Invoca `document.ExportImage(imageExportOptions)` para renderizar y capturar miniaturas 3D de familias en formato PNG.

### D. Clases Extensible Storage (`PreviewImageEStorage.cs` y `FamilyMetadataEStorage.cs`)
* **Modificación de `Element` / `Document`**:
  - Utilizan `element.GetEntity(schema)` y `element.SetEntity(entity)` para incrustar datos binarios (imágenes) y esquemas JSON directamente dentro de los elementos de Revit sin bases de datos externas.
