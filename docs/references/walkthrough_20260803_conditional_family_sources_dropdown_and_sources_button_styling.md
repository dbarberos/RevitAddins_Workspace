# Walkthrough — Carga Condicional de Fuentes de Familias y Estilo Visual del Botón "Sources"

**Fecha:** 2026-08-03  
**Add-in:** TransferPlus  
**Componentes Modificados:**
- `TransferPlusViewModel.cs`
- `TransferPlusView.xaml`

---

## 🛠️ Cambios Realizados

1. **Carga Condicional del Desplegable `"Apply transfer from:"` (`TransferPlusViewModel.cs`)**:
   - Se ha modificado `LoadDocuments()` para que **solo** incluya las fuentes de familias guardadas (carpetas locales o contenedores Azure) cuando `IsFamiliesManagerActive == true` (después de pulsar el botón **Activate**).
   - Cuando `IsFamiliesManagerActive == false` (estado por defecto o al pulsar **Desactivate**), el desplegable vuelve a mostrar exclusivamente los modelos abiertos y vínculos de la sesión de Revit.
   - La propiedad `OnIsFamiliesManagerActiveChanged` invoca automáticamente `LoadDocuments()` al alternar entre activado y desactivado.

2. **Estilo del Botón "Sources" idéntico al Botón "Cancel" (`TransferPlusView.xaml`)**:
   - Se ha actualizado el `Button.Style` del botón **Sources** dentro del panel **Families Manager** para copiar exactamente la estética del botón **Cancel** de la ventana principal:
     - **Fondo habitual**: `#E1E1E1`
     - **Borde**: `#707070` (grosor `1px`)
     - **Texto**: `Black` (SemiBold `11.5pt`)
     - **CornerRadius**: `4px`
     - **Hover (`IsMouseOver`)**: `#D5D5D5` y borde `#505050`
     - **Presionado (`IsPressed`)**: `#C5C5C5` y borde `#303030`
     - **Deshabilitado**: `#F3F3F3` con texto `#B0B0B0`

---

## 📊 Verificación y Despliegue

- **MSbuild Command**: `dotnet build "TransferPlus\TransferPlus.csproj" -c "Debug R24"`
- **Resultado**: **0 ERRORS, 0 WARNINGS FATALES** (Build & Auto-Deploy Clean).
- **Ruta de Despliegue**: `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll`.
