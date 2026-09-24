# Walkthrough: Corrección de Ubicación de Pestaña Add-Ins y Reempaquetado del Bundle (Revit 2025 y 2026)

**Fecha:** 24 de Septiembre de 2026  
**Add-in:** FilterPlus v1.7.0  
**Objetivo:** Resolver la observación del evaluador de Autodesk App Store ("Application Still Loading Under Custom Tab in Autodesk Revit 2025 and 2026").  
**Rama Git:** `FilterPlus`  
**Estándar:** `AGENTS.md` (Sección 7 - Artifact Backup y `revit-appstore-bundle`)

---

## 1. Diagnóstico y Causa Raíz

El evaluador de Autodesk App Store reportó:
> *"During testing, I observed that the application is still loading under a custom ribbon tab [DBDev] in Autodesk Revit 2025 and 2026. As previously requested, please update the application so that the command loads under the appropriate Add-Ins tab instead of creating a separate custom tab."*

### Causa Identificada:
1. **Binarios Desactualizados en el Paquete Publicado:**
   - Aunque el código fuente de `Application.cs` se había actualizado el 11 de Septiembre para usar `panel = Application.CreatePanel("FilterPlus")` (pestaña nativa de Complementos), los subdirectorios `bin/Release.R25` y `bin/Release.R26` conservaban binarios antiguos del **10 de Mayo de 2026**.
   - El script de empaquetado `build-bundle.ps1` no forzaba la recompilación limpia si detectaba que la carpeta `publish` ya existía, empaquetando por error los binarios de Mayo de 2026 que contenían la propiedad obsoleta `IsDBDevSelected` y creaban la pestaña `DBDev`.
2. **Instrucciones en `Steps.md`:**
   - El documento `FilterPlus/FilterPlusPublishPackage/Steps.md` aún indicaba en el paso 4.3 *"Confirm that the DBDev tab appears in the ribbon"*.

---

## 2. Modificaciones Implementadas

### A. Mejora en `FilterPlus/Application.cs`
- Se reforzó el método `CreateRibbon()`:
  - La opción por defecto (`AddInsDefaultTab`) ejecuta invariablemente:
    ```csharp
    panel = Application.CreatePanel("FilterPlus");
    ```
    lo cual en la API de Autodesk Revit ubica el panel directamente en la pestaña nativa **Add-Ins (Complementos)**.
  - Se blindó la opción `CustomTab` para verificar la existencia previa de la pestaña y crearla de forma segura solo si el usuario configuró explícitamente una pestaña personalizada válida.

### B. Automatización y Forzado de Recompilación en `build-bundle.ps1`
- **Archivo:** `.agents/skills/revit-appstore-bundle/scripts/build-bundle.ps1`
- Se agregó el switch `-Rebuild` (activo por defecto).
- Antes de copiar los binarios a `Contents/202X/`, el script limpia la carpeta `bin/Release.R$Year` y ejecuta una compilación fresca:
  ```powershell
  dotnet publish $Csproj -c $ConfigName /p:DeployAddin=false --verbosity minimal
  ```
  Esto previene que sesiones activas de Revit bloqueen archivos locales en `%AppData%` y asegura que nunca se empaqueten binarios antiguos.

### C. Actualización de Documentación de Entrega en `Steps.md`
- **Archivo:** `FilterPlus/FilterPlusPublishPackage/Steps.md`
- Se actualizó la versión a **v1.7.0**.
- Se corrigió la instrucción de prueba local para verificar que el panel aparezca en la pestaña **Add-Ins (Complementos)**.

---

## 3. Verificación de Binarios y Validación

Se ejecutó un escaneo binario sobre todos los ensamblados empaquetados en `FilterPlus.bundle/Contents/`:

| Versión Revit | Hash / Timestamp de Compilación | Presencia de `IsDBDevSelected` / `DBDev` Tab | Ubicación en Revit |
| :---: | :---: | :---: | :---: |
| **Revit 2023** | 2026-09-24 18:00:23 | **False** (Limpio) | Pestaña **Add-Ins** |
| **Revit 2024** | 2026-09-24 18:00:34 | **False** (Limpio) | Pestaña **Add-Ins** |
| **Revit 2025** | 2026-09-24 18:00:44 | **False** (Limpio) | Pestaña **Add-Ins** |
| **Revit 2026** | 2026-09-24 18:00:56 | **False** (Limpio) | Pestaña **Add-Ins** |
| **Revit 2027** | 2026-09-24 18:01:08 | **False** (Limpio) | Pestaña **Add-Ins** |

### Paquetes Generados Listos para Envío:
- `B:\REVIT\C#\RevitAddins_Workspace\FilterPlus\FilterPlusPublishPackage\FilterPlus.bundle.zip`
- `B:\REVIT\C#\RevitAddins_Workspace\FilterPlus\Deploy\FilterPlus_v1.7.0.zip`
- `PackageContents.xml` validado con series `R2023` a `R2027`.
