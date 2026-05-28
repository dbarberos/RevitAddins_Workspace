using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace {{Namespace}}.Helpers
{
    /// <summary>
    /// Utilidades de alto rendimiento para consultar relaciones lógicas, físicas y conectividades entre elementos de Revit.
    /// </summary>
    public static class RevitRelationshipUtils
    {
        /// <summary>
        /// Obtiene el componente padre (Supercomponente) si el elemento actual es una instancia de familia anidada.
        /// </summary>
        public static Element GetParentFamily(Element element)
        {
            if (element is FamilyInstance familyInstance && familyInstance.SuperComponent != null)
            {
                return familyInstance.SuperComponent;
            }
            return null;
        }

        /// <summary>
        /// Obtiene todos los miembros que pertenecen al mismo Grupo de Modelo o Ensamblaje (AssemblyInstance) que el elemento de origen.
        /// </summary>
        public static ICollection<ElementId> GetGroupOrAssemblyMembers(Element element, Document doc)
        {
            // 1. Grupo de Modelo
            if (element.GroupId != ElementId.InvalidElementId)
            {
                if (doc.GetElement(element.GroupId) is Group group)
                {
                    return group.GetMemberIds();
                }
            }

            // 2. Ensamblaje
            if (element.AssemblyInstanceId != ElementId.InvalidElementId)
            {
                if (doc.GetElement(element.AssemblyInstanceId) is AssemblyInstance assembly)
                {
                    return assembly.GetMemberIds();
                }
            }

            return new List<ElementId>();
        }

        /// <summary>
        /// Obtiene todos los elementos que lógicamente dependen del elemento de origen (ej. etiquetas, cotas, barridos hospedados).
        /// </summary>
        public static ICollection<ElementId> GetDependentElements(Element element)
        {
            return element.GetDependentElements(null);
        }

        /// <summary>
        /// Obtiene los elementos dentro del dominio de búsqueda que intersectan físicamente en 3D con el elemento origen.
        /// Aplica una optimización en cascada restringiendo el FilteredElementCollector al conjunto de identificadores provisto.
        /// </summary>
        public static List<Element> GetPhysicallyIntersectingElements(Element sourceElement, ICollection<ElementId> searchDomainIds, Document doc)
        {
            if (searchDomainIds == null || searchDomainIds.Count == 0) 
                return new List<Element>();

            using (var collector = new FilteredElementCollector(doc, searchDomainIds))
            {
                var intersectFilter = new ElementIntersectsElementFilter(sourceElement);
                return collector.WherePasses(intersectFilter).ToElements().ToList();
            }
        }

        /// <summary>
        /// Obtiene todos los elementos conectados físicamente en la misma red de sistemas MEP (tuberías, conductos o equipos).
        /// Utiliza la navegación recursiva a través del ConnectorManager.
        /// </summary>
        public static List<Element> GetMEPSystemElements(Element element)
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

            if (connectorManager == null) 
                return systemElements;

            foreach (Connector connector in connectorManager.Connectors)
            {
                if (connector.MEPSystem is MEPSystem mepSystem)
                {
                    foreach (Element mepElement in mepSystem.Elements)
                    {
                        if (mepElement.Id.Value != element.Id.Value)
                        {
                            systemElements.Add(mepElement);
                        }
                    }
                    // Comúnmente basta con encontrar el primer sistema activo conectado
                    break;
                }
            }

            return systemElements
                .GroupBy(x => x.Id.Value)
                .Select(g => g.First())
                .ToList();
        }
    }
}
