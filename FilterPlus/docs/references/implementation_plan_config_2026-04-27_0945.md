# Plan de Implementación: Ventana de Configuración y Ubicación en el Ribbon

Añadir un engranaje de configuración en la interfaz principal que permita al usuario decidir en qué pestaña de Revit (Ribbon) debe aparecer el icono de FilterPlus.

> [!WARNING]
> **Limitación Importante de la API de Revit**
> La API oficial de Revit requiere que las pestañas y botones del Ribbon se creen exclusivamente durante el evento `OnStartup` (cuando Revit arranca). **No es posible mover un botón de una pestaña a otra de forma dinámica mientras Revit está en ejecución sin usar librerías internas no documentadas (que suelen causar crashes)**. 
> Por lo tanto, cuando el usuario cambie la opción en esta nueva ventana de Configuración y pulse "Save", **el cambio se guardará, pero el usuario deberá reiniciar Revit para ver el icono en la nueva ubicación.**

## User Review Required

1. **Reinicio de Revit**: ¿Estás de acuerdo con mostrar un mensaje al usuario indicando que debe reiniciar Revit para que el cambio de pestaña surta efecto tras pulsar "Save"?
2. **Ubicación "Revit default tab"**: Mencionas *"mostrar el addin junto al icono de filtro que muestra revit en el ribbon oficial"*. El icono de filtro nativo de Revit aparece dinámicamente en la pestaña contextual múltiple o en la pestaña estándar "Modificar" (`Tab.Modify`). Ubicar nuestro botón *exactamente al lado* de un botón nativo específico es complejo y poco fiable en la API. Mi propuesta es colocar el panel "FilterPlus" dentro de la pestaña oficial `Tab.Modify` de Revit. ¿Te parece bien este enfoque?

## Proposed Changes

### 1. Sistema de Configuración (Settings)
- **[NEW]** `Services/SettingsService.cs`: Clase encargada de guardar y leer la configuración en un archivo `settings.json` dentro de `%AppData%\FilterPlus\`.
- **[NEW]** `Models/FilterPlusSettings.cs`: Modelo de datos para guardar la opción seleccionada (Ej: `TabOption` Enum y `CustomTabName` string).

### 2. Interfaz de Configuración (UI)
- **[NEW]** `Views/ConfigurationView.xaml`: Nueva ventana con el título "Tab Option", 3 RadioButtons (DBDev, Revit default, Custom) y un input de texto habilitado solo si se elige "Custom". Botones "Save" y "Cancel".
- **[NEW]** `ViewModels/ConfigurationViewModel.cs`: Lógica MVVM para gestionar la selección, enlazar los RadioButtons, comprobar si ha habido cambios y guardar a través del `SettingsService`.

### 3. Modificación de la Interfaz Principal
- **[MODIFY]** `Views/SelectionFilterView.xaml`: Añadir un botón con un icono de engranaje (⚙️) a la derecha del botón "Clear" en la fila del buscador.
- **[MODIFY]** `ViewModels/SelectionFilterViewModel.cs`: Añadir el `OpenConfigurationCommand` para instanciar y mostrar la `ConfigurationView` mediante `ShowDialog()`.

### 4. Modificación del Ribbon (Arranque)
- **[MODIFY]** `Application.cs`: Actualizar el método `OnStartup()` para que antes de crear el Ribbon, lea el archivo de configuración usando `SettingsService`. Dependiendo de la opción:
  - Opción 1: Crear en pestaña "DBDev".
  - Opción 2: Crear en la pestaña `Modify` de Revit usando la API nativa.
  - Opción 3: Crear en la pestaña personalizada cuyo nombre está en el JSON.

## Verification Plan
1. Compilar el add-in.
2. Comprobar que al pulsar el engranaje se abre la configuración.
3. Cambiar a "Custom" e introducir "MiPestaña". Pulsar Save.
4. Reiniciar Revit y verificar que el icono ahora está en "MiPestaña" y ya no en "DBDev".
