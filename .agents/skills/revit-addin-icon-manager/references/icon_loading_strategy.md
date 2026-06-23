# Estrategia de Carga e Integración de Iconos en Revit

Este documento describe las especificaciones técnicas para integrar imágenes personalizadas en los paneles de la cinta de opciones (Ribbon) de Autodesk Revit, abarcando compatibilidad de temas y configuraciones de compilación de recursos WPF.

---

## 1. Fase de Diagnóstico Activo

El agente debe determinar automáticamente lo siguiente antes de modificar cualquier archivo:
1.  **Ruta del Proyecto**: Buscar la clase `IExternalApplication` (p. ej. `App.cs` o `Application.cs`) y el archivo `.csproj`.
2.  **Versión de Revit**: Extraer la versión objetivo para aplicar correctamente el soporte del Tema Oscuro (disponible a partir de Revit 2024+).
3.  **Fuentes de Iconos**: Detectar carpetas `/Icons` o `/Resources` existentes en el proyecto.
4.  **Botones Existentes**: Inspeccionar la configuración de Ribbon de la aplicación para listar los botones que requieran iconos.

---

## 2. Procedimiento Técnico de Ejecución

### Paso A: Gestión y Organización de Archivos de Imagen
*   **Ruta Estándar**: Copiar las imágenes en la subcarpeta `Resources/Icons/` del proyecto.
*   **Mapeo por Resolución**:
    *   Imagen de **32x32 px** (o nombre con "32") -> Se asigna a la propiedad `LargeImage` del botón.
    *   Imagen de **16x16 px** (o nombre con "16") -> Se asigna a la propiedad `Image` del botón.
*   **Sustitución**: Es preferible conservar el nombre de la plantilla (p. ej., `RibbonIcon32.png`) para minimizar modificaciones en el código de inicialización, a menos que el desarrollador solicite nombres personalizados.

### Paso B: Modificación del Proyecto (.csproj)
Los iconos de Revit **deben** compilarse como **Resource** para que estén disponibles en el ensamblado a través del esquema `pack://application` de WPF:

```xml
<ItemGroup>
  <Resource Include="Resources\Icons\YourIcon32.png" />
  <Resource Include="Resources\Icons\YourIcon16.png" />
</ItemGroup>
```

---

## 3. Consideraciones de Pantallas y Temas (DPI y Dark Theme)

*   **Tema Oscuro (Revit 2024+)**: Si el add-in soporta Revit 2024+, es recomendable utilizar formatos vectoriales (.svg o iconos de alta resolución con transparencia transparente) para evitar fondos grises o blancos que rompan la estética del tema oscuro en la interfaz de Revit.
*   **Uso de pack://application**: Esta URI de recursos es vital en complementos de Revit, ya que garantiza que WPF pueda cargar la imagen directamente desde la memoria del ensamblado de la aplicación, evitando dependencias de rutas físicas absolutas que fallarían al instalar el complemento en computadoras de clientes.
