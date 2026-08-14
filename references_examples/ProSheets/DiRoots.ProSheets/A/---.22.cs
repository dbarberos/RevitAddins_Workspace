using System;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Models;

namespace A
{
	// Token: 0x020000CC RID: 204
	internal static class \u0014\u001F\u0018
	{
		// Token: 0x06000B29 RID: 2857 RVA: 0x00042404 File Offset: 0x00040604
		public static PrinterConfig \u0014()
		{
			return XMLUtility.DeserialiseInfo<PrinterConfig>(\u0003\u001A\u0018.\u0018(\u001E\u0013\u0016.\u0018(), "printers.xml"));
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x0004242C File Offset: 0x0004062C
		public static bool \u0003()
		{
			if (\u0014\u001F\u0018.\u0018 == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u001F\u0018.\u0003()).MethodHandle;
				}
				\u0014\u001F\u0018.\u0018 = \u0014\u001F\u0018.\u0014();
			}
			object u000C = \u0004\u0013\u0016.\u0018(\u0014\u001F\u0018.\u0018);
			Predicate<Printer> u;
			if ((u = \u0014\u001F\u0018.<>c.\u0018) == null)
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
				u = (\u0014\u001F\u0018.<>c.\u0018 = new Predicate<Printer>(\u0014\u001F\u0018.<>c.\u000C.\u0014));
			}
			return \u0002\u0013\u0016.\u0018(u000C, u);
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0004249C File Offset: 0x0004069C
		internal static bool \u0016(ICustomLogger \u000C)
		{
			if (\u0014\u001F\u0018.\u0003())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u001F\u0018.\u0016(ICustomLogger)).MethodHandle;
				}
				return \u0020\u001F\u0018.\u000C(\u000C);
			}
			return false;
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x000424D0 File Offset: 0x000406D0
		internal static bool \u000F(bool \u000C, ICustomLogger \u0018)
		{
			if (\u0014\u001F\u0018.\u0016(\u0018))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u001F\u0018.\u000F(bool, ICustomLogger)).MethodHandle;
				}
				return true;
			}
			return \u000C;
		}

		// Token: 0x04000544 RID: 1348
		private static string \u000C;

		// Token: 0x04000545 RID: 1349
		private static PrinterConfig \u0018;
	}
}
