using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Models;
using DiRoots.One.OneFilter.CommonLibrary.Messaging;
using DiRoots.One.OneFilter.SelectionsManager.Enums;
using SelectionsManager.ViewModels.Base;

namespace SelectionsManager.ViewModels
{
	// Token: 0x0200001E RID: 30
	public class RuleBasedFiltersItemViewModel : SelectionItem
	{
		// Token: 0x060000DD RID: 221 RVA: 0x00004CA8 File Offset: 0x00002EA8
		public RuleBasedFiltersItemViewModel()
		{
			\u0007\u001E\u000A.\u000A(this, false);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004CC4 File Offset: 0x00002EC4
		public RuleBasedFiltersItemViewModel(UIDocument uidoc, ParameterFilterElement filter) : base(uidoc)
		{
			this.F = filter;
			\u0006\u001E\u000A.\u000A(this, filter);
			\u0016\u001E\u000A.\u000A(this, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(filter)));
			\u0018\u001E\u000A.\u000A(this, \u0005\u001E\u000A.\u000A(filter));
			\u0007\u001E\u000A.\u000A(this, true);
			\u001D\u001E\u000A.\u000A(this, \u0004\u001E\u000A.\u000A(" ", \u0019\u001E\u000A.\u000A()));
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000DF RID: 223 RVA: 0x00004D2C File Offset: 0x00002F2C
		// (remove) Token: 0x060000E0 RID: 224 RVA: 0x00004D78 File Offset: 0x00002F78
		internal static event DeleteFinishedHandler R
		{
			[CompilerGenerated]
			add
			{
				DeleteFinishedHandler deleteFinishedHandler = RuleBasedFiltersItemViewModel.R;
				DeleteFinishedHandler deleteFinishedHandler2;
				do
				{
					deleteFinishedHandler2 = deleteFinishedHandler;
					DeleteFinishedHandler value2 = \u0016\u0015\u0010.\u001F(\u000F\u001E\u000A.\u000A(deleteFinishedHandler2, value));
					deleteFinishedHandler = Interlocked.CompareExchange<DeleteFinishedHandler>(ref RuleBasedFiltersItemViewModel.R, value2, deleteFinishedHandler2);
				}
				while (deleteFinishedHandler != deleteFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RuleBasedFiltersItemViewModel.add_R(DeleteFinishedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				DeleteFinishedHandler deleteFinishedHandler = RuleBasedFiltersItemViewModel.R;
				DeleteFinishedHandler deleteFinishedHandler2;
				do
				{
					deleteFinishedHandler2 = deleteFinishedHandler;
					DeleteFinishedHandler value2 = \u0016\u0015\u0010.\u001F(\u0012\u001E\u000A.\u000A(deleteFinishedHandler2, value));
					deleteFinishedHandler = Interlocked.CompareExchange<DeleteFinishedHandler>(ref RuleBasedFiltersItemViewModel.R, value2, deleteFinishedHandler2);
				}
				while (deleteFinishedHandler != deleteFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RuleBasedFiltersItemViewModel.remove_R(DeleteFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00004DC4 File Offset: 0x00002FC4
		public CommandBase CollapseSelectionCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.XZ), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00004DEC File Offset: 0x00002FEC
		public CommandBase HideCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.JZ), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00004E14 File Offset: 0x00003014
		public CommandBase IsolateCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.NZ), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00004E3C File Offset: 0x0000303C
		public CommandBase EditCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.ZZ), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00004E64 File Offset: 0x00003064
		public CommandBase DeleteCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.VZ), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x00004E8C File Offset: 0x0000308C
		public CommandBase SelectCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.KZ), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00004EB4 File Offset: 0x000030B4
		internal static void WZ()
		{
			if (RuleBasedFiltersItemViewModel.R != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RuleBasedFiltersItemViewModel.WZ()).MethodHandle;
				}
				Delegate[] array = \u001C\u001E\u000A.\u000A(RuleBasedFiltersItemViewModel.R);
				for (int i = 0; i < (int)\u000B\u0015\u0010.\u001F(array); i++)
				{
					RuleBasedFiltersItemViewModel.R -= \u0016\u0015\u0010.\u001F(array[i]);
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

		// Token: 0x060000E8 RID: 232 RVA: 0x00004F18 File Offset: 0x00003118
		private void KZ()
		{
			this.MZ();
			IEnumerable<SelectedElementsBagViewModel> enumerable = \u000E\u001E\u000A.\u000A(this);
			Func<SelectedElementsBagViewModel, IEnumerable<ElementId>> func;
			if ((func = RuleBasedFiltersItemViewModel.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RuleBasedFiltersItemViewModel.KZ()).MethodHandle;
				}
				func = (RuleBasedFiltersItemViewModel.<>c.\u000A = new Func<SelectedElementsBagViewModel, IEnumerable<ElementId>>(RuleBasedFiltersItemViewModel.<>c.\u001F.\u0006));
			}
			List<ElementId> list = Enumerable.ToList<ElementId>(Enumerable.SelectMany<SelectedElementsBagViewModel, ElementId>(enumerable, func));
			if (list != null)
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
				if (Enumerable.Any<ElementId>(list))
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
					\u000D\u001E\u000A.\u000A(\u0010\u001E\u000A.\u0007(this._uidoc), list);
				}
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00004FA8 File Offset: 0x000031A8
		private void JZ()
		{
			try
			{
				\u0008\u001E\u000A.\u000A(this, !\u001B\u001E\u000A.\u000A(this));
				this.EZ(HideIsolateType.Hide, \u001B\u001E\u000A.\u000A(this));
			}
			catch (Exception)
			{
				\u0008\u001E\u000A.\u000A(this, !\u001B\u001E\u000A.\u000A(this));
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00004FFC File Offset: 0x000031FC
		private void EZ(HideIsolateType F, bool R)
		{
			this.MZ();
			IEnumerable<SelectedElementsBagViewModel> enumerable = \u000E\u001E\u000A.\u000A(this);
			Func<SelectedElementsBagViewModel, IEnumerable<ElementId>> func;
			if ((func = RuleBasedFiltersItemViewModel.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RuleBasedFiltersItemViewModel.EZ(HideIsolateType, bool)).MethodHandle;
				}
				func = (RuleBasedFiltersItemViewModel.<>c.\u0007 = new Func<SelectedElementsBagViewModel, IEnumerable<ElementId>>(RuleBasedFiltersItemViewModel.<>c.\u001F.\u000F));
			}
			List<ElementId> list = Enumerable.ToList<ElementId>(Enumerable.SelectMany<SelectedElementsBagViewModel, ElementId>(enumerable, func));
			if (!Enumerable.Any<ElementId>(list))
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
				return;
			}
			\u0004\u0006\u000A u000A = new \u0004\u0006\u000A(list, R, F);
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000A);
			\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00005094 File Offset: 0x00003294
		private void NZ()
		{
			try
			{
				\u0014\u001E\u000A.\u000A(this, !\u0013\u001E\u000A.\u000A(this));
				this.EZ(HideIsolateType.Isolate, \u0013\u001E\u000A.\u000A(this));
			}
			catch (Exception)
			{
				\u0014\u001E\u000A.\u000A(this, !\u0013\u001E\u000A.\u000A(this));
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000050E8 File Offset: 0x000032E8
		private void MZ()
		{
			IEnumerable<ElementId> enumerable = \u001D\u0020\u000A.\u000A(this.F);
			Func<ElementId, ElementCategoryFilter> func;
			if ((func = RuleBasedFiltersItemViewModel.<>c.\u001D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RuleBasedFiltersItemViewModel.MZ()).MethodHandle;
				}
				func = (RuleBasedFiltersItemViewModel.<>c.\u001D = new Func<ElementId, ElementCategoryFilter>(RuleBasedFiltersItemViewModel.<>c.\u001F.\u0012));
			}
			LogicalOrFilter logicalOrFilter = \u0007\u0020\u000A.\u000A(Enumerable.ToList<ElementFilter>(Enumerable.Cast<ElementFilter>(Enumerable.Select<ElementId, ElementCategoryFilter>(enumerable, func))));
			ElementFilter elementFilter = \u000A\u0020\u000A.\u000A(this.F);
			ElementFilter u000A;
			if (elementFilter == null)
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
				u000A = logicalOrFilter;
			}
			else
			{
				u000A = \u001F\u0020\u000A.\u000A(elementFilter, logicalOrFilter);
			}
			IEnumerable<Element> enumerable2 = \u0001\u001E\u000A.\u0007(\u0014\u0011\u000A.\u0007(\u0009\u001E\u000A.\u0007(\u0020\u0011\u000A.\u000A(this._doc)), u000A));
			Func<Element, Category> func2;
			if ((func2 = RuleBasedFiltersItemViewModel.<>c.\u0004) == null)
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
				func2 = (RuleBasedFiltersItemViewModel.<>c.\u0004 = new Func<Element, Category>(RuleBasedFiltersItemViewModel.<>c.\u001F.\u0003));
			}
			IEnumerable<IGrouping<Category, Element>> enumerable3 = Enumerable.GroupBy<Element, Category>(enumerable2, func2, \u0015\u001E\u000A.\u000A());
			Func<IGrouping<Category, Element>, bool> func3;
			if ((func3 = RuleBasedFiltersItemViewModel.<>c.\u0019) == null)
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
				func3 = (RuleBasedFiltersItemViewModel.<>c.\u0019 = new Func<IGrouping<Category, Element>, bool>(RuleBasedFiltersItemViewModel.<>c.\u001F.\u001C));
			}
			IEnumerable<IGrouping<Category, Element>> enumerable4 = Enumerable.Where<IGrouping<Category, Element>>(enumerable3, func3);
			Func<IGrouping<Category, Element>, Category> func4;
			if ((func4 = RuleBasedFiltersItemViewModel.<>c.\u0018) == null)
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
				func4 = (RuleBasedFiltersItemViewModel.<>c.\u0018 = new Func<IGrouping<Category, Element>, Category>(RuleBasedFiltersItemViewModel.<>c.\u001F.\u000D));
			}
			Func<IGrouping<Category, Element>, List<Element>> func5;
			if ((func5 = RuleBasedFiltersItemViewModel.<>c.\u0005) == null)
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
				func5 = (RuleBasedFiltersItemViewModel.<>c.\u0005 = new Func<IGrouping<Category, Element>, List<Element>>(RuleBasedFiltersItemViewModel.<>c.\u001F.\u0010));
			}
			Dictionary<Category, List<Element>> dictionary = Enumerable.ToDictionary<IGrouping<Category, Element>, Category, List<Element>>(enumerable4, func4, func5);
			IEnumerable<KeyValuePair<Category, List<Element>>> enumerable5 = dictionary;
			Func<KeyValuePair<Category, List<Element>>, SelectedElementsBagViewModel> func6;
			if ((func6 = RuleBasedFiltersItemViewModel.<>c.\u000B) == null)
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
				func6 = (RuleBasedFiltersItemViewModel.<>c.\u000B = new Func<KeyValuePair<Category, List<Element>>, SelectedElementsBagViewModel>(RuleBasedFiltersItemViewModel.<>c.\u001F.\u000E));
			}
			IEnumerable<SelectedElementsBagViewModel> enumerable6 = Enumerable.Select<KeyValuePair<Category, List<Element>>, SelectedElementsBagViewModel>(enumerable5, func6);
			Func<SelectedElementsBagViewModel, string> func7;
			if ((func7 = RuleBasedFiltersItemViewModel.<>c.\u0002) == null)
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
				func7 = (RuleBasedFiltersItemViewModel.<>c.\u0002 = new Func<SelectedElementsBagViewModel, string>(RuleBasedFiltersItemViewModel.<>c.\u001F.\u001B));
			}
			\u001A\u001E\u000A.\u000A(this, \u000C\u001E\u000A.\u000A(Enumerable.OrderBy<SelectedElementsBagViewModel, string>(enumerable6, func7)));
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000052CC File Offset: 0x000034CC
		private void VZ()
		{
			bool? flag = \u0018\u0020\u000A.\u0007(\u0005\u0020\u000A.\u000A(\u0016\u0020\u000A.\u000A()));
			if (\u0019\u0020\u000A.\u000A(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RuleBasedFiltersItemViewModel.VZ()).MethodHandle;
				}
				\u0016\u000A u0016_u000A = new \u0016\u000A();
				\u0004\u0020\u000A.\u000A(u0016_u000A, this);
				\u0016\u000A u0016_u000A2 = u0016_u000A;
				u0016_u000A2.\u001F += RuleBasedFiltersItemViewModel.R;
				\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u0016_u000A2);
				\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00005344 File Offset: 0x00003544
		private void ZZ()
		{
			\u001D\u0006\u000A u001D_u0006_u000A = new \u001D\u0006\u000A(this._uidoc);
			\u000F\u0020\u000A.\u000A(u001D_u0006_u000A, \u0012\u0020\u000A.\u0007(this));
			\u0006\u0020\u000A.\u000A(u001D_u0006_u000A, Context.FilterPassedFromSelectionsManager);
			\u001D\u0006\u000A u000A = u001D_u0006_u000A;
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000A);
			\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
			\u000B\u0020\u000A.\u000A(\u0002\u0020\u000A.\u000A());
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000053A0 File Offset: 0x000035A0
		private void XZ()
		{
			if (\u001C\u0020\u000A.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RuleBasedFiltersItemViewModel.XZ()).MethodHandle;
				}
				\u0003\u0020\u000A.\u000A(this, false);
				return;
			}
			this.MZ();
			\u0003\u0020\u000A.\u000A(this, true);
		}

		// Token: 0x04000031 RID: 49
		private readonly ParameterFilterElement F;
	}
}
