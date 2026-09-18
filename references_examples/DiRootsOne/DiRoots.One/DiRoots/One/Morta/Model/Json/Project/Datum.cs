using System;

namespace DiRoots.One.Morta.Model.Json.Project
{
	// Token: 0x020001DD RID: 477
	[Serializable]
	public class Datum
	{
		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x06001201 RID: 4609 RVA: 0x0006A990 File Offset: 0x00068B90
		// (set) Token: 0x06001202 RID: 4610 RVA: 0x0006A9A4 File Offset: 0x00068BA4
		public object deletedAt { get; set; }

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x06001203 RID: 4611 RVA: 0x0006A9B8 File Offset: 0x00068BB8
		// (set) Token: 0x06001204 RID: 4612 RVA: 0x0006A9CC File Offset: 0x00068BCC
		public bool hideProcessCreated { get; set; }

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x06001205 RID: 4613 RVA: 0x0006A9E0 File Offset: 0x00068BE0
		// (set) Token: 0x06001206 RID: 4614 RVA: 0x0006A9F4 File Offset: 0x00068BF4
		public bool isDeleted { get; set; }

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x06001207 RID: 4615 RVA: 0x0006AA08 File Offset: 0x00068C08
		// (set) Token: 0x06001208 RID: 4616 RVA: 0x0006AA1C File Offset: 0x00068C1C
		public bool mfaRequired { get; set; }

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x06001209 RID: 4617 RVA: 0x0006AA30 File Offset: 0x00068C30
		// (set) Token: 0x0600120A RID: 4618 RVA: 0x0006AA44 File Offset: 0x00068C44
		public string name { get; set; }

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x0600120B RID: 4619 RVA: 0x0006AA58 File Offset: 0x00068C58
		// (set) Token: 0x0600120C RID: 4620 RVA: 0x0006AA6C File Offset: 0x00068C6C
		public string primaryColour { get; set; }

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x0600120D RID: 4621 RVA: 0x0006AA80 File Offset: 0x00068C80
		// (set) Token: 0x0600120E RID: 4622 RVA: 0x0006AA94 File Offset: 0x00068C94
		public string publicId { get; set; }

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x0600120F RID: 4623 RVA: 0x0006AAA8 File Offset: 0x00068CA8
		// (set) Token: 0x06001210 RID: 4624 RVA: 0x0006AABC File Offset: 0x00068CBC
		public Process process { get; set; }

		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x06001211 RID: 4625 RVA: 0x0006AAD0 File Offset: 0x00068CD0
		// (set) Token: 0x06001212 RID: 4626 RVA: 0x0006AAE4 File Offset: 0x00068CE4
		public string type { get; set; }

		// Token: 0x17000536 RID: 1334
		// (get) Token: 0x06001213 RID: 4627 RVA: 0x0006AAF8 File Offset: 0x00068CF8
		// (set) Token: 0x06001214 RID: 4628 RVA: 0x0006AB0C File Offset: 0x00068D0C
		public Table table { get; set; }
	}
}
