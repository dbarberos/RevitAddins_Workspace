using System;

namespace DiRoots.One.Morta.Model.Json.TableType
{
	// Token: 0x020001CC RID: 460
	[Serializable]
	public class User
	{
		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06001152 RID: 4434 RVA: 0x00069BE4 File Offset: 0x00067DE4
		// (set) Token: 0x06001153 RID: 4435 RVA: 0x00069BF8 File Offset: 0x00067DF8
		public string email { get; set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06001154 RID: 4436 RVA: 0x00069C0C File Offset: 0x00067E0C
		// (set) Token: 0x06001155 RID: 4437 RVA: 0x00069C20 File Offset: 0x00067E20
		public string firebaseUserId { get; set; }

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06001156 RID: 4438 RVA: 0x00069C34 File Offset: 0x00067E34
		// (set) Token: 0x06001157 RID: 4439 RVA: 0x00069C48 File Offset: 0x00067E48
		public string name { get; set; }

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06001158 RID: 4440 RVA: 0x00069C5C File Offset: 0x00067E5C
		// (set) Token: 0x06001159 RID: 4441 RVA: 0x00069C70 File Offset: 0x00067E70
		public string publicId { get; set; }
	}
}
