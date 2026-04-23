using Nice3point.Revit.Toolkit.External;
using AIRender.Commands;
using JetBrains.Annotations;
using Nice3point.Revit.Extensions;
namespace AIRender;

/// <summary>
///     Application entry-point for AIRender
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
        var panel = Application.CreatePanel("AIRender", "DabaDev");

        panel.AddPushButton<StartupCommand>("AIRender")
            .SetImage("/AIRender;component/Resources/Icons/RibbonIcon16.png")
            .SetLargeImage("/AIRender;component/Resources/Icons/RibbonIcon32.png");
    }
}
