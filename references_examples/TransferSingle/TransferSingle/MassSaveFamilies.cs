using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace TransferSingleApp
{
	// Token: 0x02000011 RID: 17
	[Regeneration(0)]
	[Transaction(1)]
	public class MassSaveFamilies : IExternalCommand
	{
		// Token: 0x0600008D RID: 141 RVA: 0x00006FEC File Offset: 0x000051EC
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			UIApplication application = commandData.Application;
			UIDocument activeUIDocument = application.ActiveUIDocument;
			Application application2 = application.Application;
			Document document = activeUIDocument.Document;
			new List<FamilySymbol>();
			formgeneral formgeneral = new formgeneral();
			this.AllFamilyByCategoryToTree(document, formgeneral.treeView1);
			if (BarraDeProgreso.cancelado)
			{
				return 1;
			}
			formgeneral.treeView1.Sort();
			formgeneral.ShowDialog();
			if (formgeneral.Cancelado)
			{
				return 1;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			BarraDeProgresoLineal barraDeProgresoLineal = new BarraDeProgresoLineal();
			barraDeProgresoLineal.Show();
			IList<TreeNode> list = new List<TreeNode>();
			foreach (object obj in formgeneral.treeView1.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				list.Add(treeNode);
				foreach (object obj2 in treeNode.Nodes)
				{
					TreeNode treeNode2 = (TreeNode)obj2;
					list.Add(treeNode2);
					foreach (object obj3 in treeNode2.Nodes)
					{
						TreeNode item = (TreeNode)obj3;
						list.Add(item);
					}
				}
			}
			int num4 = 0;
			foreach (TreeNode treeNode3 in list)
			{
				if (treeNode3.Tag != null && treeNode3.Checked)
				{
					num4++;
				}
			}
			barraDeProgresoLineal.FijaBarra(0, num4);
			foreach (TreeNode treeNode4 in list)
			{
				barraDeProgresoLineal.textobarra.Text = string.Concat(new string[]
				{
					"Processing ",
					num.ToString(),
					" of ",
					num4.ToString(),
					" Saved (",
					num2.ToString(),
					") Errors (",
					num3.ToString(),
					")"
				});
				barraDeProgresoLineal.Refresh();
				Application.DoEvents();
				if (barraDeProgresoLineal.cancelado)
				{
					break;
				}
				if (treeNode4.Tag != null && treeNode4.Checked)
				{
					barraDeProgresoLineal.progreso.PerformStep();
					num++;
					Family family = treeNode4.Tag as Family;
					if (family != null)
					{
						string text = family.Name.ToString();
						string text2 = formgeneral.Directorio;
						string text3 = family.FamilyCategory.Name.ToString();
						if (formgeneral.tofolders.Checked)
						{
							if (this.EsSimbolo(family))
							{
								text2 = text2 + "\\Annotation Symbols\\" + text3 + "\\";
							}
							else if (this.EsEstructura(family))
							{
								text2 = text2 + "\\Structural\\" + text3 + "\\";
							}
							else
							{
								text2 = text2 + "\\" + text3 + "\\";
							}
						}
						else
						{
							text2 += "\\";
						}
						if (formgeneral.addcat.Checked)
						{
							if (this.EsSimbolo(family))
							{
								text = "(Annotation Symbols)" + text;
							}
							else if (this.EsEstructura(family))
							{
								text = "(Structural)" + text;
							}
							else
							{
								text = "(" + text3 + ")" + text;
							}
						}
						DirectoryInfo directoryInfo = new DirectoryInfo(text2);
						if (!directoryInfo.Exists)
						{
							directoryInfo.Create();
						}
						try
						{
							string text4 = text2 + text + ".rfa";
							FileInfo fileInfo = new FileInfo(text4);
							if (fileInfo.Exists && formgeneral.ignorar.Checked)
							{
								num3++;
								if (formgeneral.logerror.Checked)
								{
									this.LogError(family.Name.ToString() + " file aready exists. Family Ignored.");
								}
							}
							else
							{
								if (fileInfo.Exists)
								{
									fileInfo.Delete();
								}
								Document document2 = document.EditFamily(family);
								if (formgeneral.fija3d.Checked)
								{
									this.Set3DView(document2);
								}
								document2.SaveAs(text4);
								document2.Close(false);
								num2++;
							}
						}
						catch (Exception ex)
						{
							num3++;
							if (formgeneral.logerror.Checked)
							{
								this.LogError(family.Name.ToString() + " there was an error " + ex.ToString());
							}
						}
					}
				}
			}
			barraDeProgresoLineal.Hide();
			TaskDialog.Show("Saved Families", string.Concat(new string[]
			{
				"Selected Families: ",
				num.ToString(),
				"\nSaved Families: ",
				num2.ToString(),
				"\nErrors: ",
				num3.ToString()
			}));
			return 0;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000756C File Offset: 0x0000576C
		private void RellenaDiccionario(Dictionary<string, string> dic, IList<string> iList)
		{
			foreach (string key in iList)
			{
				dic.Add(key, "#VACIO#");
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000075BC File Offset: 0x000057BC
		private void LogError(string error)
		{
			string path = formgeneral.Directorio + "\\log_SaveFamilies.txt";
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

		// Token: 0x06000090 RID: 144 RVA: 0x00007638 File Offset: 0x00005838
		private void AllFamilyByCategoryToTree(Document doc, TreeView treeview)
		{
			CategoryNameMap categories = doc.Settings.Categories;
			BarraDeProgreso barraDeProgreso = new BarraDeProgreso();
			barraDeProgreso.Show();
			Dictionary<string, Family> dictionary = new Dictionary<string, Family>();
			int num = -1;
			foreach (object obj in categories)
			{
				ElementCategoryFilter elementCategoryFilter = new ElementCategoryFilter(((Category)obj).Id);
				FilteredElementCollector filteredElementCollector = new FilteredElementCollector(doc).WherePasses(elementCategoryFilter);
				filteredElementCollector.OfClass(typeof(FamilySymbol));
				foreach (Element element in filteredElementCollector)
				{
					FamilySymbol familySymbol = (FamilySymbol)element;
					if (familySymbol != null)
					{
						barraDeProgreso.textobarra.Text = "Processed Families: " + num.ToString();
						barraDeProgreso.Refresh();
						Application.DoEvents();
						if (BarraDeProgreso.cancelado)
						{
							break;
						}
						string text = familySymbol.Family.Name.ToString();
						string text2 = familySymbol.Category.Name.ToString();
						Family family = familySymbol.Family;
						string key = familySymbol.Family.Id.ToString();
						if (!dictionary.ContainsKey(key))
						{
							num++;
							dictionary.Add(key, family);
							TreeNode[] array = treeview.Nodes.Find(text2, true);
							TreeNode treeNode;
							if (array.Length == 0)
							{
								treeNode = treeview.Nodes.Add(text2, text2);
							}
							else
							{
								treeNode = array[0];
							}
							treeNode.Nodes.Add(text2 + text, text).Tag = family;
						}
					}
				}
			}
			barraDeProgreso.Close();
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00007818 File Offset: 0x00005A18
		private bool EsSimbolo(Family fam)
		{
			bool result = false;
			string text = fam.FamilyCategory.Name.ToString();
			if (text.Contains("Tags"))
			{
				result = true;
			}
			if (text.Contains("Heads"))
			{
				result = true;
			}
			if (text.Contains("Marks"))
			{
				result = true;
			}
			if (text.Contains("Symbol"))
			{
				result = true;
			}
			if (text.Contains("View Reference"))
			{
				result = true;
			}
			if (text.Contains("View Titles"))
			{
				result = true;
			}
			if (text.Contains("Title Blocks"))
			{
				result = true;
			}
			if (text.Contains("Annotations"))
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000078B0 File Offset: 0x00005AB0
		private bool EsEstructura(Family fam)
		{
			bool result = false;
			string text = fam.FamilyCategory.Name.ToString();
			if (text.Contains("Structural Columns"))
			{
				result = true;
			}
			if (text.Contains("Structural Connections"))
			{
				result = true;
			}
			if (text.Contains("Structural Foundations"))
			{
				result = true;
			}
			if (text.Contains("Structural Framing"))
			{
				result = true;
			}
			if (text.Contains("Structural Stiffeners"))
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000791C File Offset: 0x00005B1C
		private void Set3DView(Document docf)
		{
			try
			{
				Transaction transaction = new Transaction(docf, "T1");
				transaction.Start();
				docf.Regenerate();
				docf.GetDocumentPreviewSettings();
				SaveAsOptions saveAsOptions = new SaveAsOptions();
				if (docf.GetDocumentPreviewSettings().PreviewViewId.Equals(ElementId.InvalidElementId))
				{
					StartingViewSettings startingViewSettings = StartingViewSettings.GetStartingViewSettings(docf);
					if (!startingViewSettings.ViewId.Equals(ElementId.InvalidElementId))
					{
						saveAsOptions.PreviewViewId = startingViewSettings.ViewId;
					}
					else
					{
						FilteredElementCollector source = new FilteredElementCollector(docf).OfClass(typeof(View));
						IEnumerable enumerable = from View f in source
						where f.ViewType == 4 && !f.IsTemplate
						select f;
						bool flag = true;
						foreach (object obj in enumerable)
						{
							View view = (View)obj;
							if (!view.IsTemplate)
							{
								saveAsOptions.PreviewViewId = view.Id;
								flag = false;
								break;
							}
						}
						if (flag)
						{
							foreach (object obj2 in from View fNon3D in source
							where fNon3D.ViewType == 1 || fNon3D.ViewType == 115 || fNon3D.ViewType == 3 || (fNon3D.ViewType == 117 && !fNon3D.IsTemplate)
							select fNon3D)
							{
								View view2 = (View)obj2;
								if (!view2.IsTemplate)
								{
									saveAsOptions.PreviewViewId = view2.Id;
									break;
								}
							}
						}
					}
				}
				transaction.Commit();
			}
			catch
			{
			}
		}
	}
}
