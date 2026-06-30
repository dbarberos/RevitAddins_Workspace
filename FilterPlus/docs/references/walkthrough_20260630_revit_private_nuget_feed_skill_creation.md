# Walkthrough: Revit Private NuGet Feed Skill Creation

I have created a new global skill `revit-private-nuget-feed` in the repository's `.agents/skills/` directory. This skill provides an instruction manual, configuration templates, and a PowerShell automation script to extract Revit API DLLs and package them into custom, private NuGet packages. 

No active project configurations or solution-level code files were modified.

## Files Created

- **[.agents/skills/revit-private-nuget-feed/SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-private-nuget-feed/SKILL.md)**: Metadata index and entry point for the skill, listing technical guides, templates, and scripts.
- **[.agents/skills/revit-private-nuget-feed/references/revit_nuget_feed_guide.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-private-nuget-feed/references/revit_nuget_feed_guide.md)**: Conceptual guide detailing Autodesk DLL extraction, multi-version directory structures, relative local workspace NuGet feed registration, version pinning rules, and corporate caching strategies.
- **[.agents/skills/revit-private-nuget-feed/assets/RevitAPI.nuspec](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-private-nuget-feed/assets/RevitAPI.nuspec)**: NuGet XML specification template to bundle `RevitAPI.dll`, `RevitAPIUI.dll`, and `AdWindows.dll` for net48 and net8.0 targets.
- **[.agents/skills/revit-private-nuget-feed/assets/nuget.config](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-private-nuget-feed/assets/nuget.config)**: Example configuration template registering a relative local feed path.
- **[.agents/skills/revit-private-nuget-feed/scripts/pack_revit_api.ps1](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-private-nuget-feed/scripts/pack_revit_api.ps1)**: Reusable PowerShell automation script to extract Revit binaries, write versions in the `.nuspec` dynamically, download `nuget.exe` if needed, and build the custom `.nupkg` package into the output folder.

## Modified Files
- **[AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md)**: Registered the `revit-private-nuget-feed` skill in the "Available Skills" table.

---

## Verification & Testing
- Checked that the directory structure and file contents follow the strict metadata separation standards: code is isolated in `assets/` and `scripts/` with native extensions, and the index `SKILL.md` is strictly under 50 lines.
- Evaluated YAML frontmatter headers to ensure they are valid and descriptive.
