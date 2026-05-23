---
name: workspace-ops
description: Repository infrastructure instructions for RevitAddins_Workspace — skill building, frontmatter validation, and plugin management. Use this when you need to maintain or validate the workspace's skills and plugins structure.
---

# Workspace Operations — Repository Infrastructure

> These instructions were originally part of `AGENTS.md` and were extracted here to keep the main file focused on Revit add-in generation. This skill preserves the operational knowledge about the workspace infrastructure.

## 1. Plugins Structure

This repository contains skill plugins under `plugins/`. Each subdirectory in `plugins/` is an independent plugin (e.g., `plugins/dotnet-msbuild`, `plugins/dotnet`).

## 2. Skill Build

When you modify skills, run the agentic-workflows build script to validate and regenerate compiled artifacts:

```powershell
pwsh agentic-workflows/<plugin>/build.ps1
```

This validates the frontmatter of each skill and recompiles the knowledge lock files. **Always commit the regenerated lock files along with your changes.**

## 3. Skill-Validator

> Backward compatibility does not matter much for this tool. Consumers understand that its shape changes constantly.

The skill-validator is a distribution tool — its NuGet package and `.tar.gz` files are built from `eng/skill-validator/src/`.

### Content Rules
- Content referenced at runtime or packaged with the tool (docs, README, etc.) **must live under `src/`** so that it is included in the published output.
- **Do not add** references from `src/` to files outside of it, except for packaging assets explicitly linked (like the `LICENSE` file from the repository root) referenced by the project file.

### Documentation Synchronization
When you modify:
- The evaluation pipeline (`evaluation.yml`)
- The JSON results schema (`Models.cs`)
- The evaluation logic of the skill-validator

**YOU MUST review and update** `eng/skill-validator/src/docs/InvestigatingResults.md` to keep the failure investigation guide, the schema documentation, and the example scripts synchronized.

## 4. When to Use This Skill
- When creating or modifying skills in the `.agents/skills/` folder
- When updating plugins under `plugins/`
- When debugging skill-validator build issues
- When you need to regenerate lock files after changes in skill frontmatter
