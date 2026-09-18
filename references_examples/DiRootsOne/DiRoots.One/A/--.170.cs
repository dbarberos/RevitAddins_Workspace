using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.SheetGen;
using DiRoots.One.SheetGen.TemplateTransfer;

namespace A
{
	// Token: 0x020002E3 RID: 739
	internal static class \u0011\u0011
	{
		// Token: 0x06001E94 RID: 7828 RVA: 0x000C0820 File Offset: 0x000BEA20
		public static void \u001F(View \u001F, View \u000A, IEnumerable<ElementId> \u0007)
		{
			List<ElementId> list = Enumerable.ToList<ElementId>(\u0005\u0002\u0016.\u000A(\u001F));
			List<ElementId> list2 = Enumerable.ToList<ElementId>(\u0012\u0001\u0016.\u000A(\u001F));
			List<ElementId> list3 = \u001C\u0013\u000A.\u000A();
			IEnumerator<ElementId> enumerator = \u000B\u0013\u0007.\u000A(\u0007);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ElementId u000A = \u0016\u0013\u0007.\u000A(enumerator);
					if (\u0014\u000E\u0007.\u000A(list2, u000A))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0011.\u001F(View, View, IEnumerable<ElementId>)).MethodHandle;
						}
						\u0018\u0002\u0016.\u000A(list2, u000A);
					}
					if (\u0014\u000E\u0007.\u000A(list, u000A))
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
						\u0018\u0002\u0016.\u000A(list, u000A);
						\u0003\u0010\u0007.\u000A(list3, u000A);
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
			\u0004\u0002\u0016.\u000A(\u001F, list2);
			\u0019\u0002\u0016.\u000A(\u000A, \u001F);
			if (Enumerable.Any<ElementId>(list3))
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
				\u000F\u0013\u000A.\u000A(list, list3);
			}
			\u0004\u0002\u0016.\u000A(\u001F, list);
		}

		// Token: 0x06001E95 RID: 7829 RVA: 0x000C0928 File Offset: 0x000BEB28
		public static void \u000A(ViewManagerView \u001F, List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> \u000A)
		{
			List<ElementId> list = Enumerable.ToList<ElementId>(\u0005\u0002\u0016.\u000A(\u001F\u000B\u0016.\u0007(\u001F)));
			Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, bool> func;
			if ((func = \u0011\u0011.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0011.\u000A(ViewManagerView, List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>)).MethodHandle;
				}
				func = (\u0011\u0011.<>c.\u000A = new Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, bool>(\u0011\u0011.<>c.\u001F.\u0018));
			}
			IEnumerable<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> enumerable = Enumerable.Where<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>(\u000A, func);
			Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, ElementId> func2;
			if ((func2 = \u0011\u0011.<>c.\u0007) == null)
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
				func2 = (\u0011\u0011.<>c.\u0007 = new Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, ElementId>(\u0011\u0011.<>c.\u001F.\u0005));
			}
			IEnumerable<ElementId> enumerable2 = Enumerable.Select<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, ElementId>(enumerable, func2);
			list = Enumerable.ToList<ElementId>(Enumerable.Except<ElementId>(list, enumerable2));
			object u001F = list;
			Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, bool> func3;
			if ((func3 = \u0011\u0011.<>c.\u001D) == null)
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
				func3 = (\u0011\u0011.<>c.\u001D = new Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, bool>(\u0011\u0011.<>c.\u001F.\u0016));
			}
			IEnumerable<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> enumerable3 = Enumerable.Where<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>(\u000A, func3);
			Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, ElementId> func4;
			if ((func4 = \u0011\u0011.<>c.\u0004) == null)
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
				func4 = (\u0011\u0011.<>c.\u0004 = new Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, ElementId>(\u0011\u0011.<>c.\u001F.\u000B));
			}
			\u000F\u0013\u000A.\u000A(u001F, Enumerable.Select<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, ElementId>(enumerable3, func4));
			list = Enumerable.ToList<ElementId>(Enumerable.Distinct<ElementId>(list));
			\u0004\u0002\u0016.\u000A(\u001F\u000B\u0016.\u0007(\u001F), list);
		}

		// Token: 0x06001E96 RID: 7830 RVA: 0x000C0A50 File Offset: 0x000BEC50
		public static List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> \u0007(ViewManagerView \u001F, List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> \u000A, List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> \u0007)
		{
			List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> list = \u000E\u000C\u0016.\u000A();
			Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, bool> func;
			if ((func = \u0011\u0011.<>c.\u0019) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0011.\u0007(ViewManagerView, List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>, List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>)).MethodHandle;
				}
				func = (\u0011\u0011.<>c.\u0019 = new Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, bool>(\u0011\u0011.<>c.\u001F.\u0002));
			}
			IEnumerator<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> enumerator = \u000F\u0015\u0016.\u000A(Enumerable.Where<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>(\u0007, func));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u0011\u0011.\u001B\u0011 u001B_u = new \u0011\u0011.\u001B\u0011();
					u001B_u.\u001F = \u0006\u0015\u0016.\u000A(enumerator);
					if (\u0013\u0015\u0016.\u000A(\u000A, new Predicate<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>(u001B_u.\u000A)))
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
						\u0010\u0001\u0016.\u000A(u001B_u.\u001F, true);
					}
					else
					{
						\u0010\u0001\u0016.\u000A(u001B_u.\u001F, false);
						\u0013\u001A\u0016.\u001D(u001B_u.\u001F, \u0018\u000E\u0007.\u000A(\u000D\u0001\u0016.\u000A(), \u0009\u000C\u0016.\u000A(u001B_u.\u001F), \u0007\u000B\u0016.\u000A(\u001F)));
						DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo u000A = \u0003\u0001\u0016.\u000A(\u001A\u001A\u0016.\u001D(u001B_u.\u001F), \u001C\u0001\u0016.\u000A(u001B_u.\u001F));
						\u000B\u0001\u0016.\u000A(list, u000A);
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
			return list;
		}

		// Token: 0x020009C1 RID: 2497
		[CompilerGenerated]
		private sealed class \u001B\u0011
		{
			// Token: 0x060053D3 RID: 21459 RVA: 0x001ED940 File Offset: 0x001EBB40
			internal bool \u000A(DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo \u001F)
			{
				return \u0011\u0016\u001D.\u000A(\u0003\u0015\u0016.\u000A(\u001F), \u0003\u0015\u0016.\u000A(this.\u001F));
			}

			// Token: 0x0400255F RID: 9567
			public DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo \u001F;
		}
	}
}
