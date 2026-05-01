---
name: Revit API Master
description: Instrucciones estrictas para desarrollar Add-ins de Revit en C#. Úsalo siempre que modifiques o crees código relacionado con la API de Autodesk Revit.
---

# Instrucciones de Código C# Estrictas
* Siempre usa C# 12. Usa 'Primary Constructors' en los ViewModels.
* Nunca uses `#region`. Mantén las clases pequeñas.
* Siempre inyecta dependencias a través del constructor, nunca instancies servicios directamente dentro de un Command.

# Versionado y Sincronización con Git
* **Versión Única:** La verdad sobre la versión del Add-in reside en los **Tags de Git**.
* **Sincronización:** Cada vez que se prepare una compilación o un instalador, el Agente DEBE sincronizar el tag de git (`git describe --tags --abbrev=0`) con la etiqueta `<Version>` del archivo `.csproj`.
* **Consistencia:** No permitas discrepancias entre la versión del instalador, la versión del ensamblado y la etiqueta de git.

# Instrucciones sobre la API de Revit
* Cuando busques elementos en el modelo con `FilteredElementCollector`, SIEMPRE prioriza filtros rápidos (QuickFilters) como `OfCategory()` antes que filtros lentos como literales de parámetros.
* Nunca intentes modificar la UI de Revit (Ribbon) fuera del evento `OnStartup` de la aplicación.
* Toda modificación al modelo debe estar envuelta en un bloque `Transaction`.

---

# ⚠️ REGLAS CRÍTICAS: Contexto de Hilo y Seguridad de la API de Revit

> Estas reglas son el resultado de debugging intensivo. Ignorarlas produce crashes silenciosos y cierres inesperados de Revit sin mensaje de error.

## 🚫 PROHIBIDO: Llamar a la API de Revit desde el hilo WPF

**NUNCA** llames a ninguna API de Revit (`FilteredElementCollector`, `Document`, `UIDocument`, `Selection`, etc.) desde:
- Un `Dispatcher.BeginInvoke()` o `Dispatcher.Invoke()`
- Un `Task.Run()` o hilo de fondo
- Un manejador de evento WPF (click de botón, cambio de RadioButton, `PropertyChanged`, etc.)
- Un `partial void OnXxxChanged()` generado por CommunityToolkit MVVM si está vinculado a un control WPF

**Cualquier llamada a la API de Revit fuera del contexto correcto CIERRA Revit sin mensaje de error.**

### Contextos SEGUROS para llamar a la API de Revit:

| Contexto | Seguro |
|---|---|
| `IExternalCommand.Execute()` | ✅ |
| `IExternalEventHandler.Execute(UIApplication app)` | ✅ |
| `IExternalApplication.OnStartup()` | ✅ |
| Evento `Application.Idling` (handler registrado) | ✅ |
| `Dispatcher.BeginInvoke` / `Task.Run` | ❌ CRASH |
| `partial void OnXxxChanged()` (CommunityToolkit) | ❌ CRASH |
| Hilo de fondo / `async void` | ❌ CRASH |

---

## ✅ PATRÓN RECOMENDADO: Pre-fetch en el constructor del ViewModel

Cuando un ViewModel necesita datos de Revit que pueden cambiar según la interacción del usuario (ej: cambio de scope/alcance), **pre-carga todos los datos posibles en el constructor del ViewModel**, que es llamado desde `IExternalCommand.Execute()` (contexto seguro).

```csharp
// ✅ CORRECTO: Constructor llamado desde Execute() – contexto API seguro
public SelectionFilterViewModel(RevitSelectionService service)
{
    // Todos los scopes se pre-cargan aquí, en el contexto API correcto
    _currentSelectionElements = service.GetAvailableElements(SelectionScope.CurrentSelection);
    _elementsInViewElements   = service.GetAvailableElements(SelectionScope.ElementsInView);
    _allModelElements         = service.GetAvailableElements(SelectionScope.AllModelElements);
}

// ✅ CORRECTO: scope change solo cambia punteros en memoria – sin llamadas API
partial void OnCurrentScopeChanged(SelectionScope value)
{
    _activeElements = value switch {
        SelectionScope.ElementsInView   => _elementsInViewElements,
        SelectionScope.AllModelElements => _allModelElements,
        _                               => _currentSelectionElements
    };
    BuildTreeFromMemory(); // Solo opera sobre datos ya cargados en memoria
}
```

```csharp
// ❌ INCORRECTO: Llamada a API de Revit desde hilo WPF – CRASH garantizado
partial void OnCurrentScopeChanged(SelectionScope value)
{
    Dispatcher.BeginInvoke(() => {
        var elements = new FilteredElementCollector(_doc, _doc.ActiveView.Id); // 💥 CIERRA REVIT
    });
}
```

---

## ✅ PATRÓN ALTERNATIVO: IExternalEventHandler (para datos bajo demanda)

Úsalo cuando los datos son demasiado grandes para pre-cargar o necesitan actualizarse en tiempo real. Es más complejo pero correcto.

```csharp
// 1. Handler: se ejecuta en el hilo API de Revit
public class FetchElementsHandler : IExternalEventHandler
{
    public void Execute(UIApplication app)
    {
        // ✅ SEGURO: estamos en contexto API de Revit
        var elements = new FilteredElementCollector(app.ActiveUIDocument.Document)
            .WhereElementIsNotElementType().ToList();
        _viewModel.UpdateData(elements); // devolver datos al ViewModel vía callback
    }
    public string GetName() => "FetchElements";
}

// 2. Arranque: crear el ExternalEvent DENTRO de Execute() del Command
var handler = new FetchElementsHandler(viewModel);
var externalEvent = Autodesk.Revit.UI.ExternalEvent.Create(handler); // ✅

// 3. Desde WPF: solo .Raise() – nunca datos de Revit directos
partial void OnCurrentScopeChanged(SelectionScope value)
{
    handler.SetScope(value);
    externalEvent.Raise(); // ✅ seguro desde cualquier hilo – solo señaliza a Revit
}

// 4. El ViewModel recibe los datos ya en el contexto correcto y los envía a la UI
public void UpdateData(List<ElementModel> elements)
{
    // Ahora sí podemos ir al Dispatcher para actualizar la UI
    _uiDispatcher.BeginInvoke(() => BuildTree(elements));
}
```

### ⚠️ Advertencia sobre `ExternalEvent` con `Nice3point.Revit.Toolkit`
- `Nice3point.Revit.Toolkit.External.ExternalEvent` y `Autodesk.Revit.UI.ExternalEvent` son tipos **distintos con el mismo nombre**.
- Usa siempre el nombre completo `Autodesk.Revit.UI.ExternalEvent.Create(handler)` para evitar errores de ambigüedad en compilación (CS0104).

---

## ❌ ANTI-PATRÓN: DoEvents / PushFrame en el hilo UI de Revit

**NUNCA** implementes un `DoEvents()` (basado en `DispatcherFrame`) dentro de callbacks que se ejecuten durante operaciones de carga pesada de Revit. Esto causa:
- Reentrada en el bucle de mensajes de Windows
- Bloqueo indefinido del hilo UI
- Cierre forzado de Revit

```csharp
// ❌ PROHIBIDO dentro de Add-ins de Revit – causa deadlock y cierre de Revit
private static void DoEvents()
{
    var frame = new System.Windows.Threading.DispatcherFrame();
    Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, ExitFrame, frame);
    Dispatcher.PushFrame(frame); // 💥 deadlock en contexto de Revit
}
```

---

## ✅ Logging seguro entre hilos en Add-ins de Revit

Para un servicio de log que funcione desde cualquier hilo (API o WPF), captura el `Dispatcher` al inicio y usa **siempre `BeginInvoke` (no `Invoke`)** para los mensajes de log. Nunca uses `DoEvents` para forzar el refresco.

```csharp
public static class LoggerService
{
    private static Dispatcher _uiDispatcher;
    
    // Llamar desde StartupCommand.Execute() – contexto seguro
    public static void SetDispatcher(Dispatcher d) => _uiDispatcher = d;

    public static void LogInfo(string message)
    {
        string entry = $"[{DateTime.Now:HH:mm:ss.fff}] {message}";
        System.Diagnostics.Debug.WriteLine(entry); // siempre visible en Output de VS

        // BeginInvoke (asíncrono): no bloquea nunca el hilo llamante
        _uiDispatcher?.BeginInvoke(new Action(() => Logs.Insert(0, entry)));
        // ❌ Nunca usar Invoke() ni PushFrame() para "forzar" el refresco
    }
}
```

---

## ✅ Construcción eficiente de TreeView con miles de nodos sin bloquear la UI

Cuando construyas un árbol grande (`TreeView` con cientos o miles de nodos):

1. **Construye la estructura completa en memoria** (`TreeItemViewModel` offline) antes de modificar la `ObservableCollection`.
2. **Haz un único swap atómico al final**: `RootNodes.Clear(); RootNodes.Add(root);`
3. **Usa un flag estático `IsBulkUpdating`** para suprimir el disparo de `SelectionChanged` / `PropertyChanged` durante la construcción masiva y evitar "tormentas de eventos".
4. **Llama a `RefreshState()` bottom-up al final** para propagar correctamente el estado de checkboxes padres/hijos.

```csharp
// ✅ CORRECTO: construir offline, insertar en un único swap atómico
TreeItemViewModel.IsBulkUpdating = true;
try
{
    var root = new TreeItemViewModel("All", null, 0, callback);
    // ... construir todo el árbol en 'root' sin modificar RootNodes ...
    RootNodes.Clear();      // un solo Clear
    RootNodes.Add(root);    // un solo Add – una sola notificación a WPF
}
finally
{
    foreach (var node in RootNodes) node.RefreshState(); // propagar checkboxes
    TreeItemViewModel.IsBulkUpdating = false;
}

// ❌ INCORRECTO: añadir nodos uno a uno dispara cientos de actualizaciones de UI
foreach (var item in allItems)
    RootNodes.Add(new TreeItemViewModel(item, ...)); // 💥 tormenta de eventos
```

---

## ✅ Templates de Proyecto `.csproj`

### .NET Framework 4.8 (Revit ≤ 2024)

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net48</TargetFramework>
    <LangVersion>12</LangVersion>
    <ImplicitUsings>enable</ImplicitUsings>
    <UseWPF>true</UseWPF>
    <Configurations>Debug;Release</Configurations>
    <Version>1.0.0</Version>
    <AssemblyName>{{Nombre}}</AssemblyName>
    <RootNamespace>{{Nombre}}</RootNamespace>
  </PropertyGroup>

  <ItemGroup>
    <!-- Revit API References - ajustar la ruta según la instalación local -->
    <Reference Include="RevitAPI">
      <HintPath>$(ProgramW6432)\Autodesk\Revit 2024\RevitAPI.dll</HintPath>
      <Private>false</Private>
    </Reference>
    <Reference Include="RevitAPIUI">
      <HintPath>$(ProgramW6432)\Autodesk\Revit 2024\RevitAPIUI.dll</HintPath>
      <Private>false</Private>
    </Reference>
  </ItemGroup>

  <!-- Nice3point Toolkit (recomendado) -->
  <ItemGroup>
    <PackageReference Include="Nice3point.Revit.Toolkit" Version="2024.*" />
    <PackageReference Include="Nice3point.Revit.Extensions" Version="2024.*" />
    <PackageReference Include="Nice3point.Revit.Api.RevitAPI" Version="2024.*" />
    <PackageReference Include="Nice3point.Revit.Api.RevitAPIUI" Version="2024.*" />
  </ItemGroup>
</Project>
```

> **⚠️ Nota:** Si se usan los paquetes NuGet de Nice3point (`Nice3point.Revit.Api.RevitAPI`), las referencias manuales a `RevitAPI.dll` **no son necesarias**. Usa uno u otro, nunca ambos.

### .NET 8 (Revit 2025+)

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0-windows</TargetFramework>
    <LangVersion>12</LangVersion>
    <ImplicitUsings>enable</ImplicitUsings>
    <UseWPF>true</UseWPF>
    <EnableDynamicLoading>true</EnableDynamicLoading>
    <Version>1.0.0</Version>
    <AssemblyName>{{Nombre}}</AssemblyName>
    <RootNamespace>{{Nombre}}</RootNamespace>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Nice3point.Revit.Toolkit" Version="2025.*" />
    <PackageReference Include="Nice3point.Revit.Extensions" Version="2025.*" />
    <PackageReference Include="Nice3point.Revit.Api.RevitAPI" Version="2025.*" />
    <PackageReference Include="Nice3point.Revit.Api.RevitAPIUI" Version="2025.*" />
  </ItemGroup>
</Project>
```

### Propiedades críticas del `.csproj`

| Propiedad | Valor obligatorio | Motivo |
|-----------|------------------|--------|
| `ImplicitUsings` | `enable` | Inyecta namespaces globales de Revit/Nice3point |
| `LangVersion` | `12` | Habilita Primary Constructors, records, etc. |
| `UseWPF` | `true` | Necesario para `pack://application` y controles WPF |
| `Private` (en References) | `false` | Evita copiar DLLs de Revit al output (ya están en el GAC) |
| `EnableDynamicLoading` | `true` (solo .NET 8) | Requerido para que Revit cargue el assembly correctamente |

---

## ✅ ForgeTypeId — Unidades Modernas (Revit 2022+)

Desde Revit 2022, los tipos de unidades basados en enteros (`DisplayUnitType`, `UnitType`) están **obsoletos**. Usa siempre `ForgeTypeId`:

### Conversión de unidades

```csharp
// ✅ CORRECTO (Revit 2022+): ForgeTypeId
double meters = UnitUtils.ConvertFromInternalUnits(feetValue, UnitTypeId.Meters);
double feet = UnitUtils.ConvertToInternalUnits(metersValue, UnitTypeId.Meters);

// ❌ OBSOLETO (pre-2022): DisplayUnitType
double meters = UnitUtils.ConvertFromInternalUnits(feetValue, DisplayUnitType.DUT_METERS); // CS0618
```

### Lectura de parámetros con tipo de especificación

```csharp
// ✅ CORRECTO: Verificar tipo de parámetro con SpecTypeId
Parameter param = element.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
if (param != null && param.Definition.GetDataType() == SpecTypeId.Length)
{
    double lengthInMeters = UnitUtils.ConvertFromInternalUnits(param.AsDouble(), UnitTypeId.Meters);
}
```

### Tabla de ForgeTypeId más comunes

| Concepto | Clase | Ejemplos |
|----------|-------|----------|
| **Qué se mide** (especificación) | `SpecTypeId` | `.Length`, `.Area`, `.Volume`, `.Angle`, `.Mass` |
| **En qué unidad** (unidad) | `UnitTypeId` | `.Meters`, `.Millimeters`, `.Feet`, `.Degrees`, `.SquareMeters` |
| **Tipo de dato del parámetro** | `ParameterTypeId` | `.Text`, `.Integer`, `.YesNo`, `.Material` |

---

# Flujo de Ejecución para el Agente
1. Cuando el usuario te pida crear un nuevo Add-in, tu primer paso DEBE ser ejecutar `dotnet new revit -n [Nombre]`.
2. Tu segundo paso DEBE ser reestructurar las carpetas `/UI` a `/Views` y `/ViewModels` según los estándares de MVVM.
3. Cada vez que crees, iteres o modifiques un add-in, DEBES copiar los artefactos generados (Implementation Plan, Task y Walkthrough) a la carpeta `docs/` del proyecto actual, siguiendo el patrón `[artifact]_[keywords]_[YYYY-MM-DD_HHmm].md`.