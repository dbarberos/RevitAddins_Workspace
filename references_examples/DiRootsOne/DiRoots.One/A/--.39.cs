using System;
using Autodesk.Revit.UI;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Container;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Logs;
using DiRoots.One.Commons.Models;

namespace A
{
	// Token: 0x020000E1 RID: 225
	internal static class \u0007\u0018
	{
		// Token: 0x06000876 RID: 2166 RVA: 0x00033534 File Offset: 0x00031734
		public static void \u000A(string \u001F)
		{
			if (\u0007\u0018.\u001F.GetService<ICustomLogger>(true) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0007\u0018.\u000A(string)).MethodHandle;
				}
				return;
			}
			Logger implementation = \u0008\u0007\u001D.\u000A("DiRootsOne", \u0004\u0001\u001D.\u000A());
			\u0007\u0018.\u001F.RegisterSingleton<ICustomLogger, Logger>(implementation);
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x00033588 File Offset: 0x00031788
		public static void \u000A(UIApplication \u001F)
		{
			if (\u0007\u0018.\u001F.GetService<DocumentContext>(true) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0007\u0018.\u000A(UIApplication)).MethodHandle;
				}
				return;
			}
			DocumentContext implementation = \u0012\u0008\u001D.\u000A(\u001F);
			\u0007\u0018.\u001F.RegisterSingleton<DocumentContext>(implementation);
			\u0007\u0018.\u001F.RegisterSingleton<ActiveDocumentHandler>(\u0007\u000F\u001D.\u000A().GetService<ActiveDocumentHandler>(false));
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x000335EC File Offset: 0x000317EC
		public static \u001F \u0007<\u001F>()
		{
			return \u0007\u0018.\u001F.GetService<\u001F>(false);
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x00033608 File Offset: 0x00031808
		public static void \u001D()
		{
			\u0004\u000F\u001D.\u000A(\u0007\u0018.\u001F);
		}

		// Token: 0x04000352 RID: 850
		internal static readonly IoC \u001F = \u001D\u0001\u001D.\u000A();
	}
}
