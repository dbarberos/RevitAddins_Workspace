using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DiRoots.One.TGDatabaseLayer;

namespace DiRoots.One.TableGen.Models
{
	// Token: 0x02000185 RID: 389
	public class WorkSheetNamedRegion
	{
		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06000E75 RID: 3701 RVA: 0x0005BF0C File Offset: 0x0005A10C
		// (set) Token: 0x06000E76 RID: 3702 RVA: 0x0005BF20 File Offset: 0x0005A120
		public string SheetName { get; set; }

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06000E77 RID: 3703 RVA: 0x0005BF34 File Offset: 0x0005A134
		// (set) Token: 0x06000E78 RID: 3704 RVA: 0x0005BF48 File Offset: 0x0005A148
		public List<NamedRangeInfo> NamedRanges { get; set; }

		// Token: 0x040005B3 RID: 1459
		[CompilerGenerated]
		private string \u001F;

		// Token: 0x040005B4 RID: 1460
		[CompilerGenerated]
		private List<NamedRangeInfo> \u000A;
	}
}
