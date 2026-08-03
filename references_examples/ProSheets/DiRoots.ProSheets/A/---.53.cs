using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using ProSheets.Commons.Extensions;
using ProSheets.DrawingRegister.Model.TreeViewModel;

namespace A
{
	// Token: 0x0200012B RID: 299
	internal static class \u001B\u0015\u0018
	{
		// Token: 0x06000F63 RID: 3939 RVA: 0x0005745C File Offset: 0x0005565C
		private static List<ViewInfo> \u000C(Document \u000C)
		{
			IEnumerable<ViewSchedule> elements = \u000C.GetElements<ViewSchedule>();
			List<ViewInfo> list = \u0001\u000C\u000F.\u0018();
			Func<ViewSchedule, bool> func;
			if ((func = \u001B\u0015\u0018.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0015\u0018.\u000C(Document)).MethodHandle;
				}
				func = (\u001B\u0015\u0018.<>c.\u0018 = new Func<ViewSchedule, bool>(\u001B\u0015\u0018.<>c.\u000C.\u0003));
			}
			IEnumerator<ViewSchedule> enumerator = \u001F\u000D\u000F.\u0018(Enumerable.Where<ViewSchedule>(elements, func));
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					ViewSchedule u000C = \u0020\u000D\u000F.\u0018(enumerator);
					ViewInfo viewInfo = \u000A\u000D\u000F.\u0018(\u001E\u0016\u0014.\u0018(u000C), \u0009\u0002\u0018.\u0018(u000C).\u000C(), \u001E\u0002\u0016.\u0018(u000C));
					\u0009\u000D\u000F.\u0018(viewInfo, true);
					\u0013\u000D\u000F.\u0018(viewInfo, \u000C);
					\u000D\u0014\u000F.\u0018(list, viewInfo);
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
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					\u0020\u001E\u0018.\u0018(enumerator);
				}
			}
			return list;
		}

		// Token: 0x06000F64 RID: 3940 RVA: 0x0005753C File Offset: 0x0005573C
		public static List<long> \u0018(Document \u000C, long \u0018)
		{
			IEnumerable<ViewSheet> elements = \u000C.GetElements(\u0018.\u0018(), -2003100L);
			Func<ViewSheet, long> func;
			if ((func = \u001B\u0015\u0018.<>c.\u0014) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0015\u0018.\u0018(Document, long)).MethodHandle;
				}
				func = (\u001B\u0015\u0018.<>c.\u0014 = new Func<ViewSheet, long>(\u001B\u0015\u0018.<>c.\u000C.\u0016));
			}
			return Enumerable.ToList<long>(Enumerable.Select<ViewSheet, long>(elements, func));
		}

		// Token: 0x06000F65 RID: 3941 RVA: 0x000575A0 File Offset: 0x000557A0
		public static List<ViewInfo> \u0014(Document \u000C, BrowserOrganization \u0018)
		{
			List<ViewInfo> list = \u0001\u000C\u000F.\u0018();
			List<ViewInfo> list2 = \u001B\u0015\u0018.\u000C(\u000C);
			if (!Enumerable.Any<ViewInfo>(list2))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0015\u0018.\u0014(Document, BrowserOrganization)).MethodHandle;
				}
				return list;
			}
			ViewInfo u = \u0011\u000D\u000F.\u0018(\u0006\u0004\u0018.\u0018(\u000C));
			\u000D\u0014\u000F.\u0018(list, u);
			List<ViewInfo>.Enumerator enumerator = \u0008\u0019\u0016.\u0018(list2);
			try
			{
				while (\u000B\u0019\u0016.\u0018(ref enumerator))
				{
					ViewInfo viewInfo = \u0006\u0019\u0016.\u0018(ref enumerator);
					\u000C\u0017\u0018.\u0003(\u0018, u, \u0017\u0010\u0016.\u0018(viewInfo).\u0018(), viewInfo);
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
			\u000C\u0017\u0018.\u0018(list);
			return list;
		}
	}
}
