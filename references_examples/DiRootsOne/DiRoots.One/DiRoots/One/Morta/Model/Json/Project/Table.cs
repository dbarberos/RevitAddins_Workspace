using System;

namespace DiRoots.One.Morta.Model.Json.Project
{
	// Token: 0x020001DF RID: 479
	[Serializable]
	public class Table
	{
		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x06001225 RID: 4645 RVA: 0x0006AC60 File Offset: 0x00068E60
		// (set) Token: 0x06001226 RID: 4646 RVA: 0x0006AC74 File Offset: 0x00068E74
		public DateTime createdAt { get; set; }

		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x06001227 RID: 4647 RVA: 0x0006AC88 File Offset: 0x00068E88
		// (set) Token: 0x06001228 RID: 4648 RVA: 0x0006AC9C File Offset: 0x00068E9C
		public string defaultViewId { get; set; }

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x06001229 RID: 4649 RVA: 0x0006ACB0 File Offset: 0x00068EB0
		// (set) Token: 0x0600122A RID: 4650 RVA: 0x0006ACC4 File Offset: 0x00068EC4
		public object deletedAt { get; set; }

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x0600122B RID: 4651 RVA: 0x0006ACD8 File Offset: 0x00068ED8
		// (set) Token: 0x0600122C RID: 4652 RVA: 0x0006ACEC File Offset: 0x00068EEC
		public bool isDeleted { get; set; }

		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x0600122D RID: 4653 RVA: 0x0006AD00 File Offset: 0x00068F00
		// (set) Token: 0x0600122E RID: 4654 RVA: 0x0006AD14 File Offset: 0x00068F14
		public object[] joins { get; set; }

		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x0600122F RID: 4655 RVA: 0x0006AD28 File Offset: 0x00068F28
		// (set) Token: 0x06001230 RID: 4656 RVA: 0x0006AD3C File Offset: 0x00068F3C
		public object logo { get; set; }

		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x06001231 RID: 4657 RVA: 0x0006AD50 File Offset: 0x00068F50
		// (set) Token: 0x06001232 RID: 4658 RVA: 0x0006AD64 File Offset: 0x00068F64
		public string name { get; set; }

		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x06001233 RID: 4659 RVA: 0x0006AD78 File Offset: 0x00068F78
		// (set) Token: 0x06001234 RID: 4660 RVA: 0x0006AD8C File Offset: 0x00068F8C
		public string publicId { get; set; }

		// Token: 0x17000546 RID: 1350
		// (get) Token: 0x06001235 RID: 4661 RVA: 0x0006ADA0 File Offset: 0x00068FA0
		// (set) Token: 0x06001236 RID: 4662 RVA: 0x0006ADB4 File Offset: 0x00068FB4
		public string type { get; set; }

		// Token: 0x17000547 RID: 1351
		// (get) Token: 0x06001237 RID: 4663 RVA: 0x0006ADC8 File Offset: 0x00068FC8
		// (set) Token: 0x06001238 RID: 4664 RVA: 0x0006ADDC File Offset: 0x00068FDC
		public string kind { get; set; }

		// Token: 0x17000548 RID: 1352
		// (get) Token: 0x06001239 RID: 4665 RVA: 0x0006ADF0 File Offset: 0x00068FF0
		// (set) Token: 0x0600123A RID: 4666 RVA: 0x0006AE04 File Offset: 0x00069004
		public DateTime updatedAt { get; set; }
	}
}
