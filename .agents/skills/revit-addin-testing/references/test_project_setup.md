# Test Project Setup and Execution

This document details the recommended physical structure for a unit testing project of a Revit add-in and the commands for its automated execution.

---

## 1. Recommended Folder Structure

It is fundamental to physically separate the add-in's code project and its corresponding test suite. Follow this organizational pattern in the repository:

```
{{Name}}/
├── {{Name}}.csproj          # Main application project
└── {{Name}}.Tests/
    ├── {{Name}}.Tests.csproj # Unit testing project
    ├── Services/
    │   └── WallAnalysisServiceTests.cs # Service unit tests
    └── Helpers/
        └── UnitHelperTests.cs          # Helper/extension unit tests
```

---

## 2. Console Commands for Test Execution

The agent and CI/CD automation tools can run the tests using the following native .NET CLI commands:

```powershell
# 1. Run all tests in the project
dotnet test {{Name}}.Tests/{{Name}}.Tests.csproj

# 2. Run tests with output and detailed information
dotnet test --verbosity normal

# 3. Filter and run only tests from a specific class
dotnet test --filter "FullyQualifiedName~WallAnalysisServiceTests"
```
