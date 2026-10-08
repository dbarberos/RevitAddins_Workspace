# Clean-Room Architectural Blueprint: [Target Add-in Name]

> **Status:** Draft / Approved  
> **Source Reference:** `[Path to binary or draft folder]`  
> **Target Modern Add-in:** `[New Addin Name]`  
> **Target Revit Versions:** Revit 2024 (.NET Framework 4.8) & Revit 2025+ (.NET 8 CoreCLR)  
> **Compliance Gate:** Clean-room abstraction verified. No proprietary expression copied.

---

## 1. Reference Inspection Summary

| Attribute | Reference Implementation | Clean-Room Target |
|---|---|---|
| **Assembly / Script** | `OriginalName.dll` | `NewAddinName.dll` |
| **Original Architecture** | WinForms / Legacy WPF code-behind | C# 12 MVVM (`CommunityToolkit.Mvvm` 8.2.2) |
| **Ribbon Tab / Panel** | Custom Tab `[OldTab]` | Standard `Add-Ins` tab (`Application.CreatePanel`) |
| **Execution Modality** | Modal Dialog / Modeless (Blocking) | Async Modeless (`Revit.Async`) / Modal Nice3point |
| **Failure Handling** | None (Default Revit Dialogs) | `WarningSwallower` (Silent batch execution) |

---

## 2. Discovered Entry Points & Commands

### A. Ribbon & Application Startup
- **Application Class:** `OriginalNamespace.App : IExternalApplication`
- **Ribbon Layout:**
  - Panel: `[Panel Title]`
  - PushButton: `[Button Name]` -> Calls `Cmd[FeatureName]`

### B. Commands Catalog
```text
- Command: Cmd[FeatureName]
  - TransactionMode: Manual
  - Modality: Modal Dialog / Modeless Window / Direct Execution
  - Summary: [What this command triggers]
```

---

## 3. Extracted Domain Rules & Evidence

### A. Document Transactions & DB Operations
```text
1. Transaction: "[Transaction Name]"
   - Target Elements: [OST_Categories involved]
   - Modifications: [What parameters or geometry are altered]
   - SubTransactions: [Any subtransactions used]
```

### B. Extensible Storage & Parameter Mapping
- **Extensible Storage Schemas:**
  - Schema GUID: `[00000000-0000-0000-0000-000000000000]`
  - Field Names & Types: `[FieldName (StringType), ...]`
- **Parameters Used:**
  - Built-in Parameters: `[BuiltInParameter.XXX]`
  - Shared Parameters: `[Name, GUID, Group, Type]`

### C. Mathematical & Geometry Algorithms
```text
[Describe the step-by-step mathematical logic in plain language or pseudocode. Do not paste decompiled C# code.]
Step 1: Calculate bounding box coordinates.
Step 2: Transform points across linked coordinate space using LinkDocument.GetTotalTransform().
Step 3: ...
```

---

## 4. Architectural Clean-Room Specification

### A. Pure Domain Models (DTOs)
```csharp
// Pure records independent of Autodesk.Revit.DB
public record FeatureItemDto(
    string Id,
    string Name,
    bool IsActive
);
```

### B. Service Interfaces
```csharp
public interface IFeatureProcessingService
{
    Task<ProcessingResult> ExecuteAsync(Document doc, FeatureItemDto item, CancellationToken ct);
}
```

### C. Modern UI Design System
- **View:** `Views/[FeatureName]View.xaml`
  - Style: FilterPlus Fluent card-based layout.
  - Resources: Inline `<Window.Resources>` (Zero pack:// application dictionaries).
  - Virtualization: `VirtualizingStackPanel.IsVirtualizing="True"` for all lists.

---

## 5. Delta Engineering & Innovation (Superiority Features)

| Feature | Reference Limitation | Clean-Room Innovation |
|---|---|---|
| **UI Responsiveness** | UI freezes during calculation | Background processing with cancellation token |
| **Warning Dialogs** | Crashes on duplicate types | Automated suppression via `WarningSwallower` |
| **Parameter Handling** | Creates unmanaged parameters | Reusable pool or Extensible Storage |
| **Search / Filtering** | Basic static list | Live regex search and multi-column filtering |

---

## 6. Testing & Validation Plan

- [ ] In-process Ribbon registration test via `Nice3point.TUnit.Revit`.
- [ ] Isolated in-memory transaction test on empty document.
- [ ] Stress test with 10,000+ elements for UI virtualization verification.
