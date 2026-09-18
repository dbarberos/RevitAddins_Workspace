using System;
using System.Runtime.CompilerServices;
using ProSheets;
using ProSheets.Models;

namespace DiRoots.ProSheets.Models
{
	// Token: 0x0200004B RID: 75
	public abstract class AbstractExpression
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060002FC RID: 764 RVA: 0x000120F4 File Offset: 0x000102F4
		// (set) Token: 0x060002FD RID: 765 RVA: 0x00012108 File Offset: 0x00010308
		public SelectionParameter Parameter { get; set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060002FE RID: 766 RVA: 0x0001211C File Offset: 0x0001031C
		// (set) Token: 0x060002FF RID: 767 RVA: 0x00012130 File Offset: 0x00010330
		public SheetInfo SheetInstance { get; set; }

		// Token: 0x06000300 RID: 768
		public abstract bool Evaluate(Context context);

		// Token: 0x04000166 RID: 358
		[CompilerGenerated]
		private SelectionParameter \u000C;

		// Token: 0x04000167 RID: 359
		[CompilerGenerated]
		private SheetInfo \u0018;
	}
}
