***

# Guía 1: Estructura y Patrones de Arquitectura Base en Revit API

Esta guía asienta los cimientos para el desarrollo de tu add-in, abarcando cómo definir clases, implementar las interfaces obligatorias de Revit, gestionar variables globales y construir código escalable mediante genéricos.

## 1. Clases, Propiedades y Modificadores de Acceso (Lección 4)

En el desarrollo de un add-in, el código debe organizarse cuidadosamente bajo distintos **Namespaces** (espacios de nombres) para evitar ambigüedades. Las clases funcionan como plantillas o "moldes" que dictan qué pueden hacer los objetos.

**Mejores Prácticas y Conceptos:**
*   **Clases Estáticas vs. Instanciadas**: Si necesitas crear un "Toolkit" o conjunto de utilidades que llamarás directamente sin crear un objeto nuevo, usa `public static class`. Si vas a crear múltiples copias o representar un objeto (como un formulario de resultados), usa `public class`.
*   **Campos Privados vs Propiedades Públicas**: Oculta la información de la clase usando campos privados (minúsculas) y exponla mediante propiedades públicas (PascalCase) con métodos get y set. Esto protege tu código para que no sea modificado de forma insegura por otras clases.

**Ejemplo de Código: Clase base para manejar resultados de formularios (FormResult)**

```csharp
namespace Guru.Forms 
{ 
    public class FormResult 
    { 
        // Propiedad pública que el resto del código puede leer y modificar 
        public bool Cancelled { get; set; } 
        public bool IsValid { get; set; } 

        // Constructor para cuando no damos argumentos (estado por defecto) 
        public FormResult() 
        { 
            this.Cancelled = true; 
            this.IsValid = false; 
        } 

        // Método para invalidar rápidamente el formulario 
        public void SetToInvalid() 
        { 
            this.Cancelled = true; 
            this.IsValid = false; 
        } 
    } 
}
```

*En este ejemplo, usamos la palabra clave `this` para referirnos a las variables de la instancia actual de la clase.*

## 2. Implementación de Interfaces de Revit (Lección 5)

La API de Revit exige que utilicemos "interfaces" que actúan como contratos obligatorios que nuestras clases deben cumplir. Estas interfaces nos brindan el punto de entrada al programa.

### A. La Interfaz IExternalApplication (El arranque del plugin)
Esta clase se ejecuta cuando Revit arranca y se cierra. Nos da acceso a la `UIControlledApplication`, que es necesaria para construir el Ribbon (la cinta de opciones) antes de que el usuario abra un modelo.

**Ejemplo de Código:**

```csharp
using Autodesk.Revit.UI; 

namespace Guru 
{ 
    public class Application : IExternalApplication 
    { 
        public Result OnStartup(UIControlledApplication uiControlledApp) 
        { 
            // Lógica para crear las pestañas y botones del Ribbon aquí... 
            return Result.Succeeded; // Retorno obligatorio para cumplir la interfaz 
        } 

        public Result OnShutdown(UIControlledApplication uiControlledApp) 
        { 
            // Lógica de limpieza al cerrar Revit 
            return Result.Succeeded; 
        } 
    } 
}
```

### B. La Interfaz IExternalCommand (La ejecución del botón)
Esta interfaz requiere el método `Execute`. Cuando el usuario presiona tu botón, este es el código que se detona. Nos provee `ExternalCommandData`, que permite obtener el documento activo en ese momento. Es obligatorio decorar esta clase con el atributo de transacción `[Transaction(TransactionMode.Manual)]` si queremos alterar el modelo.

**Ejemplo de Código:**

```csharp
using Autodesk.Revit.Attributes; 
using Autodesk.Revit.DB; 
using Autodesk.Revit.UI; 

namespace Guru.Commands.General 
{ 
    [Transaction(TransactionMode.Manual)] 
    public class CommandTest : IExternalCommand 
    { 
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements) 
        { 
            // Extraer la aplicación y el documento activo 
            UIApplication uiApp = commandData.Application; 
            UIDocument uiDoc = uiApp.ActiveUIDocument; 
            Document doc = uiDoc.Document; 

            // Lógica principal de tu herramienta aquí... 
            return Result.Succeeded; 
        } 
    } 
}
```

## 3. Variables Globales y Evento "Idling" (Lección 7)

A diferencia de otros lenguajes, C# no tiene variables globales por defecto. A veces necesitamos tener acceso continuo a la aplicación (`UIApplication`), incluso fuera de la ejecución normal de un comando.

**El Problema**: Al arrancar Revit (`OnStartup`), la `UIApplication` no está disponible todavía.
**La Solución**: Nos suscribiremos a un "Evento" de Revit llamado `Idling` (cuando Revit se queda inactivo por primera vez). Una vez dispare, recolectamos la aplicación, la guardamos en nuestra clase `Globals` y nos **desuscribimos inmediatamente** para no consumir recursos el resto de la sesión.

**Ejemplo de Código: Gestión del Evento**

```csharp
public static class Globals 
{ 
    // Nuestra variable global que retendrá la aplicación 
    public static UIApplication UiApp { get; set; } 

    // Este método se llamará en OnStartup 
    public static void RegisterProperties(UIControlledApplication uiControlledApp) 
    { 
        // Nos suscribimos al evento Idling 
        uiControlledApp.Idling += RegisterUiApp; 
    } 

    // Este método captura el evento cuando ocurre 
    private static void RegisterUiApp(object sender, Autodesk.Revit.UI.Events.IdlingEventArgs e) 
    { 
        // 1. Nos desuscribimos de inmediato para que no vuelva a correr 
        var uiControlledApp = sender as UIControlledApplication; 
        if(uiControlledApp != null) uiControlledApp.Idling -= RegisterUiApp; 

        // 2. Extraemos el sender como UIApplication y lo guardamos 
        if (sender is UIApplication app) 
        { 
            UiApp = app; 
        } 
    } 
}
```

## 4. Métodos y Clases Genéricas `<T>` (Lección 22)

A medida que el código crece, nos encontraremos convirtiendo objetos o pasando variables sin un tipo claro (Casting). Las genéricas permiten flexibilizar las clases para que acepten un tipo que se declara en el momento de usarse, mejorando la seguridad, la legibilidad y el autocompletado en el IDE.

**Mejores Prácticas:**
*   Reemplazar usos genéricos de `object` por `T` en tus utilidades.
*   Al declarar algo no existente usar `default(T)` en vez de `null`, ya que los tipos valor (como `int` o `bool`) no pueden ser "nulos", por lo que `default(T)` se ajustará dinámicamente según lo que espere el código (0 para enteros, `false` para boleanos, etc.).

**Ejemplo de Código: Mejora de la clase FormResult con Generics**

```csharp
// Al añadir <T>, decimos que esta clase guardará un objeto de cualquier tipo 
public class FormResult<T> 
{ 
    // Ahora Object no es un "object" ambiguo, sino del tipo T especificado 
    public T Object { get; set; } 
    public List<T> Objects { get; set; } 

    public FormResult() 
    { 
        // Inicializamos los valores basados en el default del tipo provisto 
        this.Object = default(T); 
        this.Objects = new List<T>(); 
    } 
}
```

*Uso práctico: En lugar de recuperar la información genérica e insegura, la declaramos al usarla:* `FormResult<ViewSheet> form = new FormResult<ViewSheet>();`. *Ahora el IDE y el compilador saben sin dudar que form.Object es un plano (ViewSheet), ahorrando líneas de conversión (casting) y minimizando errores durante la ejecución.*

***
