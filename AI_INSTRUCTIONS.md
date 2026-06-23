# 🏗️ AI-Optimized Project Architecture (Google Antigravity & Project IDX)

**Contexto del Proyecto:** Desarrollo de Add-ins para Revit (C#, .NET 8 / .NET Framework 4.8) y Macros / Scripts (Python, pyRevit, RevitPythonShell).  
**Objetivo:** Establecer una arquitectura de Ingeniería de Prompts a nivel de repositorio (RAG Local) para maximizar la eficiencia del agente de IA, reducir el consumo de tokens y eliminar "alucinaciones" (uso de APIs deprecadas).

---

## 🧭 1. Filosofía de Trabajo (Para el Agente de IA)

Como asistente de IA en este proyecto, **NO debes asumir contexto global innecesario**. Tu conocimiento sobre cómo programar en este repositorio está totalmente segregado en módulos. 
Cuando el usuario te asigne una tarea en el chat, te proveerá de referencias explícitas (p. ej., `@skills/revit-addin-helpers.md` o `@prompts/new-command.md`). **Debes leer y aplicar estrictamente el contenido de esos archivos referenciados antes de generar cualquier código.**

---

## 📂 2. Estructura de Directorios AI-Aware (Topología Unificada)

El cerebro de IA del proyecto está centralizado bajo la carpeta `.agents/`, separando limpiamente el contexto de IA del código fuente del proyecto real:

```text
RevitAddins_Workspace/
├── .idx/
│   └── dev.nix                # ⚙️ [El Entorno] Configuración de Project IDX (SDKs y extensiones).
├── .agents/                   # 🧠 [Cerebro de IA] Directorio raíz de RAG local y contexto de IA
│   ├── AGENTS.md              # Reglas maestras del agente de Revit.
│   ├── prompts/               # 📋 [Comandos] Flujos de trabajo estandarizados (prompts reutilizables).
│   │   ├── new-command.md     # Pasos para andamiar un nuevo IExternalCommand (C# o script Python).
│   │   └── review-addin.md    # Checklist para auditoría de código C# o extensiones pyRevit.
│   ├── agents/                # 👥 [Especialistas] System prompts enfocados en tareas específicas.
│   │   └── ui-expert.md       # Especialista en UI (WPF en C# o WPF-xaml en pyRevit).
│   └── skills/                # 🛠️ [Caja de Herramientas] Skills modulares del sistema.
│       ├── revit-api/         # Reglas de compilación y thread-safety de Revit.
│       │   ├── SKILL.md       # Índice de directivas.
│       │   └── references/    # Documentación avanzada (hilos, ForgeTypeId, csproj).
│       └── revit-addin-helpers/ # Helpers base reusables.
│           ├── SKILL.md       # Índice de utilidades.
│           ├── assets/        # Helpers reales de C# (.cs) y Python (.py) listos para copiar.
│           └── references/    # Guías técnicas y lecciones de depuración (debugging).
├── hooks/                     # 🛡️ [Guardrails] Scripts de validación de pre-commit.
│   └── pre-commit.ps1         # Formateo de código y comprobación de build.
├── FilterPlus/                # 💻 [Código Fuente] Proyecto real C# de add-in.
├── AIRender/                  # 💻 [Código Fuente] Segundo add-in de C#.
└── docs/                      # 📚 [Documentación] Registros del desarrollador e hitos de arquitectura.
```

---

## 🧩 3. Detalle de Componentes y Reglas de Uso

### A. `.idx/dev.nix` (Configuración de Contenedor en IDX)
*   **Función:** Define el stack tecnológico (SDK .NET 8, entorno Python) y las extensiones del IDE recomendadas (C# Dev Kit, Python) para asegurar que el entorno de desarrollo se autoconfigure al vuelo.

### B. `.agents/skills/[skill-name]/references/` (Las Leyes y Debugging)
*   **Función:** Archivos Markdown pequeños y específicos que aíslan reglas técnicas y guardan la solución de problemas complejos resueltos (**debugging**).
*   **Convención de Debugging:** Cada vez que soluciones un error crítico de API o un bug complejo de Revit, documenta la solución en un archivo bajo la nomenclatura:  
    `.agents/skills/[skill-name]/references/debugging_[problema]_[YYYY-MM-DD].md`  
    *Esto previene la pérdida de memoria y permite que el agente lo consulte en problemas similares.*

### C. `.agents/skills/[skill-name]/assets/` (La Caja de Herramientas de Código)
*   **Función:** Archivos físicos que contienen código fuente de "superpoderes" C# (`.cs`) o Python (`.py`) listos para inyectarse directamente en el proyecto, evitando bloques en línea obsoletos.

### D. `.agents/prompts/` (Comandos / Flujos repetitivos)
*   **Función:** Archivos `.md` que detallan recetas paso a paso para andamiar o auditar componentes del sistema de forma predecible.

### E. `.agents/agents/` (Especialistas de Sistema)
*   **Función:** Definición de roles de IA enfocados en un dominio específico para evitar la contaminación de contexto en tareas complejas (ej. diseño de interfaz de usuario WPF).

---

## 🚀 4. Protocolo de Ejecución para el Agente de IA

Cuando el desarrollador te asigne una tarea en este repositorio, sigue estrictamente este protocolo:

1.  **Analizar Stack Tecnológico:** Identifica si la tarea requiere código compilado C# (Add-in, instalador MSI) o scripting en Python (pyRevit, consola RPS).
2.  **Mapear Recursos de IA:** Identifica qué skills modularizados en `.agents/skills/` y qué archivos de referencias/assets o prompts aplican.
3.  **Proponer / Referenciar:** Sugiere al desarrollador la lectura de `@skills/[nombre]` o `@prompts/[nombre]` antes de generar el código.
4.  **Preservar Conocimiento:** Al finalizar una depuración exitosa o implementar una nueva funcionalidad, asegúrate de guardar cualquier asset nuevo o documentación de error solucionado en el skill correspondiente siguiendo las reglas de la carpeta `.agents/`.
