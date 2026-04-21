using Nice3point.Revit.Toolkit.External;
using KreanRenderLocal.Commands;
using JetBrains.Annotations;
using Nice3point.Revit.Extensions;
namespace KreanRenderLocal;

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
        var panel = Application.CreatePanel("Render Local", "DabaDev");

        panel.AddPushButton<StartupCommand>("Execute")
            .SetImage("/KreanRenderLocal;component/Resources/Icons/RibbonIcon16.png")
            .SetLargeImage("/KreanRenderLocal;component/Resources/Icons/RibbonIcon32.png");
    }
}
