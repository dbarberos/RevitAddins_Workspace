---
name: revit-tunit-testing
description: In-process automated UI and DB integration testing for Autodesk Revit add-ins using Nice3point.TUnit.Revit (RevitUnit) and Microsoft.Testing.Platform. Use when creating, updating, or running live Revit tests, verifying Ribbon panels/buttons, testing isolated in-memory model transactions, or executing autonomous testing gates.
---

# Revit In-Process Testing with TUnit — Table of Contents

This skill provides comprehensive architectural guidelines, execution scripts, and production templates for running unit and integration tests inside live Autodesk Revit instances using `Nice3point.TUnit.Revit`.

## 📚 Technical References (Knowledge Base)
For detailed architecture guides and execution methodologies, consult the files in the `references/` folder:

*   `references/revit_unit_architecture.md`: Conceptual guide covering `RevitApiTest`, `RevitThreadExecutor`, `Application` property for UI testing, test isolation, and CLI commands (`dotnet run` / `dotnet test`).
*   `references/autonomous_testing_guidelines.md`: Autonomous agent rules for the Continuous Validation Loop and Self-Healing Cycle without user intervention.

## 📦 Assets (Templates and Code Examples)
The following files are located in the `assets/` folder and can be injected directly into test projects:

*   `assets/TestProjectTemplate.csproj`: Multi-version `.csproj` configured with `Nice3point.Revit.Sdk`, `Nice3point.TUnit.Revit`, `RevitVersion`, and Microsoft.Testing.Platform.
*   `assets/RevitUiIntegrationTestTemplate.cs`: C# test class template validating Ribbon items, panels, tabs, and buttons through `Application`.
*   `assets/RevitDbTransactionTestTemplate.cs`: C# test class template for transactional database testing with automated blank document isolation using `[Before(Test)]` and `[HookExecutor]`.

## ⚙️ Operational Scripts
*   `scripts/run_revit_tests.ps1`: Automated PowerShell runner for executing tests against target Revit version configurations (`R24`, `R25`, `R26`, `R27`).
