---

# 📘 **Documento Maestro Profesional — Desarrollo de Add-ins para Autodesk Revit (2024+)**

## **1. Propósito del Documento**
Este documento define los estándares técnicos, arquitectónicos y operativos para el desarrollo de add-ins profesionales para Autodesk Revit.  
Su objetivo es:

- Garantizar consistencia entre proyectos  
- Facilitar la generación automática de código mediante IA  
- Asegurar compatibilidad con Revit 2024, 2025 y versiones futuras  
- Establecer un marco de trabajo moderno, escalable y mantenible  

---

# **2. Entorno de Desarrollo**

## **2.1 IDE Recomendado**
- **Visual Studio 2022** (Community o superior)

## **2.2 Framework según versión de Revit**

| Versión Revit | Framework requerido |
|---------------|--------------------|
| Revit 2024 y anteriores | **.NET Framework 4.8** |
| Revit 2025+ | **.NET 8 (Windows)** |

## **2.3 Dependencias esenciales**
Revit requiere dos ensamblados principales:

- `RevitAPI.dll`  
- `RevitAPIUI.dll`

En Revit 2025+ estas referencias se gestionan mediante paquetes NuGet oficiales.

---

# **3. Plantillas y Frameworks Recomendados**

## **3.1 Plantillas Nice3point (estándar recomendado)**

Para garantizar consistencia y rapidez, **todos los proyectos deben generarse utilizando la CLI de .NET con las plantillas de Nice3point**. La IA o el desarrollador no debe crear el `.csproj` ni la estructura básica manualmente desde cero.

Instalación de las plantillas (una sola vez por máquina):

```bash
dotnet new install Nice3point.Revit.Templates
```

**Creación de un nuevo proyecto base:**

```bash
dotnet new revit -n {{ProjectName}}
```

Ventajas de usar este flujo:

- Configuración automática del `.addin`  
- Build events preconfigurados (copiado automático a Revit)
- Soporte multiversión integrado 
- Estructura profesional desde el minuto cero  

## **3.2 Configuración Crítica del Archivo `.csproj`**

Al usar plantillas modernas (como Nice3point), el compilador inyecta muchos espacios de nombres globales de forma automática (Revit API, Nice3point Extensions, colecciones genéricas de .NET, JetBrains.Annotations, etc.).  

**Regla de Oro:**
- Asegúrate **SIEMPRE** de que **`<ImplicitUsings>enable</ImplicitUsings>`** esté configurado en tu archivo `.csproj`. 
- **Nunca establezcas** `<ImplicitUsings>disable</ImplicitUsings>`. Si lo desactivas, los métodos de extensión esenciales (como `Application.CreatePanel()`), las colecciones genéricas y otras dependencias fallarán al compilar y requerirán importaciones de namespaces manuales en todo el código.

---

# **4. Anatomía de un Add-in de Revit**

Todo add-in consta de tres elementos fundamentales:

1. **Archivo Manifiesto (.addin)**  
2. **Clase de Aplicación (`IExternalApplication`)**  
3. **Clases de Comando (`IExternalCommand`)**

---

## **4.1 Archivo Manifiesto (.addin)**

```xml
<?xml version="1.0" encoding="utf-8"?>
<RevitAddIns>
  <AddIn Type="Application">
    <Name>{{PROJECT_NAME}}</Name>
    <Assembly>{{ASSEMBLY_PATH}}</Assembly>
    <AddInId>{{GUID}}</AddInId>
    <FullClassName>{{NAMESPACE}}.Application</FullClassName>
    <VendorId>{{VENDOR_ID}}</VendorId>
    <VendorDescription>{{VENDOR_DESCRIPTION}}</VendorDescription>
  </AddIn>
</RevitAddIns>
```

### **Reglas:**
- El GUID debe ser único  
- El Assembly debe apuntar al `.dll` final  
- El FullClassName debe coincidir exactamente con el namespace y clase  

---

## **4.2 Clase de Comando (`IExternalCommand`)**

```csharp
[Transaction(TransactionMode.Manual)]
public class {{COMMAND_NAME}} : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        UIApplication uiApp = commandData.Application;
        UIDocument uiDoc = uiApp.ActiveUIDocument;
        Document doc = uiDoc.Document;

        try
        {
            {{COMMAND_LOGIC}}
            return Result.Succeeded;
        }
        catch (Exception ex)
        {
            message = ex.Message;
            return Result.Failed;
        }
    }
}
```

### **Reglas:**
- Siempre usar `TransactionMode.Manual`  
- Manejar excepciones de forma controlada  
- Nunca modificar el documento sin transacción  

---

## **4.3 Clase de Aplicación (`IExternalApplication`)**

```csharp
public class Application : IExternalApplication
{
    public Result OnStartup(UIControlledApplication app)
    {
        string tab = "{{TAB_NAME}}";
        app.CreateRibbonTab(tab);

        RibbonPanel panel = app.CreateRibbonPanel(tab, "{{PANEL_NAME}}");

        PushButtonData btn = new PushButtonData(
            "{{BUTTON_ID}}",
            "{{BUTTON_TEXT}}",
            Assembly.GetExecutingAssembly().Location,
            "{{NAMESPACE}}.Commands.{{COMMAND_NAME}}"
        );

        panel.AddItem(btn);
        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication app)
    {
        return Result.Succeeded;
    }
}
```

---

# **5. Reglas de Oro de la API de Revit**

## **5.1 Transacciones**

```csharp
using (Transaction t = new Transaction(doc, "Descripción"))
{
    t.Start();
    // cambios
    t.Commit();
}
```

## **5.2 Búsqueda de elementos**

```csharp
var walls = new FilteredElementCollector(doc)
    .OfCategory(BuiltInCategory.OST_Walls)
    .WhereElementIsNotElementType()
    .ToElements();
```

## **5.3 Unidades y ForgeTypeId**
Desde Revit 2022+:

- Evitar tipos obsoletos basados en enteros  
- Usar `UnitTypeId`, `SpecTypeId`, `ForgeTypeId`  

---

# **6. Estructura de Carpetas Estándar**

Al generar el proyecto mediante la plantilla (y adaptarlo si es necesario), la estructura final debe alinearse a lo siguiente:

```text
/src
  /{{ProjectName}}
    /Application
    /Commands
    /Services
    /Models
    /UI
      /Views        <-- (Ventanas y controles WPF .xaml)
      /ViewModels   <-- (Lógica de presentación .cs, MVVM)
    /Utils
    /Resources      <-- (Para íconos .png de 16x16 y 32x32 del Ribbon)
/addin
  {{ProjectName}}.addin
/docs
  README.md
  CHANGELOG.md
```

*Nota Crítica: Todo nuevo add-in deberá crearse siempre como una carpeta independiente en la raíz del entorno de trabajo (`RevitAddins_Workspace/{{ProjectName}}`).*

---

# **7. Convenciones de Nombres**

| Elemento | Convención |
|----------|------------|
| **Namespace Raíz** | **`{{ProjectName}}`** (Ej. `MyAwesomeAddin`) |
| Clases | PascalCase |
| Métodos | PascalCase |
| Variables | camelCase |
| Comandos | `Cmd{Acción}{Entidad}` |
| Servicios | `{Entidad}Service` |
| Paneles | `{Categoria}Panel` |
| Pestañas | `{Empresa}` |

---

# **8. Patrones de Diseño Recomendados**

- **Service Layer** para lógica de negocio  
- **Command Handler** para comandos complejos  
- **Result<T>** para operaciones seguras  
- **Logger centralizado**  
- **MVVM** para interfaces WPF  

---

# **9. Manejo de Excepciones**

### **Reglas:**
- Nunca mostrar excepciones crudas  
- Siempre loggear  
- Usar `TaskDialog` para errores controlados  

```csharp
catch (Exception ex)
{
    Logger.Log(ex);
    TaskDialog.Show("Error", ex.Message);
    return Result.Failed;
}
```

---

# **10. Flujo de Trabajo Completo**

1. Instalar plantillas Nice3point  
2. Crear proyecto desde Visual Studio  
3. Implementar comandos  
4. Configurar Ribbon  
5. Seleccionar versión objetivo (R24 o R25)  
6. Compilar (copiado automático del .addin)  
7. Depurar en Revit  

---

# **11. Documentación e Historial de Desarrollo (Logs)**

Para asegurar la trazabilidad, depuración y aprendizaje continuo, **se debe mantener un registro de cada creación, iteración o modificación** de un add-in.

- **Regla estricta para el Agente (IA):** Siempre que el usuario indique que la tarea actual ha finalizado o **que los cambios ya funcionan correctamente**, el Agente copiará obligatoriamente los artefactos generados en la carpeta `docs/` dentro del proyecto correspondiente.
- Los archivos deben nombrarse obligatoriamente con el patrón que incluye una o dos palabras clave descriptivas sobre los cambios además de la fecha y hora: `[nombre_artefacto]_[keywords]_[YYYY-MM-DD_HHmm].md`.
- Allí se guardarán las versiones finales de cada iteración:
  - `implementation_plan_[keywords]_[YYYY-MM-DD_HHmm].md`
  - `task_[keywords]_[YYYY-MM-DD_HHmm].md`
  - `walkthrough_[keywords]_[YYYY-MM-DD_HHmm].md`

Esto garantiza que siempre haya una fuente de consulta en el futuro para entender cómo se estructuró el código o por qué se tomaron ciertas decisiones de diseño.

---
