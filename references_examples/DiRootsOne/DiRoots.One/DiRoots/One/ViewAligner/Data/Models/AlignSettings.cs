using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DiRoots.Revit.SheetsAndViews.Models;

namespace DiRoots.One.ViewAligner.Data.Models
{
	// Token: 0x020000D3 RID: 211
	public class AlignSettings
	{
		// Token: 0x17000219 RID: 537
		// (get) Token: 0x060007F9 RID: 2041 RVA: 0x0002E148 File Offset: 0x0002C348
		// (set) Token: 0x060007FA RID: 2042 RVA: 0x0002E15C File Offset: 0x0002C35C
		public ViewInfo ReferenceView { get; set; }

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x060007FB RID: 2043 RVA: 0x0002E170 File Offset: 0x0002C370
		// (set) Token: 0x060007FC RID: 2044 RVA: 0x0002E184 File Offset: 0x0002C384
		public List<ViewInfo> TargetViews { get; set; }

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x060007FD RID: 2045 RVA: 0x0002E198 File Offset: 0x0002C398
		// (set) Token: 0x060007FE RID: 2046 RVA: 0x0002E1AC File Offset: 0x0002C3AC
		public AlignmentMode AlignmentMode { get; set; }

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x060007FF RID: 2047 RVA: 0x0002E1C0 File Offset: 0x0002C3C0
		// (set) Token: 0x06000800 RID: 2048 RVA: 0x0002E1D4 File Offset: 0x0002C3D4
		public bool ApplyScopeBox { get; set; }

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000801 RID: 2049 RVA: 0x0002E1E8 File Offset: 0x0002C3E8
		// (set) Token: 0x06000802 RID: 2050 RVA: 0x0002E1FC File Offset: 0x0002C3FC
		public bool AlignTitles { get; set; }

		// Token: 0x0400032B RID: 811
		[CompilerGenerated]
		private ViewInfo \u001F;

		// Token: 0x0400032C RID: 812
		[CompilerGenerated]
		private List<ViewInfo> \u000A;

		// Token: 0x0400032D RID: 813
		[CompilerGenerated]
		private AlignmentMode \u0007;

		// Token: 0x0400032E RID: 814
		[CompilerGenerated]
		private bool \u001D;

		// Token: 0x0400032F RID: 815
		[CompilerGenerated]
		private bool \u0004;
	}
}
