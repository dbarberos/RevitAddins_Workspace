using System;
using System.Collections.Generic;

namespace DiRoots.One.Morta.Model.Json.Column
{
	// Token: 0x020001E8 RID: 488
	[Serializable]
	public class Content
	{
		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x0600127F RID: 4735 RVA: 0x0006B4EC File Offset: 0x000696EC
		// (set) Token: 0x06001280 RID: 4736 RVA: 0x0006B500 File Offset: 0x00069700
		public List<Block> blocks { get; set; } = new List<Block>();

		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x06001281 RID: 4737 RVA: 0x0006B514 File Offset: 0x00069714
		// (set) Token: 0x06001282 RID: 4738 RVA: 0x0006B528 File Offset: 0x00069728
		public EntityMap entityMap { get; set; } = new EntityMap();
	}
}
