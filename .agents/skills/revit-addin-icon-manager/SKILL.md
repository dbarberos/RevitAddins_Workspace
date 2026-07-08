---
name: revit-addin-icon-manager
description: Automates the replacement of default icons in Revit projects with custom images, managing .csproj resources and C# code injection. Use this when you need to update or configure Ribbon UI icons for a Revit add-in.
---

# Revit Add-in Icon Manager (v2.0)

This skill automates the integration of custom icons into Revit add-ins, autonomously managing physical file preparation, project `.csproj` XML file modification, and C# code injection.

## 📚 Technical References (Knowledge Base)
For detailed technical specifications and execution flows, consult the files in the `references/` folder:

*   `references/icon_loading_strategy.md`: Active environment diagnosis, image size organization, resource compilation schemes in the `.csproj` project, and compatibility with variable DPI screens and Dark Themes (Revit 2024+).
*   `references/debugging_wpf_icon_baml_exception_2026-07-07.md`: Resolving startup BAML / TypeConverterMarkupExtension crashes inside external Revit hosts by enforcing absolute pack URIs in WPF window titles.

## 📦 Assets (Templates and C# Code Examples)
The following files are located in the `assets/` folder and can be injected as reusable helpers:

*   `assets/GetImageSource.cs`: Static C# class and utility method to load and resolve images from the embedded assembly memory using the `pack://application` URI syntax.