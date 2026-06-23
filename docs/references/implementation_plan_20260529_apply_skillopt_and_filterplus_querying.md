# Implementation Plan: SkillOpt Meta-Learning for Model Exploration & Filtering (FilterPlus)

Este plan detalla el andamiaje técnico y la aplicación del ciclo de **SkillOpt** para documentar, estructurar y archivar el conocimiento técnico sobre **consulta, exploración y filtrado avanzado de modelos** derivado del add-in `FilterPlus`.

---

## 🎯 Objetivo y Propósito

El add-in `FilterPlus` implementa un motor robusto de consulta y categorización de elementos de Revit (`RevitSelectionService.cs` y `SelectionFilterViewModel.cs`). Queremos extraer este conocimiento de alto nivel para archivarlo en las habilidades globales del repositorio de forma modular y en inglés.

Documentaremos:
1. **Estrategia de Selección y Scopes**: Consulta por Selección, Vista Activa, Elementos de Vista (incluyendo anotaciones geométricas específicas) y Modelo Completo.
2. **Normalización y Extracción de Familias y Tipos**: Diferencia técnica de extracción para instancias cargables (`FamilyInstance`) y objetos de sistema (`HostObject`).
3. **Mapeo Segurado y Caching de Fases / Niveles**: Diccionarios indexados para orden secuencial de fases y prevención de violaciones de acceso de parámetros.
4. **Búsqueda Indexada (Searchable Metadata)**: Construcción de cadenas de texto unificadas para posibilitar búsquedas instantáneas y Regex a nivel local.

---

## 🛠️ Propuesta de Cambios por Componente

### [NEW] [.agents/skills/revit-api/references/revit_model_exploration_and_filtering.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api/references/revit_model_exploration_and_filtering.md)
Guía de referencia técnica avanzada en el skill global de `revit-api` detallando:
- Las firmas y constructores eficientes de `FilteredElementCollector` según el Scope.
- La lógica específica para `SelectionScope.ElementsBelongingToView` (anotación view-specific + elementos físicos con Bounding Box).
- Diferenciación en la extracción de metadatos entre `FamilyInstance` and `HostObject`.
- Lectura segura de parámetros Built-In y prevención de `AccessViolationException`.

### [NEW] [.agents/skills/revit-addin-helpers/assets/RevitFilterUtils.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-helpers/assets/RevitFilterUtils.cs)
Componente de código C# reusable inyectable en el catálogo global:
- Métodos auxiliares para resolver nombres de familia y tipo para cualquier elemento de Revit de forma segura.
- Constructor optimizado de mapeo secuencial de Fases del proyecto.
- Extractor robusto de metadatos de marcas y comentarios.

### [MODIFY] [.agents/skills/revit-api/SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api/SKILL.md)
Registrar la nueva guía de referencia técnica en la sección `## 📚 Technical References (Knowledge Base)`.

### [MODIFY] [.agents/skills/revit-addin-helpers/SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-helpers/SKILL.md)
Registrar el nuevo asset de código `RevitFilterUtils.cs` en la sección `## 📦 Assets (Reusable Code)`.

---

## 🔬 Plan de Verificación

1. **Escritura del conocimiento técnico**: Crearemos la guía técnica `revit_model_exploration_and_filtering.md` en inglés.
2. **Generación del Asset**: Escribiremos el código de `RevitFilterUtils.cs` respetando las directrices de C# 12, ElementId de 64 bits y manejo seguro de excepciones.
3. **Actualización de Manifiestos**: Añadiremos las referencias correspondientes en los archivos `SKILL.md`.

---

## 💬 Preguntas para el Usuario / Review Requerido

> [!NOTE]
> Esta meta-documentación dotará a los futuros agentes de un entendimiento excelente sobre cómo resolver el explorador de árbol de Revit de manera eficiente, previniendo errores de hilos y cuellos de botella de rendimiento.

1. **¿Estás de acuerdo con esta propuesta para inmilitar y estructurar la lógica de filtrado de FilterPlus?**
2. **¿Deseas que iniciemos la creación de la documentación y el asset reutilizable en este momento?**
