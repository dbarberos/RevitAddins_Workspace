---
name: revit-addin-testing
description: Guide for testing Revit Add-ins — unit testing with API mocks, build validation, and testing strategies without a Revit instance. Use this when configuring CI/CD, setting up tests, or validating business logic independently of the Revit API.
---

# Revit Add-in Testing — Table of Contents

This skill provides comprehensive guidelines for developing and executing tests in Revit add-ins, optimizing the separation of pure business logic and the API.

## 📚 Technical References (Knowledge Base)
For in-depth testing guides and methodologies, consult the files in the `references/` folder:

*   `references/testing_strategy.md`: The fundamental problem of the headless API, testing levels, minimum build validation, and agent behavior rules.
*   `references/test_project_setup.md`: Physical folder hierarchy of the test project and execution commands (`dotnet test`).
*   `references/tdd_and_mocking_rules.md`: Technical guide for Dependency Injection, adapter layers, In-Process test frameworks (xUnitRevit/RTF) and prompt rules.

## 📦 Assets (Templates and Code Examples)
The following files are located in the `assets/` folder and can be injected or used as a guide in projects:

*   `assets/TestProjectTemplate.csproj`: Base `.csproj` file with references to xUnit, Moq, and FluentAssertions for .NET 4.8 and .NET 8.
*   `assets/TestableArchitectureExample.cs`: Comparative code example demonstrating how to extract code with dependency injection to isolate the Revit API.
*   `assets/WallAnalysisServiceTests.cs`: Example xUnit test class validating the business logic of grouping services.
*   `assets/HelperTests.cs`: xUnit test class for generic helpers (such as `OperationResult`).
*   `assets/Skill18_Pattern_1.cs` to `assets/Skill18_Pattern_5.cs`: C# patterns for interface contracts, DTO injection, xUnit test mockings, and In-Process xUnitRevit boilerplates.
