---
name: revit-addin-icon-manager
description: Automates the replacement of default icons in Revit projects with custom images, managing .csproj resources and C# code injection. Use this when you need to update or configure Ribbon UI icons for a Revit add-in.
---

# Revit Add-in Icon Manager (v2.0)

Este skill automatiza la integración de iconos personalizados en add-ins de Revit, gestionando la preparación del archivo físico, la modificación del archivo XML `.csproj` del proyecto y la inyección de código C# de forma autónoma.

## 📚 Referencias Técnicas (Knowledge Base)
Para obtener especificaciones técnicas detalladas y flujos de ejecución, consulta los archivos en la carpeta `references/`:

*   `references/icon_loading_strategy.md`: Diagnóstico activo del entorno, organización por tamaños de imagen, esquemas de compilación de recursos en el proyecto `.csproj` y compatibilidad con pantallas de DPI variable y Temas Oscuros (Revit 2024+).

## 📦 Assets (Plantillas y Ejemplos de Código C#)
Los siguientes archivos se encuentran en la carpeta `assets/` y pueden inyectarse como helpers reusables:

*   `assets/GetImageSource.cs`: Clase estática en C# y método utilitario para cargar y resolver imágenes desde la memoria del ensamblado incrustado utilizando la sintaxis de URIs `pack://application`.