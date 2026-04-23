using Nice3point.Revit.Toolkit.External;
using FilterPlus.Commands;
using JetBrains.Annotations;
using Nice3point.Revit.Extensions;
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
        var panel = Application.CreatePanel("FilterPlus", "DabaDev");

        panel.AddPushButton<StartupCommand>("FilterPlus")
            .SetImage("/FilterPlus;component/Resources/Icons/RibbonIcon16.png")
            .SetLargeImage("/FilterPlus;component/Resources/Icons/RibbonIcon32.png");
    }
}