using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using ProSheets.DrawingRegister.Enums;

namespace A
{
	// Token: 0x02000123 RID: 291
	internal static class \u0019\u0015\u0018
	{
		// Token: 0x06000F00 RID: 3840 RVA: 0x0005545C File Offset: 0x0005365C
		public static Dictionary<string, object> \u000C(Document \u000C)
		{
			BrowserOrganization u = \u001E\u001C\u0016.\u0018(\u000C);
			return \u0019\u0015\u0018.\u0014(\u000C, u);
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x0005547C File Offset: 0x0005367C
		public static Dictionary<string, object> \u0018(Document \u000C)
		{
			BrowserOrganization u = \u0013\u000F\u000F.\u0018(\u000C);
			return \u0019\u0015\u0018.\u0014(\u000C, u);
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x0005549C File Offset: 0x0005369C
		private static Dictionary<string, object> \u0014(Document \u000C, BrowserOrganization \u0018)
		{
			\u0019\u0015\u0018.\u000B\u0015\u0018 u000B_u0015_u = new \u0019\u0015\u0018.\u000B\u0015\u0018();
			u000B_u0015_u.\u000C = \u000C;
			Dictionary<string, object> dictionary = \u0018\u0010\u0016.\u0018();
			List<BrowserOrganization>.Enumerator enumerator = \u0020\u000F\u000F.\u0018(Enumerable.ToList<BrowserOrganization>(Enumerable.Cast<BrowserOrganization>(Enumerable.Select<ElementId, Element>(\u0017\u001C\u0016.\u0018(\u0018), new Func<ElementId, Element>(u000B_u0015_u.\u0018)))));
			try
			{
				while (\u0009\u000F\u000F.\u0018(ref enumerator))
				{
					BrowserOrganization browserOrganization = \u000A\u000F\u000F.\u0018(ref enumerator);
					\u0005\u0007\u0016.\u0018(dictionary, \u001E\u0016\u0014.\u0018(browserOrganization), browserOrganization);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0015\u0018.\u0014(Document, BrowserOrganization)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return dictionary;
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x0005554C File Offset: 0x0005374C
		public static Dictionary<string, object> \u0003(Document \u000C, BrowserOption \u0018)
		{
			if (\u0018 == BrowserOption.BrowserOrganization)
			{
				return \u0019\u0015\u0018.\u000C(\u000C);
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0015\u0018.\u0003(Document, BrowserOption)).MethodHandle;
			}
			if (\u0018 != BrowserOption.SheetList)
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
				return \u0018\u0010\u0016.\u0018();
			}
			return \u0019\u0015\u0018.\u0018(\u000C);
		}

		// Token: 0x02000213 RID: 531
		[CompilerGenerated]
		private sealed class \u000B\u0015\u0018
		{
			// Token: 0x060012FC RID: 4860 RVA: 0x00061410 File Offset: 0x0005F610
			internal Element \u0018(ElementId \u000C)
			{
				return \u0003\u0004\u0018.\u0018(this.\u000C, \u000C);
			}

			// Token: 0x04000963 RID: 2403
			public Document \u000C;
		}
	}
}
