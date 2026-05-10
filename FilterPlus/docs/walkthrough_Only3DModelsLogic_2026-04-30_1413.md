# Walkthrough — FilterPlus: 'Only 3D Modeled' Filter Logic

**Date:** 2026-04-30_1413  
**Feature:** Only 3D Modeled Toggle  
**Status:** ✅ Functional logic implemented

---

## 1. Logic Overview
The "Only 3D Modeled" switch now acts as a real-time filter for the element explorer.

- **Filtrado Inteligente**: Al activarse, el add-in oculta instantáneamente cualquier elemento que no sea de tipo "Modelo" (CategoryType.Model). Esto elimina textos, etiquetas, líneas de detalle y otros elementos de anotación 2D.
- **Exclusión Mutua**: Por diseño, al activar "Only 3D Modeled", se desactivan automáticamente los switches de "Only Annotations" y "Has Bounding Box" para evitar conflictos lógicos.
- **Limpieza de Selección**: Según lo solicitado, si un elemento estaba marcado (checked) y se oculta al activar este filtro, el add-in lo **desmarca** automáticamente. Esto evita que el usuario aplique cambios accidentalmente a elementos que no está viendo.

## 2. Technical Strategy: Offline Processing
Para mantener el add-in fluido, no se realizan llamadas a la API de Revit cuando se pulsa el switch:
- Los metadatos de geometría y categoría se capturan una sola vez durante el arranque (Pre-fetch).
- El filtrado y la reconstrucción del árbol ocurren íntegramente en el hilo de la UI usando datos en caché.

## 3. Results
- **Respuesta Instantánea**: El árbol se actualiza en milisegundos.
- **Contador Dinámico**: El contador de "Elementos marcados" se actualiza si se desmarcan elementos ocultos.

Build and deployment verified. ✅
