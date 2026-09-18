using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.ViewRange.Model
{
	// Token: 0x02000295 RID: 661
	public class ElevationInfo : ModelBase
	{
		// Token: 0x060019F4 RID: 6644 RVA: 0x000A7820 File Offset: 0x000A5A20
		public ElevationInfo(PlanViewPlane viewPlaneType)
		{
			\u0018\u0007\u0016.\u000A(this, viewPlaneType);
		}

		// Token: 0x17000723 RID: 1827
		// (get) Token: 0x060019F5 RID: 6645 RVA: 0x000A783C File Offset: 0x000A5A3C
		// (set) Token: 0x060019F6 RID: 6646 RVA: 0x000A7850 File Offset: 0x000A5A50
		public double Offset
		{
			get
			{
				return this.YL;
			}
			set
			{
				this.YL = value;
				\u0007\u0013\u000A.\u000A(this, "Offset");
			}
		}

		// Token: 0x17000724 RID: 1828
		// (get) Token: 0x060019F7 RID: 6647 RVA: 0x000A7870 File Offset: 0x000A5A70
		// (set) Token: 0x060019F8 RID: 6648 RVA: 0x000A7884 File Offset: 0x000A5A84
		public List<LevelInfo> Levels { get; set; }

		// Token: 0x17000725 RID: 1829
		// (get) Token: 0x060019F9 RID: 6649 RVA: 0x000A7898 File Offset: 0x000A5A98
		// (set) Token: 0x060019FA RID: 6650 RVA: 0x000A78AC File Offset: 0x000A5AAC
		public LevelInfo Level
		{
			get
			{
				return this.HL;
			}
			set
			{
				this.HL = value;
				\u0007\u0013\u000A.\u000A(this, "Level");
			}
		}

		// Token: 0x17000726 RID: 1830
		// (get) Token: 0x060019FB RID: 6651 RVA: 0x000A78CC File Offset: 0x000A5ACC
		// (set) Token: 0x060019FC RID: 6652 RVA: 0x000A78E0 File Offset: 0x000A5AE0
		public PlanViewPlane ViewPlaneType { get; set; }

		// Token: 0x060019FD RID: 6653 RVA: 0x000A78F4 File Offset: 0x000A5AF4
		public double GetElevationWithOffset(UnitConverter unitConverter)
		{
			return \u000A\u001F\u0016.\u000A(\u001F\u0001\u0005.\u001D(this)) + \u0014\u0015\u0005.\u000A(unitConverter, \u0013\u0015\u0005.\u001D(this));
		}

		// Token: 0x04000A4B RID: 2635
		private LevelInfo HL;

		// Token: 0x04000A4C RID: 2636
		private double YL;

		// Token: 0x04000A4D RID: 2637
		[CompilerGenerated]
		private List<LevelInfo> QC;

		// Token: 0x04000A4E RID: 2638
		[CompilerGenerated]
		private PlanViewPlane CL;
	}
}
