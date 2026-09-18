# Informe de Resolución Técnica: Transferencia de Vistas con Elementos 2D y Consolidación de Vistas por Nivel Mapeado

**Fecha:** 2026-07-28  
**Proyecto:** TransferPlus  
**Componente:** `TransferOrchestrator.cs` / `ponDependientes`  
**Tecnología:** C# 12 / .NET Framework 4.8 / Autodesk Revit API 2024  

---

## 1. Contexto y Problema Inicial

Durante la transferencia de vistas de plano (`ViewPlan`) entre diferentes modelos donde los niveles de origen y destino difieren en elevación (o cuando se mapean a niveles con nombres distintos/creados en caliente):
1. **Excepción de SketchPlane en ViewPlan**: Intentar asignar `targetViewPlan.SketchPlane = sk` corrompía la vista lanzando:
   `Autodesk.Revit.Exceptions.ArgumentException: View does not and may not contain a fixed sketch plane`.
2. **Fallo en Copia Individual de Líneas 2D**: Intentar copiar elementos 2D elemento por elemento fallaba con:
   `Copying one or more elements failed`, debido a que las líneas de detalle poseen uniones y restricciones geométricas conectadas entre sí que Revit API no permite resolver en solitario.
3. **Duplicación de Vista por Efecto Secundario del Motor de Revit**:
   Al invocar `ElementTransformUtils.CopyElements` con un lote de elementos 2D entre niveles con elevaciones distintas, el motor interno C++ de Revit creaba automáticamente una nueva vista duplicada con sufijo `1` (`P1 - EST - OFICINAS_Nivel Oficinas1`) para alojar las líneas en su nivel plano correspondiente, dejando la primera vista destino vacía.

---

## 2. Solución Aplicada (Patrón de Consolidación de Vistas)

1. **Protección de Workplane en `ViewPlan`**:
   Se añadió una salvaguarda estricta en `EnsureViewWorkplane`: las vistas de tipo `ViewPlan` nunca deben recibir la asignación explícita de un `SketchPlane`.
2. **Copiado en Lote (Batch Copy)**:
   Se pasan **todos los ElementId 2D a la vez** en un único lote a `CopyElements`. De este modo, el motor de Revit resuelve el 100% de las uniones de detalle y referencias geométricas.
3. **Consolidación Automática de Vistas**:
   - Se captura la lista previa `existingViewIdsBeforeCopy` antes de invocar `CopyElements`.
   - Si Revit genera la vista duplicada por efecto secundario (`...1`), el add-in la detecta (`sideEffectView`), le transfiere los parámetros de ejemplar y la plantilla de vista de la vista origen, **elimina la vista inicial vacía** y **renombra la vista poblada al nombre original** sin sufijo.

---

## 3. Comprobación y Resultado Final

- **Cero Vistas Duplicadas**: Queda únicamente 1 vista en el modelo destino con el nombre original exacto.
- **100% de Elementos 2D Copiados**: Todas las anotaciones y líneas de detalle se conservan intactas.
- **Cero Ventanas Modales de Error**.
