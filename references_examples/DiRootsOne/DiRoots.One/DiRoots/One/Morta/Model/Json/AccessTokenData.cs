using System;

namespace DiRoots.One.Morta.Model.Json
{
	// Token: 0x020001BF RID: 447
	[Serializable]
	public class AccessTokenData : jsonBaseClass
	{
		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x060010A9 RID: 4265 RVA: 0x00068EB0 File Offset: 0x000670B0
		// (set) Token: 0x060010AA RID: 4266 RVA: 0x00068EC4 File Offset: 0x000670C4
		public Data data { get; set; }

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x060010AB RID: 4267 RVA: 0x00068ED8 File Offset: 0x000670D8
		// (set) Token: 0x060010AC RID: 4268 RVA: 0x00068EEC File Offset: 0x000670EC
		public jsonBaseClass.Metadata metadata { get; set; }
	}
}
