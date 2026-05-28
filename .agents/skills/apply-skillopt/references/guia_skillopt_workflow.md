# Guía Técnica del Flujo de Trabajo SkillOpt (Meta-Learning)

Esta guía detalla el protocolo operativo exacto que debe seguir el agente de IA cuando el desarrollador solicita aplicar **SkillOpt** para documentar y refinar el conocimiento técnico de una funcionalidad previamente completada.

Inspirado en el framework [Microsoft SkillOpt](https://github.com/microsoft/SkillOpt), este workflow optimiza dinámicamente el conjunto de habilidades globales del repositorio (`.agents/skills/`) basándose en trayectorias de desarrollo exitosas, asegurando que las lecciones técnicas no se pierdan y previniendo la reintroducción de fallos conocidos.

---

## 🔄 El Ciclo SkillOpt en RevitAddins_Workspace

Cuando el usuario invoque el disparador:
> **"aplica el skillopt para todo el trabajo realizado anterior de [feature/cambio]"**

El agente ejecutará secuencialmente los siguientes pasos:

```
┌────────────────────────────────────────────────────────┐
│             1. INVESTIGACIÓN DE TRAYECTORIA            │
│  Escanear Git (diffs, logs) y leer archivos editados   │
└───────────────────────────┬────────────────────────────┘
                            │
                            ▼
┌────────────────────────────────────────────────────────┐
│          2. DIAGNÓSTICO Y EXTRACCIÓN DE REGLAS         │
│ Identificar: Patrón Óptimo, Causa Raíz (si hubo bugs)  │
└───────────────────────────┬────────────────────────────┘
                            │
                            ▼
┌────────────────────────────────────────────────────────┐
│         3. ASIGNACIÓN MODULAR Y SEPARACIÓN             │
│   Seleccionar Skill receptor y separar código (asset)  │
│   de documentación de referencia (reporte debugging)   │
└───────────────────────────┬────────────────────────────┘
                            │
                            ▼
┌────────────────────────────────────────────────────────┐
│           4. REVISIÓN DE INTEGRIDAD Y CONTROL          │
│   ¿Hay ambigüedades? -> Preguntar al usuario           │
│   ¿Es conciso? -> Evitar sobrecargar tokens            │
└───────────────────────────┬────────────────────────────┘
                            │
                            ▼
┌────────────────────────────────────────────────────────┐
│          5. REGISTRO Y ACTUALIZACIÓN FÍSICA            │
│  Crear references/debugging_..., assets/ y SKILL.md     │
└────────────────────────────────────────────────────────┘
```

---

## 📖 Instrucciones Operativas Detalladas

### Paso 1: Recolección y Análisis de la Trayectoria
El agente debe aislar el código modificado y las interacciones pasadas relativas a la feature mencionada.
- **Herramienta de terminal**: Ejecutar `git status` y `git diff` o analizar los commits locales recientes relacionados con la feature.
- **Análisis de archivos**: Inspeccionar los archivos de código fuente directamente para entender las API llamadas y las resoluciones aplicadas (p. ej., métodos de `FilteredElementCollector`, wrappers de transacción, control de hilos en Revit, etc.).

### Paso 2: Extracción y Refinamiento del Conocimiento
Determinar qué información técnica es crítica preservar para el futuro. Clasificar el conocimiento en dos categorías:
1. **Reglas de Diseño y Patrones Óptimos (Best Practices)**: Nuevas arquitecturas que funcionan, flujos WPF/MVVM limpios, consumo eficiente de API, etc.
2. **Lecciones de Depuración (Debugging Lessons-Learned)**: Por qué ocurrió un fallo de compilación o de API de Revit (p. ej., problemas de transacciones, uso incorrecto de `FamilyInstance`, errores de hilos en WPF) y cómo se resolvió exactamente.

### Paso 3: Asignación Modular y Segregación de Contenido
Nunca almacenar todo el conocimiento en un solo lugar. Distribuirlo según las habilidades preexistentes:
- **`revit-api`**: Lógica pura de manipulación de elementos en el modelo Revit, transacciones, filtros, recolectores.
- **`csharp-blueprints` / `csharp-community-toolkit-mvvm`**: Lógica de patrones de diseño, ViewModels, inyección de dependencias, propiedades observables.
- **`integrating-wpfui-fluent`**: Estilos XAML, integración de controles Fluent, navegación, SnackBar.
- **`revit-addin-helpers`**: Métodos de extensión, conversores de unidades de Revit, utilidades genéricas reutilizables.
- **`revit-pyrevit-python` / `revit-rps-python`**: Ecosistema Python, scripts, interfaces xaml de pyRevit.

#### Reglas de Escritura Física:
- **Assets de Código (`assets/`)**: Si se ha desarrollado un helper de alta utilidad (p. ej., un conversor, un iterador de conectores robusto, o un filtro de intersecciones físico), extraerlo y guardarlo en la carpeta `assets/` del skill de destino con su extensión nativa (`.cs`, `.py`). **No incrustar bloques grandes de código en Markdown**.
- **Referencias (`references/`)**:
  - Para guías y patrones: `references/guia_[keywords].md`
  - Para bugs resueltos: `references/debugging_[keywords]_[YYYY-MM-DD].md` (detallando Síntoma, Causa Raíz y Solución con un fragmento breve de código).
- **Actualizar Índice (`SKILL.md`)**: Añadir los nuevos archivos a las listas de "Referencias Técnicas" o "Assets" en el archivo `SKILL.md` del skill de destino.

### Paso 4: Evitar la Redundancia y Sobrecarga
Un principio clave de **SkillOpt** es que las instrucciones de IA deben ser lo más ligeras posible para evitar el consumo masivo de contexto de tokens (lo que degrada el rendimiento de la IA y ralentiza las respuestas).
- Escribir reportes y guías de forma concisa y muy estructurada.
- Usar explicaciones directas y código compacto enfocado en el problema/solución.

### Paso 5: Manejo de Ambigüedad e Interacción Humana
Si la trayectoria de código es muy amplia, o si la causa raíz de un problema no queda clara en los archivos actuales, el agente **debe detenerse y preguntar** al usuario:
- *"He detectado que para X feature implementaste Y y Z. ¿El bug que experimentaste en Y se debió a un tema de transacciones de Revit o fue un fallo de casteo en WPF?"*
- Esto garantiza que el conocimiento almacenado sea 100% verídico y represente una optimización real.

---

## ✅ Lista de Verificación para el Agente (Definición de Hecho)

Antes de concluir una tarea de SkillOpt, el agente debe validar:
- [ ] Se han identificado y leído todos los archivos modificados de la feature en el workspace.
- [ ] Se ha seleccionado el skill global receptor adecuado.
- [ ] Si se documenta un bug, se ha creado el archivo `debugging_[keywords]_[YYYY-MM-DD].md` con las tres secciones obligatorias: Síntoma, Causa Raíz y Solución.
- [ ] Si hay código reutilizable de infraestructura, se ha movido a un asset con extensión física nativa (`.cs`, `.py`).
- [ ] Se ha actualizado la sección correspondiente en el `SKILL.md` del skill objetivo.
- [ ] No se ha incrementado el tamaño de `SKILL.md` del skill de destino más allá de las 50 líneas físicas (sigue siendo solo un índice ligero).
- [ ] El resultado final es conciso y libre de redundancias.
