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
                // Attempt to place in the native "Modify" tab (Modificar in Spanish)
                // In Revit API, native tabs can sometimes be accessed by their internal string name
                panel = Application.CreatePanel("FilterPlus", "Modify");
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
        catch (Exception ex)
        {
            // Log the error but continue with fallback
            LoggerService.LogError("Ribbon Panel Creation", ex);
            panel = Application.CreatePanel("FilterPlus");
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