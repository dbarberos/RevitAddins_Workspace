using System;

namespace DiRoots.One.Morta.Model.Json.Project
{
	// Token: 0x020001DC RID: 476
	[Serializable]
	public class ProjectInfo : jsonBaseClass
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x060011FC RID: 4604 RVA: 0x0006A92C File Offset: 0x00068B2C
		// (set) Token: 0x060011FD RID: 4605 RVA: 0x0006A940 File Offset: 0x00068B40
		public Datum[] data { get; set; }

		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x060011FE RID: 4606 RVA: 0x0006A954 File Offset: 0x00068B54
		// (set) Token: 0x060011FF RID: 4607 RVA: 0x0006A968 File Offset: 0x00068B68
		public jsonBaseClass.Metadata metadata { get; set; }
	}
}
