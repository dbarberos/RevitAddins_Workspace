# Plan de Implementación: Creación del Instalador MSI Multi-Versión

Este plan detalla la configuración del instalador MSI para FilterPlus, cubriendo desde la compilación masiva hasta la generación de los archivos de WiX Toolset.

## Detalles del Instalador
- **Nombre:** FilterPlus
- **Fabricante:** DabaDev
- **Versiones Soportadas:** 2023, 2024, 2025, 2026, 2027
- **Licencia:** MIT (Libre uso y modificación con atribución al autor), en Inglés.

## Componentes Realizados
- **Compilación Masiva:** Ejecutada para todas las configuraciones Release (R23-R27).
- **Correcciones de Compatibilidad:**
  - Ajuste de `ElementId.Value` vs `ElementId.IntegerValue` para Revit 2023.
  - Ajuste de firma `RegisterContextMenu` para Revit 2025+.
- **Estructura WiX:** Generación de `Product.wxs` con mapeo de directorios multi-versión.
- **Recursos:** Creación de `License.rtf` (MIT License).

## Verificación
- El usuario debe compilar el proyecto WiX en Visual Studio siguiendo los pasos detallados en el Walkthrough.
