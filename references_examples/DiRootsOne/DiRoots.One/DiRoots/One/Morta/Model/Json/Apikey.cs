using System;

namespace DiRoots.One.Morta.Model.Json
{
	// Token: 0x020001C1 RID: 449
	[Serializable]
	public class Apikey
	{
		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x060010E7 RID: 4327 RVA: 0x00069388 File Offset: 0x00067588
		// (set) Token: 0x060010E8 RID: 4328 RVA: 0x0006939C File Offset: 0x0006759C
		public string hash { get; set; }

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x060010E9 RID: 4329 RVA: 0x000693B0 File Offset: 0x000675B0
		// (set) Token: 0x060010EA RID: 4330 RVA: 0x000693C4 File Offset: 0x000675C4
		public string name { get; set; }

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x060010EB RID: 4331 RVA: 0x000693D8 File Offset: 0x000675D8
		// (set) Token: 0x060010EC RID: 4332 RVA: 0x000693EC File Offset: 0x000675EC
		public string prefix { get; set; }

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x060010ED RID: 4333 RVA: 0x00069400 File Offset: 0x00067600
		// (set) Token: 0x060010EE RID: 4334 RVA: 0x00069414 File Offset: 0x00067614
		public string publicId { get; set; }
	}
}
