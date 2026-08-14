using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.SpatialElementViews.Enums;
using DiRoots.SpatialElementViews.Models;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000082 RID: 130
	public class SectionData : SectionViewSettings
	{
		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x00020400 File Offset: 0x0001E600
		// (set) Token: 0x0600058F RID: 1423 RVA: 0x00020414 File Offset: 0x0001E614
		public List<Boundary> Boundaries { get; set; }

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x00020428 File Offset: 0x0001E628
		// (set) Token: 0x06000591 RID: 1425 RVA: 0x0002043C File Offset: 0x0001E63C
		public ElementId SectionTypeId { get; set; }

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x00020450 File Offset: 0x0001E650
		// (set) Token: 0x06000593 RID: 1427 RVA: 0x00020464 File Offset: 0x0001E664
		public ElementId ElevationTypeId { get; set; }

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x00020478 File Offset: 0x0001E678
		// (set) Token: 0x06000595 RID: 1429 RVA: 0x0002048C File Offset: 0x0001E68C
		public ViewDetailLevel DetailLevel { get; set; }

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000596 RID: 1430 RVA: 0x000204A0 File Offset: 0x0001E6A0
		// (set) Token: 0x06000597 RID: 1431 RVA: 0x000204B4 File Offset: 0x0001E6B4
		public SortingDirections SortingDirection { get; set; }

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000598 RID: 1432 RVA: 0x000204C8 File Offset: 0x0001E6C8
		// (set) Token: 0x06000599 RID: 1433 RVA: 0x000204DC File Offset: 0x0001E6DC
		public int ClockOrder { get; set; }

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x000204F0 File Offset: 0x0001E6F0
		// (set) Token: 0x0600059B RID: 1435 RVA: 0x00020504 File Offset: 0x0001E704
		public bool ClockWised { get; set; } = true;

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x00020518 File Offset: 0x0001E718
		// (set) Token: 0x0600059D RID: 1437 RVA: 0x0002052C File Offset: 0x0001E72C
		public double SectionHeight { get; set; }

		// Token: 0x04000220 RID: 544
		[CompilerGenerated]
		private List<Boundary> T;

		// Token: 0x04000221 RID: 545
		[CompilerGenerated]
		private ElementId I;

		// Token: 0x04000222 RID: 546
		[CompilerGenerated]
		private ElementId Q;

		// Token: 0x04000223 RID: 547
		[CompilerGenerated]
		private ViewDetailLevel A;

		// Token: 0x04000224 RID: 548
		[CompilerGenerated]
		private SortingDirections G;

		// Token: 0x04000225 RID: 549
		[CompilerGenerated]
		private int FR;

		// Token: 0x04000226 RID: 550
		[CompilerGenerated]
		private bool RR;

		// Token: 0x04000227 RID: 551
		[CompilerGenerated]
		private double DR;
	}
}
