# Testing Strategy for Revit Add-ins

This document describes the testing levels and fundamental principles for validating add-ins in Autodesk Revit.

---

## 1. The Fundamental Problem of Testing in Revit

The Revit API **cannot run outside of a running Revit session** (there is no native *headless* mode). 
* It is not possible to instantiate objects like `Document`, `Element`, `FilteredElementCollector` or call API methods in normal unit tests executed in external environments (e.g., the VS test runner or dotnet console).
* Unit tests must focus on **isolating pure business logic** from Revit API calls using interface injection patterns.
* Full integration validations require starting Revit and loading the add-in manually or using automation frameworks.

---

## 2. Testing Levels in Revit

| Level | What it evaluates | Tool | Automatable |
|-------|-------------------|------|-------------|
| **Build** | Absence of syntax or linking errors | `dotnet build` | ✅ Yes |
| **Unit** | Internal logic of isolated services and models | xUnit / NUnit + mocks | ✅ Yes |
| **Integration** | Behavior of the add-in loaded in Revit | RevitTestFramework / manual | ⚠️ Partial |
| **Manual** | User interface (Ribbon), dialogs, full workflow | Real Revit | ❌ No |

---

## 3. Build Validation (Minimum Mandatory Level)

Always run this command after making any significant change:

```powershell
dotnet build {{Name}}.csproj --configuration Release
```

### Post-Build Checklist:
- [ ] The build completes successfully (`exit code 0`).
- [ ] There are no critical warnings (e.g., ambiguity `CS0104`, obsolete methods `CS0618`).
- [ ] The DLL has been generated in the configured output folder.
- [ ] The `.addin` (manifest) file is present and has the correct `FullClassName`.

---

## 4. Agent Behavior Rules (When and What to Test)

### When to create unit tests:
- **Whenever** a service containing pure data processing logic is created or modified (without direct dependencies on Revit classes).
- **Whenever** utility generic helper/extension classes are created.

### What NOT to unit test:
- Classes implementing `IExternalCommand` (they act solely as flow coordinators).
- Services directly depending on a real Revit `Document` for complex queries.
- User interface code / XAML and WPF files.
- Ribbon configuration in `Application.cs`.

### What TO unit test:
- Data transformation logic (grouping, filtering, mathematical or unit calculations).
- Data models and their internal validation rules.
- Helpers and extensions independent of the Revit API.
- ViewModels (presentation logic isolated from Revit, simulating user commands).
