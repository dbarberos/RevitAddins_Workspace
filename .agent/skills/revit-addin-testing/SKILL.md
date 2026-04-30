---
name: revit-addin-testing
description: Guía para testing de Add-ins de Revit — pruebas unitarias con mocks de la API, validación de builds y estrategias de testing sin instancia de Revit.
---

# Revit Add-in Testing

## Objetivo
Guiar al agente en la creación de pruebas para Add-ins de Revit, abarcando desde validación de compilación hasta pruebas unitarias con aislamiento de la API.

## Cuándo Usar
- Al configurar testing en un proyecto de add-in nuevo o existente
- Al necesitar validar lógica de servicios sin una instancia de Revit
- Al configurar CI/CD para compilación automática

---

## 1. Estrategia de Testing para Add-ins de Revit

### El problema fundamental
La API de Revit **no puede ejecutarse fuera de Revit** (no hay modo headless). Esto significa:
- No se pueden crear instancias de `Document`, `Element`, `FilteredElementCollector` en tests
- Los tests unitarios deben **aislar la lógica de negocio** de las llamadas a la API
- La validación real requiere cargar el add-in en Revit

### Niveles de testing

| Nivel | Qué prueba | Herramienta | Automatizable |
|-------|-----------|-------------|---------------|
| **Build** | Compilación sin errores | `dotnet build` | ✅ Sí |
| **Unitario** | Lógica de servicios y modelos | xUnit / NUnit + mocks | ✅ Sí |
| **Integración** | Add-in cargado en Revit | RevitTestFramework / manual | ⚠️ Parcial |
| **Manual** | UI, Ribbon, flujo completo | Revit real | ❌ No |

---

## 2. Validación de Build (Nivel Mínimo Obligatorio)

**SIEMPRE** ejecutar tras cualquier cambio:

```powershell
dotnet build {{Nombre}}.csproj --configuration Release
```

### Checklist de validación post-build
- [ ] Compila sin errores (`exit code 0`)
- [ ] Sin warnings críticos (`CS0104` ambigüedad, `CS0618` obsoleto)
- [ ] DLL generada en la carpeta de salida esperada
- [ ] Archivo `.addin` presente y con `FullClassName` correcto

---

## 3. Pruebas Unitarias — Arquitectura Testable

### Principio: Separar la lógica de la API

```csharp
// ❌ NO TESTABLE: lógica mezclada con la API de Revit
public class CmdCountWalls : IExternalCommand
{
    public Result Execute(ExternalCommandData data, ref string msg, ElementSet elements)
    {
        var doc = data.Application.ActiveUIDocument.Document;
        var walls = new FilteredElementCollector(doc)
            .OfCategory(BuiltInCategory.OST_Walls)
            .WhereElementIsNotElementType()
            .ToElements();
        
        // Lógica de negocio mezclada aquí...
        var grouped = walls.GroupBy(w => w.get_Parameter(BuiltInParameter.WALL_BASE_CONSTRAINT).AsValueString());
        TaskDialog.Show("Resultado", $"Total: {walls.Count}, Grupos: {grouped.Count()}");
        return Result.Succeeded;
    }
}
```

```csharp
// ✅ TESTABLE: lógica extraída a un servicio con interfaz

// 1. Modelo de datos (testable, sin dependencia de Revit)
public record WallInfo(string Name, string Level, double Length);

// 2. Interfaz del servicio (abstracción de la API)
public interface IWallService
{
    IList<WallInfo> GetAllWalls();
}

// 3. Implementación real (usa API de Revit — no se testea unitariamente)
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

// 4. Servicio de análisis (lógica pura — 100% testable)
public class WallAnalysisService
{
    public Dictionary<string, int> GroupByLevel(IList<WallInfo> walls)
        => walls.GroupBy(w => w.Level)
                .ToDictionary(g => g.Key, g => g.Count());

    public double TotalLength(IList<WallInfo> walls)
        => walls.Sum(w => w.Length);
}

// 5. Command (orquestación mínima)
public class CmdCountWalls(IWallService wallService, WallAnalysisService analysis) : IExternalCommand
{
    public Result Execute(ExternalCommandData data, ref string msg, ElementSet elements)
    {
        var walls = wallService.GetAllWalls();
        var groups = analysis.GroupByLevel(walls);
        TaskDialog.Show("Resultado", $"Total: {walls.Count}, Niveles: {groups.Count}");
        return Result.Succeeded;
    }
}
```

---

## 4. Configuración del Proyecto de Tests

### Estructura de carpetas
```
{{Nombre}}/
├── {{Nombre}}.csproj          # Proyecto principal
└── {{Nombre}}.Tests/
    ├── {{Nombre}}.Tests.csproj
    ├── Services/
    │   └── WallAnalysisServiceTests.cs
    └── Helpers/
        └── UnitHelperTests.cs
```

### `.csproj` del proyecto de tests

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net48</TargetFramework>  <!-- Mismo framework que el add-in -->
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
    <ProjectReference Include="..\{{Nombre}}.csproj" />
  </ItemGroup>
</Project>
```

> **⚠️ Nota para .NET 8 (Revit 2025+):** Cambiar `TargetFramework` a `net8.0-windows`.

---

## 5. Ejemplo de Test Unitario

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

## 6. Testing de Helpers (sin dependencia de Revit)

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
        var result = OperationResult<int>.Fail("algo salió mal");
        result.Success.Should().BeFalse();
        result.ErrorMessage.Should().Be("algo salió mal");
    }
}
```

---

## 7. Ejecución de Tests

```powershell
# Ejecutar todos los tests
dotnet test {{Nombre}}.Tests/{{Nombre}}.Tests.csproj

# Con detalle de resultados
dotnet test --verbosity normal

# Solo tests de una clase específica
dotnet test --filter "FullyQualifiedName~WallAnalysisServiceTests"
```

---

## 8. Reglas para el Agente

### Cuándo crear tests
- **Siempre** que se cree un servicio con lógica de negocio pura (sin API de Revit)
- **Siempre** que se creen helpers/extensiones reutilizables
- **No crear** tests para Commands (son orquestadores — se validan manualmente)
- **No crear** tests para Services que dependan directamente de `Document` o `FilteredElementCollector`

### Qué NO testear unitariamente
- Clases `IExternalCommand` — son coordinadores thin
- Servicios que requieren instancias reales de `Document`
- Código de UI/XAML
- Configuración del Ribbon (`Application.cs`)

### Qué SÍ testear
- Lógica de transformación de datos (agrupación, filtrado, cálculo)
- Modelos de datos y sus validaciones
- Helpers y extensiones que no dependen de la API
- ViewModels (lógica de presentación aislada de Revit)
