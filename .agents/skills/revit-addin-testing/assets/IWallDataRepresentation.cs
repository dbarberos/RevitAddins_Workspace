// ==============================================================================
// SKILL: revit-addin-testing (Testing and TDD)
// PATTERN: Wall Data Interface Abstraction
// PURPOSE: Decouples Revit element parameters from business logic for unit testing.
// ==============================================================================

namespace RevitAddinBase.Testing
{
    public interface IWallDataRepresentation
    {
        double GetMetricArea();
        string GetWallType();
    }
}
