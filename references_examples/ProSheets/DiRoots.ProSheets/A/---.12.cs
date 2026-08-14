using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using ProSheets;

namespace A
{
	// Token: 0x0200005E RID: 94
	internal static class \u0002\u0009\u0018
	{
		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x00018AFC File Offset: 0x00016CFC
		// (set) Token: 0x0600048E RID: 1166 RVA: 0x00018B10 File Offset: 0x00016D10
		public static string SetupName { get; set; }

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x00018B24 File Offset: 0x00016D24
		// (set) Token: 0x06000490 RID: 1168 RVA: 0x00018B38 File Offset: 0x00016D38
		public static IFCVersion FileVersion { get; set; }

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x00018B4C File Offset: 0x00016D4C
		// (set) Token: 0x06000492 RID: 1170 RVA: 0x00018B60 File Offset: 0x00016D60
		public static string IFCFileType { get; set; }

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x00018B74 File Offset: 0x00016D74
		// (set) Token: 0x06000494 RID: 1172 RVA: 0x00018B88 File Offset: 0x00016D88
		public static string ActivePhaseId { get; set; }

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x00018B9C File Offset: 0x00016D9C
		// (set) Token: 0x06000496 RID: 1174 RVA: 0x00018BB0 File Offset: 0x00016DB0
		public static IFCPhase CurrentPhase { get; set; } = \u001F\u001E\u0014.\u0018();

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x00018BC4 File Offset: 0x00016DC4
		// (set) Token: 0x06000498 RID: 1176 RVA: 0x00018BD8 File Offset: 0x00016DD8
		public static string SpaceBoundaries { get; set; }

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x00018BEC File Offset: 0x00016DEC
		// (set) Token: 0x0600049A RID: 1178 RVA: 0x00018C00 File Offset: 0x00016E00
		public static string SitePlacement { get; set; }

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x00018C14 File Offset: 0x00016E14
		// (set) Token: 0x0600049C RID: 1180 RVA: 0x00018C28 File Offset: 0x00016E28
		public static bool WallAndColumnSplitting { get; set; }

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x00018C3C File Offset: 0x00016E3C
		// (set) Token: 0x0600049E RID: 1182 RVA: 0x00018C50 File Offset: 0x00016E50
		public static bool IncludeSteelElements { get; set; }

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x00018C64 File Offset: 0x00016E64
		// (set) Token: 0x060004A0 RID: 1184 RVA: 0x00018C78 File Offset: 0x00016E78
		public static bool Export2DElements { get; set; }

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x00018C8C File Offset: 0x00016E8C
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x00018CA0 File Offset: 0x00016EA0
		public static string LinkedFileExport { get; set; }

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x00018CB4 File Offset: 0x00016EB4
		// (set) Token: 0x060004A4 RID: 1188 RVA: 0x00018CC8 File Offset: 0x00016EC8
		public static bool ExportRoomsInView { get; set; }

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x00018CDC File Offset: 0x00016EDC
		// (set) Token: 0x060004A6 RID: 1190 RVA: 0x00018CF0 File Offset: 0x00016EF0
		public static bool ExportInternalRevitPropertySets { get; set; }

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x00018D04 File Offset: 0x00016F04
		// (set) Token: 0x060004A8 RID: 1192 RVA: 0x00018D18 File Offset: 0x00016F18
		public static bool ExportIFCCommonPropertySets { get; set; }

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x00018D2C File Offset: 0x00016F2C
		// (set) Token: 0x060004AA RID: 1194 RVA: 0x00018D40 File Offset: 0x00016F40
		public static bool ExportBaseQuantities { get; set; }

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x00018D54 File Offset: 0x00016F54
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x00018D68 File Offset: 0x00016F68
		public static bool ExportSchedulesAsPsets { get; set; }

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x00018D7C File Offset: 0x00016F7C
		// (set) Token: 0x060004AE RID: 1198 RVA: 0x00018D90 File Offset: 0x00016F90
		public static bool ExportSpecificSchedules { get; set; }

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x00018DA4 File Offset: 0x00016FA4
		// (set) Token: 0x060004B0 RID: 1200 RVA: 0x00018DB8 File Offset: 0x00016FB8
		public static bool ExportUserDefinedPsets { get; set; }

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x060004B1 RID: 1201 RVA: 0x00018DCC File Offset: 0x00016FCC
		// (set) Token: 0x060004B2 RID: 1202 RVA: 0x00018DE0 File Offset: 0x00016FE0
		public static bool UseTypePropertiesInInstancePSets { get; set; }

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x060004B3 RID: 1203 RVA: 0x00018DF4 File Offset: 0x00016FF4
		// (set) Token: 0x060004B4 RID: 1204 RVA: 0x00018E08 File Offset: 0x00017008
		public static string ExportUserDefinedPsetsFileName { get; set; }

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x060004B5 RID: 1205 RVA: 0x00018E1C File Offset: 0x0001701C
		// (set) Token: 0x060004B6 RID: 1206 RVA: 0x00018E30 File Offset: 0x00017030
		public static bool ExportUserDefinedParameterMapping { get; set; }

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x00018E44 File Offset: 0x00017044
		// (set) Token: 0x060004B8 RID: 1208 RVA: 0x00018E58 File Offset: 0x00017058
		public static string ExportUserDefinedParameterMappingFileName { get; set; }

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x060004B9 RID: 1209 RVA: 0x00018E6C File Offset: 0x0001706C
		// (set) Token: 0x060004BA RID: 1210 RVA: 0x00018E80 File Offset: 0x00017080
		public static string TessellationLevelOfDetail { get; set; }

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x060004BB RID: 1211 RVA: 0x00018E94 File Offset: 0x00017094
		// (set) Token: 0x060004BC RID: 1212 RVA: 0x00018EA8 File Offset: 0x000170A8
		public static bool ExportPartsAsBuildingElements { get; set; }

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x00018EBC File Offset: 0x000170BC
		// (set) Token: 0x060004BE RID: 1214 RVA: 0x00018ED0 File Offset: 0x000170D0
		public static bool ExportSolidModelRep { get; set; }

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x060004BF RID: 1215 RVA: 0x00018EE4 File Offset: 0x000170E4
		// (set) Token: 0x060004C0 RID: 1216 RVA: 0x00018EF8 File Offset: 0x000170F8
		public static bool UseFamilyAndTypeNameForReference { get; set; }

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x00018F0C File Offset: 0x0001710C
		// (set) Token: 0x060004C2 RID: 1218 RVA: 0x00018F20 File Offset: 0x00017120
		public static bool Use2DRoomBoundaryForVolume { get; set; }

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x00018F34 File Offset: 0x00017134
		// (set) Token: 0x060004C4 RID: 1220 RVA: 0x00018F48 File Offset: 0x00017148
		public static bool IncludeSiteElevation { get; set; }

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x00018F5C File Offset: 0x0001715C
		// (set) Token: 0x060004C6 RID: 1222 RVA: 0x00018F70 File Offset: 0x00017170
		public static bool StoreIFCGUID { get; set; }

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x00018F84 File Offset: 0x00017184
		// (set) Token: 0x060004C8 RID: 1224 RVA: 0x00018F98 File Offset: 0x00017198
		public static bool ExportBoundingBox { get; set; }

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x00018FAC File Offset: 0x000171AC
		// (set) Token: 0x060004CA RID: 1226 RVA: 0x00018FC0 File Offset: 0x000171C0
		public static bool UseOnlyTriangulation { get; set; }

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x00018FD4 File Offset: 0x000171D4
		// (set) Token: 0x060004CC RID: 1228 RVA: 0x00018FE8 File Offset: 0x000171E8
		public static bool VisibleElementsOfCurrentView { get; set; }

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x00018FFC File Offset: 0x000171FC
		// (set) Token: 0x060004CE RID: 1230 RVA: 0x00019010 File Offset: 0x00017210
		public static double TessellationFactor { get; set; } = -1.0;

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x00019024 File Offset: 0x00017224
		// (set) Token: 0x060004D0 RID: 1232 RVA: 0x00019038 File Offset: 0x00017238
		public static bool UseActiveViewCreatingGeometry { get; set; }

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x0001904C File Offset: 0x0001724C
		// (set) Token: 0x060004D2 RID: 1234 RVA: 0x00019060 File Offset: 0x00017260
		public static bool UseTypeNameOnlyForIfcType { get; set; }

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x00019074 File Offset: 0x00017274
		// (set) Token: 0x060004D4 RID: 1236 RVA: 0x00019088 File Offset: 0x00017288
		public static bool UseVisibleRevitNameAsEntityName { get; set; }

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x0001909C File Offset: 0x0001729C
		// (set) Token: 0x060004D6 RID: 1238 RVA: 0x000190B0 File Offset: 0x000172B0
		public static string CategoryMapping { get; set; }

		// Token: 0x04000191 RID: 401
		[CompilerGenerated]
		private static string \u000C;

		// Token: 0x04000192 RID: 402
		[CompilerGenerated]
		private static IFCVersion \u0018;

		// Token: 0x04000193 RID: 403
		[CompilerGenerated]
		private static string \u0014;

		// Token: 0x04000194 RID: 404
		[CompilerGenerated]
		private static string \u0003;

		// Token: 0x04000195 RID: 405
		[CompilerGenerated]
		private static IFCPhase \u0016;

		// Token: 0x04000196 RID: 406
		[CompilerGenerated]
		private static string \u000F;

		// Token: 0x04000197 RID: 407
		[CompilerGenerated]
		private static string \u0012;

		// Token: 0x04000198 RID: 408
		[CompilerGenerated]
		private static bool \u000D;

		// Token: 0x04000199 RID: 409
		[CompilerGenerated]
		private static bool \u001C;

		// Token: 0x0400019A RID: 410
		[CompilerGenerated]
		private static bool \u0013;

		// Token: 0x0400019B RID: 411
		[CompilerGenerated]
		private static string \u0009;

		// Token: 0x0400019C RID: 412
		[CompilerGenerated]
		private static bool \u000A;

		// Token: 0x0400019D RID: 413
		[CompilerGenerated]
		private static bool \u0020;

		// Token: 0x0400019E RID: 414
		[CompilerGenerated]
		private static bool \u001F;

		// Token: 0x0400019F RID: 415
		[CompilerGenerated]
		private static bool \u0011;

		// Token: 0x040001A0 RID: 416
		[CompilerGenerated]
		private static bool \u0015;

		// Token: 0x040001A1 RID: 417
		[CompilerGenerated]
		private static bool \u0017;

		// Token: 0x040001A2 RID: 418
		[CompilerGenerated]
		private static bool \u001E;

		// Token: 0x040001A3 RID: 419
		[CompilerGenerated]
		private static bool \u0002;

		// Token: 0x040001A4 RID: 420
		[CompilerGenerated]
		private static string \u0004;

		// Token: 0x040001A5 RID: 421
		[CompilerGenerated]
		private static bool \u001D;

		// Token: 0x040001A6 RID: 422
		[CompilerGenerated]
		private static string \u001A;

		// Token: 0x040001A7 RID: 423
		[CompilerGenerated]
		private static string \u000B;

		// Token: 0x040001A8 RID: 424
		[CompilerGenerated]
		private static bool \u0019;

		// Token: 0x040001A9 RID: 425
		[CompilerGenerated]
		private static bool \u0007;

		// Token: 0x040001AA RID: 426
		[CompilerGenerated]
		private static bool \u0010;

		// Token: 0x040001AB RID: 427
		[CompilerGenerated]
		private static bool \u0006;

		// Token: 0x040001AC RID: 428
		[CompilerGenerated]
		private static bool \u0008;

		// Token: 0x040001AD RID: 429
		[CompilerGenerated]
		private static bool \u0001;

		// Token: 0x040001AE RID: 430
		[CompilerGenerated]
		private static bool \u001B;

		// Token: 0x040001AF RID: 431
		[CompilerGenerated]
		private static bool \u0005;

		// Token: 0x040001B0 RID: 432
		[CompilerGenerated]
		private static bool \u000E;

		// Token: 0x040001B1 RID: 433
		[CompilerGenerated]
		private static double \u000C\u0018;

		// Token: 0x040001B2 RID: 434
		[CompilerGenerated]
		private static bool \u0018\u0018;

		// Token: 0x040001B3 RID: 435
		[CompilerGenerated]
		private static bool \u0014\u0018;

		// Token: 0x040001B4 RID: 436
		[CompilerGenerated]
		private static bool \u0003\u0018;

		// Token: 0x040001B5 RID: 437
		[CompilerGenerated]
		private static string \u0016\u0018;
	}
}
