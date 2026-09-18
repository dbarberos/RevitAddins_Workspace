using System;
using System.Collections.Generic;

namespace DiRoots.One.Morta.Model.Json.Column
{
	// Token: 0x020001E3 RID: 483
	[Serializable]
	public class KindOptions
	{
		// Token: 0x1700055C RID: 1372
		// (get) Token: 0x06001265 RID: 4709 RVA: 0x0006B160 File Offset: 0x00069360
		// (set) Token: 0x06001266 RID: 4710 RVA: 0x0006B174 File Offset: 0x00069374
		public List<string> manualOptions { get; set; }

		// Token: 0x1700055D RID: 1373
		// (get) Token: 0x06001267 RID: 4711 RVA: 0x0006B188 File Offset: 0x00069388
		// (set) Token: 0x06001268 RID: 4712 RVA: 0x0006B19C File Offset: 0x0006939C
		public TableOptions tableOptions { get; set; }
	}
}
