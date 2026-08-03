using System;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Logs;

namespace A
{
	// Token: 0x0200008D RID: 141
	internal static class \u001A\u001D
	{
		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x0600062C RID: 1580 RVA: 0x00022A4C File Offset: 0x00020C4C
		// (set) Token: 0x0600062D RID: 1581 RVA: 0x00022A60 File Offset: 0x00020C60
		internal static bool IsProgressClosedIntermediately { get; set; }

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x0600062E RID: 1582 RVA: 0x00022A74 File Offset: 0x00020C74
		// (set) Token: 0x0600062F RID: 1583 RVA: 0x00022A88 File Offset: 0x00020C88
		internal static bool IsCacheCleared { get; set; } = true;

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000630 RID: 1584 RVA: 0x00022A9C File Offset: 0x00020C9C
		// (set) Token: 0x06000631 RID: 1585 RVA: 0x00022AB0 File Offset: 0x00020CB0
		internal static bool IsHandleExpanded { get; set; }

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000632 RID: 1586 RVA: 0x00022AC4 File Offset: 0x00020CC4
		// (set) Token: 0x06000633 RID: 1587 RVA: 0x00022AD8 File Offset: 0x00020CD8
		internal static Logger LoggerInstance { get; set; } = \u0008\u0007\u001D.\u000A("DiRootsOne", \u001B\u0007\u001D.\u000A());

		// Token: 0x04000250 RID: 592
		[CompilerGenerated]
		private static bool \u001F;

		// Token: 0x04000251 RID: 593
		[CompilerGenerated]
		private static bool \u000A;

		// Token: 0x04000252 RID: 594
		[CompilerGenerated]
		private static bool \u0007;

		// Token: 0x04000253 RID: 595
		[CompilerGenerated]
		private static Logger \u001D;
	}
}
