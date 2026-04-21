using Nice3point.Revit.Toolkit.External;
using KreanRender.Commands;
using JetBrains.Annotations;
using Nice3point.Revit.Extensions;
namespace KreanRender;

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
        var panel = Application.CreatePanel("Commands", "KreanRender");

        panel.AddPushButton<StartupCommand>("Execute")
            .SetImage("/KreanRender;component/Resources/Icons/RibbonIcon16.png")
            .SetLargeImage("/KreanRender;component/Resources/Icons/RibbonIcon32.png");
    }
}
