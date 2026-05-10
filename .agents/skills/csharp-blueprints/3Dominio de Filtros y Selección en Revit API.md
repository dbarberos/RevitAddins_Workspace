***

# Guía 3: Colección, Filtrado y Selección de Elementos

Esta guía abarca las Lecciones 12, 20, 23 y 24. Extraer datos correctamente marca la diferencia entre un add-in que procesa la información en milisegundos y uno que congela la interfaz de Revit.

## 1. El uso de FilteredElementCollector (Lección 12)

Casi cualquier comando que construyas necesitará interactuar con elementos del modelo. La clase `FilteredElementCollector` actúa de forma similar a una consulta de base de datos. En lugar de pedirle a Revit "dame todos los elementos", aplicamos filtros en cadena (Method Chaining) para acotar la búsqueda.

**Mejores Prácticas: Filtros Rápidos vs. Filtros Lentos**
*   **Filtros Rápidos (Quick Filters)**: Interactúan directamente a nivel de base de datos en Revit sin tener que expandir el elemento en memoria. Ejemplos: `.OfClass()` y `.OfCategory()`. **Siempre debes empezar tu colector con un filtro rápido**.
*   **Filtros Lentos (Slow Filters)**: Tienen un impacto en el rendimiento si se aplican a todo el modelo, porque requieren que Revit analice la información profunda del elemento. Ejemplos: `ElementLevelFilter` o evaluar parámetros de un elemento.

**Ejemplo de Código: Colector Básico de Muros**

```csharp
using Autodesk.Revit.DB; 
using System.Collections.Generic; 

// Se asume que 'doc' es el Documento activo 

// 1. Iniciar el colector 
var walls = new FilteredElementCollector(doc) 
    // 2. Filtro Rápido por Clase 
    .OfClass(typeof(Wall)) 
    // 3. Excluir los tipos (WallTypes), queremos solo las instancias físicas 
    .WhereElementIsNotElementType() 
    // 4. Convertir y cerrar el colector 
    .ToElements();
```

## 2. Colección de Worksets (Lección 20)

Es un error común pensar que todo en Revit es un `Element`. Los Subproyectos (Worksets) son una excepción a esta regla; heredan de `WorksetPreview`, no de `Element`. Por lo tanto, no puedes usar un `FilteredElementCollector` tradicional.

**Ejemplo de Código: Recopilar todos los Worksets de Usuario**

```csharp
using Autodesk.Revit.DB; 
using System.Linq; 

// Se usa FilteredWorksetCollector en lugar de FilteredElementCollector 
var userWorksets = new FilteredWorksetCollector(doc) 
    // Filtramos solo por los creados por el usuario (ignoramos los internos del sistema) 
    .OfKind(WorksetKind.UserWorkset) 
    .ToWorksets() 
    .ToList(); // Convertimos a lista genérica de C# para trabajar más fácil
```

## 3. Filtrado Avanzado con System.Linq (Lección 12)

Aunque la API nativa de Revit posee filtros avanzados (como `WherePasses` junto a `ElementParameterFilter`), son extremadamente complejos y dolorosos de escribir. La alternativa moderna es usar **System.Linq**. Una vez que extraes la información básica de la base de datos, empleas expresiones Lambda (`=>`) para filtrar y ordenar los datos directamente en la memoria de C#.

**Mejores Prácticas con LINQ:**
*   Aplica LINQ solo **después** de haber reducido la cantidad de elementos usando un filtro rápido de Revit.
*   Usa el método `.Cast<T>()` para convertir genéricamente los elementos (`Element`) a su clase real (ej. `ViewSheet`), lo que te dará acceso a sus propiedades específicas.

**Ejemplo de Código: Filtrar y ordenar planos con LINQ**

```csharp
using Autodesk.Revit.DB; 
using System.Linq; 
using System.Collections.Generic; 

List<ViewSheet> validSheets = new FilteredElementCollector(doc) 
    .OfCategory(BuiltInCategory.OST_Sheets) // Filtro rápido 
    .WhereElementIsNotElementType() 
    .Cast<ViewSheet>() // Convertimos a objeto ViewSheet de Revit 
    // LINQ: Filtramos planos que no sean 'Placeholders' 
    .Where(sheet => !sheet.IsPlaceholder) 
    // LINQ: Ordenamos alfanuméricamente por el número de plano 
    .OrderBy(sheet => sheet.SheetNumber) 
    .ToList(); // Retornamos la lista final
```

## 4. Obtener y Establecer la Selección Actual (Lección 23)

A menudo, tus comandos actuarán sobre los elementos que el usuario **ya tiene seleccionados** antes de ejecutar el plugin. Todo esto se gestiona mediante la clase `UIDocument` y su propiedad `Selection`.

**Ejemplo de Código: Método de Extensión para Obtener Elementos Seleccionados**

```csharp
using Autodesk.Revit.UI; 
using Autodesk.Revit.DB; 
using System.Collections.Generic; 
using System.Linq; 

public static class UIDocumentExtensions 
{ 
    // Método para extraer todos los elementos que el usuario tiene seleccionados 
    public static List<Element> GetSelectedElements(this UIDocument uiDoc) 
    { 
        if (uiDoc == null) return new List<Element>(); 
        Document doc = uiDoc.Document; 
        
        // Obtenemos los IDs de la selección actual 
        ICollection<ElementId> selectedIds = uiDoc.Selection.GetElementIds(); 
        
        // Convertimos esos IDs a Elementos físicos con LINQ 
        return selectedIds.Select(id => doc.GetElement(id)) 
            .Where(e => e != null) 
            .ToList(); 
    } 

    // Método inverso para imponer una nueva selección (resaltarlos en azul en pantalla) 
    public static void SetSelectedElements(this UIDocument uiDoc, List<ElementId> idsToSelect) 
    { 
        uiDoc.Selection.SetElementIds(idsToSelect); 
    } 
}
```

## 5. Selecciones Interactivas Controladas: ISelectionFilter (Lección 24)

Si deseas que el usuario haga clic en un objeto en tiempo real (`PickObject` o `PickObjects`), pero quieres restringir en qué puede hacer clic (por ejemplo, "Solo permite seleccionar Habitaciones"), debes implementar un filtro de selección personalizado basado en la interfaz `ISelectionFilter`.

**Ejemplo de Código: Interfaz restrictiva de selección por Categoría**

```csharp
using Autodesk.Revit.DB; 
using Autodesk.Revit.UI.Selection; 

// 1. Definimos la clase que implementa el contrato de ISelectionFilter 
public class CategorySelectionFilter : ISelectionFilter 
{ 
    private BuiltInCategory _targetCategory; 

    // Constructor: Le indicamos qué categoría permitiremos 
    public CategorySelectionFilter(BuiltInCategory category) 
    { 
        _targetCategory = category; 
    } 

    // 2. Regla para elementos físicos 
    public bool AllowElement(Element elem) 
    { 
        if (elem.Category == null) return false; 
        // Solo permitimos el clic si el ID de la categoría coincide 
        return elem.Category.Id.IntegerValue == (int)_targetCategory; 
    } 

    // 3. Regla para referencias (ej. caras, bordes) - no las necesitamos aquí 
    public bool AllowReference(Reference reference, XYZ position) 
    { 
        return false; 
    } 
}
```

**Uso de la clase en un comando:**

```csharp
// Ejecutando la selección restringida a solo Habitaciones (Rooms) 
ISelectionFilter roomFilter = new CategorySelectionFilter(BuiltInCategory.OST_Rooms); 
// El usuario verá el cursor cambiar y solo podrá hacer clic en habitaciones 
IList<Reference> pickedRefs = uiDoc.Selection.PickObjects(ObjectType.Element, roomFilter, "Selecciona habitaciones y pulsa Finish");
```

***