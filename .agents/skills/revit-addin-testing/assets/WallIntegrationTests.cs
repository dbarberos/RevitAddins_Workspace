// ==============================================================================
// SKILL: revit-addin-testing (Testing and TDD)
// PATTERN: In-Process Integration Test with Transaction Cleanup
// PURPOSE: Runs tests inside Revit's active database thread context.
// ==============================================================================

using Autodesk.Revit.DB;
using Xunit;

namespace RevitAddinBase.Testing.Tests
{
    public class WallIntegrationTests
    {
        // Example of an in-process integration test (requires active Revit context)
        [Fact]
        public void CreateWall_WhenValidDataProvided_ShouldCreateElementInDb()
        {
            // Dummy values for demonstration (Fixture is a placeholder for in-process DB setups)
            Document doc = Fixture.Document;
            Curve testCurve = Fixture.TestCurve;
            ElementId levelId = Fixture.LevelId;

            using (Transaction t = new Transaction(doc, "Test Wall"))
            {
                t.Start();
                
                // Act
                Wall newWall = Wall.Create(doc, testCurve, levelId, false);
                
                // Assert
                Assert.NotNull(newWall);
                Assert.True(newWall.Id.IntegerValue > 0);
                
                t.RollBack(); // IMPORTANT: Rollback the transaction to keep the model database clean
            }
        }
        
        // Mock fixture representation
        private static class Fixture
        {
            public static Document Document => null;
            public static Curve TestCurve => null;
            public static ElementId LevelId => null;
        }
    }
}
