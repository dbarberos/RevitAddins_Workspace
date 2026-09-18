using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace A
{
	// Token: 0x0200010B RID: 267
	internal class \u001C\u0005
	{
		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000970 RID: 2416 RVA: 0x00041780 File Offset: 0x0003F980
		// (set) Token: 0x06000971 RID: 2417 RVA: 0x00041794 File Offset: 0x0003F994
		public \u001E\u0016 Value { get; set; }

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000972 RID: 2418 RVA: 0x000417A8 File Offset: 0x0003F9A8
		// (set) Token: 0x06000973 RID: 2419 RVA: 0x000417BC File Offset: 0x0003F9BC
		public int InitialRowIndex { get; set; }

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x000417D0 File Offset: 0x0003F9D0
		// (set) Token: 0x06000975 RID: 2421 RVA: 0x000417E4 File Offset: 0x0003F9E4
		public int InitialColumnIndex { get; set; }

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x000417F8 File Offset: 0x0003F9F8
		// (set) Token: 0x06000977 RID: 2423 RVA: 0x0004180C File Offset: 0x0003FA0C
		public int RowIndex { get; set; }

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000978 RID: 2424 RVA: 0x00041820 File Offset: 0x0003FA20
		// (set) Token: 0x06000979 RID: 2425 RVA: 0x00041834 File Offset: 0x0003FA34
		public int ColumnIndex { get; set; }

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x0600097A RID: 2426 RVA: 0x00041848 File Offset: 0x0003FA48
		// (set) Token: 0x0600097B RID: 2427 RVA: 0x0004185C File Offset: 0x0003FA5C
		public int RowAdjust { get; set; }

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x00041870 File Offset: 0x0003FA70
		// (set) Token: 0x0600097D RID: 2429 RVA: 0x00041884 File Offset: 0x0003FA84
		public int ColumnAdjust { get; set; }

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x00041898 File Offset: 0x0003FA98
		// (set) Token: 0x0600097F RID: 2431 RVA: 0x000418AC File Offset: 0x0003FAAC
		public double RowHeight { get; set; }

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x000418C0 File Offset: 0x0003FAC0
		// (set) Token: 0x06000981 RID: 2433 RVA: 0x000418D4 File Offset: 0x0003FAD4
		public HorizontalAlignments HorizontalAlignment { get; set; }

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x000418E8 File Offset: 0x0003FAE8
		// (set) Token: 0x06000983 RID: 2435 RVA: 0x000418FC File Offset: 0x0003FAFC
		public VerticalAlignments VerticalAlignment { get; set; }

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x00041910 File Offset: 0x0003FB10
		// (set) Token: 0x06000985 RID: 2437 RVA: 0x00041924 File Offset: 0x0003FB24
		public \u0010\u0005 CellFont { get; set; }

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x00041938 File Offset: 0x0003FB38
		// (set) Token: 0x06000987 RID: 2439 RVA: 0x0004194C File Offset: 0x0003FB4C
		public \u0008\u0005 CellMergeInfo { get; set; }

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x00041960 File Offset: 0x0003FB60
		// (set) Token: 0x06000989 RID: 2441 RVA: 0x00041974 File Offset: 0x0003FB74
		public \u000D\u0005 CellBorderLineStyles { get; set; }

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x00041988 File Offset: 0x0003FB88
		// (set) Token: 0x0600098B RID: 2443 RVA: 0x0004199C File Offset: 0x0003FB9C
		public Color FillBackgroundColor { get; set; }

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x0600098C RID: 2444 RVA: 0x000419B0 File Offset: 0x0003FBB0
		// (set) Token: 0x0600098D RID: 2445 RVA: 0x000419C4 File Offset: 0x0003FBC4
		public int TextOrientation { get; set; }

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x0600098E RID: 2446 RVA: 0x000419D8 File Offset: 0x0003FBD8
		// (set) Token: 0x0600098F RID: 2447 RVA: 0x000419EC File Offset: 0x0003FBEC
		public ExcelTextStyleInfo OriginalTextStyle { get; set; }

		// Token: 0x040003C8 RID: 968
		[CompilerGenerated]
		private \u001E\u0016 \u000F;

		// Token: 0x040003C9 RID: 969
		[CompilerGenerated]
		private int \u0012;

		// Token: 0x040003CA RID: 970
		[CompilerGenerated]
		private int \u0003;

		// Token: 0x040003CB RID: 971
		[CompilerGenerated]
		private int \u001C;

		// Token: 0x040003CC RID: 972
		[CompilerGenerated]
		private int \u000D;

		// Token: 0x040003CD RID: 973
		[CompilerGenerated]
		private int \u0010;

		// Token: 0x040003CE RID: 974
		[CompilerGenerated]
		private int \u000E;

		// Token: 0x040003CF RID: 975
		[CompilerGenerated]
		private double \u0008;

		// Token: 0x040003D0 RID: 976
		[CompilerGenerated]
		private HorizontalAlignments \u001B;

		// Token: 0x040003D1 RID: 977
		[CompilerGenerated]
		private VerticalAlignments \u0011;

		// Token: 0x040003D2 RID: 978
		[CompilerGenerated]
		private \u0010\u0005 \u001E;

		// Token: 0x040003D3 RID: 979
		[CompilerGenerated]
		private \u0008\u0005 \u0020;

		// Token: 0x040003D4 RID: 980
		[CompilerGenerated]
		private \u000D\u0005 \u0017;

		// Token: 0x040003D5 RID: 981
		[CompilerGenerated]
		private Color \u0014;

		// Token: 0x040003D6 RID: 982
		[CompilerGenerated]
		private int \u0013;

		// Token: 0x040003D7 RID: 983
		[CompilerGenerated]
		private ExcelTextStyleInfo \u001A;
	}
}
