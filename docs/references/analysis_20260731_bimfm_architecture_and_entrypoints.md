# Análisis Arquitectónico del Add-in `Bim.FamilyManager` (`references_examples\BimFM`)

## 📅 Fecha de Registro: 2026-07-31
## 🧩 Componente: `references_examples\BimFM` -> Evaluación de Arquitectura y Puntos de Entrada

---

## 1. Resumen General

Se ha realizado una auditoría exhaustiva del código fuente del add-in **Bim.FamilyManager** alojado en `references_examples\BimFM`. El add-in está construido bajo una arquitectura modular limpia en C# .NET, utilizando **Dependency Injection (Autofac / MS Extensions)**, **Inyección de Hospedaje (`IHostBuilder`)** y la suite **Scotec.Revit** (aislamiento de ensamblados, Paneles Acoplables/Dockable Panes y ejecuciones asíncronas con `RevitTask`).

---

## 2. Puntos de Entrada a Revit (`IExternalApplication` y `IExternalCommand`)

Todos los puntos de entrada principales se concentran en el proyecto **`Bim.FamilyManager`**:

### A. Registro de la Aplicación y Dockable Pane (`IExternalApplication`)
* **[`RevitFamilyManagerApp.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/references_examples/BimFM/Source/Bim.FamilyManager/RevitFamilyManagerApp.cs)**:
  - Hereda de `RevitApp` (wrapper sobre `IExternalApplication`).
  - **`OnStartup()`**: Registra la pestaña y panel de la cinta de opciones (Ribbon) en Revit y configura la barra lateral o panel acoplable (**Dockable Pane**) usando `Application.RegisterDockablePane(Constants.PaneId, ..., _pane)`.
  - **`OnConfigure(IHostBuilder builder)`**: Configura la inyección de dependencias (**Autofac** + `Microsoft.Extensions.Hosting`), carga dinámicamente ensamblados dependientes (`LoadDependentAssemblies`) desde `appsettings.json` y registra el servicio asíncrono **`RevitTask`**.

### B. Comandos de la Cinta de Opciones (`IExternalCommand`)
Ubicados en el directorio `Bim.FamilyManager/Commands/`:
1. **[`OpenFamilyManagerCommand.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/references_examples/BimFM/Source/Bim.FamilyManager/Commands/OpenFamilyManagerCommand.cs)**:
   - Hereda de `RevitCommand`.
   - Abre y muestra la ventana acoplable (`uiApplication.GetDockablePane(PaneId).Show()`).
   - Usa la anotación `[RevitCommandIsolation]` para aislar el contexto de carga del ensamblado en memoria.
2. **[`OpenFamilyManagerSettingsCommand.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/references_examples/BimFM/Source/Bim.FamilyManager/Commands/OpenFamilyManagerSettingsCommand.cs)**:
   - Invocación modal de la ventana de configuración del gestor de familias.
3. **[`CreatePreviewImageCommand.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/references_examples/BimFM/Source/Bim.FamilyManager/Commands/CreatePreviewImageCommand.cs)**:
   - Genera imágenes de previsualización 3D para cada tipo de familia.

---

## 3. Lógica Core: Transacciones, Filtrado y Carga de Familias (`Bim.FamilyManager.Base`)

La lógica central de la API de Revit está desacoplada de la UI e implementada en el proyecto **`Bim.FamilyManager.Base`**:

### A. Gestión de Familias y Transacciones (`FamilyManager.cs`)
El archivo principal es **[`FamilyManager.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/references_examples/BimFM/Source/Bim.FamilyManager.Base/Logic/FamilyManager.cs)** (~1860 líneas):
- **Carga de Familias (`TryLoadFamily`)**:
  - Utiliza `document.LoadFamily` con una clase personalizada `OverwriteFamilyOption` para controlar sobrescrituras.
  - Implementa `LoadMissingSymbols` para cargar iterativamente tipos/símbolos individuales faltantes mediante `document.LoadFamilySymbol`.
- **Uso Estricto de Transacciones (`Transaction` y `TransactionGroup`)**:
  - En la generación de miniaturas (`CreatePreviewImage`): Utiliza `TransactionGroup` para iterar entre los tipos de la familia (`FamilyType`), cambiar el tipo activo, exportar la imagen a un PNG en memoria (`ViewImageExporter.ExportViewPng`) y **hacer Rollback automático del TransactionGroup** para no dejar cambios residuales en el documento.
  - En la inserción/eliminación de familias (`TryLoadFamilyIntoActiveDocument` y `RemoveFamilyFromActiveDocument`): Envuelve las acciones en bloque `using var transaction = new Transaction(doc, ...)`.

### B. Extensible Storage (`EStorage`)
Ubicado en `Bim.FamilyManager.Base/Logic/EStorage/`:
- **`FamilyMetadataEStorage.cs`** y **`PreviewImageEStorage.cs`**:
  - Almacenan metadatos e imágenes binarias comprimidas dentro de los propios elementos de Revit usando `Schema` y `Entity` de la Extensible Storage API, sin depender de bases de datos externas.

### C. Multithreading y Coordinación Asíncrona (`RevitTask`)
- Registra `RevitTask` en el contenedor DI para ejecutar llamadas a la API de Revit de forma segura desde los comandos de los ViewModels y eventos de fondo sin bloquear la interfaz WPF.

---

## 4. Arquitectura de Interfaz de Usuario (XAML, ViewModels y Drag & Drop)

La interfaz se estructura de manera modular dividida en **`Bim.FamilyManager.Ui`**, **`Bim.FamilyManager.Ui.FamilyExplorer`** y **`Bim.FamilyManager.Ui.FamilyNavigator`**:

### A. Contenedores UI y Dockable Pane
- **[`FamilyManagerPane.xaml`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/references_examples/BimFM/Source/Bim.FamilyManager.Ui/Views/FamilyManagerPane.xaml)**:
  - Implementa `IDockablePaneProvider`. Almacena la vista principal WPF que se acopla a los paneles laterales de Revit.
- **[`FamilyManagerView.xaml`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/references_examples/BimFM/Source/Bim.FamilyManager.Ui.FamilyExplorer/Views/FamilyManagerView.xaml)**:
  - Vista del explorador de familias con árbol jerárquico (`FolderView`), barra de búsqueda dinámica y panel de detalles (`FamilyView`).

### B. Sistema Drag & Drop Interactivo a Revit (`FamilyDropHandler.cs`)
- **[`FamilyDropHandler.cs`](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/references_examples/BimFM/Source/Bim.FamilyManager.Ui/FamilyDropHandler.cs)**:
  - Implementa `IControllableDropHandler`. Permite al usuario **arrastrar una familia o símbolo desde el panel WPF directamente hacia la vista activa de Revit**.
  - Calcula la posición exacta del cursor y escala de pantalla usando `VisualTreeHelper.GetDpi`.
  - Coloca el elemento en Revit usando la función nativa interactiva:
    ```csharp
    uiDocument.PostRequestForElementTypePlacement(familySymbol);
    ```

### C. ViewModels y Sistema de Diseño XAML
- **ViewModels principales** (`Bim.FamilyManager.Ui/ViewModels/`):
  - `FamilyViewModel.cs`: Gestiona la familia seleccionada, lista de tipos (`FamilySymbolViewModel`), metadatos e imágenes de vista previa.
  - `FolderViewModel.cs`: Gestiona carpetas y estructuración en árbol.
  - `FamilyDropViewModel.cs`: ViewModel para la interacción modal de arrastre.
- **Estilos y Temas (`Bim.FamilyManager.Ui/Themes/`)**:
  - Recursos XAML independientes para botones (`ButtonStyles.xaml`), listas (`ListViewStyles.xaml`), combos (`ComboBoxStyles.xaml`) e iconos vectoriales (`Icons.xaml`).

---

## 5. Componentes Clave Reutilizables

1. **Inserción Interactiva de Familias (`PostRequestForElementTypePlacement`)**:
   - `FamilyDropHandler.cs` ofrece la lógica exacta para permitir colocar tipos de familia seleccionados de forma interactiva en la vista.
2. **Generación de Miniaturas con `TransactionGroup` + Rollback**:
   - La técnica usada en `FamilyManager.CreatePreviewImage` es idéntica al estándar para capturar imágenes de tipos sin modificar el modelo origen.
3. **Manejo Seguro de Carga y Sobrescritura de Familias**:
   - `TryLoadFamily` y `LoadMissingSymbols` resuelven la limitación nativa donde `document.LoadFamily` no carga tipos/símbolos faltantes cuando la familia ya existe en el modelo.
