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
        try
        {
            CreateRibbon();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("OnStartup Error: " + ex.Message);
        }
    }

    private void CreateRibbon()
    {
        try
        {
            var settings = SettingsService.Load();
            RibbonPanel? panel = null;

            string tabName = "DBDev";
            if (settings.SelectedTabOption == TabOption.RevitDefault)
            {
                tabName = "Modify";
            }
            else if (settings.SelectedTabOption == TabOption.Custom && !string.IsNullOrWhiteSpace(settings.CustomTabName))
            {
                tabName = settings.CustomTabName;
            }

            // Ensure custom tab exists in Revit ribbon
            if (!tabName.Equals("Modify", StringComparison.OrdinalIgnoreCase) &&
                !tabName.Equals("Add-Ins", StringComparison.OrdinalIgnoreCase) &&
                !tabName.Equals("AddIns", StringComparison.OrdinalIgnoreCase))
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

            try
            {
                panel = Application.CreatePanel("TransferPlus", tabName);
            }
            catch
            {
                try
                {
                    panel = Application.CreatePanel("TransferPlus");
                }
                catch
                {
                    // Fallback to Add-Ins tab
                }
            }

            if (panel != null)
            {
                panel.AddPushButton<CmdTransferPlus>("Transfer\nPlus")
                    .SetImage("/TransferPlus;component/Resources/Icons/TransferPlus16x16.png")
                    .SetLargeImage("/TransferPlus;component/Resources/Icons/TransferPlus32x32.png");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Ribbon Creation Error: " + ex.Message);
        }
    }
}