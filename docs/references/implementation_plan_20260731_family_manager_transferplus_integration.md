# Implementation Plan — Integración del Gestor de Familias (`TransferFamily`) en `TransferPlus`

## 📅 Fecha de Registro: 2026-07-31
## 🌿 Rama Git: `TransferFamily` (marcada sobre `TransferPlus`)

---

## 1. Resumen Ejecutivo y Objetivos

Este plan documenta la estrategia de arquitectura, diseño MVVM, ejecución asíncrona modeless y auditoría de seguridad para la extracción del gestor de familias de `references_examples/BimFM` e integración directa en el add-in `TransferPlus`.

---

## 2. Decisiones Arquitectónicas e Hitos

### 2.1. Aislamiento Estricto MVVM (Fase 1)
- Separación radical de la Vista (`FamilyManagerView.xaml`), el ViewModel (`FamilyManagerViewModel.cs`) y los Modelos (`FamilyItemModel.cs` / `FamilySymbolItemModel.cs`).
- **Independencia de Revit API**: El trío vista-modelos no contiene referencias a `Autodesk.Revit.DB` o `Autodesk.Revit.UI`.
- **Modo de Prueba Aislado (Mock Data)**: El ViewModel incluye la inicialización de datos de prueba en su constructor para permitir la prueba independiente de la UI sin Revit abierto.

### 2.2. Modernización a C# 12 y CommunityToolkit.Mvvm (Fase 2)
- **Constructores Primarios y Generadores de Código**: Adopción de `ObservableObject`, `[ObservableProperty]` y `[RelayCommand]`.
- **Eliminación de Ensamblados Propietarios**: Eliminación de dependencias externas (Scotec/ScaleHQ).

### 2.3. Virtualización Nativa de UI de Alta Eficiencia (Fase 3)
- Activación de virtualización de contenedores en todos los `ListBox`/`ListView` para soportar catálogos de más de 100,000 elementos a 60 fps:
  - `VirtualizingStackPanel.IsVirtualizing="True"`
  - `VirtualizingStackPanel.VirtualizationMode="Recycling"`
  - `VirtualizingStackPanel.IsContainerVirtualizable="True"`
  - `ScrollViewer.CanContentScroll="True"`
  - `ScrollViewer.VerticalScrollBarVisibility="Auto"`

### 2.4. Servicio de Revit y Ejecución Modeless Asíncrona (Fase 4)
- **`FamilyRevitService.cs`**: Encapsula las operaciones `TryLoadFamily` y `TryLoadFamilySymbol`.
- **Supresión de Diálogos Modales (`SilentOverwriteFamilyOption` & `WarningSwallower`)**:
  - `SilentOverwriteFamilyOption`: Implementa `IFamilyLoadOptions` para sobrescribir automáticamente familias y parámetros.
  - `WarningSwallower`: Intercepta y suprime advertencias no fatales (`FailureSeverity.Warning`) en cada transacción de Revit mediante `WarningSwallower.AttachToTransaction(transaction)`.
- **Patrón `RevitTask`**: Despacha comandos desde el ViewModel a través de `RevitTask.RunAsync(app => { ... })` garantizando la ejecución en el hilo principal de Revit sin congelar la ventana de WPF.

### 2.5. Auditoría de Seguridad y Telemetría PII (Fase 5)
- **Mitigación Estricta de Path Traversal (`FamilyFileManager.cs`)**:
  - Sanitización de nombres de archivo con `Path.GetInvalidFileNameChars()`.
  - Resolución canónica con `Path.GetFullPath()`.
  - Verificación de límites de directorio: asegura que todo archivo temporal permanezca estrictamente dentro de `%TEMP%\TransferPlus_Families`.
- **Desensibilización PII de Rutas (`TelemetryLogger.cs`)**:
  - Reemplazo automático de la ruta de usuario de Windows (`C:\Users\<username>`) por `%USERPROFILE%` y directorios temporales por `%TEMP%` en todos los registros de logs y excepciones.

---

## 3. Estructura de Archivos Modificados y Creados

```text
TransferPlus/
├── Models/
│   └── FamilyItemModel.cs                  # [NEW] Modelos de datos puros C#
├── ViewModels/
│   └── FamilyManagerViewModel.cs           # [NEW] ViewModel C# 12 con CommunityToolkit.Mvvm y RevitTask
├── Views/
│   ├── FamilyManagerView.xaml              # [NEW] Vista WPF Fluent estilo PowerRename con Virtualización
│   └── FamilyManagerView.xaml.cs           # [NEW] Code-behind con binding DataContext
├── Services/
│   ├── FamilyFileManager.cs                # [NEW] Gestor seguro de temporales (Anti-Path Traversal)
│   ├── FamilyRevitService.cs               # [NEW] Servicio de Revit con WarningSwallower y SilentOverwrite
│   ├── RevitTask.cs                        # [NEW] Encapsulador asíncrono de IExternalEventHandler
│   ├── TelemetryLogger.cs                  # [NEW] Registro desensibilizado de PII (%USERPROFILE%)
│   └── LoggerService.cs                    # [MODIFY] Integración de saneamiento PII
└── docs/references/
    ├── walkthrough_20260731_family_manager_ui_mvvm_isolation.md
    └── implementation_plan_20260731_family_manager_transferplus_integration.md
```

---

## 4. Plan de Verificación

### 4.1. Verificación Automática (Compilación MSBuild)
```bash
dotnet build "TransferPlus\TransferPlus.csproj" -c "Debug R24" /p:PublishAddin=false /p:DeployAddin=false
```
- **Criterio de Éxito**: `BUILD SUCCESSFUL (0 Errores)`.

### 4.2. Verificación de Seguridad y PII
- Comprobar que en los registros de log nunca aparezca `C:\Users\david.barbero\...`, sino `%USERPROFILE%\...`.
- Comprobar que intentos de nombres de archivo como `../../malicious.rfa` desencadenen una `SecurityException` sin salir de `%TEMP%\TransferPlus_Families`.
