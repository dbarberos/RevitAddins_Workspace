# Plan de Actuación: Integración de Icono Personalizado en Ventanas WPF

Sustituir el icono genérico de Revit ("R") de las cabeceras de todas las ventanas principales y auxiliares por el icono propio del add-in `FilterPlus`.

## Análisis y Requisitos Técnicos

### 1. Formato y Tamaño del Icono
Para las barras de título de las ventanas en WPF (Windows OS), el estándar de resolución es **32x32 píxeles**. 
El proyecto ya cuenta con el recurso embebido `Resources/Icons/RibbonIcon32.png` (32x32 px con fondo transparente en formato PNG), el cual está compilado como **Resource** en el archivo `.csproj`:
```xml
<Resource Include="Resources\Icons\RibbonIcon32.png"/>
```
Dado que este archivo ya se encuentra en el ensamblado y su formato PNG con transparencias es ideal para el escalado DPI y temas de color (incluido el tema oscuro de Revit), **no es necesario añadir ningún archivo nuevo** ni cambiar formatos a `.ico`. Reutilizaremos `RibbonIcon32.png`.

### 2. Método de Carga en WPF
En WPF, cuando un recurso se compila con la acción `Resource`, puede referenciarse en el atributo `Icon` de las ventanas XAML mediante una URI relativa simple:
```xml
Icon="/Resources/Icons/RibbonIcon32.png"
```
Esto resuelve dinámicamente la carga de la imagen desde el ensamblado del addin sin dependencias de rutas físicas de disco.

---

## Cambios Propuestos

Modificaremos las 6 ventanas WPF del proyecto localizadas bajo la carpeta `Views` para incluir el atributo `Icon="/Resources/Icons/RibbonIcon32.png"` en su nodo raíz `<Window>`:

### 1. Ventana Principal
#### [MODIFY] [SelectionFilterView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml)
- Añadir `Icon="/Resources/Icons/RibbonIcon32.png"`.

### 2. Ventana de Pre-Selección
#### [MODIFY] [PreSelectionView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/PreSelectionView.xaml)
- Añadir `Icon="/Resources/Icons/RibbonIcon32.png"`.

### 3. Ventana de Guardado (Save Dialog)
#### [MODIFY] [SaveSelectionView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SaveSelectionView.xaml)
- Añadir `Icon="/Resources/Icons/RibbonIcon32.png"`.

### 4. Ventana de Selección de Modelos (Model Selection)
#### [MODIFY] [ModelSelectionView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/ModelSelectionView.xaml)
- Añadir `Icon="/Resources/Icons/RibbonIcon32.png"`.

### 5. Ventana de Configuración (Configuration)
#### [MODIFY] [ConfigurationView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/ConfigurationView.xaml)
- Añadir `Icon="/Resources/Icons/RibbonIcon32.png"`.

### 6. Ventana de Logs de Depuración (Log View)
#### [MODIFY] [LogView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/LogView.xaml)
- Añadir `Icon="/Resources/Icons/RibbonIcon32.png"`.

---

## Plan de Verificación

### Compilación y Prueba
1. Compilar el proyecto en modo de desarrollo (`dotnet build -c Debug.R24`).
2. Abrir Revit 2024 e iniciar el add-in `FilterPlus`.
3. Comprobar visualmente que la barra de título de la ventana principal y de todas las ventanas secundarias ("Filter Rules", "Save Selection", "Select model or models", "Configuration" y "FilterPlus Debug Log") muestran el icono de FilterPlus en vez del icono por defecto de Revit.
