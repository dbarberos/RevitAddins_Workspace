# Technical Guide: SkillOpt Workflow (Meta-Learning)

This technical reference outlines the exact operational protocol the AI agent must follow when the developer requests to apply **SkillOpt** to capture, catalog, and refine technical knowledge from a recently completed feature or bug fix.

Inspired by [Microsoft's SkillOpt](https://github.com/microsoft/SkillOpt) concepts, this workflow dynamically optimizes the repository's global skills (`.agents/skills/`) based on successful development trajectories, preserving technical wisdom and preventing the reintroduction of known issues.

---

## 🔄 The SkillOpt Cycle in RevitAddins_Workspace

Upon receiving the user trigger:
> **"aplica el skillopt para todo el trabajo realizado anterior de [feature/change]"**

The agent will sequentially execute the following workflow:

```
┌────────────────────────────────────────────────────────┐
│             1. TRAJECTORY INVESTIGATION                │
│  Scan Git (diffs, logs) and read edited workspace files │
└───────────────────────────┬────────────────────────────┘
                            │
                            ▼
┌────────────────────────────────────────────────────────┐
│          2. DIAGNOSIS & RULE EXTRACTION                │
│ Identify: Optimal Design Pattern, Root Cause of bugs   │
└───────────────────────────┬────────────────────────────┘
                            │
                            ▼
┌────────────────────────────────────────────────────────┐
│         3. MODULAR ASSIGNMENT & SEGREGATION            │
│   Select target Skill, separate code assets from       │
│   written Markdown documentation (debugging reports)   │
└───────────────────────────┬────────────────────────────┘
                            │
                            ▼
┌────────────────────────────────────────────────────────┐
│           4. INTEGRITY CHECK & REFINEMENT              │
│   Resolve ambiguities (Ask User) & ensure conciseness   │
└───────────────────────────┬────────────────────────────┘
                            │
                            ▼
┌────────────────────────────────────────────────────────┐
│             5. PHYSICAL SKILL UPDATING                 │
│  Create references/debugging_..., assets/ & update SKILL.md│
└────────────────────────────────────────────────────────┘
```

---

## 📖 Step-by-Step Operational Instructions

### Step 1: Trajectory Scanning and Scope Definition
The agent must isolate all modified files and past interactions related to the specified feature.
- **Terminal Inspection**: Run `git status` and `git diff` (or analyze recent git commits) to pinpoint exact changes.
- **Workspace Reading**: Directly read modified code files to map out API usage, WPF configurations, or custom logic implemented.

### Step 2: Knowledge Extraction and Formatting
Determine what technical elements must be preserved. Categorize findings into:
1. **Best Practices / Optimal Design Patterns**: High-performance architecture, clean WPF/MVVM models, efficient API queries, etc.
2. **Debugging Lessons-Learned**: Root causes of compilation or execution failures (e.g., Revit thread safety issues, transaction problems, WPF binding bugs) and their exact code resolutions.

### Step 3: Target Skill Mapping & Segregation of Concerns
Never accumulate all knowledge into a single generic file. Distribute findings modularly across global skills:
- **`revit-api`**: Pure Revit database operations, FilteredElementCollectors, transactions, thread handling.
- **`csharp-blueprints` / `csharp-community-toolkit-mvvm`**: Design patterns, ViewModels, observable properties, generic hosts.
- **`integrating-wpfui-fluent`**: XAML styling, Fluent controls, dark/light themes.
- **`revit-addin-helpers`**: Reusable extensions, unit conversions, UI dialog wrappers.
- **`revit-pyrevit-python` / `revit-rps-python`**: pyRevit UI components, dynamic scripting, and shell consoles.

#### Physical Coding & Documentation Rules:
- **Reusable Code Assets (`assets/`)**: If a robust utility class or helper function is designed (e.g., a custom collector or an MEP connector crawler), extract it into a standalone file under the target skill's `assets/` folder with its native file extension (`.cs`, `.py`). **Do not embed large code blocks inside Markdown files.**
- **Technical Reference Documents (`references/`)**:
  - For concepts/patterns: `references/guia_[keywords].md` (or `references/[keywords]_guide.md`).
  - For bug resolutions: `references/debugging_[keywords]_[YYYY-MM-DD].md` (explicitly detailing Symptom, Root Cause, and Solution).
- **Index Update (`SKILL.md`)**: List the new reference/asset under the appropriate sections of the target skill's index file.

### Step 4: Token Efficiency & Conciseness
A cornerstone of **SkillOpt** is avoiding rule bloat. Instructions must remain lightweight to optimize the model's active context window.
- Write highly-structured, brief technical summaries.
- Keep code snippets compact, focusing strictly on the issue/solution.

### Step 5: Handling Ambiguity via Interactive Questioning
If the code trajectory is too wide or a bug's root cause is unclear from the files alone, the agent **must halt and ask the user** clarifying questions before proceeding:
- *"I noticed you implemented X but also adjusted Y. Was the original error due to a Revit API thread violation or a WPF assembly mismatch?"*
- This prevents injecting incorrect assumptions into the global skill files.

---

## ✅ Agent Definition of Done Checklist

Before completing a SkillOpt run, the agent must verify:
- [ ] All modified files for the requested feature have been identified and analyzed.
- [ ] The appropriate target global skill has been selected.
- [ ] Bug resolutions are written in the `references/debugging_[keywords]_[YYYY-MM-DD].md` standard.
- [ ] Reusable code is isolated in a native-extension file inside `assets/`.
- [ ] The target skill's index `SKILL.md` is updated and remains under 50 lines (metadata index only).
- [ ] The generated contents are fully in English to maximize token-saving and LLM consistency.
