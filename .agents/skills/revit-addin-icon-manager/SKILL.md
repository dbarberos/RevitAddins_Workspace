---
name: revit-addin-icon-manager
description: Automates the replacement of default icons in Revit projects with custom images, managing .csproj resources and C# code injection. Use this when you need to update or configure Ribbon UI icons for a Revit add-in.
---

# Revit Add-in Icon Manager (v2.0)

This skill automates the integration of custom icons into Revit add-ins, managing everything from file preparation to `.csproj` modification and C# code refactoring to ensure correct display (including support for DPI and Dark Themes).

## When to use
- When preparing a Revit add-in for final compilation or distribution.
- When you want to change the visual branding of the Ribbon without repetitive manual edits.

## 🟢 1. Active Diagnostics (Minimal Interaction)
Before asking the user, the agent **MUST** try to autonomously discover:
1.  **Project Path:** Locate the `.csproj` file and the `IExternalApplication` class (usually `App.cs` or `Application.cs`).
2.  **Revit Version:** Extract it from the `.csproj` or API references to adjust advice on Dark Themes (Revit 2024+).
3.  **Icon Sources:** Look for `/icons` or `/assets` folders in the root.
4.  **Existing Buttons:** Analyze the code to identify which buttons need new icons.

*Only if there is critical ambiguity (e.g., multiple projects or multiple images with unclear names), the agent will request clarification.*

## 🛠 2. Technical Execution Procedure

### Step A: Image Management
- **Destination Folder:** Ensure the existence of `Resources/Icons/` within the project.
- **Mapping by Size:** 
    - Image of ~32px or with "32" in the name -> `LargeImage`.
    - Image of ~16px or with "16" in the name -> `Image`.
- **Overwriting:** Prefer overwriting the template files (`RibbonIcon32.png`) to avoid unnecessary code changes, unless the user prefers specific names.

### Step B: Project Modification (.csproj)
Ensure the icons are included as a **Resource** (required for the `pack://application` scheme in WPF):
```xml
<ItemGroup>
  <Resource Include="Resources\Icons\YourIcon32.png" />
  <Resource Include="Resources\Icons\YourIcon16.png" />
</ItemGroup>
```

### Step C: Code Refactoring (C#)
1. **Utility Injection:** If it does not exist, add the method to load resources in the application class:
```csharp
private System.Windows.Media.ImageSource GetImageSource(string resourceName)
{
    try
    {
        string assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        // The "pack://application" format is vital for resource resolution in Revit/WPF
        Uri uri = new Uri($"pack://application:,,,/{assemblyName};component/Resources/Icons/{resourceName}");
        return new System.Windows.Media.Imaging.BitmapImage(uri);
    }
    catch { return null; }
}
```
2. **Binding:** Update the `PushButtonData` properties:
   - `button.LargeImage = GetImageSource("YourIcon32.png");`
   - `button.Image = GetImageSource("YourIcon16.png");`

## 🤖 3. Agent Behavior Rules
- **Full Autonomy:** If the agent has access to the file system, it must make changes in the `.csproj` and `.cs` proactively.
- **Generation Support:** If the user has no icons, the agent must offer to generate them (using `generate_image`) respecting Revit standards.
- **Test Build:** Always finish by running `dotnet build` to ensure the `AssemblyName` and resource paths match.

## 📋 4. Exit Checklist
- [ ] Icons copied to `/Resources/Icons/`.
- [ ] `.csproj` configured with `Resource Include`.
- [ ] `GetImageSource` method functional and injected.
- [ ] `.Image` and `.LargeImage` properties correctly assigned.
- [ ] The project compiles successfully.