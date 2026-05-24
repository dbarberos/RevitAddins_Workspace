# Installation of `integrating-wpfui-fluent` Skill

The requested skill has been cloned. The original document contains a monolithic guide with mixed Korean and English text for setting up WPF-UI (Wpf.Ui) for Fluent Design in WPF apps. I will translate everything into English and split the content into the `assets/` and `references/` modular architecture.

## Proposed Changes

### `integrating-wpfui-fluent` Skill Folder

I will create a new skill directory: `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\integrating-wpfui-fluent\`

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\integrating-wpfui-fluent\SKILL.md`
This file will contain the YAML frontmatter, the purpose of the skill (building modern UIs with WPF-UI, `FluentWindow`, `NavigationView`), and links to its references and assets.

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\integrating-wpfui-fluent\references\fluent_integration_guide.md`
This guide will contain the theoretical breakdown, translated into English:
- Key rules for WPF-UI (`FluentWindow` usage, GenericHost DI registration, `INavigableView` interfaces).
- Instructions for Navigation, Snackbar, ContentDialog, and Theme management.

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\integrating-wpfui-fluent\assets\FluentSetupTemplates.cs`
I will bundle the C# snippets (GenericHost DI setup, `MainWindow.xaml.cs`, and `HomePage` navigation setup) into this asset file so the agent can easily copy-paste the boilerplate code when scaffolding a new modern window.

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\integrating-wpfui-fluent\assets\FluentSetupTemplates.xaml`
I will bundle the XAML setup templates (`App.xaml` merged dictionaries, `MainWindow.xaml` with `ui:TitleBar` and `ui:NavigationView`) into this asset file.

#### [DELETE] `b:\REVIT\C#\RevitAddins_Workspace\tmp_clone`
I will delete the temporary cloned repository folder after completing the installation.

## User Review Required
> [!IMPORTANT]
> Do you approve this structural breakdown? I will translate the Korean text to English to optimize tokens and ensure the agent only reads code templates from `assets/` and instructions from `references/`.
