using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.UI;

namespace A
{
	// Token: 0x020000BD RID: 189
	internal class \u0001\u0004
	{
		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000747 RID: 1863 RVA: 0x0002A7D0 File Offset: 0x000289D0
		// (set) Token: 0x06000748 RID: 1864 RVA: 0x0002A7E4 File Offset: 0x000289E4
		internal static string PluginName { get; set; } = "ViewAligner";

		// Token: 0x06000749 RID: 1865 RVA: 0x0002A7F8 File Offset: 0x000289F8
		public static void \u0007(UIControlledApplication \u001F, string \u000A, string \u0007, string \u001D, int \u0004)
		{
			RibbonPanel u001F = \u0001\u0004.\u001F = \u000D\u0012\u001D.\u000A(\u001F, \u000A, \u0007, true);
			\u0001\u0004.\u001D(\u0004);
			PushButton u001F2 = \u001C\u0012\u001D.\u000A(u001F, "btnViewAligner", "View\nAligner", \u001E\u0011\u000A.\u000A(\u000E\u001D\u000E.\u001F()), \u001D);
			\u0012\u0012\u001D.\u000A(u001F2, \u0003\u0012\u001D.\u000A(\u001E\u0011\u000A.\u000A(\u0008\u001D\u000E.\u001F())));
			\u0006\u0012\u001D.\u000A(u001F2, \u000B\u0012\u001D.\u000A(\u000F\u0012\u001D.\u000A()));
			\u0016\u0012\u001D.\u000A(u001F2, \u000B\u0012\u001D.\u000A(\u0002\u0012\u001D.\u000A()));
			\u0018\u0012\u001D.\u000A(u001F2, \u0005\u0012\u001D.\u000A(2, "https://diroots.com/plugins/ViewAligner"));
			\u0004\u0012\u001D.\u000A(u001F2, \u0019\u0012\u001D.\u000A());
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x0002A8A0 File Offset: 0x00028AA0
		internal static void \u001D(int \u001F)
		{
			\u0010\u0012\u001D.\u000A(\u0001\u0004.\u001F, \u001F, "#E2EFDA", "#82af64");
		}

		// Token: 0x040002EA RID: 746
		private static RibbonPanel \u001F;

		// Token: 0x040002EB RID: 747
		[CompilerGenerated]
		private static string \u000A;
	}
}
