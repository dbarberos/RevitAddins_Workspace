using System;

namespace DiRoots.One.Morta.Model.Json.TableType
{
	// Token: 0x020001CB RID: 459
	[Serializable]
	public class ProjectList
	{
		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06001147 RID: 4423 RVA: 0x00069B08 File Offset: 0x00067D08
		// (set) Token: 0x06001148 RID: 4424 RVA: 0x00069B1C File Offset: 0x00067D1C
		public DateTime createdAt { get; set; }

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06001149 RID: 4425 RVA: 0x00069B30 File Offset: 0x00067D30
		// (set) Token: 0x0600114A RID: 4426 RVA: 0x00069B44 File Offset: 0x00067D44
		public bool favourite { get; set; }

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x0600114B RID: 4427 RVA: 0x00069B58 File Offset: 0x00067D58
		// (set) Token: 0x0600114C RID: 4428 RVA: 0x00069B6C File Offset: 0x00067D6C
		public string projectRole { get; set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x0600114D RID: 4429 RVA: 0x00069B80 File Offset: 0x00067D80
		// (set) Token: 0x0600114E RID: 4430 RVA: 0x00069B94 File Offset: 0x00067D94
		public DateTime updatedAt { get; set; }

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x0600114F RID: 4431 RVA: 0x00069BA8 File Offset: 0x00067DA8
		// (set) Token: 0x06001150 RID: 4432 RVA: 0x00069BBC File Offset: 0x00067DBC
		public User user { get; set; }
	}
}
