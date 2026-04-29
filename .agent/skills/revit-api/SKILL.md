---
name: Revit API Master
description: Instrucciones estrictas para desarrollar Add-ins de Revit en C#. Úsalo siempre que modifiques o crees código relacionado con la API de Autodesk Revit.
---

# Instrucciones de Código C# Estrictas
* Siempre usa C# 12. Usa 'Primary Constructors' en los ViewModels.
* Nunca uses `#region`. Mantén las clases pequeñas.
* Siempre inyecta dependencias a través del constructor, nunca instancies servicios directamente dentro de un Command.

# Versionado y Sincronización con Git
* **Versión Única:** La verdad sobre la versión del Add-in reside en los **Tags de Git**.
* **Sincronización:** Cada vez que se prepare una compilación o un instalador, el Agente DEBE sincronizar el tag de git (`git describe --tags --abbrev=0`) con la etiqueta `<Version>` del archivo `.csproj`.
* **Consistencia:** No permitas discrepancias entre la versión del instalador, la versión del ensamblado y la etiqueta de git.

# Instrucciones sobre la API de Revit
* Cuando busques elementos en el modelo con `FilteredElementCollector`, SIEMPRE prioriza filtros rápidos (QuickFilters) como `OfCategory()` antes que filtros lentos como literales de parámetros.
* Nunca intentes modificar la UI de Revit (Ribbon) fuera del evento `OnStartup` de la aplicación.
* Toda modificación al modelo debe estar envuelta en un bloque `Transaction`.

# Flujo de Ejecución para el Agente
1. Cuando el usuario te pida crear un nuevo Add-in, tu primer paso DEBE ser ejecutar `dotnet new revit -n [Nombre]`.
2. Tu segundo paso DEBE ser reestructurar las carpetas `/UI` a `/Views` y `/ViewModels` según los estándares de MVVM.
3. Cada vez que crees, iteres o modifiques un add-in, DEBES copiar los artefactos generados (Implementation Plan, Task y Walkthrough) a una carpeta llamada `_Development_Logs/[YYYY-MM-DD]_[NombreDelAddin]_[Accion]` en la raíz del workspace. Esto servirá como historial de consulta futura para debugging y entendimiento del código.