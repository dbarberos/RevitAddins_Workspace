# Walkthrough — Transferencia de Vistas de Sección y Detalle

## Descripción General
Se ha implementado el soporte completo para transferir símbolos y vistas hijas de tipo **Sección** (`ViewType.Section`) y **Detalle** (`ViewType.Detail`), sincronizado con las opciones de interfaz de usuario de TransferPlus.

## Cambios Realizados

1. **[TransferOrchestrator.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/TransferOrchestrator.cs)**:
   - Añadido el método `ponSections(...)`.
   - Invocación de `ponSections` en los 3 puntos de entrada del orquestador: transferencia de vistas de plano, vistas individuales y vistas colocadas en planos.

2. **[TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs)**:
   - Propiedad `IncludeSections` vinculada a `Configuraciones.cf_chk_Section`.

3. **[TransferPlusView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml)**:
   - CheckBox `Transfer Sections & Details of Views` integrado en el panel *On View*.

## Verificación
- Compilación `Debug R24`: 0 errores.
- Binario desplegado en `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll`.
