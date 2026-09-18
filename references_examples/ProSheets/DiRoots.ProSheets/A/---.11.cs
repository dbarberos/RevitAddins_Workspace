using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x0200005D RID: 93
	internal static class \u001E\u0009\u0018
	{
		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x000187B4 File Offset: 0x000169B4
		// (set) Token: 0x06000465 RID: 1125 RVA: 0x000187C8 File Offset: 0x000169C8
		public static ExportPaperFormat PaperSize { get; set; }

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000466 RID: 1126 RVA: 0x000187DC File Offset: 0x000169DC
		// (set) Token: 0x06000467 RID: 1127 RVA: 0x000187F0 File Offset: 0x000169F0
		public static bool IsDwfx { get; set; }

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000468 RID: 1128 RVA: 0x00018804 File Offset: 0x00016A04
		// (set) Token: 0x06000469 RID: 1129 RVA: 0x00018818 File Offset: 0x00016A18
		public static PaperPlacementType PaperPlacementType { get; set; }

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x0600046A RID: 1130 RVA: 0x0001882C File Offset: 0x00016A2C
		// (set) Token: 0x0600046B RID: 1131 RVA: 0x00018840 File Offset: 0x00016A40
		public static MarginType MarginType { get; set; }

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x00018854 File Offset: 0x00016A54
		// (set) Token: 0x0600046D RID: 1133 RVA: 0x00018868 File Offset: 0x00016A68
		public static double XValue { get; set; }

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x0001887C File Offset: 0x00016A7C
		// (set) Token: 0x0600046F RID: 1135 RVA: 0x00018890 File Offset: 0x00016A90
		public static double YValue { get; set; }

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x000188A4 File Offset: 0x00016AA4
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x000188B8 File Offset: 0x00016AB8
		public static ZoomType ZoomType { get; set; }

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x000188CC File Offset: 0x00016ACC
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x000188E0 File Offset: 0x00016AE0
		public static int ZoomSize { get; set; }

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x000188F4 File Offset: 0x00016AF4
		// (set) Token: 0x06000475 RID: 1141 RVA: 0x00018908 File Offset: 0x00016B08
		public static PageOrientationType PageOrientationType { get; set; }

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x0001891C File Offset: 0x00016B1C
		// (set) Token: 0x06000477 RID: 1143 RVA: 0x00018930 File Offset: 0x00016B30
		public static HiddenLineViewsType HiddenLineViewsType { get; set; }

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000478 RID: 1144 RVA: 0x00018944 File Offset: 0x00016B44
		// (set) Token: 0x06000479 RID: 1145 RVA: 0x00018958 File Offset: 0x00016B58
		public static RasterQualityType RasterQualityType { get; set; }

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x0001896C File Offset: 0x00016B6C
		// (set) Token: 0x0600047B RID: 1147 RVA: 0x00018980 File Offset: 0x00016B80
		public static ColorDepthType ColorDepthType { get; set; }

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x00018994 File Offset: 0x00016B94
		// (set) Token: 0x0600047D RID: 1149 RVA: 0x000189A8 File Offset: 0x00016BA8
		public static bool RegionEdgesMask { get; set; }

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x000189BC File Offset: 0x00016BBC
		// (set) Token: 0x0600047F RID: 1151 RVA: 0x000189D0 File Offset: 0x00016BD0
		public static bool HideReforWorkPlanes { get; set; }

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x000189E4 File Offset: 0x00016BE4
		// (set) Token: 0x06000481 RID: 1153 RVA: 0x000189F8 File Offset: 0x00016BF8
		public static bool HideUnreferencedViewTags { get; set; }

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x00018A0C File Offset: 0x00016C0C
		// (set) Token: 0x06000483 RID: 1155 RVA: 0x00018A20 File Offset: 0x00016C20
		public static bool HideScopeBoxes { get; set; }

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x00018A34 File Offset: 0x00016C34
		// (set) Token: 0x06000485 RID: 1157 RVA: 0x00018A48 File Offset: 0x00016C48
		public static bool HideCropBoundaries { get; set; }

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x00018A5C File Offset: 0x00016C5C
		// (set) Token: 0x06000487 RID: 1159 RVA: 0x00018A70 File Offset: 0x00016C70
		public static bool ReplaceHalftoneWithThinLines { get; set; }

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000488 RID: 1160 RVA: 0x00018A84 File Offset: 0x00016C84
		// (set) Token: 0x06000489 RID: 1161 RVA: 0x00018A98 File Offset: 0x00016C98
		public static bool CombineFlag { get; set; }

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x0600048A RID: 1162 RVA: 0x00018AAC File Offset: 0x00016CAC
		// (set) Token: 0x0600048B RID: 1163 RVA: 0x00018AC0 File Offset: 0x00016CC0
		public static string CombineFilename { get; set; }

		// Token: 0x0400017D RID: 381
		[CompilerGenerated]
		private static ExportPaperFormat \u000C;

		// Token: 0x0400017E RID: 382
		[CompilerGenerated]
		private static bool \u0018;

		// Token: 0x0400017F RID: 383
		[CompilerGenerated]
		private static PaperPlacementType \u0014;

		// Token: 0x04000180 RID: 384
		[CompilerGenerated]
		private static MarginType \u0003;

		// Token: 0x04000181 RID: 385
		[CompilerGenerated]
		private static double \u0016;

		// Token: 0x04000182 RID: 386
		[CompilerGenerated]
		private static double \u000F;

		// Token: 0x04000183 RID: 387
		[CompilerGenerated]
		private static ZoomType \u0012;

		// Token: 0x04000184 RID: 388
		[CompilerGenerated]
		private static int \u000D;

		// Token: 0x04000185 RID: 389
		[CompilerGenerated]
		private static PageOrientationType \u001C;

		// Token: 0x04000186 RID: 390
		[CompilerGenerated]
		private static HiddenLineViewsType \u0013;

		// Token: 0x04000187 RID: 391
		[CompilerGenerated]
		private static RasterQualityType \u0009;

		// Token: 0x04000188 RID: 392
		[CompilerGenerated]
		private static ColorDepthType \u000A;

		// Token: 0x04000189 RID: 393
		[CompilerGenerated]
		private static bool \u0020;

		// Token: 0x0400018A RID: 394
		[CompilerGenerated]
		private static bool \u001F;

		// Token: 0x0400018B RID: 395
		[CompilerGenerated]
		private static bool \u0011;

		// Token: 0x0400018C RID: 396
		[CompilerGenerated]
		private static bool \u0015;

		// Token: 0x0400018D RID: 397
		[CompilerGenerated]
		private static bool \u0017;

		// Token: 0x0400018E RID: 398
		[CompilerGenerated]
		private static bool \u001E;

		// Token: 0x0400018F RID: 399
		[CompilerGenerated]
		private static bool \u0002;

		// Token: 0x04000190 RID: 400
		[CompilerGenerated]
		private static string \u0004;

		// Token: 0x02000179 RID: 377
		public class \u0017\u0009\u0018
		{
			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x060010B7 RID: 4279 RVA: 0x0005AB10 File Offset: 0x00058D10
			// (set) Token: 0x060010B8 RID: 4280 RVA: 0x0005AB24 File Offset: 0x00058D24
			public static DWFImageFormat ImageFormat { get; set; }

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x060010B9 RID: 4281 RVA: 0x0005AB38 File Offset: 0x00058D38
			// (set) Token: 0x060010BA RID: 4282 RVA: 0x0005AB4C File Offset: 0x00058D4C
			public static DWFImageQuality ImageQuality { get; set; }

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x060010BB RID: 4283 RVA: 0x0005AB60 File Offset: 0x00058D60
			// (set) Token: 0x060010BC RID: 4284 RVA: 0x0005AB74 File Offset: 0x00058D74
			public static bool CropBoxVisible { get; set; }

			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x060010BD RID: 4285 RVA: 0x0005AB88 File Offset: 0x00058D88
			// (set) Token: 0x060010BE RID: 4286 RVA: 0x0005AB9C File Offset: 0x00058D9C
			public static bool ExportingAreas { get; set; }

			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x060010BF RID: 4287 RVA: 0x0005ABB0 File Offset: 0x00058DB0
			// (set) Token: 0x060010C0 RID: 4288 RVA: 0x0005ABC4 File Offset: 0x00058DC4
			public static bool ExportTextures { get; set; }

			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x060010C1 RID: 4289 RVA: 0x0005ABD8 File Offset: 0x00058DD8
			// (set) Token: 0x060010C2 RID: 4290 RVA: 0x0005ABEC File Offset: 0x00058DEC
			public static bool ExportObjectData { get; set; }

			// Token: 0x040007A6 RID: 1958
			[CompilerGenerated]
			private static DWFImageFormat \u000C;

			// Token: 0x040007A7 RID: 1959
			[CompilerGenerated]
			private static DWFImageQuality \u0018;

			// Token: 0x040007A8 RID: 1960
			[CompilerGenerated]
			private static bool \u0014;

			// Token: 0x040007A9 RID: 1961
			[CompilerGenerated]
			private static bool \u0003;

			// Token: 0x040007AA RID: 1962
			[CompilerGenerated]
			private static bool \u0016;

			// Token: 0x040007AB RID: 1963
			[CompilerGenerated]
			private static bool \u000F;
		}
	}
}
