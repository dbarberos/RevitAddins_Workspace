# Plan de Implementación: Actualización a Versión 1.7.0, Documentación Completa y Bundle de Publicación

Siguiendo las directrices del skill `revit-addin-doc-manager` y `revit-appstore-bundle`, este plan detalla la subida de versión menor (**v1.6.0 -> v1.7.0**), la actualización holística de toda la documentación técnica y de usuario en inglés, la sincronización de la ayuda contextual F1 (`help.html`), el archivado de paquetes previos y la generación del nuevo bundle de producción para la Autodesk App Store.

---

## 🎯 Objetivos y Requisitos

1. **Incremento de Versión Menor (Minor Version Bump)**:
   - Incrementar la versión del proyecto de `1.6.0` a `1.7.0` en [FilterPlus.csproj](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/FilterPlus.csproj).
   - Crear el tag de Git `FilterPlus-v1.7.0` una vez completados y validados los cambios.

2. **Actualización de Documentación de Usuario ([user_guide.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/docs/references/user_guide.md))**:
   - Actualizar cabecera a **Current Version: 1.7.0**.
   - **Sección 5.1 Ribbon Panel**: Actualizar la descripción para reflejar que FilterPlus se ubica por defecto en la pestaña nativa de Revit **"Add-Ins" (Complementos)** cumpliendo con los estándares de Autodesk para complementos de comando único, y documentar las opciones de configuración disponibles (pestaña nativa Add-Ins, pestaña contextual Modificar, o pestaña personalizada).
   - **Sección 7 (Changelog)**: Añadir en la parte superior el bloque `### [1.7.0]` respetando el histórico previo, con subsecciones:
     - **Added**: Ubicación por defecto en pestaña Add-Ins, nuevas opciones de configuración de ribbon, migración automática de esquemas XML, arranque silencioso/resiliente ante archivos corruptos, inclusión de recursos de ayuda para Revit 2023.
     - **Changed**: Sustitución del logo de Revit por el icono oficial de FilterPlus (`RibbonIcon32.png`) en todas las ventanas y versión 2023.
     - **Fixed**: Compatibilidad multi-versión de `ElementId` (64-bit vs 32-bit) para Revit 2023, y resolución del error de deserialización `XmlSerializer` (3, 54) por el atributo `[Obsolete]`.

3. **Sincronización de Ayuda Contextual F1 ([FilterPlus/Resources/help.html](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Resources/help.html))**:
   - Actualizar la versión a `v1.7.0`.
   - Sincronizar la sección de Ribbon Panel y el registro de cambios (Changelog) en HTML limpio con los mismos puntos que el manual de usuario.

4. **Archivado de Versiones Anteriores y Generación del Bundle v1.7.0**:
   - Archivar los paquetes zip previos (`FilterPlus_v1.0.0.zip`, `FilterPlus_v1.6.0.zip`) en la carpeta [FilterPlus/Deploy/Archive/](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Deploy/Archive/).
   - Mejorar [build-bundle.ps1](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-appstore-bundle/scripts/build-bundle.ps1) para que lea dinámicamente la versión desde el `.csproj` si no se especifica explícitamente.
   - Recompilar Release para Revit 2023 a 2027 y ejecutar `build-bundle.ps1 -Version "1.7.0"` para generar:
     - [FilterPlus/Deploy/FilterPlus_v1.7.0.zip](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Deploy/FilterPlus_v1.7.0.zip)
     - [FilterPlus/FilterPlusPublishPackage/FilterPlus.bundle.zip](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/FilterPlusPublishPackage/FilterPlus.bundle.zip)
     - [PackageContents.xml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Deploy/FilterPlus.bundle/PackageContents.xml) con `AppVersion="1.7.0"`.

5. **Actualización del Despliegue Local (Debug)**:
   - Recompilar `Debug.R24` y `Debug.R23` con `DeployAddin=true` para que tu instalación local de Revit cuente con los ensamblados v1.7.0 y la ventana de depuración en tiempo real.

6. **Git Commit y Tag**:
   - Hacer commit con un mensaje descriptivo de la versión 1.7.0 y crear el tag anotado `FilterPlus-v1.7.0`.
