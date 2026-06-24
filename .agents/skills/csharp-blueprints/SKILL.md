---
name: csharp-component-blueprints
description: Technical memory and architectural blueprints for complex C# components. Use this to understand the internal logic, business rules, and UI patterns of the add-in before modifying existing core classes.
---

# 🏗️ Component Blueprints Index

This directory contains the "technical memory" of the most complex C# components. The goal is that any agent or developer can understand the internal logic without having to analyze thousands of lines of code from scratch.

## 📂 Guides Directory

- [SelectionFilterViewModel_Blueprint](references/SelectionFilterViewModel_Blueprint.md): Hierarchical tree logic, offline filtering, and live synchronization of the explorer.
- [1. Base Architecture and Patterns](references/1_Base_Architecture_and_Patterns.md): Add-in foundations, `IExternalApplication`/`IExternalCommand` interfaces, global variables, and generics.
- [2. UI Design](references/2_Efficient_UI_Design.md): Professional Ribbon creation, UI extension methods, embedded icon management, and menu organization (PullDowns/Stacks).
- [3. Filters and Selection](references/3_Filters_and_Selection.md): Advanced use of `FilteredElementCollector`, LINQ for Revit, Workset collection, and interactive selection filters (`ISelectionFilter`).
- [4. Transactions and Events](references/4_Transactions_and_Events.md): Secure database management, editability in collaborative models (Worksharing), and subscription to native Revit events.
- [5. Advanced Forms (WinForms)](references/5_Advanced_UI_WinForms.md): `FormResult` pattern, responsive layouts, dynamic filtering ListViews, and async progress bars (`DoEvents`).
- [6. Scalability and Performance](references/6_Scalability_and_Performance.md): Multiversion support (`#if`), dynamic command availability, Excel interoperability (`ClosedXML`), and high-performance dictionaries.
- [RevitSelectionService_Blueprint](references/RevitSelectionService_Blueprint.md): Collector management, phase pre-fetching, and thread-safety (Pending to write).
- [debugging_increase_checked_apply_not_firing_2026-06-22](references/debugging_increase_checked_apply_not_firing_2026-06-22.md): Root cause analysis for "Apply" button with no effect — empty currentCheckedIds, missing element injection into `_activeElements`, and scope-crossing persistence gap.
- [guide_visible_in_view_scope_filter_2026-06-22](references/guide_visible_in_view_scope_filter_2026-06-22.md): Pattern for adding a "Visible in current view" WHERE scope using the two-argument `FilteredElementCollector(doc, viewId)` overload.
- [guide_unselect_elements_purge_pattern_2026-06-22](references/guide_unselect_elements_purge_pattern_2026-06-22.md): Design pattern for applying exclusion rules (group/assembly membership) as a global purge AFTER unification — enabling standalone purge mode with no WHAT rules.
- [debugging_increase_checked_infinite_recursion_2026-06-24](references/debugging_increase_checked_infinite_recursion_2026-06-24.md): Root cause analysis for UI freezing during bulk selection updates due to missing `TreeItemViewModel.IsBulkUpdating` flag during external event execution.

## 🔧 Assets (Reusable Code)

- [SelectionSetHelper.cs](assets/SelectionSetHelper.cs): Static helper with `UnifySelectionSets()`, `PurgeByMembership()`, and `GetDomainElements()` for multi-scope selection expansion pipelines.

## 💡 How to use these guides
1. When asked to modify an existing class, first check if its Blueprint exists here.
2. If you create new complex logic, **it is mandatory** to generate its corresponding Blueprint in the `references/` directory for future reference.
3. Blueprints should focus on the "WHY" and "BUSINESS RULES", not just the "HOW".
