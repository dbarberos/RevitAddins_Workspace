using System;

namespace DiRoots.One.Morta.Model.Json.Table
{
	// Token: 0x020001D7 RID: 471
	[Serializable]
	public class Metadata
	{
		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x060011AB RID: 4523 RVA: 0x0006A2D8 File Offset: 0x000684D8
		// (set) Token: 0x060011AC RID: 4524 RVA: 0x0006A2EC File Offset: 0x000684EC
		public string nextPageToken { get; set; }

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x060011AD RID: 4525 RVA: 0x0006A300 File Offset: 0x00068500
		// (set) Token: 0x060011AE RID: 4526 RVA: 0x0006A314 File Offset: 0x00068514
		public int size { get; set; }

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x060011AF RID: 4527 RVA: 0x0006A328 File Offset: 0x00068528
		// (set) Token: 0x060011B0 RID: 4528 RVA: 0x0006A33C File Offset: 0x0006853C
		public int total { get; set; }
	}
}
