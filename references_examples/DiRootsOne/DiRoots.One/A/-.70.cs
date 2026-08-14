using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Logs;
using DiRoots.One.Commons.Models;

namespace A
{
	// Token: 0x02000257 RID: 599
	internal static class \u0018\u000D
	{
		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x06001850 RID: 6224 RVA: 0x0009C7F4 File Offset: 0x0009A9F4
		// (set) Token: 0x06001851 RID: 6225 RVA: 0x0009C808 File Offset: 0x0009AA08
		internal static string PluginName { get; set; }

		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x06001852 RID: 6226 RVA: 0x0009C81C File Offset: 0x0009AA1C
		// (set) Token: 0x06001853 RID: 6227 RVA: 0x0009C830 File Offset: 0x0009AA30
		internal static bool DisableModifiedTrigger { get; set; }

		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x06001854 RID: 6228 RVA: 0x0009C844 File Offset: 0x0009AA44
		// (set) Token: 0x06001855 RID: 6229 RVA: 0x0009C858 File Offset: 0x0009AA58
		internal static UIDocument ActiveUIDocument { get; set; }

		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x06001856 RID: 6230 RVA: 0x0009C86C File Offset: 0x0009AA6C
		// (set) Token: 0x06001857 RID: 6231 RVA: 0x0009C880 File Offset: 0x0009AA80
		internal static \u000E\u000E\u000A CurrentFolderHandler { get; set; }

		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x06001858 RID: 6232 RVA: 0x0009C894 File Offset: 0x0009AA94
		// (set) Token: 0x06001859 RID: 6233 RVA: 0x0009C8A8 File Offset: 0x0009AAA8
		internal static PluginInfo PluginInfoInstance { get; set; }

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x0600185A RID: 6234 RVA: 0x0009C8BC File Offset: 0x0009AABC
		// (set) Token: 0x0600185B RID: 6235 RVA: 0x0009C8D0 File Offset: 0x0009AAD0
		internal static Logger LoggerInstance { get; set; } = \u0008\u0007\u001D.\u000A("DiRootsOne", "SheetLink");

		// Token: 0x0600185C RID: 6236 RVA: 0x0009C8E4 File Offset: 0x0009AAE4
		internal static void \u0006(UIDocument \u001F, string \u000A)
		{
			\u001C\u0011\u0019.\u000A(\u001F);
			\u001A\u000E\u0019.\u000A().\u001D(\u0011\u0020\u000A.\u0007(\u001F), true);
			if (\u001A\u0006\u0007.\u000A(\u001B\u0016\u0018.\u000A()))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u000D.\u0006(UIDocument, string)).MethodHandle;
				}
				\u001A\u0020\u0005.\u000A(\u000A);
				\u0013\u0020\u0005.\u000A(new \u000E\u000E\u000A("DiRootsOne", \u001B\u0016\u0018.\u000A(), \u0010\u0011\u000A.\u000A()));
			}
			PluginInfo u001F = \u0014\u0020\u0005.\u000A();
			\u0015\u0001\u000A.\u000A(u001F, \u000A);
			\u001A\u0001\u000A.\u000A(u001F, \u0010\u0011\u000A.\u000A());
			\u0017\u0020\u0005.\u000A(u001F);
			object u001F2 = \u0020\u0020\u0005.\u000A();
			UnhandledExceptionEventHandler u000A;
			if ((u000A = \u0018\u000D.<>c.\u000A) == null)
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
				u000A = (\u0018\u000D.<>c.\u000A = new UnhandledExceptionEventHandler(\u0018\u000D.<>c.\u001F.\u0007));
			}
			\u001E\u0020\u0005.\u000A(u001F2, u000A);
		}

		// Token: 0x0600185D RID: 6237 RVA: 0x0009C9AC File Offset: 0x0009ABAC
		private static void \u000F(UnhandledExceptionEventArgs \u001F)
		{
			Exception u000A = \u000F\u0004\u000E.\u001F(\u000C\u0020\u0005.\u000A(\u001F));
			\u000D\u0014\u0004.\u000A(\u001B\u0016\u0018.\u000A(), u000A, true);
		}

		// Token: 0x04000994 RID: 2452
		[CompilerGenerated]
		private static string \u001F;

		// Token: 0x04000995 RID: 2453
		[CompilerGenerated]
		private static bool \u000A;

		// Token: 0x04000996 RID: 2454
		internal static string \u0007;

		// Token: 0x04000997 RID: 2455
		internal static string \u001D;

		// Token: 0x04000998 RID: 2456
		internal static string \u0004;

		// Token: 0x04000999 RID: 2457
		internal static string \u0019;

		// Token: 0x0400099A RID: 2458
		internal static string \u0018;

		// Token: 0x0400099B RID: 2459
		[CompilerGenerated]
		private static UIDocument \u0005;

		// Token: 0x0400099C RID: 2460
		[CompilerGenerated]
		private static \u000E\u000E\u000A \u0016;

		// Token: 0x0400099D RID: 2461
		[CompilerGenerated]
		private static PluginInfo \u000B;

		// Token: 0x0400099E RID: 2462
		[CompilerGenerated]
		private static Logger \u0002;
	}
}
