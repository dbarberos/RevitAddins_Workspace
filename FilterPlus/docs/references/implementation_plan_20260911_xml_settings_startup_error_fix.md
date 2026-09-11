# Plan de Implementación: Corrección de Error XML (3, 54) y Resiliencia en Carga de Configuración

## Contexto y Diagnóstico del Problema

Al iniciar Autodesk Revit tras instalar la versión actualizada de FilterPlus, se disparó una ventana emergente modal bloqueante:
`"FilterPlus Error: An error occurred in Loading Settings: Error en el documento XML (3, 54). Check Debug Log for details."`

### Causa Raíz
1. **Exclusión de Miembros Enum con `[Obsolete]` en `XmlSerializer`**:
   El enum `TabOption` en `FilterPlusSettings.cs` tenía marcado el valor previo con `[Obsolete("Use AddInsDefaultTab instead.")]`. En .NET Framework 4.8, `XmlReflectionImporter` omite los miembros con `[Obsolete]` del esquema de serialización/deserialización. Cuando `XmlSerializer` intentó leer el archivo local del usuario conteniendo `<SelectedTabOption>DBDevDefault</SelectedTabOption>`, lanzó `InvalidOperationException: 'DBDevDefault' no es un valor válido para TabOption`.
2. **Ventana Emergente Invasiva en Inicio (`IExternalApplication.OnStartup()`)**:
   `SettingsService.Load()` capturaba la excepción y ejecutaba `LoggerService.LogError()`, mostrando un `MessageBox` modal que congelaba el arranque de Revit hasta ser aceptado.

---

## Cambios a Implementar

### 1. Modelo de Configuración (`FilterPlus/Models/FilterPlusSettings.cs`)
- Retirar el atributo `[Obsolete]` del enum `DBDevDefault`, preservando `[XmlEnum("DBDevDefault")]` para que `XmlSerializer` pueda deserializar limpiamente configuraciones heredadas existentes.

### 2. Servicio de Configuración (`FilterPlus/Services/SettingsService.cs`)
- **Migración transparente**: Al deserializar, si `SelectedTabOption == TabOption.DBDevDefault`, convertir en memoria a `TabOption.AddInsDefaultTab` y guardar inmediatamente el archivo normalizado.
- **Liberación de archivos**: Cerrar el stream de lectura antes de cualquier operación de escritura.
- **Arranque no bloqueante**: Sustituir llamadas a `LogError` con `LogWarning`. Ante cualquier archivo corrupto o inválido, cargar la configuración por defecto y sobreescribir con un archivo válido sin mostrar ventanas modales en Revit.

### 3. Servicio de Registro (`FilterPlus/Services/LoggerService.cs`)
- Implementar `LogWarning(string message)` para diagnósticos silenciosos en log y UI sin popups.
- Añadir el parámetro opcional `showDialog = true` en `LogError()`.

### 4. Compilación y Despliegue
- **Local (Debug)**: Compilar y desplegar `Debug.R24` y `Debug.R23` en `%APPDATA%\Autodesk\Revit\Addins\...` con `#if DEBUG` y ventana `LogView`.
- **Producción (Release)**: Compilar `Release.R23` a `Release.R27` y re-ejecutar `build-bundle.ps1` para actualizar `FilterPlus.bundle.zip`.

---

## Verificación
- Carga de settings en caliente mediante reflexión en PowerShell demostrando que `SelectedTabOption` se resuelve como `AddInsDefaultTab`.
- Verificación del archivo `%APPDATA%\FilterPlus\settings.xml` actualizado en disco.
- Generación exitosa de los zips del bundle en `Deploy/` y `FilterPlusPublishPackage/`.
