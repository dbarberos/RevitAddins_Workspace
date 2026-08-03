using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.TreeGrid;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.ViewAligner.Data.Models;
using DiRoots.One.ViewAligner.Interfaces;
using DiRoots.Revit.SheetsAndViews.Models;

namespace DiRoots.One.ViewAligner.Wpf.ViewModels
{
	// Token: 0x020000C0 RID: 192
	public class MainViewModel : ViewModelBase
	{
		// Token: 0x06000762 RID: 1890 RVA: 0x0002B084 File Offset: 0x00029284
		public MainViewModel()
		{
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0002B0B4 File Offset: 0x000292B4
		public MainViewModel(IDataService dataService, IViewAlignProvider viewAlignProvider)
		{
			this.UC = dataService;
			this.WC = viewAlignProvider;
			\u0007\u0003\u001D.\u000A(this, new CommandBase(new Action(this.IER), new Predicate<object>(this.TER)));
			\u001F\u0003\u001D.\u000A(this, \u000A\u0003\u001D.\u000A(dataService));
			ViewInfo u000A;
			if ((u000A = Enumerable.FirstOrDefault<ViewInfo>(\u0020\u0012\u001D.\u000A(this), new Func<ViewInfo, bool>(this.YNR))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel..ctor(IDataService, IViewAlignProvider)).MethodHandle;
				}
				u000A = Enumerable.FirstOrDefault<ViewInfo>(\u0020\u0012\u001D.\u000A(this));
			}
			\u0009\u0012\u001D.\u000A(this, u000A);
			ViewInfo viewInfo = \u0001\u0012\u001D.\u000A(this);
			object u001F;
			if (viewInfo == null)
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
				u001F = null;
			}
			else
			{
				u001F = Enumerable.FirstOrDefault<BaseTreeItem>(\u0015\u0012\u001D.\u0007(viewInfo));
			}
			\u000C\u0012\u001D.\u000A(this, \u001B\u001D\u000E.\u001F(u001F));
			ComboBoxViewModel<ViewSetInfo> comboBoxViewModel = new ComboBoxViewModel<ViewSetInfo>();
			\u0013\u0012\u001D.\u000A(comboBoxViewModel, \u001A\u0012\u001D.\u000A(dataService));
			\u0014\u0012\u001D.\u000A(this, comboBoxViewModel);
			\u0017\u0012\u001D.\u000A(this).HC += this.OER;
			this.PER(\u0020\u0012\u001D.\u000A(this));
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000764 RID: 1892 RVA: 0x0002B1E0 File Offset: 0x000293E0
		// (set) Token: 0x06000765 RID: 1893 RVA: 0x0002B1F4 File Offset: 0x000293F4
		public List<ViewInfo> Sheets { get; set; }

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000766 RID: 1894 RVA: 0x0002B208 File Offset: 0x00029408
		// (set) Token: 0x06000767 RID: 1895 RVA: 0x0002B21C File Offset: 0x0002941C
		public ViewInfo SelectedSheet
		{
			get
			{
				return this.JC;
			}
			set
			{
				if (base.SetProperty<ViewInfo>(ref this.JC, value, null, "SelectedSheet"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.set_SelectedSheet(ViewInfo)).MethodHandle;
					}
					\u000C\u0012\u001D.\u000A(this, \u001B\u001D\u000E.\u001F(Enumerable.FirstOrDefault<BaseTreeItem>(\u0015\u0012\u001D.\u0007(value))));
					if (\u0004\u0003\u001D.\u000A(this) != null)
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
						this.AER(\u0019\u0003\u001D.\u0007(value));
						\u001D\u0003\u001D.\u000A(\u0004\u0003\u001D.\u000A(this));
					}
				}
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000768 RID: 1896 RVA: 0x0002B2A0 File Offset: 0x000294A0
		// (set) Token: 0x06000769 RID: 1897 RVA: 0x0002B2B4 File Offset: 0x000294B4
		public ViewInfo SelectedView
		{
			get
			{
				return this.EC;
			}
			set
			{
				if (base.SetProperty<ViewInfo>(ref this.EC, value, null, "SelectedView"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.set_SelectedView(ViewInfo)).MethodHandle;
					}
					this.GER();
					TreeManager treeManager = \u0004\u0003\u001D.\u000A(this);
					if (treeManager == null)
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
					}
					else
					{
						\u001D\u0003\u001D.\u000A(treeManager);
					}
					this.HNR();
				}
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x0600076A RID: 1898 RVA: 0x0002B314 File Offset: 0x00029514
		// (set) Token: 0x0600076B RID: 1899 RVA: 0x0002B328 File Offset: 0x00029528
		public string SectionBoxName
		{
			get
			{
				return this.NC;
			}
			set
			{
				base.SetProperty<string>(ref this.NC, value, null, "SectionBoxName");
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x0600076C RID: 1900 RVA: 0x0002B34C File Offset: 0x0002954C
		// (set) Token: 0x0600076D RID: 1901 RVA: 0x0002B360 File Offset: 0x00029560
		public string SearchText
		{
			get
			{
				return this.MC;
			}
			set
			{
				if (base.SetProperty<string>(ref this.MC, value, null, "SearchText"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.set_SearchText(string)).MethodHandle;
					}
					\u0005\u0003\u001D.\u000A(this.KC, value);
					TreeManager treeManager = \u0004\u0003\u001D.\u000A(this);
					if (treeManager == null)
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
						\u001D\u0003\u001D.\u000A(treeManager);
					}
					if (\u001A\u0006\u0007.\u000A(value))
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
						\u0018\u0003\u001D.\u000A(\u0004\u0003\u001D.\u000A(this), false);
					}
				}
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x0600076E RID: 1902 RVA: 0x0002B3E4 File Offset: 0x000295E4
		// (set) Token: 0x0600076F RID: 1903 RVA: 0x0002B3F8 File Offset: 0x000295F8
		public bool SimilarViewsOnly
		{
			get
			{
				return this.VC;
			}
			set
			{
				if (base.SetProperty<bool>(ref this.VC, value, null, "SimilarViewsOnly"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.set_SimilarViewsOnly(bool)).MethodHandle;
					}
					TreeManager treeManager = \u0004\u0003\u001D.\u000A(this);
					if (treeManager == null)
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
					\u001D\u0003\u001D.\u000A(treeManager);
				}
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x0002B44C File Offset: 0x0002964C
		// (set) Token: 0x06000771 RID: 1905 RVA: 0x0002B460 File Offset: 0x00029660
		public AlignmentMode AlignmentMode
		{
			get
			{
				return this.ZC;
			}
			set
			{
				base.SetProperty<AlignmentMode>(ref this.ZC, value, null, "AlignmentMode");
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x0002B484 File Offset: 0x00029684
		// (set) Token: 0x06000773 RID: 1907 RVA: 0x0002B498 File Offset: 0x00029698
		public bool ApplyScopeBox
		{
			get
			{
				return this.XC;
			}
			set
			{
				base.SetProperty<bool>(ref this.XC, value, null, "ApplyScopeBox");
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000774 RID: 1908 RVA: 0x0002B4BC File Offset: 0x000296BC
		// (set) Token: 0x06000775 RID: 1909 RVA: 0x0002B4D0 File Offset: 0x000296D0
		public bool ApplyScopeBoxEnabled
		{
			get
			{
				return this.PC;
			}
			set
			{
				base.SetProperty<bool>(ref this.PC, value, null, "ApplyScopeBoxEnabled");
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000776 RID: 1910 RVA: 0x0002B4F4 File Offset: 0x000296F4
		// (set) Token: 0x06000777 RID: 1911 RVA: 0x0002B508 File Offset: 0x00029708
		public bool AlignTitles
		{
			get
			{
				return this.OC;
			}
			set
			{
				base.SetProperty<bool>(ref this.OC, value, null, "AlignTitles");
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x0002B52C File Offset: 0x0002972C
		// (set) Token: 0x06000779 RID: 1913 RVA: 0x0002B540 File Offset: 0x00029740
		public bool ApplyControlEnabled
		{
			get
			{
				return this.TC;
			}
			set
			{
				base.SetProperty<bool>(ref this.TC, value, null, "ApplyControlEnabled");
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x0600077A RID: 1914 RVA: 0x0002B564 File Offset: 0x00029764
		// (set) Token: 0x0600077B RID: 1915 RVA: 0x0002B578 File Offset: 0x00029778
		public bool CanAlignByCoords
		{
			get
			{
				return this.IC;
			}
			set
			{
				if (base.SetProperty<bool>(ref this.IC, value, null, "CanAlignByCoords"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.set_CanAlignByCoords(bool)).MethodHandle;
					}
					if (!value)
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
						\u0016\u0003\u001D.\u000A(this, AlignmentMode.Viewport);
					}
				}
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x0600077C RID: 1916 RVA: 0x0002B5C4 File Offset: 0x000297C4
		// (set) Token: 0x0600077D RID: 1917 RVA: 0x0002B5D8 File Offset: 0x000297D8
		public TreeManager SheetTreeManager { get; set; }

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x0600077E RID: 1918 RVA: 0x0002B5EC File Offset: 0x000297EC
		// (set) Token: 0x0600077F RID: 1919 RVA: 0x0002B600 File Offset: 0x00029800
		public ComboBoxViewModel<ViewSetInfo> ViewSetModel { get; set; }

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000780 RID: 1920 RVA: 0x0002B614 File Offset: 0x00029814
		// (set) Token: 0x06000781 RID: 1921 RVA: 0x0002B628 File Offset: 0x00029828
		public CommandBase ApplyCommand { get; set; }

		// Token: 0x06000782 RID: 1922 RVA: 0x0002B63C File Offset: 0x0002983C
		private void PER(List<ViewInfo> F)
		{
			\u0019\u0019 u0019_u = new \u0019\u0019();
			\u001C\u0003\u001D.\u000A(u0019_u, new Predicate<ViewInfo>(this.FNR));
			\u0003\u0003\u001D.\u000A(u0019_u, new Predicate<ViewInfo>(this.DNR));
			\u0012\u0003\u001D.\u000A(u0019_u, new Predicate<ViewInfo>(this.RNR));
			this.KC = u0019_u;
			this.QC = \u000F\u0003\u001D.\u000A(this.UC, F);
			TreeManager treeManager = \u0006\u0003\u001D.\u000A(this.QC, new Predicate<ITreeItem>(this.KC.\u0004));
			\u0002\u0003\u001D.\u000A(treeManager, false);
			\u000B\u0003\u001D.\u000A(this, treeManager);
			\u001D\u0003\u001D.\u000A(\u0004\u0003\u001D.\u000A(this));
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0002B6D8 File Offset: 0x000298D8
		private void OER(object F)
		{
			TreeManager treeManager = \u0004\u0003\u001D.\u000A(this);
			if (treeManager == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.OER(object)).MethodHandle;
				}
				return;
			}
			\u001D\u0003\u001D.\u000A(treeManager);
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x0002B70C File Offset: 0x0002990C
		private bool TER(object F)
		{
			if (\u0008\u0003\u001D.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.TER(object)).MethodHandle;
				}
				if (\u000E\u0003\u001D.\u000A(this))
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
					if (\u0004\u0003\u001D.\u000A(this) != null)
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
						bool? flag = \u0010\u0003\u001D.\u000A(\u0004\u0003\u001D.\u000A(this));
						bool flag2 = false;
						return !(\u0012\u0015\u000A.\u000A(ref flag) == flag2 & \u000D\u0003\u001D.\u000A(ref flag));
					}
				}
			}
			return false;
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x0002B78C File Offset: 0x0002998C
		private void IER()
		{
			\u0007\u001C\u001D.\u000A(this, false);
			AlignSettings alignSettings = \u000A\u001C\u001D.\u000A();
			\u0009\u0003\u001D.\u000A(alignSettings, \u001F\u001C\u001D.\u000A(this));
			\u0015\u0003\u001D.\u000A(alignSettings, \u0001\u0003\u001D.\u000A(this));
			\u001A\u0003\u001D.\u000A(alignSettings, \u000C\u0003\u001D.\u000A(this));
			\u0013\u0003\u001D.\u000A(alignSettings, \u0008\u0003\u001D.\u000A(this));
			IEnumerable<ViewInfo> enumerable = Enumerable.Cast<ViewInfo>(\u0017\u0003\u001D.\u000A(\u0014\u0003\u001D.\u000A(\u0004\u0003\u001D.\u000A(this))));
			Func<ViewInfo, bool> func;
			if ((func = MainViewModel.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.IER()).MethodHandle;
				}
				func = (MainViewModel.<>c.\u000A = new Func<ViewInfo, bool>(MainViewModel.<>c.\u001F.\u001D));
			}
			\u0020\u0003\u001D.\u000A(alignSettings, Enumerable.ToList<ViewInfo>(Enumerable.Where<ViewInfo>(enumerable, func)));
			AlignSettings u000A = alignSettings;
			\u001E\u0003\u001D.\u000A(this.WC, u000A);
			\u0011\u0003\u001D.\u000A(this.WC, new TaskFinishedDelegate(this.QER));
			\u001B\u0003\u001D.\u000A(this.WC, new TaskFinishedDelegate(this.QER));
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0002B880 File Offset: 0x00029A80
		private void QER()
		{
			\u0007\u001C\u001D.\u000A(this, true);
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x0002B894 File Offset: 0x00029A94
		private void AER(long F)
		{
			MainViewModel.\u0007\u0019 u0007_u = new MainViewModel.\u0007\u0019();
			u0007_u.\u001F = F;
			ITreeItem treeItem = Enumerable.FirstOrDefault<ITreeItem>(\u0014\u0003\u001D.\u000A(\u0004\u0003\u001D.\u000A(this)), new Func<ITreeItem, bool>(u0007_u.\u000A));
			if (treeItem != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.AER(long)).MethodHandle;
				}
				bool? flag = \u0004\u001C\u001D.\u000A(treeItem);
				bool flag2 = false;
				if (!(\u0012\u0015\u000A.\u000A(ref flag) == flag2 & \u000D\u0003\u001D.\u000A(ref flag)))
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
					\u001D\u001C\u001D.\u000A(treeItem, new bool?(false));
				}
			}
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x0002B920 File Offset: 0x00029B20
		private void GER()
		{
			ViewInfo viewInfo = \u0008\u0003\u001D.\u000A(this);
			bool u000A;
			if (viewInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.GER()).MethodHandle;
				}
				u000A = false;
			}
			else
			{
				u000A = \u0018\u001C\u001D.\u0007(viewInfo);
			}
			\u0019\u001C\u001D.\u000A(this, u000A);
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x0002B95C File Offset: 0x00029B5C
		private bool FNR(ViewInfo F)
		{
			string u001F = \u0005\u001C\u001D.\u001D(F);
			ViewInfo viewInfo = \u0001\u0012\u001D.\u000A(this);
			string u000A;
			if (viewInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.FNR(ViewInfo)).MethodHandle;
				}
				u000A = \u000F\u0015\u0010.\u001F;
			}
			else
			{
				u000A = \u0005\u001C\u001D.\u0007(viewInfo);
			}
			return \u001D\u0017\u000A.\u000A(u001F, u000A);
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0002B9A8 File Offset: 0x00029BA8
		private bool RNR(ViewInfo F)
		{
			IList<ViewSetInfo> list = \u0012\u001C\u001D.\u000A(\u0017\u0012\u001D.\u000A(this));
			if (\u000F\u001C\u001D.\u000A(list) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.RNR(ViewInfo)).MethodHandle;
				}
				return true;
			}
			if (\u0006\u001C\u001D.\u000A(F))
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
				return false;
			}
			IEnumerable<ViewSetInfo> enumerable = list;
			Func<ViewSetInfo, IEnumerable<long>> func;
			if ((func = MainViewModel.<>c.\u0007) == null)
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
				func = (MainViewModel.<>c.\u0007 = new Func<ViewSetInfo, IEnumerable<long>>(MainViewModel.<>c.\u001F.\u0004));
			}
			HashSet<long> u001F = \u0002\u001C\u001D.\u000A(Enumerable.SelectMany<ViewSetInfo, long>(enumerable, func));
			bool flag = \u0016\u001C\u001D.\u000A(u001F, \u0019\u0003\u001D.\u0007(F));
			if (!flag)
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
				ViewInfo viewInfo = \u001B\u001D\u000E.\u001F(\u000B\u001C\u001D.\u000A(F));
				if (viewInfo != null)
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
					if (\u0019\u0003\u001D.\u0007(viewInfo) > 0L)
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
						flag = \u0016\u001C\u001D.\u000A(u001F, \u0019\u0003\u001D.\u0007(viewInfo));
					}
				}
			}
			return flag;
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0002BA98 File Offset: 0x00029C98
		private bool DNR(ViewInfo F)
		{
			if (\u001C\u001C\u001D.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.DNR(ViewInfo)).MethodHandle;
				}
				if (\u0008\u0003\u001D.\u000A(this) == null)
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
					if (\u0006\u001C\u001D.\u000A(F))
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
						return false;
					}
					return \u0003\u001C\u001D.\u000A(this.UC, \u0008\u0003\u001D.\u000A(this), F);
				}
			}
			return true;
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0002BB04 File Offset: 0x00029D04
		private void HNR()
		{
			\u0010\u001C\u001D.\u000A(this, true);
			if (\u0008\u0003\u001D.\u000A(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.HNR()).MethodHandle;
				}
				return;
			}
			\u000E\u001C\u001D.\u000A(this, \u0011\u001C\u001D.\u000A(this.UC, \u0019\u0003\u001D.\u0007(\u0008\u0003\u001D.\u000A(this))));
			if (\u001A\u0006\u0007.\u000A(\u001B\u001C\u001D.\u000A(this)))
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
				\u000E\u001C\u001D.\u000A(this, \u0008\u001C\u001D.\u000A());
				\u0010\u001C\u001D.\u000A(this, false);
				\u000D\u001C\u001D.\u000A(this, false);
			}
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x0002BB90 File Offset: 0x00029D90
		[CompilerGenerated]
		private bool YNR(ViewInfo F)
		{
			return \u0019\u0003\u001D.\u0007(F) == \u001E\u001C\u001D.\u000A(this.UC);
		}

		// Token: 0x040002F5 RID: 757
		private readonly IDataService UC;

		// Token: 0x040002F6 RID: 758
		private readonly IViewAlignProvider WC;

		// Token: 0x040002F7 RID: 759
		private \u0004\u0019 KC;

		// Token: 0x040002F8 RID: 760
		private ViewInfo JC;

		// Token: 0x040002F9 RID: 761
		private ViewInfo EC;

		// Token: 0x040002FA RID: 762
		private string NC;

		// Token: 0x040002FB RID: 763
		private string MC;

		// Token: 0x040002FC RID: 764
		private bool VC = true;

		// Token: 0x040002FD RID: 765
		private AlignmentMode ZC = AlignmentMode.Viewport;

		// Token: 0x040002FE RID: 766
		private bool XC;

		// Token: 0x040002FF RID: 767
		private bool PC = true;

		// Token: 0x04000300 RID: 768
		private bool OC;

		// Token: 0x04000301 RID: 769
		private bool TC = true;

		// Token: 0x04000302 RID: 770
		private bool IC;

		// Token: 0x04000303 RID: 771
		private List<ViewInfo> QC;

		// Token: 0x04000304 RID: 772
		[CompilerGenerated]
		private List<ViewInfo> AC;

		// Token: 0x04000305 RID: 773
		[CompilerGenerated]
		private TreeManager GC;

		// Token: 0x04000306 RID: 774
		[CompilerGenerated]
		private ComboBoxViewModel<ViewSetInfo> FL;

		// Token: 0x04000307 RID: 775
		[CompilerGenerated]
		private CommandBase RL;

		// Token: 0x020007D8 RID: 2008
		[CompilerGenerated]
		private sealed class \u0007\u0019
		{
			// Token: 0x06004CD1 RID: 19665 RVA: 0x001DCF4C File Offset: 0x001DB14C
			internal bool \u000A(ITreeItem \u001F)
			{
				ViewInfo viewInfo = \u001B\u001D\u000E.\u001F(\u001F);
				if (viewInfo != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainViewModel.\u0007\u0019.\u000A(ITreeItem)).MethodHandle;
					}
					return \u0019\u0003\u001D.\u0007(viewInfo) == this.\u001F;
				}
				return false;
			}

			// Token: 0x04001FC7 RID: 8135
			public long \u001F;
		}
	}
}
