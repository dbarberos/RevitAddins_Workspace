---
name: revit-addin-obfuscation
description: Anti-tampering protection, Obfuscar configuration, MSBuild target integration, and automated CI/CD build scripts.
---

# Skill Manifest: Revit Add-in Obfuscation & Anti-Tampering (`revit-addin-obfuscation`)

## 1. Skill Identity & Purpose
* **ID:** SKILL-RVT-OBF
* **Domain:** Intellectual Property Protection, Assembly Obfuscation, MSBuild Targets, and CI/CD Automation.
* **Objective:** Automatically secure compiled Revit assemblies (DLLs) against reverse engineering (decompilation) during production builds, while guaranteeing that Revit API reflection and WPF/WebView2 string bindings are not broken.

## 2. Core Execution Guardrails
When executing tasks within this domain, the agent MUST strictly enforce these programmatic constraints:
1. **Reflection Compatibility:** Command entry points (`IExternalCommand`) and application starts (`IExternalApplication`) MUST be excluded from class/namespace renaming (either via `obfuscar.xml` rules or C# `[Obfuscation]` attributes).
2. **WPF Binding Protection:** Properties bound to WPF ViewModels MUST be kept intact. Property renaming on ViewModel classes must be disabled or excluded to prevent runtime binding failure.
3. **No Source Modification:** The obfuscator MUST NOT modify C# source files (`.cs`). It runs as a post-build step on compiled assemblies (`.dll`), outputting obfuscated binaries to replace the original compiler output.
4. **Configuration Selection:** Local deployment and build scripts MUST prompt the developer or check parameters to choose between **Production (Release + Obfuscated)** and **Development (Debug + PDB symbols)** to facilitate troubleshooting.

## 3. Reference Mapping (Theory & Ontologies)
Refer to the following guide in the `references/` directory for configuration:
* **Obfuscation Architecture & Exclusions:** [44_AntiTampering_and_Obfuscation.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-obfuscation/references/44_AntiTampering_and_Obfuscation.md)

## 4. Asset Mapping (Code Blueprints)
Inject, adapt, or copy the implementations located in the `assets/` directory:
* [obfuscar.xml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-obfuscation/assets/obfuscar.xml) -> The universal configuration file template specifying variables, optimization rules, and default skip filters.
* [Obfuscar.targets](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-obfuscation/assets/Obfuscar.targets) -> The custom MSBuild targets file that automatically installs `Obfuscar.GlobalTool` if missing, runs it, and replaces compiled binaries.
* [build-and-pack.ps1](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-obfuscation/assets/build-and-pack.ps1) -> The PowerShell orchestration script that prompts the developer for configuration, cleans folders, restores packages, builds, and outputs distributables.
