# Procedimiento de Inspección de Código y Escenarios de Documentación

Este documento detalla las fases para la extracción de información técnica directamente del código fuente y los procedimientos de actuación del agente según el estado de la documentación en el proyecto.

---

## 1. Fase de Inspección Automática (Extracción de la Verdad)

Antes de realizar cambios o interactuar con el usuario, el agente debe inspeccionar el repositorio para recopilar los siguientes metadatos objetivos:

### A. Versión del Proyecto:
1.  Ejecuta `git describe --tags --abbrev=0` para leer la versión oficial actual (Tag de Git).
2.  Si falla o no hay etiquetas, lee el archivo `Properties/AssemblyInfo.cs` para extraer el valor del atributo `[assembly: AssemblyVersion("...")]`.
3.  Si no existe, lee el archivo `.csproj` para buscar las etiquetas XML `<Version>` o `<AssemblyVersion>`.

### B. Identidad del Add-in:
1.  Analiza el manifiesto `.addin` (Revit Manifest) para recuperar el `AddInId` (GUID), `FullClassName` y el `Text` que se muestra en la interfaz gráfica de Revit.

### C. Detección de Funcionalidades (Features):
1.  Busca y analiza todas las clases que implementen la interfaz `IExternalCommand` para identificar los comandos disponibles y deducir sus acciones a partir de los nombres y comentarios de código.

---

## 2. Flujo de Trabajo por Escenarios

### Escenario A: Si la Carpeta de Documentación `/docs` NO Existe
1.  **Creación**: Crea una carpeta con nombre `/docs` en la raíz del proyecto.
2.  **Generación Base**: Crea el archivo `User_Guide.md` conforme al estándar establecido.
3.  **Contenido Inicial**: Rellena automáticamente el documento utilizando la información técnica extraída en la **Fase de Inspección Automática**.

### Escenario B: Si el Documento `User_Guide.md` YA Existe
1.  **Comparación de Versión**: Compara la versión extraída de Git o el código con la última versión documentada en el historial del archivo.
2.  **Actualización Silenciosa**:
    *   Si la versión del código es superior a la registrada en el documento, actualiza el encabezado del archivo.
    *   **Generación de Changelog**: Ejecuta el comando `git log [ultimo_tag]..HEAD --oneline` para recuperar el listado de commits y agrupar los cambios realizados bajo las secciones **Added** (Añadido), **Changed** (Modificado) o **Fixed** (Corregido).
    *   Registra una nueva entrada en el historial de versiones con la fecha actual y la lista formateada.
    *   Si se detectan nuevas clases de comandos C# sin documentación, agrégalas a la sección de la guía de comandos con la etiqueta `[PENDIENTE: Descripción funcional]`.

---

## 3. Criterios de Interrupción (Intervención Mínima)

El agente debe trabajar de forma 100% autónoma y silenciosa. Solo solicitará asistencia del desarrollador en estos tres casos extremos:
1.  No se detecta ningún archivo `.csproj` o manifiesto `.addin` en el workspace.
2.  Se detecta una clase de comando nueva pero no hay pistas o comentarios suficientes en el código para deducir su funcionalidad.
3.  La información crítica de soporte o contacto del desarrollador está completamente ausente en todo el proyecto.
