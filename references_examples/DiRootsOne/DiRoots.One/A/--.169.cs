using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.SheetGen;
using DiRoots.One.SheetGen.TemplateTransfer;

namespace A
{
	// Token: 0x020002E2 RID: 738
	internal static class \u0008\u0011
	{
		// Token: 0x06001E92 RID: 7826 RVA: 0x000C0404 File Offset: 0x000BE604
		internal static List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> \u001F(List<ViewManagerView> \u001F)
		{
			Predicate<ViewManagerView> u000A;
			if ((u000A = \u0008\u0011.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0011.\u001F(List<ViewManagerView>)).MethodHandle;
				}
				u000A = (\u0008\u0011.<>c.\u000A = new Predicate<ViewManagerView>(\u0008\u0011.<>c.\u001F.\u0012));
			}
			View u001F;
			if (!\u0005\u0001\u0016.\u000A(\u001F, u000A))
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
				u001F = null;
			}
			else
			{
				Predicate<ViewManagerView> u000A2;
				if ((u000A2 = \u0008\u0011.<>c.\u0007) == null)
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
					u000A2 = (\u0008\u0011.<>c.\u0007 = new Predicate<ViewManagerView>(\u0008\u0011.<>c.\u001F.\u0003));
				}
				u001F = \u001F\u000B\u0016.\u0007(\u0018\u0001\u0016.\u000A(\u001F, u000A2));
			}
			Predicate<ViewManagerView> u000A3;
			if ((u000A3 = \u0008\u0011.<>c.\u001D) == null)
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
				u000A3 = (\u0008\u0011.<>c.\u001D = new Predicate<ViewManagerView>(\u0008\u0011.<>c.\u001F.\u001C));
			}
			View view;
			if (!\u0005\u0001\u0016.\u000A(\u001F, u000A3))
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
				view = \u0011\u001F\u000E.\u001F;
			}
			else
			{
				Predicate<ViewManagerView> u000A4;
				if ((u000A4 = \u0008\u0011.<>c.\u0004) == null)
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
					u000A4 = (\u0008\u0011.<>c.\u0004 = new Predicate<ViewManagerView>(\u0008\u0011.<>c.\u001F.\u000D));
				}
				view = \u001F\u000B\u0016.\u0007(\u0018\u0001\u0016.\u000A(\u001F, u000A4));
			}
			View u001F2 = view;
			Predicate<ViewManagerView> u000A5;
			if ((u000A5 = \u0008\u0011.<>c.\u0019) == null)
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
				u000A5 = (\u0008\u0011.<>c.\u0019 = new Predicate<ViewManagerView>(\u0008\u0011.<>c.\u001F.\u0010));
			}
			View view2;
			if (!\u0005\u0001\u0016.\u000A(\u001F, u000A5))
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
				view2 = \u0011\u001F\u000E.\u001F;
			}
			else
			{
				Predicate<ViewManagerView> u000A6;
				if ((u000A6 = \u0008\u0011.<>c.\u0018) == null)
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
					u000A6 = (\u0008\u0011.<>c.\u0018 = new Predicate<ViewManagerView>(\u0008\u0011.<>c.\u001F.\u000E));
				}
				view2 = \u001F\u000B\u0016.\u0007(\u0018\u0001\u0016.\u000A(\u001F, u000A6));
			}
			View u001F3 = view2;
			Predicate<ViewManagerView> u000A7;
			if ((u000A7 = \u0008\u0011.<>c.\u0005) == null)
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
				u000A7 = (\u0008\u0011.<>c.\u0005 = new Predicate<ViewManagerView>(\u0008\u0011.<>c.\u001F.\u0008));
			}
			View view3;
			if (!\u0005\u0001\u0016.\u000A(\u001F, u000A7))
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
				view3 = \u0011\u001F\u000E.\u001F;
			}
			else
			{
				Predicate<ViewManagerView> u000A8;
				if ((u000A8 = \u0008\u0011.<>c.\u0016) == null)
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
					u000A8 = (\u0008\u0011.<>c.\u0016 = new Predicate<ViewManagerView>(\u0008\u0011.<>c.\u001F.\u001B));
				}
				view3 = \u001F\u000B\u0016.\u0007(\u0018\u0001\u0016.\u000A(\u001F, u000A8));
			}
			View u001F4 = view3;
			IEnumerable<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> u001F5 = \u0008\u0011.\u000A(u001F);
			List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> u000A9 = \u0008\u0011.\u000A(u001F2);
			List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> u000A10 = \u0008\u0011.\u000A(u001F3);
			List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> u000A11 = \u0008\u0011.\u000A(u001F4);
			List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> list = \u0019\u0001\u0016.\u000A(u001F5);
			\u0004\u0001\u0016.\u000A(list, u000A9);
			\u0004\u0001\u0016.\u000A(list, u000A10);
			\u0004\u0001\u0016.\u000A(list, u000A11);
			Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, ElementId> func;
			if ((func = \u0008\u0011.<>c.\u000B) == null)
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
				func = (\u0008\u0011.<>c.\u000B = new Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, ElementId>(\u0008\u0011.<>c.\u001F.\u0011));
			}
			IEnumerable<IGrouping<ElementId, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>> enumerable = Enumerable.GroupBy<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, ElementId>(list, func);
			Func<IGrouping<ElementId, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>, ElementId> func2;
			if ((func2 = \u0008\u0011.<>c.\u0002) == null)
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
				func2 = (\u0008\u0011.<>c.\u0002 = new Func<IGrouping<ElementId, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>, ElementId>(\u0008\u0011.<>c.\u001F.\u001E));
			}
			Func<IGrouping<ElementId, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> func3;
			if ((func3 = \u0008\u0011.<>c.\u0006) == null)
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
				func3 = (\u0008\u0011.<>c.\u0006 = new Func<IGrouping<ElementId, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>(\u0008\u0011.<>c.\u001F.\u0020));
			}
			IEnumerable<KeyValuePair<ElementId, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>> enumerable2 = Enumerable.ToDictionary<IGrouping<ElementId, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>, ElementId, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>(enumerable, func2, func3);
			Func<KeyValuePair<ElementId, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> func4;
			if ((func4 = \u0008\u0011.<>c.\u000F) == null)
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
				func4 = (\u0008\u0011.<>c.\u000F = new Func<KeyValuePair<ElementId, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>(\u0008\u0011.<>c.\u001F.\u0017));
			}
			return Enumerable.ToList<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>(Enumerable.Select<KeyValuePair<ElementId, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>, DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>(enumerable2, func4));
		}

		// Token: 0x06001E93 RID: 7827 RVA: 0x000C070C File Offset: 0x000BE90C
		internal static List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> \u000A(View \u001F)
		{
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0011.\u000A(View)).MethodHandle;
				}
				\u0008\u0011.\u000D\u0011 u000D_u = new \u0008\u0011.\u000D\u0011();
				u000D_u.\u001F = \u0012\u0001\u0016.\u000A(\u001F);
				u000D_u.\u000A = \u0005\u0002\u0016.\u000A(\u001F);
				List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> list = \u000E\u000C\u0016.\u000A();
				IEnumerator u001F = \u0006\u0001\u0016.\u000A(\u000F\u0001\u0016.\u000A(\u001F));
				try
				{
					while (\u000A\u0017\u000A.\u000A(u001F))
					{
						Parameter u001F2 = \u0006\u0003\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F));
						if (!\u0010\u0014\u0007.\u000A(u001F2))
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
							\u000B\u0001\u0016.\u000A(list, \u0002\u0001\u0016.\u000A(u001F2));
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
					IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
					if (disposable != null)
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
						\u001F\u0017\u000A.\u000A(disposable);
					}
				}
				list = Enumerable.ToList<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>(Enumerable.Where<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>(list, new Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, bool>(u000D_u.\u0007)));
				\u0016\u0001\u0016.\u000A(list, new Action<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>(u000D_u.\u001D));
				return list;
			}
			return \u000E\u000C\u0016.\u000A();
		}

		// Token: 0x020009BD RID: 2493
		[CompilerGenerated]
		private sealed class \u000D\u0011
		{
			// Token: 0x060053C5 RID: 21445 RVA: 0x001ED79C File Offset: 0x001EB99C
			internal bool \u0007(DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo \u001F)
			{
				\u0008\u0011.\u0010\u0011 u0010_u = new \u0008\u0011.\u0010\u0011();
				u0010_u.\u001F = \u001F;
				return Enumerable.Any<ElementId>(this.\u001F, new Func<ElementId, bool>(u0010_u.\u000A));
			}

			// Token: 0x060053C6 RID: 21446 RVA: 0x001ED7D0 File Offset: 0x001EB9D0
			internal void \u001D(DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo \u001F)
			{
				\u0008\u0011.\u000E\u0011 u000E_u = new \u0008\u0011.\u000E\u0011();
				u000E_u.\u001F = \u001F;
				\u0020\u0015\u0016.\u000A(u000E_u.\u001F, !Enumerable.Any<ElementId>(this.\u000A, new Func<ElementId, bool>(u000E_u.\u000A)));
			}

			// Token: 0x04002555 RID: 9557
			public IList<ElementId> \u001F;

			// Token: 0x04002556 RID: 9558
			public ICollection<ElementId> \u000A;
		}

		// Token: 0x020009BE RID: 2494
		[CompilerGenerated]
		private sealed class \u0010\u0011
		{
			// Token: 0x060053C8 RID: 21448 RVA: 0x001ED828 File Offset: 0x001EBA28
			internal bool \u000A(ElementId \u001F)
			{
				return \u0011\u0016\u001D.\u000A(\u001F, \u0003\u0015\u0016.\u000A(this.\u001F));
			}

			// Token: 0x04002557 RID: 9559
			public DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo \u001F;
		}

		// Token: 0x020009BF RID: 2495
		[CompilerGenerated]
		private sealed class \u000E\u0011
		{
			// Token: 0x060053CA RID: 21450 RVA: 0x001ED860 File Offset: 0x001EBA60
			internal bool \u000A(ElementId \u001F)
			{
				return \u0011\u0016\u001D.\u000A(\u001F, \u0003\u0015\u0016.\u000A(this.\u001F));
			}

			// Token: 0x04002558 RID: 9560
			public DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo \u001F;
		}
	}
}
