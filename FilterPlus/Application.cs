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
        CreateRibbon();
    }

    private void CreateRibbon()
    {
        var settings = SettingsService.Load();
        
        Autodesk.Revit.UI.RibbonPanel panel = null;

        try
        {
            if (settings.SelectedTabOption == TabOption.RevitDefault)
            {
<<<<<<< HEAD
                // Tab.AddIns (Revit Default Tab for plugins)
                panel = Application.CreatePanel("FilterPlus");
=======
                // Tab.Modify
                panel = Application.CreatePanel("FilterPlus", Autodesk.Revit.UI.Tab.Modify);
>>>>>>> c52b3d4 (Instalación de Visual Studio)
            }
            else if (settings.SelectedTabOption == TabOption.Custom && !string.IsNullOrWhiteSpace(settings.CustomTabName))
            {
                panel = Application.CreatePanel("FilterPlus", settings.CustomTabName);
            }
            else
            {
                // DBDevDefault
                panel = Application.CreatePanel("FilterPlus", "DBDev");
            }
        }
        catch
        {
            // Fallback just in case
            panel = Application.CreatePanel("FilterPlus", "DBDev");
        }

        if (panel != null)
        {
            panel.AddPushButton<StartupCommand>("FilterPlus")
                .SetImage("/FilterPlus;component/Resources/Icons/RibbonIcon16.png")
                .SetLargeImage("/FilterPlus;component/Resources/Icons/RibbonIcon32.png");
        }

#if REVIT2025_OR_GREATER
        if (settings.UseAsContextualFilter)
        {
            // Register context menu creator for Revit 2025+
            try
            {
<<<<<<< HEAD
                this.Application.RegisterContextMenu(new FilterContextMenuCreator());
=======
                // UIControlledApplication is accessible via Application property in Nice3point ExternalApplication
                Application.RegisterContextMenu(new FilterContextMenuCreator());
>>>>>>> c52b3d4 (Instalación de Visual Studio)
            }
            catch (Exception ex)
            {
                // Log or handle error if registration fails
            }
        }
#endif
    }
}