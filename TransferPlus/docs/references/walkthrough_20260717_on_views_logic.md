# Walkthrough: Lógica "On Views" y Pre-flight Check de Niveles

## Fecha: 2026-07-17

Se ha completado e integrado toda la lógica de control y transferencia para la tarjeta **"On Views"** en `TransferPlus`. Adicionalmente, se han aplicado mejoras de robustez en la gestión de excepciones y resolución de errores siguiendo las guías de los skills del repositorio.

---

## 1. Cambios Realizados

### A. Pre-flight Check y Diálogo de Mapeo de Niveles
- **LevelConflict.cs**: Modelo observable (marcado como `partial`) que recopila los datos de niveles requeridos por las vistas seleccionadas que no existen en el destino.
- **LevelMappingViewModel.cs & LevelMappingView.xaml**: Ventana modal interactiva en WPF para resolver conflictos de niveles faltantes, ofreciendo opciones automáticas basadas en elevación (exactitud, límites superior e inferior) o creación del nivel.
- **TransferPlusViewModel.cs**: Integración del método `DetectMissingLevels` que realiza un cruce de datos pre-flight y detiene la transferencia para mostrar el diálogo modal de mapeo en caso de haber discrepancias.

### B. Transacción e Inyección Condicional de Warnings
- **WarningSwallower.cs**: Ajustado para filtrar advertencias leves (`FailureSeverity.Warning`) y eliminarlas.
- **TransferOrchestrator.cs**: La supresión de advertencias ahora es condicional a la casilla `cf_chk_AcceptAll`.

### C. Mapeo y Resolución de Errores Críticos (Robustez según Skills)
- **WarningSwallower.cs**: Si se topa con un `FailureSeverity.Error` de Revit:
  1. Registra el mensaje descriptivo del error en el log de diagnóstico y en la consola Debug Log utilizando `LoggerService.LogWarning`.
  2. Verifica si el fallo puede resolverse por defecto mediante `failure.HasResolutions()`.
  3. Si tiene resolución predeterminada (como errores menores que sólo requieren "Aceptar" o autodesunir elementos), aplica `ResolveFailure` y realiza un commit controlado.
  4. Si es un error irresoluble, fuerza un `ProceedWithRollBack` silencioso para evitar que la interfaz de Revit se congele con ventanas de diálogo modales.
- **Estrategia de rehost de niveles**: Para evitar niveles duplicados (ej: "Nivel 1 1") al copiar vistas de planta, si el usuario decide mapear un nivel a uno existente con nombre diferente, el orquestador:
  1. Renombra temporalmente el nivel del destino al nombre del origen.
  2. Ejecuta la transferencia de la vista (haciendo que Revit la asocie a dicho nivel debido a la coincidencia de nombre).
  3. Restaura el nombre original del nivel destino en el bloque `finally`.
  4. Crea niveles nuevos en destino si el usuario así lo decide.

### D. Eliminación de Silent Failures (Logs en Debug)
- **LoggerService.cs**: Ampliado con los métodos `LogWarning(string)` y `LogExceptionSilently(string, Exception)` para reportar incidencias secundarias al registro de diagnósticos y a la consola visual Debug Log de la UI, sin entorpecer al usuario con diálogos emergentes.
- **TransferOrchestrator.cs**: Reemplazados los bloques `catch { }` vacíos por capturas de excepción específicas vinculadas a `LoggerService.LogExceptionSilently` (en copias de viewports, callouts, parámetros, estilos y dependencias).

### E. Replicación Completa de Planos y Viewports
- **TransferOrchestrator.cs**: Se ha implementado la duplicación de `ViewSheet`. Ahora se leen las vistas del plano origen y se copian al destino (o se reutilizan Leyendas, Tablas y Ensamblajes si ya existen y las casillas correspondientes están marcadas). Tras copiar la vista, se genera el `Viewport` en el destino y se alinea calculando las cajas de contorno (`BoundingBoxXYZ`) para conservar la posición exacta en el papel.

---

## 2. Verificación
El add-in ha sido compilado exitosamente para la versión de Revit 2024 (`Debug.R24`) con 0 errores:
```bash
dotnet build TransferPlus/TransferPlus.csproj -c Debug.R24
# Resultado: Éxito (0 errores)
```
