# Plan de Implementación: Consolidación y Creación del Skill de Diseño de Interfaces (`revit-addin-gui-design`)

Este plan detalla el proceso para unificar todo el conocimiento de diseño de interfaces de usuario (WPF, Fluent UI, virtualización y los estilos de `FilterPlus`) en un único skill centralizado `.agents/skills/revit-addin-gui-design/`. 

Esto evitará la duplicidad y conflictos entre habilidades anteriores (`integrating-wpfui-fluent` y `virtualizing-wpf-ui`), agrupándolas de forma lógica.

## Objetivos Clave
1.  **Eliminar Redundancia**: Unificar los skills `integrating-wpfui-fluent` y `virtualizing-wpf-ui` bajo un único skill maestro de diseño visual y rendimiento: `revit-addin-gui-design`.
2.  **Extracción de Estilos de FilterPlus**: Extraer y documentar los estilos customizados de `FilterPlus` (SwitchStyle, custom TreeView container, card layout, RTL scrollbar, loading overlays) como plantillas reutilizables en C#/XAML.
3.  **Reglas de Performance (Virtualización y Cap Límite)**: Centralizar las guías de virtualización de vistas con grandes volúmenes de elementos y la lógica de seguridad de límite de caché (>100k elementos).
4.  **Actualización Global en `AGENTS.md`**: Registrar el nuevo skill `revit-addin-gui-design` en el Planning Gate global para asegurar su consulta obligatoria en el desarrollo de interfaces.

---

## Cambios Propuestos

### A. Crear la Habilidad Unificada de Diseño de Interfaces (`revit-addin-gui-design`)

#### [NEW] [SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/SKILL.md)
* Archivo índice con ID `SKILL-RVT-GUI` redactado en inglés. Estructurará la teoría y activos de Fluent, Virtualización y FilterPlus.

#### [NEW] [Assets del nuevo Skill]
Trasladar y crear en `.agents/skills/revit-addin-gui-design/assets/`:
1.  `FluentSetupTemplates.cs` & `FluentSetupTemplates.xaml` (Trasladados de wpfui-fluent).
2.  `VirtualizationHelpers.cs` & `VirtualizingDataGrid.xaml` (Trasladados de virtualizing-wpf-ui).
3.  [FilterPlusStyles.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/assets/FilterPlusStyles.xaml): **[NUEVO]** ResourceDictionary XAML con los estilos listos para copiar de ToggleSwitch (`SwitchStyle`), botones de cabecera (`HeaderIconButtonStyle`), bordes de tarjeta (Cards) y scrollbars compactos de FilterPlus.

#### [NEW] [Referencias del nuevo Skill]
Crear y unificar en `.agents/skills/revit-addin-gui-design/references/`:
1.  `50_WPF_UI_Virtualization.md`: Teoría y directrices de virtualización de ListView, TreeView y DataGrid.
2.  `51_WPF_Fluent_Design.md`: Integración de la biblioteca `Wpf.Ui` y Bootstrap de interfaces estilo Windows 11.
3.  [52_FilterPlus_UI_Styling.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-gui-design/references/52_FilterPlus_UI_Styling.md): **[NUEVO]** Guía técnica sobre la composición visual de FilterPlus (uso de cuadrícula de 3 columnas, scrollbar físico a la izquierda mediante RTL parent, overlays de carga y cap de límite de caché en ViewModel).
4.  `debugging_wpf_rtl_scrollviewer_margins_2026-07-02.md` (Trasladado de wpfui-fluent).
5.  `debugging_cache_limit_linked_models_2026-07-08.md` (Trasladado de virtualizing-wpf-ui).

---

### B. Limpieza de Habilidades Obsoletas

#### [DELETE] [Skills wpfui-fluent y virtualizing-wpf-ui]
* Eliminar por completo las carpetas físicas de `.agents/skills/integrating-wpfui-fluent/` y `.agents/skills/virtualizing-wpf-ui/` tras haber consolidado todo su contenido en la nueva carpeta.

---

### C. Registro e Instrucciones Globales del Agente

#### [MODIFY] [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md)
*   **Sección 6 (Skills)**: Remover las filas de `virtualizing-wpf-ui` e `integrating-wpfui-fluent` e incorporar `revit-addin-gui-design`.
*   **Sección 6.1 (Planning Gate)**: Actualizar/Consolidar las reglas de diseño en:
    *   `- **WPF UI Design & Virtualization (revit-addin-gui-design)**: ...` (Unificar las reglas de performance, virtualization, Fluent Window bootstrap y la estética premium inspirada en el diseño de tarjetas y paletas de FilterPlus).

---

## 3. Plan de Verificación

1.  **Linter de Habilidades**: Validación de que todos los archivos Markdown mantengan su estructura YAML limpia en inglés.
2.  **Verificación de Enlaces**: Asegurar que todos los enlaces `file:///` apunten a la nueva carpeta unificada.
3.  **Comprobación de Fusión**: Asegurarse de que no existan carpetas huérfanas de los dos skills antiguos.
