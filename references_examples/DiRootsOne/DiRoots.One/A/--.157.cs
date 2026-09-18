using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.UI;

namespace A
{
	// Token: 0x0200029B RID: 667
	internal class \u0014\u000E
	{
		// Token: 0x1700072D RID: 1837
		// (get) Token: 0x06001A15 RID: 6677 RVA: 0x000A7E60 File Offset: 0x000A6060
		// (set) Token: 0x06001A16 RID: 6678 RVA: 0x000A7E74 File Offset: 0x000A6074
		internal static string PluginName { get; set; } = "SheetGen";

		// Token: 0x06001A17 RID: 6679 RVA: 0x000A7E88 File Offset: 0x000A6088
		public void \u0007(UIControlledApplication \u001F, string \u000A, string \u0007, string \u001D, int \u0004)
		{
			RibbonPanel u001F = \u0014\u000E.\u001F = \u000D\u0012\u001D.\u000A(\u001F, \u000A, \u0007, true);
			\u0014\u000E.\u001D(\u0004);
			PushButton u001F2 = \u001C\u0012\u001D.\u000A(u001F, "btnSheetGen", "SheetGen", \u001E\u0011\u000A.\u000A(\u0001\u0012\u000E.\u001F()), \u001D);
			\u0012\u0012\u001D.\u000A(u001F2, \u0003\u0012\u001D.\u000A(\u001E\u0011\u000A.\u000A(\u0008\u001D\u000E.\u001F())));
			\u0006\u0012\u001D.\u000A(u001F2, \u000B\u0012\u001D.\u000A(\u0003\u0007\u0016.\u000A()));
			\u0016\u0012\u001D.\u000A(u001F2, \u000B\u0012\u001D.\u000A(\u0012\u0007\u0016.\u000A()));
			\u0018\u0012\u001D.\u000A(u001F2, \u0005\u0012\u001D.\u000A(2, "https://diroots.com/revit-plugins/batch-create-revit-sheets-and-place-views-with-sheetgen/"));
			\u0004\u0012\u001D.\u000A(u001F2, \u000F\u0007\u0016.\u000A());
			\u000F\u0016\u0018.\u000A(u001F);
			PushButton u001F3 = \u001C\u0012\u001D.\u000A(u001F, "btnViewManager", "View\nManager", \u001E\u0011\u000A.\u000A(\u0009\u0012\u000E.\u001F()), \u001D);
			\u0012\u0012\u001D.\u000A(u001F3, \u0003\u0012\u001D.\u000A(\u001E\u0011\u000A.\u000A(\u0008\u001D\u000E.\u001F())));
			\u0006\u0012\u001D.\u000A(u001F3, \u000B\u0012\u001D.\u000A(\u0006\u0007\u0016.\u000A()));
			\u0016\u0012\u001D.\u000A(u001F3, \u000B\u0012\u001D.\u000A(\u0002\u0007\u0016.\u000A()));
			\u0018\u0012\u001D.\u000A(u001F3, \u0005\u0012\u001D.\u000A(2, "https://diroots.com/revit-plugins/batch-create-revit-sheets-and-place-views-with-sheetgen/"));
			\u0004\u0012\u001D.\u000A(u001F3, \u000B\u0007\u0016.\u000A());
		}

		// Token: 0x06001A18 RID: 6680 RVA: 0x000A7FBC File Offset: 0x000A61BC
		internal static void \u001D(int \u001F)
		{
			\u0010\u0012\u001D.\u000A(\u0014\u000E.\u001F, \u001F, "#E2EFDA", "#82af64");
		}

		// Token: 0x04000A68 RID: 2664
		private static RibbonPanel \u001F;

		// Token: 0x04000A69 RID: 2665
		[CompilerGenerated]
		private static string \u000A;
	}
}
