using System;

namespace DiRoots.One.Morta.Model.Json.Project
{
	// Token: 0x020001DE RID: 478
	[Serializable]
	public class Process
	{
		// Token: 0x17000537 RID: 1335
		// (get) Token: 0x06001216 RID: 4630 RVA: 0x0006AB34 File Offset: 0x00068D34
		// (set) Token: 0x06001217 RID: 4631 RVA: 0x0006AB48 File Offset: 0x00068D48
		public DateTime createdAt { get; set; }

		// Token: 0x17000538 RID: 1336
		// (get) Token: 0x06001218 RID: 4632 RVA: 0x0006AB5C File Offset: 0x00068D5C
		// (set) Token: 0x06001219 RID: 4633 RVA: 0x0006AB70 File Offset: 0x00068D70
		public object deletedAt { get; set; }

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x0600121A RID: 4634 RVA: 0x0006AB84 File Offset: 0x00068D84
		// (set) Token: 0x0600121B RID: 4635 RVA: 0x0006AB98 File Offset: 0x00068D98
		public object logo { get; set; }

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x0600121C RID: 4636 RVA: 0x0006ABAC File Offset: 0x00068DAC
		// (set) Token: 0x0600121D RID: 4637 RVA: 0x0006ABC0 File Offset: 0x00068DC0
		public string name { get; set; }

		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x0600121E RID: 4638 RVA: 0x0006ABD4 File Offset: 0x00068DD4
		// (set) Token: 0x0600121F RID: 4639 RVA: 0x0006ABE8 File Offset: 0x00068DE8
		public string publicId { get; set; }

		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x06001220 RID: 4640 RVA: 0x0006ABFC File Offset: 0x00068DFC
		// (set) Token: 0x06001221 RID: 4641 RVA: 0x0006AC10 File Offset: 0x00068E10
		public string type { get; set; }

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x06001222 RID: 4642 RVA: 0x0006AC24 File Offset: 0x00068E24
		// (set) Token: 0x06001223 RID: 4643 RVA: 0x0006AC38 File Offset: 0x00068E38
		public DateTime updatedAt { get; set; }
	}
}
