# Plan de Implementación: Ventana de Configuración y Ubicación en el Ribbon

Añadir un engranaje de configuración en la interfaz principal que permita al usuario decidir en qué pestaña de Revit (Ribbon) debe aparecer el icono de FilterPlus, además de permitir su uso en el menú contextual.

> [!WARNING]
> **Limitación Importante de la API de Revit sobre el Menú Contextual**
> El acceso al **Menú Contextual (clic derecho en la pantalla)** se añadió de forma oficial en la API de **Revit 2025**. Para Revit 2024 y versiones anteriores, **no existe API oficial** para añadir comandos al menú contextual. 
> Por lo tanto, añadiremos el Checkbox de "Use FilterPlus as Contextual Filter", pero a nivel de código lo protegeremos para que solo se ejecute y registre el menú si el usuario compila y ejecuta el addin en **Revit 2025 o superior** (`#if REVIT2025_OR_GREATER`). En Revit 2024, el checkbox existirá pero la función no se aplicará debido a las restricciones de Autodesk.

## User Review Required

1. **Revit 2024 vs 2025**: ¿Estás de acuerdo con añadir la funcionalidad del menú contextual sabiendo que internamente solo funcionará para usuarios con Revit 2025 o superior? (En Revit 2024 simplemente no se registrará el menú para evitar fallos).

## Proposed Changes

### 1. Sistema de Configuración (Settings)
- **[NEW]** `Services/SettingsService.cs`: Clase encargada de guardar y leer la configuración en `%AppData%\FilterPlus\settings.json`.
- **[NEW]** `Models/FilterPlusSettings.cs`: Modelo de datos (Enum `TabOption`, string `CustomTabName`, bool `UseAsContextualFilter`).

### 2. Interfaz de Configuración (UI)
- **[NEW]** `Views/ConfigurationView.xaml`: 
  - Título "Tab Option"
  - 3 RadioButtons (DBDev, Revit default tab, Custom).
  - Input de texto para Custom.
  - Checkbox "Use FilterPlus as Contextual Filter" debajo de las opciones.
  - Texto con asterisco: "* You must restart Revit in order to apply these changes".
  - Botones "Save" y "Cancel".
- **[NEW]** `ViewModels/ConfigurationViewModel.cs`: Lógica MVVM para la vista de configuración.

### 3. Modificación de la Interfaz Principal
- **[MODIFY]** `Views/SelectionFilterView.xaml`: Añadir un botón con un icono de engranaje (⚙️) a la derecha del botón "Clear".
- **[MODIFY]** `ViewModels/SelectionFilterViewModel.cs`: `OpenConfigurationCommand` para mostrar la `ConfigurationView`.

### 4. Modificación del Ribbon y Menú Contextual (Arranque)
- **[MODIFY]** `Application.cs`: Actualizar `OnStartup()` para leer la configuración.
  - Ubicación en `Tab.Modify` de Revit si se elige "Revit default tab".
  - Registrar un `IContextMenuCreator` (solo si `#if REVIT2025_OR_GREATER`) si el booleano `UseAsContextualFilter` es true.
- **[NEW]** `Commands/FilterContextMenuCreator.cs`: (Solo Revit 2025+) Implementa `IContextMenuCreator` para añadir el comando de FilterPlus al hacer clic derecho en Revit.

## Verification Plan
1. Compilar el add-in para `R24` (Verificar que no da error aunque no use el menú contextual).
2. Compilar el add-in para `R25` (Verificar que registra el menú contextual si se activa).
3. Validar el funcionamiento de guardar/cargar configuración.
