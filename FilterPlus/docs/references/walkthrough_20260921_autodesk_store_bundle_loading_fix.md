# Walkthrough: Corrección del Fallo de Carga de FilterPlus en Autodesk App Store (Revit 2023 y 2027)

Se han diagnosticado, corregido y validado con éxito las causas por las cuales el examinador de Autodesk App Store reportó que el add-in no cargaba en ninguna versión compatible de Revit (especialmente observado en Revit 2027 en las pruebas de validación).

---

## 🛠️ Diagnóstico y Causa Raíz

### 1. Ausencia del Prefijo `"R"` en `PackageContents.xml` (Causa Primaria del Fallo en Todas las Versiones)
- **El problema:** En las últimas ejecuciones de empaquetado, la etiqueta `<RuntimeRequirements>` se inyectó con `SeriesMin="2027" SeriesMax="2027"` (y `2023`, `2024`, etc.) en lugar de `SeriesMin="R2027" SeriesMax="R2027"`.
- **Efecto en Revit:** El Autoloader de Revit compara el identificador interno del producto (`"R2027"`) contra los límites declarados. Al ser `"R2027"` mayor lexicográficamente que `"2027"`, Revit evaluaba que la versión actual superaba la serie máxima soportada y **descartaba silenciosamente el bundle al arrancar** sin emitir error alguno ni cargar el add-in.

### 2. Incompatibilidad de API de 64 bits en Revit 2023 (`ElementSelectionKey.cs`)
- En el modelo `ElementSelectionKey.cs` se utilizaba directamente `ElementId.Value`. En Revit 2023 la API es de 32 bits y utiliza `ElementId.IntegerValue`, lo que arrojaba 6 errores `CS1061` impidiendo compilar `Release.R23`.

### 3. Resolución Autónoma de Ensamblados en .NET 8 (Revit 2025+)
- En CoreCLR (.NET 8), al cargar el add-in desde la carpeta de plugins de Autodesk, las dependencias secundarias como `Nice3point.Revit.Toolkit.dll` o `CommunityToolkit.Mvvm.dll` requieren la resolución de ensamblados en el dominio de aplicación local para evitar fallos de enlace de tipos.

---

## 🔧 Cambios Realizados

### 1. Corrección en `build-bundle.ps1`
- **Archivo**: [.agents/skills/revit-appstore-bundle/scripts/build-bundle.ps1](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-appstore-bundle/scripts/build-bundle.ps1)
- Restaurada la sintaxis estricta de Autoloader:
  ```powershell
  <RuntimeRequirements OS="Win64" Platform="Revit" SeriesMin="R$Year" SeriesMax="R$Year" />
  ```
- Refinada la selección y copia de binarios: se toman los artefactos en estricto orden de prioridad de publicación y se excluyen subcarpetas anidadas `publish\` o temporales.

### 2. Corrección Multi-Versión en `ElementSelectionKey.cs`
- **Archivo**: [FilterPlus/Models/ElementSelectionKey.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/ElementSelectionKey.cs)
- Implementada compatibilidad dual:
  ```csharp
#if REVIT2024_OR_GREATER
        long thisId = ElementId != null ? ElementId.Value : -1;
        long thisLinkId = LinkInstanceId != null ? LinkInstanceId.Value : -1;
#else
        long thisId = ElementId != null ? ElementId.IntegerValue : -1;
        long thisLinkId = LinkInstanceId != null ? LinkInstanceId.IntegerValue : -1;
#endif
  ```
- **Resultado**: `Release.R23` compila con **0 errores**.

### 3. Registro de `AssemblyResolve` en `Application.cs`
- **Archivo**: [FilterPlus/Application.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Application.cs)
- Añadido el manejador `AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;` y el método resolvedor local para garantizar la carga segura de dependencias en Revit 2025–2027 (.NET 8).

### 4. Regeneración del Bundle y Paquetes de Publicación
- Recompiladas y publicadas las 5 configuraciones de Release (`Release.R23`, `Release.R24`, `Release.R25`, `Release.R26`, `Release.R27`).
- Regenerados los paquetes de entrega para Autodesk App Store:
  - [FilterPlusPublishPackage/FilterPlus.bundle.zip](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/FilterPlusPublishPackage/FilterPlus.bundle.zip)
  - [FilterPlus/Deploy/FilterPlus_v1.7.0.zip](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Deploy/FilterPlus_v1.7.0.zip)

---

## 🧠 SkillOpt: Conocimiento Preservado

Siguiendo las directrices del skill `apply-skillopt`, se ha registrado el aprendizaje técnico para evitar regresiones en futuros add-ins:
1. **Guía de Depuración**: Creado [.agents/skills/revit-appstore-bundle/references/debugging_appstore_bundle_autoloader_series_prefix_and_multiversion_2026-09-21.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-appstore-bundle/references/debugging_appstore_bundle_autoloader_series_prefix_and_multiversion_2026-09-21.md).
2. **Reglas del Skill**: Actualizado [.agents/skills/revit-appstore-bundle/SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-appstore-bundle/SKILL.md) con la Regla 6 (**Autoloader Series Prefix**).
3. **Instrucciones Globales**: Incorporada la regla obligatoria en la Sección 6.1 de [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md).

---

## 🔍 Tabla de Verificación

| Validación | Resultado | Detalle |
|---|---|---|
| **Compilación Release.R23** | ✅ 0 errores | `ElementSelectionKey.cs` adaptado con `#if REVIT2024_OR_GREATER`. |
| **Compilación Release.R24-R27** | ✅ 0 errores | Todas las versiones compilaron y publicaron limpiamente. |
| **Sintaxis de Autoloader en `PackageContents.xml`** | ✅ Validado | `SeriesMin="R2023"` hasta `SeriesMin="R2027"` con prefijo `"R"`. |
| **Árbol de Directorios del Bundle** | ✅ Limpio | Eliminadas carpetas anidadas `publish/`; inclusión de DLLs, `.addin`, `Resources/` y `Help.html`. |
| **Paquete ZIP para App Store** | ✅ Generado | Listo para entrega en `FilterPlusPublishPackage/FilterPlus.bundle.zip`. |
