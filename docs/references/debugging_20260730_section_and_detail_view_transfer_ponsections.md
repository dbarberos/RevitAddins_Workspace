# Reporte Técnico: Transferencia de Vistas de Sección y Detalle (`ponSections`)

## Resumen del Problema y Solución

En el add-in TransferPlus, la transferencia de vistas no contemplaba la clonación y creación nativa de vistas de **Sección** (`ViewType.Section`) y **Detalle** (`ViewType.Detail`) asociadas a vistas principales. Al intentar utilizar llamadas como `GetSectionBox()` sobre objetos `View`, la compilación fallaba por falta de método en la API de Revit.

### Solución Implementada
1. **Descubrimiento de Vistas Hijas**: `ponSections` analiza `vistaorigen.GetDependentElements()` y busca referencias mediante el parámetro nativo `SECTION_PARENT_VIEW_NAME`.
2. **Reconstrucción Geométrica 3D**: Extracción directa de `Origin`, `RightDirection`, `UpDirection`, `ViewDirection` y `CropBox` del objeto `View` para construir el `BoundingBoxXYZ` transformado sin llamar a métodos inexistentes.
3. **Creación Nativa y Visibilidad**: Creación con `ViewSection.CreateSection`, desbloqueo de `SECTION_COARSER_SCALE_PULLDOWN`, visibilización de categorías `OST_Viewers` y `OST_SectionBox` en la vista padre destino, y transferencia completa de detalles 2D mediante `ponDependientes`.
