# Auditoría de Estructura y Organización de Skills y Agente

Este documento presenta una auditoría técnica y exhaustiva de la estructura de agentes y skills en el repositorio **RevitAddins_Workspace**, evaluando su mantenibilidad actual y su capacidad de escalar para incorporar nuevas capacidades de automatización.

---

## 1. Diagnóstico del Estado Actual

Tras inspeccionar detalladamente el workspace, se identifican tanto grandes fortalezas arquitectónicas como algunas discrepancias críticas que afectan la consistencia y escalabilidad futura.

### A. Fortalezas Clave
1. **Compilación de Lockfiles Inteligente (`build.ps1`)**:
   - El script de compilación en `agentic-workflows/dotnet-msbuild/build.ps1` está diseñado para expandir en línea enlaces del tipo `[texto](references/archivo.md)` en los `SKILL.md` principales.
   - Esto permite que los skills mantengan archivos Markdown pequeños y legibles durante el desarrollo sin perder la consolidación en archivos `.lock.md` para el consumo del modelo.
2. **Modularización Exitosa en Skills Clave**:
   - `csharp-blueprints`: Guías arquitectónicas movidas a `references/`.
   - `revit-addin-helpers`: Helpers de C# extraídos como archivos físicos `.cs` individuales en `assets/` (p. ej. `UnitHelper.cs`, `DocumentExtensions.cs`).
   - `revit-api`: Reglas avanzadas (hilo, TreeView, ForgeTypeId) movidas a `references/`.
3. **Reducción de Contexto**:
   - Los archivos de entrada principales (`SKILL.md`) se redujeron en más del 75%, optimizando el consumo de tokens y previniendo la degradación del razonamiento (loss-in-the-middle).

---

## 2. Hallazgos y Discrepancias Identificadas

Para lograr una arquitectura 100% mantenible y lista para futuras capacidades, es crucial corregir los siguientes puntos:

### ⚠️ Hallazgo 1: Discrepancia Crítica de Nombres (`.agent` vs `.agents`)
En el archivo principal de reglas `AGENTS.md` (y en varios registros históricos), las rutas de los skills de Revit se referencian usando la carpeta **singular** `.agent`:
* Ejemplo en `AGENTS.md`: `| revit-api | .agent/skills/revit-api/ |`
* Sin embargo, la carpeta física en el disco que contiene los 47 skills activos y cargados por el sistema es **plural**: `.agents/skills/`.
* Actualmente existe una carpeta `.agent` (singular) en el root del repositorio que está vacía (solo tiene una subcarpeta `skills` sin archivos).
* **Impacto**: Esto confunde a futuros agentes que intentan leer de `.agent` o crear archivos allí de forma redundante (problema de "split-brain").

### ⚠️ Hallazgo 2: Modularización Incompleta
Aunque el plan de modularización de skills (iniciado el `2026-05-18`) es excelente, **solo se ha ejecutado parcialmente**:
* Skills clave como `revit-addin-testing`, `revit-addin-icon-manager`, `revit-addin-doc-manager`, `create-skill` y `workspace-ops` siguen siendo **monolíticos**.
* Por ejemplo, `revit-addin-testing/SKILL.md` contiene 290 líneas de código con grandes bloques inline de configuraciones XML y archivos `.csproj` de prueba.
* **Impacto**: Los monolitos incrementan la carga cognitiva del agente y dificultan la edición o agregado de características en secciones específicas de pruebas, documentación o empaquetado.

---

## 3. Propuesta de Optimización y Extensibilidad

Para asegurar que añadir nuevas capacidades al agente sea rápido, modular y robusto, proponemos el siguiente plan de acción:

### Paso 1: Corrección de Consistencia y Limpieza
1. **Corregir `AGENTS.md`**: Actualizar todas las referencias de `.agent/skills/` a `.agents/skills/` (plural) para alinearse al estándar físico y del sistema.
2. **Eliminar Carpeta Redundante**: Eliminar de forma segura la carpeta vacía `.agent/` en el root del repositorio para evitar duplicidades accidentales.

### Paso 2: Completar la Modularización de los Skills Restantes
Se deben reestructurar los skills monolíticos usando las tres carpetas estándar:
* **`references/`**: Para guías y explicaciones en Markdown.
* **`assets/`**: Para plantillas de archivos, fragmentos de código e imágenes/iconos.
* **`scripts/`**: Para scripts de automatización.

#### Ejemplo de Restructuración de `revit-addin-testing`:
* **`assets/TestProjectTemplate.csproj`**: Extraer la plantilla XML del archivo de pruebas.
* **`assets/WallAnalysisServiceTests.cs`**: Extraer el ejemplo de código C# de pruebas unitarias.
* **`references/testing_strategy.md`**: Explicación de por qué no se puede ejecutar la API de Revit de forma nativa en entornos headless y cómo solucionarlo con mocks.
* **`SKILL.md`**: Reducir a un índice simplificado de menos de 40 líneas.

### Paso 3: Plan para Añadir Nuevas Capacidades
Cuando decidas dotar al agente de nuevas habilidades (p. ej., Integración con CI/CD automatizada, herramientas de análisis estático de código como SonarQube, o generadores automáticos de layouts WPF avanzados):
1. **Crear carpetas modularizadas desde el inicio**: Utilizar `create-skill` para crear el esqueleto básico con las subcarpetas `references/`, `assets/`, y `scripts/`.
2. **Mantener `SKILL.md` ligero**: Usar los links relativos en `SKILL.md` y dejar que el script de build los combine automáticamente si es necesario consolidar lockfiles.
3. **Validación Automática**: Ejecutar `workspace-ops` para validar la frontmatter y asegurar que el nuevo skill no rompe la consistencia.

---

## 4. Conclusión

La arquitectura elegida para los skills (`.agents/skills/` con modularización por subcarpetas) es **excelente y del más alto nivel técnico**. Resuelve de forma brillante el equilibrio entre mantener un contexto de token bajo para el modelo y proporcionar documentación rica a demanda. 

Sin embargo, **no está completamente implementada de forma homogénea**, y la discrepancia de nombres entre `.agent` y `.agents` en la documentación principal es un riesgo de mantenibilidad. Corregir estos dos detalles dejará el repositorio en un estado impecable y 100% escalable.
