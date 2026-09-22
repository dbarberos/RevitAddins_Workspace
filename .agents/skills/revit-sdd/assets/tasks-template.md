# Tasks: [Feature Name]

**Spec ID:** `[00X]`  
**Target Add-in:** `[AddInName]`  
**Status:** DRAFT | IN PROGRESS | COMPLETED  
**Author / Architect:** SDD Architect  

---

## 1. Execution Protocol

1. **One Task at a Time**: Process strictly one task per turn.
2. **Review & Check**: Before moving to the next task, verify that the current task compiles and satisfies its associated requirement, then mark it with `[x]`.
3. **No Unplanned Code**: Never add classes, methods, or UI controls outside the approved technical plan.

---

## 2. Microtasks Breakdown (20–30 min per task)

### Phase 1: Pure Domain & Decoupled Contracts
- [ ] **T1: Define Pure Models and DTOs** (Maps to: `RF-1`)
  - Create `/Models/[FeatureItem]Model.cs` with primitive properties, avoiding Revit API element references.
  - Implement any pure formatting, validation, or sorting logic.
- [ ] **T2: Define Service Interface** (Maps to: `RF-1`, `RF-2`)
  - Create `/Services/I[Feature]Service.cs` declaring data extraction and mutation method signatures.

### Phase 2: Revit API Data Access & Mutation
- [ ] **T3: Implement Target Collector & Filtering** (Maps to: `RF-2`)
  - Implement collector logic in `/Services/[Feature]Service.cs` using fast native filters (`OfCategory`, `OfClass`).
  - Add null checks and boundary safety filters (e.g., read-only document guards).
- [ ] **T4: Implement Transactional Execution with WarningSwallower** (Maps to: `RF-3`, `RF-4`)
  - Implement mutation methods wrapping operations in `using (Transaction tx = ...)` blocks.
  - Attach `WarningSwallower` to preprocessor options.

### Phase 3: WPF MVVM Presentation Layer
- [ ] **T5: Create ViewModel with CommunityToolkit.Mvvm** (Maps to: `RF-2`, `RF-3`)
  - Create `/ViewModels/[Feature]ViewModel.cs` using `ObservableObject`, `[ObservableProperty]`, and `[RelayCommand]`.
  - Wire injected service calls asynchronously or via command binding.
- [ ] **T6: Build WPF View with Inline Resources and Virtualization** (Maps to: `RF-2`, `RF-5`)
  - Create `/Views/[Feature]View.xaml` adhering to FilterPlus card-based theme.
  - Declare all styles and templates inline in `<Window.Resources>`.
  - Enable virtualization on list/tree controls.

### Phase 4: Revit Command & Ribbon Integration
- [ ] **T7: Implement IExternalCommand** (Maps to: `RF-1`)
  - Create `/Commands/Cmd[Feature].cs` with `[Transaction(TransactionMode.Manual)]`.
  - Resolve dependencies and invoke View/ViewModel.
- [ ] **T8: Register Ribbon PushButton** (Maps to: `RF-1`)
  - Add button definition to `Application.cs` with 16x16 and 32x32 embedded icons, tooltip, and help link.

### Phase 5: Verification & Acceptance Sign-off
- [ ] **T9: Full Acceptance Criteria Verification** (Maps to: `AC-1` .. `AC-5`)
  - Walk through all criteria in `spec.md` and confirm full coverage.
  - Verify clean build without warnings across supported Revit versions.
