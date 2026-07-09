# Research Notes: Anti-Tampering & Obfuscation in Revit Add-ins using Obfuscar

This guide details how to implement obfuscation in the CI/CD pipeline of Revit add-ins to prevent reverse engineering and protect proprietary business logic.

## 1. What is Obfuscar?
Obfuscar is an open-source, lightweight, and command-line utility for .NET assemblies obfuscation. It uses basic obfuscation rules:
- Renaming classes, methods, fields, and properties to unreadable characters.
- String encryption (optional, to hide hardcoded strings).
- Control flow obfuscation.

## 2. NuGet Integration
Instead of installing Obfuscar globally, it is highly recommended to reference it as a development dependency directly within the `.csproj` file. This ensures the build is portable and independent of machine configurations:

```xml
<ItemGroup>
    <PackageReference Include="Obfuscar" Version="2.2.50">
        <PrivateAssets>all</PrivateAssets>
        <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
</ItemGroup>
```

When this NuGet package is installed, it runs Obfuscar automatically as part of the MSBuild compilation pipeline (specifically after compiler outputs are generated) if a configuration file named `obfuscar.xml` is present in the project folder.

## 3. Revit API Modeless & Reflection Constraints (Mandatory Exclusions)
Revit add-ins rely heavily on **Reflection** and **string-based bindings**. If you obfuscate everything blindly, the add-in will crash or fail to load. You MUST exclude the following elements in your `obfuscar.xml`:

### A. IExternalCommand & IExternalApplication (Manifest Entrypoints)
Revit reads the `<FullClassName>` tag in your `.addin` manifest file to locate the entrypoint class. If the class name or its namespace is obfuscated, Revit will throw an "Add-in Load Failure" error.
- **Rule:** Exclude all namespaces/classes implementing `IExternalCommand` and `IExternalApplication` from renaming.

### B. WPF MVVM Binding Properties
WPF bindings in XAML files bind to properties using string names (e.g., `{Binding SelectedElement}`). If the properties in your ViewModel are renamed (e.g., from `SelectedElement` to `_a`), the binding will fail silently, and the UI will not work.
- **Rule:** Exclude ViewModel classes (or property names) from obfuscation.

### C. WebView2 JS-to-C# Interop Bridge
Any class registered as a host object in WebView2 (e.g., using `RegisterJsObject` or through WebMessage routers) interacts with JavaScript via reflection. Obfuscating their methods or property names will break the JS-C# communication interface.
- **Rule:** Exclude WebView2 routing classes from obfuscation.

## 4. Standard `obfuscar.xml` Template
Place this template at the root of your Add-in project:

```xml
<?xml version='1.0'?>
<Obfuscator>
  <Var name="InPath" value="." />
  <Var name="OutPath" value=".\Obfuscated" />
  <Var name="KeepPublicApi" value="false" />
  <Var name="HidePrivateApi" value="true" />
  <Var name="RenameProperties" value="true" />
  <Var name="RenameFields" value="true" />
  <Var name="EncryptStrings" value="true" />
  <Var name="OptimizeMethods" value="true" />
  
  <!-- Target Assemblies -->
  <Module file="$(TargetFileName)">
    <!-- Keep Revit Entrypoints Intact -->
    <SkipNamespace name="RevitAddinBase.Commands" />
    <SkipClass name="RevitAddinBase.Application" />
    
    <!-- Keep ViewModels Intact for WPF Binding -->
    <SkipNamespace name="RevitAddinBase.ViewModels" />
  </Module>
</Obfuscator>
```

## 5. Automation in CI/CD Pipelines
By checking the build configuration, we can configure MSBuild to execute obfuscation exclusively during `Release` builds (so developer builds in `Debug` remain clean for debugging):

```xml
<Target Name="ObfuscateRelease" AfterTargets="AfterBuild" Condition="'$(Configuration)' == 'Release'">
  <Message Text="Running Obfuscar on compiled binaries..." Importance="High" />
  <Obfuscar.MSBuild.ObfuscateTask ProjectPath="$(ProjectDir)obfuscar.xml" />
</Target>
```
