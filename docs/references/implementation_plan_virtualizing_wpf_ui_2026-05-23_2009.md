# Installation of `virtualizing-wpf-ui` Skill

The requested skill has been fetched from the provided GitHub repository. The original skill is a monolithic `SKILL.md` file. To comply with this project's modular architecture (as defined in `AGENTS.md`) and token optimization (English content), I will restructure it into our standard layout.

## Proposed Changes

### `virtualizing-wpf-ui` Skill Folder

I will create a new skill directory: `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\virtualizing-wpf-ui\`

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\virtualizing-wpf-ui\SKILL.md`
This will serve as the index/prompt file. It will contain the frontmatter, a description of the skill's purpose (avoiding memory crashes in AECO massive data), and links to the references and assets.

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\virtualizing-wpf-ui\references\wpf_virtualization_guide.md`
This reference file will store the documentation extracted from the monolithic file:
- Quick Setup parameters.
- Key properties (`IsVirtualizing`, `VirtualizationMode`, etc.).
- Virtualization Breakers (what to avoid, like `ScrollViewer` wrappers).
- Deferred Scrolling tips.

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\virtualizing-wpf-ui\assets\VirtualizationHelpers.cs`
This asset file will store the C# diagnostic methods (`IsVirtualizing`, `GetRealizedCount`) and the `PrepareContainerForItemOverride` recycling snippet, so they can be injected directly into the user's code when needed.

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\virtualizing-wpf-ui\assets\VirtualizingDataGrid.xaml`
This asset file will store the XAML templates for `ListBox` and `DataGrid` virtualization, ready to be copied into the `Views/` folder of the add-ins.

#### [DELETE] `b:\REVIT\C#\RevitAddins_Workspace\tmp_clone`
After installing the skill, I will remove the temporary folder used for cloning the repository to keep the workspace clean.

## User Review Required
> [!IMPORTANT]
> Do you approve this structural breakdown? By splitting the monolithic `SKILL.md` into `references/` and `assets/`, we adhere to the project's standards and keep the agent's context clean and token-efficient. All content will remain in English as requested.
