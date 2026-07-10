# Walkthrough: Integración de Golden Assets y Consolidación de Skills de Revit API

Hemos completado la estructuración del conocimiento avanzado de Revit API contenido en `docs/revit-api-docs-golden-assets` y consolidado todos los recursos en la carpeta global de habilidades de agente (`.agents/skills/`).

## Resumen de Cambios

### 1. Consolidación de Interfaz de Usuario Avanzada (`revit-api-ux`)
Hemos creado el skill [revit-api-ux](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/SKILL.md) como el centro unificado para todo el desarrollo de UI avanzado de Revit (tanto WPF como WebView2).

*   **Assets WPF**:
    *   [DockablePaneRegistrator.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/DockablePaneRegistrator.cs) (Registro de Page).
    *   [DynamicEventMonitor.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/DynamicEventMonitor.cs) (Sincronización mediante eventos DocumentChanged).
    *   [ViewModelBase.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/ViewModelBase.cs) (Modelo base WPF).
*   **Assets WebView2 y React (Relocados)**:
    *   [DockablePaneWebViewRegistration.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/DockablePaneWebViewRegistration.cs) (Registro de WebView2 Page).
    *   [WebMessageRouter.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/WebMessageRouter.cs) (Ruteador de mensajes asíncronos JS -> C#).
    *   [WebMessageResponseSender.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/WebMessageResponseSender.cs) (Dispatcher C# -> JS).
    *   [DirectDocumentAccessAntiPattern.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/DirectDocumentAccessAntiPattern.cs) (Antipatrón de acceso a API desde hilos web).
*   **Referencias**:
    *   [31_DockablePanes_and_Providers.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/references/31_DockablePanes_and_Providers.md) (Ciclo de vida y registros).
    *   [32_WPF_XAML_MVVM.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/references/32_WPF_XAML_MVVM.md) (Arquitectura y binding).
    *   [33_DocumentEvents_and_Idling.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/references/33_DocumentEvents_and_Idling.md) (Fugas de memoria por desuscripción de eventos).
    *   [17_WebView2_and_WebUI.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/references/17_WebView2_and_WebUI.md) (Paso de mensajes JSON e integración React).
*   **Limpieza**: Removimos los archivos duplicados de WebView2 de `revit-api-core` y enlazamos a este nuevo skill.

### 2. Habilidad de Exportación e Interoperabilidad (`revit-api-export`)
Creamos el skill [revit-api-export](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/SKILL.md) para independizar y optimizar la generación de entregables BIM y CAD.

*   **Assets**:
    *   [CadExportManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/CadExportManager.cs) (DWG con setups por nombre).
    *   [IfcExportManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/IfcExportManager.cs) (IFC4 optimizado para visores de fragmentos web).
    *   [PdfExportManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/PdfExportManager.cs) (Exportación nativa de PDFs en Revit 2022+).
*   **Referencias**:
    *   [34_PDF_and_PrintManager.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/34_PDF_and_PrintManager.md) (PDF nativo y fallback con PrintManager).
    *   [35_DWG_DXF_LayerMapping.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/35_DWG_DXF_LayerMapping.md) (Mapeo de capas).
    *   [36_IFC_and_ThatOpen_Fragments.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/36_IFC_and_ThatOpen_Fragments.md) (OpenBIM web fragments).
*   **Limpieza**: Borramos el asset duplicado `DwgExportManager.cs` en `revit-api-enterprise` y redireccionamos su teoría.

### 3. Habilidad de Colaboración y Coordenadas (`revit-api-worksharing`)
Creamos el skill [revit-api-worksharing](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/SKILL.md) para unificar la concurrencia de base de datos y la georreferenciación.

*   **Assets**:
    *   [CoordinateSystemManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/assets/CoordinateSystemManager.cs) (Unpinning y traslaciones).
    *   [ElementCheckoutHandler.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/assets/ElementCheckoutHandler.cs) (Préstamos y auditoría).
    *   [WorksetManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/assets/WorksetManager.cs) (Reasignación de subproyectos).
*   **Referencias**:
    *   [37_Worksets_and_CheckoutStatus.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/references/37_Worksets_and_CheckoutStatus.md) (CheckoutStatus y concurrencia).
    *   [38_Synchronize_and_Relinquish.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/references/38_Synchronize_and_Relinquish.md) (Sincronizaciones y liberaciones).
    *   [39_SharedCoordinates_and_BasePoints.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/references/39_SharedCoordinates_and_BasePoints.md) (Unpin/pin en Survey y Base Point).
*   **Limpieza**: Eliminamos `14_Worksharing_and_Worksets.md` de `revit-api-core` para que no haya duplicados.

### 4. Registro en el Planning Gate Global
*   Actualizamos [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md) registrando las tres nuevas habilidades.
*   Inyectamos reglas estrictas en la sección `6.1` para que el agente asimile estas directrices de forma autónoma:
    1.  Verificar `doc.IsWorkshared` y aplicar préstamos explícitos.
    2.  Regenerar vistas y validar compatibilidad de PDF nativo.
    3.  Asegurar que los Base Points sean desbloqueados y vueltos a bloquear al trasladar coordenadas.
    4.  Utilizar exclusivamente `IExternalApplication.OnStartup()` para registros de paneles.
    5.  Impedir acceso directo a Revit API desde hilos y subprocesos web en WebView2.
