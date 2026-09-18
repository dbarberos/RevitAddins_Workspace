using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.OneFilter.CommonLibrary.Messaging;
using SelectionsManager.ViewModels.Interfaces;

namespace SelectionsManager.ViewModels
{
	// Token: 0x02000020 RID: 32
	public class RuleBasedFiltersViewModel : ViewModelBase
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00005730 File Offset: 0x00003930
		public CommandBase TopButtonCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.RKR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x00005758 File Offset: 0x00003958
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x0000576C File Offset: 0x0000396C
		public ObservableCollection<ISelectionItem> Items
		{
			get
			{
				return this.F;
			}
			set
			{
				this.F = value;
				\u000D\u0020\u000A.\u000A(this, "Items");
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x0000578C File Offset: 0x0000398C
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x000057A0 File Offset: 0x000039A0
		public bool IsButtonVisible
		{
			get
			{
				return this.H;
			}
			set
			{
				this.H = value;
				\u000D\u0020\u000A.\u000A(this, "IsButtonVisible");
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000057C0 File Offset: 0x000039C0
		internal void AWR(UIDocument F)
		{
			this.R = \u0011\u0020\u000A.\u0007(F);
			this.D = F;
			IEnumerable<RuleBasedFiltersItemViewModel> enumerable = Enumerable.Select<ParameterFilterElement, RuleBasedFiltersItemViewModel>(Enumerable.Cast<ParameterFilterElement>(\u0018\u000A.\u001F<ParameterFilterElement>(this.R)), new Func<ParameterFilterElement, RuleBasedFiltersItemViewModel>(this.YKR));
			Func<RuleBasedFiltersItemViewModel, string> func;
			if ((func = RuleBasedFiltersViewModel.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RuleBasedFiltersViewModel.AWR(UIDocument)).MethodHandle;
				}
				func = (RuleBasedFiltersViewModel.<>c.\u000A = new Func<RuleBasedFiltersItemViewModel, string>(RuleBasedFiltersViewModel.<>c.\u001F.\u0007));
			}
			ObservableCollection<ISelectionItem> observableCollection = \u001B\u0020\u000A.\u000A(Enumerable.OrderBy<RuleBasedFiltersItemViewModel, string>(enumerable, func));
			\u000E\u0020\u000A.\u000A(observableCollection, \u0008\u0020\u000A.\u000A());
			\u0010\u0020\u000A.\u000A(this, observableCollection);
			RuleBasedFiltersItemViewModel.WZ();
			RuleBasedFiltersItemViewModel.R += this.DeleteSelection;
			this.GWR();
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00005878 File Offset: 0x00003A78
		internal void GWR()
		{
			\u0005\u001B\u000A.\u0018.\u001D<ParameterFilterElement>(this, new Action<ParameterFilterElement>(this.FKR), Context.NewRuleFilterCreated);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000058A8 File Offset: 0x00003AA8
		private void FKR(ParameterFilterElement F)
		{
			if (F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RuleBasedFiltersViewModel.FKR(ParameterFilterElement)).MethodHandle;
				}
				\u0017\u0020\u000A.\u000A(\u001E\u0020\u000A.\u000A(this), \u0014\u0020\u000A.\u000A(\u001E\u0020\u000A.\u000A(this)) - 1);
				\u000E\u0020\u000A.\u000A(\u001E\u0020\u000A.\u000A(this), \u0020\u0020\u000A.\u000A(this.D, F));
				\u000E\u0020\u000A.\u000A(\u001E\u0020\u000A.\u000A(this), \u0008\u0020\u000A.\u000A());
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00005918 File Offset: 0x00003B18
		private void RKR()
		{
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00005928 File Offset: 0x00003B28
		public void DeleteSelection(ISelectionItem item)
		{
			if (item != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RuleBasedFiltersViewModel.DeleteSelection(ISelectionItem)).MethodHandle;
				}
				if (\u001E\u0020\u000A.\u000A(this) != null)
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
					\u0013\u0020\u000A.\u000A(\u001E\u0020\u000A.\u000A(this), item);
				}
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00005970 File Offset: 0x00003B70
		internal void DKR(object F, EventArgs R)
		{
			RuleBasedFiltersViewModel.\u0015 u = new RuleBasedFiltersViewModel.\u0015();
			u.\u001F = this;
			u.\u000A = Enumerable.Cast<ParameterFilterElement>(\u0018\u000A.\u001F<ParameterFilterElement>(this.R));
			if (Enumerable.Count<ParameterFilterElement>(u.\u000A) != Enumerable.Count<ISelectionItem>(\u001E\u0020\u000A.\u000A(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RuleBasedFiltersViewModel.DKR(object, EventArgs)).MethodHandle;
				}
				\u0010\u0020\u000A.\u000A(this, \u001B\u0020\u000A.\u000A(Enumerable.Select<ParameterFilterElement, RuleBasedFiltersItemViewModel>(u.\u000A, new Func<ParameterFilterElement, RuleBasedFiltersItemViewModel>(u.\u0007))));
				return;
			}
			if (Enumerable.All<ISelectionItem>(\u001E\u0020\u000A.\u000A(this), new Func<ISelectionItem, bool>(u.\u001D)))
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
				return;
			}
			\u0010\u0020\u000A.\u000A(this, \u001B\u0020\u000A.\u000A(Enumerable.Select<ParameterFilterElement, RuleBasedFiltersItemViewModel>(u.\u000A, new Func<ParameterFilterElement, RuleBasedFiltersItemViewModel>(u.\u0004))));
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00005A4C File Offset: 0x00003C4C
		internal void HKR()
		{
			if (\u001E\u0020\u000A.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RuleBasedFiltersViewModel.HKR()).MethodHandle;
				}
				IEnumerator<ParameterFilterElement> enumerator = \u0005\u0017\u000A.\u000A(Enumerable.Cast<ParameterFilterElement>(\u0018\u000A.\u001F<ParameterFilterElement>(this.R)));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						RuleBasedFiltersViewModel.\u0009 u = new RuleBasedFiltersViewModel.\u0009();
						u.\u001F = \u0018\u0017\u000A.\u000A(enumerator);
						ISelectionItem u001F = \u0006\u0015\u0010.\u001F;
						if (!Enumerable.Any<ISelectionItem>(\u001E\u0020\u000A.\u000A(this), new Func<ISelectionItem, bool>(u.\u000A)))
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
							\u0019\u0017\u000A.\u000A(\u001E\u0020\u000A.\u000A(this), \u0014\u0020\u000A.\u000A(\u001E\u0020\u000A.\u000A(this)) - 1, \u0020\u0020\u000A.\u000A(this.D, u.\u001F));
						}
						else if ((u001F = Enumerable.FirstOrDefault<ISelectionItem>(\u001E\u0020\u000A.\u000A(this), new Func<ISelectionItem, bool>(u.\u0007))) != null)
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
							if (\u001D\u0017\u000A.\u000A(\u0004\u0017\u000A.\u000A(u001F), \u0005\u001E\u000A.\u000A(u.\u001F)))
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
								\u0007\u0017\u000A.\u000A(u001F, \u0005\u001E\u000A.\u000A(u.\u001F));
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
				}
				finally
				{
					if (enumerator != null)
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
				List<ISelectionItem>.Enumerator enumerator2 = \u0009\u0020\u000A.\u000A(Enumerable.ToList<ISelectionItem>(\u001E\u0020\u000A.\u000A(this)));
				try
				{
					while (\u001A\u0020\u000A.\u000A(ref enumerator2))
					{
						ISelectionItem selectionItem = \u0001\u0020\u000A.\u000A(ref enumerator2);
						if (\u0015\u0020\u000A.\u000A(selectionItem) != null)
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
							if (!\u000C\u0020\u000A.\u0007(\u0015\u0020\u000A.\u000A(selectionItem)))
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
								\u0013\u0020\u000A.\u000A(\u001E\u0020\u000A.\u000A(this), selectionItem);
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
					((IDisposable)enumerator2).Dispose();
				}
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00005C48 File Offset: 0x00003E48
		[CompilerGenerated]
		private RuleBasedFiltersItemViewModel YKR(ParameterFilterElement F)
		{
			return \u0020\u0020\u000A.\u000A(this.D, F);
		}

		// Token: 0x0400004A RID: 74
		private ObservableCollection<ISelectionItem> F;

		// Token: 0x0400004B RID: 75
		private Document R;

		// Token: 0x0400004C RID: 76
		private UIDocument D;

		// Token: 0x0400004D RID: 77
		private bool H;

		// Token: 0x02000768 RID: 1896
		[CompilerGenerated]
		private sealed class \u0015
		{
			// Token: 0x06004A91 RID: 19089 RVA: 0x001D7420 File Offset: 0x001D5620
			internal RuleBasedFiltersItemViewModel \u0007(ParameterFilterElement \u001F)
			{
				return \u0020\u0020\u000A.\u000A(this.\u001F.D, \u001F);
			}

			// Token: 0x06004A92 RID: 19090 RVA: 0x001D7440 File Offset: 0x001D5640
			internal bool \u001D(ISelectionItem \u001F)
			{
				RuleBasedFiltersViewModel.\u0001 u = new RuleBasedFiltersViewModel.\u0001();
				u.\u001F = \u001F;
				return Enumerable.Any<ParameterFilterElement>(this.\u000A, new Func<ParameterFilterElement, bool>(u.\u000A));
			}

			// Token: 0x06004A93 RID: 19091 RVA: 0x001D7474 File Offset: 0x001D5674
			internal RuleBasedFiltersItemViewModel \u0004(ParameterFilterElement \u001F)
			{
				return \u0020\u0020\u000A.\u000A(this.\u001F.D, \u001F);
			}

			// Token: 0x04001DCC RID: 7628
			public RuleBasedFiltersViewModel \u001F;

			// Token: 0x04001DCD RID: 7629
			public IEnumerable<ParameterFilterElement> \u000A;
		}

		// Token: 0x02000769 RID: 1897
		[CompilerGenerated]
		private sealed class \u0001
		{
			// Token: 0x06004A95 RID: 19093 RVA: 0x001D74A8 File Offset: 0x001D56A8
			internal bool \u000A(ParameterFilterElement \u001F)
			{
				if (\u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)) == \u0020\u0001\u000A.\u000A(this.\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(RuleBasedFiltersViewModel.\u0001.\u000A(ParameterFilterElement)).MethodHandle;
					}
					return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), \u0004\u0017\u000A.\u000A(this.\u001F));
				}
				return false;
			}

			// Token: 0x04001DCE RID: 7630
			public ISelectionItem \u001F;
		}

		// Token: 0x0200076A RID: 1898
		[CompilerGenerated]
		private sealed class \u0009
		{
			// Token: 0x06004A97 RID: 19095 RVA: 0x001D7518 File Offset: 0x001D5718
			internal bool \u000A(ISelectionItem \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(this.\u001F)) == \u0020\u0001\u000A.\u000A(\u001F);
			}

			// Token: 0x06004A98 RID: 19096 RVA: 0x001D7544 File Offset: 0x001D5744
			internal bool \u0007(ISelectionItem \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(this.\u001F)) == \u0020\u0001\u000A.\u000A(\u001F);
			}

			// Token: 0x04001DCF RID: 7631
			public ParameterFilterElement \u001F;
		}
	}
}
