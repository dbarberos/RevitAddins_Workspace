# Technical Guide: Revit Private NuGet Feed & Caching

This reference document outlines the exact procedure to extract official Autodesk Revit DLLs, package them into custom private NuGet packages, configure a relative workspace package source, and manage version controls for secure, offline-capable Revit add-in development.

---

## 1. Official Revit DLL Extraction
Revit API assemblies are proprietary Autodesk binaries. In order to build your own NuGet packages:
1. Locate the installation folder of Autodesk Revit on your machine (e.g., `C:\Program Files\Autodesk\Revit 2024\`).
2. Copy the following critical binaries needed for add-in compilation:
   - **`RevitAPI.dll`**: Core database API elements.
   - **`RevitAPIUI.dll`**: User interface API commands, dialogs, and ribbon classes.
   - **`AdWindows.dll`**: Autodesk Windowing wrapper (required for UI extensions).
   - **`UIFramework.dll`**: Custom WPF extensions and controls (if applicable).
3. Do not modify or decompile these DLLs.

---

## 2. Directory Structure & Multi-Target Packaging
Revit versions target different .NET runtimes:
- **Revit 2019 - 2024**: Target `.NET Framework 4.8` (placed under `lib/net48` in the NuGet package).
- **Revit 2025+**: Target `.NET 8.0` (placed under `lib/net8.0` in the NuGet package).

To create a package that supports compilation for multiple Revit versions:
1. Create a workspace temporary folder (e.g. `TempPack/`).
2. Build the target directory structure inside:
   ```text
   TempPack/
   ├── RevitAPI.nuspec
   └── lib/
       ├── net48/
       │   ├── RevitAPI.dll
       │   ├── RevitAPIUI.dll
       │   └── AdWindows.dll
       └── net8.0/
           ├── RevitAPI.dll
           ├── RevitAPIUI.dll
           └── AdWindows.dll
   ```
3. Run `nuget pack RevitAPI.nuspec -OutputDirectory Output/` to generate the `.nupkg` package.

---

## 3. Registering the Local Workspace Feed
To avoid dependency on third-party public repositories (like NuGet.org or external Nice3point feeds), configure a relative local package feed inside your project repository:

1. Create a dedicated folder in your solution root: `ThirdParty/Packages/`.
2. Move the custom `.nupkg` files into this directory.
3. Create a `nuget.config` file in your solution root to instruct MSBuild to search this directory for dependencies:
   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <configuration>
     <packageSources>
       <!-- Keep official NuGet feed for generic tools -->
       <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
       <!-- Add local relative folder as feed -->
       <add key="LocalWorkspaceFeed" value="ThirdParty/Packages" />
     </packageSources>
   </configuration>
   ```

---

## 4. Strict Version Pinning
To prevent build drift and compile discrepancies across developer environments or CI/CD pipelines, always enforce explicit versioning:
- **Rule**: Never use wildcard version ranges (e.g., `<PackageReference Include="RevitAPI" Version="2024.*" />` or version ranges).
- **Correct Pattern**: Specify the exact target build and hotfix version:
  ```xml
  <PackageReference Include="RevitAPI" Version="2024.2.0" PrivateAssets="All" />
  <PackageReference Include="RevitAPIUI" Version="2024.2.0" PrivateAssets="All" />
  ```
- *Tip:* `PrivateAssets="All"` prevents these proprietary assemblies from being published or copied to the output build directory, keeping the deployment payload clean (since Revit already hosts these assemblies at runtime).

---

## 5. CI/CD Local Caching & Mirroring
When executing automated builds (e.g., GitHub Actions, GitLab CI, or Jenkins):
1. **Source Control Tracking**: Commit the `ThirdParty/Packages/` directory containing the proprietary `.nupkg` files directly to Git. Since these packages only contain compilation references, their sizes are small and acceptable for Git.
2. **CI Cache Configuration**: Configure your CI pipeline to cache the NuGet package restore folder (e.g., `~/.nuget/packages`) to speed up runs.
3. **Internal Mirror (Corporate Networks)**: For corporate environments, publish these packages to an internal private repository feed (such as Azure Artifacts, ProGet, or JFrog Artifactory) and register the source in `nuget.config`.

---

## 6. Hybrid Package Strategy
A robust architecture utilizes a hybrid approach:
1. **Core Assemblies (Private NuGet)**: Host proprietary Autodesk core binaries (`RevitAPI`, `RevitAPIUI`, `AdWindows`) in your private local feed.
2. **Utility & UI Frameworks (Public NuGet)**: You can safely reference public developer tools (e.g., Nice3point templates, `Nice3point.Revit.Toolkit`, or MVVM libraries) from `nuget.org` as long as their versions are strictly pinned. If these public libraries ever disappear, they can be easily replaced or compiled from source, while your proprietary core remains secure in your repository.
