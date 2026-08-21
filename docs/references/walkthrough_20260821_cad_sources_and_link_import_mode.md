# Walkthrough - Integración de Fuentes Externas CAD (Multi-Cloud) y Selector de Modo Import / Link

Se ha completado la integración y despliegue del sistema de gestión de fuentes externas para **CAD Details Manager**, replicando la arquitectura, ventanas y lógica de **Families Manager** con soporte para todos los formatos CAD y 3D soportados por Revit (`.dwg`, `.dxf`, `.axm`, `.sat`, `.dgn`, `.obj`, `.3dm`, `.skp`, `.stl`), además de añadir el selector contextual de modo de transferencia (**Import CAD** vs **Link CAD**).

---

## 1. Novedades y Componentes Desarrollados

### A. Botón "Sources" y Ventanas de Configuración CAD
- **Botón `Sources`**: Añadido en la tarjeta `CAD Details Manager` de [TransferPlusView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml), con layout de 5 columnas alineado con la tarjeta `Families Manager`.
- **Ventana Principal de Fuentes CAD**: [CadSourcesWindow.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/CadSourcesWindow.xaml) gestionada por [CadSourcesViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/CadSourcesViewModel.cs).
- **Selector de Tipo de Fuente**: [CadSourceTypeWindow.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/CadSourceTypeWindow.xaml) gestionada por [CadSourceTypeViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/CadSourceTypeViewModel.cs).
- **Persistencia Segura DPAPI**: [CadSourceConfigService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/CadSourceConfigService.cs) guarda y recupera la configuración de fuentes desde `%APPDATA%\TransferPlus\cad_sources.json` con cifrado Windows DPAPI.

```
[CAD Details Manager Card]
├── Activate
├── Desactivate
└── Sources  ──►  [CadSourcesWindow]
                     ├── Add Source  ──►  [CadSourceTypeWindow]
                     │                       ├── Autodesk Docs (APS)
                     │                       ├── Azure Storage
                     │                       ├── AWS S3
                     │                       └── Directory
                     ├── Edit Source
                     ├── Remove Source
                     └── Active Checkbox (determina visibilidad en dropdown)
```

---

### B. Selector Condicional de Modo de Transferencia (Import CAD / Link CAD)
Añadido en la tarjeta **Select Details/CAD**, columna **ORGANIZE**:
- **RadioButtons en dos filas**:
  1. `Import CAD` (Predeterminado para todas las fuentes).
  2. `Link CAD` (Habilitado **únicamente** cuando la fuente seleccionada es una **Carpeta Local** o **Autodesk Docs**).
- **Regla de habilitación**:
  - Si la fuente es **AWS S3**, **Azure Storage**, un **Modelo de Revit Abierto** o un **Modelo Vinculado**, la opción `Link CAD` se deshabilita automáticamente y se fuerza la selección de `Import CAD`.

---

### C. Proveedores CAD y Factoría Polimórfica (`ICadProvider`)
- [ICadProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/ICadProvider.cs): Interfaz común para escaneo y transferencia asíncrona de archivos y vistas CAD.
- [LocalFolderCadProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/LocalFolderCadProvider.cs): Exploración de carpetas locales y subcarpetas para los 9 formatos CAD/3D.
- [AzureStorageCadProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/AzureStorageCadProvider.cs): Descarga segura a caché local temporal y transferencia.
- [AwsS3StorageCadProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/AwsS3StorageCadProvider.cs): Conexión S3 / MinIO para transferencias CAD.
- [AutodeskDocsCadProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/AutodeskDocsCadProvider.cs): Conexión con Autodesk APS Data Management para CAD en BIM 360 / ACC.
- [OpenDocumentCadProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/OpenDocumentCadProvider.cs): Vistas de diseño e importaciones en modelos abiertos.
- [LinkedDocumentCadProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/LinkedDocumentCadProvider.cs): Elementos CAD desde instancias vinculadas.
- [CadProviderFactory.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/CadProviderFactory.cs): Resuelve el proveedor adecuado según la selección de `Apply transfer from:`.

---

### D. Motor de Transferencia de Revit (`TransferExternalCadToDraftingView`)
Implementado en [FamilyRevitService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/FamilyRevitService.cs):
- Crea una vista de diseño (`ViewDrafting`) dedicada con el nombre `CAD - [FileName]` (o nombre único con sufijo si ya existe).
- Asigna escala 1:1 (`view.Scale = 1`).
- Si `isLinkMode == true`: invoca `targetDoc.Link(filePath, linkOptions, newDraftingView, out _)`.
- Si `isLinkMode == false`: invoca `targetDoc.Import(filePath, impOptions, newDraftingView, out _)`.

---

## 2. Verificación de Compilación

La solución se ha compilado con éxito mediante el CLI de .NET:
```powershell
dotnet build TransferPlus/TransferPlus.csproj -c Debug.R24 /p:DeployAddin=false
```
**Resultado:** `0 Errores`, código de salida `0`.
