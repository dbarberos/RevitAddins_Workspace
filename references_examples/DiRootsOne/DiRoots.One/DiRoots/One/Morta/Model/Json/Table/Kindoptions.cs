using System;

namespace DiRoots.One.Morta.Model.Json.Table
{
	// Token: 0x020001D3 RID: 467
	[Serializable]
	public class Kindoptions
	{
		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x06001191 RID: 4497 RVA: 0x0006A0D0 File Offset: 0x000682D0
		// (set) Token: 0x06001192 RID: 4498 RVA: 0x0006A0E4 File Offset: 0x000682E4
		public string[] manualOptions { get; set; }

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x06001193 RID: 4499 RVA: 0x0006A0F8 File Offset: 0x000682F8
		// (set) Token: 0x06001194 RID: 4500 RVA: 0x0006A10C File Offset: 0x0006830C
		public Tableoptions tableOptions { get; set; }
	}
}
