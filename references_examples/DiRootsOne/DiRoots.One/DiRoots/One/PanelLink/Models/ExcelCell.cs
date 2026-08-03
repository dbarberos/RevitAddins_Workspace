using System;
using System.Runtime.CompilerServices;

namespace DiRoots.One.PanelLink.Models
{
	// Token: 0x0200019C RID: 412
	public class ExcelCell
	{
		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06000F58 RID: 3928 RVA: 0x00062304 File Offset: 0x00060504
		// (set) Token: 0x06000F59 RID: 3929 RVA: 0x00062318 File Offset: 0x00060518
		public ImageInfo ImageInfo { get; set; }

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06000F5A RID: 3930 RVA: 0x0006232C File Offset: 0x0006052C
		// (set) Token: 0x06000F5B RID: 3931 RVA: 0x00062340 File Offset: 0x00060540
		public string Value { get; set; }

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x06000F5C RID: 3932 RVA: 0x00062354 File Offset: 0x00060554
		// (set) Token: 0x06000F5D RID: 3933 RVA: 0x00062368 File Offset: 0x00060568
		public int RowIndex { get; set; }

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06000F5E RID: 3934 RVA: 0x0006237C File Offset: 0x0006057C
		// (set) Token: 0x06000F5F RID: 3935 RVA: 0x00062390 File Offset: 0x00060590
		public int ColumnIndex { get; set; }

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06000F60 RID: 3936 RVA: 0x000623A4 File Offset: 0x000605A4
		// (set) Token: 0x06000F61 RID: 3937 RVA: 0x000623B8 File Offset: 0x000605B8
		public double RowHeight { get; set; }

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06000F62 RID: 3938 RVA: 0x000623CC File Offset: 0x000605CC
		// (set) Token: 0x06000F63 RID: 3939 RVA: 0x000623E0 File Offset: 0x000605E0
		public double ColumnWidth { get; set; }

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x06000F64 RID: 3940 RVA: 0x000623F4 File Offset: 0x000605F4
		// (set) Token: 0x06000F65 RID: 3941 RVA: 0x00062408 File Offset: 0x00060608
		public bool IsImage { get; set; }

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06000F66 RID: 3942 RVA: 0x0006241C File Offset: 0x0006061C
		// (set) Token: 0x06000F67 RID: 3943 RVA: 0x00062430 File Offset: 0x00060630
		public FontInfo CellFont { get; set; }

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06000F68 RID: 3944 RVA: 0x00062444 File Offset: 0x00060644
		// (set) Token: 0x06000F69 RID: 3945 RVA: 0x00062458 File Offset: 0x00060658
		public HorizontalAlignments HorizontalAlignment { get; set; }

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06000F6A RID: 3946 RVA: 0x0006246C File Offset: 0x0006066C
		// (set) Token: 0x06000F6B RID: 3947 RVA: 0x00062480 File Offset: 0x00060680
		public BorderLinestyle CellBorderLinestyles { get; set; }

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06000F6C RID: 3948 RVA: 0x00062494 File Offset: 0x00060694
		// (set) Token: 0x06000F6D RID: 3949 RVA: 0x000624A8 File Offset: 0x000606A8
		public VerticalAlignments VerticalAlignment { get; set; }

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x06000F6E RID: 3950 RVA: 0x000624BC File Offset: 0x000606BC
		// (set) Token: 0x06000F6F RID: 3951 RVA: 0x000624D0 File Offset: 0x000606D0
		public MergedCells MergedCells { get; set; }

		// Token: 0x0400060C RID: 1548
		[CompilerGenerated]
		private ImageInfo \u001F;

		// Token: 0x0400060D RID: 1549
		[CompilerGenerated]
		private string \u000A;

		// Token: 0x0400060E RID: 1550
		[CompilerGenerated]
		private int \u0007;

		// Token: 0x0400060F RID: 1551
		[CompilerGenerated]
		private int \u001D;

		// Token: 0x04000610 RID: 1552
		[CompilerGenerated]
		private double \u0004;

		// Token: 0x04000611 RID: 1553
		[CompilerGenerated]
		private double \u0019;

		// Token: 0x04000612 RID: 1554
		[CompilerGenerated]
		private bool \u0018;

		// Token: 0x04000613 RID: 1555
		[CompilerGenerated]
		private FontInfo \u0005;

		// Token: 0x04000614 RID: 1556
		[CompilerGenerated]
		private HorizontalAlignments \u0016;

		// Token: 0x04000615 RID: 1557
		[CompilerGenerated]
		private BorderLinestyle \u000B;

		// Token: 0x04000616 RID: 1558
		[CompilerGenerated]
		private VerticalAlignments \u0002;

		// Token: 0x04000617 RID: 1559
		[CompilerGenerated]
		private MergedCells \u0006;
	}
}
