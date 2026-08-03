using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DiRoots.One.PanelLink.Models
{
	// Token: 0x0200019B RID: 411
	public class ExcelSheetInfo
	{
		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06000F4B RID: 3915 RVA: 0x00062200 File Offset: 0x00060400
		// (set) Token: 0x06000F4C RID: 3916 RVA: 0x00062214 File Offset: 0x00060414
		public List<ExcelCell> LstExcelCells { get; set; }

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06000F4D RID: 3917 RVA: 0x00062228 File Offset: 0x00060428
		// (set) Token: 0x06000F4E RID: 3918 RVA: 0x0006223C File Offset: 0x0006043C
		public ExcelType ExcelType { get; set; }

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06000F4F RID: 3919 RVA: 0x00062250 File Offset: 0x00060450
		// (set) Token: 0x06000F50 RID: 3920 RVA: 0x00062264 File Offset: 0x00060464
		public string Name { get; set; }

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x06000F51 RID: 3921 RVA: 0x00062278 File Offset: 0x00060478
		// (set) Token: 0x06000F52 RID: 3922 RVA: 0x0006228C File Offset: 0x0006048C
		public int LastColumn { get; set; }

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06000F53 RID: 3923 RVA: 0x000622A0 File Offset: 0x000604A0
		// (set) Token: 0x06000F54 RID: 3924 RVA: 0x000622B4 File Offset: 0x000604B4
		public int StartRowIndex { get; set; }

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06000F55 RID: 3925 RVA: 0x000622C8 File Offset: 0x000604C8
		// (set) Token: 0x06000F56 RID: 3926 RVA: 0x000622DC File Offset: 0x000604DC
		public int LastRowIndex { get; set; }

		// Token: 0x04000606 RID: 1542
		[CompilerGenerated]
		private List<ExcelCell> \u001F;

		// Token: 0x04000607 RID: 1543
		[CompilerGenerated]
		private ExcelType \u000A;

		// Token: 0x04000608 RID: 1544
		[CompilerGenerated]
		private string \u0007;

		// Token: 0x04000609 RID: 1545
		[CompilerGenerated]
		private int \u001D;

		// Token: 0x0400060A RID: 1546
		[CompilerGenerated]
		private int \u0004;

		// Token: 0x0400060B RID: 1547
		[CompilerGenerated]
		private int \u0019;
	}
}
