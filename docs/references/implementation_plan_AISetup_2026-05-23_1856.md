# Plan de Implementación - Integración de Arquitectura de IA y Estandarización de Conocimiento

Este plan detalla el proceso técnico para integrar la arquitectura optimizada de IA de la industria y **actualizar exhaustivamente las guías maestras del repositorio** (`AGENTS.md`, `.agents/skills/create-skill/SKILL.md` y `.agents/skills/workspace-ops/SKILL.md`). El objetivo es estandarizar la creación de skills, el guardado de assets, fragmentos de código, y la documentación sistemática de nuevos problemas resueltos para su reutilización cruzada.

## User Review Required

> [!IMPORTANT]
> **Estandarización del Guardado de Conocimiento y Debugging:**
> Ampliaremos las reglas de guardado para que, cada vez que se solucione un error de la API de Revit o un bug complejo (debugging), la IA documente la lección aprendida en un archivo físico bajo la ruta `.agents/skills/[skill-name]/references/debugging_[keywords]_[YYYY-MM-DD].md`. Esto previene que el conocimiento se pierda entre conversaciones y permite al agente consultar resoluciones pasadas en tareas similares.

---

## Proposed Changes

A continuación se detallan los cambios y nuevos archivos organizados por componentes:

### Component: Core Repository Documentation

#### [MODIFY] [AGENTS.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/AGENTS.md)
*   **Actualización de la Sección #7 (Artifact Backup):** Reescribir por completo la sección para detallar:
    1.  **Dónde se guardan los assets de código:** Carpeta `.agents/skills/[skill-name]/assets/` con archivos de extensión nativa C# (`.cs`) o XML (`.csproj`, `.wxs`) en lugar de bloques inline.
    2.  **Dónde se guardan las lecciones de depuración (debugging):** Carpeta `.agents/skills/[skill-name]/references/` bajo la nomenclatura `debugging_[problema]_[YYYY-MM-DD].md`.
    3.  **Cómo referenciar conocimiento cruzado:** Uso de links Markdown relativos legibles para el compilador `build.ps1`.

#### [NEW] [AI_INSTRUCTIONS.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/AI_INSTRUCTIONS.md)
*   **Mapa Maestro del Cerebro de IA:** Documento raíz de la topología `.agents/`, instruyendo a Google Antigravity y Project IDX sobre cómo leer las reglas modulares y los flujos de prompts antes de actuar.

#### [NEW] [dev.nix](file:///b:/REVIT/C%23/RevitAddins_Workspace/.idx/dev.nix)
*   **Entorno IDX:** Configuración nativa del contenedor de Project IDX con el SDK de .NET 8, paquetes y herramientas NuGet recomendadas, y scripts automáticos de inicialización.

---

### Component: `.agents/skills/` (Instrucciones Maestras de Skills)

#### [MODIFY] [SKILL.md (create-skill)](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/create-skill/SKILL.md)
*   **Actualización de Flujos y Checklist:** 
    1.  Cambiar todas las referencias de ruta de `skills/` a `.agents/skills/` (plural).
    2.  Actualizar el **Paso 5 (Add mandatory directories)** detallando la estructura modular exacta.
    3.  Añadir una sección obligatoria de **"Preservación de Debugging y Errores Resueltos"**, que enseñe al agente a crear reportes de fallos solucionados en `references/` para enriquecer la memoria a largo plazo del repositorio.

#### [MODIFY] [SKILL.md (workspace-ops)](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/workspace-ops/SKILL.md)
*   Asegurar que todas las llamadas de validación y de comandos se alinien con la ruta `.agents/skills/`.

---

### Component: `.agents/prompts/` & `.agents/agents/` (Flujos de Trabajo)

#### [NEW] [review-addin.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/prompts/review-addin.md)
*   **Prompt de Revisión:** Flujo paso a paso para auditoría de código Revit.

#### [NEW] [new-command.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/prompts/new-command.md)
*   **Prompt de Andamiaje:** Flujo paso a paso para la creación de comandos `IExternalCommand` respetando el hilo de ejecución de Revit.

#### [NEW] [ui-expert.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/agents/ui-expert.md)
*   **Prompt Especialista:** Instrucciones de rol para desarrollo de interfaz WPF/MVVM en Revit.

---

### Component: `hooks/` (Red de Seguridad)

#### [NEW] [pre-commit.ps1](file:///b:/REVIT/C%23/RevitAddins_Workspace/hooks/pre-commit.ps1)
*   Script PowerShell para formatear código (`dotnet format`), compilar el add-in y comprobar la consistencia de directorios de IA antes de realizar un commit de Git.

---

## Verification Plan

### Automated Tests
- Ejecutar la suite de compilación de skills usando el validador del repositorio para confirmar que la frontmatter y el formato de los nuevos skills, agentes y carpetas de prompts siguen siendo 100% correctos:
  ```powershell
  pwsh agentic-workflows/dotnet-msbuild/build.ps1
  ```

### Manual Verification
- Comprobar que el archivo `AI_INSTRUCTIONS.md`, `AGENTS.md` y `create-skill/SKILL.md` están perfectamente sincronizados y enlazan mutuamente a las carpetas y convenciones físicas.
