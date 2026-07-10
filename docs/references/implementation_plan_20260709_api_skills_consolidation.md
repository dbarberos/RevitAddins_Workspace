# Plan de Actuación: Integración, Limpieza y Consolidación de Habilidades de Revit API (UX, Export, Worksharing)

Este plan detalla las acciones para estructurar el conocimiento avanzado de Revit API de `docs/revit-api-docs-golden-assets` dentro de `.agents/skills/`.

Consolidaremos toda la tecnología de interfaz de usuario avanzada (tanto WPF nativa como WebView2/React para visores y gráficos web) en un único módulo especializado (`revit-api-ux`), previniendo la dispersión y asegurando que el agente localice este conocimiento en el futuro.

## Objetivos Clave
1. **Consolidación de UI en `revit-api-ux`**: Reubicar `DockablePaneWebViewRegistration.cs`, `WebMessageRouter.cs` y su guía `17_WebView2_and_WebUI.md` desde `revit-api-core` hacia `revit-api-ux` para unificar WPF y WebUI en un solo skill de interfaces avanzadas.
2. **Prevención de Duplicados**: Eliminar `DwgExportManager.cs` (enterprise) y `14_Worksharing_and_Worksets.md` (core) al ser reemplazados por sus versiones senior avanzadas.
3. **Planning Gate en AGENTS.md**: Registrar las tres nuevas habilidades y definir sus reglas de validación previa obligatoria.

---

## Cambios Propuestos

### Componente: Registro e Instrucciones Globales del Agente

#### [MODIFY] [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md)
* **Tabla de Skills (Sección 6)**: Añadir `revit-api-export`, `revit-api-ux` y `revit-api-worksharing`.
* **Planning Gate (Sección 6.1)**: Añadir tres reglas de comprobación obligatoria durante el análisis del plan:
  1. *Advanced UX & WebUI (revit-api-ux)*: Registro exclusivo de `IDockablePaneProvider` en `OnStartup`, MVVM desvinculado de la API y soporte para visores Web/React hospedados con WebView2.
  2. *Deliverables & Exporters (revit-api-export)*: Regeneración de vistas antes de exportar, comprobación multiversión de PDF nativo y tablas de mapeo de capas CAD.
  3. *Multi-user Concurrency & Coordinates (revit-api-worksharing)*: Comprobación de `doc.IsWorkshared`, préstamos (`Checkout`) silenciosos y flujos de coordenadas georreferenciadas con Survey/Base Point (unpin/pin).

---

### Componente: Habilidad Avanzada de UX/UI (`revit-api-ux`)

#### [NEW] [SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/SKILL.md)
* Archivo índice con cabecera YAML (`name: revit-api-ux`). Indexará WPF y WebView2.

#### [NEW] [Assets y Referencias de revit-api-ux]
* **WPF Assets**: [DockablePaneRegistrator.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/DockablePaneRegistrator.cs), [DynamicEventMonitor.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/DynamicEventMonitor.cs), [ViewModelBase.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/ViewModelBase.cs).
* **WebView2 Assets (Reubicados)**: [DockablePaneWebViewRegistration.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/DockablePaneWebViewRegistration.cs), [WebMessageRouter.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/assets/WebMessageRouter.cs).
* **Referencias**:
  * [31_DockablePanes_and_Providers.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/references/31_DockablePanes_and_Providers.md): Registro nativo de WPF Page en el UI Shell de Revit.
  * [32_WPF_XAML_MVVM.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/references/32_WPF_XAML_MVVM.md): Desacoplamiento de la API en ViewModels e inyecciones WPF.
  * [33_DocumentEvents_and_Idling.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/references/33_DocumentEvents_and_Idling.md): Control de fugas de memoria y desuscripción obligatoria.
  * [17_WebView2_and_WebUI.md (Reubicado)](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-ux/references/17_WebView2_and_WebUI.md): Integración de visores 3D y dashboards React/Angular en Revit.

#### [DELETE] [WebView2 files in revit-api-core]
* Eliminar `WebMessageRouter.cs` y `DockablePaneWebViewRegistration.cs` de `revit-api-core/assets/`.
* Eliminar `17_WebView2_and_WebUI.md` de `revit-api-core/references/`.

#### [MODIFY] [revit-api-core/SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/SKILL.md)
* Eliminar referencias a WebView2/WPF y redirigir al skill `revit-api-ux`.

---

### Componente: Habilidad de Exportación e Interoperabilidad (`revit-api-export`)

#### [NEW] [SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/SKILL.md)
* Archivo índice con cabecera YAML (`name: revit-api-export`).

#### [NEW] [Assets y Referencias de revit-api-export]
* **Assets**: [CadExportManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/CadExportManager.cs), [IfcExportManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/IfcExportManager.cs), [PdfExportManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/PdfExportManager.cs).
* **Referencias**:
  * [34_PDF_and_PrintManager.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/34_PDF_and_PrintManager.md): Generación PDF nativo y fallback con `PrintManager`.
  * [35_DWG_DXF_LayerMapping.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/35_DWG_DXF_LayerMapping.md): Tablas de mapeo de capas CAD avanzadas.
  * [36_IFC_and_ThatOpen_Fragments.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/36_IFC_and_ThatOpen_Fragments.md): IFC4 para fragmentos web.

#### [DELETE] [DwgExportManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-enterprise/assets/DwgExportManager.cs)
* Eliminación física para evitar duplicaciones.

#### [MODIFY] [revit-api-enterprise/SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-enterprise/SKILL.md) & [13_Interoperability_and_REST.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-enterprise/references/13_Interoperability_and_REST.md)
* Quitar referencias de DWG/IFC y enlazar a `revit-api-export`.

---

### Componente: Habilidad de Colaboración y Coordenadas (`revit-api-worksharing`)

#### [NEW] [SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/SKILL.md)
* Archivo índice con cabecera YAML (`name: revit-api-worksharing`).

#### [NEW] [Assets y Referencias de revit-api-worksharing]
* **Assets**: [CoordinateSystemManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/assets/CoordinateSystemManager.cs), [ElementCheckoutHandler.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/assets/ElementCheckoutHandler.cs), [WorksetManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/assets/WorksetManager.cs).
* **Referencias**:
  * [37_Worksets_and_CheckoutStatus.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/references/37_Worksets_and_CheckoutStatus.md): Element Borrowing y base de datos distribuida de Revit.
  * [38_Synchronize_and_Relinquish.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/references/38_Synchronize_and_Relinquish.md): Sincronización e historial de liberaciones.
  * [39_SharedCoordinates_and_BasePoints.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/references/39_SharedCoordinates_and_BasePoints.md): Survey/Base Point pinning y traslaciones.

#### [DELETE] [14_Worksharing_and_Worksets.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-core/references/14_Worksharing_and_Worksets.md)
* Eliminación física para evitar duplicados.

---

## Plan de Verificación

1. **Linter de Habilidades**: Validación de que todos los archivos `SKILL.md` bajo `.agents/skills` conserven su formato YAML.
2. **Prueba de Inferencia**: Realizar una prueba lógica preguntando al agente por la localización de las guías de WebView2 y Base Point para verificar que puede trazarlas dinámicamente desde `revit-api-ux` y `revit-api-worksharing`.
