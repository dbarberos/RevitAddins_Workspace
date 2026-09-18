using System;

namespace DiRoots.One.Morta.Model.Json.Column
{
	// Token: 0x020001E5 RID: 485
	[Serializable]
	public class CreatedColumn
	{
		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x0600126B RID: 4715 RVA: 0x0006B1D8 File Offset: 0x000693D8
		// (set) Token: 0x0600126C RID: 4716 RVA: 0x0006B1EC File Offset: 0x000693EC
		public Metadata metadata { get; set; }

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x0600126D RID: 4717 RVA: 0x0006B200 File Offset: 0x00069400
		// (set) Token: 0x0600126E RID: 4718 RVA: 0x0006B214 File Offset: 0x00069414
		public Data data { get; set; }
	}
}
