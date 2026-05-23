// ============================================================================
// ❌ ARQUITECTURA NO TESTEABLE: Lógica de negocio mezclada con la API de Revit
// ============================================================================
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitAddin.Example.Untestable
{
    [Transaction(TransactionMode.Manual)]
    public class CmdCountWalls : IExternalCommand
    {
        public Result Execute(ExternalCommandData data, ref string msg, ElementSet elements)
        {
            var doc = data.Application.ActiveUIDocument.Document;
            
            // Lógica de acceso a datos directa utilizando FilteredElementCollector (Depende 100% de Revit real)
            var walls = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Walls)
                .WhereElementIsNotElementType()
                .ToElements();
            
            // Lógica de negocio mezclada en la misma función (Imposible de probar unitariamente)
            var grouped = walls.GroupBy(w => w.get_Parameter(BuiltInParameter.WALL_BASE_CONSTRAINT).AsValueString());
            
            TaskDialog.Show("Resultados", $"Total muros: {walls.Count}, Niveles: {grouped.Count()}");
            return Result.Succeeded;
        }
    }
}

// ============================================================================
// ✅ ARQUITECTURA TESTEABLE: Separación de Lógica y Abstracción de API
// ============================================================================
using System.Collections.Generic;
using System.Linq;

namespace RevitAddin.Example.Testable
{
    // 1. Modelo de Datos Puro (Poco peso, no depende de la API de Revit en memoria)
    public record WallInfo(string Name, string Level, double Length);

    // 2. Interfaz de Acceso a Datos de Revit (Abstracción de la API)
    public interface IWallService
    {
        IList<WallInfo> GetAllWalls();
    }

    // 3. Implementación Real en Revit (Solo se ejecuta dentro de Revit — No se prueba unitariamente)
    public class WallService(Document doc) : IWallService
    {
        public IList<WallInfo> GetAllWalls()
        {
            return new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Walls)
                .WhereElementIsNotElementType()
                .Cast<Wall>()
                .Select(w => new WallInfo(
                    w.Name,
                    w.get_Parameter(BuiltInParameter.WALL_BASE_CONSTRAINT).AsValueString() ?? "Unconstrained",
                    w.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble()))
                .ToList();
        }
    }

    // 4. Servicio de Análisis Puro (Lógica de negocio pura — 100% testeable fuera de Revit)
    public class WallAnalysisService
    {
        public Dictionary<string, int> GroupByLevel(IList<WallInfo> walls)
            => walls.GroupBy(w => w.Level)
                    .ToDictionary(g => g.Key, g => g.Count());

        public double TotalLength(IList<WallInfo> walls)
            => walls.Sum(w => w.Length);
    }

    // 5. Comando Orquestador (Código minimalista y limpio)
    [Transaction(TransactionMode.Manual)]
    public class CmdCountWalls(IWallService wallService, WallAnalysisService analysis) : IExternalCommand
    {
        public Result Execute(ExternalCommandData data, ref string msg, ElementSet elements)
        {
            var walls = wallService.GetAllWalls();
            var groups = analysis.GroupByLevel(walls);
            
            TaskDialog.Show("Resultados", $"Total muros: {walls.Count}, Niveles: {groups.Count}");
            return Result.Succeeded;
        }
    }
}
