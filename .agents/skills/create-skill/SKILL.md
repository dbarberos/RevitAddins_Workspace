---
name: create-skill
description: Scaffolds new agent skills for the RevitAddins_Workspace repository. Use when creating a new skill, generating SKILL.md files, or setting up skill directory structures. Handles frontmatter generation, section templates, and validation guidance for dual-stack (C#/Python) environments.
---

# Create Skill — Guía de Creación y Andamiaje de Habilidades

Este skill asiste al agente en la creación y estructuración de nuevas habilidades de IA modulares, asegurando que cumplan con la topología unificada de doble stack del repositorio.

## When to Use
- Al crear una habilidad nueva desde cero para expandir las capacidades del agente (p. ej., manipulación de PDFs, generación automática de documentación de Word, o integraciones de CI/CD).
- Al estructurar y generar un archivo `SKILL.md` con su correspondiente bloque YAML de frontmatter.
- Al configurar la jerarquía física de subcarpetas obligatorias para prevenir el engrosamiento del índice principal.

## When Not to Use
- Al modificar código fuente de skills ya existentes (edita directamente sus assets o referencias en su lugar).
- Al configurar prompts de flujos de trabajo aislados (usa la carpeta `.agents/prompts/` en su lugar).

---

## Inputs

| Input | Required | Description |
|-------|----------|-------------|
| **Skill name** | Sí | Nombre en minúsculas, alfanumérico y con guiones (p. ej., `pdf-generator`, `revit-clash-detector`). |
| **Description** | Sí | Qué hace la habilidad y cuándo debe usarla el agente (1-1024 caracteres). |
| **Purpose** | Sí | Un párrafo detallando el resultado y meta del skill. |
| **Workflow** | Recomendado | Pasos numerados secuenciales con puntos de control (checkpoints). |

---

## Workflow de Creación

### Paso 1: Validación del Nombre del Skill
Asegúrate de que el nombre:
- Contenga únicamente letras minúsculas, números y guiones sencillos.
- No comience ni termine con un guion.
- Tenga una longitud de entre 1 y 64 caracteres.

### Paso 2: Creación de la Estructura de Directorios
Crea el directorio del skill bajo la ruta física unificada del repositorio:
```text
.agents/skills/<skill-name>/
├── SKILL.md         # Índice y manifiesto semántico principal del skill
├── scripts/         # Scripts ejecutables auxiliares (PowerShell, Python, Bash)
├── references/      # Guías técnicas, reglas de API y lecciones aprendidas de debugging
└── assets/          # Código fuente reusable inyectable (.cs, .py, .wxs, .xml)
```

---

## 🛠️ Reglas Estrictas de Segregación de Contenido

### A. Guardado de Assets de Código (assets/):
*   **Regla Obligatoria:** Todo código fuente o fragmento C# o Python reusable **debe** guardarse en su archivo físico con extensión nativa correspondiente (p. ej. `MyHelper.cs`, `script.py`, `Product.wxs`).
*   **Prohibición:** Está estrictamente **prohibido** incrustar bloques de código extensos directamente dentro de `SKILL.md` o en archivos Markdown de `references/`. Esto mantiene los tokens de contexto en el nivel óptimo.

### B. Preservación de Lecciones de Depuración (references/):
*   **Regla Obligatoria:** Cada vez que el agente solucione un error complejo de Revit API, un fallo de compilación de C# o un problema de ejecución en Python/pyRevit, **debe** documentar la resolución.
*   **Formato de Archivo:** Crea un reporte Markdown rápido en la carpeta `references/` del skill bajo la nomenclatura:  
    `references/debugging_[keywords]_[YYYY-MM-DD].md`
*   **Contenido Mínimo:**
    1.  **Síntoma:** Qué error de consola o comportamiento anómalo se presentó.
    2.  **Causa Raíz:** Por qué falló la API, transacción o hilo de Revit.
    3.  **Solución:** Explicación técnica y fragmento de código corregido que solucionó el bug.

---

## Plantilla Base para `SKILL.md`

Todo nuevo archivo `SKILL.md` debe actuar únicamente como un **índice ligero de metadatos** estructurado bajo el siguiente formato:

```markdown
---
name: <skill-name>
description: <1-1024 caracteres describiendo qué hace el skill y cuándo invocarlo>
---

# <Nombre del Skill>

<Un párrafo conciso describiendo el propósito y resultado de este componente.>

## 📚 Referencias Técnicas (Knowledge Base)
Consulta los siguientes archivos en la carpeta `references/` para obtener guías en profundidad:

*   `references/guia_tecnica.md`: Explicación conceptual del dominio del skill.
*   `references/debugging_[problema]_[fecha].md`: Lecciones aprendidas e historial de fallos solucionados.

## 📦 Assets (Plantillas y Código Fuente)
Los siguientes archivos se encuentran en la carpeta `assets/` listos para inyectarse directamente en el proyecto:

*   `assets/HelperClass.cs`: Clase base de soporte en C# (si aplica).
*   `assets/utility_script.py`: Script base de soporte en Python (si aplica).
```

---

## Lista de Verificación de Validación

- [ ] El nombre del skill coincide exactamente con el nombre de su subcarpeta.
- [ ] La descripción YAML es concisa, descriptiva y no excede los 1024 caracteres.
- [ ] El archivo principal `SKILL.md` no excede las 50 líneas físicas (actúa únicamente como índice).
- [ ] Las carpetas secundarias `references/`, `assets/` y `scripts/` existen físicamente.
- [ ] No existen fragmentos de código inyectables incrustados en `SKILL.md`. Todo código reusable reside en `assets/` con sus respectivas extensiones de archivo nativas (`.cs`, `.py`).
- [ ] Los reportes de resolución de errores se guardan bajo la nomenclatura `debugging_[keywords]_[YYYY-MM-DD].md`.
