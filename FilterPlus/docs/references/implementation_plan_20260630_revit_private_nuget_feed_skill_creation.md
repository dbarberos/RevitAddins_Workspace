# Implementation Plan: Revit Private NuGet Feed Skill Creation

This plan outlines the creation of a new global agent skill: `revit-private-nuget-feed` inside the `.agents/skills/` directory. This skill acts as a complete guide and automation script kit to extract official Autodesk Revit DLLs, build private NuGet packages, set up a local workspace package feed, and configure CI/CD caching.

## User Review Required

> [!IMPORTANT]
> - **Isolation from Active Workspace Code:**
>   - **No active project code, `.csproj` configurations, or solution-level config files in the project workspace will be modified.**
>   - All files (the technical guide, the PowerShell script, the `.nuspec` template, and the `nuget.config` example) will reside strictly within the new global skill directory `.agents/skills/revit-private-nuget-feed/` and its subdirectories (`assets/`, `references/`, `scripts/`).
>   - This ensures the project's current operation is completely unaffected, while providing the agent and user with a self-contained reference and automation kit for future use.

## Proposed Changes

### Component: New Global Agent Skill (Self-Contained)

---

#### [NEW] [SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-private-nuget-feed/SKILL.md)
- Define YAML frontmatter containing:
  - `name: revit-private-nuget-feed`
  - `description: Manages the creation, building, and configuration of custom private NuGet packages for official Revit API binaries, establishing local project feeds and CI/CD version caching to eliminate third-party dependencies.`
- Structure it as a lightweight metadata index (under 50 lines) referencing the guide, scripts, and templates.

#### [NEW] [revit_nuget_feed_guide.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-private-nuget-feed/references/revit_nuget_feed_guide.md)
- Technical guide outlining:
  - Extracting Revit DLLs from Autodesk installation folders.
  - Creating multi-target private packages (.NET Framework 4.8 and .NET 8).
  - Registering the project-level feed via `nuget.config`.
  - Enforcing version pinning.
  - Mirroring/caching critical packages locally in corporate networks.
  - Applying a hybrid dependency strategy.

#### [NEW] [RevitAPI.nuspec](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-private-nuget-feed/assets/RevitAPI.nuspec)
- A template `.nuspec` file under `assets/` to define how the Revit DLL packages should be metadata-structured.

#### [NEW] [nuget.config](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-private-nuget-feed/assets/nuget.config)
- An example `nuget.config` template under `assets/` to register a local feed relative to the workspace.

#### [NEW] [pack_revit_api.ps1](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-private-nuget-feed/scripts/pack_revit_api.ps1)
- An automation script in PowerShell under `scripts/` to copy and package the official DLLs dynamically.

## Verification Plan

### Automated Checks
- Validate that the new skill's YAML matches formatting standards.

### Manual Verification
- Review the created files to ensure strict content segregation: code and configurations are isolated in `assets/` and `scripts/`, and `SKILL.md` is kept strictly under 50 lines.
