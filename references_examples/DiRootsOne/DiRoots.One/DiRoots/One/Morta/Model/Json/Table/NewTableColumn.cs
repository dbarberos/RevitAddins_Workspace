using System;

namespace DiRoots.One.Morta.Model.Json.Table
{
	// Token: 0x020001D2 RID: 466
	[Serializable]
	public class NewTableColumn
	{
		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06001180 RID: 4480 RVA: 0x00069F7C File Offset: 0x0006817C
		// (set) Token: 0x06001181 RID: 4481 RVA: 0x00069F90 File Offset: 0x00068190
		public string publicId { get; set; }

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06001182 RID: 4482 RVA: 0x00069FA4 File Offset: 0x000681A4
		// (set) Token: 0x06001183 RID: 4483 RVA: 0x00069FB8 File Offset: 0x000681B8
		public string name { get; set; }

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06001184 RID: 4484 RVA: 0x00069FCC File Offset: 0x000681CC
		// (set) Token: 0x06001185 RID: 4485 RVA: 0x00069FE0 File Offset: 0x000681E0
		public string kind { get; set; }

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06001186 RID: 4486 RVA: 0x00069FF4 File Offset: 0x000681F4
		// (set) Token: 0x06001187 RID: 4487 RVA: 0x0006A008 File Offset: 0x00068208
		public Kindoptions kindOptions { get; set; }

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06001188 RID: 4488 RVA: 0x0006A01C File Offset: 0x0006821C
		// (set) Token: 0x06001189 RID: 4489 RVA: 0x0006A030 File Offset: 0x00068230
		public Description description { get; set; }

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x0600118A RID: 4490 RVA: 0x0006A044 File Offset: 0x00068244
		// (set) Token: 0x0600118B RID: 4491 RVA: 0x0006A058 File Offset: 0x00068258
		public int width { get; set; }

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x0600118C RID: 4492 RVA: 0x0006A06C File Offset: 0x0006826C
		// (set) Token: 0x0600118D RID: 4493 RVA: 0x0006A080 File Offset: 0x00068280
		public bool isIndexed { get; set; }

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x0600118E RID: 4494 RVA: 0x0006A094 File Offset: 0x00068294
		// (set) Token: 0x0600118F RID: 4495 RVA: 0x0006A0A8 File Offset: 0x000682A8
		public string alterOptions { get; set; }
	}
}
