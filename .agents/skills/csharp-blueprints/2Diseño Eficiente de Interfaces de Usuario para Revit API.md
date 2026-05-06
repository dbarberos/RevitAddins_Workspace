Esta sección es fundamental porque define cómo el usuario interactuará con tu código. Construir una interfaz gráfica (UI) de manera modular evitará que tu método de inicio (OnStartup) se convierta en un caos a medida que tu plugin crezca.

***

# Guía 2: Creación Eficiente de la Interfaz de Usuario (Ribbon)

Esta guía abarca las Lecciones 6, 8, 9, 10 y 11. Se centra en cómo construir pestañas, paneles, botones y submenús utilizando métodos de extensión para mantener tu código limpio, además de cómo gestionar recursos visuales (iconos) y textos de ayuda (tooltips).

## 1. Métodos de Extensión para la Interfaz (Lección 9)

Normalmente, para agregar un panel a una pestaña, tendrías que pasar la aplicación como un argumento a una utilidad estática. Para hacer el código más intuitivo y natural, utilizamos **Métodos de Extensión** (Extension Methods) usando la palabra clave `this`. Esto nos permite "extender" las clases nativas de la API de Revit.

**Ejemplo de Código: Extendiendo UIControlledApplication y RibbonPanel**

```csharp
namespace Guru.Extensions 
{ 
    public static class UiApplicationExt 
    { 
        // Extiende la aplicación para añadir un panel fácilmente 
        public static RibbonPanel AddRibbonPanel(this UIControlledApplication uiApp, string tabName, string panelName) 
        { 
            return uiApp.CreateRibbonPanel(tabName, panelName); 
        } 
    } 

    public static class RibbonPanelExt 
    { 
        // Extiende un panel para poder agregarle un botón directamente 
        public static PushButton AddPushButton(this RibbonPanel panel, PushButtonData buttonData) 
        { 
            return panel.AddItem(buttonData) as PushButton; // Se castea a PushButton 
        } 
    } 
}
```

*Uso práctico: En tu método OnStartup, ahora puedes escribir simplemente `uiApp.AddRibbonPanel(...)` en lugar de crear llamadas complejas y repetitivas.*

## 2. Creación de Botones Simples: PushButton (Lección 6)

El `PushButton` es el botón básico de ejecución. Para crearlo en Revit, primero se necesita un "molde" con sus datos llamado `PushButtonData`. Los argumentos requeridos para este objeto son:
1.  **Nombre interno**: Un identificador único (que el usuario no ve).
2.  **Texto visible**: Lo que aparece escrito en la cinta de Revit.
3.  **Assembly Path**: La ruta de tu archivo `.dll`.
4.  **Full Class Name**: El nombre de la clase (incluyendo el *Namespace*) que contiene el método `Execute` del comando.

**Ejemplo de Código: Generando el Botón**

```csharp
using System.Reflection; 
using Autodesk.Revit.UI; 

// 1. Obtener la ruta del Assembly que se está ejecutando 
string assemblyPath = Assembly.GetExecutingAssembly().Location; 

// 2. Definir los datos del botón 
PushButtonData btnData = new PushButtonData( 
    "cmdMiHerramienta", // Nombre Interno 
    "Ejecutar\nHerramienta", // Nombre Visible (\n crea un salto de línea) 
    assemblyPath, // Ruta del DLL 
    "Guru.Commands.MiComando" // Namespace + Clase 
); 

// 3. Añadirlo al panel usando nuestro método de extensión 
PushButton myButton = miPanel.AddPushButton(btnData);
```

## 3. Tooltips e Iconos Profesionales (Lección 8)

Evita utilizar rutas de archivos locales en el disco duro (ej. `C:\mis_imagenes\...`), ya que fallarán al compartir el plugin. Debes incrustar las imágenes como **Embedded Resources** (Recursos Incrustados) desde las propiedades en Visual Studio.

### Gestión de Iconos
Revit usa dos tamaños estándar a 96 DPI: **16x16 píxeles** (para menús pequeños o desplegables) y **32x32 píxeles** (para el botón principal). Revit requiere que las imágenes se conviertan al formato `ImageSource` nativo de Windows.

**Ejemplo Conceptual: Extracción del Icono Incrustado**
Para transformar la imagen desde el ensamblado, se utiliza un `ManifestResourceStream` y un decodificador:

```csharp
// Ruta de recurso (Nota: Se usan puntos en lugar de barras) 
string resourcePath = "Guru.Resources.Icons32.MiIcono32.png"; 

// Extraer el archivo de la memoria (Stream) 
using (Stream stream = assembly.GetManifestResourceStream(resourcePath)) 
{ 
    // Decodificar el PNG en un ImageSource para Revit 
    PngBitmapDecoder decoder = new PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default); 
    ImageSource imageSource = decoder.Frames[0]; 

    // Asignar al botón (LargeImage = 32x32, Image = 16x16) 
    myButton.LargeImage = imageSource; 
}
```

### Gestión de Tooltips
Para los Tooltips (el cuadro de ayuda que aparece al posar el cursor), se recomienda crear un archivo `.resx` (Resource File) que funcione como un diccionario. Al abrir Revit, usas la clase `ResourceManager` de C# para cargar todos estos textos de ayuda en un Diccionario global en memoria y luego asignarlos usando `myButton.ToolTip = "Texto buscado"`.

## 4. Ahorro de Espacio: PullDowns y Stacks (Lecciones 10 y 11)

A medida que sumas herramientas, el Ribbon se llenará rápido. Agrupar botones es vital para una buena experiencia de usuario (UX).

### A. PullDownButton (Botones Desplegables)
Un `PullDownButton` consolida múltiples comandos bajo una sola flecha desplegable. A diferencia del `PushButton`, un PullDown **no ejecuta ningún comando directamente**, por lo que su clase *Data* (`PulldownButtonData`) no requiere ruta de Assembly ni nombre de clase de ejecución, solo su nombre interno y texto visible.

**Ejemplo de Código:**

```csharp
// 1. Crear la data del menú desplegable 
PulldownButtonData pullDownData = new PulldownButtonData("grupoMuros", "Herramientas\nde Muros"); 

// 2. Añadir el PullDown al Panel 
PulldownButton pullDown = miPanel.AddItem(pullDownData) as PulldownButton; 

// 3. Añadir PushButtons DENTRO del PullDown 
pullDown.AddPushButton(btnData1); // Botón 1 
pullDown.AddPushButton(btnData2); // Botón 2
```

### B. Stacked Items (Botones Apilados)
Si prefieres que los botones sean visibles inmediatamente pero ocupen menos espacio, puedes apilar verticalmente hasta 3 botones (PushButtons o PullDowns) en el mismo espacio que ocuparía un botón grande.

**Ejemplo de Código: Apilando 3 Botones**

```csharp
// Se utiliza el método AddStackedItems y se pasan 2 o 3 objetos "Data" 
IList<RibbonItem> stackedItems = miPanel.AddStackedItems(btnData1, btnData2, btnData3); 
// Revit los colocará usando automáticamente sus iconos de 16x16 píxeles
```

## 5. Interoperabilidad Revit + WPF (.NET)

Cuando se desarrollan interfaces modernas usando WPF dentro de Revit, hay una regla de oro para la estabilidad del add-in:

### El Problema del Dispatcher
En una aplicación WPF estándar, se suele usar `System.Windows.Application.Current.Dispatcher` para actualizar la interfaz desde otros hilos. Sin embargo, en Revit (que es una aplicación nativa C++ que hospeda .NET), `Application.Current` suele ser **null**. Intentar usarlo provocará un error de referencia nula.

### La Solución: Safe Dispatcher
Para actualizaciones asíncronas de la UI o para asegurar que un código se ejecute en el hilo principal de la interfaz, utiliza siempre:

```csharp
// FORMA SEGURA (Recomendada en Revit)
var dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
dispatcher.InvokeAsync(() => {
    // Código que actualiza la UI (ej: limpiar un TextBox)
    this.MyProperty = string.Empty;
});
```

*Uso: Aplica esto en tus ViewModels o Commands cuando necesites limpiar campos de texto o actualizar colecciones tras una operación pesada de la API de Revit.*

***

Al estructurar la interfaz con Métodos de Extensión y agrupar correctamente usando PullDowns y Stacks, la clase `Application.cs` (`OnStartup`) quedará extremadamente limpia y legible.