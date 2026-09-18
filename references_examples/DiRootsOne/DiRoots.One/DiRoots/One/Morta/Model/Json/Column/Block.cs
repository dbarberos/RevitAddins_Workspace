using System;
using System.Collections.Generic;

namespace DiRoots.One.Morta.Model.Json.Column
{
	// Token: 0x020001E9 RID: 489
	[Serializable]
	public class Block
	{
		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x06001284 RID: 4740 RVA: 0x0006B57C File Offset: 0x0006977C
		// (set) Token: 0x06001285 RID: 4741 RVA: 0x0006B590 File Offset: 0x00069790
		public string key { get; set; }

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x06001286 RID: 4742 RVA: 0x0006B5A4 File Offset: 0x000697A4
		// (set) Token: 0x06001287 RID: 4743 RVA: 0x0006B5B8 File Offset: 0x000697B8
		public string text { get; set; }

		// Token: 0x17000569 RID: 1385
		// (get) Token: 0x06001288 RID: 4744 RVA: 0x0006B5CC File Offset: 0x000697CC
		// (set) Token: 0x06001289 RID: 4745 RVA: 0x0006B5E0 File Offset: 0x000697E0
		public string type { get; set; } = "unstyled";

		// Token: 0x1700056A RID: 1386
		// (get) Token: 0x0600128A RID: 4746 RVA: 0x0006B5F4 File Offset: 0x000697F4
		// (set) Token: 0x0600128B RID: 4747 RVA: 0x0006B608 File Offset: 0x00069808
		public int depth { get; set; }

		// Token: 0x1700056B RID: 1387
		// (get) Token: 0x0600128C RID: 4748 RVA: 0x0006B61C File Offset: 0x0006981C
		// (set) Token: 0x0600128D RID: 4749 RVA: 0x0006B630 File Offset: 0x00069830
		public List<object> inlineStyleRanges { get; set; } = new List<object>();

		// Token: 0x1700056C RID: 1388
		// (get) Token: 0x0600128E RID: 4750 RVA: 0x0006B644 File Offset: 0x00069844
		// (set) Token: 0x0600128F RID: 4751 RVA: 0x0006B658 File Offset: 0x00069858
		public List<object> entityRanges { get; set; } = new List<object>();

		// Token: 0x1700056D RID: 1389
		// (get) Token: 0x06001290 RID: 4752 RVA: 0x0006B66C File Offset: 0x0006986C
		// (set) Token: 0x06001291 RID: 4753 RVA: 0x0006B680 File Offset: 0x00069880
		public ColumnData data { get; set; } = new ColumnData();
	}
}
