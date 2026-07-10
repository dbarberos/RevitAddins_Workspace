# Walkthrough: Obfuscation and CI/CD Anti-Tampering Integration

We have successfully created the `revit-addin-obfuscation` skill, integrated Obfuscar into the workspace build targets, and added interactive compile configuration selection to the local deployment pipeline.

## 1. Created the Global Agent Skill `revit-addin-obfuscation`
*   **Skill Manifest**: Created [SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-obfuscation/SKILL.md) in English outlining constraints for entry point reflection, WPF ViewModel properties, and WebView2 interop.
*   **Assets Managed**:
    *   [obfuscar.xml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-obfuscation/assets/obfuscar.xml): Universal exclusions configuration for Revit DLL projects.
    *   [Obfuscar.targets](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-obfuscation/assets/Obfuscar.targets): Custom MSBuild target executing in `Configuration == Release` with auto-installer self-healing task.
    *   [build-and-pack.ps1](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-obfuscation/assets/build-and-pack.ps1): Interactive orchestrator offering menu choice for Production (Release + Obfuscated) or Development (Debug + full PDB symbols).
*   **Reference Document**: Wrote [44_AntiTampering_and_Obfuscation.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-obfuscation/references/44_AntiTampering_and_Obfuscation.md) to explain the C# code-behind decoration `[Obfuscation(Exclude = true, ApplyToMembers = true)]` approach to exclude custom items selectively.

## 2. Updated Agent Rules (`AGENTS.md`)
*   Registered `revit-addin-obfuscation` under Section 6.
*   Injected a mandatory planning rule in Section 6.1:
    > **CI/CD Obfuscation & Exclusions (revit-addin-obfuscation)**: Each time a pipeline of publication or a .csproj is configured in Release mode, import Obfuscar.targets, provide an obfuscar.xml template, and ensure entrypoint/UI classes are excluded using `[Obfuscation(Exclude = true, ApplyToMembers = true)]` in C#. Local deployment scripts must prompt the developer to choose between Production (Release + Obfuscated) and Development (Debug + PDB symbols).

## 3. Local Project Configuration (`FilterPlus`)
*   **MSBuild Import**: Configured [FilterPlus.csproj](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/FilterPlus.csproj) to import `..\Obfuscar.targets`.
*   **Workspace Deployment**: Deployed solution-level files [obfuscar.xml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/obfuscar.xml), [Obfuscar.targets](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/Obfuscator.targets), and [build-and-pack.ps1](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/build-and-pack.ps1) at the workspace root directory.
*   **Cleanup**: Successfully deleted temporary workspace directory `docs\revit-cdci-obfuscation`.
