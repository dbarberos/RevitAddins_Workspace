using System;
using System.Collections.Generic;

namespace DiRoots.One.Morta.Model.Json
{
	// Token: 0x020001C4 RID: 452
	[Serializable]
	public class Error
	{
		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x060010FC RID: 4348 RVA: 0x0006952C File Offset: 0x0006772C
		// (set) Token: 0x060010FD RID: 4349 RVA: 0x00069540 File Offset: 0x00067740
		public object attribute { get; set; }

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x060010FE RID: 4350 RVA: 0x00069554 File Offset: 0x00067754
		// (set) Token: 0x060010FF RID: 4351 RVA: 0x00069568 File Offset: 0x00067768
		public List<string> messages { get; set; }
	}
}
