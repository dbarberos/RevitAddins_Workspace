using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.SheetGen.TemplateTransfer
{
	// Token: 0x020002DE RID: 734
	public class TemplateTransferViewModel : ViewModelBase
	{
		// Token: 0x17000859 RID: 2137
		// (get) Token: 0x06001E50 RID: 7760 RVA: 0x000BF354 File Offset: 0x000BD554
		// (set) Token: 0x06001E51 RID: 7761 RVA: 0x000BF368 File Offset: 0x000BD568
		public ICollectionView OriginViewTemplates
		{
			get
			{
				return this.YJ;
			}
			set
			{
				this.YJ = value;
				\u000D\u0020\u000A.\u000A(this, "OriginViewTemplates");
			}
		}

		// Token: 0x1700085A RID: 2138
		// (get) Token: 0x06001E52 RID: 7762 RVA: 0x000BF388 File Offset: 0x000BD588
		// (set) Token: 0x06001E53 RID: 7763 RVA: 0x000BF39C File Offset: 0x000BD59C
		public ICollectionView DestinationViewTemplates
		{
			get
			{
				return this.CJ;
			}
			set
			{
				this.CJ = value;
				\u000D\u0020\u000A.\u000A(this, "DestinationViewTemplates");
			}
		}

		// Token: 0x1700085B RID: 2139
		// (get) Token: 0x06001E54 RID: 7764 RVA: 0x000BF3BC File Offset: 0x000BD5BC
		// (set) Token: 0x06001E55 RID: 7765 RVA: 0x000BF3D0 File Offset: 0x000BD5D0
		public ICollectionView ViewTemplateParameter
		{
			get
			{
				return this.LJ;
			}
			set
			{
				this.LJ = value;
				\u000D\u0020\u000A.\u000A(this, "ViewTemplateParameter");
			}
		}

		// Token: 0x1700085C RID: 2140
		// (get) Token: 0x06001E56 RID: 7766 RVA: 0x000BF3F0 File Offset: 0x000BD5F0
		// (set) Token: 0x06001E57 RID: 7767 RVA: 0x000BF404 File Offset: 0x000BD604
		public ViewManagerView OriginSelectedViewTemplates
		{
			get
			{
				return this.SJ;
			}
			set
			{
				this.SJ = value;
				\u000D\u0020\u000A.\u000A(this, "OriginSelectedViewTemplates");
				\u000C\u001A\u0016.\u000A(this);
			}
		}

		// Token: 0x1700085D RID: 2141
		// (get) Token: 0x06001E58 RID: 7768 RVA: 0x000BF42C File Offset: 0x000BD62C
		// (set) Token: 0x06001E59 RID: 7769 RVA: 0x000BF440 File Offset: 0x000BD640
		public IList<ViewManagerView> SelectedDestinationViewTemplates
		{
			get
			{
				return this.BJ;
			}
			set
			{
				this.BJ = value;
				\u000D\u0020\u000A.\u000A(this, "SelectedDestinationViewTemplates");
			}
		}

		// Token: 0x1700085E RID: 2142
		// (get) Token: 0x06001E5A RID: 7770 RVA: 0x000BF460 File Offset: 0x000BD660
		// (set) Token: 0x06001E5B RID: 7771 RVA: 0x000BF474 File Offset: 0x000BD674
		public IList<ParameterInfo> SelectedParameterInfo
		{
			get
			{
				return this.UJ;
			}
			set
			{
				this.UJ = value;
				\u000D\u0020\u000A.\u000A(this, "SelectedParameterInfo");
			}
		}

		// Token: 0x1700085F RID: 2143
		// (get) Token: 0x06001E5C RID: 7772 RVA: 0x000BF494 File Offset: 0x000BD694
		// (set) Token: 0x06001E5D RID: 7773 RVA: 0x000BF4A8 File Offset: 0x000BD6A8
		public ViewTemplateFilter OriginDisciplineFilter { get; set; }

		// Token: 0x17000860 RID: 2144
		// (get) Token: 0x06001E5E RID: 7774 RVA: 0x000BF4BC File Offset: 0x000BD6BC
		// (set) Token: 0x06001E5F RID: 7775 RVA: 0x000BF4D0 File Offset: 0x000BD6D0
		public ViewTemplateFilter OriginTypeFilter { get; set; }

		// Token: 0x17000861 RID: 2145
		// (get) Token: 0x06001E60 RID: 7776 RVA: 0x000BF4E4 File Offset: 0x000BD6E4
		// (set) Token: 0x06001E61 RID: 7777 RVA: 0x000BF4F8 File Offset: 0x000BD6F8
		public ViewTemplateFilter DestinationDisciplineFilter { get; set; }

		// Token: 0x17000862 RID: 2146
		// (get) Token: 0x06001E62 RID: 7778 RVA: 0x000BF50C File Offset: 0x000BD70C
		// (set) Token: 0x06001E63 RID: 7779 RVA: 0x000BF520 File Offset: 0x000BD720
		public ViewTemplateFilter DestinationTypeFilter { get; set; }

		// Token: 0x17000863 RID: 2147
		// (get) Token: 0x06001E64 RID: 7780 RVA: 0x000BF534 File Offset: 0x000BD734
		// (set) Token: 0x06001E65 RID: 7781 RVA: 0x000BF548 File Offset: 0x000BD748
		public bool DestinationUnChecked
		{
			get
			{
				return this.WJ;
			}
			set
			{
				this.WJ = value;
				\u000D\u0020\u000A.\u000A(this, "DestinationUnChecked");
			}
		}

		// Token: 0x17000864 RID: 2148
		// (get) Token: 0x06001E66 RID: 7782 RVA: 0x000BF568 File Offset: 0x000BD768
		// (set) Token: 0x06001E67 RID: 7783 RVA: 0x000BF57C File Offset: 0x000BD77C
		public bool DestinationCheckAll
		{
			get
			{
				return this.KJ;
			}
			set
			{
				this.KJ = value;
				\u000D\u0020\u000A.\u000A(this, "DestinationCheckAll");
			}
		}

		// Token: 0x17000865 RID: 2149
		// (get) Token: 0x06001E68 RID: 7784 RVA: 0x000BF59C File Offset: 0x000BD79C
		// (set) Token: 0x06001E69 RID: 7785 RVA: 0x000BF5B0 File Offset: 0x000BD7B0
		public bool ParameterCheckAll
		{
			get
			{
				return this.JJ;
			}
			set
			{
				this.JJ = value;
				\u000D\u0020\u000A.\u000A(this, "ParameterCheckAll");
			}
		}

		// Token: 0x17000866 RID: 2150
		// (get) Token: 0x06001E6A RID: 7786 RVA: 0x000BF5D0 File Offset: 0x000BD7D0
		// (set) Token: 0x06001E6B RID: 7787 RVA: 0x000BF5E4 File Offset: 0x000BD7E4
		public bool ParameterUnChecked
		{
			get
			{
				return this.EJ;
			}
			set
			{
				this.EJ = value;
				\u000D\u0020\u000A.\u000A(this, "ParameterUnChecked");
			}
		}

		// Token: 0x17000867 RID: 2151
		// (get) Token: 0x06001E6C RID: 7788 RVA: 0x000BF604 File Offset: 0x000BD804
		// (set) Token: 0x06001E6D RID: 7789 RVA: 0x000BF618 File Offset: 0x000BD818
		public string ParameterSearchText
		{
			get
			{
				return this.NJ;
			}
			set
			{
				this.NJ = value;
				\u000D\u0020\u000A.\u000A(this, "ParameterSearchText");
			}
		}

		// Token: 0x17000868 RID: 2152
		// (get) Token: 0x06001E6E RID: 7790 RVA: 0x000BF638 File Offset: 0x000BD838
		// (set) Token: 0x06001E6F RID: 7791 RVA: 0x000BF64C File Offset: 0x000BD84C
		public ProgressModel ProgressBar { get; set; }

		// Token: 0x17000869 RID: 2153
		// (get) Token: 0x06001E70 RID: 7792 RVA: 0x000BF660 File Offset: 0x000BD860
		// (set) Token: 0x06001E71 RID: 7793 RVA: 0x000BF674 File Offset: 0x000BD874
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

		// Token: 0x1700086A RID: 2154
		// (get) Token: 0x06001E72 RID: 7794 RVA: 0x000BF694 File Offset: 0x000BD894
		// (set) Token: 0x06001E73 RID: 7795 RVA: 0x000BF6A8 File Offset: 0x000BD8A8
		public bool IsEditViewTemplateEnable
		{
			get
			{
				return this.MJ;
			}
			set
			{
				this.MJ = value;
				\u000D\u0020\u000A.\u000A(this, "IsEditViewTemplateEnable");
			}
		}

		// Token: 0x1700086B RID: 2155
		// (get) Token: 0x06001E74 RID: 7796 RVA: 0x000BF6C8 File Offset: 0x000BD8C8
		// (set) Token: 0x06001E75 RID: 7797 RVA: 0x000BF6DC File Offset: 0x000BD8DC
		public List<ViewManagerView> ViewTemplates { get; set; }

		// Token: 0x06001E76 RID: 7798 RVA: 0x000BF6F0 File Offset: 0x000BD8F0
		public void Load()
		{
			\u001B\u000C\u0016.\u000A(this, \u0008\u000C\u0016.\u000A(\u0011\u000C\u0016.\u0007(\u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u0007(\u0018\u000B\u0007.\u0007(this))))));
			List<ViewManagerView> u001F = \u0008\u000C\u0016.\u000A(\u0019\u000C\u0016.\u000A(this));
			List<ParameterInfo> u001F2 = \u000E\u000C\u0016.\u000A();
			if (Enumerable.Any<ViewManagerView>(\u0019\u000C\u0016.\u000A(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransferViewModel.Load()).MethodHandle;
				}
				u001F2 = \u0008\u0011.\u001F(\u0019\u000C\u0016.\u000A(this));
			}
			\u0010\u000C\u0016.\u000A(this, \u000B\u000C\u0016.\u000A());
			\u0002\u000C\u0016.\u000A(\u000D\u000C\u0016.\u000A(this), \u000D\u000C\u0016.\u000A(this), \u0019\u000C\u0016.\u000A(this), \u0006\u000C\u0016.\u000A());
			\u001C\u000C\u0016.\u000A(this, \u000B\u000C\u0016.\u000A());
			\u0018\u000C\u0016.\u000A(\u0003\u000C\u0016.\u000A(this), \u0003\u000C\u0016.\u000A(this), \u0019\u000C\u0016.\u000A(this), \u0011\u001F\u0016.\u000A());
			\u0012\u000C\u0016.\u000A(this, \u000B\u000C\u0016.\u000A());
			\u0002\u000C\u0016.\u000A(\u000F\u000C\u0016.\u000A(this), \u000F\u000C\u0016.\u000A(this), \u0019\u000C\u0016.\u000A(this), \u0006\u000C\u0016.\u000A());
			\u0016\u000C\u0016.\u000A(this, \u000B\u000C\u0016.\u000A());
			\u0018\u000C\u0016.\u000A(\u0005\u000C\u0016.\u000A(this), \u0005\u000C\u0016.\u000A(this), \u0019\u000C\u0016.\u000A(this), \u0011\u001F\u0016.\u000A());
			\u0004\u000C\u0016.\u000A(this, \u0011\u0009\u000A.\u000A(\u0019\u000C\u0016.\u000A(this)));
			\u001D\u000C\u0016.\u000A(this, \u0011\u0009\u000A.\u000A(u001F));
			\u0007\u000C\u0016.\u000A(this, \u0011\u0009\u000A.\u000A(u001F2));
			\u0017\u001A\u0019.\u000A(\u0014\u001A\u0019.\u000A(\u0009\u001A\u0016.\u000A(this)), new SortDescription("Name", ListSortDirection.Ascending));
			\u0005\u0008\u0007.\u000A(\u000A\u000C\u0016.\u000A(this), new Predicate<object>(this.OriginFilter));
			\u0005\u0008\u0007.\u000A(\u001F\u000C\u0016.\u000A(this), new Predicate<object>(this.DestinationFilter));
			\u0005\u0008\u0007.\u000A(\u0009\u001A\u0016.\u000A(this), new Predicate<object>(this.ParameterFilter));
			\u000C\u001A\u0016.\u000A(this);
			ProgressModel progressModel = \u0001\u001A\u0016.\u000A();
			\u000A\u0013\u0019.\u000A(progressModel, \u0018\u000B\u0007.\u0007(this));
			\u0015\u001A\u0016.\u000A(this, progressModel);
		}

		// Token: 0x06001E77 RID: 7799 RVA: 0x000BF8F4 File Offset: 0x000BDAF4
		public void UpdateStatus()
		{
			int num;
			if (\u0014\u000C\u0016.\u000A(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransferViewModel.UpdateStatus()).MethodHandle;
				}
				num = 0;
			}
			else
			{
				num = \u0017\u000C\u0016.\u000A(\u0014\u000C\u0016.\u000A(this));
			}
			int num2 = num;
			\u001E\u000C\u0016.\u000A(this, \u0018\u000E\u0007.\u000A(\u0020\u000C\u0016.\u000A(), \u0004\u000B\u0016.\u000A(\u0019\u000C\u0016.\u000A(this)), num2));
		}

		// Token: 0x06001E78 RID: 7800 RVA: 0x000BF960 File Offset: 0x000BDB60
		public bool OriginFilter(object o)
		{
			ViewManagerView viewManagerView = \u001A\u001C\u000E.\u001F(o);
			if (viewManagerView == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransferViewModel.OriginFilter(object)).MethodHandle;
				}
				return false;
			}
			return this.VPR(viewManagerView, \u000D\u000C\u0016.\u000A(this), \u0003\u000C\u0016.\u000A(this));
		}

		// Token: 0x06001E79 RID: 7801 RVA: 0x000BF9A8 File Offset: 0x000BDBA8
		public bool DestinationFilter(object o)
		{
			ViewManagerView viewManagerView = \u001A\u001C\u000E.\u001F(o);
			if (viewManagerView == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransferViewModel.DestinationFilter(object)).MethodHandle;
				}
				return false;
			}
			bool flag = this.VPR(viewManagerView, \u000F\u000C\u0016.\u000A(this), \u0005\u000C\u0016.\u000A(this));
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
				if (\u001A\u000C\u0016.\u000A(this))
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
					flag = \u0013\u000C\u0016.\u000A(viewManagerView);
				}
			}
			return flag;
		}

		// Token: 0x06001E7A RID: 7802 RVA: 0x000BFA1C File Offset: 0x000BDC1C
		public bool ParameterFilter(object o)
		{
			ParameterInfo parameterInfo = \u0008\u000D\u000E.\u001F(o);
			if (parameterInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransferViewModel.ParameterFilter(object)).MethodHandle;
				}
				return false;
			}
			bool flag = true;
			if (!\u0010\u0010\u001D.\u000A(\u0001\u000C\u0016.\u000A(this)))
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
				flag = \u000D\u0008\u000A.\u001F(\u0009\u000C\u0016.\u000A(parameterInfo), \u0001\u000C\u0016.\u000A(this));
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
				if (\u0015\u000C\u0016.\u000A(this))
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
					flag = \u000C\u000C\u0016.\u000A(parameterInfo);
				}
			}
			return flag;
		}

		// Token: 0x06001E7B RID: 7803 RVA: 0x000BFAAC File Offset: 0x000BDCAC
		private bool VPR(ViewManagerView F, ViewTemplateFilter R, ViewTemplateFilter D)
		{
			bool flag = this.ZPR(R, \u001F\u0015\u0016.\u000A(F));
			bool flag2 = this.ZPR(D, \u0014\u0016\u0016.\u0007(F));
			bool flag3 = this.XPR(R, \u0007\u000B\u0016.\u000A(F));
			return flag && flag2 && flag3;
		}

		// Token: 0x06001E7C RID: 7804 RVA: 0x000BFAF4 File Offset: 0x000BDCF4
		private bool ZPR(ViewTemplateFilter F, int R)
		{
			TemplateTransferViewModel.\u0003\u0011 u0003_u = new TemplateTransferViewModel.\u0003\u0011();
			u0003_u.\u001F = R;
			if (\u000A\u0015\u0016.\u000A(F) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransferViewModel.ZPR(ViewTemplateFilter, int)).MethodHandle;
				}
				IEnumerable<KeyValuePair<string, object>> enumerable = \u000A\u0015\u0016.\u000A(F);
				Func<KeyValuePair<string, object>, bool> func;
				if ((func = TemplateTransferViewModel.<>c.\u000A) == null)
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
					func = (TemplateTransferViewModel.<>c.\u000A = new Func<KeyValuePair<string, object>, bool>(TemplateTransferViewModel.<>c.\u001F.\u0016));
				}
				if (!Enumerable.Any<KeyValuePair<string, object>>(enumerable, func))
				{
					return Enumerable.Any<KeyValuePair<string, object>>(\u000A\u0015\u0016.\u000A(F), new Func<KeyValuePair<string, object>, bool>(u0003_u.\u000A));
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
			return true;
		}

		// Token: 0x06001E7D RID: 7805 RVA: 0x000BFB8C File Offset: 0x000BDD8C
		private bool XPR(ViewTemplateFilter F, string R)
		{
			if (!\u0010\u0010\u001D.\u000A(\u0007\u0015\u0016.\u000A(F)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransferViewModel.XPR(ViewTemplateFilter, string)).MethodHandle;
				}
				return \u000D\u0008\u000A.\u001F(R, \u0007\u0015\u0016.\u000A(F));
			}
			return true;
		}

		// Token: 0x06001E7E RID: 7806 RVA: 0x000BFBD0 File Offset: 0x000BDDD0
		[BindableMethod("MultiSelectTemplateSelected")]
		public void MultiSelectTemplateSelected(object sender)
		{
			CheckBox checkBox = \u0011\u000A\u000E.\u001F(sender);
			if (checkBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransferViewModel.MultiSelectTemplateSelected(object)).MethodHandle;
				}
				ViewManagerView viewManagerView = \u001A\u001C\u000E.\u001F(\u0007\u000C\u000A.\u0007(checkBox));
				if (viewManagerView != null)
				{
					if (\u0005\u0015\u0016.\u000A(this) != null)
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
						IEnumerable<ViewManagerView> enumerable = \u0005\u0015\u0016.\u000A(this);
						Func<ViewManagerView, long> func;
						if ((func = TemplateTransferViewModel.<>c.\u0007) == null)
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
							func = (TemplateTransferViewModel.<>c.\u0007 = new Func<ViewManagerView, long>(TemplateTransferViewModel.<>c.\u001F.\u000B));
						}
						if (Enumerable.Contains<long>(Enumerable.Select<ViewManagerView, long>(enumerable, func), \u0017\u0016\u0016.\u000A(viewManagerView)))
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
							IEnumerator<ViewManagerView> enumerator = \u0018\u0015\u0016.\u000A(\u0005\u0015\u0016.\u000A(this));
							try
							{
								while (\u000A\u0017\u000A.\u000A(enumerator))
								{
									\u0019\u0015\u0016.\u000A(\u001B\u0013\u0016.\u000A(enumerator), \u0013\u000C\u0016.\u000A(viewManagerView));
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
					}
					object u001F = \u000D\u000D\u000E.\u001F(\u0005\u000E\u0007.\u000A(\u001F\u000C\u0016.\u000A(this)));
					Predicate<ViewManagerView> u000A;
					if ((u000A = TemplateTransferViewModel.<>c.\u001D) == null)
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
						u000A = (TemplateTransferViewModel.<>c.\u001D = new Predicate<ViewManagerView>(TemplateTransferViewModel.<>c.\u001F.\u0002));
					}
					\u001D\u0015\u0016.\u000A(this, \u0004\u0015\u0016.\u000A(u001F, u000A));
					return;
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
		}

		// Token: 0x06001E7F RID: 7807 RVA: 0x000BFD34 File Offset: 0x000BDF34
		[BindableMethod("MultiSelectParameterSelected")]
		public void MultiSelectParameterSelected(object sender)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransferViewModel.MultiSelectParameterSelected(object)).MethodHandle;
				}
				ParameterInfo parameterInfo = \u0008\u000D\u000E.\u001F(\u0007\u000C\u000A.\u0007(checkBox));
				if (parameterInfo != null)
				{
					if (\u0012\u0015\u0016.\u000A(this) != null)
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
						IEnumerable<ParameterInfo> enumerable = \u0012\u0015\u0016.\u000A(this);
						Func<ParameterInfo, ElementId> func;
						if ((func = TemplateTransferViewModel.<>c.\u0004) == null)
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
							func = (TemplateTransferViewModel.<>c.\u0004 = new Func<ParameterInfo, ElementId>(TemplateTransferViewModel.<>c.\u001F.\u0006));
						}
						if (Enumerable.Contains<ElementId>(Enumerable.Select<ParameterInfo, ElementId>(enumerable, func), \u0003\u0015\u0016.\u000A(parameterInfo)))
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
							IEnumerator<ParameterInfo> enumerator = \u000F\u0015\u0016.\u000A(\u0012\u0015\u0016.\u000A(this));
							try
							{
								while (\u000A\u0017\u000A.\u000A(enumerator))
								{
									\u0002\u0015\u0016.\u000A(\u0006\u0015\u0016.\u000A(enumerator), \u000C\u000C\u0016.\u000A(parameterInfo));
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
					}
					object u001F = \u001C\u000D\u000E.\u001F(\u0005\u000E\u0007.\u000A(\u0009\u001A\u0016.\u000A(this)));
					Predicate<ParameterInfo> u000A;
					if ((u000A = TemplateTransferViewModel.<>c.\u0019) == null)
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
						u000A = (TemplateTransferViewModel.<>c.\u0019 = new Predicate<ParameterInfo>(TemplateTransferViewModel.<>c.\u001F.\u000F));
					}
					\u0016\u0015\u0016.\u000A(this, \u000B\u0015\u0016.\u000A(u001F, u000A));
					return;
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
		}

		// Token: 0x06001E80 RID: 7808 RVA: 0x000BFE98 File Offset: 0x000BE098
		[BindableMethod("SelectAll")]
		public void SelectAll(ListCollectionView collectionView)
		{
			IList<ParameterInfo> list = \u0010\u000D\u000E.\u001F(\u0005\u001C\u0007.\u000A(collectionView));
			if (list != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransferViewModel.SelectAll(ListCollectionView)).MethodHandle;
				}
				IEnumerator<ParameterInfo> enumerator = \u000F\u0015\u0016.\u000A(list);
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						\u0002\u0015\u0016.\u000A(\u0006\u0015\u0016.\u000A(enumerator), \u000D\u0015\u0016.\u000A(this));
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
			IList<ViewManagerView> list2 = \u000E\u000D\u000E.\u001F(\u0005\u001C\u0007.\u000A(collectionView));
			if (list2 != null)
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
				IEnumerator<ViewManagerView> enumerator2 = \u0018\u0015\u0016.\u000A(list2);
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator2))
					{
						\u0019\u0015\u0016.\u000A(\u001B\u0013\u0016.\u000A(enumerator2), \u001C\u0015\u0016.\u000A(this));
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
					if (enumerator2 != null)
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
						\u001F\u0017\u000A.\u000A(enumerator2);
					}
				}
			}
		}

		// Token: 0x06001E81 RID: 7809 RVA: 0x000BFF98 File Offset: 0x000BE198
		[BindableMethod("RefreshOrigin")]
		public void RefreshOrigin()
		{
			\u0014\u0003\u0007.\u000A(\u000A\u000C\u0016.\u000A(this));
		}

		// Token: 0x06001E82 RID: 7810 RVA: 0x000BFFB4 File Offset: 0x000BE1B4
		[BindableMethod("RefreshDestination")]
		public void RefreshDestination()
		{
			\u0014\u0003\u0007.\u000A(\u001F\u000C\u0016.\u000A(this));
		}

		// Token: 0x06001E83 RID: 7811 RVA: 0x000BFFD0 File Offset: 0x000BE1D0
		[BindableMethod("RefreshParameter")]
		public void RefreshParameter()
		{
			\u0014\u0003\u0007.\u000A(\u0009\u001A\u0016.\u000A(this));
		}

		// Token: 0x06001E84 RID: 7812 RVA: 0x000BFFEC File Offset: 0x000BE1EC
		[BindableMethod("EditViewTemplate")]
		public void EditViewTemplateOpen()
		{
			\u0010\u0015\u0016.\u000A(this, !\u000E\u0015\u0016.\u000A(33683, new Action(this.PPR)));
		}

		// Token: 0x06001E85 RID: 7813 RVA: 0x000C001C File Offset: 0x000BE21C
		private void PPR()
		{
			\u0010\u0015\u0016.\u000A(this, true);
		}

		// Token: 0x06001E86 RID: 7814 RVA: 0x000C0030 File Offset: 0x000BE230
		[BindableMethod("Apply")]
		public void SetTemplateTransfer()
		{
			IEnumerable<ParameterInfo> enumerable = \u001C\u000D\u000E.\u001F(\u0005\u000E\u0007.\u000A(\u0009\u001A\u0016.\u000A(this)));
			Func<ParameterInfo, bool> func;
			if ((func = TemplateTransferViewModel.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransferViewModel.SetTemplateTransfer()).MethodHandle;
				}
				func = (TemplateTransferViewModel.<>c.\u0018 = new Func<ParameterInfo, bool>(TemplateTransferViewModel.<>c.\u001F.\u0012));
			}
			List<ParameterInfo> list = Enumerable.ToList<ParameterInfo>(Enumerable.Where<ParameterInfo>(enumerable, func));
			IEnumerable<ViewManagerView> enumerable2 = \u000D\u000D\u000E.\u001F(\u0005\u000E\u0007.\u000A(\u001F\u000C\u0016.\u000A(this)));
			Func<ViewManagerView, bool> func2;
			if ((func2 = TemplateTransferViewModel.<>c.\u0005) == null)
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
				func2 = (TemplateTransferViewModel.<>c.\u0005 = new Func<ViewManagerView, bool>(TemplateTransferViewModel.<>c.\u001F.\u0003));
			}
			List<ViewManagerView> list2 = Enumerable.ToList<ViewManagerView>(Enumerable.Where<ViewManagerView>(enumerable2, func2));
			string empty = string.Empty;
			if (this.OPR(list, list2, out empty))
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
				\u000F\u0005\u0019.\u000A(empty, \u0018\u000B\u0007.\u0007(this), MessageBoxButtons.OK);
				return;
			}
			List<ParameterInfo> u001F = \u0008\u0011.\u000A(\u001F\u000B\u0016.\u0007(\u0014\u000C\u0016.\u000A(this)));
			List<ParameterInfo>.Enumerator enumerator = \u000C\u0015\u0016.\u000A(list);
			try
			{
				while (\u001B\u0015\u0016.\u000A(ref enumerator))
				{
					TemplateTransferViewModel.\u001C\u0011 u001C_u = new TemplateTransferViewModel.\u001C\u0011();
					u001C_u.\u001F = \u001A\u0015\u0016.\u000A(ref enumerator);
					if (\u0013\u0015\u0016.\u000A(u001F, new Predicate<ParameterInfo>(u001C_u.\u000A)))
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
						\u001E\u0015\u0016.\u000A(u001C_u.\u001F, true);
						\u0020\u0015\u0016.\u000A(u001C_u.\u001F, \u0017\u0015\u0016.\u000A(\u0014\u0015\u0016.\u000A(u001F, new Predicate<ParameterInfo>(u001C_u.\u0007))));
					}
					else
					{
						\u001E\u0015\u0016.\u000A(u001C_u.\u001F, false);
						\u0013\u001A\u0016.\u001D(u001C_u.\u001F, \u0017\u0006\u0007.\u000A(\u0011\u0015\u0016.\u000A(), \u0009\u000C\u0016.\u000A(u001C_u.\u001F)));
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
			\u001E\u0011 u000A = new \u001E\u0011(\u0008\u0015\u0016.\u000A(this), \u0014\u000C\u0016.\u000A(this), list2, list);
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000A);
			\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
		}

		// Token: 0x06001E87 RID: 7815 RVA: 0x000C024C File Offset: 0x000BE44C
		private unsafe bool OPR(List<ParameterInfo> F, List<ViewManagerView> R, out string D)
		{
			D = string.Empty;
			bool flag = false;
			if (\u0014\u000C\u0016.\u000A(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransferViewModel.OPR(List<ParameterInfo>, List<ViewManagerView>, string*)).MethodHandle;
				}
				D = \u0018\u000E\u0007.\u000A("{0} {1}", \u0007\u0001\u0016.\u000A(), \u000A\u0001\u0016.\u000A());
				flag = true;
			}
			if (!Enumerable.Any<ParameterInfo>(F))
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
				D = this.TPR(flag, D, \u001F\u0001\u0016.\u000A(), \u0009\u0015\u0016.\u000A());
				flag = true;
			}
			if (!Enumerable.Any<ViewManagerView>(R))
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
				D = this.TPR(flag, D, \u0001\u0015\u0016.\u000A(), \u0015\u0015\u0016.\u000A());
				flag = true;
			}
			return flag;
		}

		// Token: 0x06001E88 RID: 7816 RVA: 0x000C0300 File Offset: 0x000BE500
		private string TPR(bool F, string R, string D, string H)
		{
			if (!F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransferViewModel.TPR(bool, string, string, string)).MethodHandle;
				}
				return \u0018\u000E\u0007.\u000A("{0} {1}", \u0007\u0001\u0016.\u000A(), H);
			}
			return \u001E\u0007\u0007.\u000A("{0} {1} {2}", R, \u001D\u0001\u0016.\u000A(), D);
		}

		// Token: 0x04000C78 RID: 3192
		private ICollectionView YJ;

		// Token: 0x04000C79 RID: 3193
		private ICollectionView CJ;

		// Token: 0x04000C7A RID: 3194
		private ICollectionView LJ;

		// Token: 0x04000C7B RID: 3195
		private ViewManagerView SJ;

		// Token: 0x04000C7C RID: 3196
		private IList<ViewManagerView> BJ;

		// Token: 0x04000C7D RID: 3197
		private IList<ParameterInfo> UJ;

		// Token: 0x04000C7E RID: 3198
		private bool WJ;

		// Token: 0x04000C7F RID: 3199
		private bool KJ;

		// Token: 0x04000C80 RID: 3200
		private bool JJ;

		// Token: 0x04000C81 RID: 3201
		private bool EJ;

		// Token: 0x04000C82 RID: 3202
		private string NJ;

		// Token: 0x04000C83 RID: 3203
		private string GK;

		// Token: 0x04000C84 RID: 3204
		private bool MJ = true;

		// Token: 0x04000C85 RID: 3205
		[CompilerGenerated]
		private ViewTemplateFilter VJ;

		// Token: 0x04000C86 RID: 3206
		[CompilerGenerated]
		private ViewTemplateFilter ZJ;

		// Token: 0x04000C87 RID: 3207
		[CompilerGenerated]
		private ViewTemplateFilter XJ;

		// Token: 0x04000C88 RID: 3208
		[CompilerGenerated]
		private ViewTemplateFilter PJ;

		// Token: 0x04000C89 RID: 3209
		[CompilerGenerated]
		private ProgressModel FJ;

		// Token: 0x04000C8A RID: 3210
		[CompilerGenerated]
		private List<ViewManagerView> I;

		// Token: 0x020009BA RID: 2490
		[CompilerGenerated]
		private sealed class \u0003\u0011
		{
			// Token: 0x060053B2 RID: 21426 RVA: 0x001ED55C File Offset: 0x001EB75C
			internal bool \u000A(KeyValuePair<string, object> \u001F)
			{
				return \u0005\u0005\u000E.\u001F(\u000C\u0014\u0005.\u000A(ref \u001F)) == this.\u001F;
			}

			// Token: 0x04002546 RID: 9542
			public int \u001F;
		}

		// Token: 0x020009BB RID: 2491
		[CompilerGenerated]
		private sealed class \u001C\u0011
		{
			// Token: 0x060053B4 RID: 21428 RVA: 0x001ED598 File Offset: 0x001EB798
			internal bool \u000A(ParameterInfo \u001F)
			{
				return \u0011\u0016\u001D.\u000A(\u0003\u0015\u0016.\u000A(\u001F), \u0003\u0015\u0016.\u000A(this.\u001F));
			}

			// Token: 0x060053B5 RID: 21429 RVA: 0x001ED5C4 File Offset: 0x001EB7C4
			internal bool \u0007(ParameterInfo \u001F)
			{
				return \u0011\u0016\u001D.\u000A(\u0003\u0015\u0016.\u000A(\u001F), \u0003\u0015\u0016.\u000A(this.\u001F));
			}

			// Token: 0x04002547 RID: 9543
			public ParameterInfo \u001F;
		}
	}
}
