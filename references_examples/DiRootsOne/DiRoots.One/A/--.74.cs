using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;

namespace A
{
	// Token: 0x0200012A RID: 298
	internal class \u001F\u0016
	{
		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000B72 RID: 2930 RVA: 0x00048254 File Offset: 0x00046454
		// (set) Token: 0x06000B73 RID: 2931 RVA: 0x00048268 File Offset: 0x00046468
		internal static string PluginName { get; set; } = "TableGen";

		// Token: 0x06000B74 RID: 2932 RVA: 0x0004827C File Offset: 0x0004647C
		public void \u0007(UIControlledApplication \u001F, string \u000A, string \u0007, string \u001D, int \u0004)
		{
			RibbonPanel u001F = \u001F\u0016.\u001F = \u000D\u0012\u001D.\u000A(\u001F, \u000A, \u0007, true);
			\u001F\u0016.\u0004(\u0004);
			\u0009\u0013\u000A.\u000A(\u001F\u001A\u000A.\u000A(\u001F), new EventHandler<DocumentOpenedEventArgs>(this.\u001D));
			PushButton u001F2 = \u001C\u0012\u001D.\u000A(u001F, "TableGen", "TableGen", \u001E\u0011\u000A.\u000A(\u0007\u0018\u000E.\u001F()), \u001D);
			\u0012\u0012\u001D.\u000A(u001F2, \u0003\u0012\u001D.\u000A(\u001E\u0011\u000A.\u000A(\u0008\u001D\u000E.\u001F())));
			\u0006\u0012\u001D.\u000A(u001F2, \u000B\u0012\u001D.\u000A(\u0003\u0014\u0004.\u000A()));
			\u0016\u0012\u001D.\u000A(u001F2, \u000B\u0012\u001D.\u000A(\u0012\u0014\u0004.\u000A()));
			\u0018\u0012\u001D.\u000A(u001F2, \u0005\u0012\u001D.\u000A(2, "https://diroots.com/plugins/tablegen-revit-addin/"));
			\u0004\u0012\u001D.\u000A(u001F2, \u000F\u0014\u0004.\u000A());
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x00048340 File Offset: 0x00046540
		public void \u001D(object \u001F, DocumentOpenedEventArgs \u000A)
		{
			Document document = \u0019\u001A\u000A.\u000A(\u000A);
			if (document != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0016.\u001D(object, DocumentOpenedEventArgs)).MethodHandle;
				}
				if (\u000B\u001A\u000A.\u001D(document))
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
					if (!\u000F\u000C\u001D.\u0007(\u0014\u0009\u0007.\u0007(document), "LegendView"))
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
						\u001C\u0014\u0004.\u000A().\u0012(\u001B\u001A\u000A.\u000A(\u0017\u0005\u0004.\u0007(document)));
					}
				}
			}
		}

		// Token: 0x06000B76 RID: 2934 RVA: 0x000483C0 File Offset: 0x000465C0
		internal static void \u0004(int \u001F)
		{
			\u0010\u0012\u001D.\u000A(\u001F\u0016.\u001F, \u001F, "#E6E1EF", "#c8bae8");
		}

		// Token: 0x0400049B RID: 1179
		private static RibbonPanel \u001F;

		// Token: 0x0400049C RID: 1180
		[CompilerGenerated]
		private static string \u000A;
	}
}
