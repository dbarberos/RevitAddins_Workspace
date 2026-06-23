# Prompt: Auditoría de Código de Revit Add-in

Este prompt estandariza el flujo de revisión para evaluar si un fragmento de código (C# o Python pyRevit) cumple con las reglas del repositorio.

---

## 🎯 Objetivo de la Tarea
Auditar exhaustivamente un archivo de código o comando propuesto para identificar posibles fugas de memoria, malas prácticas de transacciones, problemas de hilos o APIs deprecadas.

---

## 📋 Lista de Verificación de Auditoría (Checklist)

### 1. Gestión de Transacciones (Transactions)
*   **Regla C#:** Cada modificación del modelo debe encapsularse en un bloque `using (Transaction tx = new Transaction(doc, "Name"))`. El bloque debe contener `tx.Start()` y `tx.Commit()` (o `tx.RollBack()` en caso de excepción).
*   **Regla Python (pyRevit):** Se debe usar el gestor de contexto nativo `with revit.Transaction("Name"):`.
*   **Filtro:** Las consultas de datos puras (FilteredElementCollector de solo lectura) **no deben** envolverse en transacciones para evitar bloqueos innecesarios en el modelo.

### 2. Seguridad de Hilos (Thread Safety)
*   **Regla de Oro:** La API de Revit **no es segura para subprocesos**. Toda consulta o modificación de elementos debe realizarse dentro del hilo principal de ejecución de Revit (llamado por comandos o aplicaciones externas de Revit).
*   **Filtro:** Si detectas llamadas asíncronas (`async/await`, `Task.Run` o `Thread.Start`) interactuando directamente con objetos de Revit (`Element`, `Document`), levanta una alerta crítica de inmediato y sugiere el uso de `ExternalEvent`.

### 3. Rendimiento en Colectores (Collector Performance)
*   **Filtro Rápido:** Prioriza siempre filtros rápidos (`OfClass()`, `OfCategory()`) antes de aplicar filtros lentos o consultas LINQ en memoria.
*   **Filtro:** Siempre verifica que el colector llame a `WhereElementIsNotElementType()` a menos que busques explícitamente tipos de familias.

### 4. Limpieza de Recursos y ElementIds (Revit 2024+)
*   **ElementId as Int64:** Asegúrate de que no se llame a `ElementId.IntegerValue`. En su lugar, usa `ElementId.Value` (retorna un tipo `long`).
*   **Topografía:** Comprueba que no se use `TopographySurface`. En su lugar, se debe usar la clase moderna `Toposolid`.
*   **Unidades:** Valida que no se usen enumeraciones de tipo `DisplayUnitType`. En su lugar, usa `ForgeTypeId` con la clase utilitaria `UnitUtils`.

---

## 🚀 Instrucciones para Generar el Reporte de Auditoría

Al finalizar tu revisión, proporciona los hallazgos estructurados bajo la siguiente plantilla de salida:

1.  **Diagnóstico General:** Resumen en un párrafo indicando si el código es apto o requiere modificaciones.
2.  **Alertas Críticas (Bloqueantes):** Problemas de hilos, transacciones sin cerrar o fugas de memoria.
3.  **Advertencias (Mejoras):** Optimización de colectores, uso de APIs obsoletas o formato de estilo (C# 12 / PEP 8).
4.  **Propuesta de Código Corregido:** Fragmento de código completo aplicando las correcciones propuestas.
