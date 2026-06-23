using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using RevitAddin.Example.Testable;

namespace RevitAddin.Tests.Services
{
    public class WallAnalysisServiceTests
    {
        private readonly WallAnalysisService _sut = new();

        [Fact]
        public void GroupByLevel_WithMultipleLevels_ReturnsCorrectGroups()
        {
            // Arrange
            var walls = new List<WallInfo>
            {
                new("Wall-A", "Level 1", 5.0),
                new("Wall-B", "Level 1", 3.0),
                new("Wall-C", "Level 2", 7.0),
            };

            // Act
            var result = _sut.GroupByLevel(walls);

            // Assert
            result.Should().HaveCount(2);
            result["Level 1"].Should().Be(2);
            result["Level 2"].Should().Be(1);
        }

        [Fact]
        public void TotalLength_SumsAllWalls()
        {
            // Arrange
            var walls = new List<WallInfo>
            {
                new("Wall-A", "Level 1", 5.0),
                new("Wall-B", "Level 1", 3.0),
            };

            // Act
            var total = _sut.TotalLength(walls);

            // Assert
            total.Should().Be(8.0);
        }

        [Fact]
        public void GroupByLevel_EmptyList_ReturnsEmptyDictionary()
        {
            // Act
            var result = _sut.GroupByLevel(new List<WallInfo>());

            // Assert
            result.Should().BeEmpty();
        }
    }
}
