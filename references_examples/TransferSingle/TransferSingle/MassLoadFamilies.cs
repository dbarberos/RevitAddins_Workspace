using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace TransferSingleApp
{
	// Token: 0x0200000E RID: 14
	[Regeneration(0)]
	[Transaction(1)]
	public class MassLoadFamilies : IExternalCommand, IFamilyLoadOptions
	{
		// Token: 0x06000082 RID: 130 RVA: 0x00006A80 File Offset: 0x00004C80
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			UIApplication application = commandData.Application;
			UIDocument activeUIDocument = application.ActiveUIDocument;
			Application application2 = application.Application;
			Document document = activeUIDocument.Document;
			FormLoad formLoad = new FormLoad();
			formLoad.ShowDialog();
			if (formLoad.Cancelado)
			{
				return 1;
			}
			int max = 0;
			int num = 0;
			int num2 = 0;
			string directorio = FormLoad.Directorio;
			if (!new DirectoryInfo(directorio).Exists)
			{
				TaskDialog.Show("Error", "No such directory.");
				return 1;
			}
			if (formLoad.treeView1.Nodes.Count == 0)
			{
				TaskDialog.Show("Error", "There are no families listed.");
				return 1;
			}
			this.ListaFam = new List<string>();
			this.AddChildrenTag(formLoad.treeView1.Nodes[0]);
			if (this.ListaFam.Count == 0)
			{
				TaskDialog.Show("Error", "There are no families in that directory.");
				return 1;
			}
			max = this.ListaFam.Count;
			BarraDeProgresoLineal barraDeProgresoLineal = new BarraDeProgresoLineal();
			barraDeProgresoLineal.Show();
			barraDeProgresoLineal.FijaBarra(0, max);
			int num3 = 0;
			Family family = null;
			foreach (string text in this.ListaFam)
			{
				num3++;
				barraDeProgresoLineal.progreso.PerformStep();
				barraDeProgresoLineal.textobarra.Text = string.Concat(new string[]
				{
					"Processing ",
					num3.ToString(),
					" of ",
					max.ToString(),
					"  Loaded (",
					num.ToString(),
					")  Errors (",
					num2.ToString(),
					")"
				});
				barraDeProgresoLineal.Refresh();
				Application.DoEvents();
				if (barraDeProgresoLineal.cancelado)
				{
					break;
				}
				Transaction transaction = new Transaction(document);
				FailureHandlingOptions failureHandlingOptions = transaction.GetFailureHandlingOptions();
				FailurePreproccessor failuresPreprocessor = new FailurePreproccessor();
				failureHandlingOptions.SetFailuresPreprocessor(failuresPreprocessor);
				transaction.SetFailureHandlingOptions(failureHandlingOptions);
				transaction.Start("Loading");
				new Transaction(document);
				try
				{
					document.LoadFamily(text, this, ref family);
					num++;
				}
				catch (Exception ex)
				{
					num2++;
					if (formLoad.logerror.Checked)
					{
						this.LogError(text + " there was an error " + ex.ToString(), directorio);
					}
				}
				transaction.Commit();
				transaction.Dispose();
			}
			barraDeProgresoLineal.Hide();
			TaskDialog.Show("Families Loaded", string.Concat(new string[]
			{
				"Selected Families: ",
				max.ToString(),
				"\nFamilies Loaded: ",
				num.ToString(),
				"\nErrors: ",
				num2.ToString()
			}));
			return 0;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00006D60 File Offset: 0x00004F60
		private void LogError(string error, string dir)
		{
			string path = dir + "\\log_LoadFamilies.txt";
			StreamWriter streamWriter;
			if (!File.Exists(path))
			{
				streamWriter = new StreamWriter(path);
			}
			else
			{
				streamWriter = File.AppendText(path);
			}
			DateTime dateTime = default(DateTime);
			dateTime = DateTime.Now;
			string format = "yyyyMMddHHmm";
			streamWriter.WriteLine("-----------------------------------------------------");
			streamWriter.WriteLine("log: " + dateTime.ToString(format));
			streamWriter.WriteLine(error);
			streamWriter.Close();
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00006DD5 File Offset: 0x00004FD5
		public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
		{
			overwriteParameterValues = true;
			return true;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00006DDB File Offset: 0x00004FDB
		public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
		{
			source = 1;
			overwriteParameterValues = true;
			return true;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00006DE8 File Offset: 0x00004FE8
		private void AddChildrenTag(TreeNode rootNode)
		{
			foreach (object obj in rootNode.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				this.AddChildrenTag(treeNode);
				if (treeNode.Tag != null && treeNode.Checked)
				{
					object tag = treeNode.Tag;
					if (tag is string || tag is string)
					{
						this.ListaFam.Add((string)tag);
					}
				}
			}
		}

		// Token: 0x04000069 RID: 105
		private IList<string> ListaFam = new List<string>();
	}
}
