## ✅ `.csproj` Project Templates

### .NET Framework 4.8 (Revit ≤ 2024)

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net48</TargetFramework>
    <LangVersion>12</LangVersion>
    <ImplicitUsings>enable</ImplicitUsings>
    <UseWPF>true</UseWPF>
    <Configurations>Debug;Release</Configurations>
    <Version>1.0.0</Version>
    <AssemblyName>{{Name}}</AssemblyName>
    <RootNamespace>{{Name}}</RootNamespace>
  </PropertyGroup>

  <ItemGroup>
    <!-- Revit API References - adjust path according to local installation -->
    <Reference Include="RevitAPI">
      <HintPath>$(ProgramW6432)\Autodesk\Revit 2024\RevitAPI.dll</HintPath>
      <Private>false</Private>
    </Reference>
    <Reference Include="RevitAPIUI">
      <HintPath>$(ProgramW6432)\Autodesk\Revit 2024\RevitAPIUI.dll</HintPath>
      <Private>false</Private>
    </Reference>
  </ItemGroup>

  <!-- Nice3point Toolkit (recommended) -->
  <ItemGroup>
    <PackageReference Include="Nice3point.Revit.Toolkit" Version="2024.*" />
    <PackageReference Include="Nice3point.Revit.Extensions" Version="2024.*" />
    <PackageReference Include="Nice3point.Revit.Api.RevitAPI" Version="2024.*" />
    <PackageReference Include="Nice3point.Revit.Api.RevitAPIUI" Version="2024.*" />
  </ItemGroup>
</Project>
```

> **⚠️ Note:** If you use the Nice3point NuGet packages (`Nice3point.Revit.Api.RevitAPI`), the manual references to `RevitAPI.dll` **are not necessary**. Use one or the other, never both.

### .NET 8 (Revit 2025+)

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0-windows</TargetFramework>
    <LangVersion>12</LangVersion>
    <ImplicitUsings>enable</ImplicitUsings>
    <UseWPF>true</UseWPF>
    <EnableDynamicLoading>true</EnableDynamicLoading>
    <Version>1.0.0</Version>
    <AssemblyName>{{Name}}</AssemblyName>
    <RootNamespace>{{Name}}</RootNamespace>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Nice3point.Revit.Toolkit" Version="2025.*" />
    <PackageReference Include="Nice3point.Revit.Extensions" Version="2025.*" />
    <PackageReference Include="Nice3point.Revit.Api.RevitAPI" Version="2025.*" />
    <PackageReference Include="Nice3point.Revit.Api.RevitAPIUI" Version="2025.*" />
  </ItemGroup>
</Project>
```

### Critical `.csproj` Properties

| Property | Mandatory Value | Reason |
|-----------|------------------|--------|
| `ImplicitUsings` | `enable` | Injects global Revit/Nice3point namespaces |
| `LangVersion` | `12` | Enables Primary Constructors, records, etc. |
| `UseWPF` | `true` | Required for `pack://application` and WPF controls |
| `Private` (in References) | `false` | Prevents copying Revit DLLs to output (they are already in the GAC) |
| `EnableDynamicLoading` | `true` (only .NET 8) | Required for Revit to load the assembly correctly |

---
