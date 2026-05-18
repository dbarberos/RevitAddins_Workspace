# Implementation Plan - Modular Skill Restructuring

This plan details the technical process for migrating and restructuring the entire workspace skill ecosystem to the new modular architecture (`scripts/`, `references/`, `assets/`) proposed to optimize AI agent performance and reasoning accuracy.

## Objectives
1. **Standardize**: Create the three key subfolders in all 44 workspace skills.
2. **Decompress**: Extract massive code blocks from `SKILL.md` files into independent physical files.
3. **Reinforce**: Update the master rules for creating and modifying skills to mandate this structure for future agents.

## Proposed Changes

### 1. Global Folder Creation
Execute an automated PowerShell script to iterate through all directories in `.agents/skills/` and guarantee the existence of:
- `scripts/`: For executable script files.
- `references/`: For technical guides and Markdown documentation.
- `assets/`: For templates, boilerplates, and icons.

### 2. C# and Revit Skills Migration
- **`csharp-blueprints`**: Move all architecture guides (1, 2, 3, 4, 5, 6, and specific Blueprints) into `references/`.
- **`revit-addin-helpers`**: Extract the 7 C# helpers from `SKILL.md` into individual `.cs` files inside `assets/`.
- **`revit-api`**: Extract advanced Revit rules (thread safety, TreeView performance, `.csproj` templates, and `ForgeTypeId`) into Markdown files under `references/`.
- **Update `SKILL.md`**: Convert the main skill files into clean, lightweight indices.

### 3. Modifying Master Instructions (AI Guidelines)
- **`AGENTS.md`**: Modify the artifact backup guidelines to enforce the modular structure when saving walkthroughs or reporting debugging logs.
- **`create-skill/SKILL.md`**: Modify the templates and validation checklist in the creation skill to make `scripts/`, `references/`, and `assets/` subfolders mandatory for all future skills.
