using System;

namespace DiRoots.One.Morta.Model.Json.Table
{
	// Token: 0x020001D1 RID: 465
	[Serializable]
	public class Data
	{
		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06001169 RID: 4457 RVA: 0x00069DB0 File Offset: 0x00067FB0
		// (set) Token: 0x0600116A RID: 4458 RVA: 0x00069DC4 File Offset: 0x00067FC4
		public string publicId { get; set; }

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x0600116B RID: 4459 RVA: 0x00069DD8 File Offset: 0x00067FD8
		// (set) Token: 0x0600116C RID: 4460 RVA: 0x00069DEC File Offset: 0x00067FEC
		public string name { get; set; }

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x0600116D RID: 4461 RVA: 0x00069E00 File Offset: 0x00068000
		// (set) Token: 0x0600116E RID: 4462 RVA: 0x00069E14 File Offset: 0x00068014
		public string[] variables { get; set; }

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x0600116F RID: 4463 RVA: 0x00069E28 File Offset: 0x00068028
		// (set) Token: 0x06001170 RID: 4464 RVA: 0x00069E3C File Offset: 0x0006803C
		public string keepValidationsInSync { get; set; }

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06001171 RID: 4465 RVA: 0x00069E50 File Offset: 0x00068050
		// (set) Token: 0x06001172 RID: 4466 RVA: 0x00069E64 File Offset: 0x00068064
		public string keepColoursInSync { get; set; }

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06001173 RID: 4467 RVA: 0x00069E78 File Offset: 0x00068078
		// (set) Token: 0x06001174 RID: 4468 RVA: 0x00069E8C File Offset: 0x0006808C
		public bool allowDuplication { get; set; }

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06001175 RID: 4469 RVA: 0x00069EA0 File Offset: 0x000680A0
		// (set) Token: 0x06001176 RID: 4470 RVA: 0x00069EB4 File Offset: 0x000680B4
		public bool expandByDefault { get; set; }

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06001177 RID: 4471 RVA: 0x00069EC8 File Offset: 0x000680C8
		// (set) Token: 0x06001178 RID: 4472 RVA: 0x00069EDC File Offset: 0x000680DC
		public string type { get; set; }

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06001179 RID: 4473 RVA: 0x00069EF0 File Offset: 0x000680F0
		// (set) Token: 0x0600117A RID: 4474 RVA: 0x00069F04 File Offset: 0x00068104
		public string logo { get; set; }

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x0600117B RID: 4475 RVA: 0x00069F18 File Offset: 0x00068118
		// (set) Token: 0x0600117C RID: 4476 RVA: 0x00069F2C File Offset: 0x0006812C
		public bool isDeleted { get; set; }

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x0600117D RID: 4477 RVA: 0x00069F40 File Offset: 0x00068140
		// (set) Token: 0x0600117E RID: 4478 RVA: 0x00069F54 File Offset: 0x00068154
		public NewTableColumn[] columns { get; set; }
	}
}
