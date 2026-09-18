using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.ViewRange.Model;

namespace DiRoots.One.ViewRange
{
	// Token: 0x0200028E RID: 654
	public class ViewInformation : ModelBase
	{
		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x06001974 RID: 6516 RVA: 0x000A4D1C File Offset: 0x000A2F1C
		// (set) Token: 0x06001975 RID: 6517 RVA: 0x000A4D30 File Offset: 0x000A2F30
		public View ViewPlan { get; set; }

		// Token: 0x170006FB RID: 1787
		// (get) Token: 0x06001976 RID: 6518 RVA: 0x000A4D44 File Offset: 0x000A2F44
		// (set) Token: 0x06001977 RID: 6519 RVA: 0x000A4D58 File Offset: 0x000A2F58
		public UpdatedIconChange UpdateStatus
		{
			get
			{
				return this.OC;
			}
			set
			{
				this.OC = value;
				\u0007\u0013\u000A.\u000A(this, "UpdateStatus");
			}
		}

		// Token: 0x170006FC RID: 1788
		// (get) Token: 0x06001978 RID: 6520 RVA: 0x000A4D78 File Offset: 0x000A2F78
		// (set) Token: 0x06001979 RID: 6521 RVA: 0x000A4D8C File Offset: 0x000A2F8C
		public bool IsSelected
		{
			get
			{
				return this.VH;
			}
			set
			{
				this.VH = value;
				\u0007\u0013\u000A.\u000A(this, "IsSelected");
			}
		}

		// Token: 0x170006FD RID: 1789
		// (get) Token: 0x0600197A RID: 6522 RVA: 0x000A4DAC File Offset: 0x000A2FAC
		public string ViewName
		{
			get
			{
				return \u0005\u001E\u000A.\u000A(\u0007\u0001\u0005.\u001D(this));
			}
		}

		// Token: 0x170006FE RID: 1790
		// (get) Token: 0x0600197B RID: 6523 RVA: 0x000A4DC8 File Offset: 0x000A2FC8
		// (set) Token: 0x0600197C RID: 6524 RVA: 0x000A4DDC File Offset: 0x000A2FDC
		public ViewType ViewType { get; set; }

		// Token: 0x170006FF RID: 1791
		// (get) Token: 0x0600197D RID: 6525 RVA: 0x000A4DF0 File Offset: 0x000A2FF0
		public string ViewTypeString
		{
			get
			{
				return \u000F\u0011.\u001F(\u0009\u0001\u0005.\u0007(this));
			}
		}

		// Token: 0x17000700 RID: 1792
		// (get) Token: 0x0600197E RID: 6526 RVA: 0x000A4E0C File Offset: 0x000A300C
		// (set) Token: 0x0600197F RID: 6527 RVA: 0x000A4E20 File Offset: 0x000A3020
		public List<LevelInfo> Levels { get; set; } = new List<LevelInfo>();

		// Token: 0x17000701 RID: 1793
		// (get) Token: 0x06001980 RID: 6528 RVA: 0x000A4E34 File Offset: 0x000A3034
		// (set) Token: 0x06001981 RID: 6529 RVA: 0x000A4E48 File Offset: 0x000A3048
		public bool IsEnable { get; set; }

		// Token: 0x17000702 RID: 1794
		// (get) Token: 0x06001982 RID: 6530 RVA: 0x000A4E5C File Offset: 0x000A305C
		// (set) Token: 0x06001983 RID: 6531 RVA: 0x000A4E70 File Offset: 0x000A3070
		public string Warring
		{
			get
			{
				return this.TC;
			}
			set
			{
				this.TC = value;
				\u0007\u0013\u000A.\u000A(this, "Warring");
			}
		}

		// Token: 0x17000703 RID: 1795
		// (get) Token: 0x06001984 RID: 6532 RVA: 0x000A4E90 File Offset: 0x000A3090
		// (set) Token: 0x06001985 RID: 6533 RVA: 0x000A4EA4 File Offset: 0x000A30A4
		public ElevationInfo TopElevation { get; set; } = new ElevationInfo(1);

		// Token: 0x17000704 RID: 1796
		// (get) Token: 0x06001986 RID: 6534 RVA: 0x000A4EB8 File Offset: 0x000A30B8
		// (set) Token: 0x06001987 RID: 6535 RVA: 0x000A4ECC File Offset: 0x000A30CC
		public ElevationInfo BottomElevation { get; set; } = new ElevationInfo(2);

		// Token: 0x17000705 RID: 1797
		// (get) Token: 0x06001988 RID: 6536 RVA: 0x000A4EE0 File Offset: 0x000A30E0
		// (set) Token: 0x06001989 RID: 6537 RVA: 0x000A4EF4 File Offset: 0x000A30F4
		public ElevationInfo CutPlaneElevation { get; set; } = new ElevationInfo(0);

		// Token: 0x17000706 RID: 1798
		// (get) Token: 0x0600198A RID: 6538 RVA: 0x000A4F08 File Offset: 0x000A3108
		// (set) Token: 0x0600198B RID: 6539 RVA: 0x000A4F1C File Offset: 0x000A311C
		public ElevationInfo ViewDepthPlaneElevation { get; set; } = new ElevationInfo(3);

		// Token: 0x04000A14 RID: 2580
		private UpdatedIconChange OC;

		// Token: 0x04000A15 RID: 2581
		private bool VH;

		// Token: 0x04000A16 RID: 2582
		private string TC;

		// Token: 0x04000A17 RID: 2583
		[CompilerGenerated]
		private View IC;

		// Token: 0x04000A18 RID: 2584
		[CompilerGenerated]
		private ViewType M;

		// Token: 0x04000A19 RID: 2585
		[CompilerGenerated]
		private List<LevelInfo> QC;

		// Token: 0x04000A1A RID: 2586
		[CompilerGenerated]
		private bool AC;

		// Token: 0x04000A1B RID: 2587
		[CompilerGenerated]
		private ElevationInfo GC;

		// Token: 0x04000A1C RID: 2588
		[CompilerGenerated]
		private ElevationInfo FL;

		// Token: 0x04000A1D RID: 2589
		[CompilerGenerated]
		private ElevationInfo RL;

		// Token: 0x04000A1E RID: 2590
		[CompilerGenerated]
		private ElevationInfo DL;
	}
}
