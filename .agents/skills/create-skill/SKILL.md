---
name: create-skill
description: Scaffolds new agent skills for the RevitAddins_Workspace repository. Use when creating a new skill, generating SKILL.md files, or setting up skill directory structures. Handles frontmatter generation, section templates, and validation guidance for dual-stack (C#/Python) environments.
---

# Create Skill — AI Skill Creation and Scaffolding Guide

This skill assists the agent in the creation and structuring of new modular AI skills, ensuring they comply with the unified dual-stack topology of the repository.

## When to Use
- When creating a new skill from scratch to expand the agent's capabilities (e.g., PDF manipulation, automatic Word documentation generation, or CI/CD integrations).
- When structuring and generating a `SKILL.md` file with its corresponding YAML frontmatter block.
- When configuring the physical hierarchy of mandatory subfolders to prevent bloat in the main index.

## When Not to Use
- When modifying the source code of existing skills (edit their assets or references directly instead).
- When configuring isolated workflow prompts (use the `.agents/prompts/` folder instead).

---

## Inputs

| Input | Required | Description |
|-------|----------|-------------|
| **Skill name** | Yes | Lowercase, alphanumeric, and dashed name (e.g., `pdf-generator`, `revit-clash-detector`). |
| **Description** | Yes | What the skill does and when the agent should use it (1-1024 characters). |
| **Purpose** | Yes | A paragraph detailing the result and goal of the skill. |
| **Workflow** | Recommended | Sequential numbered steps with checkpoints. |

---

## Creation Workflow

### Step 1: Skill Name Validation
Ensure that the name:
- Contains only lowercase letters, numbers, and single dashes.
- Does not start or end with a dash.
- Has a length between 1 and 64 characters.

### Step 2: Directory Structure Creation
Create the skill directory under the unified physical path of the repository:
```text
.agents/skills/<skill-name>/
├── SKILL.md         # Index and main semantic manifest of the skill
├── scripts/         # Auxiliary executable scripts (PowerShell, Python, Bash)
├── references/      # Technical guides, API rules, and debugging lessons learned
└── assets/          # Injectable reusable source code (.cs, .py, .wxs, .xml)
```

---

## 🛠️ Strict Content Segregation Rules

### A. Saving Code Assets (assets/):
*   **Mandatory Rule:** All source code or reusable C# or Python snippets **must** be saved in their physical file with the corresponding native extension (e.g., `MyHelper.cs`, `script.py`, `Product.wxs`).
*   **Prohibition:** It is strictly **prohibited** to embed extensive code blocks directly within `SKILL.md` or in Markdown files under `references/`. This keeps context tokens at the optimal level.

### B. Preserving Debugging Lessons (references/):
*   **Mandatory Rule:** Every time the agent solves a complex Revit API error, a C# compilation failure, or an execution problem in Python/pyRevit, it **must** document the resolution.
*   **File Format:** Create a quick Markdown report in the skill's `references/` folder under the nomenclature:  
    `references/debugging_[keywords]_[YYYY-MM-DD].md`
*   **Minimum Content:**
    1.  **Symptom:** What console error or anomalous behavior occurred.
    2.  **Root Cause:** Why the API, transaction, or Revit thread failed.
    3.  **Solution:** Technical explanation and corrected code snippet that solved the bug.

---

## Base Template for `SKILL.md`

Every new `SKILL.md` file must act solely as a **lightweight metadata index** structured under the following format:

```markdown
---
name: <skill-name>
description: <1-1024 characters describing what the skill does and when to invoke it>
---

# <Skill Name>

<A concise paragraph describing the purpose and outcome of this component.>

## 📚 Technical References (Knowledge Base)
Check the following files in the `references/` folder for in-depth guides:

*   `references/technical_guide.md`: Conceptual explanation of the skill's domain.
*   `references/debugging_[problem]_[date].md`: Lessons learned and history of resolved bugs.

## 📦 Assets (Templates and Source Code)
The following files are found in the `assets/` folder ready to be injected directly into the project:

*   `assets/HelperClass.cs`: Support base class in C# (if applicable).
*   `assets/utility_script.py`: Support base script in Python (if applicable).
```

---

## Validation Checklist

- [ ] The skill name exactly matches the name of its subfolder.
- [ ] The YAML description is concise, descriptive, and does not exceed 1024 characters.
- [ ] The main `SKILL.md` file does not exceed 50 physical lines (acts only as an index).
- [ ] The secondary folders `references/`, `assets/`, and `scripts/` physically exist.
- [ ] There are no injectable code snippets embedded in `SKILL.md`. All reusable code resides in `assets/` with their respective native file extensions (`.cs`, `.py`).
- [ ] Bug resolution reports are saved under the nomenclature `debugging_[keywords]_[YYYY-MM-DD].md`.
