# Implementation Plan - Workspace Globalization and Skill Translation

This implementation plan details the technical roadmap used to migrate and standardize the entire Revit developer workspace to a modular, 100% English-first architecture. This optimizes token efficiency, prevents character encoding issues, and simplifies future AI reasoning.

## 🎯 Objectives
1. **Language Standardization**: Translate all core instructions (`AGENTS.md`), master guides, and skill references from Spanish to English.
2. **Modular Organization**: Fully enforce the modular directory structure (`scripts/`, `references/`, `assets/`) globally across all agent skills.
3. **Robustness & Validation**: Resolve character encoding issues by renaming Spanish reference files to ASCII English and updating markdown links, followed by running automated domain-gate validations.

---

## 🛠️ Proposed Changes

### 1. Global Developer Guidelines
- [MODIFY] [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md): Translate all core instructions, directory structure specifications, and backup procedures to English.
- [MODIFY] [3Guia maestra desarrollo add-ins Revit 2024.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/3Guia%20maestra%20desarrollo%20add-ins%20Revit%202024.md): Fully translate the Master Development Guide to English.

### 2. Core Agent Skills
- [MODIFY] `csharp-blueprints/SKILL.md`: Translate the skill manifest and update relative links to point to the new English-named reference blueprints.
- [MODIFY] `revit-api/SKILL.md`: Translate and index all technical reference files.
- [MODIFY] `revit-addin-helpers/SKILL.md`: Translate the lightweight index for helper classes.
- [MODIFY] `revit-addin-installer-manager/SKILL.md`: Translate WiX automation and MSI packaging rules.
- [MODIFY] `revit-addin-doc-manager/SKILL.md`: Translate the documentation standard index.
- [MODIFY] `revit-addin-icon-manager/SKILL.md`: Translate the Ribbon icon replacement rules.
- [MODIFY] `revit-addin-testing/SKILL.md`: Translate unit testing, mock frameworks, and MSBuild compilation testing rules.
- [MODIFY] `workspace-ops/SKILL.md`: Translate the workspace infrastructure commands.

### 3. Blueprint References (`csharp-blueprints/references/`)
- [DELETE] Spanish blueprints (1 to 6) containing special accents/characters in their names.
- [NEW] Write English versions with clean ASCII filenames:
  - `1_Base_Architecture_and_Patterns.md`
  - `2_Efficient_UI_Design.md`
  - `3_Filters_and_Selection.md`
  - `4_Transactions_and_Events.md`
  - `5_Advanced_UI_WinForms.md`
  - `6_Scalability_and_Performance.md`

### 4. Global References & Product Docs
- [DELETE] Spanish originals `guia_firma_digital_revit.md` and `Guia_Uso.md`.
- [NEW] Write translated, clear English guides:
  - `docs/references/revit_digital_signing_guide.md`
  - `FilterPlus/docs/references/user_guide.md`

---

## 🔬 Verification Plan
- **Automated Validation**: Run the `agentic-workflows/dotnet-msbuild/build.ps1` script with `powershell.exe -ExecutionPolicy Bypass` to ensure that all 14 skills pass frontmatter check criteria and compile cleanly into their respective lock files.
- **Link Checking**: Verify that all relative paths in `SKILL.md` indices point to existing reference files and resolve properly in markdown preview.
