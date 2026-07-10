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
        var panel = Application.CreatePanel("TransferPlus", "DBDev");

        panel.AddPushButton<CmdTransferPlus>("Transfer\nPlus")
            .SetImage("/TransferPlus;component/Resources/Icons/TransferPlus16x16.png")
            .SetLargeImage("/TransferPlus;component/Resources/Icons/TransferPlus32x32.png");
    }
}