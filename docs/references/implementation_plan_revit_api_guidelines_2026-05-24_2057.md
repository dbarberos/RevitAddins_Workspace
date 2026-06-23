# Implementation of Critical Revit API Rules

He revisado la base de conocimientos actual. Actualmente, el tema de las unidades está cubierto parcialmente en `revit-api/references/forge_type_id.md`, y el tema de los colectores es solo un punto rápido en las reglas generales. 

Dado que en modelos AECO masivos un mal filtrado colapsa la memoria, y usar clases obsoletas impide compilar en Revit modernos, **tienes toda la razón**: necesitamos reforzar estas dos áreas con documentos dedicados y estrictos.

## Proposed Changes

Integraré estos dos conceptos como **Reglas Críticas de Referencia** dentro de la super-skill maestra existente `revit-api`, ya que pertenecen inherentemente al núcleo de la API de Revit.

### 1. Refuerzo de Compatibilidad (Breaking Changes)
#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\revit-api\references\revit_breaking_changes.md`
Crearé una guía exhaustiva que enseñará al agente:
- El salto histórico de `DisplayUnitType` a `ForgeTypeId` (y `SpecTypeId`, `UnitTypeId`).
- Prohibición estricta de usar APIs deprecadas como `Parameter.Definition.UnitType`.
- Manejo de compatibilidad multi-versión mediante `#if REVIT2021` si alguna vez fuera necesario.
*(Este archivo reemplazará y ampliará el actual `forge_type_id.md` para englobar cualquier "breaking change" futuro).*

### 2. Rendimiento Extremo (FilteredElementCollector)
#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\revit-api\references\revit_filtered_element_collector.md`
Crearé una guía de rendimiento obligatorio que dictará:
- **Prioridad de Motor Interno:** Obligación de encadenar filtros rápidos nativos de C++ (`OfClass()`, `OfCategory()`, `WhereElementIsNotElementType()`, `BoundingBoxIntersectsFilter`).
- **Prohibición LINQ Temprana:** Prohibición absoluta de convertir el colector a `IEnumerable` (`.ToElements()`, `list()` en Python, o usar `LINQ / lambda`) antes de agotar los filtros rápidos.
- **Ejemplos Duales:** Patrones de rendimiento correctos tanto para C# LINQ como para IronPython.

### 3. Actualización de Enrutamiento
#### [MODIFY] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\revit-api\SKILL.md`
Actualizaré el índice principal para que, antes de iterar cualquier lista de elementos o lidiar con parámetros de unidad, el agente tenga la **obligación** de leer estas dos nuevas guías arquitectónicas.

## User Review Required
> [!IMPORTANT]
> ¿Apruebas que integre estas dos guías de alto rendimiento como pilares dentro de la skill `revit-api` existente? Una vez confirmado, procederé a redactarlas e instalarlas.
