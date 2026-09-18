# Walkthrough: Sincronización de Vistas Duplicadas, Filtrado de Visores 2D y Advertencia Pre-flight de Worksets

**Fecha de Implementación:** 2026-07-23  
**Proyecto / Add-in:** TransferPlus  
**Stack Técnico:** C# 12 / .NET Framework 4.8 / Revit API 2024  

---

## 1. Línea de Pensamiento y Evolución de la Solución

```
┌─────────────────────────────────────────────────────────────────────────────┐
│ 1. SÍNTOMA OBSERVADO:                                                      │
│    Se creaban dos vistas al transferir: una primera vista vacía y una     │
│    segunda vista duplicada con sufijo '... 1' con todas las propiedades.     │
└──────────────────────────────────────┬──────────────────────────────────────┘
                                       │
                                       ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│ 2. FASE 1 - CAUSA RAÍZ EN 'CreateViewPlan':                                │
│    En 'Append Suffix', 'CreateViewPlan' creaba un nombre temporal con       │
│    colisión. La captura 'catch' devolvía la vista existente en el destino   │
│    y la renombraba en caliente a '... 1'.                                   │
│    --> FIX FASE 1: Cálculo del nombre con sufijo UPFRONT.                   │
└──────────────────────────────────────┬──────────────────────────────────────┘
                                       │
                                       ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│ 3. FASE 2 - CAUSA RAÍZ EN 'ponDependientes' (Efecto Colateral C++ Revit):  │
│    A pesar del cálculo upfront, los logs revelaron que tras ejecutar        │
│    'ElementTransformUtils.CopyElements' en 'ponDependientes', Revit         │
│    clonaba automáticamente la vista si la lista de 2D incluía visores.      │
│    --> FIX FASE 2: Exclusión de visores/marcadores (ElevationMarker,        │
│        ReferenceViewer, OST_Viewers) en 'ponDependientes'.                   │
└─────────────────────────────────────────────────────────────────────────────┘
```

---

## 2. Resumen de Funcionalidades Implementadas

### A. Filtrado de Visores 2D sin Pérdida de Elementos de Anotación
- **Copia 100% Intacta**: Cotas, textos, líneas de detalle, regiones rellenadas, nubes de revisión y componentes de detalle 2D se transfieren íntegramente mediante `ElementTransformUtils.CopyElements`.
- **Visores Filtrados**: Se excluyen los símbolos de visor (`OST_Viewers`, `ReferenceViewer`, etc.) en `ponDependientes` para evitar que el motor de Revit instancie réplicas con sufijo `1`, dejando la gestión de llamadas a `ponCallouts`.

### B. Pre-flight Check de Subproyectos (`Worksets`)
- **Detección Previa**: Si se detectan subproyectos y algún modelo destino no está en modo colaborativo (`!Adoc.IsWorkshared`), se cancela la operación de forma inmediata sin modificar la base de datos de Revit.
- **Diálogo Modal `TaskDialog`**: Explica claramente en inglés que se cancela la transferencia completa por la incompatibilidad de subproyectos en modelos no colaborativos.

---

## 3. Estado de Compilación y Despliegue
- **Resultado de Compilación**: `.NET Framework 4.8` (`Debug.R24`) — **0 Errores**.
- **Binario Compilado**: Listo en `bin\Debug.R24\TransferPlus.dll` para copiar a `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll` al cerrar Revit.
