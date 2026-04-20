---
name: create-revit-installer
description: When a user wants to create an installer (.msi or .exe) for a Revit add-in. Do not use for non-Revit projects.
---

# Purpose
To create a professional software installer that automatically deploys a Revit add-in (`.addin` and `.dll` dependencies) to the correct `%AppData%\Autodesk\Revit\Addins\<Version>` directory on target computers.

# When to use
Whenever a user requests to build an installer, create an MSI, create an EXE, or "empaquetar" a Revit plugin for distribution. 

# Inputs
The agent needs:
- The path to the compiled Revit add-in source code.
- Knowledge of the user preferences (MSI via WiX toolset vs EXE via Inno Setup).
- Target Revit versions (e.g. 2024, or 2023+2024+2025).

# Workflow
1. **Clarify Requirements:** BEFORE generating any code, creating templates, or executing commands, YOU MUST ask the user:
   - "¿Quieres generar un archivo .msi (empleando la plantilla oficial de Nice3point WiX) o prefieres crear un instalador .exe (mediante Inno Setup script)?"
   - "¿Para qué versiones de Revit deseas que sea válido el instalador? (Pregunta por versiones específicas como 2024, o si desea que instale en todas las versiones detectadas)."
2. **Wait for user response.** (Do not proceed until you have this information).
3. **Compile the Add-in:** Ensure the add-in is compiled in `Release` mode for the chosen Revit versions.
4. **Implement Selected Installer Strategy:**
   - **If WiX (.msi):** Use the command `dotnet new wix` (provided by `Nice3point.Revit.Templates.Installer`) to generate the installer project structure. Configure the `<Wix>` XML properties to copy the output files into `[AppDataFolder]Autodesk\Revit\Addins\<Version>`.
   - **If Inno Setup (.exe):** Create an `installer.iss` script. Set the `DestDir` flag for your `[Files]` block to `{userappdata}\Autodesk\Revit\Addins\<Version>`. 
5. **Multi-version Multi-targeting:** If the user requested an installer for multiple versions of Revit, the scripts `.wxs` or `.iss` must reflect deploying files to each iteration of the folder (e.g., `Addins\2023`, `Addins\2024`, `Addins\2025`).
6. **Compile Installer:** Process the installer project (e.g., via `dotnet build` for WiX, or executing `iscc.exe` over the Inno Setup script) to generate the final file.

# Validation
- Ensure the output `.exe` or `.msi` file was actually successfully generated.
- Verify that the target directories inside the installer configuration strictly map to the Revit Add-In AppData paths.

# Common pitfalls
- Not copying the `.addin` file; without the `.addin` manifest at the root of `Addins\<Version>`, Revit will not load the plugin, even if the `.dll` is present via the installer.
- Hardcoding absolute paths instead of using `%AppData%` aliases (`[AppDataFolder]` in WiX or `{userappdata}` in InnoSetup).
