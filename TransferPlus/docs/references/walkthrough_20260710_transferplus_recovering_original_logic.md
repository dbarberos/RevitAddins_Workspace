# TransferPlus - Integración y Recuperación

Hemos finalizado el proceso de recuperación del addin antiguo `TransferSingle` y su adaptación al nuevo entorno moderno y limpio dentro del proyecto `TransferPlus`.

## Cambios Realizados

- **Resolución de Errores de Compilación**: Se han corregido las dependencias obsoletas (`!!0` en des-serialización), se han forzado los casteos al tipo `ViewType` y se han convertido los parámetros de tipo entero (`int`) al estándar moderno usando `(BuiltInParameter)`.
- **Estructura de la Interfaz (MVVM)**: 
  - La ventana `TransferPlusView.xaml` ahora respeta exactamente tu distribución en 2 columnas:
    - **Columna Izquierda**: Selector de origen (From), árbol de elementos a seleccionar (What) y selector de modelos destino con *checkboxes* (To).
    - **Columna Derecha**: Las tarjetas (Cards) de acciones como "Include Links", opciones de resolución de duplicados y acciones de renombramiento sobre los ítems.
- **Botón en el Ribbon**: Se ha modificado `Application.cs` para asegurar que el botón aparezca ordenado bajo la pestaña **DBDev** y panel **TransferPlus**.

## Validación

El proyecto ahora **compila con 0 errores** en `.NET Framework 4.8` bajo la configuración `Debug.R24`. La interfaz gráfica se levanta correctamente y cumple con los estándares estéticos indicados en los *skills* (FilterPlus / Fluent UI / GridCards).
