using Nice3point.Revit.Toolkit.External;
using PrimeraPrueba.Commands;
using JetBrains.Annotations;
using Nice3point.Revit.Extensions;
namespace PrimeraPrueba;

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
        var panel = Application.CreatePanel("Commands", "PrimeraPrueba");

        panel.AddPushButton<StartupCommand>("Execute")
            .SetImage("/PrimeraPrueba;component/Resources/Icons/RibbonIcon16.png")
            .SetLargeImage("/PrimeraPrueba;component/Resources/Icons/RibbonIcon32.png");
    }
}