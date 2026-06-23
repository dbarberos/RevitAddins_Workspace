# Walkthrough — FilterPlus: Bug Fix (Selection & UI Gap)

**Date:** 2026-04-30_1659  
**Feature:** Selection Bug & UI Refinement  
**Status:** ✅ Fixed and deployed

---

## 1. UI Refinement: 15px Gaps
Se ha ajustado el diseño para cumplir con el requisito de espaciado exacto:
- **Ancho**: Se ha ampliado el ancho de la ventana a **710px** y el panel derecho a **330px**.
- **Padding**: Se ha aplicado un `Padding="15,10"` en el borde de la tarjeta. Esto garantiza que la distancia entre el borde de la tarjeta y los elementos de las columnas sea de exactamente 15px en ambos lados, manteniendo la rejilla centrada.

## 2. Bug Fix: Selección Vacía
- **Problema**: Al desmarcar todo en el árbol y pulsar "Apply Selection", el add-in seleccionaba por defecto todos los elementos del ámbito actual (comportamiento heredado de filtros rápidos).
- **Solución**: Se ha eliminado la lógica de "fallback". Ahora, si el usuario no tiene nada marcado en el árbol, el add-in entiende que desea **limpiar la selección** en Revit. Al pulsar el botón con 0 elementos marcados, Revit ahora deseleccionará todo correctamente.

Build and deployment verified. ✅
