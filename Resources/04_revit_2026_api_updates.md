***

### Archivo: `pyrevit-dev-mentor/references/04_revit_2026_api_updates.md`

# Guía de Actualizaciones: Novedades y Depreciaciones en Revit API 2026

Mantener el código de tus extensiones actualizado es vital, ya que Autodesk elimina anualmente métodos y propiedades que han sido marcados como obsoletos (depreciados) en versiones anteriores. La API de Revit 2026 introduce cambios significativos que romperán los scripts antiguos si no se actualizan.

## 1. El Cambio más Crítico: `ElementId` a 64 bits
Históricamente, los IDs de los elementos en Revit se manejaban como números enteros de 32 bits (`integer 32`). En Revit 2026, la base de datos interna se ha actualizado para soportar identificadores mucho más grandes, pasando a 64 bits (`integer 64`).

*   **Propiedad eliminada:** Ya no puedes usar `ElementId.IntegerValue` para extraer el número entero de un ID.
*   **Nueva propiedad:** Debes reemplazarlo por la propiedad `.Value`.
*   **Métodos afectados:** Métodos como `Evaluate` que antes recibían un argumento `int32`, ahora requieren un `int64`.

**Ejemplo de migración en Python:**
```python
# CÓDIGO ANTIGUO (Revit 2025 o anterior) - ¡Romperá en 2026!
id_entero = muro.Id.IntegerValue

# CÓDIGO NUEVO (Revit 2026)
id_entero = muro.Id.Value
```

## 2. Reemplazo de Métodos y Propiedades Obsoletas
Varios métodos comunes de creación y manipulación geométrica han sido eliminados de la API de 2026. Debes aplicar los siguientes reemplazos:

### A. Edición de Formas (Suelos y Cubiertas)
*   **Acceso al editor:** Para las clases `Floor` y `RoofBase`, la propiedad directa `SlabShapeEditor` ha sido eliminada. Ahora debes usar el método `get_SlabShapeEditor()`.
*   **Creación de líneas y puntos:** Los métodos `DrawPoint()` y `DrawSplitLine()` ya no existen. Han sido reemplazados por `AddPoint()` y `AddSplitLine()`.

### B. Geometría y Arreglos
*   **Curve Loops:** El método para validar si un bucle de curvas es correcto ha cambiado. `CurveLoop.IsValid` ha sido eliminado y debe reemplazarse por `IsOuterControlValid`.
*   **Arreglos (Arrays):** Para arreglos radiales y lineales, el método para evaluar miembros ha sido eliminado. Debes usar la comprobación `IsValidNumberOfMembers`.

### C. Cambios en MEP
*   **Fluidos y Presión:** En los datos de caída de presión de conductos, `Viscosity` ahora debe llamarse `DynamicViscosity`, y `AirViscosity` cambia a `AirDynamicViscosity`.
*   **Electricidad:** Las propiedades eléctricas han sido renomadas para ser más legibles. `NumberOfPhases` pasa a ser `PhasesNumber`, y también se ha ajustado el nombre para `AssignedVoltage`.

## 3. Limpieza de API Inútil
*   El método `isPDFImportAvailable` ha sido eliminado completamente del código base, ya que los desarrolladores notaron que siempre devolvía el valor `True` y no aportaba utilidad real.

## 4. Advertencia Crítica sobre la Documentación (rvtdocs)
Al programar para Revit 2026, notarás que la documentación oficial (en sitios como *rvtdocs.com* o la ayuda oficial de Autodesk) parece "rota" o vacía para muchos métodos. 

*   Autodesk ha omitido la inclusión de las *Descriptions* (descripciones), *Remarks* (notas adicionales) y *Examples* (ejemplos de código) para métodos fundamentales como `Ceiling.Create`.
*   **Mejor práctica:** Cuando inspecciones la API de 2026 y no encuentres información sobre cómo usar un método o qué devuelve, **cambia a la documentación de la API 2025**. En la versión 2025 encontrarás toda la información vital, advertencias y ejemplos que siguen siendo aplicables a la forma en que funciona la clase en 2026. 
*   Puedes usar herramientas de Inteligencia Artificial proporcionando el código antiguo y preguntando específicamente por la compatibilidad con Revit 2026 para agilizar el proceso de actualización.

***

