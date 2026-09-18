using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Nice3point.Revit.Toolkit.External;
using TransferPlus.ViewModels;
using TransferPlus.Views;

namespace TransferPlus.Commands;

[Transaction(TransactionMode.Manual)]
public class CmdTransferPlus : ExternalCommand
{
    public override void Execute()
    {
        var viewModel = new TransferPlusViewModel(Application, Application.ActiveUIDocument.Document);
        var view = new TransferPlusView(viewModel);

        if (Application.MainWindowHandle != System.IntPtr.Zero)
        {
            new System.Windows.Interop.WindowInteropHelper(view).Owner = Application.MainWindowHandle;
        }

        view.ShowDialog();
    }
}
