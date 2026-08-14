using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Models;
using DiRoots.One.TGDatabaseLayer;

namespace A
{
	// Token: 0x020000D8 RID: 216
	internal static class \u0011\u0019
	{
		// Token: 0x06000827 RID: 2087 RVA: 0x0002E80C File Offset: 0x0002CA0C
		// Note: this type is marked as 'beforefieldinit'.
		static \u0011\u0019()
		{
			List<int> list = \u0010\u0011\u001D.\u000A(4);
			\u0020\u000B\u001D.\u000A(list, 75);
			\u0020\u000B\u001D.\u000A(list, 150);
			\u0020\u000B\u001D.\u000A(list, 300);
			\u0020\u000B\u001D.\u000A(list, 600);
			\u0011\u0019.\u0019 = list;
			\u0011\u0019.\u0018 = Enumerable.ToList<EnumInfo>(Enumerable.Select<PageOptions, EnumInfo>(Enumerable.Cast<PageOptions>(\u000D\u0011\u001D.\u000A(\u001E\u0011\u000A.\u000A(\u0007\u0004\u000E.\u001F()))), new Func<PageOptions, EnumInfo>(\u0011\u0019.<>c.\u001F.\u000A)));
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000828 RID: 2088 RVA: 0x0002E894 File Offset: 0x0002CA94
		// (set) Token: 0x06000829 RID: 2089 RVA: 0x0002E8A8 File Offset: 0x0002CAA8
		internal static bool IsMainWindowClosed { get; set; } = true;

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x0600082A RID: 2090 RVA: 0x0002E8BC File Offset: 0x0002CABC
		// (set) Token: 0x0600082B RID: 2091 RVA: 0x0002E8D0 File Offset: 0x0002CAD0
		internal static bool IsAutoSync { get; set; }

		// Token: 0x0400033E RID: 830
		[CompilerGenerated]
		private static bool \u001F;

		// Token: 0x0400033F RID: 831
		[CompilerGenerated]
		private static bool \u000A;

		// Token: 0x04000340 RID: 832
		internal static string \u0007;

		// Token: 0x04000341 RID: 833
		internal static string \u001D;

		// Token: 0x04000342 RID: 834
		internal static int \u0004;

		// Token: 0x04000343 RID: 835
		internal static readonly List<int> \u0019;

		// Token: 0x04000344 RID: 836
		internal static readonly List<EnumInfo> \u0018;

		// Token: 0x04000345 RID: 837
		internal static string \u0005;
	}
}
