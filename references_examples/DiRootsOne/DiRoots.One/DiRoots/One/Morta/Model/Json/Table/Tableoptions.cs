using System;

namespace DiRoots.One.Morta.Model.Json.Table
{
	// Token: 0x020001D4 RID: 468
	[Serializable]
	public class Tableoptions
	{
		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x06001196 RID: 4502 RVA: 0x0006A134 File Offset: 0x00068334
		// (set) Token: 0x06001197 RID: 4503 RVA: 0x0006A148 File Offset: 0x00068348
		public string[] cachedOptions { get; set; }

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06001198 RID: 4504 RVA: 0x0006A15C File Offset: 0x0006835C
		// (set) Token: 0x06001199 RID: 4505 RVA: 0x0006A170 File Offset: 0x00068370
		public string tableId { get; set; }

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x0600119A RID: 4506 RVA: 0x0006A184 File Offset: 0x00068384
		// (set) Token: 0x0600119B RID: 4507 RVA: 0x0006A198 File Offset: 0x00068398
		public string viewId { get; set; }

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x0600119C RID: 4508 RVA: 0x0006A1AC File Offset: 0x000683AC
		// (set) Token: 0x0600119D RID: 4509 RVA: 0x0006A1C0 File Offset: 0x000683C0
		public string columnId { get; set; }
	}
}
