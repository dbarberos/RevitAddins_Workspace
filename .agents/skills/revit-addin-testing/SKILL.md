---
name: revit-addin-testing
description: Guide for testing Revit Add-ins — unit testing with API mocks, build validation, and testing strategies without a Revit instance. Use this when configuring CI/CD, setting up tests, or validating business logic independently of the Revit API.
---

# Revit Add-in Testing

## Objective
Guide the agent in creating tests for Revit Add-ins, ranging from build validation to unit testing with API isolation.

## When to Use
- When configuring testing in a new or existing add-in project.
- When needing to validate service logic without a Revit instance.
- When configuring CI/CD for automatic builds.

---

## 1. Testing Strategy for Revit Add-ins

### The fundamental problem
The Revit API **cannot be executed outside of Revit** (there is no headless mode). This means:
- You cannot create instances of `Document`, `Element`, `FilteredElementCollector` in tests.
- Unit tests must **isolate the business logic** from API calls.
- Real validation requires loading the add-in in Revit.

### Testing levels

| Level | What it tests | Tool | Automatable |
|-------|-----------|-------------|---------------|
| **Build** | Compilation without errors | `dotnet build` | ✅ Yes |
| **Unit** | Service and model logic | xUnit / NUnit + mocks | ✅ Yes |
| **Integration** | Add-in loaded in Revit | RevitTestFramework / manual | ⚠️ Partial |
| **Manual** | UI, Ribbon, complete flow | Real Revit | ❌ No |

---

## 2. Build Validation (Minimum Required Level)

**ALWAYS** run after any change:

```powershell
dotnet build {{Name}}.csproj --configuration Release
```

### Post-build validation checklist
- [ ] Compiles without errors (`exit code 0`).
- [ ] No critical warnings (`CS0104` ambiguity, `CS0618` obsolete).
- [ ] DLL generated in the expected output folder.
- [ ] `.addin` file present and with the correct `FullClassName`.

---

## 3. Unit Tests — Testable Architecture

### Principle: Separate logic from the API

```csharp
// ❌ NOT TESTABLE: logic mixed with the Revit API
public class CmdCountWalls : IExternalCommand
{
    public Result Execute(ExternalCommandData data, ref string msg, ElementSet elements)
    {
        var doc = data.Application.ActiveUIDocument.Document;
        var walls = new FilteredElementCollector(doc)
            .OfCategory(BuiltInCategory.OST_Walls)
            .WhereElementIsNotElementType()
            .ToElements();
        
        // Business logic mixed here...
        var grouped = walls.GroupBy(w => w.get_Parameter(BuiltInParameter.WALL_BASE_CONSTRAINT).AsValueString());
        TaskDialog.Show("Result", $"Total: {walls.Count}, Groups: {grouped.Count()}");
        return Result.Succeeded;
    }
}
```

```csharp
// ✅ TESTABLE: logic extracted to a service with an interface

// 1. Data model (testable, no Revit dependency)
public record WallInfo(string Name, string Level, double Length);

// 2. Service interface (API abstraction)
public interface IWallService
{
    IList<WallInfo> GetAllWalls();
}

// 3. Real implementation (uses Revit API — not unit tested)
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
                w.GetParamValue(BuiltInParameter.WALL_BASE_CONSTRAINT),
                w.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble()))
            .ToList();
    }
}

// 4. Analysis service (pure logic — 100% testable)
public class WallAnalysisService
{
    public Dictionary<string, int> GroupByLevel(IList<WallInfo> walls)
        => walls.GroupBy(w => w.Level)
                .ToDictionary(g => g.Key, g => g.Count());

    public double TotalLength(IList<WallInfo> walls)
        => walls.Sum(w => w.Length);
}

// 5. Command (minimal orchestration)
public class CmdCountWalls(IWallService wallService, WallAnalysisService analysis) : IExternalCommand
{
    public Result Execute(ExternalCommandData data, ref string msg, ElementSet elements)
    {
        var walls = wallService.GetAllWalls();
        var groups = analysis.GroupByLevel(walls);
        TaskDialog.Show("Result", $"Total: {walls.Count}, Levels: {groups.Count}");
        return Result.Succeeded;
    }
}
```

---

## 4. Test Project Configuration

### Folder structure
```
{{Name}}/
├── {{Name}}.csproj          # Main project
└── {{Name}}.Tests/
    ├── {{Name}}.Tests.csproj
    ├── Services/
    │   └── WallAnalysisServiceTests.cs
    └── Helpers/
        └── UnitHelperTests.cs
```

### `.csproj` of the test project

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net48</TargetFramework>  <!-- Same framework as the add-in -->
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="xunit" Version="2.9.*" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.8.*" />
    <PackageReference Include="Moq" Version="4.20.*" />
    <PackageReference Include="FluentAssertions" Version="7.*" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\{{Name}}.csproj" />
  </ItemGroup>
</Project>
```

> **⚠️ Note for .NET 8 (Revit 2025+):** Change `TargetFramework` to `net8.0-windows`.

---

## 5. Unit Test Example

```csharp
using FluentAssertions;
using Xunit;

namespace {{Namespace}}.Tests.Services;

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
        var walls = new List<WallInfo>
        {
            new("Wall-A", "Level 1", 5.0),
            new("Wall-B", "Level 1", 3.0),
        };

        _sut.TotalLength(walls).Should().Be(8.0);
    }

    [Fact]
    public void GroupByLevel_EmptyList_ReturnsEmptyDictionary()
    {
        _sut.GroupByLevel(new List<WallInfo>()).Should().BeEmpty();
    }
}
```

---

## 6. Helper Testing (without Revit dependency)

```csharp
using FluentAssertions;
using Xunit;

namespace {{Namespace}}.Tests.Helpers;

public class OperationResultTests
{
    [Fact]
    public void Ok_CreatesSuccessfulResult()
    {
        var result = OperationResult<int>.Ok(42);
        result.Success.Should().BeTrue();
        result.Value.Should().Be(42);
    }

    [Fact]
    public void Fail_CreatesFailedResultWithMessage()
    {
        var result = OperationResult<int>.Fail("something went wrong");
        result.Success.Should().BeFalse();
        result.ErrorMessage.Should().Be("something went wrong");
    }
}
```

---

## 7. Test Execution

```powershell
# Run all tests
dotnet test {{Name}}.Tests/{{Name}}.Tests.csproj

# With detailed results
dotnet test --verbosity normal

# Only tests of a specific class
dotnet test --filter "FullyQualifiedName~WallAnalysisServiceTests"
```

---

## 8. Agent Rules

### When to create tests
- **Always** when a service with pure business logic (no Revit API) is created.
- **Always** when reusable helpers/extensions are created.

### What NOT to unit test
- `IExternalCommand` classes — they are thin coordinators.
- Services requiring real `Document` instances.
- UI/XAML code.
- Ribbon configuration (`Application.cs`).

### What TO test
- Data transformation logic (grouping, filtering, calculation).
- Data models and their validations.
- Helpers and extensions that do not depend on the API.
- ViewModels (presentation logic isolated from Revit).
