using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.SheetGen;
using DiRoots.One.SheetGen.Data;
using DiRoots.One.SheetGen.DI.Interfaces;
using DiRoots.One.SheetGen.Models;
using DiRoots.One.UIBehaviours.Extensions;
using DiRoots.One.ViewRange.Model;

namespace DiRoots.One.ViewRange
{
	// Token: 0x02000294 RID: 660
	public class ViewRangeViewModel : ViewModelBase
	{
		// Token: 0x060019C2 RID: 6594 RVA: 0x000A6124 File Offset: 0x000A4324
		public ViewRangeViewModel()
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\ViewRange\\ViewModel\\ViewRangeViewModel.cs", ".ctor");
			this.R = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004);
			this.QK = \u000B\u001F\u0016.\u0007(DocumentAccessProvider.\u0004);
			\u0016\u001F\u0016.\u000A(this, new ProgressModel());
			\u0005\u001F\u0016.\u000A(this, false);
			\u0018\u001F\u0016.\u000A(this, 0);
			this.AK = new UnitConverter();
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\ViewRange\\ViewModel\\ViewRangeViewModel.cs", ".ctor");
		}

		// Token: 0x17000716 RID: 1814
		// (get) Token: 0x060019C3 RID: 6595 RVA: 0x000A61C8 File Offset: 0x000A43C8
		// (set) Token: 0x060019C4 RID: 6596 RVA: 0x000A61DC File Offset: 0x000A43DC
		public List<ViewInformation> ViewInformations
		{
			get
			{
				return this.NK;
			}
			set
			{
				this.NK = value;
				\u000D\u0020\u000A.\u000A(this, "ViewInformations");
			}
		}

		// Token: 0x17000717 RID: 1815
		// (get) Token: 0x060019C5 RID: 6597 RVA: 0x000A61FC File Offset: 0x000A43FC
		// (set) Token: 0x060019C6 RID: 6598 RVA: 0x000A6210 File Offset: 0x000A4410
		public bool IsHideAllView
		{
			get
			{
				return this.IK;
			}
			set
			{
				this.IK = value;
				\u000D\u0020\u000A.\u000A(this, "IsHideAllView");
			}
		}

		// Token: 0x17000718 RID: 1816
		// (get) Token: 0x060019C7 RID: 6599 RVA: 0x000A6230 File Offset: 0x000A4430
		// (set) Token: 0x060019C8 RID: 6600 RVA: 0x000A6244 File Offset: 0x000A4444
		public bool IsBatchRangeEnable
		{
			get
			{
				return this.XK;
			}
			set
			{
				this.XK = value;
				\u000D\u0020\u000A.\u000A(this, "IsBatchRangeEnable");
			}
		}

		// Token: 0x17000719 RID: 1817
		// (get) Token: 0x060019C9 RID: 6601 RVA: 0x000A6264 File Offset: 0x000A4464
		// (set) Token: 0x060019CA RID: 6602 RVA: 0x000A6278 File Offset: 0x000A4478
		public IList<ViewInformation> SelectViewInformation
		{
			get
			{
				return this.MK;
			}
			set
			{
				this.MK = value;
				this.OnPropertyChanged<IList<ViewInformation>>(new Func<IList<ViewInformation>>(this.NPR), "SelectViewInformation");
			}
		}

		// Token: 0x1700071A RID: 1818
		// (get) Token: 0x060019CB RID: 6603 RVA: 0x000A62A4 File Offset: 0x000A44A4
		// (set) Token: 0x060019CC RID: 6604 RVA: 0x000A62B8 File Offset: 0x000A44B8
		public int SelectedCount
		{
			get
			{
				return this.PK;
			}
			set
			{
				this.PK = value;
				this.YPR();
				\u000D\u0020\u000A.\u000A(this, "SelectedCount");
			}
		}

		// Token: 0x1700071B RID: 1819
		// (get) Token: 0x060019CD RID: 6605 RVA: 0x000A62E0 File Offset: 0x000A44E0
		// (set) Token: 0x060019CE RID: 6606 RVA: 0x000A62F4 File Offset: 0x000A44F4
		public ProgressModel ProgressBar { get; set; }

		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x060019CF RID: 6607 RVA: 0x000A6308 File Offset: 0x000A4508
		// (set) Token: 0x060019D0 RID: 6608 RVA: 0x000A631C File Offset: 0x000A451C
		public string FilterViewNameText
		{
			get
			{
				return this.ZK;
			}
			set
			{
				this.ZK = value;
				\u000D\u0020\u000A.\u000A(this, "FilterViewNameText");
			}
		}

		// Token: 0x1700071D RID: 1821
		// (get) Token: 0x060019D1 RID: 6609 RVA: 0x000A633C File Offset: 0x000A453C
		// (set) Token: 0x060019D2 RID: 6610 RVA: 0x000A6350 File Offset: 0x000A4550
		public string Status
		{
			get
			{
				return this.GK;
			}
			set
			{
				this.GK = value;
				\u000D\u0020\u000A.\u000A(this, "Status");
			}
		}

		// Token: 0x1700071E RID: 1822
		// (get) Token: 0x060019D3 RID: 6611 RVA: 0x000A6370 File Offset: 0x000A4570
		// (set) Token: 0x060019D4 RID: 6612 RVA: 0x000A6384 File Offset: 0x000A4584
		public int ViewsCount
		{
			get
			{
				return this.TK;
			}
			set
			{
				this.TK = value;
				\u000D\u0020\u000A.\u000A(this, "ViewsCount");
			}
		}

		// Token: 0x1700071F RID: 1823
		// (get) Token: 0x060019D5 RID: 6613 RVA: 0x000A63A4 File Offset: 0x000A45A4
		// (set) Token: 0x060019D6 RID: 6614 RVA: 0x000A63B8 File Offset: 0x000A45B8
		public ViewFilters ViewFilterType { get; set; }

		// Token: 0x17000720 RID: 1824
		// (get) Token: 0x060019D7 RID: 6615 RVA: 0x000A63CC File Offset: 0x000A45CC
		// (set) Token: 0x060019D8 RID: 6616 RVA: 0x000A63E0 File Offset: 0x000A45E0
		public List<Element> Levels { get; set; } = new List<Element>();

		// Token: 0x17000721 RID: 1825
		// (get) Token: 0x060019D9 RID: 6617 RVA: 0x000A63F4 File Offset: 0x000A45F4
		// (set) Token: 0x060019DA RID: 6618 RVA: 0x000A6408 File Offset: 0x000A4608
		public ICollectionView ViewInformationCollection
		{
			get
			{
				return this.VK;
			}
			set
			{
				this.VK = value;
				\u000D\u0020\u000A.\u000A(this, "ViewInformationCollection");
			}
		}

		// Token: 0x17000722 RID: 1826
		// (get) Token: 0x060019DB RID: 6619 RVA: 0x000A6428 File Offset: 0x000A4628
		// (set) Token: 0x060019DC RID: 6620 RVA: 0x000A643C File Offset: 0x000A463C
		public List<ViewInformation> OriginalViewInformations { get; set; } = new List<ViewInformation>();

		// Token: 0x060019DD RID: 6621 RVA: 0x000A6450 File Offset: 0x000A4650
		private void YPR()
		{
			string u001F = "{0} {1} {2} {3}";
			object[] array = \u0004\u0015\u0010.\u001F(4);
			array[0] = \u0003\u001F\u0016.\u000A();
			int num = 1;
			int num2 = \u0012\u001F\u0016.\u000A(this);
			array[num] = \u000C\u0013\u0007.\u000A(ref num2);
			array[2] = \u000F\u001F\u0016.\u000A();
			int num3 = 3;
			num2 = \u0006\u001F\u0016.\u000A(this);
			array[num3] = \u000C\u0013\u0007.\u000A(ref num2);
			\u0002\u001F\u0016.\u000A(this, \u001C\u0015\u001D.\u000A(u001F, array));
		}

		// Token: 0x060019DE RID: 6622 RVA: 0x000A64B8 File Offset: 0x000A46B8
		private void CPR()
		{
			FilteredElementCollector u001F = \u0020\u0011\u000A.\u000A(this.R);
			IEnumerable<Element> enumerable = \u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u001D(u001F, -2000240L));
			Func<Element, bool> func;
			if ((func = ViewRangeViewModel.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.CPR()).MethodHandle;
				}
				func = (ViewRangeViewModel.<>c.\u000A = new Func<Element, bool>(ViewRangeViewModel.<>c.\u001F.\u0003));
			}
			IEnumerable<Element> enumerable2 = Enumerable.Where<Element>(enumerable, func);
			Func<Element, double> func2;
			if ((func2 = ViewRangeViewModel.<>c.\u0007) == null)
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
				func2 = (ViewRangeViewModel.<>c.\u0007 = new Func<Element, double>(ViewRangeViewModel.<>c.\u001F.\u001C));
			}
			\u001C\u001F\u0016.\u000A(this, Enumerable.ToList<Element>(Enumerable.OrderBy<Element, double>(enumerable2, func2)));
		}

		// Token: 0x060019DF RID: 6623 RVA: 0x000A6560 File Offset: 0x000A4760
		[BindableMethod("Reload")]
		public void Reload()
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\ViewRange\\ViewModel\\ViewRangeViewModel.cs", "Reload");
			this.CPR();
			object u001F = Enumerable.ToList<View>(Enumerable.Where<View>(Enumerable.Cast<View>(\u0017\u0011\u000A.\u001D(\u0020\u0011\u000A.\u000A(this.R), -2000279L)), new Func<View, bool>(this.MPR)));
			\u000C\u001F\u0016.\u000A(this, \u0015\u001F\u0016.\u000A());
			List<View>.Enumerator enumerator = \u0018\u0010\u0007.\u000A(u001F);
			try
			{
				while (\u0007\u0010\u0007.\u000A(ref enumerator))
				{
					View view = \u0019\u0010\u0007.\u000A(ref enumerator);
					PlanViewRange r = \u000A\u0001\u0005.\u000A(\u0016\u001F\u000E.\u001F(view));
					ViewInformation viewInformation = this.LPR(view, r);
					\u001A\u001F\u0016.\u000A(viewInformation, \u001C\u001C\u0007.\u0007(view));
					\u0013\u001F\u0016.\u000A(\u000D\u001F\u0016.\u000A(this), viewInformation);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.Reload()).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u0017\u001F\u0016.\u000A(this, \u0014\u001F\u0016.\u000A());
			IEnumerable<ViewInformation> enumerable = \u000D\u001F\u0016.\u000A(this);
			Func<ViewInformation, SelectionNamedItem> func;
			if ((func = ViewRangeViewModel.<>c.\u001D) == null)
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
				func = (ViewRangeViewModel.<>c.\u001D = new Func<ViewInformation, SelectionNamedItem>(ViewRangeViewModel.<>c.\u001F.\u000D));
			}
			List<SelectionNamedItem> list = Enumerable.ToList<SelectionNamedItem>(Enumerable.Distinct<SelectionNamedItem>(Enumerable.Select<ViewInformation, SelectionNamedItem>(enumerable, func), new \u001B\u001A()));
			object u001F2 = list;
			Comparison<SelectionNamedItem> u000A;
			if ((u000A = ViewRangeViewModel.<>c.\u0004) == null)
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
				u000A = (ViewRangeViewModel.<>c.\u0004 = new Comparison<SelectionNamedItem>(ViewRangeViewModel.<>c.\u001F.\u0010));
			}
			\u0020\u001F\u0016.\u000A(u001F2, u000A);
			\u001B\u001F\u0016.\u000A(\u001E\u001F\u0016.\u000A(this), \u001E\u001F\u0016.\u000A(this), list, \u0011\u001F\u0016.\u000A());
			\u0008\u001F\u0016.\u000A(this, \u0011\u0009\u000A.\u000A(\u000D\u001F\u0016.\u000A(this)));
			\u0005\u0008\u0007.\u000A(\u000E\u001F\u0016.\u000A(this), new Predicate<object>(this.EPR));
			\u0010\u001F\u0016.\u000A(this, \u0018\u0001\u0005.\u000A(\u000D\u001F\u0016.\u000A(this)));
			IEnumerable<ViewInformation> enumerable2 = \u000D\u001F\u0016.\u000A(this);
			Func<ViewInformation, bool> func2;
			if ((func2 = ViewRangeViewModel.<>c.\u0019) == null)
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
				func2 = (ViewRangeViewModel.<>c.\u0019 = new Func<ViewInformation, bool>(ViewRangeViewModel.<>c.\u001F.\u000E));
			}
			\u0018\u001F\u0016.\u000A(this, \u0018\u0001\u0005.\u000A(Enumerable.ToList<ViewInformation>(Enumerable.Where<ViewInformation>(enumerable2, func2))));
			\u0005\u001F\u0016.\u000A(this, false);
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\ViewRange\\ViewModel\\ViewRangeViewModel.cs", "Reload");
		}

		// Token: 0x060019E0 RID: 6624 RVA: 0x000A67B0 File Offset: 0x000A49B0
		[BindableMethod("FilterType")]
		public void FilterType()
		{
			\u000F\u000D\u0007.\u000A(\u001E\u001F\u0016.\u000A(this), \u001E\u001F\u0016.\u000A(this));
			\u0001\u001F\u0016.\u000A(this);
		}

		// Token: 0x060019E1 RID: 6625 RVA: 0x000A67D8 File Offset: 0x000A49D8
		[BindableMethod("ChangeInViewType")]
		public void ChangeInViewType(object sender)
		{
			CheckBox u000A = \u0016\u0009\u0010.\u001F(sender);
			\u0012\u000D\u0007.\u000A(\u001E\u001F\u0016.\u000A(this), u000A, \u001E\u001F\u0016.\u000A(this), \u0011\u001F\u0016.\u000A());
		}

		// Token: 0x060019E2 RID: 6626 RVA: 0x000A680C File Offset: 0x000A4A0C
		private ViewInformation LPR(View F, PlanViewRange R)
		{
			ViewRangeViewModel.\u000D\u000E u000D_u000E = new ViewRangeViewModel.\u000D\u000E();
			u000D_u000E.\u001F = \u0011\u0017\u000A.\u0007(this.R, \u0005\u000A\u0016.\u000A(R, 0));
			double u000A = \u0018\u000A\u0016.\u000A(R, 0);
			ViewInformation viewInformation = \u0019\u000A\u0016.\u000A();
			\u0004\u000A\u0016.\u000A(viewInformation, F);
			List<LevelInfo> list = this.WPR();
			\u001D\u000A\u0016.\u000A(viewInformation, list);
			\u0001\u0009\u0005.\u000A(\u001A\u0015\u0005.\u000A(viewInformation), \u0004\u001F\u0016.\u000A(\u001F\u001F\u0016.\u000A(viewInformation), new Predicate<LevelInfo>(u000D_u000E.\u000A)));
			\u0007\u000A\u0016.\u000A(viewInformation, \u001C\u001C\u0007.\u0007(F) != 2);
			\u0001\u0009\u0005.\u000A(\u0001\u0015\u0005.\u000A(viewInformation), this.UPR(R, \u0001\u0015\u0005.\u000A(viewInformation), \u001F\u001F\u0016.\u000A(viewInformation), \u001F\u0001\u0005.\u0007(\u001A\u0015\u0005.\u000A(viewInformation))));
			this.SPR(list, \u0001\u0015\u0005.\u000A(viewInformation), \u001F\u0001\u0005.\u0007(\u001A\u0015\u0005.\u000A(viewInformation)), true);
			\u0001\u0009\u0005.\u000A(\u0015\u0015\u0005.\u000A(viewInformation), this.UPR(R, \u0015\u0015\u0005.\u000A(viewInformation), \u001F\u001F\u0016.\u000A(viewInformation), \u001F\u0001\u0005.\u0007(\u001A\u0015\u0005.\u000A(viewInformation))));
			this.SPR(list, \u0015\u0015\u0005.\u000A(viewInformation), \u001F\u0001\u0005.\u0007(\u001A\u0015\u0005.\u000A(viewInformation)), false);
			\u0001\u0009\u0005.\u000A(\u000C\u0015\u0005.\u000A(viewInformation), this.UPR(R, \u000C\u0015\u0005.\u000A(viewInformation), \u001F\u001F\u0016.\u000A(viewInformation), \u001F\u0001\u0005.\u0007(\u001A\u0015\u0005.\u000A(viewInformation))));
			object u001F = \u000C\u0015\u0005.\u000A(viewInformation);
			List<LevelInfo> u000A2;
			if (!\u0002\u0001\u0005.\u000A(viewInformation))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.LPR(View, PlanViewRange)).MethodHandle;
				}
				u000A2 = \u000A\u000A\u0016.\u000A(\u0001\u0015\u0005.\u000A(viewInformation));
			}
			else
			{
				u000A2 = \u000A\u000A\u0016.\u000A(\u0015\u0015\u0005.\u000A(viewInformation));
			}
			\u001F\u000A\u0016.\u000A(u001F, u000A2);
			\u0011\u0009\u0005.\u000A(\u001A\u0015\u0005.\u000A(viewInformation), \u0009\u001F\u0016.\u000A(this.AK, u000A));
			\u001E\u0015\u0005.\u000A(viewInformation, UpdatedIconChange.Updated);
			return viewInformation;
		}

		// Token: 0x060019E3 RID: 6627 RVA: 0x000A69EC File Offset: 0x000A4BEC
		private void SPR(List<LevelInfo> F, ElevationInfo R, LevelInfo D, bool H)
		{
			ViewRangeViewModel.\u0010\u000E u0010_u000E = new ViewRangeViewModel.\u0010\u000E();
			u0010_u000E.\u001F = D;
			Predicate<LevelInfo> u000A;
			if ((u000A = ViewRangeViewModel.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.SPR(List<LevelInfo>, ElevationInfo, LevelInfo, bool)).MethodHandle;
				}
				u000A = (ViewRangeViewModel.<>c.\u0018 = new Predicate<LevelInfo>(ViewRangeViewModel.<>c.\u001F.\u0008));
			}
			LevelInfo levelInfo = \u0004\u001F\u0016.\u000A(F, u000A);
			\u0012\u000A\u0016.\u000A(F, levelInfo);
			int num = \u000F\u000A\u0016.\u000A(F, new Predicate<LevelInfo>(u0010_u000E.\u000A));
			List<LevelInfo> list = \u0002\u000A\u0016.\u000A();
			if (H)
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
				list = \u0006\u000A\u0016.\u000A(F, num, \u0007\u001F\u0016.\u000A(F) - num);
			}
			else
			{
				list = \u0006\u000A\u0016.\u000A(F, 0, num + 1);
			}
			\u001F\u000A\u0016.\u000A(R, \u0002\u000A\u0016.\u000A());
			\u000B\u000A\u0016.\u000A(\u000A\u000A\u0016.\u000A(R), list);
			\u0016\u000A\u0016.\u000A(\u000A\u000A\u0016.\u000A(R), \u0007\u001F\u0016.\u000A(list), levelInfo);
			\u0016\u000A\u0016.\u000A(F, \u0007\u001F\u0016.\u000A(F), levelInfo);
		}

		// Token: 0x060019E4 RID: 6628 RVA: 0x000A6ADC File Offset: 0x000A4CDC
		private void BPR(List<LevelInfo> F, ElevationInfo R)
		{
			ViewRangeViewModel.\u000E\u000E u000E_u000E = new ViewRangeViewModel.\u000E\u000E();
			u000E_u000E.\u001F = R;
			Predicate<LevelInfo> u000A;
			if ((u000A = ViewRangeViewModel.<>c.\u0005) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.BPR(List<LevelInfo>, ElevationInfo)).MethodHandle;
				}
				u000A = (ViewRangeViewModel.<>c.\u0005 = new Predicate<LevelInfo>(ViewRangeViewModel.<>c.\u001F.\u001B));
			}
			LevelInfo levelInfo = \u0004\u001F\u0016.\u000A(F, u000A);
			\u0012\u000A\u0016.\u000A(F, levelInfo);
			int num = \u000F\u000A\u0016.\u000A(F, new Predicate<LevelInfo>(u000E_u000E.\u000A));
			if (num == 0)
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
				object u001F = u000E_u000E.\u001F;
				List<LevelInfo> list = \u0002\u000A\u0016.\u000A();
				\u0003\u000A\u0016.\u000A(list, \u001F\u0001\u0005.\u0007(u000E_u000E.\u001F));
				\u0003\u000A\u0016.\u000A(list, levelInfo);
				\u001F\u000A\u0016.\u000A(u001F, list);
				return;
			}
			List<LevelInfo> list2 = \u0006\u000A\u0016.\u000A(F, 0, num + 1);
			\u001F\u000A\u0016.\u000A(u000E_u000E.\u001F, \u0002\u000A\u0016.\u000A());
			\u000B\u000A\u0016.\u000A(\u000A\u000A\u0016.\u000A(u000E_u000E.\u001F), list2);
			\u0016\u000A\u0016.\u000A(\u000A\u000A\u0016.\u000A(u000E_u000E.\u001F), \u0007\u001F\u0016.\u000A(list2), levelInfo);
		}

		// Token: 0x060019E5 RID: 6629 RVA: 0x000A6BD8 File Offset: 0x000A4DD8
		private LevelInfo UPR(PlanViewRange F, ElevationInfo R, List<LevelInfo> D, LevelInfo H)
		{
			ViewRangeViewModel.\u0008\u000E u0008_u000E = new ViewRangeViewModel.\u0008\u000E();
			double u000A = \u0018\u000A\u0016.\u000A(F, \u001C\u000A\u0016.\u000A(R));
			\u0011\u0009\u0005.\u000A(R, \u0009\u001F\u0016.\u000A(this.AK, u000A));
			u0008_u000E.\u001F = \u0005\u000A\u0016.\u000A(F, \u001C\u000A\u0016.\u000A(R));
			if (\u0011\u0017\u000A.\u0007(this.R, u0008_u000E.\u001F) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.UPR(PlanViewRange, ElevationInfo, List<LevelInfo>, LevelInfo)).MethodHandle;
				}
				LevelInfo result;
				if ((result = \u0004\u001F\u0016.\u000A(D, new Predicate<LevelInfo>(u0008_u000E.\u000A))) == null)
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
					result = H;
				}
				return result;
			}
			if (\u000B\u001E\u000A.\u000A(u0008_u000E.\u001F) == -1L)
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
				Predicate<LevelInfo> u000A2;
				if ((u000A2 = ViewRangeViewModel.<>c.\u0016) == null)
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
					u000A2 = (ViewRangeViewModel.<>c.\u0016 = new Predicate<LevelInfo>(ViewRangeViewModel.<>c.\u001F.\u0011));
				}
				LevelInfo result2;
				if ((result2 = \u0004\u001F\u0016.\u000A(D, u000A2)) == null)
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
					result2 = H;
				}
				return result2;
			}
			return H;
		}

		// Token: 0x060019E6 RID: 6630 RVA: 0x000A6CD4 File Offset: 0x000A4ED4
		private List<LevelInfo> WPR()
		{
			ViewRangeViewModel.\u001B\u000E u001B_u000E = new ViewRangeViewModel.\u001B\u000E();
			u001B_u000E.\u000A = this;
			u001B_u000E.\u001F = \u0002\u000A\u0016.\u000A();
			\u001B\u000A\u0016.\u000A(\u0011\u000A\u0016.\u000A(this), new Action<Element>(u001B_u000E.\u0007));
			ViewRangeViewModel.\u001B\u000E u001B_u000E2 = u001B_u000E;
			IEnumerable<LevelInfo> u001F = u001B_u000E.\u001F;
			Func<LevelInfo, double> func;
			if ((func = ViewRangeViewModel.<>c.\u000B) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.WPR()).MethodHandle;
				}
				func = (ViewRangeViewModel.<>c.\u000B = new Func<LevelInfo, double>(ViewRangeViewModel.<>c.\u001F.\u001E));
			}
			u001B_u000E2.\u001F = Enumerable.ToList<LevelInfo>(Enumerable.OrderBy<LevelInfo, double>(u001F, func));
			object u001F2 = u001B_u000E.\u001F;
			int u000A = \u0007\u001F\u0016.\u000A(u001B_u000E.\u001F);
			LevelInfo levelInfo = \u0008\u000A\u0016.\u000A();
			\u000E\u000A\u0016.\u000A(levelInfo, \u0012\u0009\u0005.\u000A());
			\u0010\u000A\u0016.\u000A(levelInfo, double.MaxValue);
			\u000D\u000A\u0016.\u000A(levelInfo, -1L);
			\u0016\u000A\u0016.\u000A(u001F2, u000A, levelInfo);
			return u001B_u000E.\u001F;
		}

		// Token: 0x060019E7 RID: 6631 RVA: 0x000A6DAC File Offset: 0x000A4FAC
		private LevelInfo KPR(Element F)
		{
			LevelInfo levelInfo = \u0008\u000A\u0016.\u000A();
			Level level = \u001A\u0009\u0010.\u001F(F);
			if (level == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.KPR(Element)).MethodHandle;
				}
				\u000E\u000A\u0016.\u000A(levelInfo, "");
			}
			else
			{
				\u000E\u000A\u0016.\u000A(levelInfo, \u0005\u001E\u000A.\u000A(level));
				\u0010\u000A\u0016.\u000A(levelInfo, \u000E\u0007\u001D.\u000A(level));
				\u000D\u000A\u0016.\u000A(levelInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(level)));
			}
			return levelInfo;
		}

		// Token: 0x060019E8 RID: 6632 RVA: 0x000A6E20 File Offset: 0x000A5020
		private bool JPR(View F)
		{
			if (!\u000C\u0009\u001D.\u000A(F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.JPR(View)).MethodHandle;
				}
				if (\u001C\u001C\u0007.\u0007(F) != 1)
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
					if (\u001C\u001C\u0007.\u0007(F) != 2)
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
						return \u001C\u001C\u0007.\u0007(F) == 115;
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x060019E9 RID: 6633 RVA: 0x000A6E84 File Offset: 0x000A5084
		private bool EPR(object F)
		{
			ViewRangeViewModel.\u0011\u000E u0011_u000E = new ViewRangeViewModel.\u0011\u000E();
			u0011_u000E.\u001F = \u0013\u0012\u000E.\u001F(F);
			if (u0011_u000E.\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.EPR(object)).MethodHandle;
				}
				return false;
			}
			bool flag = \u0004\u000D\u0007.\u000A(\u0019\u000D\u0007.\u000A(\u001E\u001F\u0016.\u000A(this)), new Predicate<SelectionNamedItem>(u0011_u000E.\u000A));
			if (!\u001A\u0006\u0007.\u000A(\u0017\u000A\u0016.\u000A(this)) && flag)
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
				flag = \u000D\u0008\u000A.\u001F(\u000C\u0001\u0005.\u000A(u0011_u000E.\u001F), \u0017\u000A\u0016.\u000A(this));
			}
			if (flag)
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
				if (\u0020\u000A\u0016.\u000A(this))
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
					flag = \u001E\u000A\u0016.\u000A(u0011_u000E.\u001F);
				}
			}
			return flag;
		}

		// Token: 0x060019EA RID: 6634 RVA: 0x000A6F54 File Offset: 0x000A5154
		[BindableMethod("RefreshViews")]
		public void RefreshViews()
		{
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u000D\u001F\u0016.\u000A(this)));
		}

		// Token: 0x060019EB RID: 6635 RVA: 0x000A6F78 File Offset: 0x000A5178
		[BindableMethod("Apply")]
		public void SetViewRange()
		{
			if (\u001E\u000E\u0007.\u000A(\u001A\u000A\u0016.\u000A(), \u0018\u000B\u0007.\u0007(this), 350.0, MessageBoxButtons.YesNo))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.SetViewRange()).MethodHandle;
				}
				\u001C\u000E u001C_u000E = new \u001C\u000E(\u0018\u000B\u0007.\u0007(this), \u0013\u000A\u0016.\u000A(this));
				\u0014\u000A\u0016.\u000A(u001C_u000E, \u000D\u001F\u0016.\u000A(this));
				\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u001C_u000E);
				\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
			}
		}

		// Token: 0x060019EC RID: 6636 RVA: 0x000A6FFC File Offset: 0x000A51FC
		[BindableMethod("AllSelectedIsChecked")]
		public void AllSelectedIsChecked(object sender)
		{
			ViewRangeViewModel.\u001E\u000E u001E_u000E = new ViewRangeViewModel.\u001E\u000E();
			CheckBox checkBox = \u0011\u000A\u000E.\u001F(sender);
			if (checkBox == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.AllSelectedIsChecked(object)).MethodHandle;
				}
				return;
			}
			ViewRangeViewModel.\u001E\u000E u001E_u000E2 = u001E_u000E;
			bool? flag = \u0003\u0015\u000A.\u000A(checkBox);
			u001E_u000E2.\u001F = \u0012\u0015\u000A.\u000A(ref flag);
			\u000C\u000A\u0016.\u000A(Enumerable.ToList<ViewInformation>(Enumerable.Cast<ViewInformation>(\u000E\u001F\u0016.\u000A(this))), new Action<ViewInformation>(u001E_u000E.\u000A));
			\u0005\u001F\u0016.\u000A(this, u001E_u000E.\u001F);
			IEnumerable<ViewInformation> enumerable = \u000D\u001F\u0016.\u000A(this);
			Func<ViewInformation, bool> func;
			if ((func = ViewRangeViewModel.<>c.\u0002) == null)
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
				func = (ViewRangeViewModel.<>c.\u0002 = new Func<ViewInformation, bool>(ViewRangeViewModel.<>c.\u001F.\u0020));
			}
			\u0018\u001F\u0016.\u000A(this, Enumerable.Count<ViewInformation>(enumerable, func));
		}

		// Token: 0x060019ED RID: 6637 RVA: 0x000A70B8 File Offset: 0x000A52B8
		[BindableMethod("CollectionSelected")]
		public void CollectionSelected(object sender)
		{
			CheckBox checkBox = \u0011\u000A\u000E.\u001F(sender);
			if (checkBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.CollectionSelected(object)).MethodHandle;
				}
				ViewInformation viewInformation = \u0013\u0012\u000E.\u001F(\u0007\u000C\u000A.\u0007(checkBox));
				if (viewInformation != null)
				{
					IEnumerator<ViewInformation> enumerator = \u0004\u0001\u0005.\u000A(\u0001\u000A\u0016.\u000A(this));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							\u0015\u000A\u0016.\u000A(\u001D\u0001\u0005.\u000A(enumerator), \u001E\u000A\u0016.\u000A(viewInformation));
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
					if (\u001E\u000A\u0016.\u000A(viewInformation))
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
						\u0005\u001F\u0016.\u000A(this, true);
					}
					IEnumerable<ViewInformation> enumerable = \u000D\u001F\u0016.\u000A(this);
					Func<ViewInformation, bool> func;
					if ((func = ViewRangeViewModel.<>c.\u0006) == null)
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
						func = (ViewRangeViewModel.<>c.\u0006 = new Func<ViewInformation, bool>(ViewRangeViewModel.<>c.\u001F.\u0017));
					}
					if (!Enumerable.Any<ViewInformation>(enumerable, func))
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
						\u0005\u001F\u0016.\u000A(this, false);
					}
					IEnumerable<ViewInformation> enumerable2 = \u000D\u001F\u0016.\u000A(this);
					Func<ViewInformation, bool> func2;
					if ((func2 = ViewRangeViewModel.<>c.\u000F) == null)
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
						func2 = (ViewRangeViewModel.<>c.\u000F = new Func<ViewInformation, bool>(ViewRangeViewModel.<>c.\u001F.\u0014));
					}
					\u0018\u001F\u0016.\u000A(this, Enumerable.Count<ViewInformation>(enumerable2, func2));
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

		// Token: 0x060019EE RID: 6638 RVA: 0x000A7208 File Offset: 0x000A5408
		[BindableMethod("SelectionChangeInComboBox")]
		public void SelectionChangeInComboBox(object sender)
		{
			ViewRangeViewModel.\u0020\u000E u0020_u000E = new ViewRangeViewModel.\u0020\u000E();
			if (\u0001\u000A\u0016.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.SelectionChangeInComboBox(object)).MethodHandle;
				}
				ComboBox comboBox = \u000F\u001F\u000E.\u001F(sender);
				if (comboBox != null)
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
					object u001F = \u0007\u000C\u000A.\u0007(comboBox);
					u0020_u000E.\u001F = \u0013\u0012\u000E.\u001F(u001F);
					if (u0020_u000E.\u001F != null)
					{
						IEnumerator<ViewInformation> enumerator = \u0004\u0001\u0005.\u000A(\u0001\u000A\u0016.\u000A(this));
						try
						{
							while (\u000A\u0017\u000A.\u000A(enumerator))
							{
								ViewInformation u001F2 = \u001D\u0001\u0005.\u000A(enumerator);
								\u001E\u0015\u0005.\u000A(u001F2, UpdatedIconChange.Modify);
								\u0006\u0001\u0005.\u000A(u001F2, string.Empty);
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
						string u001F3 = \u000E\u000C\u0007.\u0007(\u0008\u000C\u0007.\u000A(\u0020\u000C\u0007.\u0007(\u0017\u000C\u0007.\u001D(comboBox, Selector.SelectedItemProperty))));
						if (\u0009\u000A\u0016.\u000A(\u0001\u000A\u0016.\u000A(this)) > 1)
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
							if (\u0008\u0013\u000A.\u000A(u001F3, "TopElevation.Level"))
							{
								\u000C\u000A\u0016.\u000A(Enumerable.ToList<ViewInformation>(\u0001\u000A\u0016.\u000A(this)), new Action<ViewInformation>(u0020_u000E.\u0004));
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
							if (\u0008\u0013\u000A.\u000A(u001F3, "BottomElevation.Level"))
							{
								\u000C\u000A\u0016.\u000A(Enumerable.ToList<ViewInformation>(\u0001\u000A\u0016.\u000A(this)), new Action<ViewInformation>(u0020_u000E.\u0018));
								return;
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
							if (!\u0008\u0013\u000A.\u000A(u001F3, "ViewDepthPlaneElevation.Level"))
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
							\u000C\u000A\u0016.\u000A(Enumerable.ToList<ViewInformation>(\u0001\u000A\u0016.\u000A(this)), new Action<ViewInformation>(u0020_u000E.\u0016));
						}
						return;
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
			}
		}

		// Token: 0x060019EF RID: 6639 RVA: 0x000A73D4 File Offset: 0x000A55D4
		[BindableMethod("BatchViewRange")]
		public void BatchViewRange()
		{
			IEnumerable<ViewInformation> enumerable = \u000D\u001F\u0016.\u000A(this);
			Func<ViewInformation, bool> func;
			if ((func = ViewRangeViewModel.<>c.\u0012) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.BatchViewRange()).MethodHandle;
				}
				func = (ViewRangeViewModel.<>c.\u0012 = new Func<ViewInformation, bool>(ViewRangeViewModel.<>c.\u001F.\u0013));
			}
			if (Enumerable.Any<ViewInformation>(enumerable, func))
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
				BatchViewRangeUI u001F = \u001F\u0007\u0016.\u000A(\u000D\u001F\u0016.\u000A(this));
				\u000C\u000E\u0007.\u0007(u001F, \u0018\u000B\u0007.\u0007(this));
				bool? flag = \u0018\u0020\u000A.\u0007(u001F);
				if (\u0012\u0015\u000A.\u000A(ref flag))
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
					\u000C\u001F\u0016.\u000A(this, \u0013\u0009\u0005.\u001D(\u001F\u0009\u0005.\u001D(u001F)));
				}
			}
		}

		// Token: 0x060019F0 RID: 6640 RVA: 0x000A7480 File Offset: 0x000A5680
		[BindableMethod("OpenView")]
		public void OpenView()
		{
			if (\u0001\u000A\u0016.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.OpenView()).MethodHandle;
				}
				if (\u0009\u000A\u0016.\u000A(\u0001\u000A\u0016.\u000A(this)) > 10)
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
					IYesNoDialog service = \u000E\u001B\u000A.\u0004.GetService<IYesNoDialog>(false);
					\u0019\u0007\u0016.\u000A(service, \u0018\u000B\u0007.\u0007(this));
					\u001D\u0007\u0016.\u000A(service, \u0004\u0007\u0016.\u000A());
					\u0007\u0007\u0016.\u000A(service, 250.0);
					bool? flag = \u000A\u0007\u0016.\u000A(service);
					bool flag2 = false;
					if (\u0012\u0015\u000A.\u000A(ref flag) == flag2 & \u000D\u0003\u001D.\u000A(ref flag))
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
						return;
					}
				}
				IEnumerator<ViewInformation> enumerator = \u0004\u0001\u0005.\u000A(\u0001\u000A\u0016.\u000A(this));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						ViewInformation u001F = \u001D\u0001\u0005.\u000A(enumerator);
						if (\u0007\u0001\u0005.\u0007(u001F) != null)
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
							\u001D\u0010\u0007.\u0007(this.QK, \u0007\u0001\u0005.\u0007(u001F));
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
			}
		}

		// Token: 0x060019F1 RID: 6641 RVA: 0x000A75AC File Offset: 0x000A57AC
		[BindableMethod("TextChangeInTextBox")]
		public void TextChangeInTextBox(object sender)
		{
			ViewRangeViewModel.\u0017\u000E u0017_u000E = new ViewRangeViewModel.\u0017\u000E();
			if (\u0001\u000A\u0016.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.TextChangeInTextBox(object)).MethodHandle;
				}
				TextBox textBox = \u0008\u000A\u000E.\u001F(sender);
				if (textBox != null)
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
					object u001F = \u0007\u000C\u000A.\u0007(textBox);
					u0017_u000E.\u001F = \u0013\u0012\u000E.\u001F(u001F);
					if (u0017_u000E.\u001F != null)
					{
						string u001F2 = \u000E\u000C\u0007.\u0007(\u0008\u000C\u0007.\u000A(\u0020\u000C\u0007.\u0007(\u0017\u000C\u0007.\u001D(textBox, TextBox.TextProperty))));
						if (\u0009\u000A\u0016.\u000A(\u0001\u000A\u0016.\u000A(this)) > 1)
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
							if (!\u0008\u0013\u000A.\u000A(u001F2, "TopElevation.Offset"))
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
								if (!\u0008\u0013\u000A.\u000A(u001F2, "CutPlaneElevation.Offset"))
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
									if (!\u0008\u0013\u000A.\u000A(u001F2, "BottomElevation.Offset"))
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
										if (!\u0008\u0013\u000A.\u000A(u001F2, "ViewDepthPlaneElevation.Offset"))
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
										}
										else
										{
											\u000C\u000A\u0016.\u000A(Enumerable.ToList<ViewInformation>(\u0001\u000A\u0016.\u000A(this)), new Action<ViewInformation>(u0017_u000E.\u0004));
										}
									}
									else
									{
										\u000C\u000A\u0016.\u000A(Enumerable.ToList<ViewInformation>(\u0001\u000A\u0016.\u000A(this)), new Action<ViewInformation>(u0017_u000E.\u001D));
									}
								}
								else
								{
									\u000C\u000A\u0016.\u000A(Enumerable.ToList<ViewInformation>(\u0001\u000A\u0016.\u000A(this)), new Action<ViewInformation>(u0017_u000E.\u0007));
								}
							}
							else
							{
								\u000C\u000A\u0016.\u000A(Enumerable.ToList<ViewInformation>(\u0001\u000A\u0016.\u000A(this)), new Action<ViewInformation>(u0017_u000E.\u000A));
							}
						}
						IEnumerator<ViewInformation> enumerator = \u0004\u0001\u0005.\u000A(\u0001\u000A\u0016.\u000A(this));
						try
						{
							while (\u000A\u0017\u000A.\u000A(enumerator))
							{
								ViewInformation u001F3 = \u001D\u0001\u0005.\u000A(enumerator);
								\u001E\u0015\u0005.\u000A(u001F3, UpdatedIconChange.Modify);
								\u0006\u0001\u0005.\u000A(u001F3, string.Empty);
								if (!\u0002\u0001\u0005.\u000A(u001F3))
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
									\u0011\u0009\u0005.\u000A(\u0015\u0015\u0005.\u000A(u001F3), \u0013\u0015\u0005.\u0007(\u001A\u0015\u0005.\u000A(u001F3)));
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
						return;
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
			}
		}

		// Token: 0x060019F2 RID: 6642 RVA: 0x000A77F0 File Offset: 0x000A59F0
		[CompilerGenerated]
		private IList<ViewInformation> NPR()
		{
			return \u0001\u000A\u0016.\u000A(this);
		}

		// Token: 0x060019F3 RID: 6643 RVA: 0x000A7808 File Offset: 0x000A5A08
		[CompilerGenerated]
		private bool MPR(View F)
		{
			return this.JPR(F);
		}

		// Token: 0x04000A3B RID: 2619
		private List<ViewInformation> NK;

		// Token: 0x04000A3C RID: 2620
		private IList<ViewInformation> MK;

		// Token: 0x04000A3D RID: 2621
		private ICollectionView VK;

		// Token: 0x04000A3E RID: 2622
		private string ZK;

		// Token: 0x04000A3F RID: 2623
		private bool XK;

		// Token: 0x04000A40 RID: 2624
		private int PK;

		// Token: 0x04000A41 RID: 2625
		private int TK;

		// Token: 0x04000A42 RID: 2626
		private bool IK;

		// Token: 0x04000A43 RID: 2627
		private Document R;

		// Token: 0x04000A44 RID: 2628
		private UIDocument QK;

		// Token: 0x04000A45 RID: 2629
		private UnitConverter AK;

		// Token: 0x04000A46 RID: 2630
		private string GK;

		// Token: 0x04000A47 RID: 2631
		[CompilerGenerated]
		private ProgressModel FJ;

		// Token: 0x04000A48 RID: 2632
		[CompilerGenerated]
		private ViewFilters RJ;

		// Token: 0x04000A49 RID: 2633
		[CompilerGenerated]
		private List<Element> DJ;

		// Token: 0x04000A4A RID: 2634
		[CompilerGenerated]
		private List<ViewInformation> HJ;

		// Token: 0x02000954 RID: 2388
		[CompilerGenerated]
		private sealed class \u000D\u000E
		{
			// Token: 0x06005278 RID: 21112 RVA: 0x001EA704 File Offset: 0x001E8904
			internal bool \u000A(LevelInfo \u001F)
			{
				return \u0009\u0015\u0005.\u000A(\u001F) == \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(this.\u001F));
			}

			// Token: 0x04002466 RID: 9318
			public Element \u001F;
		}

		// Token: 0x02000955 RID: 2389
		[CompilerGenerated]
		private sealed class \u0010\u000E
		{
			// Token: 0x0600527A RID: 21114 RVA: 0x001EA744 File Offset: 0x001E8944
			internal bool \u000A(LevelInfo \u001F)
			{
				return \u0009\u0015\u0005.\u000A(\u001F) == \u0009\u0015\u0005.\u000A(this.\u001F);
			}

			// Token: 0x04002467 RID: 9319
			public LevelInfo \u001F;
		}

		// Token: 0x02000956 RID: 2390
		[CompilerGenerated]
		private sealed class \u000E\u000E
		{
			// Token: 0x0600527C RID: 21116 RVA: 0x001EA77C File Offset: 0x001E897C
			internal bool \u000A(LevelInfo \u001F)
			{
				return \u0009\u0015\u0005.\u000A(\u001F) == \u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(this.\u001F));
			}

			// Token: 0x04002468 RID: 9320
			public ElevationInfo \u001F;
		}

		// Token: 0x02000957 RID: 2391
		[CompilerGenerated]
		private sealed class \u0008\u000E
		{
			// Token: 0x0600527E RID: 21118 RVA: 0x001EA7BC File Offset: 0x001E89BC
			internal bool \u000A(LevelInfo \u001F)
			{
				return \u0009\u0015\u0005.\u000A(\u001F) == \u000B\u001E\u000A.\u000A(this.\u001F);
			}

			// Token: 0x04002469 RID: 9321
			public ElementId \u001F;
		}

		// Token: 0x02000958 RID: 2392
		[CompilerGenerated]
		private sealed class \u001B\u000E
		{
			// Token: 0x06005280 RID: 21120 RVA: 0x001EA7F4 File Offset: 0x001E89F4
			internal void \u0007(Element \u001F)
			{
				\u0003\u000A\u0016.\u000A(this.\u001F, this.\u000A.KPR(\u001F));
			}

			// Token: 0x0400246A RID: 9322
			public List<LevelInfo> \u001F;

			// Token: 0x0400246B RID: 9323
			public ViewRangeViewModel \u000A;
		}

		// Token: 0x02000959 RID: 2393
		[CompilerGenerated]
		private sealed class \u0011\u000E
		{
			// Token: 0x06005282 RID: 21122 RVA: 0x001EA830 File Offset: 0x001E8A30
			internal bool \u000A(SelectionNamedItem \u001F)
			{
				if (\u0015\u001C\u0007.\u0007(\u001F) != 101)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.\u0011\u000E.\u000A(SelectionNamedItem)).MethodHandle;
					}
					return \u0009\u0001\u0005.\u001D(this.\u001F) == \u0015\u001C\u0007.\u0007(\u001F);
				}
				return true;
			}

			// Token: 0x0400246C RID: 9324
			public ViewInformation \u001F;
		}

		// Token: 0x0200095A RID: 2394
		[CompilerGenerated]
		private sealed class \u001E\u000E
		{
			// Token: 0x06005284 RID: 21124 RVA: 0x001EA88C File Offset: 0x001E8A8C
			internal void \u000A(ViewInformation \u001F)
			{
				\u0015\u000A\u0016.\u000A(\u001F, this.\u001F);
			}

			// Token: 0x0400246D RID: 9325
			public bool \u001F;
		}

		// Token: 0x0200095B RID: 2395
		[CompilerGenerated]
		private sealed class \u0020\u000E
		{
			// Token: 0x06005286 RID: 21126 RVA: 0x001EA8BC File Offset: 0x001E8ABC
			internal void \u0004(ViewInformation \u001F)
			{
				object u001F = \u0001\u0015\u0005.\u000A(\u001F);
				object u001F2 = \u001F\u001F\u0016.\u000A(\u001F);
				Predicate<LevelInfo> u000A;
				if ((u000A = this.\u000A) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.\u0020\u000E.\u0004(ViewInformation)).MethodHandle;
					}
					u000A = (this.\u000A = new Predicate<LevelInfo>(this.\u0019));
				}
				\u0001\u0009\u0005.\u000A(u001F, \u0004\u001F\u0016.\u000A(u001F2, u000A));
			}

			// Token: 0x06005287 RID: 21127 RVA: 0x001EA918 File Offset: 0x001E8B18
			internal bool \u0019(LevelInfo \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001D\u001F\u0016.\u000A(\u001F), \u001D\u001F\u0016.\u000A(\u001F\u0001\u0005.\u0007(\u0001\u0015\u0005.\u000A(this.\u001F))));
			}

			// Token: 0x06005288 RID: 21128 RVA: 0x001EA950 File Offset: 0x001E8B50
			internal void \u0018(ViewInformation \u001F)
			{
				object u001F = \u0015\u0015\u0005.\u000A(\u001F);
				object u001F2 = \u001F\u001F\u0016.\u000A(\u001F);
				Predicate<LevelInfo> u000A;
				if ((u000A = this.\u0007) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.\u0020\u000E.\u0018(ViewInformation)).MethodHandle;
					}
					u000A = (this.\u0007 = new Predicate<LevelInfo>(this.\u0005));
				}
				\u0001\u0009\u0005.\u000A(u001F, \u0004\u001F\u0016.\u000A(u001F2, u000A));
			}

			// Token: 0x06005289 RID: 21129 RVA: 0x001EA9AC File Offset: 0x001E8BAC
			internal bool \u0005(LevelInfo \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001D\u001F\u0016.\u000A(\u001F), \u001D\u001F\u0016.\u000A(\u001F\u0001\u0005.\u0007(\u0015\u0015\u0005.\u000A(this.\u001F))));
			}

			// Token: 0x0600528A RID: 21130 RVA: 0x001EA9E4 File Offset: 0x001E8BE4
			internal void \u0016(ViewInformation \u001F)
			{
				object u001F = \u000C\u0015\u0005.\u000A(\u001F);
				object u001F2 = \u001F\u001F\u0016.\u000A(\u001F);
				Predicate<LevelInfo> u000A;
				if ((u000A = this.\u001D) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeViewModel.\u0020\u000E.\u0016(ViewInformation)).MethodHandle;
					}
					u000A = (this.\u001D = new Predicate<LevelInfo>(this.\u000B));
				}
				\u0001\u0009\u0005.\u000A(u001F, \u0004\u001F\u0016.\u000A(u001F2, u000A));
			}

			// Token: 0x0600528B RID: 21131 RVA: 0x001EAA40 File Offset: 0x001E8C40
			internal bool \u000B(LevelInfo \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001D\u001F\u0016.\u000A(\u001F), \u001D\u001F\u0016.\u000A(\u001F\u0001\u0005.\u0007(\u000C\u0015\u0005.\u000A(this.\u001F))));
			}

			// Token: 0x0400246E RID: 9326
			public ViewInformation \u001F;

			// Token: 0x0400246F RID: 9327
			public Predicate<LevelInfo> \u000A;

			// Token: 0x04002470 RID: 9328
			public Predicate<LevelInfo> \u0007;

			// Token: 0x04002471 RID: 9329
			public Predicate<LevelInfo> \u001D;
		}

		// Token: 0x0200095C RID: 2396
		[CompilerGenerated]
		private sealed class \u0017\u000E
		{
			// Token: 0x0600528D RID: 21133 RVA: 0x001EAA8C File Offset: 0x001E8C8C
			internal void \u000A(ViewInformation \u001F)
			{
				\u0011\u0009\u0005.\u000A(\u0001\u0015\u0005.\u000A(\u001F), \u0013\u0015\u0005.\u0007(\u0001\u0015\u0005.\u000A(this.\u001F)));
			}

			// Token: 0x0600528E RID: 21134 RVA: 0x001EAABC File Offset: 0x001E8CBC
			internal void \u0007(ViewInformation \u001F)
			{
				\u0011\u0009\u0005.\u000A(\u001A\u0015\u0005.\u000A(\u001F), \u0013\u0015\u0005.\u0007(\u001A\u0015\u0005.\u000A(this.\u001F)));
			}

			// Token: 0x0600528F RID: 21135 RVA: 0x001EAAEC File Offset: 0x001E8CEC
			internal void \u001D(ViewInformation \u001F)
			{
				\u0011\u0009\u0005.\u000A(\u0015\u0015\u0005.\u000A(\u001F), \u0013\u0015\u0005.\u0007(\u0015\u0015\u0005.\u000A(this.\u001F)));
			}

			// Token: 0x06005290 RID: 21136 RVA: 0x001EAB1C File Offset: 0x001E8D1C
			internal void \u0004(ViewInformation \u001F)
			{
				\u0011\u0009\u0005.\u000A(\u000C\u0015\u0005.\u000A(\u001F), \u0013\u0015\u0005.\u0007(\u000C\u0015\u0005.\u000A(this.\u001F)));
			}

			// Token: 0x04002472 RID: 9330
			public ViewInformation \u001F;
		}
	}
}
