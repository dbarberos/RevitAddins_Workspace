# 🏗️ AI-Optimized Project Architecture (Google Antigravity & Project IDX)

**Contexto del Proyecto:** Desarrollo de Add-ins para Revit (C#, .NET 8 / .NET Framework 4.8) y Macros / Scripts (Python, pyRevit, RevitPythonShell).  
**Objetivo:** Establecer una arquitectura de Ingeniería de Prompts a nivel de repositorio (RAG Local) para maximizar la eficiencia del agente de IA, reducir el consumo de tokens y eliminar "alucinaciones" (uso de APIs deprecadas).

---

## 🧭 1. Filosofía de Trabajo (Para el Agente de IA)

Como asistente de IA en este proyecto, tu conocimiento sobre cómo programar está estructurado en **Skills modulares** dentro de `.agents/skills/`.
Para garantizar que el código cumpla con los estándares técnicos, de rendimiento y seguridad del repositorio, **debes aplicar de forma autónoma e implícita las directrices de los Skills Core en cada Plan de Actuación (`implementation_plan.md`) y generación de código**, sin esperar a que el usuario haga mención expresa de ellos.

### 🛑 Puerta de Planificación Core (Core Planning Gate)
Antes de proponer cualquier cambio o escribir código, debes validar el diseño contra los siguientes **Skills Core/Arquitectónicos**:
1. **Aislamiento de Hilos (Threading & Modeless WPF)** ([revit-api-core](file:///.agents/skills/revit-api-core/SKILL.md) / [revit-async-operations](file:///.agents/skills/revit-async-operations/SKILL.md)): Todo acceso o modificación del modelo Revit desde interfaces flotantes (WPF, WebView2, RelayCommands) **debe** realizarse de forma asíncrona mediante `Revit.Async` (`await RevitTask.RunAsync(...)`) o `IExternalEventHandler`. Queda estrictamente prohibido realizar transacciones o mutaciones directamente en el hilo de la UI.
2. **Seguridad de Transacciones (Transaction Safety)** ([revit-transactions](file:///.agents/skills/revit-transactions/SKILL.md) / [revit-api](file:///.agents/skills/revit-api/SKILL.md)): Cualquier modificación de la base de datos de Revit requiere transacciones. En C#, la instancia de `Transaction` o `SubTransaction` **debe** estar envuelta en un bloque `using` para evitar fugas de memoria C++. En Python, usa el context manager `with revit.Transaction(...)`.
3. **Virtualización y Rendimiento WPF (WPF UI Performance)** ([virtualizing-wpf-ui](file:///.agents/skills/virtualizing-wpf-ui/SKILL.md)): Cuando representes más de 1000 elementos en controles WPF (ListView, TreeView, DataGrid), la virtualización es **obligatoria**. Nunca envuelvas el control en un `ScrollViewer` y usa `VirtualizationMode="Standard"` para evitar corrupción de estados visuales.
4. **Hardening de Seguridad (Security Hardening)** ([security-engineer](file:///.agents/skills/security-engineer/SKILL.md)): Implementa sanitización de rutas (evitar path traversal), cifrado DPAPI (`ProtectedData`) para credenciales locales, validación de inputs (FluentValidation/Regex), y deserialización segura (sin `TypeNameHandling.All` en Newtonsoft).
5. **Configuración del Stack del Proyecto (ImplicitUsings y Target Framework)** (Ver `3Guia maestra desarrollo add-ins Revit 2024.md` y `AGENTS.md`): Asegúrate de usar `<ImplicitUsings>enable</ImplicitUsings>` y comprobar la versión de framework según la versión de Revit (4.8 vs .NET 8).

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

1.  **Mapear Skills Core (Obligatorio e Implícito):** Analiza cómo se aplican las directrices de Threading, Transacciones, Seguridad y Virtualización en la nueva funcionalidad. Incluye una sección en tu Plan de Actuación (`implementation_plan.md`) verificando explícitamente estas directrices contra la **Puerta de Planificación Core**.
2.  **Analizar Stack Tecnológico:** Identifica si la tarea requiere código compilado C# (Add-in, instalador MSI) o scripting en Python (pyRevit, consola RPS).
3.  **Mapear Skills Específicos:** Identifica qué skills específicos (ej. `revit-api-geometry`, `revit-api-mep`, `revit-addin-installer-manager`) aplican a la lógica interna de las funciones y consúltalos para desarrollar los métodos detallados.
4.  **Preservar Conocimiento:** Al finalizar una depuración exitosa o implementar una nueva funcionalidad, asegúrate de guardar cualquier asset nuevo o documentación de error solucionado en el skill correspondiente siguiendo las reglas de la carpeta `.agents/`.
