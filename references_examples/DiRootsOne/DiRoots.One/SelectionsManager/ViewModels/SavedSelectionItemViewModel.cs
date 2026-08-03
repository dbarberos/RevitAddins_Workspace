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
using DiRoots.One.OneFilter.CommonLibrary.Models;
using DiRoots.One.OneFilter.SelectionsManager.Enums;
using SelectionsManager.ViewModels.Base;

namespace SelectionsManager.ViewModels
{
	// Token: 0x02000021 RID: 33
	public class SavedSelectionItemViewModel : SelectionItem
	{
		// Token: 0x06000102 RID: 258 RVA: 0x00005C64 File Offset: 0x00003E64
		public SavedSelectionItemViewModel()
		{
			\u0007\u001E\u000A.\u000A(this, false);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00005C80 File Offset: 0x00003E80
		public SavedSelectionItemViewModel(UIDocument uidoc, SelectionFilterElement selection) : base(uidoc)
		{
			\u0006\u001E\u000A.\u000A(this, selection);
			\u0016\u001E\u000A.\u000A(this, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(selection)));
			\u0018\u001E\u000A.\u000A(this, \u0005\u001E\u000A.\u000A(selection));
			ICollection<ElementId> f = \u0016\u0017\u000A.\u000A(selection);
			this.PZ(f);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00005CD0 File Offset: 0x00003ED0
		public SavedSelectionItemViewModel(UIDocument uidoc, SelectionInfo selection) : base(uidoc)
		{
			\u0016\u001E\u000A.\u000A(this, \u0006\u0017\u000A.\u000A(selection));
			\u0018\u001E\u000A.\u000A(this, \u0002\u0017\u000A.\u000A(selection));
			List<ElementId> f = \u000B\u0017\u000A.\u000A(selection);
			this.PZ(f);
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000105 RID: 261 RVA: 0x00005D10 File Offset: 0x00003F10
		// (remove) Token: 0x06000106 RID: 262 RVA: 0x00005D5C File Offset: 0x00003F5C
		internal static event DeleteFinishedHandler R
		{
			[CompilerGenerated]
			add
			{
				DeleteFinishedHandler deleteFinishedHandler = SavedSelectionItemViewModel.R;
				DeleteFinishedHandler deleteFinishedHandler2;
				do
				{
					deleteFinishedHandler2 = deleteFinishedHandler;
					DeleteFinishedHandler value2 = \u0016\u0015\u0010.\u001F(\u000F\u001E\u000A.\u000A(deleteFinishedHandler2, value));
					deleteFinishedHandler = Interlocked.CompareExchange<DeleteFinishedHandler>(ref SavedSelectionItemViewModel.R, value2, deleteFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionItemViewModel.add_R(DeleteFinishedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				DeleteFinishedHandler deleteFinishedHandler = SavedSelectionItemViewModel.R;
				DeleteFinishedHandler deleteFinishedHandler2;
				do
				{
					deleteFinishedHandler2 = deleteFinishedHandler;
					DeleteFinishedHandler value2 = \u0016\u0015\u0010.\u001F(\u0012\u001E\u000A.\u000A(deleteFinishedHandler2, value));
					deleteFinishedHandler = Interlocked.CompareExchange<DeleteFinishedHandler>(ref SavedSelectionItemViewModel.R, value2, deleteFinishedHandler2);
				}
				while (deleteFinishedHandler != deleteFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionItemViewModel.remove_R(DeleteFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00005DA8 File Offset: 0x00003FA8
		public CommandBase CollapseSelectionCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.XZ), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00005DD0 File Offset: 0x00003FD0
		public CommandBase HideCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.JZ), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00005DF8 File Offset: 0x00003FF8
		public CommandBase IsolateCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.NZ), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00005E20 File Offset: 0x00004020
		public CommandBase EditCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.ZZ), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00005E48 File Offset: 0x00004048
		public CommandBase DeleteCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.VZ), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00005E70 File Offset: 0x00004070
		public CommandBase SelectCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.KZ), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00005E98 File Offset: 0x00004098
		internal static void WZ()
		{
			if (SavedSelectionItemViewModel.R != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionItemViewModel.WZ()).MethodHandle;
				}
				Delegate[] array = \u001C\u001E\u000A.\u000A(SavedSelectionItemViewModel.R);
				for (int i = 0; i < (int)\u000B\u0015\u0010.\u001F(array); i++)
				{
					SavedSelectionItemViewModel.R -= \u0016\u0015\u0010.\u001F(array[i]);
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
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00005EFC File Offset: 0x000040FC
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

		// Token: 0x0600010F RID: 271 RVA: 0x00005F50 File Offset: 0x00004150
		private void EZ(HideIsolateType F, bool R)
		{
			IEnumerable<SelectedElementsBagViewModel> enumerable = \u000E\u001E\u000A.\u000A(this);
			Func<SelectedElementsBagViewModel, IEnumerable<ElementId>> func;
			if ((func = SavedSelectionItemViewModel.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionItemViewModel.EZ(HideIsolateType, bool)).MethodHandle;
				}
				func = (SavedSelectionItemViewModel.<>c.\u000A = new Func<SelectedElementsBagViewModel, IEnumerable<ElementId>>(SavedSelectionItemViewModel.<>c.\u001F.\u000E));
			}
			List<ElementId> list = Enumerable.ToList<ElementId>(Enumerable.SelectMany<SelectedElementsBagViewModel, ElementId>(enumerable, func));
			if (!Enumerable.Any<ElementId>(list))
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
			\u0004\u0006\u000A u000A = new \u0004\u0006\u000A(list, R, F);
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000A);
			\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00005FE0 File Offset: 0x000041E0
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

		// Token: 0x06000111 RID: 273 RVA: 0x00006034 File Offset: 0x00004234
		private void PZ(IEnumerable<ElementId> F)
		{
			IEnumerable<Element> enumerable = Enumerable.Select<ElementId, Element>(F, new Func<ElementId, Element>(this.OZ));
			Func<Element, bool> func;
			if ((func = SavedSelectionItemViewModel.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionItemViewModel.PZ(IEnumerable<ElementId>)).MethodHandle;
				}
				func = (SavedSelectionItemViewModel.<>c.\u0007 = new Func<Element, bool>(SavedSelectionItemViewModel.<>c.\u001F.\u0008));
			}
			IEnumerable<Element> enumerable2 = Enumerable.Where<Element>(enumerable, func);
			Func<Element, bool> func2;
			if ((func2 = SavedSelectionItemViewModel.<>c.\u001D) == null)
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
				func2 = (SavedSelectionItemViewModel.<>c.\u001D = new Func<Element, bool>(SavedSelectionItemViewModel.<>c.\u001F.\u001B));
			}
			IEnumerable<Element> enumerable3 = Enumerable.Where<Element>(enumerable, func2);
			Func<Element, bool> func3;
			if ((func3 = SavedSelectionItemViewModel.<>c.\u0004) == null)
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
				func3 = (SavedSelectionItemViewModel.<>c.\u0004 = new Func<Element, bool>(SavedSelectionItemViewModel.<>c.\u001F.\u0011));
			}
			IEnumerable<Element> enumerable4 = Enumerable.Where<Element>(enumerable, func3);
			IEnumerable<Element> enumerable5 = enumerable2;
			Func<Element, bool> func4;
			if ((func4 = SavedSelectionItemViewModel.<>c.\u0019) == null)
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
				func4 = (SavedSelectionItemViewModel.<>c.\u0019 = new Func<Element, bool>(SavedSelectionItemViewModel.<>c.\u001F.\u001E));
			}
			IEnumerable<Element> enumerable6 = Enumerable.Where<Element>(enumerable5, func4);
			Func<Element, Category> func5;
			if ((func5 = SavedSelectionItemViewModel.<>c.\u0018) == null)
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
				func5 = (SavedSelectionItemViewModel.<>c.\u0018 = new Func<Element, Category>(SavedSelectionItemViewModel.<>c.\u001F.\u0020));
			}
			IEnumerable<IGrouping<Category, Element>> enumerable7 = Enumerable.GroupBy<Element, Category>(enumerable6, func5, \u0015\u001E\u000A.\u000A());
			Func<IGrouping<Category, Element>, Category> func6;
			if ((func6 = SavedSelectionItemViewModel.<>c.\u0005) == null)
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
				func6 = (SavedSelectionItemViewModel.<>c.\u0005 = new Func<IGrouping<Category, Element>, Category>(SavedSelectionItemViewModel.<>c.\u001F.\u0017));
			}
			Func<IGrouping<Category, Element>, List<ElementId>> func7;
			if ((func7 = SavedSelectionItemViewModel.<>c.\u000B) == null)
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
				func7 = (SavedSelectionItemViewModel.<>c.\u000B = new Func<IGrouping<Category, Element>, List<ElementId>>(SavedSelectionItemViewModel.<>c.\u001F.\u0014));
			}
			IEnumerable<KeyValuePair<Category, List<ElementId>>> enumerable8 = Enumerable.ToDictionary<IGrouping<Category, Element>, Category, List<ElementId>>(enumerable7, func6, func7);
			Func<KeyValuePair<Category, List<ElementId>>, SelectedElementsBagViewModel> func8;
			if ((func8 = SavedSelectionItemViewModel.<>c.\u0002) == null)
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
				func8 = (SavedSelectionItemViewModel.<>c.\u0002 = new Func<KeyValuePair<Category, List<ElementId>>, SelectedElementsBagViewModel>(SavedSelectionItemViewModel.<>c.\u001F.\u001A));
			}
			List<SelectedElementsBagViewModel> list = Enumerable.ToList<SelectedElementsBagViewModel>(Enumerable.Select<KeyValuePair<Category, List<ElementId>>, SelectedElementsBagViewModel>(enumerable8, func8));
			if (Enumerable.Any<Element>(enumerable3))
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
				IEnumerable<Element> enumerable9 = enumerable3;
				Func<Element, string> func9;
				if ((func9 = SavedSelectionItemViewModel.<>c.\u0006) == null)
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
					func9 = (SavedSelectionItemViewModel.<>c.\u0006 = new Func<Element, string>(SavedSelectionItemViewModel.<>c.\u001F.\u000C));
				}
				IEnumerable<IGrouping<string, Element>> enumerable10 = Enumerable.GroupBy<Element, string>(enumerable9, func9);
				Func<IGrouping<string, Element>, string> func10;
				if ((func10 = SavedSelectionItemViewModel.<>c.\u000F) == null)
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
					func10 = (SavedSelectionItemViewModel.<>c.\u000F = new Func<IGrouping<string, Element>, string>(SavedSelectionItemViewModel.<>c.\u001F.\u0015));
				}
				Func<IGrouping<string, Element>, List<Element>> func11;
				if ((func11 = SavedSelectionItemViewModel.<>c.\u0012) == null)
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
					func11 = (SavedSelectionItemViewModel.<>c.\u0012 = new Func<IGrouping<string, Element>, List<Element>>(SavedSelectionItemViewModel.<>c.\u001F.\u0001));
				}
				Dictionary<string, List<Element>>.Enumerator enumerator = \u0008\u0017\u000A.\u000A(Enumerable.ToDictionary<IGrouping<string, Element>, string, List<Element>>(enumerable10, func10, func11));
				try
				{
					while (\u001C\u0017\u000A.\u000A(ref enumerator))
					{
						KeyValuePair<string, List<Element>> keyValuePair = \u000E\u0017\u000A.\u000A(ref enumerator);
						object u001F = list;
						string u001F2 = \u0010\u0017\u000A.\u000A(ref keyValuePair);
						IEnumerable<Element> enumerable11 = \u000D\u0017\u000A.\u000A(ref keyValuePair);
						Func<Element, ElementId> func12;
						if ((func12 = SavedSelectionItemViewModel.<>c.\u0003) == null)
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
							func12 = (SavedSelectionItemViewModel.<>c.\u0003 = new Func<Element, ElementId>(SavedSelectionItemViewModel.<>c.\u001F.\u0009));
						}
						\u0012\u0017\u000A.\u000A(u001F, \u0003\u0017\u000A.\u000A(u001F2, Enumerable.ToList<ElementId>(Enumerable.Select<Element, ElementId>(enumerable11, func12))));
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
			}
			if (Enumerable.Any<Element>(enumerable4))
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
				object u001F3 = list;
				string u001F4 = \u0005\u001E\u000A.\u000A(Enumerable.First<Element>(enumerable4));
				IEnumerable<Element> enumerable12 = enumerable4;
				Func<Element, ElementId> func13;
				if ((func13 = SavedSelectionItemViewModel.<>c.\u001C) == null)
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
					func13 = (SavedSelectionItemViewModel.<>c.\u001C = new Func<Element, ElementId>(SavedSelectionItemViewModel.<>c.\u001F.\u001F\u000A));
				}
				\u0012\u0017\u000A.\u000A(u001F3, \u0003\u0017\u000A.\u000A(u001F4, Enumerable.ToList<ElementId>(Enumerable.Select<Element, ElementId>(enumerable12, func13))));
			}
			IEnumerable<SelectedElementsBagViewModel> enumerable13 = list;
			Func<SelectedElementsBagViewModel, string> func14;
			if ((func14 = SavedSelectionItemViewModel.<>c.\u000D) == null)
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
				func14 = (SavedSelectionItemViewModel.<>c.\u000D = new Func<SelectedElementsBagViewModel, string>(SavedSelectionItemViewModel.<>c.\u001F.\u000A\u000A));
			}
			\u001A\u001E\u000A.\u000A(this, \u000C\u001E\u000A.\u000A(Enumerable.OrderBy<SelectedElementsBagViewModel, string>(enumerable13, func14)));
			\u0007\u001E\u000A.\u000A(this, true);
			\u001D\u001E\u000A.\u000A(this, \u0004\u001E\u000A.\u000A(" ", \u000F\u0017\u000A.\u000A()));
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000063F4 File Offset: 0x000045F4
		private void KZ()
		{
			IEnumerable<SelectedElementsBagViewModel> enumerable = \u000E\u001E\u000A.\u000A(this);
			Func<SelectedElementsBagViewModel, IEnumerable<ElementId>> func;
			if ((func = SavedSelectionItemViewModel.<>c.\u0010) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionItemViewModel.KZ()).MethodHandle;
				}
				func = (SavedSelectionItemViewModel.<>c.\u0010 = new Func<SelectedElementsBagViewModel, IEnumerable<ElementId>>(SavedSelectionItemViewModel.<>c.\u001F.\u0007\u000A));
			}
			List<ElementId> list = Enumerable.ToList<ElementId>(Enumerable.SelectMany<SelectedElementsBagViewModel, ElementId>(enumerable, func));
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

		// Token: 0x06000113 RID: 275 RVA: 0x00006480 File Offset: 0x00004680
		private void VZ()
		{
			bool? flag = \u0018\u0020\u000A.\u0007(\u0005\u0020\u000A.\u000A(\u001B\u0017\u000A.\u000A()));
			if (\u0019\u0020\u000A.\u000A(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionItemViewModel.VZ()).MethodHandle;
				}
				\u0016\u000A u0016_u000A = new \u0016\u000A();
				\u0004\u0020\u000A.\u000A(u0016_u000A, this);
				\u0016\u000A u0016_u000A2 = u0016_u000A;
				u0016_u000A2.\u001F += SavedSelectionItemViewModel.R;
				\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u0016_u000A2);
				\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
				\u000B\u0020\u000A.\u000A(\u0002\u0020\u000A.\u000A());
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00006504 File Offset: 0x00004704
		private void ZZ()
		{
			\u001D\u0006\u000A u001D_u0006_u000A = new \u001D\u0006\u000A(this._uidoc);
			\u000F\u0020\u000A.\u000A(u001D_u0006_u000A, \u0012\u0020\u000A.\u0007(this));
			\u0006\u0020\u000A.\u000A(u001D_u0006_u000A, Context.SelectionPassedFromSelectionsManager);
			\u001D\u0006\u000A u000A = u001D_u0006_u000A;
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000A);
			\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00006550 File Offset: 0x00004750
		private void XZ()
		{
			if (\u001C\u0020\u000A.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionItemViewModel.XZ()).MethodHandle;
				}
				\u0003\u0020\u000A.\u000A(this, false);
				return;
			}
			\u0003\u0020\u000A.\u000A(this, true);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000658C File Offset: 0x0000478C
		[CompilerGenerated]
		private Element OZ(ElementId F)
		{
			return \u0011\u0017\u000A.\u0007(this._doc, F);
		}
	}
}
