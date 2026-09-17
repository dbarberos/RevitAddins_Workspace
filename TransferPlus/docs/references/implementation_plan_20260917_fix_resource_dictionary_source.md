# Plan de Acción: Corrección del Error 'System.Windows.ResourceDictionary.Source' en TransferPlus

## 1. Diagnóstico y Causa Raíz del Error

Al ejecutar el comando de lanzamiento del add-in `TransferPlus` en Revit, se genera un cuadro de diálogo nativo de Revit con el siguiente mensaje:
> **Fallo de comando para comando externo**  
> *Revit no ha podido completar el comando externo. Solicite asistencia a su proveedor...*  
> *Revit ha encontrado Se produjo una excepción al establecer la propiedad 'System.Windows.ResourceDictionary.Source'.*

### Causa Raíz Técnica en TransferPlus
En el archivo `TransferPlus/Views/TransferPlusView.xaml` (líneas 46-51), los recursos de la ventana se estaban cargando mediante un diccionario combinado externo con Pack URI:
```xaml
<Window.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/TransferPlus;component/Resources/Styles/TransferPlusStyles.xaml"/>
        </ResourceDictionary.MergedDictionaries>
        ...
    </ResourceDictionary>
</Window.Resources>
```

#### ¿Por qué falla este mecanismo en Revit?
1. **Contexto de Proceso No-WPF Nativo:** Autodesk Revit es una aplicación C++ Win32 nativa. Cuando carga add-ins .NET, el entorno de ejecución no inicializa el ciclo de vida estándar de una `System.Windows.Application` independiente. A menudo `Application.Current` es nulo o no tiene mapeado el esquema de recursos ensamblados de los add-ins de terceros cargados dinámicamente.
2. **Fallo de Resolución de Pack URIs para Diccionarios:** Cuando el parser XAML intenta resolver la autoridad `pack://application:,,,/` para cargar un archivo `.xaml` externo de estilos como `ResourceDictionary`, la llamada interna a `Application.LoadComponent` o `Application.GetResourceStream` falla y dispara `System.Windows.Markup.XamlParseException` ("Se produjo una excepción al establecer la propiedad 'System.Windows.ResourceDictionary.Source'").
3. **Contaminación de Recursos BAML:** En `TransferPlus.csproj`, las carpetas de empaquetado (`Deploy/` y `TransferPlusPublishPackage/`) no estaban excluidas por defecto en la búsqueda de elementos XAML. Al compilar, MSBuild rastreaba esas carpetas secundarias e incrustaba decenas de entradas duplicadas en la tabla de recursos `TransferPlus.g.resources`.

---

## 2. ¿Por qué este error NO ocurre en FilterPlus?

Al inspeccionar minuciosamente el código fuente de `FilterPlus` (`FilterPlus/Views/SelectionFilterView.xaml`):
```xaml
<Window.Resources>
    <BooleanToVisibilityConverter x:Key="BoolToVis"/>
    <converters:EnumToBoolConverter x:Key="EnumToBool"/>
    <sys:Double x:Key="{x:Static SystemParameters.VerticalScrollBarWidthKey}">10</sys:Double>
    
    <Style TargetType="TextBlock">
        ...
    </Style>
    <Style TargetType="ComboBox">
        ...
    </Style>
    <Style TargetType="Button">
        ...
    </Style>
    <Style x:Key="HeaderIconButtonStyle" TargetType="Button">
        ...
    </Style>
    <Style x:Key="SwitchStyle" TargetType="{x:Type CheckBox}">
        ...
    </Style>
</Window.Resources>
```

### Diferencias Clave:
- **Cero referencias externas:** `FilterPlus` **NO** utiliza `<ResourceDictionary Source="pack://..."/>` ni `MergedDictionaries`.
- **Definición Inline 100%:** Todos los estilos globales, converters y estilos con clave (`SwitchStyle`, `HeaderIconButtonStyle`, `CheckboxTreeTemplate`) están declarados de forma nativa e inline dentro de `<Window.Resources>`.
- **Resolución Inmediata en Memoria:** Al llamar a `InitializeComponent()`, WPF analiza y crea todos los estilos en el propio árbol de objetos de la ventana sin depender de peticiones URI al host de Revit. Por esta razón, `FilterPlus` siempre se abre al instante sin errores de recursos.

---

## 3. Plan de Acción Propuesto

El plan sigue la arquitectura contrastada y probada de `FilterPlus`:

### Paso 1: Inyectar estilos inline en TransferPlusView.xaml
- Incorporar el namespace del sistema en la cabecera:
  `xmlns:sys="clr-namespace:System;assembly=mscorlib"`
- Eliminar el bloque `<ResourceDictionary.MergedDictionaries>` y la etiqueta externa `<ResourceDictionary Source="pack://application:,,,/TransferPlus;component/Resources/Styles/TransferPlusStyles.xaml"/>`.
- Trasladar directamente a `<Window.Resources>` de `TransferPlusView.xaml`:
  - Dimensiones de scrollbars: `SystemParameters.VerticalScrollBarWidthKey` y `HorizontalScrollBarHeightKey`.
  - Estilos globales: `TextBlock`, `Button`, `TextBox`, `ComboBox`.
  - Estilos específicos: `HeaderIconButtonStyle` (botones de colapsar/expandir árbol) y `SwitchStyle` (estilo toggle switch para todos los checkboxes).
  - Conservar los converters y plantillas ya existentes (`BoolToVis`, `NegativeConverter`, `CheckboxTreeTemplate`, `CardBorderStyle`, `FilterPlusTextBlockStyle`, etc.).

### Paso 2: Limpieza de archivos redundantes
- Eliminar la carpeta `TransferPlus/Resources/Styles/` y el archivo `TransferPlusStyles.xaml`, eliminando cualquier riesgo de carga duplicada o desincronizada.

### Paso 3: Configuración limpia en TransferPlus.csproj
- Añadir en `<PropertyGroup>` de `TransferPlus.csproj`:
  ```xml
  <DefaultItemExcludes>$(DefaultItemExcludes);Deploy\**;TransferPlusPublishPackage\**</DefaultItemExcludes>
  ```
  Esto garantiza que MSBuild no indexe archivos XAML ni recursos dentro de las carpetas de publicación y bundles.

### Paso 4: Compilación, despliegue y verificación técnica
- Ejecutar limpieza de `bin/` y `obj/`.
- Compilar `TransferPlus` en configuración `Debug.R24` con `/p:DeployAddin=true` para actualizar el DLL directamente en la carpeta de Add-ins de Revit 2024.
- Compilar `Release.R24`.
- Inspeccionar el manifiesto con script de recursos (`check_baml.ps1`) para certificar que `TransferPlus.g.resources` contiene únicamente las vistas válidas y que no hay referencias rotas a diccionarios externos.
- Actualizar el paquete bundle con `build-bundle.ps1`.

---

## 4. Plan de Verificación

### Verificación Automática:
- Inspección de `TransferPlus.g.resources`: verificar que no existe ninguna referencia a `transferplusstyles.baml` y que todas las vistas BAML son únicas.
- Compilación `dotnet build` limpia con 0 errores.

### Verificación en Revit:
- Lanzar Autodesk Revit 2024.
- Abrir un modelo y hacer clic en el botón **TransferPlus**.
- Confirmar que la ventana principal de `TransferPlus` se abre inmediatamente con todos los estilos (tarjetas, botones con esquinas redondeadas, switches de checkbox y botones de expandir/colapsar) renderizados con total normalidad y sin ningún cuadro de diálogo de error.
