using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB;

namespace {{Namespace}}.Helpers
{
    /// <summary>
    /// Utilidades de consulta, resolución y filtrado de alto rendimiento para el explorador de elementos en Revit.
    /// </summary>
    public static class RevitFilterUtils
    {
        /// <summary>
        /// Resuelve de forma segura los nombres de familia y tipo para cualquier elemento de Revit.
        /// Maneja la distinción física entre instancias cargables (FamilyInstance) y familias del sistema (HostObject).
        /// </summary>
        public static (string FamilyName, string TypeName) ResolveFamilyAndType(Element element, Document doc)
        {
            string familyName = "N/A";
            string typeName = element.Name;

            if (element is FamilyInstance familyInstance)
            {
                if (familyInstance.Symbol != null)
                {
                    familyName = familyInstance.Symbol.FamilyName;
                    typeName = familyInstance.Symbol.Name;
                }
            }
            else if (element is HostObject hostObject)
            {
                var type = doc.GetElement(hostObject.GetTypeId()) as ElementType;
                if (type != null)
                {
                    familyName = type.FamilyName;
                    typeName = type.Name;
                }
            }

            return (familyName, typeName);
        }

        /// <summary>
        /// Determina si un elemento lógicamente pertenece a una vista (visibilidad por caja o pertenencia de anotación).
        /// </summary>
        public static bool BelongsToView(Element element, View activeView)
        {
            if (activeView == null) return false;
            bool isViewSpecific = element.OwnerViewId.Value == activeView.Id.Value;
            bool isVisibleInView = element.get_BoundingBox(activeView) != null;

            return isViewSpecific || isVisibleInView;
        }

        /// <summary>
        /// Crea una mapa indexado secuencial de las fases del proyecto para permitir el ordenamiento cronológico.
        /// </summary>
        public static Dictionary<ElementId, (string Name, int Order)> GetPhaseOrderMap(Document doc)
        {
            return doc.Phases.Cast<Phase>()
                .Select((p, i) => new { p.Id, p.Name, Order = i })
                .ToDictionary(x => x.Id, x => (x.Name, x.Order));
        }

        /// <summary>
        /// Extrae y concatena parámetros Built-In de ejemplar y tipo en una cadena en minúsculas para búsquedas locales.
        /// Protege la ejecución contra excepciones AccessViolationException mediante un bloque try-catch seguro.
        /// </summary>
        public static string ExtractSearchableMetadata(Element element, Document doc)
        {
            var metaBuilder = new StringBuilder(128);

            try
            {
                // 1. Marcas y Comentarios de Ejemplar
                var pMark = element.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
                if (pMark != null && pMark.HasValue) 
                    metaBuilder.Append(pMark.AsString()?.ToLowerInvariant()).Append(" ");

                var pComments = element.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                if (pComments != null && pComments.HasValue) 
                    metaBuilder.Append(pComments.AsString()?.ToLowerInvariant()).Append(" ");

                // 2. Marcas y Comentarios de Tipo
                var type = doc.GetElement(element.GetTypeId()) as ElementType;
                if (type != null)
                {
                    var pTypeMark = type.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_MARK);
                    if (pTypeMark != null && pTypeMark.HasValue) 
                        metaBuilder.Append(pTypeMark.AsString()?.ToLowerInvariant()).Append(" ");

                    var pTypeComments = type.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_COMMENTS);
                    if (pTypeComments != null && pTypeComments.HasValue) 
                        metaBuilder.Append(pTypeComments.AsString()?.ToLowerInvariant()).Append(" ");
                }

                // 3. Nivel de restricción base
                if (element.LevelId != ElementId.InvalidElementId)
                {
                    var level = doc.GetElement(element.LevelId);
                    if (level != null)
                    {
                        metaBuilder.Append(level.Name.ToLowerInvariant()).Append(" ");
                    }
                }
            }
            catch
            {
                // Ignorar fallos de lectura puntuales y preservar el flujo principal
            }

            return metaBuilder.ToString();
        }
    }
}
