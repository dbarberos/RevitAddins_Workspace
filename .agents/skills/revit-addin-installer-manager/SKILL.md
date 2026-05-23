---
name: revit-addin-installer-manager
description: Automates the creation of professional MSI installers for multi-version Revit Add-ins (2023-2027) using WiX Toolset v3.11+. Use this when preparing a deployment package, updating installer versions, or generating WXS scripts.
---

# Revit Add-in Installer Manager (WiX Toolset Automation)

Este skill guía al agente en la automatización de la creación de instaladores profesionales en formato `.msi` para add-ins multi-versión de Revit, gestionando el empaquetado de recursos de forma robusta e independiente de Visual Studio.

## 📚 Referencias Técnicas (Knowledge Base)
Para obtener especificaciones teóricas y guías de validación de Windows Installer, consulta los archivos en la carpeta `references/`:

*   `references/wix_toolset_architecture.md`: Explicación de cómo es posible crear archivos `.msi` y compilar proyectos de C# sin utilizar Visual Studio (desmitificando el rol del IDE y permitiendo flujos de CI/CD).
*   `references/wxs_golden_rules.md`: Reglas de oro obligatorias para escribir archivos XML `.wxs` robustos, previniendo errores de validación de Windows Installer (ICE38 y ICE64) en instalaciones en AppData.

## 📦 Assets (Plantillas y Ejemplos de Configuración de Instalador)
Los siguientes archivos se encuentran en la carpeta `assets/` y pueden inyectarse o utilizarse como guía en los proyectos:

*   `assets/ProductTemplate.wxs`: Plantilla XML base estructurada para empaquetado de add-ins multi-versión (Revit 2024 y 2025) con componentes de limpieza e IDs únicos.
*   `assets/LicenseTemplate.rtf`: Archivo base en formato de Texto Enriquecido (RTF) para el Acuerdo de Licencia de Usuario Final (EULA) que se muestra en la interfaz del instalador.