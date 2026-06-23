---
name: revit-addin-doc-manager
description: Autonomous management of documentation and versioning for Revit Add-ins through technical file inspection. Use this when generating a user guide, creating a changelog, or updating project documentation based on git tags and source code.
---

# Revit Add-in Documentation Skill (Autonomous Version)

Este skill permite al agente gestionar el ciclo de vida de la documentación del add-in con autonomía, extrayendo la verdad técnica directamente del código fuente y los archivos de configuración del proyecto.

## 🚨 Reglas Críticas Obligatorias
1. **Idioma Inglés:** Toda la información generada y volcada en el `User_Guide.md` (o documentos similares) **DEBE estar redactada en inglés**.
2. **Contexto Histórico y Artefactos:** Para documentar cómo usar las opciones y features, el agente NO debe limitarse a mirar los commits. **Debe leer obligatoriamente los archivos `.md` de los artefactos** (ej. en `docs/references/`) para extraer las funcionalidades, usos y evolución de cada opción.
3. **Actualización Completa:** El manual debe actualizarse en todos sus puntos desde su origen hasta la versión actual. Si una función previa ha sido modificada, la guía de uso principal debe reescribirse para reflejar su estado en el nuevo tag, usando el contexto previo de los artefactos.
4. **Estructura Amable y Legible (UX Textual):** El "Comprehensive Usage Guide" o secciones de descripción deben estructurarse usando viñetas (bulletpoints), subsecciones claras y tablas para hacer la lectura muy amable y rápida. Deben evitarse los párrafos densos o "muros de texto".
5. **Estándar Autodesk App Store:** Toda la información sobre "Installation & Uninstallation" debe usar estrictamente el estándar de la Autodesk App Store (explicando que el instalador descargado ya hace el trabajo, el reinicio del producto Autodesk y el método de desinstalación desde el Panel de Control).

## 📚 Referencias Técnicas (Knowledge Base)
Para obtener guías y procedimientos de inspección de documentación, consulta los archivos en la carpeta `references/`:

*   `references/doc_extraction_and_scenarios.md`: Procesos de inspección automática de código y flujos lógicos por escenarios.

## 📦 Assets (Plantillas y Ejemplos de Documentación)
Los siguientes archivos se encuentran en la carpeta `assets/` y definen las plantillas a inyectar:

*   `assets/user_guide_template.md`: Estructura estándar y reglas de formato para el archivo `User_Guide.md` del add-in.