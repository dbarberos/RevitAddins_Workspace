using System;

namespace DiRoots.One.Morta.Model.Json
{
	// Token: 0x020001C5 RID: 453
	[Serializable]
	public class ErrorInfo
	{
		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06001101 RID: 4353 RVA: 0x00069590 File Offset: 0x00067790
		// (set) Token: 0x06001102 RID: 4354 RVA: 0x000695A4 File Offset: 0x000677A4
		public string code { get; set; }

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06001103 RID: 4355 RVA: 0x000695B8 File Offset: 0x000677B8
		// (set) Token: 0x06001104 RID: 4356 RVA: 0x000695CC File Offset: 0x000677CC
		public Detail detail { get; set; }
	}
}
