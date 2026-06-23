# Implementation Plan: Revit AppStore Bundle Skill

Este plan detalla la creación de un nuevo *skill* (`revit-appstore-bundle`) para automatizar la generación del paquete `.bundle` requerido por Autodesk App Store. Esto estandarizará el proceso para futuras subidas y actualizaciones.

## 1. Estructura del Nuevo Skill

Se creará la siguiente estructura de carpetas bajo `.agents/skills/revit-appstore-bundle/`:

- `SKILL.md`: Índice y metadatos del skill.
- `assets/PackageContents.xml`: Plantilla base requerida por Autodesk que define las versiones soportadas de Revit, el punto de entrada (el archivo `.addin`), y la información del desarrollador.
- `scripts/build-bundle.ps1`: Script de automatización en PowerShell que creará la carpeta `[AppName].bundle`, inyectará el `PackageContents.xml` configurado, y copiará las DLLs compiladas y el archivo `.addin` en las subcarpetas de versión correctas (ej. `Contents/2024/`).
- `references/autodesk_bundle_guide.md`: Pequeña guía con las reglas de Autodesk para la estructura del bundle.

## 2. Archivos a Generar

### `SKILL.md`
Contendrá el frontmatter de YAML necesario:
```yaml
name: revit-appstore-bundle
description: Generates the Autodesk App Store .bundle folder structure and PackageContents.xml for Revit addins. Use when preparing a plugin for the Autodesk App Store marketplace.
```
Y las instrucciones de cómo el agente debe usar el script de PowerShell para empaquetar el add-in.

### `assets/PackageContents.xml` (Template)
Se creará un XML base compatible con el formato `Autodesk.appstore` que soportará Revit 2023, 2024, 2025, 2026 y 2027 utilizando la sintaxis de SeriesMax y SeriesMin.

### `scripts/build-bundle.ps1`
Un script ejecutable que tomará como parámetros:
- Nombre del Add-in (ej. `FilterPlus`)
- Versión (ej. `1.1.0`)
- Ruta de origen de los archivos compilados (`bin/Release.R24/`)

El script se encargará de:
1. Crear la carpeta `FilterPlus.bundle`.
2. Crear la subcarpeta `FilterPlus.bundle/Contents/2024/`.
3. Copiar `FilterPlus.dll`, `CommunityToolkit.Mvvm.dll` y `FilterPlus.addin` a la subcarpeta de versión.
4. Generar y rellenar el `PackageContents.xml` en la raíz del bundle.

## 3. Ejecución del Skill (Post-Creación)
Una vez creado el skill, lo ejecutaremos inmediatamente para generar el paquete `.bundle` de `FilterPlus`, comprimirlo en `.zip` y dejarlo listo para que lo subas al Autodesk App Store.

> [!IMPORTANT]
> **User Review Required: Metadatos del XML**
> El archivo `PackageContents.xml` requiere tu ID de desarrollador de Autodesk (Author / AppDomain). Por defecto, usaré `DBDev_dbarberos` y tu email. ¿Hay algún otro ID específico o "AppId" de Autodesk que deba insertar en el XML, o usamos unos identificadores genéricos que tú puedas editar luego?

Por favor, aprueba este plan para proceder con la creación del skill y la automatización del bundle.
