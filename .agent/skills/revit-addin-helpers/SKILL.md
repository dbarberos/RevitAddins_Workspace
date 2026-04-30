---
name: revit-addin-helpers
description: Catálogo de extensiones C# reutilizables y utilidades comunes para Add-ins de Revit 2024+. Úsalo cuando necesites métodos de extensión, wrappers de TaskDialog, conversiones de unidades, manejo de Toposolids o helpers de parámetros.
---

# Revit Add-in Helpers — Extensiones y Utilidades Reutilizables

## Objetivo
Proporcionar un catálogo de código C# reutilizable que el agente puede inyectar en cualquier proyecto de Add-in de Revit para evitar código duplicado y aplicar patrones probados.

## Reglas Estrictas Revit 2024+ (.NET 7 / .NET 8)
Al generar código para este proyecto, debes adherirte estrictamente a los cambios de la API de Revit 2024+:
1. **ElementId es Int64:** NUNCA uses `ElementId.IntegerValue`. Usa SIEMPRE `ElementId.Value` (el cual devuelve un `long`).
2. **Topografía:** NUNCA uses `TopographySurface`. Usa exclusivamente la clase `Toposolid`.
3. **Unidades:** Usa exclusivamente `ForgeTypeId` con la clase `UnitUtils`. Las enumeraciones antiguas están deprecadas.
4. **C# 12:** Maximiza el uso de `records` con Primary Constructors y pattern matching.

---

## 1. Extensiones de Document
```csharp
namespace {{Namespace}}.Helpers;

/// <summary>
/// Extensiones de conveniencia para Autodesk.Revit.DB.Document
/// </summary>
public static class DocumentExtensions
{
    /// <summary>
    /// Obtiene todos los elementos de un tipo específico, excluyendo tipos de elemento.
    /// </summary>
    public static IList<T> GetInstances<T>(this Document doc) where T : Element
    {
        return new FilteredElementCollector(doc)
            .OfClass(typeof(T))
            .WhereElementIsNotElementType()
            .Cast<T>()
            .ToList();
    }

    /// <summary>
    /// Obtiene todos los elementos de una categoría específica en la vista activa.
    /// </summary>
    public static IList<Element> GetElementsInView(this Document doc, BuiltInCategory category, ElementId viewId)
    {
        return new FilteredElementCollector(doc, viewId)
            .OfCategory(category)
            .WhereElementIsNotElementType()
            .ToElements();
    }

    /// <summary>
    /// Ejecuta una acción dentro de una transacción de forma segura.
    /// Devuelve true si la transacción se completó con éxito.
    /// </summary>
    public static bool RunInTransaction(this Document doc, string name, Action<Transaction> action)
    {
        using var tx = new Transaction(doc, name);
        try
        {
            tx.Start();
            action(tx);
            tx.Commit();
            return true;
        }
        catch (Exception ex)
        {
            if (tx.HasStarted() && !tx.HasEnded())
                tx.RollBack();
            System.Diagnostics.Debug.WriteLine($"[Transaction Error] {name}: {ex.Message}");
            return false;
        }
    }
}
```

---

## 2. Extensiones de Element y Parámetros

```csharp
namespace {{Namespace}}.Helpers;

/// <summary>
/// Extensiones para lectura segura de parámetros de Element.
/// </summary>
public static class ElementExtensions
{
    /// <summary>
    /// Obtiene el valor de un parámetro como string, con fallback si no existe.
    /// </summary>
    public static string GetParamValue(this Element element, BuiltInParameter param, string fallback = "")
    {
        var p = element.get_Parameter(param);
        if (p == null || !p.HasValue) return fallback;

        return p.StorageType switch
        {
            StorageType.String  => p.AsString() ?? fallback,
            StorageType.Integer => p.AsInteger().ToString(),
            StorageType.Double  => p.AsDouble().ToString("F4"),
            // IMPORTANTE 2024+: .Value devuelve un long
            StorageType.ElementId => p.AsElementId().Value.ToString(), 
            _ => fallback
        };
    }

    /// <summary>
    /// Obtiene el nombre de categoría de un elemento de forma segura.
    /// </summary>
    public static string GetCategoryName(this Element element)
        => element.Category?.Name ?? "(Sin Categoría)";

    /// <summary>
    /// Obtiene el nombre de familia y tipo combinados.
    /// </summary>
    public static string GetFamilyAndTypeName(this Element element)
    {
        var typeId = element.GetTypeId();
        if (typeId == ElementId.InvalidElementId) return "(Sin Tipo)";

        var type = element.Document.GetElement(typeId) as ElementType;
        string familyName = type?.FamilyName ?? "";
        string typeName = type?.Name ?? "";

        return string.IsNullOrEmpty(familyName) ? typeName : $"{familyName} : {typeName}";
    }
}
```

---

## 3. Mapeo a Modelos de UI (C# 12 Records)

```csharp
namespace {{Namespace}}.Helpers;

/// <summary>
/// Patrón estándar para mapear Elementos de Revit a DTOs para la UI.
/// Los Ids deben ser siempre 'long' para compatibilidad con Revit 2024+.
/// </summary>
public record ElementDto(long ElementId, string Name, string Category);

public static class ElementMappers
{
    public static ElementDto ToDto(this Element element) =>
        new(
            ElementId: element.Id.Value, // Obligatorio .Value (long) en 2024+
            Name: element.Name,
            Category: element.GetCategoryName()
        );
}
```

---

## 4. Helper de Topografía (Revit 2024+)

```csharp
namespace {{Namespace}}.Helpers;

/// <summary>
/// Helper exclusivo para la nueva API de Toposolids (Revit 2024+).
/// </summary>
public static class TopoHelper
{
    /// <summary>
    /// Obtiene todos los sólidos topográficos del documento.
    /// </summary>
    public static IList<Toposolid> GetToposolids(this Document doc)
    {
        return doc.GetInstances<Toposolid>();
    }
}
```

---

## 5. Wrapper de TaskDialog y UI Theme

```csharp
namespace {{Namespace}}.Helpers;

/// <summary>
/// Wrapper simplificado para TaskDialog y utilidades de UI (Revit 2024+).
/// </summary>
public static class RevitUI
{
    private static string _appName = "Add-in";

    public static void Initialize(string appName) => _appName = appName;

    public static void Info(string message, string title = "Información")
    {
        var td = new TaskDialog($"{_appName} — {title}")
        {
            MainContent = message,
            MainIcon = TaskDialogIcon.TaskDialogIconInformation
        };
        td.Show();
    }

    public static void Warning(string message, string title = "Advertencia")
    {
        var td = new TaskDialog($"{_appName} — {title}")
        {
            MainContent = message,
            MainIcon = TaskDialogIcon.TaskDialogIconWarning
        };
        td.Show();
    }

    public static void Error(string message, Exception ex = null, string title = "Error")
    {
        var td = new TaskDialog($"{_appName} — {title}")
        {
            MainContent = message,
            MainIcon = TaskDialogIcon.TaskDialogIconError
        };
        if (ex != null)
            td.ExpandedContent = $"Detalle técnico:\n{ex.Message}\n\n{ex.StackTrace}";
        td.Show();
    }

    public static bool Confirm(string message, string title = "Confirmar")
    {
        var td = new TaskDialog($"{_appName} — {title}")
        {
            MainContent = message,
            CommonButtons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No,
            DefaultButton = TaskDialogResult.No
        };
        return td.Show() == TaskDialogResult.Yes;
    }

    /// <summary>
    /// Detecta si Revit está utilizando el Tema Oscuro (Revit 2024+).
    /// </summary>
    public static bool IsDarkThemeActive()
    {
        return UIThemeManager.CurrentTheme == UITheme.Dark;
    }
}
```

---

## 6. Conversiones de Unidades (ForgeTypeId)

```csharp
namespace {{Namespace}}.Helpers;

/// <summary>
/// Utilidades de conversión de unidades usando ForgeTypeId.
/// </summary>
public static class UnitHelper
{
    public static double FeetToMeters(double feetValue)
        => UnitUtils.ConvertFromInternalUnits(feetValue, UnitTypeId.Meters);

    public static double MetersToFeet(double metersValue)
        => UnitUtils.ConvertToInternalUnits(metersValue, UnitTypeId.Meters);

    public static double FeetToMillimeters(double feetValue)
        => UnitUtils.ConvertFromInternalUnits(feetValue, UnitTypeId.Millimeters);

    public static double MillimetersToFeet(double mmValue)
        => UnitUtils.ConvertToInternalUnits(mmValue, UnitTypeId.Millimeters);

    public static double SqFeetToSqMeters(double sqFeetValue)
        => UnitUtils.ConvertFromInternalUnits(sqFeetValue, UnitTypeId.SquareMeters);

    public static double CuFeetToCuMeters(double cuFeetValue)
        => UnitUtils.ConvertFromInternalUnits(cuFeetValue, UnitTypeId.CubicMeters);

    public static string FormatWithDocUnits(Document doc, ForgeTypeId specTypeId, double internalValue)
    {
        var formatOptions = doc.GetUnits().GetFormatOptions(specTypeId);
        return UnitFormatUtils.Format(doc.GetUnits(), specTypeId, internalValue, false);
    }
}
```

### Tabla de referencia ForgeTypeId

| Magnitud | `SpecTypeId` | `UnitTypeId` más comunes |
|----------|-------------|------------------------|
| Longitud | `SpecTypeId.Length` | `UnitTypeId.Meters`, `UnitTypeId.Millimeters`, `UnitTypeId.Feet` |
| Área | `SpecTypeId.Area` | `UnitTypeId.SquareMeters`, `UnitTypeId.SquareFeet` |
| Volumen | `SpecTypeId.Volume` | `UnitTypeId.CubicMeters`, `UnitTypeId.CubicFeet` |
| Ángulo | `SpecTypeId.Angle` | `UnitTypeId.Degrees`, `UnitTypeId.Radians` |
| Masa | `SpecTypeId.Mass` | `UnitTypeId.Kilograms` |

---

## 7. Result Wrapper (Operaciones Seguras)
```csharp
namespace {{Namespace}}.Helpers;

/// <summary>
/// Wrapper para resultados de operaciones que pueden fallar de forma controlada.
/// </summary>
public record OperationResult<T>(bool Success, T Value = default, string ErrorMessage = null)
{
    public static OperationResult<T> Ok(T value) => new(true, value);
    public static OperationResult<T> Fail(string error) => new(false, ErrorMessage: error);
    public static OperationResult<T> Fail(Exception ex) => new(false, ErrorMessage: ex.Message);
}

/// <summary>
/// Versión sin valor de retorno.
/// </summary>
public record OperationResult(bool Success, string ErrorMessage = null)
{
    public static OperationResult Ok() => new(true);
    public static OperationResult Fail(string error) => new(false, error);
    public static OperationResult Fail(Exception ex) => new(false, ex.Message);
}
```

---

## 8. Reglas de Integración

### Ubicación de archivos
Todos los helpers deben colocarse en la carpeta `/Helpers` del proyecto:
```
{{Nombre}}/
├── Helpers/
│   ├── DocumentExtensions.cs
│   ├── ElementExtensions.cs
│   ├── ElementMappers.cs
│   ├── RevitUI.cs
│   ├── TopoHelper.cs
│   ├── UnitHelper.cs
│   └── OperationResult.cs
```

### Inclusión selectiva
- El agente **NO debe** inyectar todos los helpers en todos los proyectos.
- Solo incluir los que el proyecto realmente utilice.
- Si el proyecto no usa UI, omitir `RevitUI` y usar `TaskDialog` directo si fuera estrictamente necesario.
- Si el proyecto no maneja unidades, omitir `UnitHelper`.

### Namespace
- Todos los helpers usan el namespace `{{Namespace}}.Helpers`.
- Nunca crear clases `static partial` — mantener cada helper en su propio archivo.
````</T></T></T></T></Toposolid></Toposolid></Transaction></Element></T></T></T>