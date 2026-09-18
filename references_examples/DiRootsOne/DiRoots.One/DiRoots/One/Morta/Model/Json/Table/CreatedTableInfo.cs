using System;

namespace DiRoots.One.Morta.Model.Json.Table
{
	// Token: 0x020001D0 RID: 464
	[Serializable]
	public class CreatedTableInfo : jsonBaseClass
	{
		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06001164 RID: 4452 RVA: 0x00069D4C File Offset: 0x00067F4C
		// (set) Token: 0x06001165 RID: 4453 RVA: 0x00069D60 File Offset: 0x00067F60
		public jsonBaseClass.Metadata metadata { get; set; }

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06001166 RID: 4454 RVA: 0x00069D74 File Offset: 0x00067F74
		// (set) Token: 0x06001167 RID: 4455 RVA: 0x00069D88 File Offset: 0x00067F88
		public Data data { get; set; }
	}
}
