# Walkthrough: Corrección de Incidencias Autodesk App Store en TransferPlus (Revit 2023)

Se han corregido y validado con éxito las incidencias señaladas por el equipo de revisión de Autodesk App Store sobre el paquete bundle de **TransferPlus**:

1. **Resource folder in 2023 bundle**: Ausencia de la carpeta de recursos de ayuda F1 en el bundle de Revit 2023.
2. **Revit logo in App UI of Revit 2023**: Visualización del logotipo de Autodesk Revit en la cabecera de la UI en la versión 2023 en lugar del icono propio de la aplicación.
3. **Inclusión de todos los archivos necesarios en la carpeta Resources de todas las versiones**: Asegurar la presencia de todos los recursos (imágenes, hojas de estilo, iconos, `help.html`, `Help.html`) en `Contents/202X/Resources/`, `Contents/202X/Resource/` y en `Contents/Resources/`.

---

## 🛠️ Cambios Realizados

### 1. Compatibilidad Multi-versión (Revit 2023 vs Revit 2024+)
- **[ElementIdExtensions.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Extensions/ElementIdExtensions.cs)**:
  - Creada clase de extensión que unifica el acceso al identificador numérico entre la API de 64 bits (`ElementId.Value` en Revit 2024+) y la API de 32 bits (`ElementId.IntegerValue` en Revit 2023) mediante el método `GetIdValue()`.
- **Adaptación en Servicios y Modelos**:
  - Reemplazadas todas las llamadas directas `.Id.Value` por `.Id.GetIdValue()` en `TransferOrchestrator.cs`, `DocumentCollector.cs`, `FamilyRevitService.cs`, `CadInstanceProvider.cs`, `DetailGroupProvider.cs`, `CadThumbnailService.cs`, `CadDeleteCandidateModel.cs` y `TransferPlusViewModel.cs`.
- **Protección de APIs exclusivas de Revit 2024+**:
  - En `TransferOrchestrator.cs`, se protegió el bloque de `RevitLinkGraphicsSettings` y `GetLinkOverrides` / `SetLinkOverrides` con `#if REVIT2024_OR_GREATER ... #endif`, manteniendo en 2023 la sincronización nativa de ocultación de vínculos ya existente (`srcLink.IsHidden` y `targetView.HideElements`).
  - **Resultado**: `Release.R23` y `Debug.R23` compilan limpiamente con **0 errores**.

### 2. Garantía de Copia de Recursos F1 y Assets de Ayuda
- **[TransferPlus.csproj](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/TransferPlus.csproj)**:
  - Se actualizó el elemento `<None Update="Resources\help.html">` a `<Content Include="Resources\**\*"><CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory></Content>` para asegurar que MSBuild copie la carpeta `Resources` completa con todas las imágenes de ayuda y estilos en todos los targets.
- **[build-bundle.ps1](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-appstore-bundle/scripts/build-bundle.ps1)**:
  - Se mejoró la copia para transferir de manera recursiva la carpeta completa `Resources\*` tanto a `Contents/$Year/Resources/`, como a `Contents/$Year/Resource/` (alias singular) y a `Contents/Resources/` en la raíz del bundle.
  - Se garantiza la presencia dual `help.html` y `Help.html` (mayúscula y minúscula) en todas las ubicaciones.

### 3. Icono Propio en la UI y Eliminación del Logo de Revit
- Al compilar con los fuentes actualizados que contienen `Icon="pack://application:,,,/TransferPlus;component/Resources/Icons/TransferPlus32x32.png"` en todas las vistas WPF, `TransferPlus.dll` para Revit 2023 ahora incluye el icono personalizado embebido en la barra de título, eliminando por completo la herencia del icono "R" de Revit.

---

## 🔍 Verificación Realizada

| Validación | Resultado | Detalle |
|---|---|---|
| **Compilación Release (2023-2027)** | ✅ Exitoso (0 errores) | Las 5 versiones compilaron y publicaron limpiamente (`Release.R23`, `R24`, `R25`, `R26`, `R27`). |
| **Presencia de `Resources` en 2023** | ✅ Exitoso | `Contents/2023/Resources/help.html` y alias `Resource/help.html` verificados en el bundle con todos sus assets (`Icons`, `Styles`, `Screenshots`, imágenes JPG). |
| **Presencia de `Resources` en 2024-2027** | ✅ Exitoso | Todas las subcarpetas de versión contienen sus carpetas `Resources` y `Resource` completas. |
| **Icono embebido en 2023 (`TransferPlus32x32`)** | ✅ Verificado | `findstr /m "TransferPlus32x32"` positivo en `Contents/2023/TransferPlus.dll` (1.37 MB). |
| **Paquetes Bundle generados** | ✅ Generados | [TransferPlus_v1.3.0.zip](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Deploy/TransferPlus_v1.3.0.zip) (70.1 MB) y en `TransferPlusPublishPackage/TransferPlus.bundle.zip`. |
