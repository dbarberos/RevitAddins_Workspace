using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace A
{
	// Token: 0x0200008E RID: 142
	internal static class \u000C\u001D
	{
		// Token: 0x06000634 RID: 1588 RVA: 0x00022AEC File Offset: 0x00020CEC
		// Note: this type is marked as 'beforefieldinit'.
		static \u000C\u001D()
		{
			List<ViewDetailLevel> u001F = \u0020\u0007\u001D.\u000A();
			\u0017\u000B\u0007.\u000A(u001F, 1);
			\u0017\u000B\u0007.\u000A(u001F, 2);
			\u0017\u000B\u0007.\u000A(u001F, 3);
			\u000C\u001D.\u0016 = \u001E\u0007\u001D.\u000A(u001F);
			\u000C\u001D.\u000B = \u0011\u0007\u001D.\u000A(\u0017\u0001\u0007.\u000A());
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000635 RID: 1589 RVA: 0x00022B64 File Offset: 0x00020D64
		// (set) Token: 0x06000636 RID: 1590 RVA: 0x00022B78 File Offset: 0x00020D78
		internal static string PluginName { get; set; } = "";

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000637 RID: 1591 RVA: 0x00022B8C File Offset: 0x00020D8C
		// (set) Token: 0x06000638 RID: 1592 RVA: 0x00022BA0 File Offset: 0x00020DA0
		internal static UIControlledApplication ControlledUIApp { get; set; }

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000639 RID: 1593 RVA: 0x00022BB4 File Offset: 0x00020DB4
		// (set) Token: 0x0600063A RID: 1594 RVA: 0x00022BC8 File Offset: 0x00020DC8
		internal static UIApplication UIApp { get; set; }

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x0600063B RID: 1595 RVA: 0x00022BDC File Offset: 0x00020DDC
		internal static UIDocument \u0002
		{
			get
			{
				return \u0020\u0013\u000A.\u000A(\u0014\u0010\u0007.\u000A());
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x0600063C RID: 1596 RVA: 0x00022BF8 File Offset: 0x00020DF8
		internal static Document \u0006
		{
			get
			{
				UIDocument uidocument = \u0020\u0013\u000A.\u000A(\u0014\u0010\u0007.\u000A());
				if (uidocument == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u001D.get_\u0006()).MethodHandle;
					}
					return null;
				}
				return \u0011\u0020\u000A.\u001D(uidocument);
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x00022C34 File Offset: 0x00020E34
		internal static double \u000F
		{
			get
			{
				return \u0013\u0007\u001D.\u000A(\u001A\u0007\u001D.\u000A(\u0014\u0010\u0007.\u000A()));
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x00022C58 File Offset: 0x00020E58
		// (set) Token: 0x0600063F RID: 1599 RVA: 0x00022C6C File Offset: 0x00020E6C
		internal static string FeatureFolderPath { get; private set; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x00022C80 File Offset: 0x00020E80
		// (set) Token: 0x06000641 RID: 1601 RVA: 0x00022C94 File Offset: 0x00020E94
		internal static string FeatureName { get; private set; }

		// Token: 0x06000642 RID: 1602 RVA: 0x00022CA8 File Offset: 0x00020EA8
		internal static void \u0012(UIControlledApplication \u001F, string \u000A)
		{
			\u0001\u0007\u001D.\u000A(\u001F);
			if (\u001A\u0006\u0007.\u000A(\u0015\u0007\u001D.\u000A()))
			{
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u001D.\u0012(UIControlledApplication, string)).MethodHandle;
				}
				\u000C\u0007\u001D.\u000A(\u000A);
			}
		}

		// Token: 0x04000254 RID: 596
		[CompilerGenerated]
		private static string \u001F;

		// Token: 0x04000255 RID: 597
		[CompilerGenerated]
		private static UIControlledApplication \u000A;

		// Token: 0x04000256 RID: 598
		[CompilerGenerated]
		private static UIApplication \u0007;

		// Token: 0x04000257 RID: 599
		[CompilerGenerated]
		private static string \u001D;

		// Token: 0x04000258 RID: 600
		[CompilerGenerated]
		private static string \u0004;

		// Token: 0x04000259 RID: 601
		internal static readonly string \u0019 = \u0014\u0007\u001D.\u000A();

		// Token: 0x0400025A RID: 602
		internal static readonly string \u0018 = \u0011\u001A\u0007.\u000A();

		// Token: 0x0400025B RID: 603
		internal static readonly string \u0005 = \u0017\u0007\u001D.\u000A();

		// Token: 0x0400025C RID: 604
		internal static readonly ReadOnlyCollection<ViewDetailLevel> \u0016;

		// Token: 0x0400025D RID: 605
		internal static readonly ReadOnlyCollection<char> \u000B;
	}
}
