# Plan de Implementación: Reubicación a Pestaña "Add-Ins" (AddInsDefaultTab) y Actualización de UI de Configuración

Este plan resuelve la tercera indicación recibida del equipo de revisión de Autodesk App Store:

> **#Custom tab**
> "The app currently loads under a custom ribbon tab. Please note that custom tabs are generally permitted only when:
> - An app contains multiple commands that need to be grouped together, or
> - A publisher has multiple applications and wants to group them under a single company-branded tab.
> In your case, the app contains only a single command, and the custom tab is named after the application rather than your company. Please move the command to the Add-Ins tab."

---

## 🎯 Requisitos y Objetivos

1. **Ubicación por defecto en Add-Ins (Complementos)**:
   Al iniciar Revit, FilterPlus debe situarse por defecto en la pestaña nativa de **Add-Ins** (`Complementos`), cumpliendo con la directiva de Autodesk para add-ins de un solo comando.
2. **Refactorización de nombres a `AddInsDefaultTab`**:
   Para eliminar deuda técnica y garantizar trazabilidad futura, se renombra la opción y todas sus referencias en código (`DBDevDefault` -> `AddInsDefaultTab`).
3. **Actualización de la UI de Configuración (`ConfigurationView.xaml`)**:
   Dentro de la tarjeta *"Tab Option (*)"*:
   - **Opción 1**:
     `Place FilterPlus on Add-Ins tab (default)`
     vinculada a `IsAddInsDefaultTabSelected`.
   - **Opción 2**:
     `Place on Revit contextual tab`
     vinculada a `IsRevitDefaultSelected` (mantiene la lógica de pestaña contextual "Modify").
   - **Opción 3**:
     `Place on tab named:`
     vinculada a `IsCustomSelected` con cuadro de texto editable.
4. **Compatibilidad hacia atrás con `settings.xml` existente**:
   Se normaliza en `SettingsService.Load()` cualquier valor antiguo `DBDevDefault` para convertirlo a `AddInsDefaultTab` de forma transparente.
5. **Actualización de Entornos**:
   - Reempaquetar el bundle de producción (.zip) para Autodesk App Store.
   - Recompilar y desplegar la versión `Debug` en el Revit local del desarrollador (con la ventana de Debug Log activa).
6. **Persistencia de Conocimiento**:
   Almacenar los artefactos de plan y walkthrough en `FilterPlus/docs/references/` bajo la convención de nombres estándar.

---

## Proposed Changes

### Componente 1: Modelo de Configuración y Retrocompatibilidad

#### [MODIFY] [FilterPlusSettings.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/FilterPlusSettings.cs)
- Actualizar el enum `TabOption`:
  ```csharp
  public enum TabOption
  {
      [XmlEnum("AddInsDefaultTab")]
      AddInsDefaultTab,

      [Obsolete("Use AddInsDefaultTab instead.")]
      [XmlEnum("DBDevDefault")]
      DBDevDefault,

      [XmlEnum("RevitDefault")]
      RevitDefault,

      [XmlEnum("Custom")]
      Custom
  }
  ```
- Asignar `SelectedTabOption = TabOption.AddInsDefaultTab;` como valor inicial en `FilterPlusSettings`.

#### [MODIFY] [SettingsService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Services/SettingsService.cs)
- En `SettingsService.Load()`, normalizar automáticamente si `settings.SelectedTabOption == TabOption.DBDevDefault` a `TabOption.AddInsDefaultTab`.

---

### Componente 2: Creación del Ribbon en Arranque

#### [MODIFY] [Application.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Application.cs)
- En `CreateRibbon()`:
  - Si la opción seleccionada es `AddInsDefaultTab` o el fallback `else`, llamar a `Application.CreatePanel("FilterPlus");` (sin segundo argumento `tabName`), situando el botón en la pestaña nativa de **Add-Ins (Complementos)**.

---

### Componente 3: Interfaz Gráfica y ViewModel de Configuración

#### [MODIFY] [ConfigurationView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/ConfigurationView.xaml)
- Línea 68: Reemplazar `"Place FilterPlus on DBDev tab(default)"` por `"Place FilterPlus on Add-Ins tab (default)"`. Vincular a `IsAddInsDefaultTabSelected`.
- Línea 69: Reemplazar `"Place on Revit default tab"` por `"Place on Revit contextual tab"`. Vincular a `IsRevitDefaultSelected`.
- Línea 70: Mantener `"Place on tab named:"` vinculado a `IsCustomSelected`.

#### [MODIFY] [ConfigurationViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/ConfigurationViewModel.cs)
- Reemplazar la propiedad `IsDBDevSelected` por `IsAddInsDefaultTabSelected`.
- En el constructor:
  `IsAddInsDefaultTabSelected = _originalSettings.SelectedTabOption == TabOption.AddInsDefaultTab || _originalSettings.SelectedTabOption == TabOption.DBDevDefault;`
- En el método `Save(Window window)`:
  Asignar `selectedOption = TabOption.AddInsDefaultTab` por defecto cuando `IsAddInsDefaultTabSelected` esté activo.

---

### Componente 4: Compilación y Despliegue

1. **Revit Local (Debug)**:
   - Compilar `Debug.R24` y `Debug.R23` con `DeployAddin=true` hacia `%APPDATA%\Autodesk\Revit\Addins\2024\FilterPlus` y `2023\FilterPlus` (con `#if DEBUG` activo para mostrar la ventana de Debug Log).
2. **Producción (Release Bundle)**:
   - Compilar y publicar `Release.R23`, `Release.R24`, `Release.R25`, `Release.R26`, `Release.R27`.
   - Ejecutar `build-bundle.ps1` para generar el paquete [FilterPlus.bundle.zip](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/FilterPlusPublishPackage/FilterPlus.bundle.zip) y en `Deploy/`.

---

## Verification Plan

### Automated / Build Verification
- Compilar sin advertencias ni errores todas las configuraciones Release y Debug:
  `dotnet build .\FilterPlus\FilterPlus.csproj -c Release.R23`
  `dotnet build .\FilterPlus\FilterPlus.csproj -c Release.R24`
  `dotnet build .\FilterPlus\FilterPlus.csproj -c Debug.R24 /p:DeployAddin=true`
- Ejecutar `build-bundle.ps1` y confirmar la sincronización del bundle.

### Manual Verification
- Iniciar Revit y verificar:
  1. El panel **FilterPlus** aparece automáticamente dentro de la pestaña nativa de **Complementos (Add-Ins)**.
  2. Al pulsar el icono de engranaje (Configuración), la tarjeta *"Tab Option (*)"* muestra:
     - `(•) Place FilterPlus on Add-Ins tab (default)` (seleccionado por defecto).
     - `( ) Place on Revit contextual tab`.
     - `( ) Place on tab named: [   ]`.
  3. Al guardar cambios y reiniciar Revit, se respeta la pestaña configurada.
