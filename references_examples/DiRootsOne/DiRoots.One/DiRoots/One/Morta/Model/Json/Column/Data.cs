using System;

namespace DiRoots.One.Morta.Model.Json.Column
{
	// Token: 0x020001E2 RID: 482
	[Serializable]
	public class Data
	{
		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x0600124E RID: 4686 RVA: 0x0006AF94 File Offset: 0x00069194
		// (set) Token: 0x0600124F RID: 4687 RVA: 0x0006AFA8 File Offset: 0x000691A8
		public string publicId { get; set; }

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x06001250 RID: 4688 RVA: 0x0006AFBC File Offset: 0x000691BC
		// (set) Token: 0x06001251 RID: 4689 RVA: 0x0006AFD0 File Offset: 0x000691D0
		public string name { get; set; }

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x06001252 RID: 4690 RVA: 0x0006AFE4 File Offset: 0x000691E4
		// (set) Token: 0x06001253 RID: 4691 RVA: 0x0006AFF8 File Offset: 0x000691F8
		public string kind { get; set; }

		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x06001254 RID: 4692 RVA: 0x0006B00C File Offset: 0x0006920C
		// (set) Token: 0x06001255 RID: 4693 RVA: 0x0006B020 File Offset: 0x00069220
		public KindOptions kindOptions { get; set; }

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x06001256 RID: 4694 RVA: 0x0006B034 File Offset: 0x00069234
		// (set) Token: 0x06001257 RID: 4695 RVA: 0x0006B048 File Offset: 0x00069248
		public Description description { get; set; }

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x06001258 RID: 4696 RVA: 0x0006B05C File Offset: 0x0006925C
		// (set) Token: 0x06001259 RID: 4697 RVA: 0x0006B070 File Offset: 0x00069270
		public int width { get; set; }

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x0600125A RID: 4698 RVA: 0x0006B084 File Offset: 0x00069284
		// (set) Token: 0x0600125B RID: 4699 RVA: 0x0006B098 File Offset: 0x00069298
		public bool isIndexed { get; set; }

		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x0600125C RID: 4700 RVA: 0x0006B0AC File Offset: 0x000692AC
		// (set) Token: 0x0600125D RID: 4701 RVA: 0x0006B0C0 File Offset: 0x000692C0
		public string alterOptions { get; set; }

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x0600125E RID: 4702 RVA: 0x0006B0D4 File Offset: 0x000692D4
		// (set) Token: 0x0600125F RID: 4703 RVA: 0x0006B0E8 File Offset: 0x000692E8
		public int sortOrder { get; set; }

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x06001260 RID: 4704 RVA: 0x0006B0FC File Offset: 0x000692FC
		// (set) Token: 0x06001261 RID: 4705 RVA: 0x0006B110 File Offset: 0x00069310
		public bool locked { get; set; }

		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x06001262 RID: 4706 RVA: 0x0006B124 File Offset: 0x00069324
		// (set) Token: 0x06001263 RID: 4707 RVA: 0x0006B138 File Offset: 0x00069338
		public bool required { get; set; }
	}
}
