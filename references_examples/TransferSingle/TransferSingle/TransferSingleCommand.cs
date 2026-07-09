using System;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace TransferSingleApp
{
	// Token: 0x02000003 RID: 3
	[Transaction(1)]
	[Regeneration(0)]
	public class TransferSingleCommand : IExternalCommand
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000022FC File Offset: 0x000004FC
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			UIApplication application = commandData.Application;
			UIDocument activeUIDocument = commandData.Application.ActiveUIDocument;
			Document document = activeUIDocument.Document;
			try
			{
				if (new TransferSingle(document, activeUIDocument, application).ShowDialog() == DialogResult.Cancel)
				{
					return 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Se ha producido un error general en la aplicación:   " + ex.Message);
				return -1;
			}
			return 0;
		}
	}
}
