# Build Architecture: WiX Toolset vs Visual Studio

This document explains how it is possible to create `.msi` files and compile C# projects without using Visual Studio, demystifying the IDE's role in the compilation and packaging process of Revit add-ins.

## 1. Visual Studio is an Interface (IDE), not a Compiler

Visual Studio acts as a graphical user interface (IDE) for underlying build engines (`MSBuild`, `.NET CLI`) and packaging tools (like `WiX Toolset`). When you press the "Build" button in Visual Studio, the graphical interface simply orchestrates the execution of console tools by passing them the parameters you have visually configured.

## 2. Compiling the C# Code (`dotnet publish`)

When you compile for multiple versions (2023 to 2027), Visual Studio reads your `.csproj` file and sends the instructions to **MSBuild** (or the modern **.NET CLI** interface). 
By running the `dotnet publish` command in the console and specifying the configuration (`Release.R23`, `Release.R24`, etc.), the command reads the `.csproj` and invokes the compiler (Roslyn). The result is the exact same `.dll` files you would get when building from Visual Studio.

## 3. MSI Creation via WiX Toolset

The `.msi` file is not a proprietary Visual Studio format, but a native Windows installer (Windows Installer). To build it from code, the **WiX Toolset** is used. 
When you install the WiX extension in Visual Studio, the interface simply creates a shortcut to invoke two programs that are already included in the WiX Toolset:

*   **Candle.exe** (The compiler): Reads the XML source code (`Product.wxs`) and transforms it into an object file (`.wixobj`).
*   **Light.exe** (The linker): Takes the `.wixobj`, collects the `.dll`s from the corresponding folders, compresses the files into an internal `.cab` format, and generates the final `.msi` file.

It is possible to run these tools directly from the console (for example, from `C:\Program Files (x86)\WiX Toolset v3.14\bin\`) obtaining the same `.msi` that Visual Studio would generate.

## 4. License, Uninstallation, and Repair Conditions

The installer's behavior is not configured in Visual Studio but resides entirely in the code of the `Product.wxs` file:

*   **License (EULA)**: Defined using WiX variables, such as `<WixVariable Id="WixUILicenseRtf" Value="Resources\License.rtf" />`. When passing through `light.exe`, WiX automatically injects the standard license screen (e.g., `WixUI_Minimal`).
*   **Uninstallation and Repair**: The rules for how the MSI uninstalls cleanly without leaving garbage (ICE64 and ICE38 rules) are coded in the `<RemoveFolder>` directives and the registry keys of your `.wxs`. Windows Installer reads this from the generated `.msi` and knows exactly what to do from the Windows Control Panel.
*   **Multi-version Compatibility**: The multiple Revit folders (2023, 2024...) are organized in the `ComponentGroup`s within the `.wxs`. When compiling it, WiX automatically packages the appropriate DLLs into the correct path.

## Summary and CI/CD

Dispensing with Visual Studio and using the command line is the technical foundation of **Continuous Integration (CI/CD)**. It is the industry-standard method (used on platforms like GitHub Actions or Azure DevOps) to automate the process so that, every time a change is pushed to the code, the final `.msi` is built flawlessly and ready for production, without requiring human intervention in a graphical interface.
