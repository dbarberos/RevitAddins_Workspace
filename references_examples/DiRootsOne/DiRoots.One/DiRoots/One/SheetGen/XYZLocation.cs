using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002C7 RID: 711
	public class XYZLocation
	{
		// Token: 0x06001CFC RID: 7420 RVA: 0x000B76D0 File Offset: 0x000B58D0
		public XYZLocation()
		{
		}

		// Token: 0x06001CFD RID: 7421 RVA: 0x000B76E4 File Offset: 0x000B58E4
		public XYZLocation(XYZ p)
		{
			\u0001\u001B\u0016.\u0007(this, \u000D\u001F\u0007.\u000A(p));
			\u0015\u001B\u0016.\u0007(this, \u001C\u001F\u0007.\u000A(p));
			\u000C\u001B\u0016.\u0007(this, \u0003\u000A\u0007.\u000A(p));
		}

		// Token: 0x17000826 RID: 2086
		// (get) Token: 0x06001CFE RID: 7422 RVA: 0x000B7724 File Offset: 0x000B5924
		// (set) Token: 0x06001CFF RID: 7423 RVA: 0x000B7738 File Offset: 0x000B5938
		public double X { get; set; }

		// Token: 0x17000827 RID: 2087
		// (get) Token: 0x06001D00 RID: 7424 RVA: 0x000B774C File Offset: 0x000B594C
		// (set) Token: 0x06001D01 RID: 7425 RVA: 0x000B7760 File Offset: 0x000B5960
		public double Y { get; set; }

		// Token: 0x17000828 RID: 2088
		// (get) Token: 0x06001D02 RID: 7426 RVA: 0x000B7774 File Offset: 0x000B5974
		// (set) Token: 0x06001D03 RID: 7427 RVA: 0x000B7788 File Offset: 0x000B5988
		public double Z { get; set; }

		// Token: 0x06001D04 RID: 7428 RVA: 0x000B779C File Offset: 0x000B599C
		public XYZ GetLocationForRevit()
		{
			return \u001B\u001F\u0007.\u000A(\u001F\u0019\u0016.\u001D(this), \u0009\u0004\u0016.\u001D(this), \u0009\u001B\u0016.\u0007(this));
		}

		// Token: 0x04000B9E RID: 2974
		[CompilerGenerated]
		private double \u001F;

		// Token: 0x04000B9F RID: 2975
		[CompilerGenerated]
		private double \u000A;

		// Token: 0x04000BA0 RID: 2976
		[CompilerGenerated]
		private double \u0007;
	}
}
