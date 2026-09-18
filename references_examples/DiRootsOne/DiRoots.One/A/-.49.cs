using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace A
{
	// Token: 0x020000DA RID: 218
	internal class \u0020\u0019
	{
		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x0002EA24 File Offset: 0x0002CC24
		// (set) Token: 0x06000839 RID: 2105 RVA: 0x0002EA38 File Offset: 0x0002CC38
		public SelectedExcel Excel { get; set; } = new SelectedExcel();

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x0600083A RID: 2106 RVA: 0x0002EA4C File Offset: 0x0002CC4C
		// (set) Token: 0x0600083B RID: 2107 RVA: 0x0002EA60 File Offset: 0x0002CC60
		public List<\u001C\u0005> Cells { get; set; } = new List<\u001C\u0005>();

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x0600083C RID: 2108 RVA: 0x0002EA74 File Offset: 0x0002CC74
		// (set) Token: 0x0600083D RID: 2109 RVA: 0x0002EA88 File Offset: 0x0002CC88
		public List<\u0003\u0005> Columns { get; set; } = new List<\u0003\u0005>();

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x0600083E RID: 2110 RVA: 0x0002EA9C File Offset: 0x0002CC9C
		// (set) Token: 0x0600083F RID: 2111 RVA: 0x0002EAB0 File Offset: 0x0002CCB0
		public List<\u001B\u0005> Images { get; set; } = new List<\u001B\u0005>();

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000840 RID: 2112 RVA: 0x0002EAC4 File Offset: 0x0002CCC4
		// (set) Token: 0x06000841 RID: 2113 RVA: 0x0002EAD8 File Offset: 0x0002CCD8
		public HashSet<ExcelLineStyleInfo> UsedLineStyleKeys { get; set; } = new HashSet<ExcelLineStyleInfo>();

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000842 RID: 2114 RVA: 0x0002EAEC File Offset: 0x0002CCEC
		// (set) Token: 0x06000843 RID: 2115 RVA: 0x0002EB00 File Offset: 0x0002CD00
		public HashSet<ExcelTextStyleInfo> UsedTextStyleKeys { get; set; } = new HashSet<ExcelTextStyleInfo>();

		// Token: 0x0400034B RID: 843
		[CompilerGenerated]
		private SelectedExcel \u001F;

		// Token: 0x0400034C RID: 844
		[CompilerGenerated]
		private List<\u001C\u0005> \u000A;

		// Token: 0x0400034D RID: 845
		[CompilerGenerated]
		private List<\u0003\u0005> \u0007;

		// Token: 0x0400034E RID: 846
		[CompilerGenerated]
		private List<\u001B\u0005> \u001D;

		// Token: 0x0400034F RID: 847
		[CompilerGenerated]
		private HashSet<ExcelLineStyleInfo> \u0004;

		// Token: 0x04000350 RID: 848
		[CompilerGenerated]
		private HashSet<ExcelTextStyleInfo> \u0019;
	}
}
