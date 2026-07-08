// ==============================================================================
// SKILL: revit-addin-testing (Testing and TDD)
// PATTERN: Unit Test with Mocks (xUnit & Moq)
// PURPOSE: Validates business logic in isolation without starting Revit.exe.
// ==============================================================================

using Xunit;
using Moq;

namespace RevitAddinBase.Testing.Tests
{
    public class CostCalculatorUnitTests
    {
        [Fact]
        public void CalculateTotalCost_ShouldReturnCorrectValue()
        {
            // Arrange
            var mockWall1 = new Mock<IWallDataRepresentation>();
            mockWall1.Setup(m => m.GetMetricArea()).Returns(10.0);
            
            var mockWall2 = new Mock<IWallDataRepresentation>();
            mockWall2.Setup(m => m.GetMetricArea()).Returns(20.0);

            var calculator = new CostCalculatorService();

            // Act
            double result = calculator.CalculateTotalCost(new[] { mockWall1.Object, mockWall2.Object });

            // Assert
            Assert.Equal(465.0, result); // (10 * 15.5) + (20 * 15.5)
        }
    }
}
