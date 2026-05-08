Soportar múltiples versiones de Revit con una sola base de código, a interactuar fluidamente con Excel y a garantizar un rendimiento ultra rápido en modelos masivos mediante diccionarios.

***

# Guía 6: Escalabilidad, Interoperabilidad y Control de Versiones

Esta guía abarca las Lecciones 21, 25, 26 y 27. Se enfoca en estructurar tu código para que funcione de manera inteligente, se conecte con datos externos y escale eficientemente.

## 1. Control de Múltiples Versiones de Revit (Lección 25)

La API de Revit cambia cada año; algunos métodos se añaden y otros se marcan como obsoletos (*deprecated*). Por ejemplo, en Revit 2024+, extraer el valor entero de un ID de elemento usando `IntegerValue` quedó obsoleto a favor del método `Value` (que devuelve un número de 64 bits).

**Mejores Prácticas: Directivas de Preprocesador**
Gracias a las plantillas de *Nice3point*, tu proyecto genera constantes automáticas según la configuración de compilación (ej. `Release R24`, `Release R25`). Utiliza directivas `#if` para pedirle al compilador que ignore o incluya bloques de código basándose en la versión a la que estás apuntando.

**Ejemplo de Código: Extensión para manejar IDs obsoletos**

```csharp
public static class ElementIdExt 
{ 
    // Método universal para obtener el valor numérico del ID sin importar la versión 
    public static long GetIdValue(this ElementId elementId) 
    { 
        if (elementId == null) return -1; 

        // El compilador leerá esta parte SOLO si apuntas a Revit 2024 o superior 
        #if Revit2024 || Revit2025 || Revit2026 
        return elementId.Value; 
        // El compilador leerá esta parte SOLO si apuntas a Revit 2023 o inferior 
        #else 
        return elementId.IntegerValue; 
        #endif 
    } 
}
```

## 2. Disponibilidad Dinámica de Comandos (Lección 21)

No tiene sentido permitir que el usuario ejecute un comando para "Modificar Worksets" si está trabajando dentro de una Familia, ya que generará un error. Debes desactivar (grisar) el botón proactivamente.

**Mejores Prácticas:**
*   Implementa la interfaz `IExternalCommandAvailability`.
*   **Regla de Oro**: El método `IsCommandAvailable` es consultado por Revit constantemente en segundo plano cada vez que el usuario mueve el ratón o cambia algo. **Bajo ninguna circunstancia realices cálculos pesados ni transacciones aquí**, debe ser una simple comprobación booleana.

**Ejemplo de Código: Desactivar botón en Familias**

```csharp
using Autodesk.Revit.DB; 
using Autodesk.Revit.UI; 

public class AvailabilityProjectOnly : IExternalCommandAvailability 
{ 
    public bool IsCommandAvailable(UIApplication uiApp, CategorySet selectedCategories) 
    { 
        if (uiApp.ActiveUIDocument == null) return false; // No hay documento abierto 
        Document doc = uiApp.ActiveUIDocument.Document; 
        
        // Solo estará disponible si NO es un documento de familia 
        return !doc.IsFamilyDocument; 
    } 
}
```

*Uso Práctico: En tu clase Application.cs (OnStartup), enlazas esta clase al botón asignando su nombre a la propiedad AvailabilityClassName del PushButtonData.*

## 3. Interoperabilidad con Excel y NuGet (Lección 26)

Para leer o escribir bases de datos como Excel, el ecosistema de C# usa el administrador de paquetes **NuGet** para instalar librerías creadas por terceros.

**Mejores Prácticas (Librería ClosedXML):**
*   Utiliza `ClosedXML` en lugar del Interop nativo de Office. `ClosedXML` procesa el archivo mucho más rápido en memoria sin requerir que el usuario tenga Excel abierto.
*   Las dependencias (archivos `.dll`) se descargarán y se copiarán automáticamente a la carpeta de tu Add-in. Debes tener cuidado con el "DLL Hell": si otro Add-in de Revit usa una versión diferente de `ClosedXML`, pueden entrar en conflicto.
*   **Apertura Segura**: Antes de intentar leer la data de Excel, debes comprobar que el archivo no esté siendo utilizado por otro programa abriéndolo mediante un `FileStream` en modo `FileShare.Read` dentro de un bloque `try/catch`.

## 4. Rendimiento Extremo con Diccionarios (Lección 27)

Cuando extraes datos de Excel para compararlos con los de Revit (por ejemplo, buscar qué plano en el modelo corresponde a cada fila de Excel), usar listas anidadas con `.Where()` o `for` genera una "complejidad algorítmica" exponencial de tipo O(N^2). A medida que el modelo crece, el plugin se volverá inaceptablemente lento.

**La Solución (O(1)):**
Los **Diccionarios** (`Dictionary<TKey, TValue>`) resuelven este problema estructurando los datos mediante tablas *hash*. Buscar un elemento en un diccionario es prácticamente instantáneo sin importar si hay 100 o 10.000 planos.

**Ejemplo de Código: Mapeo de Planos desde Revit a un Diccionario**

```csharp
using System.Collections.Generic; 
using Autodesk.Revit.DB; 

// ... asumimos que ya ejecutaste tu FilteredElementCollector para traer todos los ViewSheet ... 

// 1. Declarar el Diccionario. La llave (Key) será el Número de Plano, el valor (Value) será el Plano físico de Revit. 
Dictionary<string, ViewSheet> sheetDictionary = new Dictionary<string, ViewSheet>(); 

// 2. Llenar el Diccionario con nuestra lista de elementos 
foreach (ViewSheet sheet in allSheetsInModel) 
{ 
    // Usamos ToLower() para asegurarnos de que no falle si en Excel está en minúsculas 
    string sheetNumberKey = sheet.SheetNumber.ToLower(); 
    
    // Evitar la sobrescritura añadiendo la llave al diccionario 
    if(!sheetDictionary.ContainsKey(sheetNumberKey)) 
    { 
        sheetDictionary.Add(sheetNumberKey, sheet); 
    } 
} 

// 3. Extracción de Alta Velocidad (Digamos que estamos leyendo una fila de Excel que pide el plano "A101") 
string numeroDeExcel = "a101"; 

// TryGetValue busca el plano en 0 milisegundos y lo asigna a 'existingSheet' si lo encuentra 
if (sheetDictionary.TryGetValue(numeroDeExcel, out ViewSheet existingSheet)) 
{ 
    // ¡Plano encontrado! Aquí harías tu actualización 
    string name = existingSheet.Name; 
} 
else 
{ 
    // El plano de Excel no existe en el modelo de Revit (debemos crearlo) 
}
```

***
