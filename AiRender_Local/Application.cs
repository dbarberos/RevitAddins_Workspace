using Nice3point.Revit.Toolkit.External;
using AiRenderLocal.Commands;
using JetBrains.Annotations;
using Nice3point.Revit.Extensions;
namespace AiRenderLocal;

/// <summary>
///     Application entry-point for AiRender Local
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
        var panel = Application.CreatePanel("AiRender Local", "DabaDev");

        panel.AddPushButton<StartupCommand>("AiRender\nLocal")
            .SetImage("/AiRenderLocal;component/Resources/Icons/RibbonIcon16.png")
            .SetLargeImage("/AiRenderLocal;component/Resources/Icons/RibbonIcon32.png");
    }
}
