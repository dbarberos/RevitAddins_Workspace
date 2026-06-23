### Archivo: `pyrevit-dev-mentor/references/03_revit_api_data_management.md`

# Guía de Gestión de Datos de la API de Revit: Coleccionistas, Parámetros y Transacciones

Entender Revit como un sistema de gestión de bases de datos relacionales es clave para crear scripts eficientes. Todo flujo de trabajo que interactúe con esta base de datos se basa en operaciones **CRUD** (Crear, Leer, Actualizar, Eliminar).

## 1. Lectura: Recopilación Eficiente de Datos (`FilteredElementCollector`)
Para extraer información de la base de datos de Revit sin sobrecargar la memoria, se utiliza la clase `FilteredElementCollector`.

### A. Filtrado Básico
Siempre debes filtrar la información desde la base de datos antes de iterar sobre ella con Python. Un recolector estándar debe especificar la categoría, excluir los tipos (para obtener solo instancias) y convertirse a elementos:

```python
from Autodesk.Revit import DB

# 1. Instanciar el recolector en el documento activo
collector = DB.FilteredElementCollector(doc)

# 2. Aplicar filtros encadenados
walls = collector.OfCategory(DB.BuiltInCategory.OST_Walls) \
                 .WhereElementIsNotElementType() \
                 .ToElements()
```
*Nota: Aplicar `WhereElementIsNotElementType()` es vital porque, por defecto, el recolector también devolverá los "Tipos" (Wall Types), los cuales no poseen propiedades de instancia como el volumen o el área.*

### B. Filtrado Avanzado: Filtros Rápidos vs. Lentos
Para modelos grandes, debes aprovechar los índices internos de Revit usando métodos avanzados en lugar de recolectar todo y usar bucles `for` en Python.
*   **Filtros Rápidos (Quick Filters):** Operan en la memoria indexada de Revit (ej. `BoundingBoxContainsPointFilter`). Son extremadamente rápidos.
*   **Filtros Lentos (Slow Filters):** Obligan a Revit a expandir el objeto para leer sus propiedades internas (ej. `ElementParameterFilter`). Deben usarse **después** de haber aplicado filtros rápidos (como `OfCategory`) para reducir la cantidad de elementos a procesar.

**Ejemplo de Filtro Avanzado (`WherePasses`):**
```python
# Definir el parámetro a evaluar (ej. Altura Desconectada)
param_id = DB.ElementId(DB.BuiltInParameter.WALL_USER_HEIGHT_PARAM)
provider = DB.ParameterValueProvider(param_id)

# Crear la regla: Que sea exactamente igual a 10 pies
evaluator = DB.FilterNumericEquals()
rule = DB.FilterDoubleRule(provider, evaluator, 10.0, 1e-6)

# Crear el filtro lento y aplicarlo al recolector
param_filter = DB.ElementParameterFilter(rule)
tall_walls = DB.FilteredElementCollector(doc).OfCategory(DB.BuiltInCategory.OST_Walls).WherePasses(param_filter).ToElementIds()
```
*Esta técnica procesa la información directamente en el motor de Revit, resultando hasta dos veces más rápida que iterar manualmente en Python.*

## 2. Actualización: Manejo de Parámetros
Una vez que tienes el elemento, necesitas leer o modificar sus propiedades.

*   **Búsqueda de parámetros:** Puedes usar `element.LookupParameter("Nombre")`, pero esto puede fallar si hay parámetros duplicados o si el modelo está en otro idioma. 
*   **Práctica Senior:** Siempre que sea posible, utiliza el método `get_Parameter(BuiltInParameter.NOMBRE_DEL_PARAMETRO)`. Es universal, a prueba de idiomas y computacionalmente más robusto.
*   **Storage Type:** Antes de extraer un valor, debes conocer su tipo de almacenamiento (`StorageType`), ya que dicta qué método usar (ej. `.AsDouble()`, `.AsInteger()`, `.AsString()`).

## 3. Seguridad de la Base de Datos: Transacciones
Revit no permite que realices cambios en su base de datos (Actualizar, Crear o Eliminar) a menos que inicies una **Transacción**. Esto bloquea la base de datos para otros procesos, garantizando que si algo falla, los datos no se corrompan (principios ACID).

### A. Transacciones Simples
En pyRevit, puedes usar el administrador de contexto `with` para simplificar esto:
```python
from pyrevit import revit

with revit.Transaction("Actualizar Parámetro"):
    # Tu código para modificar el modelo aquí
    param.Set("Nuevo Valor")
```

### B. Agrupación de Transacciones (`TransactionGroup`)
Si tu script realiza múltiples operaciones distintas (ej. actualizar hojas y luego borrar elementos), creará múltiples entradas en el menú "Deshacer" (Undo) de Revit. Para ofrecer una mejor experiencia al usuario, debes agruparlas usando `TransactionGroup` y el método `Assimilate()`.
*   `Assimilate()` fusiona todas las transacciones internas en una sola acción de "Deshacer" con el nombre del grupo.

## 4. Creación y Eliminación de Elementos

*   **Eliminación:** Se utiliza el método `doc.Delete(ElementId)`. Este método devuelve una lista de los IDs de los elementos que fueron eliminados como daño colateral (ej. si borras un muro, Revit te informará que también borró las ventanas hospedadas en él).
*   **Creación:** Históricamente se usaba el espacio de nombres `Autodesk.Revit.Creation.Document` (ej. `doc.Create`). Sin embargo, muchos de estos métodos están obsoletos. La práctica actual es buscar el método estático `Create()` dentro de la clase del elemento que deseas generar (ej. `Wall.Create(document, curve, levelId...)`). Al ser un método estático, no necesitas una instancia previa del elemento para ejecutarlo.

***
