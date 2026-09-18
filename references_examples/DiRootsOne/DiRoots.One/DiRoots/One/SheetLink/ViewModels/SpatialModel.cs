using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.SheetLink.Core;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.Profile;
using DiRoots.One.SheetLink.UI.Controls;
using DiRoots.One.SheetLink.UI.Windows;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.SheetLink.ViewModels
{
	// Token: 0x02000217 RID: 535
	public class SpatialModel : ViewModelBase
	{
		// Token: 0x06001453 RID: 5203 RVA: 0x00083FC4 File Offset: 0x000821C4
		public SpatialModel(UIDocument uidoc, Window parent, SpatialControl spatialControl)
		{
			this._uidocument = uidoc;
			\u000A\u000C\u0007.\u001D(this, parent);
			this.AU = spatialControl;
			this.ActiveProgressBar = \u0005\u0002\u000E.\u001F(parent).RH;
			\u0010\u001F\u0005.\u000A(this, new \u0015\u001C());
			this._parametersModel = \u001A\u0014\u0018.\u0007(spatialControl.B);
			\u000D\u001F\u0005.\u000A(spatialControl.B, true);
			\u0003\u001F\u0005.\u000A(this, Enumerable.First<CategoryCollection>(\u001C\u001F\u0005.\u000A(this)));
			this.UXR();
			RevitParametersModel parametersModel = this._parametersModel;
			\u0014\u0014\u0018.\u000A(parametersModel, \u0020\u000B\u000E.\u001F(\u000F\u001E\u000A.\u000A(\u0013\u0014\u0018.\u0007(parametersModel), new ParameterBaseModel<BaseParameter>.CollectionChangedDelegate(this.SetStatus))));
			SpatialNavigator l = spatialControl.L;
			\u000F\u001F\u0005.\u000A(l, (SpatialNavigator.ContextMenuDelegate)\u000F\u001E\u000A.\u000A(\u0012\u001F\u0005.\u0007(l), new SpatialNavigator.ContextMenuDelegate(this.OVR)));
			\u0006\u001F\u0005.\u000A(this);
		}

		// Token: 0x06001454 RID: 5204 RVA: 0x000840AC File Offset: 0x000822AC
		// Note: this type is marked as 'beforefieldinit'.
		static SpatialModel()
		{
			List<CategoryCollection> list = \u0017\u0017\u0019.\u000A();
			int u001F = -2000160;
			List<string> list2 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list2, "1");
			CategoryCollection categoryCollection = \u001B\u001F\u0005.\u000A(u001F, list2);
			\u0015\u0015\u0018.\u0007(categoryCollection, \u0011\u001F\u0005.\u000A());
			\u000E\u001F\u0005.\u000A(categoryCollection, ExportTypes.Rooms);
			\u0020\u0017\u0019.\u000A(list, categoryCollection);
			int u001F2 = -2003600;
			List<string> list3 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list3, "6");
			CategoryCollection categoryCollection2 = \u001B\u001F\u0005.\u000A(u001F2, list3);
			\u0015\u0015\u0018.\u0007(categoryCollection2, \u0008\u001F\u0005.\u000A());
			\u000E\u001F\u0005.\u000A(categoryCollection2, ExportTypes.Spaces);
			\u0020\u0017\u0019.\u000A(list, categoryCollection2);
			SpatialModel.QW = list;
		}

		// Token: 0x170005C6 RID: 1478
		// (get) Token: 0x06001455 RID: 5205 RVA: 0x00084138 File Offset: 0x00082338
		// (set) Token: 0x06001456 RID: 5206 RVA: 0x0008414C File Offset: 0x0008234C
		internal \u0015\u001C ParamCollector { get; set; }

		// Token: 0x170005C7 RID: 1479
		// (get) Token: 0x06001457 RID: 5207 RVA: 0x00084160 File Offset: 0x00082360
		// (set) Token: 0x06001458 RID: 5208 RVA: 0x00084174 File Offset: 0x00082374
		public ObservableCollection<SpatialBaseElement> Items
		{
			get
			{
				return this.LC;
			}
			set
			{
				this.LC = value;
				this.OnPropertyChanged<ObservableCollection<SpatialBaseElement>>(new Func<ObservableCollection<SpatialBaseElement>>(this.NXR), "Items");
			}
		}

		// Token: 0x170005C8 RID: 1480
		// (get) Token: 0x06001459 RID: 5209 RVA: 0x000841A0 File Offset: 0x000823A0
		// (set) Token: 0x0600145A RID: 5210 RVA: 0x000841B4 File Offset: 0x000823B4
		public int ElementsOption
		{
			get
			{
				return this.SD;
			}
			set
			{
				this.SD = value;
				\u000D\u0020\u000A.\u000A(this, "ElementsOption");
			}
		}

		// Token: 0x170005C9 RID: 1481
		// (get) Token: 0x0600145B RID: 5211 RVA: 0x000841D4 File Offset: 0x000823D4
		// (set) Token: 0x0600145C RID: 5212 RVA: 0x000841E8 File Offset: 0x000823E8
		public bool IsLinkedFileChecked
		{
			get
			{
				return this.GU;
			}
			set
			{
				this.GU = value;
				\u000D\u0020\u000A.\u000A(this, "IsLinkedFileChecked");
			}
		}

		// Token: 0x170005CA RID: 1482
		// (get) Token: 0x0600145D RID: 5213 RVA: 0x00084208 File Offset: 0x00082408
		// (set) Token: 0x0600145E RID: 5214 RVA: 0x0008421C File Offset: 0x0008241C
		public string StatusText
		{
			get
			{
				return this.PB;
			}
			set
			{
				this.PB = value;
				this.OnPropertyChanged<string>(new Func<string>(this.MXR), "StatusText");
			}
		}

		// Token: 0x170005CB RID: 1483
		// (get) Token: 0x0600145F RID: 5215 RVA: 0x00084248 File Offset: 0x00082448
		// (set) Token: 0x06001460 RID: 5216 RVA: 0x0008425C File Offset: 0x0008245C
		public bool IsExportable
		{
			get
			{
				return this.OB;
			}
			set
			{
				this.OB = value;
				\u000D\u0020\u000A.\u000A(this, "IsExportable");
			}
		}

		// Token: 0x170005CC RID: 1484
		// (get) Token: 0x06001461 RID: 5217 RVA: 0x0008427C File Offset: 0x0008247C
		public string ExportContent
		{
			get
			{
				return \u001E\u001F\u0005.\u000A();
			}
		}

		// Token: 0x170005CD RID: 1485
		// (get) Token: 0x06001462 RID: 5218 RVA: 0x00084290 File Offset: 0x00082490
		public List<CategoryCollection> SpatialTypes
		{
			get
			{
				return SpatialModel.QW;
			}
		}

		// Token: 0x170005CE RID: 1486
		// (get) Token: 0x06001463 RID: 5219 RVA: 0x000842A4 File Offset: 0x000824A4
		// (set) Token: 0x06001464 RID: 5220 RVA: 0x000842B8 File Offset: 0x000824B8
		public CategoryCollection SelectedType
		{
			get
			{
				return this.IW;
			}
			set
			{
				this.IW = value;
				if (this.AU != null)
				{
					for (;;)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.set_SelectedType(CategoryCollection)).MethodHandle;
					}
					if (this.IW != null)
					{
						for (;;)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
						\u0020\u001F\u0005.\u000A(this.AU.L, \u0002\u0013\u000A.\u000A(\u0017\u001F\u0005.\u000A(), " ", \u0012\u001E\u0018.\u000A(this.IW)));
					}
				}
				\u000D\u0020\u000A.\u000A(this, "SelectedType");
			}
		}

		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x06001465 RID: 5221 RVA: 0x00084334 File Offset: 0x00082534
		public CommandBase SpatialSelectionChangedCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.UXR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x06001466 RID: 5222 RVA: 0x0008435C File Offset: 0x0008255C
		[BindableMethod("LinkedOptionChanged")]
		public void LinkedOptionChanged()
		{
			this.JXR();
			\u0006\u001F\u0005.\u000A(this);
		}

		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x06001467 RID: 5223 RVA: 0x00084378 File Offset: 0x00082578
		public CommandBase ExportCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.OnExportClicked), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005D1 RID: 1489
		// (get) Token: 0x06001468 RID: 5224 RVA: 0x000843A0 File Offset: 0x000825A0
		public CommandBase ExportToDriveCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.OnExportToDriveClicked), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x06001469 RID: 5225 RVA: 0x000843C8 File Offset: 0x000825C8
		public CommandBase StandardExportCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.ExportProjectStandards), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x0600146A RID: 5226 RVA: 0x000843F0 File Offset: 0x000825F0
		public CommandBase ResetCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.OnResetClicked), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x0600146B RID: 5227 RVA: 0x00084418 File Offset: 0x00082618
		public CommandBase RefreshCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.OnRefreshClicked), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x0600146C RID: 5228 RVA: 0x00084440 File Offset: 0x00082640
		private void UXR()
		{
			FilteredElementCollector filteredElementCollector = \u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u0011\u0020\u000A.\u0007(this._uidocument)), \u0013\u000E\u0018.\u0007(\u0015\u001F\u0005.\u000A(this))));
			try
			{
				IEnumerable<Element> enumerable = Enumerable.ToList<Element>(\u0001\u001E\u000A.\u0007(filteredElementCollector));
				\u0002\u000E u000A = new \u0002\u000E(true);
				Func<Element, SpatialBaseElement> func;
				if ((func = SpatialModel.<>c.\u000A) == null)
				{
					for (;;)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.UXR()).MethodHandle;
					}
					func = (SpatialModel.<>c.\u000A = new Func<Element, SpatialBaseElement>(SpatialModel.<>c.\u001F.\u0012));
				}
				List<SpatialBaseElement> u001F = Enumerable.ToList<SpatialBaseElement>(Enumerable.Select<Element, SpatialBaseElement>(enumerable, func));
				\u000C\u001F\u0005.\u000A(u001F, u000A);
				\u0013\u001F\u0005.\u000A(this, \u001A\u001F\u0005.\u000A(u001F));
			}
			finally
			{
				if (filteredElementCollector != null)
				{
					for (;;)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					\u001F\u0017\u000A.\u000A(filteredElementCollector);
				}
			}
			this.JXR();
			\u0014\u001F\u0005.\u000A(this);
		}

		// Token: 0x0600146D RID: 5229 RVA: 0x00084520 File Offset: 0x00082720
		[BindableMethod("CheckedChangedEvent")]
		public void CheckedChangedEvent()
		{
			\u0001\u001F\u0005.\u000A(this);
			\u0006\u001F\u0005.\u000A(this);
		}

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x0600146E RID: 5230 RVA: 0x0008453C File Offset: 0x0008273C
		public CommandBase<ProfileUserControl> ProfileChangedCommand
		{
			get
			{
				return \u0009\u0014\u0018.\u000A(new Action<ProfileUserControl>(this.ProfileChanged), \u0015\u000B\u000E.\u001F);
			}
		}

		// Token: 0x0600146F RID: 5231 RVA: 0x00084564 File Offset: 0x00082764
		public void ProfileChanged(ProfileUserControl profileControl)
		{
			\u000A\u000A\u0005.\u000A(this);
			TemplateInfo templateInfo = \u000C\u000B\u000E.\u001F(\u0018\u0013\u0018.\u0007(profileControl));
			\u001F\u000A\u0005.\u000A(this, 1);
			\u0009\u001F\u0005.\u000A(this, \u0004\u0013\u0018.\u000A(templateInfo));
			this.MVR(\u001F\u0013\u0018.\u0007(profileControl), templateInfo);
			this.AU.L.N();
		}

		// Token: 0x06001470 RID: 5232 RVA: 0x000845BC File Offset: 0x000827BC
		private void MVR(Profile F, TemplateInfo R)
		{
			SpatialModel.\u001C\u0003 u001C_u = new SpatialModel.\u001C\u0003();
			u001C_u.\u001F = R;
			List<ProfileReport> list = \u0009\u0013\u0018.\u000A();
			object u001F = Enumerable.ToList<SpatialBaseElement>(\u000B\u000A\u0005.\u0007(this.AU.L));
			Action<SpatialBaseElement> u000A;
			if ((u000A = SpatialModel.<>c.\u0007) == null)
			{
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.MVR(Profile, TemplateInfo)).MethodHandle;
				}
				u000A = (SpatialModel.<>c.\u0007 = new Action<SpatialBaseElement>(SpatialModel.<>c.\u001F.\u0003));
			}
			\u0016\u000A\u0005.\u000A(u001F, u000A);
			CategoryCollection categoryCollection = Enumerable.FirstOrDefault<CategoryCollection>(\u001C\u001F\u0005.\u000A(this), new Func<CategoryCollection, bool>(u001C_u.\u000A));
			if (categoryCollection != null)
			{
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				\u0003\u001F\u0005.\u000A(this, categoryCollection);
				\u0005\u000A\u0005.\u0007(\u0004\u000A\u0005.\u0007(this.AU.L));
				List<long>.Enumerator enumerator = \u0015\u0013\u0018.\u000A(\u0001\u0013\u0018.\u000A(u001C_u.\u001F));
				try
				{
					while (\u0017\u0013\u0018.\u000A(ref enumerator))
					{
						SpatialModel.\u000D\u0003 u000D_u = new SpatialModel.\u000D\u0003();
						u000D_u.\u001F = (int)\u000C\u0013\u0018.\u000A(ref enumerator);
						SpatialBaseElement spatialBaseElement = Enumerable.FirstOrDefault<SpatialBaseElement>(\u0018\u000A\u0005.\u000A(this), new Func<SpatialBaseElement, bool>(u000D_u.\u000A));
						if (spatialBaseElement != null)
						{
							for (;;)
							{
								switch (4)
								{
								case 0:
									continue;
								}
								break;
							}
							\u0019\u000A\u0005.\u000A(spatialBaseElement, true);
							\u001D\u000A\u0005.\u000A(\u0004\u000A\u0005.\u0007(this.AU.L), spatialBaseElement);
						}
					}
					for (;;)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				\u0001\u001F\u0005.\u000A(this);
				List<RevitParameter> list2 = Enumerable.ToList<RevitParameter>(Enumerable.Cast<RevitParameter>(\u000E\u0013\u0018.\u0007(this._parametersModel)));
				List<ParamExportInfo>.Enumerator enumerator2 = \u001E\u0013\u0018.\u000A(\u0020\u0013\u0018.\u000A(u001C_u.\u001F));
				try
				{
					while (\u000B\u0013\u0018.\u000A(ref enumerator2))
					{
						SpatialModel.\u0010\u0003 u0010_u = new SpatialModel.\u0010\u0003();
						u0010_u.\u001F = \u0011\u0013\u0018.\u000A(ref enumerator2);
						SpatialModel.\u000E\u0003 u000E_u = new SpatialModel.\u000E\u0003();
						SpatialModel.\u000E\u0003 u000E_u2 = u000E_u;
						IEnumerable<BaseParameter> enumerable = Enumerable.Where<BaseParameter>(\u000E\u0013\u0018.\u0007(this._parametersModel), new Func<BaseParameter, bool>(u0010_u.\u000A));
						Func<BaseParameter, string> func;
						if ((func = SpatialModel.<>c.\u001D) == null)
						{
							for (;;)
							{
								switch (6)
								{
								case 0:
									continue;
								}
								break;
							}
							func = (SpatialModel.<>c.\u001D = new Func<BaseParameter, string>(SpatialModel.<>c.\u001F.\u001C));
						}
						u000E_u2.\u001F = Enumerable.ToList<string>(Enumerable.Select<BaseParameter, string>(enumerable, func));
						u000E_u.\u000A = Enumerable.FirstOrDefault<RevitParameter>(list2, new Func<RevitParameter, bool>(u000E_u.\u0007));
						if (u000E_u.\u000A != null)
						{
							for (;;)
							{
								switch (4)
								{
								case 0:
									continue;
								}
								break;
							}
							if (Enumerable.FirstOrDefault<BaseParameter>(\u001B\u0013\u0018.\u000A(this._parametersModel), new Func<BaseParameter, bool>(u000E_u.\u001D)) == null)
							{
								for (;;)
								{
									switch (2)
									{
									case 0:
										continue;
									}
									break;
								}
								\u0008\u0013\u0018.\u000A(\u001B\u0013\u0018.\u000A(this._parametersModel), u000E_u.\u000A);
								\u0010\u0013\u0018.\u000A(\u000E\u0013\u0018.\u0007(this._parametersModel), u000E_u.\u000A);
							}
						}
						else
						{
							ProfileReport profileReport = \u000D\u0013\u0018.\u000A();
							\u001C\u0013\u0018.\u000A(profileReport, \u0014\u0004\u0018.\u0007(u0010_u.\u001F));
							\u0020\u0014\u0007.\u000A(profileReport, ReportStates.Error);
							\u0006\u0013\u0018.\u000A(profileReport, \u000F\u0013\u0018.\u000A(\u0003\u0013\u0018.\u000A(), \u0014\u0004\u0018.\u0007(u0010_u.\u001F), \u0012\u0013\u0018.\u000A(F)));
							\u0002\u0013\u0018.\u000A(list, profileReport);
						}
					}
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			\u0006\u001F\u0005.\u000A(this);
			\u0007\u000A\u0005.\u000A(this, list);
		}

		// Token: 0x06001471 RID: 5233 RVA: 0x0008492C File Offset: 0x00082B2C
		protected void ShowReport(List<ProfileReport> reports)
		{
			if (\u001D\u0015\u0018.\u000A(reports) > 0)
			{
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.ShowReport(List<ProfileReport>)).MethodHandle;
				}
				ReportsWindow u001F = \u0003\u0018\u001D.\u000A(\u0007\u0015\u0018.\u000A(Enumerable.ToList<Report>(Enumerable.Cast<Report>(reports)), \u001E\u0011\u000A.\u000A(\u0004\u0002\u000E.\u001F()), 700), false);
				\u000C\u000E\u0007.\u0007(u001F, \u0018\u000B\u0007.\u0007(this));
				\u0018\u0020\u000A.\u0007(u001F);
			}
		}

		// Token: 0x06001472 RID: 5234 RVA: 0x000849A0 File Offset: 0x00082BA0
		[BindableMethod("AddProfile")]
		public void AddProfile(ProfileUserControl profileControl)
		{
			this.VVR(profileControl);
		}

		// Token: 0x06001473 RID: 5235 RVA: 0x000849B4 File Offset: 0x00082BB4
		[BindableMethod("SaveProfile")]
		public void SaveProfile(ProfileUserControl profileControl)
		{
			this.VVR(profileControl);
		}

		// Token: 0x06001474 RID: 5236 RVA: 0x000849C8 File Offset: 0x00082BC8
		private void VVR(ProfileUserControl F)
		{
			SpatialModel.\u0008\u0003 u0008_u = new SpatialModel.\u0008\u0003();
			u0008_u.\u001F = this;
			TemplateInfo templateInfo = \u0016\u001A\u0018.\u000A();
			if (\u0018\u000A\u0005.\u000A(this) != null)
			{
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.VVR(ProfileUserControl)).MethodHandle;
				}
				\u0011\u0015\u0018.\u000A(templateInfo, \u0013\u000E\u0018.\u0007(\u0015\u001F\u0005.\u000A(this)));
				ObservableCollection<SpatialBaseElement> observableCollection = \u0004\u000A\u0005.\u0007(this.AU.L);
				List<SpatialBaseElement> list;
				if (observableCollection == null)
				{
					for (;;)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					list = \u0013\u0002\u000E.\u001F;
				}
				else
				{
					list = Enumerable.ToList<SpatialBaseElement>(Enumerable.Cast<SpatialBaseElement>(observableCollection));
				}
				List<SpatialBaseElement> list2 = list;
				object u001F = templateInfo;
				List<long> u000A;
				if (list2 == null)
				{
					for (;;)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					u000A = \u001A\u000B\u000E.\u001F;
				}
				else
				{
					IEnumerable<SpatialBaseElement> enumerable = list2;
					Func<SpatialBaseElement, long> func;
					if ((func = SpatialModel.<>c.\u0004) == null)
					{
						for (;;)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							break;
						}
						func = (SpatialModel.<>c.\u0004 = new Func<SpatialBaseElement, long>(SpatialModel.<>c.\u001F.\u000D));
					}
					u000A = Enumerable.ToList<long>(Enumerable.Select<SpatialBaseElement, long>(enumerable, func));
				}
				\u0005\u001A\u0018.\u0007(u001F, u000A);
				u0008_u.\u000A = this.WXR();
				\u0018\u001A\u0018.\u0007(templateInfo, Enumerable.ToList<ParamExportInfo>(Enumerable.Select<BaseParameter, ParamExportInfo>(\u001B\u0013\u0018.\u000A(this._parametersModel), new Func<BaseParameter, ParamExportInfo>(u0008_u.\u0007))));
				\u0004\u001A\u0018.\u000A(templateInfo, \u0002\u000A\u0005.\u000A(this));
			}
			\u000A\u001A\u0018.\u0007(F, templateInfo);
		}

		// Token: 0x06001475 RID: 5237 RVA: 0x00084AF8 File Offset: 0x00082CF8
		private List<CategoryCollection> WXR()
		{
			List<CategoryCollection> list = \u0017\u0017\u0019.\u000A();
			List<Element> u000A = \u0016\u0016\u0004.\u000A();
			if (\u0004\u000A\u0005.\u0007(this.AU.L) != null)
			{
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.WXR()).MethodHandle;
				}
				IEnumerable<SpatialBaseElement> enumerable = \u0004\u000A\u0005.\u0007(this.AU.L);
				Func<SpatialBaseElement, Element> func;
				if ((func = SpatialModel.<>c.\u0019) == null)
				{
					for (;;)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					func = (SpatialModel.<>c.\u0019 = new Func<SpatialBaseElement, Element>(SpatialModel.<>c.\u001F.\u0010));
				}
				u000A = Enumerable.ToList<Element>(Enumerable.Select<SpatialBaseElement, Element>(enumerable, func));
			}
			CategoryCollection categoryCollection = \u000C\u0003\u0018.\u000A(Enumerable.FirstOrDefault<CategoryCollection>(\u0014\u0014\u0019.\u000A(), new Func<CategoryCollection, bool>(this.VXR)), u000A);
			\u001B\u0013\u0019.\u000A(categoryCollection, true);
			\u0020\u0017\u0019.\u000A(list, categoryCollection);
			return list;
		}

		// Token: 0x06001476 RID: 5238 RVA: 0x00084BB8 File Offset: 0x00082DB8
		private string KXR(List<CategoryCollection> F)
		{
			return \u0012\u001E\u0018.\u000A(\u0015\u001F\u0005.\u000A(this));
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x00084BD4 File Offset: 0x00082DD4
		protected void SelectionChanged()
		{
			if (this._parametersModel != null)
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.SelectionChanged()).MethodHandle;
				}
				SpatialModel.\u001B\u0003 u001B_u = new SpatialModel.\u001B\u0003();
				\u000F\u000A\u0005.\u000A(\u000E\u0020\u0018.\u000A(\u0006\u000A\u0005.\u000A(this)));
				\u0011\u000C\u0018.\u000A(\u001B\u0014\u0019.\u0007(\u0006\u000A\u0005.\u000A(this)));
				List<CategoryCollection> list = this.WXR();
				IEnumerable<CategoryCollection> enumerable = list;
				Func<CategoryCollection, bool> func;
				if ((func = SpatialModel.<>c.\u0018) == null)
				{
					for (;;)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					func = (SpatialModel.<>c.\u0018 = new Func<CategoryCollection, bool>(SpatialModel.<>c.\u001F.\u000E));
				}
				if (Enumerable.Any<CategoryCollection>(enumerable, func))
				{
					for (;;)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					IEnumerable<SpatialBaseElement> enumerable2 = \u0018\u000A\u0005.\u000A(this);
					Func<SpatialBaseElement, bool> func2;
					if ((func2 = SpatialModel.<>c.\u0005) == null)
					{
						for (;;)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							break;
						}
						func2 = (SpatialModel.<>c.\u0005 = new Func<SpatialBaseElement, bool>(SpatialModel.<>c.\u001F.\u0008));
					}
					if (Enumerable.Any<SpatialBaseElement>(enumerable2, func2))
					{
						for (;;)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						ProgressWindow u001F = \u0008\u000C\u0018.\u000A(\u001B\u000C\u0018.\u000A(\u0011\u0020\u000A.\u0007(this._uidocument), \u0006\u000A\u0005.\u000A(this), list));
						\u0015\u000D\u001D.\u000A(u001F, \u0018\u000B\u0007.\u0007(this));
						\u0018\u0020\u000A.\u0007(u001F);
					}
				}
				SpatialModel.\u001B\u0003 u001B_u2 = u001B_u;
				IEnumerable<RevitParameter> enumerable3 = SpatialBaseElement.LO();
				Func<RevitParameter, long> func3;
				if ((func3 = SpatialModel.<>c.\u0016) == null)
				{
					for (;;)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					func3 = (SpatialModel.<>c.\u0016 = new Func<RevitParameter, long>(SpatialModel.<>c.\u001F.\u001B));
				}
				u001B_u2.\u001F = Enumerable.ToList<long>(Enumerable.Select<RevitParameter, long>(enumerable3, func3));
				\u000E\u000C\u0018.\u000A(this._parametersModel, \u0018\u0014\u0019.\u000A(Enumerable.Where<RevitParameter>(\u001B\u0014\u0019.\u0007(\u0006\u000A\u0005.\u000A(this)), new Func<RevitParameter, bool>(u001B_u.\u000A))));
				\u0010\u000C\u0018.\u000A(this._parametersModel, \u0018\u0014\u0019.\u000A(\u000D\u000E\u0018.\u000A()));
			}
		}

		// Token: 0x06001478 RID: 5240 RVA: 0x00084D88 File Offset: 0x00082F88
		private void JXR()
		{
			if (\u0002\u000A\u0005.\u000A(this))
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.JXR()).MethodHandle;
				}
				ElementFilter elementFilter = \u001E\u0002\u000E.\u001F;
				ExportTypes exportTypes = \u0014\u000A\u0005.\u000A(\u0015\u001F\u0005.\u000A(this));
				if (exportTypes != ExportTypes.Rooms)
				{
					for (;;)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					if (exportTypes != ExportTypes.Spaces)
					{
						for (;;)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					else
					{
						elementFilter = \u0020\u000A\u0005.\u000A();
					}
				}
				else
				{
					elementFilter = \u0017\u000A\u0005.\u000A();
				}
				Document u001F = \u0011\u0020\u000A.\u0007(this._uidocument);
				object u001F2 = \u0011\u0011\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(u001F), -2001352L), \u001E\u0011\u000A.\u000A(\u0020\u0002\u000E.\u001F()));
				Dictionary<string, bool> u001F3 = \u001E\u000A\u0005.\u000A();
				IEnumerator<Element> enumerator = \u0009\u000C\u0004.\u000A(u001F2);
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						RevitLinkType u001F4 = \u0017\u0002\u000E.\u001F(\u0001\u000C\u0004.\u000A(enumerator));
						IEnumerator u001F5 = \u001B\u000A\u0005.\u000A(\u0011\u000A\u0005.\u000A(\u0017\u0005\u0004.\u0007(u001F)));
						try
						{
							while (\u000A\u0017\u000A.\u000A(u001F5))
							{
								Document u001F6 = \u0014\u0002\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F5));
								string u000A = \u001C\u000B\u001D.\u0007(\u0005\u001E\u000A.\u000A(u001F4), ".rvt", "");
								if (\u000D\u001F\u001D.\u000A(\u001C\u000B\u001D.\u0007(\u0014\u0009\u0007.\u0007(u001F6), ".rvt", ""), u000A))
								{
									for (;;)
									{
										switch (7)
										{
										case 0:
											continue;
										}
										break;
									}
									bool flag;
									if (!\u0008\u000A\u0005.\u000A(u001F3, \u0005\u001A\u000A.\u0007(u001F6), ref flag))
									{
										for (;;)
										{
											switch (3)
											{
											case 0:
												continue;
											}
											break;
										}
										\u000E\u000A\u0005.\u000A(u001F3, \u0005\u001A\u000A.\u0007(u001F6), true);
										FilteredElementCollector u001F7 = \u0020\u0011\u000A.\u000A(u001F6);
										if (elementFilter != null)
										{
											for (;;)
											{
												switch (6)
												{
												case 0:
													continue;
												}
												break;
											}
											List<Element>.Enumerator enumerator2 = \u0001\u0010\u0007.\u000A(Enumerable.ToList<Element>(\u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(\u0014\u0011\u000A.\u0007(u001F7, elementFilter)))));
											try
											{
												while (\u000C\u0010\u0007.\u000A(ref enumerator2))
												{
													Element u001F8 = \u0015\u0010\u0007.\u000A(ref enumerator2);
													\u001D\u000A\u0005.\u000A(\u0018\u000A\u0005.\u000A(this), \u0010\u000A\u0005.\u000A(u001F8, true, \u0005\u001E\u000A.\u000A(u001F4)));
												}
												for (;;)
												{
													switch (2)
													{
													case 0:
														continue;
													}
													break;
												}
											}
											finally
											{
												((IDisposable)enumerator2).Dispose();
											}
										}
									}
								}
							}
							for (;;)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						finally
						{
							IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F5);
							if (disposable != null)
							{
								for (;;)
								{
									switch (7)
									{
									case 0:
										continue;
									}
									break;
								}
								\u001F\u0017\u000A.\u000A(disposable);
							}
						}
					}
					for (;;)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					return;
				}
				finally
				{
					if (enumerator != null)
					{
						for (;;)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
			}
			IEnumerable<SpatialBaseElement> enumerable = \u0018\u000A\u0005.\u000A(this);
			Func<SpatialBaseElement, bool> func;
			if ((func = SpatialModel.<>c.\u000B) == null)
			{
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				func = (SpatialModel.<>c.\u000B = new Func<SpatialBaseElement, bool>(SpatialModel.<>c.\u001F.\u0011));
			}
			List<SpatialBaseElement>.Enumerator enumerator3 = \u000D\u000A\u0005.\u000A(Enumerable.ToList<SpatialBaseElement>(Enumerable.Where<SpatialBaseElement>(enumerable, func)));
			try
			{
				while (\u0012\u000A\u0005.\u000A(ref enumerator3))
				{
					SpatialBaseElement u000A2 = \u001C\u000A\u0005.\u000A(ref enumerator3);
					\u0003\u000A\u0005.\u000A(\u0018\u000A\u0005.\u000A(this), u000A2);
				}
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)enumerator3).Dispose();
			}
		}

		// Token: 0x06001479 RID: 5241 RVA: 0x00085100 File Offset: 0x00083300
		public void SetStatus()
		{
			string[] array = \u001B\u001F\u000E.\u001F(11);
			array[0] = \u001A\u000A\u0005.\u000A();
			array[1] = " ";
			int num = 2;
			ObservableCollection<SpatialBaseElement> observableCollection = \u0018\u000A\u0005.\u000A(this);
			int? num2;
			int? num3;
			if (observableCollection == null)
			{
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.SetStatus()).MethodHandle;
				}
				\u000B\u0007\u000E.\u001F(ref num2);
				num3 = num2;
			}
			else
			{
				Func<SpatialBaseElement, bool> func;
				if ((func = SpatialModel.<>c.\u0002) == null)
				{
					for (;;)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					func = (SpatialModel.<>c.\u0002 = new Func<SpatialBaseElement, bool>(SpatialModel.<>c.\u001F.\u001E));
				}
				num3 = new int?(Enumerable.Count<SpatialBaseElement>(observableCollection, func));
			}
			num2 = num3;
			array[num] = num2.ToString();
			array[3] = " | ";
			array[4] = \u001C\u0013\u0019.\u000A();
			array[5] = " ";
			int num4 = 6;
			ObservableCollection<BaseParameter> observableCollection2 = \u000E\u0013\u0018.\u0007(this._parametersModel);
			int? num5;
			if (observableCollection2 == null)
			{
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				\u000B\u0007\u000E.\u001F(ref num2);
				num5 = num2;
			}
			else
			{
				num5 = new int?(\u0012\u001A\u0018.\u001D(observableCollection2));
			}
			num2 = num5;
			array[num4] = num2.ToString();
			array[7] = " | ";
			array[8] = \u000F\u001A\u0018.\u000A();
			array[9] = " ";
			int num6 = 10;
			ObservableCollection<BaseParameter> observableCollection3 = \u001B\u0013\u0018.\u000A(this._parametersModel);
			int? num7;
			if (observableCollection3 == null)
			{
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				\u000B\u0007\u000E.\u001F(ref num2);
				num7 = num2;
			}
			else
			{
				num7 = new int?(\u0012\u001A\u0018.\u001D(observableCollection3));
			}
			num2 = num7;
			array[num6] = num2.ToString();
			\u0013\u000A\u0005.\u000A(this, \u0014\u0006\u001D.\u000A(array));
		}

		// Token: 0x0600147A RID: 5242 RVA: 0x00085264 File Offset: 0x00083464
		public void OnExportClicked()
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Spatial\\SpatialModel.cs", "OnExportClicked");
			ExportOptions u001F = \u0013\u000C\u0018.\u000A(false, false);
			\u0015\u000D\u001D.\u000A(u001F, \u0018\u000B\u0007.\u0007(this));
			bool? flag = \u0018\u0020\u000A.\u0007(u001F);
			if (\u0012\u0015\u000A.\u000A(ref flag))
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.OnExportClicked()).MethodHandle;
				}
				ExportOption exportOption = \u001D\u0013\u0019.\u000A(u001F);
				if (\u0017\u0014\u0019.\u000A(exportOption))
				{
					for (;;)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					\u0015\u000A\u0005.\u000A(this, exportOption);
				}
				else
				{
					\u000C\u000A\u0005.\u000A(this, exportOption);
				}
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Spatial\\SpatialModel.cs", "OnExportClicked");
		}

		// Token: 0x0600147B RID: 5243 RVA: 0x0008530C File Offset: 0x0008350C
		public void ExportToExcel(IExportOption exportOption)
		{
			if (\u0004\u000A\u0005.\u0007(this.AU.L) != null)
			{
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.ExportToExcel(IExportOption)).MethodHandle;
				}
				List<CategoryCollection> list = this.WXR();
				string u = \u0004\u000F.\u0018(this.KXR(list), false, true);
				\u0001\u000A\u0005.\u000A(this, Enumerable.ToList<CategoryCollection>(list), u, exportOption);
			}
		}

		// Token: 0x0600147C RID: 5244 RVA: 0x0008536C File Offset: 0x0008356C
		public void ExportToExcel(List<CategoryCollection> catCollections, string filePath, IExportOption exportOption)
		{
			if (\u0020\u0003.\u001F(catCollections, \u0018\u000B\u0007.\u0007(this), ref filePath))
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.ExportToExcel(List<CategoryCollection>, string, IExportOption)).MethodHandle;
				}
				\u0017\u0010 u0017_u = new \u0017\u0010();
				\u001E\u0014\u0019.\u000A(u0017_u, \u0006\u000A\u0005.\u000A(this));
				\u0011\u0014\u0019.\u000A(u0017_u, catCollections);
				\u0008\u0014\u0019.\u000A(u0017_u, this.EXR(catCollections));
				\u001C\u0020\u0018.\u000A(\u000C\u000C\u0018.\u0007(u0017_u), new Action<RevitParameter>(this.ZXR));
				\u0010\u001A\u0018.\u000A(exportOption, filePath);
				\u000E\u0014\u0019.\u000A(u0017_u, exportOption);
				u0017_u.\u001F += this.TaskFinished;
				\u000D\u0014\u0019.\u000A(u0017_u, \u0010\u0014\u0019.\u0007(this.ActiveProgressBar));
				\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u0017_u);
				\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
			}
		}

		// Token: 0x0600147D RID: 5245 RVA: 0x00085434 File Offset: 0x00083634
		public void OnExportToDriveClicked()
		{
		}

		// Token: 0x0600147E RID: 5246 RVA: 0x00085444 File Offset: 0x00083644
		public void ExportToDrive(IExportOption exportOption)
		{
			if (\u0004\u000A\u0005.\u0007(this.AU.L) != null)
			{
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.ExportToDrive(IExportOption)).MethodHandle;
				}
				List<CategoryCollection> list = this.WXR();
				\u001B\u001A\u0018.\u000A(exportOption, this.KXR(list));
				\u0009\u000A\u0005.\u000A(this, Enumerable.ToList<CategoryCollection>(list), exportOption, false);
			}
		}

		// Token: 0x0600147F RID: 5247 RVA: 0x000854A0 File Offset: 0x000836A0
		public void ExportToDrive(List<CategoryCollection> catCollections, IExportOption exportOption, bool projectStandards = false)
		{
			string u001F = \u0009\u000C\u0018.\u000A(exportOption);
			\u0010\u001A\u0018.\u000A(exportOption, \u001B\u0015\u001D.\u000A(\u0004\u000F.\u0019(), \u0004\u001E\u000A.\u000A(u001F, ".xlsx")));
			\u001B\u0010 u001B_u = new \u001B\u0010();
			\u001E\u0014\u0019.\u000A(u001B_u, \u0006\u000A\u0005.\u000A(this));
			\u0011\u0014\u0019.\u000A(u001B_u, catCollections);
			\u0008\u0014\u0019.\u000A(u001B_u, this.EXR(catCollections));
			\u001C\u0020\u0018.\u000A(\u000C\u000C\u0018.\u0007(u001B_u), new Action<RevitParameter>(this.XXR));
			\u0001\u000C\u0018.\u000A(u001B_u, new Action<string, string>(this.OMR));
			\u000D\u0014\u0019.\u000A(u001B_u, \u0010\u0014\u0019.\u0007(this.ActiveProgressBar));
			\u000E\u0014\u0019.\u000A(u001B_u, exportOption);
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u001B_u);
			\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x00085560 File Offset: 0x00083760
		private void OMR(string F, string R)
		{
			PluginInfo u001F = \u000F\u0013\u0019.\u000A();
			List<string> list = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list, R);
			DriveSelection u001F2 = \u0006\u0013\u0019.\u000A(u001F, list, true);
			\u0015\u000D\u001D.\u000A(u001F2, \u0018\u000B\u0007.\u0007(this));
			\u0018\u0020\u000A.\u0007(u001F2);
			\u0020\u0008\u000A.\u001F(R);
		}

		// Token: 0x06001481 RID: 5249 RVA: 0x000855AC File Offset: 0x000837AC
		public void TaskFinished(ITaskFinishedArgs taskFinished)
		{
			ExportTaskArgs u001F = \u0019\u0002\u000E.\u001F(taskFinished);
			\u001F\u0007\u0005.\u000A(this, \u001A\u0013\u0019.\u000A(u001F), \u0017\u0013\u0019.\u000A(u001F));
			\u0002\u0013\u0019.\u0007(\u0010\u0014\u0019.\u0007(this.ActiveProgressBar));
		}

		// Token: 0x06001482 RID: 5250 RVA: 0x000855EC File Offset: 0x000837EC
		protected void OpenFile(string filePath, bool openSpreadSheet)
		{
			if (openSpreadSheet)
			{
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.OpenFile(string, bool)).MethodHandle;
				}
				\u0004\u0019\u0019.\u000A(filePath);
				return;
			}
			\u0008\u0011\u001D.\u000A(\u0001\u0013\u0019.\u000A());
		}

		// Token: 0x06001483 RID: 5251 RVA: 0x00085628 File Offset: 0x00083828
		private List<RevitParameter> EXR(List<CategoryCollection> F)
		{
			List<RevitParameter> list = \u000D\u000E\u0018.\u000A();
			List<RevitParameter> list2 = SpatialBaseElement.LO();
			if (\u0008\u000D\u0018.\u000A(\u001B\u0014\u0019.\u0007(\u0006\u000A\u0005.\u000A(this))) > 0)
			{
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.EXR(List<CategoryCollection>)).MethodHandle;
				}
				IEnumerable<RevitParameter> enumerable = list2;
				Func<RevitParameter, long> func;
				if ((func = SpatialModel.<>c.\u0006) == null)
				{
					for (;;)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					func = (SpatialModel.<>c.\u0006 = new Func<RevitParameter, long>(SpatialModel.<>c.\u001F.\u0020));
				}
				List<long>.Enumerator enumerator = \u0015\u0013\u0018.\u000A(Enumerable.ToList<long>(Enumerable.Select<RevitParameter, long>(enumerable, func)));
				try
				{
					while (\u0017\u0013\u0018.\u000A(ref enumerator))
					{
						SpatialModel.\u0011\u0003 u0011_u = new SpatialModel.\u0011\u0003();
						u0011_u.\u001F = \u000C\u0013\u0018.\u000A(ref enumerator);
						RevitParameter revitParameter = Enumerable.FirstOrDefault<RevitParameter>(\u001B\u0014\u0019.\u0007(\u0006\u000A\u0005.\u000A(this)), new Func<RevitParameter, bool>(u0011_u.\u000A));
						if (revitParameter != null)
						{
							for (;;)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							\u0017\u0010\u0018.\u000A(list, revitParameter);
						}
					}
					for (;;)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				\u000D\u0020\u0018.\u000A(list, Enumerable.ToList<RevitParameter>(Enumerable.Cast<RevitParameter>(\u001B\u0013\u0018.\u000A(this._parametersModel))));
			}
			else
			{
				ParamNameGroupUniqueHandler.\u0018(\u0006\u000A\u0005.\u000A(this), list2);
				ParamUniqueHandler.\u001D(\u0006\u000A\u0005.\u000A(this), list2, \u000B\u001E\u0018.\u000A(F, 0));
				List<RevitParameter>.Enumerator enumerator2 = \u0013\u000D\u0018.\u000A(list2);
				try
				{
					while (\u0011\u000D\u0018.\u000A(ref enumerator2))
					{
						RevitParameter revitParameter2 = \u0014\u000D\u0018.\u000A(ref enumerator2);
						\u000A\u0007\u0005.\u0007(revitParameter2, \u0013\u000E\u0018.\u0007(\u000B\u001E\u0018.\u000A(F, 0)));
						RevitParameter.FO(\u0006\u000A\u0005.\u000A(this), revitParameter2, \u000B\u001E\u0018.\u000A(F, 0));
					}
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				\u000D\u0020\u0018.\u000A(list, list2);
			}
			return list;
		}

		// Token: 0x06001484 RID: 5252 RVA: 0x00085804 File Offset: 0x00083A04
		public virtual void ExportProjectStandards()
		{
			StandardExportOptions u001F = \u0012\u000C\u0018.\u000A();
			\u0015\u000D\u001D.\u000A(u001F, \u0018\u000B\u0007.\u0007(this));
			bool? flag = \u0018\u0020\u000A.\u0007(u001F);
			if (\u0012\u0015\u000A.\u000A(ref flag))
			{
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.ExportProjectStandards()).MethodHandle;
				}
				SpatialModel.\u001E\u0003 u001E_u = new SpatialModel.\u001E\u0003();
				u001E_u.\u001F = \u000F\u000C\u0018.\u0007(u001F);
				List<CategoryCollection> list = CategoryCollection.QP();
				list = Enumerable.ToList<CategoryCollection>(Enumerable.Where<CategoryCollection>(list, new Func<CategoryCollection, bool>(u001E_u.\u000A)));
				string text = \u001F\u0011\u0018.\u000A().\u001F();
				if (\u0006\u000C\u0018.\u000A(u001F))
				{
					for (;;)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					string text2 = \u0004\u000F.\u0018(text, true, false);
					if (!\u001A\u0006\u0007.\u000A(text2))
					{
						for (;;)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						\u0009\u0014\u0019.\u000A(\u0010\u0014\u0019.\u0007(this.ActiveProgressBar), \u0020\u0014\u0018.\u000A(list), \u0018\u000E\u0007.\u000A(\u000C\u0013\u0019.\u000A(), 1, 1));
						\u0020\u0003.\u000A(list, text2, \u0002\u000C\u0018.\u000A(u001F), true, \u0006\u000F\u0018.\u0007(\u0010\u0014\u0019.\u0007(this.ActiveProgressBar)));
						return;
					}
				}
				else
				{
					List<CategoryCollection> u000A = list;
					ExportOption exportOption = \u000B\u000C\u0018.\u000A();
					\u0016\u000C\u0018.\u000A(exportOption, text);
					\u0009\u000A\u0005.\u000A(this, u000A, exportOption, true);
				}
			}
		}

		// Token: 0x06001485 RID: 5253 RVA: 0x00085948 File Offset: 0x00083B48
		public void GetData(Delegate showPreview)
		{
			List<CategoryCollection> list = this.WXR();
			\u0009\u0014\u0019.\u000A(\u0010\u0014\u0019.\u0007(this.ActiveProgressBar), \u0020\u0014\u0018.\u000A(list), \u0018\u000E\u0007.\u000A(\u001F\u0013\u0019.\u000A(), 1, 1));
			\u0014\u0010 u0014_u = new \u0014\u0010();
			\u001E\u0014\u0019.\u000A(u0014_u, \u0006\u000A\u0005.\u000A(this));
			\u0011\u0014\u0019.\u000A(u0014_u, list);
			\u0008\u0014\u0019.\u000A(u0014_u, this.EXR(list));
			\u001C\u0020\u0018.\u000A(\u000C\u000C\u0018.\u0007(u0014_u), new Action<RevitParameter>(this.PXR));
			\u0007\u0007\u0005.\u000A(u0014_u, \u0014\u000A\u0005.\u000A(\u0015\u001F\u0005.\u000A(this)));
			\u000E\u0014\u0019.\u000A(u0014_u, \u000B\u000C\u0018.\u000A());
			\u000D\u0014\u0019.\u000A(u0014_u, \u0010\u0014\u0019.\u0007(this.ActiveProgressBar));
			\u0001\u000C\u0018.\u000A(u0014_u, showPreview);
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u0014_u);
			\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
		}

		// Token: 0x06001486 RID: 5254 RVA: 0x00085A2C File Offset: 0x00083C2C
		private void OVR(List<SpatialBaseElement> F, MenuContext R)
		{
			List<ElementId> list = \u001C\u0013\u000A.\u000A();
			object u001F = list;
			Func<SpatialBaseElement, ElementId> func;
			if ((func = SpatialModel.<>c.\u000F) == null)
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.OVR(List<SpatialBaseElement>, MenuContext)).MethodHandle;
				}
				func = (SpatialModel.<>c.\u000F = new Func<SpatialBaseElement, ElementId>(SpatialModel.<>c.\u001F.\u0017));
			}
			\u000F\u0013\u000A.\u000A(u001F, Enumerable.Select<SpatialBaseElement, ElementId>(F, func));
			try
			{
				if (\u001A\u0014\u000A.\u000A(list) > 0)
				{
					for (;;)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					if (R == MenuContext.Select)
					{
						for (;;)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						\u0004\u0007\u0005.\u000A(this, list);
					}
					else if (R == MenuContext.Show)
					{
						for (;;)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							break;
						}
						\u001D\u0007\u0005.\u000A(this, list);
					}
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Spatial\\SpatialModel.cs", "ContextMenuHandler");
			}
		}

		// Token: 0x06001487 RID: 5255 RVA: 0x00085AF0 File Offset: 0x00083CF0
		public void SelectElements(List<ElementId> elementIds)
		{
			\u000D\u001E\u000A.\u000A(\u0010\u001E\u000A.\u0007(this._uidocument), elementIds);
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x00085B10 File Offset: 0x00083D10
		public void ShowElements(List<ElementId> elementIds)
		{
			\u000D\u001E\u000A.\u000A(\u0010\u001E\u000A.\u0007(this._uidocument), elementIds);
			\u000E\u0013\u000A.\u000A(this._uidocument, elementIds);
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x00085B3C File Offset: 0x00083D3C
		public void OnResetClicked()
		{
			\u0009\u001F\u0005.\u000A(this, false);
			\u0019\u0007\u0005.\u000A(this.AU.L);
			\u0011\u001A\u0018.\u000A(this.AU.B);
			if (\u0015\u001F\u0005.\u000A(this) == Enumerable.First<CategoryCollection>(\u001C\u001F\u0005.\u000A(this)))
			{
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.OnResetClicked()).MethodHandle;
				}
				this.UXR();
			}
			else
			{
				\u0003\u001F\u0005.\u000A(this, Enumerable.First<CategoryCollection>(\u001C\u001F\u0005.\u000A(this)));
			}
			\u0006\u001F\u0005.\u000A(this);
		}

		// Token: 0x0600148A RID: 5258 RVA: 0x00085BC0 File Offset: 0x00083DC0
		public void OnRefreshClicked()
		{
			this.UXR();
		}

		// Token: 0x0600148B RID: 5259 RVA: 0x00085BD4 File Offset: 0x00083DD4
		public void CustomDispose()
		{
			this._uidocument = \u0009\u000B\u000E.\u001F;
			\u0013\u001F\u0005.\u000A(this, \u001B\u0002\u000E.\u001F);
			\u0010\u001F\u0005.\u000A(this, \u000A\u0002\u000E.\u001F);
			SpatialNavigator l = this.AU.L;
			\u000F\u001F\u0005.\u000A(l, (SpatialNavigator.ContextMenuDelegate)\u0012\u001E\u000A.\u000A(\u0012\u001F\u0005.\u0007(l), new SpatialNavigator.ContextMenuDelegate(this.OVR)));
			this.AU = \u0011\u0002\u000E.\u001F;
			RevitParametersModel parametersModel = this._parametersModel;
			\u0014\u0014\u0018.\u000A(parametersModel, \u0020\u000B\u000E.\u001F(\u0012\u001E\u000A.\u000A(\u0013\u0014\u0018.\u0007(parametersModel), new ParameterBaseModel<BaseParameter>.CollectionChangedDelegate(this.SetStatus))));
			this._parametersModel = \u0007\u0002\u000E.\u001F;
			CustomProgressBar activeProgressBar = this.ActiveProgressBar;
			if (activeProgressBar == null)
			{
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialModel.CustomDispose()).MethodHandle;
				}
			}
			else
			{
				\u0018\u001A\u0019.\u000A(\u0010\u0014\u0019.\u001D(activeProgressBar), \u000D\u0018\u000E.\u001F);
			}
			this.ActiveProgressBar = \u001D\u0002\u000E.\u001F;
			\u000A\u000C\u0007.\u001D(this, \u000D\u0018\u000E.\u001F);
		}

		// Token: 0x0600148C RID: 5260 RVA: 0x00085CBC File Offset: 0x00083EBC
		[CompilerGenerated]
		private ObservableCollection<SpatialBaseElement> NXR()
		{
			return \u0018\u000A\u0005.\u000A(this);
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x00085CD4 File Offset: 0x00083ED4
		[CompilerGenerated]
		private string MXR()
		{
			return \u0018\u0007\u0005.\u000A(this);
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x00085CEC File Offset: 0x00083EEC
		[CompilerGenerated]
		private bool VXR(CategoryCollection F)
		{
			return \u0013\u000E\u0018.\u0007(F) == \u0013\u000E\u0018.\u0007(\u0015\u001F\u0005.\u000A(this));
		}

		// Token: 0x0600148F RID: 5263 RVA: 0x00085D14 File Offset: 0x00083F14
		[CompilerGenerated]
		private void ZXR(RevitParameter F)
		{
			\u0005\u0007\u0005.\u000A(F, \u0014\u000A\u0005.\u000A(\u0015\u001F\u0005.\u000A(this)));
		}

		// Token: 0x06001490 RID: 5264 RVA: 0x00085D38 File Offset: 0x00083F38
		[CompilerGenerated]
		private void XXR(RevitParameter F)
		{
			\u0005\u0007\u0005.\u000A(F, \u0014\u000A\u0005.\u000A(\u0015\u001F\u0005.\u000A(this)));
		}

		// Token: 0x06001491 RID: 5265 RVA: 0x00085D5C File Offset: 0x00083F5C
		[CompilerGenerated]
		private void PXR(RevitParameter F)
		{
			\u0005\u0007\u0005.\u000A(F, \u0014\u000A\u0005.\u000A(\u0015\u001F\u0005.\u000A(this)));
		}

		// Token: 0x040007D0 RID: 2000
		private ObservableCollection<SpatialBaseElement> LC;

		// Token: 0x040007D1 RID: 2001
		private int SD;

		// Token: 0x040007D2 RID: 2002
		private bool GU;

		// Token: 0x040007D3 RID: 2003
		protected CustomProgressBar ActiveProgressBar;

		// Token: 0x040007D4 RID: 2004
		protected RevitParametersModel _parametersModel;

		// Token: 0x040007D5 RID: 2005
		protected UIDocument _uidocument;

		// Token: 0x040007D6 RID: 2006
		private string PB;

		// Token: 0x040007D7 RID: 2007
		private bool OB = true;

		// Token: 0x040007D8 RID: 2008
		private CategoryCollection IW;

		// Token: 0x040007D9 RID: 2009
		private SpatialControl AU;

		// Token: 0x040007DA RID: 2010
		[CompilerGenerated]
		private \u0015\u001C CW;

		// Token: 0x040007DB RID: 2011
		private static readonly List<CategoryCollection> QW;

		// Token: 0x020008DD RID: 2269
		[CompilerGenerated]
		private sealed class \u001C\u0003
		{
			// Token: 0x060050CF RID: 20687 RVA: 0x001E79FC File Offset: 0x001E5BFC
			internal bool \u000A(CategoryCollection \u001F)
			{
				return \u0013\u000E\u0018.\u0007(\u001F) == \u001B\u0016\u0010.\u000A(this.\u001F);
			}

			// Token: 0x04002344 RID: 9028
			public TemplateInfo \u001F;
		}

		// Token: 0x020008DE RID: 2270
		[CompilerGenerated]
		private sealed class \u000D\u0003
		{
			// Token: 0x060050D1 RID: 20689 RVA: 0x001E7A34 File Offset: 0x001E5C34
			internal bool \u000A(SpatialBaseElement \u001F)
			{
				return \u001A\u0016\u0010.\u000A(\u001F) == (long)this.\u001F;
			}

			// Token: 0x04002345 RID: 9029
			public int \u001F;
		}

		// Token: 0x020008DF RID: 2271
		[CompilerGenerated]
		private sealed class \u0010\u0003
		{
			// Token: 0x060050D3 RID: 20691 RVA: 0x001E7A68 File Offset: 0x001E5C68
			internal bool \u000A(BaseParameter \u001F)
			{
				return \u001A\u0008\u0019.\u000A(\u0005\u001B\u0005.\u001D(this.\u001F), \u0017\u000B\u0018.\u0007(\u001F));
			}

			// Token: 0x04002346 RID: 9030
			public ParamExportInfo \u001F;
		}

		// Token: 0x020008E0 RID: 2272
		[CompilerGenerated]
		private sealed class \u000E\u0003
		{
			// Token: 0x060050D5 RID: 20693 RVA: 0x001E7AA8 File Offset: 0x001E5CA8
			internal bool \u0007(RevitParameter \u001F)
			{
				return \u001F\u0020\u001D.\u000A(this.\u001F, \u000F\u0020\u0018.\u0007(\u001F));
			}

			// Token: 0x060050D6 RID: 20694 RVA: 0x001E7ACC File Offset: 0x001E5CCC
			internal bool \u001D(BaseParameter \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u000F\u0020\u0018.\u0007(\u001F), \u000F\u0020\u0018.\u0007(this.\u000A));
			}

			// Token: 0x04002347 RID: 9031
			public List<string> \u001F;

			// Token: 0x04002348 RID: 9032
			public RevitParameter \u000A;
		}

		// Token: 0x020008E1 RID: 2273
		[CompilerGenerated]
		private sealed class \u0008\u0003
		{
			// Token: 0x060050D8 RID: 20696 RVA: 0x001E7B0C File Offset: 0x001E5D0C
			internal ParamExportInfo \u0007(BaseParameter \u001F)
			{
				return ParamExportInfo.\u001D(\u0006\u000A\u0005.\u000A(this.\u001F), \u0018\u0012\u000E.\u001F(\u001F), this.\u000A);
			}

			// Token: 0x04002349 RID: 9033
			public SpatialModel \u001F;

			// Token: 0x0400234A RID: 9034
			public List<CategoryCollection> \u000A;
		}

		// Token: 0x020008E2 RID: 2274
		[CompilerGenerated]
		private sealed class \u001B\u0003
		{
			// Token: 0x060050DA RID: 20698 RVA: 0x001E7B50 File Offset: 0x001E5D50
			internal bool \u000A(RevitParameter \u001F)
			{
				return !\u001A\u0008\u0019.\u000A(this.\u001F, \u0017\u000B\u0018.\u0007(\u001F));
			}

			// Token: 0x0400234B RID: 9035
			public List<long> \u001F;
		}

		// Token: 0x020008E3 RID: 2275
		[CompilerGenerated]
		private sealed class \u0011\u0003
		{
			// Token: 0x060050DC RID: 20700 RVA: 0x001E7B8C File Offset: 0x001E5D8C
			internal bool \u000A(RevitParameter \u001F)
			{
				return \u0017\u000B\u0018.\u0007(\u001F) == this.\u001F;
			}

			// Token: 0x0400234C RID: 9036
			public long \u001F;
		}

		// Token: 0x020008E4 RID: 2276
		[CompilerGenerated]
		private sealed class \u001E\u0003
		{
			// Token: 0x060050DE RID: 20702 RVA: 0x001E7BC0 File Offset: 0x001E5DC0
			internal bool \u000A(CategoryCollection \u001F)
			{
				return \u001F\u0020\u001D.\u000A(this.\u001F, \u0012\u001E\u0018.\u000A(\u001F));
			}

			// Token: 0x0400234D RID: 9037
			public List<string> \u001F;
		}
	}
}
