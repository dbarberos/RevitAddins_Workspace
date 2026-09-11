# Plan de Implementación: TransferPlus en Pestaña Add-Ins, UI de Configuración y Resiliencia de Ajustes XML

**Fecha:** 2026-09-11  
**Componente:** TransferPlus  
**Autor:** DBDev_dbarberos (DBDev Solutions)  
**Entorno:** Autodesk Revit 2024–2027 (.NET Framework 4.8 / .NET 8)

---

## 🎯 Objetivos y Requisitos

1. **Ubicación por Defecto en Pestaña Add-Ins**:
   - En `Application.cs`, el panel `TransferPlus` se crea por defecto dentro de la pestaña nativa de **Complementos (Add-Ins)** con `Application.CreatePanel("TransferPlus")` para cumplir con las directrices de la tienda Autodesk App Store para add-ins de comando único.
   - Mantener soporte para ubicación en pestaña Gestionar/Manage y pestañas personalizadas si el usuario lo elige.

2. **Actualización de la Tarjeta "Tab Option (*)" en la Ventana de Configuración**:
   - En `ConfigurationView.xaml`:
     - **Opción 1**: `Place TransferPlus on Add-Ins tab (default)` vinculado a `IsAddInsDefaultTabSelected`.
     - **Opción 2**: `Place on Revit Manage tab` vinculado a `IsRevitDefaultSelected`.
     - **Opción 3**: `Place on tab named:` vinculado a `IsCustomSelected` con el cuadro de texto editable.
   - En `ConfigurationViewModel.cs`:
     - Renombrar la propiedad observable a `IsAddInsDefaultTabSelected`.
     - En el constructor, verificar `SelectedTabOption == TabOption.AddInsDefaultTab || SelectedTabOption == TabOption.DBDevDefault`.
     - En el comando `Save()`, asignar `TabOption.AddInsDefaultTab`.

3. **Lógica de Ubicación en Pestaña Gestionar/Manage (Grupo Configuración)**:
   - Al seleccionar la opción **Place on Revit Manage tab**, TransferPlus busca el panel nativo **Configuración** (`Settings`) dentro de la pestaña **Gestionar** (`Manage`) vía AdWindows (`Autodesk.Windows.ComponentManager.RibbonControl`).
   - Localiza el elemento nativo **"Configuración adicional"** (`Additional Settings` / `AdditionalSettings`) dentro de la colección de ítems del panel.
   - Inserta el botón de TransferPlus **inmediatamente a su derecha** (`items.Insert(index + 1, newButton)`), garantizando su ubicación exacta junto a las herramientas de configuración del proyecto.

4. **Prevención y Solución del Bug de Deserialización XML (`DBDevDefault`)**:
   - En `TransferPlusSettings.cs`:
     - Declarar explícitamente en el enum `TabOption`:
       ```csharp
       [XmlEnum("AddInsDefaultTab")]
       AddInsDefaultTab,

       [XmlEnum("DBDevDefault")]
       DBDevDefault,

       [XmlEnum("RevitDefault")]
       RevitDefault,

       [XmlEnum("Custom")]
       Custom
       ```
     - **CRÍTICO:** NO añadir el atributo `[Obsolete]` a `DBDevDefault`, ya que en .NET Framework 4.8 `XmlReflectionImporter` ignora miembros obsoletos provocando `InvalidOperationException: Instance validation error: 'DBDevDefault' is not a valid value for TabOption`.
   - En `SettingsService.cs`:
     - Migración automática: si al deserializar se detecta `SelectedTabOption == TabOption.DBDevDefault`, se actualiza en memoria a `TabOption.AddInsDefaultTab` y se guarda en disco.
     - Silenciamiento y resiliencia: reemplazar cualquier llamada modal bloqueante por advertencias diagnósticas en `LoggerService.LogWarning()`. Si el archivo está corrupto, se genera un fallback seguro a `new TransferPlusSettings()` sin mostrar cuadros de diálogo que congelen el arranque de Revit.

5. **Soporte de Ayuda Contextual F1 en Ribbon**:
   - Configurar `ContextualHelp` en el botón principal apuntando a `help.html` para una experiencia homogénea con FilterPlus.

---

## 🛠️ Cambios Realizados

### Componente 1: Modelo de Configuración y Migración XML
* **`TransferPlusSettings.cs`**:
  - Añadido `AddInsDefaultTab = 0` como valor por defecto.
  - Conservado `DBDevDefault = 1` con `[XmlEnum("DBDevDefault")]` sin `[Obsolete]`.
  - Asignado `SelectedTabOption = TabOption.AddInsDefaultTab`.

* **`SettingsService.cs`**:
  - Implementada auto-migración de `DBDevDefault` a `AddInsDefaultTab`.
  - Manejo de excepciones en `Load()` y `Save()` con advertencias (`LogWarning`) y fallback seguro sin diálogos modales.

### Componente 2: Interfaz y Lógica de Configuración (UI / MVVM)
* **`ConfigurationView.xaml`**:
  - Actualizados los tres RadioButtons en el bloque `Tab Option (*)`:
    - `Place TransferPlus on Add-Ins tab (default)`
    - `Place on Revit Manage tab`
    - `Place on tab named:`

* **`ConfigurationViewModel.cs`**:
  - Actualizada propiedad observable a `IsAddInsDefaultTabSelected`.
  - Conectada la lectura y guardado al nuevo enum `AddInsDefaultTab`.

### Componente 3: Creación de Ribbon en Revit
* **`Application.cs`**:
  - En `TryAddButtonToNativeSettingsPanel()`:
    - Búsqueda de la posición del botón "Configuración adicional" (`Additional Settings` / `AdditionalSettings`) e inserción del botón justo después de él (`items.Insert(targetIndex + 1, newButton)`).
  - En `CreateRibbon()`:
    - Si es `RevitDefault`, invocar `TryAddButtonToNativeSettingsPanel()` para integrarlo a la derecha de Configuración adicional en Manage.
    - Si es `Custom` con nombre no vacío, crear/usar pestaña personalizada.
    - Por defecto (`AddInsDefaultTab` o fallback), crear panel en la pestaña nativa de **Complementos (Add-Ins)** con `Application.CreatePanel("TransferPlus")`.
  - Inyectar `ContextualHelp` hacia `help.html` en el botón principal.

---

## 🔍 Verificación Realizada
1. **Prueba de Compatibilidad XML**: Ejecutado `test_transferplus_xml.ps1`, deserializando exitosamente XML con `DBDevDefault` y verificando migración automática a `AddInsDefaultTab`.
2. **Compilaciones**:
   - `Debug.R24` con despliegue local exitoso.
   - `Release.R24`, `Release.R25`, `Release.R26`, `Release.R27` compilados con 0 errores.
3. **Empaquetado**:
   - Generado `TransferPlus_v1.2.0.zip` y `TransferPlus.bundle.zip` mediante `build-bundle.ps1`.
4. **Documentación**:
   - Sincronizados `User_Guide.md`, `help.html` y walkthrough de cambios.
