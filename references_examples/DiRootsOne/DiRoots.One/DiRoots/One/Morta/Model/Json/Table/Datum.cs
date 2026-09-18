using System;
using System.Collections.Generic;

namespace DiRoots.One.Morta.Model.Json.Table
{
	// Token: 0x020001D6 RID: 470
	[Serializable]
	public class Datum
	{
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x060011A0 RID: 4512 RVA: 0x0006A1FC File Offset: 0x000683FC
		// (set) Token: 0x060011A1 RID: 4513 RVA: 0x0006A210 File Offset: 0x00068410
		public DateTime createdAt { get; set; }

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x060011A2 RID: 4514 RVA: 0x0006A224 File Offset: 0x00068424
		// (set) Token: 0x060011A3 RID: 4515 RVA: 0x0006A238 File Offset: 0x00068438
		public string publicId { get; set; }

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x060011A4 RID: 4516 RVA: 0x0006A24C File Offset: 0x0006844C
		// (set) Token: 0x060011A5 RID: 4517 RVA: 0x0006A260 File Offset: 0x00068460
		public Dictionary<string, object> rowData { get; set; }

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x060011A6 RID: 4518 RVA: 0x0006A274 File Offset: 0x00068474
		// (set) Token: 0x060011A7 RID: 4519 RVA: 0x0006A288 File Offset: 0x00068488
		public double sortOrder { get; set; }

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x060011A8 RID: 4520 RVA: 0x0006A29C File Offset: 0x0006849C
		// (set) Token: 0x060011A9 RID: 4521 RVA: 0x0006A2B0 File Offset: 0x000684B0
		public DateTime updatedAt { get; set; }
	}
}
