# Plan de Implementación: Portabilidad y Creación de `TransferPlus` (Revit 2024+)

Este plan describe el proceso para portar la utilidad `TransferSingle` (desarrollada originalmente para Revit 2020 con WinForms) a un plugin moderno de Revit multi-versión llamado **`TransferPlus`** (soportando versiones de Revit 2023 a 2027), reescribiendo la UI bajo los principios de diseño de WPF y MVVM establecidos en el skill `revit-addin-gui-design`.

---

## 1. Arquitectura Propuesta (C# / WPF MVVM)

El proyecto se estructurará bajo el estándar definido en `AGENTS.md`:

```text
TransferPlus/
├── Application.cs              # IExternalApplication (Ribbon Configuration)
├── TransferPlus.csproj         # Nice3point.Revit.Sdk multi-versión
├── TransferPlus.addin          # XML Manifest para registrar el add-in en Revit
├── Commands/
│   └── CmdTransferPlus.cs      # IExternalCommand (Entry point)
├── Services/
│   ├── DocumentCollector.cs    # Recolección rápida de elementos en segundo plano
│   └── TransferOrchestrator.cs # Operaciones de copia, carga de familias y transformaciones
├── Models/
│   ├── TransferItem.cs         # Modelo plano del elemento
│   └── TargetDocumentItem.cs   # Representación del documento destino
├── ViewModels/
│   ├── TransferPlusViewModel.cs# Lógica de presentación de la ventana principal
│   └── TreeItemViewModel.cs    # Nodos del árbol jerárquico (Checked, Indeterminate)
└── Views/
    ├── TransferPlusView.xaml   # WPF View (Estética FilterPlus: 3 Columnas, Scroll izquierdo)
    └── TransferPlusView.xaml.cs# Code-behind simple
```

---

## 2. Cambios Propuestos por Componente

### A. Proyecto y Manifiestos (.csproj & .addin)

#### [NEW] [TransferPlus.csproj](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/TransferPlus.csproj)
* Configurado con `Nice3point.Revit.Sdk` (v6.2.1).
* Soporta compilaciones dinámicas: `<Configurations>Debug.R23;Debug.R24;Debug.R25;Debug.R26;Debug.R27;Release.R23;Release.R24;Release.R25;Release.R26;Release.R27</Configurations>`.
* Inyección de `Obfuscar.targets` para protección desatendida en compilación Release.
* Habilita WPF (`<UseWPF>true</UseWPF>`).

#### [NEW] [TransferPlus.addin](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/TransferPlus.addin)
* Manifiesto de Revit apuntando al ensamblado de `TransferPlus.dll`.

---

### B. Lógica del Negocio (Services & Models)

#### [NEW] [TransferItem.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/TransferItem.cs)
* Reemplaza a `Elemento.cs`. Almacena metadatos del elemento a transferir (Id original, Nombre, Tipo, Familia, Categoría, si es familia cargable, leyenda, etc.).

#### [NEW] [DocumentCollector.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/DocumentCollector.cs)
* Implementa la recolección rápida de elementos de `TransferSingle.cs` (`TomaElementosSeleccion`).
* Realiza consultas con `FilteredElementCollector` y empaqueta los objetos en `TransferItem`.
* **Aplicación de Regla de Límite de Caché**: Ejecuta una cuenta rápida (`GetElementCount()`) sobre todos los documentos seleccionados. Si supera los 100k elementos, activa un flag para omitir vínculos y evitar bloqueos en la interfaz gráfica.

#### [NEW] [TransferOrchestrator.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/TransferOrchestrator.cs)
* Implementa la lógica de copia y transferencia (`bt_Filtra_Click` y `ponCallouts`/`ponDependientes`).
* Gestiona la carga de familias editables y sus opciones (`IFamilyLoadOptions`).
* Controla las transformaciones de coordenadas (`chk_GetTransformLink`, `chk_GetTransformShared`).
* Controla los diálogos y fallas temporales de Revit instalando y desinstalando event handlers (`DialogBoxShowing` y `FailuresProcessing` con un `WarningSwallower` desatendido).

---

### C. Capa de Presentación (ViewModels & Views)

#### [NEW] [TreeItemViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TreeItemViewModel.cs)
* ViewModel jerárquico para el control de árbol.
* Soporta lógica de tres estados (`IsChecked` = True, False, null) donde marcar un nodo padre marca recursivamente a todos sus hijos, y viceversa.
* Define propiedades de visualización como `IndentMargin` y highlights de estado.

#### [NEW] [TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs)
* Expone comandos e inicializaciones utilizando `CommunityToolkit.Mvvm` (`[ObservableProperty]`, `[RelayCommand]`).
* Expone listas de archivos abiertos, lógica para buscar/filtrar el árbol por texto, comandos para expandir/colapsar nodos, y el comando de transferencia con reporte de progreso (`IsBusy` y `StatusMessage`).

#### [NEW] [TransferPlusView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml)
* Interfaz gráfica en WPF que reemplaza el diseño WinForms antiguo.
* **Diseño Premium de 3 Columnas**:
  * Columna 1 (Izquierda): Árbol jerárquico de elementos (`RootNodes`) con chevrons planos, highlights de estado (verde para checked, amarillo para indeterminate) y barra de scroll vertical a la derecha.
  * Columna 2 (Medio): Separador fino.
  * Columna 3 (Derecha): Panel de filtros de búsqueda (con interruptores planos estilo `FilterPlus`), radio buttons para selección de documentos origen/destino y opciones de sobreescritura de duplicados.
* **Scrollbar Relocado**: Panel derecho con `ScrollViewer` (`FlowDirection="RightToLeft"`) para posicionar la scrollbar a la izquierda, y contenido a la derecha (`FlowDirection="LeftToRight"` con margen `Margin="0,0,9,0"`).
* **Overlay de Carga**: Tarjeta central con efecto translúcido para mostrar el estado de la recolección y transferencia sin bloquear la pantalla.

---

### D. Puntos de Entrada de Revit

#### [NEW] [CmdTransferPlus.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Commands/CmdTransferPlus.cs)
* Ejecuta el comando externo y abre la ventana WPF modalmente (`ShowDialog`).

#### [NEW] [Application.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Application.cs)
* Agrega un nuevo botón "TransferPlus" a la pestaña del Ribbon (junto a `FilterPlus` si corresponde).

---

## 3. Plan de Verificación

1.  **Compilación**: Compilar localmente en modo `Debug` para validar las referencias y el SDK de Nice3point.
2.  **Verificación de Interfaz WPF**: Comprobar visualmente la correcta disposición del layout de tarjetas, switches planos y scrollbars de la ventana.
3.  **Protección de Ofuscación**: Validar que la compilación en `Release` ejecute correctamente el flujo de ofuscación de `Obfuscar.targets` sin fallos.
