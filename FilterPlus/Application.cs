using Autodesk.Revit.UI;
using Nice3point.Revit.Toolkit.External;
using FilterPlus.Commands;
using FilterPlus.Services;
using FilterPlus.Models;
using JetBrains.Annotations;
using Nice3point.Revit.Extensions;
using System;

namespace FilterPlus;

/// <summary>
///     Application entry point for FilterPlus
/// </summary>
[UsedImplicitly]
public class Application : ExternalApplication
{
    public override void OnStartup()
    {
        AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
        try
        {
            CreateRibbon();
        }
        catch (Exception ex)
        {
            LoggerService.LogError("OnStartup Error creating ribbon", ex);
        }
    }

    private static System.Reflection.Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
    {
        try
        {
            string assemblyName = new System.Reflection.AssemblyName(args.Name).Name + ".dll";
            string folderPath = System.IO.Path.GetDirectoryName(typeof(Application).Assembly.Location) ?? string.Empty;
            string assemblyPath = System.IO.Path.Combine(folderPath, assemblyName);

            if (System.IO.File.Exists(assemblyPath))
            {
                return System.Reflection.Assembly.LoadFrom(assemblyPath);
            }
        }
        catch
        {
            // Ignore assembly resolve errors
        }
        return null;
    }

    private void CreateRibbon()
    {
        var settings = SettingsService.Load();
        
        Autodesk.Revit.UI.RibbonPanel panel = null;

        try
        {
            if (settings.SelectedTabOption == TabOption.RevitDefault)
            {
                // Attempt to place in the native "Modify" tab (Modificar in Spanish)
                // In Revit API, native tabs can sometimes be accessed by their internal string name
                panel = Application.CreatePanel("FilterPlus", "Modify");
            }
            else if (settings.SelectedTabOption == TabOption.Custom && !string.IsNullOrWhiteSpace(settings.CustomTabName))
            {
                string tabName = settings.CustomTabName;
                if (!tabName.Equals("Modify", StringComparison.OrdinalIgnoreCase) &&
                    !tabName.Equals("Add-Ins", StringComparison.OrdinalIgnoreCase) &&
                    !tabName.Equals("AddIns", StringComparison.OrdinalIgnoreCase) &&
                    !tabName.Equals("Manage", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        Application.CreateRibbonTab(tabName);
                    }
                    catch
                    {
                        // Tab already exists in current Revit session
                    }
                }

                panel = Application.CreatePanel("FilterPlus", tabName);
            }
            else
            {
                // AddInsDefaultTab: Place in native "Add-Ins" tab (Complementos)
                panel = Application.CreatePanel("FilterPlus");
            }
        }
        catch (Exception ex)
        {
            // Log the error but continue with fallback
            LoggerService.LogError("Ribbon Panel Creation", ex);
            panel = Application.CreatePanel("FilterPlus");
        }

        if (panel != null)
        {
            var pushButton = panel.AddPushButton<StartupCommand>("FilterPlus");
            pushButton.SetImage("/FilterPlus;component/Resources/Icons/RibbonIcon16.png");
            pushButton.SetLargeImage("/FilterPlus;component/Resources/Icons/RibbonIcon32.png");
            pushButton.ToolTip = "FilterPlus Hierarchical Explorer";
            pushButton.LongDescription = "Advanced selection and filtering add-in for Revit. Allows asynchronous collection of elements, visualizing them in a Category/Family/Type/Instance tree, and refining selections through dynamic rules without freezing the UI.";

            string assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            string helpPath = System.IO.Path.Combine(assemblyDir, "Resources", "help.html");
            if (!System.IO.File.Exists(helpPath))
            {
                string helpCapitalized = System.IO.Path.Combine(assemblyDir, "Resources", "Help.html");
                if (System.IO.File.Exists(helpCapitalized))
                {
                    helpPath = helpCapitalized;
                }
                else
                {
                    string bundleRootHelp = System.IO.Path.GetFullPath(System.IO.Path.Combine(assemblyDir, "..", "Resources", "help.html"));
                    string bundleRootHelpCap = System.IO.Path.GetFullPath(System.IO.Path.Combine(assemblyDir, "..", "Resources", "Help.html"));
                    string singularResource = System.IO.Path.Combine(assemblyDir, "Resource", "help.html");
                    if (System.IO.File.Exists(bundleRootHelp))
                    {
                        helpPath = bundleRootHelp;
                    }
                    else if (System.IO.File.Exists(bundleRootHelpCap))
                    {
                        helpPath = bundleRootHelpCap;
                    }
                    else if (System.IO.File.Exists(singularResource))
                    {
                        helpPath = singularResource;
                    }
                }
            }
            ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, helpPath);
            pushButton.SetContextualHelp(contextHelp);
        }

#if REVIT2025_OR_GREATER
        if (settings.UseAsContextualFilter)
        {
            try
            {
                // In Revit 2025, RegisterContextMenu requires a name and the creator
                this.Application.RegisterContextMenu("FilterPlus", new FilterContextMenuCreator());
            }
            catch (Exception ex)
            {
                LoggerService.LogError("Context Menu Registration", ex);
            }
        }
#endif
    }
}