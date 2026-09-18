using System;
using System.Collections.Generic;

namespace DiRoots.One.Morta.Model.Json
{
	// Token: 0x020001C3 RID: 451
	[Serializable]
	public class Detail
	{
		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x060010F7 RID: 4343 RVA: 0x000694C8 File Offset: 0x000676C8
		// (set) Token: 0x060010F8 RID: 4344 RVA: 0x000694DC File Offset: 0x000676DC
		public List<Error> errors { get; set; }

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x060010F9 RID: 4345 RVA: 0x000694F0 File Offset: 0x000676F0
		// (set) Token: 0x060010FA RID: 4346 RVA: 0x00069504 File Offset: 0x00067704
		public string message { get; set; }
	}
}
