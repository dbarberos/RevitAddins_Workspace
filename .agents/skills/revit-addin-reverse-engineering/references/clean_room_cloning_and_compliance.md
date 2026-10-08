# Clean-Room Cloning & Legal Compliance Guide

This guide establishes the legal boundaries and clean-room engineering principles that the agent and developer must follow when analyzing reference add-ins and building modern clones.

---

## 1. The Clean-Room Engineering Principle

Clean-room design (also known as the "Chinese Wall" technique) separates the **analysis of functionality** from the **authoring of new code**:

```text
┌─────────────────────────────────┐           ┌─────────────────────────────────┐
│     DIRTY ROOM (Analysis)       │           │     CLEAN ROOM (Authoring)      │
│  - Inspect reference .dll/.py   │           │  - Reads ONLY the Blueprint     │
│  - Trace transactions & logic   │ ────────▶ │  - Writes C# 12 / MVVM from     │
│  - Identify formulas & formats  │ Blueprint │    scratch                      │
│  - Discard all original code    │           │  - Uses FilterPlus design system│
└─────────────────────────────────┘           └─────────────────────────────────┘
```

1. **Analysis Output**: The analysis phase produces only a **Functional Specification / Architectural Blueprint** (`assets/clean_room_blueprint_template.md`). It describes *what* the system does (inputs, steps, math, Revit API types used), never copying the syntax.
2. **Authoring Input**: The implementation phase reads *only* the clean blueprint and writes brand new, modern C# 12 / MVVM code.

---

## 2. Legal Boundaries & Copyright Protection

### A. Idea vs. Expression Dichotomy
Under international copyright law (US Copyright Act § 102(b), EU Software Directive 2009/24/EC Art. 5 & 6, WIPO):
- **Protected by Copyright**: The specific creative *expression* (the exact source code, method variable names, comments, visual branding, logos, proprietary UI layout).
- **NOT Protected by Copyright**: The underlying *idea*, *procedure*, *process*, *system*, *method of operation*, or *mathematical concept*.

### B. Interoperability & Fair Use
Reverse engineering a compiled software component to achieve interoperability (e.g., reading files, understanding Extensible Storage schemas, extracting parameter structures, or understanding Revit API coordination) is explicitly protected when:
1. The analysis is performed by a legitimate possessor of the binary.
2. The information obtained is not used to create a substantially identical clone of the *expression*, but rather an independently authored work.

### C. Strict Boundaries: What MUST NEVER be Done
1. **Never copy decompiled source code verbatim**: Decompiled code often contains decompilation artifacts and preserves the original author's expression. Write all methods from scratch using modern C# 12 syntax.
2. **Never copy proprietary branding or assets**:
   - Do NOT reuse proprietary icons, splash screens, trademarks, or copyrighted strings.
   - Recreate custom icons using standard geometric SVG/PNG resources or the `revit-addin-icon-manager` skill.
3. **Never bypass DRM or licensing controls**:
   - If the reference add-in contains license key validation, server phone-homes, or anti-tamper cryptography, **do not reverse-engineer the license bypass**.
   - Simply implement the legitimate core functionality without licensing encumbrances.
4. **Never reuse third-party proprietary binaries**:
   - If the reference tool relies on closed-source third-party utility DLLs, replace them with standard open-source equivalents (e.g., replace closed Excel readers with `ClosedXML` / `ExcelDataReader` / `EPPlus`).

---

## 3. Modernization & Superiority (Delta Principles)

A clean-room clone is not just an alternative; it must be **technically superior** to the reference:

| Legacy Reference Pattern | Modernized Clean-Room Implementation |
|---|---|
| **WinForms or old WPF with Code-Behind** | WPF MVVM with `CommunityToolkit.Mvvm` 8.2.2 and C# 12 primary constructors. |
| **No thread safety (Revit UI Freezes)** | Modeless async execution via `Revit.Async` (`await RevitTask.RunAsync(...)`). |
| **Unhandled Warning popups block batch runs** | Integrated `WarningSwallower` (`IFailuresPreprocessor`) to silently dismiss non-fatal warnings. |
| **Parameter Bloat / Unmanaged Shared Params** | Reusable parameter pools or structured Extensible Storage schemas. |
| **Monolithic 2,000-line God Classes** | SOLID separation: `View` -> `ViewModel` -> `Service` -> `RevitApiGateway`. |
| **Deprecated Revit API calls** | Modern API types: `ForgeTypeId` instead of `UnitType`/`ParameterType`; 64-bit `ElementId.Value`. |
| **No automated test coverage** | In-process integration tests with `Nice3point.TUnit.Revit`. |
