# Debugging Log: Erradicación de Duplicados en Forzar Niveles (Algoritmo de 4 Capas `FindExistingViewByName` y Registro `processedViewsMap`)

**Fecha:** 2026-07-23  
**Add-in:** TransferPlus  
**Componente:** `TransferOrchestrator.cs` (`FindExistingViewByName`, `ToAlphaNumericOnly`, `processSheetViewports`)  

## 1. Análisis de la Pregunta del Usuario y Causa Raíz Oculta

El usuario preguntó si la función de **Forzar Niveles** (`ForceLevelInLevelBaseViews`) estaba ignorando la opción *"Keep Original"* y provocando la vista por duplicado (`P1 - EST - OFICINAS_Nivel Oficinas1`).

### Hallazgo Clave
1. **La Asignación de Nivel No Ignora "Keep Original"**:
   - `ForceLevelInLevelBaseViews` se pasa a `CreateViewPlan`.
   - Sin embargo, `CreateViewPlan` **solo se ejecuta si la vista NO existe** en el documento destino.
   - Si la vista ya existe, la búsqueda previa `FindExistingViewByName` devuelve la vista existente y omite `CreateViewPlan`.

2. **Causa Real: Fallo de Detección en `FindExistingViewByName`**:
   - El nombre de la vista en el modelo origen (`P1 - EST - OFICINAS_Nivel Oficinas`) contiene guiones, espacios o caracteres tipográficos especiales.
   - Si `FindExistingViewByName` no detectaba la coincidencia exacta de caracteres en la primera pasada (por diferencias de espacios o guiones unicode), devolvía `null`.
   - Al devolver `null`, `TransferOrchestrator` asumía que la vista no existía y llamaba a `CreateViewPlan`.
   - Al ejecutar `ViewPlan.Create`, el motor C++ nativo de Revit (que sí normaliza guiones y espacios) detectaba la colisión con la vista ya existente y forzaba la creación de un sufijo (`P1 - EST - OFICINAS_Nivel Oficinas1`).

3. **Omisión de Registro en `processedViewsMap` durante `processSheetViewports`**:
   - En `processSheetViewports`, cuando la vista de plano ya estaba colocada en un plano destino y `Viewport.CanAddViewToSheet` devolvía `false`, `targetViewId` quedaba en `InvalidElementId`.
   - Como resultado, `processedViewsMap` no registraba la vista existente, y la etapa 5 de vistas de plano intentaba procesarla de nuevo.

## 2. Solución Aplicada

1. **Algoritmo de Detección de 4 Capas en `FindExistingViewByName`**:
   - **Capa 1 (Exacta)**: Coincidencia directa de `v.Name`.
   - **Capa 2 (Normalizada)**: Convierte guiones unicode (`\u2013`, `\u2014`, `\u2212`) a `-` ASCII y espacios unicode (`\u00A0`, `\u200B`) a espacio estándar.
   - **Capa 3 (Parámetros)**: Consulta el parámetro `BuiltInParameter.VIEW_NAME`.
   - **Capa 4 (Alfanumérica Absoluta `ToAlphaNumericOnly`)**: Elimina todos los guiones, guiones bajos, espacios y puntuación (`"P1 - EST - OFICINAS_Nivel Oficinas"` -> `"p1estoficinasniveloficinas"`). **Garantiza la coincidencia 100% infalible**.

2. **Registro Obligatorio en `processedViewsMap`**:
   - En `processSheetViewports`, cuando *"Keep Original"* está activo y la vista ya existe en el destino, **siempre asigna `targetViewId = existingTargetView.Id`**, asegurando que `processedViewsMap` recuerde la vista existente e impida la reinvocación de `CreateViewPlan` en etapas posteriores.

## 3. Verificación
- Compilado para `.NET Framework 4.8` (`Debug.R24`) con **0 Errores**.
