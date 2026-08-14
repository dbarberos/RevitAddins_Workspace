using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.UI;

namespace A
{
	// Token: 0x020001F7 RID: 503
	internal class \u001D\u000F
	{
		// Token: 0x17000584 RID: 1412
		// (get) Token: 0x060012CA RID: 4810 RVA: 0x0006C04C File Offset: 0x0006A24C
		// (set) Token: 0x060012CB RID: 4811 RVA: 0x0006C060 File Offset: 0x0006A260
		internal static string PluginName { get; set; } = "SheetLink";

		// Token: 0x060012CC RID: 4812 RVA: 0x0006C074 File Offset: 0x0006A274
		internal void \u0007(UIControlledApplication \u001F, string \u000A, string \u0007, string \u001D, int \u0004)
		{
			RibbonPanel u001F = \u001D\u000F.\u001F = \u000D\u0012\u001D.\u000A(\u001F, \u000A, \u0007, true);
			\u001D\u000F.\u001D(\u0004);
			PushButton u001F2 = \u001C\u0012\u001D.\u000A(u001F, "SheetLink", "SheetLink", \u001E\u0011\u000A.\u000A(\u0001\u0016\u000E.\u001F()), \u001D);
			\u0006\u0012\u001D.\u000A(u001F2, \u000B\u0012\u001D.\u000A(\u001C\u0016\u0018.\u000A()));
			\u0016\u0012\u001D.\u000A(u001F2, \u000B\u0012\u001D.\u000A(\u0003\u0016\u0018.\u000A()));
			\u0018\u0012\u001D.\u000A(u001F2, \u0005\u0012\u001D.\u000A(2, "https://diroots.com/plugins/sheetlink-revit-to-excel/"));
			\u0004\u0012\u001D.\u000A(u001F2, \u0012\u0016\u0018.\u000A());
			\u000F\u0016\u0018.\u000A(u001F);
			PushButton u001F3 = \u001C\u0012\u001D.\u000A(u001F, "PanelLink", "PanelLink", \u001E\u0011\u000A.\u000A(\u0009\u0016\u000E.\u001F()), \u001D);
			\u0012\u0012\u001D.\u000A(u001F3, \u0003\u0012\u001D.\u000A(\u001E\u0011\u000A.\u000A(\u0008\u001D\u000E.\u001F())));
			\u0006\u0012\u001D.\u000A(u001F3, \u000B\u0012\u001D.\u000A(\u0006\u0016\u0018.\u000A()));
			\u0016\u0012\u001D.\u000A(u001F3, \u000B\u0012\u001D.\u000A(\u0002\u0016\u0018.\u000A()));
			\u0018\u0012\u001D.\u000A(u001F3, \u0005\u0012\u001D.\u000A(2, "https://diroots.com/plugins/sheetlink-revit-to-excel/"));
			\u0004\u0012\u001D.\u000A(u001F3, \u000B\u0016\u0018.\u000A());
		}

		// Token: 0x060012CD RID: 4813 RVA: 0x0006C18C File Offset: 0x0006A38C
		internal static void \u001D(int \u001F)
		{
			\u0010\u0012\u001D.\u000A(\u001D\u000F.\u001F, \u001F, "#E6E1EF", "#c8bae8");
		}

		// Token: 0x04000780 RID: 1920
		private static RibbonPanel \u001F;

		// Token: 0x04000781 RID: 1921
		[CompilerGenerated]
		private static string \u000A;
	}
}
