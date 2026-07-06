// ==============================================================================
// SKILL: SKILL-RVT-ENT (Enterprise & Cloud Ecosystem)
// PATTERN: Clean Architecture & Unit Testing Wrappers
// PURPOSE: Decouples business logic from the native Revit API using Interfaces.
//          Allows logic to be tested in standard CI/CD pipelines using Moq/xUnit 
//          without requiring Revit.exe to be running.
// DEPENDENCIES: System.Collections.Generic
// ==============================================================================

using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Enterprise.QA
{
    /// <summary>
    /// Interface abstracting the Revit database. 
    /// Can be implemented by a real Revit wrapper or a Fake/Mock for testing.
    /// </summary>
    public interface IRevitRepository
    {
        IEnumerable<string> GetAllWallNames();
        bool RenameElement(string uniqueId, string newName);
    }

    /// <summary>
    /// The REAL implementation that calls the Revit API.
    /// This class is excluded from Unit Tests.
    /// </summary>
    public class ProductionRevitRepository : IRevitRepository
    {
        private readonly Document _doc;

        public ProductionRevitRepository(Document doc)
        {
            _doc = doc ?? throw new ArgumentNullException(nameof(doc));
        }

        public IEnumerable<string> GetAllWallNames()
        {
            var walls = new FilteredElementCollector(_doc).OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType();
            foreach (Element w in walls) yield return w.Name;
        }

        public bool RenameElement(string uniqueId, string newName)
        {
            Element elem = _doc.GetElement(uniqueId);
            if (elem != null && elem.get_Parameter(BuiltInParameter.ALL_MODEL_MARK) is Parameter p && !p.IsReadOnly)
            {
                return p.Set(newName);
            }
            return false;
        }
    }

    /// <summary>
    /// The purely logical service. This is what gets tested in xUnit.
    /// It knows NOTHING about Autodesk.Revit.DB, it only knows the Interface.
    /// </summary>
    public class WallAuditService
    {
        private readonly IRevitRepository _repository;

        // Dependency Injection
        public WallAuditService(IRevitRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Business logic: Renames a wall if it violates company naming conventions.
        /// </summary>
        public bool AuditWallName(string uniqueId, string currentName)
        {
            if (string.IsNullOrWhiteSpace(currentName) || !currentName.StartsWith("BIM_"))
            {
                // Fix the violation
                return _repository.RenameElement(uniqueId, "BIM_" + currentName);
            }
            return true; // Wall is compliant
        }
    }
}