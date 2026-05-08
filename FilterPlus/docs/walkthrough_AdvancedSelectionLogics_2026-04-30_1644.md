# Walkthrough — FilterPlus: Advanced Selection Logics

**Date:** 2026-04-30_1644  
**Feature:** Triple Geometry Filtering (3D Objects, Annotations, Bounding Box)  
**Status:** ✅ Advanced filtering fully functional

---

## 1. UI Renaming
- La opción original de "Only 3D Models" ha sido renombrada a **"Only 3D model objects"** para reflejar mejor que incluye elementos técnicos del modelo.

## 2. New Logic: Only Annotations
- **Objetivo**: Mostrar exclusivamente elementos 2D y de anotación (Textos, Cotas, Etiquetas).
- **Comportamiento**: Al activarse, apaga los otros filtros y desmarca automáticamente cualquier elemento de modelo que estuviera seleccionado.

## 3. New Logic: Has Bounding Box
- **Objetivo**: Este es el filtro de "objetos físicos". Solo muestra elementos que tienen una extensión geométrica real (muros, puertas, mobiliario, etc.).
- **Utilidad**: Elimina instantáneamente cámaras, caminos de sol, materiales y otros objetos "abstractos" que a menudo ensucian el listado de "All Model Elements".

## 4. Logical Safety (Mutual Exclusion)
Se ha implementado un sistema de "triángulo de exclusión":
- Solo uno de estos tres filtros puede estar activo a la vez. Al encender uno, se apagan los demás. Esto garantiza que el explorador tenga una lógica de visualización coherente y predecible.

## 5. Selection Integrity
Se mantiene la regla de oro: **lo que no se ve, no se selecciona**. Si un elemento desaparece del explorador debido a uno de estos switches, el add-in lo desmarca automáticamente de la persistencia de selección.

Build and deployment verified. ✅
