using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x0200011B RID: 283
	internal class \u001A\u0005
	{
		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000AB5 RID: 2741 RVA: 0x00045F40 File Offset: 0x00044140
		// (set) Token: 0x06000AB6 RID: 2742 RVA: 0x00045F54 File Offset: 0x00044154
		public ElementId TextElementID { get; set; }

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000AB7 RID: 2743 RVA: 0x00045F68 File Offset: 0x00044168
		// (set) Token: 0x06000AB8 RID: 2744 RVA: 0x00045F7C File Offset: 0x0004417C
		public XYZ TextOriginalLocation { get; set; }

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000AB9 RID: 2745 RVA: 0x00045F90 File Offset: 0x00044190
		// (set) Token: 0x06000ABA RID: 2746 RVA: 0x00045FA4 File Offset: 0x000441A4
		public XYZ TextNewLocation { get; set; }

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000ABB RID: 2747 RVA: 0x00045FB8 File Offset: 0x000441B8
		// (set) Token: 0x06000ABC RID: 2748 RVA: 0x00045FCC File Offset: 0x000441CC
		public int Justification { get; set; }

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06000ABD RID: 2749 RVA: 0x00045FE0 File Offset: 0x000441E0
		// (set) Token: 0x06000ABE RID: 2750 RVA: 0x00045FF4 File Offset: 0x000441F4
		public double TextAngle { get; set; }

		// Token: 0x0400044D RID: 1101
		[CompilerGenerated]
		private ElementId \u001F;

		// Token: 0x0400044E RID: 1102
		[CompilerGenerated]
		private XYZ \u000A;

		// Token: 0x0400044F RID: 1103
		[CompilerGenerated]
		private XYZ \u0007;

		// Token: 0x04000450 RID: 1104
		[CompilerGenerated]
		private int \u001D;

		// Token: 0x04000451 RID: 1105
		[CompilerGenerated]
		private double \u0004;
	}
}
