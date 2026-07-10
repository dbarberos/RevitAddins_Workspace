using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using BrightIdeasSoftware;
using TransferSingleApp.Properties;

namespace TransferSingleApp
{
	// Token: 0x02000019 RID: 25
	public partial class TransferSingle : Form
	{
		// Token: 0x060000AE RID: 174 RVA: 0x0000824C File Offset: 0x0000644C
		public TransferSingle(Document _doc, UIDocument _uidoc, UIApplication _app)
		{
			this.doc = _doc;
			this.uidoc = _uidoc;
			this.app = _app;
			this.InitializeComponent();
			this.MinimumSize = new Size(480, 750);
			this.LeeConfiguraciones();
			this.CompruebaUbicacionVentana();
			this.ListaArchivosAbiertos();
			this.CompruebaViabilidad();
			TransferSingle.usercancelled = 0;
			this.Text = "TransferSingle v" + this.VersionActual;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00008308 File Offset: 0x00006508
		public void LeeConfiguraciones()
		{
			this.config = SaveXMLConfigs.Lee_Configuracion_de_XML();
			base.Size = this.config.VentanaTamano;
			base.Location = this.config.VentanaPosicion;
			if (this.config.VentanaMaximizada)
			{
				base.WindowState = FormWindowState.Maximized;
			}
			this.rbOverride.Checked = this.config.cf_rbOverride;
			this.rbCancel.Checked = this.config.cf_rbCancel;
			this.rbAsk.Checked = this.config.cf_rbAsk;
			this.chk_Callout.Checked = this.config.cf_chk_Callout;
			this.chk_ViewElements.Checked = this.config.cf_chk_ViewElements;
			this.chk_SheetWithViews.Checked = this.config.cf_chk_SheetWithViews;
			this.chk_Links.Checked = this.config.cf_chk_Links;
			this.chk_GetTransformNone.Checked = this.config.cf_chk_GetTransformNone;
			this.chk_GetTransformLink.Checked = this.config.cf_chk_GetTransformLink;
			this.chk_GetTransformShared.Checked = this.config.cf_chk_GetTransformShared;
			this.chk_AcceptAll.Checked = this.config.cf_chk_AcceptAll;
			this.Numero.Width = this.config.cf_rcSheetNumber;
			this.textBusca.Text = this.config.cf_textBusca;
			this.LeeConfiguracionesDelTab();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000847C File Offset: 0x0000667C
		public void LeeConfiguracionesDelTab()
		{
			ConfiguracionTab configuracionTab = SaveXMLConfigTab.Lee_Configuracion_de_XML();
			this.HideMessages = configuracionTab.cf_HideMessages;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000849C File Offset: 0x0000669C
		public void SalvaConfiguraciones()
		{
			if (base.WindowState == FormWindowState.Maximized)
			{
				this.config.VentanaMaximizada = true;
				this.config.VentanaPosicion = base.RestoreBounds.Location;
				this.config.VentanaTamano = base.RestoreBounds.Size;
			}
			else
			{
				this.config.VentanaMaximizada = false;
				this.config.VentanaPosicion = base.Location;
				this.config.VentanaTamano = base.Size;
			}
			this.config.cf_rbOverride = this.rbOverride.Checked;
			this.config.cf_rbCancel = this.rbCancel.Checked;
			this.config.cf_rbAsk = this.rbAsk.Checked;
			this.config.cf_chk_Callout = this.chk_Callout.Checked;
			this.config.cf_chk_ViewElements = this.chk_ViewElements.Checked;
			this.config.cf_chk_SheetWithViews = this.chk_SheetWithViews.Checked;
			this.config.cf_textBusca = this.textBusca.Text;
			this.config.cf_chk_Links = this.chk_Links.Checked;
			this.config.cf_chk_GetTransformNone = this.chk_GetTransformNone.Checked;
			this.config.cf_chk_GetTransformLink = this.chk_GetTransformLink.Checked;
			this.config.cf_chk_GetTransformShared = this.chk_GetTransformShared.Checked;
			this.config.cf_chk_AcceptAll = this.chk_AcceptAll.Checked;
			this.config.cf_rcSheetNumber = this.Numero.Width;
			SaveXMLConfigs.Salva_config(this.config);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000864C File Offset: 0x0000684C
		public void CompruebaViabilidad()
		{
			if (this.pOrigen.SelectedItem == null)
			{
				this.bt_Transfer.Enabled = false;
				return;
			}
			if (this.CuentaChecked() > 0)
			{
				this.bt_Transfer.Enabled = true;
				return;
			}
			if (this.CuentaChecked() < 1)
			{
				this.bt_Transfer.Enabled = false;
				return;
			}
			this.bt_Transfer.Enabled = true;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000086AC File Offset: 0x000068AC
		public int CuentaChecked()
		{
			int num = 0;
			using (IEnumerator<Archivo> enumerator = this.est.ArchivosFiltrados.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Checked)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00008704 File Offset: 0x00006904
		private void ListaArchivosAbiertos()
		{
			this.est.Archivos = new List<Archivo>();
			this.est.ArchivosFiltrados = new List<Archivo>();
			this.pOrigen.Items.Clear();
			int num = 0;
			foreach (object obj in this.app.Application.Documents)
			{
				Document document = (Document)obj;
				if (!document.IsLinked)
				{
					this.pOrigen.Items.Add(document.Title);
					Archivo item = new Archivo(document);
					this.est.Archivos.Add(item);
					this.est.ArchivosFiltrados.Add(item);
					num++;
				}
				else
				{
					Archivo archivo = new Archivo(document);
					archivo.EsVinculo = true;
					this.est.Archivos.Add(archivo);
					num++;
					if (this.chk_Links.Checked)
					{
						this.pOrigen.Items.Add(document.Title);
					}
				}
			}
			this.foArchivos.SetObjects(this.est.ArchivosFiltrados);
			this.FiltraDestinos();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00008850 File Offset: 0x00006A50
		public void ProcesaSeleccion()
		{
			this.tlElementos.BeginUpdate();
			Cursor.Current = Cursors.WaitCursor;
			this.GeneraEstructura();
			this.IniciaArbolElementos();
			this.ColapsarHastaSegundo();
			this.Contar();
			Cursor.Current = Cursors.Default;
			this.tlElementos.EndUpdate();
			this.tlElementos.Refresh();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000088AC File Offset: 0x00006AAC
		private void TomaElementosSeleccion(Document _doc_origen, int caso)
		{
			ICollection<ElementId> collection;
			if (caso != 1)
			{
				if (caso != 2)
				{
					collection = new FilteredElementCollector(_doc_origen).WhereElementIsElementType().ToElementIds();
				}
				else
				{
					collection = (from x in new FilteredElementCollector(_doc_origen).WhereElementIsNotElementType()
					where x.Category != null
					select x.Id).Cast<ElementId>().ToList<ElementId>();
				}
			}
			else
			{
				collection = new FilteredElementCollector(_doc_origen, this.uidoc.ActiveView.Id).WhereElementIsNotElementType().ToElementIds();
			}
			int num = 0;
			int maxMain = 37;
			this.ElementosAFiltrar = new List<Elemento>();
			BarraProgresoMultiple barraProgresoMultiple = new BarraProgresoMultiple(collection.Count, maxMain);
			barraProgresoMultiple.Show();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(collection.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			int num2 = 1;
			foreach (ElementId elementId in collection)
			{
				if (num2 % 50 == 0 && !this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element = _doc_origen.GetElement(elementId);
				if (!(element is AssemblyType) && !(element is RevitLinkType))
				{
					if (element != null && element.Category != null)
					{
						try
						{
							Elemento item = new Elemento(element);
							this.ElementosAFiltrar.Add(item);
						}
						catch
						{
						}
					}
					num2++;
				}
			}
			FilteredElementCollector filteredElementCollector = new FilteredElementCollector(_doc_origen);
			ElementClassFilter elementClassFilter = new ElementClassFilter(typeof(ParameterFilterElement), false);
			ICollection<ElementId> collection2 = filteredElementCollector.WherePasses(elementClassFilter).ToElementIds();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(collection2.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId2 in collection2)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element2 = _doc_origen.GetElement(elementId2);
				if (element2 != null)
				{
					try
					{
						Elemento item2 = new Elemento(element2, "Filters", 0, _doc_origen);
						this.ElementosAFiltrar.Add(item2);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list = (from View i in new FilteredElementCollector(_doc_origen).OfClass(typeof(View))
			where i.IsTemplate
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId3 in list)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element3 = _doc_origen.GetElement(elementId3);
				if (element3 != null)
				{
					try
					{
						Elemento item3 = new Elemento(element3, "View Templates", 3, _doc_origen);
						this.ElementosAFiltrar.Add(item3);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list2 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(BrowserOrganization))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list2.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId4 in list2)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element4 = _doc_origen.GetElement(elementId4);
				if (element4 != null)
				{
					try
					{
						BrowserOrganization browserOrganization = element4 as BrowserOrganization;
						if (browserOrganization != null)
						{
							Elemento item4 = new Elemento(element4, "Browser Organization", browserOrganization.FamilyName, "Undefined", _doc_origen);
							this.ElementosAFiltrar.Add(item4);
						}
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list3 = (from i in new FilteredElementCollector(_doc_origen).OfClass(typeof(ExportDWGSettings))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list3.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId5 in list3)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element5 = _doc_origen.GetElement(elementId5);
				if (element5 != null)
				{
					try
					{
						Elemento item5 = new Elemento(element5, "DWG Export Settings", 0, _doc_origen);
						this.ElementosAFiltrar.Add(item5);
					}
					catch
					{
					}
				}
				num2++;
			}
			FilteredElementCollector filteredElementCollector2 = new FilteredElementCollector(_doc_origen);
			filteredElementCollector2.WherePasses(new LogicalOrFilter(new List<ElementFilter>
			{
				new ElementCategoryFilter(-2000552),
				new ElementCategoryFilter(-2003201),
				new ElementCategoryFilter(-2000112),
				new ElementCategoryFilter(-2006000)
			}));
			ICollection<ElementId> collection3 = filteredElementCollector2.ToElementIds();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(collection3.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			barraProgresoMultiple.Show();
			num2 = 1;
			foreach (ElementId elementId6 in collection3)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element6 = _doc_origen.GetElement(elementId6);
				if (element6 != null)
				{
					try
					{
						Elemento item6 = new Elemento(element6, 0);
						this.ElementosAFiltrar.Add(item6);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list4 = (from View i in new FilteredElementCollector(_doc_origen).OfClass(typeof(View)).WhereElementIsNotElementType()
			where !i.IsTemplate
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list4.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			barraProgresoMultiple.Show();
			num2 = 1;
			foreach (ElementId elementId7 in list4)
			{
				bool flag = false;
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				num2++;
				Element element7 = _doc_origen.GetElement(elementId7);
				if (element7 != null)
				{
					View view = element7 as View;
					if (view != null && view.ViewType != 12 && view.ViewType != 7)
					{
						if (view.IsAssemblyView)
						{
							flag = true;
						}
						if (view.ViewType == 3)
						{
							flag = true;
						}
						if (element7.get_Parameter(-1002051).AsValueString() != null && !(element7.get_Parameter(-1002051).AsValueString() == ""))
						{
							if (view.GetPrimaryViewId().IntegerValue != -1)
							{
								flag = true;
							}
							if (element7.get_Parameter(-1006612) != null && element7.get_Parameter(-1006612).AsElementId() != ElementId.InvalidElementId)
							{
								flag = true;
							}
							try
							{
								Elemento elemento = new Elemento(element7, "Views", 0, _doc_origen);
								if (flag)
								{
									elemento.NoTransferible = true;
								}
								this.ElementosAFiltrar.Add(elemento);
							}
							catch
							{
							}
						}
					}
				}
			}
			IList<ElementId> list5 = (from ElevationMarker i in new FilteredElementCollector(_doc_origen).OfClass(typeof(ElevationMarker)).WhereElementIsNotElementType()
			where i.CurrentViewCount > 0
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list5.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId8 in list5)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				num2++;
				Element element8 = _doc_origen.GetElement(elementId8);
				if (element8 != null)
				{
					string text = "Views:";
					ElevationMarker elevationMarker = element8 as ElevationMarker;
					if (elevationMarker != null)
					{
						for (int j = 0; j < elevationMarker.MaximumViewCount; j++)
						{
							ElementId viewId = elevationMarker.GetViewId(j);
							if (!(viewId == ElementId.InvalidElementId))
							{
								Element element9 = _doc_origen.GetElement(viewId);
								if (element9 != null)
								{
									text = text + " " + element9.Name;
								}
							}
						}
						try
						{
							Elemento elemento2 = new Elemento(element8, "Views", "Elevation", "Group of Views", text, _doc_origen);
							elemento2.IsElevation = true;
							this.ElementosAFiltrar.Add(elemento2);
						}
						catch
						{
						}
					}
				}
			}
			IList<ElementId> list6 = (from ElementType q in new FilteredElementCollector(_doc_origen).OfClass(typeof(ElementType))
			where q.FamilyName == "Viewport"
			select q into i
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list6.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId9 in list6)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				num2++;
				Element element10 = _doc_origen.GetElement(elementId9);
				if (element10 != null)
				{
					try
					{
						Elemento item7 = new Elemento(element10, "Viewport Types", 0, _doc_origen);
						this.ElementosAFiltrar.Add(item7);
					}
					catch
					{
					}
				}
			}
			IList<ElementId> list7 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(Material))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list7.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId10 in list7)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element11 = _doc_origen.GetElement(elementId10);
				if (element11 != null)
				{
					try
					{
						Elemento item8 = new Elemento(element11, 0);
						this.ElementosAFiltrar.Add(item8);
					}
					catch
					{
					}
				}
				num2++;
			}
			if (_doc_origen.IsWorkshared)
			{
				FilteredWorksetCollector filteredWorksetCollector = new FilteredWorksetCollector(_doc_origen).OfKind(4);
				num++;
				barraProgresoMultiple.IniciaBarraInferior(filteredWorksetCollector.Count<Workset>());
				barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
				{
					"Collecting Standards (",
					num.ToString(),
					"/",
					maxMain.ToString(),
					")"
				}));
				num2 = 1;
				foreach (Workset ws in filteredWorksetCollector)
				{
					try
					{
						Elemento item9 = new Elemento(ws);
						this.ElementosAFiltrar.Add(item9);
					}
					catch
					{
					}
					num2++;
				}
			}
			IList<ElementId> list8 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(PrintSetting))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list8.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId11 in list8)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element12 = _doc_origen.GetElement(elementId11);
				if (element12 != null)
				{
					try
					{
						Elemento item10 = new Elemento(element12, "Print Settings", 0, _doc_origen);
						this.ElementosAFiltrar.Add(item10);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list9 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(TextNoteType))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list9.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId12 in list9)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element13 = _doc_origen.GetElement(elementId12);
				if (element13 != null)
				{
					try
					{
						Elemento item11 = new Elemento(element13, "TextNote Types", 0, _doc_origen);
						this.ElementosAFiltrar.Add(item11);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list10 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(ProjectInfo))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list10.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId13 in list10)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element14 = _doc_origen.GetElement(elementId13);
				if (element14 != null)
				{
					try
					{
						Elemento elemento3 = new Elemento(element14, "Project Info", 0, _doc_origen);
						elemento3.IsProjectInfo = true;
						this.ElementosAFiltrar.Add(elemento3);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list11 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(ProjectLocation))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list11.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId14 in list11)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element15 = _doc_origen.GetElement(elementId14);
				if (element15 != null)
				{
					try
					{
						Elemento item12 = new Elemento(element15, "Project Location", 0, _doc_origen);
						this.ElementosAFiltrar.Add(item12);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list12 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(SiteLocation))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list12.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId15 in list12)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element16 = _doc_origen.GetElement(elementId15);
				if (element16 != null)
				{
					try
					{
						Elemento item13 = new Elemento(element16, "Site Location", 2, _doc_origen);
						this.ElementosAFiltrar.Add(item13);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list13 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(Revision))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list13.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId16 in list13)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element17 = _doc_origen.GetElement(elementId16);
				if (element17 != null)
				{
					try
					{
						Elemento item14 = new Elemento(element17, "Revision", 1, _doc_origen);
						this.ElementosAFiltrar.Add(item14);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list14 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(RevisionSettings))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list14.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId17 in list14)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element18 = _doc_origen.GetElement(elementId17);
				if (element18 != null)
				{
					try
					{
						Elemento item15 = new Elemento(element18, "Revision Settings", 0, _doc_origen);
						this.ElementosAFiltrar.Add(item15);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list15 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(PhaseFilter))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list15.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId18 in list15)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element19 = _doc_origen.GetElement(elementId18);
				if (element19 != null)
				{
					try
					{
						Elemento item16 = new Elemento(element19, "Phase Filter", 0, _doc_origen);
						this.ElementosAFiltrar.Add(item16);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list16 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(LinePatternElement))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list16.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId19 in list16)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element20 = _doc_origen.GetElement(elementId19);
				if (element20 != null)
				{
					try
					{
						Elemento item17 = new Elemento(element20, "Line Patterns", 0, _doc_origen);
						this.ElementosAFiltrar.Add(item17);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list17 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(FillPatternElement))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list17.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId20 in list17)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element21 = _doc_origen.GetElement(elementId20);
				if (element21 != null)
				{
					try
					{
						Elemento item18 = new Elemento(element21, "Fill Patterns", 0, _doc_origen);
						this.ElementosAFiltrar.Add(item18);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list18 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(DimensionType))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list18.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId21 in list18)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element22 = _doc_origen.GetElement(elementId21);
				if (element22 != null)
				{
					try
					{
						Elemento item19 = new Elemento(element22, "Dimension Types", 0, _doc_origen);
						this.ElementosAFiltrar.Add(item19);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list19 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(ParameterElement))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list19.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId22 in list19)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element23 = _doc_origen.GetElement(elementId22);
				if (element23 != null)
				{
					try
					{
						Elemento item20 = new Elemento(element23, "Parameters", 7, _doc_origen);
						this.ElementosAFiltrar.Add(item20);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list20 = (from i in new FilteredElementCollector(_doc_origen).OfClass(typeof(Grid)).WhereElementIsNotElementType()
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list20.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId23 in list20)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				num2++;
				Element element24 = _doc_origen.GetElement(elementId23);
				if (element24 != null)
				{
					try
					{
						Elemento item21 = new Elemento(element24, "Grids", 99, _doc_origen);
						this.ElementosAFiltrar.Add(item21);
					}
					catch
					{
					}
				}
			}
			IList<ElementId> list21 = (from i in new FilteredElementCollector(_doc_origen).OfClass(typeof(Level)).WhereElementIsNotElementType()
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list21.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId24 in list21)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				num2++;
				Element element25 = _doc_origen.GetElement(elementId24);
				if (element25 != null)
				{
					try
					{
						Elemento item22 = new Elemento(element25, "Levels", 99, _doc_origen);
						this.ElementosAFiltrar.Add(item22);
					}
					catch
					{
					}
				}
			}
			if (!_doc_origen.IsFamilyDocument)
			{
				num++;
				barraProgresoMultiple.IniciaBarraInferior(0);
				barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
				{
					"Collecting Standards (",
					num.ToString(),
					"/",
					maxMain.ToString(),
					")"
				}));
				num2 = 1;
				DefinitionBindingMapIterator definitionBindingMapIterator = _doc_origen.ParameterBindings.ForwardIterator();
				definitionBindingMapIterator.Reset();
				while (definitionBindingMapIterator.MoveNext())
				{
					InternalDefinition internalDefinition = (InternalDefinition)definitionBindingMapIterator.Key;
					if (!(_doc_origen.GetElement(internalDefinition.Id) is SharedParameterElement))
					{
						Elemento item23 = new Elemento(_doc_origen.GetElement(internalDefinition.Id), "Parameters", 5, _doc_origen);
						this.ElementosAFiltrar.Add(item23);
					}
					else
					{
						Elemento item24 = new Elemento(_doc_origen.GetElement(internalDefinition.Id), "Parameters", 6, _doc_origen);
						this.ElementosAFiltrar.Add(item24);
					}
				}
			}
			IList<ElementId> list22 = (from ViewFamilyType i in new FilteredElementCollector(_doc_origen).OfClass(typeof(ViewFamilyType))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list22.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId25 in list22)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				num2++;
				Element element26 = _doc_origen.GetElement(elementId25);
				if (element26 != null)
				{
					try
					{
						Elemento item25 = new Elemento(element26, "View Family Types", 4, _doc_origen);
						this.ElementosAFiltrar.Add(item25);
					}
					catch
					{
					}
				}
			}
			IList<ElementId> list23 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(SunAndShadowSettings))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list23.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId26 in list23)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element27 = _doc_origen.GetElement(elementId26);
				if (element27 != null)
				{
					try
					{
						Elemento item26 = new Elemento(element27, "Sun And Shadow Settings", 0, _doc_origen);
						this.ElementosAFiltrar.Add(item26);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list24 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(SpatialElement))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list24.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId27 in list24)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element28 = _doc_origen.GetElement(elementId27);
				if (element28 != null)
				{
					try
					{
						if (element28.Category.Id.IntegerValue == -2000160)
						{
							Elemento item27 = new Elemento(element28, "Rooms", 0, _doc_origen);
							this.ElementosAFiltrar.Add(item27);
						}
						else
						{
							Elemento item28 = new Elemento(element28, "Spaces", 0, _doc_origen);
							this.ElementosAFiltrar.Add(item28);
						}
					}
					catch
					{
					}
				}
				num2++;
			}
			Categories categories = _doc_origen.Settings.Categories;
			num++;
			barraProgresoMultiple.IniciaBarraInferior(categories.Size);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (object obj in categories)
			{
				Category category = (Category)obj;
				if (category.Id.IntegerValue <= 0)
				{
					CategoryNameMap subCategories = category.SubCategories;
					if (subCategories != null && subCategories.Size != 0)
					{
						foreach (object obj2 in subCategories)
						{
							Category category2 = (Category)obj2;
							try
							{
								Element element29 = _doc_origen.GetElement(category2.Id);
								if (element29 != null)
								{
									Elemento item29 = new Elemento(element29, "Category", category.CategoryType.ToString(), category.Name, _doc_origen);
									this.ElementosAFiltrar.Add(item29);
								}
							}
							catch
							{
							}
						}
					}
				}
			}
			IList<ElementId> list25 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(Family))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list25.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId28 in list25)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element30 = _doc_origen.GetElement(elementId28);
				Family family = _doc_origen.GetElement(elementId28) as Family;
				if (element30 != null)
				{
					try
					{
						Elemento item30 = new Elemento(element30, "Loadable Families (Overwrite All Types)", family.FamilyCategory.Name, _doc_origen);
						this.ElementosAFiltrar.Add(item30);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list26 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(GlobalParameter))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list26.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId29 in list26)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element31 = _doc_origen.GetElement(elementId29);
				if (element31 != null)
				{
					try
					{
						Elemento item31 = new Elemento(element31, "Parameters", 71, _doc_origen);
						this.ElementosAFiltrar.Add(item31);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list27 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(AssemblyInstance))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list27.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			IList<ElementId> list28 = new List<ElementId>();
			foreach (ElementId elementId30 in list27)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element32 = _doc_origen.GetElement(elementId30);
				if (element32 != null)
				{
					ElementId typeId = element32.GetTypeId();
					if (list28.Contains(typeId))
					{
						continue;
					}
					string familiaForzada = element32.get_Parameter(-1150403).AsValueString();
					try
					{
						Elemento item32 = new Elemento(element32, "Assembly", familiaForzada, "Only One Instance", _doc_origen);
						this.ElementosAFiltrar.Add(item32);
						list28.Add(typeId);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list29 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(AssemblyInstance))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list29.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			using (IEnumerator<ElementId> enumerator = list29.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementId id = enumerator.Current;
					if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
					{
						break;
					}
					Element element33 = _doc_origen.GetElement(id);
					if (element33 != null)
					{
						string familiaForzada2 = element33.get_Parameter(-1150403).AsValueString();
						IList<ElementId> list30 = new List<ElementId>();
						IList<ElementId> second = (from View i in new FilteredElementCollector(_doc_origen).OfClass(typeof(View)).WhereElementIsNotElementType()
						where !i.IsTemplate
						where i.IsAssemblyView
						where i.AssociatedAssemblyInstanceId == id
						select i.Id).ToList<ElementId>();
						list30 = list30.Concat(second).ToList<ElementId>();
						if (list30.Count == 0)
						{
							continue;
						}
						try
						{
							Elemento elemento4 = new Elemento(element33, "Assembly (with views)", familiaForzada2, "Instance with Views", _doc_origen);
							elemento4.IdsAdicionales = list30;
							this.ElementosAFiltrar.Add(elemento4);
						}
						catch
						{
						}
					}
					num2++;
				}
			}
			FilteredElementCollector filteredElementCollector3 = new FilteredElementCollector(_doc_origen);
			filteredElementCollector3.WherePasses(new ElementCategoryFilter(-2000107));
			ICollection<ElementId> collection4 = filteredElementCollector3.ToElementIds();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(collection4.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId31 in collection4)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element34 = _doc_origen.GetElement(elementId31);
				if (element34 != null)
				{
					try
					{
						Elemento item33 = new Elemento(element34, "Guide Grids", "Guide Grids", "Undefined", _doc_origen);
						this.ElementosAFiltrar.Add(item33);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list31 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(PanelScheduleTemplate))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list31.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId32 in list31)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element35 = _doc_origen.GetElement(elementId32);
				if (element35 != null)
				{
					try
					{
						Elemento item34 = new Elemento(element35, "Panel Schedule Templates", 9, _doc_origen);
						this.ElementosAFiltrar.Add(item34);
					}
					catch
					{
					}
				}
				num2++;
			}
			IList<ElementId> list32 = (from Element i in new FilteredElementCollector(_doc_origen).OfClass(typeof(RevitLinkInstance))
			select i.Id).ToList<ElementId>();
			num++;
			barraProgresoMultiple.IniciaBarraInferior(list32.Count);
			barraProgresoMultiple.FijaTextoSuperior(string.Concat(new string[]
			{
				"Collecting Standards (",
				num.ToString(),
				"/",
				maxMain.ToString(),
				")"
			}));
			num2 = 1;
			foreach (ElementId elementId33 in list32)
			{
				if (!this.barraupdateMultiple(barraProgresoMultiple, num2))
				{
					break;
				}
				Element element36 = _doc_origen.GetElement(elementId33);
				if (element36 != null)
				{
					RevitLinkInstance revitLinkInstance = element36 as RevitLinkInstance;
					if (revitLinkInstance != null)
					{
						RevitLinkType revitLinkType = _doc_origen.GetElement(revitLinkInstance.GetTypeId()) as RevitLinkType;
						if (revitLinkType != null && !(ElementId.InvalidElementId != revitLinkType.GetParentId()))
						{
							try
							{
								Elemento item35 = new Elemento(element36, "Revit Link Instances", 10, _doc_origen);
								this.ElementosAFiltrar.Add(item35);
							}
							catch
							{
							}
							num2++;
						}
					}
				}
			}
			barraProgresoMultiple.Close();
			this.ElementosAFiltrar = (from c in this.ElementosAFiltrar
			orderby c.Categoria, c.Familia, c.Tipo, c.Nombre
			select c).ToList<Elemento>();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000BA30 File Offset: 0x00009C30
		public bool barraupdate(BarraProgreso bar, int i)
		{
			bar.FijaTexto(0, this.ElementosAFiltrar.Count, i);
			bar.Refresh();
			Application.DoEvents();
			return !bar.cancelado;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000BA5B File Offset: 0x00009C5B
		public bool barraupdateMultiple(BarraProgresoMultiple bar, int i)
		{
			bar.FijaTexto(0, this.ElementosAFiltrar.Count, i);
			bar.Refresh();
			Application.DoEvents();
			return !bar.cancelado;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000BA88 File Offset: 0x00009C88
		private void IniciaArbolElementos()
		{
			this.tlElementos.RevealAfterExpand = true;
			this.tlElementos.CanExpandGetter = delegate(object x)
			{
				if (x is Nodo)
				{
					return (x as Nodo).Has_childs();
				}
				Elemento elemento = x as Elemento;
				return false;
			};
			this.tlElementos.ChildrenGetter = delegate(object x)
			{
				if (x is Nodo)
				{
					return ((Nodo)x).childs();
				}
				return null;
			};
			this.tlElementos.SetObjects(this.est.Raices_Nodos);
			this.tlElementos.ExpandAll();
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000BB18 File Offset: 0x00009D18
		public void GeneraEstructura()
		{
			this.tlElementos.ClearObjects();
			this.est.Raices_Nodos = new List<Nodo>();
			this.est.Raices_Elementos = new List<Elemento>();
			Nodo nodo = new Nodo("All", this.ElementosAFiltrar.Count);
			nodo.Num = this.ElementosAFiltrar.Count<Elemento>();
			nodo.set_Vistas(this.ElementosAFiltrar);
			nodo = this.Ordenanodos(nodo, 3);
			this.est.Raices_Nodos.Add(nodo);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000BBA0 File Offset: 0x00009DA0
		public Nodo Ordenanodos(Nodo n, int niv)
		{
			IEnumerable<IGrouping<string, Elemento>> enumerable = from Elemento V in n.Elementos
			group V by V.Categoria into grouping
			select grouping;
			if (niv == 3)
			{
				foreach (IGrouping<string, Elemento> grouping6 in enumerable)
				{
					Nodo nodo = new Nodo(grouping6.Key);
					nodo.Num = grouping6.Count<Elemento>();
					foreach (IGrouping<string, Elemento> grouping2 in from Elemento V in grouping6.ToList<Elemento>()
					group V by V.Familia into grouping
					select grouping)
					{
						if (grouping2.Key.Equals("Undefined"))
						{
							nodo.Elementos = grouping2.OrderBy((Elemento Elemento) => Elemento.Nombre).ToList<Elemento>();
							using (IEnumerator<Elemento> enumerator3 = nodo.Elementos.GetEnumerator())
							{
								while (enumerator3.MoveNext())
								{
									Elemento elemento = enumerator3.Current;
									elemento.Padre = nodo;
								}
								continue;
							}
						}
						Nodo nodo2 = new Nodo(grouping2.Key);
						nodo2.Num = grouping2.Count<Elemento>();
						foreach (IGrouping<string, Elemento> grouping3 in grouping2.ToList<Elemento>().Cast<Elemento>().GroupBy((Elemento V) => V.Tipo).Select((IGrouping<string, Elemento> grouping) => grouping))
						{
							if (grouping3.Key.Equals("Undefined"))
							{
								nodo2.Elementos = grouping3.OrderBy((Elemento Elemento) => Elemento.Nombre).ToList<Elemento>();
								using (IEnumerator<Elemento> enumerator3 = nodo2.Elementos.GetEnumerator())
								{
									while (enumerator3.MoveNext())
									{
										Elemento elemento2 = enumerator3.Current;
										elemento2.Padre = nodo2;
									}
									continue;
								}
							}
							Nodo nodo3 = new Nodo(grouping3.Key);
							nodo3.Num = grouping3.Count<Elemento>();
							nodo3.Elementos = grouping3.OrderBy((Elemento Elemento) => Elemento.Nombre).ToList<Elemento>();
							foreach (Elemento elemento3 in nodo3.Elementos)
							{
								elemento3.Padre = nodo3;
							}
							string text = nodo3.NombreNodo;
							while (nodo2.Nodos.ContainsKey(text))
							{
								text += " (dup)";
							}
							nodo2.Nodos.Add(text, nodo3);
						}
						string text2 = nodo2.NombreNodo;
						while (nodo.Nodos.ContainsKey(text2))
						{
							text2 += " (dup)";
						}
						nodo.Nodos.Add(text2, nodo2);
					}
					string text3 = nodo.NombreNodo;
					while (n.Nodos.ContainsKey(text3))
					{
						text3 += " (dup)";
					}
					n.Nodos.Add(text3, nodo);
				}
			}
			if (niv == 2)
			{
				foreach (IGrouping<string, Elemento> grouping4 in enumerable)
				{
					Nodo nodo4 = new Nodo(grouping4.Key);
					nodo4.Num = grouping4.Count<Elemento>();
					foreach (IGrouping<string, Elemento> grouping5 in from Elemento V in grouping4.ToList<Elemento>()
					group V by V.Familia into grouping
					select grouping)
					{
						if (grouping5.Key.Equals("Undefined"))
						{
							nodo4.Elementos = grouping5.OrderBy((Elemento Elemento) => Elemento.Nombre).ToList<Elemento>();
							using (IEnumerator<Elemento> enumerator3 = nodo4.Elementos.GetEnumerator())
							{
								while (enumerator3.MoveNext())
								{
									Elemento elemento4 = enumerator3.Current;
									elemento4.Padre = nodo4;
								}
								continue;
							}
						}
						Nodo nodo5 = new Nodo(grouping5.Key);
						nodo4.Num = grouping5.Count<Elemento>();
						nodo5.Elementos = grouping5.OrderBy((Elemento Elemento) => Elemento.Nombre).ToList<Elemento>();
						foreach (Elemento elemento5 in nodo5.Elementos)
						{
							elemento5.Padre = nodo5;
						}
						string text4 = nodo5.NombreNodo;
						while (nodo4.Nodos.ContainsKey(text4))
						{
							text4 += " (dup)";
						}
						nodo4.Nodos.Add(text4, nodo5);
					}
					string text5 = nodo4.NombreNodo;
					while (n.Nodos.ContainsKey(text5))
					{
						text5 += " (dup)";
					}
					n.Nodos.Add(text5, nodo4);
				}
			}
			n.Elementos.Clear();
			return n;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000C2CC File Offset: 0x0000A4CC
		private void Contar2()
		{
			int num = 0;
			using (IEnumerator<Elemento> enumerator = this.ElementosAFiltrar.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Checked)
					{
						num++;
					}
				}
			}
			this.txtSelection.Text = num.ToString();
			this.txtSelection.Refresh();
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000C33C File Offset: 0x0000A53C
		private void Contar()
		{
			this.contador = 0;
			int num = 0;
			foreach (object obj in this.tlElementos.Objects)
			{
				if (obj is Elemento && (obj as Elemento).Checked)
				{
					num++;
				}
				if (obj is Nodo)
				{
					Nodo nod = obj as Nodo;
					this.ContarNodo(nod);
				}
			}
			this.contador += num;
			this.txtSelection.Text = this.contador.ToString();
			this.txtSelection.Refresh();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000C3F8 File Offset: 0x0000A5F8
		private void ContarNodo(Nodo nod)
		{
			int num = 0;
			using (IEnumerator<Elemento> enumerator = nod.Elementos.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Checked)
					{
						num++;
					}
				}
			}
			foreach (Nodo nod2 in nod.Nodos.Values)
			{
				this.ContarNodo(nod2);
			}
			this.contador += num;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000C49C File Offset: 0x0000A69C
		private int DameCuenta()
		{
			int num = 0;
			using (IEnumerator<Elemento> enumerator = this.ElementosAFiltrar.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Checked)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000C4F0 File Offset: 0x0000A6F0
		public void FiltraDestinos()
		{
			if (this.pOrigen.SelectedIndex > -1)
			{
				IList<Archivo> list = new List<Archivo>();
				foreach (Archivo archivo in this.est.Archivos)
				{
					if (!archivo.Nombre.Equals(this.pOrigen.SelectedItem.ToString()) && !archivo.EsVinculo)
					{
						list.Add(archivo);
					}
				}
				this.est.ArchivosFiltrados = list;
				this.foArchivos.SetObjects(this.est.ArchivosFiltrados);
				this.foArchivos.Refresh();
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000C5AC File Offset: 0x0000A7AC
		private void bt_Filtra_Click(object sender, EventArgs e)
		{
			string str = "Ask User.";
			CopyPasteOptions copyPasteOptions = new CopyPasteOptions();
			if (this.rbOverride.Checked)
			{
				copyPasteOptions.SetDuplicateTypeNamesHandler(new TransferSingle.CustomCopyHandlerOk());
				str = "Ok on Duplicates.";
			}
			else if (this.rbCancel.Checked)
			{
				copyPasteOptions.SetDuplicateTypeNamesHandler(new TransferSingle.CustomCopyHandlerAbort());
				str = "Abort on Duplicates.";
			}
			if (this.chk_AcceptAll.Checked)
			{
				this.app.DialogBoxShowing += TransferSingle.UiAppOnDialogBoxShowing;
				this.app.Application.FailuresProcessing += this.HandleFailures_Soft;
			}
			int num = 0;
			int num2 = 0;
			string text = "";
			int count = this.foArchivos.CheckedObjects.Count;
			Document origen = this.DameDocDeTexto(this.pOrigen.SelectedItem.ToString());
			BarraProgreso barraProgreso = new BarraProgreso(this.DameCuenta());
			barraProgreso.Text = "Transferring Standards";
			barraProgreso.Show();
			int num3 = 1;
			this.est.LogTxt.Add(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", DateTimeFormatInfo.InvariantInfo) + " Starting Tranferring Standards from File: " + this.pOrigen.SelectedItem.ToString());
			Func<RevitLinkInstance, bool> <>9__0;
			foreach (object obj in this.foArchivos.CheckedObjects)
			{
				Archivo archivo = (Archivo)obj;
				num2 = 0;
				num = 0;
				int num4 = 1;
				barraProgreso.Text = string.Concat(new string[]
				{
					"Transferring Standards (",
					num3.ToString(),
					" of ",
					count.ToString(),
					")"
				});
				Document adoc = archivo.Adoc;
				this.est.LogTxt.Add("Current Destination File: " + archivo.Nombre);
				this.est.LogTxt.Add("Options on Duplicate Selected: " + str);
				Transform transform = null;
				bool flag = false;
				if (this.chk_GetTransformLink.Checked)
				{
					IEnumerable<RevitLinkInstance> source = new FilteredElementCollector(adoc).OfClass(typeof(RevitLinkInstance)).Cast<RevitLinkInstance>();
					Func<RevitLinkInstance, bool> predicate;
					if ((predicate = <>9__0) == null)
					{
						predicate = (<>9__0 = ((RevitLinkInstance i) => i.GetLinkDocument().Title.Equals(origen.Title)));
					}
					IList<RevitLinkInstance> list = source.Where(predicate).ToList<RevitLinkInstance>();
					if (list.Count > 0)
					{
						transform = list.FirstOrDefault<RevitLinkInstance>().GetTotalTransform();
						flag = true;
					}
				}
				else if (this.chk_GetTransformShared.Checked)
				{
					Transform totalTransform = origen.ActiveProjectLocation.GetTotalTransform();
					transform = adoc.ActiveProjectLocation.GetTotalTransform().Multiply(totalTransform.Inverse);
					flag = true;
				}
				Transaction transaction = new Transaction(adoc);
				transaction.Start("Transfer Single");
				using (IEnumerator<Elemento> enumerator2 = this.ElementosAFiltrar.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						Elemento el = enumerator2.Current;
						if (barraProgreso.cancelado)
						{
							break;
						}
						if (el.Checked && el.IsLoadable)
						{
							barraProgreso.FijaTexto(1, num, num4);
							barraProgreso.Refresh();
							Application.DoEvents();
							try
							{
								Family family = origen.GetElement(el.eID) as Family;
								int num5 = 1;
								FamilyLoadOptions familyLoadOptions = new FamilyLoadOptions();
								if (num5 == 0)
								{
									Document document = origen.EditFamily(family);
									document.LoadFamily(adoc, familyLoadOptions);
									document.Close(false);
								}
								if (num5 != 0)
								{
									Document document2 = origen.EditFamily(family);
									string text2 = Path.GetTempPath() + "\\TransferSingleTMP\\";
									DirectoryInfo directoryInfo = new DirectoryInfo(text2);
									if (!directoryInfo.Exists)
									{
										directoryInfo.Create();
									}
									string text3 = text2 + family.Name + ".rfa";
									FileInfo fileInfo = new FileInfo(text3);
									if (fileInfo.Exists)
									{
										fileInfo.Delete();
									}
									document2.SaveAs(text3);
									document2.Close(false);
									Family family2;
									adoc.LoadFamily(text3, familyLoadOptions, ref family2);
									FileInfo fileInfo2 = new FileInfo(text3);
									if (fileInfo2.Exists)
									{
										fileInfo2.Delete();
									}
								}
								num2++;
							}
							catch (Exception ex)
							{
								num++;
								if (el.Categoria.Equals("Worksets"))
								{
									this.est.LogTxt.Add(string.Concat(new string[]
									{
										"\tERROR transferring element: ",
										el.Nombre,
										" (",
										el.Categoria,
										"/",
										el.Familia,
										"/",
										el.Tipo,
										") (wid:",
										el.wID.ToString(),
										") Exception: ",
										ex.Message
									}));
								}
								else
								{
									this.est.LogTxt.Add(string.Concat(new string[]
									{
										"\tERROR transferring element: ",
										el.Nombre,
										" (",
										el.Categoria,
										"/",
										el.Familia,
										"/",
										el.Tipo,
										") (id:",
										el.eID.ToString(),
										") Exception: ",
										ex.Message
									}));
								}
							}
							num4++;
						}
						if (barraProgreso.cancelado)
						{
							break;
						}
						if (el.Checked && !el.IsLoadable)
						{
							barraProgreso.FijaTexto(1, num, num4);
							barraProgreso.Refresh();
							Application.DoEvents();
							try
							{
								if (el.Categoria.Equals("Worksets"))
								{
									if (adoc.IsWorkshared)
									{
										Workset.Create(adoc, el.Nombre);
									}
									else
									{
										this.est.LogTxt.Add(string.Concat(new string[]
										{
											"\tWARNING current file is not Workshared, ignoring: ",
											el.Nombre,
											" (",
											el.Categoria,
											"/",
											el.Familia,
											"/",
											el.Tipo,
											") (id:",
											el.eID.ToString(),
											")"
										}));
									}
								}
								else
								{
									if (el.IsProjectInfo)
									{
										using (IEnumerator enumerator3 = origen.ProjectInformation.Parameters.GetEnumerator())
										{
											while (enumerator3.MoveNext())
											{
												object obj2 = enumerator3.Current;
												Parameter parameter = (Parameter)obj2;
												Parameter parameter2 = adoc.ProjectInformation.LookupParameter(parameter.Definition.Name);
												if (parameter2 != null && !parameter2.IsReadOnly && parameter.StorageType == parameter2.StorageType)
												{
													try
													{
														switch (parameter.StorageType)
														{
														case 1:
															parameter2.Set(parameter.AsInteger());
															break;
														case 2:
															parameter2.Set(parameter.AsDouble());
															break;
														case 3:
															parameter2.Set(parameter.AsString());
															break;
														case 4:
															parameter2.Set(parameter.AsElementId());
															break;
														}
													}
													catch
													{
													}
												}
											}
											goto IL_195F;
										}
									}
									if (el.IsView && el.IsSchedule)
									{
										ICollection<ElementId> collection = new List<ElementId>();
										collection.Add(el.eID);
										View vistaorigen = origen.GetElement(el.eID) as View;
										View vistadestino = adoc.GetElement(ElementTransformUtils.CopyElements(origen, collection, adoc, null, copyPasteOptions).FirstOrDefault<ElementId>()) as View;
										this.matchPlantilla(origen, adoc, vistaorigen, vistadestino);
									}
									else
									{
										if (el.IsView && el.IsLegend)
										{
											using (Transaction transaction2 = new Transaction(origen, "Borradotemporal"))
											{
												transaction2.Start();
												ICollection<ElementId> collection2 = new List<ElementId>();
												collection2.Add(el.eID);
												View view = origen.GetElement(el.eID) as View;
												IList<ReferencePlane> list2 = new FilteredElementCollector(origen, view.Id).OfClass(typeof(ReferencePlane)).Cast<ReferencePlane>().ToList<ReferencePlane>();
												IList<ElementId> list3 = (from i in new FilteredElementCollector(origen, view.Id).OfClass(typeof(ReferencePlane))
												select i.Id).ToList<ElementId>();
												try
												{
													origen.Delete(list3);
												}
												catch
												{
												}
												View view2 = adoc.GetElement(ElementTransformUtils.CopyElements(origen, collection2, adoc, null, copyPasteOptions).FirstOrDefault<ElementId>()) as View;
												this.matchPlantilla(origen, adoc, view, view2);
												transaction2.RollBack();
												foreach (ReferencePlane referencePlane in list2)
												{
													try
													{
														adoc.Create.NewReferencePlane(referencePlane.BubbleEnd, referencePlane.FreeEnd, view2.ViewDirection, view2);
													}
													catch
													{
													}
												}
												goto IL_195F;
											}
										}
										if (el.IsView && el.IsDrafting)
										{
											ICollection<ElementId> collection3 = new List<ElementId>();
											collection3.Add(el.eID);
											View view3 = (from View i in new FilteredElementCollector(origen).OfClass(typeof(View)).WhereElementIsNotElementType()
											where i.Id == el.eID
											select i).FirstOrDefault<View>();
											ICollection<ElementId> collection4 = new List<ElementId>();
											ICollection<ElementId> collection5 = new List<ElementId>();
											View view4 = origen.GetElement(el.eID) as View;
											if (view4 != null)
											{
												new List<ElementId>();
												view4.GetDependentViewIds();
												foreach (ElementId elementId in view4.GetDependentElements(null))
												{
													Element element = origen.GetElement(elementId);
													if (element != null && !(element is Viewport) && !(element is View) && element.Category != null)
													{
														if (element.Category.Id.IntegerValue == -2000278)
														{
															collection5.Add(element.Id);
														}
														else if (element.Category.Id.IntegerValue != -2009611 && element.Category.Id.IntegerValue != -2009612 && element.Category.Id.IntegerValue != -2009610 && element.Category.Id.IntegerValue != -2009609 && element.Category.Id.IntegerValue != -2000055 && !(element.Category.Name == "Sun Path") && !(element is SunAndShadowSettings))
														{
															collection4.Add(element.Id);
														}
													}
												}
											}
											using (Transaction transaction3 = new Transaction(origen, "Borradotemporal"))
											{
												transaction3.Start();
												foreach (ElementId elementId2 in collection4)
												{
													try
													{
														origen.Delete(elementId2);
													}
													catch
													{
													}
												}
												foreach (ElementId elementId3 in collection5)
												{
													try
													{
														origen.Delete(elementId3);
													}
													catch
													{
													}
												}
												View view5 = adoc.GetElement(ElementTransformUtils.CopyElements(origen, collection3, adoc, Transform.Identity, copyPasteOptions).First<ElementId>()) as View;
												this.matchPlantilla(origen, adoc, view3, view5);
												transaction3.RollBack();
												if (collection4.Count<ElementId>() > 0)
												{
													ElementTransformUtils.CopyElements(view3, collection4, view5, null, copyPasteOptions);
												}
												goto IL_195F;
											}
										}
										if (el.IsView && el.IsSheet)
										{
											ICollection<ElementId> collection6 = new List<ElementId>();
											collection6.Add(el.eID);
											View view6 = (from View i in new FilteredElementCollector(origen).OfClass(typeof(View)).WhereElementIsNotElementType()
											where i.Id == el.eID
											select i).FirstOrDefault<View>();
											ICollection<ElementId> collection7 = new List<ElementId>();
											foreach (Element element2 in new FilteredElementCollector(origen).OwnedByView(el.eID))
											{
												if (!(element2 is Viewport) && !(element2 is View) && !(element2 is SketchPlane) && !(element2 is ReferencePlane) && element2.Category != null && element2.Category.Id.IntegerValue != -2009611 && element2.Category.Id.IntegerValue != -2009612 && element2.Category.Id.IntegerValue != -2009610 && element2.Category.Id.IntegerValue != -2009609 && element2.Category.Id.IntegerValue != -2009609 && element2.Category.Id.IntegerValue != -2000530 && !(element2.Category.Name == "Sun Path") && !(element2 is SunAndShadowSettings))
												{
													collection7.Add(element2.Id);
												}
											}
											View view7 = null;
											using (Transaction transaction4 = new Transaction(origen, "Borradotemporal"))
											{
												transaction4.Start();
												foreach (Viewport viewport in ((IEnumerable<Viewport>)(from Viewport q in new FilteredElementCollector(origen).OfClass(typeof(Viewport))
												where q.SheetId == el.eID
												select q).ToList<Viewport>()))
												{
													origen.Delete(viewport.Id);
												}
												view7 = (adoc.GetElement(ElementTransformUtils.CopyElements(origen, collection6, adoc, Transform.Identity, copyPasteOptions).First<ElementId>()) as View);
												if (collection7.Count<ElementId>() > 0)
												{
													ElementTransformUtils.CopyElements(view6, collection7, view7, null, copyPasteOptions);
												}
												transaction4.RollBack();
											}
											if (!this.chk_SheetWithViews.Checked)
											{
												goto IL_195F;
											}
											ViewSheet viewSheet = origen.GetElement(el.eID) as ViewSheet;
											if (viewSheet == null)
											{
												goto IL_195F;
											}
											using (IEnumerator<ElementId> enumerator5 = viewSheet.GetAllPlacedViews().GetEnumerator())
											{
												while (enumerator5.MoveNext())
												{
													ElementId elementId4 = enumerator5.Current;
													try
													{
														View view8 = origen.GetElement(elementId4) as View;
														View view9 = adoc.GetElement(ElementTransformUtils.CopyElements(origen, new List<ElementId>
														{
															elementId4
														}, adoc, null, copyPasteOptions).FirstOrDefault<ElementId>()) as View;
														if (flag)
														{
															try
															{
																if (!transform.Origin.IsAlmostEqualTo(XYZ.Zero))
																{
																	ElementTransformUtils.MoveElement(adoc, TransferSingle.GetCropBoxFor(view9), transform.Origin);
																}
															}
															catch
															{
															}
															try
															{
																Line rotationAxisFromTransform = TransferSingle.GetRotationAxisFromTransform(transform);
																double rotationAngleFromTransform = TransferSingle.GetRotationAngleFromTransform(transform);
																if (rotationAngleFromTransform != 0.0)
																{
																	ElementTransformUtils.RotateElement(adoc, TransferSingle.GetCropBoxFor(view9), rotationAxisFromTransform, rotationAngleFromTransform);
																}
															}
															catch
															{
															}
														}
														this.matchPlantilla(origen, adoc, view8, view9);
														if (this.chk_ViewElements.Checked)
														{
															this.ponDependientes(origen, view8.GetDependentElements(null), view8, view9, copyPasteOptions);
														}
														if (this.chk_Callout.Checked && view8.ViewType != 10)
														{
															this.ponCallouts(origen, adoc, view8, view9, copyPasteOptions, this.chk_ViewElements.Checked, 3, flag, transform);
														}
														foreach (Element element3 in new FilteredElementCollector(origen).OfClass(typeof(Viewport)))
														{
															Viewport viewport2 = (Viewport)element3;
															if (viewport2.SheetId == viewSheet.Id && viewport2.ViewId == view8.Id)
															{
																BoundingBoxXYZ boundingBoxXYZ = viewport2.get_BoundingBox(viewSheet);
																XYZ xyz = (boundingBoxXYZ.Max + boundingBoxXYZ.Min) / 2.0;
																string name = viewport2.Name;
																Viewport viewport3 = Viewport.Create(adoc, view7.Id, view9.Id, XYZ.Zero);
																foreach (ElementId elementId5 in viewport3.GetValidTypes())
																{
																	if ((adoc.GetElement(elementId5) as ElementType).Name.Equals(name))
																	{
																		viewport3.ChangeTypeId(elementId5);
																	}
																}
																BoundingBoxXYZ boundingBoxXYZ2 = viewport3.get_BoundingBox(view7);
																XYZ xyz2 = (boundingBoxXYZ2.Max + boundingBoxXYZ2.Min) / 2.0;
																ElementTransformUtils.MoveElement(adoc, viewport3.Id, new XYZ(xyz.X - xyz2.X, xyz.Y - xyz2.Y, 0.0));
															}
														}
													}
													catch
													{
													}
												}
												goto IL_195F;
											}
										}
										if (el.IsView)
										{
											ICollection<ElementId> collection8 = new List<ElementId>();
											collection8.Add(el.eID);
											if (el.IdsAdicionales.Count > 0)
											{
												foreach (ElementId item in el.IdsAdicionales)
												{
													collection8.Add(item);
												}
											}
											ICollection<ElementId> collection9 = new List<ElementId>();
											foreach (ElementId elementId6 in collection8)
											{
												Element element4 = origen.GetElement(elementId6);
												if (element4 != null)
												{
													ICollection<ElementId> dependentElements = element4.GetDependentElements(null);
													if (dependentElements.Count > 0)
													{
														collection9 = collection9.Union(dependentElements).ToList<ElementId>();
													}
												}
											}
											using (IEnumerator<ElementId> enumerator5 = ElementTransformUtils.CopyElements(origen, collection8, adoc, null, copyPasteOptions).GetEnumerator())
											{
												while (enumerator5.MoveNext())
												{
													ElementId elementId7 = enumerator5.Current;
													if (elementId7 != ElementId.InvalidElementId)
													{
														View view10 = adoc.GetElement(elementId7) as View;
														if (view10 != null)
														{
															View view11 = origen.GetElement(el.eID) as View;
															if (view11 != null)
															{
																if (flag)
																{
																	try
																	{
																		if (!transform.Origin.IsAlmostEqualTo(XYZ.Zero))
																		{
																			ElementTransformUtils.MoveElement(adoc, TransferSingle.GetCropBoxFor(view10), transform.Origin);
																		}
																	}
																	catch
																	{
																	}
																	try
																	{
																		Line rotationAxisFromTransform2 = TransferSingle.GetRotationAxisFromTransform(transform);
																		double rotationAngleFromTransform2 = TransferSingle.GetRotationAngleFromTransform(transform);
																		if (rotationAngleFromTransform2 != 0.0)
																		{
																			ElementTransformUtils.RotateElement(adoc, TransferSingle.GetCropBoxFor(view10), rotationAxisFromTransform2, rotationAngleFromTransform2);
																		}
																	}
																	catch
																	{
																	}
																}
																this.matchPlantilla(origen, adoc, view11, view10);
																try
																{
																	if (this.chk_ViewElements.Checked)
																	{
																		this.ponDependientes(origen, collection9, view11, view10, copyPasteOptions);
																	}
																}
																catch
																{
																}
																try
																{
																	if (this.chk_Callout.Checked)
																	{
																		this.ponCallouts(origen, adoc, view11, view10, copyPasteOptions, this.chk_ViewElements.Checked, 3, flag, transform);
																	}
																}
																catch
																{
																}
															}
														}
													}
												}
												goto IL_195F;
											}
										}
										if (el.IsElevation)
										{
											ICollection<ElementId> collection10 = new List<ElementId>();
											collection10.Add(el.eID);
											if (el.IdsAdicionales.Count > 0)
											{
												foreach (ElementId item2 in el.IdsAdicionales)
												{
													collection10.Add(item2);
												}
											}
											ElevationMarker elevationMarker = origen.GetElement(el.eID) as ElevationMarker;
											if (elevationMarker == null)
											{
												continue;
											}
											ICollection<ElementId> collection11 = ElementTransformUtils.CopyElements(origen, collection10, adoc, null, copyPasteOptions);
											if (flag)
											{
												try
												{
													if (!transform.Origin.IsAlmostEqualTo(XYZ.Zero))
													{
														ElementTransformUtils.MoveElements(adoc, collection11, transform.Origin);
													}
												}
												catch
												{
												}
												try
												{
													Line rotationAxisFromTransform3 = TransferSingle.GetRotationAxisFromTransform(transform);
													double rotationAngleFromTransform3 = TransferSingle.GetRotationAngleFromTransform(transform);
													if (rotationAngleFromTransform3 != 0.0)
													{
														ElementTransformUtils.RotateElements(adoc, collection11, rotationAxisFromTransform3, rotationAngleFromTransform3);
													}
												}
												catch
												{
												}
											}
											ElementId elementId8 = collection11.FirstOrDefault<ElementId>();
											if (elementId8 != ElementId.InvalidElementId)
											{
												ElevationMarker elevationMarker2 = adoc.GetElement(elementId8) as ElevationMarker;
												if (elevationMarker2 != null)
												{
													for (int j = 0; j < elevationMarker.MaximumViewCount; j++)
													{
														ElementId viewId = elevationMarker.GetViewId(j);
														if (!(viewId == ElementId.InvalidElementId))
														{
															ElementId viewId2 = elevationMarker2.GetViewId(j);
															if (!(viewId2 == ElementId.InvalidElementId))
															{
																View view12 = origen.GetElement(viewId) as View;
																View view13 = adoc.GetElement(viewId2) as View;
																if (view12 != null && view13 != null)
																{
																	if (flag)
																	{
																		try
																		{
																			if (!transform.Origin.IsAlmostEqualTo(XYZ.Zero))
																			{
																				ElementTransformUtils.MoveElement(adoc, TransferSingle.GetCropBoxFor(view13), transform.Origin);
																			}
																		}
																		catch
																		{
																		}
																		try
																		{
																			Line rotationAxisFromTransform4 = TransferSingle.GetRotationAxisFromTransform(transform);
																			double rotationAngleFromTransform4 = TransferSingle.GetRotationAngleFromTransform(transform);
																			if (rotationAngleFromTransform4 != 0.0)
																			{
																				ElementTransformUtils.RotateElement(adoc, TransferSingle.GetCropBoxFor(view13), rotationAxisFromTransform4, rotationAngleFromTransform4);
																			}
																		}
																		catch
																		{
																		}
																		try
																		{
																			XYZ xyz3 = TransferSingle.DameVectorReposicionOrigenTransformada(view12, view13, transform);
																			if (!xyz3.IsAlmostEqualTo(XYZ.Zero))
																			{
																				ElementTransformUtils.MoveElement(adoc, TransferSingle.GetCropBoxFor(view13), xyz3);
																			}
																		}
																		catch
																		{
																		}
																	}
																	this.matchPlantilla(origen, adoc, view12, view13);
																	try
																	{
																		if (this.chk_ViewElements.Checked)
																		{
																			this.ponDependientes(origen, view12.GetDependentElements(null), view12, view13, copyPasteOptions);
																		}
																	}
																	catch
																	{
																	}
																	try
																	{
																		if (this.chk_Callout.Checked)
																		{
																			this.ponCallouts(origen, adoc, view12, view13, copyPasteOptions, this.chk_ViewElements.Checked, 3, flag, transform);
																		}
																	}
																	catch
																	{
																	}
																}
															}
														}
													}
												}
											}
										}
										else if (el.PasteEntreVistas)
										{
											ICollection<ElementId> collection12 = new List<ElementId>();
											collection12.Add(el.eID);
											if (el.IdsAdicionales.Count > 0)
											{
												foreach (ElementId item3 in el.IdsAdicionales)
												{
													collection12.Add(item3);
												}
											}
											ElementTransformUtils.CopyElements(origen.ActiveView, collection12, adoc.ActiveView, null, copyPasteOptions);
										}
										else
										{
											ICollection<ElementId> collection13 = new List<ElementId>();
											collection13.Add(el.eID);
											if (el.IdsAdicionales.Count > 0)
											{
												foreach (ElementId item4 in el.IdsAdicionales)
												{
													collection13.Add(item4);
												}
											}
											ICollection<ElementId> collection14 = ElementTransformUtils.CopyElements(origen, collection13, adoc, null, copyPasteOptions);
											if (flag)
											{
												try
												{
													if (!transform.Origin.IsAlmostEqualTo(XYZ.Zero))
													{
														ElementTransformUtils.MoveElements(adoc, collection14, transform.Origin);
													}
												}
												catch
												{
												}
												try
												{
													Line rotationAxisFromTransform5 = TransferSingle.GetRotationAxisFromTransform(transform);
													double rotationAngleFromTransform5 = TransferSingle.GetRotationAngleFromTransform(transform);
													if (rotationAngleFromTransform5 != 0.0)
													{
														ElementTransformUtils.RotateElements(adoc, collection14, rotationAxisFromTransform5, rotationAngleFromTransform5);
													}
												}
												catch
												{
												}
											}
										}
									}
								}
								IL_195F:
								num2++;
							}
							catch (Exception ex2)
							{
								num++;
								if (el.Categoria.Equals("Worksets"))
								{
									this.est.LogTxt.Add(string.Concat(new string[]
									{
										"\tERROR transferring element: ",
										el.Nombre,
										" (",
										el.Categoria,
										"/",
										el.Familia,
										"/",
										el.Tipo,
										") (wid:",
										el.wID.ToString(),
										") Exception: ",
										ex2.Message
									}));
								}
								else
								{
									this.est.LogTxt.Add(string.Concat(new string[]
									{
										"\tERROR transferring element: ",
										el.Nombre,
										" (",
										el.Categoria,
										"/",
										el.Familia,
										"/",
										el.Tipo,
										") (id:",
										el.eID.ToString(),
										") Exception: ",
										ex2.Message
									}));
								}
							}
							num4++;
						}
					}
				}
				if (transaction.Commit() == 3)
				{
					transaction.Dispose();
					if (this.foArchivos.CheckedObjects.Count > 1)
					{
						text = string.Concat(new string[]
						{
							text,
							adoc.Title,
							" - Transferred: ",
							(num2 - TransferSingle.usercancelled).ToString(),
							" - Errors: ",
							num.ToString(),
							" - User Cancelled: ",
							TransferSingle.usercancelled.ToString(),
							"\n"
						});
					}
					else
					{
						text = string.Concat(new string[]
						{
							text,
							adoc.Title,
							"\n\nTransferred: ",
							(num2 - TransferSingle.usercancelled).ToString(),
							"\nErrors: ",
							num.ToString(),
							"\nUser Cancelled: ",
							TransferSingle.usercancelled.ToString(),
							"\n\n"
						});
					}
				}
				else
				{
					text = text + adoc.Title + " Transaction was cancelled: 0 transfers done\n";
					this.est.LogTxt.Add("\tTransaction CANCELED, no trasnfers were done.");
				}
				num3++;
			}
			barraProgreso.Close();
			TaskDialog taskDialog = new TaskDialog("Transfer Single");
			taskDialog.MainInstruction = "Transfer Single";
			text += "View Log for details.";
			taskDialog.MainContent = text;
			taskDialog.CommonButtons = 32;
			taskDialog.DefaultButton = 8;
			taskDialog.Show();
			if (this.chk_AcceptAll.Checked)
			{
				this.app.DialogBoxShowing -= TransferSingle.UiAppOnDialogBoxShowing;
				this.app.Application.FailuresProcessing -= this.HandleFailures_Soft;
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000E6BC File Offset: 0x0000C8BC
		public void FiltraAntiguo()
		{
			ICollection<ElementId> collection = new List<ElementId>();
			foreach (object obj in this.tlElementos.CheckedObjects)
			{
				if (obj is Elemento)
				{
					Elemento elemento = obj as Elemento;
					collection.Add(elemento.eID);
				}
			}
			this.uidoc.Selection.SetElementIds(collection);
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000E750 File Offset: 0x0000C950
		private void CheckAllChildNodes(Nodo nod, bool nodeChecked)
		{
			foreach (Nodo nodo in nod.Nodos.Values)
			{
				nodo.Checked = nodeChecked;
				this.tlElementos.RefreshObject(nodo);
				if (nodo.Nodos.Count > 0 || nodo.Elementos.Count > 0)
				{
					this.CheckAllChildNodes(nodo, nodeChecked);
				}
			}
			foreach (Elemento elemento in nod.Elementos)
			{
				elemento.Checked = nodeChecked;
				this.tlElementos.RefreshObject(elemento);
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00002395 File Offset: 0x00000595
		private void tlElementos_ItemCheck(object sender, ItemCheckEventArgs e)
		{
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000E81C File Offset: 0x0000CA1C
		public void VistasTodoNada(bool estado)
		{
			this.tlElementos.BeginUpdate();
			foreach (Nodo nodo in this.est.Raices_Nodos)
			{
				nodo.Checked = estado;
				this.CheckAllChildNodes(nodo, estado);
			}
			this.tlElementos.EndUpdate();
			this.tlElementos.Refresh();
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000E898 File Offset: 0x0000CA98
		private void ExpandTodoNada(bool estado)
		{
			this.tlElementos.BeginUpdate();
			if (estado)
			{
				this.tlElementos.ExpandAll();
			}
			else
			{
				this.ColapsarHastaSegundo();
			}
			this.tlElementos.EndUpdate();
			this.tlElementos.Refresh();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000E8D4 File Offset: 0x0000CAD4
		private void ColapsarHastaSegundo()
		{
			foreach (Nodo nodo in this.est.Raices_Nodos)
			{
				this.tlElementos.Expand(nodo);
				foreach (KeyValuePair<string, Nodo> keyValuePair in nodo.Nodos)
				{
					this.tlElementos.Collapse(keyValuePair.Value);
					this.ColapsarSubNodos(keyValuePair.Value);
				}
			}
			this.tlElementos.Refresh();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000E98C File Offset: 0x0000CB8C
		private void ColapsarSubNodos(Nodo nod)
		{
			foreach (KeyValuePair<string, Nodo> keyValuePair in nod.Nodos)
			{
				this.tlElementos.Collapse(keyValuePair.Value);
				this.ColapsarSubNodos(keyValuePair.Value);
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000E9F4 File Offset: 0x0000CBF4
		private void ExpandTodos_MouseEnter(object sender, EventArgs e)
		{
			this.ExpandTodos.Image = Resources.ExpTodos_over;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000EA06 File Offset: 0x0000CC06
		private void ExpandTodos_MouseLeave(object sender, EventArgs e)
		{
			this.ExpandTodos.Image = Resources.ExpTodos;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000EA18 File Offset: 0x0000CC18
		private void ExpandTodos_MouseClick(object sender, MouseEventArgs e)
		{
			this.ExpandTodoNada(true);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000EA21 File Offset: 0x0000CC21
		private void ExpandNinguno_MouseEnter(object sender, EventArgs e)
		{
			this.ExpandNinguno.Image = Resources.ExpNinguno_over;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000EA33 File Offset: 0x0000CC33
		private void ExpandNinguno_MouseLeave(object sender, EventArgs e)
		{
			this.ExpandNinguno.Image = Resources.ExpNinguno;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000EA45 File Offset: 0x0000CC45
		private void ExpandNinguno_MouseClick(object sender, MouseEventArgs e)
		{
			this.ExpandTodoNada(false);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000EA4E File Offset: 0x0000CC4E
		private void vistasTodo_MouseEnter(object sender, EventArgs e)
		{
			this.vistasTodo.Image = Resources.SelTodos_over;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000EA60 File Offset: 0x0000CC60
		private void vistasTodo_MouseLeave(object sender, EventArgs e)
		{
			this.vistasTodo.Image = Resources.SelTodos;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000EA72 File Offset: 0x0000CC72
		private void vistasTodo_MouseClick(object sender, MouseEventArgs e)
		{
			this.VistasTodoNada(true);
			this.Contar();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000EA81 File Offset: 0x0000CC81
		private void vistasNada_MouseEnter(object sender, EventArgs e)
		{
			this.vistasNada.Image = Resources.SelNinguno_over;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000EA93 File Offset: 0x0000CC93
		private void vistasNada_MouseLeave(object sender, EventArgs e)
		{
			this.vistasNada.Image = Resources.SelNinguno;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000EAA5 File Offset: 0x0000CCA5
		private void vistasNada_MouseClick(object sender, MouseEventArgs e)
		{
			this.VistasTodoNada(false);
			this.Contar();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00002395 File Offset: 0x00000595
		private void rbModel_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000EAB4 File Offset: 0x0000CCB4
		private void Configuracion_MouseEnter(object sender, EventArgs e)
		{
			this.configuracion.Image = Resources.Config_Over;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000EAC6 File Offset: 0x0000CCC6
		private void Configuracion_MouseLeave(object sender, EventArgs e)
		{
			this.configuracion.Image = Resources.Config;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000EAD8 File Offset: 0x0000CCD8
		private void Configuracion_MouseClick(object sender, MouseEventArgs e)
		{
			new Configuration().ShowDialog();
			this.LeeConfiguracionesDelTab();
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000EAD8 File Offset: 0x0000CCD8
		private void Configuracion_ClickMenu(object sender, EventArgs e)
		{
			new Configuration().ShowDialog();
			this.LeeConfiguracionesDelTab();
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		private void About_ClickMenu(object sender, EventArgs e)
		{
			new About().ShowDialog();
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00002395 File Offset: 0x00000595
		private void tlElementos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00002395 File Offset: 0x00000595
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00002395 File Offset: 0x00000595
		private void txtSelection_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000EAF8 File Offset: 0x0000CCF8
		private void pOrigen_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.flag_ComboArchivos)
			{
				this.FiltraDestinos();
				this.CompruebaViabilidad();
				if (this.AnteriorOrigen == -1 || this.AnteriorOrigen != this.pOrigen.SelectedIndex)
				{
					Document doc_origen = this.DameDocDeTexto(this.pOrigen.SelectedItem.ToString());
					this.TomaElementosSeleccion(doc_origen, 0);
					this.ProcesaSeleccion();
					this.AnteriorOrigen = this.pOrigen.SelectedIndex;
				}
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000EB6C File Offset: 0x0000CD6C
		public Document DameDocDeTexto(string Nombre)
		{
			Document result = null;
			foreach (object obj in this.app.Application.Documents)
			{
				Document document = (Document)obj;
				if (Nombre.Equals(document.Title))
				{
					result = document;
					break;
				}
			}
			return result;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000EBE0 File Offset: 0x0000CDE0
		private void pDestino_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CompruebaViabilidad();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000EBE8 File Offset: 0x0000CDE8
		private void button1_Click(object sender, EventArgs e)
		{
			this.Contar();
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00002395 File Offset: 0x00000595
		private void tlElementos_MouseUp(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00002395 File Offset: 0x00000595
		private void tlElementos_ItemsChanged(object sender, ItemsChangedEventArgs e)
		{
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000EBF0 File Offset: 0x0000CDF0
		private void btVerLog_Click(object sender, EventArgs e)
		{
			LogEditor logEditor = new LogEditor();
			logEditor.ContenidoLog = this.est.LogTxt;
			logEditor.PonTexto();
			logEditor.ShowDialog();
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000EBE0 File Offset: 0x0000CDE0
		private void foArchivos_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			this.CompruebaViabilidad();
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000EBE0 File Offset: 0x0000CDE0
		private void foArchivos_Click(object sender, EventArgs e)
		{
			this.CompruebaViabilidad();
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000EBE0 File Offset: 0x0000CDE0
		private void foArchivos_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			this.CompruebaViabilidad();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000EC14 File Offset: 0x0000CE14
		private void TransferSingle_Load(object sender, EventArgs e)
		{
			base.Size = this.config.VentanaTamano;
			base.Location = this.config.VentanaPosicion;
			this.CompruebaUbicacionVentana();
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000EC3E File Offset: 0x0000CE3E
		private void TransferSingle_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.SalvaConfiguraciones();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000EC48 File Offset: 0x0000CE48
		public void CompruebaUbicacionVentana()
		{
			if (!Utiles.IsVisibleOnAnyScreen(new Rectangle(base.Location, base.Size)))
			{
				base.StartPosition = FormStartPosition.Manual;
				base.Size = new Size(490, 580);
				base.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - 245, Screen.PrimaryScreen.WorkingArea.Height / 2 - 290);
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000ECC8 File Offset: 0x0000CEC8
		private void pOrigen_MouseWheel(object sender, MouseEventArgs e)
		{
			if (!this.pOrigen.DroppedDown)
			{
				((HandledMouseEventArgs)e).Handled = true;
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00002395 File Offset: 0x00000595
		private void ExpandTodos_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000ECE4 File Offset: 0x0000CEE4
		private void clip_MouseClick(object sender, MouseEventArgs e)
		{
			string text = "";
			int num = 0;
			if (this.ElementosAFiltrar.Count<Elemento>() == 0)
			{
				return;
			}
			foreach (object obj in this.ElementosAFiltrar)
			{
				if (obj != null && obj is Elemento)
				{
					Elemento elemento = obj as Elemento;
					if (elemento.Checked)
					{
						if (num > 0)
						{
							text += "\n";
						}
						text += elemento.Nombre;
						num++;
					}
				}
			}
			Clipboard.SetText(text);
			TaskDialog.Show("Names to Clipboard", "Total Names to Clipboard: " + num.ToString());
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000EDA0 File Offset: 0x0000CFA0
		private void clip_MouseEnter(object sender, EventArgs e)
		{
			this.clip.Image = Resources.Clip_over;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000EDB2 File Offset: 0x0000CFB2
		private void clip_MouseLeave(object sender, EventArgs e)
		{
			this.clip.Image = Resources.Clip;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000EDC4 File Offset: 0x0000CFC4
		private void ClipId_MouseClick(object sender, MouseEventArgs e)
		{
			string text = "";
			int num = 0;
			if (this.ElementosAFiltrar == null)
			{
				return;
			}
			if (this.ElementosAFiltrar.Count<Elemento>() == 0)
			{
				return;
			}
			foreach (object obj in this.ElementosAFiltrar)
			{
				if (obj != null && obj is Elemento)
				{
					Elemento elemento = obj as Elemento;
					if (elemento != null && elemento.Checked)
					{
						if (num > 0)
						{
							text += ";";
						}
						string str = text;
						ElementId eID = elemento.eID;
						text = str + ((eID != null) ? eID.ToString() : null);
						num++;
					}
				}
			}
			if (num > 0)
			{
				Clipboard.SetText(text);
				TaskDialog.Show("Ids to Clipboard", "Total Ids to Clipboard: " + num.ToString());
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000EEA0 File Offset: 0x0000D0A0
		private void ClipId_MouseEnter(object sender, EventArgs e)
		{
			this.clipId.Image = Resources.Id_over;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000EEB2 File Offset: 0x0000D0B2
		private void ClipId_MouseLeave(object sender, EventArgs e)
		{
			this.clipId.Image = Resources.Id;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000EEC4 File Offset: 0x0000D0C4
		private void clip_MouseHover(object sender, EventArgs e)
		{
			new ToolTip().SetToolTip(this.clip, "Checked Names to Clipboard");
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000EEDB File Offset: 0x0000D0DB
		private void clipId_MouseHover(object sender, EventArgs e)
		{
			new ToolTip().SetToolTip(this.clipId, "Checked IDs to Clipboard");
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000EEF4 File Offset: 0x0000D0F4
		private void tlElementos_CellEditStarting(object sender, CellEditEventArgs e)
		{
			if (e.ListViewItem == null)
			{
				e.Cancel = true;
			}
			if (e.ListViewItem.RowObject is Nodo)
			{
				e.Cancel = true;
			}
			if (e.ListViewItem.RowObject is Elemento)
			{
				if (this.tlElementos.SelectedObject != null)
				{
					Elemento elemento = this.tlElementos.SelectedObject as Elemento;
					if (this.DameDocDeTexto(this.pOrigen.SelectedItem.ToString()).GetElement(elemento.eID) == null)
					{
						e.Cancel = true;
						return;
					}
				}
				else
				{
					e.Cancel = true;
				}
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000EF8C File Offset: 0x0000D18C
		private void tlElementos_CellEditFinishing(object sender, CellEditEventArgs e)
		{
			string text = e.Value.ToString();
			string value = e.NewValue.ToString();
			Elemento elemento = this.tlElementos.SelectedObject as Elemento;
			if (elemento == null)
			{
				e.NewValue = e.Value;
				return;
			}
			if (text.Equals(value))
			{
				return;
			}
			Document document = this.DameDocDeTexto(this.pOrigen.SelectedItem.ToString());
			Element element = document.GetElement(elemento.eID);
			if (element == null)
			{
				return;
			}
			using (Transaction transaction = new Transaction(document, "TS Rename Element"))
			{
				if (transaction.Start("TS Rename Element") == 1)
				{
					try
					{
						element.Name = e.NewValue.ToString();
						elemento.Nombre = e.NewValue.ToString();
					}
					catch
					{
						MessageBox.Show("Can't Rename Element");
						transaction.RollBack();
						return;
					}
				}
				transaction.Commit();
			}
			this.tlElementos.RefreshObject(e);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000F09C File Offset: 0x0000D29C
		private void tlElementos_CellRightClick(object sender, CellRightClickEventArgs e)
		{
			e.MenuStrip = this.menuElements;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000F0AA File Offset: 0x0000D2AA
		private void FindAndReplacecheckedToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.FindAndReplaceChecked();
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000F0B2 File Offset: 0x0000D2B2
		private void FindselectedToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.FindAndReplaceSelected(sender, e);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000F0BC File Offset: 0x0000D2BC
		private void DeletecheckedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.DeleteChecked();
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000F0C4 File Offset: 0x0000D2C4
		private void deleteselectedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.DeleteSelected(sender, e);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000F0D0 File Offset: 0x0000D2D0
		private void NamescheckedElementsToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			string text = "";
			int num = 0;
			if (this.ElementosAFiltrar.Count<Elemento>() == 0)
			{
				return;
			}
			foreach (object obj in this.ElementosAFiltrar)
			{
				if (obj != null && obj is Elemento)
				{
					Elemento elemento = obj as Elemento;
					if (elemento.Checked)
					{
						if (num > 0)
						{
							text += "\n";
						}
						text += elemento.Nombre;
						num++;
					}
				}
			}
			Clipboard.SetText(text);
			if (!this.HideMessages)
			{
				TaskDialog.Show("Names to Clipboard", "Total Names to Clipboard: " + num.ToString());
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000F194 File Offset: 0x0000D394
		private void NamesselectedElementsToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			string text = "";
			int num = 0;
			IList selectedIndices = this.tlElementos.SelectedIndices;
			if (selectedIndices.Count == 0)
			{
				return;
			}
			foreach (object obj in selectedIndices)
			{
				int num2 = (int)obj;
				Elemento elemento = this.tlElementos.GetModelObject(num2) as Elemento;
				if (elemento != null)
				{
					if (num > 0)
					{
						text += "\n";
					}
					text += elemento.Nombre;
					num++;
				}
			}
			Clipboard.SetText(text);
			if (!this.HideMessages)
			{
				TaskDialog.Show("Names to Clipboard", "Total Names to Clipboard: " + num.ToString());
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000F268 File Offset: 0x0000D468
		private void IDscheckedElementsToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			string text = "";
			int num = 0;
			if (this.ElementosAFiltrar == null)
			{
				return;
			}
			if (this.ElementosAFiltrar.Count<Elemento>() == 0)
			{
				return;
			}
			foreach (object obj in this.ElementosAFiltrar)
			{
				if (obj != null && obj is Elemento)
				{
					Elemento elemento = obj as Elemento;
					if (elemento != null && elemento.Checked)
					{
						if (num > 0)
						{
							text += ";";
						}
						string str = text;
						ElementId eID = elemento.eID;
						text = str + ((eID != null) ? eID.ToString() : null);
						num++;
					}
				}
			}
			if (num > 0)
			{
				Clipboard.SetText(text);
				if (!this.HideMessages)
				{
					TaskDialog.Show("Ids to Clipboard", "Total Ids to Clipboard: " + num.ToString());
				}
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000F34C File Offset: 0x0000D54C
		private void IDsselectedElementsToolStripMenuItem6_Click(object sender, EventArgs e)
		{
			string text = "";
			int num = 0;
			IList selectedIndices = this.tlElementos.SelectedIndices;
			if (selectedIndices.Count == 0)
			{
				return;
			}
			foreach (object obj in selectedIndices)
			{
				int num2 = (int)obj;
				Elemento elemento = this.tlElementos.GetModelObject(num2) as Elemento;
				if (elemento != null)
				{
					if (num > 0)
					{
						text += ";";
					}
					string str = text;
					ElementId eID = elemento.eID;
					text = str + ((eID != null) ? eID.ToString() : null);
					num++;
				}
			}
			Clipboard.SetText(text);
			if (!this.HideMessages)
			{
				TaskDialog.Show("Ids to Clipboard", "Total Ids to Clipboard: " + num.ToString());
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00002395 File Offset: 0x00000595
		private void tlElementos_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000F42C File Offset: 0x0000D62C
		private void tlElementos_ItemCheck_1(object sender, ItemCheckEventArgs e)
		{
			this.tlElementos.BeginUpdate();
			object modelObject = this.tlElementos.GetModelObject(e.Index);
			bool flag = e.NewValue.ToString().Equals("Checked");
			if (modelObject is Nodo)
			{
				Nodo nod = modelObject as Nodo;
				this.CheckAllChildNodes(nod, flag);
			}
			else
			{
				(modelObject as Elemento).Checked = flag;
			}
			this.tlElementos.EndUpdate();
			this.tlElementos.Refresh();
			this.Contar();
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000F4BF File Offset: 0x0000D6BF
		private void AddPrefixchekedElemensToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.AddTextCheked(1);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000F4C8 File Offset: 0x0000D6C8
		private void AddPrefixselectedElementsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.AddTextSelected(sender, e, 1);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000F4D3 File Offset: 0x0000D6D3
		private void AddSuffixcheckedElementsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.AddTextCheked(2);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000F4DC File Offset: 0x0000D6DC
		private void AddSuffixselectedElementsToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.AddTextSelected(sender, e, 2);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000F4E7 File Offset: 0x0000D6E7
		private void UppercheckedElementsToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.ChangeCaseChecked(1);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000F4F0 File Offset: 0x0000D6F0
		private void UpperselectedElementsToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			this.ChangeCaseSelected(sender, e, 1);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000F4FB File Offset: 0x0000D6FB
		private void lowercasecheckedElementsToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			this.ChangeCaseChecked(2);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000F504 File Offset: 0x0000D704
		private void lowecaseselectedElementsToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			this.ChangeCaseSelected(sender, e, 2);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0000F50F File Offset: 0x0000D70F
		private void propercasecheckedElementsToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			this.ChangeCaseChecked(3);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000F518 File Offset: 0x0000D718
		private void propercaseselectedElementsToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			this.ChangeCaseSelected(sender, e, 3);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000F524 File Offset: 0x0000D724
		public void ChangeCaseChecked(int tipo)
		{
			if (this.ElementosAFiltrar.Count<Elemento>() == 0)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			Document document = this.DameDocDeTexto(this.pOrigen.SelectedItem.ToString());
			if (this.pOrigen.SelectedItem.ToString().Equals(""))
			{
				return;
			}
			string text = "";
			if (tipo == 1)
			{
				text = "TS UPPER Case";
			}
			else if (tipo == 2)
			{
				text = "TS lower Case";
			}
			else
			{
				if (tipo != 3)
				{
					return;
				}
				text = "TS Proper Case";
			}
			using (Transaction transaction = new Transaction(document, text))
			{
				if (transaction.Start(text) == 1)
				{
					foreach (object obj in this.ElementosAFiltrar)
					{
						if (obj != null && obj is Elemento)
						{
							Elemento elemento = obj as Elemento;
							if (elemento.Checked)
							{
								num++;
								string text2 = "";
								if (tipo == 1)
								{
									text2 = elemento.Nombre.ToUpper();
								}
								if (tipo == 2)
								{
									text2 = elemento.Nombre.ToLower();
								}
								if (tipo == 3)
								{
									text2 = this.ProperCaseConNumeros(elemento.Nombre);
								}
								if (!elemento.Nombre.Equals(text2))
								{
									Element element = document.GetElement(elemento.eID);
									if (element != null)
									{
										try
										{
											element.Name = text2;
											num2++;
											elemento.Nombre = text2;
										}
										catch
										{
										}
									}
								}
							}
						}
					}
				}
				transaction.Commit();
			}
			if (!this.HideMessages)
			{
				TaskDialog.Show(text, "Total Elements Changed: " + num2.ToString() + "\nNot Changed, with Errors or Ignored: " + (num - num2).ToString());
			}
			if (num2 > 0)
			{
				this.tlElementos.Refresh();
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000F718 File Offset: 0x0000D918
		public void ChangeCaseSelected(object sender, EventArgs e, int tipo)
		{
			int num = 0;
			int num2 = 0;
			Document document = this.DameDocDeTexto(this.pOrigen.SelectedItem.ToString());
			if (this.pOrigen.SelectedItem.ToString().Equals(""))
			{
				return;
			}
			string text = "";
			if (tipo == 1)
			{
				text = "TS UPPER Case";
			}
			else if (tipo == 2)
			{
				text = "TS lower Case";
			}
			else
			{
				if (tipo != 3)
				{
					return;
				}
				text = "TS Proper Case";
			}
			IList selectedIndices = this.tlElementos.SelectedIndices;
			if (selectedIndices.Count == 0)
			{
				return;
			}
			using (Transaction transaction = new Transaction(document, text))
			{
				if (transaction.Start(text) == 1)
				{
					foreach (object obj in selectedIndices)
					{
						int num3 = (int)obj;
						Elemento elemento = this.tlElementos.GetModelObject(num3) as Elemento;
						if (elemento != null)
						{
							string text2 = "";
							num++;
							if (tipo == 1)
							{
								text2 = elemento.Nombre.ToUpper();
							}
							if (tipo == 2)
							{
								text2 = elemento.Nombre.ToLower();
							}
							if (tipo == 3)
							{
								text2 = this.ProperCaseConNumeros(elemento.Nombre);
							}
							if (!elemento.Nombre.Equals(text2))
							{
								Element element = document.GetElement(elemento.eID);
								if (element != null)
								{
									try
									{
										element.Name = text2;
										num2++;
										elemento.Nombre = text2;
									}
									catch
									{
									}
								}
							}
						}
					}
				}
				transaction.Commit();
			}
			if (!this.HideMessages)
			{
				TaskDialog.Show(text, "Total Elements Changed: " + num2.ToString() + "\nNot Changed, with Errors or Ignored: " + (num - num2).ToString());
			}
			if (num2 > 0)
			{
				this.tlElementos.Refresh();
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000F910 File Offset: 0x0000DB10
		public void DeleteChecked()
		{
			int num = 0;
			int num2 = 0;
			if (this.ElementosAFiltrar.Count<Elemento>() == 0)
			{
				return;
			}
			Document document = this.DameDocDeTexto(this.pOrigen.SelectedItem.ToString());
			List<Elemento> list = new List<Elemento>();
			using (Transaction transaction = new Transaction(document, "TS Delete Elements"))
			{
				if (transaction.Start("TS Delete Elements") == 1)
				{
					foreach (object obj in this.ElementosAFiltrar)
					{
						if (obj != null && obj is Elemento)
						{
							Elemento elemento = obj as Elemento;
							if (elemento.Checked)
							{
								num++;
								try
								{
									document.Delete(elemento.eID);
									num2++;
									list.Add(elemento);
								}
								catch
								{
								}
							}
						}
					}
				}
				transaction.Commit();
			}
			if (num2 > 0)
			{
				this.tlElementos.BeginUpdate();
				List<object> list2 = new List<object>();
				foreach (Elemento elemento2 in list)
				{
					Nodo padre = elemento2.Padre;
					if (!list2.Contains(padre))
					{
						list2.Add(padre);
					}
					padre.Elementos.Remove(elemento2);
				}
				foreach (Elemento item in list)
				{
					this.ElementosAFiltrar.Remove(item);
				}
				this.tlElementos.EndUpdate();
				this.tlElementos.Refresh();
				this.Contar2();
				this.UpdateAllNodos();
			}
			if (!this.HideMessages)
			{
				TaskDialog.Show("Delete Elements", "Total Elements Deleted: " + num2.ToString() + "\nElements with Errors or Ignored: " + (num - num2).ToString());
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000FB34 File Offset: 0x0000DD34
		public void UpdateAllNodos()
		{
			foreach (object obj in this.tlElementos.Objects)
			{
				if (obj is Nodo)
				{
					this.tlElementos.UpdateObject(obj);
				}
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000FB9C File Offset: 0x0000DD9C
		public void DeleteSelected(object sender, EventArgs e)
		{
			int num = 0;
			int num2 = 0;
			IList selectedIndices = this.tlElementos.SelectedIndices;
			if (selectedIndices.Count == 0)
			{
				return;
			}
			IList<Elemento> list = new List<Elemento>();
			Document document = this.DameDocDeTexto(this.pOrigen.SelectedItem.ToString());
			using (Transaction transaction = new Transaction(document, "TS Delete Elements"))
			{
				if (transaction.Start("TS Delete Elements") == 1)
				{
					foreach (object obj in selectedIndices)
					{
						int num3 = (int)obj;
						Elemento elemento = this.tlElementos.GetModelObject(num3) as Elemento;
						if (elemento != null)
						{
							num++;
							try
							{
								document.Delete(elemento.eID);
								num2++;
								list.Add(elemento);
							}
							catch
							{
							}
						}
					}
				}
				transaction.Commit();
			}
			if (!this.HideMessages)
			{
				TaskDialog.Show("Delete Elements", "Total Elements Deleted: " + num2.ToString() + "\nElements with Errors or Ignored: " + (num - num2).ToString());
			}
			if (num2 > 0)
			{
				this.tlElementos.BeginUpdate();
				List<object> list2 = new List<object>();
				foreach (Elemento elemento2 in list)
				{
					Nodo padre = elemento2.Padre;
					if (!list2.Contains(padre))
					{
						list2.Add(padre);
					}
					padre.Elementos.Remove(elemento2);
				}
				foreach (Elemento item in list)
				{
					this.ElementosAFiltrar.Remove(item);
				}
				this.tlElementos.EndUpdate();
				this.tlElementos.Refresh();
				this.Contar2();
				this.UpdateAllNodos();
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000FDC8 File Offset: 0x0000DFC8
		public void FindAndReplaceChecked()
		{
			if (this.ElementosAFiltrar.Count<Elemento>() == 0)
			{
				return;
			}
			new RenameText().ShowDialog();
			if (RenameText.cancelado)
			{
				return;
			}
			string textofind_out = RenameText.textofind_out;
			string textoreplace_out = RenameText.textoreplace_out;
			bool usaregex = RenameText.usaregex;
			int num = 0;
			int num2 = 0;
			Document document = this.DameDocDeTexto(this.pOrigen.SelectedItem.ToString());
			using (Transaction transaction = new Transaction(document, "TS Find and Replace"))
			{
				if (transaction.Start("TS Find and Replace") == 1)
				{
					foreach (object obj in this.ElementosAFiltrar)
					{
						if (obj != null && obj is Elemento)
						{
							Elemento elemento = obj as Elemento;
							if (elemento.Checked)
							{
								num++;
								string text = elemento.Nombre;
								if (!usaregex)
								{
									text = elemento.Nombre.Replace(textofind_out, textoreplace_out);
								}
								else
								{
									text = Regex.Replace(elemento.Nombre, textofind_out, textoreplace_out);
								}
								if (!text.Equals(elemento.Nombre))
								{
									Element element = document.GetElement(elemento.eID);
									if (element != null)
									{
										try
										{
											element.Name = text;
											num2++;
											elemento.Nombre = text;
										}
										catch
										{
										}
									}
								}
							}
						}
					}
				}
				transaction.Commit();
			}
			if (!this.HideMessages)
			{
				TaskDialog.Show("Find and Replace", "Total Elements Replaced: " + num2.ToString() + "\nNot Changed, with Errors or Ignored: " + (num - num2).ToString());
			}
			if (num2 > 0)
			{
				this.tlElementos.Refresh();
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000FF98 File Offset: 0x0000E198
		public void FindAndReplaceSelected(object sender, EventArgs e)
		{
			new RenameText().ShowDialog();
			if (RenameText.cancelado)
			{
				return;
			}
			string textofind_out = RenameText.textofind_out;
			string textoreplace_out = RenameText.textoreplace_out;
			bool usaregex = RenameText.usaregex;
			int num = 0;
			int num2 = 0;
			IList selectedIndices = this.tlElementos.SelectedIndices;
			if (selectedIndices.Count == 0)
			{
				return;
			}
			Document document = this.DameDocDeTexto(this.pOrigen.SelectedItem.ToString());
			using (Transaction transaction = new Transaction(document, "TS Find and Replace"))
			{
				if (transaction.Start("TS Find and Replace") == 1)
				{
					foreach (object obj in selectedIndices)
					{
						int num3 = (int)obj;
						Elemento elemento = this.tlElementos.GetModelObject(num3) as Elemento;
						if (elemento != null)
						{
							num++;
							string text = elemento.Nombre;
							if (!usaregex)
							{
								text = elemento.Nombre.Replace(textofind_out, textoreplace_out);
							}
							else
							{
								text = Regex.Replace(elemento.Nombre, textofind_out, textoreplace_out);
							}
							if (!text.Equals(elemento.Nombre))
							{
								Element element = document.GetElement(elemento.eID);
								if (element != null)
								{
									try
									{
										element.Name = text;
										num2++;
										elemento.Nombre = text;
									}
									catch
									{
									}
								}
							}
						}
					}
				}
				transaction.Commit();
			}
			if (!this.HideMessages)
			{
				TaskDialog.Show("Find and Replace", "Total Elements Replaced: " + num2.ToString() + "\nNot Changed, with Errors or Ignored: " + (num - num2).ToString());
			}
			if (num2 > 0)
			{
				this.tlElementos.Refresh();
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00010170 File Offset: 0x0000E370
		public void AddTextCheked(int tipo)
		{
			if (this.ElementosAFiltrar.Count<Elemento>() == 0)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			Document document = this.DameDocDeTexto(this.pOrigen.SelectedItem.ToString());
			if (this.pOrigen.SelectedItem.ToString().Equals(""))
			{
				return;
			}
			string text = "";
			if (tipo == 1)
			{
				text = "TS Add Prefix";
			}
			else
			{
				if (tipo != 2)
				{
					return;
				}
				text = "TS Add Suffix";
			}
			new TakeText
			{
				Text = text
			}.ShowDialog();
			if (TakeText.cancelado)
			{
				return;
			}
			string texto_out = TakeText.texto_out;
			if (texto_out.Equals(""))
			{
				return;
			}
			using (Transaction transaction = new Transaction(document, text))
			{
				if (transaction.Start(text) == 1)
				{
					foreach (object obj in this.ElementosAFiltrar)
					{
						if (obj != null && obj is Elemento)
						{
							Elemento elemento = obj as Elemento;
							if (elemento.Checked)
							{
								string text2 = "";
								num++;
								if (tipo == 1)
								{
									text2 = texto_out + elemento.Nombre;
								}
								if (tipo == 2)
								{
									text2 = elemento.Nombre + texto_out;
								}
								Element element = document.GetElement(elemento.eID);
								if (element != null)
								{
									try
									{
										element.Name = text2;
										num2++;
										elemento.Nombre = text2;
									}
									catch
									{
									}
								}
							}
						}
					}
				}
				transaction.Commit();
			}
			if (!this.HideMessages)
			{
				TaskDialog.Show(text, "Total Elements Changed: " + num2.ToString() + "\nNot Changed, with Errors or Ignored: " + (num - num2).ToString());
			}
			if (num2 > 0)
			{
				this.tlElementos.Refresh();
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00010360 File Offset: 0x0000E560
		public void AddTextSelected(object sender, EventArgs e, int tipo)
		{
			int num = 0;
			int num2 = 0;
			Document document = this.DameDocDeTexto(this.pOrigen.SelectedItem.ToString());
			if (this.pOrigen.SelectedItem.ToString().Equals(""))
			{
				return;
			}
			string text = "";
			if (tipo == 1)
			{
				text = "TS Add Prefix";
			}
			else
			{
				if (tipo != 2)
				{
					return;
				}
				text = "TS Add Suffix";
			}
			new TakeText
			{
				Text = text
			}.ShowDialog();
			if (TakeText.cancelado)
			{
				return;
			}
			string texto_out = TakeText.texto_out;
			if (texto_out.Equals(""))
			{
				return;
			}
			IList selectedIndices = this.tlElementos.SelectedIndices;
			if (selectedIndices.Count == 0)
			{
				return;
			}
			using (Transaction transaction = new Transaction(document, text))
			{
				if (transaction.Start(text) == 1)
				{
					foreach (object obj in selectedIndices)
					{
						int num3 = (int)obj;
						Elemento elemento = this.tlElementos.GetModelObject(num3) as Elemento;
						if (elemento != null)
						{
							string text2 = "";
							num++;
							if (tipo == 1)
							{
								text2 = texto_out + elemento.Nombre;
							}
							if (tipo == 2)
							{
								text2 = elemento.Nombre + texto_out;
							}
							Element element = document.GetElement(elemento.eID);
							if (element != null)
							{
								try
								{
									element.Name = text2;
									num2++;
									elemento.Nombre = text2;
								}
								catch
								{
								}
							}
						}
					}
				}
				transaction.Commit();
			}
			if (!this.HideMessages)
			{
				TaskDialog.Show(text, "Total Elements Changed: " + num2.ToString() + "\nNot Changed, with Errors or Ignored: " + (num - num2).ToString());
			}
			if (num2 > 0)
			{
				this.tlElementos.Refresh();
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0001055C File Offset: 0x0000E75C
		public string ProperCaseConNumeros(string text)
		{
			string[] array = text.Split(new char[]
			{
				' '
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (!Regex.IsMatch(array[i], "^\\d+"))
				{
					array[i] = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(array[i].ToLower());
				}
			}
			return string.Join(" ", array);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00002395 File Offset: 0x00000595
		private void configuracion_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000F0BC File Offset: 0x0000D2BC
		private void bt_Delete_Click(object sender, EventArgs e)
		{
			this.DeleteChecked();
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000F0AA File Offset: 0x0000D2AA
		private void bt_FindReplace_Click(object sender, EventArgs e)
		{
			this.FindAndReplaceChecked();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000F4BF File Offset: 0x0000D6BF
		private void bt_AddPrefix_Click(object sender, EventArgs e)
		{
			this.AddTextCheked(1);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000F4D3 File Offset: 0x0000D6D3
		private void bt_AddSuffix_Click(object sender, EventArgs e)
		{
			this.AddTextCheked(2);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000F4E7 File Offset: 0x0000D6E7
		private void button1_Click_1(object sender, EventArgs e)
		{
			this.ChangeCaseChecked(1);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000F4FB File Offset: 0x0000D6FB
		private void button2_Click(object sender, EventArgs e)
		{
			this.ChangeCaseChecked(2);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000F50F File Offset: 0x0000D70F
		private void button3_Click(object sender, EventArgs e)
		{
			this.ChangeCaseChecked(3);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00002395 File Offset: 0x00000595
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000105C4 File Offset: 0x0000E7C4
		private void Search_Click(object sender, EventArgs e)
		{
			if (this.ElementosAFiltrar.Count == 0)
			{
				return;
			}
			if (this.textBusca.Text.Equals(""))
			{
				return;
			}
			if (!this.textBusca.Text.Equals(this.lastText))
			{
				this.lastfound = null;
			}
			this.lastText = this.textBusca.Text;
			bool flag = true;
			bool flag2 = false;
			if (this.lastfound == null)
			{
				flag = false;
			}
			foreach (object obj in this.ElementosAFiltrar)
			{
				if (flag)
				{
					if (obj == this.lastfound)
					{
						flag = false;
					}
				}
				else if (obj != null && obj is Elemento && (obj as Elemento).Nombre.Contains(this.textBusca.Text))
				{
					this.tlElementos.Reveal(obj, true);
					this.lastfound = obj;
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				this.lastfound = null;
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000106C8 File Offset: 0x0000E8C8
		public void ponDependientes(Document origen, ICollection<ElementId> dependientes, View vistaorigen, View vistadestino, CopyPasteOptions copyOptions)
		{
			ICollection<ElementId> collection = new List<ElementId>();
			foreach (ElementId elementId in dependientes)
			{
				Element element = origen.GetElement(elementId);
				if (element != null && !(element is View) && !(element is SunAndShadowSettings) && !(element is Level) && !(element is Viewport) && !(element is SketchPlane))
				{
					if (element is IndependentTag && element.OwnerViewId == vistaorigen.Id)
					{
						collection.Add(elementId);
					}
					if (element is AreaTag && element.OwnerViewId == vistaorigen.Id)
					{
						collection.Add(elementId);
					}
					if (element is RoomTag && element.OwnerViewId == vistaorigen.Id)
					{
						collection.Add(elementId);
					}
					if (element is DetailLine && element.OwnerViewId == vistaorigen.Id)
					{
						collection.Add(elementId);
					}
					if (element is DetailArc && element.OwnerViewId == vistaorigen.Id)
					{
						collection.Add(elementId);
					}
					if (element is DetailCurve && element.OwnerViewId == vistaorigen.Id)
					{
						collection.Add(elementId);
					}
					if (element is DetailEllipse && element.OwnerViewId == vistaorigen.Id)
					{
						collection.Add(elementId);
					}
					if (element is TextNote && element.OwnerViewId == vistaorigen.Id)
					{
						collection.Add(elementId);
					}
					if (element is FilledRegion && element.OwnerViewId == vistaorigen.Id)
					{
						collection.Add(elementId);
					}
					if (element is Dimension && element.OwnerViewId == vistaorigen.Id)
					{
						collection.Add(elementId);
					}
					if (element is AnnotationSymbol && element.OwnerViewId == vistaorigen.Id)
					{
						collection.Add(elementId);
					}
					if (element is FamilyInstance && element.OwnerViewId == vistaorigen.Id)
					{
						collection.Add(elementId);
					}
				}
			}
			try
			{
				ElementTransformUtils.CopyElements(vistaorigen, collection, vistadestino, Transform.Identity, copyOptions);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00010930 File Offset: 0x0000EB30
		public void ponCallouts(Document origen, Document destino, View vistaorigen, View vistadestino, CopyPasteOptions copyOptions, bool CopiaDetalles, int Contador)
		{
			foreach (ElementId elementId in vistaorigen.GetDependentElements(null))
			{
				Element elem = origen.GetElement(elementId);
				if (elem != null && elem is View && elem.Id != vistaorigen.Id)
				{
					if (((ICollection<ElementId>)(from View i in new FilteredElementCollector(origen).OfClass(typeof(View))
					where i.GetDependentElements(null).Contains(elem.Id)
					select i.Id).ToList<ElementId>()).Count < Contador)
					{
						ICollection<ElementId> source = ElementTransformUtils.CopyElements(vistaorigen, new List<ElementId>
						{
							elem.Id
						}, vistadestino, null, copyOptions);
						View view = destino.GetElement(source.FirstOrDefault<ElementId>()) as View;
						View view2 = origen.GetElement(elem.Id) as View;
						if (view != null && view2 != null)
						{
							if (CopiaDetalles)
							{
								this.ponDependientes(origen, vistaorigen.GetDependentElements(null), view2, view, copyOptions);
							}
							this.ponCallouts(origen, destino, view2, view, copyOptions, CopiaDetalles, Contador + 1);
						}
					}
				}
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00010AB4 File Offset: 0x0000ECB4
		public void ponCallouts(Document origen, Document destino, View vistaorigen, View vistadestino, CopyPasteOptions copyOptions, bool CopiaDetalles, int Contador, bool transforma, Transform T)
		{
			foreach (ElementId elementId in vistaorigen.GetDependentElements(null))
			{
				Element elem = origen.GetElement(elementId);
				if (elem != null && elem is View && elem.Id != vistaorigen.Id)
				{
					if (((ICollection<ElementId>)(from View i in new FilteredElementCollector(origen).OfClass(typeof(View))
					where i.GetDependentElements(null).Contains(elem.Id)
					select i.Id).ToList<ElementId>()).Count < Contador)
					{
						ICollection<ElementId> source = ElementTransformUtils.CopyElements(vistaorigen, new List<ElementId>
						{
							elem.Id
						}, vistadestino, null, copyOptions);
						View view = destino.GetElement(source.FirstOrDefault<ElementId>()) as View;
						View view2 = origen.GetElement(elem.Id) as View;
						if (view != null && view2 != null)
						{
							if (transforma)
							{
								try
								{
									if (!T.Origin.IsAlmostEqualTo(XYZ.Zero))
									{
										ElementTransformUtils.MoveElement(destino, TransferSingle.GetCropBoxFor(view), T.Origin);
									}
								}
								catch
								{
								}
								try
								{
									Line rotationAxisFromTransform = TransferSingle.GetRotationAxisFromTransform(T);
									double rotationAngleFromTransform = TransferSingle.GetRotationAngleFromTransform(T);
									if (rotationAngleFromTransform != 0.0)
									{
										ElementTransformUtils.RotateElement(destino, TransferSingle.GetCropBoxFor(view), rotationAxisFromTransform, rotationAngleFromTransform);
									}
								}
								catch
								{
								}
								try
								{
									XYZ xyz = TransferSingle.DameVectorReposicionOrigenTransformada(view2, view, T);
									if (!xyz.IsAlmostEqualTo(XYZ.Zero))
									{
										ElementTransformUtils.MoveElement(destino, TransferSingle.GetCropBoxFor(view), xyz);
									}
								}
								catch
								{
								}
							}
							if (CopiaDetalles)
							{
								this.ponDependientes(origen, vistaorigen.GetDependentElements(null), view2, view, copyOptions);
							}
							this.ponCallouts(origen, destino, view2, view, copyOptions, CopiaDetalles, Contador + 1, transforma, T);
						}
					}
				}
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00010D24 File Offset: 0x0000EF24
		public void matchPlantilla(Document origen, Document destino, View vistaorigen, View vistadestino)
		{
			if (vistaorigen.ViewTemplateId == ElementId.InvalidElementId)
			{
				return;
			}
			View view = origen.GetElement(vistaorigen.ViewTemplateId) as View;
			string tName = view.Name;
			IList<ElementId> list = (from View i in new FilteredElementCollector(destino).OfClass(typeof(View))
			where i.IsTemplate
			select i into v
			where v.Name.Equals(tName)
			select v into i
			select i.Id).ToList<ElementId>();
			if (list.Count > 0)
			{
				ElementId viewTemplateId = list.FirstOrDefault<ElementId>();
				try
				{
					vistadestino.ViewTemplateId = viewTemplateId;
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00010E10 File Offset: 0x0000F010
		private void chk_Links_CheckedChanged(object sender, EventArgs e)
		{
			this.flag_ComboArchivos = false;
			if (this.pOrigen.SelectedIndex > -1)
			{
				string text = this.pOrigen.Text;
				this.ListaArchivosAbiertos();
				if (this.pOrigen.Items.Contains(text))
				{
					this.pOrigen.SelectedIndex = this.pOrigen.FindStringExact(text);
				}
				else
				{
					this.tlElementos.ClearObjects();
				}
				this.FiltraDestinos();
			}
			else
			{
				this.ListaArchivosAbiertos();
			}
			this.CompruebaViabilidad();
			this.flag_ComboArchivos = true;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00010E9C File Offset: 0x0000F09C
		private void tlElementos_FormatCell(object sender, FormatCellEventArgs e)
		{
			if (e.Model is Elemento && ((Elemento)e.Model).NoTransferible)
			{
				e.SubItem.ForeColor = Color.Red;
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00010ED0 File Offset: 0x0000F0D0
		private static Line GetRotationAxisFromTransform(Transform transform)
		{
			double num = transform.BasisY.Z - transform.BasisZ.Y;
			double num2 = transform.BasisZ.X - transform.BasisX.Z;
			double num3 = transform.BasisX.Y - transform.BasisY.X;
			return Line.CreateUnbound(transform.Origin, new XYZ(num, num2, num3));
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00010F38 File Offset: 0x0000F138
		private static double GetRotationAngleFromTransform(Transform transform)
		{
			double x = transform.BasisX.X;
			double y = transform.BasisY.Y;
			double z = transform.BasisZ.Z;
			return Math.Acos((x + y + z - 1.0) / 2.0);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00010F88 File Offset: 0x0000F188
		private static ElementId GetCropBoxFor(View view)
		{
			ElementParameterFilter elementParameterFilter = new ElementParameterFilter(new FilterElementIdRule(new ParameterValueProvider(new ElementId(-1002100)), new FilterNumericEquals(), view.Id));
			return (from a in new FilteredElementCollector(view.Document).WherePasses(elementParameterFilter).ToElementIds()
			where a.IntegerValue != view.Id.IntegerValue
			select a).FirstOrDefault<ElementId>();
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00011000 File Offset: 0x0000F200
		private static Element GetCropBoxForAsElement(View view)
		{
			ElementParameterFilter elementParameterFilter = new ElementParameterFilter(new FilterElementIdRule(new ParameterValueProvider(new ElementId(-1002100)), new FilterNumericEquals(), view.Id));
			ElementId elementId = (from a in new FilteredElementCollector(view.Document).WherePasses(elementParameterFilter).ToElementIds()
			where a.IntegerValue != view.Id.IntegerValue
			select a).FirstOrDefault<ElementId>();
			return view.Document.GetElement(elementId);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00011088 File Offset: 0x0000F288
		private static XYZ DameVectorReposicion(View vistaorigen, View vistadestino, Transform T)
		{
			BoundingBoxXYZ cropBox = vistaorigen.CropBox;
			XYZ max = cropBox.Max;
			XYZ min = cropBox.Min;
			XYZ xyz = new XYZ((max.X + min.X) / 2.0, (max.Y + min.Y) / 2.0, (max.Z + min.Z) / 2.0);
			xyz = T.OfPoint(xyz);
			BoundingBoxXYZ cropBox2 = vistadestino.CropBox;
			XYZ max2 = cropBox2.Max;
			XYZ min2 = cropBox2.Min;
			XYZ xyz2 = new XYZ((max2.X + min2.X) / 2.0, (max2.Y + min2.Y) / 2.0, (max2.Z + min2.Z) / 2.0);
			return new XYZ(xyz.X - xyz2.X, xyz.Y - xyz2.Y, xyz.Z - xyz2.Z);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00011190 File Offset: 0x0000F390
		private static XYZ DameVectorReposicionOrigenTransformada(View vistaorigen, View vistadestino, Transform T)
		{
			XYZ xyz = vistaorigen.CropBox.Transform.Origin;
			xyz = T.OfPoint(xyz);
			XYZ origin = vistadestino.CropBox.Transform.Origin;
			return new XYZ(xyz.X - origin.X, xyz.Y - origin.Y, xyz.Z - origin.Z);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x000111F4 File Offset: 0x0000F3F4
		private static void UiAppOnDialogBoxShowing(object sender, DialogBoxShowingEventArgs args)
		{
			TaskDialogShowingEventArgs taskDialogShowingEventArgs = args as TaskDialogShowingEventArgs;
			if (taskDialogShowingEventArgs != null)
			{
				if (!(taskDialogShowingEventArgs.DialogId == "Dialog_Revit_DocWarnDialog"))
				{
					return;
				}
				taskDialogShowingEventArgs.OverrideResult(1001);
			}
			if (args == null)
			{
				return;
			}
			if (args.DialogId == "Dialog_Revit_DocWarnDialog")
			{
				args.OverrideResult(1001);
				return;
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00011254 File Offset: 0x0000F454
		public void HandleFailures_Soft(object s, FailuresProcessingEventArgs e)
		{
			FailuresAccessor failuresAccessor = e.GetFailuresAccessor();
			foreach (FailureMessageAccessor failureMessageAccessor in failuresAccessor.GetFailureMessages())
			{
				if (failuresAccessor.GetSeverity() == 1)
				{
					failuresAccessor.DeleteWarning(failureMessageAccessor);
				}
				else
				{
					failuresAccessor.ResolveFailure(failureMessageAccessor);
				}
			}
		}

		// Token: 0x0400008F RID: 143
		private Document doc;

		// Token: 0x04000090 RID: 144
		private UIDocument uidoc;

		// Token: 0x04000091 RID: 145
		private UIApplication app;

		// Token: 0x04000092 RID: 146
		private Estructura est = new Estructura();

		// Token: 0x04000093 RID: 147
		private IList<Elemento> ElementosAFiltrar = new List<Elemento>();

		// Token: 0x04000094 RID: 148
		public static int usercancelled;

		// Token: 0x04000095 RID: 149
		public int AnteriorOrigen = -1;

		// Token: 0x04000096 RID: 150
		public int contador;

		// Token: 0x04000097 RID: 151
		public bool HideMessages;

		// Token: 0x04000098 RID: 152
		public object lastfound;

		// Token: 0x04000099 RID: 153
		public string lastText = "";

		// Token: 0x0400009A RID: 154
		public bool flag_ComboArchivos = true;

		// Token: 0x0400009B RID: 155
		public Configuraciones config = new Configuraciones();

		// Token: 0x0400009C RID: 156
		public string VersionActual = "3.5.1";

		// Token: 0x0200001A RID: 26
		public class CustomCopyHandlerOk : IDuplicateTypeNamesHandler
		{
			// Token: 0x06000130 RID: 304 RVA: 0x000144FF File Offset: 0x000126FF
			public DuplicateTypeAction OnDuplicateTypeNamesFound(DuplicateTypeNamesHandlerArgs args)
			{
				return 1;
			}
		}

		// Token: 0x0200001B RID: 27
		public class CustomCopyHandlerAbort : IDuplicateTypeNamesHandler
		{
			// Token: 0x06000132 RID: 306 RVA: 0x00014502 File Offset: 0x00012702
			public DuplicateTypeAction OnDuplicateTypeNamesFound(DuplicateTypeNamesHandlerArgs args)
			{
				TransferSingle.usercancelled++;
				return 2;
			}
		}
	}
}
