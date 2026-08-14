using System;
using System.Collections.Generic;

namespace DiRoots.One.Morta.Model.Json.Column
{
	// Token: 0x020001E6 RID: 486
	[Serializable]
	public class TableOptions
	{
		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x06001270 RID: 4720 RVA: 0x0006B23C File Offset: 0x0006943C
		// (set) Token: 0x06001271 RID: 4721 RVA: 0x0006B250 File Offset: 0x00069450
		public List<string> cachedOptions { get; set; }

		// Token: 0x17000561 RID: 1377
		// (get) Token: 0x06001272 RID: 4722 RVA: 0x0006B264 File Offset: 0x00069464
		// (set) Token: 0x06001273 RID: 4723 RVA: 0x0006B278 File Offset: 0x00069478
		public string tableId { get; set; }

		// Token: 0x17000562 RID: 1378
		// (get) Token: 0x06001274 RID: 4724 RVA: 0x0006B28C File Offset: 0x0006948C
		// (set) Token: 0x06001275 RID: 4725 RVA: 0x0006B2A0 File Offset: 0x000694A0
		public string viewId { get; set; }

		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x06001276 RID: 4726 RVA: 0x0006B2B4 File Offset: 0x000694B4
		// (set) Token: 0x06001277 RID: 4727 RVA: 0x0006B2C8 File Offset: 0x000694C8
		public string columnId { get; set; }
	}
}
