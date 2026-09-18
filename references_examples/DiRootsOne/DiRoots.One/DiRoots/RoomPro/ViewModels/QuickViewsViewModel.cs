using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.Profiles;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.QuickViews.Models;
using DiRoots.One.QuickViews.Models.Profile;
using DiRoots.One.SheetGen.Models;
using DiRoots.One.UIBehaviours.Extensions;
using DiRoots.RoomPro.Comparers;
using DiRoots.RoomPro.Enums;
using DiRoots.RoomPro.Interfaces;
using DiRoots.RoomPro.Models;
using DiRoots.RoomPro.UI.Windows;

namespace DiRoots.RoomPro.ViewModels
{
	// Token: 0x0200005B RID: 91
	public class QuickViewsViewModel : ViewModelBase
	{
		// Token: 0x06000361 RID: 865 RVA: 0x00015568 File Offset: 0x00013768
		public QuickViewsViewModel(Document doc)
		{
			List<SpatialType> list = new List<SpatialType>();
			\u0020\u0003\u0007.\u000A(list, SpatialType.Room);
			\u0020\u0003\u0007.\u000A(list, SpatialType.Space);
			this.JD = list;
			List<SpatialStatus> list2 = new List<SpatialStatus>();
			\u001E\u0003\u0007.\u000A(list2, SpatialStatus.NotCreated);
			\u001E\u0003\u0007.\u000A(list2, SpatialStatus.Created);
			\u001E\u0003\u0007.\u000A(list2, SpatialStatus.Changed);
			this.ED = list2;
			this.PD = "";
			List<SpatialType> list3 = new List<SpatialType>();
			\u0020\u0003\u0007.\u000A(list3, SpatialType.Room);
			\u0020\u0003\u0007.\u000A(list3, SpatialType.Space);
			this.SpatialTypes = list3;
			List<SpatialStatus> list4 = new List<SpatialStatus>();
			\u001E\u0003\u0007.\u000A(list4, SpatialStatus.NotCreated);
			\u001E\u0003\u0007.\u000A(list4, SpatialStatus.Created);
			\u001E\u0003\u0007.\u000A(list4, SpatialStatus.Changed);
			this.SpatialTypesStatuses = list4;
			this.SelectedElements = new ObservableCollection<IModelElement>();
			base..ctor();
			\u0011\u0003\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\ViewModels\\QuickViewsViewModel.cs", ".ctor");
			this.R = doc;
			\u001B\u0003\u0007.\u000A(this, new UIDocument(doc));
			this.CR = new \u0013\u001D(this.R);
			\u0008\u0003\u0007.\u000A(new CallOutInfo());
			\u000E\u0003\u0007.\u000A(this, new SubItems());
			\u0010\u0003\u0007.\u000A(this, new SubItems());
			\u000D\u0003\u0007.\u000A(this, new SubItems());
			\u001C\u0003\u0007.\u000A(this, new SubItems());
			\u0003\u0003\u0007.\u000A(new SectionElevationInfo());
			this.DER();
			\u000A\u0004 u000A_u = new \u000A\u0004(doc);
			this.WD = u000A_u.\u000A();
			\u0012\u0003\u0007.\u000A(this, new ViewFilters());
			object u001F = \u0006\u0003\u0007.\u000A(this);
			List<SelectionNamedItem> list5 = new List<SelectionNamedItem>();
			SelectionNamedItem selectionNamedItem = new SelectionNamedItem(101, \u000F\u0003\u0007.\u000A());
			\u001A\u0012\u0007.\u000A(selectionNamedItem, true);
			\u000C\u0012\u0007.\u000A(selectionNamedItem, true);
			\u0013\u0012\u0007.\u000A(list5, selectionNamedItem);
			SelectionNamedItem selectionNamedItem2 = new SelectionNamedItem(100, \u0016\u0003\u0007.\u000A());
			\u001A\u0012\u0007.\u000A(selectionNamedItem2, true);
			\u000C\u0012\u0007.\u000A(selectionNamedItem2, true);
			\u0013\u0012\u0007.\u000A(list5, selectionNamedItem2);
			SelectionNamedItem selectionNamedItem3 = new SelectionNamedItem(1, \u0005\u0003\u0007.\u000A());
			\u000C\u0012\u0007.\u000A(selectionNamedItem3, true);
			\u0004\u0003\u0007.\u000A(selectionNamedItem3, "");
			\u0013\u0012\u0007.\u000A(list5, selectionNamedItem3);
			SelectionNamedItem selectionNamedItem4 = new SelectionNamedItem(0, \u0018\u0003\u0007.\u000A());
			\u000C\u0012\u0007.\u000A(selectionNamedItem4, true);
			\u0004\u0003\u0007.\u000A(selectionNamedItem4, "");
			\u0013\u0012\u0007.\u000A(list5, selectionNamedItem4);
			SelectionNamedItem selectionNamedItem5 = new SelectionNamedItem(2, \u0019\u0003\u0007.\u000A());
			\u000C\u0012\u0007.\u000A(selectionNamedItem5, true);
			\u0004\u0003\u0007.\u000A(selectionNamedItem5, "");
			\u0013\u0012\u0007.\u000A(list5, selectionNamedItem5);
			\u0014\u0012\u0007.\u000A(u001F, list5);
			\u0017\u0012\u0007.\u000A(\u0006\u0003\u0007.\u000A(this), 0);
			\u001B\u0012\u0007.\u000A(\u0006\u0003\u0007.\u000A(this), \u0011\u0012\u0007.\u000A(\u001E\u0012\u0007.\u000A(\u0006\u0003\u0007.\u000A(this)), 0));
			\u0007\u0003\u0007.\u000A(\u0006\u0003\u0007.\u000A(this), \u001E\u0012\u0007.\u000A(\u0006\u0003\u0007.\u000A(this)));
			\u0002\u0003\u0007.\u000A(this, new ViewFilters());
			object u001F2 = \u001D\u0003\u0007.\u000A(this);
			List<SelectionNamedItem> list6 = new List<SelectionNamedItem>();
			SelectionNamedItem selectionNamedItem6 = new SelectionNamedItem(101, \u000B\u0003\u0007.\u000A());
			\u001A\u0012\u0007.\u000A(selectionNamedItem6, true);
			\u000C\u0012\u0007.\u000A(selectionNamedItem6, true);
			\u0013\u0012\u0007.\u000A(list6, selectionNamedItem6);
			SelectionNamedItem selectionNamedItem7 = new SelectionNamedItem(100, \u0016\u0003\u0007.\u000A());
			\u001A\u0012\u0007.\u000A(selectionNamedItem7, true);
			\u000C\u0012\u0007.\u000A(selectionNamedItem7, true);
			\u0013\u0012\u0007.\u000A(list6, selectionNamedItem7);
			SelectionNamedItem selectionNamedItem8 = new SelectionNamedItem(1, \u0005\u0003\u0007.\u000A());
			\u000C\u0012\u0007.\u000A(selectionNamedItem8, true);
			\u0004\u0003\u0007.\u000A(selectionNamedItem8, "");
			\u0013\u0012\u0007.\u000A(list6, selectionNamedItem8);
			SelectionNamedItem selectionNamedItem9 = new SelectionNamedItem(0, \u0018\u0003\u0007.\u000A());
			\u000C\u0012\u0007.\u000A(selectionNamedItem9, true);
			\u0004\u0003\u0007.\u000A(selectionNamedItem9, "");
			\u0013\u0012\u0007.\u000A(list6, selectionNamedItem9);
			SelectionNamedItem selectionNamedItem10 = new SelectionNamedItem(2, \u0019\u0003\u0007.\u000A());
			\u000C\u0012\u0007.\u000A(selectionNamedItem10, true);
			\u0004\u0003\u0007.\u000A(selectionNamedItem10, "");
			\u0013\u0012\u0007.\u000A(list6, selectionNamedItem10);
			\u0014\u0012\u0007.\u000A(u001F2, list6);
			\u0017\u0012\u0007.\u000A(\u001D\u0003\u0007.\u000A(this), 0);
			\u001B\u0012\u0007.\u000A(\u001D\u0003\u0007.\u000A(this), \u0011\u0012\u0007.\u000A(\u001E\u0012\u0007.\u000A(\u001D\u0003\u0007.\u000A(this)), 0));
			\u0007\u0003\u0007.\u000A(\u001D\u0003\u0007.\u000A(this), \u001E\u0012\u0007.\u000A(\u001D\u0003\u0007.\u000A(this)));
			\u000A\u0003\u0007.\u000A(this, new ViewFilters());
			object u001F3 = \u0020\u0012\u0007.\u000A(this);
			List<SelectionNamedItem> list7 = new List<SelectionNamedItem>();
			SelectionNamedItem selectionNamedItem11 = new SelectionNamedItem(0, \u001F\u0003\u0007.\u000A());
			\u001A\u0012\u0007.\u000A(selectionNamedItem11, true);
			\u000C\u0012\u0007.\u000A(selectionNamedItem11, true);
			\u0013\u0012\u0007.\u000A(list7, selectionNamedItem11);
			SelectionNamedItem selectionNamedItem12 = new SelectionNamedItem(1, \u0009\u0012\u0007.\u000A());
			\u000C\u0012\u0007.\u000A(selectionNamedItem12, true);
			\u0013\u0012\u0007.\u000A(list7, selectionNamedItem12);
			SelectionNamedItem selectionNamedItem13 = new SelectionNamedItem(2, \u0001\u0012\u0007.\u000A());
			\u000C\u0012\u0007.\u000A(selectionNamedItem13, true);
			\u0013\u0012\u0007.\u000A(list7, selectionNamedItem13);
			SelectionNamedItem selectionNamedItem14 = new SelectionNamedItem(3, \u0015\u0012\u0007.\u000A());
			\u000C\u0012\u0007.\u000A(selectionNamedItem14, false);
			\u001A\u0012\u0007.\u000A(selectionNamedItem14, true);
			\u0013\u0012\u0007.\u000A(list7, selectionNamedItem14);
			\u0014\u0012\u0007.\u000A(u001F3, list7);
			this.CJR();
			\u0017\u0012\u0007.\u000A(\u0020\u0012\u0007.\u000A(this), 0);
			\u001B\u0012\u0007.\u000A(\u0020\u0012\u0007.\u000A(this), \u0011\u0012\u0007.\u000A(\u001E\u0012\u0007.\u000A(\u0020\u0012\u0007.\u000A(this)), 0));
			this.AJR();
			\u0008\u0012\u0007.\u000A(this, new CommandBase(new Action(this.SelectSpatialElements), new Predicate<object>(this.XJR)));
			\u000E\u0012\u0007.\u000A(this, new CommandBase(new Action(this.PJR), new Predicate<object>(this.OJR)));
			\u0010\u0012\u0007.\u000A(this, new CommandBase(new Action(this.TJR), new Predicate<object>(this.QJR)));
			\u000D\u0012\u0007.\u000A(this, new CommandBase<string>(new Action<string>(this.OpenCalloutViews), null));
			\u001C\u0012\u0007.\u000A(this, new CommandBase<string>(new Action<string>(this.OpenSectionViews), null));
			\u0003\u0012\u0007.\u000A(this, new CommandBase<string>(new Action<string>(this.DeleteCalloutViews), null));
			\u0012\u0012\u0007.\u000A(this, new CommandBase<string>(new Action<string>(this.DeleteSectionViews), null));
			\u000F\u0012\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\ViewModels\\QuickViewsViewModel.cs", ".ctor");
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000362 RID: 866 RVA: 0x00015A98 File Offset: 0x00013C98
		// (set) Token: 0x06000363 RID: 867 RVA: 0x00015AAC File Offset: 0x00013CAC
		public SubItems ShowCallOut { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000364 RID: 868 RVA: 0x00015AC0 File Offset: 0x00013CC0
		// (set) Token: 0x06000365 RID: 869 RVA: 0x00015AD4 File Offset: 0x00013CD4
		public SubItems ShowElevation { get; set; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000366 RID: 870 RVA: 0x00015AE8 File Offset: 0x00013CE8
		// (set) Token: 0x06000367 RID: 871 RVA: 0x00015AFC File Offset: 0x00013CFC
		public SubItems DeleteCallOut { get; set; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000368 RID: 872 RVA: 0x00015B10 File Offset: 0x00013D10
		// (set) Token: 0x06000369 RID: 873 RVA: 0x00015B24 File Offset: 0x00013D24
		public SubItems DeleteElevation { get; set; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600036A RID: 874 RVA: 0x00015B38 File Offset: 0x00013D38
		// (set) Token: 0x0600036B RID: 875 RVA: 0x00015B4C File Offset: 0x00013D4C
		public ICollectionView ElementsCollection { get; private set; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600036C RID: 876 RVA: 0x00015B60 File Offset: 0x00013D60
		// (set) Token: 0x0600036D RID: 877 RVA: 0x00015B74 File Offset: 0x00013D74
		public List<SpatialType> SpatialTypes { get; private set; }

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600036E RID: 878 RVA: 0x00015B88 File Offset: 0x00013D88
		// (set) Token: 0x0600036F RID: 879 RVA: 0x00015B9C File Offset: 0x00013D9C
		public List<SpatialStatus> SpatialTypesStatuses { get; private set; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000370 RID: 880 RVA: 0x00015BB0 File Offset: 0x00013DB0
		// (set) Token: 0x06000371 RID: 881 RVA: 0x00015BC4 File Offset: 0x00013DC4
		public IList<ModelSpatialElement> SelectModelElements
		{
			get
			{
				return this.ID;
			}
			set
			{
				this.ID = value;
				\u000D\u0020\u000A.\u000A(this, "SelectModelElements");
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000372 RID: 882 RVA: 0x00015BE4 File Offset: 0x00013DE4
		// (set) Token: 0x06000373 RID: 883 RVA: 0x00015BF8 File Offset: 0x00013DF8
		public SectionOrElevationView SectionOrElevation
		{
			get
			{
				return this.OD;
			}
			set
			{
				this.OD = value;
				this.OnPropertyChanged<SectionOrElevationView>(new Func<SectionOrElevationView>(this.YER), "SectionOrElevation");
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000374 RID: 884 RVA: 0x00015C24 File Offset: 0x00013E24
		// (set) Token: 0x06000375 RID: 885 RVA: 0x00015C38 File Offset: 0x00013E38
		public ViewFilters TypeFilter { get; set; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000376 RID: 886 RVA: 0x00015C4C File Offset: 0x00013E4C
		// (set) Token: 0x06000377 RID: 887 RVA: 0x00015C60 File Offset: 0x00013E60
		public ViewFilters CallOutStatusFilter { get; set; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000378 RID: 888 RVA: 0x00015C74 File Offset: 0x00013E74
		// (set) Token: 0x06000379 RID: 889 RVA: 0x00015C88 File Offset: 0x00013E88
		public ViewFilters SectionElevationStatusFilter { get; set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600037A RID: 890 RVA: 0x00015C9C File Offset: 0x00013E9C
		// (set) Token: 0x0600037B RID: 891 RVA: 0x00015CB0 File Offset: 0x00013EB0
		public List<IModelElement> SpatialElementsInActiveView { get; set; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600037C RID: 892 RVA: 0x00015CC4 File Offset: 0x00013EC4
		// (set) Token: 0x0600037D RID: 893 RVA: 0x00015CD8 File Offset: 0x00013ED8
		public bool CreateCallout
		{
			get
			{
				return this.BH;
			}
			set
			{
				this.BH = value;
				\u000D\u0020\u000A.\u000A(this, "CreateCallout");
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600037E RID: 894 RVA: 0x00015CF8 File Offset: 0x00013EF8
		// (set) Token: 0x0600037F RID: 895 RVA: 0x00015D0C File Offset: 0x00013F0C
		public bool CreateElevationOrSection
		{
			get
			{
				return this.UH;
			}
			set
			{
				this.UH = value;
				\u000D\u0020\u000A.\u000A(this, "CreateElevationOrSection");
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00015D2C File Offset: 0x00013F2C
		// (set) Token: 0x06000381 RID: 897 RVA: 0x00015D40 File Offset: 0x00013F40
		public UIDocument UIDocument { get; set; }

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00015D54 File Offset: 0x00013F54
		// (set) Token: 0x06000383 RID: 899 RVA: 0x00015D68 File Offset: 0x00013F68
		public Document Document { get; set; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000384 RID: 900 RVA: 0x00015D7C File Offset: 0x00013F7C
		// (set) Token: 0x06000385 RID: 901 RVA: 0x00015D90 File Offset: 0x00013F90
		public CalloutsSettingsViewModel CallOutSettingsViewModel { get; set; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000386 RID: 902 RVA: 0x00015DA4 File Offset: 0x00013FA4
		// (set) Token: 0x06000387 RID: 903 RVA: 0x00015DB8 File Offset: 0x00013FB8
		public SectionsSettingsViewModel SectionsSettingsViewModels { get; set; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000388 RID: 904 RVA: 0x00015DCC File Offset: 0x00013FCC
		// (set) Token: 0x06000389 RID: 905 RVA: 0x00015DE0 File Offset: 0x00013FE0
		public ModelSpatialElementType TypeToDisplay { get; set; }

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x0600038A RID: 906 RVA: 0x00015DF4 File Offset: 0x00013FF4
		// (set) Token: 0x0600038B RID: 907 RVA: 0x00015E08 File Offset: 0x00014008
		public SpatialElementStatus StatusToDisplay
		{
			get
			{
				return this.ND;
			}
			set
			{
				this.ND = value;
				\u0014\u0003\u0007.\u000A(\u0013\u0003\u0007.\u0007(this));
				\u0017\u0003\u0007.\u0007(this);
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600038C RID: 908 RVA: 0x00015E30 File Offset: 0x00014030
		// (set) Token: 0x0600038D RID: 909 RVA: 0x00015E44 File Offset: 0x00014044
		public int ElementsOption
		{
			get
			{
				return this.SD;
			}
			set
			{
				this.SD = value;
				this.OnPropertyChanged<int>(new Func<int>(this.CER), "ElementsOption");
				if (this.SD == 2)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.set_ElementsOption(int)).MethodHandle;
					}
					\u001A\u0003\u0007.\u000A(this, this.ZJR());
				}
				\u0014\u0003\u0007.\u000A(\u0013\u0003\u0007.\u0007(this));
				this.YJR();
				\u0017\u0003\u0007.\u0007(this);
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600038E RID: 910 RVA: 0x00015EB4 File Offset: 0x000140B4
		// (set) Token: 0x0600038F RID: 911 RVA: 0x00015EC8 File Offset: 0x000140C8
		public bool IncludeElementsFromLinkedFiles
		{
			get
			{
				return this.KD;
			}
			set
			{
				this.KD = value;
				this.OnPropertyChanged<bool>(new Func<bool>(this.LER), "IncludeElementsFromLinkedFiles");
				if (!this.KD)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.set_IncludeElementsFromLinkedFiles(bool)).MethodHandle;
					}
					IEnumerable<IModelElement> ud = this.UD;
					Func<IModelElement, bool> func;
					if ((func = QuickViewsViewModel.<>c.\u000A) == null)
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
						func = (QuickViewsViewModel.<>c.\u000A = new Func<IModelElement, bool>(QuickViewsViewModel.<>c.\u001F.\u000D\u000A));
					}
					object u001F = Enumerable.ToList<IModelElement>(Enumerable.Where<IModelElement>(ud, func));
					Action<IModelElement> u000A;
					if ((u000A = QuickViewsViewModel.<>c.\u0007) == null)
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
						u000A = (QuickViewsViewModel.<>c.\u0007 = new Action<IModelElement>(QuickViewsViewModel.<>c.\u001F.\u0010\u000A));
					}
					\u000C\u0003\u0007.\u000A(u001F, u000A);
				}
				\u0014\u0003\u0007.\u000A(\u0013\u0003\u0007.\u0007(this));
				\u0017\u0003\u0007.\u0007(this);
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000390 RID: 912 RVA: 0x00015F90 File Offset: 0x00014190
		// (set) Token: 0x06000391 RID: 913 RVA: 0x00015FA4 File Offset: 0x000141A4
		public bool ShowCreatedElements
		{
			get
			{
				return this.MD;
			}
			set
			{
				this.MD = value;
				this.OnPropertyChanged<bool>(new Func<bool>(this.SER), "ShowCreatedElements");
				\u0014\u0003\u0007.\u000A(\u0013\u0003\u0007.\u0007(this));
				\u0017\u0003\u0007.\u0007(this);
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000392 RID: 914 RVA: 0x00015FE4 File Offset: 0x000141E4
		// (set) Token: 0x06000393 RID: 915 RVA: 0x00015FF8 File Offset: 0x000141F8
		public bool ShowUnCreatedElements
		{
			get
			{
				return this.VD;
			}
			set
			{
				this.VD = value;
				this.OnPropertyChanged<bool>(new Func<bool>(this.BER), "ShowUnCreatedElements");
				\u0015\u0003\u0007.\u000A(this);
			}
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0001602C File Offset: 0x0001422C
		[BindableMethod("ElementCollectionRefresh")]
		public void ElementCollectionRefresh()
		{
			\u0014\u0003\u0007.\u000A(\u0013\u0003\u0007.\u0007(this));
			\u0017\u0003\u0007.\u0007(this);
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000395 RID: 917 RVA: 0x0001604C File Offset: 0x0001424C
		// (set) Token: 0x06000396 RID: 918 RVA: 0x00016060 File Offset: 0x00014260
		public bool ShowChangedElements
		{
			get
			{
				return this.ZD;
			}
			set
			{
				this.ZD = value;
				this.OnPropertyChanged<bool>(new Func<bool>(this.UER), "ShowChangedElements");
				\u0014\u0003\u0007.\u000A(\u0013\u0003\u0007.\u0007(this));
				\u0017\u0003\u0007.\u0007(this);
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000397 RID: 919 RVA: 0x000160A0 File Offset: 0x000142A0
		// (set) Token: 0x06000398 RID: 920 RVA: 0x000160B4 File Offset: 0x000142B4
		public bool HideUnCheckedElements
		{
			get
			{
				return this.XD;
			}
			set
			{
				this.XD = value;
				this.OnPropertyChanged<bool>(new Func<bool>(this.WER), "HideUnCheckedElements");
				\u0014\u0003\u0007.\u000A(\u0013\u0003\u0007.\u0007(this));
				\u0017\u0003\u0007.\u0007(this);
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000399 RID: 921 RVA: 0x000160F4 File Offset: 0x000142F4
		// (set) Token: 0x0600039A RID: 922 RVA: 0x00016108 File Offset: 0x00014308
		public IList SelectedSpatialTypesList
		{
			get
			{
				return this.JD;
			}
			set
			{
				if (this.JD == value)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.set_SelectedSpatialTypesList(IList)).MethodHandle;
					}
					return;
				}
				this.JD = value;
				Func<string> property;
				if ((property = QuickViewsViewModel.<>c.\u001D) == null)
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
					property = (QuickViewsViewModel.<>c.\u001D = new Func<string>(QuickViewsViewModel.<>c.\u001F.\u000E\u000A));
				}
				this.OnPropertyChanged<string>(property, "SelectedSpatialTypesList");
				if (\u0018\u0013\u000A.\u000A(\u0009\u0003\u0007.\u000A(this)) == 0)
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
					\u0001\u0003\u0007.\u000A(this, ModelSpatialElementType.None);
					return;
				}
				if (\u0018\u0013\u000A.\u000A(\u0009\u0003\u0007.\u000A(this)) == 2)
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
					\u0001\u0003\u0007.\u000A(this, ModelSpatialElementType.All);
					return;
				}
				if (\u0018\u0013\u000A.\u000A(\u0009\u0003\u0007.\u000A(this)) == 1)
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
					if (\u0018\u0011\u000A.\u000A(\u0009\u0003\u0007.\u000A(this), SpatialType.Space))
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
						\u0001\u0003\u0007.\u000A(this, ModelSpatialElementType.Spaces);
						return;
					}
				}
				if (\u0018\u0013\u000A.\u000A(\u0009\u0003\u0007.\u000A(this)) == 1)
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
					if (\u0018\u0011\u000A.\u000A(\u0009\u0003\u0007.\u000A(this), SpatialType.Room))
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
						\u0001\u0003\u0007.\u000A(this, ModelSpatialElementType.Rooms);
					}
				}
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00016240 File Offset: 0x00014440
		// (set) Token: 0x0600039C RID: 924 RVA: 0x00016254 File Offset: 0x00014454
		public IList SelectedSpatialStatusList
		{
			get
			{
				return this.ED;
			}
			set
			{
				if (this.ED == value)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.set_SelectedSpatialStatusList(IList)).MethodHandle;
					}
					return;
				}
				this.ED = value;
				Func<string> property;
				if ((property = QuickViewsViewModel.<>c.\u0004) == null)
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
					property = (QuickViewsViewModel.<>c.\u0004 = new Func<string>(QuickViewsViewModel.<>c.\u001F.\u0008\u000A));
				}
				this.OnPropertyChanged<string>(property, "SelectedSpatialStatusList");
				if (\u0018\u0011\u000A.\u000A(\u000A\u001C\u0007.\u000A(this), SpatialStatus.Created))
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
					\u001D\u001C\u0007.\u000A(this, true);
				}
				else
				{
					\u001D\u001C\u0007.\u000A(this, false);
				}
				if (\u0018\u0011\u000A.\u000A(\u000A\u001C\u0007.\u000A(this), SpatialStatus.NotCreated))
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
					\u0007\u001C\u0007.\u000A(this, true);
				}
				else
				{
					\u0007\u001C\u0007.\u000A(this, false);
				}
				if (\u0018\u0011\u000A.\u000A(\u000A\u001C\u0007.\u000A(this), SpatialStatus.Changed))
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
					\u001F\u001C\u0007.\u000A(this, true);
				}
				else
				{
					\u001F\u001C\u0007.\u000A(this, false);
				}
				\u0014\u0003\u0007.\u000A(\u0013\u0003\u0007.\u0007(this));
				\u0017\u0003\u0007.\u0007(this);
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600039D RID: 925 RVA: 0x00016360 File Offset: 0x00014560
		// (set) Token: 0x0600039E RID: 926 RVA: 0x00016374 File Offset: 0x00014574
		public string Label
		{
			get
			{
				return this.PD;
			}
			set
			{
				this.PD = value;
				\u000D\u0020\u000A.\u000A(this, "Label");
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600039F RID: 927 RVA: 0x00016394 File Offset: 0x00014594
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x000163A8 File Offset: 0x000145A8
		public ObservableCollection<IModelElement> SelectedElements { get; set; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x000163BC File Offset: 0x000145BC
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x000163D0 File Offset: 0x000145D0
		public static CallOutInfo CallOutInfo { get; set; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x000163E4 File Offset: 0x000145E4
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x000163F8 File Offset: 0x000145F8
		public static SectionElevationInfo SectionElevationInfo { get; set; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x0001640C File Offset: 0x0001460C
		// (set) Token: 0x060003A6 RID: 934 RVA: 0x00016420 File Offset: 0x00014620
		public ICommand SelectElementsCommand { get; set; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x00016434 File Offset: 0x00014634
		// (set) Token: 0x060003A8 RID: 936 RVA: 0x00016448 File Offset: 0x00014648
		public ICommand CreateCmd { get; set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x0001645C File Offset: 0x0001465C
		// (set) Token: 0x060003AA RID: 938 RVA: 0x00016470 File Offset: 0x00014670
		public ICommand UpdateCmd { get; set; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060003AB RID: 939 RVA: 0x00016484 File Offset: 0x00014684
		// (set) Token: 0x060003AC RID: 940 RVA: 0x00016498 File Offset: 0x00014698
		public ICommand OpenCallOut { get; set; }

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060003AD RID: 941 RVA: 0x000164AC File Offset: 0x000146AC
		// (set) Token: 0x060003AE RID: 942 RVA: 0x000164C0 File Offset: 0x000146C0
		public ICommand OpenElevation { get; set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060003AF RID: 943 RVA: 0x000164D4 File Offset: 0x000146D4
		// (set) Token: 0x060003B0 RID: 944 RVA: 0x000164E8 File Offset: 0x000146E8
		public ICommand CallOutDelete { get; set; }

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x000164FC File Offset: 0x000146FC
		// (set) Token: 0x060003B2 RID: 946 RVA: 0x00016510 File Offset: 0x00014710
		public ICommand ElevationDelete { get; set; }

		// Token: 0x060003B3 RID: 947 RVA: 0x00016524 File Offset: 0x00014724
		private void YJR()
		{
			if (!Enumerable.Any<IModelElement>(this.UD))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.YJR()).MethodHandle;
				}
				return;
			}
			if (\u000F\u001C\u0007.\u000A(this) == 2)
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
				QuickViewsViewModel.\u001A\u0007 u001A_u = new QuickViewsViewModel.\u001A\u0007();
				u001A_u.\u000A = \u0004\u0013\u000A.\u0007(this.R);
				if (\u0006\u001C\u0007.\u000A(u001A_u.\u000A) == null)
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
					return;
				}
				u001A_u.\u001F = \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u0006\u001C\u0007.\u000A(u001A_u.\u000A)));
				IEnumerable<IModelElement> ud = this.UD;
				Func<IModelElement, ModelSpatialElement> func;
				if ((func = QuickViewsViewModel.<>c.\u0019) == null)
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
					func = (QuickViewsViewModel.<>c.\u0019 = new Func<IModelElement, ModelSpatialElement>(QuickViewsViewModel.<>c.\u001F.\u001B\u000A));
				}
				List<ModelSpatialElement>.Enumerator enumerator = \u0002\u001C\u0007.\u000A(Enumerable.ToList<ModelSpatialElement>(Enumerable.Where<ModelSpatialElement>(Enumerable.Select<IModelElement, ModelSpatialElement>(ud, func), new Func<ModelSpatialElement, bool>(u001A_u.\u001D))));
				try
				{
					while (\u0004\u001C\u0007.\u000A(ref enumerator))
					{
						ModelSpatialElement u001F = \u000B\u001C\u0007.\u000A(ref enumerator);
						object u001F2 = \u0010\u001F\u000E.\u001F(\u0005\u001C\u0007.\u000A(\u0016\u001C\u0007.\u000A(u001F)));
						Predicate<ViewInformation> u000A;
						if ((u000A = u001A_u.\u0007) == null)
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
							u000A = (u001A_u.\u0007 = new Predicate<ViewInformation>(u001A_u.\u0004));
						}
						\u0019\u001C\u0007.\u000A(u001F, \u0018\u001C\u0007.\u000A(u001F2, u000A));
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
			}
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x000166A4 File Offset: 0x000148A4
		private void CJR()
		{
			IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0009\u001E\u000A.\u001D(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.R), \u001E\u0011\u000A.\u000A(\u0006\u001F\u000E.\u001F()))));
			Func<View, bool> func;
			if ((func = QuickViewsViewModel.<>c.\u0005) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.CJR()).MethodHandle;
				}
				func = (QuickViewsViewModel.<>c.\u0005 = new Func<View, bool>(QuickViewsViewModel.<>c.\u001F.\u001E\u000A));
			}
			IEnumerable<View> enumerable2 = Enumerable.ToList<View>(Enumerable.Where<View>(enumerable, func));
			this.TD = \u001E\u001C\u0007.\u000A();
			Func<View, bool> func2;
			if ((func2 = QuickViewsViewModel.<>c.\u0016) == null)
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
				func2 = (QuickViewsViewModel.<>c.\u0016 = new Func<View, bool>(QuickViewsViewModel.<>c.\u001F.\u0020\u000A));
			}
			IEnumerator<View> enumerator = \u0011\u001C\u0007.\u000A(Enumerable.Where<View>(enumerable2, func2));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					View u001F = \u001B\u001C\u0007.\u000A(enumerator);
					ViewInformation viewInformation = \u0008\u001C\u0007.\u000A();
					\u000E\u001C\u0007.\u000A(viewInformation, \u0005\u001E\u000A.\u000A(u001F));
					\u0010\u001C\u0007.\u000A(viewInformation, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F)));
					\u000D\u001C\u0007.\u000A(viewInformation, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u0006\u001C\u0007.\u000A(u001F))));
					\u0003\u001C\u0007.\u000A(viewInformation, \u001C\u001C\u0007.\u0007(u001F));
					ViewInformation u000A = viewInformation;
					\u0012\u001C\u0007.\u000A(this.TD, u000A);
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

		// Token: 0x060003B5 RID: 949 RVA: 0x0001680C File Offset: 0x00014A0C
		[BindableMethod("CheckAllElements")]
		public void CheckAllElements()
		{
			object u001F = Enumerable.ToList<IModelElement>(Enumerable.Where<IModelElement>(this.UD, new Func<IModelElement, bool>(this.KER)));
			Action<IModelElement> u000A;
			if ((u000A = QuickViewsViewModel.<>c.\u000B) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.CheckAllElements()).MethodHandle;
				}
				u000A = (QuickViewsViewModel.<>c.\u000B = new Action<IModelElement>(QuickViewsViewModel.<>c.\u001F.\u0017\u000A));
			}
			\u000C\u0003\u0007.\u000A(u001F, u000A);
			\u0014\u0003\u0007.\u000A(\u0013\u0003\u0007.\u0007(this));
			\u0017\u0003\u0007.\u0007(this);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00016884 File Offset: 0x00014A84
		[BindableMethod("ChangeInFilter")]
		public void ChangeInFilter()
		{
			\u0020\u001C\u0007.\u000A(\u0020\u0012\u0007.\u000A(this), \u0020\u0012\u0007.\u000A(this));
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x000168A8 File Offset: 0x00014AA8
		[BindableMethod("UnCheckAllElements")]
		public void UnCheckAllElements()
		{
			object ud = this.UD;
			Action<IModelElement> u000A;
			if ((u000A = QuickViewsViewModel.<>c.\u0002) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.UnCheckAllElements()).MethodHandle;
				}
				u000A = (QuickViewsViewModel.<>c.\u0002 = new Action<IModelElement>(QuickViewsViewModel.<>c.\u001F.\u0014\u000A));
			}
			\u000C\u0003\u0007.\u000A(ud, u000A);
			\u0014\u0003\u0007.\u000A(\u0013\u0003\u0007.\u0007(this));
			\u0017\u0003\u0007.\u0007(this);
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00016908 File Offset: 0x00014B08
		private bool LJR(object F)
		{
			ModelSpatialElement modelSpatialElement = \u0002\u001F\u000E.\u001F(F);
			if (modelSpatialElement == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.LJR(object)).MethodHandle;
				}
				return false;
			}
			ModelSpatialElementType u000A;
			if (!\u0009\u001C\u0007.\u000A(\u0001\u001C\u0007.\u000A(\u0020\u0012\u0007.\u000A(this))))
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
				u000A = (ModelSpatialElementType)\u0015\u001C\u0007.\u0007(\u0011\u0012\u0007.\u000A(\u001E\u0012\u0007.\u000A(\u0020\u0012\u0007.\u000A(this)), 3));
			}
			else
			{
				u000A = (ModelSpatialElementType)\u0015\u001C\u0007.\u0007(\u0001\u001C\u0007.\u000A(\u0020\u0012\u0007.\u000A(this)));
			}
			\u0001\u0003\u0007.\u000A(this, u000A);
			if (!this.SJR(modelSpatialElement))
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
				\u0017\u001C\u0007.\u000A(modelSpatialElement, false);
				return false;
			}
			if (!this.BJR(modelSpatialElement))
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
				\u0017\u001C\u0007.\u000A(modelSpatialElement, false);
				return false;
			}
			if (!this.UJR(modelSpatialElement))
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
				\u0017\u001C\u0007.\u000A(modelSpatialElement, false);
				return false;
			}
			if (!this.WJR(modelSpatialElement))
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
				\u0017\u001C\u0007.\u000A(modelSpatialElement, false);
				return false;
			}
			if (\u000F\u001C\u0007.\u000A(this) == 2)
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
				if (!this.KJR(modelSpatialElement))
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
					\u0017\u001C\u0007.\u000A(modelSpatialElement, false);
					return false;
				}
			}
			if (\u000C\u001C\u0007.\u000A(this))
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
				if (!\u001A\u001C\u0007.\u000A(modelSpatialElement))
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
					\u0017\u001C\u0007.\u000A(modelSpatialElement, false);
					return false;
				}
			}
			if (!\u0013\u001C\u0007.\u0007(this))
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
				if (\u0014\u001C\u0007.\u0007(modelSpatialElement))
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
					\u0017\u001C\u0007.\u000A(modelSpatialElement, false);
					return false;
				}
			}
			\u0017\u001C\u0007.\u000A(modelSpatialElement, true);
			return true;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00016AAC File Offset: 0x00014CAC
		private bool SJR(ModelSpatialElement F)
		{
			if (!\u001A\u0006\u0007.\u000A(\u001F\u000D\u0007.\u000A(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.SJR(ModelSpatialElement)).MethodHandle;
				}
				if (!\u000D\u0008\u000A.\u001F(\u001D\u000D\u0007.\u0007(F), \u001F\u000D\u0007.\u000A(this)))
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
					if (!\u000D\u0008\u000A.\u001F(\u0007\u000D\u0007.\u0007(F), \u001F\u000D\u0007.\u000A(this)))
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
						return \u000D\u0008\u000A.\u001F(\u0005\u001E\u000A.\u000A(\u000A\u000D\u0007.\u0007(F)), \u001F\u000D\u0007.\u000A(this));
					}
				}
			}
			return true;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00016B48 File Offset: 0x00014D48
		private bool BJR(ModelSpatialElement F)
		{
			QuickViewsViewModel.\u000C\u0007 u000C_u = new QuickViewsViewModel.\u000C\u0007();
			u000C_u.\u001F = F;
			return \u0004\u000D\u0007.\u000A(\u0019\u000D\u0007.\u000A(\u0006\u0003\u0007.\u000A(this)), new Predicate<SelectionNamedItem>(u000C_u.\u000A));
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00016B84 File Offset: 0x00014D84
		private bool UJR(ModelSpatialElement F)
		{
			QuickViewsViewModel.\u0015\u0007 u0015_u = new QuickViewsViewModel.\u0015\u0007();
			u0015_u.\u001F = F;
			return \u0004\u000D\u0007.\u000A(\u0019\u000D\u0007.\u000A(\u001D\u0003\u0007.\u000A(this)), new Predicate<SelectionNamedItem>(u0015_u.\u000A));
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00016BC0 File Offset: 0x00014DC0
		private bool WJR(ModelSpatialElement F)
		{
			switch (\u0018\u000D\u0007.\u000A(this))
			{
			case ModelSpatialElementType.All:
				if (\u001C\u001F\u000E.\u001F(F) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.WJR(ModelSpatialElement)).MethodHandle;
					}
					return \u0012\u001F\u000E.\u001F(F) != \u0003\u001F\u000E.\u001F;
				}
				return true;
			case ModelSpatialElementType.Spaces:
				return \u0012\u001F\u000E.\u001F(F) != \u0003\u001F\u000E.\u001F;
			case ModelSpatialElementType.Rooms:
				return \u001C\u001F\u000E.\u001F(F) != \u000D\u001F\u000E.\u001F;
			case ModelSpatialElementType.None:
				return false;
			default:
				return false;
			}
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00016C40 File Offset: 0x00014E40
		private bool KJR(ModelSpatialElement F)
		{
			IEnumerable<IModelElement> enumerable = \u0005\u000D\u0007.\u000A(this);
			Func<IModelElement, long> func;
			if ((func = QuickViewsViewModel.<>c.\u0006) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.KJR(ModelSpatialElement)).MethodHandle;
				}
				func = (QuickViewsViewModel.<>c.\u0006 = new Func<IModelElement, long>(QuickViewsViewModel.<>c.\u001F.\u0013\u000A));
			}
			return Enumerable.Contains<long>(Enumerable.Select<IModelElement, long>(enumerable, func), \u0018\u0018\u0007.\u0007(F));
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00016CA0 File Offset: 0x00014EA0
		[BindableMethod("ViewInformationChange")]
		public void ViewInformationChange(object sender)
		{
			QuickViewsViewModel.\u0001\u0007 u0001_u = new QuickViewsViewModel.\u0001\u0007();
			ComboBox comboBox = \u000F\u001F\u000E.\u001F(sender);
			if (comboBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.ViewInformationChange(object)).MethodHandle;
				}
				object u001F = \u0007\u000C\u000A.\u0007(comboBox);
				u0001_u.\u001F = \u0002\u001F\u000E.\u001F(u001F);
				if (u0001_u.\u001F != null)
				{
					if (Enumerable.Any<ModelSpatialElement>(\u0006\u000D\u0007.\u000A(this), new Func<ModelSpatialElement, bool>(u0001_u.\u000A)))
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
						IEnumerator<ModelSpatialElement> enumerator = \u0002\u000D\u0007.\u000A(\u0006\u000D\u0007.\u000A(this));
						try
						{
							while (\u000A\u0017\u000A.\u000A(enumerator))
							{
								\u0019\u001C\u0007.\u000A(\u000B\u000D\u0007.\u000A(enumerator), \u0016\u000D\u0007.\u000A(u0001_u.\u001F));
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
							if (enumerator != null)
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
								\u001F\u0017\u000A.\u000A(enumerator);
							}
						}
					}
					return;
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
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00016D8C File Offset: 0x00014F8C
		[BindableMethod("SectionElevationStatusRefresh")]
		public void SectionElevationStatusRefresh()
		{
			\u000F\u000D\u0007.\u000A(\u001D\u0003\u0007.\u000A(this), \u001D\u0003\u0007.\u000A(this));
			\u0015\u0003\u0007.\u000A(this);
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00016DB4 File Offset: 0x00014FB4
		[BindableMethod("ChangeInSectionElevationStatus")]
		public void ChangeInSectionElevationStatus(object sender)
		{
			CheckBox u000A = \u0016\u0009\u0010.\u001F(sender);
			\u0012\u000D\u0007.\u000A(\u001D\u0003\u0007.\u000A(this), u000A, \u001D\u0003\u0007.\u000A(this), "Section/Elevation Status");
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00016DE8 File Offset: 0x00014FE8
		[BindableMethod("CallOutStatusRefresh")]
		public void CallOutStatusRefresh()
		{
			\u000F\u000D\u0007.\u000A(\u0006\u0003\u0007.\u000A(this), \u0006\u0003\u0007.\u000A(this));
			\u0015\u0003\u0007.\u000A(this);
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00016E10 File Offset: 0x00015010
		[BindableMethod("ChangeInCallOutStatus")]
		public void ChangeInCallOutStatus(object sender)
		{
			CheckBox u000A = \u0016\u0009\u0010.\u001F(sender);
			\u0012\u000D\u0007.\u000A(\u0006\u0003\u0007.\u000A(this), u000A, \u0006\u0003\u0007.\u000A(this), "CallOut Status");
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00016E44 File Offset: 0x00015044
		[BindableMethod("OpenSectionViews")]
		public void OpenSectionViews(string viewName)
		{
			QuickViewsViewModel.\u0009\u0007 u0009_u = new QuickViewsViewModel.\u0009\u0007();
			u0009_u.\u001F = viewName;
			IEnumerable<IModelElement> enumerable = \u000E\u000D\u0007.\u000A(this);
			Func<IModelElement, SpatialElementStoredData> func;
			if ((func = QuickViewsViewModel.<>c.\u000F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.OpenSectionViews(string)).MethodHandle;
				}
				func = (QuickViewsViewModel.<>c.\u000F = new Func<IModelElement, SpatialElementStoredData>(QuickViewsViewModel.<>c.\u001F.\u001A\u000A));
			}
			IEnumerator<SpatialElementStoredData> enumerator = \u0010\u000D\u0007.\u000A(Enumerable.Select<IModelElement, SpatialElementStoredData>(enumerable, func));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SpatialElementStoredData spatialElementStoredData = \u000D\u000D\u0007.\u000A(enumerator);
					if (spatialElementStoredData != null)
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
						List<View> list = \u001C\u000D\u0007.\u000A(spatialElementStoredData, this.R);
						if (\u0008\u0013\u000A.\u000A(u0009_u.\u001F, \u0003\u000D\u0007.\u000A()))
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
							this.EJR(list);
						}
						else
						{
							IEnumerable<View> enumerable2 = list;
							Func<View, bool> func2;
							if ((func2 = u0009_u.\u000A) == null)
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
								func2 = (u0009_u.\u000A = new Func<View, bool>(u0009_u.\u0007));
							}
							list = Enumerable.ToList<View>(Enumerable.Where<View>(enumerable2, func2));
							this.EJR(list);
						}
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00016F7C File Offset: 0x0001517C
		[BindableMethod("FillSubItems")]
		public void FillSubItems()
		{
			QuickViewsViewModel.\u001F\u001D u001F_u001D = new QuickViewsViewModel.\u001F\u001D();
			u001F_u001D.\u001F = \u0014\u000D\u0007.\u000A();
			u001F_u001D.\u000A = \u0014\u000D\u0007.\u000A();
			IEnumerable<IModelElement> enumerable = \u000E\u000D\u0007.\u000A(this);
			Func<IModelElement, SpatialElementStoredData> func;
			if ((func = QuickViewsViewModel.<>c.\u0012) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.FillSubItems()).MethodHandle;
				}
				func = (QuickViewsViewModel.<>c.\u0012 = new Func<IModelElement, SpatialElementStoredData>(QuickViewsViewModel.<>c.\u001F.\u000C\u000A));
			}
			IEnumerator<SpatialElementStoredData> enumerator = \u0010\u000D\u0007.\u000A(Enumerable.Select<IModelElement, SpatialElementStoredData>(enumerable, func));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SpatialElementStoredData spatialElementStoredData = \u000D\u000D\u0007.\u000A(enumerator);
					if (spatialElementStoredData != null)
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
						List<View> list = \u0017\u000D\u0007.\u000A(spatialElementStoredData, this.R);
						object u001F = \u001C\u000D\u0007.\u000A(spatialElementStoredData, this.R);
						object u001F2 = list;
						Action<View> u000A;
						if ((u000A = u001F_u001D.\u0007) == null)
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
							u000A = (u001F_u001D.\u0007 = new Action<View>(u001F_u001D.\u0004));
						}
						\u0020\u000D\u0007.\u000A(u001F2, u000A);
						Action<View> u000A2;
						if ((u000A2 = u001F_u001D.\u001D) == null)
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
							u000A2 = (u001F_u001D.\u001D = new Action<View>(u001F_u001D.\u0019));
						}
						\u0020\u000D\u0007.\u000A(u001F, u000A2);
					}
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			this.JJR(u001F_u001D.\u001F, \u001E\u000D\u0007.\u0007(this), \u0011\u000D\u0007.\u0007(this));
			this.JJR(u001F_u001D.\u000A, \u001B\u000D\u0007.\u0007(this), \u0008\u000D\u0007.\u0007(this));
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00017104 File Offset: 0x00015304
		private void JJR(List<string> F, SubItems R, SubItems D)
		{
			if (Enumerable.Any<string>(F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.JJR(List<string>, SubItems, SubItems)).MethodHandle;
				}
				\u001A\u000D\u0007.\u0007(R, \u000C\u000D\u0007.\u000A());
				\u001A\u000D\u0007.\u0007(D, \u000C\u000D\u0007.\u000A());
				\u000A\u0010\u0007.\u000A(R);
				\u001F\u0010\u0007.\u000A(D);
				\u0009\u000D\u0007.\u000A(\u0001\u000D\u0007.\u0007(R), F);
				\u0013\u000D\u0007.\u0007(R, \u0015\u000D\u0007.\u000A(\u0001\u000D\u0007.\u0007(R)) - 2);
				\u0009\u000D\u0007.\u000A(\u0001\u000D\u0007.\u0007(D), F);
				\u0013\u000D\u0007.\u0007(D, \u0015\u000D\u0007.\u000A(\u0001\u000D\u0007.\u0007(D)) - 2);
				return;
			}
			\u001A\u000D\u0007.\u0007(R, \u000C\u000D\u0007.\u000A());
			\u001A\u000D\u0007.\u0007(D, \u000C\u000D\u0007.\u000A());
			\u0013\u000D\u0007.\u0007(R, 0);
			\u0013\u000D\u0007.\u0007(D, 0);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x000171CC File Offset: 0x000153CC
		public void OpenCalloutViews(string viewName)
		{
			QuickViewsViewModel.\u000A\u001D u000A_u001D = new QuickViewsViewModel.\u000A\u001D();
			u000A_u001D.\u001F = viewName;
			IEnumerable<IModelElement> enumerable = \u000E\u000D\u0007.\u000A(this);
			Func<IModelElement, SpatialElementStoredData> func;
			if ((func = QuickViewsViewModel.<>c.\u0003) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.OpenCalloutViews(string)).MethodHandle;
				}
				func = (QuickViewsViewModel.<>c.\u0003 = new Func<IModelElement, SpatialElementStoredData>(QuickViewsViewModel.<>c.\u001F.\u0015\u000A));
			}
			IEnumerator<SpatialElementStoredData> enumerator = \u0010\u000D\u0007.\u000A(Enumerable.Select<IModelElement, SpatialElementStoredData>(enumerable, func));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SpatialElementStoredData spatialElementStoredData = \u000D\u000D\u0007.\u000A(enumerator);
					if (spatialElementStoredData != null)
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
						List<View> list = \u0017\u000D\u0007.\u000A(spatialElementStoredData, this.R);
						if (\u0008\u0013\u000A.\u000A(u000A_u001D.\u001F, \u0003\u000D\u0007.\u000A()))
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
							this.EJR(list);
						}
						else
						{
							IEnumerable<View> enumerable2 = list;
							Func<View, bool> func2;
							if ((func2 = u000A_u001D.\u000A) == null)
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
								func2 = (u000A_u001D.\u000A = new Func<View, bool>(u000A_u001D.\u0007));
							}
							list = Enumerable.ToList<View>(Enumerable.Where<View>(enumerable2, func2));
							this.EJR(list);
						}
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00017304 File Offset: 0x00015504
		private void EJR(List<View> F)
		{
			List<View>.Enumerator enumerator = \u0018\u0010\u0007.\u000A(F);
			try
			{
				while (\u0007\u0010\u0007.\u000A(ref enumerator))
				{
					View u000A = \u0019\u0010\u0007.\u000A(ref enumerator);
					\u001D\u0010\u0007.\u0007(\u0004\u0010\u0007.\u000A(this), u000A);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.EJR(List<View>)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00017374 File Offset: 0x00015574
		[BindableMethod("DeleteSectionViews")]
		public void DeleteSectionViews(string viewName)
		{
			QuickViewsViewModel.\u0007\u001D u0007_u001D = new QuickViewsViewModel.\u0007\u001D();
			u0007_u001D.\u001F = this;
			u0007_u001D.\u000A = viewName;
			u0007_u001D.\u0007 = \u001C\u0013\u000A.\u000A();
			IEnumerable<IModelElement> enumerable = \u000E\u000D\u0007.\u000A(this);
			Func<IModelElement, bool> func;
			if ((func = QuickViewsViewModel.<>c.\u001C) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.DeleteSectionViews(string)).MethodHandle;
				}
				func = (QuickViewsViewModel.<>c.\u001C = new Func<IModelElement, bool>(QuickViewsViewModel.<>c.\u001F.\u0001\u000A));
			}
			IEnumerable<IModelElement> enumerable2 = Enumerable.Where<IModelElement>(enumerable, func);
			Func<IModelElement, SpatialElementStoredData> func2;
			if ((func2 = QuickViewsViewModel.<>c.\u000D) == null)
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
				func2 = (QuickViewsViewModel.<>c.\u000D = new Func<IModelElement, SpatialElementStoredData>(QuickViewsViewModel.<>c.\u001F.\u0009\u000A));
			}
			\u0002\u0010\u0007.\u000A(Enumerable.ToList<SpatialElementStoredData>(Enumerable.Select<IModelElement, SpatialElementStoredData>(enumerable2, func2)), new Action<SpatialElementStoredData>(u0007_u001D.\u0004));
			QuickViewsViewModel.MJR(u0007_u001D.\u0007);
			IEnumerable<IModelElement> enumerable3 = \u000E\u000D\u0007.\u000A(this);
			Func<IModelElement, bool> func3;
			if ((func3 = QuickViewsViewModel.<>c.\u0008) == null)
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
				func3 = (QuickViewsViewModel.<>c.\u0008 = new Func<IModelElement, bool>(QuickViewsViewModel.<>c.\u001F.\u0007\u0007));
			}
			IEnumerator<IModelElement> enumerator = \u000B\u0010\u0007.\u000A(Enumerable.Where<IModelElement>(enumerable3, func3));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ModelSpatialElement modelSpatialElement = \u0002\u001F\u000E.\u001F(\u0016\u0010\u0007.\u000A(enumerator));
					if (modelSpatialElement != null)
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
						\u0005\u0010\u0007.\u000A(modelSpatialElement, 1);
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			\u0002\u0004.\u0005(new Action(u0007_u001D.\u0018), "RoomPro_QuickViews_DeleteSectionViews", false, this.R);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x000174F4 File Offset: 0x000156F4
		private void NJR(List<ElementId> F, List<string> R, ElementId D)
		{
			QuickViewsViewModel.\u001D\u001D u001D_u001D = new QuickViewsViewModel.\u001D\u001D();
			u001D_u001D.\u001F = this;
			u001D_u001D.\u000A = D;
			List<ElevationMarker>.Enumerator enumerator = \u0010\u0010\u0007.\u000A(Enumerable.ToList<ElevationMarker>(Enumerable.Cast<ElevationMarker>(Enumerable.Select<string, Element>(R, new Func<string, Element>(u001D_u001D.\u001D)))));
			try
			{
				while (\u0006\u0010\u0007.\u000A(ref enumerator))
				{
					ElevationMarker u001F = \u000D\u0010\u0007.\u000A(ref enumerator);
					ElementFilter u000A = \u0003\u0018\u0007.\u000A(-2000279L);
					if (\u001C\u0010\u0007.\u000A(u001F) > 0)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.NJR(List<ElementId>, List<string>, ElementId)).MethodHandle;
						}
						IEnumerable<ElementId> enumerable = \u0012\u0018\u0007.\u000A(u001F, u000A);
						Func<ElementId, bool> func;
						if ((func = u001D_u001D.\u0007) == null)
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
							func = (u001D_u001D.\u0007 = new Func<ElementId, bool>(u001D_u001D.\u0004));
						}
						if (Enumerable.Any<ElementId>(enumerable, func))
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
							if (\u001C\u0010\u0007.\u000A(u001F) == 1)
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
								\u0003\u0010\u0007.\u000A(F, \u0002\u001E\u000A.\u0007(u001F));
								\u000F\u0010\u0007.\u000A(R, \u0012\u0010\u0007.\u000A(u001F));
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
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00017630 File Offset: 0x00015830
		private static void MJR(List<ElementId> F)
		{
			QuickViewsViewModel.\u0004\u001D u0004_u001D = new QuickViewsViewModel.\u0004\u001D();
			u0004_u001D.\u001F = F;
			UIApplication u001F = \u0014\u0010\u0007.\u000A();
			IList<UIView> list = \u0017\u0010\u0007.\u000A(\u0020\u0013\u000A.\u000A(u001F));
			List<UIView> list2 = Enumerable.ToList<UIView>(Enumerable.Where<UIView>(list, new Func<UIView, bool>(u0004_u001D.\u000A)));
			if (\u0020\u0010\u0007.\u000A(list2) == \u001E\u0010\u0007.\u000A(list))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.MJR(List<ElementId>)).MethodHandle;
				}
				IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0001\u001E\u000A.\u0007(\u0011\u0011\u000A.\u001D(\u0020\u0011\u000A.\u000A(\u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(u001F))), \u001E\u0011\u000A.\u000A(\u0006\u001F\u000E.\u001F()))));
				Func<View, bool> func;
				if ((func = QuickViewsViewModel.<>c.\u001B) == null)
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
					func = (QuickViewsViewModel.<>c.\u001B = new Func<View, bool>(QuickViewsViewModel.<>c.\u001F.\u001D\u0007));
				}
				View u000A = Enumerable.First<View>(enumerable, func);
				\u001D\u0010\u0007.\u0007(\u0020\u0013\u000A.\u000A(u001F), u000A);
			}
			if (Enumerable.Any<UIView>(list2))
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
				List<UIView>.Enumerator enumerator = \u0011\u0010\u0007.\u000A(list2);
				try
				{
					while (\u000E\u0010\u0007.\u000A(ref enumerator))
					{
						\u0008\u0010\u0007.\u000A(\u001B\u0010\u0007.\u000A(ref enumerator));
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
			}
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00017784 File Offset: 0x00015984
		[BindableMethod("DeleteCalloutViews")]
		public void DeleteCalloutViews(string viewName)
		{
			QuickViewsViewModel.\u0019\u001D u0019_u001D = new QuickViewsViewModel.\u0019\u001D();
			u0019_u001D.\u001F = this;
			u0019_u001D.\u000A = viewName;
			u0019_u001D.\u0007 = \u001C\u0013\u000A.\u000A();
			IEnumerable<IModelElement> enumerable = \u000E\u000D\u0007.\u000A(this);
			Func<IModelElement, bool> func;
			if ((func = QuickViewsViewModel.<>c.\u0011) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.DeleteCalloutViews(string)).MethodHandle;
				}
				func = (QuickViewsViewModel.<>c.\u0011 = new Func<IModelElement, bool>(QuickViewsViewModel.<>c.\u001F.\u0004\u0007));
			}
			IEnumerable<IModelElement> enumerable2 = Enumerable.Where<IModelElement>(enumerable, func);
			Func<IModelElement, SpatialElementStoredData> func2;
			if ((func2 = QuickViewsViewModel.<>c.\u001E) == null)
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
				func2 = (QuickViewsViewModel.<>c.\u001E = new Func<IModelElement, SpatialElementStoredData>(QuickViewsViewModel.<>c.\u001F.\u0019\u0007));
			}
			\u0002\u0010\u0007.\u000A(Enumerable.ToList<SpatialElementStoredData>(Enumerable.Select<IModelElement, SpatialElementStoredData>(enumerable2, func2)), new Action<SpatialElementStoredData>(u0019_u001D.\u0004));
			QuickViewsViewModel.MJR(u0019_u001D.\u0007);
			IEnumerable<IModelElement> enumerable3 = \u000E\u000D\u0007.\u000A(this);
			Func<IModelElement, bool> func3;
			if ((func3 = QuickViewsViewModel.<>c.\u0017) == null)
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
				func3 = (QuickViewsViewModel.<>c.\u0017 = new Func<IModelElement, bool>(QuickViewsViewModel.<>c.\u001F.\u0005\u0007));
			}
			IEnumerator<IModelElement> enumerator = \u000B\u0010\u0007.\u000A(Enumerable.Where<IModelElement>(enumerable3, func3));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ModelSpatialElement modelSpatialElement = \u0002\u001F\u000E.\u001F(\u0016\u0010\u0007.\u000A(enumerator));
					if (modelSpatialElement != null)
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
						\u0013\u0010\u0007.\u000A(modelSpatialElement, 1);
					}
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
			\u0002\u0004.\u0005(new Action(u0019_u001D.\u0018), "RoomPro_QuickViews_DeleteCalloutViews", false, this.R);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00017904 File Offset: 0x00015B04
		private void VJR(IEnumerable<ElementId> F)
		{
			IEnumerable<Element> enumerable = Enumerable.Select<ElementId, Element>(F, new Func<ElementId, Element>(this.JER));
			Func<Element, bool> func;
			if ((func = QuickViewsViewModel.<>c.\u0014) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.VJR(IEnumerable<ElementId>)).MethodHandle;
				}
				func = (QuickViewsViewModel.<>c.\u0014 = new Func<Element, bool>(QuickViewsViewModel.<>c.\u001F.\u0016\u0007));
			}
			List<Element>.Enumerator enumerator = \u0001\u0010\u0007.\u000A(Enumerable.ToList<Element>(Enumerable.Where<Element>(enumerable, func)));
			try
			{
				while (\u000C\u0010\u0007.\u000A(ref enumerator))
				{
					Element u001F = \u0015\u0010\u0007.\u000A(ref enumerator);
					try
					{
						\u0011\u0001\u000A.\u000A(this.R, \u0002\u001E\u000A.\u0007(u001F));
					}
					catch (Exception u000A)
					{
						\u000D\u0011\u000A.\u0007(\u001E\u000A\u0007.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\ViewModels\\QuickViewsViewModel.cs", "DeleteElementViews");
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
				((IDisposable)enumerator).Dispose();
			}
			IEnumerator<ModelSpatialElement> enumerator2 = \u0002\u000D\u0007.\u000A(Enumerable.OfType<ModelSpatialElement>(\u000E\u000D\u0007.\u000A(this)));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator2))
				{
					\u001A\u0010\u0007.\u000A(\u000B\u000D\u0007.\u000A(enumerator2));
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
				if (enumerator2 != null)
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
					\u001F\u0017\u000A.\u000A(enumerator2);
				}
			}
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00017A48 File Offset: 0x00015C48
		private List<IModelElement> ZJR()
		{
			IEnumerable<Space> enumerable = Enumerable.Cast<Space>(this.CR.\u0004(-2003600L));
			Func<Space, ModelSpace> func;
			if ((func = QuickViewsViewModel.<>c.\u0013) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.ZJR()).MethodHandle;
				}
				func = (QuickViewsViewModel.<>c.\u0013 = new Func<Space, ModelSpace>(QuickViewsViewModel.<>c.\u001F.\u000B\u0007));
			}
			List<ModelSpace> list = Enumerable.ToList<ModelSpace>(Enumerable.Select<Space, ModelSpace>(enumerable, func));
			IEnumerable<Room> enumerable2 = Enumerable.Cast<Room>(this.CR.\u0004(-2000160L));
			Func<Room, ModelRoom> func2;
			if ((func2 = QuickViewsViewModel.<>c.\u001A) == null)
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
				func2 = (QuickViewsViewModel.<>c.\u001A = new Func<Room, ModelRoom>(QuickViewsViewModel.<>c.\u001F.\u0002\u0007));
			}
			List<ModelRoom> list2 = Enumerable.ToList<ModelRoom>(Enumerable.Select<Room, ModelRoom>(enumerable2, func2));
			IEnumerable<Tuple<SpatialElement, RevitLinkInstance>> enumerable3 = this.CR.\u0006();
			Func<Tuple<SpatialElement, RevitLinkInstance>, bool> func3;
			if ((func3 = QuickViewsViewModel.<>c.\u000C) == null)
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
				func3 = (QuickViewsViewModel.<>c.\u000C = new Func<Tuple<SpatialElement, RevitLinkInstance>, bool>(QuickViewsViewModel.<>c.\u001F.\u0006\u0007));
			}
			IEnumerable<Tuple<SpatialElement, RevitLinkInstance>> enumerable4 = Enumerable.Where<Tuple<SpatialElement, RevitLinkInstance>>(enumerable3, func3);
			Func<Tuple<SpatialElement, RevitLinkInstance>, SpatialElement> func4;
			if ((func4 = QuickViewsViewModel.<>c.\u0015) == null)
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
				func4 = (QuickViewsViewModel.<>c.\u0015 = new Func<Tuple<SpatialElement, RevitLinkInstance>, SpatialElement>(QuickViewsViewModel.<>c.\u001F.\u000F\u0007));
			}
			IEnumerable<Space> enumerable5 = Enumerable.Cast<Space>(Enumerable.Select<Tuple<SpatialElement, RevitLinkInstance>, SpatialElement>(enumerable4, func4));
			Func<Space, ModelSpace> func5;
			if ((func5 = QuickViewsViewModel.<>c.\u0001) == null)
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
				func5 = (QuickViewsViewModel.<>c.\u0001 = new Func<Space, ModelSpace>(QuickViewsViewModel.<>c.\u001F.\u0012\u0007));
			}
			List<ModelSpace> list3 = Enumerable.ToList<ModelSpace>(Enumerable.Select<Space, ModelSpace>(enumerable5, func5));
			IEnumerable<Tuple<SpatialElement, RevitLinkInstance>> enumerable6 = this.CR.\u0006();
			Func<Tuple<SpatialElement, RevitLinkInstance>, bool> func6;
			if ((func6 = QuickViewsViewModel.<>c.\u0009) == null)
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
				func6 = (QuickViewsViewModel.<>c.\u0009 = new Func<Tuple<SpatialElement, RevitLinkInstance>, bool>(QuickViewsViewModel.<>c.\u001F.\u0003\u0007));
			}
			IEnumerable<Tuple<SpatialElement, RevitLinkInstance>> enumerable7 = Enumerable.Where<Tuple<SpatialElement, RevitLinkInstance>>(enumerable6, func6);
			Func<Tuple<SpatialElement, RevitLinkInstance>, SpatialElement> func7;
			if ((func7 = QuickViewsViewModel.<>c.\u001F\u000A) == null)
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
				func7 = (QuickViewsViewModel.<>c.\u001F\u000A = new Func<Tuple<SpatialElement, RevitLinkInstance>, SpatialElement>(QuickViewsViewModel.<>c.\u001F.\u001C\u0007));
			}
			IEnumerable<Room> enumerable8 = Enumerable.Cast<Room>(Enumerable.Select<Tuple<SpatialElement, RevitLinkInstance>, SpatialElement>(enumerable7, func7));
			Func<Room, ModelRoom> func8;
			if ((func8 = QuickViewsViewModel.<>c.\u000A\u000A) == null)
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
				func8 = (QuickViewsViewModel.<>c.\u000A\u000A = new Func<Room, ModelRoom>(QuickViewsViewModel.<>c.\u001F.\u000D\u0007));
			}
			List<ModelRoom> list4 = Enumerable.ToList<ModelRoom>(Enumerable.Select<Room, ModelRoom>(enumerable8, func8));
			\u0007\u000E\u0007.\u000A(list, new \u0010\u0004(SpatialElementSortPriority.Level, SortDirection.Ascending));
			\u000A\u000E\u0007.\u000A(list2, new \u0010\u0004(SpatialElementSortPriority.Level, SortDirection.Ascending));
			\u0007\u000E\u0007.\u000A(list3, new \u0010\u0004(SpatialElementSortPriority.Level, SortDirection.Ascending));
			\u000A\u000E\u0007.\u000A(list4, new \u0010\u0004(SpatialElementSortPriority.Level, SortDirection.Ascending));
			List<IModelElement> list5 = \u001F\u000E\u0007.\u000A();
			switch (\u0018\u000D\u0007.\u000A(this))
			{
			case ModelSpatialElementType.All:
				\u0009\u0010\u0007.\u000A(list5, Enumerable.ToList<ModelSpatialElement>(Enumerable.Cast<ModelSpatialElement>(list)));
				\u0009\u0010\u0007.\u000A(list5, Enumerable.ToList<ModelSpatialElement>(Enumerable.Cast<ModelSpatialElement>(list2)));
				\u0009\u0010\u0007.\u000A(list5, Enumerable.ToList<ModelSpatialElement>(Enumerable.Cast<ModelSpatialElement>(list3)));
				\u0009\u0010\u0007.\u000A(list5, Enumerable.ToList<ModelSpatialElement>(Enumerable.Cast<ModelSpatialElement>(list4)));
				break;
			case ModelSpatialElementType.Spaces:
				\u0009\u0010\u0007.\u000A(list5, Enumerable.ToList<ModelSpatialElement>(Enumerable.Cast<ModelSpatialElement>(list)));
				\u0009\u0010\u0007.\u000A(list5, Enumerable.ToList<ModelSpatialElement>(Enumerable.Cast<ModelSpatialElement>(list3)));
				break;
			case ModelSpatialElementType.Rooms:
				\u0009\u0010\u0007.\u000A(list5, Enumerable.ToList<ModelSpatialElement>(Enumerable.Cast<ModelSpatialElement>(list2)));
				\u0009\u0010\u0007.\u000A(list5, Enumerable.ToList<ModelSpatialElement>(Enumerable.Cast<ModelSpatialElement>(list4)));
				break;
			}
			return list5;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00017D74 File Offset: 0x00015F74
		[BindableMethod("OnSelectedModelSpatialElements")]
		public void OnSelectedModelSpatialElements(object sender)
		{
			List<IModelElement> u001F = Enumerable.ToList<IModelElement>(Enumerable.OfType<IModelElement>(\u0009\u0006\u0007.\u0007(\u001D\u001F\u000E.\u001F(sender))));
			\u001D\u000E\u0007.\u000A(this, \u0004\u000E\u0007.\u000A(u001F));
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00017DB0 File Offset: 0x00015FB0
		public void UpdateLabel()
		{
			string u001F = \u0016\u000E\u0007.\u000A();
			IEnumerable<ModelSpatialElement> enumerable = Enumerable.Cast<ModelSpatialElement>(\u0005\u000E\u0007.\u000A(\u0013\u0003\u0007.\u0007(this)));
			Func<ModelSpatialElement, bool> func;
			if ((func = QuickViewsViewModel.<>c.\u0007\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.UpdateLabel()).MethodHandle;
				}
				func = (QuickViewsViewModel.<>c.\u0007\u000A = new Func<ModelSpatialElement, bool>(QuickViewsViewModel.<>c.\u001F.\u0010\u0007));
			}
			object u000A = Enumerable.Count<ModelSpatialElement>(enumerable, func);
			IEnumerable<ModelSpatialElement> enumerable2 = Enumerable.Cast<ModelSpatialElement>(\u0005\u000E\u0007.\u000A(\u0013\u0003\u0007.\u0007(this)));
			Func<ModelSpatialElement, bool> func2;
			if ((func2 = QuickViewsViewModel.<>c.\u001D\u000A) == null)
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
				func2 = (QuickViewsViewModel.<>c.\u001D\u000A = new Func<ModelSpatialElement, bool>(QuickViewsViewModel.<>c.\u001F.\u000E\u0007));
			}
			\u0019\u000E\u0007.\u000A(this, \u0018\u000E\u0007.\u000A(u001F, u000A, Enumerable.Count<ModelSpatialElement>(enumerable2, func2)));
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00017E70 File Offset: 0x00016070
		public void SelectSpatialElements()
		{
			\u0012\u0004 u0012_u = new \u0012\u0004(this);
			\u000D\u0001\u000A.\u001D(u0012_u, \u000B\u000E\u0007.\u000A());
			\u0012\u0004 u0012_u2 = u0012_u;
			u0012_u2.\u001F += this.UpdateLabel;
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u0012_u2);
			\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00017EC0 File Offset: 0x000160C0
		private bool XJR(object F)
		{
			try
			{
				Document r = this.R;
				bool flag;
				if (r == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.XJR(object)).MethodHandle;
					}
					flag = false;
				}
				else
				{
					flag = \u000B\u001A\u000A.\u001D(r);
				}
				bool result;
				if (flag)
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
					result = (\u0016\u001F\u000E.\u001F(\u0004\u0013\u000A.\u0007(this.R)) != \u000B\u001F\u000E.\u001F);
				}
				else
				{
					result = false;
				}
				return result;
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u001E\u000A\u0007.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\ViewModels\\QuickViewsViewModel.cs", "CanSelectElements");
			}
			return false;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00017F50 File Offset: 0x00016150
		private void PJR()
		{
			\u0016\u0004 u0016_u = new \u0016\u0004();
			\u000E\u000E\u0007.\u000A(u0016_u, \u0019\u0004.\u000A());
			\u0010\u000E\u0007.\u000A(u0016_u, \u0019\u0004.\u001F());
			\u001C\u000E\u0007.\u000A(u0016_u, \u000D\u000E\u0007.\u000A(this));
			\u0012\u000E\u0007.\u000A(u0016_u, \u0003\u000E\u0007.\u000A(this));
			\u0006\u000E\u0007.\u000A(u0016_u, \u000F\u000E\u0007.\u000A(this));
			\u0002\u000E\u0007.\u000A(u0016_u, this.WD);
			\u0016\u0004 u000A = u0016_u;
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000A);
			\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00017FD0 File Offset: 0x000161D0
		private bool OJR(object F)
		{
			if (!\u000D\u000E\u0007.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.OJR(object)).MethodHandle;
				}
				if (!\u0003\u000E\u0007.\u000A(this))
				{
					return false;
				}
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
			IEnumerable<IModelElement> ud = this.UD;
			Func<IModelElement, bool> func;
			if ((func = QuickViewsViewModel.<>c.\u0004\u000A) == null)
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
				func = (QuickViewsViewModel.<>c.\u0004\u000A = new Func<IModelElement, bool>(QuickViewsViewModel.<>c.\u001F.\u0008\u0007));
			}
			return Enumerable.Any<IModelElement>(ud, func);
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00018048 File Offset: 0x00016248
		private void TJR()
		{
			QuickViewsViewModel.\u0018\u001D u0018_u001D = new QuickViewsViewModel.\u0018\u001D();
			u0018_u001D.\u001F = this;
			u0018_u001D.\u000A = \u001C\u0013\u000A.\u000A();
			IEnumerable<IModelElement> enumerable = \u000E\u000D\u0007.\u000A(this);
			Func<IModelElement, bool> func;
			if ((func = QuickViewsViewModel.<>c.\u0019\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.TJR()).MethodHandle;
				}
				func = (QuickViewsViewModel.<>c.\u0019\u000A = new Func<IModelElement, bool>(QuickViewsViewModel.<>c.\u001F.\u001B\u0007));
			}
			IEnumerable<IModelElement> enumerable2 = Enumerable.Where<IModelElement>(enumerable, func);
			Func<IModelElement, SpatialElementStoredData> func2;
			if ((func2 = QuickViewsViewModel.<>c.\u0018\u000A) == null)
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
				func2 = (QuickViewsViewModel.<>c.\u0018\u000A = new Func<IModelElement, SpatialElementStoredData>(QuickViewsViewModel.<>c.\u001F.\u0011\u0007));
			}
			\u0002\u0010\u0007.\u000A(Enumerable.ToList<SpatialElementStoredData>(Enumerable.Select<IModelElement, SpatialElementStoredData>(enumerable2, func2)), new Action<SpatialElementStoredData>(u0018_u001D.\u001D));
			u0018_u001D.\u0007 = \u0017\u0010\u0007.\u000A(\u0004\u0010\u0007.\u000A(this));
			ElementId u000A = \u0002\u001E\u000A.\u0007(\u0004\u0013\u000A.\u0007(this.R));
			WarningWindow u001F = \u0015\u000E\u0007.\u000A();
			\u000C\u000E\u0007.\u0007(u001F, \u0018\u000B\u0007.\u0007(this));
			\u0020\u0014\u000A.\u0007(u001F, WindowStartupLocation.CenterOwner);
			bool? flag = \u0018\u0020\u000A.\u0007(u001F);
			if (!\u0012\u0015\u000A.\u000A(ref flag))
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
				return;
			}
			if (\u001E\u0010\u0007.\u000A(u0018_u001D.\u0007) == 1)
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
				if (\u0014\u000E\u0007.\u000A(u0018_u001D.\u000A, u000A))
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
					\u001E\u000E\u0007.\u000A(\u0018\u000E\u0007.\u000A("{0}\n{1}", \u001A\u000E\u0007.\u000A(), \u0013\u000E\u0007.\u000A()), \u0018\u000B\u0007.\u0007(this), 425.0, MessageBoxButtons.OK);
					return;
				}
			}
			if (\u0014\u000E\u0007.\u000A(u0018_u001D.\u000A, u000A))
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
				if (!\u001E\u000E\u0007.\u000A(\u0018\u000E\u0007.\u000A("{0}\n{1}", \u0017\u000E\u0007.\u000A(), \u0020\u000E\u0007.\u000A()), \u0018\u000B\u0007.\u0007(this), 350.0, MessageBoxButtons.YesNo))
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
					return;
				}
				\u0011\u000E\u0007.\u000A(Enumerable.ToList<UIView>(Enumerable.Where<UIView>(u0018_u001D.\u0007, new Func<UIView, bool>(u0018_u001D.\u0004))), new Action<UIView>(u0018_u001D.\u0019));
				\u001D\u0010\u0007.\u0007(\u0004\u0010\u0007.\u000A(this), \u0005\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(this.R, \u0008\u000E\u0007.\u000A(\u001B\u000E\u0007.\u000A(u0018_u001D.\u0007, 0)))));
			}
			this.IJR();
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00018290 File Offset: 0x00016490
		private void IJR()
		{
			\u000D\u0004 u000D_u = new \u000D\u0004();
			\u0001\u000E\u0007.\u000A(u000D_u, this.WD);
			\u000D\u0004 u000A = u000D_u;
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000A);
			\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x000182CC File Offset: 0x000164CC
		private bool QJR(object F)
		{
			IEnumerable<IModelElement> ud = this.UD;
			Func<IModelElement, bool> func;
			if ((func = QuickViewsViewModel.<>c.\u0002\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.QJR(object)).MethodHandle;
				}
				func = (QuickViewsViewModel.<>c.\u0002\u000A = new Func<IModelElement, bool>(QuickViewsViewModel.<>c.\u001F.\u0014\u0007));
			}
			return Enumerable.Any<IModelElement>(ud, func);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00018318 File Offset: 0x00016518
		[BindableMethod("OpenElevationsAndSectionsSettingsWindow")]
		public void OpenElevationsAndSectionsSettingsWindow()
		{
			if (\u001F\u0008\u0007.\u000A(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.OpenElevationsAndSectionsSettingsWindow()).MethodHandle;
				}
				\u000A\u0008\u0007.\u000A(this, \u0007\u0008\u0007.\u000A(null, null, \u0019\u001F\u000E.\u001F));
			}
			SectionsAndElevationsSettingsWindow u001F = \u0009\u000E\u0007.\u000A(\u001F\u0008\u0007.\u000A(this));
			\u000C\u000E\u0007.\u0007(u001F, \u0018\u000B\u0007.\u0007(this));
			\u0020\u0014\u000A.\u0007(u001F, WindowStartupLocation.CenterOwner);
			\u0018\u0020\u000A.\u0007(u001F);
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00018384 File Offset: 0x00016584
		[BindableMethod("OpenCalloutsSettingsWindow")]
		public void OpenCalloutsSettingsWindow()
		{
			if (\u0004\u0008\u0007.\u000A(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.OpenCalloutsSettingsWindow()).MethodHandle;
				}
				\u0019\u0008\u0007.\u000A(this, \u0018\u0008\u0007.\u000A(null, null, \u0019\u001F\u000E.\u001F));
			}
			CalloutSettingsWindow u001F = \u001D\u0008\u0007.\u000A(\u0004\u0008\u0007.\u000A(this));
			\u000C\u000E\u0007.\u0007(u001F, \u0018\u000B\u0007.\u0007(this));
			\u0020\u0014\u000A.\u0007(u001F, WindowStartupLocation.CenterOwner);
			\u0018\u0020\u000A.\u0007(u001F);
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x000183F0 File Offset: 0x000165F0
		private void AJR()
		{
			QuickViewsViewModel.\u0005\u001D u0005_u001D = new QuickViewsViewModel.\u0005\u001D();
			\u0011\u0003\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\ViewModels\\QuickViewsViewModel.cs", "InitElementsCollection");
			List<ModelSpace> list = Enumerable.ToList<ModelSpace>(\u0008\u0008\u0007.\u0007(this.WD));
			List<ModelRoom> list2 = Enumerable.ToList<ModelRoom>(\u000E\u0008\u0007.\u0007(this.WD));
			u0005_u001D.\u001F = \u0010\u0008\u0007.\u000A();
			\u000D\u0008\u0007.\u000A(list, new Action<ModelSpace>(u0005_u001D.\u000A));
			\u001C\u0008\u0007.\u000A(list2, new Action<ModelRoom>(u0005_u001D.\u0007));
			this.GJR(u0005_u001D.\u001F);
			List<ModelSpatialElement>.Enumerator enumerator = \u0002\u001C\u0007.\u000A(u0005_u001D.\u001F);
			try
			{
				while (\u0004\u001C\u0007.\u000A(ref enumerator))
				{
					QuickViewsViewModel.\u0016\u001D u0016_u001D = new QuickViewsViewModel.\u0016\u001D();
					u0016_u001D.\u001F = \u000B\u001C\u0007.\u000A(ref enumerator);
					List<ViewInformation> list3;
					if (!\u0014\u001C\u0007.\u0007(u0016_u001D.\u001F))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.AJR()).MethodHandle;
						}
						list3 = Enumerable.ToList<ViewInformation>(Enumerable.Where<ViewInformation>(this.TD, new Func<ViewInformation, bool>(u0016_u001D.\u000A)));
					}
					else
					{
						list3 = this.TD;
					}
					List<ViewInformation> list4 = list3;
					IEnumerable<ViewInformation> enumerable = list4;
					Func<ViewInformation, string> func;
					if ((func = QuickViewsViewModel.<>c.\u0006\u000A) == null)
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
						func = (QuickViewsViewModel.<>c.\u0006\u000A = new Func<ViewInformation, string>(QuickViewsViewModel.<>c.\u001F.\u0013\u0007));
					}
					IOrderedEnumerable<ViewInformation> orderedEnumerable = Enumerable.OrderBy<ViewInformation, string>(enumerable, func);
					Func<ViewInformation, ViewInformation> func2;
					if ((func2 = QuickViewsViewModel.<>c.\u000F\u000A) == null)
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
						func2 = (QuickViewsViewModel.<>c.\u000F\u000A = new Func<ViewInformation, ViewInformation>(QuickViewsViewModel.<>c.\u001F.\u001A\u0007));
					}
					list4 = Enumerable.ToList<ViewInformation>(Enumerable.ThenBy<ViewInformation, ViewInformation>(orderedEnumerable, func2, new \u001B\u0004()));
					ListCollectionView listCollectionView = \u0003\u0008\u0007.\u000A(list4);
					\u0006\u0008\u0007.\u000A(\u0012\u0008\u0007.\u000A(listCollectionView), \u000F\u0008\u0007.\u000A("ViewTypeString"));
					\u0002\u0008\u0007.\u000A(u0016_u001D.\u001F, listCollectionView);
					ModelSpatialElement u001F = u0016_u001D.\u001F;
					if (\u0016\u000D\u0007.\u000A(u001F) == null)
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
						\u0019\u001C\u0007.\u000A(u001F, Enumerable.FirstOrDefault<ViewInformation>(list4));
					}
					if (\u0016\u000D\u0007.\u000A(u0016_u001D.\u001F) != null)
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
						\u0019\u001C\u0007.\u000A(u0016_u001D.\u001F, \u0018\u001C\u0007.\u000A(list4, new Predicate<ViewInformation>(u0016_u001D.\u0007)));
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
				((IDisposable)enumerator).Dispose();
			}
			\u0007\u000E\u0007.\u000A(list, new \u0010\u0004(SpatialElementSortPriority.Level, SortDirection.Ascending));
			\u000A\u000E\u0007.\u000A(list2, new \u0010\u0004(SpatialElementSortPriority.Level, SortDirection.Ascending));
			\u0009\u0010\u0007.\u000A(this.UD, list);
			\u0009\u0010\u0007.\u000A(this.UD, list2);
			\u000B\u0008\u0007.\u000A(this, \u0011\u0009\u000A.\u000A(this.UD));
			ICollectionView u001F2 = \u0013\u0003\u0007.\u0007(this);
			\u0005\u0008\u0007.\u000A(u001F2, \u0018\u001F\u000E.\u001F(\u000F\u001E\u000A.\u000A(\u0016\u0008\u0007.\u000A(u001F2), new Predicate<object>(this.LJR))));
			\u000F\u0012\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\ViewModels\\QuickViewsViewModel.cs", "InitElementsCollection");
		}

		// Token: 0x060003DA RID: 986 RVA: 0x000186D8 File Offset: 0x000168D8
		private void GJR(List<ModelSpatialElement> F)
		{
			List<ModelSpatialElement>.Enumerator enumerator = \u0002\u001C\u0007.\u000A(F);
			try
			{
				while (\u0004\u001C\u0007.\u000A(ref enumerator))
				{
					ModelSpatialElement u001F = \u000B\u001C\u0007.\u000A(ref enumerator);
					this.FER(\u0020\u0008\u0007.\u0007(\u0011\u0008\u0007.\u000A(u001F)));
					if (!Enumerable.Any<string>(\u0020\u0008\u0007.\u0007(\u0011\u0008\u0007.\u000A(u001F))))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.GJR(List<ModelSpatialElement>)).MethodHandle;
						}
						\u0013\u0010\u0007.\u000A(u001F, 1);
					}
					this.FER(\u001E\u0008\u0007.\u0007(\u0011\u0008\u0007.\u000A(u001F)));
					this.FER(\u001B\u0008\u0007.\u0007(\u0011\u0008\u0007.\u000A(u001F)));
					if (!Enumerable.Any<string>(\u001E\u0008\u0007.\u0007(\u0011\u0008\u0007.\u000A(u001F))))
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
						if (!Enumerable.Any<string>(\u001B\u0008\u0007.\u0007(\u0011\u0008\u0007.\u000A(u001F))))
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
							\u0005\u0010\u0007.\u000A(u001F, 1);
						}
					}
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
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060003DB RID: 987 RVA: 0x000187F4 File Offset: 0x000169F4
		private void FER(List<string> F)
		{
			List<string> u001F = \u0014\u000D\u0007.\u000A();
			List<string>.Enumerator enumerator = \u0013\u0008\u0007.\u000A(F);
			try
			{
				while (\u0017\u0008\u0007.\u000A(ref enumerator))
				{
					string u000A = \u0014\u0008\u0007.\u000A(ref enumerator);
					if (\u000C\u0008\u0007.\u000A(this.R, u000A) == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.FER(List<string>)).MethodHandle;
						}
						\u001A\u0008\u0007.\u000A(u001F, u000A);
					}
				}
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			enumerator = \u0013\u0008\u0007.\u000A(u001F);
			try
			{
				while (\u0017\u0008\u0007.\u000A(ref enumerator))
				{
					string u000A2 = \u0014\u0008\u0007.\u000A(ref enumerator);
					\u000F\u0010\u0007.\u000A(F, u000A2);
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x000188D0 File Offset: 0x00016AD0
		[BindableMethod("OnWindowClosing")]
		public void OnWindowClosing()
		{
			this.RER();
		}

		// Token: 0x060003DD RID: 989 RVA: 0x000188E4 File Offset: 0x00016AE4
		private void RER()
		{
			\u0011\u0003\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\ViewModels\\QuickViewsViewModel.cs", "SaveUserSettings");
			\u000A\u001B\u0007.\u000A(\u0001\u0008\u0007.\u000A(), (int)\u000F\u000E\u0007.\u000A(this));
			\u001F\u001B\u0007.\u000A(\u0001\u0008\u0007.\u000A(), \u000D\u000E\u0007.\u000A(this));
			\u0009\u0008\u0007.\u000A(\u0001\u0008\u0007.\u000A(), \u0003\u000E\u0007.\u000A(this));
			\u0015\u0008\u0007.\u000A(\u0001\u0008\u0007.\u000A());
			\u000F\u0012\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\ViewModels\\QuickViewsViewModel.cs", "SaveUserSettings");
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00018968 File Offset: 0x00016B68
		private void DER()
		{
			\u0011\u0003\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\ViewModels\\QuickViewsViewModel.cs", "LoadUserSettings");
			\u0018\u001B\u0007.\u000A(this, (SectionOrElevationView)\u0005\u001B\u0007.\u000A(\u0001\u0008\u0007.\u000A()));
			\u0004\u001B\u0007.\u000A(this, \u0019\u001B\u0007.\u000A(\u0001\u0008\u0007.\u000A()));
			\u0007\u001B\u0007.\u000A(this, \u001D\u001B\u0007.\u000A(\u0001\u0008\u0007.\u000A()));
			\u000F\u0012\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\ViewModels\\QuickViewsViewModel.cs", "LoadUserSettings");
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060003DF RID: 991 RVA: 0x000189E0 File Offset: 0x00016BE0
		// (set) Token: 0x060003E0 RID: 992 RVA: 0x000189F4 File Offset: 0x00016BF4
		public string SearchTxt
		{
			get
			{
				return this.BD;
			}
			set
			{
				this.BD = value;
				\u0014\u0003\u0007.\u000A(\u0013\u0003\u0007.\u0007(this));
				\u0017\u0003\u0007.\u0007(this);
			}
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00018A1C File Offset: 0x00016C1C
		public TemplateInfo AddProfile()
		{
			return this.HER();
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00018A34 File Offset: 0x00016C34
		public TemplateInfo SaveProfile()
		{
			return this.HER();
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00018A4C File Offset: 0x00016C4C
		private TemplateInfo HER()
		{
			TemplateInfo templateInfo = \u000D\u001B\u0007.\u000A();
			\u001C\u001B\u0007.\u000A(templateInfo, \u000F\u001C\u0007.\u000A(this));
			\u0003\u001B\u0007.\u000A(templateInfo, \u000D\u000E\u0007.\u000A(this));
			\u0012\u001B\u0007.\u000A(templateInfo, \u0003\u000E\u0007.\u000A(this));
			IEnumerable<IModelElement> ud = this.UD;
			Func<IModelElement, bool> func;
			if ((func = QuickViewsViewModel.<>c.\u0012\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.HER()).MethodHandle;
				}
				func = (QuickViewsViewModel.<>c.\u0012\u000A = new Func<IModelElement, bool>(QuickViewsViewModel.<>c.\u001F.\u000C\u0007));
			}
			List<IModelElement> list = Enumerable.ToList<IModelElement>(Enumerable.Where<IModelElement>(ud, func));
			IEnumerable<IModelElement> enumerable = list;
			Func<IModelElement, long> func2;
			if ((func2 = QuickViewsViewModel.<>c.\u0003\u000A) == null)
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
				func2 = (QuickViewsViewModel.<>c.\u0003\u000A = new Func<IModelElement, long>(QuickViewsViewModel.<>c.\u001F.\u0015\u0007));
			}
			\u0006\u001B\u0007.\u000A(templateInfo, \u000F\u001B\u0007.\u000A(Enumerable.ToList<long>(Enumerable.Select<IModelElement, long>(enumerable, func2))));
			\u0002\u001B\u0007.\u000A(templateInfo, \u000B\u0016\u0007.\u000A());
			\u0016\u001B\u0007.\u000A(templateInfo, \u000B\u001B\u0007.\u000A());
			return templateInfo;
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00018B30 File Offset: 0x00016D30
		public void ProfileChanged(ProfileTemplate profileInfo)
		{
			QuickViewsViewModel.\u000B\u001D u000B_u001D = new QuickViewsViewModel.\u000B\u001D();
			u000B_u001D.\u001F = \u0004\u001F\u000E.\u001F(profileInfo);
			if (u000B_u001D.\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.ProfileChanged(ProfileTemplate)).MethodHandle;
				}
				return;
			}
			\u0015\u001B\u0007.\u000A(this, \u0001\u001B\u0007.\u000A(u000B_u001D.\u001F));
			\u0004\u001B\u0007.\u000A(this, \u000C\u001B\u0007.\u000A(u000B_u001D.\u001F));
			\u0007\u001B\u0007.\u000A(this, \u001A\u001B\u0007.\u000A(u000B_u001D.\u001F));
			object u001F = Enumerable.ToList<IModelElement>(Enumerable.Where<IModelElement>(this.UD, new Func<IModelElement, bool>(u000B_u001D.\u000A)));
			Action<IModelElement> u000A;
			if ((u000A = QuickViewsViewModel.<>c.\u001C\u000A) == null)
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
				u000A = (QuickViewsViewModel.<>c.\u001C\u000A = new Action<IModelElement>(QuickViewsViewModel.<>c.\u001F.\u0001\u0007));
			}
			\u000C\u0003\u0007.\u000A(u001F, u000A);
			\u0008\u0003\u0007.\u000A(\u0017\u001B\u0007.\u000A(u000B_u001D.\u001F));
			\u0019\u0008\u0007.\u000A(this, \u0018\u0008\u0007.\u000A(null, null, \u0019\u001F\u000E.\u001F));
			IModelSettings u001F2 = \u0019\u001F\u000E.\u001F;
			if (\u0013\u001B\u0007.\u000A(\u0017\u001B\u0007.\u000A(u000B_u001D.\u001F)) != null)
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
				u001F2 = \u0013\u001B\u0007.\u000A(\u0017\u001B\u0007.\u000A(u000B_u001D.\u001F));
			}
			IModelSettings u000A2 = \u0019\u001F\u000E.\u001F;
			if (\u0014\u001B\u0007.\u000A(\u0017\u001B\u0007.\u000A(u000B_u001D.\u001F)) != null)
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
				u000A2 = \u0014\u001B\u0007.\u000A(\u0017\u001B\u0007.\u000A(u000B_u001D.\u001F));
			}
			IModelSettings u = \u0019\u001F\u000E.\u001F;
			if (Enumerable.Any<ParameterSettingInfo>(\u0020\u001B\u0007.\u000A(\u0017\u001B\u0007.\u000A(u000B_u001D.\u001F))))
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
				List<ParameterSettingInfo> u000A3 = \u0020\u001B\u0007.\u000A(\u0017\u001B\u0007.\u000A(u000B_u001D.\u001F));
				u = \u0010\u001B\u0007.\u000A(\u0006\u000B\u0007.\u001D(\u0004\u0008\u0007.\u000A(this)), u000A3);
			}
			\u0019\u0008\u0007.\u000A(this, \u0018\u0008\u0007.\u000A(u001F2, u000A2, u));
			\u0003\u0003\u0007.\u000A(\u001B\u001B\u0007.\u000A(u000B_u001D.\u001F));
			\u000A\u0008\u0007.\u000A(this, \u0007\u0008\u0007.\u000A(null, null, \u0019\u001F\u000E.\u001F));
			IModelSettings u001F3 = \u0019\u001F\u000E.\u001F;
			if (\u001E\u001B\u0007.\u000A(\u001B\u001B\u0007.\u000A(u000B_u001D.\u001F)) != null)
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
				u001F3 = \u001E\u001B\u0007.\u000A(\u001B\u001B\u0007.\u000A(u000B_u001D.\u001F));
			}
			IModelSettings u000A4 = \u0019\u001F\u000E.\u001F;
			if (\u0011\u001B\u0007.\u000A(\u001B\u001B\u0007.\u000A(u000B_u001D.\u001F)) != null)
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
				u000A4 = \u0011\u001B\u0007.\u000A(\u001B\u001B\u0007.\u000A(u000B_u001D.\u001F));
			}
			IModelSettings u2 = \u0019\u001F\u000E.\u001F;
			if (Enumerable.Any<ParameterSettingInfo>(\u0008\u001B\u0007.\u000A(\u001B\u001B\u0007.\u000A(u000B_u001D.\u001F))))
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
				List<ParameterSettingInfo> u000A5 = \u0008\u001B\u0007.\u000A(\u001B\u001B\u0007.\u000A(u000B_u001D.\u001F));
				u2 = \u0010\u001B\u0007.\u000A(\u000E\u001B\u0007.\u0007(\u001F\u0008\u0007.\u000A(this)), u000A5);
			}
			\u000A\u0008\u0007.\u000A(this, \u0007\u0008\u0007.\u000A(u001F3, u000A4, u2));
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00018E10 File Offset: 0x00017010
		[CompilerGenerated]
		private SectionOrElevationView YER()
		{
			return \u000F\u000E\u0007.\u000A(this);
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00018E28 File Offset: 0x00017028
		[CompilerGenerated]
		private int CER()
		{
			return \u000F\u001C\u0007.\u000A(this);
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00018E40 File Offset: 0x00017040
		[CompilerGenerated]
		private bool LER()
		{
			return \u0013\u001C\u0007.\u0007(this);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00018E58 File Offset: 0x00017058
		[CompilerGenerated]
		private bool SER()
		{
			return \u0009\u001B\u0007.\u000A(this);
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00018E70 File Offset: 0x00017070
		[CompilerGenerated]
		private bool BER()
		{
			return \u001F\u0011\u0007.\u000A(this);
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00018E88 File Offset: 0x00017088
		[CompilerGenerated]
		private bool UER()
		{
			return \u000A\u0011\u0007.\u000A(this);
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00018EA0 File Offset: 0x000170A0
		[CompilerGenerated]
		private bool WER()
		{
			return \u000C\u001C\u0007.\u000A(this);
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00018EB8 File Offset: 0x000170B8
		[CompilerGenerated]
		private bool KER(IModelElement F)
		{
			return \u0007\u0011\u0007.\u000A(\u0013\u0003\u0007.\u0007(this), F);
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00018ED8 File Offset: 0x000170D8
		[CompilerGenerated]
		private Element JER(ElementId F)
		{
			return \u0011\u0017\u000A.\u0007(this.R, F);
		}

		// Token: 0x0400013F RID: 319
		private int SD = 1;

		// Token: 0x04000140 RID: 320
		private string BD;

		// Token: 0x04000141 RID: 321
		internal List<IModelElement> UD = new List<IModelElement>();

		// Token: 0x04000142 RID: 322
		private readonly Document R;

		// Token: 0x04000143 RID: 323
		private readonly \u0013\u001D CR;

		// Token: 0x04000144 RID: 324
		private readonly SpatialElementsSchema WD;

		// Token: 0x04000145 RID: 325
		private bool KD;

		// Token: 0x04000146 RID: 326
		private IList JD;

		// Token: 0x04000147 RID: 327
		private IList ED;

		// Token: 0x04000148 RID: 328
		private SpatialElementStatus ND;

		// Token: 0x04000149 RID: 329
		private bool MD;

		// Token: 0x0400014A RID: 330
		private bool VD;

		// Token: 0x0400014B RID: 331
		private bool ZD;

		// Token: 0x0400014C RID: 332
		private bool XD;

		// Token: 0x0400014D RID: 333
		private string PD;

		// Token: 0x0400014E RID: 334
		private SectionOrElevationView OD;

		// Token: 0x0400014F RID: 335
		private List<ViewInformation> TD;

		// Token: 0x04000150 RID: 336
		private IList<ModelSpatialElement> ID;

		// Token: 0x04000151 RID: 337
		[CompilerGenerated]
		private SubItems QD;

		// Token: 0x04000152 RID: 338
		[CompilerGenerated]
		private SubItems AD;

		// Token: 0x04000153 RID: 339
		[CompilerGenerated]
		private SubItems GD;

		// Token: 0x04000154 RID: 340
		[CompilerGenerated]
		private SubItems FH;

		// Token: 0x04000155 RID: 341
		[CompilerGenerated]
		private ICollectionView RH;

		// Token: 0x04000156 RID: 342
		[CompilerGenerated]
		private List<SpatialType> DH;

		// Token: 0x04000157 RID: 343
		[CompilerGenerated]
		private List<SpatialStatus> HH;

		// Token: 0x04000158 RID: 344
		[CompilerGenerated]
		private ViewFilters YH;

		// Token: 0x04000159 RID: 345
		[CompilerGenerated]
		private ViewFilters CH;

		// Token: 0x0400015A RID: 346
		[CompilerGenerated]
		private ViewFilters LH;

		// Token: 0x0400015B RID: 347
		[CompilerGenerated]
		private List<IModelElement> SH;

		// Token: 0x0400015C RID: 348
		private bool BH;

		// Token: 0x0400015D RID: 349
		private bool UH;

		// Token: 0x0400015E RID: 350
		[CompilerGenerated]
		private UIDocument WH;

		// Token: 0x0400015F RID: 351
		[CompilerGenerated]
		private Document KH;

		// Token: 0x04000160 RID: 352
		[CompilerGenerated]
		private CalloutsSettingsViewModel JH;

		// Token: 0x04000161 RID: 353
		[CompilerGenerated]
		private SectionsSettingsViewModel EH;

		// Token: 0x04000162 RID: 354
		[CompilerGenerated]
		private ModelSpatialElementType NH;

		// Token: 0x04000163 RID: 355
		[CompilerGenerated]
		private ObservableCollection<IModelElement> MH;

		// Token: 0x04000164 RID: 356
		[CompilerGenerated]
		private static CallOutInfo VH;

		// Token: 0x04000165 RID: 357
		[CompilerGenerated]
		private static SectionElevationInfo ZH;

		// Token: 0x04000166 RID: 358
		[CompilerGenerated]
		private ICommand XH;

		// Token: 0x04000167 RID: 359
		[CompilerGenerated]
		private ICommand PH;

		// Token: 0x04000168 RID: 360
		[CompilerGenerated]
		private ICommand OH;

		// Token: 0x04000169 RID: 361
		[CompilerGenerated]
		private ICommand TH;

		// Token: 0x0400016A RID: 362
		[CompilerGenerated]
		private ICommand IH;

		// Token: 0x0400016B RID: 363
		[CompilerGenerated]
		private ICommand QH;

		// Token: 0x0400016C RID: 364
		[CompilerGenerated]
		private ICommand AH;

		// Token: 0x0200079A RID: 1946
		[CompilerGenerated]
		private sealed class \u001A\u0007
		{
			// Token: 0x06004BC5 RID: 19397 RVA: 0x001DAAF4 File Offset: 0x001D8CF4
			internal bool \u001D(ModelSpatialElement \u001F)
			{
				IEnumerable<ViewInformation> enumerable = \u0010\u001F\u000E.\u001F(\u0005\u001C\u0007.\u000A(\u0016\u001C\u0007.\u000A(\u001F)));
				Func<ViewInformation, long> func;
				if ((func = QuickViewsViewModel.<>c.\u0018) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.\u001A\u0007.\u001D(ModelSpatialElement)).MethodHandle;
					}
					func = (QuickViewsViewModel.<>c.\u0018 = new Func<ViewInformation, long>(QuickViewsViewModel.<>c.\u001F.\u0011\u000A));
				}
				return Enumerable.Contains<long>(Enumerable.Select<ViewInformation, long>(enumerable, func), this.\u001F);
			}

			// Token: 0x06004BC6 RID: 19398 RVA: 0x001DAB60 File Offset: 0x001D8D60
			internal bool \u0004(ViewInformation \u001F)
			{
				return \u0011\u0016\u001D.\u000A(\u0002\u001E\u000A.\u0007(this.\u000A), \u001E\u0001\u000A.\u000A(\u000C\u0019\u001D.\u000A(\u001F)));
			}

			// Token: 0x04001F00 RID: 7936
			public long \u001F;

			// Token: 0x04001F01 RID: 7937
			public View \u000A;

			// Token: 0x04001F02 RID: 7938
			public Predicate<ViewInformation> \u0007;
		}

		// Token: 0x0200079B RID: 1947
		[CompilerGenerated]
		private sealed class \u000C\u0007
		{
			// Token: 0x06004BC8 RID: 19400 RVA: 0x001DABA4 File Offset: 0x001D8DA4
			internal bool \u000A(SelectionNamedItem \u001F)
			{
				if (\u0015\u001C\u0007.\u0007(\u001F) != 101)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.\u000C\u0007.\u000A(SelectionNamedItem)).MethodHandle;
					}
					return \u0012\u001D\u001D.\u000A(this.\u001F) == \u0015\u001C\u0007.\u0007(\u001F);
				}
				return true;
			}

			// Token: 0x04001F03 RID: 7939
			public ModelSpatialElement \u001F;
		}

		// Token: 0x0200079C RID: 1948
		[CompilerGenerated]
		private sealed class \u0015\u0007
		{
			// Token: 0x06004BCA RID: 19402 RVA: 0x001DAC00 File Offset: 0x001D8E00
			internal bool \u000A(SelectionNamedItem \u001F)
			{
				if (\u0015\u001C\u0007.\u0007(\u001F) != 101)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.\u0015\u0007.\u000A(SelectionNamedItem)).MethodHandle;
					}
					return \u000F\u001D\u001D.\u000A(this.\u001F) == \u0015\u001C\u0007.\u0007(\u001F);
				}
				return true;
			}

			// Token: 0x04001F04 RID: 7940
			public ModelSpatialElement \u001F;
		}

		// Token: 0x0200079D RID: 1949
		[CompilerGenerated]
		private sealed class \u0001\u0007
		{
			// Token: 0x06004BCC RID: 19404 RVA: 0x001DAC5C File Offset: 0x001D8E5C
			internal bool \u000A(ModelSpatialElement \u001F)
			{
				return \u0018\u0018\u0007.\u0007(\u001F) == \u0018\u0018\u0007.\u0007(this.\u001F);
			}

			// Token: 0x04001F05 RID: 7941
			public ModelSpatialElement \u001F;
		}

		// Token: 0x0200079E RID: 1950
		[CompilerGenerated]
		private sealed class \u0009\u0007
		{
			// Token: 0x06004BCE RID: 19406 RVA: 0x001DAC94 File Offset: 0x001D8E94
			internal bool \u0007(View \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x04001F06 RID: 7942
			public string \u001F;

			// Token: 0x04001F07 RID: 7943
			public Func<View, bool> \u000A;
		}

		// Token: 0x0200079F RID: 1951
		[CompilerGenerated]
		private sealed class \u001F\u001D
		{
			// Token: 0x06004BD0 RID: 19408 RVA: 0x001DACCC File Offset: 0x001D8ECC
			internal void \u0004(View \u001F)
			{
				\u001A\u0008\u0007.\u000A(this.\u001F, \u0005\u001E\u000A.\u000A(\u001F));
			}

			// Token: 0x06004BD1 RID: 19409 RVA: 0x001DACEC File Offset: 0x001D8EEC
			internal void \u0019(View \u001F)
			{
				\u001A\u0008\u0007.\u000A(this.\u000A, \u0005\u001E\u000A.\u000A(\u001F));
			}

			// Token: 0x04001F08 RID: 7944
			public List<string> \u001F;

			// Token: 0x04001F09 RID: 7945
			public List<string> \u000A;

			// Token: 0x04001F0A RID: 7946
			public Action<View> \u0007;

			// Token: 0x04001F0B RID: 7947
			public Action<View> \u001D;
		}

		// Token: 0x020007A0 RID: 1952
		[CompilerGenerated]
		private sealed class \u000A\u001D
		{
			// Token: 0x06004BD3 RID: 19411 RVA: 0x001DAD20 File Offset: 0x001D8F20
			internal bool \u0007(View \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x04001F0C RID: 7948
			public string \u001F;

			// Token: 0x04001F0D RID: 7949
			public Func<View, bool> \u000A;
		}

		// Token: 0x020007A1 RID: 1953
		[CompilerGenerated]
		private sealed class \u0007\u001D
		{
			// Token: 0x06004BD5 RID: 19413 RVA: 0x001DAD58 File Offset: 0x001D8F58
			internal void \u0004(SpatialElementStoredData \u001F)
			{
				List<View> list = \u001C\u000D\u0007.\u000A(\u001F, this.\u001F.R);
				IEnumerable<View> enumerable = list;
				Func<View, ElementId> func;
				if ((func = QuickViewsViewModel.<>c.\u0010) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.\u0007\u001D.\u0004(SpatialElementStoredData)).MethodHandle;
					}
					func = (QuickViewsViewModel.<>c.\u0010 = new Func<View, ElementId>(QuickViewsViewModel.<>c.\u001F.\u001F\u0007));
				}
				List<ElementId> u000A = Enumerable.ToList<ElementId>(Enumerable.Select<View, ElementId>(enumerable, func));
				if (\u0008\u0013\u000A.\u000A(this.\u000A, \u000E\u001C\u0006.\u000A()))
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
					IEnumerable<ElevationMarker> enumerable2 = \u0005\u0016\u001D.\u000A(\u001F, this.\u001F.R);
					Func<ElevationMarker, ElementId> func2;
					if ((func2 = QuickViewsViewModel.<>c.\u000E) == null)
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
						func2 = (QuickViewsViewModel.<>c.\u000E = new Func<ElevationMarker, ElementId>(QuickViewsViewModel.<>c.\u001F.\u000A\u0007));
					}
					List<ElementId> u000A2 = Enumerable.ToList<ElementId>(Enumerable.Select<ElevationMarker, ElementId>(enumerable2, func2));
					\u000F\u0013\u000A.\u000A(this.\u0007, u000A);
					\u000F\u0013\u000A.\u000A(this.\u0007, u000A2);
					\u0019\u001F\u0019.\u000A(\u001E\u0008\u0007.\u0007(\u001F));
					\u0019\u001F\u0019.\u000A(\u001B\u0008\u0007.\u0007(\u001F));
					return;
				}
				object u001F = list;
				Predicate<View> u000A3;
				if ((u000A3 = this.\u001D) == null)
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
					u000A3 = (this.\u001D = new Predicate<View>(this.\u0019));
				}
				View view = \u000E\u0001\u000D.\u000A(u001F, u000A3);
				if (view != null)
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
					\u0003\u0010\u0007.\u000A(this.\u0007, \u0002\u001E\u000A.\u0007(view));
					\u000F\u0010\u0007.\u000A(\u001E\u0008\u0007.\u0007(\u001F), \u0012\u0010\u0007.\u000A(view));
					this.\u001F.NJR(this.\u0007, \u001B\u0008\u0007.\u0007(\u001F), \u0002\u001E\u000A.\u0007(view));
				}
			}

			// Token: 0x06004BD6 RID: 19414 RVA: 0x001DAEEC File Offset: 0x001D90EC
			internal bool \u0019(View \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u000A);
			}

			// Token: 0x06004BD7 RID: 19415 RVA: 0x001DAF10 File Offset: 0x001D9110
			internal void \u0018()
			{
				this.\u001F.VJR(this.\u0007);
			}

			// Token: 0x04001F0E RID: 7950
			public QuickViewsViewModel \u001F;

			// Token: 0x04001F0F RID: 7951
			public string \u000A;

			// Token: 0x04001F10 RID: 7952
			public List<ElementId> \u0007;

			// Token: 0x04001F11 RID: 7953
			public Predicate<View> \u001D;
		}

		// Token: 0x020007A2 RID: 1954
		[CompilerGenerated]
		private sealed class \u001D\u001D
		{
			// Token: 0x06004BD9 RID: 19417 RVA: 0x001DAF44 File Offset: 0x001D9144
			internal Element \u001D(string \u001F)
			{
				return \u000C\u0008\u0007.\u000A(this.\u001F.R, \u001F);
			}

			// Token: 0x06004BDA RID: 19418 RVA: 0x001DAF64 File Offset: 0x001D9164
			internal bool \u0004(ElementId \u001F)
			{
				return \u0011\u0016\u001D.\u000A(\u001F, this.\u000A);
			}

			// Token: 0x04001F12 RID: 7954
			public QuickViewsViewModel \u001F;

			// Token: 0x04001F13 RID: 7955
			public ElementId \u000A;

			// Token: 0x04001F14 RID: 7956
			public Func<ElementId, bool> \u0007;
		}

		// Token: 0x020007A3 RID: 1955
		[CompilerGenerated]
		private sealed class \u0004\u001D
		{
			// Token: 0x06004BDC RID: 19420 RVA: 0x001DAF94 File Offset: 0x001D9194
			internal bool \u000A(UIView \u001F)
			{
				return \u0014\u000E\u0007.\u000A(this.\u001F, \u0008\u000E\u0007.\u000A(\u001F));
			}

			// Token: 0x04001F15 RID: 7957
			public List<ElementId> \u001F;
		}

		// Token: 0x020007A4 RID: 1956
		[CompilerGenerated]
		private sealed class \u0019\u001D
		{
			// Token: 0x06004BDE RID: 19422 RVA: 0x001DAFCC File Offset: 0x001D91CC
			internal void \u0004(SpatialElementStoredData \u001F)
			{
				List<View> list = \u0017\u000D\u0007.\u000A(\u001F, this.\u001F.R);
				IEnumerable<View> enumerable = list;
				Func<View, ElementId> func;
				if ((func = QuickViewsViewModel.<>c.\u0020) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.\u0019\u001D.\u0004(SpatialElementStoredData)).MethodHandle;
					}
					func = (QuickViewsViewModel.<>c.\u0020 = new Func<View, ElementId>(QuickViewsViewModel.<>c.\u001F.\u0018\u0007));
				}
				List<ElementId> u000A = Enumerable.ToList<ElementId>(Enumerable.Select<View, ElementId>(enumerable, func));
				if (\u0008\u0013\u000A.\u000A(this.\u000A, \u000E\u001C\u0006.\u000A()))
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
					\u000F\u0013\u000A.\u000A(this.\u0007, u000A);
					\u0019\u001F\u0019.\u000A(\u0020\u0008\u0007.\u0007(\u001F));
					return;
				}
				object u001F = list;
				Predicate<View> u000A2;
				if ((u000A2 = this.\u001D) == null)
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
					u000A2 = (this.\u001D = new Predicate<View>(this.\u0019));
				}
				View view = \u000E\u0001\u000D.\u000A(u001F, u000A2);
				if (view != null)
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
					\u0003\u0010\u0007.\u000A(this.\u0007, \u0002\u001E\u000A.\u0007(view));
					\u000F\u0010\u0007.\u000A(\u0020\u0008\u0007.\u0007(\u001F), \u0012\u0010\u0007.\u000A(view));
				}
			}

			// Token: 0x06004BDF RID: 19423 RVA: 0x001DB0D4 File Offset: 0x001D92D4
			internal bool \u0019(View \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u000A);
			}

			// Token: 0x06004BE0 RID: 19424 RVA: 0x001DB0F8 File Offset: 0x001D92F8
			internal void \u0018()
			{
				this.\u001F.VJR(this.\u0007);
			}

			// Token: 0x04001F16 RID: 7958
			public QuickViewsViewModel \u001F;

			// Token: 0x04001F17 RID: 7959
			public string \u000A;

			// Token: 0x04001F18 RID: 7960
			public List<ElementId> \u0007;

			// Token: 0x04001F19 RID: 7961
			public Predicate<View> \u001D;
		}

		// Token: 0x020007A5 RID: 1957
		[CompilerGenerated]
		private sealed class \u0018\u001D
		{
			// Token: 0x06004BE2 RID: 19426 RVA: 0x001DB12C File Offset: 0x001D932C
			internal void \u001D(SpatialElementStoredData \u001F)
			{
				IEnumerable<View> enumerable = \u0017\u000D\u0007.\u000A(\u001F, this.\u001F.R);
				Func<View, ElementId> func;
				if ((func = QuickViewsViewModel.<>c.\u0005\u000A) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsViewModel.\u0018\u001D.\u001D(SpatialElementStoredData)).MethodHandle;
					}
					func = (QuickViewsViewModel.<>c.\u0005\u000A = new Func<View, ElementId>(QuickViewsViewModel.<>c.\u001F.\u001E\u0007));
				}
				List<ElementId> u000A = Enumerable.ToList<ElementId>(Enumerable.Select<View, ElementId>(enumerable, func));
				IEnumerable<View> enumerable2 = \u001C\u000D\u0007.\u000A(\u001F, this.\u001F.R);
				Func<View, ElementId> func2;
				if ((func2 = QuickViewsViewModel.<>c.\u0016\u000A) == null)
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
					func2 = (QuickViewsViewModel.<>c.\u0016\u000A = new Func<View, ElementId>(QuickViewsViewModel.<>c.\u001F.\u0020\u0007));
				}
				List<ElementId> u000A2 = Enumerable.ToList<ElementId>(Enumerable.Select<View, ElementId>(enumerable2, func2));
				IEnumerable<ElevationMarker> enumerable3 = \u0005\u0016\u001D.\u000A(\u001F, this.\u001F.R);
				Func<ElevationMarker, ElementId> func3;
				if ((func3 = QuickViewsViewModel.<>c.\u000B\u000A) == null)
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
					func3 = (QuickViewsViewModel.<>c.\u000B\u000A = new Func<ElevationMarker, ElementId>(QuickViewsViewModel.<>c.\u001F.\u0017\u0007));
				}
				List<ElementId> u000A3 = Enumerable.ToList<ElementId>(Enumerable.Select<ElevationMarker, ElementId>(enumerable3, func3));
				\u000F\u0013\u000A.\u000A(this.\u000A, u000A2);
				\u000F\u0013\u000A.\u000A(this.\u000A, u000A3);
				\u000F\u0013\u000A.\u000A(this.\u000A, u000A);
			}

			// Token: 0x06004BE3 RID: 19427 RVA: 0x001DB248 File Offset: 0x001D9448
			internal bool \u0004(UIView \u001F)
			{
				return \u0014\u000E\u0007.\u000A(this.\u000A, \u0008\u000E\u0007.\u000A(\u001F));
			}

			// Token: 0x06004BE4 RID: 19428 RVA: 0x001DB26C File Offset: 0x001D946C
			internal void \u0019(UIView \u001F)
			{
				\u0008\u0001\u000D.\u000A(this.\u0007, \u001F);
			}

			// Token: 0x04001F1A RID: 7962
			public QuickViewsViewModel \u001F;

			// Token: 0x04001F1B RID: 7963
			public List<ElementId> \u000A;

			// Token: 0x04001F1C RID: 7964
			public IList<UIView> \u0007;
		}

		// Token: 0x020007A6 RID: 1958
		[CompilerGenerated]
		private sealed class \u0005\u001D
		{
			// Token: 0x06004BE6 RID: 19430 RVA: 0x001DB29C File Offset: 0x001D949C
			internal void \u000A(ModelSpace \u001F)
			{
				\u001B\u0001\u000D.\u000A(this.\u001F, \u001F);
			}

			// Token: 0x06004BE7 RID: 19431 RVA: 0x001DB2B8 File Offset: 0x001D94B8
			internal void \u0007(ModelRoom \u001F)
			{
				\u001B\u0001\u000D.\u000A(this.\u001F, \u001F);
			}

			// Token: 0x04001F1D RID: 7965
			public List<ModelSpatialElement> \u001F;
		}

		// Token: 0x020007A7 RID: 1959
		[CompilerGenerated]
		private sealed class \u0016\u001D
		{
			// Token: 0x06004BE9 RID: 19433 RVA: 0x001DB2E8 File Offset: 0x001D94E8
			internal bool \u000A(ViewInformation \u001F)
			{
				return \u0016\u0001\u000D.\u000A(\u001F) == \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u000A\u000D\u0007.\u0007(this.\u001F)));
			}

			// Token: 0x06004BEA RID: 19434 RVA: 0x001DB31C File Offset: 0x001D951C
			internal bool \u0007(ViewInformation \u001F)
			{
				return \u000C\u0019\u001D.\u000A(\u001F) == \u000C\u0019\u001D.\u000A(\u0016\u000D\u0007.\u000A(this.\u001F));
			}

			// Token: 0x04001F1E RID: 7966
			public ModelSpatialElement \u001F;
		}

		// Token: 0x020007A8 RID: 1960
		[CompilerGenerated]
		private sealed class \u000B\u001D
		{
			// Token: 0x06004BEC RID: 19436 RVA: 0x001DB35C File Offset: 0x001D955C
			internal bool \u000A(IModelElement \u001F)
			{
				return \u001A\u0008\u0019.\u000A(\u0011\u0001\u000D.\u000A(this.\u001F), \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u0010\u0001\u000D.\u000A(\u001F))));
			}

			// Token: 0x04001F1F RID: 7967
			public TemplateInfo \u001F;
		}
	}
}
