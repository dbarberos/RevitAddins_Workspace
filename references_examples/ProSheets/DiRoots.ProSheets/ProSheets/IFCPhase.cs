using System;

namespace ProSheets
{
	// Token: 0x02000072 RID: 114
	[Serializable]
	public class IFCPhase
	{
		// Token: 0x1700029F RID: 671
		// (get) Token: 0x060006AC RID: 1708 RVA: 0x00026428 File Offset: 0x00024628
		// (set) Token: 0x060006AD RID: 1709 RVA: 0x0002643C File Offset: 0x0002463C
		public long id { get; set; } = -1L;

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x060006AE RID: 1710 RVA: 0x00026450 File Offset: 0x00024650
		// (set) Token: 0x060006AF RID: 1711 RVA: 0x00026464 File Offset: 0x00024664
		public string Text { get; set; }
	}
}
