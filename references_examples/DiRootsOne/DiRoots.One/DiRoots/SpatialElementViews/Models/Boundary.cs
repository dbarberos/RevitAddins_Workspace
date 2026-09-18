using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;

namespace DiRoots.SpatialElementViews.Models
{
	// Token: 0x0200003F RID: 63
	public class Boundary
	{
		// Token: 0x060001F9 RID: 505 RVA: 0x0000A590 File Offset: 0x00008790
		public Boundary()
		{
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000A5A4 File Offset: 0x000087A4
		public Boundary(Line line, double offset, XYZ outwardDirection)
		{
			\u001D\u001F\u0007.\u000A(this, line);
			\u0007\u001F\u0007.\u000A(this, offset);
			\u000A\u001F\u0007.\u000A(this, outwardDirection);
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001FB RID: 507 RVA: 0x0000A5CC File Offset: 0x000087CC
		// (set) Token: 0x060001FC RID: 508 RVA: 0x0000A5E0 File Offset: 0x000087E0
		public Line Line { get; set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001FD RID: 509 RVA: 0x0000A5F4 File Offset: 0x000087F4
		// (set) Token: 0x060001FE RID: 510 RVA: 0x0000A608 File Offset: 0x00008808
		public double Offset { get; set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001FF RID: 511 RVA: 0x0000A61C File Offset: 0x0000881C
		// (set) Token: 0x06000200 RID: 512 RVA: 0x0000A630 File Offset: 0x00008830
		public XYZ OutwardDirection { get; set; }

		// Token: 0x040000E3 RID: 227
		[CompilerGenerated]
		private Line \u001F;

		// Token: 0x040000E4 RID: 228
		[CompilerGenerated]
		private double \u000A;

		// Token: 0x040000E5 RID: 229
		[CompilerGenerated]
		private XYZ \u0007;
	}
}
