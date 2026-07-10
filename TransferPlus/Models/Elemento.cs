using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;

namespace TransferPlus.Models
{
	// Token: 0x02000028 RID: 40
	public class Elemento
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000197 RID: 407 RVA: 0x0001499C File Offset: 0x00012B9C
		// (set) Token: 0x06000198 RID: 408 RVA: 0x000149A4 File Offset: 0x00012BA4
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				this._Nombre = value;
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000149B0 File Offset: 0x00012BB0
		public Elemento(Element el)
		{
			if (el.Name != null)
			{
				this.Nombre = el.Name;
			}
			else
			{
				this.Nombre = "Undefined";
			}
			if (el.get_Parameter((BuiltInParameter)(-1002050)).AsValueString() != null)
			{
				this.Tipo = el.get_Parameter((BuiltInParameter)(-1002050)).AsValueString();
			}
			else
			{
				this.Tipo = "Undefined";
			}
			if (this.Tipo.Equals(""))
			{
				this.Tipo = "Undefined";
			}
			if (el.get_Parameter((BuiltInParameter)(-1002002)) != null)
			{
				Parameter parameter = el.get_Parameter((BuiltInParameter)(-1002002));
				if (parameter.StorageType == (StorageType)4)
				{
					Element element = el.Document.GetElement(parameter.AsElementId());
					this.Familia = element.Name;
				}
				else if (parameter.AsString() != null)
				{
					this.Familia = parameter.AsString();
				}
				else if (parameter.AsValueString() != null)
				{
					this.Familia = parameter.AsValueString();
				}
				else
				{
					this.Familia = "Undefined";
				}
			}
			else
			{
				this.Familia = "Undefined";
			}
			if (this.Familia.Equals(""))
			{
				this.Familia = "Undefined";
			}
			if (el.Category != null)
			{
				this.Categoria = el.Category.Name;
			}
			else if (el.GetType() != null)
			{
				this.Categoria = el.GetType().ToString();
			}
			else
			{
				this.Categoria = "Undefined";
			}
			if (!this.Categoria.Equals("Undefined"))
			{
				this.Categoria += " Types";
			}
			this.eID = el.Id;
			this.Checked = false;
			this.Num = 1;
			this.wID = WorksetId.InvalidWorksetId;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00014B78 File Offset: 0x00012D78
		public Elemento(Element el, string CategoriaForzada, int caso, Document docin)
		{
			if (caso == 0)
			{
				if (el.Name != null)
				{
					this.Nombre = el.Name;
				}
				else
				{
					this.Nombre = "Undefined";
				}
				if (el.get_Parameter((BuiltInParameter)(-1002050)).AsValueString() != null)
				{
					this.Tipo = el.get_Parameter((BuiltInParameter)(-1002050)).AsValueString();
				}
				else
				{
					this.Tipo = "Undefined";
				}
				if (this.Tipo.Equals(""))
				{
					this.Tipo = "Undefined";
				}
				if (el.get_Parameter((BuiltInParameter)(-1002051)).AsValueString() != null)
				{
					this.Familia = el.get_Parameter((BuiltInParameter)(-1002051)).AsValueString();
				}
				else
				{
					this.Familia = "Undefined";
				}
				if (this.Familia.Equals(""))
				{
					this.Familia = "Undefined";
				}
				if (el.Category != null)
				{
					this.Categoria = el.Category.Name;
				}
				else
				{
					this.Categoria = CategoriaForzada;
				}
				this.eID = el.Id;
				this.Checked = false;
				this.Num = 1;
				this.wID = WorksetId.InvalidWorksetId;
				View view = docin.GetElement(el.Id) as View;
				if (view != null)
				{
					this.IsView = true;
					if (view.ViewType == (ViewType)11)
					{
						this.IsLegend = true;
					}
					if (view.ViewType == (ViewType)5)
					{
						this.IsSchedule = true;
					}
					if (view.ViewType == (ViewType)10)
					{
						this.IsDrafting = true;
					}
					if (view.ViewType == (ViewType)6)
					{
						this.IsSheet = true;
						ViewSheet viewSheet = view as ViewSheet;
						this.SheetNumber = viewSheet.SheetNumber;
						this.Nombre = el.Name;
					}
					if (view.IsAssemblyView)
					{
						this.Categoria = "Views of Assemblies";
						ElementId associatedAssemblyInstanceId = view.AssociatedAssemblyInstanceId;
						if (null != associatedAssemblyInstanceId)
						{
							Element element = docin.GetElement(associatedAssemblyInstanceId);
							this.Familia = element.Name;
						}
					}
				}
				SpatialElement spatialElement = docin.GetElement(el.Id) as SpatialElement;
				if (spatialElement != null)
				{
					this.SheetNumber = spatialElement.Number;
					if (spatialElement.get_Parameter((BuiltInParameter)(-1006900)).AsString() != null)
					{
						this.Nombre = spatialElement.get_Parameter((BuiltInParameter)(-1006900)).AsString();
						return;
					}
				}
			}
			else
			{
				if (caso == 1)
				{
					if (el.get_Parameter((BuiltInParameter)(-1011952)).AsString() != null)
					{
						this.Nombre = el.get_Parameter((BuiltInParameter)(-1011952)).AsString();
					}
					else
					{
						this.Nombre = "Undefined";
					}
					if (this.Nombre.Equals(""))
					{
						this.Nombre = "Undefined";
					}
					this.Familia = "Undefined";
					this.Tipo = "Undefined";
					if (el.Category != null)
					{
						this.Categoria = el.Category.Name;
					}
					else
					{
						this.Categoria = CategoriaForzada;
					}
					this.eID = el.Id;
					this.Checked = false;
					this.Num = 1;
					this.wID = WorksetId.InvalidWorksetId;
					return;
				}
				if (caso == 2)
				{
					this.Nombre = "Undefined";
					this.Tipo = "Undefined";
					SiteLocation siteLocation = el as SiteLocation;
					this.Nombre = string.Concat(new string[]
					{
						"(",
						siteLocation.Longitude.ToString(),
						",",
						siteLocation.Latitude.ToString(),
						")"
					});
					this.Familia = "Undefined";
					this.Tipo = "Undefined";
					if (el.Category != null)
					{
						this.Categoria = el.Category.Name;
					}
					else
					{
						this.Categoria = CategoriaForzada;
					}
					this.eID = el.Id;
					this.Checked = false;
					this.Num = 1;
					this.wID = WorksetId.InvalidWorksetId;
					return;
				}
				if (caso == 3)
				{
					if (el.Name != null)
					{
						this.Nombre = el.Name;
					}
					else
					{
						this.Nombre = "Undefined";
					}
					if (el.get_Parameter((BuiltInParameter)(-1002050)).AsValueString() != null)
					{
						this.Tipo = el.get_Parameter((BuiltInParameter)(-1002050)).AsValueString();
					}
					else
					{
						this.Tipo = "Undefined";
					}
					if (this.Tipo.Equals(""))
					{
						this.Tipo = "Undefined";
					}
					if (el.get_Parameter((BuiltInParameter)(-1002051)).AsValueString() != null)
					{
						this.Familia = el.get_Parameter((BuiltInParameter)(-1002051)).AsValueString();
					}
					if (this.Familia.Equals(""))
					{
						View view2 = docin.GetElement(el.Id) as View;
						if (view2 != null)
						{
							this.Familia = view2.ViewType.ToString();
						}
					}
					if (this.Familia.Equals(""))
					{
						if (el is View3D)
						{
							this.Familia = "View3D";
						}
						else if (el is ViewFamilyType)
						{
							this.Familia = "ViewFamilyType";
						}
						else if (el is Viewport)
						{
							this.Familia = "Viewport";
						}
						else if (el is ViewSchedule)
						{
							this.Familia = "ViewSchedule";
						}
						else if (el is ViewSection)
						{
							this.Familia = "ViewSection";
						}
						else if (el is ViewSheet)
						{
							this.Familia = "ViewSheet";
						}
						else if (el is ViewSheetSet)
						{
							this.Familia = "ViewSheetSet";
						}
						else
						{
							this.Familia = "View";
						}
					}
					if (el.Category != null)
					{
						this.Categoria = el.Category.Name + " Templates";
					}
					else
					{
						this.Categoria = CategoriaForzada;
					}
					this.eID = el.Id;
					this.Checked = false;
					this.Num = 1;
					this.wID = WorksetId.InvalidWorksetId;
					return;
				}
				if (caso == 4)
				{
					this.Categoria = CategoriaForzada;
					if (el.Name != null)
					{
						this.Nombre = el.Name;
					}
					else
					{
						this.Nombre = "Undefined";
					}
					this.Familia = "Undefined";
					this.Tipo = "Undefined";
					ViewFamilyType viewFamilyType = docin.GetElement(el.Id) as ViewFamilyType;
					if (viewFamilyType != null)
					{
						this.Tipo = "Undefined";
					}
					if (viewFamilyType.ViewFamily.ToString() != null)
					{
						this.Familia = viewFamilyType.ViewFamily.ToString();
					}
					this.eID = el.Id;
					this.Checked = false;
					this.Num = 1;
					this.wID = WorksetId.InvalidWorksetId;
					return;
				}
				if (caso == 5)
				{
					this.Categoria = CategoriaForzada;
					if (el.Name != null)
					{
						this.Nombre = el.Name;
					}
					else
					{
						this.Nombre = "Undefined";
					}
					this.Familia = "Project No Shared";
					this.Tipo = "Undefined";
					this.eID = el.Id;
					this.Checked = false;
					this.Num = 1;
					this.wID = WorksetId.InvalidWorksetId;
					this.IsParameter = true;
					return;
				}
				if (caso == 6)
				{
					this.Categoria = CategoriaForzada;
					if (el.Name != null)
					{
						this.Nombre = el.Name;
					}
					else
					{
						this.Nombre = "Undefined";
					}
					this.Familia = "Project Shared";
					this.Tipo = "Undefined";
					this.eID = el.Id;
					this.Checked = false;
					this.Num = 1;
					this.wID = WorksetId.InvalidWorksetId;
					this.IsParameter = true;
					return;
				}
				if (caso == 7)
				{
					this.Categoria = CategoriaForzada;
					if (el.Name != null)
					{
						this.Nombre = el.Name;
					}
					else
					{
						this.Nombre = "Undefined";
					}
					this.Familia = "All";
					this.Tipo = "Undefined";
					this.eID = el.Id;
					this.Checked = false;
					this.Num = 1;
					this.wID = WorksetId.InvalidWorksetId;
					this.IsParameter = true;
					return;
				}
				if (caso == 71)
				{
					this.Categoria = CategoriaForzada;
					if (el.Name != null)
					{
						this.Nombre = el.Name;
					}
					else
					{
						this.Nombre = "Undefined";
					}
					this.Familia = "Global";
					this.Tipo = "Undefined";
					this.eID = el.Id;
					this.Checked = false;
					this.Num = 1;
					this.wID = WorksetId.InvalidWorksetId;
					this.IsParameter = true;
					return;
				}
				if (caso == 8)
				{
					this.Categoria = CategoriaForzada;
					if (el.Name != null)
					{
						this.Nombre = el.Name;
					}
					else
					{
						this.Nombre = "Undefined";
					}
					if (el.Category != null)
					{
						this.Familia = el.Category.Name;
					}
					else
					{
						this.Familia = "Undefined";
					}
					this.Tipo = "Undefined";
					this.eID = el.Id;
					this.Checked = false;
					this.Num = 1;
					this.wID = WorksetId.InvalidWorksetId;
					return;
				}
				if (caso == 9)
				{
					this.Categoria = CategoriaForzada;
					if (el.Name != null)
					{
						this.Nombre = el.Name;
					}
					else
					{
						this.Nombre = "Undefined";
					}
					PanelScheduleTemplate panelScheduleTemplate = el as PanelScheduleTemplate;
					if (panelScheduleTemplate != null)
					{
						this.Familia = panelScheduleTemplate.GetPanelScheduleType().ToString();
					}
					else
					{
						this.Familia = "Undefined";
					}
					this.Tipo = "Undefined";
					this.eID = el.Id;
					this.Checked = false;
					this.Num = 1;
					this.wID = WorksetId.InvalidWorksetId;
					return;
				}
				if (caso == 10)
				{
					if (el.Name != null)
					{
						this.Nombre = el.Name;
					}
					else
					{
						this.Nombre = "Undefined";
					}
					if (el.get_Parameter((BuiltInParameter)(-1002050)).AsValueString() != null)
					{
						this.Tipo = el.get_Parameter((BuiltInParameter)(-1002050)).AsValueString();
					}
					else
					{
						this.Tipo = "Undefined";
					}
					if (this.Tipo.Equals(""))
					{
						this.Tipo = "Undefined";
					}
					this.Familia = this.Tipo;
					if (el.Category != null)
					{
						this.Categoria = el.Category.Name;
					}
					else
					{
						this.Categoria = "Revit Link Instances";
					}
					this.eID = el.Id;
					this.Checked = false;
					this.Num = 1;
					this.wID = WorksetId.InvalidWorksetId;
					return;
				}
				if (el.Name != null)
				{
					this.Nombre = el.Name;
				}
				else
				{
					this.Nombre = "Undefined";
				}
				if (el.get_Parameter((BuiltInParameter)(-1002050)).AsValueString() != null)
				{
					this.Tipo = el.get_Parameter((BuiltInParameter)(-1002050)).AsValueString();
				}
				else
				{
					this.Tipo = "Undefined";
				}
				if (this.Tipo.Equals(""))
				{
					this.Tipo = "Undefined";
				}
				if (el.get_Parameter((BuiltInParameter)(-1002051)).AsValueString() != null)
				{
					this.Familia = el.get_Parameter((BuiltInParameter)(-1002051)).AsValueString();
				}
				if (this.Familia.Equals(""))
				{
					if (el is View3D)
					{
						this.Familia = "View3D";
					}
					else if (el is ViewFamilyType)
					{
						this.Familia = "ViewFamilyType";
					}
					else if (el is Viewport)
					{
						this.Familia = "Viewport";
					}
					else if (el is ViewSchedule)
					{
						this.Familia = "ViewSchedule";
					}
					else if (el is ViewSection)
					{
						this.Familia = "ViewSection";
					}
					else if (el is ViewSheet)
					{
						this.Familia = "ViewSheet";
					}
					else if (el is ViewSheetSet)
					{
						this.Familia = "ViewSheetSet";
					}
					else
					{
						this.Familia = "View";
					}
				}
				if (el.Category != null)
				{
					this.Categoria = el.Category.Name;
				}
				else
				{
					this.Categoria = CategoriaForzada;
				}
				this.eID = el.Id;
				this.Checked = false;
				this.Num = 1;
				this.wID = WorksetId.InvalidWorksetId;
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00015730 File Offset: 0x00013930
		public Elemento(Element el, string CategoriaForzada, string FamiliaForzada, string TipoForzado, string NombreForzado, Document docin)
		{
			this.Nombre = NombreForzado;
			this.Categoria = CategoriaForzada;
			this.Familia = FamiliaForzada;
			this.Tipo = TipoForzado;
			this.eID = el.Id;
			this.Checked = false;
			this.Num = 1;
			this.wID = WorksetId.InvalidWorksetId;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00015794 File Offset: 0x00013994
		public Elemento(Element el, string CategoriaForzada, string FamiliaForzada, string TipoForzado, Document docin)
		{
			if (el.Name != null)
			{
				this.Nombre = el.Name;
			}
			else
			{
				this.Nombre = "Undefined";
			}
			this.Categoria = CategoriaForzada;
			this.Familia = FamiliaForzada;
			this.Tipo = TipoForzado;
			this.eID = el.Id;
			this.Checked = false;
			this.Num = 1;
			this.wID = WorksetId.InvalidWorksetId;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00015810 File Offset: 0x00013A10
		public Elemento(Element el, string CategoriaForzada, string FamiliaForzada, Document docin)
		{
			if (el.Name != null)
			{
				this.Nombre = el.Name;
			}
			else
			{
				this.Nombre = "Undefined";
			}
			this.Categoria = CategoriaForzada;
			this.Familia = FamiliaForzada;
			this.Tipo = "Undefined";
			this.IsLoadable = true;
			this.eID = el.Id;
			this.Checked = false;
			this.Num = 1;
			this.wID = WorksetId.InvalidWorksetId;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00015894 File Offset: 0x00013A94
		public Elemento(Element el, int caso)
		{
			if (el.Name != null)
			{
				this.Nombre = el.Name;
			}
			else
			{
				this.Nombre = "Undefined";
			}
			if (el.get_Parameter((BuiltInParameter)(-1002050)).AsValueString() != null)
			{
				this.Tipo = el.get_Parameter((BuiltInParameter)(-1002050)).AsValueString();
			}
			else
			{
				this.Tipo = "Undefined";
			}
			if (this.Tipo.Equals(""))
			{
				this.Tipo = "Undefined";
			}
			if (el.get_Parameter((BuiltInParameter)(-1002051)).AsValueString() != null)
			{
				this.Familia = el.get_Parameter((BuiltInParameter)(-1002051)).AsValueString();
			}
			else
			{
				this.Familia = "Undefined";
			}
			if (this.Familia.Equals(""))
			{
				this.Familia = "Undefined";
			}
			if (el.Category != null)
			{
				this.Categoria = el.Category.Name;
			}
			else if (el.GetType() != null)
			{
				this.Categoria = el.GetType().ToString();
			}
			else
			{
				this.Categoria = "Undefined";
			}
			this.eID = el.Id;
			this.Checked = false;
			this.Num = 1;
			this.wID = WorksetId.InvalidWorksetId;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x000159E4 File Offset: 0x00013BE4
		public Elemento(Workset ws)
		{
			this.Nombre = ws.Name;
			this.Tipo = "Undefined";
			this.Familia = "Undefined";
			this.Categoria = "Worksets";
			this.wID = ws.Id;
			this.Checked = false;
			this.Num = 1;
			this.eID = ElementId.InvalidElementId;
			this.IsWorkset = true;
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00015A5B File Offset: 0x00013C5B
		public string Descripcion()
		{
			return this.Nombre;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00015A63 File Offset: 0x00013C63
		private ElementId DameID()
		{
			return this.eID;
		}

		// Token: 0x0400014D RID: 333
		private string _Nombre;

		// Token: 0x0400014E RID: 334
		public string Categoria;

		// Token: 0x0400014F RID: 335
		public string Familia;

		// Token: 0x04000150 RID: 336
		public string Tipo;

		// Token: 0x04000151 RID: 337
		public string SheetNumber;

		// Token: 0x04000152 RID: 338
		public bool Checked;

		// Token: 0x04000153 RID: 339
		public ElementId eID;

		// Token: 0x04000154 RID: 340
		public WorksetId wID;

		// Token: 0x04000155 RID: 341
		public int Num;

		// Token: 0x04000156 RID: 342
		public bool IsWorkset;

		// Token: 0x04000157 RID: 343
		public bool IsLegend;

		// Token: 0x04000158 RID: 344
		public bool IsView;

		// Token: 0x04000159 RID: 345
		public bool IsSheet;

		// Token: 0x0400015A RID: 346
		public bool IsElevation;

		// Token: 0x0400015B RID: 347
		public bool IsSchedule;

		// Token: 0x0400015C RID: 348
		public bool IsDrafting;

		// Token: 0x0400015D RID: 349
		public bool IsLoadable;

		// Token: 0x0400015E RID: 350
		public bool IsParameter;

		// Token: 0x0400015F RID: 351
		public bool IsProjectInfo;

		// Token: 0x04000160 RID: 352
		public bool NoTransferible;

		// Token: 0x04000161 RID: 353
		public bool PasteEntreVistas;

		// Token: 0x04000162 RID: 354
		public IList<ElementId> IdsAdicionales = new List<ElementId>();

		// Token: 0x04000163 RID: 355
		public Nodo Padre;
	}
}
