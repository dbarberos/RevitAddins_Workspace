using System;

namespace DiRoots.One.Morta.Model.Json.TableType
{
	// Token: 0x020001C7 RID: 455
	[Serializable]
	public class ProjectFolder
	{
		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06001107 RID: 4359 RVA: 0x00069608 File Offset: 0x00067808
		// (set) Token: 0x06001108 RID: 4360 RVA: 0x0006961C File Offset: 0x0006781C
		public Data data { get; set; }

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06001109 RID: 4361 RVA: 0x00069630 File Offset: 0x00067830
		// (set) Token: 0x0600110A RID: 4362 RVA: 0x00069644 File Offset: 0x00067844
		public Metadata metadata { get; set; }
	}
}
