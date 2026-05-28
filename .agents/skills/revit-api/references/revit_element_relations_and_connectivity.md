# Revit Element Relations, Grouping, and MEP Systems Connectivity

Esta guía técnica proporciona patrones de diseño óptimos y lecciones de depuración para navegar relaciones complejas entre elementos del modelo en Autodesk Revit (C#).

---

## 1. Supercomponentes (Nested Families)
Al trabajar con familias anidadas (*nested families*), a menudo necesitamos identificar el componente principal o contenedor de un elemento secundario seleccionado.

*   **API Clave:** `(el as FamilyInstance)?.SuperComponent`
*   **Regla Óptima:**
    *   Si `SuperComponent` es diferente de `null`, el elemento seleccionado es una subfamilia.
    *   Para obtener el elemento padre que controla la instancia completa, se navega recursivamente hacia arriba o se lee directamente el primer `SuperComponent`.
*   **Código de Referencia:**
    ```csharp
    public static Element GetParentFamily(Element element)
    {
        if (element is FamilyInstance familyInstance && familyInstance.SuperComponent != null)
        {
            return familyInstance.SuperComponent;
        }
        return null;
    }
    ```

---

## 2. Grupos y Ensamblajes (Model Groups & Assemblies)
Los elementos pueden pertenecer a una agrupación física (`Group`) o a una instancia de ensamblaje (`AssemblyInstance`). Si el usuario selecciona un elemento miembro, comúnmente se requiere seleccionar toda la agrupación.

*   **API Clave:** `GroupId`, `AssemblyInstanceId` y `GetMemberIds()`
*   **Patrón Óptimo:**
    ```csharp
    public static ICollection<ElementId> GetGroupingMembers(Element element, Document doc)
    {
        // 1. Verificar si pertenece a un Grupo de Modelo
        if (element.GroupId != ElementId.InvalidElementId)
        {
            if (doc.GetElement(element.GroupId) is Group group)
            {
                return group.GetMemberIds();
            }
        }

        // 2. Verificar si pertenece a un Ensamblaje (Assembly)
        if (element.AssemblyInstanceId != ElementId.InvalidElementId)
        {
            if (doc.GetElement(element.AssemblyInstanceId) is AssemblyInstance assembly)
            {
                return assembly.GetMemberIds();
            }
        }

        return new List<ElementId>();
    }
    ```

---

## 3. Elementos Dependientes
Existen relaciones de dependencia lógica (cotas, etiquetas de texto, barridos de muro hospedados, etc.) que se destruyen o mueven junto con el elemento anfitrión.

*   **API Clave:** `Element.GetDependentElements(ElementFilter)`
*   **Regla de Performance:**
    *   Pasar `null` al filtro recupera **todos** los elementos dependientes.
    *   Es sumamente útil para recolectar anotaciones de documentación en vistas asociadas de forma instantánea.

---

## 4. Intersección Física 3D Real (Real 3D Physical Intersection)
A menudo requerimos buscar elementos que colisionan o intersectan físicamente con nuestra selección. 

*   **API Clave:** `ElementIntersectsElementFilter`
*   **Lección Aprendida (Performance & Scope):**
    *   *Fallo Común:* Aplicar un filtro de intersección física en un `FilteredElementCollector` global de todo el documento es sumamente lento y puede congelar Revit en modelos grandes.
    *   *Solución Óptima (Filtrado en Cascada):* Restringir el recolector de intersección a un **dominio de búsqueda pre-filtrado** (por ejemplo, los elementos actualmente cargados en la vista o una lista acotada de identificadores), y aplicar el filtro físico individualmente contra cada elemento origen.
*   **Código de Referencia:**
    ```csharp
    public static List<Element> GetIntersectingElements(Element sourceElement, ICollection<ElementId> searchDomainIds, Document doc)
    {
        if (searchDomainIds == null || searchDomainIds.Count == 0) return new List<Element>();

        // Restringir el colector únicamente al dominio acotado para evitar escaneo completo de base de datos
        using (var collector = new FilteredElementCollector(doc, searchDomainIds))
        {
            var intersectFilter = new ElementIntersectsElementFilter(sourceElement);
            return collector.WherePasses(intersectFilter).ToElements().ToList();
        }
    }
    ```

---

## 5. Conectividad y Redes de Sistemas MEP
En ingeniería MEP (mecánica, electricidad y fontanería), los conductos, tuberías y terminales están conectados en redes. Si necesitamos propagar una selección o comprobar continuidad física a lo largo del sistema, debemos navegar a través de la conectividad de los conectores.

*   **API Clave:** `ConnectorManager`, `Connector` y `MEPSystem`
*   **Estrategia de Navegación de Red:**
    1.  Determinar si el elemento es un elemento de curva MEP (`MEPCurve`) o un equipo/terminal con un modelo MEP (`FamilyInstance.MEPModel`).
    2.  Obtener el `ConnectorManager` del objeto.
    3.  Iterar todos los conectores activos (`Connectors`).
    4.  Para cada conector, leer su `MEPSystem` correspondiente.
    5.  Si el sistema es válido, extraer todas sus partes físicas a través de `mepSystem.Elements`.
*   **Código de Referencia:**
    ```csharp
    public static List<Element> GetMEPSystemElements(Element element, Document doc)
    {
        var systemElements = new List<Element>();
        ConnectorManager connectorManager = null;

        if (element is MEPCurve mepCurve)
        {
            connectorManager = mepCurve.ConnectorManager;
        }
        else if (element is FamilyInstance familyInstance)
        {
            connectorManager = familyInstance.MEPModel?.ConnectorManager;
        }

        if (connectorManager == null) return systemElements;

        foreach (Connector connector in connectorManager.Connectors)
        {
            if (connector.MEPSystem is MEPSystem mepSystem)
            {
                foreach (Element mepElement in mepSystem.Elements)
                {
                    if (mepElement.Id != element.Id)
                    {
                        systemElements.Add(mepElement);
                    }
                }
                // Si encontramos un sistema válido, comúnmente no requerimos seguir iterando otros conectores
                break;
            }
        }

        return systemElements.DistinctBy(x => x.Id.Value).ToList();
    }
    ```
