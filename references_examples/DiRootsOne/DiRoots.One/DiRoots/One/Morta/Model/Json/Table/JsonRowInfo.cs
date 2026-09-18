using System;
using System.Collections.Generic;

namespace DiRoots.One.Morta.Model.Json.Table
{
	// Token: 0x020001D8 RID: 472
	[Serializable]
	public class JsonRowInfo
	{
		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x060011B2 RID: 4530 RVA: 0x0006A364 File Offset: 0x00068564
		// (set) Token: 0x060011B3 RID: 4531 RVA: 0x0006A378 File Offset: 0x00068578
		public List<Datum> data { get; set; }

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x060011B4 RID: 4532 RVA: 0x0006A38C File Offset: 0x0006858C
		// (set) Token: 0x060011B5 RID: 4533 RVA: 0x0006A3A0 File Offset: 0x000685A0
		public Metadata metadata { get; set; }
	}
}
