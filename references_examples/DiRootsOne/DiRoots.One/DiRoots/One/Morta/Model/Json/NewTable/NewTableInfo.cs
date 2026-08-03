using System;

namespace DiRoots.One.Morta.Model.Json.NewTable
{
	// Token: 0x020001E0 RID: 480
	[Serializable]
	public class NewTableInfo
	{
		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x0600123C RID: 4668 RVA: 0x0006AE2C File Offset: 0x0006902C
		// (set) Token: 0x0600123D RID: 4669 RVA: 0x0006AE40 File Offset: 0x00069040
		public string projectId { get; set; }

		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x0600123E RID: 4670 RVA: 0x0006AE54 File Offset: 0x00069054
		// (set) Token: 0x0600123F RID: 4671 RVA: 0x0006AE68 File Offset: 0x00069068
		public string name { get; set; }

		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x06001240 RID: 4672 RVA: 0x0006AE7C File Offset: 0x0006907C
		// (set) Token: 0x06001241 RID: 4673 RVA: 0x0006AE90 File Offset: 0x00069090
		public Column[] columns { get; set; }

		// Token: 0x1700054C RID: 1356
		// (get) Token: 0x06001242 RID: 4674 RVA: 0x0006AEA4 File Offset: 0x000690A4
		// (set) Token: 0x06001243 RID: 4675 RVA: 0x0006AEB8 File Offset: 0x000690B8
		public string type { get; set; }
	}
}
