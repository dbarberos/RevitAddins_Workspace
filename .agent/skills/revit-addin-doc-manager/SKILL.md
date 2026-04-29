---
name: revit-addin-auto-doc-manager
description: Gestión autónoma de documentación y versionado para Add-ins de Revit mediante inspección de archivos técnicos.
---

# Revit Add-in Documentation Skill (Versión Autónoma)

## Objetivo
Este skill permite al agente administrar el ciclo de vida de la documentación del Add-in con intervención humana mínima. El agente debe actuar como un documentador técnico que extrae la verdad directamente del código y los archivos de configuración del proyecto.

## 1. Fase de Inspección Automática (Extracción de Datos)
Antes de realizar cualquier acción o preguntar al usuario, el agente DEBE intentar extraer los siguientes datos:

* **Versión del Proyecto:** 1. Buscar en `Properties/AssemblyInfo.cs` el atributo `[assembly: AssemblyVersion("...")]`.
    2. Si no existe, buscar en el archivo `.csproj` la etiqueta `<Version>` o `<AssemblyVersion>`.
* **Identidad del Add-in:** 1. Leer el archivo `.addin` (Manifiesto de Revit) para obtener el `AddInId`, el `FullClassName` y el `Text` (nombre que aparece en la cinta de opciones).
* **Detección de Funcionalidades:** 1. Analizar las clases que heredan de `IExternalCommand` para identificar nuevos botones o comandos añadidos desde la última revisión.

## 2. Instrucciones de Operación

### Escenario A: Si no existe la carpeta de documentación
1.  **Creación:** Crear una carpeta llamada `/docs` en la raíz del proyecto.
2.  **Generación Base:** Crear el archivo `Guia_Uso.md` siguiendo la estructura técnica de Autodesk (Referencia: AppID 4005291581487532621).
3.  **Contenido Inicial:** Rellenar automáticamente con los datos extraídos en la Fase 1.

### Escenario B: Si el documento ya existe
1.  **Comparación de Versiones:** Comparar la versión extraída del código con la última versión registrada en la guía.
2.  **Actualización Silenciosa:** * Si la versión del código es mayor, actualizar el encabezado de la guía.
    * Añadir una nueva entrada en la sección `# Historial de Cambios` con la fecha actual y la nueva versión.
    * Si se detectan nuevas clases de comandos, añadir secciones de "Uso" para esos comandos con el marcador `[PENDIENTE: Descripción funcional]`.

## 3. Interacción con el Usuario (Mínima Necesaria)
El agente solo interrumpirá al usuario si:
1.  No se encuentra ningún archivo `.csproj` o `.addin` en el directorio.
2.  El agente detecta una nueva funcionalidad pero no puede deducir su propósito mediante el nombre de la clase o los comentarios del código.
3.  Falta información de contacto o soporte que no está en el código.

## 4. Estructura Requerida del Documento (`Guia_Uso.md`)
El documento generado debe seguir este orden estricto:

1.  **Título del Add-in:** (Extraído del archivo .addin).
2.  **Versión Actual:** (Extraída de AssemblyInfo o .csproj).
3.  **Descripción General:** Propósito del Add-in.
4.  **Instrucciones de Instalación:** Basadas en la ubicación de los archivos `.bundle` o `.msi`.
5.  **Guía de Comandos:**
    * Listado de botones en el Ribbon de Revit.
    * Explicación técnica de cada comando (`FullClassName`).
6.  **Historial de Versiones (Changelog):**
    * `## [Versión X.X.X] - YYYY-MM-DD`
    * Listado automático de: **Añadido**, **Cambiado** o **Corregido**.

## 5. Reglas de Formato
* Utilizar Markdown profesional.
* Tablas para datos técnicos (ID de cliente, Versiones de Revit soportadas).
* Bloques de advertencia para requisitos del sistema (ej. "Requiere Revit 2021 o superior").