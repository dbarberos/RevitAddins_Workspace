# Skill: Build Automation, Multi-Targeting and Corporate Deployment (DevOps for Revit)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-015
* **Technical Area:** DevOps / CI-CD / Build Automation / Release Management
* **API dependencies:** `MSBuild`, `.csproj` (XML structure), `Post-Build Events`
* **Design Patterns:** Shared Projects, Preprocessor Directives (`#if REVIT2024`)
* **Operational Impact:** Critical for scalability. Reduces human error during installation to zero and allows you to maintain a single code base for multiple annual versions of Revit.

---

## 2. The Fragmentation Problem (Multi-Version)

Autodesk releases a new version of Revit every year, and each version updates its base dependencies (for example, Revit 2024 requires `.NET 8/Core`, while Revit 2021 to 2023 use `.NET Framework 4.8`). Additionally, the native API suffers from constant deprecations (old methods are removed and new ones added).

### Common Anti-Pattern (Unsustainable Maintenance)
* Developer copies and pastes the entire project to create "MiAddin_2022", "MiAddin_2023", etc.
* If a bug is found in a tool, the developer has to open 4 different projects, fix the code 4 times and compile 4 times. This breaks the DRY (Don't Repeat Yourself) principle.

---

## 3. Multi-Targeting Architecture (One code, multiple outputs)

The corporate solution is to modify the project file (`.csproj`) so that the C# compiler understands to generate multiple `.dll` files from a single source code.

### A. Preprocessor Directives
When the Revit API changes between versions, logical directives within the C# code are used to isolate execution.

```csharp
public double ConvertUnits(double value)
{
#if REVIT2021
    // Legacy code for Revit 2021 using the old enumerator
    return UnitUtils.ConvertFromInternalUnits(value, DisplayUnitType.DUT_METERS);
#else
    // Modern code for Revit 2022+ using ForgeTypeId
    return UnitUtils.ConvertFromInternalUnits(value, UnitTypeId.Meters);
#endif
}
B. MSBuild Configuration
In advanced architectures, the agent must know how to configure the core project so that the reference libraries (RevitAPI.dll) change dynamically according to the build configuration selected in the IDE.
4. Workflow Automation (Post-Build Events)
During the development phase, testing an Add-in requires that the .dll and .addin be in the Revit Add-ons folder (%AppData%\Autodesk\Revit\Addins\[Version]).
Doing this manually on each test is inefficient. The agent should inject MSBuild scripts into the "Post-Build Events" to automate the handoff.
Optimized Script (Example for .csproj):
TWO
:: This script automatically copies the binaries to the system folder after compiling
echo "Starting local deployment..."
set AddinFolder="%AppData%\Autodesk\Revit\Addins\2024"

:: Create directory if it does not exist
if not exist %AddinFolder% mkdir %AddinFolder%

:: Copy Manifest
xcopy "$(ProjectDir)Manifest\MyAddin.addin" %AddinFolder% /y

:: Copy Compiled Library
xcopy "$(TargetDir)$(TargetFileName)" %AddinFolder% /y
5. Packaging and Distribution (Installers)
To distribute the tool to hundreds of architects and engineers at an AECO consultancy, the final product is not a .dll, but a .exe or .msi executable.
The industry standard requires the use of packaging tools (such as Inno Setup or WiX Toolset) that silently perform the following operations:
Detect which versions of Revit are installed on the client machine by reading the Windows Registry (RegEdit).
Copy the correct .dlls to the global paths (%ProgramData%\Autodesk\Revit\Addins\).
* Detect which versions of Revit are installed on the client machine by reading the Windows Registry (RegEdit).
* Copy the correct .dlls to the global paths (%ProgramData%\Autodesk\Revit\Addins\).
* Delete old versions if they exist.

## 6. Agent Injection Instructions (Prompting Prompt)
When you are assigned the task of structuring the deployment of an Add-in or managing code for different versions of Revit, you must apply these rules:
* **Strict Conditional Directives:** If you inject code that contains methods marked [Obsolete] into modern versions of Revit, you MUST surround that block with #if REVIT[YEAR] / #else / #endif directives and provide the corresponding modern alternative in the else block.
* **No Manual Intervention:** Configures project instructions so that the local environment is automatically updated using Post-Build events. The developer should not move .addin files manually at any point in the development lifecycle.
* **Prohibition of Copy Local (Copy Local = False):** Always verify that in the generated build documentation, the main Autodesk dependencies (RevitAPI.dll, RevitAPIUI.dll, AdWindows.dll) have the instruction not to be copied to the output directory to avoid bulking up the final installer and causing memory collisions.
* **Agonistic Paths:** When generating folder automation scripts, never use absolute paths burned into the code (like C:\Users\Juan\AppData...). Always use system environment variables (%AppData%, %ProgramData%) or compiler macro variables ($(TargetDir)).
* **Debug Log Window Handling (CI/CD):** During Development/Debug builds, any code displaying debug log windows (e.g. `_logView.Show()`) MUST remain active and uncommented to aid diagnostics. However, during Production/Release builds, the automated CI/CD pipeline or pre-compilation routine must comment out/exclude these log-showing lines (or wrap them in `#if DEBUG` preprocessor directives) to ensure end-users never see debug interfaces.