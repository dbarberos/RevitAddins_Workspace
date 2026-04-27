---
name: revit-addin-icon-manager
description: Automatiza la sustitución de iconos por defecto en proyectos de Revit por imágenes personalizadas, gestionando recursos .csproj e inyección de código C#.
---

# Revit Add-in Icon Manager (v2.0)

Este skill automatiza la integración de iconos personalizados en complementos de Revit, gestionando desde la preparación de archivos hasta la modificación del proyecto `.csproj` y la refactorización del código C# para asegurar una visualización correcta (incluyendo soporte para DPI y temas oscuros).

## Cuándo usar
- Al preparar un add-in de Revit para su compilación final o distribución.
- Cuando se desea cambiar el branding visual del Ribbon sin realizar ediciones manuales repetitivas.

## 🟢 1. Diagnóstico Activo (Mínima Interacción)
Antes de preguntar al usuario, el agente **DEBE** intentar descubrir de forma autónoma:
1.  **Ruta del Proyecto:** Localizar el archivo `.csproj` y la clase `IExternalApplication` (habitualmente `App.cs` o `Application.cs`).
2.  **Versión de Revit:** Extraerla del `.csproj` o de las referencias a la API para ajustar consejos sobre Temas Oscuros (Revit 2024+).
3.  **Fuentes de Iconos:** Buscar carpetas `/icons` o `/assets` en la raíz.
4.  **Botones Existentes:** Analizar el código para identificar qué botones necesitan nuevos iconos.

*Solo si hay ambigüedad crítica (ej. múltiples proyectos o múltiples imágenes sin nombres claros), el agente solicitará aclaración.*

## 🛠 2. Procedimiento de Ejecución Técnica

### Paso A: Gestión de Imágenes
- **Carpeta de Destino:** Asegurar la existencia de `Resources/Icons/` dentro del proyecto.
- **Mapeo por Tamaño:** 
    - Imagen de ~32px o con "32" en nombre -> `LargeImage`.
    - Imagen de ~16px o con "16" en nombre -> `Image`.
- **Sobrescritura:** Preferir sobrescribir los archivos de la plantilla (`RibbonIcon32.png`) para evitar cambios innecesarios en el código, a menos que el usuario prefiera nombres específicos.

### Paso B: Modificación del Proyecto (.csproj)
Asegurar que los iconos estén incluidos como **Resource** (requerido para el esquema `pack://application` de WPF):
```xml
<ItemGroup>
  <Resource Include="Resources\Icons\YourIcon32.png" />
  <Resource Include="Resources\Icons\YourIcon16.png" />
</ItemGroup>
```

### Paso C: Refactorización de Código (C#)
1. **Inyección de Utilidad:** Si no existe, añadir el método para cargar recursos en la clase de la aplicación:
```csharp
private System.Windows.Media.ImageSource GetImageSource(string resourceName)
{
    try
    {
        string assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        // El formato "pack://application" es vital para la resolución de recursos en Revit/WPF
        Uri uri = new Uri($"pack://application:,,,/{assemblyName};component/Resources/Icons/{resourceName}");
        return new System.Windows.Media.Imaging.BitmapImage(uri);
    }
    catch { return null; }
}
```
2. **Vinculación:** Actualizar las propiedades del `PushButtonData`:
   - `button.LargeImage = GetImageSource("YourIcon32.png");`
   - `button.Image = GetImageSource("YourIcon16.png");`

## 🤖 3. Reglas de Comportamiento del Agente
- **Autonomía Total:** Si el agente tiene acceso al sistema de archivos, debe realizar los cambios en el `.csproj` y `.cs` proactivamente.
- **Soporte de Generación:** Si el usuario no tiene iconos, el agente debe ofrecer generarlos (usando `generate_image`) respetando los estándares de Revit.
- **Compilación de Prueba:** Finalizar siempre ejecutando `dotnet build` para garantizar que el `AssemblyName` y las rutas de recursos coinciden.

## 📋 4. Lista de Verificación de Salida
- [ ] Iconos copiados a `/Resources/Icons/`.
- [ ] `.csproj` configurado con `Resource Include`.
- [ ] Método `GetImageSource` funcional e inyectado.
- [ ] Propiedades `.Image` y `.LargeImage` correctamente asignadas.
- [ ] El proyecto compila satisfactoriamente.