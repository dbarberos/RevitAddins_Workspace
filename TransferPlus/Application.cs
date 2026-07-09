using Nice3point.Revit.Toolkit.External;
using TransferPlus.Commands;

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
        var panel = Application.CreatePanel("Commands", "TransferPlus");

        panel.AddPushButton<CmdTransferPlus>("Transfer\nPlus")
            .SetImage("/TransferPlus;component/Resources/Icons/RibbonIcon16.png")
            .SetLargeImage("/TransferPlus;component/Resources/Icons/RibbonIcon32.png");
    }
}