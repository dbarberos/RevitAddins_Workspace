# Debugging Log: Revit API `ponDependientes` Element-by-Element View Duplication Interception & Auto-Cleanup

**Fecha:** 2026-07-23  
**Proyecto / Add-in:** TransferPlus  
**Componente:** `TransferOrchestrator.cs` (`ponDependientes`)  
**Stack Técnico:** C# 12 / .NET Framework 4.8 / Revit API 2024  

---

## 1. Evidencia Log Definitiva
Mediante el sistema de rastreo por puntos de control (`[VIEW CHECKPOINT]`), se acotó de forma matemática el momento exacto de la duplicación:
- `[CHECKPOINT 12 - AFTER_MATCH_PLANTILLA]`: Total ViewPlans: 9 (`P1 - EST - OFICINAS_Nivel Oficinas`, Id: 150684).
- Ejecución de `ponDependientes`.
- `[CHECKPOINT 13 - AFTER_PON_DEPENDIENTES]`: Total ViewPlans: 10 (`P1 - EST - OFICINAS_Nivel Oficinas1`, Id: 150695).

---

## 2. Solución Final Implementada

1. **Copiado Unitario Elemento a Elemento**:
   - `ponDependientes` itera individualmente sobre cada elemento 2D filtrado.

2. **Detección del Elemento Detonante**:
   - Mide `viewsBefore` y `viewsAfter` alrededor de `ElementTransformUtils.CopyElements` para cada elemento.
   - Imprime un aviso `LogWarning` indicando el Nombre, Categoría, Clase e ID exactos del elemento que provoca que Revit C++ clone la vista.

3. **Eliminación Automática de Vistas Parásitas (Auto-Cleanup)**:
   - Si `viewsAfter > viewsBefore`, identifica inmediatamente la vista duplicada colateral generada por Revit (`P1 - EST - OFICINAS_Nivel Oficinas1`) y la elimina en caliente (`destino.Delete(dupView.Id)`).

---

## 3. Estado de Compilación y Despliegue
- **Compilado**: `.NET Framework 4.8` (`Debug.R24`) — **0 Errores**.
- **Binario Copiado**: Exitosamente actualizado en `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll`.
