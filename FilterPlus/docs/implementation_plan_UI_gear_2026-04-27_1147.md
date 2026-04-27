# Plan de Implementación: Pulido Visual del Icono de Configuración

Mejorar la estética del botón de configuración para que se integre de forma premium en la interfaz, eliminando el aspecto de botón estándar y utilizando gráficos vectoriales.

## Cambios Propuestos

### Interfaz de Usuario
- **[MODIFY]** `Views/SelectionFilterView.xaml`:
  - Reemplazar el `Button` con borde cuadrado por un estilo minimalista.
  - Utilizar un `Path` vectorial (SVG convertido a XAML) para el icono del engranaje.
  - Eliminar `BorderThickness`, `BorderBrush` y `Background` (ahora `Transparent`).
  - Implementar disparadores (`Triggers`) para un efecto de hover circular sutil.

## Verificación
- Compilar y observar el cambio visual en la ventana principal del add-in.
- Validar que el botón sigue siendo funcional y abre la ventana de configuración.
