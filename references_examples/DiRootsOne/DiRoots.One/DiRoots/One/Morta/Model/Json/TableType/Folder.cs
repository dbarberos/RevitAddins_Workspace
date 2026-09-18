using System;

namespace DiRoots.One.Morta.Model.Json.TableType
{
	// Token: 0x020001C9 RID: 457
	[Serializable]
	public class Folder
	{
		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x0600113D RID: 4413 RVA: 0x00069A40 File Offset: 0x00067C40
		// (set) Token: 0x0600113E RID: 4414 RVA: 0x00069A54 File Offset: 0x00067C54
		public object childFolders { get; set; }

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x0600113F RID: 4415 RVA: 0x00069A68 File Offset: 0x00067C68
		// (set) Token: 0x06001140 RID: 4416 RVA: 0x00069A7C File Offset: 0x00067C7C
		public string id { get; set; }

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06001141 RID: 4417 RVA: 0x00069A90 File Offset: 0x00067C90
		// (set) Token: 0x06001142 RID: 4418 RVA: 0x00069AA4 File Offset: 0x00067CA4
		public int layer { get; set; }

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06001143 RID: 4419 RVA: 0x00069AB8 File Offset: 0x00067CB8
		// (set) Token: 0x06001144 RID: 4420 RVA: 0x00069ACC File Offset: 0x00067CCC
		public string name { get; set; }
	}
}
