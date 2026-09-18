using System;

namespace DiRoots.One.Morta.Model.Json.Table
{
	// Token: 0x020001DA RID: 474
	[Serializable]
	public class ColumnData
	{
		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x060011BA RID: 4538 RVA: 0x0006A404 File Offset: 0x00068604
		// (set) Token: 0x060011BB RID: 4539 RVA: 0x0006A418 File Offset: 0x00068618
		public bool allowDuplication { get; set; }

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x060011BC RID: 4540 RVA: 0x0006A42C File Offset: 0x0006862C
		// (set) Token: 0x060011BD RID: 4541 RVA: 0x0006A440 File Offset: 0x00068640
		public Column[] columns { get; set; }

		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x060011BE RID: 4542 RVA: 0x0006A454 File Offset: 0x00068654
		// (set) Token: 0x060011BF RID: 4543 RVA: 0x0006A468 File Offset: 0x00068668
		public DateTime createdAt { get; set; }

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x060011C0 RID: 4544 RVA: 0x0006A47C File Offset: 0x0006867C
		// (set) Token: 0x060011C1 RID: 4545 RVA: 0x0006A490 File Offset: 0x00068690
		public string defaultViewId { get; set; }

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x060011C2 RID: 4546 RVA: 0x0006A4A4 File Offset: 0x000686A4
		// (set) Token: 0x060011C3 RID: 4547 RVA: 0x0006A4B8 File Offset: 0x000686B8
		public object deletedAt { get; set; }

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x060011C4 RID: 4548 RVA: 0x0006A4CC File Offset: 0x000686CC
		// (set) Token: 0x060011C5 RID: 4549 RVA: 0x0006A4E0 File Offset: 0x000686E0
		public bool isDeleted { get; set; }

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x060011C6 RID: 4550 RVA: 0x0006A4F4 File Offset: 0x000686F4
		// (set) Token: 0x060011C7 RID: 4551 RVA: 0x0006A508 File Offset: 0x00068708
		public bool isSynced { get; set; }

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x060011C8 RID: 4552 RVA: 0x0006A51C File Offset: 0x0006871C
		// (set) Token: 0x060011C9 RID: 4553 RVA: 0x0006A530 File Offset: 0x00068730
		public bool isViewpointSynced { get; set; }

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x060011CA RID: 4554 RVA: 0x0006A544 File Offset: 0x00068744
		// (set) Token: 0x060011CB RID: 4555 RVA: 0x0006A558 File Offset: 0x00068758
		public object[] joins { get; set; }

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x060011CC RID: 4556 RVA: 0x0006A56C File Offset: 0x0006876C
		// (set) Token: 0x060011CD RID: 4557 RVA: 0x0006A580 File Offset: 0x00068780
		public bool keepColoursInSync { get; set; }

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x060011CE RID: 4558 RVA: 0x0006A594 File Offset: 0x00068794
		// (set) Token: 0x060011CF RID: 4559 RVA: 0x0006A5A8 File Offset: 0x000687A8
		public bool keepValidationsInSync { get; set; }

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x060011D0 RID: 4560 RVA: 0x0006A5BC File Offset: 0x000687BC
		// (set) Token: 0x060011D1 RID: 4561 RVA: 0x0006A5D0 File Offset: 0x000687D0
		public object logo { get; set; }

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x060011D2 RID: 4562 RVA: 0x0006A5E4 File Offset: 0x000687E4
		// (set) Token: 0x060011D3 RID: 4563 RVA: 0x0006A5F8 File Offset: 0x000687F8
		public string name { get; set; }

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x060011D4 RID: 4564 RVA: 0x0006A60C File Offset: 0x0006880C
		// (set) Token: 0x060011D5 RID: 4565 RVA: 0x0006A620 File Offset: 0x00068820
		public int permissionLevel { get; set; }

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060011D6 RID: 4566 RVA: 0x0006A634 File Offset: 0x00068834
		// (set) Token: 0x060011D7 RID: 4567 RVA: 0x0006A648 File Offset: 0x00068848
		public string publicId { get; set; }

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x060011D8 RID: 4568 RVA: 0x0006A65C File Offset: 0x0006885C
		// (set) Token: 0x060011D9 RID: 4569 RVA: 0x0006A670 File Offset: 0x00068870
		public string type { get; set; }

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x060011DA RID: 4570 RVA: 0x0006A684 File Offset: 0x00068884
		// (set) Token: 0x060011DB RID: 4571 RVA: 0x0006A698 File Offset: 0x00068898
		public DateTime updatedAt { get; set; }

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x060011DC RID: 4572 RVA: 0x0006A6AC File Offset: 0x000688AC
		// (set) Token: 0x060011DD RID: 4573 RVA: 0x0006A6C0 File Offset: 0x000688C0
		public object[] variables { get; set; }
	}
}
