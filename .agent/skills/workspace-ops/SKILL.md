---
name: workspace-ops
description: Instrucciones de infraestructura del repositorio RevitAddins_Workspace — build de skills, validación de frontmatter y gestión de plugins. Úsalo cuando necesites mantener o validar la estructura de skills y plugins del workspace.
---

# Workspace Operations — Infraestructura del Repositorio

> Estas instrucciones fueron originalmente parte de `AGENTS.md` y se extrajeron aquí para mantener el archivo principal enfocado en la generación de add-ins de Revit. Este skill preserva el conocimiento operativo sobre la infraestructura del workspace.

## 1. Estructura de Plugins

Este repositorio contiene skill plugins bajo `plugins/`. Cada subdirectorio en `plugins/` es un plugin independiente (ej. `plugins/dotnet-msbuild`, `plugins/dotnet`).

## 2. Build de Skills

Cuando modifiques skills, ejecuta el script de build de agentic-workflows para validar y regenerar artefactos compilados:

```powershell
pwsh agentic-workflows/<plugin>/build.ps1
```

Esto valida el frontmatter de cada skill y recompila los archivos de lock de conocimiento. **Siempre haz commit de los lock files regenerados junto con tus cambios.**

## 3. Skill-Validator

> No importa mucho la retro-compatibilidad para esta herramienta. Los consumidores entienden que la forma cambia constantemente.

El skill-validator es una herramienta de distribución — su paquete NuGet y archivos `.tar.gz` se construyen desde `eng/skill-validator/src/`.

### Reglas de Contenido
- El contenido referenciado en tiempo de ejecución o empaquetado con la herramienta (docs, README, etc.) **debe vivir bajo `src/`** para que se incluya en la salida publicada.
- **No añadir** referencias desde `src/` a archivos fuera de él, excepto para assets de empaquetamiento explícitamente vinculados (como el archivo `LICENSE` de la raíz del repositorio) referenciados por el archivo de proyecto.

### Sincronización de Documentación
Cuando modifiques:
- El pipeline de evaluación (`evaluation.yml`)
- El esquema JSON de resultados (`Models.cs`)
- La lógica de evaluación del skill-validator

**DEBES revisar y actualizar** `eng/skill-validator/src/docs/InvestigatingResults.md` para mantener sincronizada la guía de investigación de fallos, la documentación del esquema y los scripts de ejemplo.

## 4. Cuándo Usar Este Skill
- Al crear o modificar skills en la carpeta `.agent/skills/`
- Al actualizar plugins bajo `plugins/`
- Al depurar problemas de compilación del skill-validator
- Al necesitar regenerar lock files tras cambios en el frontmatter de skills
