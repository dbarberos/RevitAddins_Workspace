using System;
using DiRoots.One.Morta.Model.Json.Column;

namespace DiRoots.One.Morta.Model.Json.Table
{
	// Token: 0x020001DB RID: 475
	[Serializable]
	public class Column
	{
		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x060011DF RID: 4575 RVA: 0x0006A6E8 File Offset: 0x000688E8
		// (set) Token: 0x060011E0 RID: 4576 RVA: 0x0006A6FC File Offset: 0x000688FC
		public int aggregate { get; set; }

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x060011E1 RID: 4577 RVA: 0x0006A710 File Offset: 0x00068910
		// (set) Token: 0x060011E2 RID: 4578 RVA: 0x0006A724 File Offset: 0x00068924
		public object dateFormat { get; set; }

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x060011E3 RID: 4579 RVA: 0x0006A738 File Offset: 0x00068938
		// (set) Token: 0x060011E4 RID: 4580 RVA: 0x0006A74C File Offset: 0x0006894C
		public int decimalPlaces { get; set; }

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060011E5 RID: 4581 RVA: 0x0006A760 File Offset: 0x00068960
		// (set) Token: 0x060011E6 RID: 4582 RVA: 0x0006A774 File Offset: 0x00068974
		public Description description { get; set; }

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060011E7 RID: 4583 RVA: 0x0006A788 File Offset: 0x00068988
		// (set) Token: 0x060011E8 RID: 4584 RVA: 0x0006A79C File Offset: 0x0006899C
		public bool isIndexed { get; set; }

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x060011E9 RID: 4585 RVA: 0x0006A7B0 File Offset: 0x000689B0
		// (set) Token: 0x060011EA RID: 4586 RVA: 0x0006A7C4 File Offset: 0x000689C4
		public bool isJoined { get; set; }

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x060011EB RID: 4587 RVA: 0x0006A7D8 File Offset: 0x000689D8
		// (set) Token: 0x060011EC RID: 4588 RVA: 0x0006A7EC File Offset: 0x000689EC
		public string kind { get; set; }

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x060011ED RID: 4589 RVA: 0x0006A800 File Offset: 0x00068A00
		// (set) Token: 0x060011EE RID: 4590 RVA: 0x0006A814 File Offset: 0x00068A14
		public string name { get; set; }

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x060011EF RID: 4591 RVA: 0x0006A828 File Offset: 0x00068A28
		// (set) Token: 0x060011F0 RID: 4592 RVA: 0x0006A83C File Offset: 0x00068A3C
		public string publicId { get; set; }

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x060011F1 RID: 4593 RVA: 0x0006A850 File Offset: 0x00068A50
		// (set) Token: 0x060011F2 RID: 4594 RVA: 0x0006A864 File Offset: 0x00068A64
		public object script { get; set; }

		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x060011F3 RID: 4595 RVA: 0x0006A878 File Offset: 0x00068A78
		// (set) Token: 0x060011F4 RID: 4596 RVA: 0x0006A88C File Offset: 0x00068A8C
		public bool scriptEnabled { get; set; }

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x060011F5 RID: 4597 RVA: 0x0006A8A0 File Offset: 0x00068AA0
		// (set) Token: 0x060011F6 RID: 4598 RVA: 0x0006A8B4 File Offset: 0x00068AB4
		public bool thousandSeparator { get; set; }

		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x060011F7 RID: 4599 RVA: 0x0006A8C8 File Offset: 0x00068AC8
		// (set) Token: 0x060011F8 RID: 4600 RVA: 0x0006A8DC File Offset: 0x00068ADC
		public int viewpointSynced { get; set; }

		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x060011F9 RID: 4601 RVA: 0x0006A8F0 File Offset: 0x00068AF0
		// (set) Token: 0x060011FA RID: 4602 RVA: 0x0006A904 File Offset: 0x00068B04
		public int width { get; set; }
	}
}
