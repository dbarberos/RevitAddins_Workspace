using System;
using System.Collections.Generic;
using A;

namespace DiRoots.One.TGDatabaseLayer
{
	// Token: 0x02000118 RID: 280
	[Serializable]
	public class SheetAndNamedRange
	{
		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06000A1A RID: 2586 RVA: 0x00042D78 File Offset: 0x00040F78
		// (set) Token: 0x06000A1B RID: 2587 RVA: 0x00042D8C File Offset: 0x00040F8C
		public string Name { get; set; }

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06000A1C RID: 2588 RVA: 0x00042DA0 File Offset: 0x00040FA0
		// (set) Token: 0x06000A1D RID: 2589 RVA: 0x00042DB4 File Offset: 0x00040FB4
		public List<NamedRangeInfo> Ranges { get; set; }

		// Token: 0x06000A1E RID: 2590 RVA: 0x00042DC8 File Offset: 0x00040FC8
		public static SheetAndNamedRange GetDefault()
		{
			SheetAndNamedRange sheetAndNamedRange = \u0018\u0008\u0004.\u000A();
			\u0019\u0008\u0004.\u000A(sheetAndNamedRange, "N/A");
			List<NamedRangeInfo> list = \u0004\u0008\u0004.\u000A(1);
			NamedRangeInfo namedRangeInfo = \u001F\u001E\u001D.\u000A();
			\u0009\u0011\u001D.\u000A(namedRangeInfo, "N/A");
			\u000C\u0011\u001D.\u000A(list, namedRangeInfo);
			\u001D\u0008\u0004.\u000A(sheetAndNamedRange, list);
			return sheetAndNamedRange;
		}
	}
}
