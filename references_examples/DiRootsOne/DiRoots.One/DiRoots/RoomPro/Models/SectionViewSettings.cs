using System;
using DiRoots.One.Commons.ExtensibleStorage;
using DiRoots.RoomPro.Interfaces;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000084 RID: 132
	[Schema("6238FA9F-29CC-47A6-AA45-67D3AE3C4CF3", "SectionViewSettings")]
	[Serializable]
	public class SectionViewSettings : IModelSettings, IRevitEntity
	{
		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x00020630 File Offset: 0x0001E830
		// (set) Token: 0x060005AB RID: 1451 RVA: 0x00020644 File Offset: 0x0001E844
		[Field]
		public ModelViewType SectionType { get; set; }

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x00020658 File Offset: 0x0001E858
		// (set) Token: 0x060005AD RID: 1453 RVA: 0x0002066C File Offset: 0x0001E86C
		[Field]
		public ModelViewType ElevationType { get; set; }

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060005AE RID: 1454 RVA: 0x00020680 File Offset: 0x0001E880
		// (set) Token: 0x060005AF RID: 1455 RVA: 0x00020694 File Offset: 0x0001E894
		[Field]
		public int Scale { get; set; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x000206A8 File Offset: 0x0001E8A8
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x000206BC File Offset: 0x0001E8BC
		[Field]
		public int ViewDetailLevel { get; set; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x000206D0 File Offset: 0x0001E8D0
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x000206E4 File Offset: 0x0001E8E4
		[Field]
		public ModelPhase Phase { get; set; }

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x000206F8 File Offset: 0x0001E8F8
		// (set) Token: 0x060005B5 RID: 1461 RVA: 0x0002070C File Offset: 0x0001E90C
		[Field]
		public ViewTemplate ViewTemplate { get; set; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060005B6 RID: 1462 RVA: 0x00020720 File Offset: 0x0001E920
		// (set) Token: 0x060005B7 RID: 1463 RVA: 0x00020734 File Offset: 0x0001E934
		[Field]
		public bool UseOneSingleMarker { get; set; }

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x00020748 File Offset: 0x0001E948
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x0002075C File Offset: 0x0001E95C
		[Field]
		public string HeightReference { get; set; }

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x00020770 File Offset: 0x0001E970
		// (set) Token: 0x060005BB RID: 1467 RVA: 0x00020784 File Offset: 0x0001E984
		[Field]
		public double AbsoluteSectionHeight { get; set; }

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x00020798 File Offset: 0x0001E998
		// (set) Token: 0x060005BD RID: 1469 RVA: 0x000207AC File Offset: 0x0001E9AC
		[Field]
		public double RelativeSectionHeight { get; set; }

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060005BE RID: 1470 RVA: 0x000207C0 File Offset: 0x0001E9C0
		// (set) Token: 0x060005BF RID: 1471 RVA: 0x000207D4 File Offset: 0x0001E9D4
		[Field]
		public double OffsetBottom { get; set; }

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x000207E8 File Offset: 0x0001E9E8
		// (set) Token: 0x060005C1 RID: 1473 RVA: 0x000207FC File Offset: 0x0001E9FC
		[Field]
		public double OffsetLeft { get; set; }

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060005C2 RID: 1474 RVA: 0x00020810 File Offset: 0x0001EA10
		// (set) Token: 0x060005C3 RID: 1475 RVA: 0x00020824 File Offset: 0x0001EA24
		[Field]
		public double OffsetRight { get; set; }

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060005C4 RID: 1476 RVA: 0x00020838 File Offset: 0x0001EA38
		// (set) Token: 0x060005C5 RID: 1477 RVA: 0x0002084C File Offset: 0x0001EA4C
		[Field]
		public double DistanceBeforeBoundary { get; set; }

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060005C6 RID: 1478 RVA: 0x00020860 File Offset: 0x0001EA60
		// (set) Token: 0x060005C7 RID: 1479 RVA: 0x00020874 File Offset: 0x0001EA74
		[Field]
		public double FarClipOffset { get; set; }

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060005C8 RID: 1480 RVA: 0x00020888 File Offset: 0x0001EA88
		// (set) Token: 0x060005C9 RID: 1481 RVA: 0x0002089C File Offset: 0x0001EA9C
		[Field]
		public double BoundLineTolerance { get; set; }
	}
}
