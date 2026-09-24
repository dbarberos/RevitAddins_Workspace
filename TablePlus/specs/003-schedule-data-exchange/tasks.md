# Tasks: Bidirectional Schedule Data Exchange (Spec 003)

**Spec ID:** `003`  
**Target Add-in:** `TablePlus`  
**Status:** DRAFT (Phase Gate 4: Ready for User Validation)  
**Author / Architect:** SDD Polyglot Architect  
**Date:** 2026-09-24  

---

## 1. Execution Protocol

1. **One Task at a Time**: Process strictly one task per turn.
2. **Review & Check**: Before moving to the next task, verify that the current task compiles and satisfies its associated requirement, then mark it with `[x]`.
3. **No Unplanned Code**: Never add classes, methods, or UI controls outside the approved technical plan.
4. **Artifact Traceability**: Document milestones in `TablePlus/docs/references/` upon major task completions.

---

## 2. Microtasks Breakdown (20–30 min per task)

### Phase 1: Pure Domain, DTOs & Service Contracts

- [ ] **T1: Define Pure Models and DTOs (`TablePlus/Models/ScheduleLink/`)** (Maps to: `RF-2`, `RF-3`, `RF-4`)
  - Create `ExtractionMode.cs` and `ParameterScope.cs`.
  - Create `ScheduleDefinitionItem.cs` and `CategoryDefinitionItem.cs`.
  - Create `ParameterDefinitionItem.cs` with StorageType, ForgeTypeId, UnitLabel, and Scope.
  - Create `ScheduleRowData.cs` and `ScheduleTablePayload.cs`.
  - Create `WorksharingConflictItem.cs` and `ReconciliationReport.cs`.

- [ ] **T2: Define Service Interfaces (`TablePlus/Services/ScheduleLink/`)** (Maps to: `RF-2`, `RF-3`, `RF-5`, `RF-6`, `RF-7`, `RF-8`)
  - Create `IScheduleDataService.cs` (schedule extraction contracts).
  - Create `ICategoryDataService.cs` (category extraction contracts).
  - Create `IScheduleExcelService.cs` (ClosedXML export/import contracts).
  - Create `IWorksharingConflictService.cs` (borrowing conflict detection).
  - Create `IParameterMutationService.cs` (transactional mutation contracts).

### Phase 2: Core Data Extraction & ClosedXML Excel Engine

- [ ] **T3: Implement `ScheduleDataService` & `CategoryDataService`** (Maps to: `RF-2`, `RF-3`, `RF-4`)
  - Implement schedule inspection extracting visible fields and filtered rows via `ScheduleDefinition`.
  - Implement category inspection extracting instances and bound parameter definitions (Instance & Type).
  - Categorize parameters into Instance, Type, and Read-Only (`Parameter.IsReadOnly`).

- [ ] **T4: Implement `ScheduleExcelService` with ClosedXML** (Maps to: `RF-5`, `RF-6`, `RF-8`)
  - Implement `ExportToExcel`: builds formatted `.xlsx` workbooks, graying out locked `ElementId`/`UniqueId` headers, applying Lavender styling with `[TYPE]` badges for Type parameters, Gray styling for `[READ-ONLY]`, and formatting numerical values in active project units.
  - Implement `ReadFromExcel`: parses edited workbooks, correlates rows with `UniqueId`/`ElementId`, and detects cell modifications against current values.

### Phase 3: Transaction Safety, Worksharing & Parameter Mutation Engine

- [ ] **T5: Implement `WorksharingConflictService` & `ParameterMutationService`** (Maps to: `RF-7`, `RF-8`, `RF-9`, `RF-10`)
  - Implement `DetectConflicts` using `WorksharingUtils.GetCheckoutStatus`.
  - Implement `ApplyMutations`: wraps operations in `TransactionGroup`, applies `WarningSwallower`, safely parses strings back into internal storage types (Double, Integer, String, ElementId), applies `Parameter.Set()`, and tracks mutation metrics (Updated, Unchanged, Failed, Skipped).

### Phase 4: WPF MVVM Presentation Layer (FilterPlus Design System)

- [ ] **T6: Implement ViewModels (`ScheduleLinkViewModel`, `WorksharingConflictViewModel`, `ReconciliationReportViewModel`)** (Maps to: `RF-2`, `RF-3`, `RF-4`, `RF-7`, `RF-10`)
  - Create `ScheduleLinkViewModel.cs` using `CommunityToolkit.Mvvm` managing tabs, search filtering, collection selection, and export/import commands.
  - Create `WorksharingConflictViewModel.cs` handling user decision (Skip & Report vs. Rollback & Abort).
  - Create `ReconciliationReportViewModel.cs` managing summary badges, log displays, and text export.

- [ ] **T7: Implement WPF Views (`ScheduleLinkView.xaml`, `WorksharingConflictView.xaml`, `ReconciliationReportView.xaml`)** (Maps to: `RF-1`, `RF-4`, `RF-7`, `RF-10`)
  - Create `ScheduleLinkView.xaml` with inline XAML resources, virtualized lists for schedules/categories, and parameter checklist with scope badges.
  - Create `WorksharingConflictView.xaml` displaying conflict items and resolution action buttons.
  - Create `ReconciliationReportView.xaml` displaying executive summary cards and error logs.

### Phase 5: Command Wiring, Ribbon Integration & Validation

- [ ] **T8: Wire Command `CmdScheduleLink` and TablePlus Ribbon Integration** (Maps to: `RF-1`)
  - Create `TablePlus/Commands/CmdScheduleLink.cs` with `[Transaction(TransactionMode.Manual)]`.
  - Register `Schedule Link` pushbutton in the `TablePlus` ribbon panel under Revit's **Add-Ins** tab.
  - Add icons and contextual F1 help link.

- [ ] **T9: Multi-Version Compilation, Acceptance Criteria Verification & App Store Bundle Packaging** (Maps to: `AC-1` .. `AC-10`)
  - Compile and verify cleanly across `Release.R24`, `Release.R25`, `Release.R26`, and `Release.R27`.
  - Verify all 10 Acceptance Criteria.
  - Run `build-bundle.ps1` to update the App Store bundle.
  - Archive milestone walkthrough in `TablePlus/docs/references/`.
