# Walkthrough: Corrección de Incidencias Autodesk App Store en FilterPlus (Revit 2023)

Se han corregido y validado con éxito las dos primeras incidencias señaladas por el equipo de revisión de Autodesk App Store sobre el paquete bundle de **FilterPlus**:

1. **Resource folder in 2023 bundle**: Ausencia de la carpeta de recursos de ayuda F1 en el bundle de Revit 2023.
2. **Revit logo in App UI of Revit 2023**: Visualización del logotipo de Autodesk Revit en la cabecera de la UI en la versión 2023.

---

## 🛠️ Cambios Realizados

### 1. Compatibilidad Multi-versión (Revit 2023 vs Revit 2024+)
- **[SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)**:
  - Se añadieron directivas condicionales `#if REVIT2024_OR_GREATER` para gestionar la diferencia entre la API de 64 bits (`ElementId.Value` en Revit 2024+) y la API de 32 bits (`ElementId.IntegerValue` en Revit 2023).
  - Se corrigieron los constructores de `ElementId` evitando el casteo explícito `(long)` en Revit 2023.
  - Se adaptó `ElementIdEqualityComparer` para usar `IntegerValue` en Revit 2023 y `Value` en Revit 2024+.
  - **Resultado**: `Release.R23` y `Debug.R23` compilan limpiamente con **0 errores**.

### 2. Garantía de Copia de Recursos de Ayuda F1 (`help.html`)
- **[FilterPlus.csproj](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/FilterPlus.csproj)**:
  - Se actualizó el elemento `<None Update="Resources\help.html">` a `<Content Include="Resources\**\*"><CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory></Content>` para asegurar que MSBuild copie la carpeta `Resources` completa en todos los targets.
- **[Application.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Application.cs)**:
  - Se implementó un algoritmo resiliente de localización de `help.html` que verifica rutas locales (`Resources/help.html`, `Resources/Help.html`), relativas a la raíz del bundle (`../Resources/help.html`, `../Resources/Help.html`) y alias (`Resource/help.html`).

### 3. Icono Propio en la UI y Eliminación del Logo de Revit
- Al compilar con los fuentes actualizados que contienen `Icon="pack://application:,,,/FilterPlus;component/Resources/Icons/RibbonIcon32.png"` en todas las vistas WPF, `FilterPlus.dll` para Revit 2023 ahora incluye el icono de embudo azul personalizado en la barra de título, eliminando por completo la herencia del icono "R" de Revit.

### 4. Automatización del Debug Log Local vs Producción
- **[SelectionFilterView.xaml.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml.cs)**:
  - Se protegió la inicialización de `LogView` bajo directivas `#if DEBUG`:
    ```csharp
#if DEBUG
    private LogView _logView;
#endif
    ...
#if DEBUG
    _logView = new LogView();
    _logView.Show();
    this.Closed += (s, e) => _logView?.Close();
#endif
    ```
  - **Versión de Producción (Bundle)**: No ejecuta ni compila la ventana de logs.
  - **Versión Local (Debug en Revit)**: Abre automáticamente la ventana de `LogView` en tiempo real al lanzar el add-in.

### 5. Script de Empaquetado Bundle (`build-bundle.ps1`)
- **[build-bundle.ps1](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-appstore-bundle/scripts/build-bundle.ps1)**:
  - Se agregó `"2023"` en `$TargetYears`: `@("2023", "2024", "2025", "2026", "2027")`.
  - Se implementó selección de candidatos binarios ordenada por fecha de modificación (`LastWriteTime -Descending`), evitando arrastrar carpetas obsoletas.
  - Se garantiza la copia explícita de `Resources\help.html` y `Help.html` (y alias `Resource\help.html`) dentro de cada carpeta de versión (`Contents/2023/`, `Contents/2024/`, etc.) y en la raíz `Contents/Resources/`.

---

## 🔍 Verificación Realizada

| Validación | Resultado | Detalle |
|---|---|---|
| **Compilación Release (2023-2027)** | ✅ Exitoso (0 errores) | Todas las 5 versiones compilaron y publicaron limpiamente. |
| **Presencia de `Resources` en 2023** | ✅ Exitoso | `Contents/2023/Resources/help.html` y alias `Resource/help.html` verificados en el bundle. |
| **Icono embebido en 2023 (`RibbonIcon32`)** | ✅ Verificado | `findstr /m "RibbonIcon32"` positivo en `Contents/2023/FilterPlus.dll` (730 KB). |
| **Paquetes Bundle generados** | ✅ Generados | [FilterPlus.bundle.zip](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/FilterPlusPublishPackage/FilterPlus.bundle.zip) y en `FilterPlus/Deploy/`. |
| **Instalación Local en Revit (Debug)** | ✅ Desplegado | Binarios `Debug.R24` y `Debug.R23` (752 KB) desplegados con `LogView` activo en `%APPDATA%\Autodesk\Revit\Addins\2024\FilterPlus` y `2023\FilterPlus`. |
