using System;
using ProSheets.Enums;

namespace ProSheets
{
	// Token: 0x0200006F RID: 111
	[Serializable]
	public class AutoRemember
	{
		// Token: 0x17000272 RID: 626
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x00025C9C File Offset: 0x00023E9C
		// (set) Token: 0x06000650 RID: 1616 RVA: 0x00025CB0 File Offset: 0x00023EB0
		public string Create_ExportFolderPath { get; set; }

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x00025CC4 File Offset: 0x00023EC4
		// (set) Token: 0x06000652 RID: 1618 RVA: 0x00025CD8 File Offset: 0x00023ED8
		public bool Create_SplitFolder { get; set; }

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x00025CEC File Offset: 0x00023EEC
		// (set) Token: 0x06000654 RID: 1620 RVA: 0x00025D00 File Offset: 0x00023F00
		public TemporaryModeOption WorsketMode { get; set; }

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000655 RID: 1621 RVA: 0x00025D14 File Offset: 0x00023F14
		// (set) Token: 0x06000656 RID: 1622 RVA: 0x00025D28 File Offset: 0x00023F28
		public TemporaryModeOption TemporaryIsolateOrHide { get; set; }

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000657 RID: 1623 RVA: 0x00025D3C File Offset: 0x00023F3C
		// (set) Token: 0x06000658 RID: 1624 RVA: 0x00025D50 File Offset: 0x00023F50
		public TemporaryModeOption RevealHiddenElements { get; set; }

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000659 RID: 1625 RVA: 0x00025D64 File Offset: 0x00023F64
		// (set) Token: 0x0600065A RID: 1626 RVA: 0x00025D78 File Offset: 0x00023F78
		public TemporaryModeOption RevealConstraints { get; set; }
	}
}
