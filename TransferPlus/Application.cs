using System;
using Autodesk.Revit.UI;
using Nice3point.Revit.Toolkit.External;
using TransferPlus.Commands;
using TransferPlus.Services;
using TransferPlus.Models;

namespace TransferPlus;

/// <summary>
///     Application entry point
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
        
        RibbonPanel panel = null;

        try
        {
            if (settings.SelectedTabOption == TabOption.RevitDefault)
            {
                panel = Application.CreatePanel("TransferPlus", "Modify");
            }
            else if (settings.SelectedTabOption == TabOption.Custom && !string.IsNullOrWhiteSpace(settings.CustomTabName))
            {
                panel = Application.CreatePanel("TransferPlus", settings.CustomTabName);
            }
            else
            {
                // DBDevDefault
                panel = Application.CreatePanel("TransferPlus", "DBDev");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Ribbon Panel Creation Error: " + ex.Message);
            panel = Application.CreatePanel("TransferPlus");
        }

        if (panel != null)
        {
            panel.AddPushButton<CmdTransferPlus>("Transfer\nPlus")
                .SetImage("/TransferPlus;component/Resources/Icons/TransferPlus16x16.png")
                .SetLargeImage("/TransferPlus;component/Resources/Icons/TransferPlus32x32.png");
        }
    }
}