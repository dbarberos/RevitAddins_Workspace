---
name: revit-addin-helpers
description: Catalog of reusable C# extensions and common utilities for Revit 2024+ Add-ins. Use this when you need extension methods, TaskDialog wrappers, unit conversions, Toposolid handling, or parameter helpers.
---

# Revit Add-in Helpers — Reusable Extensions and Utilities

## Objective
Provide a catalog of reusable C# code that the agent can inject into any Revit Add-in project to avoid duplicated code and apply proven patterns.

## Strict Rules Revit 2024+ (.NET 7 / .NET 8)
1. **ElementId is Int64:** NEVER use `ElementId.IntegerValue`. ALWAYS use `ElementId.Value` (which returns a `long`).
2. **Topography:** NEVER use `TopographySurface`. Exclusively use the `Toposolid` class.
3. **Units:** Exclusively use `ForgeTypeId` with the `UnitUtils` class. The old enumerations are deprecated.
4. **C# 12:** Maximize the use of records with Primary Constructors and pattern matching.

## 📦 Assets (Reusable Code)
The following files are located in the `assets/` folder and you can copy them directly into the project:

- `assets/DocumentExtensions.cs`: Convenience extensions for `Document` and `FilteredElementCollector`.
- `assets/ElementExtensions.cs`: Safe reading of parameters and category names.
- `assets/ElementMappers.cs`: Standard pattern to map Revit Elements to DTOs for the UI.
- `assets/TopoHelper.cs`: Exclusive helper for the new Toposolids API (Revit 2024+).
- `assets/RevitUI.cs`: Simplified wrapper for `TaskDialog` and Dark UI Theme detection.
- `assets/UnitHelper.cs`: Unit conversion utilities using `ForgeTypeId`.
- `assets/OperationResult.cs`: Wrapper for operation results in a controlled manner.
- `assets/RevitRelationshipUtils.cs`: High-performance utilities to query nesting, groups, assemblies, physical 3D intersections, and MEP system networks.
- `assets/RevitFilterUtils.cs`: Dynamic family and type resolvers, view ownership filters, sequential phase order mapping, and secure parameter metadata extraction.
- `assets/ActionEventHandler.cs`: Generic `IExternalEventHandler` to execute arbitrary actions on the Revit UI thread from Modeless WPF windows, preventing InvalidOperationExceptions.
- `assets/SequentialSelectionPattern.cs`: Implements sequential task dialog prompts and mixed selection grouping to safely retrieve objects from both the Host Document and Linked Documents without causing PickObjects ArgumentExceptions.
- `assets/RfaMetadataExtractor.cs`: High performance extraction of Revit Version and Category from `.rfa` binary headers without loading into Revit memory.

## Integration Rules
- All helpers must be placed in the project's `/Helpers` folder.
- DO NOT inject all helpers into all projects. Only include the ones that the project actually uses.
- All helpers use the `{{Namespace}}.Helpers` namespace.
