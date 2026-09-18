# Walkthrough: Reubicación a Pestaña Add-Ins (Complementos) y Actualización de Configuración

Se ha implementado con éxito la corrección para la directriz de Autodesk App Store relativa a pestañas personalizadas (*#Custom tab*):

> Para add-ins de un solo comando, las directrices de Autodesk estipulan que el comando debe ubicarse por defecto en la pestaña nativa de **Add-Ins** (`Complementos`), en lugar de crear una pestaña propia con el nombre del add-in o de la empresa.

---

## 🛠️ Cambios Realizados

### 1. Refactorización Integral a `AddInsDefaultTab`
- **[FilterPlusSettings.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/FilterPlusSettings.cs)**:
  - Se actualizó el enum `TabOption` renombrando la opción por defecto a `AddInsDefaultTab`.
  - Se añadió retrocompatibilidad declarando `[XmlEnum("DBDevDefault")] DBDevDefault` marcado como `[Obsolete]` para garantizar que cualquier archivo `settings.xml` preexistente se lea sin error.
  - La propiedad `SelectedTabOption` se inicializa por defecto en `TabOption.AddInsDefaultTab`.
- **[SettingsService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Services/SettingsService.cs)**:
  - En `Load()`, se normaliza automáticamente cualquier configuración previa que contenga `DBDevDefault` convirtiéndola a `AddInsDefaultTab`.

### 2. Creación del Ribbon en la Pestaña Add-Ins
- **[Application.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Application.cs)**:
  - En el método `CreateRibbon()`, la rama por defecto ejecuta:
    ```csharp
    panel = Application.CreatePanel("FilterPlus");
    ```
    lo cual en la API de Revit sitúa el panel `FilterPlus` directamente dentro de la pestaña nativa de **Complementos (Add-Ins)**.

### 3. Actualización de la Ventana de Configuración
- **[ConfigurationView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/ConfigurationView.xaml)**:
  - **Opción 1**:
    `Place FilterPlus on Add-Ins tab (default)`
    vinculado a `IsAddInsDefaultTabSelected`.
  - **Opción 2**:
    `Place on Revit contextual tab`
    vinculado a `IsRevitDefaultSelected` (mantiene la lógica de pestaña contextual "Modify").
  - **Opción 3**:
    `Place on tab named:`
    vinculado a `IsCustomSelected` con el cuadro de texto editable intacto.
- **[ConfigurationViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/ConfigurationViewModel.cs)**:
  - Renombrada la propiedad a `IsAddInsDefaultTabSelected`.
  - En el constructor se evalúa `_originalSettings.SelectedTabOption == TabOption.AddInsDefaultTab || _originalSettings.SelectedTabOption == TabOption.DBDevDefault`.
  - En `Save()` se almacena `TabOption.AddInsDefaultTab`.

---

## 🔍 Verificación Realizada

| Componente | Estado | Detalle |
|---|---|---|
| **Compilación Multi-versión (R23-R27)** | ✅ Exitoso | `Release.R23` a `Release.R27` compilados y publicados limpiamente con 0 errores. |
| **Generación del Bundle de Producción** | ✅ Generado | [FilterPlus.bundle.zip](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/FilterPlusPublishPackage/FilterPlus.bundle.zip) y [Deploy/FilterPlus_v1.6.0.zip](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Deploy/FilterPlus_v1.6.0.zip) actualizados con los nuevos binarios de producción. |
| **Instalación Local en Revit (Debug)** | ✅ Desplegado | `FilterPlus.dll` (753 KB) desplegado en `%APPDATA%\Autodesk\Revit\Addins\2024\FilterPlus\` y `2023\FilterPlus\` con ventana de Debug Log activa. |
| **Carga por Defecto en Complementos** | ✅ Verificado | `Application.CreatePanel("FilterPlus")` asigna el panel a la pestaña nativa de Add-Ins. |
